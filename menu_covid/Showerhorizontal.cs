using System;
using System.Collections.Generic;

namespace menu
{
    public class Showerhorizontal : Menu.MenuShower
    {
        public override int Show(Menu menu)
        {
            Console.CursorVisible = false;
            ConsoleColor startback = Console.BackgroundColor;
            ConsoleColor startfore = Console.ForegroundColor;
            ConsoleKeyInfo znak = new ConsoleKeyInfo();
            while (znak.Key != ConsoleKey.Enter && znak.Key != ConsoleKey.Escape)
            {
                Console.SetCursorPosition(menu.Posx, menu.Posy);
                int positon_x_i = menu.Posx;

                for (int i = 0; i < menu.elementy.Length; i++)
                {
                    if (i == menu.Wybrany)
                    {
                        Console.BackgroundColor = menu.Backcol_hos;
                        Console.ForegroundColor = menu.Forecol_hos;
                    }
                    else
                    {
                        Console.BackgroundColor = menu.Backcol;
                        Console.ForegroundColor = menu.Forecol;
                    }

                    if (Console.WindowWidth > positon_x_i)
                    {
                        Console.SetCursorPosition(positon_x_i, menu.Posy);
                        positon_x_i += menu.elementy[i].Length;
                        Console.WriteLine(menu.elementy[i].PadRight(menu.DlugoscMaxElement));
                    }
                    else { throw new Exception("szersze od konsoli"); }
                }
                znak = Console.ReadKey(true);
                if (znak.Key == ConsoleKey.LeftArrow && menu.Wybrany > 0)
                {
                    menu.Wybrany--;
                }
                else if (znak.Key == ConsoleKey.RightArrow && menu.Wybrany < menu.elementy.Length - 1)
                {
                    menu.Wybrany++;
                }
                else if (znak.Key == ConsoleKey.Escape)
                {
                    menu.Wybrany = -1;
                }
            }
            Console.CursorVisible = true;
            Console.BackgroundColor = startback;
            Console.ForegroundColor = startfore;

            return menu.Wybrany;
        }
    }












    //horizontal menu?
}
