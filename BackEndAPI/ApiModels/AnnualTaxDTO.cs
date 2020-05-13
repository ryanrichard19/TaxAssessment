using System;
using DAL.Entities;

namespace BackEndAPI.ApiModels
{
    public class AnnualTaxDTO
    {
    
         public int Id { get; set; }
         public DateTime CalculatedAt { get; set; }
         public string PostalCode { get; set; }
         public decimal AnnualIncome { get; set; }
         public decimal CalculatedTax { get; set; }

        public static AnnualTaxDTO FromAnnualTax(AnnualTax annualTax)
        {
            return new AnnualTaxDTO()
            {
                Id = annualTax.Id,
                CalculatedAt = annualTax.CalculatedAt,
                PostalCode = annualTax.PostalCode,
                AnnualIncome = annualTax.AnnualIncome,
                CalculatedTax = annualTax.CalculatedTax
            };
        }

    }

}
