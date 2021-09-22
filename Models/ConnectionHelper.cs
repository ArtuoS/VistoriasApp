using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace VistoriasProjeto.Models
{
    public class ConnectionHelper
    {
        public static void CloseConnection(MySqlConnection connection)
        {
            if(connection.State.Equals(ConnectionState.Open))
                connection.Close();
        }
        
        public static void OpenConnection(MySqlConnection connection)
        {
            if(connection.State.Equals(ConnectionState.Closed))
                connection.Open();
        }

        public static void Init(MySqlConnection connection, MySqlCommand command)
        {
            OpenConnection(connection);
            ClearCommand(command);
        }

        private static void ClearCommand(MySqlCommand command)
            => command.Parameters.Clear();
    }
}
