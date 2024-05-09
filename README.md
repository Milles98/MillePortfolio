

https://milleprojectapi.azurewebsites.net/swagger/index.html

https://millesportfolio.azurewebsites.net/

# MillePortfolio & ProjectApi

## Project Overview

This repository contains two main projects:

1.	ProjectApi: This is a .NET 8.0 Web API project that uses the Swashbuckle.AspNetCore package for API documentation. The API is hosted on Azure and can be accessed here.
2.	MillePortfolio: This is a .NET 8.0 Web project that uses the Newtonsoft.Json package for JSON operations. The website is hosted on Azure and can be accessed here.
   
## MillePortfolio

MillePortfolio is a .NET 8.0 web application that uses Razor Pages. It showcases a portfolio of projects and includes features such as a contact form and a weather view component.

## Dependencies

•	Newtonsoft.Json 13.0.3

## Files

•	Index.cshtml.cs: The code-behind for the main page of the portfolio. It contains a list of GitProject objects that represent the projects to be displayed.

•	Contact.cshtml.cs: The code-behind for the contact form page. It uses System.Net.Mail and System.Net to send emails.

•	WeatherViewComponent.cs: A view component that displays weather information. It uses Microsoft.Extensions.Caching.Memory for caching and Newtonsoft.Json for parsing JSON data.

## ProjectApi

ProjectApi is a .NET 8.0 web API that serves data about Git projects. It includes a data initializer that seeds the database with project data.

## Dependencies

•	Swashbuckle.AspNetCore 6.4.0

## Files

•	GitProjectController.cs: The controller for the GitProject API. It uses Microsoft.AspNetCore.Mvc for action results and ProjectApi.Data for data access.

•	DataInitializer.cs: A static class that seeds the database with project data. It uses ProjectApi.Models for the data models.

•	Program.cs: The entry point for the API. It uses ProjectApi.Data for data access.

## Models

Both projects use a GitProject model that represents a Git project. The model includes a ProjectName property.

## How to Run

1.	Clone the repository.
3.	Open the solution in Visual Studio.
4.	Set the startup projects to MillePortfolio and ProjectApi.
5.	Press F5 to run the projects.
