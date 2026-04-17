using MySql.Data.MySqlClient;
using ProjetoUFCD1790.App.Model;
using ProjetoUFCD1790.App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUFCD1790.App.Data
{
    public class CategoriaRepository
    {
        public List<CategoriaModel> obterCategorias()
        {

            var categoriaModel = new List<CategoriaModel>();
            string query = "SELECT id,nome FROM categoria";

            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoria = new CategoriaModel
                            {
                                id = reader.GetInt32("id"),
                                nomeCategoria = reader.GetString("nome"),

                            };
                            categoriaModel.Add(categoria);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }

            }
            return categoriaModel;
        }
    }
}
