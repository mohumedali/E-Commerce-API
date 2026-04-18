# 🛒 E-Commerce API (ASP.NET Core)

A **robust and scalable E-Commerce RESTful API** built using **ASP.NET Core** following **Clean Architecture principles**.
This project demonstrates real-world backend engineering skills including authentication, product management, cart system, and layered architecture design.

---

## ✨ Key Highlights

* 🔐 Secure Authentication & Authorization using **JWT**
* 👤 Role-based access (Admin / User)
* 📦 Full Product Management (CRUD operations)
* 🛒 Shopping Cart System
* 🔍 Product Search & Filtering
* 📄 Pagination support for scalable data handling
* 🧱 Clean Architecture (Separation of Concerns)
* ⚙️ Dependency Injection throughout layers
* 🗄️ Entity Framework Core with SQL Server
* 📊 DTO pattern for clean API responses
* 🔁 Repository / Service layer pattern

---

## 🏗️ Project Architecture

The solution is structured to ensure maintainability and scalability:

```
MiniProject
│
├── Controllers        → API endpoints (Presentation Layer)
├── Services           → Business logic layer
├── Repositories       → Data access abstraction
├── Models             → Database entities
├── DTOs               → Data Transfer Objects
├── Data               → DbContext & EF Core configuration
└── Helpers / Utils    → Shared utilities (if any)
```

✔ This separation ensures:

* Easy testing
* Low coupling
* High maintainability
* Scalable codebase

---

## 🛠️ Tech Stack

* ASP.NET Core Web API
* C#
* Entity Framework Core
* SQL Server
* LINQ
* JWT Authentication
* Dependency Injection
* AutoMapper (if used)

---

## 🚀 Features in Detail

### 🔐 Authentication System

* User registration & login
* Secure JWT token generation
* Role-based authorization (Admin/User)

### 📦 Product Module

* Add / Update / Delete products (Admin only)
* Get all products with pagination
* Search products by name/category

### 🛒 Cart System

* Add products to cart
* Update quantities
* Remove items from cart
* Get user cart details

---

## 📡 API Overview

### Auth

* POST /api/auth/register
* POST /api/auth/login

### Products

* GET /api/products
* GET /api/products/{id}
* POST /api/products (Admin)
* PUT /api/products/{id} (Admin)
* DELETE /api/products/{id} (Admin)

### Cart

* POST /api/cart/add
* GET /api/cart
* DELETE /api/cart/remove

---

## 🧠 What Makes This Project Strong

This project is not just CRUD — it demonstrates:

* Real backend system design thinking
* Clean separation between layers (Controller → Service → Repository)
* Scalable architecture ready for production
* Secure authentication flow
* API design best practices

---

## 🔮 Future Improvements

* 💳 Payment gateway integration (Stripe / PayPal)
* 📦 Order & Checkout system
* ⚡ Redis caching for performance
* 🧪 Unit & Integration testing
* 📘 Swagger documentation enhancement
* 🚀 CI/CD pipeline (GitHub Actions)

---

## 👨‍💻 Author

**Mohamed Ali**
Backend Developer | ASP.NET Core 

---

## ⭐ If you like this project

Give it a ⭐ on GitHub — it helps a lot!
