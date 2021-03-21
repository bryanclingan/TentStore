using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TentStore.UI.MVC.Models;
using TentStore.DATA.EF;

namespace TentStore.UI.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            
            var shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
            
            if (shoppingCart == null || shoppingCart.Count == 0)
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
                ViewBag.Message = "There are no books in your cart.";
            }
            
            else
            {
                ViewBag.Message = null;
            }


           
            return View(shoppingCart);
        }

        public ActionResult UpdateCart(int tentID, int qty)
        {
            
            if (qty == 0)
            {
                RemoveFromCart(tentID);
                return RedirectToAction("Index");
            }
            
            Dictionary<int, CartItemViewModel> shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
            
            shoppingCart[tentID].Qty = qty;
            
            Session["cart"] = shoppingCart;
            
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            
            Dictionary<int, CartItemViewModel> shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
            
            shoppingCart.Remove(id);

            return RedirectToAction("Index");
        }
    }
}