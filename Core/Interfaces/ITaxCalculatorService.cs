using System.Threading.Tasks;
using Infrastructure.Entities;
using SharedKernal.Enums;

namespace Core.Interfaces
{
    public interface ITaxCalculatorService
    {
        Task<decimal> CalculateTaxAsync(TaxType taxType, decimal amount, string postalCode);
        Task<AnnualTax> AddAnnualTax(TaxType taxType, decimal amount, decimal taxAmount, string PostalCode);
        Task Test();
    }
}
