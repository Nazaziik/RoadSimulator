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

        Random random;
        bool moveFromTop;
        bool moveRight;

        public Car()
        {
            random = new Random();

            SetNewCar();
        }

        public void Move()
        {
            IfCarFinished();
            if (!CheckIfDanger())
            {
                if (moveRight)
                {
                    RFront.X += _speed;
                    RBeck.X += _speed;
                    _position.X += _speed;
                    ///////////////////////////////////////////////add moving with pos.Y on turns (3 points: start turning; mid(rotate car); end mowing pos.Y)
                }
                else
                {
                    RFront.X -= _speed;
                    RBeck.X -= _speed;
                    _position.X -= _speed;
                    ///////////////////////////////////////////////add moving with pos.Y on turns (3 points: start turning; mid(rotate car); end mowing pos.Y)
                }
            }
        }

        public bool IfCarFinished()
        {
            if (_position.X > 1250)
            {
                SetNewCar();
                return true;
            }
            else if (_position.X < -300)
            {
                SetNewCar();
                return true;
            }
            return false;
        }

        private bool CheckIfDanger()
        {
            foreach (Car c in Road.carList)
            {
                if (RFront.IntersectsWith(c.RBeck))
                {
                    return true;
                }
            }
            if (RFront.IntersectsWith(Railway.rectangle1) || RFront.IntersectsWith(Railway.rectangle2))
                return true;

            return false;
        }

        private void SetNewCar()
        {
            _speed = random.Next(5, 25);///////////////////////////////Change speed
            Bitmap demoBtm;

            if (_speed >= 5 && _speed < 10)
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\bus\BusUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(70, 60));/////////////////////correct car size
            }
            else if (_speed >= 10 && _speed < 15)
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\Jeep\JeepUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(60, 50));/////////////////////correct car size
            }
            else if (_speed >= 15 && _speed < 20)
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\Car (slow)\CarSlowUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(55, 40));/////////////////////correct car size
            }
            else
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\car (fast)\CarFastUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(55, 40));/////////////////////correct car size
            }

            if (random.Next(0, 2) == 0)
            {
                _position.X = random.Next(-400, -100);/////////////////////////correct car spawn point
                _position.Y = 205;/////////////////////correct car spawn point
                btm.RotateFlip(RotateFlipType.Rotate90FlipY);
                RFront = new Rectangle(new Point(_position.X + 35, _position.Y + 10), new Size(15, 35));/////////////////////////change rectangle size and pos
                RBeck = new Rectangle(new Point(_position.X - 10, _position.Y + 10), new Size(15, 35));/////////////////////////change rectangle size and pos
                moveFromTop = true;
            }
            else
            {
                _position.X = random.Next(1150, 1450);/////////////////////////
                _position.Y = 610;/////////////////////correct car spawn point
                btm.RotateFlip(RotateFlipType.Rotate90FlipX);
                RFront = new Rectangle(new Point(_position.X - 15, _position.Y + 10), new Size(15, 35));/////////////////////////change rectangle size and pos
                RBeck = new Rectangle(new Point(_position.X + 30, _position.Y + 10), new Size(15, 35));/////////////////////////change rectangle size and pos
                moveFromTop = false;
            }

            moveRight = moveFromTop;
        }
    }
}
