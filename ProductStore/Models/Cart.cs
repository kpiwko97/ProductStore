using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> GetLines => lineCollection;

        public void AddItem(Products product, int quantity)
        {
            IEnumerable<CartLine> cartline =
                from l in lineCollection where product.ProductID.Equals(l.Product.ProductID) select l;
            var line = cartline.FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine {Product = product, Quantity = quantity});
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId, int quantity)
        {
            IEnumerable<CartLine> cartLine =
                from l in lineCollection where l.Product.ProductID.Equals(productId) select l;
            CartLine cart = cartLine.FirstOrDefault();
            lineCollection.Remove(cart);
        }

        public decimal ComputeAllValue() => lineCollection.Sum(a=>a.Product.UnitPrice*a.Quantity);

    }
}
