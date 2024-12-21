using FirstMVCapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;


namespace FirstMVCapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var AllProducts = _context.Products.ToList();
            return View(AllProducts);
        }

        ///////////////////////////////////////////////////////////////////////////////////
        public IActionResult Products()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized("You do not have permission to access this page. Please login as Admin.");
            }

            var AllProducts = _context.Products.ToList();
            return View(AllProducts);
        }

        public IActionResult ProductsCreateEdit(int? Id)
        {
            if (Id != null)
            {
                var EditProduct = _context.Products.FirstOrDefault(i => i.Id == Id);
                return View(EditProduct);
            }

            return View();
        }

        public IActionResult ProductsCreateEditForm(Product? model)
        {

            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("ProductsCreateEdit");
            //}

            if (model.Id == 0)
            {
                //_context.Products.Name = model.Name;
                //_context.Products.Description = model.Description;
                //_context.Products.Category = model.Category;
                //_context.Products.Price = model.Price;
                //_context.SaveChanges();

                
                _context.Products.Add(model);
                _context.SaveChanges();
            }
            else
            {
                _context.Products.Update(model);
                _context.SaveChanges();
            }
        
            return RedirectToAction("Products");
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
            if (Id != null)
            {
                var DeleteProduct = _context.Products.FirstOrDefault(i => i.Id == Id);
                _context.Products.Remove(DeleteProduct);
                _context.SaveChanges();
            }

            return RedirectToAction("Products");
        }
        ///////////////////////////////////////////////////////////////////////////////////

        public IActionResult Categories()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized("You do not have permission to access this page. Please login as Admin.");
            }

            var AllCategories = _context.Categories.ToList();
            return View(AllCategories);
        }

        public IActionResult CategoriesCreateEdit(int? Id)
        {
            if (Id != null)
            {
                var EditCategory = _context.Categories.FirstOrDefault(i => i.Id == Id);
                return View(EditCategory);
            }

            return View();
        }

        public IActionResult CategoriesCreateEditForm(Category? model)
        {

            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("CategoriesCreateEdit");
            //}

            if (model is null || model.Id == 0)
            {
                //_context.Categories.Name = model.Name;
                //_context.Categories.Description = model.Description;
                //_context.Categories.TaxRate = model.TaxRate;
                //_context.SaveChanges();


                _context.Categories.Add(model);
                _context.SaveChanges();
            }
            else
            {
                _context.Categories.Update(model);
                _context.SaveChanges();
            }

            return RedirectToAction("Categories");
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
            if (Id != null)
            {
                var DeleteCategory = _context.Categories.FirstOrDefault(i => i.Id == Id);
                _context.Categories.Remove(DeleteCategory);
                _context.SaveChanges();
            }

            return RedirectToAction("Categories");
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

            if (Id != null)
            {
                var BuyProduct = _context.Products.FirstOrDefault(i => i.Id == Id);
                return View(BuyProduct);
            }
                return View();
        }
        ///////////////////////////////////////////////////////////////////////////////////
        
        public IActionResult DecideAction(string actions, int id, int QuantityVariable)
        {
            switch  (actions)
            {
            case "Buy Now":
                    return RedirectToAction("BuyNow", new { id= id, QuantityVariable = QuantityVariable });
            case "Add to Cart" :
                    return RedirectToAction("MyCart", new { id = id, QuantityVariable = QuantityVariable });
            default:
                    //if no action then route to Home page
                    return RedirectToAction("index");
            }
        }


        public IActionResult BuyNow(int Id, int QuantityVariable)
        {
            var SelectedProduct = _context.Products.FirstOrDefault(p => p.Id == Id);

            var model = new CartProductViewModel
            {
                CartProperty = new MyCart { ProductId = Id, SelectedQuantity = QuantityVariable },
                ProdProperty = new Product {Id= SelectedProduct.Id, Name = SelectedProduct.Name, Price = SelectedProduct.Price, Discount = SelectedProduct.Discount }
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


        public IActionResult MyCart(int Id, int QuantityVariable)
        {
            if (String.IsNullOrEmpty( HttpContext.Session.GetString("Role")))
            {
                return Unauthorized("Please login to your account before using this feature.");
            }

            if (Id != 0 && QuantityVariable != 0)
            {
                var SelectedProduct = _context.Products.FirstOrDefault(i => i.Id == Id);

                if (SelectedProduct != null) // To Just Ensure the product exists
                {
                    var AlreadyPresentInCart = _context.MyCartItems.FirstOrDefault(i => i.Id == Id);
                    
                    if (AlreadyPresentInCart is null) //if not present already
                    { 
                        var NewCartItem = new MyCart { ProductId = SelectedProduct.Id, SelectedQuantity = QuantityVariable };

                        _context.MyCartItems.Add(NewCartItem);
                        _context.SaveChanges();
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


            var CartProductViewModels = _context.MyCartItems.Select(cart => new CartProductViewModel
            {
                CartProperty= cart,
                ProdProperty = _context.Products.FirstOrDefault(p => p.Id == cart.ProductId)
            }).ToList();    

            return View(CartProductViewModels);
        }

        public IActionResult MyCartEditForm(List<CartProductViewModel> model)
        {
            //TempData["fromCart"] = "YES";
            TempData["CartProductModel"] = JsonConvert.SerializeObject(model);
            return RedirectToAction("Payment");
        }

        public IActionResult MyCartDeleteForm(int Id)
        {

            if (Id != 0 )
            {
                var ToBeDeletedCartItem = _context.MyCartItems.FirstOrDefault(i => i.Id == Id);

                if (ToBeDeletedCartItem != null) // To Just Ensure the Cart item exists
                {
                        _context.MyCartItems.Remove(ToBeDeletedCartItem);
                        _context.SaveChanges();
                }
            }

            return RedirectToAction("MyCart");
        }

        ///////////////////////////////////////////////////////////////////////////////////

        public IActionResult Payment()
        {

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Role")))
            {
                return Unauthorized("Please login to your account before using this feature.");
            }

            //string fromCart = (string) TempData["fromCart"];
            if (TempData["CartProductModel"] is not null)
            { 
                string CartProductModel = (string) TempData["CartProductModel"];
                List<CartProductViewModel> CartProductViewModel1 = JsonConvert.DeserializeObject<List<CartProductViewModel>>(CartProductModel);
            

                decimal firstTotal = 0;
                decimal amountAfterDiscount = 0;
                string InvoiceSummary = "";
                decimal GrandTotal = 0;


                //switch (fromCart)
                //{
                //    case "YES":
                //    case "NO":
                //SET ViewBag.InvoiceSummary
                //var GrandTotal = _context.MyCartItems.Sum(x => x.SelectedQuantity);
                //ViewBag.GrandTotal = GrandTotal;
                //return View();
                if (CartProductViewModel1 is not null)
                { 
                    foreach (var modelItem in CartProductViewModel1)
                    {
                        //if (model.CartProperty.selectedQuantity[i] != 0)
                        //{
                        //    var SelectedProduct = _context.Products.FirstOrDefault(x => x.Id == model.CartProperty.Id[i]);

                        //    if (SelectedProduct != null) // To Just Ensure the product exists
                        //    {


                                firstTotal = modelItem.ProdProperty.Price * modelItem.CartProperty.SelectedQuantity;
                                amountAfterDiscount = firstTotal * modelItem.ProdProperty.Discount / 100;

                                //if (InvoiceSummary != "") { InvoiceSummary = InvoiceSummary + "<br/>"; }
                                //InvoiceSummary = InvoiceSummary + modelItem.ProdProperty.Name + " x " + modelItem.CartProperty.SelectedQuantity + "units = Rs." + firstTotal + ".  After " + modelItem.ProdProperty.Discount + "% discount => Rs." + amountAfterDiscount + ".";
                                GrandTotal += amountAfterDiscount;

                                
                        //    }
                        //}
                    }
                }

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
            return Index();
        }


        public IActionResult Success(string PaymentOpt)
        {
            var userInfo = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            ViewBag.PaymentOpt = PaymentOpt;
            return View(userInfo);
        }
        ///////////////////////////////////////////////////////////////////////////////////


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
