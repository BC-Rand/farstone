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
        public static int CardsPerRow = 7;

        private static int CardsDrawn = 0;
        private static int CurrentRow = 0;

        public static void CreateGrid(int width, int height)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

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
            // Console.Clear();

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

        public static void DrawCard(string name, string desc, string pic, char upperLeft, char upperRight, char lowerLeft, char lowerRight, ConsoleColor color)
        {
            int x = CardsDrawn * (CardWidth + 2) + 1;
            int y = CurrentRow * (CardHeight + 1);

            //DrawBackgroundRect(x, y, CardWidth, CardHeight, ConsoleColor.Red);
            DrawOutlinedRect(x, y, CardWidth, CardHeight, color);
            SetCharAt(x + 2, y + 1, upperLeft, color);
            SetCharAt(x + CardWidth - 3, y + 1, upperRight, color);

            DrawString(x + 2, y + CardHeight - 3, desc, color);
            DrawString(x + 2, y + CardHeight - 4, name, color);

            if (pic != "")
            {
                DrawString(x + 2, y + CardHeight - 2, "ATK " + lowerLeft + "|", color);
                DrawString(x + CardWidth - 6, y + CardHeight - 2, "HP " + lowerRight, color);

                DrawOutlinedRect(x + 4, y + 2, 6, 3, color);
                DrawString(x + 5, y + 3, pic, color);
            }

            CardsDrawn++;

            if (CardsDrawn == CardsPerRow)
            {
                CardsDrawn = 0;
                CurrentRow++;
            }
        }

        public static void DrawEmptyCard()
        {
            DrawCard("", "", "", ' ', ' ', ' ', ' ', ConsoleColor.Red);
        }

        public static void DrawBlankSlot()
        {
            DrawCard("", "", "", ' ', ' ', ' ', ' ', ConsoleColor.Black);
        }

        public static char ToChar(int str)
        {
            return str.ToString().ToCharArray()[0];
        }

        public static void DrawGame(Player current_player, Player other_player)
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++ " + other_player.name + "'s creatures +++++++++++++++");

            Render.DrawBackgroundRect(0, 0, 112, 10, ConsoleColor.DarkRed);
            Render.DrawBackgroundRect(0, 11, 112, 10, ConsoleColor.DarkGreen);

            for (int i = 0; i < 7; i++)
            {
                if (other_player.field[i] != null) {
                    Minion curr = other_player.field[i] as Minion;
                    char atk = ToChar(curr.atk);
                    char hp = ToChar(curr.hp);
                    char cost = ToChar(curr.cost);
                    Render.DrawCard("12345678", curr.name, "1234", ToChar(i), cost, atk, hp, ConsoleColor.White);
                }
                else
                {
                    Render.DrawEmptyCard();
                }
            }

            for (int i = 0; i < 7; i++)
            {
                if (current_player.field[i] != null) {
                    Minion curr = current_player.field[i] as Minion;
                    char atk = ToChar(curr.atk);
                    char hp = ToChar(curr.hp);
                    char cost = ToChar(curr.cost);
                    Render.DrawCard("12345678", curr.name, "1234", ToChar(i), cost, atk, hp, ConsoleColor.White);
                }
                else
                {
                    Render.DrawEmptyCard();
                }
            }

            for (int i = 0; i < 7; i++)
            {
                if (i < current_player.hand.Count) {
                    Minion curr = current_player.hand[i] as Minion;
                    char atk = ToChar(curr.atk);
                    char hp = ToChar(curr.hp);
                    char cost = ToChar(curr.cost);
                    Render.DrawCard("12345678", curr.name, "1234", ToChar(i), cost, atk, hp, ConsoleColor.White);
                }
                else
                {
                    Render.DrawBlankSlot();
                }
            }

            string toPut = "+++++++++++++++ " + current_player.name + "'s creatures +++++++++++++++";
            Render.DrawString(0, 10, toPut, ConsoleColor.White);

            toPut = "+++++++++++++++ " + current_player.name + "'s hand +++++++++++++++";
            Render.DrawString(0, 21, toPut, ConsoleColor.White);

            Render.Finish();
        }
    }
}