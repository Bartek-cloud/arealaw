using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Law_data_ns;
using Area_date_ns;
using menu;
//using Law_ns;
//using Law_ns;

namespace obszary_covid_jpp
{

    internal class Moddochor
    {
        Searcher searcher = new Searcher();
        Suportfunction suportfunction = new Suportfunction();
        Areas.Areas areas;
        internal Moddochor(Areas.Areas areas)
        {
            this.areas = areas;
        }
        internal void Show()
        {
            
            Console.Clear();
            var virarea = new Area_date(0, "", "", 0, "");
            //var modarea = Program_function.Search(areas, virarea, dlugoscMaxElement, posnewmenu, message);
            //if (modarea == virarea) { return; }
            var chosen_law = searcher.SearchLawhor();

            var Document = suportfunction.SelectDoc(chosen_law, 0, 1);
            Document emptydoc = new Document();
            if (Document.id == emptydoc.id)
            {
                return;
            }
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
                        } while (!suportfunction.nameverifcation(newname));
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
                        } while (!suportfunction.Linkverfication(newlink));
                        areas.Updatelinkhor(Document.id, newlink);
                        break;
                    case 3:
                        string tags = suportfunction.Createtags();
                        areas.Updatetaghor(Document.id, tags);
                        break;
                    case 4:
                        return;
                }
                Console.WriteLine("Czy chesz dokonac wiecej zmian?");
                more = morechange.Show();
            } while (more == 0);
        }
    }
}
