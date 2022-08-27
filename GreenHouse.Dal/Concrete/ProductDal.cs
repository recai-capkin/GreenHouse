using GreenHouse.Core;
using GreenHouse.Dal.Abstract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Dal.Concrete
{
    public class ProductDal:GenericRepository<Product>, IProductDal
    {
    }
}
