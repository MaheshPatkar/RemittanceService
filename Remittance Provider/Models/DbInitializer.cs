using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;

namespace Remittance_Provider.Models
{
    public static class DbInitializer
    {
        private const string ConnectionStringTemplate = "Data Source=(local);Database={0};Integrated Security=True";
        public static void Initialize()
        {
            string defaultDatabaseName = "master";
            string remittanceDatabaseName = "Remittance";
            using (var connection = new SqlConnection(string.Format(ConnectionStringTemplate, defaultDatabaseName)))
            {
                connection.Open();
                var createDbCommand = connection.CreateCommand();
                createDbCommand.CommandType = CommandType.Text;
                createDbCommand.CommandText = $"create database {remittanceDatabaseName};";
                createDbCommand.ExecuteNonQuery();
            }

            using var remittanceConnection = new SqlConnection(string.Format(ConnectionStringTemplate, remittanceDatabaseName));
            remittanceConnection.Open();
            try
            {
                var script = File.ReadAllText(Path.Combine("Database", "Scripts", "db_setup.sql"));
                var initDbCommand = remittanceConnection.CreateCommand();
                initDbCommand.CommandType = CommandType.Text;
                initDbCommand.CommandText = script;
                initDbCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // transaction.Rollback();
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
