using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms.DataVisualization.Charting;

namespace Server1111111
{
    public partial class Inquiry : UserControl
    {
        private static string ip = "192.168.111.153";
        private static string port = "13001";

        private static TcpClient client = new TcpClient();
        public Inquiry()
        {
            InitializeComponent();
        }
        private void 문의_Load(object sender, EventArgs e)
        {
            Thread receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }
        private void Receive()
        {
            while (true)
            {
                if (client.Connected)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
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
        private void Connect()
        {
            try
            {
                TcpListener server = new TcpListener(IPAddress.Parse(ip), int.Parse(port));
                server.Start();
                WriteLog("Ready to connect ...");

                client = server.AcceptTcpClient();
                WriteLog("Client connected!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string message = textBox2.Text;
            if (message.Length <= 0) { return; }

            try
            {
                NetworkStream stream = client.GetStream();
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
                Debug.WriteLine(ex.ToString());
            }

        }
        private void WriteLog(string text)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Invoke(new MethodInvoker(delegate ()
            {
                textBox1.AppendText("[" + date + "] " + text + "\r\n");
            }));
        }
    }
}
