
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Law_data_ns;
using menu;
namespace obszary_covid_jpp
{
    internal class ModLawhor
    {
        Areas.Areas areas;
        Searcher searcher = new Searcher();
        Suportfunction suportfunction = new Suportfunction();
        internal ModLawhor(Areas.Areas areas)
        {
            this.areas = areas;
        
        
        }
        internal void Show()
        {
            Console.Clear();
            HorLawdata Law = searcher.SearchLawhor();
            var adddelemen = new Menu(new string[] { "dodaj doc", " usun doc ", "dodaj obszar", "usun obszar" }, 0, 3);
            int adddele = adddelemen.Show();
            var modechangemenu = Menuform.Menu_yn(0, 8);
            switch (adddele)
            {
                case 0:
                    HandcreateDochor hand = new HandcreateDochor(areas);
                    hand.Show(Law.Id);
                    break;
                case 1:
                    DelDoc deldoc = new DelDoc(areas);
                    deldoc.DelDocHor(areas, Law,0,10);
                    break;
                case 2:
                    addarea_horlaw(areas, Law);
                    break;
                case 3:
                    delarea_horlaw(areas, Law);
                    break;

            }
        }
        /*
        private static void Modlawselect(Areas.Areas areas)
        {
            Menu typemenu = new Menu(new string[] { "pionowe", "poziome" }, 0, 0);
            int type = typemenu.Show();
            if (type == 1)
            {
                ModLawhor(areas);
            }
            else
            {
                ModLawver(areas);
            }
        }
        */
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

        internal void addarea_horlaw(Areas.Areas areas, HorLawdata law)
        {
            HandcreateDochor createdoc = new HandcreateDochor(areas);
            //areas.delareahorlaw(law.Id,selecteddoc-1);
            createdoc.Show(law.Id);
        }

    }
}
