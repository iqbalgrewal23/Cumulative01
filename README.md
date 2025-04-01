# Cumulative1
# Cumulative01 - School Management System

## Overview
Cumulative01 is a simple ASP.NET Core MVC web application designed to manage school teachers. It provides API endpoints for retrieving teacher information and a frontend interface to list and view teacher details.

## Technologies Used
- ASP.NET Core MVC
- MySQL Database
- Entity Framework (Manual Queries)
- Swagger (For API Documentation)

## Project Structure
```
Cumulative01/
│-- Controllers/
│   ├── TeacherAPIController.cs  # API Controller for teacher data
│   ├── TeacherPageController.cs  # MVC Controller for teacher pages
│
│-- Models/
│   ├── SchoolDbContext.cs  # Database connection class
│   ├── Teacher.cs  # Teacher model
│
│-- Views/
│   ├── TeacherPage/
│       ├── List.cshtml  # View for listing teachers
│       ├── Show.cshtml  # View for showing teacher details
│
│-- Program.cs  # Application entry point
│-- appsettings.json  # Application configuration
```

## Installation and Setup
### Prerequisites
- .NET 6 or later installed
- MySQL Server installed and running

### Database Setup
1. Create a MySQL database named `Comulative1`.
2. Create a `teachers` table with the following schema:
   ```sql
   CREATE TABLE teachers (
       teacherid INT AUTO_INCREMENT PRIMARY KEY,
       teacherfname VARCHAR(50),
       teacherlname VARCHAR(50),
       employeeid VARCHAR(20),
       hiredate DATE,
       salary DECIMAL(10,2)
   );
   ```
3. Update `SchoolDbContext.cs` with your MySQL credentials if necessary.

### Running the Project
1. Clone the repository or download the source code.
2. Open the project in Visual Studio.
3. Run the application using `dotnet run` or start debugging in Visual Studio.
4. Navigate to `https://localhost:<port>/swagger` to access API documentation.
5. Navigate to `https://localhost:<port>/TeacherPage/List` to see the teacher list.

## API Endpoints
### Get All Teachers
**GET** `/api/TeacherAPI/Teacher`

### Get Teacher by ID
**GET** `/api/TeacherAPI/Teacher/{id}`

## Common Issues and Fixes
### 1. Database Connection Issues
- Ensure MySQL is running.
- Verify credentials in `SchoolDbContext.cs`.

### 2. Views Not Rendering
- Ensure `List.cshtml` and `Show.cshtml` are correctly placed in the `Views/TeacherPage/` directory.
- Ensure routes are properly configured in `Program.cs`.

### 3. Swagger Not Loading
- Ensure Swagger is enabled in `Program.cs` under Development mode.
- Check logs for any startup errors.

## License
This project is open-source and free to use.

