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
    public class TypeController : Controller
    {
        private IGeneriskRepository<Category> _categoryRepo;
        private IGeneriskRepository<ComponentType> _typeRepo;
        public TypeController(IGeneriskRepository<Category> catRepo, IGeneriskRepository<ComponentType> typeRepo)
        {
            _categoryRepo = catRepo;
            _typeRepo = typeRepo;
        }
        private List<int> list;

        public IActionResult Index()
        {
            var type = new ComponentType();
            type.ComponentName = "example";
            type.ComponentTypeId = 1;
            //needs list of all types
            ViewBag.list = new List<ComponentType>{type};
            return View();
        }

        public IActionResult New()
        { 
            var cat = new Category();
            cat.Name = "hej";
            cat.CategoryId = 1;
            //requires list of all categories
            ViewBag.categorylist = new List<Category>{cat};
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(TypeViewModel model)
        { 
            //create new type and associate with chosen categories
            var cat = new Category();
            cat.Name = model.Name;
            return RedirectToAction("", "type", new { area = "" });
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Show(string id)
        {
            
            Category cat = new Category();
            cat.Name = "hejhejhej";
            ComponentType comtype = new ComponentType();
            comtype.ComponentName = "efdsdf";
            comtype.ComponentTypeId = 1;
            var com = new Component();
            com.ComponentId = 1;
            com.ComponentNumber = 3;
            //needs to find a Componenttype with its categories names and components in 2 lists
            ViewBag.componentList = new List<Component>{com};
            ViewBag.categoryNames = new List<string>{"fds", "fds"};
            ViewBag.component_type = comtype;
            return View();
        }
    }
}
