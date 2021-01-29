using System.Collections.Generic;

using Law_ns;
using sql_lib_pierwsze_podejscie;
using Area_date_ns;
using Area_creator_ns;
using System;

namespace Area_ns
{
    abstract class Area
    {
        static Sql_area SQL=Sql_area.GetInstance();

        public static string[] Typ =
        {
            "null",
            "Country",
            "Province",
            "District",
            "Commune"
        };

        public readonly int Id;
        public readonly string Name;
        public string differential_name;    
        protected readonly int id_higher;

        public abstract int   Type { get; }
        public readonly bool Sex = true;
        public abstract string Get_Higer_type_name();
        public abstract List<string> GetLowerTypeName();
        public virtual List<Area_date> Load_lower()
        {
                string search_query = $"SELECT * FROM areas WHERE Higher_id = {Id}";
                Sql_area SQL = Sql_area.GetInstance();
                return SQL.Query_multi_col_areadate(search_query);
        }
        public virtual Area Load_Higher()
        {
            return Area_creator.Atri_to_area(id_higher);
        }

        public Vertical_law Load_all_vertical_law()
        {
            Vertical_law result = new Vertical_law(Id);
            if (Type != 1&&id_higher!=0)
            {
                Area higher_area = this.Load_Higher();
                result += higher_area.Load_all_vertical_law();
            }
            return result;
        }
        internal static Area_date Load_Self_date(int id)
        {
            string search_query = $"SELECT * FROM areas WHERE id = '{id}'";
            Sql_area SQL = Sql_area.GetInstance();
            return SQL.Query_multi_col_areadate_one(search_query);
        }
        internal static List<string> Load_Self_List(int id)
        {
            string search_query = $"SELECT * FROM areas WHERE id = '{id}'";
            Sql_ms SQL = Sql_ms.GetInstance();
            return SQL.Query_multi_col_one(search_query);
        }
        //public abstract Area Load_all_law();

        public Area(List<string> atribute_list)//zopytmalizowac nie same stringi
        {
            
            Id = int.Parse(atribute_list[0]);
            Name = atribute_list[1];
            differential_name = atribute_list[2];
            if (atribute_list[3] != "")
            {
                id_higher = int.Parse(atribute_list[3]);
            }
            else { id_higher = 0; }
        }
        public Area(int id) : this(Load_Self_List(id))
        {
        }
        public Area(Area_date date)
        {
            Id = date.Id;
            Name = date.Name;
            differential_name = date.differential_name;
            id_higher = date.id_higher;
        }
        public Area_date ToAreaDate()
        {
            return new Area_date(Id, Name, differential_name, id_higher, Typ[Type]); ;//jaki typ to zalezy
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
