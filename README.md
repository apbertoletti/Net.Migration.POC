# Net.Migration.POC
Console application database migration POC, use EF Core without data model, that is, only raw SQL is used to send DML or DDL scripts to database.

The ideia of this approach is allow tbe use with leggacy database, and this console application put in the pipeline DevOps.

## How to use

1. Adjusts ConnectionString in AppContext.cs file, targeting to database. It can be set from an external settings file (appsettings.json, web.config, app.settings, etc)

3. Install the EF Tools is installed as global in you machine:

~~~
dotnet tool install --global dotnet-ef
~~~

2. Add the migration:

~~~
dotnet ef migrations add Name-Of-Your-Migration
~~~

3. Run the console application to apply the migrations in you database.
