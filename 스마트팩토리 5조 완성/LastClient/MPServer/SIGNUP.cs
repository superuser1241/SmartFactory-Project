using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MPServer
{
    
    public partial class SIGNUP : Form
    {
        OracleConnection conn;
        public SIGNUP()
        {
            InitializeComponent();
        }

        private void SIGNUP_Load(object sender, EventArgs e)
        {
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
                conn = new OracleConnection(strConn);

                //2.데이터베이스 접속을 위한 연결
                conn.Open();

                //3.서버와 함께 신나게 놀기
                // ~~~~~~~~

                //4. 리소스 반환 및 종료
                //conn.Close();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"INSERT INTO ACCOUNT VALUES ('{IDbox.Text}','{PWBox.Text}','{AddressBox.Text}','{CallBox.Text}')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("회원가입이 완료되었습니다.");
                Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
