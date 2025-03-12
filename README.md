Here is what we did in this branch:

- Implemented the `OnModelCreating` method in the DbContext class to seed the database with the data from the manually inserted data.
- Usually, such files are inserted from JSON files.
- Finally, we created new migrations to ensure the newly inserted data is populated to the database.