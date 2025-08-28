namespace PersonelTakip
{
    partial class EmployeeForm
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
            lblWelcome = new Label();
            btnCheckIn = new Button();
            btnLogout = new Button();
            btnNotCame = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 28.2F, FontStyle.Italic, GraphicsUnit.Point, 162);
            lblWelcome.Location = new Point(40, 284);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(260, 62);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Hoşgeldiniz";
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = Color.MediumAquamarine;
            btnCheckIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCheckIn.ForeColor = SystemColors.ControlText;
            btnCheckIn.Location = new Point(40, 30);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(340, 144);
            btnCheckIn.TabIndex = 1;
            btnCheckIn.Text = "İşe Giriş";
            btnCheckIn.UseVisualStyleBackColor = false;
            btnCheckIn.Click += btnCheckIn_Click_1;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.ActiveCaption;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnLogout.ForeColor = SystemColors.HighlightText;
            btnLogout.Location = new Point(40, 503);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(727, 144);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Ana Ekrana Dön";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // btnNotCame
            // 
            btnNotCame.BackColor = Color.MediumAquamarine;
            btnNotCame.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnNotCame.ForeColor = SystemColors.ControlText;
            btnNotCame.Location = new Point(406, 30);
            btnNotCame.Name = "btnNotCame";
            btnNotCame.Size = new Size(340, 144);
            btnNotCame.TabIndex = 3;
            btnNotCame.Text = "İşten Çıkış";
            btnNotCame.UseVisualStyleBackColor = false;
            btnNotCame.Click += btnNotCame_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            ClientSize = new Size(800, 670);
            Controls.Add(btnNotCame);
            Controls.Add(btnLogout);
            Controls.Add(btnCheckIn);
            Controls.Add(lblWelcome);
            ForeColor = SystemColors.ControlText;
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnCheckIn;
        private Button btnLogout;
        private Button btnNotCame;
    }
}