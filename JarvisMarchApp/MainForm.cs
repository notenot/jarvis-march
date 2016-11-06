using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace JarvisMarch
{
    public partial class MainForm : Form
    {
        private Pen _hullPen; 
        private Pen _pointPen;
        private Color _backGr;
        private Graphics _graphics;

        private LinkedList<Point> _points; 

        public MainForm()
        {
            InitializeComponent();

            _hullPen = new Pen(Color.Aquamarine);
            _pointPen = new Pen(Color.Black);
            _backGr = Color.White;

            _points = new LinkedList<Point>();
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var point = new Point(e.X, e.Y);
            if (_points.Contains(point))
                return;

            _points.AddLast(point);

            _graphics.DrawRectangle(_pointPen, point.X, point.Y, 1, 1);
            pictureBox.Invalidate();
        }

        private void MainForm_Shown(object sender, System.EventArgs e)
        {
            pictureBox.BackColor = Color.White;
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);

            _graphics = Graphics.FromImage(pictureBox.Image);
        }

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            using (var brush = new SolidBrush(_backGr))
                _graphics.FillRectangle
                    (brush, 0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Invalidate();

            _points.Clear();
        }

        private void computeButton_Click(object sender, System.EventArgs e)
        {
            if (_points.Count < 3)
                return;

            var hull = JarvisMarchLib.JarvisMarch.Calculate(_points);

            var node = hull.First;
            while (node.Next != null)
            {
                _graphics.DrawLine(_hullPen, node.Value, node.Next.Value);
                node = node.Next;
            }
            _graphics.DrawLine(_hullPen, node.Value, hull.First.Value);
            pictureBox.Invalidate();
        }
    }
}
