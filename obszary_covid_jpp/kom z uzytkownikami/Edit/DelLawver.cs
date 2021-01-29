using System;
using Area_date_ns;


namespace obszary_covid_jpp
{
    internal partial class Edit
    {
        internal class DelLawver
        {
            Areas.Areas areas;
            Searcher searcher = new Searcher();
            Suportfunction suportfunction = new Suportfunction();
            internal DelLawver(Areas.Areas areas){
                this.areas = areas;
            }
            internal void Show()
            {
                Console.Clear();
                var virarea = new Area_date(0, "", "", 0, "");
                Console.WriteLine("Podaj nazwe usuwanego prawa");
                var areasel = searcher.Search(0, 0, virarea);
                Console.Clear();
                if (areasel == virarea) { return; }
                var locallaw = areas.Find_local_law(areasel.Id);
                var doc = suportfunction.SelectDoc(locallaw, 0, 0);
                areas.DeleteLawver(doc.id);
            }
        }


    }
}