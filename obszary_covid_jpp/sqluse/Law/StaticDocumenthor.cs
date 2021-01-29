
using sql_lib_pierwsze_podejscie;
using System;

namespace Law_ns
{
    public static class StaticDocumenthor
    {
        static Sql_ms SQL = Sql_area.GetInstance();
        internal static void DeleteHorlawdoc(int id)
        {
            string Deletehorlawstring = $"DELETE FROM documents_hor WHERE law_id ='{id}'";
            SQL.Nonquery(Deletehorlawstring);
        }

        internal static void Createhor(int lawid, string name, string brief, string link, string tags)
        {
            string Addnewdoc = $"INSERT INTO documents_hor VALUES (null,{lawid},{name},{brief},{link},{tags}) ";
            SQL.Nonquery(Addnewdoc);
        }
        internal static void UpdateTitlehor(int docid, string newname)
        {
            string udaptedoc = $"UPDATE documents_hor SET title = '{newname}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }

        internal static void Updatebriefhor(int docid, string newbrief)
        {
            string udaptedoc = $"UPDATE documents_hor SET brief = '{newbrief}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }

        internal static void Updatelinkhor(int docid, string newlink)
        {
            string udaptedoc = $"UPDATE documents_hor SET reference = '{newlink}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }

        internal static void Updatetaghor(int docid, string tags)
        {
            string udaptedoc = $"UPDATE documents_hor SET tags = '{tags}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }
    }
}
