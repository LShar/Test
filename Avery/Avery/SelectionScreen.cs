using System.Drawing;
using System.Windows.Forms;

namespace Avery
{
    public partial class SelectionScreen : Form
    {
        private Rectangle _mainClippingArea = new Rectangle();
        private bool _mouseDrawRectangle = false;
        private Graphics _gs;
        private Point _startPosition = new Point();
        private Point _endPosition = new Point();
       
        public SelectionScreen()
        {
            InitializeComponent();
            this.Opacity = 0.65;
            _gs = this.CreateGraphics();
            
        }

        private void ShowSubTool()
        {           
            var sub = new SubToolForm();
            var pt = new Point(50, 50);
            sub.Location = pt;
            sub.ShowInTaskbar = false;
            sub.ShowDialog();
            
        }
              

        private void SelectionScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_mouseDrawRectangle)
                this.Invalidate();
            
            pictureBox1.Visible = true;
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(
               ((System.Byte)(255)),
               ((System.Byte)(128)),
               ((System.Byte)(128)));
            this.TransparencyKey = System.Drawing.Color.FromArgb(
                ((System.Byte)(255)),
                ((System.Byte)(128)),
                ((System.Byte)(128)));

            _mouseDrawRectangle = true;
            _startPosition.X = e.X;
            _startPosition.Y = e.Y;
            _endPosition.X = -1;
            _endPosition.Y = -1;
        }

        private void MyDrawReversibleRectangle(Point startPoint, Point endPoint)
        {
            var rc = new Rectangle();
            startPoint = PointToScreen(startPoint);
            endPoint = PointToScreen(endPoint);
            if (startPoint.X < endPoint.X)
            {
                rc.X = startPoint.X;
                rc.Width = endPoint.X - startPoint.X;               
            }
            else
            {
                rc.X = endPoint.X;
                rc.Width = startPoint.X - endPoint.X;
            }
            if (startPoint.Y < endPoint.Y)
            {
                rc.Y = startPoint.Y;
                rc.Height = endPoint.Y - startPoint.Y;
            }
            else
            {
                rc.Y = endPoint.Y;
                rc.Height = startPoint.Y - endPoint.Y;
            }

            pictureBox1.Location = rc.Location;
            pictureBox1.Height = rc.Height;
            pictureBox1.Width = rc.Width;
            _mainClippingArea = rc;
            //ControlPaint.DrawReversibleFrame(rc, Color.Red, FrameStyle.Thick);
        }

        private void SelectionScreen_MouseMove(object sender, MouseEventArgs e)
        {
            var ptCurrent = new Point(e.X, e.Y);
            if (_mouseDrawRectangle)
            {
                if (_endPosition.X != -1)
                {
                    MyDrawReversibleRectangle(_startPosition, _endPosition);
                }
                _endPosition = ptCurrent;
                MyDrawReversibleRectangle(_startPosition, ptCurrent);
            }
        }

        private void SelectionScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (_startPosition != _endPosition)
            {
                _mouseDrawRectangle = false;
                if (_endPosition.X != -1)
                {
                    Point ptCurrent = new Point(e.X, e.Y);
                    MyDrawReversibleRectangle(_startPosition, _endPosition);
                }

                _gs = this.CreateGraphics();
                _gs.DrawRectangle(new Pen(Color.Red, 10), _mainClippingArea);
                _endPosition.X = -1;
                _endPosition.Y = -1;
                _startPosition.X = -1;
                _startPosition.Y = -1;

                SelectedRectangle.UserSelection = _mainClippingArea;
                ShowSubTool();
                if (SelectedRectangle.SelectionWasMade)
                    this.Close();
                if (SelectedRectangle.SelectionWasClosed)
                    this.Close();
            }

        }       
               
    }
}
