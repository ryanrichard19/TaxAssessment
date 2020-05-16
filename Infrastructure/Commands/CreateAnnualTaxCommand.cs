using System;
using Infrastructure.Entities;
using MediatR;

namespace Infrastructure.Commands
{
    public class CreateAnnualTaxCommand : IRequest
    {
        public CreateAnnualTaxCommand(AnnualTax annualTax)
        {
            AnnualTax = annualTax;
        }

        public AnnualTax AnnualTax { get; }
    }
}