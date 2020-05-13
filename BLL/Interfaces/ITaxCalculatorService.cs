using System;
using System.Threading.Tasks;
using DAL.Enums;

namespace BLL.Interfaces
{
    public interface ITaxCalculatorService
    {
        Task<decimal> CalculateTaxAsync(TaxType taxType, decimal amount);
    }
}
