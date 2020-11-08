
namespace Schedule.Business.Models
{
    public class ClientPhone : Model
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
