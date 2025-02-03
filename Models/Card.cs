using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Describtion { get; set; }
        public float Price { get; set; }
        [ForeignKey("Card")]
        public int locationFk { get; set; }
       

    }
}
