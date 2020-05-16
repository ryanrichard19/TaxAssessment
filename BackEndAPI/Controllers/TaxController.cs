using System;
using System.Threading.Tasks;
using MediatR;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.ApiModels;
using Infrastructure.Commands;
using Infrastructure.Entities;
using Infrastructure.Handlers;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : BaseApiController
    {
        private readonly ITaxTypeService _taxTypeService;
        private readonly ITaxCalculatorService _taxCalculatorService;
     

        public TaxController(ITaxTypeService taxTypeService, ITaxCalculatorService taxCalculatorService, IMediator mediator)
        {
            _taxTypeService = taxTypeService;
            _taxCalculatorService = taxCalculatorService;
            Mediator = mediator;
        }



        [HttpPost]
        public async Task<ActionResult<AnnualTaxDTO>> Post(RequestAnnualTaxDTO input)
        {
            try
            {
                var taxType = _taxTypeService.GetTaxType(input.PostalCode);
                var taxAmount = await _taxCalculatorService.CalculateTaxAsync(taxType, input.AnnualIncome, input.PostalCode);

                NewAnnualTaxCommand command = new NewAnnualTaxCommand
                {
                    CalculatedAt = DateTime.Now,
                    PostalCode = input.PostalCode,
                    AnnualIncome = input.AnnualIncome,
                    CalculatedTax = taxAmount

                };
                var annualTax = await Mediator.Send(command);


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
