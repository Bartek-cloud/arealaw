using System.Collections.Generic;
using Area_date_ns;

namespace Area_ns
{
    class Province : Area 
    {
        public Province(List<string> atribute_list) : base(atribute_list) { }
        public Province(int id) : base(id) { }
        public Province(Area_date date) : base(date) { }
        public override List<string> GetLowerTypeName()
        {
            return new List<string> { "district" };
        }
        public override string Get_Higer_type_name()
        {
            return "country";
        }
        public override int Type { get { return 2; } }
    }
    /*
    class Gmina : Area { }
    class Powiat : Area { }
    class Dzielnica : Area { }
    class Miasto : Area { }
    class Wojewodztwo : Area { }
    class Panstwo : Area { }
    class Kontynent : Area { };
    class Planeta : Area { };
    //porozumienie prawo poziome
    //panstwo miedzynarodowe // cos jak korona cesarska w ck //np usa zwiazek radziecki
    //organizacia miedzynarodowa // cos jak koalcjia luźna federacjia // np ue onz
    //porzumienie miedzynarodowe// cos jak sojusz obrony//

       Author: Bartłoemiej Szkałuba

            /*
        public virtual bool Sex()
        {
            return true;

        }
        */


    

}
