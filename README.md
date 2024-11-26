reference link :
https://chatgpt.com/share/674617a3-1e14-800f-8b12-73d73813420f


# 1. Prerequisites
Ensure you have the following installed on your system:
Visual Studio Code
.NET SDK 8
SQLite (optional, for database inspection)

# 2. Create the Project
Open a terminal in Visual Studio Code or your preferred terminal.
Run the following commands to create a new .NET Web API project:
```bash
dotnet new webapi -n ProductInventoryApi
cd ProductInventoryApi
dotnet new gitignore
```


Add Required Folders: Inside the project directory, create these folders:
- Controllers
- Services
- Repositories
- DTOs (inside it, create Request and Response subfolders)
- Helpers (for AutoMapper profiles and common utilities)
- Models (for entity classes)

# 3. Install Required Dependencies
Run the following commands in the terminal to add the required NuGet packages:
Entity Framework Core (for database interaction):
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

AutoMapper (for object mapping):
```bash
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

FluentValidation (for input validation):
```bash
dotnet add package FluentValidation.AspNetCore
```

Add Swagger for API Documentation (optional but recommended):
```bash
dotnet add package Swashbuckle.AspNetCore
```


# 4. Configure SQLite Database
Edit appsettings.json: Open the appsettings.json file and configure the SQLite connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=productinventory.db"
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


Add DbContext: Create a Data folder and add a ProductDbContext.cs file inside it:
```csharp
using Microsoft.EntityFrameworkCore;
using ProductInventoryApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductStock> ProductStocks { get; set; }
    public DbSet<ProductPrice> ProductPrices { get; set; }
}

```

Register DbContext in Program.cs:
```csharp
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```


# 5. Install & Configure AutoMapper
Register AutoMapper in Program.cs:
```csharp
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
```

Add AutoMapper Profile: Create a Helpers folder and add the AutoMapperProfile.cs file as shown in the previous implementation.

# 6. Enable Migrations
Run the following commands to create and apply migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Verify that a productinventory.db file is created in the project directory.

# 7. Configure Swagger
Add the following lines in Program.cs to enable Swagger:
```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();
```

Launch your app, and Swagger UI will be available at http://localhost:5000/swagger.

# 8. Add Logic and API Endpoints
Use the previously provided implementations for the models, controllers, services, and repositories.
Organize files according to the folder structure we discussed.
Add validations using FluentValidation for your request DTOs.

# 9. Run the Application
Run the app using:
```bash
dotnet run
```

Test the API endpoints using:
Swagger
Postman or any API testing tool.

# 10. Debugging and Testing
Use SQLite Browser to view and verify the database data.
Debug in Visual Studio Code by adding breakpoints in the code and using the integrated debugger.

