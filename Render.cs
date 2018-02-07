using System;

namespace farstone
{
    static class Render
    {
        //                         Foreground    Background
        public static Tuple<char, ConsoleColor, ConsoleColor>[,] Grid;
        public static int Width;
        public static int Height;

        public static int CardWidth = 14;
        public static int CardHeight = 10;
        public static int CardsPerRow = 5;

        private static int CardsDrawn = 0;
        private static int CurrentRow = 0;

        public static void CreateGrid(int width, int height)
        {
            Grid = new Tuple<char, ConsoleColor, ConsoleColor>[width, height];
            Width = width;
            Height = height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Grid[x, y] = new Tuple<char, ConsoleColor, ConsoleColor>(' ', ConsoleColor.White, ConsoleColor.Black);
                }
            }
        }

        public static void Finish()
        {
            Console.Clear();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Tuple<char, ConsoleColor, ConsoleColor> toPut = Grid[x, y];
                    Console.ForegroundColor = toPut.Item2;
                    Console.BackgroundColor = toPut.Item3;
                    Console.Write(toPut.Item1);
                }

                Console.WriteLine();
            }

            CardsDrawn = 0;
            CurrentRow = 0;
        }

        public static void DrawBackgroundRect(int xPos, int yPos, int width, int height, ConsoleColor color)
        {
            for (int x = xPos; x < xPos + width; x++)
            {   
                for (int y = yPos; y < yPos + height; y++)
                {
                    Tuple<char, ConsoleColor, ConsoleColor> oldChar = Grid[x, y];
                    Grid[x, y] = new Tuple<char, ConsoleColor, ConsoleColor>(oldChar.Item1, oldChar.Item2, color);
                }
            }
        }

        public static void DrawOutlinedRect(int xPos, int yPos, int width, int height, ConsoleColor color)
        {
            for (int x = xPos; x < xPos + width; x++)
            {   
                for (int y = yPos; y < yPos + height; y++)
                {
                    bool left = x == xPos;
                    bool right = x == xPos + width - 1;
                    bool top = y == yPos;
                    bool bottom = y == yPos + height - 1;

                    char toPut = ' ';

                    if (top && left)
                    {
                        toPut = '┏';
                    }
                    else if (top && right)
                    {
                        toPut = '┓';
                    }
                    else if (bottom && left)
                    {
                        toPut = '┗';
                    }
                    else if (bottom && right)
                    {
                        toPut = '┛';
                    }
                    else if (top || bottom)
                    {
                        toPut = '━';
                    }
                    else if (left || right)
                    {
                        toPut = '┃';
                    }

                    // Grid[x, y] = new Tuple<char, ConsoleColor, ConsoleColor>(toPut, color, ConsoleColor.Black);
                    Tuple<char, ConsoleColor, ConsoleColor> oldChar = Grid[x, y];
                    Grid[x, y] = new Tuple<char, ConsoleColor, ConsoleColor>(toPut, color, oldChar.Item3);
                }
            }
        }

        public static void SetCharAt(int xPos, int yPos, char toPut, ConsoleColor color)
        {
            Tuple<char, ConsoleColor, ConsoleColor> oldChar = Grid[xPos, yPos];
            Grid[xPos, yPos] = new Tuple<char, ConsoleColor, ConsoleColor>(toPut, color, oldChar.Item3);
        }

        public static void DrawString(int xPos, int yPos, string toPut, ConsoleColor color)
        {
            for (int i = 0; i < toPut.Length; i++)
            {
                SetCharAt(xPos + i, yPos, toPut[i], color);
            }
        }

        public static void DrawCard(string name, char upperLeft, char upperRight, char lowerLeft, char lowerRight)
        {
            int x = CardsDrawn * (CardWidth + 2);
            int y = CurrentRow * (CardHeight + 1);

            //DrawBackgroundRect(x, y, CardWidth, CardHeight, ConsoleColor.Red);
            DrawOutlinedRect(x, y, CardWidth, CardHeight, ConsoleColor.White);
            SetCharAt(x + 2, y + 1, upperLeft, ConsoleColor.White);
            SetCharAt(x + CardWidth - 2, y + 1, upperRight, ConsoleColor.White);
            SetCharAt(x + 2, y + CardHeight - 2, lowerLeft, ConsoleColor.White);            
            SetCharAt(x + CardWidth - 2, y + CardHeight - 2, lowerRight, ConsoleColor.White);
            DrawString(x + 4, y + CardHeight - 4, name, ConsoleColor.White);      

            CardsDrawn++;

            if (CardsDrawn == CardsPerRow)
            {
                CardsDrawn = 0;
                CurrentRow++;
            }
        }
    }
}