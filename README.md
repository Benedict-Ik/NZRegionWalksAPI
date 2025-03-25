Here is what we did in this branch:  

- In our `NZRegionWalksDbContext` class, we added a `DbSet` property for the `Image` entity. This will allow us to query and save `Image` entities to the database.
- Next, we ran the below EF Migrations command via the Package Manager Console to create a new migration that will create the `Images` table in the database:
  ```
  Add-Migration "Adding Images Table" -Context "NZRegionWalksDbContect"
  ```
- The above, if ran successfully, should create a migration file with updated code
- Next, run the below command to update the database:
	```
	Update-Database -Context "NZRegionWalksDbContect"
	```
- Now, you should see the `Images` table in your SQL database.