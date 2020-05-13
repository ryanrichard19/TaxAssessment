using System.Threading.Tasks;

namespace BLL
{
    public interface ITaxCalculatorStrategy
    {
        Task<decimal> CalculateTaxAsync(decimal amount);
    }
}
