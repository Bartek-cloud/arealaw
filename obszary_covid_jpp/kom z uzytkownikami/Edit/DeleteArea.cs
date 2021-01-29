//using obszary_covid_jpp_areas;
using Area_date_ns;
using menu;
using System;


namespace obszary_covid_jpp
{
    internal class DeleteArea
    {
        Areas.Areas areas;
        internal DeleteArea(Areas.Areas areas)
        {
            this.areas = areas;
        }
        internal void Show()
        {
            Suportfunction function = new Suportfunction();
            Searcher searcher = new Searcher();
            Console.Clear();
            Console.WriteLine("podaj nazwe usuwanego obszaru");
            var virarea = new Area_date(0, "", "", 0, "");
            Area_date deletedarea = searcher.Search(0,1,virarea);
            if (deletedarea == virarea) { return; }
            Console.WriteLine();
            function.Show_area_date(deletedarea, areas);
            var menys = Menuform.Menu_yn(0, 10);
            Console.WriteLine();
            int yn = menys.Show();
            switch (yn)
            {
                case 0:
                    areas.DeleteArea(deletedarea);
                    break;
                case 1:
                    break;
            }
        }
    }

        
}