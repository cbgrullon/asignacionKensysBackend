To execute this project you will need .NET 7, SQL Server and Visual Studio installed in your computer.

After you make sure you have those prerequisites you need to create an empty database in your SQL Server instance.
Then you need to open the solution and go to apsettings.json 
    -After you opened the appsettings.json file you will need to go to ConnectionStrings section and update "AppDb" with your settings(Server, DB and credentials)
Then you need to run this command in the solution path: dotnet ef database update --project asignacionKensysBackend
