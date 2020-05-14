using System;
using System.Threading.Tasks;

using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.ApiModels;

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
            try
            {
                var taxType = _taxTypeService.GetTaxType(input.PostalCode);
                var taxAmount = await _taxCalculatorService.CalculateTaxAsync(taxType, input.AnnualIncome, input.PostalCode);
                var annualTax = await _taxCalculatorService.AddAnnualTax(taxType, input.AnnualIncome, taxAmount, input.PostalCode);


            //This should be done with AutoMapper
            var annualTaxDto = new AnnualTaxDTO()
            {
                Id = annualTax.Id,
                CalculatedAt = annualTax.CalculatedAt,
                PostalCode = annualTax.PostalCode,
                AnnualIncome = annualTax.AnnualIncome,
                CalculatedTax = annualTax.CalculatedTax
            };
                 
            return annualTaxDto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };


        }

     

    }
}
