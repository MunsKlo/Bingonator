using Bingonator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
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
        bool snap = false;

        string direction;
        Desktop currentDesktop;

        int borderBottom;
        int borderRight;

        Point dragCursorPoint;
        Point dragFrmPoint;

        const int originalLocationLabelX = 24;
        const int originalLocationLabelY = 594;

        int index = 1;
        readonly string startPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        

        public frmMain()
        {
            InitializeComponent();

            SetStartSettings();

            UpdateLabels();
            FillElementLists();
            UpdateButtons();

            SetDragMouseEvent();

            SetCorners();
            CornerEvents();
            SetResizeMouseEvents();

            SetToolTip();
            SaveFont();
        }

        void SetStartSettings()
        {
            standardWidth = Width;
            standardHeight = Height;

            ntbTextSize.Value = (int)rtbFullWordList.Font.Size;
            lbSize.Text = rtbFullWordList.Font.Size.ToString();
            cbTopic.BackColor = Color.White;

            lbSection.Text = string.Empty;
            tbAddWord.PlaceholderText = StringConst.ADDWORDEXTBOXTEXT;

            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                Variables.desktops.Add(new Desktop
                {
                    Left = Screen.AllScreens[i].WorkingArea.Left,
                    Right = Screen.AllScreens[i].WorkingArea.Right,
                    Height = Screen.AllScreens[i].WorkingArea.Height,
                    Top = Screen.AllScreens[i].WorkingArea.Top
                });
            }
        }

        void SetDragMouseEvent()
        {
            MouseUp += (o, e) => { MouseDragDown(); };
            MouseDown += (o, e) => { MouseDragUp(); };
            MouseMove += (o, e) => { MouseMoving(); };

            foreach (var label in Variables.dragLabels)
            {
                label.MouseUp += (o, e) => { MouseDragDown(); };
                label.MouseDown += (o, e) => { MouseDragUp(); };
                label.MouseMove += (o, e) => { MouseMoving(); };
            }

            pWordList.MouseUp += (o, e) => { MouseDragDown(); };
            pWordList.MouseDown += (o, e) => { MouseDragUp(); };
            pWordList.MouseMove += (o, e) => { MouseMoving(); };
        }

        void SetResizeMouseEvents()
        {
            pRightBorder.MouseMove += (o, e) => { direction = "r"; MouseMoving(); };
            pLeftBorder.MouseMove += (o, e) => { direction = "l"; MouseMoving(); };
            pTopBorder.MouseMove += (o, e) => { direction = "u"; MouseMoving(); };
            pBottomBorder.MouseMove += (o, e) => { direction = "d"; MouseMoving(); };

            

            foreach (var panel in Variables.borderPanels)
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
        }

        void SetCorners()
        {
            lbCornerTL.BackColor = Variables.blue;
            lbCornerTR.BackColor = Variables.blue;
            lbCornerBL.BackColor = Variables.blue;
            lbCornerBR.BackColor = Variables.blue;

            lbCornerTL.Location = new Point(Location.X, Location.Y);
            lbCornerTR.Location = new Point(Location.X + Width - lbCornerTR.Width, Location.Y);
            lbCornerBL.Location = new Point(Location.X, Location.Y + Height - lbCornerBL.Height);
            lbCornerBR.Location = new Point(Location.X + Width - lbCornerTR.Width, Location.Y + Height - lbCornerBL.Height);
        }

        void CornerEvents()
        {
            foreach (var label in Variables.cornerLabels)
            {
                label.MouseUp -= (o, e) => { MouseDragDown(); };
                label.MouseDown -= (o, e) => { MouseDragUp(); };
                label.MouseMove -= (o, e) => { MouseMoving(); };

                label.MouseUp += (o, e) => { resize = false; };
                label.MouseDown += (o, e) =>
                {
                    resize = true;
                    dragCursorPoint = Cursor.Position;
                    borderRight = Location.X + Width;
                    borderBottom = Location.Y + Height;
                };
                label.MouseMove += (o, e) => { direction = label.Name; MouseMoving(); };
            }
        }

        private void FillElementLists()
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

            Variables.cornerLabels = new List<Label>
            {
                lbCornerTL,
                lbCornerTR,
                lbCornerBR,
                lbCornerBL
            };

            Variables.borderPanels = new List<Panel>
            {
                pTopBorder,
                pRightBorder,
                pBottomBorder,
                pLeftBorder
            };

            Variables.dragLabels = new List<Label>
            {
                lbLogo,
                lbTitle,
                lbCounter,
                lbRemainingWords,
                lbTextSize
            };
        }

        void SetTimer()
        {
            if (!playing && !creatingList)
                tPoolWords.Start();
            else
            {
                tPoolWords.Stop();
                tbRandomString.Text = string.Empty;
            }
                
        }

        void SetToolTip()
        {
            tt1.SetToolTip(btnAddWord, StringConst.ADDWORDTOOLTIPTEXT);
            tt1.SetToolTip(btnRandom, StringConst.RANDOMTOOLTIPTEXT);
            tt1.SetToolTip(btnGetStringPool, StringConst.GETSTRINGPOOLTTOOLTIPTEXT);
            tt1.SetToolTip(btnStartOrQuit, StringConst.GAMESTARTTOOLTIPTEXT);
            tt1.SetToolTip(btnNewList, StringConst.NEWLISTTOOLTIPTEXT);
            tt1.SetToolTip(btnAbort, StringConst.ABORTTOOLTIPTEXT);
            tt1.SetToolTip(btnSave, StringConst.SAVETOOLTIPTEXT);
            tt1.SetToolTip(btnLoadFile, StringConst.LOADTOOLTIPTEXT);
            tt1.SetToolTip(lbSize, StringConst.SIZETOOLTIPTEXT);
            tt1.SetToolTip(btnDelete, StringConst.DELETEWORDTOOLTIPTEXT);
            tt1.SetToolTip(btnDeleteList, StringConst.DELETELISTTOOLTIPTEXT);
            tt1.SetToolTip(ntbTextSize, StringConst.SIZETOOLTIPTEXT);
            tt1.SetToolTip(lbMaxMin, StringConst.MINTOOLTIPTEXT);
            tt1.SetToolTip(lbMaxNormal, StringConst.MAXTOOLTIPTEXT);
            tt1.SetToolTip(lbClose, StringConst.CLOSETOOLTIPTEXT);
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
                    btnStartOrQuit.PerformClick();
                }

                UpdateLabels();
                FillField(false);
                btnGetStringPool.Text = StringConst.GETSTRINGPOOLBUTTONTTEXT;
                if (rtbFullWordList.Text == string.Empty)
                {
                    btnRandom.Text = StringConst.GAMESQUITBUTTONTEXT;
                }
                else
                {
                    btnRandom.Text = StringConst.RANDOMBUTTONTEXT;
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
                    if (Variables.words.Count > 0)
                    {
                        btnDelete.BackColor = Variables.enabledColor;
                    }
                    if (!CheckDuplicate(tbAddWord.Text) && tbAddWord.Text.Length > 0)
                    {
                        Variables.words.Add(tbAddWord.Text);
                    }
                    tbAddWord.Text = string.Empty;
                    if (rtbFullWordList.Text != string.Empty)
                    {
                        btnGetStringPool.PerformClick();
                    }
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
                if (btnGetStringPool.Text == StringConst.GETSTRINGPOOLBUTTONTTEXT)
                {
                    FillField(true);
                    btnGetStringPool.Text = Variables.duplicates.Count > 0 ? StringConst.GETRESTSTRINGPOOLBUTTONTTEXT : StringConst.GETSTRINGPOOLBUTTONTTEXT;
                }
                else
                {
                    FillField(false);
                    btnGetStringPool.Text = StringConst.GETSTRINGPOOLBUTTONTTEXT;
                }
            }
        }

        private void btnStartOrQuit_Click(object sender, EventArgs e)
        {
            if (!creatingList && Variables.sections.Count > 0)
            {
                if (!playing)
                {
                    playing = true;
                    btnStartOrQuit.Text = StringConst.GAMESQUITBUTTONTEXT;
                    tt1.SetToolTip(btnStartOrQuit, StringConst.GAMESQUITTOOLTIPTEXT);
                }
                else
                {
                    playing = false;
                    Variables.duplicates = new List<string>();
                    tbRandomString.Text = string.Empty;
                    tbRandomString.PlaceholderText = StringConst.QUITGAMETEXTBOXTEXT;
                    tt1.SetToolTip(btnStartOrQuit, StringConst.GAMESTARTTOOLTIPTEXT);
                    btnStartOrQuit.Text = StringConst.GAMESTARTBUTTONTEXT;
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
            if (numb <= maxSize && numb >= minSize)
            {
                rtbFullWordList.Font = new Font(rtbFullWordList.Font.FontFamily.Name, numb, FontStyle.Bold);
            }
            else
            {
                ntbTextSize.Value = int.Parse(rtbFullWordList.Font.Size.ToString());
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
            lbCounter.Text = $"{StringConst.COUNTERLABELTEXT} {Variables.words.Count}";
            lbRemainingWords.Text = $"{StringConst.REMAININGLABElTEXT} {Variables.words.Count - Variables.duplicates.Count}";
        }

        void UpdateButtons()
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.BackColor = Variables.enabledColor;
            }
            cbTopic.Enabled = true;
            tbAddWord.ReadOnly = false;
            lbSection.BackColor = Variables.enabledColor;
            //Programm ohne Listen
            if (cbTopic.SelectedIndex == -1 && !creatingList)
            {
                DisableButtons(Variables.noListButtons);
                cbTopic.Enabled = false;
                lbSection.BackColor = Variables.disabledColor;
            }
            //Programm beim erstellen von Listen
            else if (creatingList)
            {
                DisableButtons(Variables.createButtons);
                cbTopic.Enabled = false;
                lbSection.BackColor = Variables.disabledColor;
                if(Variables.words.Count == 0)
                {
                    btnDelete.BackColor = Variables.disabledColor;
                }
            }
            //Programm beim Spielen
            else if (playing)
            {
                DisableButtons(Variables.playButtons);
                cbTopic.Enabled = false;
                tbAddWord.ReadOnly = true;
                lbSection.BackColor = Variables.disabledColor;
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
                button.BackColor = Variables.disabledColor;
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
                lbMaxNormal.Text = StringConst.MAXLABELTEXT;

                tt1.SetToolTip(lbMaxNormal, StringConst.MAXTOOLTIPTEXT);

                lbLogo.Location = new Point(originalLocationLabelX, originalLocationLabelY);

                for (int i = 0; i < Variables.borderPanels.Count; i++)
                {
                    if (i % 2 == 0)
                        Variables.borderPanels[i].Cursor = Cursors.SizeNS;
                    else
                        Variables.borderPanels[i].Cursor = Cursors.SizeWE;
                }

                for (int i = 0; i < Variables.cornerLabels.Count; i++)
                {
                    if (i % 2 == 0)
                        Variables.cornerLabels[i].Cursor = Cursors.SizeNWSE;
                    else
                        Variables.cornerLabels[i].Cursor = Cursors.SizeNESW;
                }
            }
            else
            {
                lbMaxNormal.Text = StringConst.RESTORELABELTEXT;

                tt1.SetToolTip(lbMaxNormal, StringConst.RESTORETOOLTIPTEXT);

                var posButton = btnDeleteList.Location;
                var posLabel = lbSize.Location;

                var posLogo = posButton.Y - posLabel.Y;

                lbLogo.Location = new Point(lbLogo.Location.X, posLogo + lbLogo.Height);

                foreach (var panel in Variables.borderPanels)
                {
                    panel.Cursor = Cursors.Arrow;
                }
                foreach (var label in Variables.cornerLabels)
                {
                    label.Cursor = Cursors.Arrow;
                }
            }
            //TItel entfernen oder lassem
            if (lbTitle.Location.X - (tbAddWord.Location.X + tbAddWord.Width) < 80 + lbLogo.Width)
            {
                lbTitle.Visible = false;
            }
            else
            {
                lbTitle.Visible = true;
            }

            //Logo entfernen oder lassen
            if(lbLogo.Location.Y < btnDeleteList.Location.Y + btnDeleteList.Height)
            {
                lbLogo.Visible = false;
            }
            else
            {
                lbLogo.Visible = true;
            }
        }

        void MouseDragUp()
        {
            if (snap)
            {
                SetSnapMousePosition();
                snap = false;
                //SetNousePosition();
            }
            dragCursorPoint = Cursor.Position;
            dragFrmPoint = Location;
            
            dragging = true;
        }

        void MouseDragDown()
        {
            dragging = false;

            var posMouse = Cursor.Position;


            if (Cursor.Position.X == currentDesktop.Left)
            {
                Screen targetScreen = null;
                foreach (var screen in Screen.AllScreens)
                {
                    if(Cursor.Position.X >= screen.WorkingArea.X && Cursor.Position.X <= screen.WorkingArea.Right - 1)
                    {
                        targetScreen = screen;
                        break;
                    }
                }
                Location = new Point(targetScreen.WorkingArea.X, targetScreen.WorkingArea.Y);
                Width = targetScreen.WorkingArea.Width / 2;
                Height = targetScreen.WorkingArea.Height;
                snap = true;
            }

            if(Cursor.Position.X == currentDesktop.Right - 1)
            {
                Screen targetScreen = null;
                foreach (var screen in Screen.AllScreens)
                {
                    if (Cursor.Position.X >= screen.WorkingArea.X && Cursor.Position.X <= screen.WorkingArea.Right - 1)
                    {
                        targetScreen = screen;
                        break;
                    }
                }
                Width = targetScreen.WorkingArea.Width / 2;
                Location = new Point(targetScreen.WorkingArea.Right - Width, targetScreen.WorkingArea.Y);
                Height = targetScreen.WorkingArea.Height;
                snap = true;
            }

            if(Cursor.Position.Y == currentDesktop.Top)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        void MouseMoving()
        {
            SetDesktop();
            Drag();
            //Vergändern der größe vom Fenster
            ResizeWindow(direction);
        }

        void SetDesktop()
        {
            foreach (var desktop in Variables.desktops)
            {
                if(Cursor.Position.X > desktop.Left && Cursor.Position.X < desktop.Right)
                {
                    currentDesktop = desktop;
                }
            }
        }

        void Drag()
        {
            if (WindowState == FormWindowState.Maximized && dragging)
            {
                dragging = false;
                SetNousePosition();
            }
            else if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                var posMouse = Cursor.Position;
                if (lbClose.Bottom + Location.Y + 10 < currentDesktop.Height)
                {
                    Location = Point.Add(dragFrmPoint, new Size(dif));
                }
                else if (posMouse.Y < currentDesktop.Height)
                {
                    Location = new Point( Location.X, posMouse.Y - dif.Y);
                }
            }
            
            var isLeft = false;
            var isRight = false;
            foreach (var screen in Screen.AllScreens)
            {
                isLeft = Cursor.Position.X == 0 || Cursor.Position.X == screen.Bounds.X + 1 ? true : false;
                isRight = Cursor.Position.X == screen.Bounds.X - 1 ? true : false;
            }
        }

        void SetSnapMousePosition()
        {
            var isLeft = Cursor.Position.X == currentDesktop.Left ? true : false;
            var oldWidth = Width;
            Width = standardWidth;
            Height = standardHeight;
            CenterToScreen();
            if (isLeft)
            {
                Cursor.Position = new Point(Cursor.Position.X + Location.X + (Width - oldWidth), SnapY());
            }
            else
            {
                Cursor.Position = new Point(Cursor.Position.X - Location.X - (Width - oldWidth), SnapY());
            }
        }

        int SnapY() 
        {
            if(Cursor.Position.Y < Location.Y)
            {
                return Cursor.Position.Y + Location.Y;
            }
            else if(Cursor.Position.Y > Location.Y + Height)
            {
                return Cursor.Position.Y - Location.Y;
            }
            return Cursor.Position.Y;
        }

        void SetNousePosition(bool isMiddle = false)
        {
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

        void ResizeWindow(string direction)
        {
            if (resize && WindowState != FormWindowState.Maximized)
            {
                //Rechts
                if (direction == "r")
                {
                    var dif = Cursor.Position.X - dragCursorPoint.X;
                    Width += dif;
                    Cursor.Position = new Point(Location.X + Width, Cursor.Position.Y);
                }
                //Links
                else if (direction == "l")
                {
                    var dif = Cursor.Position.X - dragCursorPoint.X;
                    var left = dif > 0 ? false : true;

                    if (Width == MinimumSize.Width && left)
                    {
                        Location = new Point(Location.X, Location.Y);
                        Width -= dif;
                    }
                    else if (Width > MinimumSize.Width)
                    {
                        Location = new Point(Location.X + dif, Location.Y);
                        Width -= dif;
                    }
                    if (Location.X + Width != borderRight)
                    {
                        Location = new Point(borderRight - Width, Location.Y);
                    }
                    Cursor.Position = new Point(Location.X, Cursor.Position.Y);
                }
                //Oben
                else if (direction == "u")
                {
                    var dif = Cursor.Position.Y - dragCursorPoint.Y;
                    var top = dif > 0 ? false : true;
                    if (Height > MinimumSize.Height || top)
                    {
                        Location = new Point(Location.X, Location.Y + dif);
                        Height -= dif;
                    }
                    else if (Height > MinimumSize.Height)
                    {
                        Location = new Point(Location.X, Location.Y + dif);
                        Height -= dif;
                    }
                    if (Location.Y + Height != borderBottom)
                    {
                        Location = new Point(Location.X, borderBottom - Height);
                    }
                    Cursor.Position = new Point(Cursor.Position.X, Location.Y);
                }
                //Unten
                else if (direction == "d")
                {
                    var dif = Cursor.Position.Y - dragCursorPoint.Y;
                    Height += dif;
                    Cursor.Position = new Point(Cursor.Position.X, Location.Y + Height);
                }
                //Oben-Links
                else if(direction == lbCornerTL.Name)
                {
                    var difX = Cursor.Position.X - dragCursorPoint.X;
                    var difY = Cursor.Position.Y - dragCursorPoint.Y;
                    var left = difX > 0 ? false : true;
                    var top = difY > 0 ? false : true;
                    if (Height > MinimumSize.Height || top)
                    {
                        Location = new Point(Location.X, Location.Y + difY);
                        Height -= difY;
                    }
                    else if (Height > MinimumSize.Height)
                    {
                        Location = new Point(Location.X, Location.Y + difY);
                        Height -= difY;
                    }
                    if (Location.Y + Height != borderBottom)
                    {
                        Location = new Point(Location.X, borderBottom - Height);
                    }
                    if (Width == MinimumSize.Width && left)
                    {
                        Location = new Point(Location.X, Location.Y);
                        Width -= difX;
                    }
                    else if (Width > MinimumSize.Width)
                    {
                        Location = new Point(Location.X + difX, Location.Y);
                        Width -= difX ;
                    }
                    if (Location.X + Width != borderRight)
                    {
                        Location = new Point(borderRight - Width, Location.Y);
                    }
                    Cursor.Position = new Point(Location.X, Location.Y);
                }
                //Oben-Rechts
                else if (direction == lbCornerTR.Name)
                {
                    var difY = Cursor.Position.Y - dragCursorPoint.Y;
                    var top = difY > 0 ? false : true;
                    if (Height > MinimumSize.Height || top)
                    {
                        Location = new Point(Location.X, Location.Y + difY);
                        Height -= difY;
                    }
                    if (Location.Y + Height != borderBottom)
                    {
                        Location = new Point(Location.X, borderBottom - Height);
                    }

                    var dif = Cursor.Position.X - dragCursorPoint.X;
                    Width += dif;
                    Cursor.Position = new Point(Location.X + Width, Location.Y);
                }
                //Unten-Links
                else if (direction == lbCornerBL.Name)
                {
                    var difX = Cursor.Position.X - dragCursorPoint.X;
                    var left = difX > 0 ? false : true;

                    if (Width == MinimumSize.Width && left)
                    {
                        Location = new Point(Location.X, Location.Y);
                        Width -= difX;
                    }
                    else if (Width > MinimumSize.Width)
                    {
                        Location = new Point(Location.X + difX, Location.Y);
                        Width -= difX;
                    }
                    if (Location.X + Width != borderRight)
                    {
                        Location = new Point(borderRight - Width, Location.Y);
                    }
                    var dif = Cursor.Position.Y - dragCursorPoint.Y;
                    Height += dif;
                    Cursor.Position = new Point(Location.X, Location.Y + Height);
                }
                //Unten-Links
                else if (direction == lbCornerBR.Name)
                {
                    var difY = Cursor.Position.Y - dragCursorPoint.Y;
                    Height += difY;

                    var difX = Cursor.Position.X - dragCursorPoint.X;
                    Width += difX;

                    Cursor.Position = new Point(Location.X + Width, Location.Y + Height);
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
                tt1.SetToolTip(cbTopic, Variables.titleSection);
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
            var newContent = new Content
            {
                WordList = new List<string>()
            };
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
                    newContent = new Content
                    {
                        WordList = new List<string>(),
                        Title = word
                    };
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
                newString = newString.Substring(0, 11) + StringConst.ELLIPSIS;
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
                if (btnNewList.Text == StringConst.NEWLISTBUTTONTEXT)
                {
                    creatingList = true;
                    SetTimer();
                    UpdateButtons();
                    Variables.words = new List<string>();
                    btnNewList.Text = StringConst.ADDLISTBUTTONTEXT;
                    tt1.SetToolTip(btnNewList, StringConst.ADDLISTTOOLTIPTEXT);
                    rtbFullWordList.Text = string.Empty;
                    tbAddWord.Text = string.Empty;
                    tbAddWord.Focus();
                }
                else
                {
                    var titleFrm = new frmTitle
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    titleFrm.ShowDialog();
                    if (titleFrm.Title != null)
                    {
                        btnNewList.Text = StringConst.NEWLISTBUTTONTEXT;
                        tt1.SetToolTip(btnNewList, StringConst.NEWLISTTOOLTIPTEXT);
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
                tt1.SetToolTip(cbTopic, Variables.titleSection);
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
                btnNewList.Text = StringConst.NEWLISTBUTTONTEXT;
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
            if (!creatingList && !playing && Variables.sections.Count > 0)
                SaveLists();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(btnDelete.BackColor == Variables.enabledColor)
            {
                var frm = new frmDelete
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.ShowDialog();
                FillField(true);
                if(Variables.words.Count == 0)
                {
                    btnDelete.BackColor = Variables.disabledColor;
                }
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
            if(btnDeleteList.BackColor == Variables.enabledColor)
            {
                var frm = new frmDelete(false)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
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
            if(cbTopic.SelectedIndex != -1 && !playing && !creatingList)
                cbTopic.DroppedDown = true;
        }
    }
}
