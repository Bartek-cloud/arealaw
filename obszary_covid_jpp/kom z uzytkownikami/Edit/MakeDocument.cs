
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Area_date_ns;
namespace obszary_covid_jpp
{

    internal static class MakeDocument
    {
        internal static void MakeDocumentto(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            var virarea = new Area_date(0, "", "", 0, "");
            //bool end=false;
            Console.WriteLine("podaj nazwe obszaru jaki dotyczy");
            Area_date selected_area = Program_function.Search(areas, virarea, 0, 0, message);
            if (selected_area == virarea) { return; }
            handcreateDocver(areas, selected_area.Id);
        }
        internal static void handcreateDocver(Areas.Areas areas, int lawid)
        {
            string name;
            Console.Clear();
            do
            {
                Console.WriteLine("podaj nazwe");
                name = Console.ReadLine();
            } while (!Editmainfunction.nameverifcation());
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
        internal static void handcreateDochor(Areas.Areas areas, int lawid)
        {
            string name;
            Console.Clear();
            do
            {
                Console.WriteLine("podaj nazwe");
                name = Console.ReadLine();
            } while (!Editmainfunction.nameverifcation());
            Console.WriteLine("podaj krotki opis");
            string brief = Console.ReadLine();
            Console.WriteLine("podaj link");
            string link = Console.ReadLine();
            if (!areas.IsLaw(link))
            {
                Console.WriteLine("takie prawo istnieje");
                areas.Showdoc(link);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("podaj tagi odzielone przecinkami");
            string tags = Console.ReadLine();
            string[] tagstab = tags.Split(',');
            tags = "";
            for (int i = 0; i < tagstab.Length; i++)
            {
                tags = tags + tagstab[i].Trim() + ", ";
            }
            areas.MakeDocLawhor(lawid, name, brief, link, tags);

        }
    }
}
