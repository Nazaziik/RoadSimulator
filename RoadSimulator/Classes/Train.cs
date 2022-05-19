using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSimulator.Classes
{
    public class Train
    {
        private Random random;
        public Bitmap btm;
        public static bool moveRight = true;

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

        public Train(int speed, bool moveRight)
        {
            random = new Random();

            if (moveRight)
                _position = new Point(MakeTrainSpawnPoint(true), 280);
            else
                _position = new Point(MakeTrainSpawnPoint(false), 280);

            GetTrainBitmap(moveRight);
            this._speed = speed;
        }

        public bool Move()
        {
            if (moveRight)
            {
                if (_position.X > 1500)
                {
                    moveRight = false;
                    _position.X = MakeTrainSpawnPoint(false);
                    GetTrainBitmap(moveRight);
                }

                _position.X += _speed;

                if (_position.X > -1200 && _position.X < 1200)
                    return false;
                else
                    return true;
            }
            else
            {
                if (_position.X < -700)
                {
                    moveRight = true;
                    _position.X = MakeTrainSpawnPoint(true);
                    GetTrainBitmap(moveRight);
                }

                _position.X -= _speed;

                if (_position.X > -320 && _position.X < 2267)
                    return false;
                else
                    return true;
            }
        }

        private int MakeTrainSpawnPoint(bool moveFromLeft)
        {
            if (moveFromLeft)
                return random.Next(-2800, -1800);
            else
                return random.Next(2867, 3867);
        }

        private void GetTrainBitmap(bool moveRight)
        {
            Bitmap demoBtm;

            if (moveRight)
                demoBtm = new Bitmap(Directory.GetCurrentDirectory() + @"\SourceToProject\cars\Train\TrainRight.png", true);
            else
                demoBtm = new Bitmap(Directory.GetCurrentDirectory() + @"\SourceToProject\cars\Train\TrainLeft.png", true);

            this.btm = new Bitmap(demoBtm, new Size(990, 90));
            this.btm.SetResolution(150f, 150f);
        }
    }
}
