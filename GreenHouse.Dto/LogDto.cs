using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Dto
{
    public enum LogLevel
    {
        Warning=0,
        Information=1,
        Error=2
    }
    public class LogDto
    {
        public string Tablo { get; set; }
        public string Kisi { get; set; }
        public LogLevel LogLevel { get; set; }
        public string DataId { get; set; }
        public string Not { get; set; }
        public DateTime Tarih { get; set; }
    }
}
