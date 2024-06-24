# Project Setup and Structure

## Introduction

This project is a movie collection application that allows users to:

- Add movies along with their cast, crew, and genre.
- Create movie selections, which are lists of selected movies.

Users can view other users' movies and movie selections but can only modify their own. 

For creating, updating, and deleting certain entities like Genre and Movie Role, users must have the Admin role. This can be configured in the `SecurityManager` class.

There are tests written for this application, including some integration tests for the API. However, the tests do not cover everything and are primarily written to demonstrate concepts. This application is not a complete production-ready solution and needs improvements for production use.

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