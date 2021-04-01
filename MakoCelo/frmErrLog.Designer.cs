using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
    [DesignerGenerated()]
    public partial class frmErrLog : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmErrLog));
            lbHead = new Label();
            tbErrLog = new TextBox();
            _cmCopy = new Button();
            _cmCopy.Click += new EventHandler(cmCopy_Click);
            _cmExit = new Button();
            _cmExit.Click += new EventHandler(cmExit_Click);
            SuspendLayout();
            // 
            // lbHead
            // 
            lbHead.AutoSize = true;
            lbHead.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbHead.Location = new Point(12, 9);
            lbHead.Name = "lbHead";
            lbHead.Size = new Size(372, 16);
            lbHead.TabIndex = 0;
            lbHead.Text = "The data below is the WEB data log for the last player search:";
            // 
            // tbErrLog
            // 
            tbErrLog.BackColor = Color.White;
            tbErrLog.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            tbErrLog.Location = new Point(15, 28);
            tbErrLog.Multiline = true;
            tbErrLog.Name = "tbErrLog";
            tbErrLog.ReadOnly = true;
            tbErrLog.ScrollBars = ScrollBars.Both;
            tbErrLog.Size = new Size(488, 410);
            tbErrLog.TabIndex = 1;
            // 
            // cmCopy
            // 
            _cmCopy.Location = new Point(542, 28);
            _cmCopy.Name = "_cmCopy";
            _cmCopy.Size = new Size(125, 54);
            _cmCopy.TabIndex = 2;
            _cmCopy.Text = "Copy to Clipboard";
            _cmCopy.UseVisualStyleBackColor = true;
            // 
            // cmExit
            // 
            _cmExit.Location = new Point(542, 108);
            _cmExit.Name = "_cmExit";
            _cmExit.Size = new Size(125, 54);
            _cmExit.TabIndex = 3;
            _cmExit.Text = "Exit";
            _cmExit.UseVisualStyleBackColor = true;
            // 
            // frmErrLog
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            ClientSize = new Size(698, 458);
            Controls.Add(_cmExit);
            Controls.Add(_cmCopy);
            Controls.Add(tbErrLog);
            Controls.Add(lbHead);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmErrLog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MakoCELO - Web Transaction Log";
            Load += new EventHandler(frmErrLog_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label lbHead;
        internal TextBox tbErrLog;
        private Button _cmCopy;

        internal Button cmCopy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCopy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCopy != null)
                {
                    _cmCopy.Click -= cmCopy_Click;
                }

                _cmCopy = value;
                if (_cmCopy != null)
                {
                    _cmCopy.Click += cmCopy_Click;
                }
            }
        }

        private Button _cmExit;

        internal Button cmExit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmExit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmExit != null)
                {
                    _cmExit.Click -= cmExit_Click;
                }

                _cmExit = value;
                if (_cmExit != null)
                {
                    _cmExit.Click += cmExit_Click;
                }
            }
        }
    }
}