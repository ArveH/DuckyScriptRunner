﻿using System;
using System.IO;
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

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            using (var selectFileDialog = new OpenFileDialog())
            {
                if (selectFileDialog.ShowDialog() != DialogResult.OK) return;

                var fileName = selectFileDialog.FileName;
                txtScriptWindow.Text = File.ReadAllText(fileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var selectFileDialog = new SaveFileDialog())
            {
                if (selectFileDialog.ShowDialog() != DialogResult.OK) return;

                var fileName = selectFileDialog.FileName;
                File.WriteAllText(fileName, txtScriptWindow.Text);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                var commandLines = LineSplitter.SplitIntoLines(txtScriptWindow.Text);
                var commands = CommandFactory.CreateCommands(commandLines);

                var translator = new DuckyTranslator();
                Thread.Sleep(500);
                translator.Run(commands);

            }
            catch (Exception ex)
            {
                txtMessages.AppendText(ex + Environment.NewLine);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
