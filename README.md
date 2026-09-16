🚌 Bus Ticket Management System
A desktop-based Bus Ticket Management System developed using C# Windows Forms and Microsoft SQL Server.

The system is designed to manage bus operators, buses, routes, schedules, seat booking, customer payments, operator commissions, and administrative reports through a role-based interface.

📌 Project Overview
The Bus Ticket Management System provides a complete digital solution for managing bus ticket operations.

The system has three main user roles:

👑 Super Admin — Manages the overall system, operators, payments, commissions, and reports.
🚌 Bus Operator / Admin — Manages buses, routes, schedules, bookings, and operator payments.
👤 Customer / Ticket Buyer — Searches available buses, selects seats, books tickets, and completes payments.
The application uses a centralized SQL Server database to store and manage users, buses, routes, schedules, bookings, seats, payments, and related information.

✨ Main Features
👑 Super Admin
Secure Super Admin login
Change login credentials
View system dashboard
View total operators
View total buses
View total tickets sold
View total sales
View platform commission/revenue
Manage bus operators
Delete operators
View operator payment reports
Track received, pending, and overdue commission payments
🚌 Bus Operator / Admin
Operator login
Operator dashboard
Manage buses
Add and manage routes
Create and manage schedules
View bookings
View payment reports
Track commission payments
Manage bus-related information
👤 Customer / Ticket Buyer
Customer registration and login
Customer dashboard
Search available buses
View bus schedules
Select travel date
Select seats
View seat availability
Book tickets
Complete ticket payment
View booking/payment information
Maintain customer booking history
💺 Seat Management
The system includes a dedicated Seats table to support seat-level ticket booking.

Customers can select individual seats before confirming a booking.

The system is designed to support different bus configurations, including:

AC buses
Non-AC buses
Sleeper buses
Different seat layouts
Seat information is associated with the relevant bus and schedule to prevent invalid or duplicate seat bookings.

💳 Payment Management
The system supports customer ticket payments and operator commission payments.

Customer Payment Flow
Search Bus
     ↓
Select Schedule
     ↓
Select Seat(s)
     ↓
Review Booking
     ↓
Payment
     ↓
Booking Confirmed
     ↓
Ticket Information Stored
Operator Commission Flow
Customer Booking
      ↓
Ticket Sale
      ↓
Commission Calculated
      ↓
Operator Commission Recorded
      ↓
Operator Payment
      ↓
Payment Status Updated
The system can identify operators whose commissions are:

✅ Paid
⏳ Pending
⚠️ Overdue
🗄️ Database
The project uses Microsoft SQL Server / LocalDB.

Database Name
BusTicketManagementSystem
Main Database Tables
Users
Customers
Operators
Buses
Routes
Schedules
Seats
Bookings
BookingSeats
Payments
OperatorPayments
Reviews
Notifications
Database Relationship Overview
Users
 ├── Customers
 └── Operators

Operators
 └── Buses

Buses
 └── Seats

Routes
 └── Schedules

Buses
 └── Schedules

Schedules
 └── Bookings

Bookings
 ├── BookingSeats
 └── Payments

Operators
 └── OperatorPayments
🛠️ Technologies Used
Technology	Purpose
C#	Application development
Windows Forms	Desktop user interface
.NET Framework 4.7.2	Application framework
Microsoft SQL Server	Database management
SQL Server LocalDB	Local database environment
ADO.NET / SqlClient	Database connectivity
Visual Studio	Development environment
🔌 Database Connection
The project uses SQL Server LocalDB.

Example connection string:

Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=BusTicketManagementSystem;
Integrated Security=True;
Make sure SQL Server LocalDB is installed and the database exists before running the application.

📂 Project Structure
A simplified structure of the project is:

