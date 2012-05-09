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
    public partial class UserManage : Form
    {
        public UserManage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            dgv1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user_name="";
            if (global.current_user == "admin")
            {
                DataGridViewRow dr;
                if (this.dataGridView1.CurrentRow != null)
                {
                    dr = this.dataGridView1.CurrentRow;
                    user_name = dr.Cells[1].Value.ToString();
                }
                else
                {
                    MessageBox.Show("��ѡ����Ҫ�༭���û���");
                    return;
                }
            }
            else
            {
                user_name = "";
            }
            User user = new User(user_name);
            user.parent = this;
            user.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(global.current_user=="admin")
            {
                User_add ua = new User_add();
                ua.parent = this;
                ua.Show();
            }
            else
            {
                MessageBox.Show("ֻ�й���Ա�˻����ܽ��д˲�����");
            }
        }

        public void dgv1()
        {
            DataTable dt1 = new DataTable();
            SqlConnection sqlcon = new SqlConnection(global.sqlconstr);
            sqlcon.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select id,name,register_time from t_user", sqlcon);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns[0].HeaderText = "���";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].HeaderText = "�˻�";
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].HeaderText = "ע��ʱ��";
            dataGridView1.Columns[2].Width = 165;
            sqlcon.Close();
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (global.current_user == "admin")
            {
                DataGridViewRow dr;
                if (this.dataGridView1.CurrentRow != null)
                {
                    dr = this.dataGridView1.CurrentRow;
                    string account = dr.Cells[1].Value.ToString();
                    SqlConnection sqlcon = new SqlConnection(global.sqlconstr);
                    SqlCommand sqlcommand = sqlcon.CreateCommand();
                    if (account == "admin")
                    {
                        MessageBox.Show("�޷�ɾ������Ա�˻���");
                        return;
                    }
                    sqlcon.Open();
                    sqlcommand.CommandText = "delete from t_user where name='" + account + "'";
                    if (MessageBox.Show("ȷ��Ҫɾ���û�'" + dr.Cells[1].Value.ToString() + "'", "��ʾ", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        sqlcommand.ExecuteNonQuery();
                        dgv1();
                        MessageBox.Show("ɾ���ɹ���");
                    }
                    sqlcommand.Dispose();
                    sqlcon.Close();
                }
            }
            else
            {
                MessageBox.Show("ֻ�й���Ա�˻����ܽ��д˲�����");
            }
        }
    }
}