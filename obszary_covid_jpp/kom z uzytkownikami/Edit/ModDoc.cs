using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Area_date_ns;
using menu;
//using Law_ns;
using Law_data_ns;
using Law_ns;

namespace obszary_covid_jpp
{
    internal static class ModDoc
    {
        internal static void Moddochor(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            var virarea = new Area_date(0, "", "", 0, "");
            //var modarea = Program_function.Search(areas, virarea, dlugoscMaxElement, posnewmenu, message);
            //if (modarea == virarea) { return; }
            Console.Clear();
            var chosen_law = Program_function.SearchLawhor(areas, current_area, 0, 1, message);
            Console.Clear();
            var Document = Program_function.SelectDoc(chosen_law, 0, 1);
            Console.Clear();
            Menu Whatchange = new Menu(new string[] { "tytul", "opis", "link", "tagi","powrot" }, 0, 6);
            var morechange = Menuform.Menu_yn(Whatchange.DlugoscMaxElement, 6);
            int more = 0;
            do
            {
                int what = Whatchange.Show();
                switch (what)
                {
                    case 0:

                        string newname;
                        do
                        {
                            Console.WriteLine("podaj nowy tytuł");
                            newname = Console.ReadLine();
                        } while (!Editmainfunction.nameverifcation());
                        areas.UpdateTitlehor(Document.id, newname);
                        break;
                    case 1:
                        Console.WriteLine("podaj nowy opis");
                        string newbrief = Console.ReadLine();
                        areas.Updatebriefhor(Document.id, newbrief);
                        break;
                    case 2:
                        string newlink;
                        do
                        {
                            Console.WriteLine("podaj nowy opis");
                            newlink = Console.ReadLine();
                        } while (!Editmainfunction.Linkverfication());
                        areas.Updatelinkhor(Document.id, newlink);
                        break;
                    case 3:
                        string tags = Editmainfunction.Createtags();
                        areas.Updatetaghor(Document.id, tags);
                        break;
                    case 4:
                        return;
                }
                Console.WriteLine("Czy chesz dokonac wiecej zmian?");
                more = morechange.Show();
            } while (more == 0);
        }



        internal static void Moddocver(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            var virarea = new Area_date(0, "", "", 0, "");
            Console.WriteLine("ktorego obszaru prawo chesz modyfikować");
            var modarea = Program_function.Search(areas, virarea, 0, 1, message);
            if (modarea == virarea) { return; }
            Console.Clear();
            var chosen_law = areas.Find_local_law(modarea.Id);
            Console.Clear();
            var Document = Program_function.SelectDoc(chosen_law, 0, 1);

            Menu Whatchange = new Menu(new string[] { "tytul", "obszarprzypisany", "opis", "link", "tagi" }, 0, 8);
            var morechange = Menuform.Menu_yn(Whatchange.DlugoscMaxElement, 8);
            Console.Clear();
            int more = 0;
            do
            {
                int what = Whatchange.Show();
                switch (what)
                {
                    case 0:

                        string newname;
                        do
                        {
                            Console.WriteLine("podaj nowy tytuł");
                            newname = Console.ReadLine();
                        } while (!Editmainfunction.nameverifcation());
                        areas.UpdateTitleVer(Document.id, newname);
                        break;
                    case 1:
                        var new_area = Program_function.Search(areas, virarea, dlugoscMaxElement, posnewmenu, message);
                        if (virarea != new_area)
                        {
                            areas.Udapteareaselectedver(Document.id, new_area.Id);
                        }
                        break;
                    case 2:
                        Console.WriteLine("podaj nowy opis");
                        string newbrief = Console.ReadLine();
                        areas.Udaptebriefver(Document.id, newbrief);
                        break;
                    case 3:
                        string newlink;
                        do
                        {
                            Console.WriteLine("podaj nowy opis");
                            newlink = Console.ReadLine();
                        } while (!Editmainfunction.Linkverfication());
                        areas.Updatelinkver(Document.id, newlink);
                        break;
                    case 4:
                        string tags = Editmainfunction.Createtags();
                        areas.Updatetagver(Document.id, tags);
                        break;
                }
                Console.WriteLine("Czy chesz dokonac wiecej zmian?");
                more = morechange.Show();
            } while (more == 0);
        }

        internal static void DelDocVer(Areas.Areas areas, VerLawdata law)
        {
            Console.Clear();
            Document doc = Program_function.SelectDoc(law, 0, 0);
            areas.DeleteLawver(doc.id);



        }
        internal static void DelDocHor(Areas.Areas areas, HorLawdata law)
        {
            Console.Clear();
            Document doc = Program_function.SelectDoc(law, 0, 0);
            areas.DeleteDochorlaw(doc.id,law.Id);





        }
    }
}