BusTicketManagementSystem/
│
├── BusTicketMainPage.cs
│
├── SuperAdmin.cs
├── SuperAdminDashBoard.cs
├── ManageOperators.cs
├── PaymentsReports.cs
│
├── BusOperator_Admin_.cs
├── AdminDashboard.cs
├── MyBuses.cs
├── Routes.cs
├── Schedules.cs
│
├── Customer_TicketBuyer_.cs
├── CustomerDashboard.cs
├── BookTicket.cs
├── CutomerPayments.cs
├── MyBookings.cs
│
├── PendingBookingData.cs
│
├── App.config
├── database.sql
└── README.md
🔐 Role-Based System Flow
                    ┌──────────────────────┐
                    │  Bus Ticket System   │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │   Select User Role   │
                    └──────────┬───────────┘
                               │
             ┌─────────────────┼─────────────────┐
             ▼                 ▼                 ▼
       Super Admin        Bus Operator       Customer
             │                 │                 │
             ▼                 ▼                 ▼
      Admin Login        Operator Login     Customer Login
             │                 │                 │
             ▼                 ▼                 ▼
      Admin Dashboard    Operator Dashboard  Customer Dashboard
🖥️ Application Modules
Super Admin Module
Super Admin
│
├── Dashboard
├── Manage Operators
├── System Statistics
├── Revenue / Commission
└── Payment Reports
Operator Module
Bus Operator
│
├── Dashboard
├── My Buses
├── Routes
├── Schedules
├── Bookings
└── Payments & Reports
Customer Module
Customer
│
├── Dashboard
├── Search Buses
├── Book Ticket
├── Select Seats
├── Payments
└── My Bookings
📊 Super Admin Dashboard
The Super Admin dashboard provides an overview of the system through several statistical cards.

Important metrics include:

Total Operators
Total Buses
Total Tickets Sold
Total Sales
Platform Revenue / Commission
Received Operator Payments
Pending Operator Payments
Overdue Operator Payments
These statistics help the system owner monitor the overall performance of the platform.

🎫 Booking Process
The customer booking process is designed to be straightforward:

Customer logs into the system.
Customer searches for available buses.
Customer selects a schedule.
Available seats are displayed.
Customer selects one or more seats.
Booking information is prepared.
Customer proceeds to payment.
Payment is completed.
Booking status is updated.
Selected seats are stored against the booking.
The system uses transactional database operations during booking/payment confirmation to maintain data consistency.

🧾 Database Transaction
Booking confirmation involves multiple related database operations.

Conceptually:

BEGIN TRANSACTION

      ↓

Create Booking

      ↓

Store Selected Seats

      ↓

Create Payment

      ↓

Update Booking Status

      ↓

COMMIT TRANSACTION
If an error occurs, the transaction can be rolled back to avoid incomplete booking records.

🚀 How to Run the Project
1. Clone the Repository
git clone <repository-url>
2. Open the Project
Open the following solution in Visual Studio:

BusTicketManagementSystem.sln
3. Configure SQL Server
Make sure SQL Server LocalDB is installed.

The project expects:

(localdb)\MSSQLLocalDB
4. Create the Database
Open the SQL database script:

database.sql
Execute the script in SQL Server Management Studio or Visual Studio's SQL tools.

This creates the required:

BusTicketManagementSystem
database and its tables.

5. Check the Connection String
Make sure the connection string points to:

Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=BusTicketManagementSystem;
Integrated Security=True;
6. Build the Project
In Visual Studio:

Build → Build Solution
7. Run
Press:

F5
or click:

Start
📋 Requirements
Before running the application, make sure you have:

Windows OS
Visual Studio
.NET Framework 4.7.2
SQL Server LocalDB
SQL Server Management Studio or equivalent SQL tool
🔒 Security Considerations
The system uses role-based access to separate different types of users.

Super Admin
     ↓
System Management

Operator
     ↓
Bus & Schedule Management

Customer
     ↓
Booking & Payment
Future versions can improve security by adding:

Password hashing
Stronger authentication
Session management
Account lockout
More detailed authorization rules
Input validation and SQL injection protection
🔮 Future Improvements
Possible future improvements include:

Online payment gateway integration
Email/SMS ticket confirmation
Digital ticket generation
QR-code based tickets
Advanced booking history
Bus seat-map customization
Different seat layouts for different bus types
Customer reviews and ratings
Notification system
Advanced sales analytics
Automated operator commission settlement
Cloud database integration
Web/mobile version of the system
🎯 Project Objectives
The main objectives of this project are to:

Automate the bus ticket booking process
Reduce manual ticket management
Provide an easy-to-use customer booking system
Help operators manage buses and schedules
Provide administrators with centralized system control
Manage customer payments
