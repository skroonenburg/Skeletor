require 'albacore'
require 'version_bumper'

CONFIGURATION = ENV['Configuration'] || "Debug"
SOURCE_FOLDER = "src"
SOLUTION_NAME = "Skeletor"
SOLUTION_FILE = File.join(SOURCE_FOLDER,SOLUTION_NAME) + ".sln"
BUILD_PATH = File.expand_path("build")
TOOLS_PATH = File.expand_path("tools")
TESTS_PATH = File.join(BUILD_PATH,"tests")
NUNIT_PATH = File.join(TOOLS_PATH,"nunit")
FLUENT_MIGRATE_PATH = File.join(TOOLS_PATH,"FluentMigrator")
NUNIT_RUNNER = File.join(NUNIT_PATH,"nunit-console.exe")
LIB_PATH = File.expand_path("lib")
DATABASEMIGRATIONS_NAME = "#{SOLUTION_NAME}.DatabaseMigrations"
DATABASEMIGRATIONS_FOLDER_PATH = File.join(SOURCE_FOLDER,DATABASEMIGRATIONS_NAME)
MIGRATIONASSEMBLY = File.join(DATABASEMIGRATIONS_FOLDER_PATH,"bin\\" + CONFIGURATION + "\\Skeletor.DatabaseMigrations.dll") 
FLUENTMIGRATOR = File.join(FLUENT_MIGRATE_PATH,"migrate.exe") 
CONNECTIONSTRING = "Data Source=localhost;Initial Catalog=Grayskull;Integrated Security=true"

task :default => :unittests

desc "Remove the build folder"
task :clean do
  rmtree BUILD_PATH
end

desc "Prepare the build folder for testing and scripts"
task :preparebuildfolder => :clean do
  FileUtils.mkdir(BUILD_PATH)
  FileUtils.mkdir(TESTS_PATH)
end

desc "Copy test assemblies"
task :copytestsassemblies => :preparebuildfolder  do
  CORE_TESTS_NAME = "#{SOLUTION_NAME}.Core.UnitTests"
  CORE_TESTS_PATH = File.join(SOURCE_FOLDER,CORE_TESTS_NAME)
  CORE_TESTS_BIN_PATH = File.join(CORE_TESTS_PATH, "bin",CONFIGURATION)
  FileUtils.cp_r Dir.glob("#{CORE_TESTS_BIN_PATH}/*.dll"), TESTS_PATH
end

desc "Run unit tests"
nunit :unittests => :copytestsassemblies do |nunit|
  nunit.command = NUNIT_RUNNER
  nunit.assemblies = FileList["#{TESTS_PATH}/*.UnitTests.dll"].exclude(/obj\//)
  nunit.options "/framework=v4.0.30319","/xml=#{TESTS_PATH}/#{CORE_TESTS_NAME}-UnitTests.xml"
end

desc "Increment the version number"
task :updateversion do
  bumper_version.bump_build
  bumper_version.write('VERSION')
end

desc "Generate the AssemblyInfo file"
assemblyinfo :assemblyinfo => :updateversion do |asm|
  asm.version = bumper_version.to_s
  asm.file_version = bumper_version.to_s
  asm.company_name = SOLUTION_NAME
  asm.product_name = SOLUTION_NAME
  asm.copyright = "Blair Davidson, Padgett Rowell, Hendry Luk"
  asm.output_file = File.join(File.join(SOURCE_FOLDER,"shared"), "AssemblyInfo.cs")
end

desc "Compile the solution"
msbuild :build  => [:assemblyinfo] do |msb|
  msb.properties = { :configuration => CONFIGURATION }
  msb.targets = [ :Clean, :Build ]
  msb.verbosity = "minimal"
  msb.solution = SOLUTION_FILE
end

fluentmigrator :migrate => [:build] do |migrator|
    migrator.command = FLUENTMIGRATOR
    migrator.provider = 'sqlserver2008'
    migrator.target = MIGRATIONASSEMBLY
    migrator.connection = CONNECTIONSTRING
end
