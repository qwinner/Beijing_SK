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
    public partial class User : Form
    {
        public UserManage parent;
        private string name;
        public User(string username)
        {
            InitializeComponent();
            name = username;
            
        }

        private void User_Load(object sender, EventArgs e)
        {
            if (global.current_user == "admin")
            {
                textBox2.ReadOnly = true;
                textBox1.Text = name;
                textBox3.Focus();
            }
            else
            {
                textBox1.Text = global.current_user;
                textBox2.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text.Trim()) && !string.IsNullOrEmpty(textBox4.Text.Trim()))
            {
                SqlConnection sqlcon = new SqlConnection(global.sqlconstr);
                SqlCommand sqlcommand = sqlcon.CreateCommand();
                sqlcon.Open();
                if (global.current_user != "admin")
                {
                    if (string.IsNullOrEmpty(textBox2.Text.Trim()))
                    {
                        MessageBox.Show("������ԭʼ���룡");
                        return;
                    }
                    SqlDataReader dr;
                    sqlcommand.CommandText = "select passwd from t_user where name='" + textBox1.Text.Trim() + "'";
                    dr = sqlcommand.ExecuteReader();
                    dr.Read();
                    if (dr.GetString(0).ToString() != textBox2.Text)
                    {
                        MessageBox.Show("ԭʼ��������޸�ʧ�ܣ�");
                        dr.Close();
                        sqlcommand.Dispose();
                        sqlcon.Close();
                        return;
                    }
                    dr.Close();
                }
                if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("������������벻һ�£�");
                    return;
                }
                try
                {
                    sqlcommand.CommandText = "update t_user set passwd='" + textBox3.Text.Trim() + "' where name='" + textBox1.Text.Trim() + "'";
                    sqlcommand.ExecuteNonQuery();
                    MessageBox.Show("�����޸ĳɹ���");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("���ݿ��쳣��");
                }
                sqlcommand.Dispose();
                sqlcon.Close();
            }
            else
            {
                MessageBox.Show("���������������룡");
            }
        }
    }
}