using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Models.ViewModels
{
    public class ProductList
    {
        public IEnumerable<Products> Products { get; set; }
        public PageInfo PageInfo;
    }
}
