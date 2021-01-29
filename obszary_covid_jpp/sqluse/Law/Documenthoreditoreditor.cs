
using sql_lib_pierwsze_podejscie;
using System;

namespace Law_ns
{
    public class Documenthoreditor
    {
        static Sql_ms SQL = Sql_area.GetInstance();
        internal void DeleteHorlawdoc(int id)
        {
            string Deletehorlawstring = $"DELETE FROM documents_hor WHERE law_id ='{id}'";
            SQL.Nonquery(Deletehorlawstring);
        }

        internal void Createhor(int lawid, string name, string brief, string link, string tags)
        {

            string Addnewdoc = $"INSERT INTO documents_hor VALUES (null,{lawid},{name},{brief},{link},{tags}) ";
            SQL.Nonquery(Addnewdoc);
        }
        internal void UpdateTitlehor(int docid, string newname)
        {
            string udaptedoc = $"UPDATE documents_hor SET title = '{newname}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }

        internal void Updatebriefhor(int docid, string newbrief)
        {
            string udaptedoc = $"UPDATE documents_hor SET brief = '{newbrief}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }

        internal void Updatelinkhor(int docid, string newlink)
        {
            string udaptedoc = $"UPDATE documents_hor SET reference = '{newlink}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }

        internal void Updatetaghor(int docid, string tags)
        {
            string udaptedoc = $"UPDATE documents_hor SET tags = '{tags}' WHERE Id = '{docid}' ";
            SQL.Nonquery(udaptedoc);
        }
    }
}
