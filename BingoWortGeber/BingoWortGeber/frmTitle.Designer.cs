namespace BingoWortGeber
{
    partial class frmTitle
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lbTextSize = new System.Windows.Forms.Label();
            this.pTitle = new System.Windows.Forms.Panel();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.pLeftBorder = new System.Windows.Forms.Panel();
            this.pRightBorder = new System.Windows.Forms.Panel();
            this.pBottomBorder = new System.Windows.Forms.Panel();
            this.pTopBorder = new System.Windows.Forms.Panel();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnClose.Location = new System.Drawing.Point(12, 82);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(153, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Abbrechen";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.White;
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnSubmit.FlatAppearance.BorderSize = 2;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnSubmit.Location = new System.Drawing.Point(171, 82);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(153, 35);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Übernehmen";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbTextSize
            // 
            this.lbTextSize.AutoSize = true;
            this.lbTextSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextSize.ForeColor = System.Drawing.Color.White;
            this.lbTextSize.Location = new System.Drawing.Point(9, 10);
            this.lbTextSize.Name = "lbTextSize";
            this.lbTextSize.Size = new System.Drawing.Size(228, 29);
            this.lbTextSize.TabIndex = 10;
            this.lbTextSize.Text = "Listentiteleingabe:";
            this.lbTextSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pTitle
            // 
            this.pTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pTitle.Controls.Add(this.tbTitle);
            this.pTitle.Location = new System.Drawing.Point(12, 41);
            this.pTitle.Name = "pTitle";
            this.pTitle.Padding = new System.Windows.Forms.Padding(2);
            this.pTitle.Size = new System.Drawing.Size(312, 35);
            this.pTitle.TabIndex = 11;
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.White;
            this.tbTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.tbTitle.Location = new System.Drawing.Point(2, 2);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(4);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(308, 31);
            this.tbTitle.TabIndex = 2;
            this.tbTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // pLeftBorder
            // 
            this.pLeftBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pLeftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeftBorder.Location = new System.Drawing.Point(0, 0);
            this.pLeftBorder.Name = "pLeftBorder";
            this.pLeftBorder.Size = new System.Drawing.Size(2, 125);
            this.pLeftBorder.TabIndex = 24;
            // 
            // pRightBorder
            // 
            this.pRightBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pRightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.pRightBorder.Location = new System.Drawing.Point(332, 0);
            this.pRightBorder.Name = "pRightBorder";
            this.pRightBorder.Size = new System.Drawing.Size(2, 125);
            this.pRightBorder.TabIndex = 23;
            // 
            // pBottomBorder
            // 
            this.pBottomBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pBottomBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottomBorder.Location = new System.Drawing.Point(2, 123);
            this.pBottomBorder.Name = "pBottomBorder";
            this.pBottomBorder.Size = new System.Drawing.Size(330, 2);
            this.pBottomBorder.TabIndex = 25;
            // 
            // pTopBorder
            // 
            this.pTopBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pTopBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTopBorder.Location = new System.Drawing.Point(2, 0);
            this.pTopBorder.Name = "pTopBorder";
            this.pTopBorder.Size = new System.Drawing.Size(330, 2);
            this.pTopBorder.TabIndex = 26;
            // 
            // frmTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(334, 125);
            this.ControlBox = false;
            this.Controls.Add(this.pTopBorder);
            this.Controls.Add(this.pBottomBorder);
            this.Controls.Add(this.pRightBorder);
            this.Controls.Add(this.pLeftBorder);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.lbTextSize);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTitle";
            this.Text = "frmTitle";
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lbTextSize;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Panel pLeftBorder;
        private System.Windows.Forms.Panel pRightBorder;
        private System.Windows.Forms.Panel pBottomBorder;
        private System.Windows.Forms.Panel pTopBorder;
    }
}