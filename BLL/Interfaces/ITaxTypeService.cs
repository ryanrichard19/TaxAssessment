using System;
using DAL.Enums;

namespace BLL.Interfaces
{
    public interface ITaxTypeService
    {
        TaxType GetTaxType(string postalCode);
    }
}
