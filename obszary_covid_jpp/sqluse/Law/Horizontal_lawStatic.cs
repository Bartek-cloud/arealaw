﻿using sql_lib_pierwsze_podejscie;
using System;

namespace Law_ns
{
    internal static class Horizontal_lawStatic
    {
        static Sql_area SQL = Sql_area.GetInstance();
        internal static Horizontal_law Search(int areaid)
        {
            string areaidsearchquery = $"SELECT Id FROM Horizontal_Law WHERE area_id LIKE '%,{areaid},%' OR area_id LIKE '{areaid},%' OR area_id LIKE '%,{areaid}' Or area_id LIKE '{areaid}'";//tak znowu nieptymalne
            int id = SQL.Query_scalar(areaidsearchquery);
            return new Horizontal_law(id);//tak mi teraz przyszło do głowy czy ja to zapewniam przy wpisywaniu
        }

        internal static void Delete(int id)
        {
            string Deletehorlawstring = $"DELETE FROM Horizontal_Law WHERE Id ='{id}'";
            SQL.Nonquery(Deletehorlawstring);
            StaticDocumenthor.DeleteHorlawdoc(id);
        }

        internal static int Create(string name)
        {
            ///
            /// return id belongs to new law
            ///

            string Addnewlaw = $"INSERT INTO Horizontal_Law (Name) VALUES ('{name}') ";
            SQL.Nonquery(Addnewlaw);
            string queryid = $"SELECT Id FROM Horizontal_Law WHERE Name='{name}'";
            return SQL.Query_scalar(queryid);
        }

       
    }
}
