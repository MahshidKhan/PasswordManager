# 🔐 Password Manager

A simple password management application built with Angular and .NET Core.

**Developed by:** Mahshid Khanali

## 📋 Features

- Store passwords securely
- Organize by categories (Work, Social, Banking, etc.)
- Add, edit, and delete passwords
- Copy passwords to clipboard
- Modern web interface

## 🛠️ Tech Stack

**Frontend:** Angular + Tailwind CSS  
**Backend:** .NET Core Web API  
**Database:** SQLite  

## 🚀 Quick Start

### Prerequisites
- Node.js
- .NET 8 SDK
- Angular CLI: `npm install -g @angular/cli`

### Setup

1. **Clone the repo**
   ```bash
   git clone https://github.com/MahshidKhan/PasswordManager.git
   cd PasswordManager
   ```

2. **Run Backend**
   ```bash
   cd backend
   dotnet restore
   dotnet ef database update
   dotnet run
   ```
   Runs on `https://localhost:5234`

3. **Run Frontend**
   ```bash
   cd frontend
   npm install
   ng serve
   ```
   Runs on `http://localhost:4200`

## 📁 Project Structure

```
PasswordManager/
├── frontend/    # Angular app
├── backend/     # .NET Core API
└── README.md
```

## 🔌 API Endpoints

- `GET /api/password` - Get all passwords
- `POST /api/password` - Create password
- `PUT /api/password/{id}` - Update password
- `DELETE /api/password/{id}` - Delete password

## 👤 Author

**Mahshid Khanali**  
GitHub: [@MahshidKhan](https://github.com/MahshidKhan)
