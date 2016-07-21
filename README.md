# ASP.NET Core & EntityFramework Core Based Startup Template

This template is a simple startup project to start with ABP
using ASP.NET Core and EntityFramework Core.

## Prerequirements

* Visual Studio 2015 (Install Update3 if not installed: https://www.visualstudio.com/news/releasenotes/vs2015-update3-vs)
* ASP.NET Core (Install here: https://go.microsoft.com/fwlink/?LinkId=817245)
* SQL Server

## How To Run

* Open solution in Visual Studio 2015
* Set .Web project as Startup Project
* Run database migrations
  * Open command line
  * Locate to the folder contains .EntityFrameworkCore project
  * Run "dotnet ef database update" command from console.
* Add a few product to Products table in the database.
* Run the application.
