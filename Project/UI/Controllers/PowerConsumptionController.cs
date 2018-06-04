using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Entities.Models;
using DataAccess;
using FileReader;
using FileReader.Interfaces;

namespace UI.Controllers
{
    public class PowerConsumptionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public IUnitOfWork UnitOfWork => _unitOfWork;

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
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
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
            List<PowerConsumptionData> listOfData;

            if (inputDate != null)
            {
                if (inputDate.From > inputDate.To)
                {
                    TempData["ErrorMessage"] = "'From' date has to be earlier than 'To' date.";
                    return RedirectToAction("GetData");
                }

                if (inputDate.From == DateTime.MinValue && inputDate.To == DateTime.MinValue)
                {
                    ViewBag.ErrorMessage = "";
                    listOfData = (List<PowerConsumptionData>) _unitOfWork.PowerConsumptionDataRepository.GetAll();
                }
                else
                {
                    ViewBag.ErrorMessage = "";
                    listOfData = (List<PowerConsumptionData>) _unitOfWork
                        .PowerConsumptionDataRepository
                        .Find(x => x.Timestamp >= inputDate.From && x.Timestamp <= inputDate.To);
                }

                return View(listOfData);
            }
            else
            {
                return RedirectToAction("GetData");
            }
        }
    }
}
