using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int WidthDisplay = Console.WindowWidth;
            int HeightDisplay = Console.WindowHeight;
            Console.WindowHeight = 30;
            Console.WindowWidth = 100;
            Random randomnummer = new Random();
            int X = 5, Y = 0;
            pixel pixi = new pixel();
            pixi.xpos = WidthDisplay / 2;
            pixi.ypos = HeightDisplay / 2;
            pixi.color = ConsoleColor.Red;
            string movement = "RIGHT";
            List<int> xposition = new List<int>();
            List<int> yposition = new List<int>();
            int Xmouse = randomnummer.Next(0, WidthDisplay);
            int Ymouse = randomnummer.Next(0, HeightDisplay);
            string buttonpressed = "no";
            while (true)
            {
                Console.Clear();
                if (pixi.xpos == WidthDisplay - 1 || pixi.xpos == 0 || pixi.ypos == HeightDisplay - 1 || pixi.ypos == 0)
                {
                   X = 1;
                }
                for (int i = 0; i < WidthDisplay; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("*");
                }
                for (int i = 0; i < WidthDisplay; i++)
                {
                    Console.SetCursorPosition(i, HeightDisplay - 1);
                    Console.Write("*");
                }
                for (int i = 0; i < HeightDisplay; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("*");
                }
                for (int i = 0; i < HeightDisplay; i++)
                {
                    Console.SetCursorPosition(WidthDisplay - 1, i);
                    Console.Write("*");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (Xmouse == pixi.xpos && Ymouse == pixi.ypos)
                {
                    Y++;
                    Xmouse = randomnummer.Next(1, WidthDisplay - 2);
                    Ymouse = randomnummer.Next(1, HeightDisplay - 2);
                }
                for (int i = 0; i < xposition.Count(); i++)
                {
                    Console.SetCursorPosition(xposition[i], yposition[i]);
                    Console.Write("*");
                    if (xposition[i] == pixi.xpos && yposition[i] == pixi.ypos)
                    {
                       X = 1;
                    }
                }
                if (X == 1)
                {
                    break;
                }
                Console.SetCursorPosition(pixi.xpos, pixi.ypos);
                Console.ForegroundColor = pixi.color;
                Console.Write("*");
                Console.SetCursorPosition(Xmouse, Ymouse);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("*");
                DateTime dateTime = DateTime.Now;
                DateTime dateTime2 = DateTime.Now;
                dateTime = DateTime.Now;
                buttonpressed = "no";
                while (true)
                {
                    dateTime2 = DateTime.Now;
                    if (dateTime2.Subtract(dateTime).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonpressed == "no")
                        {
                            movement = "UP";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonpressed == "no")
                        {
                            movement = "DOWN";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonpressed == "no")
                        {
                            movement = "LEFT";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonpressed == "no")
                        {
                            movement = "RIGHT";
                            buttonpressed = "yes";
                        }
                    }
                }
                xposition.Add(pixi.xpos);
                yposition.Add(pixi.ypos);
                switch (movement)
                {
                    case "UP":
                        pixi.ypos--;
                        break;
                    case "DOWN":
                        pixi.ypos++;
                        break;
                    case "LEFT":
                        pixi.xpos--;
                        break;
                    case "RIGHT":
                        pixi.xpos++;
                        break;
                }
                if (xposition.Count() > Y)
                {
                    xposition.RemoveAt(0);
                    yposition.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(WidthDisplay / 5, HeightDisplay / 2);
            Console.WriteLine("GAMEOVER, Y " + Y);
            Console.SetCursorPosition(WidthDisplay / 5, HeightDisplay / 2 + 1);
        }
        class pixel
        {
            public int xpos { get; set; }
            public int ypos { get; set; }
            public ConsoleColor color { get; set; }
        }
    }
}
