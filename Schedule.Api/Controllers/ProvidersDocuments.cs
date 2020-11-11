using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Schedule.Api.Dto.Request;
using Schedule.Api.Dto.Response;
using Schedule.Business.Helpers;
using Schedule.Business.Interfaces.Services;
using Schedule.Business.Models;
using System.Threading.Tasks;

namespace Schedule.Api.Controllers
{
    [Route("api/providers-documents")]
    public class ProvidersDocuments : MainController
    {
        private readonly IProviderDocumentService _service;
        private readonly IMapper _mapper;
        private readonly Notification _notification;

        public ProvidersDocuments(IProviderDocumentService service, IMapper mapper, Notification notification)
        {
            _service = service;
            _mapper = mapper;
            _notification = notification;
        }

        [HttpPost]
        public async Task<ActionResult<DocumentResponseDto>> Add(DocumentRequestDto documentDto)
        {
            var document = await _service.Add(_mapper.Map<ProviderDocument>(documentDto));

            if (_notification.Any)
                return BadRequest(_notification.Messages);

            return Ok(_mapper.Map<DocumentResponseDto>(document));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentResponseDto>> Remove(int id)
        {
            await _service.Remove(id);

            if (_notification.Any)
                return BadRequest(_notification.Messages);

            return Ok();
        }
    }
}
