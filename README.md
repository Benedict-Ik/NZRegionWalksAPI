Here is what we did in this branch:

- We added the `[Authorize]` attribute to the methods in the Controller classes that we want to secure. This means that only authenticated users can access the methods within the controller class.
- Alternatively (which was omitted here), we can apply the `[Authorize]` attribute to specific methods within the controller class. This means that only authenticated users can access the specific methods within the controller class.
- In instances where we want to allow anonymous access to a method, we can use the `[AllowAnonymous]` attribute decorated on that method. This means that the method can be accessed by both authenticated and unauthenticated users.
- Based on the above settings, if we tried to access any of the methods that are secured by the `[Authorize]` attribute, we won't be permitted.