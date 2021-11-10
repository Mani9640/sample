using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStoreDomainLibrary.Concrete
{
  public class EProductRepository : IProductRepository

  {
    private SportsStoreDbContext _context;

    public EProductRepository()
    {
      _context = new SportsStoreDbContext();
    }
    public IEnumerable<Product> Products => _context.Products.ToList();

    public Product AddProduct(Product product)
    {
      _context.Products.Add(product);
      _context.SaveChanges();
      return product;
    }

    public Product DeleteProduct(int productId)
    {
      Product prod = _context.Products.Find(productId);
      if(prod!=null)
      {
        _context.Products.Remove(prod);
        _context.SaveChanges();
      }
      return prod;
    }

    public Product GetProduct(int productId) => _context.Products.Find(productId);
    

    public Product UpdateProduct(Product product)
    {
      _context.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
      _context.SaveChanges();
      return product;
    }
  }
}
