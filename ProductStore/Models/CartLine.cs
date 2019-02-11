using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Models
{
    public class CartLine
    {
        public Products Product { get; set; }
        public int CartLineId { get; set; }
        public int Quantity { get; set; }
    }
}
