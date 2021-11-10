using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStoreDomainLibrary.Entity
{
    public class Cart
    {
    private List<CartLine> _lineCollection;
        public Cart()
      {
      _lineCollection = new List<CartLine>();
      }
     public IEnumerable<CartLine> Lines { get { return _lineCollection; } }

     public void Clear() { _lineCollection.Clear(); }

    public decimal ComputeTotalValue() => _lineCollection.Sum(p => p.Product.Price * p.Quantity);


    public void RemoveLine(Product product) => _lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);

    public void AddItem(Product product,int quantity)
    {
      CartLine line = _lineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);
      if(line==null)
      {
        _lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
      }
      else
      {
        line.Quantity += quantity;
      }
    }
    }
}
