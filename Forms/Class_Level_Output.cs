using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class Class_Level_Output : Form
    {
        public Class_Level_Output()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Attentive Students"].Points.AddXY(0, 10);
            this.chart1.Series["Attentive Students"].Points.AddXY(5, 25);
            this.chart1.Series["Attentive Students"].Points.AddXY(10, 30);
            this.chart1.Series["Attentive Students"].Points.AddXY(15, 12);
            this.chart1.Series["Attentive Students"].Points.AddXY(20, 80);
            this.chart1.Series["Attentive Students"].Points.AddXY(25, 75);
            this.chart1.Series["Attentive Students"].Points.AddXY(30, 90);
            this.chart1.Series["Attentive Students"].Points.AddXY(35, 60);
        }

        private void Class_Level_Output_Load(object sender, EventArgs e)
        {

        }
    }
}
