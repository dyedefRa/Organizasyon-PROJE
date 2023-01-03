using System.Threading.Tasks;

namespace Organizasyon.HangfireServices.Abstract
{
    public interface IRecurringJobService
    {
        Task<bool> SendProductionMailsJob();
    }
}
