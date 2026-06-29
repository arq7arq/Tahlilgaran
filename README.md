# Tahlilgaran

Tahlilgaran is a Persian-language Windows desktop application for managing a small repair and service workshop. It combines inventory tracking, repair-order management, customer records, itemized repair pricing, printable invoices, and local SQLite persistence in one WinForms app.

The application is built with C# and Windows Forms, targets `.NET 6`, stores data in a per-user SQLite database, and applies Entity Framework Core migrations automatically when the program starts.

## Features

- Persian Windows Forms interface for workshop operators
- Admin login with PBKDF2-SHA256 password verification
- Default seeded administrator account for first launch
- Admin username and password change screen
- Main dashboard with quick access to inventory, repairs, login settings, and customer list
- Inventory management for parts, products, and workshop items
- Add, edit, delete, and search inventory items
- Track inventory title, stock count, price, and description
- Register an item sale by decreasing stock count
- Register returned inventory by increasing stock count
- Repair-order management for customer devices
- Add, edit, delete, search, and view repair orders
- Track customer name, phone number, device, reported problems, receive time, delivery time, repair cost, and status
- Double-click a repair order to view the full reported problem text
- Mark repairs as ready only after entering repair pricing
- Mark ready repairs as delivered to the customer
- Color-coded repair rows:
  - Yellow rows show repairs that are ready
  - Blue rows show repairs delivered to the customer
- Itemized repair cost form with multiple title/price rows
- Automatic total calculation for repair costs
- Numeric validation for inventory count, inventory price, phone number, and repair price inputs
- Optional periodic service reminder flag for completed repairs
- Customer list generated from repair-order history
- Search customers by name or phone number
- Printable Persian invoice preview with logo, customer information, itemized costs, and total price
- Local per-user SQLite database stored under `%LOCALAPPDATA%`
- Automatic EF Core database migration on startup
- Visual Studio publish profile for a self-contained `win-x86` Release build

## Download

You can download the latest Windows installer from the GitHub Releases page:

[Download Tahlilgaran](https://github.com/arq7arq/Tahlilgaran/releases/latest)

After downloading the setup file, run it and follow the installation steps.

## Tech Stack

- C#
- .NET 6
- Windows Forms
- Entity Framework Core 6.0.36
- SQLite via `Microsoft.EntityFrameworkCore.Sqlite`
- PBKDF2-SHA256 password hashing

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
    │   ├── AddPriceForm.cs
    │   ├── OrderDetail.cs
    │   ├── ChangePasswordForm.cs
    │   └── UserListForm.cs
    ├── Models/
    │   ├── Admin.cs
    │   ├── Inventory.cs
    │   ├── Order.cs
    │   └── OrderPrice.cs
    ├── Migrations/
    ├── Utility/
    │   └── PasswordHasher.cs
    ├── Images/
    ├── Resources/
    ├── Properties/
    │   └── PublishProfiles/
    ├── Program.cs
    └── Tahlilgaran.csproj
```

## Requirements

- Windows
- Visual Studio 2022 or newer
- .NET 6 SDK
- Desktop development with C# workload in Visual Studio

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

Change the default credentials from the login settings screen before using the application in a shared or production environment.

## Main Screens

| Screen | Purpose |
| --- | --- |
| Login | Authenticates the administrator account |
| Main dashboard | Opens inventory, repairs, login settings, and customer list |
| Inventory | Lists workshop items and supports add, edit, delete, search, sell, and return actions |
| Add/Edit inventory | Creates or updates inventory title, count, price, and description |
| Repairs | Lists repair orders, tracks status, searches records, prints invoices, and opens detail views |
| Add/Edit repair | Creates or updates customer, phone, device, and reported problem data |
| Add price | Adds itemized repair costs, calculates totals, and stores the service reminder flag |
| Order detail | Shows the complete repair problem description |
| Change login settings | Updates the current admin username and password |
| Customer list | Shows unique customers from repair history and supports searching |

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
| `Orders` | Stores repair orders, customer information, device problems, status flags, total price, and service reminder flag |
| `OrderPrices` | Stores itemized repair cost rows linked to an order |

## Repair Workflow

1. Create a repair order with customer, phone, device, and problem details.
2. When the repair is finished, open the pricing form from the repair list.
3. Enter one or more repair cost rows. The app calculates the total automatically.
4. Optionally enable the periodic service reminder flag.
5. Save pricing to mark the repair as ready.
6. Mark the ready repair as delivered when the customer receives the device.
7. Print an invoice when needed.

## Entity Framework Migrations

Useful EF Core commands:

```bash
dotnet ef migrations add MigrationName --project Tahlilgaran
dotnet ef database update --project Tahlilgaran
```

The app also calls `Database.Migrate()` during startup, so pending migrations are applied automatically when the program opens.

Current migrations cover:

- Admin table creation and default admin seeding
- Inventory table creation
- Repair order table creation
- Nullable repair finish time
- Repair total price and itemized `OrderPrices`
- Service reminder flag on repair orders

## Publishing

The project includes a Visual Studio folder publish profile at:

```text
Tahlilgaran/Properties/PublishProfiles/FolderProfile.pubxml
```

The profile is configured for:

| Setting | Value |
| --- | --- |
| Configuration | `Release` |
| Target framework | `net6.0-windows` |
| Runtime identifier | `win-x86` |
| Deployment mode | Self-contained |
| Publish protocol | File system |

You can publish from Visual Studio using the publish profile, or use the .NET CLI with equivalent settings.

## Security Notes

- Passwords are stored as PBKDF2-SHA256 hashes with per-password random salts.
- Password verification uses fixed-time hash comparison.
- The default admin account is convenient for first launch but should be changed before real use.
- The SQLite database is stored locally for the current Windows user.

## Current Limitations

- Windows-only, because the project targets `net6.0-windows` and uses WinForms.
- No automated test suite is currently included.
- Sales and returns update inventory counts, but a separate sales or returns history table is not currently implemented.
- Customer records are derived from repair orders, not stored in a separate customer table.
- Service reminders are stored on repair orders; the current UI includes reminder logic, but no background scheduler or notification service.

## License

No license file is currently included. Add a license before distributing or reusing this project publicly.