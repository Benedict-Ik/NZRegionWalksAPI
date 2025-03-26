Here is what we did in this branch:  

- This branch focuses of the creation of the `ImageRepository` class.
- Recall that repositories only deal with domain models. The part we don't want presented to the client (abstraction).
- We first defined an interface called `IImageRepository` with an `Upload()` method to be implemented by the repository.
- In the repository, we present a DTO to the client as the parameter which is then manually mapped to our domain model to enable us store the infirmation in our database.
- Next, we created a local folder in our solution called `Images` which will be where we will store uploaded images.
- After saving the file locally, we want to save the changes to the database, alongside the actual file path of the file.
- To do this, we injected the `IHttpContextAccessor` accessor, which basically provides us with the scheme and the URL to our running application. Before that, we injected the `HttpContextAccessor` in our Program.cs:

```csharp
builder.Services.AddHttpContextAccessor();
```

- Now we can implement our ImageRepository. But before that, we need to add the below line in our Program.cs file:
```csharp
builder.Services.AddScoped<IImageRepository, ImageRepository>();
```

- After implementing the above repository class, you can then go ahead to inject the `IImageRepository` into your Controller class .

Explaining the ImageRepository.cs class
--

**Class Declaration**  
```csharp
public class ImageRepository : IImageRepository
```

- This line declares a new public class named ImageRepository that implements the IImageRepository interface.


**Private Fields**  
```csharp
private readonly IWebHostEnvironment _webHostEnvironment;
private readonly IHttpContextAccessor _httpContextAccessor;
private readonly NZRegionWalksDbContext _dbContext;
```

- These lines declare three private readonly fields:
    - _webHostEnvironment: An instance of IWebHostEnvironment, which provides information about the web hosting environment.
    - _httpContextAccessor: An instance of IHttpContextAccessor, which provides access to the current HTTP context.
    - _dbContext: An instance of NZRegionWalksDbContext, which is a database context class.


**Constructor**
```csharp
public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZRegionWalksDbContext dbContext)
{
    this._webHostEnvironment = webHostEnvironment;
    this._httpContextAccessor = httpContextAccessor;
    this._dbContext = dbContext;
}
```

- This constructor takes three parameters and assigns them to the corresponding private fields.


**UploadImageAsync Method**
```csharp
public async Task<Image> UploadImageAsync(Image image)
{
    // ...
}
```

- This method is an asynchronous task that takes an Image object as a parameter and returns an Image object.


**Local File Path Construction**
```csharp
var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", image.FileName);
```

- This line constructs the local file path by combining the content root path, the "Images" folder, and the file name.


**File Existence Check**
```csharp
if (File.Exists(localFilePath))
{
    throw new Exception("File already exists");
}
```

- This code checks if the file already exists at the constructed local file path. If it does, it throws an exception.


**File Upload**
```csharp
using var stream = new FileStream(localFilePath, FileMode.Create);
await image.File.CopyToAsync(stream);
```

- This code uploads the file to the local file path using a file stream.


**URL Path Construction**
```csharp
var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}";
```

- This line constructs the URL path by combining the scheme, host, path base, and file name.


**Image File Path Update**
```csharp
image.FilePath = urlFilePath;
```

- This line updates the FilePath property of the Image object with the constructed URL path.


**Database Operations**
```csharp
await _dbContext.Images.AddAsync(image);
await _dbContext.SaveChangesAsync();
```

- This code adds the Image object to the database context and saves the changes asynchronously.


**Return Statement**
```csharp
return image;
```

- This line returns the Image object after the upload and database operations are complete.