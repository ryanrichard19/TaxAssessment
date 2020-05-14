using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedKernel.ApiModels;
using UI.Models;
using UI.Services;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiClient _apiClient;

        public HomeController(ILogger<HomeController> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            return View();
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TaxCalculatorModel taxCalculatorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var input = new RequestAnnualTaxDTO { AnnualIncome = taxCalculatorModel.AnnualIncome, PostalCode = taxCalculatorModel.PostalCode };
                    var output = await _apiClient.PostTaxCalculationAsync(input);
                    taxCalculatorModel.ResponseMessage = "Your Tax amount is " + output.CalculatedTax;
                }

                return View(taxCalculatorModel);
            }
            catch (Exception ex)
            {
                //This should handle errors better
                _logger.LogError(ex.Message);
                taxCalculatorModel.ResponseMessage = "Something has gone Wrong. Please try again";
                return View(taxCalculatorModel);
            }
        }

        [HttpPost]
        public IActionResult Reset()
        {
            //This should be done using client js so that server does not get made to reset the form.
            return RedirectToAction("Index", "Home");
        }
    }
}
