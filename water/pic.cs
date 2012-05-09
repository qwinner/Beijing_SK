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
            //九大区县
            this.comboBox1.Items.Add("昌平区");
            this.comboBox1.Items.Add("房山区");
            this.comboBox1.Items.Add(" 怀柔区");
            this.comboBox1.Items.Add("门头沟区");
            this.comboBox1.Items.Add("密云县");
            this.comboBox1.Items.Add("平谷区");
            this.comboBox1.Items.Add("顺义区");
            this.comboBox1.Items.Add("通州区");
            this.comboBox1.Items.Add("延庆县");
            this.comboBox1.SelectedIndex = 0;
            //一级指标
            this.comboBox4.Items.Add("组织管理");
            this.comboBox4.Items.Add("直补资金关咯i");
            this.comboBox4.Items.Add("后期扶持项目管理");
            this.comboBox4.Items.Add("实施效果评估");
            this.comboBox4.SelectedIndex = 3;
            
            //四级指标
            this.comboBox7.Items.Add("人均收入");
            this.comboBox7.Items.Add("人均支出");
            //this.comboBox7.Items.Add("后期扶持项目管理");
            //this.comboBox7.Items.Add("实施效果评估");


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (comboBox1.Text.ToString())
            {
                case "昌平区":
                    this.comboBox2.Items.Clear();
                    this.comboBox2.Items.Add("十三陵镇");
                    this.comboBox2.Items.Add("兴寿镇");
                    this.comboBox2.Items.Add("南邵镇");
                    this.comboBox2.Items.Add("城北街道办事处");
                    //this.comboBox2.SelectedIndex = 0;
                    this.Text="昌平区-分析结果";
                    break;
                case "房山区":
                    this.comboBox2.Items.Clear();
                    this.comboBox2.Items.Add("青龙湖镇");
                    this.comboBox2.Items.Add("韩村河镇");
                    //this.comboBox2.SelectedIndex = 0;
                    this.Text = "房山区-分析结果";
                    break;
                default: 
                    this.comboBox2.Items.Clear();
                    break;
            }


        }
        /// <summary>
        /// 乡镇下面的村
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text.ToString())
            {       
                    //昌平区
                case "十三陵镇":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("南新村");
                    this.comboBox3.Items.Add("北新村");
                    this.comboBox3.Items.Add("大宫门村");
                    this.comboBox3.Items.Add("胡庄村");
                    this.comboBox3.Items.Add("德陵村");
                    this.comboBox3.Items.Add("永陵村");
                    this.comboBox3.Items.Add("仙人洞村");
                    //this.comboBox3.SelectedIndex = 0;
                    this.Text = "昌平区-十三陵镇-分析结果";
                    break;
                case "南邵镇":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("营坊村");
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "昌平区-南邵镇-分析结果";
                    break;
                case "兴寿镇":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("桃峪口村");
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "昌平区-兴寿镇-分析结果";
                    break;
                case "城北街道办事处":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("朝凤庵村");
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "昌平区-城北街道办事处-分析结果";
                    break;
                    ///房山区
                case "青龙湖镇":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("石梯村");
                    this.comboBox3.Items.Add("北四位村");
                    this.comboBox3.Items.Add("南四位村");
                    this.comboBox3.Items.Add("小苑上村");
                    this.comboBox3.Items.Add("水峪村");
                    this.comboBox3.Items.Add("青龙头村");
                    this.comboBox3.Items.Add("崇各庄村");
                    this.comboBox3.Items.Add("焦各庄村");
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "房山区-青龙湖镇-分析结果";
                    break;
                case "韩村河镇":
                    this.comboBox3.Items.Clear();
                    this.comboBox3.Items.Add("孤山口村");
                    this.comboBox3.Items.Add("圣水峪村");
                    this.comboBox3.Items.Add("上中院村");
                    this.comboBox3.Items.Add("下中院村"); ;
                    this.comboBox3.SelectedIndex = 0;
                    this.Text = "房山区-韩村河-分析结果";
                    break;
                default:
                    this.comboBox3.Items.Clear();
                    break;
            }
        }
        /// <summary>
        /// 二级指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {    switch (comboBox4.Text.ToString())
            {
                case "实施效果评估":
                    this.comboBox5.Items.Clear();
                    this.comboBox5.Items.Add("移民群众经济水平");
                    this.comboBox5.Items.Add("移民群众生产生活");
                    this.comboBox5.Items.Add("库区和移民安置区社会稳定");
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
                case "移民群众经济水平":
                    this.comboBox6.Items.Clear();
                    this.comboBox6.Items.Add("收入水平");
                    this.comboBox6.Items.Add("消费水平");
                    this.comboBox6.Items.Add("与当地平均水平比较");
                    break;
                case "移民群众生产生活":
                    this.comboBox6.Items.Clear();
                    this.comboBox6.Items.Add("道路状况");
                    this.comboBox6.Items.Add("用电情况");
                    this.comboBox6.Items.Add("饮水条件");
                    this.comboBox6.Items.Add("就医情况");
                    break;
                default:
                    this.comboBox6.Items.Clear();
                    break;
            }
        }
    }
}