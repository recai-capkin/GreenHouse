using GreenHouse.Core;
using GreenHouse.Dal.Abstract.Interface;
using GreenHouse.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Dal.Concrete
{
    public class ProductDal : GenericRepository<Product, GreenHouseContext>, IProductDal
    {

        public List<Product> ProductGetAllWithDetail()
        {
            try
            {
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    var product =
                        greenHouseContext.Products.Include("ProductBrand").Include("ProductProducer").Include("ProductCategory").ToList();
                    return product;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public List<ProductContent> ProductGetAllContent(int id)
        {
            try
            {
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    var content = greenHouseContext.ProductContents.Where(x => x.ProductId == id).ToList();
                    return content;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
