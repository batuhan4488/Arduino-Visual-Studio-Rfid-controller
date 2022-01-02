using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Data.OleDb;



namespace Kart_Sistemleri
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        static SerialPort _serialPort;
        OleDbConnection baglanti = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\batuhan\source\repos\Kart-Sistemleri\Kart-Sistemleri\bç.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from icerik", baglanti);
            adtr.Fill(ds, "icerik");
            dataGridView1.DataSource = ds.Tables["icerik"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            button6.Enabled = true;
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM5";
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
            listele();
            
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            
            string b = _serialPort.ReadExisting();
            if (b == "")
                return;
            textBox4.Text = b;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into icerik(Dno,kad,ksoy,id) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                ds.Clear();
                listele();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update icerik set kad='" + textBox2.Text + "', ksoy='" + textBox3.Text + "', id='" + textBox4.Text + "' where Dno=" + textBox1.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();
            ds.Clear();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Delete from icerik where Dno=" + textBox1.Text + "";
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            ds.Clear();
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _serialPort.Close();
            Form2 yonetimPaneli = new Form2();
            this.Hide();
            yonetimPaneli.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            _serialPort.Close();
            Form2 yonetimPaneli = new Form2();
            this.Hide();
            yonetimPaneli.Show();
        }
    }
}
