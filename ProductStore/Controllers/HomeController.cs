using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Models;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace ProductStore.Controllers
{
    public class HomeController:Controller
    {
        private IRepository repo;
        public int pageSize = 10;

        public HomeController(IRepository repository)
        {
            repo = repository;       
        }

        public ViewResult Index(int page=1) => View("Index", from p in repo.Product where p.ProductID > (page - 1) * pageSize && p.ProductID <= page * pageSize select p);
    }
}
