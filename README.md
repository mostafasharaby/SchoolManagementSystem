# 📚 School Management System - Backend (ASP.NET Core)

The **School Management System** is a backend service built with **ASP.NET Core** to manage students, teachers, classrooms, library books, and borrowing operations. It follows **Clean Architecture** principles, utilizing **CQRS, MediatR, Entity Framework Core, and JWT Authentication**.

---

## 🚀 Features

✅ **Full CRUD Operations** for Students, Teachers, Classes, and Borrowed Books  
✅ **Clean Architecture** (Domain, Application, Infrastructure, Presentation)  
✅ **CQRS with MediatR** for better separation of commands & queries  
✅ **Repository & Unit of Work Pattern** for efficient data handling  
✅ **Entity Framework Core** with SQL Server  
✅ **AutoMapper** for seamless object mapping  
✅ **FluentValidation** for input validation  
✅ **JWT Authentication & Role-based Authorization**  
✅ **Swagger UI** for API documentation  
✅ **Global Exception Handling & Logging**  

---

## 🏗️ Architecture Overview

The project follows **Clean Architecture**, dividing concerns into multiple layers:

- **Core** - Contains domain models, DTOs, and core business logic  
- **Application** - Includes CQRS handlers, validators, and application services  
- **Infrastructure** - Handles database persistence, external services, and repositories  
- **API** - Defines controllers, endpoints, and middleware  

---

## 🛠️ Technologies Used

- **.NET 8**  
- **ASP.NET Core Web API**  
- **Entity Framework Core** (Code-First Migrations)  
- **MediatR** for CQRS pattern  
- **FluentValidation** for request validation  
- **AutoMapper** for object mapping  
- **Serilog** for structured logging  
- **JWT Authentication** with role-based access control  
- **SQL Server** as the primary database  
- **Swagger (NSwag/Swashbuckle)** for API documentation
  
## 🔥 Getting Started

### 📌 Prerequisites
- .NET 8  
- SQL Server  
- Visual Studio / VS Code  

### 🚀 Setup Instructions

1️⃣ Clone the repository  
```sh
git clone https://github.com/YourUsername/SchoolManagementSystem.git
cd SchoolManagementSystem
