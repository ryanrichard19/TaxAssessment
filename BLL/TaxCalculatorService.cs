using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Enums;

namespace BLL
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
       


        public TaxCalculatorService()
        {
        }

        // Chose the strategy pattern as it felt like a good fit for this problem
        public async Task<decimal> CalculateTaxAsync(TaxType taxType, decimal amount)
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


