using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Areas.Personal.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private readonly AddressRepository _addressRepository;
        public AddressController(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: Personal/Address
        [OutputCache(Duration = 0)]
        public ActionResult Index()
        {
            return View(_addressRepository.GetListDto());
        }
    }
}