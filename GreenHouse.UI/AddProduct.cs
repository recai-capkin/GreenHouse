using GreenHouse.Core;
using GreenHouse.Dal.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouse.UI
{
    public partial class AddProduct : Form
    {
        User _user;
        public string ProductContentPicture = "s";
        public string ProductFrontPicture = "s";
        public string ProductBehindPicture = "s";
        public int? updateTopCategoryId;
        public int? updateCategoryId;
        public int productId;
        bool UpdateStatus = false;
        
        string dir;
        public AddProduct()
        {
            InitializeComponent();
        }
        public AddProduct(User user) : base()
        {
            InitializeComponent();
            _user = user;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnSideMenu_Click(object sender, EventArgs e)
        {
            Navbar navbar = new Navbar();
            navbar.ShowDialog();
        }

        private void btnUserDetail_Click(object sender, EventArgs e)
        {
            UserDetail userDetail = new UserDetail();
            userDetail.Show();
            this.Hide();
        }

        private void btnAddProductImageContent_Click(object sender, EventArgs e)
        {
            ProductContentPicture = SavePicture();
            //btnAddProductImageContent.BackgroundImage = Image.FromFile("E:\\Resimler\\" + ProductContentPicture);
            label11.Visible = true;
            

        }
        public string SavePicture()
        {
            string returnPath = "";
            string path = "E:\\Resimler\\";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string pictureName = Guid.NewGuid().ToString();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(openFileDialog.FileName, path + pictureName + ".jpg");
                returnPath = pictureName + ".jpg";
            }
            return returnPath;
        }
        private void btnAddProductImageFront_Click(object sender, EventArgs e)
        {
            ProductFrontPicture = SavePicture();
            //btnAddProductImageFront.BackgroundImage = Image.FromFile("E:\\Resimler\\" + ProductFrontPicture);
            label13.Visible = true;
        }

        private void btnAddProductImageBehind_Click(object sender, EventArgs e)
        {
            ProductBehindPicture = SavePicture();
            //btnAddProductImageBehind.BackgroundImage = Image.FromFile("E:\\Resimler\\" + ProductBehindPicture);
            label12.Visible = true;
        }

        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            if (textBox1.Text != null && comboBox2.Text != null && textBox3.Text != null &&
                comboBox1.Text != null && textBox5.Text != null && textBox6 != null &&
                ProductBehindPicture != null && ProductFrontPicture != null && ProductContentPicture != null
                )
            {
                var deger = productDal.BarkodControl(textBox1.Text);
                if (deger != true && UpdateStatus != true)
                {
                    Product newProduct = new Product()
                    {
                        Barkod = textBox1.Text,
                        ProductName = textBox3.Text,
                        ProductContentImageSaveTo = ProductContentPicture,
                        ProductBehindImageSaveTo = ProductBehindPicture,
                        ProductFrontImageSaveTo = ProductFrontPicture,
                        DateOfChange = DateTime.Now,
                    };
                    string topkategori = comboBox1.Text;
                    string subkategori = comboBox3.Text;
                    string marka = textBox2.Text;
                    String[] content;
                    String[] tehlikeSeviyesi;
                    char ayrac = ',';
                    content = textBox5.Text.Split(ayrac);
                    tehlikeSeviyesi = textBox6.Text.Split(ayrac);
                    List<ProductContent> contentList = new List<ProductContent>();
                    for (int i = 0; i < content.Length; i++)
                    {
                        ProductContent productContent = new ProductContent()
                        {
                            ContentName = content[i],
                            ContentThreadLevel = tehlikeSeviyesi[i],
                            ProductId = productId
                        };
                        contentList.Add(productContent);
                    }
                    string uretici = comboBox2.Text;
                    productDal.AddProduct(newProduct, topkategori, subkategori, marka, contentList,uretici);
                }
                else
                {
                    if (UpdateStatus)
                    {
                        ProductDal productDal1 = new ProductDal();
                        Product newProduct = new Product()
                        {
                            Barkod = textBox1.Text,
                            ProductId = productId,
                            ProductName = textBox3.Text,
                            ProductContentImageSaveTo = ProductContentPicture,
                            ProductBehindImageSaveTo = ProductBehindPicture,
                            ProductFrontImageSaveTo = ProductFrontPicture,
                            DateOfChange = DateTime.Now,

                        };
                        ProductCategory productCategory = new ProductCategory()
                        {
                            CategoryName = comboBox3.Text,
                            TopCategory = updateTopCategoryId,
                            CategoryId = (int)updateCategoryId
                        };
                        String[] content;
                        String[] tehlikeSeviyesi;
                        char ayrac = ',';
                        content = textBox5.Text.Split(ayrac);
                        tehlikeSeviyesi = textBox6.Text.Split(ayrac);
                        List<ProductContent> contentList = new List<ProductContent>();
                        for (int i = 0; i < content.Length; i++)
                        {
                            ProductContent productContent = new ProductContent()
                            {
                                ContentName = content[i],
                                ContentThreadLevel = tehlikeSeviyesi[i],
                                ProductId = productId
                            };
                            contentList.Add(productContent);
                        }
                        ProductBrand productBrand = new ProductBrand()
                        {
                            BrandName = textBox2.Text
                        };
                        ProductProducer productProducer = new ProductProducer()
                        {
                            ProducerName = comboBox2.Text
                        };
                        var kontrol = productDal1.UpdateProduct(newProduct, productCategory, contentList, productBrand, productProducer);
                        if (kontrol)
                        {
                            MessageBox.Show("Başarıyla Güncellendi");
                        }
                        else
                        {
                            MessageBox.Show("Hata oluştu");
                        }
                        UpdateStatus = false;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Bu barkoda sahip ürün var. Güncelleme yapmak için Evet, devam etmek için hayır", "Uyarı", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var data = productDal.GetProductDetailWithBarkod(textBox1.Text);
                            productId = data.ProductId;
                            textBox1.Text = data.Barkod;
                            textBox2.Text = data.ProductBrand.BrandName;
                            comboBox2.Text = data.ProductProducer.ProducerName;
                            textBox3.Text = data.ProductName;
                            comboBox1.Text = productDal.TopCategory(data.CategoryId).CategoryName;
                            comboBox3.Text = data.ProductCategory.CategoryName;
                            updateTopCategoryId = productDal.TopCategory(data.CategoryId).CategoryId;
                            updateCategoryId = data.CategoryId;
                            ProductContentPicture = data.ProductContentImageSaveTo;
                            ProductFrontPicture = data.ProductFrontImageSaveTo;
                            ProductBehindPicture = data.ProductBehindImageSaveTo;
                            btnAddProductImageFront.BackgroundImage = Image.FromFile("E:\\Resimler\\" + ProductFrontPicture);
                            btnAddProductImageBehind.BackgroundImage = Image.FromFile("E:\\Resimler\\" + ProductBehindPicture);
                            btnAddProductImageContent.BackgroundImage = Image.FromFile("E:\\Resimler\\" + ProductContentPicture);
                            UpdateStatus = true;
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                        else
                        {

                        }
                    }
                  
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.Text);
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            foreach (var item in productDal.CategoryGetAll())
            {
                if (item.CategoryId == item.TopCategory)
                {
                    comboBox1.Items.Add(item);
                }
                if (item.CategoryId != item.TopCategory)
                {
                    comboBox3.Items.Add(item);
                }
            }
            foreach (var item in productDal.ProducerGetAll())
            {
                comboBox2.Items.Add(item);
            }

            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
        }
    }
}
