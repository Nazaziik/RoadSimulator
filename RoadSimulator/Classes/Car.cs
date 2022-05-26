using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSimulator.Classes
{
    public class Car
    {
        private Random random;
        public Bitmap btm;
        public Rectangle RFront, RBeck;

        private Point _position;
        public Point Position
        {
            get { return _position; }
        }

        private int _speed;
        public int Speed
        {
            get { return _speed; }
        }

        //bool stop = false;
        bool moveFromTop;

        public Car()
        {
            random = new Random();

            SetNewCar();

            if (random.Next(0, 2) == 0)
            {
                _position = new Point(-100, 205);
                moveFromTop = true;
            }
            else
            {
                _position = new Point(1130, 610);
                moveFromTop = true;
            }

            if (moveFromTop)
            {
                btm.RotateFlip(RotateFlipType.Rotate90FlipY);
                RFront = new Rectangle(new Point(_position.X + 155, _position.Y), new Size(75, 35));
                RBeck = new Rectangle(new Point(_position.X - 35, _position.Y), new Size(75, 180));
            }
            else
            {
                btm.RotateFlip(RotateFlipType.Rotate90FlipX);
                RFront = new Rectangle(new Point(_position.X - 35, _position.Y), new Size(75, 35));
                RBeck = new Rectangle(new Point(_position.X + 10, _position.Y), new Size(75, 180));
            }
        }

        public void Move()
        {
            IfCarFinished();

            if (moveFromTop)
            {
                RFront.X += _speed;
                RBeck.X += _speed;
                _position.X += _speed;
            }
            else
            {
                RFront.X -= _speed;
                RBeck.X -= _speed;
                _position.X -= _speed;
            }
        }

        private void IfCarFinished()
        {
            if (_position.X > 1250)
            {
                _position.X = random.Next(-1000, -400);
                _position.Y = random.Next(-1000, -400);
                RFront = new Rectangle(new Point(_position.X, _position.Y + 155), new Size(75, 35));
                RBeck = new Rectangle(new Point(_position.X, _position.Y - 35), new Size(75, 180));
                SetNewCar();
            }
            else if (_position.X < -300)
            {
                _position.Y = random.Next(900, 1500);
                RFront = new Rectangle(new Point(_position.X, _position.Y - 35), new Size(75, 35));
                RBeck = new Rectangle(new Point(_position.X, _position.Y + 10), new Size(75, 180));
                SetNewCar();
            }
        }
        /*
        private bool CheckIfDanger(List<Car> cars)
        {
            foreach (Car c in cars)
                if (RFront.IntersectsWith(c.RBeck)) return true;
            return false;
        }
        */
        private void SetNewCar()
        {
            _speed = random.Next(5, 25);
            Bitmap demoBtm;

            if (_speed >= 5 && _speed < 10)
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\bus\BusUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(70, 60));
            }
            else if (_speed >= 10 && _speed < 15)
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\bus\JeepUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(60, 50));
            }
            else if (_speed >= 15 && _speed < 20)
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\bus\CarSlowUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(55, 40));
            }
            else
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\bus\CarFastUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(55, 40));
            }
        }
    }
}
