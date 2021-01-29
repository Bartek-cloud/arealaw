//using obszary_covid_jpp_areas;
using Area_date_ns;
using Law_data_ns;
using menu;
using System;
using System.Collections.Generic;

namespace obszary_covid_jpp
{
    class Searcher
    {
        Areas.Areas areas = Program.areas;
        internal Area_date Search(int posx, int posy, Area_date current_area)
        {
            Console.SetCursorPosition(posx, posy);

            string area_name = Console.ReadLine();
            List<Area_date> area_list = areas.Search(area_name);//area jest od 0
            Menu menusearch = Menu_form_area.List_to_menu(area_list, posx + area_name.Length, posy + 1);
            int selected = menusearch.Show();
            if (selected == 0 || selected == -1)
            {
                return current_area;
            }
            else //if (selected >= 1 && selected <= area_list.Count)
            {
                return area_list[selected - 1];
            }

        }
        internal HorLawdata SearchLawhor()
        {
            Console.WriteLine("podaj nazwe");
            string name = Console.ReadLine();
            return areas.find_hor_law(name);
        }
    }
}
