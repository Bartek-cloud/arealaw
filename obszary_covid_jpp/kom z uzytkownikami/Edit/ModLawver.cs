
using System;

using Area_date_ns;
using menu;
namespace obszary_covid_jpp
{
    internal class ModLawver
    {
        Areas.Areas areas;
        Searcher searcher = new Searcher();
        Suportfunction suportfunction = new Suportfunction();
        internal ModLawver(Areas.Areas areas)
        {
            this.areas = areas;
        }
        internal void Show()
        {
            Console.Clear();
            Area_date varae = new Area_date();
            Console.WriteLine("Prawo kturego obszaru chezs zmodyfikowac");
            Area_date arealaw = searcher.Search(0, 1, varae);
            var law = areas.Find_local_law(arealaw.Id);
            var adddelemen = new Menu(new string[] { "dodaj doc", "dodaj usun" }, 0, 4);
            int adddele = adddelemen.Show();
            var modechangemenu = Menuform.Menu_yn(0, 7);
            switch (adddele)
            {
                case 1:
                    HandcreateDochor createhor = new HandcreateDochor(areas);
                    createhor.Show(law.Id);
                    break;

                case 2:
                    DelDoc deldoc = new DelDoc(areas);
                    deldoc.DelDocVer(areas, law, 0, 12);
                    break;
            }
        }
    }
}
