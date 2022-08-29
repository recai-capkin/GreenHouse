using GreenHouse.Core;
using GreenHouse.Dal.Abstract.Interface;
using GreenHouse.Dto;
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
        public bool UserUpdateEmail(int id,string email)
        {
            
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var result = greenHouseContext.Users.Where(x => x.UserId == id).FirstOrDefault();
                result.UserEmail = email;
                greenHouseContext.SaveChanges();
                return true;    
            }
        }
        public bool UserUpdatePassword(int id, string password)
        {

            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var result = greenHouseContext.Users.Where(x => x.UserId == id).FirstOrDefault();
                result.UserPassword = password;
                greenHouseContext.SaveChanges();
                return true;
            }
        }
        public bool UserRegister(UserRegisterDto user)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var role = greenHouseContext.UserRoles.Where(x => x.UserRoleName == user.Rol).FirstOrDefault();
                greenHouseContext.Users.Add(new User()
                {
                    Name = user.Ad,
                    UserName = user.KullaniciAdi,
                    UserPassword = user.Sifre,
                    UserEmail = user.Email,
                    Adress = user.Adres,
                    Phone = user.Telefon,
                    UserRoleId = role.UserRoleId
                });
                greenHouseContext.SaveChanges();
                return true;
            }
        }
    }
}
