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
    public partial class frmDelete : Form
    {
        public string Title { get; set; }


        bool dragging = false;
        Point dragCursorPoint;
        Point dragFrmPoint;
        bool isWordDelete;
        public frmDelete(bool isWordDelete = true)
        {
            this.isWordDelete = isWordDelete;
            InitializeComponent();

            MouseUp += (o, e) => { MouseDragDown(); };
            MouseDown += (o, e) => { MouseDragUp(); };
            MouseMove += (o, e) => { MouseMoving(); };

            foreach (var label in Controls.OfType<Label>())
            {
                label.MouseUp += (o, e) => { MouseDragDown(); };
                label.MouseDown += (o, e) => { MouseDragUp(); };
                label.MouseMove += (o, e) => { MouseMoving(); };
            }
            if (!isWordDelete)
            {
                lbDelete.Text = "Liste löschen:";
            }
            FillComboBox();
            if(cbWord.Items.Count > 0)
                cbWord.SelectedIndex = 0;
        }

        void FillComboBox()
        {
            if (isWordDelete)
            {
                foreach (var item in Variables.words)
                {
                    cbWord.Items.Add(item);
                }
            }
            else
            {
                foreach (var item in Variables.sections)
                {
                    cbWord.Items.Add(item.Title);
                }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbWord.Text == string.Empty)
                pTitle.BackColor = Color.Red;
            else if (isWordDelete)
            {
                Variables.words.Remove(cbWord.Text);
                Close();
            }
            else
            {
                Title = cbWord.Text;
                Variables.sections.Remove(GetContent());
                Close();
            }
        }
            

        private void cbWord_SelectedIndexChanged(object sender, EventArgs e)
        {
            pTitle.BackColor = Variables.blue;
            lbDelete.Focus();
        }

        Content GetContent()
        {
            var content = new Content();
            foreach (var item in Variables.sections)
            {
                if(cbWord.Text == item.Title)
                {
                    content = item;
                }
            }
            return content;
        }
    }
}
