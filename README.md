Here is what we did in this branch:  

- Since the Register() method ensures we have the newly created user in the database, we use the `Login()` method to log in the user with the `Username` and `Password` defined.
- If confirmed to be registered, we grant them access to our system as an authorized user.
- We defined a model class called `LoginRequestDTO` that presents the specified parameters to the user.
- If the user enters a valid username and password, we return:

```csharp
"User logged in successfully."
```

- If the user enters an invalid username and password, we return:
```csharp
"Invalid login details."
```