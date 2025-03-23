Here is what we did in this branch:  

- Here, we created a repository for the token management to avoid cluttering our `AuthController` class and encourage separation of concerns.
- We first created an interface called `ITokenRepository` with `GenerateJWTTokenAsync()` method. 
- Afterwards, we then implemented the repository in a separate class called `TokenRepository`.  
---
Below is a step-by-step breakdown of what the implemented method - `GenerateJWTTokenAsync()` does:

1. Create claims: The method starts by creating a list of claims, which are statements about the user. It adds the user's email as a claim.

2. Add role claims: It then iterates through the list of roles passed as an argument and adds each role as a separate claim.

3. Create a secret key: The method retrieves a secret key from the application's configuration settings, which is used for signing the token.

4. Create signing credentials: It creates signing credentials using the secret key and a specific security algorithm (HMAC SHA256).

5. Generate the JWT token: The method then generates a JWT token, passing in the issuer, audience, claims, expiration time (15 minutes), and signing credentials.

6. Return the token: Finally, it returns the generated JWT token as a string.

The purpose of this method is to create a secure token that can be used to authenticate and authorize users, incorporating their email and roles.  

---

**Understanding the role of Claims in Authentication**

- Claims are statements about a user that are encoded into a token. They can include information such as the user's email, roles, and other relevant data.
- They are important because they provide a way to convey information about a user from one system to another, allowing for authentication, authorization, and access control.
- A list of claims is created to represent the user's identity and attributes in a structured and standardized way. This list of claims is then embedded in a security token, such as a JSON Web Token (JWT), which is issued to the user after authentication.
- The list of claims typically includes information such as:

	a. User's name and email address
	b. User's roles or group memberships  
	c. User's permissions or access levels  
	d. User's authentication method or factor

- In the context of JWT tokens, claims are encoded into the token payload and can be decoded by the recipient to verify the user's identity and permissions.