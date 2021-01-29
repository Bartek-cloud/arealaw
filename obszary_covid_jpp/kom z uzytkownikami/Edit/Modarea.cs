//using obszary_covid_jpp_areas;
using Area_date_ns;
using menu;
using System;


namespace obszary_covid_jpp
{
    class Modarea
    {
        Areas.Areas areas;
        Searcher seracher = new Searcher();
        Suportfunction suportfunction = new Suportfunction();
        internal Modarea(Areas.Areas areas)
        {
            this.areas = areas;
        }
        internal void Show()
        {
            Console.Clear();

            var virarea = new Area_date(0, "", "", 0, "");
            Console.WriteLine("Ktory obszar chesz zmodyifikowac");
            Area_date modifiedarea = seracher.Search(0, 1, virarea);
            if (modifiedarea == virarea) { return; }
            Menu Whatchange = new Menu(new string[] { "nazwe", "nazwe rozncujaca", "wyższy obszar", "zakoncz" }, 0, 8);
            var morechange = Menuform.Menu_yn(0, 13);
            int more = 1;
            do
            {
                suportfunction.Show_area_date(modifiedarea, areas);
                int what = Whatchange.Show();
                switch (what)
                {
                    case 0:
                        string newname = Console.ReadLine();
                        areas.UpdateName(modifiedarea.Id, newname);
                        break;
                    case 1:
                        string newdifname = Console.ReadLine();
                        areas.UpdateDifName(modifiedarea.Id, newdifname);
                        break;
                    case 2:
                        string newhigherstring = Console.ReadLine();
                        int newhigher = 0;
                        if (Int32.TryParse(newhigherstring, out newhigher))
                        {
                            areas.Updatehigher(modifiedarea.Id, newhigher);
                        }
                        break;
                    case 3:
                        more = 1;
                        break;
                }
                if (0 <= what && what <= 3)
                {
                    Console.WriteLine("Czy chesz dokonac wiecej zmian?");
                    more = morechange.Show();
                }
            } while (more == 0);
        }
    }
}