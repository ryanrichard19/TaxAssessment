using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Entities;
using MediatR;

namespace Infrastructure.Handlers
{
    public class NewTaxCalculationHandler : IRequestHandler<NewAnnualTaxCommand, AnnualTax>
    {
        private readonly IAnnualTaxRepository _annualTaxRepository;

        
        public NewTaxCalculationHandler(IAnnualTaxRepository annualTaxRepository)
        {
            _annualTaxRepository = annualTaxRepository;
        }

        Task<AnnualTax> IRequestHandler<NewAnnualTaxCommand, AnnualTax>.Handle(NewAnnualTaxCommand newAnnualTaxCommand,
            CancellationToken cancellationToken)
        {
            var annualTax = new AnnualTax
            {
                CalculatedAt = newAnnualTaxCommand.CalculatedAt,
                PostalCode = newAnnualTaxCommand.PostalCode,
                AnnualIncome = newAnnualTaxCommand.AnnualIncome,
                CalculatedTax = newAnnualTaxCommand.CalculatedTax

            };
            _annualTaxRepository.Create(annualTax);
            return Task.FromResult(annualTax);
        }
    }
}
