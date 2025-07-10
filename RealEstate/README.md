# RealEstateAPI

**Web application with .NET Core 8.0 API and Angular v18**

## Table of Contents

- [Project Overview](#project-overview)
- [Architecture](#architecture)
- [Main Folders](#main-folders)
- [Use Cases](#use-cases)
- [API Endpoints](#api-endpoints)
- [Technologies Used](#technologies-used)
- [Project Setup & Configuration](#project-setup--configuration)
- [Contributing](#contributing)
- [License](#license)

---

## Project Overview

RealEstateAPI is a web application designed to manage real estate operations, providing a RESTful API built with .NET Core 8.0 and a frontend developed in Angular v18. The backend implements a simplified version of Clean Architecture, ensuring maintainability, scalability, and separation of concerns.

---

## Architecture

The project follows a conceptual Clean Architecture structure:

- **Application Layer**: Core business logic and use cases, interfaces for repositories, services, DTOs, and common utilities.
- **Domain Layer**: Contains the entity models reflecting the database schema.
- **Infrastructure Layer**: Implements repository interfaces, database configuration (DbContext), and other data-access concerns.
- **API Layer**: Exposes controllers and endpoints for client interaction.

### Folder Structure

- **Application**: Contains use cases, services, interfaces, DTOs, and common utilities (e.g., Pagination, OperationResult).
- **Domain**: Contains entity models mirroring the database tables.
- **Infrastructure**: Implements the repositories and includes database configuration and context.
- **API**: Houses controllers and endpoints, handling HTTP requests and responses.

---

## Main Folders

- `Application/`
  - **Interfaces**: Repository interfaces for each entity.
  - **Services**: Business logic and application services.
  - **DTO**: Data Transfer Objects for customized data exchange.
  - **Common**: Shared utilities (Pagination, OperationResult, constants).
  - **DependencyInjection**: Service registration for DI.
- `Domain/`: Entity models.
- `Infrastructure/`
  - **Repositories**: Repository implementations.
  - **Data**: Database configuration, DbContext.
- `Controllers/` and `Endpoints/`: API and fast endpoints.

---

## Use Cases

### Item Use Cases

- **CreateItem**: Add a new item to the database.
- **GetItem**: Retrieve an item by ID.
- **UpdateItem**: Update an existing item.
- **DeleteItem**: Delete an item by ID.
- **ListItems**: List all items with pagination and filtering.
- **GetItemClientsHistory**: Retrieve all clients related to a specific house (purchase or rent), with relevant client information and pagination.
- **GetItemFinancing**: Calculate loan schedules for item purchases based on input (loan amount, interest rate, term/monthly payment). Defaults to predetermined rates for EUR and ALL currencies.
- **Item Statistics**: Various statistics (totals, min/max price, period-based aggregations).

### Client Use Cases

- **CreateClient**: Register a new client.
- **GetClient**: Get client details by ID.
- **UpdateClient**: Update client data.
- **DeleteClient**: Remove a client by ID.
- **ListClients**: List all clients with pagination and filtering.
- **GetClientItemsHistory**: Show all items a client has bought or rented, with relevant item information and pagination.
- **Client Statistics**: Various statistics (total clients, active/inactive clients, spending stats, priority lists).

### ClientItem Use Cases

- **Add**: Link a client with a purchased/rented item (creates a transaction, marks item as unavailable).
- **Inactive**: Mark a ClientItem as inactive (e.g., rental ended), making the item available again.
- **Update**: Modify a client-item link in case of errors.

---

## API Endpoints

### Item

- `GET /api/item` — List all items
- `GET /api/item/{id}` — Get item by ID
- `POST /api/item` — Create new item
- `PUT /api/item` — Update item
- `DELETE /api/item/{id}` — Delete item
- `POST /api/item/filter` — Filter items (with pagination)

### Client

- `GET /api/client` — List all clients
- `GET /api/client/{id}` — Get client by ID
- `POST /api/client` — Create new client
- `PUT /api/client` — Update client
- `DELETE /api/client/{id}` — Delete client
- `POST /api/client/filter` — Filter clients (with pagination)

### ClientItem

- `GET /api/client/item` — List all client-item links
- `GET /api/client/item/{id}` — Get client-item link by ID
- `POST /api/client/item` — Create new client-item link
- `PUT /api/client/item` — Update client-item link
- `DELETE /api/client/item/{id}` — Delete client-item link

### Statistics and Reports

A full set of endpoints for items and clients statistics, e.g.:

- `/api/item/statistics/added`
- `/api/item/statistics/price/avg`
- `/api/item/statistics/price/max`
- `/api/item/statistics/given`
- `/api/client/statistics/price/history`
- `/api/client/statistics/priority/top`

> **Note:** See the `theory.txt` section [above](#use-cases) for detailed endpoint definitions, parameters, and expected results.

---

## Technologies Used

- **Backend**: .NET Core 8.0
- **Frontend**: Angular v18
- **Database**: Configurable (default: SQL Server; can be changed in `appsettings.json`)
- **ORM**: Entity Framework Core
- **Dependency Injection**: Built-in .NET Core DI
- **API Documentation**: Swagger (optional, configure as needed)
- **Other**: SCSS, HTML, TypeScript

---

## Project Setup & Configuration

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js (for Angular)](https://nodejs.org/) (recommended v18+)
- [Angular CLI](https://angular.io/cli)
- SQL Server or compatible database

### Backend Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/migel-cepele/RealEstate.git
   cd RealEstate/RealEstate
   ```

2. **Configure the database:**
   - Edit `appsettings.json` to set your connection string.
   - Example:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER;Database=RealEstateDb;Trusted_Connection=True;"
     }
     ```

3. **Apply Migrations:**
   ```bash
   dotnet ef database update
   ```

4. **Run the API:**
   ```bash
   dotnet run
   ```
   The API will be available at `https://localhost:5001` (or configured port).

### Dependency Injection

All services are registered via the `DependencyInjection` class in the Application layer. This is called from `Program.cs` on application startup.

### Additional Configuration

- **Swagger**: Enable or disable Swagger in `Program.cs` for API documentation.
- **Environment Variables**: Use environment variables for sensitive configuration (connection strings, API keys).

---

## Contributing

Contributions are welcome! Please fork the repository, create a feature branch, and submit a pull request.

---

## License

This project is licensed under the MIT License.

---

**For more details, see the source code and comments within each folder.**
