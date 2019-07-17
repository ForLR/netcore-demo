using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace requestDelegate管道
{
    public class RequestDelegate
    {
        public delegate Task RequestDalegate(Context context);
    }
}
