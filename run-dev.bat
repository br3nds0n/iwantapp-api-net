@ECHO OFF

SET ASPNETCORE_ENVIRONMENT=Development

@ECHO Database starting with docker...

docker-compose up -d database

timeout /nobreak /t 2

@ECHO.

@ECHO IWantApp.API starting...
cd IWantApp.API

dotnet watch run --no-launch-profile

cd ..
