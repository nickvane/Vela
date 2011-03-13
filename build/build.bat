@echo off
%systemroot%\Microsoft.NET\Framework\v4.0.30319\MSBuild msbuild.proj /p:Configuration=Release;DoRelease=true /fileLoggerParameters:LogFile=msbuild.log;Verbosity=normal;Encoding=UTF-8
if not %errorlevel%==0 pause