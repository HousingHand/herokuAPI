using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string cityname { get; set; }
    }

    public class StateModel
    {
        public int Id { get; set; }
        public string statename { get; set; }
    }

    public class RejectionModel
    {
        public int Id { get; set; }
        public string Item { get; set; }
    }
    public class CosignerRejectionModel
    {
        public string Id { get; set; }
        public string Item { get; set; }
    }

    public class CountryModel
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class APTypeModel
    {
        public string Id { get; set; }
        public string name { get; set; }
    }

}
