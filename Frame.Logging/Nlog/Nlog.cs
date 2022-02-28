using System;
using System.Threading.Tasks;

namespace Frame.Logging
{
    public class Nlog:ILog
    {
        public async Task Info(Exception exception, string Code, string Message)
        {
            
        }

        public async Task Debug(Exception exception, string Code, string Message)
        { 

        }


        public async Task Warning(Exception exception, string Code, string Message)
        { 

        }

        public async Task Error(Exception exception, string Code, string Message)
        { 

        }

        public async Task Critical(Exception exception, string Code, string Message)
        {
            
        }
    }
}
