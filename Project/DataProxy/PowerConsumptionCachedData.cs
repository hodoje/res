using DataAccess;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProxy
{
    public class PowerConsumptionCachedData : IPowerConsumptionCachedData
    {
        private ICacheManager<PowerConsumptionData> _cacheManager;
        private string _key;
        private InputDate _inputDate;
        private IUnitOfWork _unitOfWork;

        public PowerConsumptionCachedData(ICacheManager<PowerConsumptionData> cache, IUnitOfWork unitOfWork)
        {
            _cacheManager = cache;
            _unitOfWork = unitOfWork;
        }

        public ICacheManager<PowerConsumptionData> CacheManager { get { return _cacheManager; } }
        public string Key { get { return _key; } set { _key = value; } }
        public InputDate InputDate
        {
            private get;
            set;
        }

        public IEnumerable<PowerConsumptionData> Get()
        {
            return GetData();
        }

        private IEnumerable<PowerConsumptionData> GetData()
        {
            if (!CacheManager.IsSet(_key))
            {
                FillCacheWithData();
            }

            //TODO
            IEnumerable<PowerConsumptionData> list = (List<PowerConsumptionData>)CacheManager.CachedData.GetCacheItem(_key, null).Value;

            return list;
        }

        private IEnumerable<PowerConsumptionData> GetDataFromDb()
        {
            IEnumerable<PowerConsumptionData> listOfData;

            if (InputDate.From == DateTime.MinValue && InputDate.To == DateTime.MinValue)
            {
                listOfData = (List<PowerConsumptionData>)_unitOfWork.PowerConsumptionDataRepository.GetAll();
            }
            else
            {
                listOfData = _unitOfWork
                    .PowerConsumptionDataRepository
                    .Find(x => x.Timestamp >= InputDate.From && x.Timestamp <= InputDate.To)
                    .ToList();
            }

            return listOfData;
        }

        private void FillCacheWithData()
        {
            CacheManager.Set(_key, GetDataFromDb(), 2);
        }


    }
}
