namespace PersonelTakip
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtEmployeeID = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblMessage = new Label();
            label1 = new Label();
            label2 = new Label();
            btnDel = new Button();
            SuspendLayout();
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(392, 264);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(263, 27);
            txtEmployeeID.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(392, 334);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(263, 27);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(532, 409);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(123, 43);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Giriş Yap";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI Semibold", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblMessage.ForeColor = SystemColors.MenuHighlight;
            lblMessage.Location = new Point(267, 92);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(330, 62);
            lblMessage.TabIndex = 3;
            lblMessage.Text = "HOŞGELDİNİZ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.MenuText;
            label1.Location = new Point(209, 260);
            label1.Name = "label1";
            label1.Size = new Size(81, 28);
            label1.TabIndex = 4;
            label1.Text = "User ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.MenuText;
            label2.Location = new Point(209, 330);
            label2.Name = "label2";
            label2.Size = new Size(101, 28);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.Red;
            btnDel.ForeColor = SystemColors.ButtonHighlight;
            btnDel.Location = new Point(392, 409);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(117, 43);
            btnDel.TabIndex = 6;
            btnDel.Text = "Temizle";
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(900, 666);
            Controls.Add(btnDel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblMessage);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmployeeID);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmployeeID;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblMessage;
        private Label label1;
        private Label label2;
        private Button btnDel;
    }
}
