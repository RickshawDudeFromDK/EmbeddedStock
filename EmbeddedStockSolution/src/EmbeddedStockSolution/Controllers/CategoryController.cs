using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmbeddedStockSolution.Models;

namespace EmbeddedStockSolution.Controllers
{
    public class CategoryController : Controller
    {
        private List<int> list;

        public IActionResult Index()
        {
            list = new List<int>{1,2,3,4};
            ViewBag.list = list;
            return View();
        }

        public IActionResult New()
        { 
            list = new List<int>{1,2,3,4};
            ViewBag.list = list;
            return View();
        }
        
        public IActionResult Create()
        { 
            list = new List<int>{1,2,3,4};
            ViewBag.list = list;
            return RedirectToAction("Category", "Index", new { area = "" });
        }

        public IActionResult Show()
        {
            list = new List<int>{1,2,3,4};
            ViewBag.list = list;
            return View();
        }

        public IActionResult Edit()
        {

            list = new List<int>{1,2,3,4};
            ViewBag.list = list;
            return View();
        }

        public IActionResult Delete()
        {

            list = new List<int>{1,2,3,4};
            ViewBag.list = list;
            return View();
        }

    }
}
