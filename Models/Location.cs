using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        
        public int? CityId {get;set;}

        [ForeignKey("CityId")]
        public   City? City { get; set; }
     
    }
}
