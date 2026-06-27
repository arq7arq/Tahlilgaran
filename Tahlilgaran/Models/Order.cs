using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tahlilgaran.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public string Device { get; set; }
        public string Problems { get; set; }

        public string UserName { get; set; }
        public string Phone { get; set; }


        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }

        public bool IsDone { get; set; }
        public bool IsComplete { get; set; } // user received


        public ICollection<OrderPrice> OrderPrices { get; set; }
    }
}
