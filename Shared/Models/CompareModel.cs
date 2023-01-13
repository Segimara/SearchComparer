using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchComparer.Shared.Models
{
    public class CompareModel
    {
        public CompareModel()
        {
            Time = new List<TimeSpan>();
        }
        public List<TimeSpan> Time { get; set; }
        public TimeSpan AvarageTime
        {
            get
            {
                double doubleAverageTicks = Time.DefaultIfEmpty().Average(timeSpan => timeSpan.Ticks);
                long longAverageTicks = Convert.ToInt64(doubleAverageTicks);

                return new TimeSpan(longAverageTicks);
            }
        }
    }
}
