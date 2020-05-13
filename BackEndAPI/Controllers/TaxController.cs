using System;
using System.Threading.Tasks;
using BackEndAPI.ApiModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxTypeService _taxTypeService;
        private readonly ITaxCalculatorService _taxCalculatorService;

        public TaxController(ITaxTypeService taxTypeService, ITaxCalculatorService taxCalculatorService)
        {
            _taxTypeService = taxTypeService;
            _taxCalculatorService = taxCalculatorService;
        }


        [HttpPost]
        public async Task<ActionResult<AnnualTaxDTO>> Post(RequestAnnualTaxDTO input)
        {
            var taxType = _taxTypeService.GetTaxType(input.PostalCode);
            var taxAmount = await _taxCalculatorService.CalculateTaxAsync(taxType, input.AnnualIncome);

            var annualTaxDto = new AnnualTaxDTO
            {
                Id = 1,
                CalculatedAt = DateTime.Now,
                PostalCode = input.PostalCode,
                AnnualIncome = input.AnnualIncome,
                CalculatedTax = taxAmount
            };

            return annualTaxDto;
       
        }

    }
}
