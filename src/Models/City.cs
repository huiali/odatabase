using System.ComponentModel.DataAnnotations;

namespace ODataBase
{
    public class City
    {
        [Key]
        public int ID { set; get; }
        public string Name { set; get; }
        public string CountryCode { set; get; }
        public string District{set;get;}
        public int Population{set;get;}
    }
}