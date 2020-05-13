using System;
namespace Infrastructure.Entities
{
    public class TaxBracket: BaseEntity
    {
        public decimal To { get; set; }
        public decimal From { get; set; }
        public decimal Rate { get; set; }
    }
}
