Here is what we did in this branch:  

- First removed the [Authorize] attribute from controller level and placed them in individual action methods.
- Enabled `Authentication` feature in Swagger UI.
- To enable this, we have to modify the `AddSwaggerGen()` method in the `Program.cs` file.
- Below is the modified method
```csharp
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "NZRegionWalksAPI", Version = "v1" });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme,
                },
                Scheme = "oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header,
            },
            new List<string> ()
        },
    });
});
```

Steps in Running Authentication in Swagger UI
---
Step 1: Open Swagger UI  
Run the application to open Swagger UI.

Step 2: Click on the "Authorize" Button  
Click on the Authorize button located in the top right corner of the Swagger UI page.

Step 3: Enter the JWT Token  
Enter the JWT token obtained from your authentication endpoint (e.g., /api/token) in the Value field. 
```sh
Bearer <JWT Token>
```
where \<JWT Token> is the token obtained from the authentication endpoint.

Step 4: Click on the "Authorize" Button  
Click on the Authorize button to authenticate.

Step 5: Test Authenticated Endpoints  
You can now test authenticated endpoints by clicking on the endpoint and then clicking the Try it out button.

The authenticated endpoint will use the JWT token to authenticate the request.




Explaining the above code
---
**builder.Services.AddSwaggerGen(options => { ... });**
- builder.Services: This is a reference to the IServiceCollection instance, which is used to register services in the ASP.NET Core application.
- AddSwaggerGen: This method adds Swagger generation services to the application.
- options => { ... }: This is a lambda expression that configures the Swagger generation options.

**options.SwaggerDoc("v1", new OpenApiInfo { ... });**
- SwaggerDoc: This method adds a Swagger document to the application.
- "v1": This is the version of the Swagger document.
- new OpenApiInfo { ... }: This creates a new instance of OpenApiInfo, which contains metadata about the API.
    - Title = "NZRegionWalksAPI": Sets the title of the API.
    - Version = "v1": Sets the version of the API.

**options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme { ... });**
- AddSecurityDefinition: This method adds a security definition to the Swagger document.
- JwtBearerDefaults.AuthenticationScheme: This is the authentication scheme for JWT Bearer tokens.
- new OpenApiSecurityScheme { ... }: This creates a new instance of OpenApiSecurityScheme, which defines the security scheme.
    - Name = "Authorization": Sets the name of the security scheme.
    - In = ParameterLocation.Header: Specifies that the security scheme is applied to the Authorization header.
    - Type = SecuritySchemeType.ApiKey: Specifies that the security scheme is an API key.
    - Scheme = JwtBearerDefaults.AuthenticationScheme: Specifies the authentication scheme.

**options.AddSecurityRequirement(new OpenApiSecurityRequirement { ... });**
- AddSecurityRequirement: This method adds a security requirement to the Swagger document.
- new OpenApiSecurityRequirement { ... }: This creates a new instance of OpenApiSecurityRequirement, which defines the security requirement.
    - new List<string> (): This creates an empty list of scopes.
    - new OpenApiSecurityScheme { ... }: This creates a new instance of OpenApiSecurityScheme, which references the security scheme defined earlier.
        - Reference = new OpenApiReference { ... }: This creates a new instance of OpenApiReference, which references the security scheme.
            - Type = ReferenceType.SecurityScheme: Specifies the type of reference.
            - Id = JwtBearerDefaults.AuthenticationScheme: Specifies the ID of the security scheme.
        - Scheme = "oauth2": Specifies the authentication scheme.
        - Name = JwtBearerDefaults.AuthenticationScheme: Specifies the name of the security scheme.
        - In = ParameterLocation.Header: Specifies that the security scheme is applied to the Authorization header.

