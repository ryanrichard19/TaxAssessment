using System.Threading.Tasks;

namespace Core
{
    public class TaxCalculatorStrategy :ITaxCalculatorStrategy
    {
      
        private readonly ITaxCalculatorStrategy _taxCalculatorStrategy;
        public TaxCalculatorStrategy(ITaxCalculatorStrategy taxCalculatorStrategy)
        {
            _taxCalculatorStrategy = taxCalculatorStrategy;
        }

        public async Task<decimal> CalculateTaxAsync(decimal amount)
        {
            return await _taxCalculatorStrategy.CalculateTaxAsync(amount);

        }
    }
}
   