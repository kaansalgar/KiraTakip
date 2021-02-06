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


namespace MBP207_Proje_KiraTakip
{
    public partial class Form4 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public Form4()
        {
            InitializeComponent();
        }

        void KiracıGetir()
        {
            baglanti = new SqlConnection("Server=LAPTOP-RMJOF9U4\\SQLEXPRESS;Initial Catalog = MBP207PRJ; Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select *From KiraBilgileri2", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KiracıGetir();
        }
    }
}
