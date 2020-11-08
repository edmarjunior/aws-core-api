using Schedule.Business.Models;
using System.Collections.Generic;

namespace Schedule.Api.Dto.Provider
{
    public class ProviderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
    }
}
