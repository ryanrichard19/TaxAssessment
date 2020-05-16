using System;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities;
using SharedKernel.Enums;


namespace Core
{
    public class TaxCalculatorService : ITaxCalculatorService
    {

        private readonly IRepository _repository;

        public TaxCalculatorService(IRepository repository)
        {
            _repository = repository;
        }

        // Chose the strategy pattern as it felt like a good fit for this problem
        public async Task<decimal> CalculateTaxAsync(TaxType taxType, decimal amount, string postalCode)
        {
            TaxCalculatorStrategy taxCalculatorContext = null;
            switch (taxType)
            {
                case TaxType.FlatRate:
                      taxCalculatorContext = new TaxCalculatorStrategy(new FlatRateTaxCalculatorStrategry());
                    break;
                case TaxType.FlatValue:
                    taxCalculatorContext = new TaxCalculatorStrategy(new FlatValueTaxCalculatorStrategry());
                    break;
                case TaxType.Progression:
                     taxCalculatorContext = new TaxCalculatorStrategy(new ProgressiveTaxCalculatorStrategry());
                    break;
                default:
                    //Throw exception invalid tax type
                    break;
            }

            return await taxCalculatorContext.CalculateTaxAsync(amount);
        }
    }
}


