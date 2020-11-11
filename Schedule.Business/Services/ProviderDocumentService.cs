using Microsoft.EntityFrameworkCore.Internal;
using Schedule.Business.Helpers;
using Schedule.Business.Interfaces.Repositories;
using Schedule.Business.Interfaces.Services;
using Schedule.Business.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Business.Services
{
    public class ProviderDocumentService : IProviderDocumentService
    {
        private readonly IProviderDocumentRepository _repository;
        private readonly IStorageService _storageService;
        private readonly IProviderRepository _providerRepository;
        private readonly Notification _notification;

        public ProviderDocumentService(IProviderDocumentRepository repository, IProviderRepository providerRepository, Notification notification)
        {
            _repository = repository;
            _storageService = new StorageService("schedule-core");
            _providerRepository = providerRepository;
            _notification = notification;
        }

        public async Task<ProviderDocument> Add(ProviderDocument document)
        {
            if (!await ValidateAdd(document))
            {
                return null;
            }

            await using var transaction = await _repository.BeginTransaction();

            await _repository.Add(document);

            document.Url = await _storageService.UploadBase64(document.FileBase64, $"{document.Id}.pdf");

            await transaction.CommitAsync();

            return document;
        }

        public async Task Remove(int id)
        {
            var document = await _repository.GetById(id);

            if (document == null)
            {
                _notification.Add("Document not found");
                return;
            }

            await using var transaction = await _repository.BeginTransaction();

            await _repository.Remove(document);

            await _storageService.Remove(id + ".pdf");

            await transaction.CommitAsync();
        }

        public async Task<bool> ValidateAdd(ProviderDocument document)
        {
            var provider = await _providerRepository.GetById(document.ProviderId);

            if (provider == null)
            {
                _notification.Add("Provider not found");
                return false;
            }

            var duplicateName = (await _repository.Get(x => x.ProviderId == document.ProviderId && x.Name.Equals(document.Name))).Any();

            if (duplicateName)
            {
                _notification.Add("Name already used");
                return false;
            }

            return true;
        }
    }
}
