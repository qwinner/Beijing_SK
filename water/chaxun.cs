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
            this.comboBox1.Items.Add("昌平区");
            this.comboBox1.Items.Add("房山区");
            this.comboBox1.Items.Add("门头沟区");
            this.comboBox1.Items.Add("通州区");

           

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox2.Items.Add("青龙湖镇");
            //this.comboBox2.Items.Add("兴寿镇");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.comboBox3.Items.Add("德陵村");
           // this.comboBox3.Items.Add("永陵村");
            this.comboBox3.Items.Add("青龙头村");

        }


        

        
       




    }
}