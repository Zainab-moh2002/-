using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class IncubatorDetails
    {
        [Key]
        public int Id { get; set; }
        public string MapURL { get; set; }
        public string Address { get; set; }
        public string VideoPath { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Phone { get; set; }
        public string Name { get; set; }

        [ForeignKey("Card")]
        public int CardId { get; set; }
    }
}

