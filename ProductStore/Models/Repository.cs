using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Models
{
    public class Repository: IRepository
    {
        private readonly ProductContext _context;

        public Repository(ProductContext context) =>_context = context;

        public IQueryable<Products> Product => _context.Products;
    }
}
