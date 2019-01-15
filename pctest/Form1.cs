using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pctest.ServiceReference1;
using System.IO;

namespace pctest
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.WebService1SoapClient hr = new WebService1SoapClient();

                textBox1.Text = hr.HelloWorld();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string srfilepath = @"C:\Users\user\Documents\Visual Studio 2015\Projects\WebApplication1\WebApplication1\PdaToPc.txt";
        private string swfilepath = @"C:\Users\user\Documents\Visual Studio 2015\Projects\WebApplication1\WebApplication1\PcToPda.txt";

        private void btnsend_Click(object sender, EventArgs e)
        {
            StreamReader sa = new StreamReader(srfilepath, Encoding.Default);  //Encoding.Default：代表使用ANSI編碼，可讀中文字
            textBox2.Text = sa.ReadToEnd();
            sa.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {       
            StreamWriter sb = new StreamWriter(swfilepath, false, Encoding.Default);
            sb.Write(textBox3.Text);
            sb.Close();
            MessageBox.Show("save");
            textBox3.Text = ""; 

        }
    }
}
