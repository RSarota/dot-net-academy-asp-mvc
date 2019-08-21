using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_net_academy_asp_mvc.Models
{
    public class DateTimeHelper : IDateTimeHelper
    {
        private readonly DateTime _now = DateTime.Now;
        public DateTime GetNow()
        {
            return _now;
        }
    }
}
