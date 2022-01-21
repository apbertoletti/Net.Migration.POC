# Net.Migration.POC
Console application database migration POC, use EF Core without data model, that is, only raw SQL is used to send DML or DDL scripts to database.

The idea of this approach is to allow the [Migration concept](https://medium.com/@joelrodrigues/o-que-s%C3%A3o-database-migrations-f817448870a2) to be used with legacy databases, and this console application put in the pipeline DevOps.

This POC is free to fork and receive improvements.

## How to use

1. Adjusts ConnectionString in AppContext.cs file, targeting to database. It can be set from an external settings file (appsettings.json, web.config, app.settings, etc)

3. Install the EF Tools is installed as global in your machine:

~~~
dotnet tool install --global dotnet-ef
~~~

2. Add the migration:

~~~
dotnet ef migrations add Name-Of-Your-Migration
~~~

3. Put your Up and Down script raw SQL in the new migration file created

![image](https://user-images.githubusercontent.com/6843493/131741786-973d5f35-062c-43d4-b193-e312feb21767.png)

4. Run the console application to apply the migrations in your target database.

## EF Migration commands (via Package Manager Console)

You can run the follow commands directly on the Package Manager Console in Visual Studio (remember to set the Default Project to migration project before):

1. Adding new migration
~~~
Add-Migration Name-Of-Your-Migration
~~~


2. Removing the last migration
~~~
Remove-Migration
~~~


3. Backing to an especific migration on the Database
~~~
Update-Database Name-Of-Migration-You-Want-Back
~~~


## EF Migration commands (via .Net CLI)

You can run the follow commands directly on the .Net CLI (remember to navigate to migration project folder before):

1. Adding new migration
~~~
dotnet ef migrations add Name-Of-Your-Migration
~~~


2. Removing the last migration
~~~
dotnet ef migrations remove
~~~


3. Backing to an especific migration on the Database
~~~
dotnet ef database update Name-Of-Migration-You-Want-Back
~~~


