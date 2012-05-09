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
    public partial class User_add : Form
    {
        public UserManage parent;
        public User_add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(textBox2.Text.Trim()) && !string.IsNullOrEmpty(textBox3.Text.Trim()))
            {
                if (textBox2.Text.Trim() == textBox3.Text.Trim())
                {
                    if (textBox2.Text.Trim().Length > 5)
                    {
                        SqlConnection sqlcon = new SqlConnection(global.sqlconstr);
                        SqlCommand sqlcommand = sqlcon.CreateCommand();
                        sqlcon.Open();
                        SqlDataReader dr1;
                        sqlcommand.CommandText = "select * from t_user where name='" + textBox1.Text.Trim() + "'";
                        dr1 = sqlcommand.ExecuteReader();
                        if (!dr1.Read())
                        {
                            dr1.Close();
                            sqlcommand.CommandText = "insert into t_user(name,passwd,register_time) values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + DateTime.Now.ToString() + "')";
                            sqlcommand.ExecuteNonQuery();
                            parent.dgv1();
                            sqlcommand.Dispose();
                            sqlcon.Close();
                            MessageBox.Show("注册成功！");
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("该登录名已经被占用！", "警告");
                            dr1.Close();
                        }
                        sqlcommand.Dispose();
                        sqlcon.Close();
                    }
                    else
                    {
                        MessageBox.Show("您输入的密码太短！");
                    }
                }
                else
                {
                    MessageBox.Show("两次输入的密码不一致！");
                }
            }
            else
            {
                MessageBox.Show("请将必要信息填写完整！");
            }
        }
    }
}