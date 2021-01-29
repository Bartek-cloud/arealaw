using System.Collections.Generic;

using Law_ns;
namespace Law_data_ns
{//kadzda gmina bedie sie odowlywala do swojego zbioru praw a ten bedzie sie odwoływał do swoich praw ktore bedą miały tagi.
    public struct VerLawdata //: LawData
    {
        public readonly int Id;
        public readonly List<Document> List_document;
        public VerLawdata(int id,List<Document>listdoc)
        {
            this.Id = id;
            this.List_document = listdoc;
        }
        public static VerLawdata operator +(VerLawdata law_a, VerLawdata law_b)
        {
            var list_c = new List<Document>(law_a.List_document);
            list_c.AddRange(law_b.List_document);
            return new VerLawdata(0, list_c);
        }
    }
}
