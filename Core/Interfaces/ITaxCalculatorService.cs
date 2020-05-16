using System.Threading.Tasks;
using Infrastructure.Entities;
using SharedKernel.Enums;

namespace Core.Interfaces
{
    public interface ITaxCalculatorService
    {
        Task<decimal> CalculateTaxAsync(TaxType taxType, decimal amount, string postalCode);
    }
}
