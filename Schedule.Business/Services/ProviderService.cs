using Schedule.Business.Helpers;
using Schedule.Business.Interfaces.Repositories;
using Schedule.Business.Interfaces.Services;
using Schedule.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Business.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _repository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly Notification _notification;

        public ProviderService(IProviderRepository repository, IPhoneRepository phoneRepository, Notification notification)
        {
            _repository = repository;
            _phoneRepository = phoneRepository;
            _notification = notification;
        }

        public async Task<IEnumerable<Provider>> Get(string name)
        {
            return string.IsNullOrEmpty(name)
                ? await _repository.GetAll()
                : await _repository.Get(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task Remove(int id)
        {
            var provider = await _repository.GetById(id);

            if (provider == null)
            {
                _notification.Add("Provider not found");
                return;
            }

            await using var transaction = await _repository.BeginTransaction();

            await _repository.Remove(id);

            if (provider.Phones.Any())
            {
                await _phoneRepository.Remove(provider.Phones.Select(x => x.Phone));
            }

            await transaction.CommitAsync();
        }

        public async Task Update(Provider provider)
        {
            var currentProvider = await _repository.GetById(provider.Id);

            if (currentProvider == null)
            {
                _notification.Add("Provider not found");
                return;
            }

            await using var transaction = await _repository.BeginTransaction();

            if (currentProvider.Phones.Any())
            {
                await _phoneRepository.Remove(currentProvider.Phones.Select(x => x.Phone));
            }

            await _repository.Update(provider);

            await transaction.CommitAsync();
        }
    }
}
