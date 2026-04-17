

using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using ProjetoUFCD1790.App.Model;
using ProjetoUFCD1790.App.Utils;


namespace ProjetoUFCD1790.App.Repositories
{
    public class LoginRepository
    {
        public LoginModel ValidaLogin(LoginModel login)
        {

            string query = "SELECT u.id as usuario_id, u.nome as nomeUsuario, l.id as login_id, l.usuario FROM login l INNER JOIN usuario u ON u.id_login = l.id WHERE l.usuario = @nome AND l.senha = @pass;";

            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = login.Usuario;
                cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = login.Senha;


                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())// lê o resultado da consulta
                {
                    if (reader.Read())
                    {
                        return new LoginModel
                        {
                            Id = reader.GetInt32("usuario_id"), // já vem o ID do usuário
                            Usuario = reader.GetString("nomeUsuario")
                        };
                    }
                }
            }
            return null; // login falhou
        }

        public int CadastrarLogin(string usuario, string senha)
        {
            string query = "INSERT INTO login (usuario, senha) VALUES (@usuario, @senha)";
            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = senha;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    // pega o ID gerado
                    int idGerado = (int)cmd.LastInsertedId;
                    return idGerado;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }
            }
        }

        public void ExcluirLogin(int idLogin)
        {
            string query = "DELETE FROM login WHERE id = @idLogin";
            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.Add("@idLogin", MySqlDbType.Int32).Value = idLogin;
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
    }
}
