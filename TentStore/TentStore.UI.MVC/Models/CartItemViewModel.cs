using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TentStore.DATA.EF;

namespace TentStore.UI.MVC.Models
{
    public class CartItemViewModel
    {
        public int Qty { get; set; }
        public Tent Product { get; set; }

        public CartItemViewModel(int qty, Tent product)
        {
            Qty = qty;
            Product = product;
        }
    }
}