using EmbeddedStock.DataAccess;
using EmbeddedStock.DataAccess.Models;
using EmbeddedStock.Models;
using EmbeddedStock.Models.Loan;
using EmbeddedStock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedStock.Controllers
{
    public class LoanController : Controller
    {
        public IGenericRepository<Component> _componentRepo;
        public IGenericRepository<LoanInformation> _loanInformationRepo;
        public IGenericRepository<Loaner> _loanerRepo;
        public IEmailService _mailService;

        public LoanController(IEmailService mailService, IGenericRepository<Component> componentRepo, IGenericRepository<LoanInformation> loanInformationRepo, IGenericRepository<Loaner> loanerRepo)
        {
            _componentRepo = componentRepo;
            _loanInformationRepo = loanInformationRepo;
            _loanerRepo = loanerRepo;
            _mailService = mailService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddLoan(int componentId)
        {
            var model = new LoanViewModel
            {
                ComponentId = componentId,
                ReturnDate = GetDefaultReturnDate(),
            };

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult SendMailToLateLoaners()
        {
            var currentTime = DateTime.Now;
            var lateLoans = _loanInformationRepo.Get().Where(x => x.ReturnDate < currentTime);
            var emails = new List<string>();
            foreach(var loan in lateLoans)
            {
                emails.Add(loan.LoanOwner.Email);
            }
            try {
                _mailService.SendEmails(emails);
            } catch(Exception e) { }

            foreach(var loan in lateLoans)
            {
                loan.IsEmailSent = true;
            }
            _loanInformationRepo.SaveChanges();
            return RedirectToAction("ShowComponents", "Component");
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddLoan(LoanViewModel model)
        {
                var loaner = AutoMapper.Mapper.Map<Loaner>(model);

                var component = _componentRepo.GetByID(model.ComponentId);
                component.Loaner = loaner;
                _componentRepo.Update(component);

                var loanInformation = new LoanInformation
                {
                    ComponentId = model.ComponentId,
                    IsEmailSent = false,
                    LoanDate = DateTime.UtcNow,
                    ReturnDate = model.ReturnDate,
                    // Not sure what to do with this property, so for now it will be set to UtcNow
                    ReservationDate = DateTime.UtcNow,
                    LoanOwnerId = loaner.Id
                };

                _loanInformationRepo.Insert(loanInformation);

                return RedirectToAction("ShowComponents", "Component");
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowLoan(int loanerId)
        {
            var loan = _loanInformationRepo.Get().FirstOrDefault(x => x.LoanOwner.Id == loanerId);
            var model = AutoMapper.Mapper.Map<LoanViewModel>(loan);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ReturnLoan(LoanViewModel model)
        {
            var loan = _loanInformationRepo.GetByID(model.Id);
            var component = _componentRepo.GetByID(loan.Component.Id);
            component.LoanerId = null;
            _componentRepo.SaveChanges();
            return RedirectToAction("ShowComponents", "Component");
        }

        private DateTime GetDefaultReturnDate()
        {
            // This method would have to be revised for any more serious use, but for now it serves fine for getting a default return date.
            var now = DateTime.UtcNow;
            if(now.Month >= 1 && now.Month <= 7)
            {
                return new DateTime(now.Year, 7, 31);
            } else
            {
                return new DateTime(now.Year + 1, 1, 31);
            }
        }
    }
}