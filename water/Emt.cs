using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace water
{
    public partial class Emt : Form
    {
        private Random rd = new Random((int)DateTime.Now.Ticks);
        private int[] data = new int[20];
        private int mystyle=0;
        
        public Emt()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                data[i] = Convert.ToInt32(rd.Next(100).ToString());
            }
        }

        private void Emt_Load(object sender, EventArgs e)
        {
            tChart1.Header.Text = "µ÷²éÎÊ¾íA";
            Steema.TeeChart.Styles.Line line1 = new Steema.TeeChart.Styles.Line();
            line1.Add(data);
            tChart1.Series.Add(line1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mystyle++;
            tChart1.Series.Clear();
            switch (mystyle)
            {
                case 1:
                    Steema.TeeChart.Styles.Area area = new Steema.TeeChart.Styles.Area();
                    area.Add(data);
                    tChart1.Series.Add(area);
                    break;
                case 2:
                    Steema.TeeChart.Styles.Arrow arrow= new Steema.TeeChart.Styles.Arrow();
                    arrow.Add(data);
                    tChart1.Series.Add(arrow);
                    break;
                case 3:
                    Steema.TeeChart.Styles.Bar Bar = new Steema.TeeChart.Styles.Bar();
                    Bar.Add(data);
                    tChart1.Series.Add(Bar);
                    break;
                case 4:
                    Steema.TeeChart.Styles.Bar3D Bar3D = new Steema.TeeChart.Styles.Bar3D();
                    Bar3D.Add(data);
                    tChart1.Series.Add(Bar3D);
                    break;
                case 5:
                    Steema.TeeChart.Styles.BarJoin BarJoin = new Steema.TeeChart.Styles.BarJoin();
                    BarJoin.Add(data);
                    tChart1.Series.Add(BarJoin);
                    break;
                case 6:
                    Steema.TeeChart.Styles.Bezier Bezier = new Steema.TeeChart.Styles.Bezier();
                    Bezier.Add(data);
                    tChart1.Series.Add(Bezier);
                    break;
            }
            if (mystyle > 10)
                mystyle = 0;
        }
    }
}