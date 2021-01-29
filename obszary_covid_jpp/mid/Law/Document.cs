using System;
using System.Collections.Generic;
//a neutral/chaos good  writing the law, ironic.

namespace Law_data_ns
{//kadzda gmina bedie sie odowlywala do swojego zbioru praw a ten bedzie sie odwoływał do swoich praw ktore bedą miały tagi.
    public struct Document
    {
       
        public readonly int id;
        public readonly int law_id;
        readonly public string title;
        readonly public string brief;
        readonly public string reference;
        readonly public List<string> tags;


        public Document(int id,int law_id,string title, string brief, string reference,List<string>tags)
        {
            this.id = id;
            this.law_id = law_id;
            this.title = title;
            this.brief = brief;
            this.reference = reference;
            this.tags = tags;
            //tags = document_date[5];
        }

        /*
        public Document(List<string> document_date)
        {
            id = int.Parse(document_date[0]);
            law_id = int.Parse(document_date[1]);
            title =(document_date[2]);
            brief = (document_date[3]);
            reference = (document_date[4]);
            tags = new List<string>(document_date[5].Split(','));
            //tags = document_date[5];
        }
        */



    }
}
