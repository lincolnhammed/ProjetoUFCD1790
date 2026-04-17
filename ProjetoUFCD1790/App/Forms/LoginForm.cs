using ProjetoUFCD1790.App.Service;
using ProjetoUFCD1790.App.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoUFCD1790.App.Forms
{
    public partial class LoginForm : Form
    {
        private LoginService loginService;
        private bool senhaVisivel = false;
        public LoginForm()
        {
            InitializeComponent();
            loginService = new LoginService();
            lbl_erro.Visible = false;

            // Estado inicial (senha escondida)
            txt_pass.PasswordChar = '*';
            img_ver2.Image = Properties.Resources.olhoFechado;
            img_sair.Image = Properties.Resources.sair;
            pictureBox2.Image = Properties.Resources.pessoa;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var login = loginService.validarLogin(txt_user.Text.Trim(), txt_pass.Text.Trim());

            if (login!=null)
            {
                LoginService.sessaoLogin(login.Id, login.Usuario);
                GerirForms.TrocarForms(this, new home());
            }
            else
            {
                txt_pass.Text = "";
                txt_user.Text = "";
                txt_user.Focus();
                lbl_erro.ForeColor = Color.Red;
                lbl_erro.Visible = true;
            }
        }

        private void img_sair_Click(object sender, EventArgs e)
        {
           GerirForms.sair();
        }

  

        private void img_ver2_Click(object sender, EventArgs e)
        {
            senhaVisivel = !senhaVisivel;

            if (senhaVisivel)
            {
                // Mostrar senha
                txt_pass.PasswordChar = '\0';
                img_ver2.Image = Properties.Resources.olho;
            }
            else
            {
                // Esconder senha
                txt_pass.PasswordChar = '*';
                img_ver2.Image = Properties.Resources.olhoFechado;
            }
        }
    }
}
