using System;
using System.Threading.Tasks;

namespace BLL
{

    public class FlatRateTaxCalculatorStrategry : ITaxCalculatorStrategy
    {

        public FlatRateTaxCalculatorStrategry()
        {

        }

        public async Task<decimal> CalculateTaxAsync(decimal amount)
        {
            return await Task.FromResult(Math.Round(amount * 0.175M,2));
        }
    }

}
