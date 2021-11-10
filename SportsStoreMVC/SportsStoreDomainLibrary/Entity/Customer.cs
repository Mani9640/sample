using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SportsStoreDomainLibrary.Entity
{
    public class Customer
    {
       [Required(ErrorMessage ="Customer name is Required")] 
       public string CustomerName { get; set; }


    [Required(ErrorMessage = "Phone is Required")]
    public string Phone{ get; set; }

    [Required(ErrorMessage = "Email is Required")]
    [EmailAddress(ErrorMessage ="Enter a valid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Address is Required")]
    public string Address { get; set; }

    [Display(Name = "Credit Card Name")]
    public string CCCard { get; set; }





  }
}
