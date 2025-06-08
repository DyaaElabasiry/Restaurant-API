# Restaurants API

This is a RESTful API for managing restaurants and their dishes, built with .NET 9 and following clean architecture principles.

## 🍽️ Features

* **Restaurant Management:**
    * CRUD operations for restaurants (Create, Read, Update, Delete).
    * Get all restaurants.
    * Get a specific restaurant by its ID.
* **Dish Management:**
    * Create new dishes for a specific restaurant.
* **User Management & Authentication:**
    * User registration and login.
    * JWT-based authentication.
    * Role-based authorization with roles like `Owner` and `Admin`.
    * User profile updates.
    * Two-factor authentication management.
    * Password reset functionality.

## 🛠️ Tech Stack

* **.NET 9:** The core framework for building the application.
* **ASP.NET Core:** For building the web API.
* **Entity Framework Core:** For data access and object-relational mapping (ORM).
* **SQL Server:** The database provider used in this project.
* **MediatR:** To implement the Command Query Responsibility Segregation (CQRS) pattern.
* **AutoMapper:** For object-to-object mapping between entities and DTOs.
* **Swashbuckle:** For generating Swagger/OpenAPI documentation.
* **xUnit, Moq, FluentAssertions:** For unit and integration testing.

## 🚀 Getting Started

### Prerequisites

* .NET 9 SDK
* SQL Server

### Installation

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/DyaaElabasiry/Restaurant-API.git](https://github.com/DyaaElabasiry/Restaurant-API.git)
    ```
2.  **Navigate to the API project:**
    ```bash
    cd api/Restaurants.Api
    ```
3.  **Update the database connection string:**

    Open `appsettings.json` and modify the `DefaultConnection` string to point to your SQL Server instance.

4.  **Apply database migrations:**
    ```bash
    dotnet ef database update
    ```
5.  **Run the application:**
    ```bash
    dotnet run
    ```

The API will be running at `http://localhost:5177`. You can access the Swagger UI for API documentation and testing at `http://localhost:5177/swagger`.

## 📂 Project Structure

The project follows the principles of Clean Architecture, separating concerns into distinct layers:

* **`Restaurants.Domain`:** Contains the core business logic, entities, and interfaces. This layer has no dependencies on other layers.
* **`Restaurants.Application`:** Contains the application logic, including services, DTOs, commands, and queries.
* **`Restaurants.Infrastructure`:** Implements the interfaces defined in the `Domain` and `Application` layers. This includes database access, repository implementations, and other infrastructure-related concerns.
* **`Restaurants.Api`:** The presentation layer, which exposes the API endpoints to the outside world.
* **`Restaurants.ApiTests` & `Restaurants.ApplicationTests`:** Contain unit and integration tests for the API and application layers, respectively.

## 💡 Related Concepts

* **RESTful API:** A set of rules and conventions for building and interacting with web services. It uses standard HTTP methods (GET, POST, PUT, DELETE) and status codes.
* **Clean Architecture:** A software design philosophy that separates the elements of a design into ring-like layers. The main rule of clean architecture is that code dependencies can only move from the outer layers inward.
* **CQRS (Command Query Responsibility Segregation):** A pattern that separates read and write operations for a data store. Commands update data, and queries read data.
* **JWT (JSON Web Token):** A compact, URL-safe means of representing claims to be transferred between two parties. It is commonly used for authentication and authorization in web applications.
* **Entity Framework Core:** A modern object-database mapper for .NET. It enables .NET developers to work with a database using .NET objects, eliminating the need for most of the data-access code they usually need to write.
* **Swagger (OpenAPI):** A specification for documenting and describing RESTful APIs. It allows both humans and computers to discover and understand the capabilities of a service without access to source code, documentation, or through network traffic inspection.