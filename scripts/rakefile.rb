require 'albacore'
require 'version_bumper'

source_folder = "src"
solution_name = "Skeletor"
solution_file = File.join(source_folder,solution_name) + ".sln"



task :default => [:assemblyinfo, :msbuild]

assemblyinfo :assemblyinfo do |asm|
  asm.version = bumper_version.to_s
  asm.file_version = bumper_version.to_s
  asm.company_name = solution_name
  asm.product_name = solution_name
  asm.copyright = "Blair Davidson, Padgett Rowell, Hendry Luk"
  asm.output_file = File.join(File.join(source_folder,"shared"), "AssemblyInfo.cs")
end

msbuild :msbuild do |msb|

  puts solution_file

  msb.properties = { :configuration => :Debug }
  msb.targets = [ :Clean, :Build ]
  msb.solution = solution_file
end
