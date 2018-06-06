﻿using DataAccess;
using Entities;
using Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProxy
{
    public class PowerConsumptionCachedData : IPowerConsumptionCachedData
    {
        private IUnitOfWork _unitOfWork;
        private ICacheManager<PowerConsumptionData> _cacheManager;
        

        public PowerConsumptionCachedData(ICacheManager<PowerConsumptionData> cacheManager, IUnitOfWork unitOfWork)
        {
            _cacheManager = cacheManager;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PowerConsumptionData> Get(InputDate inputDate)
        {
            string key = "";
            if (inputDate.From == DateTime.MinValue && inputDate.To == DateTime.MaxValue)
            {
                key += "All";
            }
            else
            {
                DateTime fromKeyPart = new DateTime(inputDate.From.Year, inputDate.From.Month, inputDate.From.Day, inputDate.From.Hour, 0, 0);
                DateTime toKeyPart = new DateTime(inputDate.To.Year, inputDate.To.Month, inputDate.To.Day, inputDate.To.Hour, 0, 0);
                key += $"{fromKeyPart}_{toKeyPart}";
            }
            return GetData(key);
        }

        private IEnumerable<PowerConsumptionData> GetData(string key)
        {
            if (!_cacheManager.IsSet(key))
            {
                FillCacheWithData(key);
            }

            IEnumerable<PowerConsumptionData> list = (List<PowerConsumptionData>)_cacheManager.CachedData.GetCacheItem(key, null).Value;

            return list;
        }

        private IEnumerable<PowerConsumptionData> GetDataFromDb(string key)
        {
            InputDate inputDate = new InputDate();
            DateTime from = DateTime.Parse(key.Split('_')[0]);
            DateTime to = DateTime.Parse(key.Split('_')[1]);
            inputDate.From = from;
            inputDate.To = to;

            IEnumerable<PowerConsumptionData> listOfData;

            if (inputDate.From == DateTime.MinValue && inputDate.To == DateTime.MinValue)
            {
                listOfData = (List<PowerConsumptionData>)_unitOfWork.PowerConsumptionDataRepository.GetAll();
            }
            else
            {
                listOfData = _unitOfWork
                    .PowerConsumptionDataRepository
                    .Find(x => x.Timestamp >= inputDate.From && x.Timestamp <= inputDate.To)
                    .ToList();
            }

            return listOfData;
        }

        private void FillCacheWithData(string key)
        {
            _cacheManager.Set(key, GetDataFromDb(key), 2);
        }
    }
}
