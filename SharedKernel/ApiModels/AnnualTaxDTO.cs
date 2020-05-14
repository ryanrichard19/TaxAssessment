using System;


namespace SharedKernel.ApiModels
{
    public class AnnualTaxDTO
    {
    
         public int Id { get; set; }
         public DateTime CalculatedAt { get; set; }
         public string PostalCode { get; set; }
         public decimal AnnualIncome { get; set; }
         public decimal CalculatedTax { get; set; }

    }

}
