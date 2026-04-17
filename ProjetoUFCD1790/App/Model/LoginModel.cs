namespace ProjetoUFCD1790.App.Model
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public LoginModel(string usuario, string senha)
        {
            this.Usuario = usuario;
            this.Senha = senha;
        }
      
        public LoginModel()
        {
        }
    }
}
