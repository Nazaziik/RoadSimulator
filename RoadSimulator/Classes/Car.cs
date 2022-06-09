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
                if (moveFromTop)
                {
                    if (moveRight)
                    {
                        if (_position.X < 780 && _position.X >= 700 && _position.Y > 235 && _position.Y < 319)
                        {
                            _position.Y += _speed;
                            RFront.Y += _speed;
                            RBeck.Y += _speed;
                        }
                        else if (_position.X < 780 && _position.X > 700 && _position.Y > 319 && _position.Y < 400)
                        {
                            //(poprawic rotacje/zmiane kwadracikow)
                            btm.RotateFlip(RotateFlipType.Rotate180FlipY);
                            moveRight = false;
                        }
                        else if (_position.X < 242 && _position.X > 94 && _position.Y > 519 && _position.Y < 650)
                        {
                            _position.Y += _speed;
                            RFront.Y += _speed;
                            RBeck.Y += _speed;
                        }

                        RFront.X += _speed;
                        RBeck.X += _speed;
                        _position.X += _speed;
                    }
                    else
                    {
                        if (_position.X < 242 && _position.X >= 94 && _position.Y > 519 && _position.Y < 650)
                        {
                            //(poprawic rotacje/zmiane kwadracikow)
                            btm.RotateFlip(RotateFlipType.Rotate180FlipY);
                            moveRight = true;
                        }
                        else if (_position.X < 780 && _position.X > 700 && _position.Y > 319 && _position.Y < 400)
                        {
                            _position.Y += _speed;
                            RFront.Y += _speed;
                            RBeck.Y += _speed;
                        }
                        else if (_position.X < 242 && _position.X > 94 && _position.Y > 395 && _position.Y < 519)
                        {
                            _position.Y += _speed;
                            RFront.Y += _speed;
                            RBeck.Y += _speed;
                        }

                        RFront.X -= _speed;
                        RBeck.X -= _speed;
                        _position.X -= _speed;
                    }
                }
                else
                {
                    if (moveRight)
                    {
                        if (_position.X < 270 && _position.X >= 70 && _position.Y > 430 && _position.Y < 510)
                        {
                            _position.Y -= _speed;
                            RFront.Y -= _speed;
                            RBeck.Y -= _speed;
                        }
                        else if (_position.X < 840 && _position.X > 695 && _position.Y > 195 && _position.Y < 320)
                        {
                            //(poprawic rotacje/zmiane kwadracikow)
                            btm.RotateFlip(RotateFlipType.Rotate180FlipY);
                            moveRight = false;
                        }
                        else if (_position.X < 840 && _position.X > 695 && _position.Y > 320 && _position.Y < 438)
                        {
                            _position.Y -= _speed;
                            RFront.Y -= _speed;
                            RBeck.Y -= _speed;
                        }

                        RFront.X += _speed;
                        RBeck.X += _speed;
                        _position.X += _speed;
                    }
                    else//DZIALA
                    {
                        if (_position.X < 270 && _position.X >= 70 && _position.Y > 420 && _position.Y < 510)
                        {
                            //(poprawic rotacje/zmiane kwadracikow)
                            btm.RotateFlip(RotateFlipType.Rotate180FlipY);
                            moveRight = true;
                        }
                        else if (_position.X < 840 && _position.X > 695 && _position.Y > 195 && _position.Y < 320)
                        {
                            _position.Y -= _speed;
                            RFront.Y -= _speed;
                            RBeck.Y -= _speed;
                        }
                        else if (_position.X < 230 && _position.X > 130 && _position.Y > 450 && _position.Y < 605)
                        {
                            _position.Y -= _speed;
                            RFront.Y -= _speed;
                            RBeck.Y -= _speed;
                        }

                        RFront.X -= _speed;
                        RBeck.X -= _speed;
                        _position.X -= _speed;
                    }
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
            if ((RFront.IntersectsWith(Railway.rectangle1) || RFront.IntersectsWith(Railway.rectangle2) || RBeck.IntersectsWith(Railway.rectangle1) || RBeck.IntersectsWith(Railway.rectangle2)) && !Road.canGo)
                return true;

            return false;
        }

        private void SetNewCar()
        {
            _speed = random.Next(5, 25);
            Bitmap demoBtm;

            if (_speed >= 5 && _speed < 10)
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\bus\BusUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(65, 65));
            }
            else if (_speed >= 10 && _speed < 15)
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\Jeep\JeepUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(55, 55));
            }
            else if (_speed >= 15 && _speed < 20)
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\Car (slow)\CarSlowUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(55, 50));
            }
            else
            {
                demoBtm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\car (fast)\CarFastUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(45, 40));
            }

            if (random.Next(0, 2) == 0)
            {
                _position.X = random.Next(-400, -100);
                _position.Y = 220;
                btm.RotateFlip(RotateFlipType.Rotate90FlipY);
                RFront = new Rectangle(new Point(_position.X + 35, _position.Y + 10), new Size(15, 35));
                RBeck = new Rectangle(new Point(_position.X - 10, _position.Y + 10), new Size(15, 35));
                moveFromTop = true;
            }
            else
            {
                _position.X = random.Next(1150, 1450);
                _position.Y = 590;
                btm.RotateFlip(RotateFlipType.Rotate90FlipX);
                RFront = new Rectangle(new Point(_position.X - 15, _position.Y + 10), new Size(15, 35));
                RBeck = new Rectangle(new Point(_position.X + 30, _position.Y + 10), new Size(15, 35));
                moveFromTop = false;
            }

            moveRight = moveFromTop;
        }
    }
}
