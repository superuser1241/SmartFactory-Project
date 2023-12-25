using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;  // 추가
using System.Net; // 추가

namespace MPServer
{
    public partial class ClientMainForm : Form
    {
        public static string userid;
        Inquiry inquiry = new Inquiry();
        Order order = new Order();
        bigcell big = new bigcell();
        smallcell small = new smallcell();
        Home home = new Home();

        StreamReader streamReader;  // 데이타 읽기 위한 스트림리더
        StreamWriter streamWriter;  // 데이타 쓰기 위한 스트림라이터 
        public ClientMainForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void ClientMainForm_Load(object sender, EventArgs e)
        {
            panel1.Controls.Remove(order);
            panel1.Controls.Remove(inquiry);
            panel1.Controls.Remove(big);
            panel1.Controls.Remove(small);
            panel1.Controls.Add(home);
            textBox1.Text = userid;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(big);
            panel1.Controls.Remove(order);
            panel1.Controls.Remove(inquiry);
            panel1.Controls.Remove(small);
            panel1.Controls.Remove(home);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(inquiry);
            panel1.Controls.Remove(order);
            panel1.Controls.Remove(big);
            panel1.Controls.Remove(small);
            panel1.Controls.Remove(home);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(order);
            panel1.Controls.Remove(inquiry);
            panel1.Controls.Remove(big);
            panel1.Controls.Remove(small);
            panel1.Controls.Remove(home);

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Add(small);
            panel1.Controls.Remove(inquiry);
            panel1.Controls.Remove(big);
            panel1.Controls.Remove(order);
            panel1.Controls.Remove(home);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(home);
            panel1.Controls.Remove(inquiry);
            panel1.Controls.Remove(big);
            panel1.Controls.Remove(order);
            panel1.Controls.Remove(small);
        }
    }
}
