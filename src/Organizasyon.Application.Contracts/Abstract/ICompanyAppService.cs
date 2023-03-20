using Organizasyon.Dtos.Companies.ViewModels;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Organizasyon.Abstract
{
    public interface ICompanyAppService
    {
        Task<PagedResultDto<CompanyViewModel>> GetCompanyListAsync(PagedAndSortedResultRequestDto input);
    }
}
