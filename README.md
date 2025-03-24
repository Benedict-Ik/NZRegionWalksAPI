Here is what we did in this branch:  

- We began by injecting the interface and its services into Program.cs
```csharp
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
```   

- Next, we injected the service into the `AuthController`'s class' constructor.
- By convention and industry standard, we created a new model class called `LoginResponseDTO` that will take in the newly created JWTToken alongside other possible responses that will be defined later on.
- We used the newly created model to create an instance that can be used to pass the response below:

```csharp
public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
{
var identityUser = await _userManager.FindByEmailAsync(loginRequestDTO.Username);
if (identityUser != null && await _userManager.CheckPasswordAsync(identityUser, loginRequestDTO.Password))
{
    // Get Roles for user
    var roles = await _userManager.GetRolesAsync(identityUser);

    if (roles != null)
    {
        var jwtToken = _tokenRepository.GenerateJWTTokenAsync(identityUser, roles.ToList());

        var response = new LoginResponseDTO
        {
            JWTToken = await jwtToken
        };
        return Ok(response);
    }
}
return BadRequest("Invalid login details.");
}
```

- Once you run the app, it should give a `200` response with the generated token. This signifies that you have been authenticated and authorized.
- Even though you have now been authenticated and authorized into the system, you won't be able to access other methods via SWAGGER until its authentication feature has been enabled. Till then, we will make use of another tool called POSTMAN.
- In POSTMAN, under the "Headers" tab, add an `Authorization` key and input the generated token in the provided field.
- Authorization:
```
Bearer <key>
```
where \<key> is the generated token.  

- Alternatively, navigate to the "Authorization" tab, choose "Bearer Token" from the Auth Type, and in the "Token" field, enter the generated token.

Testing a GET method in Postman
---
1. Select the GET method from the dropdown menu.
2. Enter the URL of the API endpoint, e.g., https://example.com/api/users.
3. Add an Authorization header (as explained above) with a valid token.
4. Send the request.
5. Verify that the response status code is 200 OK and the response body contains the expected user data.


Testing a POST method in Postman
---
1. Select the POST method from the dropdown menu.
2. Enter the URL of the API endpoint, e.g., https://example.com/api/users.
3. Add an Authorization header (as explained above) with a valid token.
4. Add JSON body data, e.g., {"name":"John Doe","email":"john.doe@example.com"}.
5. Send the request.
6. Verify that the response status code is 201 Created and the response body contains the expected user data.

