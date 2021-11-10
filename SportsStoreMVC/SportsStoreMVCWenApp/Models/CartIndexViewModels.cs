using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreDomainLibrary.Entity;

namespace SportsStoreMVCWenApp.Models
{
    public class CartIndexViewModels
    {
        public Cart Cart { get; set; }
    public string ReturnUrl { get; set; }
    }
}
