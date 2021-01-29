using System;
using Law_data_ns;


namespace obszary_covid_jpp
{
    internal partial class Edit
    {
        internal class DelLawhor
        {
            Areas.Areas areas;
            Searcher searcher = new Searcher();
            internal DelLawhor(Areas.Areas areas)
            {
                this.areas = areas;
            }
            internal void Show()
            {
                Console.Clear();
                Console.WriteLine("Podaj nazwe usuwanego prawa");
                HorLawdata Law = searcher.SearchLawhor();
                areas.DeleteLawhor(Law.Id);
            }
        }


    }
}