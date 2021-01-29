using System.Collections.Generic;

using Law_ns;
namespace Law_data_ns
{//kadzda gmina bedie sie odowlywala do swojego zbioru praw a ten bedzie sie odwoływał do swoich praw ktore bedą miały tagi.
    public class HorLawdata
    {
        public readonly int Id;
        public readonly string Name;
        public readonly List<int> Idarea;
        public readonly List<Document> List_document;
        public HorLawdata(int id,string name ,List<int>idarealist,List<Document> listdoc)
        {
            this.Id = id;
            this.Name = name;     
            this.Idarea = idarealist;
            this.List_document = listdoc;
    }
        public static HorLawdata operator +(HorLawdata law_a, HorLawdata law_b)
        {
            var list_c = new List<Document>(law_a.List_document);
            list_c.AddRange(law_b.List_document);
            var listarea_c = new List<int>(law_a.Idarea);
            listarea_c.AddRange(law_b.Idarea);
            return new HorLawdata(0, law_a.Name + " " + law_b.Name, listarea_c,list_c);

        }

    }
}
