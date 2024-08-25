using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HealthMate_UI
{
    public class DatabaseManagerfo : IDisposable
    {
        private SqlConnection sqlConnection;

        public DatabaseManagerfo()
        {
            string connectionString = @"Data Source=DESKTOP-QUB8L8T\SQLEXPRESS;Initial Catalog=FoodDB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }
        }
    }
}