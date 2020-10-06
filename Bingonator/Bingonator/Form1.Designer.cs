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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnRandom = new System.Windows.Forms.Button();
            this.rtbFullWordList = new System.Windows.Forms.RichTextBox();
            this.btnGetStringPool = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnStartOrQuit = new System.Windows.Forms.Button();
            this.lbTextSize = new System.Windows.Forms.Label();
            this.ntbTextSize = new System.Windows.Forms.NumericUpDown();
            this.pAddWord = new System.Windows.Forms.Panel();
            this.tbAddWord = new System.Windows.Forms.TextBox();
            this.tbRandomString = new System.Windows.Forms.TextBox();
            this.pGetWord = new System.Windows.Forms.Panel();
            this.pWordList = new System.Windows.Forms.Panel();
            this.lbRemainingWords = new System.Windows.Forms.Label();
            this.lbCounter = new System.Windows.Forms.Label();
            this.pTextSize = new System.Windows.Forms.Panel();
            this.lbSize = new System.Windows.Forms.Label();
            this.btnNewList = new System.Windows.Forms.Button();
            this.lbMaxMin = new System.Windows.Forms.Label();
            this.lbMaxNormal = new System.Windows.Forms.Label();
            this.pTopBorder = new System.Windows.Forms.Panel();
            this.pBottomBorder = new System.Windows.Forms.Panel();
            this.pRightBorder = new System.Windows.Forms.Panel();
            this.pLeftBorder = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lbSection = new System.Windows.Forms.Label();
            this.cbTopic = new System.Windows.Forms.ComboBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tt1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbClose = new System.Windows.Forms.Label();
            this.tPoolWords = new System.Windows.Forms.Timer(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDeleteList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ntbTextSize)).BeginInit();
            this.pAddWord.SuspendLayout();
            this.pGetWord.SuspendLayout();
            this.pWordList.SuspendLayout();
            this.pTextSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRandom
            // 
            this.btnRandom.BackColor = System.Drawing.Color.White;
            this.btnRandom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnRandom.FlatAppearance.BorderSize = 2;
            this.btnRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRandom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnRandom.Location = new System.Drawing.Point(14, 14);
            this.btnRandom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(178, 40);
            this.btnRandom.TabIndex = 0;
            this.btnRandom.Text = "Nächstes Wort";
            this.btnRandom.UseVisualStyleBackColor = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // rtbFullWordList
            // 
            this.rtbFullWordList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFullWordList.BackColor = System.Drawing.Color.White;
            this.rtbFullWordList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbFullWordList.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rtbFullWordList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.rtbFullWordList.Location = new System.Drawing.Point(2, 2);
            this.rtbFullWordList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbFullWordList.Name = "rtbFullWordList";
            this.rtbFullWordList.ReadOnly = true;
            this.rtbFullWordList.Size = new System.Drawing.Size(922, 660);
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
            this.btnGetStringPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGetStringPool.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnGetStringPool.Location = new System.Drawing.Point(14, 110);
            this.btnGetStringPool.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGetStringPool.Name = "btnGetStringPool";
            this.btnGetStringPool.Size = new System.Drawing.Size(178, 40);
            this.btnGetStringPool.TabIndex = 3;
            this.btnGetStringPool.Text = "Alle Wörter ausgeben";
            this.btnGetStringPool.UseVisualStyleBackColor = false;
            this.btnGetStringPool.Click += new System.EventHandler(this.btnGetStringPool_Click);
            // 
            // btnAddWord
            // 
            this.btnAddWord.BackColor = System.Drawing.Color.White;
            this.btnAddWord.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnAddWord.FlatAppearance.BorderSize = 2;
            this.btnAddWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnAddWord.Location = new System.Drawing.Point(14, 62);
            this.btnAddWord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(178, 40);
            this.btnAddWord.TabIndex = 1;
            this.btnAddWord.Text = "Wort hinzufügen";
            this.btnAddWord.UseVisualStyleBackColor = false;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Poor Richard", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(788, 27);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.btnStartOrQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartOrQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnStartOrQuit.Location = new System.Drawing.Point(14, 157);
            this.btnStartOrQuit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStartOrQuit.Name = "btnStartOrQuit";
            this.btnStartOrQuit.Size = new System.Drawing.Size(178, 40);
            this.btnStartOrQuit.TabIndex = 4;
            this.btnStartOrQuit.Text = "Spiel starten";
            this.btnStartOrQuit.UseVisualStyleBackColor = false;
            this.btnStartOrQuit.Click += new System.EventHandler(this.btnStartOrQuit_Click);
            // 
            // lbTextSize
            // 
            this.lbTextSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTextSize.AutoSize = true;
            this.lbTextSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTextSize.ForeColor = System.Drawing.Color.White;
            this.lbTextSize.Location = new System.Drawing.Point(12, 735);
            this.lbTextSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTextSize.Name = "lbTextSize";
            this.lbTextSize.Size = new System.Drawing.Size(157, 29);
            this.lbTextSize.TabIndex = 9;
            this.lbTextSize.Text = "Schriftgröße";
            this.lbTextSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ntbTextSize
            // 
            this.ntbTextSize.BackColor = System.Drawing.Color.White;
            this.ntbTextSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ntbTextSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbTextSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ntbTextSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.ntbTextSize.Location = new System.Drawing.Point(2, 2);
            this.ntbTextSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ntbTextSize.Name = "ntbTextSize";
            this.ntbTextSize.ReadOnly = true;
            this.ntbTextSize.Size = new System.Drawing.Size(174, 40);
            this.ntbTextSize.TabIndex = 11;
            this.ntbTextSize.TabStop = false;
            this.ntbTextSize.ValueChanged += new System.EventHandler(this.ntbTextSize_ValueChanged);
            // 
            // pAddWord
            // 
            this.pAddWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pAddWord.Controls.Add(this.tbAddWord);
            this.pAddWord.Location = new System.Drawing.Point(204, 62);
            this.pAddWord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pAddWord.Name = "pAddWord";
            this.pAddWord.Padding = new System.Windows.Forms.Padding(2);
            this.pAddWord.Size = new System.Drawing.Size(482, 40);
            this.pAddWord.TabIndex = 2;
            // 
            // tbAddWord
            // 
            this.tbAddWord.BackColor = System.Drawing.Color.White;
            this.tbAddWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAddWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbAddWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.tbAddWord.Location = new System.Drawing.Point(2, 2);
            this.tbAddWord.Margin = new System.Windows.Forms.Padding(5);
            this.tbAddWord.MaxLength = 128;
            this.tbAddWord.Name = "tbAddWord";
            this.tbAddWord.Size = new System.Drawing.Size(478, 36);
            this.tbAddWord.TabIndex = 2;
            this.tbAddWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAddWord.TextChanged += new System.EventHandler(this.tbAddWord_TextChanged);
            // 
            // tbRandomString
            // 
            this.tbRandomString.BackColor = System.Drawing.Color.White;
            this.tbRandomString.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRandomString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRandomString.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbRandomString.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.tbRandomString.Location = new System.Drawing.Point(2, 2);
            this.tbRandomString.Margin = new System.Windows.Forms.Padding(5);
            this.tbRandomString.Name = "tbRandomString";
            this.tbRandomString.ReadOnly = true;
            this.tbRandomString.Size = new System.Drawing.Size(478, 36);
            this.tbRandomString.TabIndex = 1;
            this.tbRandomString.TabStop = false;
            this.tbRandomString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbRandomString.TextChanged += new System.EventHandler(this.tbRandomString_TextChanged);
            // 
            // pGetWord
            // 
            this.pGetWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pGetWord.Controls.Add(this.tbRandomString);
            this.pGetWord.Location = new System.Drawing.Point(204, 14);
            this.pGetWord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pGetWord.Name = "pGetWord";
            this.pGetWord.Padding = new System.Windows.Forms.Padding(2);
            this.pGetWord.Size = new System.Drawing.Size(482, 40);
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
            this.pWordList.Location = new System.Drawing.Point(204, 110);
            this.pWordList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pWordList.Name = "pWordList";
            this.pWordList.Padding = new System.Windows.Forms.Padding(2, 2, 2, 40);
            this.pWordList.Size = new System.Drawing.Size(926, 706);
            this.pWordList.TabIndex = 15;
            // 
            // lbRemainingWords
            // 
            this.lbRemainingWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRemainingWords.AutoSize = true;
            this.lbRemainingWords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.lbRemainingWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbRemainingWords.ForeColor = System.Drawing.Color.White;
            this.lbRemainingWords.Location = new System.Drawing.Point(6, 674);
            this.lbRemainingWords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRemainingWords.Name = "lbRemainingWords";
            this.lbRemainingWords.Size = new System.Drawing.Size(40, 20);
            this.lbRemainingWords.TabIndex = 4;
            this.lbRemainingWords.Text = "test";
            // 
            // lbCounter
            // 
            this.lbCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCounter.AutoSize = true;
            this.lbCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.lbCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbCounter.ForeColor = System.Drawing.Color.White;
            this.lbCounter.Location = new System.Drawing.Point(798, 674);
            this.lbCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Size = new System.Drawing.Size(40, 20);
            this.lbCounter.TabIndex = 3;
            this.lbCounter.Text = "test";
            // 
            // pTextSize
            // 
            this.pTextSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pTextSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pTextSize.Controls.Add(this.lbSize);
            this.pTextSize.Controls.Add(this.ntbTextSize);
            this.pTextSize.Location = new System.Drawing.Point(14, 772);
            this.pTextSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pTextSize.Name = "pTextSize";
            this.pTextSize.Padding = new System.Windows.Forms.Padding(2);
            this.pTextSize.Size = new System.Drawing.Size(178, 44);
            this.pTextSize.TabIndex = 3;
            // 
            // lbSize
            // 
            this.lbSize.BackColor = System.Drawing.Color.White;
            this.lbSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.lbSize.Location = new System.Drawing.Point(2, 2);
            this.lbSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(150, 40);
            this.lbSize.TabIndex = 28;
            this.lbSize.Text = "test";
            this.lbSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNewList
            // 
            this.btnNewList.BackColor = System.Drawing.Color.White;
            this.btnNewList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnNewList.FlatAppearance.BorderSize = 2;
            this.btnNewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnNewList.Location = new System.Drawing.Point(14, 237);
            this.btnNewList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNewList.Name = "btnNewList";
            this.btnNewList.Size = new System.Drawing.Size(178, 40);
            this.btnNewList.TabIndex = 16;
            this.btnNewList.Text = "Neue Liste";
            this.btnNewList.UseVisualStyleBackColor = false;
            this.btnNewList.Click += new System.EventHandler(this.btnNewList_Click);
            // 
            // lbMaxMin
            // 
            this.lbMaxMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMaxMin.AutoSize = true;
            this.lbMaxMin.BackColor = System.Drawing.Color.Transparent;
            this.lbMaxMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbMaxMin.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbMaxMin.ForeColor = System.Drawing.Color.White;
            this.lbMaxMin.Location = new System.Drawing.Point(1064, 1);
            this.lbMaxMin.Margin = new System.Windows.Forms.Padding(0);
            this.lbMaxMin.Name = "lbMaxMin";
            this.lbMaxMin.Size = new System.Drawing.Size(25, 23);
            this.lbMaxMin.TabIndex = 5;
            this.lbMaxMin.Text = "🗕︎";
            this.lbMaxMin.Click += new System.EventHandler(this.lbMaxMin_Click);
            // 
            // lbMaxNormal
            // 
            this.lbMaxNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMaxNormal.AutoSize = true;
            this.lbMaxNormal.BackColor = System.Drawing.Color.Transparent;
            this.lbMaxNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbMaxNormal.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbMaxNormal.ForeColor = System.Drawing.Color.White;
            this.lbMaxNormal.Location = new System.Drawing.Point(1087, 2);
            this.lbMaxNormal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaxNormal.Name = "lbMaxNormal";
            this.lbMaxNormal.Size = new System.Drawing.Size(25, 23);
            this.lbMaxNormal.TabIndex = 17;
            this.lbMaxNormal.Text = "🗖︎";
            this.lbMaxNormal.Click += new System.EventHandler(this.lbMaxNormal_Click);
            // 
            // pTopBorder
            // 
            this.pTopBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pTopBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTopBorder.Location = new System.Drawing.Point(0, 0);
            this.pTopBorder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pTopBorder.Name = "pTopBorder";
            this.pTopBorder.Size = new System.Drawing.Size(1144, 2);
            this.pTopBorder.TabIndex = 5;
            // 
            // pBottomBorder
            // 
            this.pBottomBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pBottomBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottomBorder.Location = new System.Drawing.Point(0, 828);
            this.pBottomBorder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pBottomBorder.Name = "pBottomBorder";
            this.pBottomBorder.Size = new System.Drawing.Size(1144, 2);
            this.pBottomBorder.TabIndex = 18;
            // 
            // pRightBorder
            // 
            this.pRightBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pRightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.pRightBorder.Location = new System.Drawing.Point(1142, 2);
            this.pRightBorder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pRightBorder.Name = "pRightBorder";
            this.pRightBorder.Size = new System.Drawing.Size(2, 826);
            this.pRightBorder.TabIndex = 22;
            // 
            // pLeftBorder
            // 
            this.pLeftBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pLeftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeftBorder.Location = new System.Drawing.Point(0, 2);
            this.pLeftBorder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pLeftBorder.Name = "pLeftBorder";
            this.pLeftBorder.Size = new System.Drawing.Size(2, 826);
            this.pLeftBorder.TabIndex = 23;
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(42, 606);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(110, 110);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 5;
            this.pbLogo.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.BackColor = System.Drawing.Color.White;
            this.btnLoadFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnLoadFile.FlatAppearance.BorderSize = 2;
            this.btnLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoadFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnLoadFile.Location = new System.Drawing.Point(14, 378);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(178, 40);
            this.btnLoadFile.TabIndex = 24;
            this.btnLoadFile.Text = "Lade Dokument";
            this.btnLoadFile.UseVisualStyleBackColor = false;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // pTitle
            // 
            this.pTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.pTitle.Controls.Add(this.lbSection);
            this.pTitle.Controls.Add(this.cbTopic);
            this.pTitle.Location = new System.Drawing.Point(14, 425);
            this.pTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pTitle.Name = "pTitle";
            this.pTitle.Padding = new System.Windows.Forms.Padding(2);
            this.pTitle.Size = new System.Drawing.Size(178, 42);
            this.pTitle.TabIndex = 3;
            // 
            // lbSection
            // 
            this.lbSection.BackColor = System.Drawing.Color.White;
            this.lbSection.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.lbSection.Location = new System.Drawing.Point(2, 2);
            this.lbSection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSection.Name = "lbSection";
            this.lbSection.Size = new System.Drawing.Size(154, 38);
            this.lbSection.TabIndex = 27;
            this.lbSection.Text = "test";
            this.lbSection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTopic
            // 
            this.cbTopic.BackColor = System.Drawing.Color.White;
            this.cbTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTopic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbTopic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.cbTopic.FormattingEnabled = true;
            this.cbTopic.Location = new System.Drawing.Point(2, 2);
            this.cbTopic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbTopic.MaxLength = 9;
            this.cbTopic.Name = "cbTopic";
            this.cbTopic.Size = new System.Drawing.Size(174, 38);
            this.cbTopic.TabIndex = 25;
            this.cbTopic.SelectedIndexChanged += new System.EventHandler(this.cbTopic_SelectedIndexChanged);
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.White;
            this.btnAbort.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnAbort.FlatAppearance.BorderSize = 2;
            this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAbort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnAbort.Location = new System.Drawing.Point(14, 284);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(178, 40);
            this.btnAbort.TabIndex = 25;
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnSave.Location = new System.Drawing.Point(14, 331);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(178, 40);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tt1
            // 
            this.tt1.ShowAlways = true;
            this.tt1.Tag = "lbSection";
            // 
            // lbClose
            // 
            this.lbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClose.AutoSize = true;
            this.lbClose.BackColor = System.Drawing.Color.Transparent;
            this.lbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbClose.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbClose.ForeColor = System.Drawing.Color.White;
            this.lbClose.Location = new System.Drawing.Point(1111, 2);
            this.lbClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(25, 23);
            this.lbClose.TabIndex = 27;
            this.lbClose.Text = "🗙︎";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // tPoolWords
            // 
            this.tPoolWords.Interval = 500;
            this.tPoolWords.Tick += new System.EventHandler(this.tPoolWords_Tick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnDelete.Location = new System.Drawing.Point(14, 504);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(178, 40);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Wort entfernen";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteList
            // 
            this.btnDeleteList.BackColor = System.Drawing.Color.White;
            this.btnDeleteList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnDeleteList.FlatAppearance.BorderSize = 2;
            this.btnDeleteList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(58)))), ((int)(((byte)(120)))));
            this.btnDeleteList.Location = new System.Drawing.Point(14, 550);
            this.btnDeleteList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteList.Name = "btnDeleteList";
            this.btnDeleteList.Size = new System.Drawing.Size(178, 40);
            this.btnDeleteList.TabIndex = 5;
            this.btnDeleteList.Text = "Liste entfernen";
            this.btnDeleteList.UseVisualStyleBackColor = false;
            this.btnDeleteList.Click += new System.EventHandler(this.btnDeleteList_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1144, 830);
            this.Controls.Add(this.btnDeleteList);
            this.Controls.Add(this.lbClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.pLeftBorder);
            this.Controls.Add(this.pRightBorder);
            this.Controls.Add(this.pBottomBorder);
            this.Controls.Add(this.pTopBorder);
            this.Controls.Add(this.lbMaxNormal);
            this.Controls.Add(this.lbMaxMin);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnNewList);
            this.Controls.Add(this.pTextSize);
            this.Controls.Add(this.pWordList);
            this.Controls.Add(this.pAddWord);
            this.Controls.Add(this.pGetWord);
            this.Controls.Add(this.lbTextSize);
            this.Controls.Add(this.btnStartOrQuit);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.btnGetStringPool);
            this.Controls.Add(this.btnRandom);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1144, 734);
            this.Name = "frmMain";
            this.Text = "Bingonator";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ntbTextSize)).EndInit();
            this.pAddWord.ResumeLayout(false);
            this.pAddWord.PerformLayout();
            this.pGetWord.ResumeLayout(false);
            this.pGetWord.PerformLayout();
            this.pWordList.ResumeLayout(false);
            this.pWordList.PerformLayout();
            this.pTextSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pTitle.ResumeLayout(false);
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
        private System.Windows.Forms.NumericUpDown ntbTextSize;
        private System.Windows.Forms.Panel pAddWord;
        private System.Windows.Forms.TextBox tbAddWord;
        private System.Windows.Forms.TextBox tbRandomString;
        private System.Windows.Forms.Panel pGetWord;
        private System.Windows.Forms.Panel pWordList;
        private System.Windows.Forms.Panel pTextSize;
        private System.Windows.Forms.Label lbCounter;
        private System.Windows.Forms.Label lbRemainingWords;
        private System.Windows.Forms.Button btnNewList;
        private System.Windows.Forms.Label lbMaxMin;
        private System.Windows.Forms.Label lbMaxNormal;
        private System.Windows.Forms.Panel pTopBorder;
        private System.Windows.Forms.Panel pBottomBorder;
        private System.Windows.Forms.Panel pRightBorder;
        private System.Windows.Forms.Panel pLeftBorder;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.ComboBox cbTopic;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbSection;
        private System.Windows.Forms.ToolTip tt1;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Timer tPoolWords;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteList;
    }
}

