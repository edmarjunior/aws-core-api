using Schedule.Business.Models;
using System.Collections.Generic;

namespace Schedule.Api.Dto.Response
{
    public class ProviderResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<DocumentResponseDto> Documents { get; set; }
    }
}
