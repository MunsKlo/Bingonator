using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BingoWortGeber
{

    public partial class frmMain : Form
    {
        Random random = new Random();
        bool playing = false;
        bool dragging = false;
        Point dragCursorPoint;
        Point dragFrmPoint;
        public frmMain()
        {
            InitializeComponent();
            ntbTextSize.Value = (int)rtbFullWordList.Font.Size;
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
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                if (Variables.words.Count != Variables.duplicates.Count)
                {
                    var word = "";
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

                rtbFullWordList.Text = "";
                var text = "";
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
            if (!playing)
            {
                if (!CheckDuplicate(tbAddWord.Text) && tbAddWord.Text.Length > 0)
                    Variables.words.Add(tbAddWord.Text);
                tbAddWord.Text = "";
                if (rtbFullWordList.Text != "")
                    btnGetStringPool.PerformClick();
                UpdateLabels();
            }
        }

        private void btnGetStringPool_Click(object sender, EventArgs e)
        {
            rtbFullWordList.Text = "";
            foreach (var item in Variables.words)
            {
                if(Variables.words[Variables.words.Count - 1] == item)
                {
                    rtbFullWordList.Text += item;
                }
                else
                {
                    rtbFullWordList.Text += item + ", ";
                }
            }
        }

        private void btnStartOrQuit_Click(object sender, EventArgs e)
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
                rtbFullWordList.Text = "";

                tbAddWord.Text = "";
            }
            UpdateButtons();
            
            UpdateLabels();
        }

        private void ntbTextSize_ValueChanged(object sender, EventArgs e)
        {
            var numb = (int)ntbTextSize.Value;
            if (numb < 100 && numb > 0)
            {
                rtbFullWordList.Font = new Font(rtbFullWordList.Font.FontFamily.Name, numb, FontStyle.Bold);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResetWords_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                for (int i = 60; i < Variables.words.Count; i++)
                {
                    Variables.words.RemoveAt(i);
                    i--;
                }
                btnGetStringPool.PerformClick();
                UpdateLabels();
            }
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
                btnAddWord.BackColor = Color.FromArgb(187, 194, 194);
                btnResetWords.BackColor = Color.FromArgb(187, 194, 194);
                btnRandom.BackColor = Color.White;
            }
            else
            {
                btnAddWord.BackColor = Color.White;
                btnResetWords.BackColor = Color.White;
                btnRandom.BackColor = Color.FromArgb(187, 194, 194);
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
    }
}
