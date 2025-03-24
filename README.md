Here is what we did in this branch:  

- In this branch, we hope to implement the Role-Based authentication.
- This will enable those with `reader` role to only read the data, and those with `writer` role to read and write the data.
- For simplicity, a reader role can be used to access the GET methods, and a writer role can be used to access the POST, PUT, and DELETE methods. 
- For starters, we removed the `[Authorize]` attribute at the Controller level and instead placed it at individual action methods.
- Now that our `Authorize` attribute is at the action method level, we can now specify the roles that can access the action method by using the `Roles` parameter.
- Example: For `reader` role:
```csharp
[Authorize(Roles = "Reader")]
```

- Example: For `Writer` role:
```csharp
[Authorize(Roles = "Writer")]
```

- Example: For `Reader` and `Writer` roles:
```csharp
[Authorize(Roles = "Reader, Writer")]
```

- Optionally, you can just use the `[Authorize]` attribute without specifying any roles.

- If you haven't, right now, you can use the `Register()` method to create users with `Reader` and `Writer` roles.
- Then test by accessing accessible and inaccessible methods.
- Whenever you try to access a method you don't have access to, it should return a `403 Forbidden` error.