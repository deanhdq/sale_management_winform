
namespace sale_app
{
    partial class frmQuantity
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
            this.panelUnit = new System.Windows.Forms.Panel();
            this.cbUnits = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelQuantity = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panelBtnConfirm = new System.Windows.Forms.Panel();
            this.panelUnit.SuspendLayout();
            this.panelQuantity.SuspendLayout();
            this.panelBtnConfirm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUnit
            // 
            this.panelUnit.Controls.Add(this.cbUnits);
            this.panelUnit.Controls.Add(this.label1);
            this.panelUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUnit.Location = new System.Drawing.Point(0, 0);
            this.panelUnit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelUnit.Name = "panelUnit";
            this.panelUnit.Size = new System.Drawing.Size(389, 70);
            this.panelUnit.TabIndex = 1;
            // 
            // cbUnits
            // 
            this.cbUnits.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUnits.FormattingEnabled = true;
            this.cbUnits.Location = new System.Drawing.Point(143, 21);
            this.cbUnits.Name = "cbUnits";
            this.cbUnits.Size = new System.Drawing.Size(187, 41);
            this.cbUnits.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đơn vị tính:";
            // 
            // panelQuantity
            // 
            this.panelQuantity.Controls.Add(this.label2);
            this.panelQuantity.Controls.Add(this.tbQuantity);
            this.panelQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuantity.Location = new System.Drawing.Point(0, 70);
            this.panelQuantity.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelQuantity.Name = "panelQuantity";
            this.panelQuantity.Size = new System.Drawing.Size(389, 79);
            this.panelQuantity.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lượng:";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuantity.Location = new System.Drawing.Point(143, 19);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(187, 40);
            this.tbQuantity.TabIndex = 0;
            this.tbQuantity.Text = "1";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(170)))), ((int)(((byte)(109)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(144, 15);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 38);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panelBtnConfirm
            // 
            this.panelBtnConfirm.Controls.Add(this.btnConfirm);
            this.panelBtnConfirm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBtnConfirm.Location = new System.Drawing.Point(0, 149);
            this.panelBtnConfirm.Name = "panelBtnConfirm";
            this.panelBtnConfirm.Size = new System.Drawing.Size(389, 66);
            this.panelBtnConfirm.TabIndex = 8;
            // 
            // frmQuantity
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 231);
            this.Controls.Add(this.panelBtnConfirm);
            this.Controls.Add(this.panelQuantity);
            this.Controls.Add(this.panelUnit);
            this.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập số lượng";
            this.panelUnit.ResumeLayout(false);
            this.panelUnit.PerformLayout();
            this.panelQuantity.ResumeLayout(false);
            this.panelQuantity.PerformLayout();
            this.panelBtnConfirm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbUnits;
        private System.Windows.Forms.Button btnConfirm;
        public System.Windows.Forms.Panel panelBtnConfirm;
        public System.Windows.Forms.Panel panelUnit;
        public System.Windows.Forms.Panel panelQuantity;
        public System.Windows.Forms.TextBox tbQuantity;
    }
}