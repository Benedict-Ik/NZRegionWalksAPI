Here is what we did in this branch:

- Here are the brief steps we took to set up an authentication database:

1. Installed required NuGet packages (if not already installed):

    a. Microsoft.AspNetCore.Identity.EntityFrameworkCore:
        This package provides the Entity Framework Core implementation for ASP.NET Core Identity. It allows you to store user data and authentication information in a database using Entity Framework Core.

    b. Microsoft.EntityFrameworkCore.SqlServer (or your preferred database provider):
        This package provides the SQL Server database provider for Entity Framework Core. It allows you to connect to a SQL Server database and perform CRUD (Create, Read, Update, Delete) operations. You can replace this with your preferred database provider (e.g., MySQL, PostgreSQL, etc.).

    c. Microsoft.AspNetCore.Identity.UI (optional):
    This package provides pre-built UI components for ASP.NET Core Identity, such as login, registration, and profile management pages. You can use these components to quickly scaffold a basic authentication system in your application.

2. Created a database context (DBContext):
    - Configure the database connection string in the `appsettings.json` file.
    - Create a new class that inherits from IdentityDbContext

3. Configured Identity:
    - In Program.cs (or Startup.cs), inject IdentityDbContext to the DI container
    - Optional: Configure Identity options (e.g., password requirements)

4. In the new class that inherits from IdentityDbContext, we seeded the database with default users and roles.