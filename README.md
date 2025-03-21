### Understanding the differences between Identity DbContext, Identity, and configuring Identity Options

**Identity DbContext**
---
- A DbContext is a class that represents a session with the database.
- Identity DbContext is a specialized DbContext that inherits from IdentityDbContext<TUser> (where TUser is the type of user).
- It provides the database schema for storing user data, roles, and other identity-related information.
- You typically create a custom Identity DbContext class that inherits from IdentityDbContext<TUser> and configure it to use your desired database provider.
- This has already been done in previous branches.  

**Identity**
---
- Identity refers to the ASP.NET Core Identity system, which provides a membership system for managing user data, authentication, and authorization.
- Identity provides features like user registration, login, password reset, and role-based authorization.
- Identity is built on top of the Entity Framework Core and uses the Identity DbContext to store and retrieve user data.  

**Configuring Identty Options**
---
- Configuring Identity Options refers to customizing the behavior of the ASP.NET Core Identity system.
- This includes settings like password requirements, lockout policies, and user confirmation requirements.
- You can configure Identity Options in the Program.cs file, typically in the ConfigureServices method, using the services.Configure<IdentityOptions>(options => { ... }); syntax.

---

In summary, here we added Identity and IdentityOptions to Program.cs  

**Adding Identity**
---
```Csharp
  builder.Services.AddIdentityCore<IdentityRole>()
      .AddRoles<IdentityRole>()
      .AddEntityFrameworkStores<NZRegionWalksAuthDbContext>()
      .AddDefaultTokenProviders();
```
The code  provided aims to add ASP.NET Core Identity to your application, specifically configuring it to use roles.

Here's a breakdown of what each part does:

1. builder.Services.AddIdentityCore<IdentityRole>():

- Adds the core Identity services to the application.
- Specifies IdentityRole as the type of role.

2. .AddRoles<IdentityRole>():

- Adds role-based authorization services to Identity.
- Uses the IdentityRole class to represent roles.

3. .AddEntityFrameworkStores<NZRegionWalksAuthDbContext>():

- Configures Identity to use Entity Framework Core for data storage.
- Specifies NZRegionWalksAuthDbContext as the DbContext to use.

4. .AddDefaultTokenProviders():

- Adds the default token providers for generating tokens (e.g., for password reset, email confirmation).
- Enables features like password reset, email confirmation, and two-factor authentication.

By adding these services, you're setting up ASP.NET Core Identity to manage users, roles, and authorization in your application.  

**Configuring IdentityOptions**
---
```CSharp
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
});
```

The code provided aims to configure the password and user settings for ASP.NET Core Identity.

Here's a breakdown of what each part does:

1. options.Password.RequireDigit = false;:

- Disables the requirement for passwords to contain at least one digit.

2. options.Password.RequireLowercase = false;:

- Disables the requirement for passwords to contain at least one lowercase letter.

3. options.Password.RequireNonAlphanumeric = false;:

- Disables the requirement for passwords to contain at least one non-alphanumeric character (e.g., !, @, #, etc.).

4. options.Password.RequireUppercase = false;:

- Disables the requirement for passwords to contain at least one uppercase letter.

5. options.Password.RequiredLength = 6;:

- Sets the minimum required length for passwords to 6 characters.

6. options.User.RequireUniqueEmail = true;:

- Enables the requirement for users to have a unique email address.

By configuring these settings, you're relaxing the password requirements and enforcing unique email addresses for users in your application.