using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopSnake
{
    enum GameLevel
    {
        First,
        Second
    }
    class Wall
    {
        public List<Point> bricks;
        ConsoleColor color;
        char sign;

        public Wall(int level)
        {
            bricks = new List<Point>();
            color = ConsoleColor.White;
            sign = '#';
            
        }

        public void LoadLevel(GameLevel level)
        {
            string fname = "";
            string fname2 = "";

            switch (level)
            {
                case GameLevel.First:
                    fname = @"C:\Users\User_PC\Documents\PP2\Student\week 5\Snake\\Level1.txt";
                    break;
                case GameLevel.Second:
                    fname2 = @"C:\Users\User_PC\Documents\PP2\Student\week 5\Snake\\Level2_1.txt";
                    break;
                default:
                    break;
            }

            FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int y = 0;

            while ((line = sr.ReadLine()) != null)
            {
                for (int x = 0; x < line.Length; ++x)
                {
                    if (line[x] == '#')
                    {
                        this.bricks.Add(new Point ( x , y ));
                    }
                }
                y++;
            }

            sr.Close();
            fs.Close();
        }

        public void Draw()
        {
            foreach (Point p in bricks)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.ForegroundColor = color;
                Console.Write(sign);
            }
        }
    }
}
