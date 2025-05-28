using Newtonsoft.Json;
using ShoppingKart.Core.Models;
using ShoppingKart.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.BLL.BusinessLogic
{

    public class PaymentBusinessLogic
    {
        public PaymentBusinessLogic()
        {
        }

        public  List<CartProductViewModel> CalculatePayment(string cartProductModel,ref decimal GrandTotal)
        {
            try
            {

                decimal firstTotal = 0;
                decimal amountAfterDiscount = 0;
                string InvoiceSummary = "";
                GrandTotal = 0;

                List<CartProductViewModel> CartProductViewModel1 = JsonConvert.DeserializeObject<List<CartProductViewModel>>(cartProductModel);

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
                    }

                }     //    }
                      //}
                return CartProductViewModel1;
            }
            catch (Exception ex)
            {
                //Pass to parent procedure to handle there.
                throw new CustomAppException("Some Error in PaymentBusinessLogic. Error: " + ex.Message);
            }
        }
    }
}
    

