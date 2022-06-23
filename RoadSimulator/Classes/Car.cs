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
                if (moveFromTop)//CAR
                {
                    if (moveRight)
                    {
                        if (_position.X < 780 && _position.X >= 700 && _position.Y > 230 && _position.Y < 319)//1 poworot w prawo w nyz
                        {
                            _position.Y += _speed;
                            RFront.Y += _speed;
                            RBeck.Y += _speed;
                        }
                        else if (_position.X < 820 && _position.X > 700 && _position.Y > 280 && _position.Y < 420)// 1 poworot - rozworot
                        {
                            btm.RotateFlip(RotateFlipType.Rotate180FlipY);
                            moveRight = false;
                        }
                        else if (_position.X < 170 && _position.X > 60 && _position.Y > 480 && _position.Y < 690)//2 poworot w prawo w nyz 
                        {
                            _position.Y += (_speed + (_speed / 2));
                            RFront.Y += (_speed + (_speed / 2));
                            RBeck.Y += (_speed + (_speed / 2));
                        }
                        //prosta w prawo
                        _position.X += _speed;
                        RFront.X += _speed;
                        RBeck.X += _speed;
                    }
                    else
                    {
                        if (_position.X < 170 && _position.X >= 60 && _position.Y > 480 && _position.Y < 690)//2 poworot rozworot 
                        {
                            btm.RotateFlip(RotateFlipType.Rotate180FlipY);
                            moveRight = true;
                        }
                        else if (_position.X < 820 && _position.X > 700 && _position.Y > 280 && _position.Y < 375)//1 poworot w liwo w nyz
                        {
                            _position.Y += _speed;
                            RFront.Y += _speed;
                            RBeck.Y += _speed;
                        }
                        else if (_position.X < 155 && _position.X > 75 && _position.Y > 360 && _position.Y < 540)//2 poworot w liwo w nyz
                        {
                            _position.Y += (_speed + (_speed / 2));
                            RFront.Y += (_speed + (_speed / 2));
                            RBeck.Y += (_speed + (_speed / 2));
                        }
                        //prosta w liwo
                        _position.X -= _speed;
                        RFront.X -= _speed;
                        RBeck.X -= _speed;
                    }
                }
                else//maszynky idut z nyzu
                {
                    if (moveRight)
                    {
                        if (_position.X < 270 && _position.X >= 70 && _position.Y > 430 && _position.Y < 520)//1 poworot w prawo w werch
                        {
                            _position.Y -= _speed;
                            RFront.Y -= _speed;
                            RBeck.Y -= _speed;
                        }
                        else if (_position.X < 890 && _position.X > 780 && _position.Y > 175 && _position.Y < 300)//2 poworot - rozworot
                        {
                            btm.RotateFlip(RotateFlipType.Rotate180FlipY);
                            moveRight = false;
                        }
                        else if (_position.X < 890 && _position.X > 780 && _position.Y > 300 && _position.Y < 455)//2 poworot w prawo w werch
                        {
                            _position.Y -= (_speed + (_speed / 2));
                            RFront.Y -= (_speed + (_speed / 2));
                            RBeck.Y -= (_speed + (_speed / 2));
                        }
                        //2 prosta (w prawo)
                        _position.X += _speed;
                        RFront.X += _speed;
                        RBeck.X += _speed;
                    }
                    else
                    {
                        if (_position.X < 270 && _position.X >= 70 && _position.Y > 430 && _position.Y < 520)//1 poworot - rozworot
                        {
                            btm.RotateFlip(RotateFlipType.Rotate180FlipY);
                            moveRight = true;
                        }
                        else if (_position.X < 890 && _position.X > 770 && _position.Y > 150 && _position.Y < 300)//2 poworot zwerchu w liwo w werch
                        {
                            _position.Y -= _speed;
                            RFront.Y -= _speed;
                            RBeck.Y -= _speed;
                        }
                        else if (_position.X < 245 && _position.X > 160 && _position.Y > 450 && _position.Y < 625)//1 poworot w liwo w werch
                        {
                            _position.Y -= _speed;
                            RFront.Y -= _speed;
                            RBeck.Y -= _speed;
                        }
                        //prosta w liwo @@@@@@@@@@@@
                        _position.X -= _speed;
                        RFront.X -= _speed;
                        RBeck.X -= _speed;
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
                if (this != c)
                    if (this.RFront.IntersectsWith(c.RBeck))
                        return true;
            }
            if ((this.RFront.IntersectsWith(Railway.rectangle1) || this.RFront.IntersectsWith(Railway.rectangle2)) && !Road.canGo)
                return true;

            return false;
        }

        private void SetNewCar()
        {
            _speed = random.Next(5, 25);
            Bitmap demoBtm;

            if (_speed >= 5 && _speed < 10)
            {
                demoBtm = new Bitmap(@"D:\Learn\6 Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\bus\BusUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(65, 65));
            }
            else if (_speed >= 10 && _speed < 15)
            {
                demoBtm = new Bitmap(@"D:\Learn\6 Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\Jeep\JeepUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(55, 55));
            }
            else if (_speed >= 15 && _speed < 20)
            {
                demoBtm = new Bitmap(@"D:\Learn\6 Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\Car (slow)\CarSlowUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(55, 50));
            }
            else
            {
                demoBtm = new Bitmap(@"D:\Learn\6 Systemy operacyjne\Project\RoadSimulator\SourceToProject\cars\car (fast)\CarFastUp.png", true);
                this.btm = new Bitmap(demoBtm, new Size(45, 40));
            }

            if (random.Next(0, 2) == 0)
            {
                _position.X = -300;
                _position.Y = 231;
                btm.RotateFlip(RotateFlipType.Rotate90FlipY);
                RFront = new Rectangle(new Point(_position.X + 35, _position.Y + 10), new Size(15, 30));
                RBeck = new Rectangle(new Point(_position.X - 10, _position.Y + 10), new Size(15, 30));
                moveFromTop = true;
            }
            else
            {
                _position.X = 1250;
                _position.Y = 590;
                btm.RotateFlip(RotateFlipType.Rotate90FlipX);
                RFront = new Rectangle(new Point(_position.X - 5, _position.Y + 10), new Size(15, 30));
                RBeck = new Rectangle(new Point(_position.X + 40, _position.Y + 10), new Size(15, 30));
                moveFromTop = false;
            }

            moveRight = moveFromTop;
        }
    }
}
