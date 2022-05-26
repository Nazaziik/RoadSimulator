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
    public partial class ControlPanelForm : Form
    {
        private FormCollection fc;
        private Road road;

        public ControlPanelForm()
        {
            InitializeComponent();

            fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "Road")
                {
                    road = (Road)frm;//UNBOXING
                }
            }
        }

        private void TrainButton_Click(object sender, EventArgs e)
        {
            road.InitiateTrain();
        }

        private void AddCarButton_Click(object sender, EventArgs e)
        {
            //road.InitiateCar();
        }
    }
}
