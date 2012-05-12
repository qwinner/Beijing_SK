using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace water
{
    public partial class ahp_1 : Form
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
        public ahp_1()
        {
            InitializeComponent();
            
        }
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
            int x = this.groupBox1.Location.X + 40;//WYQ=10
            int y = this.groupBox1.Location.Y + 60;//WYQ=40
            for (int i = 0; i < len; i++)//���ɱ�ǩ
            {
                Label mylabel = new Label();
                mylabel.Text = str[i].ToString();
                mylabel.Location = new Point(x + i * 90, y - 20);//60---40
                mylabel.AutoSize = true;
                this.groupBox1.Controls.Add(mylabel);
            }
            for (int i = 0; i < len; i++)//�����ı���
            {
                for (int j = 0; j < len; j++)
                {
                    mytextbox = new TextBox();
                    mytextbox.Size = new System.Drawing.Size(90, 20);//60---20
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
                    x += 90;////60
                }
                x = this.groupBox1.Location.X + 40;//10
                y += 20;////
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

        /// <summary>
        /// ���ݲ����Ĳ�ͬ���в�ͬ���㷨
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (this.button1.Text == "������")
            {
                this.vieworder();
                return;
            }
            if (this.Stepcount == 0)
            {
                this.InitValue();
                this.Initextbox(this.LenA, this.zhuze);
                this.Stepcount++;
                return;
            }
            if (this.Stepcount == 1)
            {
                foreach (Control tempC in this.groupBox1.Controls)//¼������
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
                                this.zhuzematrix[i, j] = Convert.ToDouble(tempstr.Substring(0, 1)) / Convert.ToDouble(tempstr.Substring(tempstr.Length - 1, 1));
                            }
                            else
                                this.zhuzematrix[i, j] = Convert.ToDouble(tempstr);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }//foreach
                //�����
                for (int i = 0; i < LenA; i++)
                    this.W[i] = 1;
                for (int j = 0; j < LenA; j++)
                {
                    for (int i = 0; i < LenA; i++)
                        this.W[j] *= this.zhuzematrix[j, i];
                    //
                    //W[j]=Math.Pow(W[j],1/LenA);
                    W[j] = Math.Exp(Math.Log(W[j]) / LenA);
                }
                double Tt = 0;
                for (int i = 0; i < LenA; i++)
                    Tt += W[i];
                for (int i = 0; i < LenA; i++)
                    W[i] = W[i] / Tt;
                this.lamda = 0;
                for (int j = 0; j < LenA; j++)
                {
                    for (int i = 0; i < LenA; i++)
                        this.lamda += this.zhuzematrix[j, i] * W[i] / W[j];
                }
                this.lamda /= LenA;
                //MessageBox.Show(this.lamda.ToString());
                if (((this.lamda - LenA) / (LenA - 1)) > RI[LenA] * 0.1)
                {
                    MessageBox.Show("������һ���ԣ�");
                    return;
                }
                this.Initextbox(this.LenB, this.fangan);
                //this.mytextboxclear();
                this.label5.Text = "�����뷽�������׼��� " + this.zhuze[Stepcount - 1] + " ���б����";
                this.Stepcount++;
                if (this.Stepcount == this.LenA + 2)
                {
                    this.button1.Enabled = false;
                    this.button2.Visible = false;
                }
                return;
            }//�����Ե�һ��1�����⴦��

            foreach (Control tempC in this.groupBox1.Controls)//¼������
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
                            this.fanganmatrix[this.Stepcount - 2][i, j] = Convert.ToDouble(tempstr.Substring(0, 1)) / Convert.ToDouble(tempstr.Substring(tempstr.Length - 1, 1));
                        }
                        else
                            this.fanganmatrix[this.Stepcount - 2][i, j] = Convert.ToDouble(tempstr);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }//foreach
            //�����[stepcount]
            int k = this.Stepcount - 2;
            if (k + 1 == this.LenA)
                this.label5.Text = "������!";
            else
                this.label5.Text = "�����뷽�������׼��� " + this.zhuze[k + 1] + " ���б����";
            for (int i = 0; i < LenB; i++)
                this.TW[k, i] = 1;
            for (int j = 0; j < LenB; j++)
            {
                for (int i = 0; i < LenB; i++)
                    this.TW[k, j] *= this.fanganmatrix[k][j, i];
                //TW[k,j]=Math.Pow(TW[k,j],1/LenB);
                TW[k, j] = Math.Exp(Math.Log(TW[k, j]) / LenB);
            }
            double Ttt = 0;
            for (int i = 0; i < LenB; i++)
                Ttt += TW[k, i];
            for (int i = 0; i < LenB; i++)
                TW[k, i] = TW[k, i] / Ttt;
            this.Tlamda[k] = 0;
            for (int j = 0; j < LenB; j++)
            {
                for (int i = 0; i < LenB; i++)
                    this.Tlamda[k] += this.fanganmatrix[k][j, i] * TW[k, i] / TW[k, j];
            }
            this.Tlamda[k] /= LenB;
            //MessageBox.Show(this.Tlamda[k].ToString());
            if (((this.Tlamda[k] - LenB) / (LenB - 1)) > RI[LenB])
            {
                MessageBox.Show("������һ���ԣ�");
                return;
            }
            //this.Initextbox(this.LenB,this.fangan);
            this.mytextboxclear();
            this.Stepcount++;
            if (this.Stepcount == this.LenA + 2)
            {
                this.button1.Text = "������";
                this.groupBox1.Controls.Clear();
                //this.button2.Visible = false;
            }


        }
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            switch (this.Stepcount)
            {
                case 0:
                    this.textBox1.Text = "����ˮƽ,����ˮƽ,��ĿʵʩЧ��,��������,����ȶ���";
                    this.textBox2.Text = "��ƽ,��ɽ,����";
                    break;
                case 1:
                    string[,] temparr = { { "1", "2", "7", "5", "5" }, { "1/2", "1", "4", "3", "3" }, { "1/7", "1/4", "1", "1/2", "1/3" }, { "1/5", "1/3", "2", "1", "1" }, { "1/5", "1/3", "3", "1", "1" } };
                    foreach (Control tempC in this.groupBox1.Controls)
                    {
                        try
                        {
                            if (tempC is TextBox)
                            {
                                string tempstr = tempC.Text.ToString().Trim();
                                int i = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 2, 1));
                                int j = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 1, 1));
                                tempC.Text = temparr[i, j];
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                    }
                    break;
                case 2:
                    string[,] temparr1 = { { "1", "1/5", "1/8" }, { "5", "1", "1/3" }, { "8", "3", "1" } };
                    foreach (Control tempC in this.groupBox1.Controls)
                    {
                        try
                        {
                            if (tempC is TextBox)
                            {
                                string tempstr = tempC.Text.ToString().Trim();
                                int i = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 2, 1));
                                int j = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 1, 1));
                                tempC.Text = temparr1[i, j];
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                    }
                    break;
                case 3:
                    string[,] temparr2 = { { "1", "2", "5" }, { "1/2", "1", "2" }, { "1/5", "1/2", "1" } };
                    foreach (Control tempC in this.groupBox1.Controls)
                    {
                        try
                        {
                            if (tempC is TextBox)
                            {
                                string tempstr = tempC.Text.ToString().Trim();
                                int i = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 2, 1));
                                int j = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 1, 1));
                                tempC.Text = temparr2[i, j];
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                    }
                    break;
                case 4:
                    string[,] temparr3 = { { "1", "1", "3" }, { "1", "1", "3" }, { "1/3", "1/3", "1" } };
                    foreach (Control tempC in this.groupBox1.Controls)
                    {
                        try
                        {
                            if (tempC is TextBox)
                            {
                                string tempstr = tempC.Text.ToString().Trim();
                                int i = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 2, 1));
                                int j = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 1, 1));
                                tempC.Text = temparr3[i, j];
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                    }
                    break;
                case 5:
                    string[,] temparr4 = { { "1", "3", "4" }, { "1/3", "1", "1" }, { "1/4", "1", "1" } };
                    foreach (Control tempC in this.groupBox1.Controls)
                    {
                        try
                        {
                            if (tempC is TextBox)
                            {
                                string tempstr = tempC.Text.ToString().Trim();
                                int i = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 2, 1));
                                int j = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 1, 1));
                                tempC.Text = temparr4[i, j];
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                    }
                    break;
                case 6:
                    string[,] temparr5 = { { "1", "1", "1/4" }, { "1", "1", "1/4" }, { "4", "4", "1" } };
                    foreach (Control tempC in this.groupBox1.Controls)
                    {
                        try
                        {
                            if (tempC is TextBox)
                            {
                                string tempstr = tempC.Text.ToString().Trim();
                                int i = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 2, 1));
                                int j = Convert.ToInt32(tempC.Name.ToString().Substring(tempC.Name.ToString().Length - 1, 1));
                                tempC.Text = temparr5[i, j];
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                    }
                    break;
                default:
                    break;
            }
        }





    }
}