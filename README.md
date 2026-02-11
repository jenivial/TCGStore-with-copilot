# TCGStore API

A .NET 10.0 Web API for managing a Trading Card Game store backend, built with feature-based architecture.

## Project Structure

The API follows a **Vertical Slice Architecture** where each feature owns its own domain, API handlers, and persistence:

```
TCGStore.Api/
├── Features/
│   ├── Cards/                      # Card management slice
│   │   ├── Card.cs
│   │   ├── CardsController.cs
│   │   ├── CardsService.cs
│   │   ├── ICardsService.cs
│   │   ├── CardRequests.cs
│   │   └── Persistence/            # Cards persistence layer
│   │       ├── ICardCatalogRepository.cs
│   │       └── DynamoCardRepository.cs
│   ├── Orders/                     # Order processing slice
│   │   ├── Order.cs
│   │   ├── OrdersController.cs
│   │   ├── OrdersService.cs
│   │   ├── IOrdersService.cs
│   │   ├── OrderRequests.cs
│   │   └── Persistence/            # (ready for implementation)
│   ├── Users/                      # User management slice
│   │   ├── User.cs
│   │   ├── UsersController.cs
│   │   ├── UsersService.cs
│   │   ├── IUsersService.cs
│   │   ├── UserRequests.cs
│   │   └── Persistence/            # (ready for implementation)
│   └── Inventory/                  # Inventory management slice
│       ├── InventoryItem.cs
│       ├── InventoryController.cs
│       ├── InventoryService.cs
│       ├── IInventoryService.cs
│       ├── InventoryRequests.cs
│       └── Persistence/            # (ready for implementation)
├── Common/
│   ├── Extensions/                 # Service extensions
│   └── Middleware/                 # Custom middleware
├── Shared/
│   └── Infrastructure/
│       └── Data/                   # Shared data initialization
├── Program.cs                      # Application entry point
└── appsettings*.json              # Configuration files
```

## Features

### Cards API
- `GET /api/cards` - Get all cards
- `GET /api/cards/{id}` - Get card by ID
- `POST /api/cards` - Create new card
- `PUT /api/cards/{id}` - Update card
- `DELETE /api/cards/{id}` - Delete card

### Orders API
- `GET /api/orders` - Get all orders
- `GET /api/orders/{id}` - Get order by ID
- `POST /api/orders` - Create new order
- `PUT /api/orders/{id}/status` - Update order status

### Users API
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users/register` - Register new user
- `POST /api/users/login` - User login

### Inventory API
- `GET /api/inventory` - Get all inventory items
- `GET /api/inventory/card/{cardId}` - Get inventory by card ID
- `POST /api/inventory` - Add inventory
- `PUT /api/inventory/{id}/quantity` - Update quantity

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Terraform](https://www.terraform.io/downloads)
- [AWS CLI](https://aws.amazon.com/cli/) - configured with your AWS credentials
- Visual Studio Code or Visual Studio 2025+

### Quick Start (Automated Setup)

For local development we expect to create aws resources using Terraform and connect to a DynamoDB instance. We have provided a setup script to automate this process:

```bash
# Run the setup script - initializes Terraform and configures .NET secrets
./scripts/localsetup.sh
```

This script will:
1. Check for required tools (Terraform, .NET CLI)
2. Validate AWS credentials
3. Initialize and apply Terraform with `terraform.dev.tfvars`
4. Configure .NET user secrets for DynamoDB connection

!Important: Set terraform .dev.tfvars values before running the script.

Example
```
# Development Environment Variables for TCGStore DynamoDB

# AWS Configuration
aws_region = "us-west-2"

# DynamoDB Table Configuration
table_name     = "cards"
billing_mode   = "PROVISIONED"
read_capacity  = 5
write_capacity = 5

# Tags for development environment
tags = {
  Environment = "development"
  Project     = "TCGStore"
  ManagedBy   = "Terraform"
  Owner       = "Development Team"
}
```

Then run the API:
```bash
dotnet run --project TCGStore.Api
```

### Cleanup

To clean up your local development environment (destroys Terraform resources and clears secrets):

```bash
./scripts/cleanlocal.sh
```

This script will:
1. Prompt for confirmation
2. Destroy all Terraform-managed AWS resources
3. Clear all .NET user secrets

### Development

To run in watch mode (auto-reload on changes):
```bash
dotnet watch run
```

### Building

```bash
dotnet build
```

## Architecture

### Vertical Slice Architecture
The project uses **Vertical Slice Architecture** where each feature slice owns its:
- **Models** - Domain entities
- **Controllers** - API endpoints
- **Services** - Business logic
- **Interfaces** - Service contracts
- **Requests** - DTOs for incoming data
- **Persistence** - Data access layer (repositories)

Each slice is located in `Features/<SliceName>/` with cross-cutting concerns in `Shared/`

### Feature Slices
- **Cards** - Card catalog management with DynamoDB persistence
- **Orders** - Order processing (persistence layer ready)
- **Users** - User authentication and management (persistence layer ready)
- **Inventory** - Inventory tracking (persistence layer ready)

### Shared Infrastructure
- **Shared/Infrastructure/Data** - Shared data initialization (DynamoDbInitializer)
- **Common/Middleware** - Global exception handling
- **Common/Extensions** - Service registration

## Configuration

Configuration settings can be added to [TCGStore.Api/appsettings.json](TCGStore.Api/appsettings.json) and [TCGStore.Api/appsettings.Development.json](TCGStore.Api/appsettings.Development.json).

**Setup and Configuration:**
- Use `./scripts/localsetup.sh` to automatically initialize Terraform and configure secrets
- Use `./scripts/cleanlocal.sh` to destroy resources and clean up secrets

## Docs

- Authentication: [docs/authentication.md](docs/authentication.md)
- Database architecture: [docs/databases.md](docs/databases.md)

## License

[Specify your license here]
