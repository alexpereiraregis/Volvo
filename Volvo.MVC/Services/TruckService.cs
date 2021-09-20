using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volvo.MVC.Extensions;
using Volvo.MVC.Interface;
using Volvo.MVC.Request;
using Volvo.MVC.Response;

namespace Volvo.MVC.Services
{
    public class TruckService : ITruckService
    {   
        private readonly string _uriAPI;
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _configuration;

        public TruckService(HttpClient httpClient, IOptions<AppSettings> configuration)
        {
            _configuration = configuration;            

            httpClient.BaseAddress = new Uri(_configuration.Value?.ApiTruckBaseAddress ?? String.Empty);
            _uriAPI = _configuration.Value?.ApiTruckUri ?? string.Empty;
            _configuration = configuration;

            _httpClient = httpClient;
        }

        public async Task AddTruck(TruckRequest truck)
        {
            var truckSerializer = new StringContent(JsonSerializer.Serialize(truck), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(_uriAPI + "/Add", truckSerializer);
        }

        public async Task<IEnumerable<TruckResponse>> GetListTruck()
        {
            var response = await _httpClient.GetAsync(_uriAPI + "/GetList");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<TruckResponse>>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<TruckResponse> GetTruck(int id)
        {
            var response = await _httpClient.GetAsync(_uriAPI + "/" + id + "/Get");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<TruckResponse>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task Remove(TruckRequest truckRequest)
        {
            await _httpClient.DeleteAsync(_uriAPI + "/" + truckRequest.Id.ToString() + "/Delete");
        }

        public async Task Update(TruckRequest truck)
        {
            var truckSerializer = new StringContent(JsonSerializer.Serialize(truck), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(_uriAPI + "/Update", truckSerializer);
        }

        public List<string> Validation(TruckRequest truckRequest)
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
    }
}
