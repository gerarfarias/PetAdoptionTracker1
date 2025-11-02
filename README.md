# PetAdoptionTracker1 – ASP.NET Core MVC Project

## Project Summary
The **Pet Adoption Tracker** is an ASP.NET Core MVC web application that allows users to manage pets available for adoption and track adoption activity.  
Shelters or adoption centers can register pets (with details such as name, species, age, and health condition), manage adopter information, and log every adoption event.  

This project demonstrates several key software engineering concepts, including:
- Database modeling with Entity Framework Core  
- Dependency Injection for separation of concerns  
- CRUD operations through MVC forms  
- Application diagnostics and health checks  
- Logging of user events  
- Stored procedures for analytics  
- Cloud deployment on Azure App Service  

---

## Weekly Development Plan

| **Week** | **Concept** | **Feature** | **Goal / Objective** | **Acceptance Criteria** | **Evidence in README.md** | **Test Plan** |
|-----------|--------------|--------------|-----------------------|--------------------------|-----------------------------|----------------|
| **10** | **Modeling** | Create `Pet` and `Adopter` entities | App can store pets and assign them to adopters | - [ ] `Pets` table created  <br> - [ ] `Adopters` table created <br> - [ ] One-to-many relationship works | Implemented code; README write-up; screenshots of DB tables | Run EF Core migration; verify tables and relationship in SQL |
| **11** | **Separation of Concerns / Dependency Injection** | Add `IPetService` to calculate pet adoption readiness (e.g., based on health and vaccination status) | Move readiness logic out of controller and inject via DI | - [ ] `IPetService` registered in DI <br> - [ ] Controller uses constructor injection <br> - [ ] Readiness returns correct value | Implemented code; README write-up; screenshot of service output | Call endpoint that shows pet readiness; verify output |
| **12** | **CRUD** | Add Create/Edit forms for pets | Users can add, edit, and update pet details | - [ ] Create/Edit forms display properly <br> - [ ] Validation messages show <br> - [ ] Data saves to DB | Implemented code; README write-up; screenshots of form and DB | Add new pet, edit pet, confirm DB update |
| **13** | **Diagnostics** | Add `/healthz` endpoint | App reports if database is reachable | - [ ] “Healthy” response when DB is up <br> - [ ] “Unhealthy” when DB is down | Implemented code; README write-up; screenshot of endpoint output | Stop DB; hit `/healthz`; confirm status changes |
| **14** | **Logging** | Log every adoption event | Record structured log entries when a pet is adopted | - [ ] Log message created when adoption occurs <br> - [ ] Log contains pet + adopter ID | Implemented code; README write-up; screenshot of console/log output | Adopt pet in app; check logs for entry |
| **15** | **Stored Procedures** | Call SP: “Top 5 Most Adopted Pet Types” | Display a leaderboard of most adopted species | - [ ] Stored procedure executes successfully <br> - [ ] Results displayed in leaderboard view | Implemented code; README write-up; screenshot of output | Run SP directly in DB and via app; compare results |
| **16** | **Deployment** | Deploy app to Azure App Service | Make the application accessible in the cloud | - [ ] Azure App Service created <br> - [ ] App builds and runs <br> - [ ] `/healthz` reachable <br> - [ ] Adoption path works | README write-up; deployed URL; screenshots | Visit public URL; confirm `/healthz` and adoption flow work |

---

## Technologies Used
- ASP.NET Core MVC 8  
- Entity Framework Core  
- SQL Server (LocalDB / Azure SQL)  
- Dependency Injection (built-in)  
- Serilog for logging  
- Bootstrap 5 for UI styling  
- Azure App Service for cloud deployment  

---

## Future Enhancements (Optional)
- Add “Pet Status” (Available / Adopted / Pending)  
- Create a dashboard with charts using Chart.js  
- Add authentication for shelter staff  

---

## How to Run Locally
1. Clone the repository  
   ```bash
   git clone https://github.com/YOUR-USERNAME/pet-adoption-tracker.git
   cd pet-adoption-tracker


## WEEK 10 UPDATE 

For Week 10, my goal was to implement the foundational data model for my Pet Adoption Tracker MVC application. I focused on defining the Pet entity and configuring Entity Framework Core so that the application can store and retrieve pets from a SQL Server database. This modeling work lays the groundwork for CRUD functionality in future weeks.

The Pet model includes key attributes needed for the adoption workflow: Name, Type, Breed, Age, Health Status, and Adoption Status. These properties ensure that users can easily identify pets and understand whether they are available for adoption.

I also updated the ApplicationDbContext class and added a DbSet<Pet> so Entity Framework can create a Pets table during migrations. After finalizing the structure, I ran the commands Add-Migration AddPetModel and Update-Database to generate and apply the database schema. This successfully created a SQL Server database with a Pets table that matches my model design.

Testing included verifying that the migration built correctly and that the Pets table appeared in SQL Server Object Explorer. This confirms the app is now connected to persistent storage.

These tasks were essential because every future feature — CRUD operations, logging, diagnostics, stored procedures — depends on having a working data model. With Week 10 complete, the project is now ready for controller logic and full database interaction in Week 12.

## WEEK 11 UPDATE


This week, I focused on improving the architecture of my Pet Adoption Tracker project by applying the principles of Separation of Concerns and Dependency Injection (DI). The goal was to move all non-UI logic out of the controller and into a dedicated service class that handles the data operations for the Pet entity.

I created a PetService class with methods for retrieving, adding, updating, and deleting pets. Then I defined an interface IPetService to make the service easier to test and extend in the future. The service interacts directly with the ApplicationDbContext, while the controller now just delegates tasks to it. I registered the service in the DI container using a scoped lifetime so that a new instance is created per HTTP request, which is the recommended approach for Entity Framework Core.

Implementing DI made my code cleaner and easier to maintain. The PetsController is now much thinner and focuses only on handling user requests and responses, while the logic stays encapsulated in the service layer. This structure is similar to real-world enterprise applications, where services provide reusable, testable components that can be swapped or extended without breaking other parts of the system.