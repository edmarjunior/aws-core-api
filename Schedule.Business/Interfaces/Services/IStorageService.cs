using System.Threading.Tasks;

namespace Schedule.Business.Interfaces.Services
{
    public interface IStorageService
    {
        Task<string> UploadBase64(string fileBase64, string fileName);
        Task<string> UploadBytes(byte[] buffer, string fileName);
        Task<string> UploadFromPath(string path, string fileName);
        string GetUrl(string fileName);
        Task Remove(string fileName);
    }
}
