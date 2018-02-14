using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopSnake
{
    class Worm
    {
        public List<Point> body;
        public string sign;
        public ConsoleColor color;
        public int cnt, body_cnt;
        public Worm()
        {
            cnt = 0;
            body_cnt = 0;
            sign = "■";
            body = new List<Point>();
            body.Add(new Point(10, 10));
            color = ConsoleColor.Yellow;
        }
        public void Add()
        {
            body.Add(new Point(0, 0));
            Move(0, 0);
            body_cnt++;
        }
        public void Move(int dx, int dy)
        {

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;
            if (body[0].x < 0)
                body[0].x = Console.WindowWidth - 1;
            if (body[0].x >= Console.WindowWidth)
                body[0].x = 0;
            if (body[0].y < 0)
                body[0].y = Console.WindowHeight - 1;
            if (body[0].y >= Console.WindowHeight)
                body[0].y = 0;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            int index = 0;
            foreach (Point p in body)
            {
                if (index == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                index++;
            }
        }
    }
}
