Here is what we did in this branch:

- Here, we implemented the Repository Pattern approach.
- Created a separate folder for repsitory and modified Region controller class.
- Also demonstrated how we can migrate between different data sources.
- InMemoryRepository.cs was deleted here as it was having build errors as a result of non-implementation of certain defined interfaces.
- For every method defined in the IRegionRepository interface, we have implemented the same in the InMemoryRepository class.
- Made use of anonymous objects to return data from the repository.