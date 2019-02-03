using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Models.ViewModels
{
    public class PageInfo
    {
        public int ItemsPerPage { get; set; }
        public int ProductPage { get; set; }
        public int AllElements { get; set; }
        public int TotalPages => (int) Math.Ceiling((decimal) (AllElements/ItemsPerPage)+1) ;
    }
}
