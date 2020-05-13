using SharedKernal.Enums;

namespace Core.Interfaces
{
    public interface ITaxTypeService
    {
        TaxType GetTaxType(string postalCode);
    }
}
