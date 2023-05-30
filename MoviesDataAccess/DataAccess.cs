using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace MoviesDataAccess
{
    public class DataAccess
    {
        // QUERIES DB FOR LIST OF MOVIES GIVEN MOVIESEARCH VALUE AND FIELD TO SEARCH BY
        public List<Movie> GetMovies(string movieSearch, SearchBy field)
        {
            // GETS CONNECTION STRING FOR MOVIES DB FROM HELPER CLASS
            using (var connection = new SqlConnection(Helper.CnnVal("movies")))
            {
                switch (field)
                {
                    //CASES USING STORED PROCEDURES:
                    //case SearchBy.year:
                    //    return connection.Query<Movie>("Movies_GetByYear @year", new { year = movieSearch }).ToList();

                    //case SearchBy.genre:
                    //    return connection.Query<Movie>("Movies_GetByGenre @genre", new { genre = movieSearch }).ToList();

                    //case SearchBy.title:
                    //    return connection.Query<Movie>("Movies_GetByTitle @title", new { title = movieSearch }).ToList();

                    //default:
                    //    return connection.Query<Movie>("Movies_GetByTitle @title", new { title = movieSearch }).ToList();

                    //CASES USING STRAIGHT SQL:
                    // USES DAPPER MICRO-ORM TO MAP RECORDS TO 'MOVIE' CLASS
                    case SearchBy.year:
                        return connection.Query<Movie>("SELECT * FROM dbo.tblMovies WHERE year LIKE @year", new { year = movieSearch }).ToList();

                    case SearchBy.genre:
                        return connection.Query<Movie>("SELECT * FROM dbo.tblMovies WHERE genres LIKE '%' + @genre + '%'", new { genre = movieSearch }).ToList();

                    default:
                        return connection.Query<Movie>("SELECT * FROM dbo.tblMovies WHERE title LIKE '%' + @title + '%' ", new { title = movieSearch }).ToList();
                }
            }
        }

        public bool InsertMovie(string movieId, string title, string year, string genre)
        {
            int movieIdInt=0, yearInt=0;
            if(!int.TryParse(year, out yearInt) && !int.TryParse(movieId, out movieIdInt)) { return false; }

            using (var connection = new SqlConnection(Helper.CnnVal("movies")))
            {
                List<Movie> movies = new();
                
                movies.Add(new() { movieId = movieIdInt, title = title, year = yearInt, genres = genre });

                connection.Execute("dbo.tblMovies_Insert @movieId, @title, @year, @genres", movies);

                return true;
            }
        }
    }
}
