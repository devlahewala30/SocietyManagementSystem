# 🏡 Society Management System (ASP.NET Core MVC)

A complete web-based Society Management System built with ASP.NET Core MVC and SQL Server.

## ✨ Features

- 👥 User Registration, Login & Logout
- 🏠 Dashboard with User Info (Flat No., Contact, Email)
- 📢 Notice Management (Post & View Notices)
- 🛠️ Complaint Module (Add, View, Track Status)
- 💸 Maintenance Tracking (Due Date & Payment Status)
- 💬 Chat System (Private Messaging between Users)
- ✏️ Edit Profile Option
- ✅ Session-based Login Authentication
- 🎨 Professionally Designed UI with Bootstrap 5

---

## 🔧 Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server
- Bootstrap 5
- HTML, CSS, Razor
- Git & GitHub

---

## 📂 Folder Structure

```plaintext
SocietyManagementSystem/
│
├── Controllers/
│   ├── UserController.cs
│   ├── ComplaintController.cs
│   ├── NoticeController.cs
│   ├── ChatController.cs
│   └── MaintenanceController.cs
│
├── Models/
│   ├── User.cs
│   ├── Complaint.cs
│   ├── Notice.cs
│   ├── Message.cs
│   └── Maintenance.cs
│
├── Views/
│   ├── User/
│   ├── Complaint/
│   ├── Notice/
│   ├── Chat/
│   ├── Maintenance/
│   └── Shared/
│       └── _Layout.cshtml
│
├── wwwroot/
│   ├── css/
│   └── js/
│
├── appsettings.json
└── Program.cs
