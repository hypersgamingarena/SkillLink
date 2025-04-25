Sure! Here’s your updated `README.md` with **PerStack Software House** credited at the bottom in a clean and professional way:

---

# SkillLinkCMS

SkillLinkCMS is a scalable CMS-style application built for Pakistani users to create skill-based profiles. Clients can search for skilled professionals based on their **city** and **category**.

---

## 🚀 Features

- **👤 Profile Creation + Public View**  
  Users can create public profiles to showcase their skills.

- **🔧 Admin Module**
  - Manage **Cities** and **Categories**
  - Feature profiles for homepage display

- **🔎 Homepage Search**  
  Search profiles by **City** and **Category**

- **📝 SEO Blog Module**  
  A built-in blog system under `/blog/xyz` to enhance SEO

---

## 🧰 Tech Stack

- **Backend:** C# (.NET 9)  
- **Database:** SQLite  
- **Authentication:** ASP.NET Core Identity  
- **Frontend:** Razor Pages  

### Key Modules

- Profile Management  
- Featured Profiles  
- Admin Panel (Cities & Categories)  
- SEO Blog Module  

---

## 📦 Installation

```bash
# Clone the repository
git clone https://github.com/yourusername/SkillLinkCMS.git
cd SkillLinkCMS

# Restore dependencies
dotnet restore
```

### Configure the Connection String

Update your `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=SkillLinkCMS.db"
  }
}
```

### Run Entity Framework Migrations

```bash
dotnet ef database update
```

### Start the Application

```bash
dotnet run
```

---

## 🏢 Developed By

**PerStack Software House**  
Empowering local solutions with modern technology.  
🌐 [Visit us](https://perstack.com)

---

