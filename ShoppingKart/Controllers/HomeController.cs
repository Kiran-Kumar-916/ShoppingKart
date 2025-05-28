using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using ShoppingKart.DAL.Data;
using ShoppingKart.Core.Interfaces;
using ShoppingKart.BLL.Services;
using ShoppingKart.Core.Models;
using ShoppingKart.BLL.BusinessLogic;
using ShoppingKart.Core.Exceptions;
using Azure.Core;

namespace ShoppingKart.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IMyCartServices _myCartServices;
        private readonly ICartProductViewModelServices _CartProductViewModelServices;
        private readonly IUserServices _userServices;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IProductServices productServices, ICategoryServices categoryServices, IMyCartServices myCartServices , IUserServices userServices, ILogger<HomeController> logger, ICartProductViewModelServices CartProductViewModelServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _myCartServices = myCartServices;
            _CartProductViewModelServices = CartProductViewModelServices;
            _userServices = userServices;
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            try
            {
            var AllProducts = _productServices.GetAllProducts();
                foreach (var i in AllProducts)
                    {
                    ViewBag.Z = i.Price;
                }
                return View(AllProducts);
            }
            catch (Exception ex)
            {
                //var model = new ErrorViewModel 
                //{ 
                //    Message = ex.Message,
                //    StackTrace=ex.StackTrace
                //};
                //ViewBag.ErrorMessage = "Other Error -> " + ex.Message;
                //return View("Error", model);
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        public IActionResult Products()
        {
            try
            { 
                if (HttpContext.Session.GetString("Role") != "Admin")
                {
                    return Unauthorized("You do not have permission to access this page. Please login as Admin.");
                }

                var AllProducts = _productServices.GetAllProducts();
                return View(AllProducts);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        public IActionResult ProductsCreateEdit(int? Id)
        {
            try
            {
                if (Id != null) 
                {
                var EditProduct = _productServices.GetProductById(Id.Value);
                return View(EditProduct);
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        public IActionResult ProductsCreateEditForm(Product? product)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return RedirectToAction("ProductsCreateEdit");
                //}

                if (product.Id == 0)
                {
                //_context.Products.Name = model.Name;
                //_context.Products.Description = model.Description;
                //_context.Products.Category = model.Category;
                //_context.Products.Price = model.Price;
                //_context.SaveChanges();
                    _productServices.AddProduct(product);
                }
                else
                {
                    _productServices.UpdateProduct(product);
                }

                return RedirectToAction("Products");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        //public IActionResult ProductsEdit(int Id)
        //{
        //    if (Id != null)
        //    {
        //        var EditProduct = _context.Products.FirstOrDefault(i => i.Id == Id);
        //    }
        //    return RedirectToAction("ProductsCreateEdit");
        //}

        public IActionResult ProductsDelete(int Id)
        {
            try
            {
                if (Id != null)
                {
                    _productServices.DeleteProduct(Id);
                }

                return RedirectToAction("Products");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////

        public IActionResult Categories()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") != "Admin")
                {
                    return Unauthorized("You do not have permission to access this page. Please login as Admin.");
                }

                var AllCategories = _categoryServices.GetAllCategories();
                return View(AllCategories);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        public IActionResult CategoriesCreateEdit(int? Id)
        {
            try
            {
                if (Id != null)
                {
                    var EditCategory = _categoryServices.GetCategoryById(Id.Value);
                    return View(EditCategory);
                }

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        public IActionResult CategoriesCreateEditForm(Category? category)
        {

            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("CategoriesCreateEdit");
            //}
            try
            {
                if (category is null || category.Id == 0)
            {
                //_context.Categories.Name = model.Name;
                //_context.Categories.Description = model.Description;
                //_context.Categories.TaxRate = model.TaxRate;
                //_context.SaveChanges();


                _categoryServices.AddCategory(category);
            }
            else
            {
                _categoryServices.UpdateCategory(category);
            }

            return RedirectToAction("Categories");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        //public IActionResult CategoriesEdit(int Id)
        //{
        //    if (Id != null)
        //    {
        //        var EditProduct = _context.Categories.FirstOrDefault(i => i.Id == Id);
        //    }
        //    return RedirectToAction("CategoriesCreateEdit");
        //}

        public IActionResult CategoriesDelete(int Id)
        {
            try
            {
                if (Id != null)
            {
                _categoryServices.DeleteCategory(Id);
            }

            return RedirectToAction("Categories");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //public IActionResult Customers()
        //{
        //    if (HttpContext.Session.GetString("Role") != "Admin")
        //    {
        //        return Unauthorized("You do not have permission to access this page. Please login as Admin.");
        //    }

        //    var AllCustomers = _context.Customers.ToList();
        //    return View(AllCustomers);
        //}

        //public IActionResult CustomersCreateEdit(int? Id)
        //{
        //    if (Id != null)
        //    {
        //        var EditCustomer = _context.Customers.FirstOrDefault(i => i.Id == Id);
        //        return View(EditCustomer);
        //    }

        //    return View();
        //}

        //public IActionResult CustomersCreateEditForm(Customer? model)
        //{

        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return RedirectToAction("CustomersCreateEdit");
        //    //}

        //    if (model.Id == 0)
        //    {
        //        //_context.Customers.Name = model.Name;
        //        //_context.Customers.Description = model.Description;
        //        //_context.Customers.Address = model.Address;
        //        //_context.Customers.Email = model.Email;
        //        //_context.Customers.PhoneNum = model.PhoneNum;
        //        //_context.SaveChanges();


        //        _context.Customers.Add(model);
        //        _context.SaveChanges();
        //    }
        //    else
        //    {
        //        _context.Customers.Update(model);
        //        _context.SaveChanges();
        //    }

        //    return RedirectToAction("Customers");
        //}

        ////public IActionResult CustomersEdit(int Id)
        ////{
        ////    if (Id != null)
        ////    {
        ////        var EditCustomer = _context.Customers.FirstOrDefault(i => i.Id == Id);
        ////    }
        ////    return RedirectToAction("CustomersCreateEdit");
        ////}

        //public IActionResult CustomersDelete(int Id)
        //{
        //    if (Id != null)
        //    {
        //        var DeleteCustomer = _context.Customers.FirstOrDefault(i => i.Id == Id);
        //        _context.Customers.Remove(DeleteCustomer);
        //        _context.SaveChanges();
        //    }

        //    return RedirectToAction("Customers");
        //}
        ///////////////////////////////////////////////////////////////////////////////////

        public IActionResult ProductDetails(int Id)
        {
            try
            {
                if (Id != null)
            {
                var BuyProduct=_productServices.GetProductById(Id);
                return View(BuyProduct);
            }
            return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////

        public IActionResult DecideAction(string actions, int id, int QuantityVariable)
        {
            try
            {
                switch (actions)
            {
                case "Buy Now":
                    return RedirectToAction("BuyNow", new { id, QuantityVariable });
                case "Add to Cart":
                    return RedirectToAction("MyCart", new { id, QuantityVariable });
                default:
                    //if no action then route to Home page
                    return RedirectToAction("index");
            }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }


        public IActionResult BuyNow(int Id, int QuantityVariable)
        {
            try
            {
                var SelectedProduct = _productServices.GetProductById(Id);

            var model = new CartProductViewModel
            {
                CartProperty = new MyCart { ProductId = Id, SelectedQuantity = QuantityVariable },
                ProdProperty = new Product { Id = SelectedProduct.Id, Name = SelectedProduct.Name, Price = SelectedProduct.Price, Discount = SelectedProduct.Discount }
            };

            List<CartProductViewModel> CartProductViewModel1 = new List<CartProductViewModel>();
            CartProductViewModel1.Add(model);

            //TempData["fromCart"] = "NO";
            TempData["CartProductModel"] = JsonConvert.SerializeObject(CartProductViewModel1);
            return RedirectToAction("Payment");

                //return Ok();
                //return RedirectToAction("BuyNow")                                                                                         

                //In no action then go to HOME
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }


        public IActionResult MyCart(int Id, int QuantityVariable)
        {
            try
            {
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("Role")))
            {
                return Unauthorized("Please login to your account before using this feature.");
            }

            if (Id != 0 && QuantityVariable != 0)
            {
                var SelectedProduct = _productServices.GetProductById(Id);

                if (SelectedProduct != null) // To Just Ensure the product exists
                {
                    var AlreadyPresentInCart = _myCartServices.GetMyCartById(Id);

                    if (AlreadyPresentInCart is null) //if not present already
                    {
                        var NewCartItem = new MyCart { ProductId = SelectedProduct.Id, SelectedQuantity = QuantityVariable };

                        _myCartServices.AddMyCart(NewCartItem);
                    }
                }
            }


            //var AllMyCartItems = _context.MyCartItems.ToList();


            //List<MyCartDetails> AllMyCartItemsDetails = new();
            //foreach (var item in AllMyCartItems)
            //{
            //    var productItem = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);
            //    AllMyCartItemsDetails.Add(new MyCartDetails
            //    {

            //        Id = item.Id,
            //        ProductId = item.ProductId,
            //        Name= productItem.Name,
            //        Price = productItem.Price,
            //        SelectedQuantity = item.Quantity,
            //        Discount    = productItem.Discount,
            //        FinalPrice= ((productItem.Price * item.Quantity) * productItem.Discount) /100
            //    });

            //}

            //return View(AllMyCartItemsDetails);
            
            var CartProductViewModel = _CartProductViewModelServices.GetAllCartProductViewModel(_productServices);

            return View(CartProductViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        public IActionResult MyCartEditForm(List<CartProductViewModel> model)
        {
            try
            {
                //TempData["fromCart"] = "YES";
                TempData["CartProductModel"] = JsonConvert.SerializeObject(model);
            return RedirectToAction("Payment");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        public IActionResult MyCartDeleteForm(int Id)
        {
            try
            {
                if (Id != 0)
            {
                var ToBeDeletedCartItem = _myCartServices.GetMyCartById(Id);

                if (ToBeDeletedCartItem != null) // To Just Ensure the Cart item exists
                {
                    _myCartServices.DeleteMyCart(Id);
                }
            }

            return RedirectToAction("MyCart");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////

        public IActionResult Payment()
        {

            try
            {

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("Role")))
                {
                    return Unauthorized("Please login to your account before using this feature.");
                }

                decimal GrandTotal = 0;
                //string fromCart = (string) TempData["fromCart"];
                if (TempData["CartProductModel"] is not null)
                {
                    string CartProductModel = (string)TempData["CartProductModel"];

                    if (CartProductModel != null)
                    {
                        var PaymentLogic = new PaymentBusinessLogic();
                        List<CartProductViewModel> CartProductViewModel1 = PaymentLogic.CalculatePayment(CartProductModel, ref GrandTotal);

                        ViewBag.GrandTotal = GrandTotal;
                        //ViewBag.InvoiceSummary = InvoiceSummary;
                        return View(CartProductViewModel1);
                        //case "NO":
                        //ViewBag.GrandTotal = GrandTotalPassed;
                        //ViewBag.InvoiceSummary = InvoiceSummaryPassed;
                        //        return View();
                        //    default: 
                        //        return RedirectToAction("Index");
                        //}
                    }
                }
                return Index();
            }
            catch (CustomAppException ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "Custom ErrorMessage: " + ex.Message, ErrorStackTrace = "Custom ErrorStackTrace: " + ex.StackTrace });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }


        public IActionResult Success(string PaymentOpt)
        {
            try
            {
                var userInfo = _userServices.GetUserByName(User.Identity.Name);
            ViewBag.PaymentOpt = PaymentOpt;
            return View(userInfo);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////


        public IActionResult Privacy()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        public IActionResult Error(String ErrorMessage, String ErrorStackTrace)
        {
           
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message=ErrorMessage, StackTrace=ErrorStackTrace });
            
        }
    }
}
