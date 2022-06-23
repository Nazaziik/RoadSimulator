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
            rectangle1 = new Rectangle(new Point(740, 260), new Size(65, 1));
            rectangle2 = new Rectangle(new Point(834, 365), new Size(65, 1));
        }
    }
}
