//using obszary_covid_jpp_areas;
using Area_date_ns;
using menu;
using System;

namespace obszary_covid_jpp
{

        //static class Editfunction {
    internal class MakeLawHor
    {
        Areas.Areas areas;
        Suportfunction suportfunction = new Suportfunction();
        Searcher search = new Searcher();
        HandcreateDochor createdoc;
        internal MakeLawHor(Areas.Areas areas)
        {
            this.areas = areas;
            createdoc = new HandcreateDochor(areas);
        }
        //Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message
        internal void Show()
        {
           
            Console.Clear();
            Console.WriteLine("Podaj nazwe");
            string name = Console.ReadLine();
            int id = areas.createhorlav(name);
            Console.WriteLine("ktorego obszaru bedzie dotyczyło");
            int yn = 0;
            Menu menuyn;
            //int lawid = 0;
            do
            {
                var virarea = new Area_date(0, "", "", 0, "");
                var selarea = search.Search(0, 3, virarea);
                if (selarea == virarea) { return; }
                areas.addareatolawhor(id, selarea.Id);
                Console.WriteLine("dodac wiecej obszrow?");
                menuyn = Menuform.Menu_yn(0, 10);
                yn = menuyn.Show();

            } while (yn == 0);
            Console.WriteLine("dodaj documenty do prawa");
            do
            {
                createdoc.Show(id);
                Console.WriteLine("dodac wiecej?");
                yn = menuyn.Show();
            } while (yn == 0);

        }
    }  









    // }
    
}
