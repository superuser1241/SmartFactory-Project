using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Server1111111.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server1111111
{
    public partial class Order_Inquiry : UserControl
    {
        string strConn;
        OracleConnection conn;
        TcpClient client;
        NetworkStream stream;
        public Order_Inquiry()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private async void 주문조회_Load(object sender, EventArgs e)
        {
            strConn = "User Id=hr;Password=hr;" +
      "Data Source=(DESCRIPTION=" +
      "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
      "(HOST=localhost)(PORT=1521)))" +
      "(CONNECT_DATA=(SERVER=DEDICATED)" +
      "(SERVICE_NAME=xe)));";

            conn = new OracleConnection();
            conn.ConnectionString = strConn;
            conn.Open();


            IPAddress serverip = IPAddress.Parse("192.168.111.153");
            int port = 13000;
            TcpListener server = new TcpListener(serverip, port);
            server.Start();
            textBox1.Text = "연결성공";
            while (true)
            {
                client = await server.AcceptTcpClientAsync();
                HandleClientAsync(client);
            }
        }






        private void button1_Click_1(object sender, EventArgs e)
        {
            string strConn = "User Id=hr;Password=hr;" +
                  "Data Source=(DESCRIPTION=" +
                  "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                  "(HOST=localhost)(PORT=1521)))" +
                  "(CONNECT_DATA=(SERVER=DEDICATED)" +
                  "(SERVICE_NAME=xe)));";

            conn = new OracleConnection();
            conn.ConnectionString = strConn;
            conn.Open();

            string sql = "SELECT * FROM 주문";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;

            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "주문");

            dataGridView3.DataSource = ds.Tables["주문"];
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            
        }

        async void HandleClientAsync(TcpClient client)
        {
            stream = client.GetStream();
            byte[] bytes = new byte[512];
            int length = await stream.ReadAsync(bytes, 0, bytes.Length);
            string message = Encoding.UTF8.GetString(bytes, 0, length);

            json json1 = System.Text.Json.JsonSerializer.Deserialize<json>(message);
            textBox1.Text += json1.제품 + json1.수량 + json1.판매가 + json1.총금액;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO 주문 VALUES ('{json1.제품}','{json1.수량}','{json1.판매가}','{json1.총금액}')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("주문이 입력되었습니다.");
            client.Close();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
    public class json
    {
        public string 제품 { get; set; }
        public int 수량 { get; set; }
        public int 판매가 { get; set; }
        public int 총금액 { get; set; }
    }
}

