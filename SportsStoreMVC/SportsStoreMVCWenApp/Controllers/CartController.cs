using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entity;
using SportsStoreMVCWenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStoreMVCWenApp.Controllers
{
    public class CartController:Controller
    {
    private readonly IProductRepository _productRepository;

    public CartController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    private Cart GetCart()
    {
      Cart cart = (Cart)Session["cart"];
      if(cart==null)
      {
        cart = new Cart();
        Session["cart"] = cart;
      }
      return cart;
    }

    public ActionResult Index(string returnUrl)
    {
      return View(new CartIndexViewModels { Cart=GetCart(),ReturnUrl=returnUrl});
    }

    public ViewResult Summary() { return View(GetCart()); }

    public RedirectToRouteResult AddToCart(int? productId,string returnurl)
    {
      Product prod = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
      if(prod!=null)
      {
        GetCart().AddItem(prod, 1);
      }
      return RedirectToAction("Index", new { returnurl });
    }

    public RedirectToRouteResult RemoveFromCart(int productId,string returnUrl)
    {
      Product prod = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
      if(prod!=null)
      {
        GetCart().RemoveLine(prod);
      }
      return RedirectToAction("Index", new { returnUrl });
    }
    public ViewResult Checkout() { return View(); }

    [HttpPost]

    public ViewResult Checkout(Customer customer) 
    {
    if(ModelState.IsValid)
      {
        GetCart().Clear();
        return View("Thankyou", customer);
      }
      return View();
    }

  }
}
