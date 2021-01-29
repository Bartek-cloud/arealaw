using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sql_lib_pierwsze_podejscie;
using Area_date_ns;
using Area_ns;
using Law_data_ns;
namespace sql_lib_pierwsze_podejscie
{
    public class Sql_area : Sql_ms
    {
        public List<Document> QueryDocumentList(string queryString)
        {
            int id=0;
            int law_id=0;
            string title="";
            string brief="";         
            string reference="";
            string tag="";
            List<Document> result=new List<Document>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //int id = reader.GetInt32(0);
                        id = reader.GetInt32(0);
                        law_id = reader.GetInt32(1);
                        if (!reader.IsDBNull(2)) { title = reader.GetString(2); }
                        if (!reader.IsDBNull(3)) { brief = reader.GetString(3); }
                        if (!reader.IsDBNull(4)) { reference = reader.GetString(4); }
                        if (!reader.IsDBNull(5)) { tag = reader.GetString(5); }
                        List<string> tags = new List<string>(tag.Split(','));
                        result.Add( new Document(id, law_id, title, brief, reference, tags));
                    }
                }

                //selectadapter.Dispose();
                connection.Close();
                
                
            }
            return result;
            
            
        }
        public List<Area_date> Query_multi_col_areadate(string queryString)
        {
            /// <summary>

            /// </summary>
            var results = new List<Area_date>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //int id = reader.GetInt32(0);
                        string namestr = reader.GetString(1);
                        string difstr;
                        if (!reader.IsDBNull(2)) { difstr = reader.GetString(2); }
                        else { difstr = ""; }
                        int hid = 0;
                        if (!reader.IsDBNull(3)) { hid = reader.GetInt32(3); }

                        results.Add(new Area_date(reader.GetInt32(0), namestr, difstr, hid, Area.Typ[reader.GetInt32(4)]));
                    }
                }
                //selectadapter.Dispose();
                connection.Close();
            }
            return results;
        }
        public Area_date Query_multi_col_areadate_one(string queryString)
        {
            /// <summary>

            /// </summary>
            Area_date results= new Area_date();// = new Area_date();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows&& reader.Read())
                {
                    reader.GetInt32(0);
                    string namestr = reader.GetString(1);
                    string difstr;
                    if (!reader.IsDBNull(2)) { difstr = reader.GetString(2); }
                    else { difstr = ""; }
                    int hid = 0;
                    if (!reader.IsDBNull(3)) { hid = reader.GetInt32(3); }
                    results = (new Area_date(reader.GetInt32(0), namestr, difstr, hid, Area.Typ[reader.GetInt32(4)]));
                    //selectadapter.Dispose();
                }
                //else { throw (new Exception("there is no value")); }
                connection.Close();
                
            }
            return results;
        }
        /*public Area_date Query_multi_col_areadate_one(string queryString)
        {
            /// <summary>

            /// </summary>
            Area_date results;// = new Area_date();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    reader.GetInt32(0);
                    string namestr = reader.GetString(1);
                    string difstr;
                    if (!reader.IsDBNull(2)) { difstr = reader.GetString(2); }
                    else { difstr = ""; }
                    int hid = 0;
                    if (!reader.IsDBNull(3)) { hid = reader.GetInt32(3); }
                    results = (new Area_date(reader.GetInt32(0), namestr, difstr, hid, Area.Typ[reader.GetInt32(4)]));
                    //selectadapter.Dispose();
                }
                else { throw (new Exception("there is no value")); }
                connection.Close();

            }
            return results;
        }*/

        protected static new Sql_area instance = null;
        public new static Sql_area GetInstance()//nie obsluguje wielowotkowosci
        {
            /// <summary>
            /// if instance of database exist don't create new.
            /// 
            /// </summary>
            ///
            if(instance == null)
            {
                Sql_area.instance = new Sql_area();
            }
            return instance;
        }
    }
}
