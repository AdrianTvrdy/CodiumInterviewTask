# Codium Interview Task

This project is a solution to the Codium interview task. It demonstrates a full-stack web application with a .NET 8 server and a Blazor client, using Entity Framework Core to manage employee data.

## Requirements

* **.NET 8 SDK:**  [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
* **Microsoft Visual Studio:**  [Download here](https://visualstudio.microsoft.com/downloads/)
* **Microsoft SQL Server Management Studio:** [Download here](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)   



## Getting Started

1. **Database Setup:**
    * **Ensure you have a local instance of SQL Server running.**
    * **Open `appsettings.json` in the `Codium.Interview.EmployeeEvidenceApp.Server` project.**
    * **Modify the `DefaultConnection` connection string to point to your local SQL Server database.**
    * **Open the Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console).**
    * **In the Package Manager Console, set the default project to `Codium.Interview.EmployeeEvidenceApp.Server`.** 
    * **Install the Entity Framework Core tools by running the command `Install-Package Microsoft.EntityFrameworkCore.Tools`**
    * **Run the command `Update-Database` to create the database schema based on your migrations.**

2. **Run the Application:**
    * **Open the solution in Visual Studio.**
    * **Go to `Project -> Configure Startup Projects`.**
    * **Select "Multiple startup projects".**
    * **Set the `Action` to "Start" for both `Codium.Interview.EmployeeEvidenceApp.Client` and `Codium.Interview.EmployeeEvidenceApp.Server` projects.**
    * **Use the small arrows in the "Configure Startup Projects" window to ensure the `Codium.Interview.EmployeeEvidenceApp.Server` project starts before the `Codium.Interview.EmployeeEvidenceApp.Client` project.**
    * **Start debugging.**

## Project Structure

* **Codium.Interview.EmployeeEvidenceApp.Server**: Contains the .NET 8 Web API and Entity Framework Core logic.
* **Codium.Interview.EmployeeEvidenceApp.Client**: Contains the Blazor client-side application.
* **Codium.Interview.EmployeeEvidenceApp.Shared**: Library with entities, DTOs, exceptions, and other shared classes.

## Features
  * **View a list of employees.**
  * **Add new employees.**
  * **Add new positions.**
  * **Edit existing employee details.**
  * **Delete employee records.**
  * **Upload JSON files with employees/positions to the database.** 
