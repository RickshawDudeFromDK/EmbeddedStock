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
    public class ComponentController : Controller
    {
        private IGeneriskRepository<Category> _categoryRepo;
        private IGeneriskRepository<ComponentType> _typeRepo;
        public ComponentController(IGeneriskRepository<Category> catRepo, IGeneriskRepository<ComponentType> typeRepo)
        {
            _categoryRepo = catRepo;
            _typeRepo = typeRepo;
        }
        private List<int> list;

        public IActionResult Index()
        {
            var cat = new ComponentViewModel();
            cat.ComponentNumber = 1231345454;
            //needs list of all component
            cat.SerialNo = "12a3ds12a";
            cat.ComponentId = 2;
            var com = new ComponentType();
            com.ComponentName = "hej";
            com.ComponentTypeId = 1;
            cat.ComponentType = com;
            ViewBag.list = new List<ComponentViewModel>{cat};
            return View();
        }

        public IActionResult New()
        { 
            var cat = new ComponentViewModel();
            cat.ComponentNumber = 1231345454;
            //needs list of all component
            cat.SerialNo = "12a3ds12a";
            cat.ComponentId = 2;
            var com = new ComponentType();
            com.ComponentName = "hej";
            com.ComponentTypeId = 1;
            var com2 = new ComponentType();
            com2.ComponentName = "hedsadasj";
            com2.ComponentTypeId = 4;
            //requires list of all component types
            ViewBag.list = new List<ComponentType>{com, com2};
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(ComponentViewModel model)
        { 
            //needs to create a category and create the binding to the chosen componenttypes
            return RedirectToAction("", "component", new { area = "" });
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Show(string id)
        {
            //needs to find a category with its componenttype names in the list
            Category cat = new Category();
            cat.Name = "hejhejhej";
            ComponentType com = new ComponentType();
            com.ComponentName = "efdsdf";
            com.ComponentTypeId = 1;
            ViewBag.componentList = new List<ComponentType>{com};
            ViewBag.category = cat;
            return View();
        }

        [HttpGet("{category}/[action]/{id}")]
        public IActionResult Edit(string id)
        {
            //needs to find a category with its componenttypes
            Category cat = new Category();
            cat.Name = "hejhejhej";
            cat.CategoryId = 1;
            ComponentType com = new ComponentType();
            com.ComponentName = "efdsdf";
            com.ComponentTypeId = 1;
            ViewBag.componentList = new List<ComponentType>{com};
            ViewBag.existingComponentList = new List<string>{"fdsf", "fds"};
            ViewBag.category = cat;
            return View();
        }

        [HttpPost]
        public IActionResult Update(CategoryViewModel model)
        {
            //find category and update with new name and component types
            return RedirectToAction("", "category", new { area = "" });
        }

        [HttpGet("{category}/[action]/{id}")]
        public IActionResult Delete()
        {
            //delete category and its bindings to componttypes
            return RedirectToAction("", "category", new { area = "" });
        }

    }
}
