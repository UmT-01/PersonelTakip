📋 Overview
A Windows Forms application for tracking employee attendance with secure authentication and role-based access control.

✨ Key Features
🔐 Dual-Role Authentication: Separate interfaces for employees and administrators

🔒 Secure Login System: Employee ID and password-based authentication

📊 Flexible Status Tracking: Employees can mark daily attendance as "Present" or "Absent"

👨‍💼 Admin Dashboard: Comprehensive view of all employee attendance records with date filtering

⚡ Real-Time Database Operations: Modern Microsoft.Data.SqlClient for efficient database connectivity

🎨 User-Friendly Interface: Intuitive Windows Forms design for ease of use

🛠️ Technologies Used
Backend: C# .NET Framework

Frontend: Windows Forms

Database: Microsoft SQL Server

Data Access: Microsoft.Data.SqlClient

Configuration: App.config for connection strings

🚀 Installation & Setup
Prerequisites
.NET Framework 4.6.1 or later

SQL Server (LocalDB or full version)

Visual Studio 2019 or later

* Database Setup
+ CREATE DATABASE EmployeeDB;
+ GO
+ USE EmployeeDB;
+ GO

* CREATE TABLE Employees (
  +  EmployeeID INT PRIMARY KEY IDENTITY(1,1),
  + FirstName NVARCHAR(50) NOT NULL,
  + LastName NVARCHAR(50) NOT NULL,
  + Password NVARCHAR(100) NOT NULL,
  +  IsAdmin BIT DEFAULT 0
+ );

* CREATE TABLE Attendance (
   + AttendanceID INT PRIMARY KEY IDENTITY(1,1),
   + EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
   + AttendanceDate DATE NOT NULL,
   + Status NVARCHAR(20) NOT NULL,
   + CONSTRAINT UC_EmployeeDate UNIQUE(EmployeeID, AttendanceDate)
+ );

* -- Sample data
+ INSERT INTO Employees (FirstName, LastName, Password, IsAdmin) VALUES
+ ('Admin', 'User', 'admin123', 1),
+ ('Ahmet', 'Yılmaz', '12345', 0),
+ ('Ayşe', 'Kaya', '12345', 0);

* Application Setup
+ Clone or download the project
+ Open the solution in Visual Studio
+ Install required NuGet packages:
  Microsoft.Data.SqlClient
System.Configuration.ConfigurationManager

* Update the connection string in App.config to match your SQL Server instance: <connectionStrings>
   + <add .name="EmployeeDBConnection" 
         connectionString="Server=(localdb)\MSSQLLocalDB;Database=EmployeeDB;Integrated Security=true;TrustServerCertificate=true;"
         providerName="Microsoft.Data.SqlClient". />
</connectionStrings>
* Build and run the application

* 📖 Usage
Login
Employees use their ID and password to access the system

Admin users are redirected to the admin dashboard

Regular employees are directed to the employee form

Employee Features
Mark daily attendance as "Present" or "Absent"

View current status for the day

Secure logout functionality

Admin Features
View attendance records for all employees

Filter records by specific dates

Monitor employee attendance patterns

* 🗃️ Database Schema
The system uses two main tables:

Employees Table: Stores employee information and credentials

EmployeeID (Primary Key)

FirstName

LastName

Password

IsAdmin (boolean flag)

Attendance Table: Records daily attendance status with date constraints

AttendanceID (Primary Key)

EmployeeID (Foreign Key)

AttendanceDate

Status

Unique constraint on EmployeeID and AttendanceDate
* 📁 Code Structure
LoginForm.cs: Handles user authentication

EmployeeForm.cs: Provides interface for employees to mark attendance

AdminForm.cs: Displays attendance records for administrators

DatabaseHelper.cs: Manages database connections and operations

* 🔧 Configuration
Modify the connection string in App.config to match your environment:
+ <configuration>
    <connectionStrings>
        <.add name="EmployeeDBConnection" 
             connectionString="Your_Connection_String_Here"
             providerName="Microsoft.Data.SqlClient". />
    </connectionStrings>
 </configuration>
