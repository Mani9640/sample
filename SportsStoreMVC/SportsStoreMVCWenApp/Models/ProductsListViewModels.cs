using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStoreDomainLibrary.Entity;
using SportsStoreMVCWenApp.Infrastructure;

namespace SportsStoreMVCWenApp.Models
{
  public class ProductsListViewModels
  {
    public IEnumerable<Product> Products { get; set; }
    public GPager GPager { get; set; }
  }
}