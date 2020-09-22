namespace BingoWortGeber
{
    partial class frmMain
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
            this.rtbFullWordList = new System.Windows.Forms.RichTextBox();
            this.btnGetStringPool = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnStartOrQuit = new System.Windows.Forms.Button();
            this.lbTextSize = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ntbTextSize = new System.Windows.Forms.NumericUpDown();
            this.pAddWord = new System.Windows.Forms.Panel();
            this.tbAddWord = new System.Windows.Forms.TextBox();
            this.tbRandomString = new System.Windows.Forms.TextBox();
            this.pGetWord = new System.Windows.Forms.Panel();
            this.pWordList = new System.Windows.Forms.Panel();
            this.lbRemainingWords = new System.Windows.Forms.Label();
            this.lbCounter = new System.Windows.Forms.Label();
            this.pTextSize = new System.Windows.Forms.Panel();
            this.btnResetWords = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ntbTextSize)).BeginInit();
            this.pAddWord.SuspendLayout();
            this.pGetWord.SuspendLayout();
            this.pWordList.SuspendLayout();
            this.pTextSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRandom
            // 
            this.btnRandom.BackColor = System.Drawing.Color.White;
            this.btnRandom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnRandom.FlatAppearance.BorderSize = 2;
            this.btnRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnRandom.Location = new System.Drawing.Point(12, 12);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(153, 35);
            this.btnRandom.TabIndex = 0;
            this.btnRandom.Text = "Bekomme Wort";
            this.btnRandom.UseVisualStyleBackColor = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // rtbFullWordList
            // 
            this.rtbFullWordList.BackColor = System.Drawing.Color.White;
            this.rtbFullWordList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbFullWordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbFullWordList.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbFullWordList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.rtbFullWordList.Location = new System.Drawing.Point(2, 2);
            this.rtbFullWordList.Name = "rtbFullWordList";
            this.rtbFullWordList.ReadOnly = true;
            this.rtbFullWordList.Size = new System.Drawing.Size(790, 492);
            this.rtbFullWordList.TabIndex = 2;
            this.rtbFullWordList.TabStop = false;
            this.rtbFullWordList.Text = "";
            // 
            // btnGetStringPool
            // 
            this.btnGetStringPool.BackColor = System.Drawing.Color.White;
            this.btnGetStringPool.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnGetStringPool.FlatAppearance.BorderSize = 2;
            this.btnGetStringPool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetStringPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetStringPool.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnGetStringPool.Location = new System.Drawing.Point(12, 95);
            this.btnGetStringPool.Name = "btnGetStringPool";
            this.btnGetStringPool.Size = new System.Drawing.Size(153, 35);
            this.btnGetStringPool.TabIndex = 3;
            this.btnGetStringPool.Text = "Wörter ausgeben";
            this.btnGetStringPool.UseVisualStyleBackColor = false;
            this.btnGetStringPool.Click += new System.EventHandler(this.btnGetStringPool_Click);
            // 
            // btnAddWord
            // 
            this.btnAddWord.BackColor = System.Drawing.Color.White;
            this.btnAddWord.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnAddWord.FlatAppearance.BorderSize = 2;
            this.btnAddWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnAddWord.Location = new System.Drawing.Point(12, 54);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(153, 35);
            this.btnAddWord.TabIndex = 1;
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
            this.lbTitle.Location = new System.Drawing.Point(675, 23);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(234, 53);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "Bingonator";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStartOrQuit
            // 
            this.btnStartOrQuit.BackColor = System.Drawing.Color.White;
            this.btnStartOrQuit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnStartOrQuit.FlatAppearance.BorderSize = 2;
            this.btnStartOrQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartOrQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartOrQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnStartOrQuit.Location = new System.Drawing.Point(12, 136);
            this.btnStartOrQuit.Name = "btnStartOrQuit";
            this.btnStartOrQuit.Size = new System.Drawing.Size(153, 35);
            this.btnStartOrQuit.TabIndex = 4;
            this.btnStartOrQuit.Text = "Spiel starten";
            this.btnStartOrQuit.UseVisualStyleBackColor = false;
            this.btnStartOrQuit.Click += new System.EventHandler(this.btnStartOrQuit_Click);
            // 
            // lbTextSize
            // 
            this.lbTextSize.AutoSize = true;
            this.lbTextSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextSize.ForeColor = System.Drawing.Color.White;
            this.lbTextSize.Location = new System.Drawing.Point(11, 294);
            this.lbTextSize.Name = "lbTextSize";
            this.lbTextSize.Size = new System.Drawing.Size(157, 29);
            this.lbTextSize.TabIndex = 9;
            this.lbTextSize.Text = "Schriftgröße";
            this.lbTextSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnClose.Location = new System.Drawing.Point(14, 589);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(153, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Schließen";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ntbTextSize
            // 
            this.ntbTextSize.BackColor = System.Drawing.Color.White;
            this.ntbTextSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ntbTextSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbTextSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbTextSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.ntbTextSize.Location = new System.Drawing.Point(2, 2);
            this.ntbTextSize.Name = "ntbTextSize";
            this.ntbTextSize.ReadOnly = true;
            this.ntbTextSize.Size = new System.Drawing.Size(149, 34);
            this.ntbTextSize.TabIndex = 11;
            this.ntbTextSize.TabStop = false;
            this.ntbTextSize.ValueChanged += new System.EventHandler(this.ntbTextSize_ValueChanged);
            // 
            // pAddWord
            // 
            this.pAddWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pAddWord.Controls.Add(this.tbAddWord);
            this.pAddWord.Location = new System.Drawing.Point(175, 54);
            this.pAddWord.Name = "pAddWord";
            this.pAddWord.Padding = new System.Windows.Forms.Padding(2);
            this.pAddWord.Size = new System.Drawing.Size(413, 35);
            this.pAddWord.TabIndex = 2;
            // 
            // tbAddWord
            // 
            this.tbAddWord.BackColor = System.Drawing.Color.White;
            this.tbAddWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAddWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.tbAddWord.Location = new System.Drawing.Point(2, 2);
            this.tbAddWord.Margin = new System.Windows.Forms.Padding(4);
            this.tbAddWord.Name = "tbAddWord";
            this.tbAddWord.Size = new System.Drawing.Size(409, 31);
            this.tbAddWord.TabIndex = 2;
            this.tbAddWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRandomString
            // 
            this.tbRandomString.BackColor = System.Drawing.Color.White;
            this.tbRandomString.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRandomString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRandomString.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRandomString.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.tbRandomString.Location = new System.Drawing.Point(2, 2);
            this.tbRandomString.Margin = new System.Windows.Forms.Padding(4);
            this.tbRandomString.Name = "tbRandomString";
            this.tbRandomString.ReadOnly = true;
            this.tbRandomString.Size = new System.Drawing.Size(409, 31);
            this.tbRandomString.TabIndex = 1;
            this.tbRandomString.TabStop = false;
            this.tbRandomString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pGetWord
            // 
            this.pGetWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pGetWord.Controls.Add(this.tbRandomString);
            this.pGetWord.Location = new System.Drawing.Point(175, 12);
            this.pGetWord.Name = "pGetWord";
            this.pGetWord.Padding = new System.Windows.Forms.Padding(2);
            this.pGetWord.Size = new System.Drawing.Size(413, 35);
            this.pGetWord.TabIndex = 13;
            // 
            // pWordList
            // 
            this.pWordList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pWordList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pWordList.Controls.Add(this.lbRemainingWords);
            this.pWordList.Controls.Add(this.lbCounter);
            this.pWordList.Controls.Add(this.rtbFullWordList);
            this.pWordList.Location = new System.Drawing.Point(175, 95);
            this.pWordList.Name = "pWordList";
            this.pWordList.Padding = new System.Windows.Forms.Padding(2, 2, 2, 35);
            this.pWordList.Size = new System.Drawing.Size(794, 529);
            this.pWordList.TabIndex = 15;
            // 
            // lbRemainingWords
            // 
            this.lbRemainingWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRemainingWords.AutoSize = true;
            this.lbRemainingWords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.lbRemainingWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemainingWords.ForeColor = System.Drawing.Color.White;
            this.lbRemainingWords.Location = new System.Drawing.Point(5, 503);
            this.lbRemainingWords.Name = "lbRemainingWords";
            this.lbRemainingWords.Size = new System.Drawing.Size(35, 17);
            this.lbRemainingWords.TabIndex = 4;
            this.lbRemainingWords.Text = "test";
            // 
            // lbCounter
            // 
            this.lbCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCounter.AutoSize = true;
            this.lbCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.lbCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCounter.ForeColor = System.Drawing.Color.White;
            this.lbCounter.Location = new System.Drawing.Point(684, 503);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Size = new System.Drawing.Size(35, 17);
            this.lbCounter.TabIndex = 3;
            this.lbCounter.Text = "test";
            // 
            // pTextSize
            // 
            this.pTextSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pTextSize.Controls.Add(this.ntbTextSize);
            this.pTextSize.Location = new System.Drawing.Point(12, 338);
            this.pTextSize.Name = "pTextSize";
            this.pTextSize.Padding = new System.Windows.Forms.Padding(2);
            this.pTextSize.Size = new System.Drawing.Size(153, 38);
            this.pTextSize.TabIndex = 3;
            // 
            // btnResetWords
            // 
            this.btnResetWords.BackColor = System.Drawing.Color.White;
            this.btnResetWords.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnResetWords.FlatAppearance.BorderSize = 2;
            this.btnResetWords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetWords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnResetWords.Location = new System.Drawing.Point(12, 177);
            this.btnResetWords.Name = "btnResetWords";
            this.btnResetWords.Size = new System.Drawing.Size(153, 35);
            this.btnResetWords.TabIndex = 16;
            this.btnResetWords.Text = "Zurücksetzen";
            this.btnResetWords.UseVisualStyleBackColor = false;
            this.btnResetWords.Click += new System.EventHandler(this.btnResetWords_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(981, 636);
            this.Controls.Add(this.btnResetWords);
            this.Controls.Add(this.pTextSize);
            this.Controls.Add(this.pWordList);
            this.Controls.Add(this.pAddWord);
            this.Controls.Add(this.pGetWord);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTextSize);
            this.Controls.Add(this.btnStartOrQuit);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.btnGetStringPool);
            this.Controls.Add(this.btnRandom);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(981, 636);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Bingonator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ntbTextSize)).EndInit();
            this.pAddWord.ResumeLayout(false);
            this.pAddWord.PerformLayout();
            this.pGetWord.ResumeLayout(false);
            this.pGetWord.PerformLayout();
            this.pWordList.ResumeLayout(false);
            this.pWordList.PerformLayout();
            this.pTextSize.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.RichTextBox rtbFullWordList;
        private System.Windows.Forms.Button btnGetStringPool;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnStartOrQuit;
        private System.Windows.Forms.Label lbTextSize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.NumericUpDown ntbTextSize;
        private System.Windows.Forms.Panel pAddWord;
        private System.Windows.Forms.TextBox tbAddWord;
        private System.Windows.Forms.TextBox tbRandomString;
        private System.Windows.Forms.Panel pGetWord;
        private System.Windows.Forms.Panel pWordList;
        private System.Windows.Forms.Panel pTextSize;
        private System.Windows.Forms.Label lbCounter;
        private System.Windows.Forms.Label lbRemainingWords;
        private System.Windows.Forms.Button btnResetWords;
    }
}

