using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace water
{
    public partial class pic : Form
    {
        public pic()
        {
            InitializeComponent();
        }

        private void pic_Load(object sender, EventArgs e)
        {   
            //�Ŵ�����
            this.comboBox1.Items.Add("��ƽ��");
            this.comboBox1.Items.Add("��ɽ��");
            this.comboBox1.Items.Add(" ������");
            this.comboBox1.Items.Add("��ͷ����");
            this.comboBox1.Items.Add("������");
            this.comboBox1.Items.Add("ƽ����");
            this.comboBox1.Items.Add("˳����");
            this.comboBox1.Items.Add("ͨ����");
            this.comboBox1.Items.Add("������");
            this.comboBox1.SelectedIndex = 0;
            //һ��ָ��
            this.comboBox4.Items.Add("��֯����");
            this.comboBox4.Items.Add("ֱ���ʽ�ؿ�i");
            this.comboBox4.Items.Add("���ڷ�����Ŀ����");
            this.comboBox4.Items.Add("ʵʩЧ������");
            this.comboBox4.SelectedIndex = 3;
            
            //�ļ�ָ��
            this.comboBox7.Items.Add("�˾�����");
            this.comboBox7.Items.Add("�˾�֧��");
            //this.comboBox7.Items.Add("���ڷ�����Ŀ����");
            //this.comboBox7.Items.Add("ʵʩЧ������");


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (comboBox1.Text.ToString())
            {
                case "��ƽ��":
                    this.comboBox2.Items.Clear();
                    this.comboBox2.Items.Add("ʮ������");
                    this.comboBox2.Items.Add("������");
                    this.comboBox2.Items.Add("������");
                    this.comboBox2.Items.Add("�Ǳ��ֵ����´�");
                    //this.comboBox2.SelectedIndex = 0;
                    this.Text="��ƽ��-�������";
                    break;
                case "��ɽ��":
                    this.comboBox2.Items.Clear();
                    this.comboBox2.Items.Add("��������");
                    this.comboBox2.Items.Add("�������");
                    //this.comboBox2.SelectedIndex = 0;
                    this.Text = "��ɽ��-�������";
                    break;
                default: 
                    this.comboBox2.Items.Clear();
                    break;
            }


        }
        /// <summary>
        /// ��������Ĵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text.ToString())
            {       
                    //��ƽ��
                case "ʮ������":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("���´�");
                    this.comboBox3.Items.Add("���´�");
                    this.comboBox3.Items.Add("���Ŵ�");
                    this.comboBox3.Items.Add("��ׯ��");
                    this.comboBox3.Items.Add("�����");
                    this.comboBox3.Items.Add("�����");
                    this.comboBox3.Items.Add("���˶���");
                    //this.comboBox3.SelectedIndex = 0;
                    this.Text = "��ƽ��-ʮ������-�������";
                    break;
                case "������":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("Ӫ����");
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "��ƽ��-������-�������";
                    break;
                case "������":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("�����ڴ�");
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "��ƽ��-������-�������";
                    break;
                case "�Ǳ��ֵ����´�":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("�����ִ�");
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "��ƽ��-�Ǳ��ֵ����´�-�������";
                    break;
                    ///��ɽ��
                case "��������":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("ʯ�ݴ�");
                    this.comboBox3.Items.Add("����λ��");
                    this.comboBox3.Items.Add("����λ��");
                    this.comboBox3.Items.Add("СԷ�ϴ�");
                    this.comboBox3.Items.Add("ˮ����");
                    this.comboBox3.Items.Add("����ͷ��");
                    this.comboBox3.Items.Add("���ׯ��");
                    this.comboBox3.Items.Add("����ׯ��");
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "��ɽ��-��������-�������";
                    break;
                case "�������":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("��ɽ�ڴ�");
                    this.comboBox3.Items.Add("ʥˮ����");
                    this.comboBox3.Items.Add("����Ժ��");
                    this.comboBox3.Items.Add("����Ժ��"); ;
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "��ɽ��-�����-�������";
                    break;
                default:
                    this.comboBox3.Items.Clear();
                    break;
            }
        }
        /// <summary>
        /// ����ָ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {    switch (comboBox4.Text.ToString())
            {
                case "ʵʩЧ������":
                    this.comboBox5.Items.Clear();
                    this.comboBox5.Items.Add("����Ⱥ�ھ���ˮƽ");
                    this.comboBox5.Items.Add("����Ⱥ����������");
                    this.comboBox5.Items.Add("������������������ȶ�");
                    break;
            default:
                this.comboBox5.Items.Clear();
                break;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox5.Text.ToString())
            {
                case "����Ⱥ�ھ���ˮƽ":
                    this.comboBox6.Items.Clear();
                    this.comboBox6.Items.Add("����ˮƽ");
                    this.comboBox6.Items.Add("����ˮƽ");
                    this.comboBox6.Items.Add("�뵱��ƽ��ˮƽ�Ƚ�");
                    break;
                case "����Ⱥ����������":
                    this.comboBox6.Items.Clear();
                    this.comboBox6.Items.Add("��·״��");
                    this.comboBox6.Items.Add("�õ����");
                    this.comboBox6.Items.Add("��ˮ����");
                    this.comboBox6.Items.Add("��ҽ���");
                    break;
                default:
                    this.comboBox6.Items.Clear();
                    break;
            }
        }
    }
}