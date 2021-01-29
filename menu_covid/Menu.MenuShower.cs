using System;

namespace menu
{
    public partial class Menu
    {

        public class MenuShower
        {
            public virtual int Show(Menu menu){
                Console.CursorVisible = false;
               
                ConsoleColor startback = Console.BackgroundColor;
                ConsoleColor startfore = Console.ForegroundColor;
                ConsoleKeyInfo znak = new ConsoleKeyInfo();
                while (znak.Key != ConsoleKey.Enter && znak.Key != ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(menu.Posx, menu.Posy);
                    int positon_y_i = menu.Posy;
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

                        Console.SetCursorPosition(menu.Posx, positon_y_i);
                        positon_y_i += 1;
                        Console.WriteLine(menu.elementy[i].PadRight(menu.DlugoscMaxElement));
                    }

                    znak = Console.ReadKey(true);
                    if (znak.Key == ConsoleKey.UpArrow && menu.wybrany > 0)
                    {
                        menu.Wybrany--;
                    }
                    else if (znak.Key == ConsoleKey.DownArrow && menu.wybrany < menu.elementy.Length - 1)
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
                Console.Clear();
                return menu.Wybrany;
                

            }
        
        
        }
    }











    //horizontal menu?
}
