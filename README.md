# MillePortfolio & RESTful ProjectApi

## Project Overview

This repository contains two main projects:

1. **MillePortfolio**: A .NET 8.0 web application showcasing a portfolio of projects, featuring information about me and my knowledge, a contact form, and a weather view component. The website is hosted on Azure and can be accessed [Azure link here Portfolio](https://millesportfolio.azurewebsites.net/).

2. **ProjectApi**: A RESTful .NET 8.0 Web API project that provides data about Git projects, utilizing Swashbuckle for API documentation. The API is hosted on Azure and can be accessed [Azure link here to Api](https://milleprojectapi.azurewebsites.net/swagger/index.html).

## MillePortfolio

MillePortfolio is built using .NET 8.0 and Razor Pages. It displays a portfolio of projects and includes interactive components.

### Dependencies

- `Newtonsoft.Json` 13.0.3

### Key Files

- **Index.cshtml.cs**: 
  - Code-behind for the main page, containing a list of `GitProject` objects to be displayed.
  - Handles the contact form, utilizing `System.Net.Mail` and `System.Net` to receive emails.

- **WeatherViewComponent.cs**: 
  - A view component for displaying weather information, using `Microsoft.Extensions.Caching.Memory` for caching and `Newtonsoft.Json` for JSON parsing.

## RESTful ProjectApi

ProjectApi is a RESTful .NET 8.0 web API that serves data about Git projects. It includes data initialization for seeding the database with project data and has two controllers for better SOC (Separation of Concerns) and usability.

### Dependencies

- `Swashbuckle.AspNetCore` 6.4.0
- `Microsoft.AspNetCore.JsonPatch` 6.0.0
- `Newtonsoft.Json` 13.0.3
- `Microsoft.Data.SqlClient` 5.0.0
- `Microsoft.EntityFrameworkCore.Tools` 7.0.0
- `Microsoft.AspNetCore.Authentication.JwtBearer` 8.0.5
- `Microsoft.IdentityModel.Tokens` 7.5.2
- `System.IdentityModel.Tokens.Jwt` 7.5.2

### Key Files

- **GitProjectController.cs**: Handles CRUD operations for Git projects.
- **TechStackController.cs**: Handles CRUD operations for tech stacks.
- **DataInitializer.cs**: Seeds the database with initial data.
- **Program.cs**: The entry point for the RESTful API, configuring services and middleware.

### Database

The API is connected to an Azure SQL Database, ensuring reliable data storage and access.
