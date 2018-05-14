using Microsoft.AspNetCore.Mvc;
using CsTesAspNet.Models;
using System.Linq;

namespace CsTestAspNet.Controllers 
{
    public class HomeController : Controller 
    {
        ProductContext dbContext;
        public HomeController(ProductContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View(dbContext.Products.ToList());
        }

    }
}
