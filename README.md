# GameOps .NET API

## Overview

GameOps is a sample **.NET API** for managing game studios. The project demonstrates a **Clean Architecture** approach with **Domain-Driven Design (DDD)** principles, separating concerns into **Domain**, **Application**, **Infrastructure**, and **API** layers.

The main purpose of this API is to manage `Studio` entities, allowing clients to:

- Create a new studio
- Retrieve all studios or a studio by ID
- Delete a studio

This project is designed to show best practices for structuring .NET applications, handling business rules, and integrating with **EF Core** for data persistence.

---

## Architecture

The project follows **DDD principles**:

- **Domain Layer**: Contains the core entities (`Studio`) and domain logic (validations, business rules). For example, a `Studio` has a unique `Id`, a `Name`, and a creation date. Domain rules are enforced here, such as preventing empty names or duplicates.
- **Application Layer**: Contains **handlers** (commands and queries) that orchestrate operations on the domain objects. For example:
  - `CreateStudioHandler` validates and creates a studio.
  - `GetStudiosHandler` retrieves one or all studios.
  - `DeleteStudioHandler` deletes a studio by ID.
- **Infrastructure Layer**: Contains database implementations, like `StudioRepository` using **EF Core** to persist studios in SQLite.
- **API Layer**: Exposes endpoints via **ASP.NET Core Web API**, mapping requests to the appropriate application handlers.

---

## Studio Entity

The `Studio` entity has the following properties:

| Property   | Type       | Description |
|------------|------------|-------------|
| `Id`       | Guid       | Unique identifier for each studio |
| `Name`     | string     | Name of the studio (must be unique) |
| `CreatedAt`| DateTime   | UTC timestamp when the studio was created |

**Rules enforced:**

- `Name` cannot be empty
- `Name` must be unique

---

## API Endpoints

### 1. Create a Studio (POST)

