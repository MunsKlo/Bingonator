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
        bool dragging = false;
        Point dragCursorPoint;
        Point dragFrmPoint;
        public frmDelete()
        {
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
            FillComboBox();
            if(cbWord.Items.Count > 0)
                cbWord.SelectedIndex = 0;
        }

        void FillComboBox()
        {
            foreach (var item in Variables.words)
            {
                cbWord.Items.Add(item);
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
            if(cbWord.Text == string.Empty)
                pTitle.BackColor = Color.Red;
            else
            {
                Variables.words.Remove(cbWord.Text);
                Close();
            }
        }
            

        private void cbWord_SelectedIndexChanged(object sender, EventArgs e)
        {
            pTitle.BackColor = Variables.blue;
            lbDelete.Focus();
        }
    }
}
