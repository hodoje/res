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
    public class PowerConsumptionDataRepository : IRepositoryWithDate<PowerConsumptionData, int>
    {
        private readonly PowerConsumptionDbContext _dbContext;

        public PowerConsumptionDataRepository(IDbContextProvider<PowerConsumptionDbContext> dbContextProvider)
        {
            this._dbContext = dbContextProvider.GetDbContext();
        }

        IEnumerable<PowerConsumptionData> IRepository<PowerConsumptionData, int>.GetAll()
        {
            if (_dbContext.DbPowerConsumptionDataSet != null)
            {
                return _dbContext.DbPowerConsumptionDataSet.ToList();
            }
            return new List<PowerConsumptionData>();
        }

        PowerConsumptionData IRepository<PowerConsumptionData, int>.GetById(int id)
        {
            PowerConsumptionData pcd = _dbContext.DbPowerConsumptionDataSet.FirstOrDefault(x => x.Id == id);
            if (pcd != null)
            {
                return pcd;
            }
            return null;
        }

        bool IRepository<PowerConsumptionData, int>.Insert(PowerConsumptionData entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (_dbContext.DbPowerConsumptionDataSet.FirstOrDefault(x => x.Equals(entity)) == null)
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
            }
            
            return result;
        }

        bool IRepository<PowerConsumptionData, int>.Delete(int id)
        {
            bool result = false;
            PowerConsumptionData pcd = _dbContext.DbPowerConsumptionDataSet.FirstOrDefault(x => x.Id == id);
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

        bool IRepository<PowerConsumptionData, int>.Update(PowerConsumptionData entity)
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

        IEnumerable<PowerConsumptionData> IRepositoryWithDate<PowerConsumptionData, int>.GetUnderSpecificDate(InputDate inputDate)
        {
            if (inputDate != null)
            {
                return _dbContext.DbPowerConsumptionDataSet
                    .Where(x =>
                        x.Timestamp.Equals(inputDate.From) ||
                        x.Timestamp.Equals(inputDate.To) ||
                        (DateTime.Compare(x.Timestamp, inputDate.From) > 0 && (DateTime.Compare(x.Timestamp, inputDate.To)) < 0))
                    .ToList();
            }
            return new List<PowerConsumptionData>();
        }
    }
}
