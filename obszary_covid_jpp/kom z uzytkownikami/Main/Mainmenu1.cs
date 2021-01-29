//using obszary_covid_jpp_areas;
using Area_date_ns;
using Areas;
using Law_data_ns;
using Law_ns;
using menu;
using System;
using System.Collections.Generic;

namespace obszary_covid_jpp
{
    public partial class Mainmenu//partial przypadkim odkrylem
    {
        Suportfunction suportfunction = new Suportfunction();
        internal void FindLocalLaw()//main_menu.DlugoscMaxElement menuposy + task)
        {
            VerLawdata local_law = areas.Find_local_law(current_area.Id);  
            List<Document>DocWithTag = suportfunction.TagSearch(local_law, main_menu.DlugoscMaxElement, main_menu.Posy - 2);
            Menu selectmenu = Menu_form_area.DocList_to_menu(DocWithTag, main_menu.DlugoscMaxElement, main_menu.Posy);
            selectmenu.Shower = new Showernoclear();
            Document selected = suportfunction.SelectDoc(selectmenu,local_law);
            //return selected.title+" "+selected.reference;
            Console.Clear();
            if (selected.id != 0)
            {
                //Console.SetCursorPosition(DlugoscMaxElement+selectmenu.DlugoscMaxElement,posnewmenu);
                Console.Write(selected.title + " " + selected.reference);
                Console.ReadKey();
                Console.Clear();
            }
        }
        internal void FindhorLaw()
        {
            HorLawdata law = areas.Find_hor_law(current_area.Id);
            Menu selectmenu = Menu_form_area.Law_to_menu(law, main_menu.DlugoscMaxElement, main_menu.Posy);
            selectmenu.Shower = new Showernoclear();
            //selectmenu.
            Console.SetCursorPosition(main_menu.DlugoscMaxElement, main_menu.Posy);
            var selected = suportfunction.SelectDoc(selectmenu, law);
            Console.Clear();
            if (selected.id == new Document().id)
            {
                return;
            }
            //var selected= SelectDoc(all_law, DlugoscMaxElement, posnewmenu, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, ConsoleColor.Gray);

            //Console.WriteLine(law.Name);
            Console.WriteLine(selected.title);
            Console.WriteLine(selected.reference);
            Console.ReadKey();
            Console.Clear();
        }
        internal void FindAllLaw()
        {
            VerLawdata all_law = areas.Find_all_law(current_area);
            List<Document> DocWithTag = suportfunction.TagSearch(all_law, main_menu.DlugoscMaxElement, main_menu.Posy - 2);
            Menu selectmenu = Menu_form_area.DocList_to_menu(DocWithTag, main_menu.DlugoscMaxElement, main_menu.Posy);
            selectmenu.Shower = new Showernoclear();
            var selected = suportfunction.SelectDoc(selectmenu, all_law);
            //var selected= SelectDoc(all_law, DlugoscMaxElement, posnewmenu, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, ConsoleColor.Gray);
            //Console.SetCursorPosition(DlugoscMaxElement + selectmenu.DlugoscMaxElement, posnewmenu);
            Console.Clear();
            if (selected.id != 0)
            {
                Console.Write(selected.title + " " + selected.reference);
                Console.ReadKey();

                Console.Clear();
            }

        }
        internal void Searchhorlaw()
        {
            Console.SetCursorPosition(main_menu.DlugoscMaxElement, main_menu.Posy);
            string name = Console.ReadLine();
            HorLawdata law = areas.Search_hor_law(name);
            Menu selectmenu = Menu_form_area.Law_to_menu(law, main_menu.DlugoscMaxElement, main_menu.Posy);
            selectmenu.Shower = new Showernoclear();
            //selectmenu.
            Console.SetCursorPosition(main_menu.DlugoscMaxElement, main_menu.Posy);
            var selected = suportfunction.SelectDoc(selectmenu, law);
            Console.Clear();
            if (selected.id == new Document().id) {
                return;
            }
            //var selected= SelectDoc(all_law, DlugoscMaxElement, posnewmenu, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, ConsoleColor.Gray);
            
            //Console.WriteLine(law.Name);
            Console.WriteLine(selected.title);
            Console.WriteLine(selected.reference);
            Console.ReadKey();
            Console.Clear();

        }
        internal Area_date admhigher(Areas.Areas areas, Area_date currentArea, string message)
        {
            Console.Clear();
            if (currentArea.id_higher != 0)
            {
                return areas.Get_adm_higher(currentArea.id_higher);
            }
            else { message = "nie ma wyższych id"; return currentArea; }
            //Console.ReadKey();
        }
        internal Area_date admlover()
        {
            //Console.Clear();
            List<Area_date> area_lover_list = areas.Get_adm_lover(current_area);
            Menu menulover = Menu_form_area.List_to_menu(area_lover_list, main_menu.DlugoscMaxElement, main_menu.Posy);
            int selectedLover = menulover.Show();
            if (selectedLover == 0 || selectedLover == -1)
            {
                return current_area;
            }
            else //if (selectedLover >= 1 && selectedLover <= area_lover_list.Count)
            {
                return area_lover_list[selectedLover - 1];
            }
            //Console.ReadKey();
        }
    }
}
