using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace water
{
    public partial class Config_Form : Form
    {
        private int tmpstyle;
        private string sqlcon = string.Empty;
        public Config_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Config_Form_Load(object sender, EventArgs e)
        {
            if (global.sqlstrstyle == 1)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tmpstyle = 1;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox1.Text = string.Empty;
            textBox1.Enabled = false;
            textBox2.Focus();
            if (global.sqlstrstyle == 1)
            {
                string[] splitstr = global.sqlconstr.Split(Convert.ToChar(";"));
                textBox2.Text = splitstr[0].Split(Convert.ToChar("="))[1];
                textBox4.Text = splitstr[1].Split(Convert.ToChar("="))[1];
                textBox3.Text = splitstr[2].Split(Convert.ToChar("="))[1];
                textBox5.Text = splitstr[3].Split(Convert.ToChar("="))[1];
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tmpstyle = 2;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox1.Enabled = true;
            textBox1.Focus();
            if (global.sqlstrstyle == 2)
            {
                textBox1.Text = global.sqlconstr;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = global.AppPath + @"\Myconfig.ini";
            sqlcon = "\"" + sqlcon + "\"";
            global.WritePrivateProfileString("MyConnectionStr", "style",tmpstyle.ToString() , path);
            global.WritePrivateProfileString("MyConnectionStr", "sqlstr", sqlcon, path);
            MessageBox.Show("数据库连接信息修改成功，下次启动后生效！");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tmpstyle == 1)
            {
                if (string.IsNullOrEmpty(textBox2.Text.Trim()) || string.IsNullOrEmpty(textBox3.Text.Trim()) || string.IsNullOrEmpty(textBox4.Text.Trim()) || string.IsNullOrEmpty(textBox5.Text.Trim()))
                {
                    MessageBox.Show("请将必要信息填写完整！");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    MessageBox.Show("请将必要信息填写完整！");
                    return;
                }
            }
            if (tmpstyle == 1)
            {
                sqlcon = "database=" + textBox2.Text.Trim() + ";Server=" + textBox4.Text.Trim() + ";uid=" + textBox3.Text.Trim() + ";Password=" + textBox5.Text.Trim() + ";Persist Security Info=True";
            }
            else
            {
                sqlcon = textBox1.Text.Trim();
            }  
            try
            {
                SqlConnection sqlconn = new SqlConnection(sqlcon);
                sqlconn.Open();
                sqlconn.Close();
                button1.Enabled = true;
                button3.Enabled = false;
                MessageBox.Show("测试成功！");

            }
            catch
            {
                MessageBox.Show("无法建立数据库连接！");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
        }
    }
}