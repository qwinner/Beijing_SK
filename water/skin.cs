using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace water
{
    public partial class skin : Form
    {
        private string selected = global.skin_name;
        private int firsttime = 0;
        private int defskin = 0;
        public skin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (global.skin_name != selected)
            {
                if (string.IsNullOrEmpty(global.skin_name))
                {
                    global.myskin.Active = false;
                }
                else
                {
                    try
                    {
                        global.myskin.SkinFile = "Skin\\" + this.comboBox1.Text;
                    }
                    catch
                    {
                        global.myskin.Active = false;
                        MessageBox.Show("load skin file error!");
                    }
                }
            }
            this.Close();
        }

        private void skin_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo("Skin");
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                this.comboBox1.Items.Add(file.Name);
            }
            this.comboBox1.Items.Add("默认");
            if (string.IsNullOrEmpty(selected))
            {
                comboBox1.Text = "默认";
            }
            else
            {
                comboBox1.Text = selected;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firsttime == 0 && !string.IsNullOrEmpty(selected))
            {
            }
            else
            {
                if (comboBox1.Text == "默认")
                {
                    global.myskin.Active = false;
                    selected = "";
                    defskin = 1;
                }
                else
                {
                    global.myskin.Active = true;
                    global.myskin.SkinFile = "Skin\\" + this.comboBox1.Text;
                    selected = comboBox1.Text;
                }
            }
            firsttime = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            global.myskin.Active = false;
            selected = "";
            comboBox1.SelectedItem = "默认";
            defskin = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = global.AppPath + @"\Myconfig.ini";
            global.WritePrivateProfileString("SKIN", "skin", selected, path);
            if (defskin == 1)
            {
                global.myskin.Active = true;
            }
            global.skin_name = selected;
            MessageBox.Show("保存成功！");
        }
    }
}