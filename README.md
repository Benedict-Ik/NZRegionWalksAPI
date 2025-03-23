Here is what we did in this branch:  

- We began by creating a new controller called `AuthController` which will be responsible for handling all the authentication related requests.
- For starters, in this branch, we are only implementing the `register` method which will be responsible for registering a new user.
- The `register` method takes in information such as `Username`, `Password`, and `Roles` and will return a response based on the success or failure of the registration process. Bear in mind that the username is also the user's email.
- To effect the above, we created a new model called `RegisterRequestDTO` which will be responsible for holding the information that will be passed to the `register` method.

**Corrections**
---
- We corrected a typo in our `Program.cs` file where we were using the wrong connection string.
- The modified line is:
```csharp
// Injecting Application DbContext
builder.Services.AddDbContext<NZRegionWalksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZRegionWalksConnection"));
});

// Injecting Identity DbContext
builder.Services.AddDbContext<NZRegionWalksAuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZRegionWalksAuthConnection"));
});
```

- Once all these have been effected, you can go ahead to test the Register method of the `Auth` endpoint. 
- If successful, you should see a response similar to the one below:
```json
 "User was registered successfully"
```
