using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchComparer.Shared
{
    public class FunctionTestService
    {
        public static TimeSpan Test(Func<List<int>, int, int> func, List<int> list, int searchedElement, bool isRandom)
        {
            if (isRandom)
            {
                list.Sort();
            }
            return TestFunc(() => func(list, searchedElement));
        }
        public static TimeSpan TestFunc(Func<int> func)
        {
            var sw = new Stopwatch();
            sw.Start();
            func();
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
