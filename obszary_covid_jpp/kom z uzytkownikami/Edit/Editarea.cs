//using obszary_covid_jpp_areas;
using Area_date_ns;
using menu;
using System;


namespace obszary_covid_jpp
{
    internal static class EditArea
    {
        internal static void DeleteArea(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            Console.WriteLine("podaj nazwe usuwanego obszaru");
            var virarea = new Area_date(0, "", "", 0, "");
            Area_date deletedarea = Program_function.Search(areas, virarea, 0, 1, message);
            if (deletedarea == virarea) { return; }
            Show_area_date(deletedarea, areas);
            var menys = Menuform.Menu_yn(0, 8);
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
        internal static Area_date hand_made_area(Areas.Areas areas)
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
            while (!areas.Isarea(higstr)&&higstr!="")
            {
                Console.WriteLine("brak tworu o takiej nazwie podaj istnejaca");
                higstr = Console.ReadLine();
                Console.WriteLine("podaj nazwe rozniujaco jesli potrzeba");
                namedifhig = Console.ReadLine();
            }



            areas.MadeArea(name, difname, higstr, namedifhig, typang);
            return areas.Search(name, difname)[0];
        }


        internal static void Modarea(Areas.Areas areas, Area_date current_area, int DlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            var virarea = new Area_date(0, "", "", 0, "");
            Console.WriteLine("Ktory obszar chesz zmodyifikowac");
            Area_date modifiedarea = Program_function.Search(areas, virarea, 0, 1, message);
            if (modifiedarea == virarea) { return; }
            Menu Whatchange = new Menu(new string[] { "nazwe", "nazwe rozncujaca", "wyższy obszar", "zakoncz" }, 0, 8);
            var morechange = Menuform.Menu_yn(0, 13);
            int more = 1;
            do
            {
                Show_area_date(modifiedarea, areas);
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
                        int newhigher=0;
                        if (Int32.TryParse(newhigherstring, out newhigher))
                        {
                            areas.Updatehigher(modifiedarea.Id, newhigher);
                        }
                        break;
                    case 3:
                        more = 1;
                        break;
                }
                if (0 <= what &&what <= 3)
                {
                    Console.WriteLine("Czy chesz dokonac wiecej zmian?");
                    more = morechange.Show();
                }
            } while (more == 0);
        }

        internal static void Show_area_date(Area_date area, Areas.Areas areas)
        {
            Console.WriteLine($"nazwa {area.Name}");
            Console.WriteLine($"nazwa roznicujaca {area.differential_name}");
            var higher_area = areas.Get_adm_higher(area.id_higher);
            Console.WriteLine($"nazwa wyszego adm {higher_area.Name}");
            Console.WriteLine($"typ {area.Type}");
        }

    }
}