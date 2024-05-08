namespace FrontEnd.Models
{
    public class Flatrate
    {
        public string logo_path { get; set; }
        public int ProviderId { get; set; }
        public string provider_name { get; set; }
        public int DisplayPriority { get; set; }
    }

    public class MX
    {
        public string Link { get; set; }
        public List<Flatrate> Flatrate { get; set; }
    }

    public class Results
    {
        public MX MX { get; set; }
    }

    public class PeliculaSerieProviderModel
    {
        public int Id { get; set; }
        public Results Results { get; set; }
    }


}
