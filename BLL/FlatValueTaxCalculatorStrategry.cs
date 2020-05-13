using System.Threading.Tasks;

namespace BLL
{
    public class FlatValueTaxCalculatorStrategry : ITaxCalculatorStrategy
    {

        public FlatValueTaxCalculatorStrategry()
        {

        }

        public async Task<decimal> CalculateTaxAsync(decimal amount)
        {

            if (amount < 200000)
            {
                return await Task.FromResult(amount * 0.05m);
            }
            return await Task.FromResult(10000);

        }
    }

}
