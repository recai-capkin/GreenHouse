using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Core
{
    [Table("ProductContent")]
    public class ProductContent
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ContentName { get; set; }
        public string ContentThreadLevel { get; set; }
        public string ContentDescription { get; set; }
        public override string ToString()
        {
            return ContentName;
        }

    }
}
