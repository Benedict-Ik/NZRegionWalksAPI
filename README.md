Here is what we did in this branch:

- Replaced recurring ModelState validation by creating a folder called `CustomActionFilters` in which I added a file called `ValidateModelAttribute` for custom validations.
- I did this by:
  - Creating a custom attribute called `ValidateModelAttribute` that inherits from `ActionFilterAttribute` and overrides the `OnActionExecuting` method.
  - In the `OnActionExecuting` method, I checked if the model state is valid. If it is not, I returned a `BadRequestObjectResult` with the model state errors.
  - I then added the `ValidateModelAttribute` attribute to the `RegionsController` and `WalksController` classes.