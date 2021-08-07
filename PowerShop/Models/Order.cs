using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        public bool IsFinaly { get; set; }

        //Nav
        [ForeignKey("UserId")]
        public Users users { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
