# Halifax Health Inventory Tracker

## NOTE

The Azure Hosting of this Web App has been paused for monetary purposes, however all of the code is still valid to puruse and it can be downloaded and run locally with minor tweaking!

## Overview

This is a cloud hosted web app made within two days (very short scope proof of concept project).

Halifax Health Inventory Tracker is a web application designed to internally manage and track inventory items efficiently. The application allows users to add, edit, and delete inventory items, and view all items in a sortable list. While user authentication was not fully implemented as it wasn't within the required specifications, it was added in an incomplete form to show how easily the project can be elevated and improved.

## Features

- Add, edit, and delete inventory items
- View inventory in a sortable, filterable list
- Built-in (optional) user authentication and registration
- Responsive UI using Bootstrap
- Ready for deployment to Azure

## Technologies Used

- **.NET 8** (ASP.NET Core)
- **Razor Pages** and MVC Controllers
- **Entity Framework Core** (with SQL Server/Azure SQL support)
- **ASP.NET Core Identity** (for authentication)
- **Bootstrap 5** (for responsive design)
- **jQuery & jQuery Validation** (for client-side validation)
- **Azure SQL Database** (recommended for production)

## Use Instructions

**FIRST Go to 'https://halifaxhealthinventorytracker.azurewebsites.net/'.**

**THEN Use the Navigation bar at the top of the page to go to the 'Inventory Items' page to view all items OR the 'Add an Item' page to add a new one.**

## Notes
- User accounts are scaffolded but not required for inventory management. The authentication system can be easily enabled or extended.
- The app uses modern ASP.NET Core best practices, including dependency injection and separation of concerns.

*Built with ASP.NET Core Razor Pages and Entity Framework Core.*
