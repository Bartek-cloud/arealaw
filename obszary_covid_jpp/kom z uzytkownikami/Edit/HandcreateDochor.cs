
using System;
namespace obszary_covid_jpp
{
    internal class HandcreateDochor
    {
        Areas.Areas areas;
        Suportfunction suportfunction = new Suportfunction();
        internal HandcreateDochor(Areas.Areas areas)
        {
            this.areas = areas;

        }
        internal void Show(int lawid)
        {
            string name;
            Console.Clear();
     
            do
            {
                Console.WriteLine("podaj nazwe");
                name = Console.ReadLine();
            } while (!suportfunction.nameverifcation(name));
            Console.WriteLine("podaj krotki opis");
            string brief = Console.ReadLine();
            Console.WriteLine("podaj link");
            string link = Console.ReadLine();
            if (areas.IsLaw(link))
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
