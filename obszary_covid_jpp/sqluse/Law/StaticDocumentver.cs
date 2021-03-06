﻿using System;
using System.Collections.Generic;

using sql_lib_pierwsze_podejscie;

namespace Law_ns
{
    public static class StaticDocumentver
    {
        static Sql_ms SQL = Sql_area.GetInstance();
        internal static List<string> Show(string link)
        {
            string search_query = $"SELECT * FROM documents WHERE reference = '{link}'";
            return SQL.Query_multi_col_one(search_query);
        }
        internal static bool Isver(string links)
        {
            Sql_area SQL = Sql_area.GetInstance();
            string search_query = $"SELECT * FROM documents WHERE reference = '{links}' ";
            return SQL.Is(search_query); ;
        }
        internal static void UpdateTitleVer(int docid, string newname)
        {
            string udaptedoc = $"UPDATE documents SET title = '{newname}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }
        internal static void Createver(int lawid, string name, string brief, string link, string tags)
        {
            string Addnewdoc = $"INSERT INTO documents VALUES (null,{lawid},{name},{brief},{link},{tags}) ";
            SQL.Nonquery(Addnewdoc);
        }

        internal static void Updateareaselectedver(int docid, int newareaid)
        {
            string udaptedoc = $"UPDATE documents SET Area_id = '{newareaid}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }

        internal static void UpdateBriefVer(int docid, string newbrief)
        {
            string udaptedoc = $"UPDATE documents SET brief = '{newbrief}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }

        internal static void Udaptelink(int id, string newlink)
        {
            string udaptedoc = $"UPDATE documents SET reference = '{newlink}' WHERE Id = '{id}' ";
            SQL.Nonquery(udaptedoc);
        }
        internal static void Udaptetag(int id, string tags)
        {
            string udaptedoc = $"UPDATE documents SET tags = '{ tags}' WHERE Id = '{id}' ";
            SQL.Nonquery(udaptedoc);
        }
        internal static void Deletelawdoc(int id)
        {
            string Deleteverlawstring = $"DELETE FROM documents WHERE Area_id = '{id}'";
            SQL.Nonquery(Deleteverlawstring);
        }
    }
}
