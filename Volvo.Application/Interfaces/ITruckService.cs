using System.Collections.Generic;
using System.Threading.Tasks;
using Volvo.Application.Request;
using Volvo.Application.Response;

namespace Volvo.Application.Interfaces
{
    public interface ITruckService
    {
        Task<IEnumerable<TruckResponse>> GetListTruck();

        TruckResponse GetTruck(int id);

        void AddTruck(TruckRequest truck);

        void Update(TruckRequest truck);

        void Remove(int Id);        
    }
}
