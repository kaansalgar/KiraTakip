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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-RMJOF9U4\\SQLEXPRESS;Initial Catalog = MBP207PRJ; Integrated Security=True");



        private void button1_Click(object sender, EventArgs e)
        {


            Form2 frmDetay = new Form2();
            string sorgu = "SELECT * FROM Users where UserName=@user AND UserPassword=@pass";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@user", txtUser.Text);
            cmd.Parameters.AddWithValue("@pass", txtPass.Text);
            baglanti.Open();
            SqlDataReader dtr = cmd.ExecuteReader();
            if (dtr.Read())
            {


                MessageBox.Show("Giriş Başarılı");
                frmDetay.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Giriş Başarısız");

            }
            baglanti.Close();




        }
    }
}
