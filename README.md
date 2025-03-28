Here is what we did in this branch:  

- By default, ASP .NET Core is unable to serve static files. 
- To enable this functionality, we added the following code just below the `app.UseAuthentication()` and `app.UseAuthorization` lines of code in the `Program.cs` file:
```csharp
 app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});
```
- Now, if you copy the FilePath of an image from the database and paste it in the browser, the image will be displayed.
- Note however that to serve a Static File, you must have your API running.