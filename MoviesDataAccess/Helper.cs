using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataAccess
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {// GETS REQUESTED CONNECTION STRING ([movies]) FROM APP.CONFIG FILE
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;

        }
    }
}
