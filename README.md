Here is what we did in this branch:  

- Here, we are going to learn how to create files or images via our API.
- In future branches, we will create an image domain model that creates an `images` table in our database where we will store the information of image uploads like the name, path, extension, file size etc. in the database.
- Next, we will create a controller method to upload an image which takes a DTO.
- We will also add validations to the accepted extensions ef. if we only want to accept certain file formats and size limit.
- Once the request is validated, we will use repositories to store the image to a local file storage in the API and also save the information to our database.
- Finally, we will return the path to the image so that it can be used by the client.