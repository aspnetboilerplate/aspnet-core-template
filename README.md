# ASP.NET Core & EntityFramework Core Based Startup Template

This template is a simple startup project to start with ABP
using ASP.NET Core and EntityFramework Core.

## Prerequirements

* Visual Studio 2015
* ASP.NET Core RC2 (Download here: https://go.microsoft.com/fwlink/?LinkId=798481)

## How To Run

* Open solution in Visual Studio 2015
* Set .Web project as Startup Project
* Run database migrations
  * Open command line
  * Locate to the folder contains .EntityFrameworkCore project
  * Run "dotnet ef database update" command from console.
* Add a few product to Products table in the database.
* Run the application.