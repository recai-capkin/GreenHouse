using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBarkod { get; set; }
        public string ProductMarka { get; set; }
        public string ProductKategori { get; set; }
        public string ProductUretici { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime DegistirmeTarihi { get; set; }
        public int EkleyenKullaniciAdi { get; set; }
        public int OnaylayanAdminAdi { get; set; }
        public DateTime OnaylanmaTarihi { get; set; }



    }
}
