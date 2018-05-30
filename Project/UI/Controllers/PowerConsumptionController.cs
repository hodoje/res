using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Models;

namespace UI.Controllers
{
    public class PowerConsumptionController : Controller
    {
        // GET: PowerConsumption
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetData(InputDate inputDate)
        {
            TempData["inputDate"] = inputDate;
            return RedirectToAction("ShowData");
        }

        public ActionResult ShowData()
        {
            InputDate inputDate = (InputDate) TempData["inputDate"];
            return View(inputDate);
        }
    }
}
