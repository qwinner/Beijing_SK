using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace water
{
    public partial class ceshi_2 : Form
    {
        public ceshi_2()
        {
            InitializeComponent();
        }

        private void ceshi_2_Load(object sender, EventArgs e)
        {
            //һ��ָ��
            this.comboBox4.Items.Add("��֯����");
            this.comboBox4.Items.Add("ֱ���ʽ����");
            this.comboBox4.Items.Add("���ڷ�����Ŀ����");
            this.comboBox4.Items.Add("ʵʩЧ������");
            this.comboBox4.SelectedIndex = 3;
            //����ָ��
            this.comboBox5.Items.Add("���������������");
            this.comboBox5.Items.Add("�������");
            //����ָ��
            this.comboBox6.Items.Add("��������������");
            this.comboBox6.Items.Add("�ƻ�����");
            //�ļ�ָ��
            this.comboBox7.Items.Add("��Ŀ����");
            this.comboBox7.Items.Add("�Ƿ�����쵼С��");

            this.comboBox4.Items.Add("ʵʩЧ������");
            //this.comboBox4.SelectedIndex = 3;
            ////����
            //this.comboBox3.Items.Add("��ɽ��");
            ////����
            //this.comboBox2.Items.Add("��������");






        }
    }
}