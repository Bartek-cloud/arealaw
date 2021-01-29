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
    internal static class Program_function//partial przypadkim odkrylem
    {
        internal static Document SelectDoc(VerLawdata local_law, int DlugoscMaxElement, int posnewmenu)
        {
            return SelectDoc(local_law, DlugoscMaxElement, posnewmenu, Menu.DeflautBackcolhos, Menu.DeflautForecolhos, Menu.DeflautBackcol, Menu.DeflautForecol);
        }
        internal static Document SelectDoc(VerLawdata local_law, int DlugoscMaxElement, int posnewmenu, ConsoleColor backcol_hos, ConsoleColor forecol_hos, ConsoleColor backcol, ConsoleColor forecol)
        {
            Menu selectlaw = Menu_form_area.Law_to_menu(local_law, DlugoscMaxElement, posnewmenu);
            return SelectDoc(selectlaw, local_law);
        }
        internal static Document SelectDoc(Menu menu, VerLawdata local_law)
        {
            return SelectDoc(menu, local_law.List_document);
         }
        internal static Document SelectDoc(HorLawdata local_law, int DlugoscMaxElement, int posnewmenu)
        {
            return SelectDoc(local_law, DlugoscMaxElement, posnewmenu, Menu.DeflautBackcolhos, Menu.DeflautForecolhos, Menu.DeflautBackcol, Menu.DeflautForecol);
        }
        internal static Document SelectDoc(HorLawdata local_law, int DlugoscMaxElement, int posnewmenu, ConsoleColor backcol_hos, ConsoleColor forecol_hos, ConsoleColor backcol, ConsoleColor forecol)
        {
            Menu selectlaw = Menu_form_area.Law_to_menu(local_law, DlugoscMaxElement, posnewmenu);
            return SelectDoc(selectlaw, local_law);
        }
        internal static Document SelectDoc(Menu menu, HorLawdata local_law)
        {
            return SelectDoc(menu, local_law.List_document);
        }
        internal static Document SelectDoc(Menu menu, List<Document> list_doc)
        {
            int selec = menu.Show();
            if (selec == 0 || selec == -1)
            {
                return new Document();
            }
            else
            {
                //Console.Clear();
                return list_doc[selec - 1];//Console.WriteLine(local_law.list_document[selec - 1].reference);                                                        //Console.ReadKey();
            }
        }
        internal static List<Document> TagSearch(VerLawdata law, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Aby zwezic wybór podaj tag. W przecwinym wypadku nic nie pisz");
            Console.SetCursorPosition(x, y+1);
            string usertag = Console.ReadLine();

            if (usertag != "")
            {
                List<Document> DocWithTag = new List<Document>();
                foreach (Document doc in law.List_document)
                {
                    foreach (string tag in doc.tags)
                    {
                        if (tag == usertag)
                        {
                            DocWithTag.Add(doc);
                            break;
                        }
                    }
                }
                return DocWithTag;

            }
            else
            {
                return law.List_document;
            }
        }
        internal static void FindLocalLaw(Areas.Areas areas, Area_date current_area, int DlugoscMaxElement, int posnewmenu)//main_menu.DlugoscMaxElement menuposy + task)
        {
            VerLawdata local_law = areas.Find_local_law(current_area.Id);  
            List<Document>DocWithTag = TagSearch(local_law,DlugoscMaxElement,posnewmenu-2);
            Menu selectmenu = Menu_form_area.DocList_to_menu(DocWithTag, DlugoscMaxElement,posnewmenu);
            selectmenu.Shower = new Showernoclear();
            Document selected =SelectDoc(selectmenu,local_law);
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
        internal static void FindhorLaw(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int v, string message)
        {
            HorLawdata law = areas.Find_hor_law(current_area.Id);
            Menu selectmenu = Menu_form_area.Law_to_menu(law, dlugoscMaxElement, v + 1);
            selectmenu.Shower = new Showernoclear();
            //selectmenu.
            Console.SetCursorPosition(dlugoscMaxElement, v);
            var selected = SelectDoc(selectmenu, law);
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
        internal static void FindAllLaw(Areas.Areas areas, Area_date current_area, int DlugoscMaxElement, int posnewmenu, string message)
        {
            VerLawdata all_law = areas.Find_all_law(current_area);
            List<Document> DocWithTag = TagSearch(all_law,DlugoscMaxElement,posnewmenu-2);
            Menu selectmenu = Menu_form_area.DocList_to_menu(DocWithTag, DlugoscMaxElement, posnewmenu);
            selectmenu.Shower = new Showernoclear();
            var selected = SelectDoc(selectmenu, all_law);
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
        internal static void Searchhorlaw(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int v,string message)
        {
            Console.SetCursorPosition(dlugoscMaxElement, v);
            string name = Console.ReadLine();
            HorLawdata law = areas.Search_hor_law(name);
            Menu selectmenu = Menu_form_area.Law_to_menu(law, dlugoscMaxElement, v+1);
            selectmenu.Shower = new Showernoclear();
            //selectmenu.
            Console.SetCursorPosition(dlugoscMaxElement, v);
            var selected = SelectDoc(selectmenu, law);
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

        internal static Area_date Search(Areas.Areas areas, Area_date currentArea, int DlugoscMaxElement, int posnewmenu, string message)
        {
            Console.SetCursorPosition(DlugoscMaxElement, posnewmenu);

                string area_name = Console.ReadLine();//ej i tak działa mimo ze nie ma try catch
                List<Area_date> area_list = areas.Search(area_name);//area jest od 0
                Menu menusearch = Menu_form_area.List_to_menu(area_list, DlugoscMaxElement + area_name.Length, posnewmenu + 1);//tutaj area jest od 1
                int selected = menusearch.Show();
                if (selected == 0 || selected == -1)
                {
                    return currentArea;
                }
                else //if (selected >= 1 && selected <= area_list.Count)
                {
                    return area_list[selected - 1];
                }
            
        }



        internal static Area_date admhigher(Areas.Areas areas, Area_date currentArea, string message)
        {
            Console.Clear();
            if (currentArea.id_higher != 0)
            {
                return areas.Get_adm_higher(currentArea.id_higher);
            }
            else { message = "nie ma wyższych id"; return currentArea; }
            //Console.ReadKey();
        }



        internal static Area_date admlover(Areas.Areas areas, Area_date current_area, int DlugoscMaxElement, int posnewmenu)
        {
            //Console.Clear();
            List<Area_date> area_lover_list = areas.Get_adm_lover(current_area);
            Menu menulover = Menu_form_area.List_to_menu(area_lover_list, DlugoscMaxElement, posnewmenu);
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
        internal static HorLawdata SearchLawhor(Areas.Areas areas, Area_date current_area, int posnewmenu1, int posnewmenu, string message)
        {
            Console.WriteLine("podaj nazwe");
            string name = Console.ReadLine();
            return areas.find_hor_law(name);
        }
        internal static void Show_doc(Document doc)
        {
            Console.WriteLine($"nazwa {doc.title}");
            Console.WriteLine($"nazwa {doc.brief}");
            Console.WriteLine($"nazwa {doc.reference}");
        }


    }
}
