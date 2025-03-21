Here is what we did in this branch:

A brief overview of the steps we have carried out so far:  

	1. Installed required NuGet packages (if not already installed)
	2. Created an Identity database context (DBContext) called `NZRegionWalksAuthDbContext` that inherits from IdentityDbContext
	3. Configured Identity services in the `Program.cs` file
	4. In the new class that inherits from IdentityDbContext, we seeded the database with default users and roles.

5. Open Package Manager Console and run Migration command to create the `Auth` database tables.
  
```sh
   Add-Migration Creating Auth Database
 ```

<br>

The above command will fail due to the presence of multiple DbContexts in the project. To fix this, we need to specify the DbContext we want to create the migration for using the -Context parameter. We can do this by running the following command:

```sh
   Add-Migration CreatingAuthDatabase -Context NZRegionWalksAuthDbContext
```  
<br>

At this point, you may run into the following error:

*Unable to create a 'DbContext' of type 'NZRegionWalksAuthDbContext'. The exception 'Failed to load configuration from file <path> was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728*

To fix this, we will need to modify the names of the configuration files in the `appsettings.json` file. We will need to change the names of the configuration files to match the DbContext names. For example, the `appsettings.json` file should look like this:
```json
{
  "ConnectionStrings": {
	"NZRegionWalksDbContext": "Server=(localdb)\\mssqllocaldb;Database=NZRegionWalks;Trusted_Connection=True;MultipleActiveResultSets=true",
	"NZRegionWalksAuthDbContext": "Server=(localdb)\\mssqllocaldb;Database=Auth;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```
<br>  

---
**Important Note**  
- In EF Core, the connection string name must match the DbContext name. If the connection string name does not match the DbContext name, the migration command will fail.
- This is because EF Core uses the connection string name to determine which DbContext to use when creating the migration.
- So, if you have a DbContext named `NZRegionWalksDbContext`, the connection string name must be `NZRegionWalksDbContext` as well.
- Currently, you must have observed we have two DbContext in our project: The Application DbContext `NZRegionWalksDbContext` and the Identity DbContext `NZRegionWalksAuthDbContext`. 
- To run migrations with multiple DbContexts, you'll have to specify the DbContext you want to create the migration for using the -Context parameter, otherwise the migration command will fail.
- For example, to create a migration for the `NZRegionWalksAuthDbContext`, you would run the following command:
```sh
   Add-Migration CreatingAuthDatabase -Context NZRegionWalksAuthDbContext
```
- This will create a migration for the `NZRegionWalksAuthDbContext`.
- To update the database with the necessary tables for the `NZRegionWalksAuthDbContext`, you would run the following command:
```sh
   Update-Database -Context NZRegionWalksAuthDbContext
```
---
Modified connection strings in `appsettings.json` file to match the DbContext names.
```json
{
  "ConnectionStrings": {
	"NZRegionWalksDbContext": "Server=(localdb)\\mssqllocaldb;Database=NZRegionWalks;Trusted_Connection=True;MultipleActiveResultSets=true",
	"NZRegionWalksAuthDbContext": "Server=(localdb)\\mssqllocaldb;Database=Auth;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```  
<br>Modified program.cs file to use the `NZRegionWalksAuthDbContext` for the Identity service.
```csharp
 /* Injecting Application DbContext */*
builder.Services.AddDbContext<NZRegionWalksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZRegionWalksDbContext"));
});

/* Injecting Identity DbContext */
builder.Services.AddDbContext<NZRegionWalksAuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZRegionWalksAuthDbContext"));
});
```
<br>In some instances, when you try to run the migration command, you may encounter the following error:
"*Connection property has not been initialized.*"  

To fix this, you may need to add a `DesignTimeDbContextFactory` class to the project (preferably the data folder). This class will be used by the migration command to create an instance of the DbContext.  

Since migrations are run at design time (and outside the application DI container), the migration command needs a way to create an instance of the DbContext. The `DesignTimeDbContextFactory` class provides a way to create an instance of the DbContext at design time. It helps to provide the necessary configuration for the DbContext to be created at design time.  

In some instances, you may need to rerun the migration command after adding the `DesignTimeDbContextFactory` class to the project.  

After running the `Update-Database` command, you should see the `Auth` database created in the SQL Server Object Explorer with appropriate tables.