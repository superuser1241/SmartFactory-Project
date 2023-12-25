using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Server1111111
{
    public partial class Form1 : Form
    {
        Order_Inquiry 주문조회form = new Order_Inquiry();
        Member_management 회원관리form = new Member_management();
        Production 생산form = new Production();
        Inquiry 문의form = new Inquiry();
        Sales_Statistics 판매통계form = new Sales_Statistics();
        TcpClient client;
        TcpListener server;
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("프로그램을 종료합니다. 감사합니다");
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Remove(주문조회form);
            panel1.Controls.Remove(문의form);
            panel1.Controls.Remove(회원관리form);
            panel1.Controls.Add(생산form);
            panel1.Controls.Remove(판매통계form);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            panel1.Controls.Remove(주문조회form);
            panel1.Controls.Remove(문의form);
            panel1.Controls.Remove(생산form);
            panel1.Controls.Add(회원관리form);
            panel1.Controls.Remove(판매통계form);

        }

        private async void Form1_Load(object sender, EventArgs e)
        {


            panel1.Controls.Add(생산form);
            panel1.Controls.Remove(회원관리form);
            panel1.Controls.Remove(문의form);
            panel1.Controls.Remove(주문조회form);
            panel1.Controls.Remove(판매통계form);


            //Console.WriteLine("연결을 기다리는 중...");

            string strConn = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=hr;Password=hr;";

            //1.연결 객체 만들기 - Client
            conn = new OracleConnection(strConn);

            //2.데이터베이스 접속을 위한 연결
            conn.Open();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Remove(문의form);
            panel1.Controls.Remove(회원관리form);
            panel1.Controls.Remove(생산form);
            panel1.Controls.Remove(판매통계form);
            panel1.Controls.Add(주문조회form);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            panel1.Controls.Remove(주문조회form);
            panel1.Controls.Remove(문의form);
            panel1.Controls.Remove(회원관리form);
            panel1.Controls.Remove(생산form);
            panel1.Controls.Add(판매통계form);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Remove(주문조회form);
            panel1.Controls.Remove(회원관리form);
            panel1.Controls.Remove(생산form);
            panel1.Controls.Remove(판매통계form);
            panel1.Controls.Add(문의form);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            while (true)
            {
                client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] bytes = new byte[512];
                int length = stream.Read(bytes, 0, bytes.Length);
                string message = Encoding.UTF8.GetString(bytes, 0, length);
                json json1 = System.Text.Json.JsonSerializer.Deserialize<json>(message);
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"INSERT INTO ACCOUNT VALUES ('{json1.ID}','{json1.PW}','{json1.Address}','{json1.PhoneNumber}')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("회원가입이 완료되었습니다.", "Sign up");
            }
        }
        public class json
        {
            public string ID { get; set;  }
            public string PW { get; set; }

            public string Address { get; set; }
            public string PhoneNumber { get; set; }
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
