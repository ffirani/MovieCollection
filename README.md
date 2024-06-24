# Project Setup and Structure

## Setup

To run this project, you will need:

- Visual Studio 2022
- MS SQL Server
- Docker Desktop (optional)

You should change the database connection string in the `appsettings.json` file in both the `MovieCollection.Api` and `MovieCollection.API.Test.Integration` projects.

## Overall Structure

This application is based on the CQRS (Command Query Responsibility Segregation) pattern. It includes:

- **Commands for CRUD operations**: Used for creating, reading, updating, and deleting records.
- **Commands for associating and disassociating records**: Used to manage relationships between records.

### Libraries Used

- **FluentValidation**: For validation purposes.
- **MediatR**: For handling commands and queries.