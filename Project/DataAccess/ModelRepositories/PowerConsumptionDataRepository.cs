using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            bool result = false;
            PowerConsumptionData pcd = _dbContext.DbPowerConsumptionDataSet.Find(id);
            if (pcd != null)
            {
                try
                {
                    _dbContext.DbPowerConsumptionDataSet.Remove(pcd);
                    _dbContext.SaveChanges();
                    result = true;
                }
                catch (DbUpdateException)
                {
                    result = false;
                    throw;
                }
                catch (Exception)
                {
                    result = false;
                    throw;
                }
            }
            return result;
        }

        public IEnumerable<PowerConsumptionData> GetAll()
        {
            if (_dbContext.DbPowerConsumptionDataSet != null)
            {
                return _dbContext.DbPowerConsumptionDataSet.ToList();
            }
            return new List<PowerConsumptionData>();
        }

        public PowerConsumptionData GetById(int id)
        {
            if (_dbContext.DbPowerConsumptionDataSet.FirstOrDefault(x => x.Id == id) != null)
            {
                return _dbContext.DbPowerConsumptionDataSet.Find(id);
            }
            return null;
        }

        public bool Insert(PowerConsumptionData entity)
        {
            bool result = false;
            if (_dbContext.DbPowerConsumptionDataSet.Find(entity) == null)
            {
                try
                {
                    _dbContext.DbPowerConsumptionDataSet.Add(entity);
                    _dbContext.SaveChanges();
                    result = true;
                }
                catch (DbUpdateException)
                {
                    result = false;
                    throw;
                }
                catch (Exception)
                {
                    result = false;
                    throw;
                }
            }
            return result;
        }

        public bool Update(PowerConsumptionData entity)
        {
            bool result = false;
            if (entity != null)
            {
                try
                {
                    _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    _dbContext.SaveChanges();
                    result = true;
                }
                catch (DbUpdateException)
                {
                    result = false;
                    throw;
                }
                catch (Exception)
                {
                    result = false;
                    throw;
                }
            }
            return result;
        }
    }
}
