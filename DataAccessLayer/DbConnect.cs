using System;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using CommanLayer;
namespace DataAccessLayer
{
    public class DbConnect
    {
        public SqlConnection connection;

        public DbConnect()
        {
            connection = new SqlConnection(DbConnectionConfig.ConnectionString);
        }
    }
}
