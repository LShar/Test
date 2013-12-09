using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Avery
{
    class SelectedRectangle
    {
        public static Rectangle UserSelection { get; set; }
        public static bool SelectionWasMade { get; set; }
        public static bool SelectionWasClosed { get; set; }
    }
}
