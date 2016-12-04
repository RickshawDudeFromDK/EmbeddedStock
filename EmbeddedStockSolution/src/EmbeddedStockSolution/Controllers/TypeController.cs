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
            
            //needs list of all types
            ViewBag.list = _typeRepo.GetAll().ToList<ComponentType>();
            return View();
        }

        public IActionResult New()
        { 
            var cat = new Category();
            cat.Name = "hej";
            cat.CategoryId = 1;
            //requires list of all categories
            ViewBag.categorylist = _categoryRepo.GetAll().ToList<Category>();
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(TypeViewModel model)
        {
            var com = new ComponentType();
            com.ComponentName = model.Name;
            com.ComponentInfo = model.Info;
            com.ImageUrl = model.ImageUrl;
            com.Location = model.Location;
            com.Manufacturer = model.Manufacturer;

            _typeRepo.Insert(com);

            //create new type and associate with chosen categories
     
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
