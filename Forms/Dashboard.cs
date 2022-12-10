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
    public partial class Dashboard : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public Dashboard()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 58)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
        }

        private void BtnResults_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnResults);
            using (Result1 rr = new Result1())
            {
                rr.ShowDialog();
            }
        }

        private void BtnClassLevelOutput_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnClassLevelOutput);
        }

        private void BtnStudentLevelOutput_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnStudentLevelOutput);
        }

        private void BtnAttendance_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAttendance);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnExit);
        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:SS");
        }
    }
}
