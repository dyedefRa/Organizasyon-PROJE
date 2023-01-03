using Microsoft.AspNetCore.Http;
using Organizasyon.Dtos.Files;
using Organizasyon.Enums;
using Organizasyon.Models.Results.Abstract;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Organizasyon.Abstract
{
    public interface IFileAppService : ICrudAppService<FileDto, int, PagedAndSortedResultRequestDto, FileDto, FileDto>
    {
        Task<IDataResult<FileDto>> SaveFileAsync(IFormFile fromFile, UploadType uploadType);
        Task<IDataResult<GetFileRequestDto>> GetFileAsync(int fileId);
        Task SoftDeleteAsync(int Id);
    }
}
