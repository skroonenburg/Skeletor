cd /d %~dp0
@ECHO *** Running unit tests...
@CALL rake -f %~dp0scripts\rakefile.rb unittests
pause	
