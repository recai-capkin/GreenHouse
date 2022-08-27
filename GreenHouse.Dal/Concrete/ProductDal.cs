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

        public List<ProductProducer> ProducerGetAll()
        {
            try
            {
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    var content = greenHouseContext.ProductProducers.ToList();
                    return content;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProductCategory> CategoryGetAll()
        {
            try
            {
                using(GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    var content = greenHouseContext.ProductCategories.ToList();
                    return content;
                }
                    
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool BarkodControl(string barkod)
        {
            try
            {
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    var deger = greenHouseContext.Products.Any(x => x.Barkod == barkod);
                    return deger;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  Product GetProductDetailWithBarkod(string barkod)
        {
            try
            {
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    var deger = greenHouseContext.Products.Include("ProductBrand").Include("ProductCategory").Include("ProductProducer").Where(x => x.Barkod == barkod).FirstOrDefault();
                    return deger;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ProductCategory TopCategory(int? id)
        {
            try
            {
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    var deger = greenHouseContext.ProductCategories.Where(x => x.CategoryId == id ).FirstOrDefault();
                    var deger2 = greenHouseContext.ProductCategories.Where(x => x.CategoryId == deger.TopCategory && x.TopCategory == deger.TopCategory).FirstOrDefault();
                    return deger2;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
