using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPServer
{
    public partial class Form1 : Form
    {
        SIGNUP SIGNUP = new SIGNUP();
        ClientMainForm clientMainForm = new ClientMainForm();

        string userid;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIGNUP.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=hr;Password=hr;";

                //1.연결 객체 만들기 - Client
                OracleConnection conn = new OracleConnection(strConn);

                //2.데이터베이스 접속을 위한 연결
                conn.Open();

                int login_status = 0;
                string loginid = textBox1.Text;
                string loginpw = textBox2.Text;

                string selectQuery = "SELECT * FROM ACCOUNT WHERE ID = \'" + loginid + "\' ";
                OracleCommand Selectcommand = new OracleCommand(selectQuery, conn);
                OracleDataReader userAccount = Selectcommand.ExecuteReader();
                while (userAccount.Read())
                // userAccount가 Read 되고 있을 동안
                {
                    if (loginid == (string)userAccount["ID"] && loginpw == (string)userAccount["PW"])
                    // 만약 loginid변수의 값이 account_info 테이블 값의 id 정보와,
                    // loginpwd변수의 값이 account_info 테이블 값의 pwd 정보와 일치한다면
                    {
                        login_status = 1;
                        // 해당 변수 상태를 1로 바꾼다.
                    }
                }
                conn.Close();
                // MySQL과 연결을 끊는다.
                if (login_status == 1)
                // 만약 해당 변수 상태가 1이라면,
                {
                    MessageBox.Show("로그인 완료");
                    ClientMainForm.userid = textBox1.Text;
                  
                    // 로그인 완료 메시지박스를 띄운다.
                    clientMainForm.ShowDialog();
                }
                else
                // 아니라면,
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");
                    // 오류 메시지박스를 띄운다.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
    
