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
        public ControlPanelForm()
        {
            InitializeComponent();
        }

        private void TrainButton_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "Road")
                {
                    Road road = (Road)frm;//UNBOXING
                    road.InitiateTrain();
                }
            }
        }
    }
}
