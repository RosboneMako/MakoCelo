using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
    public partial class frmErrLog
    {
        private readonly List<object> _logItems;

        public frmErrLog(List<object> logItems)
        {
            InitializeComponent();
            _cmCopy.Name = "cmCopy";
            _cmExit.Name = "cmExit";
            _logItems = logItems;
        }

        private void frmErrLog_Load(object sender, EventArgs e)
        {
            string A = "";

            // R4.41 Get the data from the main form listbox.
            for (int t = 0, loopTo = _logItems.Count - 1; t <= loopTo; t++)
                A = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(A, _logItems[t]), Constants.vbCrLf));

            // R4.41 Place the log data into the text box and unselect the text.
            tbErrLog.Text = A;
            tbErrLog.SelectionStart = 0;
            tbErrLog.SelectionLength = 0;
        }

        private void cmCopy_Click(object sender, EventArgs e)
        {
            // R4.41 Post the log to the clipboard.
            Clipboard.Clear();
            Clipboard.SetText(tbErrLog.Text);
        }

        private void cmExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}