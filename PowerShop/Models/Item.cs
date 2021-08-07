using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShop.Models
{
    public class Item
    {
        [Key]
        public int IdItem { get; set; }
        public decimal PriceItem { get; set; }
        public int QuantityInStock { get; set; } 


        public Product Product { get; set; }
    }
}
