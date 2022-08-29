﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Core
{
    [Table("FavoriteProduct")]
    public class FavoriteProduct
    {
        public int Id { get; set; }
        public int FavoriteProductListId { get; set; }
        public int ProductId { get; set; }
    }
}
