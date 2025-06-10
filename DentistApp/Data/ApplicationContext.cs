using System.Data.SQLite;

namespace DentistApp.Data
{
    public class ApplicationContext
    {
        private readonly string _connectionString;
        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
            Initialize();
        }

        private void Initialize()
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            string users = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Password TEXT, Role TEXT);";
            string appointments = "CREATE TABLE IF NOT EXISTS Appointments (Id INTEGER PRIMARY KEY AUTOINCREMENT, PatientId INTEGER, Date TEXT);";
            new SQLiteCommand(users, connection).ExecuteNonQuery();
            new SQLiteCommand(appointments, connection).ExecuteNonQuery();
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }
}
