using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Schedule.Api.Dto.Request;
using Schedule.Api.Dto.Response;
using Schedule.Business.Helpers;
using Schedule.Business.Interfaces.Services;
using Schedule.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedule.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProvidersController : MainController
    {
        private readonly IProviderService _service;
        private readonly IMapper _mapper;
        private readonly Notification _notification;

        public ProvidersController(IProviderService service, IMapper mapper, Notification notification)
        {
            _service = service;
            _mapper = mapper;
            _notification = notification;
        }

        [HttpGet]
        public async Task<IEnumerable<Provider>> Get(string name) => await _service.Get(name);

        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderResponseDto>> Get(int id)
        {
            var provider = await _service.GetById(id);

            if (provider == null)
                return BadRequest("Provider not found");

            return Ok(_mapper.Map<ProviderResponseDto>(provider));
        }

        [HttpPost]
        public async Task<ActionResult<ProviderResponseDto>> Add(ProviderRequestDto providerDto)
        {
            var provider = await _service.Add(_mapper.Map<Provider>(providerDto));

            if (_notification.Any)
            {
                return BadRequest(_notification.Messages);
            }

            return Ok(_mapper.Map<ProviderResponseDto>(provider));
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
        public async Task<ActionResult> Update(int id, ProviderRequestDto providerDto)
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
