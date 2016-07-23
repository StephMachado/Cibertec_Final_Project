using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Models;
using WebDeveloper.Model;

namespace WebDeveloper.Areas.Personal.Controllers
{
    [Authorize]
    public class PersonalController : Controller
    {
        private readonly PersonRepository _personalRepository;
        public PersonalController(PersonRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public ActionResult Index()
        {
            return View(_personalRepository.GetListDto());
        }

        public PartialViewResult EmailList(int? id)
        {
            if(!id.HasValue) return null;
            return PartialView("_EmailList",_personalRepository.EmailList(id.Value));
        }

        public PartialViewResult Create()
        {
            return  PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid) return PartialView("_Create", person);
            person.rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            person.BusinessEntity = new BusinessEntity
            {
                rowguid = person.rowguid,
                ModifiedDate = person.ModifiedDate
            };
            _personalRepository.Add(person);
            return RedirectToAction("Index");
        }
       
        public PartialViewResult Edit(int? id)
        {
            if (!id.HasValue) return null;
            Person person = _personalRepository.GetPerson(id.Value);
            if (person == null) return null;
            return PartialView("_Edit", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid) return PartialView("_Edit", person);
            person.ModifiedDate = DateTime.Now;
            person.BusinessEntity = _personalRepository.GetBusinessEntity(person.BusinessEntityID);
            {
                person.BusinessEntity.ModifiedDate = person.ModifiedDate;
            };
            _personalRepository.Update(person);
            return RedirectToAction("Index");
        }

    }
}