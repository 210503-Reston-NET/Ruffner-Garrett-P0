# Store App
## Overview
The store app is a software that helps customers purchase products from your business. Designed with functionality that would make virtual shopping much simpler!

# Building

### Makefile commands
Making dotnet commands easy. No more --project arguments or file paths.
- `make build`
    - Exectues: `dotnet build`
- `make run`
    - executes `dotnet run`
- `make test`
    - executes `detnet test`
- `make clean`
    - executes `dotnet clean`
- `make clearlogs`
    - deletes log files

## Functionality
- [x] add a new customer
- [x] search customers by name
- [ ] display details of an order
- [ ] place orders to store locations for customers
- [ ] view order history of customer
- [ ] view order history of location
- [x] view location inventory
- [ ] The customer should be able to purchase multiple products
- [ ] Order histories should have the option to be sorted by date (latest to oldest and vice versa) or cost (least expensive to most expensive)
- [x] The manager should be able to replenish inventory

## Models
- Customer
- Location
- Orders
- Product
### Note
Add as much models as you would need for your design

## Additional requirements
- Exception Handling
- Input validation
- Logging (to a file, no logging to the console)
- At least 10 unit tests
- Data should be persisted, (no data should be hard coded)
- You should use a DB to store data
- DB structure should be 3NF
- Should have an ER Diagram
- Code should have xml documentation

## Tech Stack
- C#
- Xunit 
- SQLServer DB 
- EF Core
- Serilog or Nlog (or any other logging frameworks)

