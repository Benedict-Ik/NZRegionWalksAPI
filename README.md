Here is what we did in this branch:

- Basically, here we began setting up packages we'll need for authentication.
- We installed the following:
    - Microsoft.AspNetCore.Authentication.JwtBearer
	- Microsoft.IdentityModel.Tokens
	- System.IdentityModel.Tokens.Jwt
	- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- I added a `Jwt` object in the `appsettings.json` file with the following: Key, Issuer, Audience.
    - Key is the secret key that will be used to sign the JWT token. It is a string comprised of a minimum of 32 alphanumeric random characters. However, for added security, you can use a longer length. It is generally recommended to use a key length that is a multiple of 8 characters to ensure compatibility with various cryptographic algorithms.
	- Issuer is the name of the party that issues the JWT token. It is a string that represents the entity that issues the token. It is generally the name of the application or the service that is issuing the token.
	- Audience is the intended recipient of the JWT token. It is a string that represents the entity that is intended to receive the token. It is generally the name of the application or the service that is intended to receive the token.
- Next, we added the authentication inside the `Program.cs` file before the build() function.