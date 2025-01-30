# Car Rental Web Application

## Project Overview
This is a car rental web application built with ASP.NET Core MVC. The application allows users to search for cars, filter results, view rental offices on a map, and switch languages dynamically.

## Features
- Car search and filtering (make, transmission, price)
- Rental office locations displayed on a map using Leaflet.js
- User geolocation to show nearby offices within a 30 km radius
- Language switcher (Turkish/English)
- Responsive design with Bootstrap

## Technology Stack
- Backend: ASP.NET Core MVC, Entity Framework Core
- Frontend: HTML, CSS, JavaScript, Bootstrap, Leaflet.js
- Database: Microsoft SQL Server
- Version Control: Git and GitHub

## Data Model
### Car Model

## Issues Encountered
- Offices were not appearing on the map initially. Fixed by correctly fetching and displaying coordinates.
- Search functionality was not working properly. Improved the query logic for better results.
- Language switcher was not updating dynamically. Implemented session storage for persistence.


