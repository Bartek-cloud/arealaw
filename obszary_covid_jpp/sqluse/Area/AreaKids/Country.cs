using System;
using System.Collections.Generic;
using Area_date_ns;

namespace Area_ns
{
    class Country : Area
    {
        //ze tak poxno wpadlem na leniwa implemtacje
        public Country(List<string> atribute_list) : base(atribute_list) { }
        public Country(int id) : base(id) { }
        public Country(Area_date date) : base(date) { }

        //public static readonly string Type= Type;
        public override string Get_Higer_type_name()
        {
            throw new Exception("don't have a area upper country");
        }
        public override List<string> GetLowerTypeName()
        {
            return new List<string> { "province" };
        }
        public override Area Load_Higher()
        {
            throw new Exception("can't load a area upper country");
        }

        public override int Type { get { return 1; } }
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
