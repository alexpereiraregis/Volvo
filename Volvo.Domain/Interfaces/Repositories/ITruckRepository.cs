using System.Collections.Generic;
using System.Threading.Tasks;
using Volvo.Domain.Entities;

namespace Volvo.Domain.Interfaces.Repositories
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetListTruck();

        Truck GetTruck(int id);

        void AddTruck(Truck truck);

        void Update(Truck truck);

        void Remove(int Id);
    }
}
