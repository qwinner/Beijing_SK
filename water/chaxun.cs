using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace water
{
    public partial class chaxun : Form
    {
        public chaxun()
        {
            InitializeComponent();
        }

        private void chaxun_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("��ƽ��");
            this.comboBox1.Items.Add("��ɽ��");
            this.comboBox1.Items.Add("��ͷ����");
            this.comboBox1.Items.Add("ͨ����");

           

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox2.Items.Add("��������");
            //this.comboBox2.Items.Add("������");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.comboBox3.Items.Add("�����");
           // this.comboBox3.Items.Add("�����");
            this.comboBox3.Items.Add("����ͷ��");

        }


        

        
       




    }
}