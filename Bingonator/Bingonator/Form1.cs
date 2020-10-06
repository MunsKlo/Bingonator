using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BingoWortGeber
{

    public partial class frmMain : Form
    {
        string empty = string.Empty;

        Random random = new Random();

        bool playing = false;
        bool dragging = false;
        bool creatingList = false;

        Point dragCursorPoint;
        Point dragFrmPoint;

        int index = 1;

        string startPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        Color notEnable = Color.FromArgb(187, 194, 194);
        Color enable = Color.White;



        public frmMain()
        {
            InitializeComponent();
            ntbTextSize.Value = (int)rtbFullWordList.Font.Size;
            lbSize.Text = rtbFullWordList.Font.Size.ToString();
            cbTopic.BackColor = Color.White;

            UpdateLabels();
            FillButtonLists();
            UpdateButtons();

            MouseUp += (o, e) => { MouseDragDown(); };
            MouseDown += (o, e) => { MouseDragUp(); };
            MouseMove += (o, e) => { MouseMoving(); };

            pbLogo.MouseUp += (o, e) => { MouseDragDown(); };
            pbLogo.MouseDown += (o, e) => { MouseDragUp(); };
            pbLogo.MouseMove += (o, e) => { MouseMoving(); };

            foreach (var label in Controls.OfType<Label>())
            {
                label.MouseUp += (o, e) => { MouseDragDown(); };
                label.MouseDown += (o, e) => { MouseDragUp(); };
                label.MouseMove += (o, e) => { MouseMoving(); };
            }
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
                btnDelete
            };

            Variables.createButtons = new List<Button>
            {
                btnGetStringPool,
                btnStartOrQuit,
                btnSave,
                btnLoadFile,
                btnRandom
            };

            Variables.menuButtons = new List<Button>
            {
                btnRandom,
                btnAbort
            };

            Variables.noListButtons = new List<Button>
            {
                btnRandom,
                btnAddWord,
                btnGetStringPool,
                btnStartOrQuit,
                btnAbort,
                btnSave,
                btnDelete
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
                    var word = empty;
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
                    tbAddWord.Text = empty;
                    if (rtbFullWordList.Text != empty)
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
                    btnGetStringPool.Text = "Wörter-Pool zeigen";
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
                    rtbFullWordList.Text = empty;

                    tbAddWord.Text = empty;
                }
                UpdateButtons();
                UpdateLabels();
            }

        }

        private void ntbTextSize_ValueChanged(object sender, EventArgs e)
        {
            var numb = (int)ntbTextSize.Value;
            if (numb < 100 && numb > 0)
            {
                rtbFullWordList.Font = new Font(rtbFullWordList.Font.FontFamily.Name, numb, FontStyle.Bold);
            }
            lbSize.Text = ntbTextSize.Value.ToString();
        }

        void UpdateComboBox()
        {
            cbTopic.SelectedIndex = cbTopic.FindStringExact(Variables.titleSection);
        }

        void UpdateLabels()
        {
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
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                lbMaxNormal.Text = "🗖";
            }
            else
            {
                lbMaxNormal.Text = "🗗";
            }
        }

        void MouseDragUp()
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFrmPoint = Location;
        }

        void MouseDragDown()
        {
            dragging = false;
        }

        void MouseMoving()
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFrmPoint, new Size(dif));
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (!creatingList && !playing)
            {
                var filePath = empty;
                var fileContent = empty;
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
                rtbFullWordList.Text = empty;
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
                rtbFullWordList.Text = empty;
                var text = empty;
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
            
        }

        bool IsItTxt(string path)
        {
            var txt = empty;
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
            var word = empty;
            cbTopic.MaxLength = 9;
            foreach (var item in content)
            {
                if (word.Length == 0 && item == ' ')
                    continue;
                if (item == ':' || item == ',')
                {
                    newContent.WordList.Add(word);
                    word = empty;
                }
                else if (item == ';' && newContent.WordList.Count == 0)
                {
                    newContent.Title = word;
                    word = empty;
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
                    word = empty;
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
                    rtbFullWordList.Text = empty;
                    tbAddWord.Text = empty;
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
                lbSection.Text = ShortString(Variables.titleSection);
                tt1.SetToolTip(lbSection, Variables.titleSection);
                FillField(true);
                UpdateLabels();
                SetTimer();
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                rtbFullWordList.Text = empty;
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
            var txtContent = empty;
            foreach (var item in Variables.sections)
            {
                txtContent += ConcatWords(item);
            }
            if (txtContent.Length > 0)
                return txtContent.Substring(0, txtContent.Length - 1);
            return empty;
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
            var frm = new frmDelete();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            FillField(true);
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tPoolWords_Tick(object sender, EventArgs e)
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

        private void tbRandomString_TextChanged(object sender, EventArgs e)
        {
            tt1.SetToolTip(tbRandomString, tbRandomString.Text);
        }

        private void tbAddWord_TextChanged(object sender, EventArgs e)
        {
            var posCursor = tbAddWord.SelectionStart;
            tbAddWord.Text = tbAddWord.Text
                .Replace(";", empty)
                .Replace(",", empty)
                .Replace(":", empty);
            tbAddWord.SelectionStart = posCursor;
            
        }
    }
}
