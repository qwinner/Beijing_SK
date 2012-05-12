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
            //一级指标
            this.comboBox4.Items.Add("组织管理");
            this.comboBox4.Items.Add("直补资金管理");
            this.comboBox4.Items.Add("后期扶持项目管理");
            this.comboBox4.Items.Add("实施效果评估");
            this.comboBox4.SelectedIndex = 3;
            //二级指标
            this.comboBox5.Items.Add("管理机构能力建设");
            this.comboBox5.Items.Add("建设管理");
            //三级指标
            this.comboBox6.Items.Add("移民管理机构建设");
            this.comboBox6.Items.Add("计划管理");
            //四级指标
            this.comboBox7.Items.Add("项目验收");
            this.comboBox7.Items.Add("是否成立领导小组");

            this.comboBox4.Items.Add("实施效果评估");
            //this.comboBox4.SelectedIndex = 3;
            ////区县
            //this.comboBox3.Items.Add("房山区");
            ////乡镇
            //this.comboBox2.Items.Add("青龙湖镇");






        }
    }
}