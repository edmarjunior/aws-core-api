using System;

namespace Schedule.Business.Models
{
    public class Appointment : Model
    {
        public Provider Provider { get; set; }
        public Client Client { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedUserId { get; set; }
    }
}
