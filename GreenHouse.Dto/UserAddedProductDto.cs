using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Dto
{
    public class UserAddedProductDto
    {
        public int Id { get; set; }
        public string FullUserName { get; set; }
        public int ProductCount { get; set; }
    }
}
