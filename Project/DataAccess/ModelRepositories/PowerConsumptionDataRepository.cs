using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ModelRepositories
{
    public class PowerConsumptionDataRepository : IRepository<PowerConsumptionData, int>
    {
        private readonly PowerConsumptionDbContext _dbContext;

        public PowerConsumptionDataRepository(IDbContextProvider<PowerConsumptionDbContext> dbContextProvider)
        {
            this._dbContext = dbContextProvider.GetDbContext();
        }

        public bool Delete(int id)
        {
            PowerConsumptionData pcd = _dbContext.DbPowerConsumptionDataSet.Find(id);
            _dbContext.DbPowerConsumptionDataSet.Remove(pcd);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<PowerConsumptionData> GetAll()
        {
            return _dbContext.DbPowerConsumptionDataSet.ToList();
        }

        public PowerConsumptionData GetById(int id)
        {
            return _dbContext.DbPowerConsumptionDataSet.Find(id);
        }

        public bool Insert(PowerConsumptionData entity)
        {
            _dbContext.DbPowerConsumptionDataSet.Add(entity);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(PowerConsumptionData entity)
        {
            _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            return true;
        }
    }
}
