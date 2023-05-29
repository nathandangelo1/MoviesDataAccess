namespace MoviesDataAccess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Movie
    {// MAPS TO MOVIES DB USING DAPPER, NAMING MATCHES COLUMN NAMES IN MOVIES DB
        public int movieId { get; set; }
        public string title { get; set; }
        public int? year { get; set; }
        public string? genres { get; set; }

        public string FullInfo 
        {// USED TO POPULATE THE LIST<MOVIE>
            get
            {
                return $"{movieId} {title} {year} {genres}";
            }
        }

    }
}
