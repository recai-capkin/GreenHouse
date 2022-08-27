using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Dal.Abstract.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        bool Add(T data);
        bool Update(T data);
        bool Delete(int id);
        T Insert(T data);
        List<T> GetAll();
        T GetT(int id);
        List<T> GetAllByFilter(Expression<Func<T,bool>> expression);
    }
}
