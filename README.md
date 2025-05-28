# ShoppingKart
ASP.NET MVC application, built using .NET 8.0 and crafted in C# on Visual Studio 2022. This application is to discover amazing products at unbeatable prices.

##Project Overview
The ShoppingKart application is a fully functional e-commerce platform developed using the ASP.NET MVC framework. It enables customers to log in, explore a range of products, add them to a shopping cart, and complete their purchase by choosing from various payment options. The application emphasizes modularity, maintainability, and scalability by implementing Dependency Injection (DI) and following the MVC architectural pattern.

##Key Features:

User Authentication:

Login and Signup functionality for customers.
Admin Login functionality to manage product and category creation, updation, and deletion.
Account Profile management.

Product Management:

Browse products by category.
View detailed product descriptions.

Cart Management:

Add products to the shopping cart.
View and update the cart (e.g., quantity changes, product removal).

Order Placement:

Proceed to checkout.
Choose payment methods and complete the purchase.

Application Configuration:
Connection settings, including server name and database name (ShoppingKart), are managed in appsettings.json.

Technology Stack:
Framework: ASP.NET MVC
Database: SQL Server
Dependency Injection: Configured using ASP.NET Core DI container
ORM: Entity Framework Core
Frontend: Razor Views

Database Context:
ApplicationDbContext.cs: This class serves as the central point for database access, mapping models such as Category, Product, MyCart, and User to corresponding database tables.

#Models:
ApplicationDbContext.cs: Defines the database context and manages entity configurations.
CartProductViewModel: Represents the data structure combining product and cart details.
Category: Represents product categories.
ErrorViewModel: Handles error information.
MyCart: Represents products added to the cart by users.
Product: Represents individual product details.
User.cs: Manages customer information, including authentication and profile details.


#Views:
Accounts Folder:
Loginform.cshtml: For user login.
Profile.cshtml: Displays and manages user profile.
SignUp.cshtml: For user registration.
Home Folder:
Categories.cshtml & CategoriesCreatEdit.cshtml: Manage and display product categories.
Index.cshtml: Home page view.
MyCart.cshtml: Displays products added to the cart.
Payment.cshtml: Payment processing view.
Privacy.cshtml: Privacy policy details.
Products.cshtml & Productdetails.cshtml: Display product list and detailed product descriptions.
ProductCreatEdit.cshtml: For creating and editing product details.
Success.cshtml: Order confirmation view.


#Controllers:
AccountController:

Manages authentication, including login, signup, and profile updates.
Handles views like Loginform.cshtml, Profile.cshtml, and SignUp.cshtml.

HomeController:

Manages the main shopping flow, including category and product displays, cart handling, and order placement.
Handles views such as Categories, CategoriesCreatEdit, Index, MyCart, Payment, Privacy, Products, Productdetails, ProductCreatEdit, and Success.cshtml.

#Database Connection:
Managed in appsettings.json with details for the server and database (ShoppingKart).
Dependency Injection:
Configured for services like DbContext and application-specific dependencies.

#Conclusion:
The ShoppingKart application provides a comprehensive shopping experience with robust architecture, efficient data handling, and clean UI design. It’s a scalable solution with room for enhancements like categorize & show products as per user interesets, provide search & filter options, add additional payment gateways etc.




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