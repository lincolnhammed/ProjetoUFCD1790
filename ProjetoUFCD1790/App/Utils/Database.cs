using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUFCD1790.App.Utils
{
    public static class Database
    {
        public static string ConnectionString =>
           ConfigurationManager.ConnectionStrings["minhaConnectionApp"].ConnectionString;

        // Retorna uma conexão MySQL pronta
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
