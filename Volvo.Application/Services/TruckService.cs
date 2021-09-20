using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo.Application.Interfaces;
using Volvo.Application.Request;
using Volvo.Application.Response;
using Volvo.Domain.Entities;
using Volvo.Domain.Interfaces.Repositories;

namespace Volvo.Application.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public void AddTruck(TruckRequest truckRequest)
        {
            var listValidation = Validation(truckRequest);

            if (listValidation.Any())
            {
                var error = string.Join("; ", listValidation);
                throw new Exception("Warning: " + error);
            }

            _truckRepository.AddTruck(MapperTruck(truckRequest));
        }

        public async Task<IEnumerable<TruckResponse>> GetListTruck()
        {
            var listTruck = await _truckRepository.GetListTruck();
            return MapperTruckResponseList(listTruck.ToList());
        }

        public TruckResponse GetTruck(int id)
        {
            var truck = _truckRepository.GetTruck(id);
            return MapperTruckResponse(truck);
        }

        public void Remove(int Id)
        {
            _truckRepository.Remove(Id);
        }

        public void Update(TruckRequest truckRequest)
        {
            var listValidation = Validation(truckRequest);

            if (listValidation.Any())
            {
                var error = string.Join("; ", listValidation);
                throw new Exception("Warning: " + error);
            }

            _truckRepository.Update(MapperTruck(truckRequest));
        }

        private List<string> Validation(TruckRequest truckRequest)
        {
            var mensageError = new List<string>();

            var validModel = !string.IsNullOrWhiteSpace(truckRequest.Model) &&
                             truckRequest.Model.Length >= 2 &&
                             truckRequest.Model.Length <= 20;

            var validacaoYearManufacture = truckRequest.YearManufacture == DateTime.Now.Year;

            var validacaoModelYear = truckRequest.ModelYear == DateTime.Now.Year ||
                                     truckRequest.ModelYear == DateTime.Now.AddYears(1).Year;

            if (!validModel)
                mensageError.Add("Preencher Corretamente o Modelo");

            if (!validacaoYearManufacture)
                mensageError.Add("Preencher Corretamente o Ano de Fabricação");

            if (!validacaoModelYear)
                mensageError.Add("Preencher Corretamente o Ano do Modelo");

            return mensageError;
        }

        private Truck MapperTruck(TruckRequest truckRequest)
        {
            return new Truck()
            {
                Id = truckRequest.Id.GetValueOrDefault(),
                Model = truckRequest.Model,
                YearManufacture = truckRequest.YearManufacture,
                ModelYear = truckRequest.ModelYear
            };
        }

        private TruckResponse MapperTruckResponse(Truck truck)
        {
            if (truck == null) return null;
            else
                return new TruckResponse()
                {
                    Id = truck.Id,
                    Model = truck.Model,
                    YearManufacture = truck.YearManufacture,
                    ModelYear = truck.ModelYear
                };
        }

        private IEnumerable<TruckResponse> MapperTruckResponseList(IEnumerable<Truck> truckList)
        {
            var truckResponseList = new List<TruckResponse>();

            if (truckList != null && truckList.Any())
            {
                truckList.ToList().ForEach(e =>
               {
                   truckResponseList.Add(new TruckResponse()
                   {
                       Id = e.Id,
                       Model = e.Model,
                       ModelYear = e.ModelYear,
                       YearManufacture = e.YearManufacture
                   });
               });
            }

            return truckResponseList;
        }

    }
}
