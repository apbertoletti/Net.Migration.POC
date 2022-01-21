# Net.Migration.POC
Console application database migration POC, use EF Core without data model, that is, only raw SQL is used to send DML or DDL scripts to database.

The idea of this approach is to allow the [Migration concept](https://medium.com/@joelrodrigues/o-que-s%C3%A3o-database-migrations-f817448870a2) to be used with legacy databases.

Recently the EFMigrationHistory table received an improvement to save more detail information, like bellow:

![image](https://user-images.githubusercontent.com/6843493/150549987-a6afa1c6-8715-4940-ac40-fe0acce9873c.png)

This POC is free to fork and receive improvements.

## How to use

1. Create two new databases (LegacyDB and LegacyDB_Sandbox) and runt the [initial scripts](https://github.com/apbertoletti/Net.Migration.POC/blob/master/InitialScripts.sql) in each one

2. Install the [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

3. Clone this [code repository](https://github.com/apbertoletti/Net.Migration.POC.git) (or donwload the Zip)

4. Check the connection string constants in AppContext.cs file, and verify that they are targeting to the corresponding databases
 
5. Add a new migration (choose your preferred approach in the ["EF Migration commands" sessions](https://github.com/apbertoletti/Net.Migration.POC#ef-migration-commands-via-package-manager-console) below)

6. Put your Up and Down script raw SQL in the new migration file created. It could be any kind of script (DML or DDL).

![image](https://user-images.githubusercontent.com/6843493/150584931-8a5f04f5-9384-4a34-a4bc-49c0eabfac8c.png)

7. Run the console application choosing what target database do you want to apply the pending migrations

8. Refresh the target database and check the migration applied

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


3. Backing to an especific migration on the Database (all subsequent migrations will be undone)
~~~
Update-Database Name-Of-Migration-You-Want-Back
~~~
or
~~~
Update-Database -Migration:0 //Number of migration you want to back (zero if rollback all migrations)
~~~


## EF Migration commands (via .Net CLI)

You can run the follow commands directly on the .Net CLI (remember to navigate to migration project folder before):

1. Install the EF Tools is installed as global in your machine:
~~~
dotnet tool install --global dotnet-ef
~~~


2. Adding new migration
~~~
dotnet ef migrations add Name-Of-Your-Migration
~~~


3. Removing the last migration
~~~
dotnet ef migrations remove
~~~


4. Backing to an especific migration on the Database (all subsequent migrations will be undone)
~~~
dotnet ef database update Name-Of-Migration-You-Want-Back
~~~
or
~~~
dotnet ef database update -Migration:0 //Number of migration you want to back (zero if rollback all migrations)
~~~


## Migration Best Practices

1. Choose a short and descriptive migration name. Think of this as a git commit message. For example: "Add-Column-Email-ToTable-Customer"
2. Try to use atomic migrations, each one with its context. For example, you need to create a new column and populate it, prefer to do two migrations, one to create the new column and the other to populate its content.
