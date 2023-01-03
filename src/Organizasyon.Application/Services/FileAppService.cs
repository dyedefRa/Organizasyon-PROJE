using Microsoft.AspNetCore.Http;
using Organizasyon.Abstract;
using Organizasyon.Dtos.Files;
using Organizasyon.Enums;
using Organizasyon.Helpers;
using Organizasyon.Models.Results.Abstract;
using Organizasyon.Models.Results.Concrete;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Organizasyon.Services
{
    public class FileAppService : CrudAppService<Entities.Files.File, FileDto, int, PagedAndSortedResultRequestDto, FileDto, FileDto>, IFileAppService
    {
        public FileAppService(IRepository<Entities.Files.File, int> repository) : base(repository)
        {
        }

        public async Task<IDataResult<FileDto>> SaveFileAsync(IFormFile fromFile, UploadType uploadType)
        {
            try
            {
                var data = await UploadHelper.UploadAsync(fromFile, uploadType);
                var entity = ObjectMapper.Map<FileDto, Entities.Files.File>(data.Data);
                var insertedData = await Repository.InsertAsync(entity, true);
                var resultDto = ObjectMapper.Map<Entities.Files.File, FileDto>(insertedData);
                return new SuccessDataResult<FileDto>(resultDto);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "FileAppService > SaveFileAsync");
                return new ErrorDataResult<FileDto>(new FileDto(), "Dosya eklenirken sorun oluştu.");
            }
        }

        public async Task<IDataResult<GetFileRequestDto>> GetFileAsync(int fileId)
        {
            try
            {
                var file = await Repository.GetAsync(fileId);
                if (file == null)
                {
                    //burada standart bir resim dönülebilir.
                    return new ErrorDataResult<GetFileRequestDto>("Dosya bulunamadı.");

                }
                Byte[] fileBytes = System.IO.File.ReadAllBytes(file.FullPath);

                return new SuccessDataResult<GetFileRequestDto>(new GetFileRequestDto
                {
                    FileBytes = fileBytes,
                    ContentType = file.ContentType
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "FileAppService > GetFileAsync");
                return new ErrorDataResult<GetFileRequestDto>();
            }
        }

        public async Task SoftDeleteAsync(int Id)
        {
            var entity = Repository.FirstOrDefault(x => x.Id == Id);
            entity.Status = Enums.Status.Deleted;
            await Repository.UpdateAsync(entity);
        }
    }
}
