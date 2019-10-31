using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinemark.Utilities
{
   public  class BalloonPopUp
    {
        public static Container container;
        public static NotifyIcon icon;

        public BalloonPopUp()
        {
            container = new Container();
            icon = new NotifyIcon(container);
            icon.Icon = new Icon(SystemIcons.Information, 40, 40);
        }

        /*
		 * Method : method used to indicate the current running // testcase in a balloon pop in system tray
		 * Params : current // test case name
		 * Returns: void
		 */
        public void showBaloonPopUp(string  testName)
        {
            icon.BalloonTipTitle = "Current running Testcase is ..";
            icon.BalloonTipText =  testName;
            icon.BalloonTipIcon = ToolTipIcon.Info;
            icon.Visible = true;
            icon.ShowBalloonTip(1000);
        }

        public void disposeIcon()
        {
            icon.Visible = false;
            icon.Dispose();
        }
    }
}
