using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfCrestoria.Database
{    public class DatabaseAccess
    {
        //member 
        private const string dbfile = @"G:\Tales of Crestoria Discord Bot\Code\TalesOfCrestoriaDCBot\TalesOfCrestoriaDCBot\Database\unitdb.db"; // Change String to your Database

        public DataContext connect()
        {
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + dbfile);
            DataContext context = new DataContext(connection);
            return context;
        }        
    }
}
