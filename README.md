# SkillLinkCMS

SkillLinkCMS is a scalable website built for Pakistani users to create skill-based profiles. Clients can search for skilled professionals based on their city and category. This project is a CMS-style application developed using Razor Pages, Identity, SQLite, and customizable site settings.

## Features

- **Profile Creation + Public View:** Users can create profiles showcasing their skills and make them public.
- **Admin Module:**
  - Manage Cities & Categories.
  - Featured Profiles System.
- **Homepage Search:** Users can search for profiles by City and Category.
- **SEO Blog Module:** A blog system available under `/blog/xyz` for better SEO.

## Tech Stack

- **Backend:** C# (.NET 9)
- **Database:** SQLite
- **Authentication:** ASP.NET Core Identity
- **Frontend:** Razor Pages
- **Modules:**
  - Profile management.
  - Featured profiles.
  - Admin management (Cities & Categories).
  - SEO Blog Module.

## Installation

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/yourusername/SkillLinkCMS.git
   cd SkillLinkCMS
# dotnet restore
# {
#   "ConnectionStrings": {
#     "DefaultConnection": "Data Source=SkillLinkCMS.db"
#  }
# }
### dotnet ef database update
# dotnet run
