using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace MoviesDataAccess
{
    public class DataAccess
    {
        // QUERIES DB FOR LIST OF MOVIES GIVEN MOVIESEARCH VALUE AND FIELD TO SEARCH BY
        public List<Movie> GetMovies(string movieSearch, SearchBy field)
        {
            // GETS CONNECTION STRING FOR MOVIES DB FROM HELPER CLASS
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("movies")))
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
                        return connection.Query<Movie>("SELECT * FROM dbo.tblMovies WHERE year LIKE '%'+ @year + '%'", new { year = movieSearch }).ToList();

                    case SearchBy.genre:
                        return connection.Query<Movie>("SELECT * FROM dbo.tblMovies WHERE genres LIKE '%' + @genre + '%'", new { genre = movieSearch }).ToList();

                    default:
                        return connection.Query<Movie>("SELECT * FROM dbo.tblMovies WHERE title LIKE '%' + @title + '%' ", new { title = movieSearch }).ToList();

                }

            }
        }
    }
}
