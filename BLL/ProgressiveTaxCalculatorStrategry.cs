using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL
{

    public class ProgressiveTaxCalculatorStrategry : ITaxCalculatorStrategy
    {
        private readonly TaxBracket[] taxBrackets;
        public ProgressiveTaxCalculatorStrategry()
        {
            //This should be retrieved from the database
            taxBrackets = new TaxBracket[] {
               new TaxBracket{ Id = 1, To = 0m, From = 8350m, Rate = 0.1m },
               new TaxBracket{ Id = 2, To = 8351m, From = 33950m, Rate = 0.15m },
               new TaxBracket{ Id = 3, To = 33951m, From = 82250m, Rate = 0.25m },
               new TaxBracket{ Id = 4, To = 82251m, From = 171550m, Rate = 0.28m },
               new TaxBracket{ Id = 5, To = 171551m, From = 372950m, Rate = 0.33m },
               new TaxBracket{ Id = 6, To = 372951m, From = decimal.MaxValue, Rate = 0.35m }
           };
        }

        public async Task<decimal> CalculateTaxAsync(decimal amount)
        {
            decimal totalTax = 0;
            taxBrackets.Where(t => t.To < amount)
                .ToList().ForEach(t => totalTax += Math.Min(t.From - t.To, amount - t.To) * t.Rate);
            return await Task.FromResult(Math.Round(totalTax,2));
        }
    }
    

}