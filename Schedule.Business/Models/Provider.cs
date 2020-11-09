using System.Collections.Generic;

namespace Schedule.Business.Models
{
    public class Provider : Model
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<ProviderPhone> Phones { get; set; }
    }
}
