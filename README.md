# BetterBats
## Project Description
This application is designed with functionality that would make virtual baseball bat shopping much simpler! Customers can sign up for an account, 
place orders, view their order history, and specific location inventory. It also comes with an additional interface for managing your business. 
Managers can view and replenish location inventory, add new products, and view the order history of specific locations. This application used Entity Framework Core 
to connect to a PostgreSQL database, ASP.NET Core API to create a RESTful API, and HTML, CSS, BootstrapJS, and Javascript to create the front end.

## Technologies Used
* C#
* PostgreSQL DB
* ElephantSQL
* EF Core
* ASP.NET Core
* HTML
* CSS
* JS
* HTTPClient
* BootstrapJS
* ASP.NET MVC
* Xunit
* Serilog

## Features
* The customers and managers are able to sign up for an account
* The customers are able to view their order history
* The customers are able to view location inventory
* The customers know how much of a product is remaining
* The managers are able to view a location’s order history
* The manager are able to replenish inventory
* The managera are able to add a new product to a location’s inventory
* Order histories can be sorted by date or cost 

## Getting Started
1. Install .NET Core SDK
2. Install EF Core 
3. Install PostgreSQL
4. Create Elephant SQL Server
5. `Git clone https://github.com/201019-UiPath/TejadaAnthony-P1.git `
6. Create appsettings.json and set PostgreSQL credentials 

## Usage
1. After installing the necessary tech stack and setting up the server credentials in your appsetting.json run the following in the StoreApp DB project directory from the command line: ```Dotnet ef dbcontext scaffold -c <connection-string-in-quotes> Npgsql.EntityFrameworkCore.PostgreSQL --startup-project <path to project folder> --force --output-dir Entities```
2. To start using run StoreApp project first which is the API. Then run StoreAppWeb project. 
3. Navigate to your localhost:<PORTNUMBER>/home/login

## License
This project uses the following license: [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
