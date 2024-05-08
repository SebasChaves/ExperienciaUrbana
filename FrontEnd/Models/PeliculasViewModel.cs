namespace FrontEnd.Models
{
    public class PeliculasViewModel
    {
        public int Page { get; set; }
        public List<Serie> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
    public class Serie
    {
        public bool Adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> GenreIds { get; set; }
        public int Id { get; set; }
        public List<string> OriginCountry { get; set; }
        public string OriginalLanguage { get; set; }
        public string original_title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string poster_path { get; set; }
        public string first_air_date { get; set; }
        public string release_date { get; set; }
        public string Name { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}
