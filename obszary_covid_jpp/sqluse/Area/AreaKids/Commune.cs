using System;
using System.Collections.Generic;
using Area_date_ns;

namespace Area_ns
{
    class Commune : Area
    {
        public static new readonly bool Sex = false;
        public Commune(List<string> atribute_list) : base(atribute_list)
        {       }
        public Commune(int id) : base(id) { }
        public Commune(Area_date date) : base(date) { }
        public override int Type { get { return 4; } }
        public override string Get_Higer_type_name()
        {
            return "district";
        }
        public override List<string> GetLowerTypeName()
        {
            throw new Exception("don't have a area lower commune");
        }
        public override List<Area_date> Load_lower()
        {
            throw new Exception("can't load a area lower commune");
        }
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
