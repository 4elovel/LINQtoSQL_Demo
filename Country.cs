using System.Data.Linq.Mapping;
namespace LINQtoSQL_Demo
{
    [Table(Name = "Countries")]
    public class Country
    {

        [Column(IsPrimaryKey = true, Name = "guid")]
        public string Guid { get; set; }
        [Column(Name = "country")]
        public string Name { get; set; }
        [Column(Name = "capital")]
        public string Capital { get; set; }
        [Column(Name = "population")]
        public int Population { get; set; }
        [Column(Name = "area")]
        public double Area { get; set; }
        [Column(Name = "worldpart")]
        public string WorldPart { get; set; }
    }
}
