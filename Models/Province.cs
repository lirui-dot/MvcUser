using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcUser.Models
{ 
    public class Province
    {
        
        public int id { get; set; }

        public string name { get; set; }

        public int parentid { get; set; }

        public string parentname { get; set; }

        public string areacode { get; set; }

        public string zipcode { get; set; }

        public string depth { get; set; }

    }
    [NotMapped]
    public class ProvinceDetails{
        public int status{get;set;}
        public string msg{get;set;}
        public List<Province> result{get;set;}
    }

}