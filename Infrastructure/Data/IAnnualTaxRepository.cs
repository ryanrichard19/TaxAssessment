using System;
using Infrastructure.Entities;

namespace Infrastructure.Data
{
    public interface IAnnualTaxRepository
    {
        void Create(AnnualTax annualTax);
    }
}
