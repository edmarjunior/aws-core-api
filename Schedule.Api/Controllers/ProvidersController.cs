using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Schedule.Api.Dto.Provider;
using Schedule.Business.Helpers;
using Schedule.Business.Interfaces.Repositories;
using Schedule.Business.Interfaces.Services;
using Schedule.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedule.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProvidersController : MainController
    {
        private readonly IProviderRepository _repository;
        private readonly IProviderService _service;
        private readonly IMapper _mapper;
        private readonly Notification _notification;

        public ProvidersController(IProviderRepository repository, IProviderService service, IMapper mapper, Notification notification)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
            _notification = notification;
        }

        [HttpGet]
        public async Task<IEnumerable<Provider>> Get(string name) => await _service.Get(name);

        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderDto>> Get(int id)
        {
            var provider = await _repository.GetById(id);

            if (provider == null)
                return BadRequest("Provider not found");

            return Ok(_mapper.Map<ProviderDto>(provider));
        }

        [HttpPost]
        public async Task<ActionResult<ProviderDto>> Add(ProviderDto providerDto)
        {
            var provider = await _service.Add(_mapper.Map<Provider>(providerDto));

            if (_notification.Any)
            {
                return BadRequest(_notification.Messages);
            }

            return Ok(_mapper.Map<ProviderDto>(provider));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Remove(id);

            if (_notification.Any)
                return BadRequest(_notification.Messages);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProviderDto providerDto)
        {
            if (id != providerDto.Id)
            {
                return BadRequest("Id no match");
            }

            var provider = _mapper.Map<Provider>(providerDto);

            await _service.Update(provider);

            if (_notification.Any)
                return BadRequest(_notification.Messages);

            return Ok();
        }
    }
}
