using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSimulator.Classes
{
    class Car
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

        bool stop = false;
        bool moveDown = false;

        public Car(Point point, int speed, bool move)
        {
            random = new Random();
            btm = new Bitmap(@"C:\Users\deduhan1\source\repos\System O. Project\System O. Project\Resources\car.png", true);
            _position = point;
            if (move)
                moveDown = true;
            this._speed = speed;
            if (moveDown)
            {
                btm.RotateFlip(RotateFlipType.Rotate90FlipY);
                RFront = new Rectangle(new Point(_position.X, _position.Y + 155), new Size(75, 35));
                RBeck = new Rectangle(new Point(_position.X, _position.Y - 35), new Size(75, 180));
            }
            else
            {
                btm.RotateFlip(RotateFlipType.Rotate90FlipX);
                RFront = new Rectangle(new Point(_position.X, _position.Y - 35), new Size(75, 35));
                RBeck = new Rectangle(new Point(_position.X, _position.Y + 10), new Size(75, 180));
            }
            btm.SetResolution(400f, 400f);
        }

        public void Move()
        {
            if (moveDown)
            {
                RFront.Y += _speed;
                RBeck.Y += _speed;
                _position.Y += _speed;
            }
            else
            {
                RFront.Y -= _speed;
                RBeck.Y -= _speed;
                _position.Y -= _speed;
            }
        }

        public void StopCar(bool go, Railway r, List<Car> cars)
        {
            if (stop && _speed != 0) _speed--;
            if (!stop && _speed != 7) _speed++;

            if (!go && (RFront.IntersectsWith(r.rectangle1) || RFront.IntersectsWith(r.rectangle2)))
                stop = true;
            else if (ShowValue(cars))
                stop = true;
            else
                stop = false;
        }

        public bool DelCar()
        {
            if (_position.Y > 1600)
            {
                _position.Y = random.Next(-1000, -400);
                RFront = new Rectangle(new Point(_position.X, _position.Y + 155), new Size(75, 35));
                RBeck = new Rectangle(new Point(_position.X, _position.Y - 35), new Size(75, 180));
                return true;
            }
            if (_position.Y < -1100)
            {
                _position.Y = random.Next(900, 1500);
                RFront = new Rectangle(new Point(_position.X, _position.Y - 35), new Size(75, 35));
                RBeck = new Rectangle(new Point(_position.X, _position.Y + 10), new Size(75, 180));
                return true;
            }
            return false;
        }

        private bool ShowValue(List<Car> cars)
        {
            foreach (Car c in cars)
                if (RFront.IntersectsWith(c.RBeck)) return true;
            return false;
        }
    }
}
