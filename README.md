Here is what we did in this branch:  

- Here, we are ready to create an ASP .NET MVC Template to consume our already built Web API.
- Within our soultion, we can create a new project of MVC Template.
- To enable both our projects to run concurrently so that the MVC can communicate with the API project: 
    - Right click on Solution  
    - Click on Properties
    - Select the `Configure Startup Projects`
    - Select both the *MVC* and *API* projects' Action as `Start`
    - Click on `Apply`.
- Ensure the `Solution Configuration` dropdown is on `Debug`.
- The above steps will ensure both projects are opened in different browsers (web pages) when you run the app.

![File](file.png)

- Now, since we arealy have git tracking the `API` project, we can as well create a remote repository to do same for the `MVC` project by following the steps below:
    - Create a new repository on Github called `NZRegionWalksMVC`.
    - Copy the URL of the repository.
    - Open the terminal and navigate to the root directory of the project.
    - Run the command `git remote add origin <URL>` to add the remote repository.
    - Run the command `git push -u origin master` to push the project to the remote repository.