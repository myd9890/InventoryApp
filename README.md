
# InventoryApp

## Introduction
InventoryApp is an **ASP.NET Core 8.0 MVC** web application for managing inventory.  
It uses **Entity Framework Core** with a **SQL Server** database for persistence and follows the **MVC pattern** with controllers and views.  

This README is developer-focused and provides setup instructions, dependencies, and configuration details for running and contributing to the project.

---

## Table of Contents
- [Features](#Features)  
- [Requirements](#requirements)  
- [Installation](#installation)  
- [Configuration](#configuration)  
- [Database Setup](#database-setup)  
- [Usage](#usage)  
- [Project Structure](#project-structure)  
- [Troubleshooting](#troubleshooting)  

---

## Features
- ASP.NET Core MVC architecture with controllers and views  
- SQL Server database integration via Entity Framework Core  
- Configurable environment-based settings (`appsettings.json`)  
- Dependency injection for services and database context  
- HTTPS enforcement and environment-based error handling  

---

## Requirements
- .NET 8.0 SDK  
- SQL Server (local or remote)  
- Visual Studio 2022 or Visual Studio Code (optional, for development)  
- Git (for version control)  

---

## Installation
Clone the repository:
```bash
git clone https://github.com/myd9890/InventoryApp.git
cd InventoryApp
```

Restore dependencies:
```bash
dotnet restore
```

Build the project:
```bash
dotnet build
```

---

## Configuration
The app uses **`appsettings.json`** for configuration.  
Update the connection string under the **ConnectionStrings** section:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

- **Server**: Your SQL Server instance name  
- **Database**: Desired database name (e.g., `InventoryDB`)  
- **Trusted_Connection=True**: Uses Windows Authentication (replace with username/password for SQL auth if needed)  

---

## Database Setup
Create the database (if not exists):
```sql
CREATE DATABASE InventoryDB;
```

Apply migrations:
```bash
dotnet ef database update
```

Verify schema: After migration, your tables should be created in `InventoryDB`.  

⚠️ Ensure you have the **dotnet-ef CLI tool** installed:
```bash
dotnet tool install --global dotnet-ef
```

---

## Usage
Run the application:
```bash
dotnet run --project InventoryApp
```

Then open a browser and navigate to:  
👉 [https://localhost:5001](https://localhost:5001)  
(Default port may vary depending on your setup.)  

---

## Project Structure
```
InventoryApp/
│── Program.cs                   # Entry point, service and middleware configuration
│── InventoryApp.csproj          # Project file
│── appsettings.json             # Configuration (connection strings, logging, etc.)
│── appsettings.Development.json # Development overrides
│── Data/                        # Entity Framework DbContext and migrations
│── Controllers/                 # MVC controllers
│── Views/                       # Razor views
│── Models/                      # Entity models (Inventory, Products, etc.)
```

---

## Troubleshooting
**Database connection error**  
- Check if SQL Server is running.  
- Ensure the connection string is correctly configured.  

**Migrations not applying**  
- Run:
  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```

**SSL certificate issues**  
- Run with `--no-launch-profile` if needed:
  ```bash
  dotnet run --no-launch-profile
  ```

---
