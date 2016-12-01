using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmbeddedStockSolution.Models;
using EmbeddedStockSolution.Repositories;
using EmbeddedStockSolution.ViewModels;

namespace EmbeddedStockSolution.Controllers
{
    public class CategoryController : Controller
    {
        private IGeneriskRepository<Category> _categoryRepo;
        private IGeneriskRepository<ComponentType> _typeRepo;
        public CategoryController(IGeneriskRepository<Category> catRepo, IGeneriskRepository<ComponentType> typeRepo)
        {
            _categoryRepo = catRepo;
            _typeRepo = typeRepo;
        }
        private List<int> list;

        public IActionResult Index()
        {
            list = new List<int>{1,2,3,4};
            ViewBag.list = list;
            return View();
        }

        public IActionResult New()
        { 
            var com = new ComponentType();
            com.ComponentName = "hej";
            com.ComponentTypeId = 1;
            ViewBag.list = new List<ComponentType>{com};
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        { 
            
            var cat = new Category();
            cat.Name = model.Name;
            _categoryRepo.Insert(cat);
            
            return RedirectToAction("", "Category", new { area = "" });
        }

        public IActionResult Show()
        {
            Category cat = new Category();
            cat.Name = "hejhejhej";
            ViewBag.list = new List<string>{"hej", "fdfd"};
            ViewBag.category = cat;
            return View();
        }

        public IActionResult Edit()
        {

            list = new List<int>{1,2,3,4};
            ViewBag.list = list;
            return View();
        }

        public IActionResult Update()
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
