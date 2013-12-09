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
    public partial class SubToolForm : Form
    {
        public SubToolForm()
        {
            InitializeComponent();
        }

        private void btnClipAndCopy_Click(object sender, EventArgs e)
        {
            Graphics graph = null;
            var bmp = new Bitmap(SelectedRectangle.UserSelection.Width, SelectedRectangle.UserSelection.Height);
            graph = Graphics.FromImage(bmp);
            graph.CopyFromScreen(SelectedRectangle.UserSelection.Location.X, SelectedRectangle.UserSelection.Location.Y, 0, 0, bmp.Size);
            Clipboard.SetImage(bmp);
            SelectedRectangle.SelectionWasMade = true;
            SelectedRectangle.SelectionWasClosed = false;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SelectedRectangle.SelectionWasClosed = true;
            this.Close();
        }
    }
}
