namespace BingoWortGeber
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRandom = new System.Windows.Forms.Button();
            this.tbRandomString = new System.Windows.Forms.TextBox();
            this.rtbFullWordList = new System.Windows.Forms.RichTextBox();
            this.btnGetStringPool = new System.Windows.Forms.Button();
            this.tbAddWord = new System.Windows.Forms.TextBox();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lbTextSize = new System.Windows.Forms.Label();
            this.tbClose = new System.Windows.Forms.Button();
            this.ntbTextSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ntbTextSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRandom
            // 
            this.btnRandom.BackColor = System.Drawing.Color.White;
            this.btnRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnRandom.Location = new System.Drawing.Point(12, 12);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(153, 38);
            this.btnRandom.TabIndex = 0;
            this.btnRandom.Text = "Bekomme Wort";
            this.btnRandom.UseVisualStyleBackColor = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // tbRandomString
            // 
            this.tbRandomString.BackColor = System.Drawing.Color.White;
            this.tbRandomString.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRandomString.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.tbRandomString.Location = new System.Drawing.Point(171, 12);
            this.tbRandomString.Name = "tbRandomString";
            this.tbRandomString.ReadOnly = true;
            this.tbRandomString.Size = new System.Drawing.Size(413, 38);
            this.tbRandomString.TabIndex = 1;
            this.tbRandomString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtbFullWordList
            // 
            this.rtbFullWordList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFullWordList.BackColor = System.Drawing.Color.White;
            this.rtbFullWordList.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbFullWordList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.rtbFullWordList.Location = new System.Drawing.Point(171, 100);
            this.rtbFullWordList.Name = "rtbFullWordList";
            this.rtbFullWordList.ReadOnly = true;
            this.rtbFullWordList.Size = new System.Drawing.Size(782, 489);
            this.rtbFullWordList.TabIndex = 2;
            this.rtbFullWordList.Text = "";
            // 
            // btnGetStringPool
            // 
            this.btnGetStringPool.BackColor = System.Drawing.Color.White;
            this.btnGetStringPool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetStringPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetStringPool.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnGetStringPool.Location = new System.Drawing.Point(12, 100);
            this.btnGetStringPool.Name = "btnGetStringPool";
            this.btnGetStringPool.Size = new System.Drawing.Size(153, 38);
            this.btnGetStringPool.TabIndex = 3;
            this.btnGetStringPool.Text = "Wörter ausgeben";
            this.btnGetStringPool.UseVisualStyleBackColor = false;
            this.btnGetStringPool.Click += new System.EventHandler(this.btnGetStringPool_Click);
            // 
            // tbAddWord
            // 
            this.tbAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.tbAddWord.Location = new System.Drawing.Point(171, 56);
            this.tbAddWord.Name = "tbAddWord";
            this.tbAddWord.Size = new System.Drawing.Size(413, 38);
            this.tbAddWord.TabIndex = 5;
            this.tbAddWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddWord
            // 
            this.btnAddWord.BackColor = System.Drawing.Color.White;
            this.btnAddWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnAddWord.Location = new System.Drawing.Point(12, 56);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(153, 38);
            this.btnAddWord.TabIndex = 4;
            this.btnAddWord.Text = "Wort hinzufügen";
            this.btnAddWord.UseVisualStyleBackColor = false;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Poor Richard", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(667, 24);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(234, 53);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "Bingonator";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.White;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnRestart.Location = new System.Drawing.Point(12, 144);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(153, 38);
            this.btnRestart.TabIndex = 7;
            this.btnRestart.Text = "Spiel neustarten";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lbTextSize
            // 
            this.lbTextSize.AutoSize = true;
            this.lbTextSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextSize.ForeColor = System.Drawing.Color.White;
            this.lbTextSize.Location = new System.Drawing.Point(11, 221);
            this.lbTextSize.Name = "lbTextSize";
            this.lbTextSize.Size = new System.Drawing.Size(157, 29);
            this.lbTextSize.TabIndex = 9;
            this.lbTextSize.Text = "Schriftgröße";
            this.lbTextSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbClose
            // 
            this.tbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbClose.BackColor = System.Drawing.Color.White;
            this.tbClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.tbClose.Location = new System.Drawing.Point(12, 551);
            this.tbClose.Name = "tbClose";
            this.tbClose.Size = new System.Drawing.Size(153, 38);
            this.tbClose.TabIndex = 10;
            this.tbClose.Text = "Schließen";
            this.tbClose.UseVisualStyleBackColor = false;
            this.tbClose.Click += new System.EventHandler(this.tbClose_Click);
            // 
            // ntbTextSize
            // 
            this.ntbTextSize.BackColor = System.Drawing.Color.White;
            this.ntbTextSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbTextSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.ntbTextSize.Location = new System.Drawing.Point(12, 253);
            this.ntbTextSize.Name = "ntbTextSize";
            this.ntbTextSize.ReadOnly = true;
            this.ntbTextSize.Size = new System.Drawing.Size(153, 38);
            this.ntbTextSize.TabIndex = 11;
            this.ntbTextSize.ValueChanged += new System.EventHandler(this.ntbTextSize_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(965, 597);
            this.Controls.Add(this.ntbTextSize);
            this.Controls.Add(this.tbClose);
            this.Controls.Add(this.lbTextSize);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.tbAddWord);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.btnGetStringPool);
            this.Controls.Add(this.rtbFullWordList);
            this.Controls.Add(this.tbRandomString);
            this.Controls.Add(this.btnRandom);
            this.MinimumSize = new System.Drawing.Size(981, 636);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Bingonator";
            ((System.ComponentModel.ISupportInitialize)(this.ntbTextSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.TextBox tbRandomString;
        private System.Windows.Forms.RichTextBox rtbFullWordList;
        private System.Windows.Forms.Button btnGetStringPool;
        private System.Windows.Forms.TextBox tbAddWord;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lbTextSize;
        private System.Windows.Forms.Button tbClose;
        private System.Windows.Forms.NumericUpDown ntbTextSize;
    }
}

