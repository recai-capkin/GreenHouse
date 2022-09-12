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
        public Product AddProduct(Product product, string topkategori, string subkategori, string marka, List<ProductContent> contentList, string uretici, int userId)
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
                    DateOfAdd = DateTime.Now,
                    UserId = userId
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
                    if (oldTopCate == null)
                    {
                        ProductCategory newTopcategory = new ProductCategory()
                        {
                            CategoryName = topkategori,
                        };
                        var addOldTopCategory = greenHouseContext.Entry(newTopcategory);
                        addOldTopCategory.State = EntityState.Added;
                        greenHouseContext.SaveChanges();
                        newTopcategory.TopCategory = newTopcategory.CategoryId;

                        var updatedEntity = greenHouseContext.Entry(newTopcategory);
                        updatedEntity.State = EntityState.Modified;
                        greenHouseContext.SaveChanges();
                        var oldSubCategory = greenHouseContext.ProductCategories.Where(x => x.CategoryName == subkategori).FirstOrDefault();
                        if (oldSubCategory == null)
                        {
                            ProductCategory newSubCategory = new ProductCategory()
                            {
                                CategoryName = subkategori,
                                TopCategory = newTopcategory.CategoryId
                            };
                            var addNewSubCategory = greenHouseContext.Entry(newSubCategory);
                            addNewSubCategory.State = EntityState.Added;
                            greenHouseContext.SaveChanges();
                            data.CategoryId = newSubCategory.CategoryId;
                        }
                        else
                        {
                            data.CategoryId = oldSubCategory.CategoryId;
                        }



                    }
                    else
                    {
                        ProductCategory newSubcategory = new ProductCategory()
                        {

                            CategoryName = subkategori,
                            TopCategory = oldTopCate.CategoryId
                        };
                        var addSubCategory = greenHouseContext.Entry(newSubcategory);
                        addSubCategory.State = EntityState.Added;
                        greenHouseContext.SaveChanges();
                        data.CategoryId = newSubcategory.CategoryId;

                    }
                    //ProductCategory productCategory = new ProductCategory()
                    //{
                    //    CategoryName = subkategori,
                    //    TopCategory = oldTopCate.CategoryId
                    //};
                    //var ae = greenHouseContext.Entry(productCategory);
                    //ae.State = EntityState.Added;
                    //greenHouseContext.SaveChanges();
                    //var newcate = greenHouseContext.ProductCategories.Where(x => x.CategoryName == subkategori).SingleOrDefault();

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
                var data = greenHouseContext.BlackLists.Where(x => x.UserId == userId).ToList();
                List<string> newBlackList = new List<string>();
                foreach (var item in data)
                {
                    var newData = greenHouseContext.Products.Where(x => x.ProductId == item.ProductId).SingleOrDefault();
                    newBlackList.Add(newData.ProductName);
                }
                return newBlackList;
            }
        }
        public bool UserAllergenAdd(int userId, string allergenName)
        {
            try
            {
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    greenHouseContext.UserAllergens.Add(new UserAllergen()
                    {
                        AllergenContentName = allergenName,
                        UserId = userId
                    });
                    greenHouseContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string> GetUserAllergen(int userId)
        {
            try
            {
                List<string> allergenList;
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    allergenList = greenHouseContext.UserAllergens.Where(x => x.UserId == userId).Select(x => x.AllergenContentName).ToList();
                }
                return allergenList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string> GetProductContent()
        {
            try
            {
                List<string> contentList;
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    contentList = greenHouseContext.ProductContents.Select(x => x.ContentName).ToList();
                }
                return contentList;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<ProductContentSimpleDto> GetSimpleProductWithContent()
        {
            try
            {
                List<ProductContentSimpleDto> productContentSimpleDtos = new List<ProductContentSimpleDto>();

                List<Product> tempProduct;
                List<ProductContent> tempProductContent;

                //ProductContentSimpleDto tempproductContentSimpleDto;
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    tempProduct = greenHouseContext.Products.ToList();
                    tempProductContent = greenHouseContext.ProductContents.ToList();

                    foreach (var item in tempProduct)
                    {
                        productContentSimpleDtos.Add(new ProductContentSimpleDto()
                        {
                            ContentCount = tempProductContent.Where(x => x.ProductId == item.ProductId).Count(),
                            ProductName = item.ProductName,
                        });
                    }
                }
                return productContentSimpleDtos;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> IsIncludeContentProduct(string contentName)
        {
            try
            {
                var list = new List<ProductContent>();
                var product = new List<Product>();
                using (GreenHouseContext greenHouseContext = new GreenHouseContext())
                {
                    list = greenHouseContext.ProductContents.Where(x => x.ContentName == contentName).ToList();
                    foreach (var item in list)
                    {
                        if (item.ContentName == contentName)
                        {
                            product.Add(greenHouseContext.Products.Where(x => x.ProductId == item.ProductId).SingleOrDefault());
                        }
                    }

                }
                return product;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetAllProductIsVerificationAndMonth()
        {
            var product = new List<Product>();
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                product = greenHouseContext.Products.Where(x => x.UserAdminId != null && x.AdminVerificationDate.Value.Month == DateTime.Now.Month).ToList();
            }
            return product;
        }

        //En az riski olan ürünler neler ve bunların kaçı favoride
        //public List<ProductRiskAndFavoriteDto> GetProductRiskAndFavorite()
        //{
        //    var returnData = new List<ProductRiskAndFavoriteDto>();
        //    using (GreenHouseContext greenHouseContext = new GreenHouseContext())
        //    {
        //        var data = greenHouseContext
        //    }
        //}

        public List<UserAddedProductDto> GetUserAddedProduct()
        {
            var data = new List<UserAddedProductDto>();
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var newData = greenHouseContext.Users
                    .Join(
                    greenHouseContext.Products,
                    x => x.UserId,
                    x => x.UserId,
                    (a, b) => new
                    {
                        Id = a.UserId,
                        ProductCount = a.Products.Count(x => x.UserId == a.UserId),
                        FullUserName = a.Name
                    })
                    .GroupBy(onceki => onceki.FullUserName).Select(grup => new UserAddedProductDto
                    {
                        Id = grup.Select(x => x.Id).FirstOrDefault(),
                        FullUserName = grup.Key,
                        ProductCount = grup.Count()
                    }).ToList();

                //).GroupBy(X => X.FullUserName,y => y.Id)
                //.ToList()
                //.Select((a,b) => new UserAddedProductDto { FullUserName = a.Key,Id = a.Select( x=> x.)});
                //data = newData;
                return newData;
            }
        }
        public List<UserAddedProductDto> GetUserAddedProductList()
        {
            var data = new List<UserAddedProductDto>();
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                var newData = greenHouseContext.Users
                    .Join(
                    greenHouseContext.Products,
                    x => x.UserId,
                    x => x.UserId,
                    (a, b) => new UserAddedProductDto
                    {
                        ProductCount = a.Products.Count(),
                        FullUserName = a.Name + a.Surname
                    }
                    ).Distinct().ToList();
                //data = newData;
                return newData;
            }
        }

        public List<Product> GetUnvouchedProductList()
        {
            var data = new List<Product>();
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                data = greenHouseContext.Products.Include(x => x.ProductBrand).Include(x => x.ProductProducer).Where(x => x.UserAdminId == null).ToList();
            }
            return data;
        }

        public bool VerificationProduct(Product product)
        {
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                Product oldProduct = greenHouseContext.Products.Find(product.ProductId);
                if (oldProduct != null)
                {
                    oldProduct.AdminVerificationDate = product.AdminVerificationDate;
                    oldProduct.UserAdminId = product.UserAdminId;
                    var updatedEntity = greenHouseContext.Entry(oldProduct);
                    updatedEntity.State = EntityState.Modified;
                    greenHouseContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public List<FavoriteProductDto> MostFavoriteProduct()
        {
            var data = new List<FavoriteProductDto>();
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                data = greenHouseContext.Products
                   .Join(
                   greenHouseContext.FavoriteProducts,
                   x => x.ProductId,
                   x => x.ProductId,
                   (x, y) => new
                   {
                       ProductName = x.ProductName,
                       ProductId = y.ProductId,

                   }).GroupBy(x => x.ProductName).Select(x => new FavoriteProductDto
                   {
                       ProductName = x.Key,
                       ProductCount = x.Count()
                   }).OrderByDescending(x => x.ProductCount).ToList();
            }
            return data;
        }

        public List<ProductAddUserCount> ProductAddUserCounts()
        {
            var data = new List<ProductAddUserCount>();
            using (GreenHouseContext greenHouseContext = new GreenHouseContext())
            {
                 data = greenHouseContext.Users
                    .Join(
                    greenHouseContext.Products,
                    x => x.UserId,
                    x => x.UserId,
                    (x, y) => new ProductAddUserCount
                    {
                        Username = x.UserName,
                        Email = x.UserEmail,
                        AddedProductCount =y.ProductId
                    }).GroupBy(x => new { x.Username }).Select(x => new ProductAddUserCount 
                    {
                        Username =x.Key.Username, 
                        Email = x.Select(p => p.Email).FirstOrDefault(),
                        AddedProductCount = x.Count(),
                    }).ToList();
            }
            return data;
        }
    }
}

