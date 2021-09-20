using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Volvo.MVC.Interface;
using Volvo.MVC.Models;
using Volvo.MVC.Request;
using Volvo.MVC.Response;

namespace Volvo.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITruckService _truckService;

        public HomeController(ILogger<HomeController> logger, ITruckService truckService)
        {
            _logger = logger;
            _truckService = truckService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            await LoadListItens();
            var _pageResponse = await LoadPageResponse();
            return View(_pageResponse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TruckRequest truckRequest)
        {
            try
            {
                var listValidation = _truckService.Validation(truckRequest);
                if (listValidation.Any())
                {
                    await LoadListItens();
                    var _pageViewModel = await LoadPageResponse();                    
                    return View("index", _pageViewModel);
                }

                await _truckService.AddTruck(truckRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                TempData["mesgErro"] = "Erro no Cadastro";
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var truckRequest = await _truckService.GetTruck(id);
                await LoadListItens();
                return View(truckRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                TempData["mesgErro"] = "Erro na Consulta";
                return RedirectToAction("index");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(TruckRequest truckRequest)
        {
            try
            {
                var listValidation = _truckService.Validation(truckRequest);
                if (listValidation.Any())
                {
                    await LoadListItens();
                    var _pageViewModel = await LoadPageResponse();
                    TempData["mesgErro"] = "Erro ao Editar: " + listValidation.ToArray();
                    return View("index", _pageViewModel);
                }                    

                await _truckService.Update(truckRequest);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                TempData["mesgErro"] = "Erro na Edição";
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(TruckRequest truckRequest)
        {

            try
            {
                await _truckService.Remove(truckRequest);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                TempData["mesgErro"] = "Erro ao Remover";
            }

            return RedirectToAction("index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<PageResponse<TruckResponse>> LoadPageResponse()
        {
            var _pageResponse = new PageResponse<TruckResponse>
            {
                List = _truckService.GetListTruck().Result,
                Obj = new TruckResponse() { YearManufacture = DateTime.Now.Year }
            };

            return _pageResponse;
        }

        private async Task LoadListItens()
        {
            var _ModelYear = DateTime.Now.Year.ToString();
            var _ModelYearNext = DateTime.Now.AddYears(1).Year.ToString();

            var _truckYearModel = new[]
            {
                new SelectListItem { Value = _ModelYear, Text = _ModelYear},
                new SelectListItem { Value = _ModelYearNext, Text = _ModelYearNext}
            };

            var truckModelsResponse = new List<TruckModelsResponse>()
            {
                new TruckModelsResponse(){
                    Id = Guid.NewGuid(),
                    Nome = "FH"
                },
                new TruckModelsResponse(){
                    Id = Guid.NewGuid(),
                    Nome = "FM"
                }
            };

            ViewBag.truckModelYear = new SelectList(_truckYearModel, "Value", "Text");
            ViewBag.truckModel = new SelectList(truckModelsResponse, "Nome", "Nome");
        }
    }
}
