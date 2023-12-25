using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPServer
{
    public partial class Order : UserControl
    {
        TcpClient client;
        public Order()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
        }

        private void showMsg(string msg)
        {
            textBox4.AppendText($"{msg}\r\n");
            textBox4.AppendText("\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                client.Connect("192.168.111.153", 13000);

                if (listBox1.SelectedIndex != -1)
                {
                    if (MessageBox.Show($"선택하신 품목이\r\n{listBox1.SelectedItem.ToString()}\r\n\r\n맞으십니까?", "주문 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        showMsg(listBox1.SelectedItem.ToString());
                        // JSON 객체 생성
                        json json1 = new json();
                        json1.제품 = comboBox1.Text;
                        json1.수량 = int.Parse(domainUpDown1.Text);
                        json1.판매가 = int.Parse(textBox2.Text);
                        json1.총금액 = int.Parse(textBox1.Text);
                        string text = System.Text.Json.JsonSerializer.Serialize(json1);
                        byte[] bytess = Encoding.UTF8.GetBytes(text);
                        NetworkStream stream = client.GetStream();
                        stream.Write(bytess, 0, bytess.Length);
                        client.Close();
                        MessageBox.Show($"{listBox1.SelectedItem.ToString()}\r\n\r\n주문 완료되었습니다.", "주문 완료");

                    }
                    else
                    {
                    }
                }
                else
                {
                    MessageBox.Show("물건이 선택되지 않았습니다.", "주문 실패");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("서버 상태가 불안정합니다.", "주문 실패");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("제품 : " + comboBox1.SelectedItem + " / 수량 : "
             + domainUpDown1.Text + " / 판매가 : " + textBox2.Text + " / 총금액 : " + textBox1.Text);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                textBox2.Text = "100000";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox2.Text = "150000";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBox2.Text = "200000";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textBox2.Text = "500000";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                textBox2.Text = "350000";
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                textBox2.Text = "450000";
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                textBox2.Text = "300000";
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                textBox2.Text = "400000";
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                textBox2.Text = "600000";
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                textBox2.Text = "800000";
            }
            else if (comboBox1.SelectedIndex == 10)
            {
                textBox2.Text = "1000000";
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            int result = int.Parse(domainUpDown1.Text) * int.Parse(textBox2.Text);
            textBox1.Text = result.ToString();
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
