using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace water
{
    public partial class pj_zc : Form
    {
        public pj_zc()
        {
            InitializeComponent();
        }

        private void pj_zc_Load(object sender, EventArgs e)
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
            this.comboBox3.Items.Add("���´�");
            this.comboBox3.Items.Add("�����");
            ////��
            //this.comboBox4.Items.Add("��·Ӳ����Ŀ");
            //this.comboBox4.Items.Add("��·Ӳ����Ŀ");
            //this.comboBox3.SelectedIndex = 0;
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////��Ŀ
            //this.comboBox4.Items.Add("����ͷ��");
            //this.comboBox4.Items.Add("�����");
            //this.comboBox4.SelectedIndex = 0;
        }
    }
}