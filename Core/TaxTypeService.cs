using System;
using Core.Interfaces;
using SharedKernel.Enums;

namespace Core
{

    public class TaxTypeService : ITaxTypeService
    {
   
 

        public TaxType GetTaxType(string postalCode)
        {
            //This should be a database lookup call
            return postalCode switch
            {
                "7441" => TaxType.Progression,
                "A100" => TaxType.FlatValue,
                "7000" => TaxType.FlatRate,
                "1000" => TaxType.Progression,
                _ => throw new InvalidOperationException("Invalid postal code. Please enter a valid postal code.")
            };

            
        }
    }
}
