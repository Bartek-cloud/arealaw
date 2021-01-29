using System.Collections.Generic;
using Area_date_ns;
using System;

using sql_lib_pierwsze_podejscie;
namespace Area_ns
{

    internal class Areasditor
    {
        static Sql_area SQL = Sql_area.GetInstance();
        internal  bool Is(string name_area)
        {
            string search_query = $"SELECT * FROM areas WHERE Name = '{name_area}'";
            Sql_area SQL = Sql_area.GetInstance();
            return SQL.Is(search_query);
        }
        internal bool Is(string name_area, string difname)
        {
            if (difname == "")
            {
                return Is(name_area);
            }
            else
            {
                string search_query = $"SELECT * FROM areas WHERE Name = '{name_area}' AND different name = '{difname}'";
                return SQL.Is(search_query);
            }

        }
  
        internal List<Area_date> Search(string name_area)
        {
            string search_query = $"SELECT * FROM areas WHERE Name = '{name_area}'";
            return SQL.Query_multi_col_areadate(search_query);
        }

        internal List<Area_date> Search(string name_area, string difname)
        {
            if (difname == "")
            {
                return Search(name_area);
            }
            else
            {
                string search_query = $"SELECT * FROM areas WHERE Name = '{name_area}' AND different name = '{difname}'";
                return SQL.Query_multi_col_areadate(search_query);
            }
        }
        internal void Made(string name, string difname, string strhig, string higdif, string type)
        {
            List<Area_date> findedhig = new List<Area_date>(0);
            if (strhig != "")
            {
                findedhig = Search(strhig, higdif);
            }
            int typ = 0;
            for (int i = 0; i < Area.Typ.Length; i++)
            {
                if (Area.Typ[i] == type)
                {
                    typ = i;
                    break;
                }
            }
            if (typ == 0)
            {
                throw new Exception("brak typu");
            }
            if (difname == "")
            {
                difname = " ";
            }
            if (findedhig.Count == 1)
            {
                string querystring = $"INSERT INTO areas (Name,[different name],Higher_id,Type) Values('{name}','{difname}','{findedhig[0].Id}','{typ}')";
                SQL.Nonquery(querystring);
            }
            else {
                string querystring = $"INSERT INTO areas (Name,[different name],Higher_id,Type) Values('{name}','{difname}',NULL,'{typ}')";
                SQL.Nonquery(querystring);
            }

        }
        internal void UpdateName(int areaid, string newname)
        {
            string updateareaname = $"UPDATE areas SET Name = {newname} WHERE Id = '{areaid}' ";
            SQL.Nonquery(updateareaname);
        }

        internal void UpdateDifName(int id, string newdifname)
        {
            string updateareaname = $"UPDATE areas SET [different name] = '{newdifname}' WHERE Id = '{id}'";
            SQL.Nonquery(updateareaname);
        }

        internal void Delete(int id)
        {
            string updateareaname = $"DELETE FROM areas WHERE Id = '{id}'";
            SQL.Nonquery(updateareaname);
        }
    }


}
