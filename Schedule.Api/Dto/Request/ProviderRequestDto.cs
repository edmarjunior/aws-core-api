using Schedule.Business.Models;
using System.Collections.Generic;

namespace Schedule.Api.Dto.Request
{
    public class ProviderRequestDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<DocumentRequestDto> Documents { get; set; }
    }
}
