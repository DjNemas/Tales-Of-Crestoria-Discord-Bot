using System.Data;
using System.Data.SQLite;

namespace TaleOfCrestoria.Database
{
    public class DatabaseAccess
    {
        //member 
        private const string dbfile = @"G:\Tales of Crestoria Discord Bot\Code\TalesOfCrestoriaDCBot\TalesOfCrestoriaDCBot\Database\unitdb.db";
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

        //public int GetCountOfRow()
        //{
        //    this.connect.Open();
        //    SQLiteCommand fmd = connect.CreateCommand();
        //    fmd.CommandText = "SELECT COUNT(*) FROM \"unit_unit\"";
        //    fmd.CommandType = CommandType.Text;
        //}
    }
}
