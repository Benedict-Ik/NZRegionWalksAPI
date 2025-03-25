Here is what we did in this branch:  

- Here we created a controller class called `ImagesController` which takes in a DTO called 'ImageUploadRequestDTO'.
- Asides from the `UploadImage()` method, we also created a private method `ValidateFileUpload` which helps to validate file extenstion and size.
- Herein, we also made use of ModelState to validate the incoming request.