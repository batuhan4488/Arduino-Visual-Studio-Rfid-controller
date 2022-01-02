using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace Kart_Sistemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int gkod;
        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            gkod = r.Next(1000, 9999);
            label5.Text = gkod.ToString();
            textBox1.TextAlign = HorizontalAlignment.Left;
            textBox2.TextAlign = HorizontalAlignment.Left;
            textBox3.TextAlign = HorizontalAlignment.Left;
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\batuhan\source\repos\Kart-Sistemleri\Kart-Sistemleri\bç.mdb");

                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select kad,sifre from Kullaniciislemleri where kad=@ad and sifre=@sifre", baglanti);
                sorgu.Parameters.AddWithValue("@kad", textBox1.Text);
                sorgu.Parameters.AddWithValue("@sifre", textBox2.Text);
                OleDbDataReader dr;
                dr = sorgu.ExecuteReader();

                if (dr.Read())
                {

                    if (gkod == Convert.ToInt16(textBox3.Text))
                    {
                        Form2 frm = new Form2();
                        frm.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Güvenlik Anahtarı Yanlış girdiniz lütfen tekrar deneyiniz");
                    }
                }
                else
                {
                    baglanti.Close();
                    MessageBox.Show("Yanlış kullanıcı Adı ve Parolası . lütfen tekrar deneyiniz");
                }
            }
            catch
            {
                MessageBox.Show("lütfen kullanıcı ad ve paralonız ile giriş yapınız ");
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.BackColor = Color.Black;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
            }
            
            else
            {
                this.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
            }
        }
    }
}
