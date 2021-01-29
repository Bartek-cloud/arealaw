
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Area_date_ns;
namespace obszary_covid_jpp
{


    internal class MakeDocumentto {
        Areas.Areas areas;
        internal MakeDocumentto(Areas.Areas areas)
        {
            this.areas = areas;

        }

        internal void Show()
        {
            Console.Clear();
            var virarea = new Area_date(0, "", "", 0, "");
            Searcher search = new Searcher();
            //bool end=false;
            Console.WriteLine("podaj nazwe obszaru jaki dotyczy");
            Area_date selected_area = search.Search(0, 0, virarea);
            if (selected_area == virarea) { return; }
            handcreateDocver(areas, selected_area.Id);
        }
        internal void handcreateDocver(Areas.Areas areas, int lawid)
        {
            string name;
            Console.Clear();
            Suportfunction suportfunction = new Suportfunction();
            do
            {
                Console.WriteLine("podaj nazwe");
                name = Console.ReadLine();
            } while (!suportfunction.nameverifcation(name));
            Console.WriteLine("podaj krotki opis");
            string brief = Console.ReadLine();
            Console.WriteLine("podaj link");
            string link = Console.ReadLine();
            /*
            if (!areas.IsLaw(link))
            {
                Console.WriteLine("takie prawo istnieje");
                areas.Showdoc(link);
                Console.ReadKey();
                return;
            }*/

            Console.WriteLine("podaj tagi odzielone przecinkami");
            string tags = Console.ReadLine();
            string[] tagstab = tags.Split(',');
            tags = "";
            for (int i = 0; i < tagstab.Length; i++)
            {
                tags = tags + tagstab[i].Trim() + ", ";
            }
            areas.MakeLawver(lawid, name, brief, link, tags);
        }
    }
}
