using System.Collections.Generic;

namespace Schedule.Business.Models
{
    public class Client : Model
    {
        public string Name { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<ClientPhone> Phones { get; set; }
    }
}
