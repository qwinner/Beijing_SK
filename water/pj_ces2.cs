using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace water
{
    public partial class pj_ces2 : Form
    {
        public pj_ces2()
        {
            InitializeComponent();
        }

        private void pj_ces2_Load(object sender, EventArgs e)
        {
            //����
            this.comboBox1.Items.Add("��ƽ��");
            this.comboBox1.Items.Add("��ɽ��");
            this.comboBox1.Items.Add("ͨ����");
            this.comboBox1.Items.Add("������");
            this.comboBox1.SelectedIndex = 0;
            //����
            this.comboBox2.Items.Add("��������");
            this.comboBox2.Items.Add("ʮ������");
            //this.comboBox2.SelectedIndex = 0;
            //��
            this.comboBox3.Items.Add("����ͷ��");
            this.comboBox3.Items.Add("�����");
            //this.comboBox3.SelectedIndex = 0;
        }
    }
}