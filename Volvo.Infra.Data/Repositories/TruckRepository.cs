using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo.Domain.Entities;
using Volvo.Domain.Interfaces.Repositories;
using Volvo.Infra.Data.Context;

namespace Volvo.Infra.Data.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly DbTruckContext _dbTruckContext;

        public TruckRepository(DbTruckContext dbTruckContext)
        {
            _dbTruckContext = dbTruckContext;
        }

        public void AddTruck(Truck truck)
        {
            _dbTruckContext.Add(truck);
            _dbTruckContext.SaveChanges();
        }

        public async Task<IEnumerable<Truck>> GetListTruck()
        {
            return await _dbTruckContext.Truck
                .AsNoTracking()
                .ToListAsync();
        }

        public Truck GetTruck(int id)
        {
            return _dbTruckContext.Truck
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var truck = GetTruck(id);

            if (truck != null)
            {
                _dbTruckContext.Remove(truck);
                _dbTruckContext.SaveChanges();
            }
        }

        public void Update(Truck truck)
        {
            _dbTruckContext.Update(truck);
            _dbTruckContext.SaveChanges();
        }
    }
}
