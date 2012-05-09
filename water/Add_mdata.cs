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
            //一级指标
            this.comboBox4.Items.Add("组织管理");
            this.comboBox4.Items.Add("直补资金管理");
            this.comboBox4.Items.Add("后期扶持项目管理");
            this.comboBox4.Items.Add("实施效果评估");
            this.comboBox4.SelectedIndex = 0;
            //二级指标
            this.comboBox5.Items.Add("机构能力建设");
            this.comboBox5.Items.Add("统计管理");
            this.comboBox5.SelectedIndex = 0;
            //三级指标
            this.comboBox6.Items.Add("基础设施项目");
            this.comboBox6.Items.Add("配套政策及规章制度制定");
            this.comboBox6.SelectedIndex = 0;
            ////区县
            //this.comboBox7.Items.Add("房山区");
            //this.comboBox7.Items.Add("昌平区");
            //this.comboBox7.SelectedIndex = 0;
            ////乡镇
            //this.comboBox8.Items.Add("十三陵镇");
            //this.comboBox8.Items.Add("青龙湖镇");
            //this.comboBox8.SelectedIndex = 0;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (comboBox4.Text.ToString())
            //{
            //    case "实施效果评估":
            //        this.comboBox5.Items.Clear();
            //        this.comboBox5.Items.Add("移民群众经济水平");
            //        this.comboBox5.Items.Add("移民群众生产生活");
            //        this.comboBox5.Items.Add("库区和移民安置区社会稳定");
            //        break;
            //    default:
            //        this.comboBox5.Items.Clear();
            //        break;
            //}
        }
    }
}