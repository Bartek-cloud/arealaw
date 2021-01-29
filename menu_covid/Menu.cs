using System;
using System.Collections.Generic;

namespace menu
{
    public partial class Menu
    {
        internal string[] elementy;
        internal int dlugosc_maks_elementu;
        internal MenuShower shower = new MenuShower();
        public bool visible=true;
        public int DlugoscMaxElement
        {
            get
            {
                return dlugosc_maks_elementu;
            }

            protected set
            {
                dlugosc_maks_elementu = value;
            }
        }
        public MenuShower Shower
        {
            get { return shower; }
            set { shower = value; }
        }
        public int Posx, Posy;


        public static ConsoleColor DeflautBackcol = ConsoleColor.DarkGreen;
        public static ConsoleColor DeflautBackcolhos = ConsoleColor.Green;
        public static ConsoleColor DeflautForecol = ConsoleColor.Gray;
        public static ConsoleColor DeflautForecolhos = ConsoleColor.White;
        internal ConsoleColor Backcol_hos = DeflautBackcolhos, Forecol_hos = DeflautForecolhos, Backcol = DeflautBackcol, Forecol = DeflautForecol;
        
        protected int wybrany = 0;
        public int Wybrany
        {
            get
            {
                return wybrany;
            }
            set
            {
                if (0 <= value && value <= elementy.Length)
                {
                    wybrany = value;
                }

            }
        }
        //kontruktor klasy
        public Menu(string[] dane) : this(dane, 0, 0)
        {
        }
        public Menu(List<string> dane) : this(dane, 0, 0)
        {
        }
        public Menu(List<string> dane, int positon_x, int positon_y) : this(dane.ToArray(), positon_x, positon_y)
        {
        }
        public Menu(string[] dane, int positon_x, int positon_y)
        {
            this.Posx = positon_x;
            this.Posy = positon_y;

            elementy = dane;
            AdjustDlugoscMaxElement();
        }
        protected void AdjustDlugoscMaxElement()
        {
            DlugoscMaxElement = elementy[0].Length;
            for (int i = 1; i < elementy.Length; i++)
            {
                if (DlugoscMaxElement < elementy[i].Length)
                {
                    DlugoscMaxElement = elementy[i].Length;
                }
            }
        }
        public void Refresh_string(string[] dane) {
            elementy = dane;
            AdjustDlugoscMaxElement();
        }

        public virtual int Show()
        {
            if (visible == true)
            {
                return Shower.Show(this);
            }
            else return -1;
        }
    }











    //horizontal menu?
}
