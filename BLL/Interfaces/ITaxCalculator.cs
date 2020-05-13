using System;
using System.Threading.Tasks;
using DAL.Enums;

namespace BLL.Interfaces
{
    public interface ITaxCalculator
    {
        Task<decimal> CalculateTaxAsync(TaxType taxType, decimal amount);
    }
}
