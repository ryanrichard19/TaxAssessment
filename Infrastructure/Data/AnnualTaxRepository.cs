using System;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Infrastructure.Data
{
    public class AnnualTaxRepository : EfRepository, IAnnualTaxRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AnnualTaxRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(AnnualTax annualTax)
        {
            base.Add<AnnualTax>(annualTax);

        }
    }
}
