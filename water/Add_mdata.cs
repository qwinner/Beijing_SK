using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace water
{
    public partial class Add_mdata : Form
    {
        public Add_mdata()
        {
            InitializeComponent();
        }

        private void Add_mdata_Load(object sender, EventArgs e)
        {
            //һ��ָ��
            this.comboBox4.Items.Add("��֯����");
            this.comboBox4.Items.Add("ֱ���ʽ����");
            this.comboBox4.Items.Add("���ڷ�����Ŀ����");
            this.comboBox4.Items.Add("ʵʩЧ������");
            this.comboBox4.SelectedIndex = 0;
            //����ָ��
            this.comboBox5.Items.Add("������������");
            this.comboBox5.Items.Add("ͳ�ƹ���");
            this.comboBox5.SelectedIndex = 0;
            //����ָ��
            this.comboBox6.Items.Add("������ʩ��Ŀ");
            this.comboBox6.Items.Add("�������߼������ƶ��ƶ�");
            this.comboBox6.SelectedIndex = 0;
            ////����
            //this.comboBox7.Items.Add("��ɽ��");
            //this.comboBox7.Items.Add("��ƽ��");
            //this.comboBox7.SelectedIndex = 0;
            ////����
            //this.comboBox8.Items.Add("ʮ������");
            //this.comboBox8.Items.Add("��������");
            //this.comboBox8.SelectedIndex = 0;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (comboBox4.Text.ToString())
            //{
            //    case "ʵʩЧ������":
            //        this.comboBox5.Items.Clear();
            //        this.comboBox5.Items.Add("����Ⱥ�ھ���ˮƽ");
            //        this.comboBox5.Items.Add("����Ⱥ����������");
            //        this.comboBox5.Items.Add("������������������ȶ�");
            //        break;
            //    default:
            //        this.comboBox5.Items.Clear();
            //        break;
            //}
        }
    }
}