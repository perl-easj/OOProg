using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvLINQ
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BotRight { get; set; }

        public Rectangle(Point topLeft, Point botRight)
        {
            TopLeft = topLeft;
            BotRight = botRight;
        }
    }
}
