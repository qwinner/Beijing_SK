using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;

namespace water
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        
        //˫��listview����ݵ�ǰ��ִ�в���
        private void lsvFun_DoubleClick(object sender, System.EventArgs e)
        {
            //˫����ִ��һ������
            ListView lsv = sender as ListView;
            if (lsv == null)
                return;
            if (lsv.SelectedItems.Count == 0)
                return;
            ListViewItem item = lsv.SelectedItems[0];
           // MessageBox.Show("��˫���ˣ�" + item.Text);
            if ("A�ʾ�" == item.Text)
            {
                pro_a UM = new pro_a();
                UM.Owner = this;
                UM.Show();
            };
            if ("����Ч��"==item.Text)
            {
                Emt emt = new Emt();
                emt.Owner = this;
                emt.Show();
            };

        }

        #region ������Ч
        /// <summary>
        /// ��¼��ǰ��������еİ�ť
        /// </summary>
        private ArrayList ArrFunButton = new ArrayList();

        /// <summary>
        /// ��¼��ǰ��������е�listview
        /// </summary>
        private ArrayList ArrFunListView = new ArrayList();
        /// <summary>
        /// �������Ŀ��
        /// </summary>
        private int m_nPanFunWidth = 225;
        private int m_nPanFunHeight = 40;//wyq

        //���ܰ�ť��������Ч
        private void btnFun_Click(object sender, System.EventArgs e)
        {
            Button btnNow = sender as Button;
            if (btnNow == null)
                return;

            //�����İ�ť�������е�����
            int nIndex = this.ArrFunButton.IndexOf(btnNow);
            //���ð�ťǰ����ö�
            for (int i = 1; i <= nIndex; i++)
            {
                Button btn = ArrFunButton[i] as Button;
                btn.Top = ((Button)ArrFunButton[i - 1]).Bottom;
                btn.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            }
            //������İ�ť����
            for (int i = ArrFunButton.Count - 1; i > nIndex; i--)
            {
                Button btn = ArrFunButton[i] as Button;
                if (i == ArrFunButton.Count - 1)//���һ��
                    btn.Top = this.panFunMain.Height - btn.Height - 4;
                else
                    btn.Top = ((Button)ArrFunButton[i + 1]).Top - btn.Height;
                btn.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;

            }

            //��ʾ��Ӧ��listview
            for (int i = 0; i < ArrFunButton.Count; i++)
            {
                ListView lsv = ArrFunListView[i] as ListView;
                //��ǰ��ť��Ӧ��ListView
                if (i == nIndex)
                {
                    lsv.Left = 0;
                    lsv.Width = btnNow.Width;
                    lsv.Top = btnNow.Bottom;

                    if (nIndex == ArrFunListView.Count - 1)//���һ��
                        lsv.Height = this.panFunMain.Height - btnNow.Bottom - 4;
                    else
                        lsv.Height = (ArrFunButton[i + 1] as Button).Top - btnNow.Bottom;
                    //����ǰListView��ʾ����
                    if (!lsv.Visible)
                        lsv.Visible = true;
                }
                else //��������listview
                {
                    if (lsv.Visible)
                        lsv.Visible = false;
                }
            }

        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        private void InitPanFun()
        {
            //���ù�������λ�úͿ��
            this.panFunMain.Width = m_nPanFunWidth;
            this.panFunMain.Height = m_nPanFunHeight;
            this.panFunMain.Dock = DockStyle.Left;
            //��¼���ܰ�ť
            ArrFunButton.Add(this.button1);
            ArrFunButton.Add(this.button2);
            ArrFunButton.Add(this.button4);
            ArrFunButton.Add(this.button5);
            ArrFunButton.Add(this.button3);

            //��¼��������е�listview,ע��Ҫ�������button��Ӧ
            ArrFunListView.Add(this.listView1);
            ArrFunListView.Add(this.listView2);
            ArrFunListView.Add(this.listView3);
            ArrFunListView.Add(this.listView4);
            ArrFunListView.Add(this.listView5);

            int nCount = ArrFunButton.Count;
            //���ø����ܰ�ť��λ�ú�ListView������
            for (int i = nCount - 1; i >= 0; i--)
            {
                Button btn = ArrFunButton[i] as Button;
                btn.Width = this.panFunMain.Width - 4;
                btn.Left = 0;

                //����ť�ĵ����¼��;�������Ӧ����
                btn.Click += new System.EventHandler(btnFun_Click);
                if (i == 0)
                {
                    btn.Top = 0;
                    btn.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                }
                else
                {
                    if (i == nCount - 1)
                        btn.Top = this.panFunMain.Height - btn.Height - 4;
                    else
                        btn.Top = (ArrFunButton[i + 1] as Button).Top - btn.Height;
                    btn.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                }
                //����listview��anchor����
                ListView lsv = ArrFunListView[i] as ListView;
                if (lsv != null)
                {
                    lsv.Anchor = AnchorStyles.Left | AnchorStyles.Top |
                        AnchorStyles.Right | AnchorStyles.Bottom;
                    //����listview˫���¼�
                    lsv.DoubleClick += new EventHandler(lsvFun_DoubleClick);

                }//pan
                (ArrFunButton[0] as Button).PerformClick();
            }
        }

        #endregion


        //private void pifu( ) 
        //{
        //    this.skinEngine1.SkinFile = "DeepCyan.ssk";
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitPanFun();
            global.myskin = skinEngine1;         
            if (!string.IsNullOrEmpty(global.skin_name))
            {
                try
                {
                    global.myskin.SkinFile = global.AppPath + "\\Skin\\" + global.skin_name;
                }
                catch
                {
                    global.myskin.Active = false;
                }
            }

        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// ���ص������Ͻǹرհ�ť�¼�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// ��ѯ��ť����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            chaxun UM = new chaxun();
            //UM.Owner = this;
            UM.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pic UM = new pic();
            //UM.Owner = this;
            UM.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
           Emt UM = new Emt();
            //UM.Owner = this;
            UM.Show();
        }


        private void �л�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            skin sk = new skin();
            sk.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ceshi jj = new ceshi();
            jj.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Add_mdata dt = new Add_mdata();
            dt.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            pj_zc pj = new pj_zc();
            pj.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Config_Form cf = new Config_Form();
            cf.Show();
        }

        private void a��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pro_ceshi1 ce2 = new pro_ceshi1();
            ce2.Show();
        }

        private void ��������ۺ����۲���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pj_ces2 pjc = new pj_ces2();
            pjc.Show();
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            button6.BackgroundImage = imageList3.Images[0];
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackgroundImage = imageList3.Images[2];
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.BackgroundImage= imageList3.Images[1];
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            button6.BackgroundImage = imageList3.Images[0];
        }

        private void �û�����ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserManage um = new UserManage();
            um.Show();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config_Form cf = new Config_Form();
            cf.Show();
        }

    }
}