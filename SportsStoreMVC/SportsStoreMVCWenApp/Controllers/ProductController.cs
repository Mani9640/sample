using System.Web.Mvc;
using SportsStoreDomainLibrary.Abstract;
using LoggingLibrary;
using System.Linq;
using SportsStoreMVCWenApp.Models;
using SportsStoreMVCWenApp.Infrastructure;

namespace SportsStoreMVCWenApp.Controllers
{


  public class ProductController : Controller
    {
    private readonly IProductRepository _productRepository;
    private readonly ILogger _logger;
    private int _pageSize;
    public ProductController(IProductRepository productRepository,ILogger logger)
    {
     
      _productRepository = productRepository;
      _logger = logger;
      _pageSize = 4;
    }
        public ActionResult List(string category, int page=1)

    {
      ViewBag.currentCategory = category;

      var productList = _productRepository.Products.Where(p => category == null ? true : p.Category==category).OrderBy(p => p.ProductId);


      var productsListViewModels = new ProductsListViewModels
      {
        Products = productList.Skip((page - 1) * _pageSize).Take(_pageSize).ToList(),
        GPager = new GPager(productList.Count(), page, _pageSize)

      };
      return View(productsListViewModels);
      #region Without Category

      //var productList = _productRepository.Products.OrderBy(p => p.ProductId);


      //var productsListViewModels = new ProductsListViewModels
      //{
      //  Products = productList.Skip((page - 1) * _pageSize).Take(_pageSize).ToList(),
      //  GPager = new GPager(productList.Count(), page, _pageSize)

      //};
      //return View(productsListViewModels); 
      #endregion


      #region RawPaging

      //var productList = _productRepository.Products.OrderBy(p=>p.ProductId).Skip((page-1) *_pageSize).Take(_pageSize).ToList();


      //_logger.LogMessage("ProductionController", "List", TimeSpan.Zero, $"Get all Products  from repository");
      // To the view only one object can be passed  all others are string 
      #endregion


      #region Withoutpaging

      //var productList = _productRepository.Products;
      //_logger.LogMessage("ProductionController", "List", TimeSpan.Zero, $"Get all Products  from repository");
      //return View(productList);
      #endregion


    }
    }
}