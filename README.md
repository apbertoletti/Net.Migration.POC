# Net.Migration.POC
Console application database migration POC, use EF Core without data model, that is, only raw SQL is used to send DML or DDL scripts to database.

The idea of this approach is to allow it to be used with legacy databases, and this console application put in the pipeline DevOps.

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

3. Run the console application to apply the migrations in your database.


