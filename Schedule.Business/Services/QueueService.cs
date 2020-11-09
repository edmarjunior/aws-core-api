using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using Schedule.Business.Interfaces.Services;
using System.Threading.Tasks;

namespace Schedule.Business.Services
{
    public class QueueService : IQueueService
    {
        private readonly AmazonSQSClient _sqsClient;

        public QueueService()
        {
            _sqsClient = new AmazonSQSClient(RegionEndpoint.USEast1);
        }

        public async Task Send(string queueName, object message)
        {
            await _sqsClient.SendMessageAsync(new SendMessageRequest
            {
                QueueUrl = GetQueueUrl(queueName),
                MessageBody = JsonConvert.SerializeObject(message)
            });
        }

        private string GetQueueUrl(string queueName) => _sqsClient.GetQueueUrlAsync(queueName).Result.QueueUrl;
    }
}
