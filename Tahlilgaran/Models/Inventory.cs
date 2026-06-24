using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tahlilgaran.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }

        public string Title { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }
    }
}
