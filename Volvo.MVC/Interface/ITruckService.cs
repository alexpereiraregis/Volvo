using System.Collections.Generic;
using System.Threading.Tasks;
using Volvo.MVC.Request;
using Volvo.MVC.Response;

namespace Volvo.MVC.Interface
{
    public interface ITruckService
    {
        Task<IEnumerable<TruckResponse>> GetListTruck();

        Task<TruckResponse> GetTruck(int id);

        Task AddTruck(TruckRequest truck);

        Task Update(TruckRequest truck);

        Task Remove(TruckRequest truckRequest);

        List<string> Validation(TruckRequest truckRequest);
    }
}
