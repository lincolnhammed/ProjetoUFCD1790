using MySql.Data.MySqlClient;
using ProjetoUFCD1790.App.Model;
using ProjetoUFCD1790.App.Utils;
using System;
using System.Collections.Generic;


namespace ProjetoUFCD1790.App.Data
{
    public class ResultadoRepository
    {
        public void SaveResultado(ResultadoModel resultado)
        {
            string query = "INSERT INTO resultado (categoria, totalPerguntas, acertos, percentagem, id_usuario) VALUES (@categoria, @totalPerguntas, @acertos, @percentagem, @id_userLogado)";

            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                ResultadoRepository resultadoRepo = new ResultadoRepository();
                cmd.Parameters.Add("@categoria", MySqlDbType.VarChar).Value = resultado.Categoria;
                cmd.Parameters.Add("@totalPerguntas", MySqlDbType.Int32).Value = resultado.TotalPerguntas;
                cmd.Parameters.Add("@acertos", MySqlDbType.Int32).Value = resultado.Acertos;
                cmd.Parameters.Add("@percentagem", MySqlDbType.Decimal).Value = resultado.Percentagem;
                cmd.Parameters.Add("@id_userLogado", MySqlDbType.Int32).Value = resultado.Id_userLogado;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }

            }
        }

        public List<ResultadoModel> ResultadosPorUsuario(int idUsuario)
        {
          ResultadoRepository resultadoRepo = new ResultadoRepository();
            var resultados = new List<ResultadoModel>();
            string query = "SELECT id_usuario,categoria, totalPerguntas, acertos, percentagem,data_realizacao FROM resultado WHERE id_usuario = @idUsuario";
            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.Add("@idUsuario", MySqlDbType.Int32).Value = idUsuario;
                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultados.Add(new ResultadoModel
                            {
                                Id_userLogado = reader.GetInt32("id_usuario"),
                                Categoria = reader.GetString("categoria"),
                                TotalPerguntas = reader.GetInt32("totalPerguntas"),
                                Acertos = reader.GetInt32("acertos"),
                                Percentagem = reader.GetDouble("percentagem"),
                                data_realizacao = reader.GetDateTime("data_realizacao")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }
            }
            return resultados;
        }
    }
}
