using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Law_data_ns;
//a neutral/chaos good  writing the law, ironic.

namespace Law_ns
{//kadzda gmina bedie sie odowlywala do swojego zbioru praw a ten bedzie sie odwoływał do swoich praw ktore bedą miały tagi.
    abstract public class Law
    {
        //static Sql_ms SQL = Sql_area.GetInstance();
        protected int id;
        public int Id {
            get { return id; }
        }
           
        protected List<Document> list_document;
        public List<Document> List_document
        {
            get { return list_document; }
        }

        protected Law(List<Document> list_document)
        {
            this.id = 0;
            this.list_document = list_document;

        }
        protected Law()
        {

        }
        public Law(int id)
        {
            this.id = id;
            load_self(id);

        }
        protected abstract void load_self(int id);
    }
}
