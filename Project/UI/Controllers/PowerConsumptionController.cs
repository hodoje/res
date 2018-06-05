using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Entities.Models;
using DataAccess;
using FileReader;
using FileReader.Interfaces;
using DataProxy;

namespace UI.Controllers
{
    public class PowerConsumptionController : Controller
    {
        //private readonly IUnitOfWork _unitOfWork;

        //public IUnitOfWork UnitOfWork => _unitOfWork;

        private readonly IPowerConsumptionCachedData _cachedData;

        public IPowerConsumptionCachedData CachedData => _cachedData;

        public PowerConsumptionController(IPowerConsumptionCachedData cachedData)
        {
            _cachedData = cachedData;
        }

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
            String key = "pccd";

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
                    //listOfData = (List<PowerConsumptionData>) _unitOfWork.PowerConsumptionDataRepository.GetAll();

                    key += "all";
                    CachedData.Key = key;

                    CachedData.InputDate = inputDate;

                    listOfData = (List<PowerConsumptionData>)CachedData.Get();
                }
                else
                {
                    ViewBag.ErrorMessage = "";
                    //listOfData = _unitOfWork
                    //    .PowerConsumptionDataRepository
                    //    .Find(x => x.Timestamp >= inputDate.From && x.Timestamp <= inputDate.To)
                    //    .ToList();

                    key += inputDate.From.Hour.ToString();
                    key += inputDate.To.Hour.ToString();
                    CachedData.Key = key;

                    CachedData.InputDate = inputDate;

                    listOfData = (List<PowerConsumptionData>)CachedData.Get();
                }
                listOfData = listOfData.OrderBy(x => x.GeoAreaId).ThenBy(x => x.Timestamp.TimeOfDay).ToList();
                return View(listOfData);
            }
            else
            {
                return RedirectToAction("GetData");
            }
        }
    }
}
