using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Models
{
    public interface IRepository
    {
       IQueryable<Products> Product { get; }
       IQueryable<Categories> Categories { get; }
    }
}
