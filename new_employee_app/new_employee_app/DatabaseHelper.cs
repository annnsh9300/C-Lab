/*******************
*Annick Nshimirimana
*12/8/2025
* DatabaseHelper manages the SQLite connection and creates required tables.
 It is used by the repository to read/write employee records to the database.
*/

using Microsoft.Data.Sqlite;

namespace new_employee_app
{
    public static class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=employees.db";

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(ConnectionString);
        }

        public static void InitializeDatabase()
        {
            using var connection = GetConnection();
            connection.Open();

            string tableCmd = @"
                CREATE TABLE IF NOT EXISTS Employees (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Position TEXT NOT NULL,
                    Department TEXT NOT NULL,
                    Salary REAL NOT NULL
                );
            ";

            using var command = connection.CreateCommand();
            command.CommandText = tableCmd;
            command.ExecuteNonQuery();
        }
    }
}
