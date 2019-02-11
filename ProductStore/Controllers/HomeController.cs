using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Models;
using ProductStore.Models.ViewModels;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace ProductStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepository Repo { get; }
        public int _itemsPerPage = 10;


        public HomeController(IRepository repository)
        {
            Repo = repository;
        }

        public ViewResult Index(int productPage = 1, int productCategory = 0) =>
            View(new ProductList
            {
                Products = Repo.Product
                    .Join(Repo.Categories, p => p.CategoryID, c => c.CategoryID,
                        (p, c) => (p))
                    .Where(p =>  productCategory == 0 || p.CategoryID == productCategory)
                    .Skip((productPage - 1) * _itemsPerPage)
                    .Take(_itemsPerPage),
                Categories = from c in Repo.Categories select c,
                PageInfo = new PageInfo
                {
                    AllElements = productCategory.Equals(0)
                        ? Repo.Product.Count()
                        : Repo.Product.Count(p => p.CategoryID.Equals(productCategory)),
                    ItemsPerPage = _itemsPerPage, ProductPage = productPage
                }
            });
        
    }


}

