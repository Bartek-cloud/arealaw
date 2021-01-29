using System;
//using Law_ns;
using Law_data_ns;

namespace obszary_covid_jpp
{

    internal class DelDoc
    {
        Areas.Areas areas;
        Suportfunction suportfunction = new Suportfunction();
        internal DelDoc(Areas.Areas areas)
        {
            this.areas = areas;
        }
        internal void DelDocVer(Areas.Areas areas, VerLawdata law, int posx, int posy)
        {
            Console.Clear();
            Document doc = suportfunction.SelectDoc(law, posx, posy);
            areas.DeleteLawver(doc.id);



        }
        internal void DelDocHor(Areas.Areas areas, HorLawdata law, int posx, int posy)
        {
            Console.Clear();
            Document doc = suportfunction.SelectDoc(law, posx, posy);
            areas.DeleteDochorlaw(doc.id, law.Id);
        }
    }
    
}
