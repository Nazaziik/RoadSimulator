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
        private static bool canGo = true;
        private static Thread trainThreaad;
        private Train mainTrain;
        private Random random = new Random();
        private Railway railway = new Railway();
        private Pen pen = new Pen(Color.Red);
        public List<Car> carList;
        public List<Thread> threadList;
        private Car car;
        private Thread carThread;

        #region FormSettings
        public Road()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(30, 100);
            //this.BackgroundImage = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\SourceToProject\mapa_v6.png", true);
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            carList = new List<Car>();
            threadList = new List<Thread>();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (mainTrain != null)
                e.Graphics.DrawImage(mainTrain.btm, mainTrain.Position);

            if (carList.Count > 0)
            {
                foreach (Car car in carList)
                {
                    e.Graphics.DrawImage(car.btm, car.Position);
                }
            }

            if (canGo)
            {
                e.Graphics.FillEllipse(Brushes.LightGreen, 737, 272, 15, 15);
                e.Graphics.FillEllipse(Brushes.LightGreen, 879, 343, 15, 15);
            }
            else
            {
                e.Graphics.DrawRectangle(pen, railway.rectangle1);
                e.Graphics.DrawRectangle(pen, railway.rectangle2);
                e.Graphics.FillEllipse(Brushes.Red, 737, 272, 15, 15);
                e.Graphics.FillEllipse(Brushes.Red, 879, 343, 15, 15);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Invalidate();
        }
        #endregion

        #region ControlPanelOrganization
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
        #endregion

        #region TrainOrganization
        public void InitiateTrain()
        {
            mainTrain = new Train(10, random.Next(0, 2) == 0);//use singleton pattern
            trainThreaad = new Thread(new ParameterizedThreadStart(TrainThreadFunc));
            trainThreaad.Start(mainTrain);//BOXING
        }

        private static void TrainThreadFunc(object obj)
        {
            Train train = (Train)obj;//UNBOXING
            while (true)
            {
                canGo = train.Move();
                Thread.Sleep(23);
            }
        }
        #endregion

        #region CarOrganization
        public void InitiateCar()
        {
            car = new Car();
            carList.Add(car);
            carThread = new Thread(new ParameterizedThreadStart(CarThreadFunc));
            threadList.Add(carThread);
            CarsCountLabel.Text = carList.Count.ToString();
            carThread.Start(car);//BOXING
        }

        private void CarThreadFunc(object obj)
        {
            Car car = (Car)obj;//UNBOXING
            while (true)
            {
                car.Move();
                Thread.Sleep(30);
            }
        }
        #endregion

    }
}
