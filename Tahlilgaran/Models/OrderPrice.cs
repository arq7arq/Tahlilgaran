using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tahlilgaran.Models
{
    public class OrderPrice
    {
        public int OrderPriceID { get; set; }

        public string Title { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
