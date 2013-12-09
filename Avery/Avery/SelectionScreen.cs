using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            this.Opacity = 0.65;
            gs = this.CreateGraphics();
            
        }

        private void ShowSubTool()
        {           
            SubToolForm sub = new SubToolForm();
            Point pt = new Point(50, 50);
            sub.Location = pt;
            sub.ShowInTaskbar = false;
            sub.ShowDialog();
            
        }
              

        private void SelectionScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (!mouseDrawRectangle)
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

            mouseDrawRectangle = true;
            startPosition.X = e.X;
            startPosition.Y = e.Y;
            endPosition.X = -1;
            endPosition.Y = -1;
        }

        private void MyDrawReversibleRectangle(Point startPoint, Point endPoint)
        {
            Rectangle rc = new Rectangle();
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
            mainClippingArea = rc;
            //ControlPaint.DrawReversibleFrame(rc, Color.Red, FrameStyle.Thick);
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
                ShowSubTool();
                if (SelectedRectangle.SelectionWasMade)
                    this.Close();
                if (SelectedRectangle.SelectionWasClosed)
                    this.Close();
            }

        }       
               
    }
}
