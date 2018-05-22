using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ModelRepositories
{
    public class PowerConsuptionDataRepository : IRepository<PowerConsumptionData, int>
    {
        private readonly PowerConsuptionDbContext _dbContext;

        public PowerConsuptionDataRepository(IDbContextProvider<PowerConsuptionDbContext> dbContextProvider)
        {
            this._dbContext = dbContextProvider.GetDbContext();
        }

        public bool Delete(int id)
        {
            PowerConsumptionData pcd = _dbContext.DbPowerConsuptionDataSet.Find(id);
            _dbContext.DbPowerConsuptionDataSet.Remove(pcd);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<PowerConsumptionData> GetAll()
        {
            return _dbContext.DbPowerConsuptionDataSet.ToList();
        }

        public PowerConsumptionData GetById(int id)
        {
            return _dbContext.DbPowerConsuptionDataSet.Find(id);
        }

        public bool Insert(PowerConsumptionData entity)
        {
            _dbContext.DbPowerConsuptionDataSet.Add(entity);
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
