cd /d %~dp0
@ECHO *** Migrating database...
@CALL rake -f %~dp0scripts\rakefile.rb migrate
pause	
