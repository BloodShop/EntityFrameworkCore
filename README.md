# EntityFrameworkCore
Entity Framework Core is an Object-Relational Mapper that simplifies working with relational databases using strongly-typed .NET objects.

## Required NuGet packages
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.SqlServer

#### Using different DataBase provider with EF Core requires another package
- Microsoft.EntityFrameworkCore.Sqlite (OS: DB Browser for SQLite)
- Microsoft.EntityFrameworkCore.Postgre (OS: pgAdmin4)
- Microsoft.EntityFrameworkCore.Cosmos (OS: Azure Cosmos DB)

## Create DB from VisualStudio / VScode
- Create models folder with simple Entities
- Initialize the properties as UU / PK / FK / NN etc..
- Create a DataContext class that derives from DbContext (represents a combination of the Unit Of Work and Repository patterns)
- The DataContext class will include the DbSets of the entities we have created in our Model diractory and an ovveriden method `OnConfiguring`.
```Javascript
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // UseSqlServer - option 1
    if (!optionsBuilder.IsConfigured)
    {
       optionsBuilder.UseSqlServer("Connection String");
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    }

    // Use PostgreSql - option 2
    optionsBuilder.UseNpgsql("Connection String");

    // Use Sqlite - option 3
    optionsBuilder.UseSqlite("Data Source=DBName.db");
    
    // Use Azure Cosmos DB - option 4
    optionsBuilder.UseCosmos("Connection String", "<DatabaseContextName>");
}
```
  
## Create Migration Tool 
EF Core migrations feature is a tool that makes it easy to create and evolve our db

Visual Studio Package manager console
  1. `Add-Migration Initialization`
  2. `Update-Database`
  
VS code Terminal
  1. `dotnet tool install -g dotnet-ef`
  2. `dotnet ef migrations add Initialization`
  3. `dotnet ef database update`

*Inorder to update the database after adding the new property / entity just repeat the initilization steps*

After following those steps, Set and Create out database Context in program.cs
> Before Running 
> By default visual studio wants to start the app in a different directory than the build directory. If it does that our app won't find the database. In order to fix it we need to add a start working diractory element to the csProj.
> Double click the Project --> Add this line of code to the **PropertyGroup**
>
> `<StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory>`

# ReverseEnginereeing - Using an existing Database and create entity model code
EF Core isn't just for new databases! In this sample, you will learn how to reverse engineer an existing database for use with EF Core.
## Scaffold-DbContext command link
  1. Pass the connection string (can be found in the notes)
  2. Pass the name of the provider (what package you are working with)
  3. Optionally pass the output directories for the DbContext and the Models classes
 
Visual Studio Package manager console
- `Scaffold-DbContext "Connection String Here;" Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Models/Generated -ContextNamespace <NamespaceName>.Data -Namespace <NamespaceName>.Models`

.NET CLI
- `dotnet ef dbcontext scaffold "Connection String Here;" Microsoft.EntityFrameworkCore.SqlServer --ContextDir Data --OutputDir Models/Generated --ContextNamespace <NamespaceName>.Data --Namespace <NamespaceName>.Models`

*The seperation with the Generated Directory allows us create partial classes to contain our additional logic*
