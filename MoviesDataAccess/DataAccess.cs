using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace MoviesDataAccess
{
    public class DataAccess
    {
        public List<Movie> GetMovies(string movieSearch, SearchBy field)
        {
            using (IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Helper.CnnVal("movies")))
            {
                switch (field)
                {

                    //case SearchBy.year:
                    //    return connection.Query<Movie>("Movies_GetByYear @year", new { year = movieSearch }).ToList();

                    //case SearchBy.genre:
                    //    return connection.Query<Movie>("Movies_GetByGenre @genre", new { genre = movieSearch }).ToList();

                    //case SearchBy.title:
                    //    return connection.Query<Movie>("Movies_GetByTitle @title", new { title = movieSearch }).ToList();

                    //default:
                    //    return connection.Query<Movie>("Movies_GetByTitle @title", new { title = movieSearch }).ToList();
                    case SearchBy.year:
                        return connection.Query<Movie>("SELECT * FROM dbo.tblMovies WHERE year LIKE @year", new { year = movieSearch }).ToList();

                    case SearchBy.genre:
                        return connection.Query<Movie>("SELECT * FROM dbo.tblMovies WHERE genres LIKE '%' + @genre + '%'", new { genre = movieSearch }).ToList();

                    //case SearchBy.title:
                    //    return connection.Query<Movie>("SELECT * FROM movies WHERE title LIKE @title", new { title = movieSearch }).ToList();

                    default:
                        return connection.Query<Movie>("SELECT * FROM dbo.tblMovies WHERE title LIKE '%' + @title + '%' ", new { title = movieSearch }).ToList();

                }

            }
        }
    }
}
