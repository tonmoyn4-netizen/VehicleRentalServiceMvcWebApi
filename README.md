# Vehicle Rental Service

Git-ready **ASP.NET MVC 5 + Web API 2** project using **Entity Framework 6 Code First**, **Data Annotations**, **ASP.NET Identity**, and **OAuth bearer token authentication**.

## Main features
- Vehicle Category → Vehicle relational data
- Customer → Rental relational data
- Vehicle → Rental relational data
- Vehicle CRUD
- Customer CRUD
- Rental CRUD
- Rental date validation and automatic total calculation
- Vehicle availability / overlapping-rental validation
- Vehicle image upload
- Data Annotations validation
- OAuth bearer token authentication
- Code First migrations and seed data
- `.gitignore`

## Data types
- Text: Name, Brand, Model, Customer Name
- Number: Year, DailyRate, TotalAmount
- Boolean: Vehicle.Available, Customer.Active
- Date: Rental StartDate, EndDate, CreatedAt
- Image: Vehicle.Image and `/api/vehicles/{id}/image`
- Relational Data: Category, Vehicle, Customer and Rental foreign keys

## API
### Vehicles
`GET/POST /api/vehicles`
`GET/PUT/DELETE /api/vehicles/{id}`
`POST /api/vehicles/{id}/image`

### Customers
`GET/POST /api/customers`
`GET/PUT/DELETE /api/customers/{id}`

### Rentals
`GET/POST /api/rentals`
`GET/PUT/DELETE /api/rentals/{id}`
`PUT /api/rentals/{id}/status`

### Authentication
Register: `POST /api/account/register`

Token: `POST /Token`

Use form data:
```text
grant_type=password
username=admin@vehicle.local
password=Admin@12345
```

Then:
```text
Authorization: Bearer YOUR_ACCESS_TOKEN
```

Seed account:
- Username: `admin@vehicle.local`
- Password: `Admin@12345`

Change the seeded password before production use.

## Database
Package Manager Console:
```powershell
Enable-Migrations
Add-Migration InitialCreate
Update-Database
```

## Run
1. Open `VehicleRentalService.sln` in Visual Studio 2022.
2. Restore NuGet packages.
3. Build.
4. Run with IIS Express.
5. Get a token from `/Token`.
6. Call the protected APIs with the bearer token.