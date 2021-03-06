# Net.Migration.POC
Console application database migration POC (Proof Of Concept), use EF Core without data model, that is, only raw SQL is used to send DML or DDL scripts to database.

The idea of this approach is to allow the [Migration concept](https://medium.com/@joelrodrigues/o-que-s%C3%A3o-database-migrations-f817448870a2) to be used with legacy databases.

Recently the EFMigrationHistory table received an improvement to save more detail information, like bellow:

![image](https://user-images.githubusercontent.com/6843493/150549987-a6afa1c6-8715-4940-ac40-fe0acce9873c.png)

This POC is free to fork and receive improvements (via pull requests).

## How to use

1. Run the [initial scripts](https://github.com/apbertoletti/Net.Migration.POC/blob/master/InitialScripts.sql) to create two new databases (LegacyDB and LegacyDB_Sandbox)

2. Install the [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

3. Clone this [code repository](https://github.com/apbertoletti/Net.Migration.POC.git) (or donwload the Zip)

4. Check the connection string constants in DatabaseContext.cs file, and verify that they are targeting to the corresponding databases
 
5. Add a new migration (choose your preferred approach in the ["EF Migration commands" sessions](https://github.com/apbertoletti/Net.Migration.POC#ef-migration-commands-via-package-manager-console) below). Consider reading this [best practice session](https://github.com/apbertoletti/Net.Migration.POC/blob/master/README.md#migration-best-practices) before.

6. Put your Up and Down script raw SQL in the new migration file created. It could be any kind of script (DML or DDL).

![image](https://user-images.githubusercontent.com/6843493/150584931-8a5f04f5-9384-4a34-a4bc-49c0eabfac8c.png)

7. Run the console application choosing what target database do you want to apply the pending migrations

8. Refresh the target database and check the migration applied

## EF Migration commands (via Package Manager Console)

You can run the follow commands directly on the Package Manager Console in Visual Studio:

1. Set the Startup Project (Solution explorer window) and the Default Project (Package manager console window) to the console migration project

2. Adding new migration
~~~
Add-Migration Name-Of-Your-Migration
~~~


3. Apply all the pending migrations to database (if you don??t want to apply them running the Console Application)
~~~
Update-Database
~~~


4. Removing the last migration
~~~
Remove-Migration
~~~
or
~~~
Remove-Migration -force
~~~


5. Backing to an especific migration on the Database (CAUTION: all subsequent migrations will be rolled back)
~~~
Update-Database Name-Of-Migration-You-Want-Back
~~~
or
~~~
Update-Database -Migration:0 //Number of migration you want to back (zero if rollback all migrations)
~~~


## EF Migration commands (via .Net CLI)

You can run the follow commands directly on the .Net CLI 

1. Navigate to migration project folder before:
~~~
cd .\App.Database
~~~


2. Install the EF Tools is installed as global in your machine:
~~~
dotnet tool install --global dotnet-ef
~~~


3. Adding new migration
~~~
dotnet ef migrations add Name-Of-Your-Migration
~~~
or
~~~
dotnet ef migrations add Name-Of-Your-Migration -force
~~~


4. Apply all the pending migrations to database (if you don??t want to apply them running the Console Application)
~~~
dotnet ef database update
~~~


5. Removing the last migration
~~~
dotnet ef migrations remove
~~~


6. Backing to an especific migration on the Database (CAUTION: all subsequent migrations will be rolled back)
~~~
dotnet ef database update Name-Of-Migration-You-Want-Back
~~~
or
~~~
dotnet ef database update -Migration:0 //Number of migration you want to back (zero if rollback all migrations)
~~~


## Migration Best Practices

1. Choose a short and descriptive migration name. Think of this as a git commit message. For example: "Add-Column-Email-ToTable-Customer"
2. Try to use atomic migrations, each one with its context. For example, you need to create a new column and populate it, prefer to add two migrations, one to create the new column and the other to populate its content.
3. If you will no longer be using a migration, remember to remove it from the project (see remove migration command in the ["EF Migration commands" sessions](https://github.com/apbertoletti/Net.Migration.POC#ef-migration-commands-via-package-manager-console) above). Otherwise, the EF will try to apply it again.
4. Avoid trying to rollback (or remove) migrations that have already been committed on the repository. Instead, add a new migration with your scripts to undo what you want.
