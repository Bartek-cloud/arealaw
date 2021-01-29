using System;

namespace obszary_covid_jpp
{

    internal class Hand_made_area
    {
        Areas.Areas areas;
        internal Hand_made_area(Areas.Areas areas)
        {
            this.areas = areas;
        }
        
        internal void Show()
        {
            Console.Clear();
            Console.WriteLine("podaj nazwe");
            string name = Console.ReadLine();
            Console.WriteLine("podaj nazwe rozniujaco jesli potrzeba");
            string difname = Console.ReadLine();
            while (areas.Isarea(name, difname))
            {
                Console.WriteLine("podaj inną nazwe");
                name = Console.ReadLine();
                Console.WriteLine("podaj nazwe rozniujaco jesli potrzeba");
                difname = Console.ReadLine();
            }
            Console.WriteLine("podaj typ");
            string type = Console.ReadLine();

            while (!Program.PolAngMianownik.ContainsKey(type))
            {
                Console.WriteLine("błedna nazwa typu podaj dozwolony typ");
                type = Console.ReadLine();
            }
            string typang = Program.PolAngMianownik[type];
            Console.WriteLine("podaj nazwe obszru wyżej admistracyjnie jesli istnieje");
            string higstr = "";
            higstr = Console.ReadLine();
            string namedifhig = "";
            while (!areas.Isarea(higstr) && higstr != "")
            {
                Console.WriteLine("brak tworu o takiej nazwie podaj istnejaca");
                higstr = Console.ReadLine();
                Console.WriteLine("podaj nazwe rozniujaco jesli potrzeba");
                namedifhig = Console.ReadLine();
            }



            areas.MadeArea(name, difname, higstr, namedifhig, typang);
            //return areas.Search(name, difname)[0];
        }
    }

    
}