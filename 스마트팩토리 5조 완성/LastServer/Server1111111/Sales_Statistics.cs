using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Sockets;


namespace Server1111111
{
    public partial class Sales_Statistics : UserControl
    {
        string strConn;
        OracleConnection conn;
        TcpClient client;
        NetworkStream stream;
        OracleCommand cmd;
        string sql;
        OracleDataAdapter da;

        public Sales_Statistics()
        {
            InitializeComponent();
        }

        private void 판매통계_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

            sql = "SELECT * FROM 판매";
            cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;

            da = new OracleDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "판매");

            dataGridView1.DataSource = ds.Tables["판매"];

            // 차트 설정
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Bar;
            series.XValueMember = "제품";
            series.YValueMembers = "수량";
            series.Points.DataBind(ds.Tables["판매"].DefaultView, "제품", "수량", null);
            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Interval = 1;

        }
    }
}
