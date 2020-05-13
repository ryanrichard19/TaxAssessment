using System;
namespace DAL.Entities
{
    public class AnnualTax: BaseEntity
    {
        public DateTime CalculatedAt { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal CalculatedTax { get; set; }
    }
}
