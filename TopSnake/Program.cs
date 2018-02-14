using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Worm worm = new Worm();
            int lvl = 1;
            Wall wall = new Wall(lvl);

            bool gameOver = false;
            Console.CursorVisible = false;

            Random rnd = new Random();
            int _x = rnd.Next(1, 34);
            int _y = rnd.Next(1, 34);
            Food food = new Food(_x, _y);
            while (true)
            {
                foreach (Point p in wall.bricks)
                {
                    if (p.x == food.body[0].x && p.y == food.body[0].y)
                    {
                        rnd = new Random();
                        _x = rnd.Next(1, 34);
                        _y = rnd.Next(1, 34);
                        food = new Food(_x, _y);
                        continue;
                    }
                }
                for (int p = 0; p < worm.body.Count; p++)
                {
                    if (worm.body[p].x == food.body[0].x && worm.body[p].y == food.body[0].y)
                    {
                        rnd = new Random();
                        _x = rnd.Next(1, 70);
                        _y = rnd.Next(1, 20);
                        food = new Food(_x, _y);
                        continue;
                    }
                }
                break;
            }
            int k = 1;

            while (!gameOver)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    worm.Move(0, -1);
                if (keyInfo.Key == ConsoleKey.DownArrow)
                    worm.Move(0, 1);
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                    worm.Move(-1, 0);
                if (keyInfo.Key == ConsoleKey.RightArrow)
                    worm.Move(1, 0);
                if (keyInfo.Key == ConsoleKey.Escape)
                    gameOver = true;
                foreach (Point p in wall.bricks)
                {
                    if (p.x == worm.body[0].x && p.y == worm.body[0].y)
                    {
                        gameOver = true;
                    }
                }
                for (int p = 1; p <= worm.body.Count; p++)
                {
                    if (worm.body[p].x == worm.body[1].x && worm.body[p].y == worm.body[1].y)
                    {
                        gameOver = true;
                    }
                }


                if (food.body[0].x == worm.body[0].x && food.body[0].y == worm.body[0].y)
                {
                    k++;
                    worm.Add();
                    _x = rnd.Next(1, 34);
                    _y = rnd.Next(1, 34);
                    food = new Food(_x, _y);
                    bool ok = true;
                    while (ok)
                    {
                        foreach (Point p in wall.bricks)
                        {
                            if (p.x == food.body[0].x && p.y == food.body[0].y)
                            {
                                _x = rnd.Next(1, 34);
                                _y = rnd.Next(1, 34);
                                food = new Food(_x, _y);
                            }
                        }
                        for (int p = 1; p <= worm.body.Count; p++)
                        {
                            if (worm.body[p].x == food.body[0].x && worm.body[p].y == food.body[0].y)
                            {
                                _x = rnd.Next(1, 34);
                                _y = rnd.Next(1, 34);
                                food = new Food(_x, _y);
                            }
                        }
                        ok = false;
                    }
                }
                if (k % 5 == 0)
                {
                    k = 1;
                    lvl++;
                    wall = new Wall(lvl);
                }


                Console.Clear();
                worm.Draw();
                wall.Draw();
                food.Draw(_x, _y);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(33, 12);
            Console.WriteLine("GAME OVER!");
            Console.ReadKey();
        }
    }
    }

