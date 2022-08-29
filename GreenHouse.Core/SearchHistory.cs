using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Core
{
    [Table("SearchHistory")]
    public class SearchHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SearchText { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
