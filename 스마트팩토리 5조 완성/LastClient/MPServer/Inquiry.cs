using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPServer
{
    public partial class Inquiry : UserControl
    {
        private static string ip = "192.168.111.153";
        private static string port = "13001";
        private static TcpClient client = new TcpClient();
        private static NetworkStream stream;
        public Inquiry()
        {
            InitializeComponent();
        }

        private void Inquiry_Load(object sender, EventArgs e)
        {
            Thread connectThread = new Thread(new ThreadStart(Receive));
            connectThread.IsBackground = true;
            connectThread.Start();
        }
        private void Receive()
        {
            while (true)
            {
                if (client.Connected)
                {
                    try
                    {
                        stream = client.GetStream();
                        byte[] buffer = new byte[1024];
                        int bytes = stream.Read(buffer, 0, buffer.Length);
                        if (bytes <= 0)
                        {
                            continue;
                        }

                        string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                        WriteLog("[Other] " + message);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread connectThread = new Thread(new ThreadStart(Connect));
            connectThread.IsBackground = true;
            connectThread.Start();
        }

        private void WriteLog(string text)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Invoke(new MethodInvoker(delegate ()
            {
                textBox1.AppendText("[" + date + "] " + text + "\r\n");
            }));
        }

        private void Connect()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
            try
            {
                client.Connect(endPoint);
                WriteLog("connected...");
            }
            catch (SocketException se)
            {
                WriteLog(se.Message);
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void 문의하기_Click(object sender, EventArgs e)
        {
            string message = textBox2.Text;
            if (message.Length <= 0) { return; }

            try
            {
                stream = client.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);

                stream = client.GetStream();
                byte[] buffera = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);

                WriteLog("[Me] " + message);
                textBox2.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
