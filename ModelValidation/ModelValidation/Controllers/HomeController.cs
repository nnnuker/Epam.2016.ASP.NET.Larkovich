using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Voucher());
        }

		[HttpPost]
	    public ActionResult Index(Voucher model)
	    {
            ValidateVoucherModel(model);
		    return View("Submited", model);
	    }

        public JsonResult ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Json("Please enter voucher name.", JsonRequestBehavior.AllowGet);
            }

            if (name.Length > 4)
            {
                return Json("Voucher name should be less then 50 symbols.", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private void ValidateVoucherModel(Voucher model)
        {
            const string lengthError =
                "Please enter {0} with length less then {1} symbols.";

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("Name", "Please enter voucher name.");
            }
            else if (model.Name.Length > 50)
            {
                ModelState.AddModelError("Name", string.Format(lengthError, "VaucherName", 50));
            }
        }
    }
}