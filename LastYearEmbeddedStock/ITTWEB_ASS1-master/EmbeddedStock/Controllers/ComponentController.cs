using EmbeddedStock.DataAccess;
using EmbeddedStock.DataAccess.Models;
using EmbeddedStock.Models;
using EmbeddedStock.Models.Loan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedStock.Controllers
{
    public class ComponentController : Controller
    {
        private IGenericRepository<Component> _componentRepo;
        private IGenericRepository<ComponentCategory> _categoryRepo;
        private IGenericRepository<ComponentType> _typeRepo;
        public int PageSize = 5;
        public ComponentController(IGenericRepository<Component> compRepo, IGenericRepository<ComponentCategory> catRepo, IGenericRepository<ComponentType> typeRepo)
        {
            _componentRepo = compRepo;
            _categoryRepo = catRepo;
            _typeRepo = typeRepo;
        }

        // GET: Admin
        public ActionResult Index()
        {
             return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddComponent()
        {
            var result = new ComponentViewModel
            {
                AvailableTypes = AutoMapper.Mapper.Map<List<ComponentTypeViewModel>>(_typeRepo.Get())
            };
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditComponent(int id)
        {
            var result = AutoMapper.Mapper.Map<ComponentViewModel>(_componentRepo.GetByID(id));
            result.AvailableTypes = AutoMapper.Mapper.Map<List<ComponentTypeViewModel>>(_typeRepo.Get());
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditType(int id)
        {
            var model = AutoMapper.Mapper.Map<ComponentTypeViewModel>(_typeRepo.GetByID(id));
            model.AvailableCategories = AutoMapper.Mapper.Map<List<ComponentCategoryViewModel>>(_categoryRepo.Get());
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditType(ComponentTypeViewModel model)
        {
            var updatedEntity = AutoMapper.Mapper.Map<ComponentType>(model);
            _typeRepo.Update(updatedEntity);
            return RedirectToAction("ShowTypes");
        }


        [HttpPost]
        [Authorize]
        public ActionResult EditComponent(ComponentViewModel model)
        {
            var updatedEntity = AutoMapper.Mapper.Map<Component>(model);
            _componentRepo.Update(updatedEntity);
            return RedirectToAction("ShowComponents");
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComponent(ComponentViewModel model)
        {
            var newEntity = AutoMapper.Mapper.Map<Component>(model);
            _componentRepo.Insert(newEntity);
            return RedirectToAction("ShowComponents");
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddComponentCategory()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddComponentType()
        {
            var result = new ComponentTypeViewModel
            {
                AvailableCategories = AutoMapper.Mapper.Map<List<ComponentCategoryViewModel>>(_categoryRepo.Get())
            };
            return View(result);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComponentType(ComponentTypeViewModel model)
        {
            var newEntity = AutoMapper.Mapper.Map<ComponentType>(model);
            _typeRepo.Insert(newEntity);
            return RedirectToAction("ShowTypes");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Error()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowComponentsInCategory(int id, int page = 1)
        {
            var components = _componentRepo.Get().Where(x => x.Type.CategoryId == id);
            var result = new ShowComponentsViewModel()
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = components.Count()
                }
            };
            components = components.OrderBy(c => c.Id).Skip((page - 1) * PageSize).Take(PageSize);
            result.Components = AutoMapper.Mapper.Map<List<ComponentViewModel>>(components);
            ViewBag.viewType = "ByCategory";
            return View("ShowComponents", result);

            }

        [HttpPost]
        [Authorize]
        public ActionResult AddComponentCategory(ComponentCategoryViewModel model)
        {
            var newEntity = AutoMapper.Mapper.Map<ComponentCategory>(model);
            _categoryRepo.Insert(newEntity);
            return RedirectToAction("ShowCategories");
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteComponent(int id)
        {
            _componentRepo.Delete(id);
            return RedirectToAction("ShowComponents");
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowCategories(int page = 1)
        {
            var categories = _categoryRepo.Get();
            var result = new ShowCategoriesViewModel()
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = categories.Count()
                }
            };
            categories = categories.OrderBy(c => c.Id).Skip((page - 1) * PageSize).Take(PageSize);
            result.Categories = AutoMapper.Mapper.Map<List<ComponentCategoryViewModel>>(categories);
            return View(result);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteType(int id)
        {
            _typeRepo.Delete(id);
            return RedirectToAction("ShowTypes");
        }

        [HttpGet]
        [Authorize]
        public ActionResult SearchComponent()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult SearchComponent(ComponentViewModel model)
        {
            var comp = _componentRepo.Get().FirstOrDefault(x => x.ComponentNumber == model.ComponentNumber);
            var result = AutoMapper.Mapper.Map<ComponentViewModel>(comp);
            if (result != null)
            {
                return View("Details", result);
            }
            ViewBag.Message = "Component could not be found.";
            return RedirectToAction("Error");
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowTypes(int page = 1)
        {
            var types = _typeRepo.Get();
            var result = new ShowTypesViewModel()
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = types.Count()
                }
            };
            var cat = _categoryRepo.Get();
            types = types.OrderBy(c => c.Id).Skip((page - 1) * PageSize).Take(PageSize);
            result.Types = AutoMapper.Mapper.Map<List<ComponentTypeViewModel>>(types);
            return View(result);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var result = AutoMapper.Mapper.Map<ComponentCategoryViewModel>(_categoryRepo.GetByID(id));
            return View(result);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteCategory(int id)
        {
            _categoryRepo.Delete(id);
            return RedirectToAction("ShowCategories");
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditCategory(ComponentCategoryViewModel model)
        {
            var updatedEntity = AutoMapper.Mapper.Map<ComponentCategory>(model);
            _categoryRepo.Update(updatedEntity);
            return RedirectToAction("ShowCategories");
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowComponents(int page = 1)
        {
            var components = _componentRepo.Get();
            var result = new ShowComponentsViewModel()
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = components.Count()
                }
            };
            components = components.OrderBy(c => c.Id).Skip((page - 1) * PageSize).Take(PageSize);
            result.Components = AutoMapper.Mapper.Map<List<ComponentViewModel>>(components);
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowLoanedComponents(int page = 1)
        {
            var loanedComponents = _componentRepo.Get().Where(x => x.Loaner != null);
            var result = new ShowComponentsViewModel()
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = loanedComponents.Count()
                }
            };
            loanedComponents = loanedComponents.OrderBy(c => c.Id).Skip((page - 1) * PageSize).Take(PageSize);
            result.Components = AutoMapper.Mapper.Map<List<ComponentViewModel>>(loanedComponents);
            ViewBag.viewType = "LoanedComponents";
            return View("ShowComponents", result);
        }
    }
}