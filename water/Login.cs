using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace water
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                SqlConnection sqlcon = new SqlConnection(global.sqlconstr);
                SqlCommand sqlcommand = sqlcon.CreateCommand();
                sqlcon.Open();
                SqlDataReader dr;
                sqlcommand.CommandText = "select passwd from t_user where name='" + textBox1.Text.Trim() + "'";
                dr = sqlcommand.ExecuteReader();
                if (dr.Read())
                {
                    string passwd = dr.GetString(0).ToString();
                    dr.Close();
                    if (textBox2.Text.Trim() == passwd)
                    {
                        this.Hide();
                        sqlcommand.Dispose();
                        sqlcon.Close();
                        global.current_user = textBox1.Text.Trim();
                        MainFrm mf = new MainFrm();
                        mf.Show();

                    }
                    else
                    {
                        MessageBox.Show("您输入的密码有误！");
                        textBox2.Text = "";
                        textBox2.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("该用户名不存在！");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
                dr.Close();
                sqlcommand.Dispose();
                sqlcon.Close();
            }
            else
            {
                MessageBox.Show("请将必要信息填写完整！");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            splash.NewForm.ShowDialog(this);
            if (global.sqlconstr == "error")
            {
                MessageBox.Show("配置信息错误！");
                Application.Exit();
            }
            skinEngine1.SkinFile = "Skin\\" + global.skin_name;
            textBox1.Focus();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.5;
            }
        }
    }
}