using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OgrenciTakip
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=tsomtal.com;Initial Catalog=OgrenciDb;Integrated Security=True;");
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            try { 
                baglanti.Open();
                int OkulNo=Convert.ToInt32(textBoxOkulNo.Text);
                string sqlCumlesi="INSERT INTO Ogrenciler (OkulNo,AdiSoyadi) VALUES("+OkulNo+",'" + textBoxAdiSoyadi.Text+"')";
                SqlCommand cmd = new SqlCommand(sqlCumlesi,baglanti);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Veriler aktarıldı.");
            } catch (Exception ex) {
                MessageBox.Show("Bağlantı hatası\n" + ex.Message);
            }
            finally
            {
               if (baglanti!=null) baglanti.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'ogrenciDbDataSet.Ogrenciler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrencilerTableAdapter.Fill(this.ogrenciDbDataSet.Ogrenciler);

        }

        private void buttonListele_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Update();
            dataGridView1.Refresh();
            
        }
    }
}
