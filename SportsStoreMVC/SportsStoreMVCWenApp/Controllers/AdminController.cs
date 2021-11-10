using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStoreDomainLibrary.Entity;
using SportsStoreDomainLibrary.Abstract;

namespace SportsStoreMVCWenApp.Controllers
{
  public class AdminController:Controller
  {
    private readonly IProductRepository _productRepository;
    public AdminController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public ActionResult Index()
    {
      var productsList = _productRepository.Products.ToList();
      return View(productsList);
    }

    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Product product)
    {
      if (ModelState.IsValid)
      {
        var result = _productRepository.AddProduct(product);
        if(result!=null)
        {
          
          TempData["message"] = $"New Product added with the Id: '{result.ProductId}' and Name:'{result.ProductName}'";
        }
       
      }
      return View(product);
    }
    public ActionResult Edit(int productId)
    {
      var prod = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
      return View(prod);
    }

    [HttpPost]
    public ActionResult Edit(Product product)
    {
      var prod = _productRepository.UpdateProduct(product);
      if(prod !=null)
      {
        TempData["message"] = $"ProductId:'{prod.ProductId}',ProductName:'{prod.ProductName}' has been Updated";
      }
      return View(product);
    }
  }
}