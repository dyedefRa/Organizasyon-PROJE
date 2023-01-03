using Organizasyon.Abstract;
using Organizasyon.Dtos.SentMails;
using Organizasyon.Entities.SentMails;
using Serilog;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Organizasyon.Services
{
    public class SentMailAppService : CrudAppService<SentMail, SentMailDto, int, PagedAndSortedResultRequestDto, SentMailDto, SentMailDto>, ISentMailAppService
    {
        public SentMailAppService(IRepository<SentMail, int> repository) : base(repository)
        {
        }

        public async Task<bool> SaveAsync(SentMailDto sendMailDto)
        {
            try
            {
                var entity = ObjectMapper.Map<SentMailDto, SentMail>(sendMailDto);
                var data = await Repository.InsertAsync(entity, true);

                if (data is { Id: > 0 })
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SentMailAppService > SaveAsync has error!");
                return false;
            }
        }

    }
}
