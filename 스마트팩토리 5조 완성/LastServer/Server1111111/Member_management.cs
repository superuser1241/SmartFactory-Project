using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server1111111
{
    public partial class Member_management : UserControl
    {
        public Member_management()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ODP.NET Core 누겟에서 다운 필수
            string strConn = "User Id=hr;Password=hr;" +
                   "Data Source=(DESCRIPTION=" +
                   "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                   "(HOST=localhost)(PORT=1521)))" +
                   "(CONNECT_DATA=(SERVER=DEDICATED)" +
                   "(SERVICE_NAME=xe)));";

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = strConn;
            conn.Open();

            string sql = "SELECT * FROM ACCOUNT";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;

            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "ACCOUNT");

            dataGridView1.DataSource = ds.Tables["ACCOUNT"];

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("종료하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               
                Dispose();
            }
            else
            {
              
            }
      
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void 회원관리_Load(object sender, EventArgs e)
        {

        }
    }
                }
           
      
   