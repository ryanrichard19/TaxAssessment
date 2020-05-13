using System.Threading.Tasks;

namespace Core
{
    public interface ITaxCalculatorStrategy
    {
        Task<decimal> CalculateTaxAsync(decimal amount);
    }
}
