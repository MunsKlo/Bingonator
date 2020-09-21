using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoWortGeber
{

    public partial class Form1 : Form
    {
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            ntbTextSize.Value = 20;
            //CheckDuplicates();
        }

        private void btnRandom_Click(object sender, EventArgs e)
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
                tbRandomString.Text = "Keine Wörter mehr vorhanden";
            
        }

        private void OutputDuplicates()
        {
            var list = new List<string>();
            foreach (var item in Variables.words)
            {
                if (!list.Contains(item))
                    list.Add(item);
                else
                {
                    tbAddWord.Text += item + " ";
                }

            }
            tbAddWord.Text += list.Count.ToString() + " " + Variables.words.Count.ToString();
        }

        private bool CheckDuplicate(string newWord)
        {
            return Variables.words.Contains(newWord);
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            if (!CheckDuplicate(tbAddWord.Text) && tbAddWord.Text.Length > 0)
                Variables.words.Add(tbAddWord.Text);
            tbAddWord.Text = "";
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

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Variables.duplicates = new List<string>();
            tbRandomString.Text = "Spiel wurde zurückgesetzt";
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ntbTextSize_ValueChanged(object sender, EventArgs e)
        {
            var numb = (int)ntbTextSize.Value;
            if (numb < 100 && numb > 0)
            {
                rtbFullWordList.Font = new Font(rtbFullWordList.Font.FontFamily.Name, numb, FontStyle.Bold);
            }
        }
    }
}
