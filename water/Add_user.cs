using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace water
{
    public partial class Add_user : Form
    {
        public Add_user()
        {
            InitializeComponent();
        }

        private void Add_user_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("������");
            this.comboBox2.Items.Add("��ɽ��");
            this.comboBox3.Items.Add("��������");
            this.comboBox4.Items.Add("����ͷ��");
        }
    }
}