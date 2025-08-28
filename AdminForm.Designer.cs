namespace PersonelTakip
{
    partial class AdminForm
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
            dgvAttendance = new DataGridView();
            btnReflesh = new Button();
            dtpDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // dgvAttendance
            // 
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Location = new Point(85, 141);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.RowHeadersWidth = 51;
            dgvAttendance.Size = new Size(547, 268);
            dgvAttendance.TabIndex = 0;
            // 
            // btnReflesh
            // 
            btnReflesh.BackColor = Color.BurlyWood;
            btnReflesh.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnReflesh.Location = new Point(85, 469);
            btnReflesh.Name = "btnReflesh";
            btnReflesh.Size = new Size(547, 43);
            btnReflesh.TabIndex = 3;
            btnReflesh.Text = "Yenile";
            btnReflesh.UseVisualStyleBackColor = false;
            btnReflesh.Click += btnReflesh_Click;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(538, 30);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 2;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 670);
            Controls.Add(dtpDate);
            Controls.Add(btnReflesh);
            Controls.Add(dgvAttendance);
            Name = "AdminForm";
            Text = "AminForm";
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAttendance;
        private Button btnReflesh;
        private DateTimePicker dtpDate;
    }
}