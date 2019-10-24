using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service1Client = new ServiceReference1.Service1Client();
            double distance = service1Client.Distance(textBox1.Text, textBox2.Text);
            label1.Text = distance.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference2.FewestConnectionsClient fewestConnectionsClient = new ServiceReference2.FewestConnectionsClient();
            textBox5.Text = fewestConnectionsClient.calculate(textBox3.Text, textBox4.Text);

        }
    }
}
