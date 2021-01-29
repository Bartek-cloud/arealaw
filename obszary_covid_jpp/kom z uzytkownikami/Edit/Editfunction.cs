//using obszary_covid_jpp_areas;
using Area_date_ns;
using menu;
using System;

namespace obszary_covid_jpp
{
    internal static class Editmainfunction
    {
        //static class Editfunction {







        internal static void MakeLawHor(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwe");
            string name = Console.ReadLine();
            int id=areas.createhorlav(name);
            Console.WriteLine("ktorego obszaru bedzie dotyczyło");
            int yn = 0;
            Menu menuyn;
            //int lawid = 0;
            do
            {
                var virarea = new Area_date(0, "", "", 0, "");
                var selarea = Program_function.Search(areas, virarea, 0, 3, message);
                if (selarea == virarea) { return; }
                //Console.WriteLine("podaj nazwe obszaru jakiego dotyczy");
                //Area_date area = Program_function.Search(areas,current_area,0,8,message);
                areas.addareatolawhor(id, selarea.Id);
                Console.WriteLine("dodac wiecej obszrow?");
                menuyn = Menuform.Menu_yn(0, 10);
                yn = menuyn.Show();

            } while (yn == 0);
            Console.WriteLine("dodaj documenty do prawa");
            do
            {
                MakeDocument.handcreateDochor(areas,id);

                Console.WriteLine("dodac wiecej?");
                yn = menuyn.Show();
            } while (yn == 0);
        }        
        static internal string Createtags()
        {
            Console.WriteLine("podaj tagi odzielone przecinkami");
            string tags = Console.ReadLine();
            string[] tagstab = tags.Split(',');
            tags = "";
            for (int i = 0; i < tagstab.Length; i++)
            {
                tags = tags + tagstab[i].Trim() + ", ";
            }
            return tags;
        }
        internal static bool Linkverfication()
        {
            return true;
        }
        internal static bool nameverifcation()
        {
            return true;
        }






        // }
    }
}
