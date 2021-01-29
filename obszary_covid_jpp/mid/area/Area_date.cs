using Area_ns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_date_ns
{
    public struct Area_date
    {
        public readonly int Id;
        public readonly string Name;
        public readonly string differential_name;
        public readonly bool Sex;
        public readonly int id_higher;
        public readonly string Type;
        public Area_date(int id, string name, string differential, int id_higher, string type)
        {
            this.Id = id;
            this.Name = name;
            this.differential_name = differential;
            if (type == Area.Typ[4])
            {
                this.Sex = true;
            }
            else { this.Sex = false; }
            this.id_higher = id_higher;
            this.Type = type;
        }
        public static bool operator !=(Area_date a, Area_date b)
        {
            return a.Id != b.Id;
        }
        public static bool operator ==(Area_date a, Area_date b)
        {
            return a.Id == b.Id;
        }

    }
}
