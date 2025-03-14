Here is what we did in this branch:

- Added a new `WalksController` class.
- Created a new `CreateWalkDTO` model class in the DTO folder.
- Created a new 'DifficultyDTO' model class in the DTO folder.
- Created a new repository class and interface called `SQLWalkRepository` and `IWalkRepository` respectively.
- Finally, created a new endpoint called `Walks` in the `WalksController` class implementing the actions: GET (to get all walks and a specific walk by Id), POST (to create a new walk), PUT (to update a specific walk based on the Id provided), and DELETE (to delete a specific walk based on the Id provided).
- We added the include() method in the repository class.
- The Include() method in Entity Framework Core is used to eagerly load related data, allowing you to retrieve a specified navigation property along with the main query results.
- Added a new mapping to map between the `Difficylty` and `DifficultyDTO` classes.