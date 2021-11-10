using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsStoreDomainLibrary.Entity
{
    public class Product
    {
     public int ProductId { get; set; }

    [Display(Name = "Product Name"), Required(ErrorMessage = "Enter a Product name")]
    public string ProductName { get; set; }
    [Required(ErrorMessage ="Enter a description")]
    public string Description { get; set; }

    [Required(ErrorMessage ="Enter a Price")]
    [Range(0.01,double.MaxValue,ErrorMessage ="Enter a positive price")]

    public decimal Price { get; set; }
    [Required(ErrorMessage ="Enter a category")]

    public string Category { get; set; }
  

    }
}
