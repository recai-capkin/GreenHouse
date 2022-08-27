using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Logs
{
    public interface ILogger<T> where T : class
    {
        void Log(T message);
    }
}
