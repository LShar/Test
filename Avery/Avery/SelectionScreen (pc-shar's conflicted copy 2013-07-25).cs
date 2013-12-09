using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avery
{
    public partial class SelectionScreen : Form
    {
        private Rectangle mainClippingArea = new Rectangle();
        private bool mouseDrawRectangle = false;
        private Graphics gs;
        private Point startPosition = new Point();
        private Point endPosition = new Point();
        public SelectionScreen()
        {
            InitializeComponent();
            gs = this.CreateGraphics();
            SelectedRectangle.SelectionWasMade = false;
            Point pt = new Point(Screen.PrimaryScreen.Bounds.Width - 200, 50);
            Point ptClose = new Point(Screen.PrimaryScreen.Bounds.Width - 50, 50);
            btnClose.Location = ptClose;            
            this.Opacity = 0.5;

            pictureBox1.BackColor = Color.FromArgb(155,155,255);
            this.TransparencyKey = Color.FromArgb(155, 155, 255);

        }
      
        private void SelectionScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (!mouseDrawRectangle)
                this.Invalidate();            
            mouseDrawRectangle = true;
            startPosition.X = e.X;
            startPosition.Y = e.Y;
            endPosition.X = -1;
            endPosition.Y = -1;
        }

        private void MyDrawReversibleRectangle(Point startPoint, Point endPoint)
        {
            Rectangle rc = new Rectangle();
            pictureBox1.Visible = true;
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
            mainClippingArea = rc;

            pictureBox1.Location = rc.Location;
            pictureBox1.Width = rc.Width;
            pictureBox1.Height = rc.Height;
        }

        private void SelectionScreen_MouseMove(object sender, MouseEventArgs e)
        {
            Point ptCurrent = new Point(e.X, e.Y);
            if (mouseDrawRectangle)
            {
                if (endPosition.X != -1)
                {
                    MyDrawReversibleRectangle(startPosition, endPosition);
                }
                endPosition = ptCurrent;
                MyDrawReversibleRectangle(startPosition, ptCurrent);
            }
        }

        private void SelectionScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPosition != endPosition)
            {
                mouseDrawRectangle = false;
                if (endPosition.X != -1)
                {
                    Point ptCurrent = new Point(e.X, e.Y);
                    MyDrawReversibleRectangle(startPosition, endPosition);
                }

                gs = this.CreateGraphics();               
                gs.DrawRectangle(new Pen(Color.Red, 10), mainClippingArea);
                endPosition.X = -1;
                endPosition.Y = -1;
                startPosition.X = -1;
                startPosition.Y = -1;

                SelectedRectangle.UserSelection = mainClippingArea;
                SelectedRectangle.SelectionWasMade = true;
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
