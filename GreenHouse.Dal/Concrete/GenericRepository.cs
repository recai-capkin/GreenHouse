using GreenHouse.Core;
using GreenHouse.Dal.Abstract.Interface;
using GreenHouse.Dto;
using GreenHouse.Logs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Dal.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly GreenHouseContext greenHouseContext = null;
        private readonly DbSet<T> tablo = null;
        public GenericRepository()
        {
            greenHouseContext = new GreenHouseContext();
            tablo = greenHouseContext.Set<T>();
        }
        public bool Add(T data)
        {
            JsonLogger<LogDto> jsonLogger = new JsonLogger<LogDto>("MyLog");
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllByFilter(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T GetT(int id)
        {
            throw new NotImplementedException();
        }

        public T Insert(T data)
        {
            throw new NotImplementedException();
        }

        public bool Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
