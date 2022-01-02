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
    public partial class Form2 : Form
    {
        int sayac=0;
        int sayac2 = 0;
        
        public Form2()
        {
            InitializeComponent();
        }
        static SerialPort _serialPort;

        private void a(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
            label3.Visible = false;
            label4.Visible = false; 
            label6.Visible = false;
            label5.Visible = false;
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string a = _serialPort.ReadExisting();
            if (a == "")
                return;
            label2.Visible = true;
            label2.Text = a;
            
            OleDbConnection baglanti = new OleDbConnection(@"provider=microsoft.jet.oledb.4.0; data source= C:\Users\batuhan\source\repos\Kart-Sistemleri\Kart-Sistemleri\bç.mdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select * from icerik where id=@id ", baglanti);
            sorgu.Parameters.AddWithValue("@id", a);

            OleDbDataReader dr;
            dr = sorgu.ExecuteReader();
            if (dr.Read())
            {
                
                label3.Visible = true;
                label6.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label5.Text = dr["kad"].ToString();
                label4.Visible = false;
                timer1.Start();
                
                


            }
            else
            {
                label4.Visible = true;
                label3.Visible = false;
                timer2.Start();
                
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            sayac++;
            if (sayac == 100)
            {
                label3.Visible = false;
                label2.Visible = false;
                label6.Visible = false;
                label5.Visible = false;
                sayac = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            sayac2++;
            if (sayac2 == 100)
            {
                label4.Visible = false;
                label2.Visible = false;
                
                sayac2 = 0;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _serialPort.Close();
            Form3 yonetimPaneli = new Form3();
            this.Hide();
            yonetimPaneli.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
