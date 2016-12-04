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

            using (var db = new EmbeddedStockContext())
            {
                ViewBag.list = db.Components.ToList<Component>();
            }
             
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
            ViewBag.list = _typeRepo.GetAll().ToList<ComponentType>();
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(ComponentViewModel model)
        {
            //needs to create a category and create the binding to the chosen componenttypes

            using (var db = new EmbeddedStockContext())
            {
                var com = new Component();
                com.ComponentNumber = model.ComponentNumber;
                com.SerialNo = model.SerialNo;
                com.ComponentTypeId = model.ComponentTypeId;
                db.Components.Add(com);
                db.SaveChanges();

            }

            return RedirectToAction("", "component", new { area = "" });
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Show(int id)
        {
            //needs to find a component with its componenttype names in the list
            var comp = new Component();


            var com = new ComponentType();


            using (var db = new EmbeddedStockContext())
            {

               comp = db.Components.Find(id);
               com = db.ComponentTypes.Find(comp.ComponentTypeId);

            }

            ViewBag.component = comp;

            ViewBag.componentType = com;
            return View();
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Edit(int id)
        {
            //needs to find a component with its componenttype
            var compVM = new ComponentViewModel();
            var comp = new Component();

            using (var db = new EmbeddedStockContext())
            {
                comp = db.Components.Find(id);
            }

            compVM.ComponentId = comp.ComponentId;
            compVM.ComponentNumber = comp.ComponentNumber;
            compVM.ComponentTypeId = comp.ComponentTypeId;
            compVM.SearchTerm = comp.SearchTerm;
            compVM.SerialNo = comp.SerialNo;
            

            //var com = new ComponentType();
            //com.ComponentName = "hej";
            //com.ComponentTypeId = 1;
            //var com2 = new ComponentType();
            //com2.ComponentName = "hedsadasj";
            //com2.ComponentTypeId = 2;
            //cat.ComponentType = com;
            ViewBag.list = _typeRepo.GetAll().ToList<ComponentType>();
            return View(compVM);
        }

        [HttpPost]
        public IActionResult Update(CategoryViewModel model)
        {
            //find category and update with new name and component types
            return RedirectToAction("", "component", new { area = "" });
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Delete(int id)
        {
            //delete category and its bindings to componttypes
            using (var db = new EmbeddedStockContext())
            {
                var del = new Component { ComponentId = id };
                db.Components.Remove(del);
                db.SaveChanges();
            }


            return RedirectToAction("", "component", new { area = "" });
        }

        public IActionResult Search(ComponentViewModel model){

            var cat = new ComponentViewModel();
            cat.ComponentNumber = 1231345454;
            //needs list of all component
            cat.SerialNo = "12a3ds12a";
            cat.ComponentId = 2;
            var com = new ComponentType();
            com.ComponentName = "hej";
            com.ComponentTypeId = 1;
            //cat.ComponentType = com;
            //show filtered list of Components in shape of a viewmodel


            using (var db = new EmbeddedStockContext())
            {
                // ViewBag.list = db.Components.ToList<Component>();

                if (model.SearchTerm!=null) { 
                    var tempS = db.Components.Where(c => c.ComponentNumber.ToString().Contains(model.SearchTerm));

                ViewBag.list = tempS.ToList<Component>();
            }

                else
                    ViewBag.list = db.Components.ToList<Component>();
            }

            

            return View("Index", model);
        }

    }
}
