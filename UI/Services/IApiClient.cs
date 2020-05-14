using System.Threading.Tasks;
using SharedKernel.ApiModels;

namespace UI.Services
{
    public interface IApiClient
    {
        Task<AnnualTaxDTO> PostTaxCalculationAsync(RequestAnnualTaxDTO requestAnnualTaxDTO);
    }
}
