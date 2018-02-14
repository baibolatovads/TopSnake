using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopSnake
{
    class Food
    {
        public List<Point> body;
        char sign;
        ConsoleColor color;

        public Food(int x, int y)
        {
            body = new List<Point>();
            body.Add(new Point ( x, y));
            color = ConsoleColor.Yellow;
            sign = '*';
        }

        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(sign);
        }

    }
}
