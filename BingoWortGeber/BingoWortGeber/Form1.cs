using System;
using System.Collections.Generic;
using System.Drawing;
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

            tt1.SetToolTip(btnAddWord, "Fügt ein Wort hinzu.");
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (playing && !creatingList)
            {
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
                    if (!CheckDuplicate(tbAddWord.Text) && tbAddWord.Text.Length > 0 && !creatingList)
                        Variables.words.Add(tbAddWord.Text);
                    else
                        Variables.words.Add(tbAddWord.Text);
                    tbAddWord.Text = empty;
                    if (rtbFullWordList.Text != empty)
                        btnGetStringPool.PerformClick();
                    UpdateLabels();
                    FillField();
                }
            }
            else
                rtbFullWordList.Text = "Keine Liste vorhanden";
            
        }

        private void btnGetStringPool_Click(object sender, EventArgs e)
        {
            if(!creatingList)
                FillField();
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
                    tbRandomString.Text = "Spiel wurde beendet";
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
            if (playing)
            {
                btnAddWord.BackColor = notEnable;
                btnNewList.BackColor = notEnable;
                btnRandom.BackColor = enable;
            }
            else
            {
                btnAddWord.BackColor = enable;
                btnNewList.BackColor = enable;
                btnRandom.BackColor = notEnable;
            }

            if (creatingList)
            {
                btnRandom.BackColor = notEnable;
                btnGetStringPool.BackColor = notEnable;
                btnStartOrQuit.BackColor = notEnable;
                btnSave.BackColor = notEnable;
                btnLoadFile.BackColor = notEnable;
                cbTopic.Enabled = false;
                cbTopic.BackColor = notEnable;
                btnAbort.Enabled = true;
                btnAbort.BackColor = enable;
            }
            else
            {
                btnRandom.BackColor = enable;
                btnGetStringPool.BackColor = enable;
                btnStartOrQuit.BackColor = enable;
                btnSave.BackColor = enable;
                btnLoadFile.BackColor = enable;
                cbTopic.Enabled = true;
                cbTopic.BackColor = enable;
                btnAbort.BackColor = notEnable;
            }
        }

        private void lbMaxMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lbMaxNormal_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
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
            if(!creatingList && !playing)
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
                FillField();
                UpdateLabels();
                if (Variables.sections.Count != 0)
                    UpdateComboBox();
                tt1.SetToolTip(lbSection, Variables.titleSection);
            }
        }

        void FillField()
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
            content = content.Replace(" ", empty);
            var newContent = new Content();
            newContent.WordList = new List<string>();
            var word = empty;
            cbTopic.MaxLength = 9;
            foreach (var item in content)
            {
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
            if(newString.Length > 11)
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
                    Variables.words = new List<string>();
                    creatingList = true;
                    btnNewList.Text = "Liste hinzufügen";
                    rtbFullWordList.Text = empty;
                    tbAddWord.Text = empty;
                    tbAddWord.Focus();
                }
                else
                {
                    btnNewList.Text = "Neue Liste";
                    creatingList = false;
                    var titleFrm = new frmTitle();
                    titleFrm.ShowDialog();
                    var content = new Content();
                    if(titleFrm.Title != null)
                    {
                        content = CreateContent(titleFrm.Title);
                        Variables.sections.Add(content);
                        Variables.titleSection = content.Title;
                        cbTopic.Items.Add(content.Title);
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
                FillField();
                UpdateLabels();
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            rtbFullWordList.Text = empty;
            creatingList = false;
            btnNewList.Text = "Neue Liste";
            UpdateButtons();
        }

        void SaveLists()
        {
            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = startPath;
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
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
            return txtContent.Substring(0, txtContent.Length - 1);
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
            SaveLists();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var frm = new frmDelete();
            frm.ShowDialog();
            FillField();
            var width = SystemInformation.VirtualScreen.Width;
            var height = SystemInformation.VirtualScreen.Height;
        }
    }
}
