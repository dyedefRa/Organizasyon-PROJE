using Organizasyon.Dtos.SentMails;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Organizasyon.Abstract
{
    public interface ISentMailAppService : ICrudAppService<SentMailDto, int, PagedAndSortedResultRequestDto, SentMailDto, SentMailDto>
    {
        Task<bool> SaveAsync(SentMailDto sendMailDto);
    }
}
