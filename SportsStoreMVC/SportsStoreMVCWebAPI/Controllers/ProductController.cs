using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SportsStoreDomainLibrary.Entity;
using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Concrete;

namespace SportsStoreMVCWebAPI.Controllers
{
    public class ProductController : ApiController
    {
    IProductRepository _productRepository;
     public ProductController()
    {
      _productRepository = new EProductRepository();

    }

    public IEnumerable<Product> Get() => _productRepository.Products.ToList();

    public Product Get(int id) => _productRepository.GetProduct(id);
    [HttpPost]
    public Product Post([FromBody] Product prod)
    {
      var product = _productRepository.AddProduct(prod);
      return product;
    }

    [HttpPut]
    public Product Put(int id,[FromBody] Product prod)
    {
      prod.ProductId = id;
      var product = _productRepository.AddProduct(prod);
      return product;
    }

    [HttpDelete]
    public Product Delete(int id)
    {
      
      var prod = _productRepository.DeleteProduct(id);
      return prod;
    }





  }
}
