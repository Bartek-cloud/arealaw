using Area_date_ns;
using Area_ns;
using System;
using System.Collections.Generic;


namespace Area_creator_ns
{
    static class Area_creator
    {
        public static string[] Typ = Area.Typ;
        public static Area Atri_to_area(int id)
        {

            return Atri_to_area(Area.Load_Self_date(id));          
        }
        public static Area Atri_to_area(Area_date area_date)
        {
            Area result;
            if (area_date.Type == Typ[1])//konwersja string na inta
            {
                result = new Country(area_date);
            }
            else if (area_date.Type == Typ[2])
            {
                result = new District(area_date);
            }
            else if (area_date.Type == Typ[3])
            {
                result = new Province(area_date);
            }
            else if (area_date.Type == Typ[4])
            {
                result = new Commune(area_date);
            }
            else {
                throw new Exception("type out posible");
            }         
            return result;
        }
        /*
public static Area Atri_to_area(List<string> atribute_list)
{
    Area result;

    switch (int.Parse(atribute_list[4]))
    {

        case 1:
            result = new Country(atribute_list);
            break;
        case 2:
            result = new District(atribute_list);
            break;
        case 3:
            result = new Province(atribute_list);
            break;
        case 4:
            result = new Commune(atribute_list);
            break;
        default:
            throw new Exception("type out posible");                    
    }
    return result;
}
*/
        /*
        public static List<Area> List_to_area(List<List<string>> obj_list)
        {
            List<Area> result = new List<Area>();
            foreach(List<string> atribute_list in obj_list) 
            {
                result.Add(Atri_to_area(atribute_list));
            }
            return result;
        }
        */
    }
}
//Autor: Bartłoemiej Szkałuba

/*
           try
           {
               start_area = new Area.Country(start_country[0]);

               tab_area = new Area.Area[100];
               tab_area[0] = start_area;
               current_area = start_area;
               load_lover(start_area);
               load_higer(start_area);

           }

           catch (DivideByZeroException e)
           {
               Console.WriteLine("start_list_is_empty");
           }



           catch (DivideByZeroException e)
           {
               Console.WriteLine("start_list_is_bigger");
           }


       }
       void load_lover(Area.Area chosen_area)
       {
           List<Area.Area> list_lovers = chosen_area.Load_lower();
           foreach (Area.Area lower in list_lovers)
           {
               tab_area[Last_free] = lower;
               Last_free++;

           }
       }
       void load_higer(Area.Area chosen_area)
       {
               tab_area[Last_free] = chosen_area.Load_higher();
               Last_free++;
       }
           */