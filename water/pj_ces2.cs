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
            //区县
            this.comboBox1.Items.Add("昌平区");
            this.comboBox1.Items.Add("房山区");
            this.comboBox1.Items.Add("通州区");
            this.comboBox1.Items.Add("密云县");
            this.comboBox1.SelectedIndex = 0;
            //乡镇
            this.comboBox2.Items.Add("青龙湖镇");
            this.comboBox2.Items.Add("十三陵镇");
            //this.comboBox2.SelectedIndex = 0;
            //村
            this.comboBox3.Items.Add("青龙头村");
            this.comboBox3.Items.Add("长陵村");
            //this.comboBox3.SelectedIndex = 0;
        }
    }
}