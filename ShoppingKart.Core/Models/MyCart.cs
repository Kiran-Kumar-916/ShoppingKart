﻿using System.ComponentModel.DataAnnotations;

namespace ShoppingKart.Core.Models
{
    public class MyCart
    {

        public  int Id { get; set; }

        public  int ProductId { get; set; }

        public  int SelectedQuantity { get; set; }

    }
}
