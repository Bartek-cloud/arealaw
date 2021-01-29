using System;

using Area_date_ns;
using menu;
//using Law_ns;

namespace obszary_covid_jpp
{
    internal class Moddocver
    {
        Areas.Areas areas;
        Searcher searcher = new Searcher();
        Suportfunction suportfunction = new Suportfunction();
        internal Moddocver(Areas.Areas areas)
        {
            this.areas = areas;
        }
        internal void Show()
        {

            Console.Clear();
            var virarea = new Area_date(0, "", "", 0, "");
            Console.WriteLine("ktorego obszaru prawo chesz modyfikować");
            var modarea = searcher.Search(0, 1, virarea);
            if (modarea == virarea) { return; }
            Console.Clear();
            var chosen_law = areas.Find_local_law(modarea.Id);
            Console.Clear();
            var Document = suportfunction.SelectDoc(chosen_law, 0, 5);

            Menu Whatchange = new Menu(new string[] { "tytul", "obszarprzypisany", "opis", "link", "tagi" }, 0, 10);
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
                        } while (!suportfunction.nameverifcation(newname));
                        areas.UpdateTitleVer(Document.id, newname);
                        break;
                    case 1:
                        var new_area = searcher.Search(0, 0,virarea);
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
                        } while (!suportfunction.Linkverfication(newlink));
                        areas.Updatelinkver(Document.id, newlink);
                        break;
                    case 4:
                        string tags = suportfunction.Createtags();
                        areas.Updatetagver(Document.id, tags);
                        break;
                }
                Console.WriteLine("Czy chesz dokonac wiecej zmian?");
                more = morechange.Show();
            } while (more == 0);
        }
        
    }
}
