using System;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using DuckyScriptRunner.Translator;
using DuckyScriptRunner.Translator.Commands;

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
            var commandLines = LineSplitter.SplitIntoLines(txtScriptWindow.Text);
            var commands = CommandFactory.CreateCommands(commandLines);

            var translator = new DuckyTranslator();
            Thread.Sleep(500);
            translator.Run(commands);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
