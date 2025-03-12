Here is what we did in this branch:

- Implemented the `OnModelCreating` method in the DbContext class to seed the database with the manually inserted data for Difficulties and Regions.
- Usually, such data are inserted from JSON files.
- Finally, we created new migrations to ensure the newly inserted data is populated to the database.