using System;
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
        public string ProductListName { get; set; }
        public int UserId { get; set; }
    }
}
