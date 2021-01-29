using System.Collections.Generic;
using Area_ns;
namespace Area_date_ns
{
    static class Area_date_form 
    {
        public static List<Area_date> ToAreaDatelist(List<Area>date_list)
        {
            List<Area_date> result= new List<Area_date>();
            foreach (Area area in date_list)
            {
                result.Add(area.ToAreaDate());
            }
            return result;
        }


    }
}
