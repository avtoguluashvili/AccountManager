# Account Maintenance Project - Run and Setup Guide

## Introduction
The **Account Maintenance Project** is a web application designed to manage accounts, subscriptions, and related settings efficiently. It leverages:
- **ASP.NET Core Blazor WebAssembly** for the client-side application.
- **ASP.NET Core Web API** for the server-side API.
- **Entity Framework Core** for data management.
- **SQL Server** as the primary database.

---

## Prerequisites
To run the project successfully, ensure that the following software is installed:
- **.NET 9.0 SDK**
- **SQL Server (or SQL Server Express)**
- **Node.js and npm** (for client-side dependencies)

---

## Project Structure
The project follows a modular and layered architecture:
- **API Layer:** Handles HTTP requests and responses.
- **Client Layer:** Provides a Blazor WebAssembly front-end.
- **Domain Layer:** Contains core entities and business models.
- **Repository Layer:** Manages data access using EF Core.
- **Service Layer:** Implements business logic and service methods.
- **Interfaces Layer:** Defines contracts for services and repositories.

---

## Database Configuration
### Connection String
1. Open `appsettings.json` located in:
   ```
   AccountManager.API/appsettings.json
   ```
2. Update the **connection string** as follows:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=DESKTOP-A91R0GP\\SQLEXPRESS;Database=AccountManagerDB;Trusted_Connection=True;MultipleActiveResultSets=true;"
     }
   }
   ```

---

## Database Setup
### Step 1: Run Migrations
- Open a terminal and navigate to the project root.
- Run the following command to apply the migrations:
  ```bash
  dotnet ef database update --project AccountManager.Repository --startup-project AccountManager.API
  ```

### Step 2: Populate Initial Data
- Open **SQL Server Management Studio (SSMS)**.
- Run the SQL script located in the project or use the provided script to populate initial data.

---

## Running the API
### Step 1: Navigate to API Directory
```bash
cd AccountManager.API
```

### Step 2: Start the API
```bash
dotnet run
```

### Step 3: API Documentation (Swagger)
- Open your browser and navigate to:
  ```
  https://localhost:5001/swagger
  ```

---

## Running the Client
### Step 1: Navigate to Client Directory
```bash
cd AccountManager.Client
```

### Step 2: Install Frontend Dependencies
```bash
npm install --legacy-peer-deps
```

### Step 3: Start the Client
```bash
npm start
```

### Step 4: Access the Web App
- Open your browser and visit:
  ```
  https://localhost:5002
  ```

---

## Summary
The Account Maintenance Project is designed with scalability, maintainability, and performance in mind. Follow the setup and running instructions carefully to ensure smooth execution.

For any issues or assistance, feel free to contact the development team.
