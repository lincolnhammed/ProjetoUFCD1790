namespace ProjetoUFCD1790.App.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.img_sair = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_erro = new System.Windows.Forms.Label();
            this.img_ver2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.img_sair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_ver2)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(94, 209);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(114, 20);
            this.txt_user.TabIndex = 0;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(94, 235);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(89, 20);
            this.txt_pass.TabIndex = 1;
            // 
            // btn_login
            // 
            this.btn_login.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_login.Location = new System.Drawing.Point(94, 284);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(105, 23);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lincoln Silva 2026";
            // 
            // img_sair
            // 
            this.img_sair.Location = new System.Drawing.Point(262, 12);
            this.img_sair.Name = "img_sair";
            this.img_sair.Size = new System.Drawing.Size(17, 22);
            this.img_sair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_sair.TabIndex = 4;
            this.img_sair.TabStop = false;
            this.img_sair.Click += new System.EventHandler(this.img_sair_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(94, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 97);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_erro
            // 
            this.lbl_erro.AutoSize = true;
            this.lbl_erro.Location = new System.Drawing.Point(91, 310);
            this.lbl_erro.Name = "lbl_erro";
            this.lbl_erro.Size = new System.Drawing.Size(108, 13);
            this.lbl_erro.TabIndex = 8;
            this.lbl_erro.Text = "Erro ao efetuar login!!";
            // 
            // img_ver2
            // 
            this.img_ver2.Location = new System.Drawing.Point(189, 235);
            this.img_ver2.Name = "img_ver2";
            this.img_ver2.Size = new System.Drawing.Size(20, 21);
            this.img_ver2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_ver2.TabIndex = 9;
            this.img_ver2.TabStop = false;
            this.img_ver2.Click += new System.EventHandler(this.img_ver2_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 413);
            this.ControlBox = false;
            this.Controls.Add(this.img_ver2);
            this.Controls.Add(this.lbl_erro);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.img_sair);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.img_sair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_ver2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox img_sair;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbl_erro;
        private System.Windows.Forms.PictureBox img_ver2;
    }
}