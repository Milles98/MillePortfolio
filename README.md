<div align="center">

# Mille Elfver Portfolio

### Modern .NET 8.0 Portfolio med Case Studies & RESTful API

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Azure](https://img.shields.io/badge/Azure-Deployed-0078D4?style=for-the-badge&logo=microsoftazure&logoColor=white)](https://azure.microsoft.com/)
[![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](LICENSE)

[Live Demo](https://millesportfolio.azurewebsites.net/) • [API Swagger](https://milleprojectapi.azurewebsites.net/swagger/index.html) • [LinkedIn](https://www.linkedin.com/in/mille-elfver-4428ab171/)

---

</div>

## Vad är detta?

En professionell portfolio-webbplats byggd för att visa upp mina projekt och erfarenheter som .NET-utvecklare. Inkluderar detaljerade case studies från enterprise-projekt och en fullt fungerande RESTful API.

<details>
<summary><b>Se funktioner</b></summary>

| Funktion | Beskrivning |
|----------|-------------|
| Responsiv design | Fungerar på alla enheter |
| Dark/Light mode | Sparas i localStorage |
| Animationer | Smooth scroll, fade-in, typing effect |
| Case Studies | Detaljerade projektbeskrivningar |
| Kontaktformulär | Med rate limiting (1/min) |
| Väderwidget | Realtidsväder via API |
| SEO-optimerad | Meta tags, semantic HTML |

</details>

---

## Tech Stack

<table>
<tr>
<td align="center" width="150">

**Frontend**

</td>
<td align="center" width="150">

**Backend**

</td>
<td align="center" width="150">

**Database**

</td>
<td align="center" width="150">

**DevOps**

</td>
</tr>
<tr>
<td align="center">

![Razor](https://img.shields.io/badge/Razor-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap_5-7952B3?style=flat-square&logo=bootstrap&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=flat-square&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=black)

</td>
<td align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=flat-square&logo=jsonwebtokens&logoColor=white)

</td>
<td align="center">

![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)
![Azure SQL](https://img.shields.io/badge/Azure_SQL-0078D4?style=flat-square&logo=microsoftazure&logoColor=white)

</td>
<td align="center">

![Azure](https://img.shields.io/badge/Azure_App_Service-0078D4?style=flat-square&logo=microsoftazure&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/GitHub_Actions-2088FF?style=flat-square&logo=githubactions&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=docker&logoColor=white)

</td>
</tr>
</table>

---

## Projektstruktur

```
MillePortfolio/
├── MillePortfolio/          # Frontend - Razor Pages
│   ├── Pages/
│   │   ├── Index.cshtml     # Huvudsida
│   │   └── Shared/          # Partials (_About, _Portfolio, _CaseStudy, etc.)
│   ├── ViewComponents/      # WeatherViewComponent
│   ├── Data/                # ProjectData.cs (statisk data)
│   ├── Models/              # GitProject, ContactForm, etc.
│   └── wwwroot/             # CSS, JS, bilder
│
├── ProjectApi/              # Backend - RESTful API
│   ├── Controllers/         # GitProjectController, LoginController
│   ├── Data/                # AppDbContext, DataInitializer
│   ├── Models/              # Entities & DTOs
│   └── Migrations/          # EF Core migrations
│
└── README.md
```

---

## Kom igång

### Förutsättningar

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server) (valfritt - för API:et)

### Installation

```bash
# Klona repot
git clone https://github.com/Milles98/MillePortfolio.git
cd MillePortfolio

# Kör portfolion (frontend)
cd MillePortfolio
dotnet run
# Öppna https://localhost:7291

# Kör API:et (backend)
cd ../ProjectApi
dotnet run
# Öppna https://localhost:44336/swagger
```

### Miljövariabler (för kontaktformulär)

```bash
# Windows PowerShell
$env:EMAIL_USERNAME = "din-email@gmail.com"
$env:EMAIL_PASSWORD = "ditt-app-lösenord"

# Linux/Mac
export EMAIL_USERNAME="din-email@gmail.com"
export EMAIL_PASSWORD="ditt-app-lösenord"
```

---

## Arkitektur

```
┌─────────────────┐     ┌─────────────────┐     ┌─────────────────┐
│                 │     │                 │     │                 │
│    Browser      │────▶│  MillePortfolio │────▶│   ProjectApi    │
│                 │     │  (Razor Pages)  │     │   (REST API)    │
│                 │     │                 │     │                 │
└─────────────────┘     └─────────────────┘     └────────┬────────┘
                                                         │
                                                         ▼
                                                ┌─────────────────┐
                                                │                 │
                                                │   Azure SQL     │
                                                │    Database     │
                                                │                 │
                                                └─────────────────┘
```

### Designbeslut

| Beslut | Motivering |
|--------|------------|
| **Razor Pages** | Server-side rendering för SEO och snabb initial load |
| **Statisk data** | Portfolio-data i `ProjectData.cs` för enklare deployment |
| **Memory Cache** | 15 min cache för API-anrop och väderdata |
| **Rate Limiting** | Skydd mot spam i kontaktformuläret (1 req/min/IP) |
| **JWT Auth** | Säker autentisering för API:ets admin-endpoints |

---

## API Dokumentation

### Publika endpoints

| Metod | Endpoint | Beskrivning |
|-------|----------|-------------|
| `GET` | `/GitProject` | Hämta alla projekt |
| `GET` | `/GitProject/{id}` | Hämta specifikt projekt |
| `GET` | `/TechIcon` | Hämta alla tech-ikoner |
| `POST` | `/Login` | Logga in (returnerar JWT) |

### Skyddade endpoints (kräver JWT)

| Metod | Endpoint | Beskrivning |
|-------|----------|-------------|
| `POST` | `/GitProject` | Skapa nytt projekt |
| `PUT` | `/GitProject/{id}` | Uppdatera projekt |
| `DELETE` | `/GitProject/{id}` | Ta bort projekt |

<details>
<summary><b>Exempel: Hämta alla projekt</b></summary>

```bash
curl -X GET "https://milleprojectapi.azurewebsites.net/GitProject" \
  -H "Accept: application/json"
```

**Response:**
```json
[
  {
    "id": 1,
    "projectName": "Bank Application",
    "description": "Fullstack bankapplikation...",
    "githubUrl": "https://github.com/Milles98/BankSolution",
    "technologies": [
      { "technology": "C#", "url": "..." },
      { "technology": "ASP.NET", "url": "..." }
    ]
  }
]
```

</details>

---

## Features i detalj

### Dark Mode
- Sparas i `localStorage`
- Light mode som standard
- Smooth transitions mellan teman

### Animationer
- **Typing effect** - Namn skrivs ut tecken för tecken
- **Scroll animations** - Fade-in när element syns
- **Parallax** - Hero-bakgrund rör sig vid scroll
- **Counter animation** - Siffror räknas upp i Case Study

### Säkerhet
- Rate limiting på kontaktformulär
- JWT-autentisering för API
- Input-validering på server och klient
- `rel="noopener noreferrer"` på externa länkar

---

## Deployment

### Azure App Service (rekommenderat)

```bash
# Bygg för produktion
dotnet publish -c Release

# Deploy via Azure CLI
az webapp up --name ditt-app-namn --resource-group din-resource-group
```

### Docker

```bash
cd MillePortfolio
docker build -t milleportfolio .
docker run -p 8080:80 milleportfolio
```

---

## Kontakt

<div align="center">

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Mille_Elfver-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/mille-elfver-4428ab171/)
[![Email](https://img.shields.io/badge/Email-mille.elfver98@gmail.com-EA4335?style=for-the-badge&logo=gmail&logoColor=white)](mailto:mille.elfver98@gmail.com)
[![GitHub](https://img.shields.io/badge/GitHub-Milles98-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Milles98)

---

**Byggd med .NET 8.0 och massa kaffe**

</div>
