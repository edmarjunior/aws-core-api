
namespace Schedule.Business.Models
{
    public class ProviderPhone : Model
    {
        public ProviderPhone()
        {

        }

        public ProviderPhone(int providerId, int phoneId)
        {
            ProviderId = providerId;
            PhoneId = phoneId;
        }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
