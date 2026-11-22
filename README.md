# Student Management REST API (Experiment 10)

Build Student Management REST API using ASP.NET Core (Middleware, API, Project Structure)

---

## 📋 Overview
This project is an exact implementation of **Experiment 10: Build Student Management REST API using ASP.NET Core**. It includes:
- **Model**: `Student` with data validation annotations (`Required`, `StringLength`, `EmailAddress`, `Range`).
- **Custom Middleware**: `RequestLoggingMiddleware` that measures request execution time and logs incoming & completed HTTP requests with status codes and elapsed time.
- **Controller**: `StudentsController` exposing full RESTful CRUD operations:
  - `GET /api/Students` - Returns all students in JSON format.
  - `GET /api/Students/{id}` - Returns a specific student by ID or 404 if not found.
  - `POST /api/Students` - Adds a new student with auto-incremented ID and timestamp.
  - `PUT /api/Students/{id}` - Updates existing student details.
  - `DELETE /api/Students/{id}` - Removes a student from the list.
- **Swagger / OpenAPI Documentation**: Integrated with Swashbuckle and mapped to root (`/`) and `/swagger`.

---

## 🚀 How to Run in Visual Studio

1. **Open the Solution**:
   - Double-click **`StudentManagementAPI.sln`** in this folder to open it in **Visual Studio 2022**.
2. **Run the Project**:
   - Make sure **`https`** profile is selected in the toolbar.
   - Press **`F5`** or click the green **Start Debugging** (Play) button.
3. **Automatic Browser Launch**:
   - Visual Studio will launch your default browser at:
     ```
     https://localhost:5001/
     ```
     (or `https://localhost:5001/swagger`)
   - You will see the interactive **Swagger UI** for `Student REST API v1`.

---

## 🌐 Endpoints & Sample Outputs

### 1. Swagger UI Documentation
- **URL**: `https://localhost:5001/` or `https://localhost:5001/swagger`
- **Output**: Interactive documentation displaying all endpoints (`GET`, `POST`, `PUT`, `DELETE`).

### 2. GET All Students
- **URL**: `https://localhost:5001/api/Students`
- **Response**:
```json
[
  {
    "id": 1,
    "name": "Madhusudhan J",
    "email": "madhusudan.j.133659@marwadiiuniversity.ac.in",
    "department": "Computer Science and Engineering",
    "semester": 5,
    "cgpa": 9.45,
    "enrollmentDate": "2024-08-01T00:00:00"
  },
  {
    "id": 2,
    "name": "Rohan Sharma",
    "email": "rohan.sharma@marwadiuniversity.ac.in",
    "department": "Information Technology",
    "semester": 5,
    "cgpa": 8.8,
    "enrollmentDate": "2024-08-01T00:00:00"
  },
  {
    "id": 3,
    "name": "Priya Varma",
    "email": "priya.varma@marwadiuniversity.ac.in",
    "department": "Computer Science and Engineering",
    "semester": 5,
    "cgpa": 9.15,
    "enrollmentDate": "2024-08-01T00:00:00"
  }
]
```

### 3. GET Student by ID
- **URL**: `https://localhost:5001/api/Students/1`
- **Response**:
```json
{
  "id": 1,
  "name": "Madhusudhan J",
  "email": "madhusudan.j.133659@marwadiiuniversity.ac.in",
  "department": "Computer Science and Engineering",
  "semester": 5,
  "cgpa": 9.45,
  "enrollmentDate": "2024-08-01T00:00:00"
}
```

---

## 📂 Project Directory Structure

```text
.net practicle 10/
│
├── StudentManagementAPI.sln              <-- Visual Studio Solution File (open this in VS)
├── StudentManagementAPI.slnx             <-- VS 2022 v17.10+ Solution File
├── README.md                             <-- Guide & documentation
│
└── StudentManagementAPI/
    ├── StudentManagementAPI.csproj       <-- Project file
    ├── Program.cs                        <-- Pipeline configuration & Middleware registration
    ├── appsettings.json
    ├── appsettings.Development.json
    │
    ├── Models/
    │   └── Student.cs                    <-- Student Model with validation annotations
    │
    ├── Middleware/
    │   └── RequestLoggingMiddleware.cs   <-- Custom Request Logging Middleware
    │
    ├── Controllers/
    │   └── StudentsController.cs         <-- REST API Controller (CRUD)
    │
    └── Properties/
        └── launchSettings.json           <-- Configured for https://localhost:5001
```
