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
    public class HomeController:Controller
    {
        private IRepository Repo { get; }
        public int _itemsPerPage = 10;


        public HomeController(IRepository repository)
        {
            Repo = repository;       
        }

        public ViewResult Index(int productPage=1) => View("Index", new ProductList
            {
                Products = from p in Repo.Product where p.ProductID <= productPage * _itemsPerPage && p.ProductID > (productPage * _itemsPerPage) - _itemsPerPage orderby p.CategoryID descending select p,
                PageInfo = new PageInfo{AllElements = Repo.Product.Count(),ItemsPerPage = _itemsPerPage,ProductPage = productPage  }
            });
    }
}
