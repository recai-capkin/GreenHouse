using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Core
{
    [Table("UserAllergen")]
    public class UserAllergen
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AllergenContentName { get; set; }
    }
}
