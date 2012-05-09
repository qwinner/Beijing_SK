using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace water
{
    public partial class splash : Form
    {
        private static splash sp = new splash();
        private int databaseconnected;
        private int configreaded;
        public static splash NewForm  //窗体间互访(子窗体)
        {
            get
            {
                if (sp == null || sp.IsDisposed)
                {
                    sp = new splash();
                }
                return sp;
            }
        }
        public splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                Opacity += 0.5;
            }
            else
            {
                timer2.Start();
                timer3.Start();
            }
        }

        private void splash_Load(object sender, EventArgs e)
        {
            global.AppPath = Application.StartupPath;
            StringBuilder temp = new StringBuilder(255);
            string path = global.AppPath + @"\Myconfig.ini";
            try
            {
                global.GetPrivateProfileString("SKIN", "skin", "error", temp, 255, path);
                global.skin_name = temp.ToString();
                global.GetPrivateProfileString("MyConnectionStr", "sqlstr", "error", temp, 255, path);//读取数据库连接字符串
                global.sqlconstr = temp.ToString();
                global.GetPrivateProfileString("MyConnectionStr", "style", "error", temp, 255, path);//读取数据库连接字符串
                global.sqlstrstyle = Convert.ToInt32(temp.ToString());
                configreaded = 1;
            }
            catch
            {
                configreaded = 0;
            }
            if (configreaded == 1)
            {
                SqlConnection sqlcon = new SqlConnection(global.sqlconstr);
                try
                {
                    sqlcon.Open();
                    sqlcon.Close();
                    databaseconnected = 1;
                }
                catch
                {
                    databaseconnected = 0;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            string info="";
            if (Convert.ToInt32(LabFlash.Tag) == 0)
            {
                info = "正在加载应用程序...";
            }
            else if (Convert.ToInt32(LabFlash.Tag) == 1)
            {
                info = "读取Windows系统信息...";
            }
            else if (Convert.ToInt32(LabFlash.Tag) == 2)
            {
                info = "正在获得 Microsoft Visual Studio 实例...";
            }
            else if (Convert.ToInt32(LabFlash.Tag) == 3)
            {
                info = "控件类与对像集合重载...";
            }
            else if (Convert.ToInt32(LabFlash.Tag) == 4)
            {
                info = "正在加载 Microsoft .NET Framework 组件...";
            }
            else if (Convert.ToInt32(LabFlash.Tag) > 4 && Convert.ToInt32(LabFlash.Tag) < 8)
            {
                info = "正在创建数据库连接...";
            }
            else if (Convert.ToInt32(LabFlash.Tag) < 12)
            {
                if (configreaded == 0)
                {
                    info = "配置信息加载失败...";
                }
                else
                {
                    if (databaseconnected == 1)
                    {
                        info = "加载完成...";
                    }
                    else
                    {
                        info = "无法建立数据库连接,程序即将关闭...";
                    }
                }
            }
            else
            {
                if (databaseconnected == 0|| configreaded == 0)
                {
                    Application.Exit();
                }
                timer2.Stop();
            }
            LabFlash.Text = info;
            LabFlash.Tag = Convert.ToString(Convert.ToInt32(LabFlash.Tag) + 1);
        }

        void flash(PictureBox pictureBoxN, Timer t, Timer tp)
        {
            pictureBoxN.Visible = true;
            if (Convert.ToInt32(pictureBoxN.Tag) == 1)
            {
                pictureBoxN.Image = pictureBox2.Image;
            }
            else if (Convert.ToInt32(pictureBoxN.Tag) == 2)
            {
                pictureBoxN.Image = pictureBox3.Image;
            }
            else if (Convert.ToInt32(pictureBoxN.Tag) == 3)
            {
                pictureBoxN.Image = pictureBox4.Image;
            }
            else if (Convert.ToInt32(pictureBoxN.Tag) == 6)
            {
                pictureBoxN.Image = pictureBox3.Image;
            }
            else if (Convert.ToInt32(pictureBoxN.Tag) == 7)
            {
                pictureBoxN.Image = pictureBox2.Image;
                t.Start();
            }
            else if (Convert.ToInt32(pictureBoxN.Tag) >= 8)
            {
                pictureBoxN.Visible = false;
                pictureBoxN.Tag = 0;
                tp.Stop();
            }
            pictureBoxN.Tag = Convert.ToString(Convert.ToInt32(pictureBoxN.Tag) + 1);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            flash(pictureBox5, timer4, timer3);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            flash(pictureBox6, timer5, timer4); 
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            flash(pictureBox7, timer6, timer5); 
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            flash(pictureBox8, timer7, timer6); 
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            flash(pictureBox9, timer8, timer7);
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            flash(pictureBox10, timer9, timer8);
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                Opacity -= 0.5;
            }
            else
            {
                this.Close();
            }
        }
        
    }
}