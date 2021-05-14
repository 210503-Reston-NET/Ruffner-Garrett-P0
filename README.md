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
- [x] display details of an order
- [x] place orders to store locations for customers
- [x] view order history of customer
- [x] view order history of location
- [x] view location inventory
- [ ] The customer should be able to purchase multiple products
- [ ] Order histories should have the option to be sorted by date (latest to oldest and vice versa) or cost (least expensive to most expensive)
- [x] The manager should be able to replenish inventory

## Additional requirements
- [x] Exception Handling
- [x] Input validation
- [x] Logging (to a file, no logging to the console)
- [ ] At least 10 unit tests
- [x] Data should be persisted, (no data should be hard coded)
- [x] You should use a DB to store data
- [x] DB structure should be 3NF
- [x] Should have an ER Diagram
- [ ] Code should have xml documentation

## Tech Stack
- C#
- Xunit
- SQLServer DB
- EF Core
- Serilog

## DB Schema
### 3NF

![ER Diagram](https://github.com/210503-Reston-NET/Ruffner-Garrett-P0/blob/master/DB/P0_ERD.png)
