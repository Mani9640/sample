using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStoreDomainLibrary.Abstract;

namespace SportsStoreMVCWenApp.Controllers
{
  public class NavController : Controller
  {
    private readonly IProductRepository _productRepository;
    public NavController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    public PartialViewResult Menu(string category=null)
    {
      ViewBag.selectedCategory = category;
      var result = _productRepository.Products.Select(p => p.Category).Distinct().OrderBy(p => p);
      return PartialView(result);
    }
  }
}