using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace BingoWortGeber
{

    public partial class frmMain : Form
    {
        Random random = new Random();

        const int minSize = 20;
        const int maxSize = 100;

        int standardWidth;
        int standardHeight; 

        bool playing = false;
        bool dragging = false;
        bool creatingList = false;
        bool resize = false;

        int borderBottom;
        int borderRight;

        Point dragCursorPoint;
        Point dragFrmPoint;

        const int originalLocationLabelX = 24;
        const int originalLocationLabelY = 594;

        int index = 1;

        string startPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        Color notEnable = Color.FromArgb(187, 194, 194);
        Color enable = Color.White;



        public frmMain()
        {
            InitializeComponent();

            standardWidth = Width;
            standardHeight = Height;

            ntbTextSize.Value = (int)rtbFullWordList.Font.Size;
            lbSize.Text = rtbFullWordList.Font.Size.ToString();
            cbTopic.BackColor = Color.White;

            UpdateLabels();
            FillButtonLists();
            UpdateButtons();

            MouseUp += (o, e) => { MouseDragDown(); };
            MouseDown += (o, e) => { MouseDragUp(); };
            MouseMove += (o, e) => { MouseMoving(); };

            foreach (var label in Controls.OfType<Label>())
            {
                label.MouseUp += (o, e) => { MouseDragDown(); };
                label.MouseDown += (o, e) => { MouseDragUp(); };
                label.MouseMove += (o, e) => { MouseMoving(); };
            }

            foreach (var panel in Controls.OfType<Panel>())
            {
                panel.MouseUp += (o, e) => { resize = false; };
                panel.MouseDown += (o, e) =>
                {
                    resize = true; 
                    dragCursorPoint = Cursor.Position; 
                    borderRight = Location.X + Width;
                    borderBottom = Location.Y + Height;
                };
            }

            pRightBorder.MouseMove += (o, e) => { MouseMoving("r"); };
            pLeftBorder.MouseMove += (o, e) => { MouseMoving("l"); };
            pTopBorder.MouseMove += (o, e) => { MouseMoving("u"); };
            pBottomBorder.MouseMove += (o, e) => { MouseMoving("d"); };

            lbSection.Text = "";
            tbAddWord.PlaceholderText = "Wort eingeben...";
            SetToolTip();
            SaveFont();
        }

        private void FillButtonLists()
        {
            Variables.playButtons = new List<Button>
            {
                btnAddWord,
                btnAbort,
                btnSave,
                btnLoadFile,
                btnNewList,
                btnDelete,
                btnDeleteList
            };

            Variables.createButtons = new List<Button>
            {
                btnGetStringPool,
                btnStartOrQuit,
                btnSave,
                btnLoadFile,
                btnRandom,
                btnDeleteList
            };

            Variables.menuButtons = new List<Button>
            {
                btnRandom,
                btnAbort,
                btnGetStringPool
            };

            Variables.noListButtons = new List<Button>
            {
                btnRandom,
                btnAddWord,
                btnGetStringPool,
                btnStartOrQuit,
                btnAbort,
                btnSave,
                btnDelete,
                btnDeleteList
            };
        }

        void SetTimer()
        {
            if (!playing && !creatingList)
                tPoolWords.Start();
            else
            {
                tPoolWords.Stop();
                tbRandomString.Text = "";
            }
                
        }

        void SetToolTip()
        {
            tt1.SetToolTip(btnAddWord, "Fügt ein Wort hinzu.");
            tt1.SetToolTip(btnRandom, "Gibt ein zufälliges Wort aus dem Wörter-Pool aus.");
            tt1.SetToolTip(btnGetStringPool, "Gibt alle Wörter des Pools aus.");
            //tt1.SetToolTip(btnStartOrQuit, "Startet das Spiel oder beendet das laufende Spiel");
            //tt1.SetToolTip(btnCreateList, "Fügt ein Wort hinzu.");
            tt1.SetToolTip(btnAbort, "Bricht die Listenerstellung ab.");
            tt1.SetToolTip(btnSave, "Speichert die Listen in einem Textdokument.");
            tt1.SetToolTip(btnLoadFile, "Lädt die Listen aus einem Textdokument.");
            tt1.SetToolTip(lbSize, "Bestimmt die Schriftgröße des Pools.");
            tt1.SetToolTip(btnDelete, "Entfernt eine Wort aus dem Wort-Pool.");
        }

        private void SaveFont()
        {
            var pfc = new PrivateFontCollection();
            pfc.AddFontFile(Path.Combine(Application.StartupPath, "arial.ttf"));
            lbClose.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            lbMaxMin.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            lbMaxNormal.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (playing && !creatingList)
            {
                SetTimer();
                if (Variables.words.Count != Variables.duplicates.Count)
                {
                    var word = string.Empty;
                    while (true)
                    {
                        word = Variables.words[random.Next(0, Variables.words.Count)];
                        if (Variables.duplicates.Contains(word))
                            continue;
                        break;
                    }
                    tbRandomString.Text = word;
                    Variables.duplicates.Add(word);
                    
                }
                else
                {
                    tbRandomString.Text = "Keine Wörter mehr vorhanden";
                    btnStartOrQuit.PerformClick();
                }

                UpdateLabels();
                FillField(false);
                btnGetStringPool.Text = "Alle Wörter ausgeben";
                if (rtbFullWordList.Text == "")
                {
                    btnRandom.Text = "Spiel beenden";
                }
                else
                {
                    btnRandom.Text = "Nächstes Wort";
                }
            }
        }

        private bool CheckDuplicate(string newWord)
        {
            return Variables.words.Contains(newWord);
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            if (lbSection.Text.Length > 0 || creatingList)
            {
                if (!playing)
                {
                    if (!CheckDuplicate(tbAddWord.Text) && tbAddWord.Text.Length > 0)
                        Variables.words.Add(tbAddWord.Text);
                    tbAddWord.Text = string.Empty;
                    if (rtbFullWordList.Text != string.Empty)
                        btnGetStringPool.PerformClick();
                    UpdateLabels();
                    FillField(true);
                    tbAddWord.Focus();
                }
            }
        }

        private void btnGetStringPool_Click(object sender, EventArgs e)
        {
            if (!creatingList && !playing)
                FillField(true);

            if (playing)
            {
                if (btnGetStringPool.Text == "Alle Wörter ausgeben")
                {
                    FillField(true);
                    btnGetStringPool.Text = Variables.duplicates.Count > 0 ? "Wörter-Pool zeigen" : "Alle Wörter ausgeben";
                }
                else
                {
                    FillField(false);
                    btnGetStringPool.Text = "Alle Wörter ausgeben";
                }
            }
        }

        private void btnStartOrQuit_Click(object sender, EventArgs e)
        {
            if (!creatingList)
            {
                if (!playing)
                {
                    playing = true;
                    btnStartOrQuit.Text = "Spiel beenden";
                }
                else
                {
                    playing = false;
                    Variables.duplicates = new List<string>();
                    tbRandomString.Text = "";
                    tbRandomString.PlaceholderText = "Spiel wurde beendet";
                    btnStartOrQuit.Text = "Spiel starten";
                    rtbFullWordList.Text = string.Empty;

                    tbAddWord.Text = string.Empty;
                }
                UpdateButtons();
                UpdateLabels();
            }

        }

        private void ntbTextSize_ValueChanged(object sender, EventArgs e)
        {
            var numb = (int)ntbTextSize.Value;
            if (numb < maxSize && numb > minSize)
            {
                rtbFullWordList.Font = new Font(rtbFullWordList.Font.FontFamily.Name, numb, FontStyle.Bold);
            }
            UpdateLabels();
        }

        void UpdateComboBox()
        {
            if (Variables.sections.Count > 0)
                cbTopic.SelectedIndex = cbTopic.FindStringExact(Variables.titleSection);
            else
            {
                cbTopic.SelectedIndex = -1;
                cbTopic.Refresh();
            }
                
        }

        void UpdateLabels()
        {
            lbSize.Text = ntbTextSize.Value.ToString();
            lbSection.Text = ShortString(Variables.titleSection);
            lbCounter.Text = $"Wörter: {Variables.words.Count}";
            lbRemainingWords.Text = $"Verbleibene Wörter: {Variables.words.Count - Variables.duplicates.Count}";
        }

        void UpdateButtons()
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.BackColor = enable;
            }
            cbTopic.Enabled = true;
            tbAddWord.ReadOnly = false;
            lbSection.BackColor = enable;
            //Programm ohne Listen
            if (cbTopic.SelectedIndex == -1 && !creatingList)
            {
                DisableButtons(Variables.noListButtons);
                cbTopic.Enabled = false;
                lbSection.BackColor = notEnable;
            }
            //Programm beim erstellen von Listen
            else if (creatingList)
            {
                DisableButtons(Variables.createButtons);
                cbTopic.Enabled = false;
                lbSection.BackColor = notEnable;
            }
            //Programm beim Spielen
            else if (playing)
            {
                DisableButtons(Variables.playButtons);
                cbTopic.Enabled = false;
                tbAddWord.ReadOnly = true;
                lbSection.BackColor = notEnable;
            }
            //Programm normal im Menü
            else if (!creatingList)
            {
                DisableButtons(Variables.menuButtons);
            }
        }

        void DisableButtons(List<Button> list)
        {
            foreach (var button in list)
            {
                button.BackColor = notEnable;
            }
        }

        private void lbMaxMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lbMaxNormal_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
            if(WindowState == FormWindowState.Normal)
            {
                Width = standardWidth;
                Height = standardHeight;
                CenterToScreen();
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                lbMaxNormal.Text = "🗖";

                lbLogo.Location = new Point(originalLocationLabelX, originalLocationLabelY);
            }
            else
            {
                lbMaxNormal.Text = "🗗";

                var posButton = btnDeleteList.Location;
                var posLabel = lbSize.Location;

                var posLogo = posButton.Y - posLabel.Y;

                lbLogo.Location = new Point(lbLogo.Location.X, posLogo + lbLogo.Height);
            }

            if (lbTitle.Location.X - (tbAddWord.Location.X + tbAddWord.Width) < 80 + lbLogo.Width)
            {
                lbTitle.Visible = false;
            }
            else
            {
                lbTitle.Visible = true;
            }
        }

        void MouseDragUp()
        {
            dragCursorPoint = Cursor.Position;
            dragFrmPoint = Location;

            
            
            dragging = true;
        }

        void MouseDragDown()
        {
            dragging = false;

            var posMouse = Cursor.Position;

            if (posMouse.X == 0)
            {
                Location = new Point(0, 0);
                Width = Screen.PrimaryScreen.Bounds.Width / 2;
                Height = Screen.PrimaryScreen.Bounds.Height - 40;
            }

            if(posMouse.X == Screen.AllScreens[0].Bounds.Width - 1)
            {
                Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2, 0);
                Width = Screen.PrimaryScreen.Bounds.Width / 2;
                Height = Screen.PrimaryScreen.Bounds.Height - 40;
            }

            if(posMouse.Y == 0)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        void MouseMoving(string direction = "")
        {
            lbCounter.Text = Cursor.Position.X.ToString();
            lbRemainingWords.Text = Cursor.Position.Y.ToString();
            if (WindowState == FormWindowState.Maximized && dragging)
            {
                dragging = false;

                var partX = (double)Cursor.Position.X / Width;
                var partY = (double)Cursor.Position.Y / Height;

                var oldY = Location.Y;
                var oldX = Location.X;

                WindowState = FormWindowState.Normal;
                Width = standardWidth;
                Height = standardHeight;
                CenterToScreen();

                Cursor.Position = new Point((int)(Width * partX) + (Location.X + oldX), (int)(Height * partY) + (Location.Y + oldY));
                MouseDragUp();
            }
            else if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFrmPoint, new Size(dif));
            }


            //Vergändern der größe vom Fenster
            if (resize)
            {
                //Rechts
                if (direction == "r")
                {
                    var dif = Cursor.Position.X - dragCursorPoint.X;
                    Width += dif;
                    Cursor.Position = new Point(Location.X + Width, Cursor.Position.Y);
                }
                //Links
                if (direction == "l")
                {
                    var dif = Cursor.Position.X - dragCursorPoint.X;
                    var left = dif > 0 ? false : true;

                    if(Width == MinimumSize.Width && left)
                    {
                        Location = new Point(Location.X, Location.Y);
                        Width -= dif;
                    }
                    else if (Width > MinimumSize.Width)
                    {
                        Location = new Point(Location.X + dif, Location.Y);
                        Width -= dif;
                    }
                    if(Location.X + Width != borderRight)
                    {
                        Location = new Point(borderRight - Width, Location.Y);
                    }
                    Cursor.Position = new Point(Location.X, Cursor.Position.Y);
                }
                //Oben
                if(direction == "u")
                {
                    var dif = Cursor.Position.Y - dragCursorPoint.Y;
                    var top = dif > 0 ? false : true;
                    if (Height > MinimumSize.Height || top)
                    {
                        Location = new Point(Location.X, Location.Y + dif);
                        Height -= dif;
                    }
                    else if (Width > MinimumSize.Width)
                    {
                        Location = new Point(Location.X, Location.Y + dif);
                        Height -= dif;
                    }
                    if (Location.Y + Width != borderBottom)
                    {
                        Location = new Point(Location.X, borderBottom -  Height);
                    }
                    Cursor.Position = new Point(Cursor.Position.X, Location.Y);
                }
                //Unten
                if(direction == "d")
                {
                    var dif = Cursor.Position.Y - dragCursorPoint.Y;
                    Height += dif;
                    Cursor.Position = new Point(Cursor.Position.X, Location.Y + Height);
                }
                dragCursorPoint = Cursor.Position;
            }
            
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (!creatingList && !playing)
            {
                var filePath = string.Empty;
                var fileContent = string.Empty;
                var content = new Content();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = startPath;
                    openFileDialog.Filter = "txt files (*.txt)|*.txt";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        var fileStream = openFileDialog.OpenFile();
                        if (IsItTxt(filePath))
                            fileContent = FileReaderAndWriter.ReadTxt(fileStream);
                        fileStream.Close();
                        FillFrmFromLoadFile(fileContent);
                        Variables.words = Variables.sections[0].WordList;
                        Variables.titleSection = Variables.sections[0].Title;
                    }
                }
                FillField(true);
                UpdateLabels();
                if (Variables.sections.Count != 0)
                    UpdateComboBox();
                tt1.SetToolTip(lbSection, Variables.titleSection);
            }
            UpdateButtons();
        }

        void FillField(bool all)
        {
            if (all)
            {
                rtbFullWordList.Text = string.Empty;
                foreach (var item in Variables.words)
                {
                    if (Variables.words[Variables.words.Count - 1] == item)
                    {
                        rtbFullWordList.Text += item;
                    }
                    else
                    {
                        rtbFullWordList.Text += item + ", ";
                    }
                }
            }
            else
            {
                rtbFullWordList.Text = string.Empty;
                var text = string.Empty;
                foreach (var item in Variables.words)
                {
                    if (!Variables.duplicates.Contains(item))
                        text += item + ", ";
                }
                if (Variables.duplicates.Count != Variables.words.Count)
                {
                    text = text.Substring(0, text.Length - 2);
                    rtbFullWordList.Text = text;
                }
            }
            if (Variables.words.Count < 1)
                rtbFullWordList.Text = string.Empty;
            
        }

        bool IsItTxt(string path)
        {
            var txt = string.Empty;
            for (int i = path.Length - 4; i < path.Length; i++)
            {
                txt += path[i];
            }
            if (txt == ".txt")
                return true;
            else
                return false;

        }

        void FillFrmFromLoadFile(string content)
        {
            var newContent = new Content();
            newContent.WordList = new List<string>();
            var word = string.Empty;
            cbTopic.MaxLength = 9;
            foreach (var item in content)
            {
                if (word.Length == 0 && item == ' ')
                    continue;
                if (item == ':' || item == ',')
                {
                    newContent.WordList.Add(word);
                    word = string.Empty;
                }
                else if (item == ';' && newContent.WordList.Count == 0)
                {
                    newContent.Title = word;
                    word = string.Empty;
                }
                else if (item == ';' && newContent.WordList.Count != 0)
                {
                    if (newContent.Title == null)
                    {
                        newContent.Title = "None" + index.ToString();
                        index++;
                    }
                    CheckDoubleContents(newContent);
                    newContent = new Content();
                    newContent.WordList = new List<string>();
                    newContent.Title = word;
                    word = string.Empty;
                }
                else
                    word += item;
            }
            newContent.WordList.Add(word);
            CheckDoubleContents(newContent);
            lbSection.Text = ShortString(Variables.sections[0].Title);
            if (word.Length == 0)
                newContent.WordList.Add(word);
        }

        void CheckDoubleContents(Content newContent)
        {
            if (!cbTopic.Items.Contains(newContent.Title))
            {
                cbTopic.Items.Add(newContent.Title);
                Variables.sections.Add(newContent);
            }
        }

        string ShortString(string newString)
        {
            if (newString.Length > 11)
                newString = newString.Substring(0, 11) + "...";
            return newString;
        }

        Content GetRightContent(string title)
        {
            Content newContent = new Content();
            foreach (var item in Variables.sections)
            {
                if (item.Title == title)
                {
                    newContent = item;
                    break;
                }
            }
            return newContent;
        }

        private void btnNewList_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                if (btnNewList.Text == "Neue Liste")
                {
                    creatingList = true;
                    SetTimer();
                    UpdateButtons();
                    Variables.words = new List<string>();
                    btnNewList.Text = "Liste hinzufügen";
                    rtbFullWordList.Text = string.Empty;
                    tbAddWord.Text = string.Empty;
                    tbAddWord.Focus();
                }
                else
                {
                    var titleFrm = new frmTitle();
                    titleFrm.StartPosition = FormStartPosition.CenterParent;
                    titleFrm.ShowDialog();
                    if (titleFrm.Title != null)
                    {
                        btnNewList.Text = "Neue Liste";
                        creatingList = false;
                        var content = new Content();
                        content = CreateContent(titleFrm.Title);
                        Variables.sections.Add(content);
                        Variables.titleSection = content.Title;
                        cbTopic.Items.Add(content.Title);
                        cbTopic.SelectedIndex = cbTopic.Items.Count - 1;
                        lbSection.Text = Variables.titleSection;
                    }
                }
            }
            UpdateButtons();
        }

        Content CreateContent(string title)
        {
            return new Content(title, Variables.words);
        }

        private void cbTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTopic.SelectedIndex != -1)
            {
                var content = GetRightContent(cbTopic.Text);
                Variables.words = content.WordList;
                Variables.titleSection = content.Title;
                tt1.SetToolTip(lbSection, Variables.titleSection);
                FillField(true);
                SetTimer();
            }
            else
            {
                Variables.titleSection = string.Empty;
            }
            UpdateLabels();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                rtbFullWordList.Text = string.Empty;
                creatingList = false;
                btnNewList.Text = "Neue Liste";
                UpdateButtons();
            }
        }

        void SaveLists()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = startPath;
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, TxTContent());
                }
            }
        }

        string TxTContent()
        {
            var txtContent = string.Empty;
            foreach (var item in Variables.sections)
            {
                txtContent += ConcatWords(item);
            }
            if (txtContent.Length > 0)
                return txtContent.Substring(0, txtContent.Length - 1);
            return string.Empty;
        }

        string ConcatWords(Content content)
        {
            var txt = $"{content.Title};";
            foreach (var item in content.WordList)
            {
                txt += $"{item},";
            }
            return txt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!creatingList && !playing)
                SaveLists();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(btnDelete.BackColor == enable)
            {
                var frm = new frmDelete();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                FillField(true);
            }
            
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tPoolWords_Tick(object sender, EventArgs e)
        {
            if(Variables.words.Count > 0)
            {
                while (true)
                {
                    var word = Variables.words[random.Next(0, Variables.words.Count)];
                    if (word != tbRandomString.PlaceholderText)
                    {
                        tbRandomString.PlaceholderText = word;
                        break;
                    }
                    if (Variables.words.Count < 2)
                        break;
                }
            }
        }

        private void tbRandomString_TextChanged(object sender, EventArgs e)
        {
            tt1.SetToolTip(tbRandomString, tbRandomString.Text);
        }

        private void tbAddWord_TextChanged(object sender, EventArgs e)
        {
            var posCursor = tbAddWord.SelectionStart;
            tbAddWord.Text = tbAddWord.Text
                .Replace(";", string.Empty)
                .Replace(",", string.Empty)
                .Replace(":", string.Empty);
            tbAddWord.SelectionStart = posCursor;
            
        }

        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            if(btnDeleteList.BackColor == enable)
            {
                var frm = new frmDelete(false);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                cbTopic.Items.Remove(frm.Title);
                UpdateComboBox();
                if (Variables.sections.Count > 0)
                {
                    cbTopic.SelectedIndex = 0;
                }
                else
                {
                    Variables.words = new List<string>();
                    Variables.titleSection = string.Empty;
                    lbSection.Text = string.Empty;
                    UpdateButtons();
                }
                FillField(true);
                UpdateLabels();
            }
        }

        private void lbSection_Click(object sender, EventArgs e)
        {
            if(cbTopic.SelectedIndex != -1)
                cbTopic.DroppedDown = true;
        }
    }
}
