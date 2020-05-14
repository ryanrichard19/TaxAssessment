using System;
namespace SharedKernel.ApiModels
{
    public class RequestAnnualTaxDTO
    {
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
    }
}
