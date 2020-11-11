using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Schedule.Business.Interfaces.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Schedule.Business.Services
{
    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public StorageService(string bucketName)
        {
            _s3Client = new AmazonS3Client(RegionEndpoint.USEast1);
            _bucketName = bucketName;
        }

        public string GetUrl(string fileName) => $"https://{_bucketName}.s3.amazonaws.com/{fileName}";

        public async Task Remove(string fileName) => await _s3Client.DeleteObjectAsync(_bucketName, fileName);

        public async Task<string> UploadBase64(string fileBase64, string fileName) => await Upload(Convert.FromBase64String(fileBase64), fileName);

        public async Task<string> UploadBytes(byte[] buffer, string fileName) => await Upload(buffer, fileName);

        public async Task<string> UploadFromPath(string path, string fileName) => await Upload(File.ReadAllBytes(path), fileName);

        private async Task<string> Upload(byte[] buffer, string fileName)
        {
            using var memoryStream = new MemoryStream(buffer);

            var transfer = new TransferUtility(_s3Client);

            await transfer.UploadAsync(new TransferUtilityUploadRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                InputStream = memoryStream
            });

            return GetUrl(fileName);
        }
    }
}
