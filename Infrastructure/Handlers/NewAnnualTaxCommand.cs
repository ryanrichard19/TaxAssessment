using System;
using Infrastructure.Entities;
using MediatR;

namespace Infrastructure.Handlers
{
    public class NewAnnualTaxCommand : IRequest<AnnualTax>
    {

        public DateTime CalculatedAt { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal CalculatedTax { get; set; }

    }
}