namespace GreenHouse.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlackList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FavoriteProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductListName = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        NotificationContent = c.String(),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserPassword = c.String(maxLength: 50),
                        UserEmail = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Adress = c.String(),
                        Phone = c.String(maxLength: 50),
                        UserRoleId = c.Int(),
                        UserAddDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserRole", t => t.UserRoleId)
                .Index(t => t.UserRoleId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(maxLength: 50),
                        Barkod = c.String(),
                        BrandId = c.Int(),
                        CategoryId = c.Int(),
                        ProducerId = c.Int(),
                        ProductContentImageSaveTo = c.String(),
                        ProductFrontImageSaveTo = c.String(),
                        ProductBehindImageSaveTo = c.String(),
                        DateOfAdd = c.DateTime(storeType: "date"),
                        DateOfChange = c.DateTime(storeType: "date"),
                        UserId = c.Int(),
                        UserAdminId = c.Int(),
                        AdminVerificationDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductBrand", t => t.BrandId)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryId)
                .ForeignKey("dbo.ProductProducer", t => t.ProducerId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserAdminId)
                .Index(t => t.BrandId)
                .Index(t => t.CategoryId)
                .Index(t => t.ProducerId)
                .Index(t => t.UserId)
                .Index(t => t.UserAdminId);
            
            CreateTable(
                "dbo.ProductBrand",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        TopCategory = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.ProductCategory", t => t.TopCategory)
                .Index(t => t.TopCategory);
            
            CreateTable(
                "dbo.ProductProducer",
                c => new
                    {
                        ProducerId = c.Int(nullable: false, identity: true),
                        ProducerName = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.ProducerId);
            
            CreateTable(
                "dbo.UserFavoriteProductList",
                c => new
                    {
                        FavoriteProductListId = c.Int(nullable: false, identity: true),
                        ProductListName = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.FavoriteProductListId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserRoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.ProductContent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ContentName = c.String(),
                        ContentThreadLevel = c.String(),
                        ContentDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.UserAllergen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AllergenContentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserRoleId", "dbo.UserRole");
            DropForeignKey("dbo.UserFavoriteProductList", "UserId", "dbo.User");
            DropForeignKey("dbo.Product", "UserAdminId", "dbo.User");
            DropForeignKey("dbo.Product", "UserId", "dbo.User");
            DropForeignKey("dbo.Product", "ProducerId", "dbo.ProductProducer");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductCategory", "TopCategory", "dbo.ProductCategory");
            DropForeignKey("dbo.Product", "BrandId", "dbo.ProductBrand");
            DropForeignKey("dbo.Notification", "UserId", "dbo.User");
            DropIndex("dbo.UserFavoriteProductList", new[] { "UserId" });
            DropIndex("dbo.ProductCategory", new[] { "TopCategory" });
            DropIndex("dbo.Product", new[] { "UserAdminId" });
            DropIndex("dbo.Product", new[] { "UserId" });
            DropIndex("dbo.Product", new[] { "ProducerId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Product", new[] { "BrandId" });
            DropIndex("dbo.User", new[] { "UserRoleId" });
            DropIndex("dbo.Notification", new[] { "UserId" });
            DropTable("dbo.UserAllergen");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.ProductContent");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserFavoriteProductList");
            DropTable("dbo.ProductProducer");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.ProductBrand");
            DropTable("dbo.Product");
            DropTable("dbo.User");
            DropTable("dbo.Notification");
            DropTable("dbo.FavoriteProduct");
            DropTable("dbo.BlackList");
        }
    }
}
