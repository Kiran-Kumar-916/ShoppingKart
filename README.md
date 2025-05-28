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


<<<<<<< HEAD
#Conclusion:
The ShoppingKart application provides a comprehensive shopping experience with robust architecture, efficient data handling, and clean UI design. It’s a scalable solution with room for enhancements like categorize & show products as per user interesets, provide search & filter options, add additional payment gateways etc.
=======

## Conclusion:
The ShoppingKart application provides a comprehensive shopping experience with robust architecture, efficient data handling, and clean UI design. It’s a scalable solution with room for enhancements like -- categorize & show products as per user interests, provide search & filter options, add additional payment gateways etc.
>>>>>>> 82d1e60e43dd78216c09d3ea5f217ed04b00b37d




<<<<<<< HEAD
# Screenshots
Below are key screenshots showcasing different pages of the application.

## **Categories Page**
![Categories Page](wwwroot/images/Project%20Screenshots/CategoriesPage.png)

## **Create/Edit Categories Page**
![Create/Edit Categories Page](wwwroot/images/Project%20Screenshots/CreateEditCategoriesPage.png)

## **Create/Edit Products Page**
![Create/Edit Products Page](wwwroot/images/Project%20Screenshots/CreateEditProductsPage.png)

## **Home Page**
![Home Page - View 1](wwwroot/images/Project%20Screenshots/HomePage_1.png)  
![Home Page - View 2](wwwroot/images/Project%20Screenshots/HomePage_2.png)

## **Login Page**
![Login Page](wwwroot/images/Project%20Screenshots/LoginPage.png)

## **My Cart Page**
![My Cart Page](wwwroot/images/Project%20Screenshots/MyCartPage.png)

## **Payment Options Page**
![Payment Options Page](wwwroot/images/Project%20Screenshots/PaymentOptionsPage.png)

## **Payment Success Page**
![Payment Success Page](wwwroot/images/Project%20Screenshots/PaymentSuccessPage.png)

## **Product Details Page**
![Product Details](wwwroot/images/Project%20Screenshots/ProductDetails_2.png)

## **Products Page**
![Products Page](wwwroot/images/Project%20Screenshots/ProductsPage.png)

## **Profile Page**
![Profile Page](wwwroot/images/Project%20Screenshots/ProfilePage.png)

## **Sign-Up Page**
![Sign-Up Page](wwwroot/images/Project%20Screenshots/SignUpPage.png)
=======
# Instructions to Run the ShoppingKart Project
### Update appsettings.json:

Open the appsettings.json file in the project.
Replace Server name with your SQL Server instance name in ConnectionStrings under "DefaultConnection".
Set the database name to ShoppingKart (or any other preferred name).

### Restore NuGet Packages:
Open the project in Visual Studio.
Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
Restore any missing dependencies.

### Migrate Database (Code-First Approach):
Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
Run the following commands:

_Add-Migration InitialCreate_  
_Update-Database_  

This will create the database schema in your SQL Server based on the ApplicationDbContext.cs.

### Ensure Required Tables Exist:
The database should now contain the following tables to store application data:
- Users
- Products
- Categories
- MyCartItems

### Run the Application:
Press F5 or click Start in Visual Studio.
The application will launch in your default browser.



# Screenshots
Below are key screenshots showcasing different pages of the application.

## **Categories Page**
![Categories Page](wwwroot/images/Project%20Screenshots/CategoriesPage.png)

## **Create/Edit Categories Page**
![Create/Edit Categories Page](wwwroot/images/Project%20Screenshots/CreateEditCategoriesPage.png)

## **Create/Edit Products Page**
![Create/Edit Products Page](wwwroot/images/Project%20Screenshots/CreateEditProductsPage.png)

## **Home Page**
![Home Page - View 1](wwwroot/images/Project%20Screenshots/HomePage_1.png)  
![Home Page - View 2](wwwroot/images/Project%20Screenshots/HomePage_2.png)

## **Login Page**
![Login Page](wwwroot/images/Project%20Screenshots/LoginPage.png)

## **My Cart Page**
![My Cart Page](wwwroot/images/Project%20Screenshots/MyCartPage.png)

## **Payment Options Page**
![Payment Options Page](wwwroot/images/Project%20Screenshots/PaymentOptionsPage.png)

## **Payment Success Page**
![Payment Success Page](wwwroot/images/Project%20Screenshots/PaymentSuccessPage.png)

## **Product Details Page**
![Product Details](wwwroot/images/Project%20Screenshots/ProductDetails_2.png)

## **Products Page**
![Products Page](wwwroot/images/Project%20Screenshots/ProductsPage.png)

## **Profile Page**
![Profile Page](wwwroot/images/Project%20Screenshots/ProfilePage.png)

## **Sign-Up Page**
![Sign-Up Page](wwwroot/images/Project%20Screenshots/SignUpPage.png)

### Access Admin Features:
Login as a user to access features such as: Add to Cart, Buy Products etc.
Use the Admin Login to manage products and categories. 

>>>>>>> 82d1e60e43dd78216c09d3ea5f217ed04b00b37d
