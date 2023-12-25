using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server1111111
{
    public partial class Production : UserControl
    {

        private List<Image> images = new List<Image>();
        private int currentIndex = 0;
        int column1;

        public Production()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }

        private void 생산_Load(object sender, EventArgs e)
        {
            string strConn = "User Id=hr;Password=hr;" +
"Data Source=(DESCRIPTION=" +
"(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
"(HOST=localhost)(PORT=1521)))" +
"(CONNECT_DATA=(SERVER=DEDICATED)" +
"(SERVICE_NAME=xe)));";

            OracleConnection conn = new OracleConnection();
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

            dataGridView1.DataSource = ds.Tables["주문"];

            LoadImages1();
            LoadImages2();
            LoadImages3();
            LoadImages4();
           

            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;

            comboBox1.Items.Add("원통형 전지");
            comboBox1.Items.Add("파우치");
            comboBox1.Items.Add("프리폼");
            comboBox1.SelectedIndex = 0;

            progressBar1.Style = ProgressBarStyle.Blocks;
            //최소값 지정(기본값)
            progressBar1.Minimum = 0;
            //최대값 지정(기본값 =10)
            progressBar1.Maximum = 6;


            // 1씩 증가
            progressBar1.Step = 1;
            progressBar1.Value = 0;


            progressBar2.Style = ProgressBarStyle.Blocks;
            //최소값 지정(기본값)
            progressBar2.Minimum = 0;
            //최대값 지정(기본값 =10)
            progressBar2.Maximum = 6;
            // 1씩 증가
            progressBar2.Step = 1;
            progressBar2.Value = 0;

            progressBar3.Style = ProgressBarStyle.Blocks;
            //최소값 지정(기본값)
            progressBar3.Minimum = 0;
            //최대값 지정(기본값 =10)
            progressBar3.Maximum = 6;
            // 1씩 증가
            progressBar3.Step = 1;
            progressBar3.Value = 0;

            progressBar4.Style = ProgressBarStyle.Blocks;
            //최소값 지정(기본값)
            progressBar4.Minimum = 0;
            //최대값 지정(기본값 =10)
            progressBar4.Maximum = 6;
            // 1씩 증가
            progressBar4.Step = 1;
            progressBar4.Value = 0;
        }


        private void LoadImages1()
        {
            images.Add(Image.FromFile(@"C:\Temp\믹싱공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨믹싱.png"));
            images.Add(Image.FromFile(@"C:\Temp\믹싱공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨믹싱.png"));
            images.Add(Image.FromFile(@"C:\Temp\믹싱공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨믹싱.png"));
            images.Add(Image.FromFile(@"C:\Temp\믹싱공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨믹싱.png"));

            pictureBox1.Image = images[currentIndex];
        }

        private void LoadImages2()
        {

            images.Add(Image.FromFile(@"C:\Temp\코팅공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\코팅공정빨.png"));
            images.Add(Image.FromFile(@"C:\Temp\코팅공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\코팅공정빨.png"));
            images.Add(Image.FromFile(@"C:\Temp\코팅공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\코팅공정빨.png"));
           

            pictureBox2.Image = images[currentIndex];
        }

        private void LoadImages3()
        {
            images.Add(Image.FromFile(@"C:\Temp\롤프레싱공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨롤프레싱.png"));
            images.Add(Image.FromFile(@"C:\Temp\롤프레싱공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨롤프레싱.png"));
            images.Add(Image.FromFile(@"C:\Temp\롤프레싱공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨롤프레싱.png"));
          

            pictureBox3.Image = images[currentIndex];
        }
        private void LoadImages4()
        {
            images.Add(Image.FromFile(@"C:\Temp\노칭공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨노칭공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\노칭공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨노칭공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\노칭공정.png"));
            images.Add(Image.FromFile(@"C:\Temp\빨노칭공정.png"));

            pictureBox4.Image = images[currentIndex];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"{comboBox1.Text} {textBox1.Text}개 생산이 시작됩니다.");

                timer1.Start();


                timer2.Interval = 1000;
                timer2.Start();
                pictureBox15.Visible = true;
                await Task.Delay(7000);


                timer2.Stop();
                pictureBox15.Visible = false;

                timer3.Interval = 1000;
                timer3.Start();
                pictureBox16.Visible = true;
                await Task.Delay(6000);


                timer3.Stop();
                pictureBox16.Visible = false;

                timer4.Interval = 1000;
                timer4.Start();
                pictureBox17.Visible = true;
                await Task.Delay(6000);


                timer4.Stop();
                pictureBox17.Visible = false;

                timer5.Interval = 1000;
                timer5.Start();
                pictureBox18.Visible = true;
                await Task.Delay(6000);


                timer5.Stop();
                pictureBox18.Visible = false;
                MessageBox.Show("생산을 완료하였습니다. 고객님에게 배송을 시작합니다.");



                string selectedValue = comboBox1.Text;

                string strConn = "User Id=hr;Password=hr;" +
                "Data Source=(DESCRIPTION=" +
                 "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                 "(HOST=localhost)(PORT=1521)))" +
                 "(CONNECT_DATA=(SERVER=DEDICATED)" +
                 "(SERVICE_NAME=xe)));";


                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = strConn;
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"DELETE FROM 주문 WHERE (제품 = '{comboBox1.Text}' AND 수량 = {textBox1.Text})";
                cmd.ExecuteNonQuery();

                using (OracleConnection con = new OracleConnection(strConn))
                {
                    con.Open();
                    OracleCommand insertCmd = new OracleCommand();

                    string sqlQuery = $"SELECT 수량 FROM 판매 WHERE 제품 = '{comboBox1.Text}'";


                    using (OracleCommand command = new OracleCommand(sqlQuery, conn))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string column1Value = reader["수량"].ToString();
                                column1 = int.Parse(column1Value);
                            }
                        }
                    }
                    insertCmd.Connection = con;
                    int result = column1 + int.Parse(textBox1.Text);
                    insertCmd.CommandText = $"UPDATE 판매 SET 수량 = {result}   WHERE 제품 = '{comboBox1.Text}' AND 수량 = {column1}";
                    insertCmd.ExecuteNonQuery();
                }


                using (conn = new OracleConnection(strConn))
                {
                    conn.Open();

                    string selectSql = "SELECT * FROM 주문";

                    using (cmd = new OracleCommand(selectSql, conn))
                    {
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            // 타이머 중지 조건
            if (progressBar1.Value == 6)
            {
             
                timer1.Enabled = false;
            }

            for (int proprogressBar1 = 0; proprogressBar1 < 6; proprogressBar1++)
            {
                if (progressBar1.Value % 2 == 0)
                {
                    pictureBox12.Visible = true;
                }

                else
                {
                    pictureBox12.Visible = false;
                }

            }


            await Task.Delay(6000);

            progressBar2.PerformStep();
            // 타이머 중지 조건
            if (progressBar2.Value == 6)
            {
               
                timer1.Enabled = false;
            }


            for (int proprogressBar2 = 0; proprogressBar2 < 6; proprogressBar2++)
            {
                if (progressBar2.Value % 2 == 0)
                {
                    pictureBox13.Visible = true;
                }

                else
                {
                    pictureBox13.Visible = false;
                }

            }

            await Task.Delay(6000);

            progressBar3.PerformStep();
            // 타이머 중지 조건
            if (progressBar3.Value == 6)
            {

                timer1.Enabled = false;
            }


            for (int proprogressBar3 = 0; proprogressBar3 < 6; proprogressBar3++)
            {
                if (progressBar3.Value % 2 == 0)
                {
                    pictureBox14.Visible = true;
                }

                else
                {
                    pictureBox14.Visible = false;
                }

            }


            await Task.Delay(6000);

            progressBar4.PerformStep();
            // 타이머 중지 조건
            if (progressBar4.Value == 6)
            {
                await Task.Delay(1000);
                progressBar1.Value = 0;
                progressBar2.Value = 0;
                progressBar3.Value = 0;
                progressBar4.Value = 0;
                timer1.Enabled = false;
            }


        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % images.Count;
            pictureBox1.Image = images[currentIndex];
        }

        private async void timer3_Tick(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % images.Count;
            pictureBox2.Image = images[currentIndex];
        }

        private async void timer4_Tick(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % images.Count;
            pictureBox3.Image = images[currentIndex];
        }

        private async void timer5_Tick(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % images.Count;
            pictureBox4.Image = images[currentIndex];


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strConn = "User Id=hr;Password=hr;" +
"Data Source=(DESCRIPTION=" +
"(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
"(HOST=localhost)(PORT=1521)))" +
"(CONNECT_DATA=(SERVER=DEDICATED)" +
"(SERVICE_NAME=xe)));";

            OracleConnection conn = new OracleConnection();
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

            dataGridView1.DataSource = ds.Tables["주문"];
        }
    }
}
