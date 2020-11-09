using System.Threading.Tasks;

namespace Schedule.Business.Interfaces.Services
{
    public interface IQueueService
    {
        Task Send(string queueName, object message);
    }
}
