using Microsoft.EntityFrameworkCore;
using Organizasyon.Abstract;
using Organizasyon.Dtos.Companies;
using Organizasyon.Dtos.Companies.ViewModels;
using Organizasyon.Entities.Companies;
using Organizasyon.Enums;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Organizasyon.Services
{
    //[Authorize(OrganizasyonPermissions.Companies.Default)]
    public class CompanyAppService : CrudAppService<Company, CompanyDto, int, PagedAndSortedResultRequestDto, CreateUpdateCompanyDto, CreateUpdateCompanyDto>, ICompanyAppService
    {

        public CompanyAppService(IRepository<Company, int> repository) : base(repository)
        {

        }

        public async Task<PagedResultDto<CompanyViewModel>> GetCompanyListAsync(PagedAndSortedResultRequestDto input)
        {
            var result = new PagedResultDto<CompanyViewModel>();

            var query = Repository.Where(x => x.Status == Status.Active).AsQueryable();
            //query = query.Include(x => x.ExpertPresenters).ThenInclude(x => x.Presenter);

            //query = query
            //    .WhereIf(!string.IsNullOrWhiteSpace(input.ExpertNameFilter), x => x.FullName.Contains(input.ExpertNameFilter))
            //    .WhereIf(!string.IsNullOrWhiteSpace(input.PresenterNameFilter), x => x.ExpertPresenters.Any(y => y.Presenter.FullName.Contains(input.PresenterNameFilter)));

            var totalCount = await query.CountAsync();

            //input.Sorting = "fullName asc";

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var list = await query.ToListAsync();

            var viewModels = list.Select(x =>
            {
                //var relatedDocument = x.Document;
                //var hasError = x.ProductDetails.Any(y => y.ProductionProcessingStatus == ProcessStatus.Error);
                var viewModel = ObjectMapper.Map<Company, CompanyViewModel>(x);
                //viewModel.SourceGln = relatedDocument?.SourceGln;

                return viewModel;
            }).ToList();


            result.Items = viewModels;
            result.TotalCount = totalCount;
            return result;
        }


        #region BaseMethods

        [RemoteService(IsEnabled = false, IsMetadataEnabled = false)]
        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }

        [RemoteService(IsEnabled = false, IsMetadataEnabled = false)]
        public override Task<PagedResultDto<CompanyDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        [RemoteService(IsEnabled = false, IsMetadataEnabled = false)]
        public override Task<CompanyDto> UpdateAsync(int id, CreateUpdateCompanyDto input)
        {
            return base.UpdateAsync(id, input);
        }

        [RemoteService(IsEnabled = false, IsMetadataEnabled = false)]
        public override Task<CompanyDto> CreateAsync(CreateUpdateCompanyDto input)
        {
            return base.CreateAsync(input);
        }

        [RemoteService(IsEnabled = false, IsMetadataEnabled = false)]
        public override Task<CompanyDto> GetAsync(int id)
        {
            return base.GetAsync(id);
        }

        #endregion
    }
}
