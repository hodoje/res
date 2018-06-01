using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Models;
using DataAccess;

namespace UI.Controllers
{
    public class PowerConsumptionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PowerConsumptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
            List<PowerConsumptionData> listOfData = (List<PowerConsumptionData>)_unitOfWork
                                                                                .PowerConsumptionDataRepository
                                                                                .Find(x => x.Timestamp >= inputDate.From && x.Timestamp <= inputDate.To);
            return View(listOfData);
        }
    }
}
