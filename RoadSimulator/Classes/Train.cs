using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSimulator.Classes
{
    public class Train
    {
        public Bitmap btm;

        private Point _position; //(0,280) / (1067, 280)
        public Point Position
        {
            get { return _position; }
        }

        private int _speed;
        public int Speed
        {
            get { return _speed; }
        }

        public Train(Point position, int speed)
        {
            btm = new Bitmap(@"D:\Learn\Systemy operacyjne\Project\SourceToProject\Train.png", true);
            _position = position;
            btm.SetResolution(150f, 150f);
            this._speed = speed;
        }

        public bool Move()
        {
            if (_position.X > 4000)
                _position.X = -4000;
            _position.X += _speed;
            if (_position.X > -2000 && _position.X < 1000)
                return false;
            else
                return true;
        }
    }
}
