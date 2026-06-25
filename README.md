# Tahlilgaran

Tahlilgaran is a Windows desktop application for managing a small repair workshop and its inventory. It is built with C# and Windows Forms, stores data locally with SQLite, and uses Entity Framework Core migrations to create and update the database automatically.

The application interface is designed for Persian-language users and includes two main areas: inventory management and workshop repair-order tracking.

## Features

- Admin login with hashed password verification
- Inventory management for parts, products, or workshop items
- Add, edit, delete, search, and sell inventory items
- Automatic stock reduction when an item is sold
- Repair-order management for customer devices
- Add, edit, delete, search, and view repair orders
- Track customer name, phone number, device, reported problems, receive time, and delivery time
- Mark repair orders as ready
- Mark completed repair orders as delivered to the customer
- Color-coded repair-order rows for ready and delivered states
- Local per-user SQLite database
- Automatic EF Core database migration on startup

## Tech Stack

- C#
- .NET 6
- Windows Forms
- Entity Framework Core 6
- SQLite

## Project Structure

```text
Tahlilgaran/
├── Tahlilgaran.sln
├── README.md
└── Tahlilgaran/
    ├── Data/
    │   └── AppDBContext.cs
    ├── Forms/
    │   ├── LoginForm.cs
    │   ├── MainForm.cs
    │   ├── InventoryForm.cs
    │   ├── AddInventoryForm.cs
    │   ├── OrderForm.cs
    │   ├── AddOrderForm.cs
    │   └── OrderDetail.cs
    ├── Models/
    │   ├── Admin.cs
    │   ├── Inventory.cs
    │   └── Order.cs
    ├── Migrations/
    ├── Utility/
    │   └── PasswordHasher.cs
    ├── Images/
    ├── Properties/
    ├── Program.cs
    └── Tahlilgaran.csproj
```

## Requirements

- Windows
- Visual Studio 2022 or newer
- .NET 6 SDK

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/arq7arq/Tahlilgaran.git
   cd Tahlilgaran
   ```

2. Open the solution in Visual Studio:

   ```text
   Tahlilgaran.sln
   ```

3. Restore NuGet packages if Visual Studio does not restore them automatically.

4. Build and run the project.

When the application starts, it runs pending Entity Framework Core migrations automatically. The SQLite database is created on first launch.

## Default Login

The database seed creates a default administrator account:

| Username | Password |
| --- | --- |
| `admin` | `1234` |

Change the default credentials before using the application in a shared or production environment.

## Database

Tahlilgaran uses a local SQLite database named `app.db`. By default, it is stored at:

```text
%LOCALAPPDATA%\Tahlilgaran\app.db
```

The main database tables are:

| Table | Purpose |
| --- | --- |
| `Admins` | Stores administrator usernames and hashed passwords |
| `Inventories` | Stores inventory title, quantity, price, and description |
| `Orders` | Stores repair orders, customer information, device problems, and status flags |

## Entity Framework Migrations

Useful EF Core commands:

```bash
dotnet ef migrations add MigrationName --project Tahlilgaran
dotnet ef database update --project Tahlilgaran
```

The app also calls `Database.Migrate()` during startup, so pending migrations are applied automatically when the program opens.

## Security Notes

- Passwords are stored as PBKDF2-SHA256 hashes.
- The default admin account is convenient for development but should be changed for real usage.
- The SQLite database is stored locally for the current Windows user.

## Current Limitations

- Windows-only, because the project targets `net6.0-windows` and uses WinForms.
- No automated test suite is currently included.
- Sales are recorded by reducing inventory count; a separate sales history is not currently implemented.


