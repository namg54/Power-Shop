using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

namespace PowerShop.Models
{
    
    public class CategoryrelProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        //Navigation Property
        public Category Category { get; set; }
        public Product Product { get; set; }


    }
}
