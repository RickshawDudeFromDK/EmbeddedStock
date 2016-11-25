using EmbeddedStock.DataAccess;
using EmbeddedStock.DataAccess.Models;
using EmbeddedStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedStock.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository<InfoPage> _infoPageRepo;

        public HomeController(IGenericRepository<InfoPage> infoPageRepo)
        {
            _infoPageRepo = infoPageRepo;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditAbout()
        {
            var infoPage = _infoPageRepo.Get().First();
            var infoPageViewModel = new InfoPageViewModel
            {
                PageContent = infoPage.PageContent
            };
            return View(infoPageViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditAbout(InfoPageViewModel model)
        {
            var entity = _infoPageRepo.Get().First();
            entity.PageContent = model.PageContent;
            _infoPageRepo.Update(entity);
            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            var infoPage = _infoPageRepo.Get().First();
            var infoPageViewModel = new InfoPageViewModel
            {
                Id = infoPage.Id,
                PageContent = infoPage.PageContent
            };
            return View(infoPageViewModel);
        }
    }
}