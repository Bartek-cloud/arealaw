using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace sql_lib_pierwsze_podejscie
{

    public interface ISql_lib//interface?
    {
        /// <summary>
        /// abstract class for sql database connect
        /// 
        /// </summary>
        string Col_type(string querystring, Int32 num_of_col);
         List<List<string>> Query_multi_col(string querystring);
         List<string> Query_multi_col_one(string querystring);

        List<string> Query_str(string querystring);
        
         List<int> Query_int(string querystring);
         List<double> Query_doub(string querystring);

         Int32 Query_scalar(string querystring);
    
         void Nonquery(string querystring);
         bool Query_true_false(string querystring);
         List<bool> Query_bool(string querystring);
        //abstract public DataSet Query_multi_col_dt(string queryString);
         string Query_one_string(string queryString);
    }

    public class Sql_ms : ISql_lib
    {
        /// <summary>
        /// first attemp of ms connect class
        /// always use '' or @
        /// </summary>
        protected static Sql_ms instance = null;
        protected readonly string connectionString;
        protected Sql_ms(){
            connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        }
        public static Sql_ms GetInstance()//nie obsluguje wielowotkowosci
        {
            /// <summary>
            /// if instance of database exist don't create new.
            /// 
            /// </summary>
            if (instance == null)
            {
                Sql_ms.instance = new Sql_ms();
            }
            return instance;
        }
         public string Col_type(string queryString, Int32 col_num) {
            /// <summary>
            /// returns the Sql column type iterated from zero
            /// 
            /// </summary>
            string res;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                res = reader.GetDataTypeName(col_num);
                // Call Close when done reading.
                reader.Close();               
            }
            return res;
        }
        public List<List<string>> Query_multi_col(string queryString)
        {
            /// <summary>
            ///  use for multi select query, evrything will be converted to string.
            /// returns List<List<string>>
            /// </summary>
            var results = new List<List<string>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                int num_col = reader.FieldCount;
                int j = 0;
                while (reader.Read())
                {                    
                    results.Add(new List<string>());
                    for (int i = 0; i < num_col; i++)
                    {
                        results[j].Add(reader.GetValue(i).ToString());
                    }
                    j++;
                }
                //selectadapter.Dispose();
                connection.Close();    
            }
            return results;
        }
        public string Query_one_string(string queryString)
        {
            /// <summary>
            ///  use for multi select query, evrything will be converted to string.
            /// returns List<List<string>>
            /// </summary>
            string results="";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                int num_col = reader.FieldCount;
                while (reader.Read())
                {
                    results=reader.GetValue(0).ToString();
                }
                //selectadapter.Dispose();
                connection.Close();
            }
            return results;
        }
        /*
        override public DataSet Query_multi_col_dt(string queryString)
        {
            /// <summary>
            ///  uses for multi select query
            /// returns dt
            /// </summary>
           DataSet m_objDs = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataAdapter selectadapter = new SqlDataAdapter(command);
                
                selectadapter.Fill(m_objDs);

                //selectadapter.Dispose();
                connection.Close();
            }
            return m_objDs;
        }
        */

        public List<string> Query_str(string queryString)
        {
            /// <summary>
            /// use for 1 select string returning query, evrything will be converted to string.
            /// returns List<string>
            /// </summary>
            List<string> results= new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.                
                
                while (reader.Read())
                {
                    results.Add(reader.GetValue(0).ToString());//GetString
                }
                // Call Close when done reading.
                reader.Close();
            }
            return results;
        }
         public List<int> Query_int(string queryString)
        {
            /// <summary>
            /// use for 1 select intiger returning query
            /// returns List<int>
            /// </summary>
            List<int> results = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.
                while (reader.Read())
                {
                    results.Add((Int32)reader.GetDecimal(0));
                }
                // Call Close when done reading.
                reader.Close();
            }
            return results;
        }
        public List<double> Query_doub(string queryString)
        {
            /// <summary>
            /// use for 1 select double returning query
            /// returns List<double>
            /// </summary>
            List<double> results = new List<double>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.

                while (reader.Read())
                {
                    results.Add((Int32)reader.GetDecimal(0));
                }
                // Call Close when done reading.
                reader.Close();
            }
            return results;
        }
         public List<bool> Query_bool(string queryString)
        {
            /// <summary>
            /// use for select bool returning query, evrything will be converted to string.
            /// returns List<bool>
            /// </summary>
            List<bool> results = new List<bool>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.                

                while (reader.Read())
                {
                    results.Add(reader.GetBoolean(0));//GetString
                }
                // Call Close when done reading.
                reader.Close();
            }
            return results;
        }
       public bool Query_true_false(string queryString)
        {
            /// <summary>
            /// use for 1  bool returning query
            /// returns bool
            /// </summary>
            bool result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.
                reader.Read();
                result=reader.GetBoolean(0);
                // Call Close when done reading.
                reader.Close();
            }
            return result;
        }
        public Int32 Query_scalar(string queryString)
        {
            /// <summary>
            /// use for 1 intiger returning query
            /// returns int32
            /// </summary>
            Int32 result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.
                reader.Read();
                if (reader.HasRows)
                {
                    result = (reader.GetInt32(0));
                    //result = (Int32)reader.GetDecimal(0);
                }
                else//jak ja moglem tego elsa zapomniec
                {
                    result = 0;
                }
                // Call Close when done reading.
                reader.Close();
            }
            return result;
        }

         public void Nonquery(string queryString)
        {
            /// <summary>
            /// use non returning SQL query: INSERT UPDATE DELETE.
            /// 
            /// </summary>
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool Is(string queryString)
        {
            /// <summary>

            /// </summary>
            bool result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    result = true;
                }
                else { result = false; }
                connection.Close();

            }
            return result;
        }
        public  List<string> Query_multi_col_one(string queryString)
        {
            /// <summary>
            ///  use for multi select query, evrything will be converted to string.
            /// returns List<List<string>>
            /// </summary>
            var results = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                int num_col = reader.FieldCount;
                int j = 0;
                while (reader.Read())
                {
                    for (int i = 0; i < num_col; i++)
                    {
                        results.Add(reader.GetValue(i).ToString());
                    }
                    j++;
                }
                //selectadapter.Dispose();
                connection.Close();
            }
            return results;
        }
        
    }
}



/*
  jesli ktos bedzie chciał zrobic wszystko na tablicach
  
  override public string[,] Query_multi_col(string querystring)
 {

     /// <summary>
     ///  uses for multi select query
     /// returns string[,]
     /// </summary>
     string[,] results;
     using (SqlConnection connection = new SqlConnection(connectionString))
     {

         connection.Open();
         SqlCommand command = new SqlCommand(querystring, connection);
         SqlDataAdapter selectadapter = new SqlDataAdapter(command);
         DataSet m_objDs = new DataSet();
         selectadapter.Fill(m_objDs);

         DataRowCollection rowcoll= m_objDs.Tables[0].Rows;
         Int32 num_rows = rowcoll.Count;
         DataColumnCollection colcoll = m_objDs.Tables[0].Columns;
         Int32 num_col = colcoll.Count;
         results = new string[num_rows, num_col];

         int i = 0;
         foreach (DataRow row in rowcoll)//dopracować poxznej?
         {   
             int j = 0;
             foreach (DataColumn column in colcoll)
             {
                 results[i,j] = row[column].ToString();
                 //Console.WriteLine(row[column]);
                 j++;
             }
             i++;
         }
         //selectadapter.Dispose();
         connection.Close();    
     }
     return results;
 }*/