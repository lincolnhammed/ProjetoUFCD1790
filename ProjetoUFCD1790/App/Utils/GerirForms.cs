using System.Windows.Forms;

namespace ProjetoUFCD1790.App.Utils
{
    internal class GerirForms
    {
        public static void TrocarForms(Form formAtual, Form novoForm)
        {
            formAtual.Hide();
            novoForm.ShowDialog();
            formAtual.Close();

        }

        public static void sair()
        {
            Application.Exit(); // fecha toda a aplicação
        }
    }
}
