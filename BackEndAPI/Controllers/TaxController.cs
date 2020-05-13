using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.ApiModels;
using Core.Interfaces;
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
            var taxAmount = await _taxCalculatorService.CalculateTaxAsync(taxType, input.AnnualIncome, input.PostalCode );

          

            var annualTax = await _taxCalculatorService.AddAnnualTax(taxType, input.AnnualIncome, taxAmount, input.PostalCode);
            var annualTaxDto = new AnnualTaxDTO();
            annualTaxDto.FromAnnualTax(annualTax);
            return annualTaxDto;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnualTaxDTO>>> GetAnnualTax()
        {
            var DTO = new List<AnnualTaxDTO>();
            await _taxCalculatorService.Test();
          
            return DTO;
        }


    }
}
