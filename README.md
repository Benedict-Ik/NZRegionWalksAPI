Here is what we did in this branch:

- Added model validations to endpoints in the Controller.
- We are only applying validations to the DTOs that are accessed by or returned to the client in the controller class
- Modified RegionsController.cs to include model validations in the `CreateRegions()` and `UpdateRegions()`.
- We did this by:
  - Putting data annotations such as `[Required]`, `[MinLength(n)]` and `[MaxLength(n)]` attributes on the `Code` and `Name` properties in the `Region` class, where `n` is the integer value desired.
  - Next, we added the following code to the RegionsController.cs file:
	```csharp
	if (!ModelState.IsValid)
	{
		return BadRequest(ModelState);
	}
	return <Code>;
		/* `Code` is the actual code to be executed if the model state is valid. */
	```
- Added nullability `?` to certain properties in model classes that are not required.