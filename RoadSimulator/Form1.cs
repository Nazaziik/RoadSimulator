using RoadSimulator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoadSimulator
{
    public partial class Road : Form
    {
        private ControlPanelForm controlPanelForm;
        private static bool canGo = false;
        private static Thread trainThreaad;

        public Road()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(30, 100);
            //this.BackgroundImage = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\SourceToProject\mapa_v6.png", true);
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            ControlPanelInitiation();
        }

        private void OpenControlPanelButton_Click(object sender, EventArgs e)
        {
            if (!CheckPanelOpened())
            {
                ControlPanelInitiation();
            }
        }
        private bool CheckPanelOpened()
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "ControlPanelForm")
                {
                    return true;
                }
            }
            return false;
        }

        private void ControlPanelInitiation()
        {
            controlPanelForm = new ControlPanelForm();
            controlPanelForm.StartPosition = FormStartPosition.Manual;
            controlPanelForm.Location = new Point(1090, 100);
            controlPanelForm.Show();
        }

        public static void InitiateTrain()
        {
            Train train = new Train(new Point(0, 280), 50);
            trainThreaad = new Thread(new ParameterizedThreadStart(TrainThreadFunc));
            trainThreaad.Start(train);
        }

        private static void TrainThreadFunc(object obj)
        {
            Train train = (Train)obj;
            while (true)
            {
                canGo = train.Move();
                Thread.Sleep(40);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (canGo)
            {
                e.Graphics.FillEllipse(Brushes.LightGreen, 737, 272, 15, 15);
                e.Graphics.FillEllipse(Brushes.LightGreen, 879, 343, 15, 15);
            }
            else
            {
                e.Graphics.FillEllipse(Brushes.Red, 737, 272, 15, 15);
                e.Graphics.FillEllipse(Brushes.Red, 879, 343, 15, 15);
            }
        }
    }
}
