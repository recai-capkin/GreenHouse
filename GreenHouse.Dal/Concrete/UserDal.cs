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
    public class UserDal : GenericRepository<User, GreenHouseContext>, IUserDal
    {
        public User Login(string username, string password)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var user = greenHouseContext.Users.Include("UserRole").Where(x => x.UserName == username && x.UserPassword == password).FirstOrDefault();
                return user;
            }
        }
        public List<UserAllergen> GetUserAllergen(int id)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var allergen = greenHouseContext.UserAllergens.Where(x => x.UserId == id).ToList();
                return allergen;
            }
        }
        public string GetUserName(int? id)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var username = greenHouseContext.Users.Where(x => x.UserId == id).SingleOrDefault();
                return username.Name+username.Surname;
            }
        }
    }
}
