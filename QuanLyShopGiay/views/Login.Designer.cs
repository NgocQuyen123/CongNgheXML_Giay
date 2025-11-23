namespace QuanLyShopGiay.views
{
    partial class Login
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
            this.bg_login = new System.Windows.Forms.Panel();
            this.titleLogin = new System.Windows.Forms.Label();
            this.text_username = new System.Windows.Forms.TextBox();
            this.text_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.bg_login.SuspendLayout();
            this.SuspendLayout();
            // 
            // bg_login
            // 
            this.bg_login.BackColor = System.Drawing.Color.White;
            this.bg_login.Controls.Add(this.btn_login);
            this.bg_login.Controls.Add(this.text_password);
            this.bg_login.Controls.Add(this.text_username);
            this.bg_login.Controls.Add(this.titleLogin);
            this.bg_login.Location = new System.Drawing.Point(736, 177);
            this.bg_login.Name = "bg_login";
            this.bg_login.Size = new System.Drawing.Size(394, 444);
            this.bg_login.TabIndex = 0;
            this.bg_login.Paint += new System.Windows.Forms.PaintEventHandler(this.bg_login_Paint);
            // 
            // titleLogin
            // 
            this.titleLogin.AutoSize = true;
            this.titleLogin.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLogin.Location = new System.Drawing.Point(145, 53);
            this.titleLogin.Name = "titleLogin";
            this.titleLogin.Size = new System.Drawing.Size(113, 35);
            this.titleLogin.TabIndex = 0;
            this.titleLogin.Text = "Sign In";
            // 
            // text_username
            // 
            this.text_username.Location = new System.Drawing.Point(33, 122);
            this.text_username.Multiline = true;
            this.text_username.Name = "text_username";
            this.text_username.Size = new System.Drawing.Size(325, 50);
            this.text_username.TabIndex = 1;
            // 
            // text_password
            // 
            this.text_password.Location = new System.Drawing.Point(33, 213);
            this.text_password.Multiline = true;
            this.text_password.Name = "text_password";
            this.text_password.Size = new System.Drawing.Size(325, 50);
            this.text_password.TabIndex = 2;
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_login.Location = new System.Drawing.Point(135, 304);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(138, 56);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 833);
            this.Controls.Add(this.bg_login);
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.bg_login.ResumeLayout(false);
            this.bg_login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bg_login;
        private System.Windows.Forms.Label titleLogin;
        private System.Windows.Forms.TextBox text_username;
        private System.Windows.Forms.TextBox text_password;
        private System.Windows.Forms.Button btn_login;
    }
}