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
    public partial class Form2 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        public Form2()
        {
            InitializeComponent();
        }

        void KiraciGetir()
        {
            baglanti = new SqlConnection("Server=LAPTOP-RMJOF9U4\\SQLEXPRESS;Initial Catalog = MBP207PRJ; Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select *From KiraBilgileri2", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO KiraBilgileri2(TCKimlik,Ad,Soyad,GSM,Adres,KiraBaslangicTarihi,KiraBitisTarihi,Kontrat,KiraBedeli,KirayaVerenTCKimlik,KirayaVerenAd,KirayaVerenSoyad,KirayaVerenGSM,KirayaVerenAdres) VALUES (@TCKimlik,@Ad,@Soyad,@GSM,@Adres,@KiraBaslangicTarihi,@KiraBitisTarihi,@Kontrat,@KiraBedeli,@KirayaVerenTCKimlik,@KirayaVerenAd,@KirayaVerenSoyad,@KirayaVerenGSM,@KirayaVerenAdres)";
            SqlCommand sqlCommand = new SqlCommand(sorgu, baglanti);
            komut = sqlCommand;
            komut.Parameters.AddWithValue("@TCKimlik", txt1TC.Text);
            komut.Parameters.AddWithValue("@Ad", txt1AD.Text);
            komut.Parameters.AddWithValue("@Soyad", txt1SOYAD.Text);
            komut.Parameters.AddWithValue("@GSM", txt1GSM.Text);
            komut.Parameters.AddWithValue("@Adres", txt1ADRES.Text);
            komut.Parameters.AddWithValue("@KiraBaslangicTarihi", dtpBaslangic.Value);
            komut.Parameters.AddWithValue("@KiraBitisTarihi", dtpBitis.Value);
            komut.Parameters.AddWithValue("@Kontrat", label14.Text);
            komut.Parameters.AddWithValue("@KiraBedeli", txtKiraBedeli.Text);
            komut.Parameters.AddWithValue("@KirayaVerenTCKimlik", txt2TC.Text);
            komut.Parameters.AddWithValue("@KirayaVerenAd", txt2AD.Text);
            komut.Parameters.AddWithValue("@KirayaVerenSoyad", txt2SOYAD.Text);
            komut.Parameters.AddWithValue("@KirayaVerenGSM", txt2GSM.Text);
            komut.Parameters.AddWithValue("@KirayaVerenAdres", txt2ADRES.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            KiraciGetir();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            KiraciGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt1TC.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt1AD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt1SOYAD.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt1GSM.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt1ADRES.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dtpBaslangic.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dtpBitis.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            label14.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtKiraBedeli.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txt2TC.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txt2AD.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txt2SOYAD.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txt2GSM.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txt2ADRES.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
        }

        private void btnKontratYukle_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM KiraBilgileri2 WHERE TCKimlik=@TCKimlik";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@TCKimlik", txt1TC.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            KiraciGetir();

        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            txt1TC.Clear();
            txt1AD.Clear();
            txt1SOYAD.Clear();
            txt1GSM.Clear();
            txt1ADRES.Clear();
            txt2TC.Clear();
            txt2AD.Clear();
            txt2SOYAD.Clear();
            txt2GSM.Clear();
            txt2ADRES.Clear();
            txtKiraBedeli.Clear();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE KiraBilgileri2 SET ad=@ad, soyad=@soyad, GSM=@GSM, Adres=@Adres, KiraBedeli=@KiraBedeli, KirayaVerenTCKimlik=@KirayaVerenTCKimlik, KirayaVerenAd=@KirayaVerenAd, KirayaVerenSoyad=@KirayaVerenSoyad, KirayaVerenGSM=@KirayaVerenGSM, KirayaVerenAdres=@KirayaVerenAdres WHERE TCKimlik=@TCKimlik";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("TCKimlik", txt1TC.Text);
            komut.Parameters.AddWithValue("Ad", txt1AD.Text);
            komut.Parameters.AddWithValue("Soyad", txt1SOYAD.Text);
            komut.Parameters.AddWithValue("GSM", txt1GSM.Text);
            komut.Parameters.AddWithValue("Adres", txt1ADRES.Text);
            komut.Parameters.AddWithValue("KiraBedeli", txtKiraBedeli.Text);
            komut.Parameters.AddWithValue("KirayaVerenTCKimlik", txt2TC.Text);
            komut.Parameters.AddWithValue("KirayaVerenAd", txt2AD.Text);
            komut.Parameters.AddWithValue("KirayaVerenSoyad", txt2SOYAD.Text);
            komut.Parameters.AddWithValue("KirayaVerenGSM", txt2GSM.Text);
            komut.Parameters.AddWithValue("KirayaVerenAdres", txt2ADRES.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            KiraciGetir();
    
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Çıkış Yapmak İstiyor Musunuz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Çıkış yapılmadı");
            }
        }
    }
}
