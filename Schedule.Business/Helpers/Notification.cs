using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Business.Helpers
{
    public class Notification
    {
        private readonly List<string> _notifications;
        public bool Any => _notifications.Any();
        public IEnumerable<string> Messages => _notifications;

        public Notification()
        {
            _notifications = new List<string>();
        }

        public void Add(string message)
        {
            _notifications.Add(message);
        }
    }
}
