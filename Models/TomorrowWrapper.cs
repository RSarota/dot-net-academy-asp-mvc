
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_net_academy_asp_mvc.Models
{
    public class TomorrowWrapper : ITomorrowWrapper
    {
        private readonly IDateTimeHelper _dth;

        public TomorrowWrapper()
        {
        }

        public TomorrowWrapper(IDateTimeHelper dth)
        {
            _dth = dth;
        }
        public DateTime GetTomorrow()
        {
            return _dth.GetNow().AddDays(1);
        }
    }
}
