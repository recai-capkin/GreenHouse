namespace GreenHouse.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserFavoriteProductList")]
    public partial class UserFavoriteProductList
    {
        [Key]
        public int FavoriteProductListId { get; set; }

        public string ProductListName { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public override string ToString()
        {
            return ProductListName;
        }
    }
}
