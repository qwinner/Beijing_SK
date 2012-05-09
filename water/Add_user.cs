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
            this.comboBox1.Items.Add("北京市");
            this.comboBox2.Items.Add("房山区");
            this.comboBox3.Items.Add("青龙湖镇");
            this.comboBox4.Items.Add("青龙头村");
        }
    }
}