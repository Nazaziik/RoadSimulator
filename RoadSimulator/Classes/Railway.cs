using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSimulator.Classes
{
    public static class Railway
    {
        public static Rectangle rectangle1;
        public static Rectangle rectangle2;

        static Railway()
        {
            rectangle1 = new Rectangle(new Point(756, 274), new Size(55, 5));
            rectangle2 = new Rectangle(new Point(824, 339), new Size(55, 5));
        }
    }
}
