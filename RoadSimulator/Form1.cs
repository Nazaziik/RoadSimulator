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
        private static bool canGo = true;
        private static Thread trainThreaad;
        private Train mainTrain;
        private Random random = new Random();
        private Pen pen = new Pen(Color.Red);
        private Car car;
        private Thread carThread;
        public static List<Car> carList;
        public List<Thread> threadList;

        #region FormSettings
        public Road()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(30, 100);
            carList = new List<Car>();
            threadList = new List<Thread>();
            InitiateTrain();
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
                e.Graphics.FillEllipse(Brushes.Red, 737, 272, 15, 15);
                e.Graphics.FillEllipse(Brushes.Red, 879, 343, 15, 15);
            }

            if (checkBox1.Checked)
            {
                if (!canGo)
                {
                    e.Graphics.DrawRectangle(pen, Railway.rectangle1);
                    e.Graphics.DrawRectangle(pen, Railway.rectangle2);
                }

                foreach (Car car in carList)
                {
                    e.Graphics.DrawRectangle(pen, car.RBeck);
                    e.Graphics.DrawRectangle(pen, car.RFront);
                }
            }
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            Invalidate();
        }
        #endregion

        #region TrainOrganization
        public void InitiateTrain()
        {
            mainTrain = new Train(10, random.Next(0, 2) == 0);//use singleton pattern
            trainThreaad = new Thread(new ParameterizedThreadStart(TrainThreadFunc));
            trainThreaad.Start(mainTrain);//BOXING
        }

        private void TrainThreadFunc(object obj)
        {
            Train train = (Train)obj;//UNBOXING
            while (true)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(delegate ()
                    {
                        canGo = train.Move();
                    }));
                }
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
                if (InvokeRequired)
                {
                    Invoke(new Action(delegate ()
                    {
                        car.Move();
                    }));
                }
                Thread.Sleep(16);
            }
        }
        #endregion

        private void CarAddButton_Click(object sender, EventArgs e)
        {
            InitiateCar();
        }

        private void CarDeleteButton_Click(object sender, EventArgs e)
        {
            if (carList.Count > 3)
            {
                carList.RemoveAt(random.Next(0, carList.Count));
                CarsCountLabel.Text = carList.Count.ToString();
            }
        }
    }
}
