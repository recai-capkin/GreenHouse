using GreenHouse.Core;
using GreenHouse.Dal.Abstract.Interface;
using GreenHouse.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
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
        public Product GetProductDetailWithBarkod(string barkod)
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
                    var deger = greenHouseContext.ProductCategories.Where(x => x.CategoryId == id).FirstOrDefault();
                    var deger2 = greenHouseContext.ProductCategories.Where(x => x.CategoryId == deger.TopCategory && x.TopCategory == deger.TopCategory).FirstOrDefault();
                    return deger2;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool UpdateProduct(Product product, ProductCategory productCategory, List<ProductContent> productContent, ProductBrand productBrand, ProductProducer productProducer)
        {
            try
            {

                ProductBrand newProductBrand = new ProductBrand();
                ProductContent productContent1 = new ProductContent();
                ProductCategory productCategory1 = new ProductCategory();
                ProductProducer productProducer1 = new ProductProducer();
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    Product product1 = greenHouseContext.Products.Find(product.ProductId);
                    if (product1 == null)
                    {
                        return false;
                    }
                    else
                    {
                        var updateProductCategory = greenHouseContext.ProductCategories.Where(x => x.CategoryName == productCategory.CategoryName).SingleOrDefault();
                        if (updateProductCategory != null)
                        {
                            productCategory1 = new ProductCategory()
                            {
                                CategoryId = updateProductCategory.CategoryId,
                                CategoryName = productCategory.CategoryName,
                                TopCategory = productCategory.TopCategory
                            };
                            var updatedEntity = greenHouseContext.Entry(productCategory1);
                            updatedEntity.State = EntityState.Modified;
                            greenHouseContext.SaveChanges();
                        }

                        foreach (var item in productContent)
                        {
                            var content = greenHouseContext.ProductContents.Where(x => x.ContentName == item.ContentName).SingleOrDefault();
                            if (content != null)
                            {
                                productContent1 = new ProductContent()
                                {
                                    Id = content.Id,
                                    ContentName = item.ContentName,
                                    ContentDescription = content.ContentDescription,
                                    ContentThreadLevel = item.ContentThreadLevel,
                                    ProductId = item.ProductId
                                };
                                var updatedEntity = greenHouseContext.Entry(productContent1);
                                updatedEntity.State = EntityState.Modified;
                                greenHouseContext.SaveChanges();
                            }

                        }
                        var pbrand = greenHouseContext.ProductBrands.Where(x => x.BrandName == productBrand.BrandName).SingleOrDefault();
                        if (pbrand != null)
                        {
                            newProductBrand = new ProductBrand()
                            {
                                BrandName = productBrand.BrandName,
                                BrandId = pbrand.BrandId
                            };
                            //brandId = pbrand.BrandId;
                            var updatedEntity = greenHouseContext.Entry(newProductBrand);
                            updatedEntity.State = EntityState.Modified;
                            greenHouseContext.SaveChanges();
                        }
                        var pProducer = greenHouseContext.ProductProducers.Where(x => x.ProducerName == productProducer.ProducerName).SingleOrDefault();
                        if (pProducer != null)
                        {
                            productProducer1 = new ProductProducer()
                            {
                                ProducerName = productProducer.ProducerName,
                                ProducerId = pProducer.ProducerId,
                            };

                            var updatedEntity = greenHouseContext.Entry(productProducer1);
                            updatedEntity.State = EntityState.Modified;
                            greenHouseContext.SaveChanges();
                        }
                        product1.ProductId = product.ProductId;
                        product1.ProductName = product.ProductName;
                        product1.Barkod = product.Barkod;
                        product1.BrandId = newProductBrand.BrandId;
                        product1.CategoryId = productCategory1.CategoryId;
                        product1.ProducerId = productProducer1.ProducerId;
                        product1.ProductContentImageSaveTo = product.ProductContentImageSaveTo;
                        product1.ProductFrontImageSaveTo = product.ProductFrontImageSaveTo;
                        product1.ProductBehindImageSaveTo = product.ProductBehindImageSaveTo;
                        product1.DateOfChange = product.DateOfChange;

                        var updated = greenHouseContext.Entry(product1);
                        updated.State = EntityState.Modified;
                        greenHouseContext.SaveChanges();
                        return true;
                    }

                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Product AddProduct(Product product, string topkategori, string subkategori, string marka, List<ProductContent> contentList, string uretici)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {


                greenHouseContext.Products.Add(new Product()
                {
                    Barkod = product.Barkod,
                    ProductName = product.ProductName,
                    ProductContentImageSaveTo = product.ProductContentImageSaveTo,
                    ProductBehindImageSaveTo = product.ProductBehindImageSaveTo,
                    ProductFrontImageSaveTo = product.ProductFrontImageSaveTo,
                    DateOfChange = DateTime.Now,
                });
                greenHouseContext.SaveChanges();

                var data = greenHouseContext.Products.Where(x => x.Barkod == product.Barkod).FirstOrDefault();

                var category = greenHouseContext.ProductCategories.Where(x => x.CategoryName == subkategori).FirstOrDefault();
                if (category != null)
                {
                    data.CategoryId = category.CategoryId;
                }
                else
                {
                    var oldTopCate = greenHouseContext.ProductCategories.Where(x => x.CategoryName == topkategori).SingleOrDefault();
                    ProductCategory productCategory = new ProductCategory()
                    {
                        CategoryName = subkategori,
                        TopCategory = oldTopCate.CategoryId
                    };
                    var ae = greenHouseContext.Entry(productCategory);
                    ae.State = EntityState.Added;
                    greenHouseContext.SaveChanges();
                    var newcate = greenHouseContext.ProductCategories.Where(x => x.CategoryName == subkategori).SingleOrDefault();
                    data.CategoryId = newcate.CategoryId;
                }
                var oldmarka = greenHouseContext.ProductBrands.Where(x => x.BrandName == marka).SingleOrDefault();
                if (oldmarka != null)
                {
                    data.BrandId = oldmarka.BrandId;
                }
                else
                {
                    ProductBrand productBrand = new ProductBrand()
                    {
                        BrandName = marka,
                    };
                    var ae = greenHouseContext.Entry(productBrand);
                    ae.State = EntityState.Added;
                    greenHouseContext.SaveChanges();
                    var newMarka = greenHouseContext.ProductBrands.Where(x => x.BrandName == marka).SingleOrDefault();
                    data.BrandId = newMarka.BrandId;
                }

                foreach (var item in contentList)
                {
                    ProductContent content = new ProductContent()
                    {
                        ContentName = item.ContentName,
                        ContentThreadLevel = item.ContentThreadLevel,
                        ProductId = data.ProductId
                    };
                    var ae = greenHouseContext.Entry(content);
                    ae.State = EntityState.Added;
                    greenHouseContext.SaveChanges();
                }
                var producer = greenHouseContext.ProductProducers.Where(x => x.ProducerName == uretici).SingleOrDefault();
                if (producer != null)
                {
                    data.ProducerId = producer.ProducerId;
                }
                else
                {
                    ProductProducer producerNew = new ProductProducer()
                    {
                        ProducerName = uretici,
                    };
                    var ae = greenHouseContext.Entry(producerNew);
                    ae.State = EntityState.Added;
                    greenHouseContext.SaveChanges();
                    var getNewProducer = greenHouseContext.ProductProducers.Where(x => x.ProducerName == uretici).FirstOrDefault();
                    data.ProducerId = getNewProducer.ProducerId;
                }
                var productNew = greenHouseContext.Entry(data);
                productNew.State = EntityState.Modified;
                greenHouseContext.SaveChanges();
                return greenHouseContext.Products.Where(x => x.Barkod == data.Barkod).SingleOrDefault();
            }
        }

        public List<Product> ProductGetAllWithDetailFilterByName(string productName)
        {
            try
            {
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    var product =
                        greenHouseContext.Products.Include("ProductBrand").Include("ProductProducer").Include("ProductCategory").Where(x => x.ProductName.Contains(productName)).ToList();
                    return product;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Product> ProductGetAllWithDetailFilterByBarkod(string barkod)
        {
            try
            {
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    var product =
                        greenHouseContext.Products.Include("ProductBrand").Include("ProductProducer").Include("ProductCategory").Where(x => x.Barkod.Contains(barkod)).ToList();
                    return product;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool AddSearchHistory(SearchHistory searchHistory)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                greenHouseContext.SearchHistories.Add(new SearchHistory()
                {
                    SearchDate = searchHistory.SearchDate,
                    SearchText = searchHistory.SearchText,
                    UserId = searchHistory.UserId,
                });
                greenHouseContext.SaveChanges();
                return true;
            }
        }


        public int CreateFavoriteList(int userId, string listeAdi)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                greenHouseContext.UserFavoriteProductLists.Add(new UserFavoriteProductList()
                {
                    ProductListName = listeAdi,
                    UserId = userId,
                });
                greenHouseContext.SaveChanges();
                var list = greenHouseContext.UserFavoriteProductLists.Where(x => x.ProductListName == listeAdi && x.UserId == userId).SingleOrDefault();
                return list.FavoriteProductListId;
            }
        }
        public bool AddFavoriteList(string listName, int productId, int userId)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                int baseListId;
                var liste = greenHouseContext.UserFavoriteProductLists.Where(x => x.ProductListName == listName && x.UserId == userId).FirstOrDefault();
                if (liste == null)
                {
                    baseListId = CreateFavoriteList(userId, listName);
                    greenHouseContext.FavoriteProducts.Add(new FavoriteProduct()
                    {
                        FavoriteProductListId = baseListId,
                        ProductId = productId

                    });
                }
                else
                {

                    baseListId = liste.FavoriteProductListId;
                    greenHouseContext.FavoriteProducts.Add(new FavoriteProduct()
                    {
                        FavoriteProductListId = baseListId,
                        ProductId = productId

                    });

                }
                greenHouseContext.SaveChanges();
                return true;
            }
        }

        public List<UserFavoriteProductList> GetFavoriteProductLists(int id)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var list = greenHouseContext.UserFavoriteProductLists.Where(x => x.UserId == id).ToList();
                return list;
            }

        }

        public bool AddBlackList(int productId, int userId)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                greenHouseContext.BlackLists.Add(new BlackList()
                {
                    ProductId = productId,
                    UserId = userId,
                });
                greenHouseContext.SaveChanges();
                return true;
            }
        }

        public int UserProductAddCount(int userId)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var deger = greenHouseContext.Products.Where(x => x.UserId == userId).Count();
                return deger;
            }

        }

        public List<FavoriteProductDto> GetFavoriteProducts(int userId, string listName)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var pList = greenHouseContext.UserFavoriteProductLists.Where(x => x.UserId == userId && x.ProductListName == listName).SingleOrDefault();
                var content = greenHouseContext.FavoriteProducts.Where(x => x.FavoriteProductListId == pList.FavoriteProductListId).ToList();
                List<FavoriteProductDto> favoriteProductDtoslist = new List<FavoriteProductDto>();
                foreach (var item in content)
                {
                    var data = greenHouseContext.Products.Where(x => x.ProductId == item.ProductId).SingleOrDefault();
                    favoriteProductDtoslist.Add(new FavoriteProductDto
                    {
                        ProductName = data.ProductName
                    });
                }
                return favoriteProductDtoslist;
            }
        }


        public List<string> GetBlackList(int userId)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var data = greenHouseContext.BlackLists.Where(x =>x.UserId == userId).ToList();
                List<string> newBlackList = new List<string>();
                foreach (var item in data)
                {
                    var newData = greenHouseContext.Products.Where(x => x.ProductId == item.ProductId).SingleOrDefault();
                    newBlackList.Add(newData.ProductName);
                }
                return newBlackList;
            }
        }



    }
}

