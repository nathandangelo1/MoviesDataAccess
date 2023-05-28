namespace MoviesDataAccess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Movie
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public int? year { get; set; }
        public string? genres { get; set; }

        public string FullInfo 
        { 
            get
            {
                return $"{movieId} {title} {year} {genres}";
            }
        }

    }
}
