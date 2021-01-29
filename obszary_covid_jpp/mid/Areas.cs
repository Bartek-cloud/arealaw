using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Area_ns;
//using sql_lib_pierwsze_podejscie;
using Law_ns;
using Area_date_ns;
using Area_creator_ns;
using Law_data_ns;

namespace Areas//nazwa wynika z tego ze w 1 wesjach bbyła tu tablica obszarów
{
    public class Areas
    {
        Areasditor areaeditor = new Areasditor();
        Documentvereditor documentvereditor = new Documentvereditor();
        Documenthoreditor documenthoreditor = new Documenthoreditor();
        Horizontal_laweditor horizontal_laweditor = new Horizontal_laweditor();

        public List<Area_date> Search(string name_area)
        {
            return areaeditor.Search(name_area);

        }
        public List<Area_date> Search(string name_area, string difname)
        {
            return areaeditor.Search(name_area, difname);
        }
        internal HorLawdata find_hor_law(string name)
        {
            return LawDataconv.Lawto_data(new Horizontal_law(name));
        }
        internal HorLawdata Find_hor_law(int areaid)
        {
            return LawDataconv.Lawto_data(horizontal_laweditor.Search(areaid));
        }
        public List<string> Showdoc(string link)
        {
            return documentvereditor.Show(link);

        }

        internal HorLawdata Search_hor_law(string name)
        {
            return LawDataconv.Lawto_data(new Horizontal_law(name));
        }

        public Area_date Get_adm_higher(int id_higher)
        {
            if (id_higher != 0)
            {
                Area area = Area_creator.Atri_to_area(id_higher);
                return area.ToAreaDate();
            }
            else return new Area_date();
            
        }
        public bool Isarea(string name_area)
        {
            return areaeditor.Is(name_area);

        }
        public bool IsLaw(string link)
        {
            return documentvereditor.Isver(link);

        }
        public bool Isarea(string name_area, string difname)
        {
            return areaeditor.Is(name_area, difname);
        }
                public List<Area_date> Get_adm_lover(Area_date current_area)
        {
            Area caller = Area_creator.Atri_to_area(current_area);
            return caller.Load_lower();
        }
        public void MadeArea(string name, string difname, string strhig, string higdif, string type)
        {
            areaeditor.Made(name, difname, strhig, higdif, type);
        }
        public bool isTyp(string type)
        {
            foreach (string typ in Area.Typ)
            {
                if (typ == type)
                {
                    return true;
                }
            }
            return false;
        }

        internal VerLawdata Find_all_law(Area_date area_Date)
        {
            //najpierw hor potem ver
            Area area = Area_creator.Atri_to_area(area_Date);
            VerLawdata verdata = LawDataconv.Lawto_data(area.Load_all_vertical_law());//przkombinowane?
            VerLawdata hordata = LawDataconv.HortoverLawdata(horizontal_laweditor.Search(area_Date.Id));
            return verdata + hordata;
        }
        public VerLawdata Find_local_law(int law_id)
        {
            return LawDataconv.Lawto_data( new Vertical_law(law_id));
        }

        internal void UpdateTitlehor(int docid, string newname)
        {
            documenthoreditor.UpdateTitlehor(docid, newname);
        }
        internal void Updatebriefhor(int docid, string newbrief)
        {
            documenthoreditor.Updatebriefhor(docid, newbrief);
        }
        internal void Updatelinkhor(int docid, string newlink)
        {
            documenthoreditor.Updatelinkhor(docid, newlink);
        }

        internal void Updatetaghor(int docid, string tags)
        {
            documenthoreditor.Updatetaghor(docid, tags);
        }

        internal void DeleteLawhor(int id)
        {
            horizontal_laweditor.Delete(id);
        }
        internal HorLawdata addareatolawhor(int id,int idarea)
        {
            var law = new Horizontal_law(id);
            law.Addarea(idarea);
            return LawDataconv.Lawto_data(law);
        }

        internal int createhorlav(string name)
        {
            int lawid = horizontal_laweditor.Create(name);
            return lawid;
        }

