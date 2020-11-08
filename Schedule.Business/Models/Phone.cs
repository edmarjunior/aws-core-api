
namespace Schedule.Business.Models
{
    public class Phone : Model
    {
        public Phone()
        {

        }

        public Phone(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}
