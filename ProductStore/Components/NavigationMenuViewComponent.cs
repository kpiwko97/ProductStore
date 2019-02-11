using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using ProductStore.Models;

namespace ProductStore.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private readonly IRepository _repository;

        public NavigationMenuViewComponent(IRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {

            var category=RouteData.Values["productCategory"]?? "0";
            ViewBag.ActualCategory = Int32.Parse((string) category);
            return View(from r in _repository.Categories select r.CategoryName);
        } 
            
        
    }
}
