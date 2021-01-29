using System;
using System.Collections.Generic;

using sql_lib_pierwsze_podejscie;
using Law_data_ns;
namespace Law_ns
{
    public class Horizontal_law : Law
    {//horizontal law
        static Sql_area SQL = Sql_area.GetInstance();
        protected string name;
        protected List<int> idarea=new List<int>();
        public List<int> Idarea
        {
            get { return idarea; }
        }
        public string Name
        {
            get { return name; }
        }

        internal Horizontal_law(int id) : base(id)
        {

        }

        protected override void load_self(int id)
        {

            string query = $"SELECT * FROM documents_hor WHERE law_id = '{id}'";

            list_document = SQL.QueryDocumentList(query);

            string queryname_areas = $"SELECT Name, area_id FROM Horizontal_Law WHERE Id = '{id}'";
                
                 
            if (SQL.Is(queryname_areas))
            {
                var name_areas = SQL.Query_multi_col_one(queryname_areas);
                name = name_areas[0];
                var idareastring = new List<string>(name_areas[1].Split(','));
                if (name_areas[1] != "")
                {
                    foreach (string areaid in idareastring)
                    {
                        idarea.Add(Int32.Parse(areaid));
                    }
                }
            }
                



        }
        
        private Horizontal_law(List<Document> list_document) : base(list_document) { }

        internal Horizontal_law(string name)
        {
            //Sql_area SQL = Sql_area.GetInstance();

            string queryid = $"SELECT Id FROM Horizontal_Law WHERE Name = '{name}'";
            int id = SQL.Query_scalar(queryid);
            load_self(id);//tak wiem mozna to lepej zrobic


        }

        public static Horizontal_law operator +(Horizontal_law law_a, Horizontal_law law_b)
        {
            var list_c = new List<Document>(law_a.list_document);
            list_c.AddRange(law_b.list_document);
            return new Horizontal_law(list_c);

        }

        internal void Addarea(int idarea)
        {
            Idarea.Add(idarea);
            string idareastring="";
            foreach (int id in Idarea)
            {
                idareastring = idareastring+id.ToString() + ", ";
            }
            
            string addquery = $"UPDATE Horizontal_Law SET area_id = '{idareastring}' WHERE Id = '{id}'";
            SQL.Nonquery(addquery);
            

        }

        internal void DelDoc(int numOnListDocToDel)
        {
            string idareastring = "";
            foreach (int id in Idarea)
            {
                idareastring = idareastring + id.ToString() + ", ";
            }
            idarea.RemoveAt(numOnListDocToDel);
            string addquery = $"UPDATE Horizontal_Law SET area_id = '{idareastring}') WHERE Id = '{id}'";
            SQL.Nonquery(addquery);
            /*
            for(int i = numOnListDocToDel; i < idarea.Count-1; i++)
            {
                idarea[i] = idarea[i + 1];
            }
            */

            //throw new NotImplementedException();
        }
    }
}
