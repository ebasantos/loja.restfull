using System;
using System.Data.SqlClient;

namespace Loja.Infra.Data.Context
{
    public class DataContext : IDisposable
    {

        public SqlConnection Connection;

        public DataContext(string cnnString)
        {
            Connection = new SqlConnection(cnnString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
