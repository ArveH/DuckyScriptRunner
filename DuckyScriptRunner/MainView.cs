using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace DuckyScriptRunner
{
    public partial class MainView : Form
    {
        #region Not necessary (http://www.yortondotnet.com/2006/11/on-screen-keyboards.html )

        //private const int WS_EX_NOACTIVATE = 0x08000000;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var createParam = base.CreateParams;
        //        createParam.ExStyle = createParam.ExStyle | WS_EX_NOACTIVATE;
        //        return base.CreateParams;
        //    }
        //}
        #endregion

        public MainView()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var inputSimulator = new InputSimulator();
            inputSimulator.Keyboard
                .ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_R)
                .Sleep(100)
                .TextEntry("notepad")
                .Sleep(100)
                .KeyPress(VirtualKeyCode.RETURN)
                .Sleep(100)
                .TextEntry("These are your orders if you choose to accept them...")
                .TextEntry("This message will self destruct in 2 seconds.")
                .Sleep(2000)
                .ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.VK_F)
                .KeyPress(VirtualKeyCode.VK_X)
                .KeyPress(VirtualKeyCode.TAB)
                .KeyPress(VirtualKeyCode.RETURN);


        }
    }
}
