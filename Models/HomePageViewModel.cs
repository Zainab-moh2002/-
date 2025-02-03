namespace GraduationProject.Models
{
    public class HomePageViewModel
    {
        public int Id { get; set; }
        public List<Location> Locations { get; set; }

        public List<City> Cities { get; set; }
        public List<Card> Cards { get; set; }

    }
}
