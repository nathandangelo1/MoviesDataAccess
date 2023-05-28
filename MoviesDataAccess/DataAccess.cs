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
        public List<Movie> GetMovies(string movieSearch)
        {
            using (IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Helper.CnnVal("movies")))
            {
                var output = connection.Query<Movie>($"SELECT * FROM [movies].[dbo].[tblMovies] WHERE title like '%{movieSearch}%';").ToList();
                return output;
            }
        }
    }
}
