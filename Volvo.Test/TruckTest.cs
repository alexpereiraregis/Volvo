using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volvo.Application.Request;
using Volvo.Application.Services;
using Volvo.Domain.Entities;
using Volvo.Domain.Interfaces.Repositories;
using Xunit;

namespace Volvo.Test
{
    public class TruckTest
    {
        public Mock<ITruckRepository> truckRepository;
        public TruckService truckService;

        public TruckTest()
        {
            truckRepository = new Mock<ITruckRepository>();
            truckService = new TruckService(truckRepository.Object);
        }

        [Fact]
        public void AddTruckSuccess()
        {
            var truckResponse = new TruckRequest()
            {
                Model = "FH",
                YearManufacture = DateTime.Now.Year,
                ModelYear = DateTime.Now.Year + 1
            };

            truckService.AddTruck(truckResponse);
            truckRepository.Verify(cr => cr.AddTruck(It.IsAny<Truck>()), Times.Once);
        }

        [Fact]
        public void AddTruckFailure()
        {
            var truckResponse = new TruckRequest()
            {
                Model = "FH",
                YearManufacture = DateTime.Now.Year - 1,
                ModelYear = DateTime.Now.Year - 1
            };

            Action act = () => truckService.AddTruck(truckResponse);
            Exception exception = Assert.Throws<Exception>(act);
            Assert.True(!string.IsNullOrEmpty(exception.Message));
        }

        [Fact]
        public void UpdateTruckSuccess()
        {
            var truckResponse = new TruckRequest()
            {
                Model = "FH",
                YearManufacture = DateTime.Now.Year,
                ModelYear = DateTime.Now.Year + 1
            };

            truckService.Update(truckResponse);
            truckRepository.Verify(cr => cr.Update(It.IsAny<Truck>()), Times.Once);
        }

        [Fact]
        public void UpdateTruckFailure()
        {
            var truckResponse = new TruckRequest()
            {
                Model = "FH",
                YearManufacture = DateTime.Now.Year - 1,
                ModelYear = DateTime.Now.Year - 1
            };

            Action act = () => truckService.Update(truckResponse);
            Exception exception = Assert.Throws<Exception>(act);
            Assert.True(!string.IsNullOrEmpty(exception.Message));
        }

        [Fact]
        public void GetTruckSuccess()
        {
            Task<IEnumerable<Truck>> trucksTask;
                
            var trucks = new List<Truck>()
            {
                new Truck()
                {
                    Id = 1,
                    Model = "FH",
                    YearManufacture = 2021,
                    ModelYear = 2022
                },
                new Truck()
                {
                    Id = 2,
                    Model = "FM",
                    YearManufacture = 2021,
                    ModelYear = 2022
                }
            };

            trucksTask = Task<IEnumerable<Truck>>.Factory.StartNew(() => trucks);

            truckRepository.Setup(cr => cr.GetListTruck()).Returns(trucksTask);

            var result = truckService.GetListTruck();
            truckRepository.Verify(cr => cr.GetListTruck(), Times.Once);
            Assert.True(result != null);
        }

        [Fact]
        public void GetTruckIdSuccess()
        {
            var truck = new Truck
            {
                Id = 1,
                Model = "FH",
                YearManufacture = 2021,
                ModelYear = 2022
            };

            truckRepository.Setup(cr => cr.GetTruck(It.IsAny<int>())).Returns(truck);

            var result = truckService.GetTruck(1);
            truckRepository.Verify(cr => cr.GetTruck(It.IsAny<int>()), Times.Once);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void RemoveTruckSuccess()
        {
            truckService.Remove(1);
            truckRepository.Verify(cr => cr.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
