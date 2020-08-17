using System.Data;
using System.Data.SQLite;

namespace TaleOfCrestoria.Database
{
    public class DatabaseAccess
    {
        //member 
        private const string dbfile = @"database/unitdb.db";
        private SQLiteConnection connect = new SQLiteConnection("Data Source = " + dbfile);

        public SQLiteCommand OpenConnect(string queryString)
        {
            this.connect.Open();
            SQLiteCommand fmd = connect.CreateCommand();
            fmd.CommandText = queryString;
            fmd.CommandType = CommandType.Text;
            return fmd;
        }

        public void CloseConnection()
        {
            this.connect.Close();
        }
    }
}
