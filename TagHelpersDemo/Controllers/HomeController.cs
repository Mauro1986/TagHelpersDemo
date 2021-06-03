using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TagHelpersDemo.Models;

namespace TagHelpersDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Category category = new Category();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Categorys = category.Categorys;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Product product)
        {

            product.BillAmount = product.Cost * product.Quantity;
            if (product.BillAmount > 100 && product.IsPartOfDeal)
            {
                product.Discount = product.BillAmount * 10 / 100;
            }
            else
            {
                product.Discount = product.BillAmount * 5 / 100;
            }

            ViewBag.BillAmount = product.BillAmount;
            ViewBag.Discount = product.Discount;

            product.NetBillAmount = product.BillAmount - product.Discount;


            switch (product.CategoryID)
            {
                case 1:
                case 2:
                    product.NetBillAmount -= 10;
                    ViewBag.NetBillAmount = product.NetBillAmount;
                    break;
                default:
                    break;
            }
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
