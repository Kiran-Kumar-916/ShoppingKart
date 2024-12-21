# ShoppingKart
ASP.NET MVC application, built using .NET 8.0 and crafted in C# on Visual Studio 2022. This application is to discover amazing products at unbeatable prices.

# Project Overview
The ShoppingKart application is a fully functional e-commerce platform developed using the ASP.NET MVC framework. It enables customers to log in, explore a range of products, add them to a shopping cart, and complete their purchase by choosing from various payment options. The application emphasizes modularity, maintainability, and scalability by implementing Dependency Injection (DI) and following the MVC architectural pattern.

## Key Features:

### User Authentication:

Login and Signup functionality for customers.
Admin Login functionality to manage product and category creation, updation, and deletion.
Account Profile management.

### Product Management:

Browse products and view detailed product descriptions.

### Cart Management:

Add products to the shopping cart.
View and update the cart (e.g., quantity changes, product removal).

### Order Placement:

Proceed to checkout.
Choose payment methods and complete the purchase.


## Technology Stack:
* Framework: ASP.NET MVC
* Database: SQL Server
* Database Connection: Managed in appsettings.json with details for the server and database (ShoppingKart).
* Dependency Injection: Configured using ASP.NET Core DI container for services like DbContext and application-specific dependencies.
* ORM: Entity Framework Core
* Frontend: Razor Views



## Models:
* ApplicationDbContext.cs: Defines the database context and manages entity configurations. This class serves as the central point for database access, mapping models such as Category, Product, MyCart, and User to corresponding database tables.
* User.cs: Manages customer information, including authentication and profile details.
* Product.cs: Represents individual product details.
* Category.cs: Represents product categories.
* CartProductViewModel.cs: Represents the data structure combining product and cart details.
* MyCart.cs: Represents products added to the cart by users.
* ErrorViewModel.cs: Handles error information.


## Views:
### Accounts Folder:
* Loginform.cshtml: For user login.
* Profile.cshtml: Displays and manages user profile.
* SignUp.cshtml: For user registration.

### Home Folder:
* Categories.cshtml & CategoriesCreatEdit.cshtml: Manage and display product categories.
* Index.cshtml: Home page view.
* MyCart.cshtml: Displays products added to the cart.
* Payment.cshtml: Payment processing view.
* Privacy.cshtml: Privacy policy details.
* Products.cshtml & Productdetails.cshtml: Display product list and detailed product descriptions.
* ProductCreatEdit.cshtml: For creating and editing product details.
* Success.cshtml: Order confirmation view.


## Controllers:
### AccountController:

Manages authentication, including login, signup, and profile updates.
Handles views like Loginform.cshtml, Profile.cshtml, and SignUp.cshtml.

### HomeController:

Manages the main shopping flow, including category and product displays, cart handling, and order placement.
Handles views such as Categories, CategoriesCreatEdit, Index, MyCart, Payment, Privacy, Products, Productdetails, ProductCreatEdit, and Success.cshtml.



## Conclusion:
The ShoppingKart application provides a comprehensive shopping experience with robust architecture, efficient data handling, and clean UI design. It’s a scalable solution with room for enhancements like -- categorize & show products as per user interests, provide search & filter options, add additional payment gateways etc.
