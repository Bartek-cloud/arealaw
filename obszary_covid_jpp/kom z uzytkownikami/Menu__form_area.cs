//using obszary_covid_jpp_areas;
using menu;
using Area_date_ns;
using System.Collections.Generic;
using Law_ns;
using System;
using Law_data_ns;

namespace obszary_covid_jpp
{
    static class Menu_form_area
    {
        public static Menu List_to_menu(List<Area_date> areaDataList, int position_x, int position_y)//swoja droga mozna zrobic temeplate takiej funkcji?
        {
            int numberOfArea = areaDataList.Count;
            string[] name_areas_tab = new string[numberOfArea+1];
            name_areas_tab[0] = "zakoncz";
            for (int i=1;i <= numberOfArea ; i++)
            {
                name_areas_tab[i] = areaDataList[i-1].Name + " " + areaDataList[i-1].differential_name;
            }
            
            Menu menu_areas = new Menu(name_areas_tab, position_x, position_y);
            menu_areas.Shower = new Showernoclear();
            return menu_areas;
        }


        public static Menu Law_to_menu(VerLawdata law, int position_x, int position_y)
        {
            int numberOfDocument = law.List_document.Count;
            string[] name_areas_tab = new string[numberOfDocument + 1];
            name_areas_tab[0] = "zakoncz";
            for (int i = 1; i <= numberOfDocument; i++)
            {
                name_areas_tab[i] = law.List_document[i - 1].title;
            }

            Menu menu_areas = new Menu(name_areas_tab, position_x, position_y);
            return menu_areas;
        }
        public static Menu Law_to_menu(HorLawdata law, int position_x, int position_y)
        {
            int numberOfDocument = law.List_document.Count;
            string[] name_areas_tab = new string[numberOfDocument + 1];
            name_areas_tab[0] = "zakoncz";
            for (int i = 1; i <= numberOfDocument; i++)
            {
                name_areas_tab[i] = law.List_document[i - 1].title;
            }

            Menu menu_areas = new Menu(name_areas_tab, position_x, position_y);
            return menu_areas;
        }
     
        public static Menu DocList_to_menu(List<Document>doclist, int position_x, int position_y)
        {
            int numberOfDocument = doclist.Count;
            string[] name_areas_tab = new string[numberOfDocument + 1];
            name_areas_tab[0] = "zakoncz";
            for (int i = 1; i <= numberOfDocument; i++)
            {
                name_areas_tab[i] = doclist[i - 1].title;
            }

            Menu menu_areas = new Menu(name_areas_tab, position_x, position_y);
            return menu_areas;
        }





    }
}
