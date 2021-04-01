using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
    [DesignerGenerated()]
    public partial class frmMaxPlayerSearch : Form
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaxPlayerSearch));
            _Web1 = new WebBrowser();
            _Web1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Web1_DocumentCompleted);
            _cm1v1Sov = new Button();
            _cm1v1Sov.Click += new EventHandler(cm1v1Sov_Click);
            tb1v1Sov = new TextBox();
            _cm1v1Usf = new Button();
            _cm1v1Usf.Click += new EventHandler(cm1v1Usf_Click);
            tb1v1Usf = new TextBox();
            _cm1v1Brit = new Button();
            _cm1v1Brit.Click += new EventHandler(cm1v1Brit_Click);
            _cm1v1Ost = new Button();
            _cm1v1Ost.Click += new EventHandler(cm1v1Ost_Click);
            _cm1v1Okw = new Button();
            _cm1v1Okw.Click += new EventHandler(cm1v1Okw_Click);
            tb1v1Brit = new TextBox();
            tb1v1Ost = new TextBox();
            tb1v1Okw = new TextBox();
            tb2v2Okw = new TextBox();
            tb2v2Ost = new TextBox();
            tb2v2Brit = new TextBox();
            tb2v2Usf = new TextBox();
            tb2v2Sov = new TextBox();
            tb3v3Okw = new TextBox();
            tb3v3Ost = new TextBox();
            tb3v3Brit = new TextBox();
            tb3v3Usf = new TextBox();
            tb3v3Sov = new TextBox();
            tb4v4Okw = new TextBox();
            tb4v4Ost = new TextBox();
            tb4v4Brit = new TextBox();
            tb4v4Usf = new TextBox();
            tb4v4Sov = new TextBox();
            Panel1 = new Panel();
            rb4v4 = new RadioButton();
            rb3v3 = new RadioButton();
            rb2v2 = new RadioButton();
            rb1v1 = new RadioButton();
            _cmATallies = new Button();
            _cmATallies.Click += new EventHandler(cmATallies_Click);
            tb2ATAllies = new TextBox();
            tb3ATAllies = new TextBox();
            tb4ATAllies = new TextBox();
            _cmATAxis = new Button();
            _cmATAxis.Click += new EventHandler(cmATAxis_Click);
            tb4ATAxis = new TextBox();
            tb3ATAxis = new TextBox();
            tb2ATAxis = new TextBox();
            _cmOK = new Button();
            _cmOK.Click += new EventHandler(cmOK_Click);
            _cmGetAll = new Button();
            _cmGetAll.Click += new EventHandler(cmGetAll_Click);
            _cmCancel = new Button();
            _cmCancel.Click += new EventHandler(cmCancel_Click);
            _cmStopAll = new Button();
            _cmStopAll.Click += new EventHandler(cmStopAll_Click);
            lbStatus = new Label();
            _cmGetAllActual = new Button();
            _cmGetAllActual.Click += new EventHandler(cmGetAllActual_Click);
            ToolTip1 = new ToolTip(components);
            tbHelp = new TextBox();
            Button2 = new Button();
            Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Web1
            // 
            _Web1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _Web1.Location = new Point(12, 154);
            _Web1.MinimumSize = new Size(20, 20);
            _Web1.Name = "_Web1";
            _Web1.Size = new Size(1316, 482);
            _Web1.TabIndex = 42;
            // 
            // cm1v1Sov
            // 
            _cm1v1Sov.Location = new Point(119, 8);
            _cm1v1Sov.Name = "_cm1v1Sov";
            _cm1v1Sov.Size = new Size(50, 27);
            _cm1v1Sov.TabIndex = 1;
            _cm1v1Sov.Text = "Sov";
            ToolTip1.SetToolTip(_cm1v1Sov, "Open the relic website to get the max number of players.");
            _cm1v1Sov.UseVisualStyleBackColor = true;
            // 
            // tb1v1Sov
            // 
            tb1v1Sov.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb1v1Sov.ForeColor = Color.Black;
            tb1v1Sov.Location = new Point(119, 41);
            tb1v1Sov.Name = "tb1v1Sov";
            tb1v1Sov.Size = new Size(50, 20);
            tb1v1Sov.TabIndex = 17;
            // 
            // cm1v1Usf
            // 
            _cm1v1Usf.Location = new Point(231, 8);
            _cm1v1Usf.Name = "_cm1v1Usf";
            _cm1v1Usf.Size = new Size(50, 27);
            _cm1v1Usf.TabIndex = 3;
            _cm1v1Usf.Text = "Usf";
            ToolTip1.SetToolTip(_cm1v1Usf, "Open the relic website to get the max number of players.");
            _cm1v1Usf.UseVisualStyleBackColor = true;
            // 
            // tb1v1Usf
            // 
            tb1v1Usf.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb1v1Usf.ForeColor = Color.Black;
            tb1v1Usf.Location = new Point(231, 41);
            tb1v1Usf.Name = "tb1v1Usf";
            tb1v1Usf.Size = new Size(50, 20);
            tb1v1Usf.TabIndex = 19;
            // 
            // cm1v1Brit
            // 
            _cm1v1Brit.Location = new Point(287, 8);
            _cm1v1Brit.Name = "_cm1v1Brit";
            _cm1v1Brit.Size = new Size(50, 27);
            _cm1v1Brit.TabIndex = 4;
            _cm1v1Brit.Text = "Brit";
            ToolTip1.SetToolTip(_cm1v1Brit, "Open the relic website to get the max number of players.");
            _cm1v1Brit.UseVisualStyleBackColor = true;
            // 
            // cm1v1Ost
            // 
            _cm1v1Ost.Location = new Point(63, 8);
            _cm1v1Ost.Name = "_cm1v1Ost";
            _cm1v1Ost.Size = new Size(50, 27);
            _cm1v1Ost.TabIndex = 0;
            _cm1v1Ost.Text = "Ost";
            ToolTip1.SetToolTip(_cm1v1Ost, "Open the relic website to get the max number of players.");
            _cm1v1Ost.UseVisualStyleBackColor = true;
            // 
            // cm1v1Okw
            // 
            _cm1v1Okw.Location = new Point(175, 8);
            _cm1v1Okw.Name = "_cm1v1Okw";
            _cm1v1Okw.Size = new Size(50, 27);
            _cm1v1Okw.TabIndex = 2;
            _cm1v1Okw.Text = "Okw";
            ToolTip1.SetToolTip(_cm1v1Okw, "Open the relic website to get the max number of players.");
            _cm1v1Okw.UseVisualStyleBackColor = true;
            // 
            // tb1v1Brit
            // 
            tb1v1Brit.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb1v1Brit.ForeColor = Color.Black;
            tb1v1Brit.Location = new Point(287, 41);
            tb1v1Brit.Name = "tb1v1Brit";
            tb1v1Brit.Size = new Size(50, 20);
            tb1v1Brit.TabIndex = 20;
            // 
            // tb1v1Ost
            // 
            tb1v1Ost.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb1v1Ost.ForeColor = Color.Black;
            tb1v1Ost.Location = new Point(63, 41);
            tb1v1Ost.Name = "tb1v1Ost";
            tb1v1Ost.Size = new Size(50, 20);
            tb1v1Ost.TabIndex = 16;
            // 
            // tb1v1Okw
            // 
            tb1v1Okw.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb1v1Okw.ForeColor = Color.Black;
            tb1v1Okw.Location = new Point(175, 41);
            tb1v1Okw.Name = "tb1v1Okw";
            tb1v1Okw.Size = new Size(50, 20);
            tb1v1Okw.TabIndex = 18;
            // 
            // tb2v2Okw
            // 
            tb2v2Okw.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb2v2Okw.ForeColor = Color.Black;
            tb2v2Okw.Location = new Point(175, 67);
            tb2v2Okw.Name = "tb2v2Okw";
            tb2v2Okw.Size = new Size(50, 20);
            tb2v2Okw.TabIndex = 23;
            // 
            // tb2v2Ost
            // 
            tb2v2Ost.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb2v2Ost.ForeColor = Color.Black;
            tb2v2Ost.Location = new Point(63, 67);
            tb2v2Ost.Name = "tb2v2Ost";
            tb2v2Ost.Size = new Size(50, 20);
            tb2v2Ost.TabIndex = 21;
            // 
            // tb2v2Brit
            // 
            tb2v2Brit.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb2v2Brit.ForeColor = Color.Black;
            tb2v2Brit.Location = new Point(287, 67);
            tb2v2Brit.Name = "tb2v2Brit";
            tb2v2Brit.Size = new Size(50, 20);
            tb2v2Brit.TabIndex = 25;
            // 
            // tb2v2Usf
            // 
            tb2v2Usf.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb2v2Usf.ForeColor = Color.Black;
            tb2v2Usf.Location = new Point(231, 67);
            tb2v2Usf.Name = "tb2v2Usf";
            tb2v2Usf.Size = new Size(50, 20);
            tb2v2Usf.TabIndex = 24;
            // 
            // tb2v2Sov
            // 
            tb2v2Sov.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb2v2Sov.ForeColor = Color.Black;
            tb2v2Sov.Location = new Point(119, 67);
            tb2v2Sov.Name = "tb2v2Sov";
            tb2v2Sov.Size = new Size(50, 20);
            tb2v2Sov.TabIndex = 22;
            // 
            // tb3v3Okw
            // 
            tb3v3Okw.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb3v3Okw.ForeColor = Color.Black;
            tb3v3Okw.Location = new Point(175, 93);
            tb3v3Okw.Name = "tb3v3Okw";
            tb3v3Okw.Size = new Size(50, 20);
            tb3v3Okw.TabIndex = 30;
            // 
            // tb3v3Ost
            // 
            tb3v3Ost.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb3v3Ost.ForeColor = Color.Black;
            tb3v3Ost.Location = new Point(63, 93);
            tb3v3Ost.Name = "tb3v3Ost";
            tb3v3Ost.Size = new Size(50, 20);
            tb3v3Ost.TabIndex = 28;
            // 
            // tb3v3Brit
            // 
            tb3v3Brit.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb3v3Brit.ForeColor = Color.Black;
            tb3v3Brit.Location = new Point(287, 93);
            tb3v3Brit.Name = "tb3v3Brit";
            tb3v3Brit.Size = new Size(50, 20);
            tb3v3Brit.TabIndex = 32;
            // 
            // tb3v3Usf
            // 
            tb3v3Usf.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb3v3Usf.ForeColor = Color.Black;
            tb3v3Usf.Location = new Point(231, 93);
            tb3v3Usf.Name = "tb3v3Usf";
            tb3v3Usf.Size = new Size(50, 20);
            tb3v3Usf.TabIndex = 31;
            // 
            // tb3v3Sov
            // 
            tb3v3Sov.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb3v3Sov.ForeColor = Color.Black;
            tb3v3Sov.Location = new Point(119, 93);
            tb3v3Sov.Name = "tb3v3Sov";
            tb3v3Sov.Size = new Size(50, 20);
            tb3v3Sov.TabIndex = 29;
            // 
            // tb4v4Okw
            // 
            tb4v4Okw.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb4v4Okw.ForeColor = Color.Black;
            tb4v4Okw.Location = new Point(175, 119);
            tb4v4Okw.Name = "tb4v4Okw";
            tb4v4Okw.Size = new Size(50, 20);
            tb4v4Okw.TabIndex = 36;
            // 
            // tb4v4Ost
            // 
            tb4v4Ost.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb4v4Ost.ForeColor = Color.Black;
            tb4v4Ost.Location = new Point(63, 119);
            tb4v4Ost.Name = "tb4v4Ost";
            tb4v4Ost.Size = new Size(50, 20);
            tb4v4Ost.TabIndex = 35;
            // 
            // tb4v4Brit
            // 
            tb4v4Brit.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb4v4Brit.ForeColor = Color.Black;
            tb4v4Brit.Location = new Point(287, 119);
            tb4v4Brit.Name = "tb4v4Brit";
            tb4v4Brit.Size = new Size(50, 20);
            tb4v4Brit.TabIndex = 38;
            // 
            // tb4v4Usf
            // 
            tb4v4Usf.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb4v4Usf.ForeColor = Color.Black;
            tb4v4Usf.Location = new Point(231, 119);
            tb4v4Usf.Name = "tb4v4Usf";
            tb4v4Usf.Size = new Size(50, 20);
            tb4v4Usf.TabIndex = 37;
            // 
            // tb4v4Sov
            // 
            tb4v4Sov.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb4v4Sov.ForeColor = Color.Black;
            tb4v4Sov.Location = new Point(119, 119);
            tb4v4Sov.Name = "tb4v4Sov";
            tb4v4Sov.Size = new Size(50, 20);
            tb4v4Sov.TabIndex = 35;
            // 
            // Panel1
            // 
            Panel1.Controls.Add(rb4v4);
            Panel1.Controls.Add(rb3v3);
            Panel1.Controls.Add(rb2v2);
            Panel1.Controls.Add(rb1v1);
            Panel1.Location = new Point(12, 41);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(48, 98);
            Panel1.TabIndex = 43;
            Panel1.TabStop = true;
            // 
            // rb4v4
            // 
            rb4v4.AutoSize = true;
            rb4v4.ForeColor = Color.Black;
            rb4v4.Location = new Point(3, 72);
            rb4v4.Name = "rb4v4";
            rb4v4.Size = new Size(43, 17);
            rb4v4.TabIndex = 15;
            rb4v4.TabStop = true;
            rb4v4.Text = "&4v4";
            rb4v4.UseVisualStyleBackColor = true;
            // 
            // rb3v3
            // 
            rb3v3.AutoSize = true;
            rb3v3.ForeColor = Color.Black;
            rb3v3.Location = new Point(3, 49);
            rb3v3.Name = "rb3v3";
            rb3v3.Size = new Size(43, 17);
            rb3v3.TabIndex = 14;
            rb3v3.TabStop = true;
            rb3v3.Text = "&3v3";
            rb3v3.UseVisualStyleBackColor = true;
            // 
            // rb2v2
            // 
            rb2v2.AutoSize = true;
            rb2v2.ForeColor = Color.Black;
            rb2v2.Location = new Point(3, 26);
            rb2v2.Name = "rb2v2";
            rb2v2.Size = new Size(43, 17);
            rb2v2.TabIndex = 13;
            rb2v2.TabStop = true;
            rb2v2.Text = "&2v2";
            rb2v2.UseVisualStyleBackColor = true;
            // 
            // rb1v1
            // 
            rb1v1.AutoSize = true;
            rb1v1.Checked = true;
            rb1v1.ForeColor = Color.Black;
            rb1v1.Location = new Point(3, 3);
            rb1v1.Name = "rb1v1";
            rb1v1.Size = new Size(43, 17);
            rb1v1.TabIndex = 12;
            rb1v1.TabStop = true;
            rb1v1.Text = "&1v1";
            rb1v1.UseVisualStyleBackColor = true;
            // 
            // cmATallies
            // 
            _cmATallies.Location = new Point(343, 8);
            _cmATallies.Name = "_cmATallies";
            _cmATallies.Size = new Size(66, 27);
            _cmATallies.TabIndex = 5;
            _cmATallies.Text = "AT Allies";
            ToolTip1.SetToolTip(_cmATallies, "Open the relic website to get the max number of players.");
            _cmATallies.UseVisualStyleBackColor = true;
            // 
            // tb2ATAllies
            // 
            tb2ATAllies.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb2ATAllies.ForeColor = Color.Black;
            tb2ATAllies.Location = new Point(343, 67);
            tb2ATAllies.Name = "tb2ATAllies";
            tb2ATAllies.Size = new Size(66, 20);
            tb2ATAllies.TabIndex = 26;
            // 
            // tb3ATAllies
            // 
            tb3ATAllies.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb3ATAllies.ForeColor = Color.Black;
            tb3ATAllies.Location = new Point(343, 93);
            tb3ATAllies.Name = "tb3ATAllies";
            tb3ATAllies.Size = new Size(66, 20);
            tb3ATAllies.TabIndex = 33;
            // 
            // tb4ATAllies
            // 
            tb4ATAllies.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb4ATAllies.ForeColor = Color.Black;
            tb4ATAllies.Location = new Point(343, 119);
            tb4ATAllies.Name = "tb4ATAllies";
            tb4ATAllies.Size = new Size(66, 20);
            tb4ATAllies.TabIndex = 39;
            // 
            // cmATAxis
            // 
            _cmATAxis.Location = new Point(415, 8);
            _cmATAxis.Name = "_cmATAxis";
            _cmATAxis.Size = new Size(66, 27);
            _cmATAxis.TabIndex = 6;
            _cmATAxis.Text = "AT Axis";
            ToolTip1.SetToolTip(_cmATAxis, "Open the relic website to get the max number of players.");
            _cmATAxis.UseVisualStyleBackColor = true;
            // 
            // tb4ATAxis
            // 
            tb4ATAxis.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb4ATAxis.ForeColor = Color.Black;
            tb4ATAxis.Location = new Point(415, 119);
            tb4ATAxis.Name = "tb4ATAxis";
            tb4ATAxis.Size = new Size(66, 20);
            tb4ATAxis.TabIndex = 40;
            // 
            // tb3ATAxis
            // 
            tb3ATAxis.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb3ATAxis.ForeColor = Color.Black;
            tb3ATAxis.Location = new Point(415, 93);
            tb3ATAxis.Name = "tb3ATAxis";
            tb3ATAxis.Size = new Size(66, 20);
            tb3ATAxis.TabIndex = 34;
            // 
            // tb2ATAxis
            // 
            tb2ATAxis.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            tb2ATAxis.ForeColor = Color.Black;
            tb2ATAxis.Location = new Point(415, 67);
            tb2ATAxis.Name = "tb2ATAxis";
            tb2ATAxis.Size = new Size(66, 20);
            tb2ATAxis.TabIndex = 27;
            // 
            // cmOK
            // 
            _cmOK.Location = new Point(675, 8);
            _cmOK.Name = "_cmOK";
            _cmOK.Size = new Size(132, 36);
            _cmOK.TabIndex = 10;
            _cmOK.Text = "Save and Exit";
            _cmOK.UseVisualStyleBackColor = true;
            // 
            // cmGetAll
            // 
            _cmGetAll.Location = new Point(487, 37);
            _cmGetAll.Name = "_cmGetAll";
            _cmGetAll.Size = new Size(167, 27);
            _cmGetAll.TabIndex = 8;
            _cmGetAll.Text = "Get &ALL Approximates";
            ToolTip1.SetToolTip(_cmGetAll, "Automatically get player counts by navigation page count (40 per page).");
            _cmGetAll.UseVisualStyleBackColor = true;
            // 
            // cmCancel
            // 
            _cmCancel.Location = new Point(675, 49);
            _cmCancel.Name = "_cmCancel";
            _cmCancel.Size = new Size(132, 38);
            _cmCancel.TabIndex = 11;
            _cmCancel.Text = "&Cancel";
            _cmCancel.UseVisualStyleBackColor = true;
            // 
            // cmStopAll
            // 
            _cmStopAll.Location = new Point(487, 98);
            _cmStopAll.Name = "_cmStopAll";
            _cmStopAll.Size = new Size(167, 42);
            _cmStopAll.TabIndex = 9;
            _cmStopAll.Text = "&Stop Searching";
            _cmStopAll.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            lbStatus.BackColor = Color.Silver;
            lbStatus.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            lbStatus.Location = new Point(487, 67);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(167, 25);
            lbStatus.TabIndex = 45;
            lbStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmGetAllActual
            // 
            _cmGetAllActual.Location = new Point(487, 8);
            _cmGetAllActual.Name = "_cmGetAllActual";
            _cmGetAllActual.Size = new Size(167, 27);
            _cmGetAllActual.TabIndex = 7;
            _cmGetAllActual.Text = "Get &ALL Actual";
            ToolTip1.SetToolTip(_cmGetAllActual, "Automatically get actual player counts from each web page.");
            _cmGetAllActual.UseVisualStyleBackColor = true;
            // 
            // tbHelp
            // 
            tbHelp.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            tbHelp.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            tbHelp.Location = new Point(813, 8);
            tbHelp.Multiline = true;
            tbHelp.Name = "tbHelp";
            tbHelp.ScrollBars = ScrollBars.Vertical;
            tbHelp.Size = new Size(515, 131);
            tbHelp.TabIndex = 41;
            // 
            // Button2
            // 
            Button2.Location = new Point(343, 41);
            Button2.Name = "Button2";
            Button2.Size = new Size(62, 25);
            Button2.TabIndex = 47;
            Button2.Text = "Button2";
            Button2.UseVisualStyleBackColor = true;
            Button2.Visible = false;
            // 
            // frmMaxPlayerSearch
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            ClientSize = new Size(1340, 648);
            Controls.Add(Button2);
            Controls.Add(tbHelp);
            Controls.Add(_cmGetAllActual);
            Controls.Add(lbStatus);
            Controls.Add(_cmStopAll);
            Controls.Add(_cmCancel);
            Controls.Add(_cmGetAll);
            Controls.Add(_cmOK);
            Controls.Add(tb4ATAxis);
            Controls.Add(tb3ATAxis);
            Controls.Add(tb2ATAxis);
            Controls.Add(_cmATAxis);
            Controls.Add(tb4ATAllies);
            Controls.Add(tb3ATAllies);
            Controls.Add(tb2ATAllies);
            Controls.Add(_cmATallies);
            Controls.Add(Panel1);
            Controls.Add(tb4v4Okw);
            Controls.Add(tb4v4Ost);
            Controls.Add(tb4v4Brit);
            Controls.Add(tb4v4Usf);
            Controls.Add(tb4v4Sov);
            Controls.Add(tb3v3Okw);
            Controls.Add(tb3v3Ost);
            Controls.Add(tb3v3Brit);
            Controls.Add(tb3v3Usf);
            Controls.Add(tb3v3Sov);
            Controls.Add(tb2v2Okw);
            Controls.Add(tb2v2Ost);
            Controls.Add(tb2v2Brit);
            Controls.Add(tb2v2Usf);
            Controls.Add(tb2v2Sov);
            Controls.Add(tb1v1Okw);
            Controls.Add(tb1v1Ost);
            Controls.Add(tb1v1Brit);
            Controls.Add(_cm1v1Okw);
            Controls.Add(_cm1v1Ost);
            Controls.Add(_cm1v1Brit);
            Controls.Add(tb1v1Usf);
            Controls.Add(_cm1v1Usf);
            Controls.Add(tb1v1Sov);
            Controls.Add(_cm1v1Sov);
            Controls.Add(_Web1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMaxPlayerSearch";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MakoCELO - ELO Setup Dialog";
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            Load += new EventHandler(frmMaxPlayerSearch_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private WebBrowser _Web1;

        internal WebBrowser Web1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Web1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Web1 != null)
                {
                    _Web1.DocumentCompleted -= Web1_DocumentCompleted;
                }

                _Web1 = value;
                if (_Web1 != null)
                {
                    _Web1.DocumentCompleted += Web1_DocumentCompleted;
                }
            }
        }

        private Button _cm1v1Sov;

        internal Button cm1v1Sov
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cm1v1Sov;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cm1v1Sov != null)
                {
                    _cm1v1Sov.Click -= cm1v1Sov_Click;
                }

                _cm1v1Sov = value;
                if (_cm1v1Sov != null)
                {
                    _cm1v1Sov.Click += cm1v1Sov_Click;
                }
            }
        }

        internal TextBox tb1v1Sov;
        private Button _cm1v1Usf;

        internal Button cm1v1Usf
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cm1v1Usf;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cm1v1Usf != null)
                {
                    _cm1v1Usf.Click -= cm1v1Usf_Click;
                }

                _cm1v1Usf = value;
                if (_cm1v1Usf != null)
                {
                    _cm1v1Usf.Click += cm1v1Usf_Click;
                }
            }
        }

        internal TextBox tb1v1Usf;
        private Button _cm1v1Brit;

        internal Button cm1v1Brit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cm1v1Brit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cm1v1Brit != null)
                {
                    _cm1v1Brit.Click -= cm1v1Brit_Click;
                }

                _cm1v1Brit = value;
                if (_cm1v1Brit != null)
                {
                    _cm1v1Brit.Click += cm1v1Brit_Click;
                }
            }
        }

        private Button _cm1v1Ost;

        internal Button cm1v1Ost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cm1v1Ost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cm1v1Ost != null)
                {
                    _cm1v1Ost.Click -= cm1v1Ost_Click;
                }

                _cm1v1Ost = value;
                if (_cm1v1Ost != null)
                {
                    _cm1v1Ost.Click += cm1v1Ost_Click;
                }
            }
        }

        private Button _cm1v1Okw;

        internal Button cm1v1Okw
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cm1v1Okw;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cm1v1Okw != null)
                {
                    _cm1v1Okw.Click -= cm1v1Okw_Click;
                }

                _cm1v1Okw = value;
                if (_cm1v1Okw != null)
                {
                    _cm1v1Okw.Click += cm1v1Okw_Click;
                }
            }
        }

        internal TextBox tb1v1Brit;
        internal TextBox tb1v1Ost;
        internal TextBox tb1v1Okw;
        internal TextBox tb2v2Okw;
        internal TextBox tb2v2Ost;
        internal TextBox tb2v2Brit;
        internal TextBox tb2v2Usf;
        internal TextBox tb2v2Sov;
        internal TextBox tb3v3Okw;
        internal TextBox tb3v3Ost;
        internal TextBox tb3v3Brit;
        internal TextBox tb3v3Usf;
        internal TextBox tb3v3Sov;
        internal TextBox tb4v4Okw;
        internal TextBox tb4v4Ost;
        internal TextBox tb4v4Brit;
        internal TextBox tb4v4Usf;
        internal TextBox tb4v4Sov;
        internal Panel Panel1;
        internal RadioButton rb4v4;
        internal RadioButton rb3v3;
        internal RadioButton rb2v2;
        internal RadioButton rb1v1;
        private Button _cmATallies;

        internal Button cmATallies
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmATallies;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmATallies != null)
                {
                    _cmATallies.Click -= cmATallies_Click;
                }

                _cmATallies = value;
                if (_cmATallies != null)
                {
                    _cmATallies.Click += cmATallies_Click;
                }
            }
        }

        internal TextBox tb2ATAllies;
        internal TextBox tb3ATAllies;
        internal TextBox tb4ATAllies;
        private Button _cmATAxis;

        internal Button cmATAxis
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmATAxis;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmATAxis != null)
                {
                    _cmATAxis.Click -= cmATAxis_Click;
                }

                _cmATAxis = value;
                if (_cmATAxis != null)
                {
                    _cmATAxis.Click += cmATAxis_Click;
                }
            }
        }

        internal TextBox tb4ATAxis;
        internal TextBox tb3ATAxis;
        internal TextBox tb2ATAxis;
        private Button _cmOK;

        internal Button cmOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmOK != null)
                {
                    _cmOK.Click -= cmOK_Click;
                }

                _cmOK = value;
                if (_cmOK != null)
                {
                    _cmOK.Click += cmOK_Click;
                }
            }
        }

        private Button _cmGetAll;

        internal Button cmGetAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmGetAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmGetAll != null)
                {
                    _cmGetAll.Click -= cmGetAll_Click;
                }

                _cmGetAll = value;
                if (_cmGetAll != null)
                {
                    _cmGetAll.Click += cmGetAll_Click;
                }
            }
        }

        private Button _cmCancel;

        internal Button cmCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCancel != null)
                {
                    _cmCancel.Click -= cmCancel_Click;
                }

                _cmCancel = value;
                if (_cmCancel != null)
                {
                    _cmCancel.Click += cmCancel_Click;
                }
            }
        }

        private Button _cmStopAll;

        internal Button cmStopAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmStopAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmStopAll != null)
                {
                    _cmStopAll.Click -= cmStopAll_Click;
                }

                _cmStopAll = value;
                if (_cmStopAll != null)
                {
                    _cmStopAll.Click += cmStopAll_Click;
                }
            }
        }

        internal Label lbStatus;
        private Button _cmGetAllActual;

        internal Button cmGetAllActual
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmGetAllActual;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmGetAllActual != null)
                {
                    _cmGetAllActual.Click -= cmGetAllActual_Click;
                }

                _cmGetAllActual = value;
                if (_cmGetAllActual != null)
                {
                    _cmGetAllActual.Click += cmGetAllActual_Click;
                }
            }
        }

        internal ToolTip ToolTip1;
        internal TextBox tbHelp;
        internal Button Button2;
    }
}