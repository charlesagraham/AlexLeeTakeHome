# AlexLeeTakeHome
Questions 1-2:
Located in the AlexLeeTakeHomeConsole.UtilityLibrary class.  Tests with normal use cases located in the UtilityLibraryTests class in the Tests project.

Question 3:
Located in the AlexLeeTakeHomeConsole.DirectorySearcher class.

SQL Questions:
Located in the relative path AlexLeeTakeHomeConsole\SQL\SQL Answers.sql

MVC Implementation:
Located in the AlexLeeTakeHomeWeb Project.  The connection string is set in the appsettings.json file.

I used database first model generation for the db context and models.  Once that was done, I was able to scaffold the very basic CRUD application.  I then refactored that to put all database code in a service that was then injected into the controller.  I modified the models to add validation based on the database schema and added dtos and view models where needed.
I made the assumption that the search was just text, but there could be arguments made to add search text controls or dropdowns, where applicable.  The CSS is very basic and could be changed for improvement at a later date.

Proposed changes (some may be implemented prior to interview)
1.	Use modal dialogs
2.	Improve search functionality
3.	Fix styling
4.	Expose services in web api and create a React version

