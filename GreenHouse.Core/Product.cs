namespace GreenHouse.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public string Barkod { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public int? ProducerId { get; set; }

        public string ProductContentImageSaveTo { get; set; }

        public string ProductFrontImageSaveTo { get; set; }

        public string ProductBehindImageSaveTo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfAdd { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfChange { get; set; }

        public int? UserId { get; set; }

        public int? UserAdminId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AdminVerificationDate { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ProductProducer ProductProducer { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
