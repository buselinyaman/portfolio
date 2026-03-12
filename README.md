Portfolio Site

A personal portfolio website built with ASP.NET Core 8 MVC and PostgreSQL.
The project includes a scroll-based portfolio interface and an admin panel for managing portfolio content dynamically.

| Layer          | Technology              |
| -------------- | ----------------------- |
| Backend        | ASP.NET Core 8 MVC      |
| ORM            | Entity Framework Core 8 |
| Database       | PostgreSQL              |
| Authentication | Cookie Authentication   |
| Frontend       | HTML, CSS, JavaScript   |

Features

Public Website:
-Scroll-based portfolio layout
-Timeline-based event display
-Skills with progress indicators
-Responsive layout
-Language toggle (TR / EN)

Admin Panel:
-Secure login system
-Project management (CRUD with image upload)
-Social events management
-Skills management
-About section editing
-Dashboard statistics

Frontend Note:
The frontend layout and visual design are based on a pre-existing template.
The template was integrated into the ASP.NET Core MVC structure and connected to backend services and the database.

The primary development focus of this project includes:
-Backend architecture
-Database integration with Entity Framework Core
-Authentication system
-Admin panel and CRUD functionality

Configure Database
Open appsettings.json and update the connection string

Configure Admin Credentials
Update admin credentials in appsettings.json

Project Structure:
PortfolioSite
│
├── Controllers
│   ├── HomeController.cs
│   └── AdminController.cs
│
├── Models
│   └── Models.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Services
│   └── PortfolioService.cs
│
├── Views
│   ├── Home
│   ├── Admin
│   └── Shared
│
├── wwwroot
│   ├── css
│   ├── js
│   └── images
│
└── appsettings.json

