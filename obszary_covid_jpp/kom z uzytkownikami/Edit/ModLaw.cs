
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Area_date_ns;
using Law_data_ns;
using menu;
namespace obszary_covid_jpp
{
    internal static class ModLaw
    {
        internal static void ModLawhor(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            HorLawdata Law = Program_function.SearchLawhor(areas, current_area, dlugoscMaxElement, posnewmenu, message);
            var adddelemen = new Menu(new string[] { "dodaj doc", " usun doc ","dodaj obszar","usun obszar" }, 0, 0);
            int adddele = adddelemen.Show();
            var modechangemenu = Menuform.Menu_yn(posnewmenu, 0);
            switch (adddele)
            {
                case 1:
                    MakeDocument.handcreateDocver(areas, Law.Id);
                    break;

                case 2:
                    ModDoc.DelDocHor(areas, Law);
                    break;
                case 3:
                    addarea_horlaw(areas, Law);

                    break;
                case 4:
                    delarea_horlaw(areas, Law);
                    break;

            }
        }
        private static void Modlawselect(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Menu typemenu = new Menu(new string[] { "pionowe", "poziome" }, 0, 0);
            int type = typemenu.Show();
            if (type == 1)
            {
                ModLawhor(areas, current_area, dlugoscMaxElement, posnewmenu, message);
            }
            else
            {
                ModLawver(areas, current_area, dlugoscMaxElement, posnewmenu, message);
            }
        }

        internal static void delarea_horlaw(Areas.Areas areas, HorLawdata law)
        {
            Console.Clear();
            var selectdoc = Menu_form_area.Law_to_menu(law, 0, 0);
            int selecteddoc = selectdoc.Show();
            if (selecteddoc == 0 || selecteddoc == 1)
            {
                return;
            }
            areas.DeleteDochorlaw(law.List_document[selecteddoc - 1].id, law.Id);
        }

        internal static void addarea_horlaw(Areas.Areas areas, HorLawdata law)
        {
            MakeDocument.handcreateDochor(areas,law.Id);
            //areas.delareahorlaw(law.Id,selecteddoc-1);
        }

        internal static void ModLawver(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            Area_date varae = new Area_date();
            Console.WriteLine("Prawo kturego obszaru chezs zmodyfikowac");
            Area_date arealaw = Program_function.Search(areas, varae, dlugoscMaxElement, posnewmenu, message);
            var law = areas.Find_local_law(arealaw.Id);
            var adddelemen = new Menu(new string[] { "dodaj doc", "dodaj usun" }, 0, 0);
            int adddele = adddelemen.Show();
            var modechangemenu = Menuform.Menu_yn(posnewmenu, 0);
            switch (adddele)
            {
                case 1:
                    MakeDocument.handcreateDocver(areas, law.Id);
                    break;

                case 2:
                    ModDoc.DelDocVer(areas, law);
                    break;
            }
        }
        internal static void DelLawver(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            var virarea = new Area_date(0, "", "", 0, "");
            Console.WriteLine("Podaj nazwe usuwanego prawa");
            var areasel = Program_function.Search(areas, virarea,0,0, message);
            Console.Clear();
            if (areasel == virarea) { return; }
            var locallaw =areas.Find_local_law(areasel.Id);
            var doc = Program_function.SelectDoc(locallaw, 0, 0);
            areas.DeleteLawver(doc.id);
        }

        internal static void DelLawhor(Areas.Areas areas, Area_date current_area, int dlugoscMaxElement, int posnewmenu, string message)
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwe usuwanego prawa");
            HorLawdata Law = Program_function.SearchLawhor(areas, current_area, 0, 0, message);
            areas.DeleteLawhor(Law.Id);
        }




    }
}
