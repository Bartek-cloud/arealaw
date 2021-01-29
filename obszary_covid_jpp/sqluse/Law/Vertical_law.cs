using System.Collections.Generic;
//a neutral/chaos good  writing the law, ironic.

using sql_lib_pierwsze_podejscie;
using Law_data_ns;
namespace Law_ns
{//kadzda gmina bedie sie odowlywala do swojego zbioru praw a ten bedzie sie odwoływał do swoich praw ktore bedą miały tagi.
    public partial class Vertical_law : Law
    {//publiczne miedzynarodowe prywatne miedzynarodowe aministacyjne criminal/karne cywilne prywatne
        public Vertical_law(int id) : base(id) { }
        private Vertical_law(List<Document> list_document) : base(list_document) { }

        public Vertical_law(int id, string tag)
        {
        }

        public static Vertical_law operator +(Vertical_law law_a, Vertical_law law_b)
        {
            var list_c = new List<Document>(law_a.list_document);
            list_c.AddRange(law_b.list_document);
            return new Vertical_law(list_c);

        }

        protected override void load_self(int id)
        {
            Sql_area SQL = Sql_area.GetInstance();
            string query = $"SELECT * FROM documents WHERE Area_id = '{id}'";
            list_document = SQL.QueryDocumentList(query);
        }
    }
}
