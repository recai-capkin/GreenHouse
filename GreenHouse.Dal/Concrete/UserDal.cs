using GreenHouse.Core;
using GreenHouse.Dal.Abstract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Dal.Concrete
{
    public class UserDal : GenericRepository<User,GreenHouseContext>, IUserDal
    {
        
    }
}
