# AlexLeeTakeHome
Questions 1-2:
Located in the AlexLeeTakeHomeConsole.UtilityLibrary class.  Tests with normal use cases located in the UtilityLibraryTests class in the Tests project.

Question 3:
Located in the AlexLeeTakeHomeConsole.DirectorySearcher class.

SQL Questions:
Located in the relative path AlexLeeTakeHomeConsole\SQL\SQL Answers.sql

MVC Implementation:
Located in the AlexLeeTakeHomeWeb Project.  The connection string is set in the appsettings.json file.

I used database first model generation for the db context and models.  Once that was done, I was able to scaffold the very basic CRUD application.  I then refactored that to put all database code in a service that was then injected into the controller.  I modified the models to add validation based on the database schema and added dtos and view models where needed. I then added search using contains matching on string and equals on numbers.  I then refactored to make sure that the create and update were in their own modal dialog windows using jquery ui.

Database Design Notes:
This table should be normalized and have an Items table with columns Id, Number, and Name, and the original table would just have an ItemId table.  I didn't think that this was in the scope of this exercise, but in the real world, that's what I would do.

Assumptions:
I made the assumption that the search was just text, but there could be arguments made to add search text controls or dropdowns, where applicable.  The CSS is very basic and could be changed for improvement at a later date.

Proposed changes
1. Fix styling
2.	Expose services in web api and create a React version

