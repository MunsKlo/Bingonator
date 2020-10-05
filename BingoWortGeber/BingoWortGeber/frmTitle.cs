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
    public partial class frmTitle : Form
    {
        public string Title { get; set; }
        bool dragging = false;
        Point dragCursorPoint;
        Point dragFrmPoint;
        public frmTitle()
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
            Title = null;
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text.Length > 0)
            {
                Title = tbTitle.Text;
                Close();
            }
            pTitle.BackColor = Color.Red;
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            pTitle.BackColor = Variables.blue;
        }
    }
}
