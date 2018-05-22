using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ModelRepositories
{
    class GeoAreaRepository : IRepository<GeoArea, string>
    {
        private readonly PowerConsuptionDbContext _dbContext;

        public GeoAreaRepository(IDbContextProvider<PowerConsuptionDbContext> dbContextProvider)
        {
            this._dbContext = dbContextProvider.GetDbContext();
        }

        public bool Delete(string id)
        {
            GeoArea ga = _dbContext.DbGeoAreaSet.Find(id);
            _dbContext.DbGeoAreaSet.Remove(ga);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<GeoArea> GetAll()
        {
            return _dbContext.DbGeoAreaSet.ToList();
        }

        public GeoArea GetById(string id)
        {
            return _dbContext.DbGeoAreaSet.Find(id);
        }

        public bool Insert(GeoArea entity)
        {
            _dbContext.DbGeoAreaSet.Add(entity);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(GeoArea entity)
        {
            _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            return true;
        }
    }
}