        internal void Updatehigher(int id, int newhigher)
        {
            throw new NotImplementedException();
        }

        internal void DeleteDochorlaw(int docid,int lawid)
        {
            var law = new Horizontal_law(lawid);
            law.DelDoc(docid);
        }
        internal void MakeDocLawhor(int lawid, string name, string brief, string link, string tags)
        {
            documenthoreditor.Createhor(lawid, name, brief, link, tags);
        }
        internal void UpdateTitleVer(int docid, string newname)
        {
            documentvereditor.UpdateTitleVer(docid, newname);
        }
        internal void MakeLawver(int lawid, string name, string brief, string link, string tags)
        {
            documentvereditor.Createver(lawid, name, brief, link, tags);
        }
        internal void Udapteareaselectedver(int docid, int newareaid)
        {
            documentvereditor.Updateareaselectedver(docid, newareaid);
        }

        internal void UpdateName(int areaid,string newname)
        {
            areaeditor.UpdateName(areaid, newname);
        }
        internal void Udaptebriefver(int docid, string newbrief)
        {
            documentvereditor.UpdateBriefVer(docid, newbrief);
        }

        internal void UpdateDifName(int id, string newdifname)
        {
            areaeditor.UpdateDifName(id,newdifname);
        }

        internal void Updatelinkver(int id, string newlink)
        {
            documentvereditor.Udaptelink(id, newlink);
        }
        internal void Updatetagver(int id, string tags)
        {
            documentvereditor.Udaptetag(id, tags);
        }
        internal void DeleteArea(Area_date current_area)
        {
            areaeditor.Delete(current_area.Id);
        }
        internal void DeleteLawver(int id)
        {
            documentvereditor.Deletelawdoc(id);
        }

    }
}
//Author: Bartłoemiej Szkałuba
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

/*
  private int Last_free
  {
      set
      {
          if (value == 100) { Last_free = 0; }
          else { Last_free = value; }
      }
      get
      {
          return Last_free;
      }
  }
            Last_free = 0;
            //Area.Area start_area;
            string start_query = "";
            List<List<string>> start_country = SQL.Query_multi_col(start_query);

 public List<Area_date> Search(string name_area)// OSTRZEZENIE najbzydzsza metoda projektu
        {                   //Tutaj napewno da sie to lepej zrobic pomyslec
            //string querystring = $"SELECT * FROM country  WHERE name={name_area}";
            List<List<string>> searched_list= new List<List<string>>();
            List<List<string>> country_list = search_country(name_area);
            foreach (List<string> country in country_list)//// lepej bedzie napisac to join jesli w mssql jest
            {
                country.Append("country");
                country_list.Append(country);
            }
            List<List<string>> list_district = search_district(name_area);
            foreach (List<string> district in list_district)
            {
                district.Append("district");
                searched_list.Append(district);
            }
            List<List<string>> list_province = search_province(name_area);
            foreach (List<string> province in list_province)
            {
                province.Append("province");
                searched_list.Append(province);
            }
            List <List<string>> list_communet = search_commune(name_area);
            foreach (List<string> commune in list_communet)
            {
                commune.Append("commune");
                searched_list.Append(commune);
            }
            return Area_date_form.ToArealist(searched_list);
        }
        private List<List<string>> search_country(string name_country)
        {
            string search_query = $"SELECT * FROM country  WHERE name={name_country}";
            return SQL.Query_multi_col(search_query);
        }
        private List<List<string>> search_province(string name_province)
        {
            string search_query =$"SELECT * FROM province  WHERE name={name_province}";
            return SQL.Query_multi_col(search_query);
        }
        private List<List<string>> search_district(string name_district)
        {
            string search_query = $"SELECT * FROM district  WHERE name={name_district}";
            return SQL.Query_multi_col(search_query);
        }
        private List<List<string>> search_commune(string name_commune)
        {
            string search_query = $"SELECT * FROM commune WHERE name={name_commune}";
            return SQL.Query_multi_col(search_query);
        }

  */