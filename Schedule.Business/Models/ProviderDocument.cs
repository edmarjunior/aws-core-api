using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule.Business.Models
{
    public class ProviderDocument : Model
    {
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        [NotMapped]
        public string FileBase64 { get; set; }

        [NotMapped]
        public string Url { get; set; }

        public bool EqualsName(string name) => Name.Trim().ToUpper().Equals(name.Trim().ToUpper());
    }
}
