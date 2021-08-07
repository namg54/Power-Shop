using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [DisplayName("نام محصول")]
        public string ProductName { get; set; }
        [DisplayName("توضیحات محصول")]
        public string ProductDescription { get; set; }
        public int IdItem  { get; set; }
       


        public ICollection<CategoryrelProduct> CategoryrelProducts { get; set; }

        [ForeignKey("IdItem")]
        public Item Item { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }


    }
}
