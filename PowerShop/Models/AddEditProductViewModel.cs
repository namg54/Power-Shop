using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PowerShop.Models
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }
        [DisplayName("نام محصول")] public string Name { get; set; }

        [DisplayName("توضیحات درباره ی محصول")]
        public string Description { get; set; }

        [DisplayName("قیمت محصول")] public decimal Price { get; set; }
        [DisplayName("موجودی محصول در انبار")] public int QuantityStock { get; set; }
        [DisplayName("تصویر محصول")] public IFormFile Picture { get; set; }
        [DisplayName("گروه ها")] public List<Category> Categories { get; set; }

       
    }
}