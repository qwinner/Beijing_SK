using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace water
{
    class ahp
    {
        private static double[] RI = { 0, 0, 0, 0.58, 0.90, 1.12, 1.24, 1.32, 1.41, 1.45 };
        private Int32 LenA;//׼����
        private System.Int32 LenB;//������
        private double[,] zhuzematrix;//׼��������//wyw
        private double[][,] fanganmatrix;//������//wyq
        private string[] zhuze;//׼���ַ���
        private string[] fangan;//�����ַ���
        private int Stepcount = 0;//¼�����Ĳ���
        private double[] W;//����w
        private double[,] TW;//����w
        private double[] Torder;//�ܵķ�������
        private double lamda;//�������lamda
        private double[] Tlamda;//����lamda

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;


        //��ʼ������
        private void InitValue()//
        {
            //¼��׼���ַ���
            this.zhuze = this.textBox1.Text.ToString().Trim().Split(',');
            this.fangan = this.textBox2.Text.ToString().Trim().Split(',');
            this.LenA = zhuze.Length;
            this.LenB = fangan.Length;
            if (this.LenA != 5 || this.LenB != 3) this.button2.Visible = false;
            //==ʵ����������
            this.zhuzematrix = new double[this.LenA, this.LenA];
            this.fanganmatrix = new double[this.LenA][,];
            for (int i = 0; i < LenA; i++)
                this.fanganmatrix[i] = new double[LenB, LenB];
            this.W = new double[LenA];
            this.TW = new double[LenA, LenB];
            this.Torder = new double[LenB];
            this.Tlamda = new double[LenA];
            //==
            this.groupBox1.Controls.Clear();
            this.label5.Text = "������׼������Ŀ����б����";
        }

        //��ʼ���ı���
        private void Initextbox(int len, string[] str)
        {
            this.groupBox1.Controls.Clear();//��ղ��õĿؼ�
            TextBox mytextbox;//�����ı���
            int x = this.groupBox1.Location.X + 10;//WYQ=10
            int y = this.groupBox1.Location.Y + 40;//WYQ=40
            for (int i = 0; i < len; i++)//���ɱ�ǩ
            {
                Label mylabel = new Label();
                mylabel.Text = str[i].ToString();
                mylabel.Location = new Point(x + i * 60, y - 40);
                mylabel.AutoSize = true;
                this.groupBox1.Controls.Add(mylabel);
            }
            for (int i = 0; i < len; i++)//�����ı���
            {
                for (int j = 0; j < len; j++)
                {
                    mytextbox = new TextBox();
                    mytextbox.Size = new System.Drawing.Size(60, 20);
                    mytextbox.BackColor = Color.LightGoldenrodYellow;
                    mytextbox.Name = "mytextbox" + i + j;
                    mytextbox.Leave += new System.EventHandler(this.textBox_mouseover);
                    mytextbox.Location = new Point(x, y);
                    if (i == j)
                    {
                        mytextbox.BackColor = Color.Wheat;
                        mytextbox.Text = "1";
                        mytextbox.Enabled = false;
                    }
                    if (i < j)
                    {
                        mytextbox.BackColor = SystemColors.ActiveBorder;
                        mytextbox.Enabled = false;
                    }
                    this.groupBox1.Controls.Add(mytextbox);
                    x += 60;
                }
                x = this.groupBox1.Location.X + 10;
                y += 20;
            }
        }
        //�����ı���
        private void textBox_mouseover(object sender, System.EventArgs e)
        {
            TextBox temptextbox = (TextBox)sender;
            string tempstr = temptextbox.Name.ToString();
            if (temptextbox.Text.Trim() == "")
            {
                //    MessageBox.Show("û����������");
                //    temptextbox.Focus();
            }
            else
            {
                string i = tempstr.Substring(tempstr.Length - 2, 1);
                string j = tempstr.Substring(tempstr.Length - 1, 1);
                foreach (Control tempC in this.groupBox1.Controls)
                {
                    if (tempC is TextBox)
                    {
                        if (tempC.Name.ToString() == "mytextbox" + j + i)
                        {
                            if (temptextbox.Text.ToString().Trim().IndexOf("/") > 0)
                                tempC.Text = temptextbox.Text.ToString().Substring(temptextbox.Text.ToString().Trim().Length - 1, 1);
                            else if (temptextbox.Text.ToString().Trim() == "1")
                                tempC.Text = "1";
                            else
                                tempC.Text = "1/" + temptextbox.Text;
                        }
                    }
                }
            }
        }//textBox_mouseover

        //
        private void mytextboxclear()
        {
            foreach (Control tempC in this.groupBox1.Controls)
            {
                if (tempC is TextBox)
                {
                    string tempstr = tempC.Text.ToString().Trim();
                    int i = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 2, 1));
                    int j = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 1, 1));
                    if (i == j) tempC.Text = "1";
                    else tempC.Text = "";
                }
            }
        }


        private void vieworder()
        {
            int i, j;
            int[] temp = new int[this.LenA];
            for (i = 0; i < this.LenA; i++)
                temp[i] = i;
            for (i = 0; i < this.LenA; i++)
                for (j = i + 1; j < this.LenA; j++)
                    if (this.W[temp[i]] < this.W[temp[j]])
                    { int t = temp[i]; temp[i] = temp[j]; temp[j] = t; }
            string str = "";
            for (i = 0; i < this.LenA; i++)
            //str+=this.zhuze[temp[i]].ToString()+"��"+this.W[temp[i]].ToString();
            {
                Label templabel = new Label();
                templabel.Text = this.zhuze[temp[i]].ToString() + "��" + this.W[temp[i]].ToString();
                templabel.Location = new Point(this.groupBox1.Location.X + 10, this.groupBox1.Location.Y + i * 20 + 40);
                templabel.AutoSize = true;
                this.groupBox1.Controls.Add(templabel);//END ����������
            }
            //Label templabel = new Label();
            //templabel.Text = str;
            //templabel.Location = new Point(this.groupBox1.Location.X+10,this.groupBox1.Location.Y+40);
            //templabel.AutoSize = true;
            //templabel.Width = 20*LenA;
            //this.groupBox1.Controls.Add(templabel);//END ����������

            for (j = 0; j < LenB; j++)
                for (i = 0; i < LenA; i++)
                    Torder[j] += W[i] * TW[i, j];
            int[] Ttemp = new int[this.LenB];
            for (i = 0; i < this.LenB; i++)
                Ttemp[i] = i;
            for (i = 0; i < this.LenB; i++)
                for (j = i + 1; j < this.LenB; j++)
                    if (this.Torder[Ttemp[i]] < this.Torder[Ttemp[j]])
                    { int t = Ttemp[i]; Ttemp[i] = Ttemp[j]; Ttemp[j] = t; }
            str = "";
            for (i = 0; i < this.LenB; i++)
                str += this.fangan[Ttemp[i]].ToString() + "��" + this.Torder[Ttemp[i]].ToString() + "\t";
            Label templabel2 = new Label();
            templabel2.Text = str;
            templabel2.Location = new Point(this.groupBox1.Location.X + 10, this.groupBox1.Location.Y + 20 * LenA + 80);
            templabel2.AutoSize = true;
            this.groupBox1.Controls.Add(templabel2);//END ������������
        }
        private void getdata(double[,] matrix)
        {
            foreach (Control tempC in this.groupBox1.Controls)
            {
                try
                {
                    if (tempC is TextBox)
                    {
                        string tempstr = tempC.Text.ToString().Trim();
                        if (tempstr == "")
                        {
                            MessageBox.Show("���ı���û�������ݣ�");
                            return;
                        }
                        int i = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 2, 1));
                        int j = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 1, 1));
                        if (tempstr.IndexOf("/") > 0)
                        {
                            matrix[i, j] = Convert.ToDouble(tempstr.Substring(0, 1)) / Convert.ToDouble(tempstr.Substring(tempstr.Length - 1, 1));
                        }
                        else
                            matrix[i, j] = Convert.ToDouble(tempstr);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }







    }
}
