using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
    [DesignerGenerated()]
    public partial class frmMain : Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this._cmCheckLog = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pbFact01 = new System.Windows.Forms.PictureBox();
            this.pbFact02 = new System.Windows.Forms.PictureBox();
            this.pbFact03 = new System.Windows.Forms.PictureBox();
            this.pbFact04 = new System.Windows.Forms.PictureBox();
            this.pbFact05 = new System.Windows.Forms.PictureBox();
            this.lbSteam01 = new System.Windows.Forms.Label();
            this.lbSteam02 = new System.Windows.Forms.Label();
            this.lbSteam03 = new System.Windows.Forms.Label();
            this.lbSteam04 = new System.Windows.Forms.Label();
            this.lbSteam05 = new System.Windows.Forms.Label();
            this.lbSteam06 = new System.Windows.Forms.Label();
            this.lbSteam07 = new System.Windows.Forms.Label();
            this.lbSteam08 = new System.Windows.Forms.Label();
            this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._Timer1 = new System.Windows.Forms.Timer(this.components);
            this._cmFindLog = new System.Windows.Forms.Button();
            this._cmScanLog = new System.Windows.Forms.Button();
            this._cmCopy = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.FontDialog1 = new System.Windows.Forms.FontDialog();
            this._cmAbout = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this._cboLayoutY = new System.Windows.Forms.ComboBox();
            this.gbRank = new System.Windows.Forms.GroupBox();
            this._cmELO = new System.Windows.Forms.Button();
            this._cmSetupSave = new System.Windows.Forms.Button();
            this._cmSetupLoad = new System.Windows.Forms.Button();
            this._cmNote_PlayAll = new System.Windows.Forms.Button();
            this._cmNote04_Play = new System.Windows.Forms.Button();
            this._cmNote03_Play = new System.Windows.Forms.Button();
            this._cmNote02_Play = new System.Windows.Forms.Button();
            this._cmNote01_Play = new System.Windows.Forms.Button();
            this._cmNote4 = new System.Windows.Forms.Button();
            this._cmNote04Setup = new System.Windows.Forms.Button();
            this.Label14 = new System.Windows.Forms.Label();
            this._cmNote3 = new System.Windows.Forms.Button();
            this._cmNote2 = new System.Windows.Forms.Button();
            this._cmNote1 = new System.Windows.Forms.Button();
            this._cmNote03Setup = new System.Windows.Forms.Button();
            this._cmNote02Setup = new System.Windows.Forms.Button();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this._cmNote01Setup = new System.Windows.Forms.Button();
            this.Label11 = new System.Windows.Forms.Label();
            this._cmNameSetup = new System.Windows.Forms.Button();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this._cmRankSetup = new System.Windows.Forms.Button();
            this._cmSave = new System.Windows.Forms.Button();
            this.gbLayout = new System.Windows.Forms.GroupBox();
            this._cmStatsModeHelp = new System.Windows.Forms.Button();
            this._cmDefaults = new System.Windows.Forms.Button();
            this._tbYSize = new System.Windows.Forms.TextBox();
            this._tbXsize = new System.Windows.Forms.TextBox();
            this._tbYoff = new System.Windows.Forms.TextBox();
            this._tbXoff = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this._cboNoteSpace = new System.Windows.Forms.ComboBox();
            this._chkGUIMode = new System.Windows.Forms.CheckBox();
            this.Label5 = new System.Windows.Forms.Label();
            this._cmSizeRefresh = new System.Windows.Forms.Button();
            this._cboLayoutX = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this._pbStats = new System.Windows.Forms.PictureBox();
            this._cmTestData = new System.Windows.Forms.Button();
            this._cmLastMatch = new System.Windows.Forms.Button();
            this.gbFX = new System.Windows.Forms.GroupBox();
            this.cmRID = new System.Windows.Forms.Button();
            this._chkFX = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this._cmFXModeHelp = new System.Windows.Forms.Button();
            this._cboFXVar1 = new System.Windows.Forms.ComboBox();
            this.lbFXVar1 = new System.Windows.Forms.Label();
            this._cboFxVar3 = new System.Windows.Forms.ComboBox();
            this.lbFXVar3 = new System.Windows.Forms.Label();
            this._cboFxVar4 = new System.Windows.Forms.ComboBox();
            this._cmFX3DC = new System.Windows.Forms.Button();
            this._cboFXVar2 = new System.Windows.Forms.ComboBox();
            this.lbFXVar2 = new System.Windows.Forms.Label();
            this.lbFXVar4 = new System.Windows.Forms.Label();
            this._chkMismatch = new System.Windows.Forms.CheckBox();
            this.lbError1 = new System.Windows.Forms.Label();
            this.lbError2 = new System.Windows.Forms.Label();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._chkTips = new System.Windows.Forms.CheckBox();
            this.pbNote1 = new System.Windows.Forms.PictureBox();
            this._timNote1 = new System.Windows.Forms.Timer(this.components);
            this.gbSound = new System.Windows.Forms.GroupBox();
            this._cmAudioStop = new System.Windows.Forms.Button();
            this.lbVolume = new System.Windows.Forms.Label();
            this._scrVolume = new System.Windows.Forms.HScrollBar();
            this._cmSound15 = new System.Windows.Forms.Button();
            this._cmSound14 = new System.Windows.Forms.Button();
            this._cmSound13 = new System.Windows.Forms.Button();
            this._cmSound12 = new System.Windows.Forms.Button();
            this._cmSound11 = new System.Windows.Forms.Button();
            this.lbSoundCurrent = new System.Windows.Forms.Label();
            this._cmSound10 = new System.Windows.Forms.Button();
            this._cmSound09 = new System.Windows.Forms.Button();
            this._cmSound08 = new System.Windows.Forms.Button();
            this._cmSound07 = new System.Windows.Forms.Button();
            this._cmSound06 = new System.Windows.Forms.Button();
            this._cmSound05 = new System.Windows.Forms.Button();
            this._cmSound04 = new System.Windows.Forms.Button();
            this._cmSound03 = new System.Windows.Forms.Button();
            this._cmSound02 = new System.Windows.Forms.Button();
            this._cmSound01 = new System.Windows.Forms.Button();
            this.pbNote3 = new System.Windows.Forms.PictureBox();
            this.pbNote4 = new System.Windows.Forms.PictureBox();
            this.pbNote2 = new System.Windows.Forms.PictureBox();
            this.chkPosition = new System.Windows.Forms.CheckBox();
            this.tsmPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsmPlayer_Relic = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmPlayer_OrgAT = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmPlayer_OrgFaction = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmPlayer_OrgPlayercard = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmPlayer_Google = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmPlayer_Steam = new System.Windows.Forms.ToolStripMenuItem();
            this._chkPopUp = new System.Windows.Forms.CheckBox();
            this.tsmAudio = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsmSetVolTo100 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSetVolTo90 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSetVolTo80 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSetVolTo70 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSetVolTo60 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSetVolTo50 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSetVolTo40 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSetVolTo30 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSetVolTo20 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSetVolTo10 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._tsmSelectFile = new System.Windows.Forms.ToolStripMenuItem();
            this._chkSmoothAni = new System.Windows.Forms.CheckBox();
            this._chkFoundSound = new System.Windows.Forms.CheckBox();
            this.lbTime = new System.Windows.Forms.Label();
            this._cboDelay = new System.Windows.Forms.ComboBox();
            this._chkHideMissing = new System.Windows.Forms.CheckBox();
            this._chkShowELO = new System.Windows.Forms.CheckBox();
            this._timELOCycle = new System.Windows.Forms.Timer(this.components);
            this._scrStats = new System.Windows.Forms.VScrollBar();
            this._chkSpeech = new System.Windows.Forms.CheckBox();
            this._chkGetTeams = new System.Windows.Forms.CheckBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this._cmErrLog = new System.Windows.Forms.Button();
            this._chkCountry = new System.Windows.Forms.CheckBox();
            this.SS1 = new System.Windows.Forms.StatusStrip();
            this.SS1_Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.SS1_Sep1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SS1_Filename = new System.Windows.Forms.ToolStripStatusLabel();
            this.SS1_Sep2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SS1_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.SS1_Sep3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this._chkToggleOverlay = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFact01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFact02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFact03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFact04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFact05)).BeginInit();
            this.gbRank.SuspendLayout();
            this.gbLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbStats)).BeginInit();
            this.gbFX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote1)).BeginInit();
            this.gbSound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote2)).BeginInit();
            this.tsmPlayer.SuspendLayout();
            this.tsmAudio.SuspendLayout();
            this.SS1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cmCheckLog
            // 
            this._cmCheckLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmCheckLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmCheckLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmCheckLog.ForeColor = System.Drawing.Color.Black;
            this._cmCheckLog.Location = new System.Drawing.Point(10, 35);
            this._cmCheckLog.Name = "_cmCheckLog";
            this._cmCheckLog.Size = new System.Drawing.Size(111, 30);
            this._cmCheckLog.TabIndex = 1;
            this._cmCheckLog.Text = "Check Log File";
            this._cmCheckLog.UseVisualStyleBackColor = false;
            this._cmCheckLog.Click += new System.EventHandler(this.cmCheckLog_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.Color.Silver;
            this.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.Black;
            this.lbStatus.Location = new System.Drawing.Point(880, 15);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(235, 25);
            this.lbStatus.TabIndex = 25;
            this.lbStatus.Text = "Ready.";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbFact01
            // 
            this.pbFact01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbFact01.Image = ((System.Drawing.Image)(resources.GetObject("pbFact01.Image")));
            this.pbFact01.Location = new System.Drawing.Point(1378, 192);
            this.pbFact01.Name = "pbFact01";
            this.pbFact01.Size = new System.Drawing.Size(95, 95);
            this.pbFact01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFact01.TabIndex = 26;
            this.pbFact01.TabStop = false;
            this.pbFact01.Visible = false;
            // 
            // pbFact02
            // 
            this.pbFact02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbFact02.Image = ((System.Drawing.Image)(resources.GetObject("pbFact02.Image")));
            this.pbFact02.Location = new System.Drawing.Point(1296, 192);
            this.pbFact02.Name = "pbFact02";
            this.pbFact02.Size = new System.Drawing.Size(95, 95);
            this.pbFact02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFact02.TabIndex = 27;
            this.pbFact02.TabStop = false;
            this.pbFact02.Visible = false;
            // 
            // pbFact03
            // 
            this.pbFact03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbFact03.Image = ((System.Drawing.Image)(resources.GetObject("pbFact03.Image")));
            this.pbFact03.Location = new System.Drawing.Point(1378, 279);
            this.pbFact03.Name = "pbFact03";
            this.pbFact03.Size = new System.Drawing.Size(95, 95);
            this.pbFact03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFact03.TabIndex = 28;
            this.pbFact03.TabStop = false;
            this.pbFact03.Visible = false;
            // 
            // pbFact04
            // 
            this.pbFact04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbFact04.Image = ((System.Drawing.Image)(resources.GetObject("pbFact04.Image")));
            this.pbFact04.Location = new System.Drawing.Point(1460, 279);
            this.pbFact04.Name = "pbFact04";
            this.pbFact04.Size = new System.Drawing.Size(95, 95);
            this.pbFact04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFact04.TabIndex = 29;
            this.pbFact04.TabStop = false;
            this.pbFact04.Visible = false;
            // 
            // pbFact05
            // 
            this.pbFact05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbFact05.Image = ((System.Drawing.Image)(resources.GetObject("pbFact05.Image")));
            this.pbFact05.Location = new System.Drawing.Point(1296, 279);
            this.pbFact05.Name = "pbFact05";
            this.pbFact05.Size = new System.Drawing.Size(95, 95);
            this.pbFact05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFact05.TabIndex = 30;
            this.pbFact05.TabStop = false;
            this.pbFact05.Visible = false;
            // 
            // lbSteam01
            // 
            this.lbSteam01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSteam01.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteam01.Location = new System.Drawing.Point(1465, 200);
            this.lbSteam01.Name = "lbSteam01";
            this.lbSteam01.Size = new System.Drawing.Size(50, 23);
            this.lbSteam01.TabIndex = 39;
            this.lbSteam01.Visible = false;
            // 
            // lbSteam02
            // 
            this.lbSteam02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSteam02.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteam02.Location = new System.Drawing.Point(1465, 223);
            this.lbSteam02.Name = "lbSteam02";
            this.lbSteam02.Size = new System.Drawing.Size(50, 23);
            this.lbSteam02.TabIndex = 40;
            this.lbSteam02.Visible = false;
            // 
            // lbSteam03
            // 
            this.lbSteam03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSteam03.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteam03.Location = new System.Drawing.Point(1465, 246);
            this.lbSteam03.Name = "lbSteam03";
            this.lbSteam03.Size = new System.Drawing.Size(50, 23);
            this.lbSteam03.TabIndex = 41;
            this.lbSteam03.Visible = false;
            // 
            // lbSteam04
            // 
            this.lbSteam04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSteam04.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteam04.Location = new System.Drawing.Point(1465, 269);
            this.lbSteam04.Name = "lbSteam04";
            this.lbSteam04.Size = new System.Drawing.Size(50, 23);
            this.lbSteam04.TabIndex = 42;
            this.lbSteam04.Visible = false;
            // 
            // lbSteam05
            // 
            this.lbSteam05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSteam05.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteam05.Location = new System.Drawing.Point(1519, 200);
            this.lbSteam05.Name = "lbSteam05";
            this.lbSteam05.Size = new System.Drawing.Size(50, 23);
            this.lbSteam05.TabIndex = 43;
            this.lbSteam05.Visible = false;
            // 
            // lbSteam06
            // 
            this.lbSteam06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSteam06.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteam06.Location = new System.Drawing.Point(1519, 223);
            this.lbSteam06.Name = "lbSteam06";
            this.lbSteam06.Size = new System.Drawing.Size(50, 23);
            this.lbSteam06.TabIndex = 44;
            this.lbSteam06.Visible = false;
            // 
            // lbSteam07
            // 
            this.lbSteam07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSteam07.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteam07.Location = new System.Drawing.Point(1519, 246);
            this.lbSteam07.Name = "lbSteam07";
            this.lbSteam07.Size = new System.Drawing.Size(50, 23);
            this.lbSteam07.TabIndex = 45;
            this.lbSteam07.Visible = false;
            // 
            // lbSteam08
            // 
            this.lbSteam08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSteam08.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteam08.Location = new System.Drawing.Point(1519, 269);
            this.lbSteam08.Name = "lbSteam08";
            this.lbSteam08.Size = new System.Drawing.Size(50, 23);
            this.lbSteam08.TabIndex = 46;
            this.lbSteam08.Visible = false;
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // _Timer1
            // 
            this._Timer1.Interval = 1000;
            this._Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // _cmFindLog
            // 
            this._cmFindLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmFindLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmFindLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmFindLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmFindLog.ForeColor = System.Drawing.Color.Black;
            this._cmFindLog.Location = new System.Drawing.Point(10, 6);
            this._cmFindLog.Name = "_cmFindLog";
            this._cmFindLog.Size = new System.Drawing.Size(111, 26);
            this._cmFindLog.TabIndex = 0;
            this._cmFindLog.Text = "Find Log File";
            this._cmFindLog.UseVisualStyleBackColor = false;
            this._cmFindLog.Click += new System.EventHandler(this.cmFindLog_Click);
            // 
            // _cmScanLog
            // 
            this._cmScanLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmScanLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmScanLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmScanLog.ForeColor = System.Drawing.Color.Black;
            this._cmScanLog.Location = new System.Drawing.Point(10, 115);
            this._cmScanLog.Name = "_cmScanLog";
            this._cmScanLog.Size = new System.Drawing.Size(111, 46);
            this._cmScanLog.TabIndex = 2;
            this._cmScanLog.Text = "Auto Scan Log";
            this._cmScanLog.UseVisualStyleBackColor = false;
            this._cmScanLog.Click += new System.EventHandler(this.cmScanLog_Click);
            // 
            // _cmCopy
            // 
            this._cmCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmCopy.ForeColor = System.Drawing.Color.Black;
            this._cmCopy.Location = new System.Drawing.Point(880, 120);
            this._cmCopy.Name = "_cmCopy";
            this._cmCopy.Size = new System.Drawing.Size(105, 23);
            this._cmCopy.TabIndex = 6;
            this._cmCopy.Text = "Copy Stats Image";
            this._cmCopy.UseVisualStyleBackColor = false;
            this._cmCopy.Click += new System.EventHandler(this.cmCopy_Click);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(880, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(235, 13);
            this.Label2.TabIndex = 61;
            this.Label2.Text = "Scan Status";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _cmAbout
            // 
            this._cmAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmAbout.ForeColor = System.Drawing.Color.Black;
            this._cmAbout.Location = new System.Drawing.Point(880, 45);
            this._cmAbout.Name = "_cmAbout";
            this._cmAbout.Size = new System.Drawing.Size(105, 23);
            this._cmAbout.TabIndex = 3;
            this._cmAbout.Text = "About";
            this._cmAbout.UseVisualStyleBackColor = false;
            this._cmAbout.Click += new System.EventHandler(this.cmAbout_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label3.Location = new System.Drawing.Point(5, 20);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(44, 13);
            this.Label3.TabIndex = 66;
            this.Label3.Text = "XY Size";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label4.Location = new System.Drawing.Point(5, 95);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(49, 13);
            this.Label4.TabIndex = 70;
            this.Label4.Text = "Y Layout";
            // 
            // _cboLayoutY
            // 
            this._cboLayoutY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._cboLayoutY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLayoutY.ForeColor = System.Drawing.Color.White;
            this._cboLayoutY.FormattingEnabled = true;
            this._cboLayoutY.Location = new System.Drawing.Point(60, 90);
            this._cboLayoutY.Name = "_cboLayoutY";
            this._cboLayoutY.Size = new System.Drawing.Size(126, 21);
            this._cboLayoutY.TabIndex = 23;
            this._cboLayoutY.SelectedIndexChanged += new System.EventHandler(this.cboLayoutY_SelectedIndexChanged);
            // 
            // gbRank
            // 
            this.gbRank.Controls.Add(this._cmELO);
            this.gbRank.Controls.Add(this._cmSetupSave);
            this.gbRank.Controls.Add(this._cmSetupLoad);
            this.gbRank.Controls.Add(this._cmNote_PlayAll);
            this.gbRank.Controls.Add(this._cmNote04_Play);
            this.gbRank.Controls.Add(this._cmNote03_Play);
            this.gbRank.Controls.Add(this._cmNote02_Play);
            this.gbRank.Controls.Add(this._cmNote01_Play);
            this.gbRank.Controls.Add(this._cmNote4);
            this.gbRank.Controls.Add(this._cmNote04Setup);
            this.gbRank.Controls.Add(this.Label14);
            this.gbRank.Controls.Add(this._cmNote3);
            this.gbRank.Controls.Add(this._cmNote2);
            this.gbRank.Controls.Add(this._cmNote1);
            this.gbRank.Controls.Add(this._cmNote03Setup);
            this.gbRank.Controls.Add(this._cmNote02Setup);
            this.gbRank.Controls.Add(this.Label13);
            this.gbRank.Controls.Add(this.Label12);
            this.gbRank.Controls.Add(this._cmNote01Setup);
            this.gbRank.Controls.Add(this.Label11);
            this.gbRank.Controls.Add(this._cmNameSetup);
            this.gbRank.Controls.Add(this.Label10);
            this.gbRank.Controls.Add(this.Label9);
            this.gbRank.Controls.Add(this._cmRankSetup);
            this.gbRank.ForeColor = System.Drawing.Color.Black;
            this.gbRank.Location = new System.Drawing.Point(130, 0);
            this.gbRank.Name = "gbRank";
            this.gbRank.Size = new System.Drawing.Size(198, 195);
            this.gbRank.TabIndex = 73;
            this.gbRank.TabStop = false;
            this.gbRank.Text = "Stats and Note Setups";
            // 
            // _cmELO
            // 
            this._cmELO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmELO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmELO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmELO.ForeColor = System.Drawing.Color.Black;
            this._cmELO.Location = new System.Drawing.Point(100, 15);
            this._cmELO.Name = "_cmELO";
            this._cmELO.Size = new System.Drawing.Size(50, 23);
            this._cmELO.TabIndex = 94;
            this._cmELO.Text = "ELO";
            this._cmELO.UseVisualStyleBackColor = false;
            this._cmELO.Click += new System.EventHandler(this.cmTest_Click);
            // 
            // _cmSetupSave
            // 
            this._cmSetupSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSetupSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSetupSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSetupSave.ForeColor = System.Drawing.Color.Black;
            this._cmSetupSave.Location = new System.Drawing.Point(100, 165);
            this._cmSetupSave.Name = "_cmSetupSave";
            this._cmSetupSave.Size = new System.Drawing.Size(85, 23);
            this._cmSetupSave.TabIndex = 125;
            this._cmSetupSave.Text = "Save Setup";
            this._cmSetupSave.UseVisualStyleBackColor = false;
            this._cmSetupSave.Click += new System.EventHandler(this.cmSetupSave_Click);
            // 
            // _cmSetupLoad
            // 
            this._cmSetupLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSetupLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSetupLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSetupLoad.ForeColor = System.Drawing.Color.Black;
            this._cmSetupLoad.Location = new System.Drawing.Point(5, 165);
            this._cmSetupLoad.Name = "_cmSetupLoad";
            this._cmSetupLoad.Size = new System.Drawing.Size(90, 23);
            this._cmSetupLoad.TabIndex = 124;
            this._cmSetupLoad.Text = "Load Setup";
            this._cmSetupLoad.UseVisualStyleBackColor = false;
            this._cmSetupLoad.Click += new System.EventHandler(this.cmSetupLoad_Click);
            // 
            // _cmNote_PlayAll
            // 
            this._cmNote_PlayAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote_PlayAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote_PlayAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote_PlayAll.ForeColor = System.Drawing.Color.Black;
            this._cmNote_PlayAll.Location = new System.Drawing.Point(155, 40);
            this._cmNote_PlayAll.Name = "_cmNote_PlayAll";
            this._cmNote_PlayAll.Size = new System.Drawing.Size(30, 23);
            this._cmNote_PlayAll.TabIndex = 10;
            this._cmNote_PlayAll.Text = ">";
            this._cmNote_PlayAll.UseVisualStyleBackColor = false;
            this._cmNote_PlayAll.Click += new System.EventHandler(this.cmNote_PlayAll_Click);
            // 
            // _cmNote04_Play
            // 
            this._cmNote04_Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote04_Play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote04_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote04_Play.ForeColor = System.Drawing.Color.Black;
            this._cmNote04_Play.Location = new System.Drawing.Point(155, 140);
            this._cmNote04_Play.Name = "_cmNote04_Play";
            this._cmNote04_Play.Size = new System.Drawing.Size(30, 23);
            this._cmNote04_Play.TabIndex = 14;
            this._cmNote04_Play.Text = ">";
            this._cmNote04_Play.UseVisualStyleBackColor = false;
            this._cmNote04_Play.Click += new System.EventHandler(this.cmNote04_Play_Click);
            // 
            // _cmNote03_Play
            // 
            this._cmNote03_Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote03_Play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote03_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote03_Play.ForeColor = System.Drawing.Color.Black;
            this._cmNote03_Play.Location = new System.Drawing.Point(155, 115);
            this._cmNote03_Play.Name = "_cmNote03_Play";
            this._cmNote03_Play.Size = new System.Drawing.Size(30, 23);
            this._cmNote03_Play.TabIndex = 13;
            this._cmNote03_Play.Text = ">";
            this._cmNote03_Play.UseVisualStyleBackColor = false;
            this._cmNote03_Play.Click += new System.EventHandler(this.cmNote03_Play_Click);
            // 
            // _cmNote02_Play
            // 
            this._cmNote02_Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote02_Play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote02_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote02_Play.ForeColor = System.Drawing.Color.Black;
            this._cmNote02_Play.Location = new System.Drawing.Point(155, 90);
            this._cmNote02_Play.Name = "_cmNote02_Play";
            this._cmNote02_Play.Size = new System.Drawing.Size(30, 23);
            this._cmNote02_Play.TabIndex = 12;
            this._cmNote02_Play.Text = ">";
            this._cmNote02_Play.UseVisualStyleBackColor = false;
            this._cmNote02_Play.Click += new System.EventHandler(this.cmNote02_Play_Click);
            // 
            // _cmNote01_Play
            // 
            this._cmNote01_Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote01_Play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote01_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote01_Play.ForeColor = System.Drawing.Color.Black;
            this._cmNote01_Play.Location = new System.Drawing.Point(155, 65);
            this._cmNote01_Play.Name = "_cmNote01_Play";
            this._cmNote01_Play.Size = new System.Drawing.Size(30, 23);
            this._cmNote01_Play.TabIndex = 11;
            this._cmNote01_Play.Text = ">";
            this._cmNote01_Play.UseVisualStyleBackColor = false;
            this._cmNote01_Play.Click += new System.EventHandler(this.cmNote01_Play_Click);
            // 
            // _cmNote4
            // 
            this._cmNote4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote4.ForeColor = System.Drawing.Color.Black;
            this._cmNote4.Location = new System.Drawing.Point(100, 140);
            this._cmNote4.Name = "_cmNote4";
            this._cmNote4.Size = new System.Drawing.Size(50, 23);
            this._cmNote4.TabIndex = 9;
            this._cmNote4.Text = "Notes";
            this._cmNote4.UseVisualStyleBackColor = false;
            this._cmNote4.Click += new System.EventHandler(this.cmNote4_Click);
            // 
            // _cmNote04Setup
            // 
            this._cmNote04Setup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote04Setup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote04Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote04Setup.ForeColor = System.Drawing.Color.Black;
            this._cmNote04Setup.Location = new System.Drawing.Point(45, 140);
            this._cmNote04Setup.Name = "_cmNote04Setup";
            this._cmNote04Setup.Size = new System.Drawing.Size(50, 23);
            this._cmNote04Setup.TabIndex = 8;
            this._cmNote04Setup.Text = "Setup";
            this._cmNote04Setup.UseVisualStyleBackColor = false;
            this._cmNote04Setup.Click += new System.EventHandler(this.cmNote04Setup_Click_1);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label14.Location = new System.Drawing.Point(5, 145);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(39, 13);
            this.Label14.TabIndex = 123;
            this.Label14.Text = "Note 4";
            // 
            // _cmNote3
            // 
            this._cmNote3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote3.ForeColor = System.Drawing.Color.Black;
            this._cmNote3.Location = new System.Drawing.Point(100, 115);
            this._cmNote3.Name = "_cmNote3";
            this._cmNote3.Size = new System.Drawing.Size(50, 23);
            this._cmNote3.TabIndex = 7;
            this._cmNote3.Text = "Notes";
            this._cmNote3.UseVisualStyleBackColor = false;
            this._cmNote3.Click += new System.EventHandler(this.cmNote3_Click);
            // 
            // _cmNote2
            // 
            this._cmNote2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote2.ForeColor = System.Drawing.Color.Black;
            this._cmNote2.Location = new System.Drawing.Point(100, 90);
            this._cmNote2.Name = "_cmNote2";
            this._cmNote2.Size = new System.Drawing.Size(50, 23);
            this._cmNote2.TabIndex = 5;
            this._cmNote2.Text = "Notes";
            this._cmNote2.UseVisualStyleBackColor = false;
            this._cmNote2.Click += new System.EventHandler(this.cmNote2_Click);
            // 
            // _cmNote1
            // 
            this._cmNote1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote1.ForeColor = System.Drawing.Color.Black;
            this._cmNote1.Location = new System.Drawing.Point(100, 65);
            this._cmNote1.Name = "_cmNote1";
            this._cmNote1.Size = new System.Drawing.Size(50, 23);
            this._cmNote1.TabIndex = 3;
            this._cmNote1.Text = "Notes";
            this._cmNote1.UseVisualStyleBackColor = false;
            this._cmNote1.Click += new System.EventHandler(this.cmNote1_Click);
            // 
            // _cmNote03Setup
            // 
            this._cmNote03Setup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote03Setup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote03Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote03Setup.ForeColor = System.Drawing.Color.Black;
            this._cmNote03Setup.Location = new System.Drawing.Point(45, 115);
            this._cmNote03Setup.Name = "_cmNote03Setup";
            this._cmNote03Setup.Size = new System.Drawing.Size(50, 23);
            this._cmNote03Setup.TabIndex = 6;
            this._cmNote03Setup.Text = "Setup";
            this._cmNote03Setup.UseVisualStyleBackColor = false;
            this._cmNote03Setup.Click += new System.EventHandler(this.cmNote03Setup_Click_1);
            // 
            // _cmNote02Setup
            // 
            this._cmNote02Setup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote02Setup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote02Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote02Setup.ForeColor = System.Drawing.Color.Black;
            this._cmNote02Setup.Location = new System.Drawing.Point(45, 90);
            this._cmNote02Setup.Name = "_cmNote02Setup";
            this._cmNote02Setup.Size = new System.Drawing.Size(50, 23);
            this._cmNote02Setup.TabIndex = 4;
            this._cmNote02Setup.Text = "Setup";
            this._cmNote02Setup.UseVisualStyleBackColor = false;
            this._cmNote02Setup.Click += new System.EventHandler(this.cmNote02Setup_Click_1);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label13.Location = new System.Drawing.Point(5, 120);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(39, 13);
            this.Label13.TabIndex = 117;
            this.Label13.Text = "Note 3";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label12.Location = new System.Drawing.Point(5, 95);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(39, 13);
            this.Label12.TabIndex = 116;
            this.Label12.Text = "Note 2";
            // 
            // _cmNote01Setup
            // 
            this._cmNote01Setup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNote01Setup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNote01Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNote01Setup.ForeColor = System.Drawing.Color.Black;
            this._cmNote01Setup.Location = new System.Drawing.Point(45, 65);
            this._cmNote01Setup.Name = "_cmNote01Setup";
            this._cmNote01Setup.Size = new System.Drawing.Size(50, 23);
            this._cmNote01Setup.TabIndex = 2;
            this._cmNote01Setup.Text = "Setup";
            this._cmNote01Setup.UseVisualStyleBackColor = false;
            this._cmNote01Setup.Click += new System.EventHandler(this.cmNote01Setup_Click_1);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label11.Location = new System.Drawing.Point(5, 70);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(39, 13);
            this.Label11.TabIndex = 114;
            this.Label11.Text = "Note 1";
            // 
            // _cmNameSetup
            // 
            this._cmNameSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmNameSetup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmNameSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmNameSetup.ForeColor = System.Drawing.Color.Black;
            this._cmNameSetup.Location = new System.Drawing.Point(45, 40);
            this._cmNameSetup.Name = "_cmNameSetup";
            this._cmNameSetup.Size = new System.Drawing.Size(50, 23);
            this._cmNameSetup.TabIndex = 1;
            this._cmNameSetup.Text = "Setup";
            this._cmNameSetup.UseVisualStyleBackColor = false;
            this._cmNameSetup.Click += new System.EventHandler(this.cmNameSetup_Click);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label10.Location = new System.Drawing.Point(5, 45);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(35, 13);
            this.Label10.TabIndex = 111;
            this.Label10.Text = "Name";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label9.Location = new System.Drawing.Point(5, 20);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(33, 13);
            this.Label9.TabIndex = 110;
            this.Label9.Text = "Rank";
            // 
            // _cmRankSetup
            // 
            this._cmRankSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmRankSetup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmRankSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmRankSetup.ForeColor = System.Drawing.Color.Black;
            this._cmRankSetup.Location = new System.Drawing.Point(45, 15);
            this._cmRankSetup.Name = "_cmRankSetup";
            this._cmRankSetup.Size = new System.Drawing.Size(50, 23);
            this._cmRankSetup.TabIndex = 0;
            this._cmRankSetup.Text = "Setup";
            this._cmRankSetup.UseVisualStyleBackColor = false;
            this._cmRankSetup.Click += new System.EventHandler(this.cmRankSetup_Click);
            // 
            // _cmSave
            // 
            this._cmSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSave.ForeColor = System.Drawing.Color.Black;
            this._cmSave.Location = new System.Drawing.Point(880, 145);
            this._cmSave.Name = "_cmSave";
            this._cmSave.Size = new System.Drawing.Size(105, 23);
            this._cmSave.TabIndex = 7;
            this._cmSave.Text = "Save Stats Image";
            this._cmSave.UseVisualStyleBackColor = false;
            this._cmSave.Click += new System.EventHandler(this.cmSave_Click);
            // 
            // gbLayout
            // 
            this.gbLayout.Controls.Add(this._cmStatsModeHelp);
            this.gbLayout.Controls.Add(this._cmDefaults);
            this.gbLayout.Controls.Add(this._tbYSize);
            this.gbLayout.Controls.Add(this._tbXsize);
            this.gbLayout.Controls.Add(this._tbYoff);
            this.gbLayout.Controls.Add(this._tbXoff);
            this.gbLayout.Controls.Add(this.Label7);
            this.gbLayout.Controls.Add(this._cboNoteSpace);
            this.gbLayout.Controls.Add(this._chkGUIMode);
            this.gbLayout.Controls.Add(this.Label5);
            this.gbLayout.Controls.Add(this._cmSizeRefresh);
            this.gbLayout.Controls.Add(this._cboLayoutX);
            this.gbLayout.Controls.Add(this.Label3);
            this.gbLayout.Controls.Add(this.Label6);
            this.gbLayout.Controls.Add(this._cboLayoutY);
            this.gbLayout.Controls.Add(this.Label4);
            this.gbLayout.Location = new System.Drawing.Point(335, 0);
            this.gbLayout.Name = "gbLayout";
            this.gbLayout.Size = new System.Drawing.Size(194, 195);
            this.gbLayout.TabIndex = 76;
            this.gbLayout.TabStop = false;
            this.gbLayout.Text = "Stats Layout";
            // 
            // _cmStatsModeHelp
            // 
            this._cmStatsModeHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmStatsModeHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmStatsModeHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmStatsModeHelp.ForeColor = System.Drawing.Color.Black;
            this._cmStatsModeHelp.Location = new System.Drawing.Point(67, 165);
            this._cmStatsModeHelp.Name = "_cmStatsModeHelp";
            this._cmStatsModeHelp.Size = new System.Drawing.Size(56, 23);
            this._cmStatsModeHelp.TabIndex = 26;
            this._cmStatsModeHelp.Text = "Help";
            this._cmStatsModeHelp.UseVisualStyleBackColor = false;
            this._cmStatsModeHelp.Click += new System.EventHandler(this.cmStatsModeHelp_Click);
            // 
            // _cmDefaults
            // 
            this._cmDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmDefaults.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmDefaults.ForeColor = System.Drawing.Color.Black;
            this._cmDefaults.Location = new System.Drawing.Point(7, 165);
            this._cmDefaults.Name = "_cmDefaults";
            this._cmDefaults.Size = new System.Drawing.Size(58, 23);
            this._cmDefaults.TabIndex = 25;
            this._cmDefaults.Text = "Defaults";
            this._cmDefaults.UseVisualStyleBackColor = false;
            this._cmDefaults.Click += new System.EventHandler(this.cmDefaults_Click);
            // 
            // _tbYSize
            // 
            this._tbYSize.Location = new System.Drawing.Point(126, 15);
            this._tbYSize.Name = "_tbYSize";
            this._tbYSize.Size = new System.Drawing.Size(60, 20);
            this._tbYSize.TabIndex = 19;
            this._tbYSize.Text = "180";
            this._tbYSize.TextChanged += new System.EventHandler(this.tbYSize_TextChanged);
            this._tbYSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbYSize_KeyPress);
            // 
            // _tbXsize
            // 
            this._tbXsize.Location = new System.Drawing.Point(60, 15);
            this._tbXsize.Name = "_tbXsize";
            this._tbXsize.Size = new System.Drawing.Size(60, 20);
            this._tbXsize.TabIndex = 18;
            this._tbXsize.Text = "990";
            this._tbXsize.TextChanged += new System.EventHandler(this.tbXsize_TextChanged);
            this._tbXsize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbXsize_KeyPress);
            // 
            // _tbYoff
            // 
            this._tbYoff.Location = new System.Drawing.Point(126, 40);
            this._tbYoff.Name = "_tbYoff";
            this._tbYoff.Size = new System.Drawing.Size(60, 20);
            this._tbYoff.TabIndex = 21;
            this._tbYoff.TextChanged += new System.EventHandler(this.tbYoff_TextChanged);
            this._tbYoff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbYoff_KeyPress);
            // 
            // _tbXoff
            // 
            this._tbXoff.Location = new System.Drawing.Point(60, 40);
            this._tbXoff.Name = "_tbXoff";
            this._tbXoff.Size = new System.Drawing.Size(60, 20);
            this._tbXoff.TabIndex = 20;
            this._tbXoff.TextChanged += new System.EventHandler(this.tbXoff_TextChanged);
            this._tbXoff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbXoff_KeyPress);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label7.Location = new System.Drawing.Point(5, 45);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(52, 13);
            this.Label7.TabIndex = 77;
            this.Label7.Text = "XY Offset";
            // 
            // _cboNoteSpace
            // 
            this._cboNoteSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._cboNoteSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboNoteSpace.ForeColor = System.Drawing.Color.White;
            this._cboNoteSpace.FormattingEnabled = true;
            this._cboNoteSpace.Location = new System.Drawing.Point(90, 115);
            this._cboNoteSpace.Name = "_cboNoteSpace";
            this._cboNoteSpace.Size = new System.Drawing.Size(96, 21);
            this._cboNoteSpace.TabIndex = 24;
            this._cboNoteSpace.SelectedIndexChanged += new System.EventHandler(this.cboNoteSpace_SelectedIndexChanged);
            // 
            // _chkGUIMode
            // 
            this._chkGUIMode.AutoSize = true;
            this._chkGUIMode.Location = new System.Drawing.Point(8, 145);
            this._chkGUIMode.Name = "_chkGUIMode";
            this._chkGUIMode.Size = new System.Drawing.Size(108, 17);
            this._chkGUIMode.TabIndex = 100;
            this._chkGUIMode.Text = "Toggle GUI Color";
            this._chkGUIMode.UseVisualStyleBackColor = true;
            this._chkGUIMode.CheckedChanged += new System.EventHandler(this.chkGUIMode_CheckedChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label5.Location = new System.Drawing.Point(5, 120);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(72, 13);
            this.Label5.TabIndex = 73;
            this.Label5.Text = "Note Spacing";
            // 
            // _cmSizeRefresh
            // 
            this._cmSizeRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSizeRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSizeRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSizeRefresh.ForeColor = System.Drawing.Color.Black;
            this._cmSizeRefresh.Location = new System.Drawing.Point(125, 165);
            this._cmSizeRefresh.Name = "_cmSizeRefresh";
            this._cmSizeRefresh.Size = new System.Drawing.Size(58, 23);
            this._cmSizeRefresh.TabIndex = 27;
            this._cmSizeRefresh.Text = "Refresh";
            this._cmSizeRefresh.UseVisualStyleBackColor = false;
            this._cmSizeRefresh.Click += new System.EventHandler(this.cmSizeRefresh_Click);
            // 
            // _cboLayoutX
            // 
            this._cboLayoutX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._cboLayoutX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLayoutX.ForeColor = System.Drawing.Color.White;
            this._cboLayoutX.FormattingEnabled = true;
            this._cboLayoutX.Location = new System.Drawing.Point(60, 65);
            this._cboLayoutX.Name = "_cboLayoutX";
            this._cboLayoutX.Size = new System.Drawing.Size(126, 21);
            this._cboLayoutX.TabIndex = 22;
            this._cboLayoutX.SelectedIndexChanged += new System.EventHandler(this.cboLayoutX_SelectedIndexChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label6.Location = new System.Drawing.Point(5, 70);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(49, 13);
            this.Label6.TabIndex = 72;
            this.Label6.Text = "X Layout";
            // 
            // _pbStats
            // 
            this._pbStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._pbStats.Cursor = System.Windows.Forms.Cursors.Default;
            this._pbStats.Location = new System.Drawing.Point(10, 201);
            this._pbStats.Name = "_pbStats";
            this._pbStats.Size = new System.Drawing.Size(990, 180);
            this._pbStats.TabIndex = 77;
            this._pbStats.TabStop = false;
            this._pbStats.Click += new System.EventHandler(this.pbStats_Click);
            this._pbStats.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbStats_MouseDown);
            this._pbStats.MouseLeave += new System.EventHandler(this.pbStats_MouseLeave);
            this._pbStats.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbStats_MouseMove);
            this._pbStats.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pbStats_MouseWheel);
            // 
            // _cmTestData
            // 
            this._cmTestData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmTestData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmTestData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmTestData.ForeColor = System.Drawing.Color.Black;
            this._cmTestData.Location = new System.Drawing.Point(880, 95);
            this._cmTestData.Name = "_cmTestData";
            this._cmTestData.Size = new System.Drawing.Size(105, 23);
            this._cmTestData.TabIndex = 5;
            this._cmTestData.Text = "Show Test Data";
            this._cmTestData.UseVisualStyleBackColor = false;
            this._cmTestData.Click += new System.EventHandler(this.cmTestData_Click);
            // 
            // _cmLastMatch
            // 
            this._cmLastMatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmLastMatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmLastMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmLastMatch.ForeColor = System.Drawing.Color.Black;
            this._cmLastMatch.Location = new System.Drawing.Point(880, 70);
            this._cmLastMatch.Name = "_cmLastMatch";
            this._cmLastMatch.Size = new System.Drawing.Size(105, 23);
            this._cmLastMatch.TabIndex = 4;
            this._cmLastMatch.Text = "Last Match Stats";
            this._cmLastMatch.UseVisualStyleBackColor = false;
            this._cmLastMatch.Click += new System.EventHandler(this.cmLastMatch_Click);
            // 
            // gbFX
            // 
            this.gbFX.Controls.Add(this.cmRID);
            this.gbFX.Controls.Add(this._chkFX);
            this.gbFX.Controls.Add(this.Label1);
            this.gbFX.Controls.Add(this._cmFXModeHelp);
            this.gbFX.Controls.Add(this._cboFXVar1);
            this.gbFX.Controls.Add(this.lbFXVar1);
            this.gbFX.Controls.Add(this._cboFxVar3);
            this.gbFX.Controls.Add(this.lbFXVar3);
            this.gbFX.Controls.Add(this._cboFxVar4);
            this.gbFX.Controls.Add(this._cmFX3DC);
            this.gbFX.Controls.Add(this._cboFXVar2);
            this.gbFX.Controls.Add(this.lbFXVar2);
            this.gbFX.Controls.Add(this.lbFXVar4);
            this.gbFX.Controls.Add(this._chkMismatch);
            this.gbFX.Location = new System.Drawing.Point(535, 0);
            this.gbFX.Name = "gbFX";
            this.gbFX.Size = new System.Drawing.Size(145, 195);
            this.gbFX.TabIndex = 80;
            this.gbFX.TabStop = false;
            this.gbFX.Text = "Stats FX";
            // 
            // cmRID
            // 
            this.cmRID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.cmRID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this.cmRID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmRID.ForeColor = System.Drawing.Color.Black;
            this.cmRID.Location = new System.Drawing.Point(9, 165);
            this.cmRID.Name = "cmRID";
            this.cmRID.Size = new System.Drawing.Size(50, 23);
            this.cmRID.TabIndex = 95;
            this.cmRID.Text = "RID";
            this.cmRID.UseVisualStyleBackColor = false;
            this.cmRID.Visible = false;
            // 
            // _chkFX
            // 
            this._chkFX.AutoSize = true;
            this._chkFX.Enabled = false;
            this._chkFX.Location = new System.Drawing.Point(66, 42);
            this._chkFX.Name = "_chkFX";
            this._chkFX.Size = new System.Drawing.Size(56, 17);
            this._chkFX.TabIndex = 88;
            this._chkFX.Text = "Active";
            this._chkFX.UseVisualStyleBackColor = true;
            this._chkFX.CheckedChanged += new System.EventHandler(this.chkFX_CheckedChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Label1.Location = new System.Drawing.Point(6, 45);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(34, 13);
            this.Label1.TabIndex = 89;
            this.Label1.Text = "Mode";
            // 
            // _cmFXModeHelp
            // 
            this._cmFXModeHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmFXModeHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmFXModeHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmFXModeHelp.ForeColor = System.Drawing.Color.Black;
            this._cmFXModeHelp.Location = new System.Drawing.Point(65, 165);
            this._cmFXModeHelp.Name = "_cmFXModeHelp";
            this._cmFXModeHelp.Size = new System.Drawing.Size(71, 23);
            this._cmFXModeHelp.TabIndex = 93;
            this._cmFXModeHelp.Text = "Help";
            this._cmFXModeHelp.UseVisualStyleBackColor = false;
            this._cmFXModeHelp.Click += new System.EventHandler(this.cmFXModeHelp_Click);
            // 
            // _cboFXVar1
            // 
            this._cboFXVar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._cboFXVar1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboFXVar1.ForeColor = System.Drawing.Color.White;
            this._cboFXVar1.FormattingEnabled = true;
            this._cboFXVar1.Location = new System.Drawing.Point(65, 15);
            this._cboFXVar1.Name = "_cboFXVar1";
            this._cboFXVar1.Size = new System.Drawing.Size(71, 21);
            this._cboFXVar1.TabIndex = 87;
            this._cboFXVar1.SelectedIndexChanged += new System.EventHandler(this.cboFXMode_SelectedIndexChanged);
            // 
            // lbFXVar1
            // 
            this.lbFXVar1.AutoSize = true;
            this.lbFXVar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lbFXVar1.Location = new System.Drawing.Point(6, 21);
            this.lbFXVar1.Name = "lbFXVar1";
            this.lbFXVar1.Size = new System.Drawing.Size(34, 13);
            this.lbFXVar1.TabIndex = 86;
            this.lbFXVar1.Text = "Mode";
            // 
            // _cboFxVar3
            // 
            this._cboFxVar3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._cboFxVar3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboFxVar3.Enabled = false;
            this._cboFxVar3.ForeColor = System.Drawing.Color.White;
            this._cboFxVar3.FormattingEnabled = true;
            this._cboFxVar3.Location = new System.Drawing.Point(65, 89);
            this._cboFxVar3.Name = "_cboFxVar3";
            this._cboFxVar3.Size = new System.Drawing.Size(71, 21);
            this._cboFxVar3.TabIndex = 91;
            this._cboFxVar3.SelectedIndexChanged += new System.EventHandler(this.cboFxVar3_SelectedIndexChanged);
            // 
            // lbFXVar3
            // 
            this.lbFXVar3.AutoSize = true;
            this.lbFXVar3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lbFXVar3.Location = new System.Drawing.Point(6, 91);
            this.lbFXVar3.Name = "lbFXVar3";
            this.lbFXVar3.Size = new System.Drawing.Size(13, 13);
            this.lbFXVar3.TabIndex = 84;
            this.lbFXVar3.Text = "--";
            // 
            // _cboFxVar4
            // 
            this._cboFxVar4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._cboFxVar4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboFxVar4.Enabled = false;
            this._cboFxVar4.ForeColor = System.Drawing.Color.White;
            this._cboFxVar4.FormattingEnabled = true;
            this._cboFxVar4.Location = new System.Drawing.Point(65, 113);
            this._cboFxVar4.Name = "_cboFxVar4";
            this._cboFxVar4.Size = new System.Drawing.Size(71, 21);
            this._cboFxVar4.TabIndex = 92;
            this._cboFxVar4.SelectedIndexChanged += new System.EventHandler(this.cboFxVar4_SelectedIndexChanged);
            // 
            // _cmFX3DC
            // 
            this._cmFX3DC.Enabled = false;
            this._cmFX3DC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmFX3DC.Location = new System.Drawing.Point(65, 65);
            this._cmFX3DC.Name = "_cmFX3DC";
            this._cmFX3DC.Size = new System.Drawing.Size(21, 21);
            this._cmFX3DC.TabIndex = 89;
            this._cmFX3DC.Text = "1";
            this._cmFX3DC.UseVisualStyleBackColor = true;
            this._cmFX3DC.Click += new System.EventHandler(this.cmFX3DC_Click);
            // 
            // _cboFXVar2
            // 
            this._cboFXVar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._cboFXVar2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboFXVar2.Enabled = false;
            this._cboFXVar2.ForeColor = System.Drawing.Color.White;
            this._cboFXVar2.FormattingEnabled = true;
            this._cboFXVar2.Location = new System.Drawing.Point(90, 65);
            this._cboFXVar2.Name = "_cboFXVar2";
            this._cboFXVar2.Size = new System.Drawing.Size(46, 21);
            this._cboFXVar2.TabIndex = 90;
            this._cboFXVar2.SelectedIndexChanged += new System.EventHandler(this.cboFX3D_SelectedIndexChanged);
            // 
            // lbFXVar2
            // 
            this.lbFXVar2.AutoSize = true;
            this.lbFXVar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lbFXVar2.Location = new System.Drawing.Point(6, 68);
            this.lbFXVar2.Name = "lbFXVar2";
            this.lbFXVar2.Size = new System.Drawing.Size(13, 13);
            this.lbFXVar2.TabIndex = 66;
            this.lbFXVar2.Text = "--";
            // 
            // lbFXVar4
            // 
            this.lbFXVar4.AutoSize = true;
            this.lbFXVar4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lbFXVar4.Location = new System.Drawing.Point(6, 115);
            this.lbFXVar4.Name = "lbFXVar4";
            this.lbFXVar4.Size = new System.Drawing.Size(13, 13);
            this.lbFXVar4.TabIndex = 70;
            this.lbFXVar4.Text = "--";
            // 
            // _chkMismatch
            // 
            this._chkMismatch.AutoSize = true;
            this._chkMismatch.Checked = true;
            this._chkMismatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkMismatch.Location = new System.Drawing.Point(9, 143);
            this._chkMismatch.Name = "_chkMismatch";
            this._chkMismatch.Size = new System.Drawing.Size(102, 17);
            this._chkMismatch.TabIndex = 11;
            this._chkMismatch.Text = "Show Bad Stats";
            this._chkMismatch.UseVisualStyleBackColor = true;
            this._chkMismatch.Visible = false;
            this._chkMismatch.CheckedChanged += new System.EventHandler(this.chkMismatch_CheckedChanged);
            // 
            // lbError1
            // 
            this.lbError1.BackColor = System.Drawing.Color.Silver;
            this.lbError1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbError1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError1.ForeColor = System.Drawing.Color.White;
            this.lbError1.Location = new System.Drawing.Point(10, 70);
            this.lbError1.Name = "lbError1";
            this.lbError1.Size = new System.Drawing.Size(111, 18);
            this.lbError1.TabIndex = 81;
            this.lbError1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbError2
            // 
            this.lbError2.BackColor = System.Drawing.Color.Silver;
            this.lbError2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbError2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError2.ForeColor = System.Drawing.Color.White;
            this.lbError2.Location = new System.Drawing.Point(10, 90);
            this.lbError2.Name = "lbError2";
            this.lbError2.Size = new System.Drawing.Size(111, 18);
            this.lbError2.TabIndex = 82;
            this.lbError2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _chkTips
            // 
            this._chkTips.AutoSize = true;
            this._chkTips.Location = new System.Drawing.Point(991, 42);
            this._chkTips.Name = "_chkTips";
            this._chkTips.Size = new System.Drawing.Size(100, 17);
            this._chkTips.TabIndex = 10;
            this._chkTips.Text = "Show Tool Tips";
            this._chkTips.UseVisualStyleBackColor = true;
            this._chkTips.CheckedChanged += new System.EventHandler(this.chkTips_CheckedChanged);
            // 
            // pbNote1
            // 
            this.pbNote1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbNote1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbNote1.Location = new System.Drawing.Point(11, 387);
            this.pbNote1.Name = "pbNote1";
            this.pbNote1.Size = new System.Drawing.Size(500, 60);
            this.pbNote1.TabIndex = 91;
            this.pbNote1.TabStop = false;
            // 
            // _timNote1
            // 
            this._timNote1.Enabled = true;
            this._timNote1.Interval = 30;
            this._timNote1.Tick += new System.EventHandler(this.timNote1_Tick);
            // 
            // gbSound
            // 
            this.gbSound.Controls.Add(this._cmAudioStop);
            this.gbSound.Controls.Add(this.lbVolume);
            this.gbSound.Controls.Add(this._scrVolume);
            this.gbSound.Controls.Add(this._cmSound15);
            this.gbSound.Controls.Add(this._cmSound14);
            this.gbSound.Controls.Add(this._cmSound13);
            this.gbSound.Controls.Add(this._cmSound12);
            this.gbSound.Controls.Add(this._cmSound11);
            this.gbSound.Controls.Add(this.lbSoundCurrent);
            this.gbSound.Controls.Add(this._cmSound10);
            this.gbSound.Controls.Add(this._cmSound09);
            this.gbSound.Controls.Add(this._cmSound08);
            this.gbSound.Controls.Add(this._cmSound07);
            this.gbSound.Controls.Add(this._cmSound06);
            this.gbSound.Controls.Add(this._cmSound05);
            this.gbSound.Controls.Add(this._cmSound04);
            this.gbSound.Controls.Add(this._cmSound03);
            this.gbSound.Controls.Add(this._cmSound02);
            this.gbSound.Controls.Add(this._cmSound01);
            this.gbSound.Location = new System.Drawing.Point(685, 0);
            this.gbSound.Name = "gbSound";
            this.gbSound.Size = new System.Drawing.Size(190, 195);
            this.gbSound.TabIndex = 94;
            this.gbSound.TabStop = false;
            this.gbSound.Text = "Sound";
            // 
            // _cmAudioStop
            // 
            this._cmAudioStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmAudioStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmAudioStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmAudioStop.ForeColor = System.Drawing.Color.Black;
            this._cmAudioStop.Location = new System.Drawing.Point(145, 170);
            this._cmAudioStop.Name = "_cmAudioStop";
            this._cmAudioStop.Size = new System.Drawing.Size(35, 18);
            this._cmAudioStop.TabIndex = 34;
            this._cmAudioStop.Text = "▀";
            this._cmAudioStop.UseVisualStyleBackColor = false;
            this._cmAudioStop.Click += new System.EventHandler(this.cmAudioStop_Click);
            // 
            // lbVolume
            // 
            this.lbVolume.BackColor = System.Drawing.Color.Silver;
            this.lbVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbVolume.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVolume.ForeColor = System.Drawing.Color.Black;
            this.lbVolume.Location = new System.Drawing.Point(105, 170);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(35, 18);
            this.lbVolume.TabIndex = 33;
            this.lbVolume.Text = "100";
            this.lbVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _scrVolume
            // 
            this._scrVolume.Location = new System.Drawing.Point(5, 170);
            this._scrVolume.Maximum = 109;
            this._scrVolume.Name = "_scrVolume";
            this._scrVolume.Size = new System.Drawing.Size(95, 18);
            this._scrVolume.TabIndex = 32;
            this._scrVolume.TabStop = true;
            this._scrVolume.Value = 100;
            this._scrVolume.ValueChanged += new System.EventHandler(this.scrVolume_ValueChanged);
            // 
            // _cmSound15
            // 
            this._cmSound15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound15.ForeColor = System.Drawing.Color.Black;
            this._cmSound15.Location = new System.Drawing.Point(125, 115);
            this._cmSound15.Name = "_cmSound15";
            this._cmSound15.Size = new System.Drawing.Size(55, 23);
            this._cmSound15.TabIndex = 31;
            this._cmSound15.Text = "ALERT";
            this._cmSound15.UseVisualStyleBackColor = false;
            this._cmSound15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound15_MouseDown);
            this._cmSound15.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound15.MouseHover += new System.EventHandler(this.cmSound15_MouseHover);
            // 
            // _cmSound14
            // 
            this._cmSound14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound14.ForeColor = System.Drawing.Color.Black;
            this._cmSound14.Location = new System.Drawing.Point(65, 115);
            this._cmSound14.Name = "_cmSound14";
            this._cmSound14.Size = new System.Drawing.Size(55, 23);
            this._cmSound14.TabIndex = 30;
            this._cmSound14.Text = "> 14";
            this._cmSound14.UseVisualStyleBackColor = false;
            this._cmSound14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound14_MouseDown);
            this._cmSound14.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound14.MouseHover += new System.EventHandler(this.cmSound14_MouseHover);
            // 
            // _cmSound13
            // 
            this._cmSound13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound13.ForeColor = System.Drawing.Color.Black;
            this._cmSound13.Location = new System.Drawing.Point(5, 115);
            this._cmSound13.Name = "_cmSound13";
            this._cmSound13.Size = new System.Drawing.Size(55, 23);
            this._cmSound13.TabIndex = 29;
            this._cmSound13.Text = "> 13";
            this._cmSound13.UseVisualStyleBackColor = false;
            this._cmSound13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound13_MouseDown);
            this._cmSound13.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound13.MouseHover += new System.EventHandler(this.cmSound13_MouseHover);
            // 
            // _cmSound12
            // 
            this._cmSound12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound12.ForeColor = System.Drawing.Color.Black;
            this._cmSound12.Location = new System.Drawing.Point(125, 90);
            this._cmSound12.Name = "_cmSound12";
            this._cmSound12.Size = new System.Drawing.Size(55, 23);
            this._cmSound12.TabIndex = 28;
            this._cmSound12.Text = "> 12";
            this._cmSound12.UseVisualStyleBackColor = false;
            this._cmSound12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound12_MouseDown);
            this._cmSound12.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound12.MouseHover += new System.EventHandler(this.cmSound12_MouseHover);
            // 
            // _cmSound11
            // 
            this._cmSound11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound11.ForeColor = System.Drawing.Color.Black;
            this._cmSound11.Location = new System.Drawing.Point(65, 90);
            this._cmSound11.Name = "_cmSound11";
            this._cmSound11.Size = new System.Drawing.Size(55, 23);
            this._cmSound11.TabIndex = 27;
            this._cmSound11.Text = "> 11";
            this._cmSound11.UseVisualStyleBackColor = false;
            this._cmSound11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound11_MouseDown);
            this._cmSound11.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound11.MouseHover += new System.EventHandler(this.cmSound11_MouseHover);
            // 
            // lbSoundCurrent
            // 
            this.lbSoundCurrent.BackColor = System.Drawing.Color.Silver;
            this.lbSoundCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSoundCurrent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoundCurrent.ForeColor = System.Drawing.Color.Black;
            this.lbSoundCurrent.Location = new System.Drawing.Point(5, 150);
            this.lbSoundCurrent.Name = "lbSoundCurrent";
            this.lbSoundCurrent.Size = new System.Drawing.Size(175, 18);
            this.lbSoundCurrent.TabIndex = 26;
            this.lbSoundCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cmSound10
            // 
            this._cmSound10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound10.ForeColor = System.Drawing.Color.Black;
            this._cmSound10.Location = new System.Drawing.Point(5, 90);
            this._cmSound10.Name = "_cmSound10";
            this._cmSound10.Size = new System.Drawing.Size(55, 23);
            this._cmSound10.TabIndex = 17;
            this._cmSound10.Text = "> 10";
            this._cmSound10.UseVisualStyleBackColor = false;
            this._cmSound10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound10_MouseDown);
            this._cmSound10.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound10.MouseHover += new System.EventHandler(this.cmSound10_MouseHover);
            // 
            // _cmSound09
            // 
            this._cmSound09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound09.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound09.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound09.ForeColor = System.Drawing.Color.Black;
            this._cmSound09.Location = new System.Drawing.Point(125, 65);
            this._cmSound09.Name = "_cmSound09";
            this._cmSound09.Size = new System.Drawing.Size(55, 23);
            this._cmSound09.TabIndex = 16;
            this._cmSound09.Text = "> 09";
            this._cmSound09.UseVisualStyleBackColor = false;
            this._cmSound09.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound09_MouseDown);
            this._cmSound09.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound09.MouseHover += new System.EventHandler(this.cmSound09_MouseHover);
            // 
            // _cmSound08
            // 
            this._cmSound08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound08.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound08.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound08.ForeColor = System.Drawing.Color.Black;
            this._cmSound08.Location = new System.Drawing.Point(65, 65);
            this._cmSound08.Name = "_cmSound08";
            this._cmSound08.Size = new System.Drawing.Size(55, 23);
            this._cmSound08.TabIndex = 15;
            this._cmSound08.Text = "> 08";
            this._cmSound08.UseVisualStyleBackColor = false;
            this._cmSound08.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound08_MouseDown);
            this._cmSound08.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound08.MouseHover += new System.EventHandler(this.cmSound08_MouseHover);
            // 
            // _cmSound07
            // 
            this._cmSound07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound07.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound07.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound07.ForeColor = System.Drawing.Color.Black;
            this._cmSound07.Location = new System.Drawing.Point(5, 65);
            this._cmSound07.Name = "_cmSound07";
            this._cmSound07.Size = new System.Drawing.Size(55, 23);
            this._cmSound07.TabIndex = 14;
            this._cmSound07.Text = "> 07";
            this._cmSound07.UseVisualStyleBackColor = false;
            this._cmSound07.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound07_MouseDown);
            this._cmSound07.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound07.MouseHover += new System.EventHandler(this.cmSound07_MouseHover);
            // 
            // _cmSound06
            // 
            this._cmSound06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound06.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound06.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound06.ForeColor = System.Drawing.Color.Black;
            this._cmSound06.Location = new System.Drawing.Point(125, 40);
            this._cmSound06.Name = "_cmSound06";
            this._cmSound06.Size = new System.Drawing.Size(55, 23);
            this._cmSound06.TabIndex = 13;
            this._cmSound06.Text = "> 06";
            this._cmSound06.UseVisualStyleBackColor = false;
            this._cmSound06.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound06_MouseDown);
            this._cmSound06.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound06.MouseHover += new System.EventHandler(this.cmSound06_MouseHover);
            // 
            // _cmSound05
            // 
            this._cmSound05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound05.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound05.ForeColor = System.Drawing.Color.Black;
            this._cmSound05.Location = new System.Drawing.Point(65, 40);
            this._cmSound05.Name = "_cmSound05";
            this._cmSound05.Size = new System.Drawing.Size(55, 23);
            this._cmSound05.TabIndex = 12;
            this._cmSound05.Text = "> 05";
            this._cmSound05.UseVisualStyleBackColor = false;
            this._cmSound05.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound05_MouseDown);
            this._cmSound05.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound05.MouseHover += new System.EventHandler(this.cmSound05_MouseHover);
            // 
            // _cmSound04
            // 
            this._cmSound04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound04.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound04.ForeColor = System.Drawing.Color.Black;
            this._cmSound04.Location = new System.Drawing.Point(5, 40);
            this._cmSound04.Name = "_cmSound04";
            this._cmSound04.Size = new System.Drawing.Size(55, 23);
            this._cmSound04.TabIndex = 11;
            this._cmSound04.Text = "> 04";
            this._cmSound04.UseVisualStyleBackColor = false;
            this._cmSound04.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound04_MouseDown);
            this._cmSound04.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound04.MouseHover += new System.EventHandler(this.cmSound04_MouseHover);
            // 
            // _cmSound03
            // 
            this._cmSound03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound03.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound03.ForeColor = System.Drawing.Color.Black;
            this._cmSound03.Location = new System.Drawing.Point(125, 15);
            this._cmSound03.Name = "_cmSound03";
            this._cmSound03.Size = new System.Drawing.Size(55, 23);
            this._cmSound03.TabIndex = 10;
            this._cmSound03.Text = "> 03";
            this._cmSound03.UseVisualStyleBackColor = false;
            this._cmSound03.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound03_MouseDown);
            this._cmSound03.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound03.MouseHover += new System.EventHandler(this.cmSound03_MouseHover);
            // 
            // _cmSound02
            // 
            this._cmSound02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound02.ForeColor = System.Drawing.Color.Black;
            this._cmSound02.Location = new System.Drawing.Point(65, 15);
            this._cmSound02.Name = "_cmSound02";
            this._cmSound02.Size = new System.Drawing.Size(55, 23);
            this._cmSound02.TabIndex = 9;
            this._cmSound02.Text = "> 02";
            this._cmSound02.UseVisualStyleBackColor = false;
            this._cmSound02.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound02_MouseDown);
            this._cmSound02.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound02.MouseHover += new System.EventHandler(this.cmSound02_MouseHover);
            // 
            // _cmSound01
            // 
            this._cmSound01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmSound01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmSound01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmSound01.ForeColor = System.Drawing.Color.Black;
            this._cmSound01.Location = new System.Drawing.Point(5, 15);
            this._cmSound01.Name = "_cmSound01";
            this._cmSound01.Size = new System.Drawing.Size(55, 23);
            this._cmSound01.TabIndex = 8;
            this._cmSound01.Text = "> 01";
            this._cmSound01.UseVisualStyleBackColor = false;
            this._cmSound01.Click += new System.EventHandler(this.cmSound01_Click);
            this._cmSound01.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmSound01_MouseDown);
            this._cmSound01.MouseLeave += new System.EventHandler(this.cmSound01_MouseLeave);
            this._cmSound01.MouseHover += new System.EventHandler(this.cmSound01_MouseHover);
            // 
            // pbNote3
            // 
            this.pbNote3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbNote3.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbNote3.Location = new System.Drawing.Point(11, 517);
            this.pbNote3.Name = "pbNote3";
            this.pbNote3.Size = new System.Drawing.Size(500, 60);
            this.pbNote3.TabIndex = 96;
            this.pbNote3.TabStop = false;
            // 
            // pbNote4
            // 
            this.pbNote4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbNote4.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbNote4.Location = new System.Drawing.Point(11, 582);
            this.pbNote4.Name = "pbNote4";
            this.pbNote4.Size = new System.Drawing.Size(500, 60);
            this.pbNote4.TabIndex = 97;
            this.pbNote4.TabStop = false;
            // 
            // pbNote2
            // 
            this.pbNote2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbNote2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbNote2.Location = new System.Drawing.Point(11, 452);
            this.pbNote2.Name = "pbNote2";
            this.pbNote2.Size = new System.Drawing.Size(500, 60);
            this.pbNote2.TabIndex = 98;
            this.pbNote2.TabStop = false;
            // 
            // chkPosition
            // 
            this.chkPosition.AutoSize = true;
            this.chkPosition.Location = new System.Drawing.Point(991, 59);
            this.chkPosition.Name = "chkPosition";
            this.chkPosition.Size = new System.Drawing.Size(114, 17);
            this.chkPosition.TabIndex = 12;
            this.chkPosition.Text = "Save Window Pos";
            this.chkPosition.UseVisualStyleBackColor = true;
            // 
            // tsmPlayer
            // 
            this.tsmPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmPlayer_Relic,
            this._tsmPlayer_OrgAT,
            this._tsmPlayer_OrgFaction,
            this._tsmPlayer_OrgPlayercard,
            this._tsmPlayer_Google,
            this._tsmPlayer_Steam});
            this.tsmPlayer.Name = "tsmPlayer";
            this.tsmPlayer.Size = new System.Drawing.Size(290, 136);
            // 
            // _tsmPlayer_Relic
            // 
            this._tsmPlayer_Relic.Image = ((System.Drawing.Image)(resources.GetObject("_tsmPlayer_Relic.Image")));
            this._tsmPlayer_Relic.Name = "_tsmPlayer_Relic";
            this._tsmPlayer_Relic.Size = new System.Drawing.Size(289, 22);
            this._tsmPlayer_Relic.Text = "&1 - Open Relic Stats webpage";
            this._tsmPlayer_Relic.Click += new System.EventHandler(this.tsmPlayer_Relic_Click);
            // 
            // _tsmPlayer_OrgAT
            // 
            this._tsmPlayer_OrgAT.Image = ((System.Drawing.Image)(resources.GetObject("_tsmPlayer_OrgAT.Image")));
            this._tsmPlayer_OrgAT.Name = "_tsmPlayer_OrgAT";
            this._tsmPlayer_OrgAT.Size = new System.Drawing.Size(289, 22);
            this._tsmPlayer_OrgAT.Text = "&2 - Open Coh2.Org AT stats webpage";
            this._tsmPlayer_OrgAT.Click += new System.EventHandler(this.tsmPlayer_OrgAT_Click);
            // 
            // _tsmPlayer_OrgFaction
            // 
            this._tsmPlayer_OrgFaction.Image = ((System.Drawing.Image)(resources.GetObject("_tsmPlayer_OrgFaction.Image")));
            this._tsmPlayer_OrgFaction.Name = "_tsmPlayer_OrgFaction";
            this._tsmPlayer_OrgFaction.Size = new System.Drawing.Size(289, 22);
            this._tsmPlayer_OrgFaction.Text = "3 - Open Coh2.Org Faction webpage";
            this._tsmPlayer_OrgFaction.Click += new System.EventHandler(this.tsmPlayer_OrgFaction_Click);
            // 
            // _tsmPlayer_OrgPlayercard
            // 
            this._tsmPlayer_OrgPlayercard.Image = ((System.Drawing.Image)(resources.GetObject("_tsmPlayer_OrgPlayercard.Image")));
            this._tsmPlayer_OrgPlayercard.Name = "_tsmPlayer_OrgPlayercard";
            this._tsmPlayer_OrgPlayercard.Size = new System.Drawing.Size(289, 22);
            this._tsmPlayer_OrgPlayercard.Text = "&4 - Open Coh2.Org Playercard webpage";
            this._tsmPlayer_OrgPlayercard.Click += new System.EventHandler(this.tsmPlayer_OrgPlayercard_Click);
            // 
            // _tsmPlayer_Google
            // 
            this._tsmPlayer_Google.Image = ((System.Drawing.Image)(resources.GetObject("_tsmPlayer_Google.Image")));
            this._tsmPlayer_Google.Name = "_tsmPlayer_Google";
            this._tsmPlayer_Google.Size = new System.Drawing.Size(289, 22);
            this._tsmPlayer_Google.Text = "&5 - Send player name to Google Translate";
            this._tsmPlayer_Google.Click += new System.EventHandler(this.tsmPlayer_Google_Click);
            // 
            // _tsmPlayer_Steam
            // 
            this._tsmPlayer_Steam.Image = ((System.Drawing.Image)(resources.GetObject("_tsmPlayer_Steam.Image")));
            this._tsmPlayer_Steam.Name = "_tsmPlayer_Steam";
            this._tsmPlayer_Steam.Size = new System.Drawing.Size(289, 22);
            this._tsmPlayer_Steam.Text = "&6 - Open player Steam page";
            this._tsmPlayer_Steam.Click += new System.EventHandler(this.tsmPlayer_Steam_Click);
            // 
            // _chkPopUp
            // 
            this._chkPopUp.AutoSize = true;
            this._chkPopUp.Location = new System.Drawing.Point(1029, 237);
            this._chkPopUp.Name = "_chkPopUp";
            this._chkPopUp.Size = new System.Drawing.Size(106, 17);
            this._chkPopUp.TabIndex = 13;
            this._chkPopUp.Text = "Use Stats Popup";
            this._chkPopUp.UseVisualStyleBackColor = true;
            this._chkPopUp.Visible = false;
            this._chkPopUp.CheckedChanged += new System.EventHandler(this.chkPopUp_CheckedChanged);
            // 
            // tsmAudio
            // 
            this.tsmAudio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmSetVolTo100,
            this._tsmSetVolTo90,
            this._tsmSetVolTo80,
            this._tsmSetVolTo70,
            this._tsmSetVolTo60,
            this._tsmSetVolTo50,
            this._tsmSetVolTo40,
            this._tsmSetVolTo30,
            this._tsmSetVolTo20,
            this._tsmSetVolTo10,
            this.ToolStripMenuItem1,
            this._tsmSelectFile});
            this.tsmAudio.Name = "tsmAudio";
            this.tsmAudio.Size = new System.Drawing.Size(216, 252);
            // 
            // _tsmSetVolTo100
            // 
            this._tsmSetVolTo100.Name = "_tsmSetVolTo100";
            this._tsmSetVolTo100.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo100.Text = "&0 - Set Vol to 100%";
            this._tsmSetVolTo100.Click += new System.EventHandler(this.tsmSetVolTo100_Click);
            // 
            // _tsmSetVolTo90
            // 
            this._tsmSetVolTo90.Name = "_tsmSetVolTo90";
            this._tsmSetVolTo90.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo90.Text = "9 - Set Vol to 90%";
            this._tsmSetVolTo90.Click += new System.EventHandler(this.tsmSetVolTo90_Click);
            // 
            // _tsmSetVolTo80
            // 
            this._tsmSetVolTo80.Name = "_tsmSetVolTo80";
            this._tsmSetVolTo80.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo80.Text = "8 - Set Vol to 80%";
            this._tsmSetVolTo80.Click += new System.EventHandler(this.tsmSetVolTo80_Click);
            // 
            // _tsmSetVolTo70
            // 
            this._tsmSetVolTo70.Name = "_tsmSetVolTo70";
            this._tsmSetVolTo70.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo70.Text = "7 - Set Vol to 70%";
            this._tsmSetVolTo70.Click += new System.EventHandler(this.tsmSetVolTo70_Click);
            // 
            // _tsmSetVolTo60
            // 
            this._tsmSetVolTo60.Name = "_tsmSetVolTo60";
            this._tsmSetVolTo60.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo60.Text = "6 - Set Vol to 60%";
            this._tsmSetVolTo60.Click += new System.EventHandler(this.tsmSetVolTo60_Click);
            // 
            // _tsmSetVolTo50
            // 
            this._tsmSetVolTo50.Name = "_tsmSetVolTo50";
            this._tsmSetVolTo50.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo50.Text = "5 - Set Vol to 50%";
            this._tsmSetVolTo50.Click += new System.EventHandler(this.tsmSetVolTo50_Click);
            // 
            // _tsmSetVolTo40
            // 
            this._tsmSetVolTo40.Name = "_tsmSetVolTo40";
            this._tsmSetVolTo40.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo40.Text = "4 - Set Vol to 40%";
            this._tsmSetVolTo40.Click += new System.EventHandler(this.tsmSetVolTo40_Click);
            // 
            // _tsmSetVolTo30
            // 
            this._tsmSetVolTo30.Name = "_tsmSetVolTo30";
            this._tsmSetVolTo30.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo30.Text = "3 - Set Vol to 30%";
            this._tsmSetVolTo30.Click += new System.EventHandler(this.tsmSetVolTo30_Click);
            // 
            // _tsmSetVolTo20
            // 
            this._tsmSetVolTo20.Name = "_tsmSetVolTo20";
            this._tsmSetVolTo20.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo20.Text = "2 - Set Vol to 20%";
            this._tsmSetVolTo20.Click += new System.EventHandler(this.tsmSetVolTo20_Click);
            // 
            // _tsmSetVolTo10
            // 
            this._tsmSetVolTo10.Name = "_tsmSetVolTo10";
            this._tsmSetVolTo10.Size = new System.Drawing.Size(215, 22);
            this._tsmSetVolTo10.Text = "1 - Set Vol to 10%";
            this._tsmSetVolTo10.Click += new System.EventHandler(this.tsmSetVolTo10_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(212, 6);
            // 
            // _tsmSelectFile
            // 
            this._tsmSelectFile.Name = "_tsmSelectFile";
            this._tsmSelectFile.Size = new System.Drawing.Size(215, 22);
            this._tsmSelectFile.Text = "F - Select Audio file to play";
            this._tsmSelectFile.Click += new System.EventHandler(this.tsmSelectFile_Click);
            // 
            // _chkSmoothAni
            // 
            this._chkSmoothAni.AutoSize = true;
            this._chkSmoothAni.Location = new System.Drawing.Point(991, 93);
            this._chkSmoothAni.Name = "_chkSmoothAni";
            this._chkSmoothAni.Size = new System.Drawing.Size(111, 17);
            this._chkSmoothAni.TabIndex = 14;
            this._chkSmoothAni.Text = "Smooth Animation";
            this._chkSmoothAni.UseVisualStyleBackColor = true;
            this._chkSmoothAni.CheckedChanged += new System.EventHandler(this.chkSmoothAni_CheckedChanged);
            // 
            // _chkFoundSound
            // 
            this._chkFoundSound.AutoSize = true;
            this._chkFoundSound.Location = new System.Drawing.Point(991, 110);
            this._chkFoundSound.Name = "_chkFoundSound";
            this._chkFoundSound.Size = new System.Drawing.Size(113, 17);
            this._chkFoundSound.TabIndex = 101;
            this._chkFoundSound.Text = "Match Found Alert";
            this._chkFoundSound.UseVisualStyleBackColor = true;
            this._chkFoundSound.CheckedChanged += new System.EventHandler(this.chkFoundSound_CheckedChanged);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lbTime.Location = new System.Drawing.Point(8, 170);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(56, 13);
            this.lbTime.TabIndex = 102;
            this.lbTime.Text = "Time (sec)";
            // 
            // _cboDelay
            // 
            this._cboDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._cboDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDelay.ForeColor = System.Drawing.Color.White;
            this._cboDelay.FormattingEnabled = true;
            this._cboDelay.Location = new System.Drawing.Point(70, 165);
            this._cboDelay.Name = "_cboDelay";
            this._cboDelay.Size = new System.Drawing.Size(51, 21);
            this._cboDelay.TabIndex = 103;
            this._cboDelay.SelectedIndexChanged += new System.EventHandler(this.cboDelay_SelectedIndexChanged);
            // 
            // _chkHideMissing
            // 
            this._chkHideMissing.AutoSize = true;
            this._chkHideMissing.Location = new System.Drawing.Point(991, 127);
            this._chkHideMissing.Name = "_chkHideMissing";
            this._chkHideMissing.Size = new System.Drawing.Size(123, 17);
            this._chkHideMissing.TabIndex = 104;
            this._chkHideMissing.Text = "Hide Missing Players";
            this._chkHideMissing.UseVisualStyleBackColor = true;
            this._chkHideMissing.CheckedChanged += new System.EventHandler(this.chkHideMissing_CheckedChanged);
            // 
            // _chkShowELO
            // 
            this._chkShowELO.AutoSize = true;
            this._chkShowELO.Location = new System.Drawing.Point(991, 144);
            this._chkShowELO.Name = "_chkShowELO";
            this._chkShowELO.Size = new System.Drawing.Size(99, 17);
            this._chkShowELO.TabIndex = 105;
            this._chkShowELO.Text = "Cycle ELO Vals";
            this._chkShowELO.UseVisualStyleBackColor = true;
            this._chkShowELO.CheckedChanged += new System.EventHandler(this.chkShowELO_CheckedChanged);
            // 
            // _timELOCycle
            // 
            this._timELOCycle.Enabled = true;
            this._timELOCycle.Interval = 3000;
            this._timELOCycle.Tick += new System.EventHandler(this.timELOCycle_Tick);
            // 
            // _scrStats
            // 
            this._scrStats.LargeChange = 90;
            this._scrStats.Location = new System.Drawing.Point(1003, 202);
            this._scrStats.Name = "_scrStats";
            this._scrStats.Size = new System.Drawing.Size(23, 178);
            this._scrStats.TabIndex = 107;
            this._scrStats.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrStats_Scroll);
            this._scrStats.ValueChanged += new System.EventHandler(this.scrStats_ValueChanged);
            // 
            // _chkSpeech
            // 
            this._chkSpeech.AutoSize = true;
            this._chkSpeech.Location = new System.Drawing.Point(991, 161);
            this._chkSpeech.Name = "_chkSpeech";
            this._chkSpeech.Size = new System.Drawing.Size(116, 17);
            this._chkSpeech.TabIndex = 108;
            this._chkSpeech.Text = "Read Ranks Aloud";
            this._chkSpeech.UseVisualStyleBackColor = true;
            this._chkSpeech.CheckedChanged += new System.EventHandler(this.chkSpeech_CheckedChanged);
            // 
            // _chkGetTeams
            // 
            this._chkGetTeams.AutoSize = true;
            this._chkGetTeams.Location = new System.Drawing.Point(991, 178);
            this._chkGetTeams.Name = "_chkGetTeams";
            this._chkGetTeams.Size = new System.Drawing.Size(110, 17);
            this._chkGetTeams.TabIndex = 109;
            this._chkGetTeams.Text = "Find Team Ranks";
            this._chkGetTeams.UseVisualStyleBackColor = true;
            this._chkGetTeams.CheckedChanged += new System.EventHandler(this.chkGetTeams_CheckedChanged);
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(738, 387);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(288, 277);
            this.lstLog.TabIndex = 110;
            this.lstLog.Visible = false;
            // 
            // _cmErrLog
            // 
            this._cmErrLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this._cmErrLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this._cmErrLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmErrLog.ForeColor = System.Drawing.Color.Black;
            this._cmErrLog.Location = new System.Drawing.Point(880, 170);
            this._cmErrLog.Name = "_cmErrLog";
            this._cmErrLog.Size = new System.Drawing.Size(105, 23);
            this._cmErrLog.TabIndex = 111;
            this._cmErrLog.Text = "View Web Log";
            this._cmErrLog.UseVisualStyleBackColor = false;
            this._cmErrLog.Click += new System.EventHandler(this.cmErrLog_Click);
            // 
            // _chkCountry
            // 
            this._chkCountry.AutoSize = true;
            this._chkCountry.Location = new System.Drawing.Point(991, 76);
            this._chkCountry.Name = "_chkCountry";
            this._chkCountry.Size = new System.Drawing.Size(120, 17);
            this._chkCountry.TabIndex = 112;
            this._chkCountry.Text = "Show Country Flags";
            this._chkCountry.UseVisualStyleBackColor = true;
            this._chkCountry.CheckedChanged += new System.EventHandler(this.chkCountry_CheckedChanged);
            // 
            // SS1
            // 
            this.SS1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SS1_Version,
            this.SS1_Sep1,
            this.SS1_Filename,
            this.SS1_Sep2,
            this.SS1_Time,
            this.SS1_Sep3});
            this.SS1.Location = new System.Drawing.Point(0, 717);
            this.SS1.Name = "SS1";
            this.SS1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.SS1.Size = new System.Drawing.Size(1215, 22);
            this.SS1.TabIndex = 113;
            // 
            // SS1_Version
            // 
            this.SS1_Version.AutoSize = false;
            this.SS1_Version.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.SS1_Version.Name = "SS1_Version";
            this.SS1_Version.Size = new System.Drawing.Size(35, 17);
            this.SS1_Version.Text = "v4.50";
            this.SS1_Version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SS1_Sep1
            // 
            this.SS1_Sep1.AutoSize = false;
            this.SS1_Sep1.Name = "SS1_Sep1";
            this.SS1_Sep1.Size = new System.Drawing.Size(10, 17);
            this.SS1_Sep1.Text = "|";
            // 
            // SS1_Filename
            // 
            this.SS1_Filename.AutoSize = false;
            this.SS1_Filename.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.SS1_Filename.Name = "SS1_Filename";
            this.SS1_Filename.Size = new System.Drawing.Size(250, 17);
            this.SS1_Filename.Text = "default.mcs";
            this.SS1_Filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SS1_Sep2
            // 
            this.SS1_Sep2.AutoSize = false;
            this.SS1_Sep2.Name = "SS1_Sep2";
            this.SS1_Sep2.Size = new System.Drawing.Size(10, 17);
            this.SS1_Sep2.Text = "|";
            // 
            // SS1_Time
            // 
            this.SS1_Time.AutoSize = false;
            this.SS1_Time.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.SS1_Time.Name = "SS1_Time";
            this.SS1_Time.Size = new System.Drawing.Size(180, 17);
            this.SS1_Time.Text = "Match found:";
            this.SS1_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SS1_Sep3
            // 
            this.SS1_Sep3.AutoSize = false;
            this.SS1_Sep3.Name = "SS1_Sep3";
            this.SS1_Sep3.Size = new System.Drawing.Size(10, 17);
            this.SS1_Sep3.Text = "|";
            // 
            // _chkToggleOverlay
            // 
            this._chkToggleOverlay.AutoSize = true;
            this._chkToggleOverlay.Location = new System.Drawing.Point(1111, 43);
            this._chkToggleOverlay.Name = "_chkToggleOverlay";
            this._chkToggleOverlay.Size = new System.Drawing.Size(98, 17);
            this._chkToggleOverlay.TabIndex = 115;
            this._chkToggleOverlay.Text = "Toggle Overlay";
            this._chkToggleOverlay.UseVisualStyleBackColor = true;
            this._chkToggleOverlay.CheckedChanged += new System.EventHandler(this._chkToggleOverlay_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1215, 739);
            this.Controls.Add(this._chkToggleOverlay);
            this.Controls.Add(this.SS1);
            this.Controls.Add(this._chkCountry);
            this.Controls.Add(this._cmErrLog);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this._chkGetTeams);
            this.Controls.Add(this._chkSpeech);
            this.Controls.Add(this._scrStats);
            this.Controls.Add(this._chkShowELO);
            this.Controls.Add(this._chkHideMissing);
            this.Controls.Add(this._cboDelay);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this._chkFoundSound);
            this.Controls.Add(this._chkSmoothAni);
            this.Controls.Add(this._chkPopUp);
            this.Controls.Add(this.chkPosition);
            this.Controls.Add(this._cmCopy);
            this.Controls.Add(this._cmSave);
            this.Controls.Add(this.pbNote2);
            this.Controls.Add(this.pbNote4);
            this.Controls.Add(this.pbNote3);
            this.Controls.Add(this.gbSound);
            this.Controls.Add(this.pbNote1);
            this.Controls.Add(this._chkTips);
            this.Controls.Add(this.lbError2);
            this.Controls.Add(this.lbError1);
            this.Controls.Add(this.gbFX);
            this.Controls.Add(this._cmLastMatch);
            this.Controls.Add(this._cmTestData);
            this.Controls.Add(this._pbStats);
            this.Controls.Add(this.gbLayout);
            this.Controls.Add(this.gbRank);
            this.Controls.Add(this._cmAbout);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this._cmScanLog);
            this.Controls.Add(this._cmFindLog);
            this.Controls.Add(this.lbSteam08);
            this.Controls.Add(this.lbSteam07);
            this.Controls.Add(this.lbSteam06);
            this.Controls.Add(this.lbSteam05);
            this.Controls.Add(this.lbSteam04);
            this.Controls.Add(this.lbSteam03);
            this.Controls.Add(this.lbSteam02);
            this.Controls.Add(this.lbSteam01);
            this.Controls.Add(this.pbFact05);
            this.Controls.Add(this.pbFact04);
            this.Controls.Add(this.pbFact03);
            this.Controls.Add(this.pbFact02);
            this.Controls.Add(this.pbFact01);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this._cmCheckLog);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "MakoCelo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbFact01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFact02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFact03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFact04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFact05)).EndInit();
            this.gbRank.ResumeLayout(false);
            this.gbRank.PerformLayout();
            this.gbLayout.ResumeLayout(false);
            this.gbLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbStats)).EndInit();
            this.gbFX.ResumeLayout(false);
            this.gbFX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote1)).EndInit();
            this.gbSound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNote3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote2)).EndInit();
            this.tsmPlayer.ResumeLayout(false);
            this.tsmAudio.ResumeLayout(false);
            this.SS1.ResumeLayout(false);
            this.SS1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button _cmCheckLog;

        internal Button cmCheckLog
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCheckLog;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCheckLog != null)
                {
                    _cmCheckLog.Click -= cmCheckLog_Click;
                }

                _cmCheckLog = value;
                if (_cmCheckLog != null)
                {
                    _cmCheckLog.Click += cmCheckLog_Click;
                }
            }
        }

        internal Label lbStatus;
        internal PictureBox pbFact01;
        internal PictureBox pbFact02;
        internal PictureBox pbFact03;
        internal PictureBox pbFact04;
        internal PictureBox pbFact05;
        internal Label lbSteam01;
        internal Label lbSteam02;
        internal Label lbSteam03;
        internal Label lbSteam04;
        internal Label lbSteam05;
        internal Label lbSteam06;
        internal Label lbSteam07;
        internal Label lbSteam08;
        internal ColorDialog ColorDialog1;
        internal OpenFileDialog OpenFileDialog1;
        private Timer _Timer1;

        internal Timer Timer1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Timer1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Timer1 != null)
                {
                    _Timer1.Tick -= Timer1_Tick;
                }

                _Timer1 = value;
                if (_Timer1 != null)
                {
                    _Timer1.Tick += Timer1_Tick;
                }
            }
        }

        private Button _cmFindLog;

        internal Button cmFindLog
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmFindLog;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmFindLog != null)
                {
                    _cmFindLog.Click -= cmFindLog_Click;
                }

                _cmFindLog = value;
                if (_cmFindLog != null)
                {
                    _cmFindLog.Click += cmFindLog_Click;
                }
            }
        }

        private Button _cmScanLog;

        internal Button cmScanLog
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmScanLog;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmScanLog != null)
                {
                    _cmScanLog.Click -= cmScanLog_Click;
                }

                _cmScanLog = value;
                if (_cmScanLog != null)
                {
                    _cmScanLog.Click += cmScanLog_Click;
                }
            }
        }

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

        internal Label Label2;
        internal FontDialog FontDialog1;
        private Button _cmAbout;

        internal Button cmAbout
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmAbout;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmAbout != null)
                {
                    _cmAbout.Click -= cmAbout_Click;
                }

                _cmAbout = value;
                if (_cmAbout != null)
                {
                    _cmAbout.Click += cmAbout_Click;
                }
            }
        }

        internal Label Label3;
        internal Label Label4;
        private ComboBox _cboLayoutY;

        internal ComboBox cboLayoutY
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLayoutY;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLayoutY != null)
                {
                    _cboLayoutY.SelectedIndexChanged -= cboLayoutY_SelectedIndexChanged;
                }

                _cboLayoutY = value;
                if (_cboLayoutY != null)
                {
                    _cboLayoutY.SelectedIndexChanged += cboLayoutY_SelectedIndexChanged;
                }
            }
        }

        internal GroupBox gbRank;
        internal GroupBox gbLayout;
        private ComboBox _cboLayoutX;

        internal ComboBox cboLayoutX
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLayoutX;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLayoutX != null)
                {
                    _cboLayoutX.SelectedIndexChanged -= cboLayoutX_SelectedIndexChanged;
                }

                _cboLayoutX = value;
                if (_cboLayoutX != null)
                {
                    _cboLayoutX.SelectedIndexChanged += cboLayoutX_SelectedIndexChanged;
                }
            }
        }

        internal Label Label6;
        private Button _cmSizeRefresh;

        internal Button cmSizeRefresh
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSizeRefresh;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSizeRefresh != null)
                {
                    _cmSizeRefresh.Click -= cmSizeRefresh_Click;
                }

                _cmSizeRefresh = value;
                if (_cmSizeRefresh != null)
                {
                    _cmSizeRefresh.Click += cmSizeRefresh_Click;
                }
            }
        }

        private PictureBox _pbStats;

        internal PictureBox pbStats
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbStats;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbStats != null)
                {
                    _pbStats.Click -= pbStats_Click;
                    _pbStats.MouseDown -= pbStats_MouseDown;
                    _pbStats.MouseLeave -= pbStats_MouseLeave;
                    _pbStats.MouseMove -= pbStats_MouseMove;
                    _pbStats.MouseWheel -= pbStats_MouseWheel;
                }

                _pbStats = value;
                if (_pbStats != null)
                {
                    _pbStats.Click += pbStats_Click;
                    _pbStats.MouseDown += pbStats_MouseDown;
                    _pbStats.MouseLeave += pbStats_MouseLeave;
                    _pbStats.MouseMove += pbStats_MouseMove;
                    _pbStats.MouseWheel += pbStats_MouseWheel;
                }
            }
        }

        private Button _cmTestData;

        internal Button cmTestData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmTestData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmTestData != null)
                {
                    _cmTestData.Click -= cmTestData_Click;
                }

                _cmTestData = value;
                if (_cmTestData != null)
                {
                    _cmTestData.Click += cmTestData_Click;
                }
            }
        }

        private Button _cmLastMatch;

        internal Button cmLastMatch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmLastMatch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmLastMatch != null)
                {
                    _cmLastMatch.Click -= cmLastMatch_Click;
                }

                _cmLastMatch = value;
                if (_cmLastMatch != null)
                {
                    _cmLastMatch.Click += cmLastMatch_Click;
                }
            }
        }

        internal GroupBox gbFX;
        internal Label lbFXVar2;
        internal Label lbFXVar4;
        private Button _cmFX3DC;

        internal Button cmFX3DC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmFX3DC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmFX3DC != null)
                {
                    _cmFX3DC.Click -= cmFX3DC_Click;
                }

                _cmFX3DC = value;
                if (_cmFX3DC != null)
                {
                    _cmFX3DC.Click += cmFX3DC_Click;
                }
            }
        }

        private ComboBox _cboFXVar2;

        internal ComboBox cboFXVar2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFXVar2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFXVar2 != null)
                {
                    _cboFXVar2.SelectedIndexChanged -= cboFX3D_SelectedIndexChanged;
                }

                _cboFXVar2 = value;
                if (_cboFXVar2 != null)
                {
                    _cboFXVar2.SelectedIndexChanged += cboFX3D_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboFxVar4;

        internal ComboBox cboFxVar4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFxVar4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFxVar4 != null)
                {
                    _cboFxVar4.SelectedIndexChanged -= cboFxVar4_SelectedIndexChanged;
                }

                _cboFxVar4 = value;
                if (_cboFxVar4 != null)
                {
                    _cboFxVar4.SelectedIndexChanged += cboFxVar4_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboFxVar3;

        internal ComboBox cboFxVar3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFxVar3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFxVar3 != null)
                {
                    _cboFxVar3.SelectedIndexChanged -= cboFxVar3_SelectedIndexChanged;
                }

                _cboFxVar3 = value;
                if (_cboFxVar3 != null)
                {
                    _cboFxVar3.SelectedIndexChanged += cboFxVar3_SelectedIndexChanged;
                }
            }
        }

        internal Label lbFXVar3;
        private ComboBox _cboFXVar1;

        internal ComboBox cboFXVar1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFXVar1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFXVar1 != null)
                {
                    _cboFXVar1.SelectedIndexChanged -= cboFXMode_SelectedIndexChanged;
                }

                _cboFXVar1 = value;
                if (_cboFXVar1 != null)
                {
                    _cboFXVar1.SelectedIndexChanged += cboFXMode_SelectedIndexChanged;
                }
            }
        }

        internal Label lbFXVar1;
        private Button _cmFXModeHelp;

        internal Button cmFXModeHelp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmFXModeHelp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmFXModeHelp != null)
                {
                    _cmFXModeHelp.Click -= cmFXModeHelp_Click;
                }

                _cmFXModeHelp = value;
                if (_cmFXModeHelp != null)
                {
                    _cmFXModeHelp.Click += cmFXModeHelp_Click;
                }
            }
        }

        internal Label lbError1;
        internal Label lbError2;
        private CheckBox _chkFX;

        internal CheckBox chkFX
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkFX;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkFX != null)
                {
                    _chkFX.CheckedChanged -= chkFX_CheckedChanged;
                }

                _chkFX = value;
                if (_chkFX != null)
                {
                    _chkFX.CheckedChanged += chkFX_CheckedChanged;
                }
            }
        }

        internal Label Label1;
        private Button _cmSave;

        internal Button cmSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSave != null)
                {
                    _cmSave.Click -= cmSave_Click;
                }

                _cmSave = value;
                if (_cmSave != null)
                {
                    _cmSave.Click += cmSave_Click;
                }
            }
        }

        internal SaveFileDialog SaveFileDialog1;
        private CheckBox _chkMismatch;

        internal CheckBox chkMismatch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkMismatch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkMismatch != null)
                {
                    _chkMismatch.CheckedChanged -= chkMismatch_CheckedChanged;
                }

                _chkMismatch = value;
                if (_chkMismatch != null)
                {
                    _chkMismatch.CheckedChanged += chkMismatch_CheckedChanged;
                }
            }
        }

        internal ToolTip ToolTip1;
        private CheckBox _chkTips;

        internal CheckBox chkTips
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkTips;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkTips != null)
                {
                    _chkTips.CheckedChanged -= chkTips_CheckedChanged;
                }

                _chkTips = value;
                if (_chkTips != null)
                {
                    _chkTips.CheckedChanged += chkTips_CheckedChanged;
                }
            }
        }

        internal PictureBox pbNote1;
        private Timer _timNote1;

        internal Timer timNote1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _timNote1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_timNote1 != null)
                {
                    _timNote1.Tick -= timNote1_Tick;
                }

                _timNote1 = value;
                if (_timNote1 != null)
                {
                    _timNote1.Tick += timNote1_Tick;
                }
            }
        }

        internal GroupBox gbSound;
        private Button _cmSound02;

        internal Button cmSound02
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound02;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound02 != null)
                {
                    _cmSound02.MouseDown -= cmSound02_MouseDown;
                    _cmSound02.MouseHover -= cmSound02_MouseHover;
                    _cmSound02.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound02 = value;
                if (_cmSound02 != null)
                {
                    _cmSound02.MouseDown += cmSound02_MouseDown;
                    _cmSound02.MouseHover += cmSound02_MouseHover;
                    _cmSound02.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound01;

        internal Button cmSound01
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound01;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound01 != null)
                {
                    _cmSound01.Click -= cmSound01_Click;
                    _cmSound01.MouseDown -= cmSound01_MouseDown;
                    _cmSound01.MouseHover -= cmSound01_MouseHover;
                    _cmSound01.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound01 = value;
                if (_cmSound01 != null)
                {
                    _cmSound01.Click += cmSound01_Click;
                    _cmSound01.MouseDown += cmSound01_MouseDown;
                    _cmSound01.MouseHover += cmSound01_MouseHover;
                    _cmSound01.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        internal Label lbSoundCurrent;
        private Button _cmSound10;

        internal Button cmSound10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound10 != null)
                {
                    _cmSound10.MouseDown -= cmSound10_MouseDown;
                    _cmSound10.MouseHover -= cmSound10_MouseHover;
                    _cmSound10.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound10 = value;
                if (_cmSound10 != null)
                {
                    _cmSound10.MouseDown += cmSound10_MouseDown;
                    _cmSound10.MouseHover += cmSound10_MouseHover;
                    _cmSound10.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound09;

        internal Button cmSound09
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound09;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound09 != null)
                {
                    _cmSound09.MouseDown -= cmSound09_MouseDown;
                    _cmSound09.MouseHover -= cmSound09_MouseHover;
                    _cmSound09.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound09 = value;
                if (_cmSound09 != null)
                {
                    _cmSound09.MouseDown += cmSound09_MouseDown;
                    _cmSound09.MouseHover += cmSound09_MouseHover;
                    _cmSound09.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound08;

        internal Button cmSound08
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound08;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound08 != null)
                {
                    _cmSound08.MouseDown -= cmSound08_MouseDown;
                    _cmSound08.MouseHover -= cmSound08_MouseHover;
                    _cmSound08.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound08 = value;
                if (_cmSound08 != null)
                {
                    _cmSound08.MouseDown += cmSound08_MouseDown;
                    _cmSound08.MouseHover += cmSound08_MouseHover;
                    _cmSound08.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound07;

        internal Button cmSound07
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound07;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound07 != null)
                {
                    _cmSound07.MouseDown -= cmSound07_MouseDown;
                    _cmSound07.MouseHover -= cmSound07_MouseHover;
                    _cmSound07.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound07 = value;
                if (_cmSound07 != null)
                {
                    _cmSound07.MouseDown += cmSound07_MouseDown;
                    _cmSound07.MouseHover += cmSound07_MouseHover;
                    _cmSound07.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound06;

        internal Button cmSound06
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound06;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound06 != null)
                {
                    _cmSound06.MouseDown -= cmSound06_MouseDown;
                    _cmSound06.MouseHover -= cmSound06_MouseHover;
                    _cmSound06.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound06 = value;
                if (_cmSound06 != null)
                {
                    _cmSound06.MouseDown += cmSound06_MouseDown;
                    _cmSound06.MouseHover += cmSound06_MouseHover;
                    _cmSound06.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound05;

        internal Button cmSound05
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound05;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound05 != null)
                {
                    _cmSound05.MouseDown -= cmSound05_MouseDown;
                    _cmSound05.MouseHover -= cmSound05_MouseHover;
                    _cmSound05.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound05 = value;
                if (_cmSound05 != null)
                {
                    _cmSound05.MouseDown += cmSound05_MouseDown;
                    _cmSound05.MouseHover += cmSound05_MouseHover;
                    _cmSound05.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound04;

        internal Button cmSound04
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound04;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound04 != null)
                {
                    _cmSound04.MouseDown -= cmSound04_MouseDown;
                    _cmSound04.MouseHover -= cmSound04_MouseHover;
                    _cmSound04.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound04 = value;
                if (_cmSound04 != null)
                {
                    _cmSound04.MouseDown += cmSound04_MouseDown;
                    _cmSound04.MouseHover += cmSound04_MouseHover;
                    _cmSound04.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound03;

        internal Button cmSound03
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound03;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound03 != null)
                {
                    _cmSound03.MouseDown -= cmSound03_MouseDown;
                    _cmSound03.MouseHover -= cmSound03_MouseHover;
                    _cmSound03.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound03 = value;
                if (_cmSound03 != null)
                {
                    _cmSound03.MouseDown += cmSound03_MouseDown;
                    _cmSound03.MouseHover += cmSound03_MouseHover;
                    _cmSound03.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmRankSetup;

        internal Button cmRankSetup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmRankSetup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmRankSetup != null)
                {
                    _cmRankSetup.Click -= cmRankSetup_Click;
                }

                _cmRankSetup = value;
                if (_cmRankSetup != null)
                {
                    _cmRankSetup.Click += cmRankSetup_Click;
                }
            }
        }

        private Button _cmNote3;

        internal Button cmNote3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote3 != null)
                {
                    _cmNote3.Click -= cmNote3_Click;
                }

                _cmNote3 = value;
                if (_cmNote3 != null)
                {
                    _cmNote3.Click += cmNote3_Click;
                }
            }
        }

        private Button _cmNote2;

        internal Button cmNote2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote2 != null)
                {
                    _cmNote2.Click -= cmNote2_Click;
                }

                _cmNote2 = value;
                if (_cmNote2 != null)
                {
                    _cmNote2.Click += cmNote2_Click;
                }
            }
        }

        private Button _cmNote1;

        internal Button cmNote1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote1 != null)
                {
                    _cmNote1.Click -= cmNote1_Click;
                }

                _cmNote1 = value;
                if (_cmNote1 != null)
                {
                    _cmNote1.Click += cmNote1_Click;
                }
            }
        }

        private Button _cmNote03Setup;

        internal Button cmNote03Setup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote03Setup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote03Setup != null)
                {
                    _cmNote03Setup.Click -= cmNote03Setup_Click_1;
                }

                _cmNote03Setup = value;
                if (_cmNote03Setup != null)
                {
                    _cmNote03Setup.Click += cmNote03Setup_Click_1;
                }
            }
        }

        private Button _cmNote02Setup;

        internal Button cmNote02Setup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote02Setup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote02Setup != null)
                {
                    _cmNote02Setup.Click -= cmNote02Setup_Click_1;
                }

                _cmNote02Setup = value;
                if (_cmNote02Setup != null)
                {
                    _cmNote02Setup.Click += cmNote02Setup_Click_1;
                }
            }
        }

        internal Label Label13;
        internal Label Label12;
        private Button _cmNote01Setup;

        internal Button cmNote01Setup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote01Setup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote01Setup != null)
                {
                    _cmNote01Setup.Click -= cmNote01Setup_Click_1;
                }

                _cmNote01Setup = value;
                if (_cmNote01Setup != null)
                {
                    _cmNote01Setup.Click += cmNote01Setup_Click_1;
                }
            }
        }

        internal Label Label11;
        private Button _cmNameSetup;

        internal Button cmNameSetup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNameSetup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNameSetup != null)
                {
                    _cmNameSetup.Click -= cmNameSetup_Click;
                }

                _cmNameSetup = value;
                if (_cmNameSetup != null)
                {
                    _cmNameSetup.Click += cmNameSetup_Click;
                }
            }
        }

        internal Label Label10;
        internal Label Label9;
        internal PictureBox pbNote3;
        internal PictureBox pbNote4;
        internal PictureBox pbNote2;
        private Button _cmNote4;

        internal Button cmNote4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote4 != null)
                {
                    _cmNote4.Click -= cmNote4_Click;
                }

                _cmNote4 = value;
                if (_cmNote4 != null)
                {
                    _cmNote4.Click += cmNote4_Click;
                }
            }
        }

        private Button _cmNote04Setup;

        internal Button cmNote04Setup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote04Setup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote04Setup != null)
                {
                    _cmNote04Setup.Click -= cmNote04Setup_Click_1;
                }

                _cmNote04Setup = value;
                if (_cmNote04Setup != null)
                {
                    _cmNote04Setup.Click += cmNote04Setup_Click_1;
                }
            }
        }

        internal Label Label14;
        private Button _cmNote04_Play;

        internal Button cmNote04_Play
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote04_Play;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote04_Play != null)
                {
                    _cmNote04_Play.Click -= cmNote04_Play_Click;
                }

                _cmNote04_Play = value;
                if (_cmNote04_Play != null)
                {
                    _cmNote04_Play.Click += cmNote04_Play_Click;
                }
            }
        }

        private Button _cmNote03_Play;

        internal Button cmNote03_Play
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote03_Play;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote03_Play != null)
                {
                    _cmNote03_Play.Click -= cmNote03_Play_Click;
                }

                _cmNote03_Play = value;
                if (_cmNote03_Play != null)
                {
                    _cmNote03_Play.Click += cmNote03_Play_Click;
                }
            }
        }

        private Button _cmNote02_Play;

        internal Button cmNote02_Play
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote02_Play;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote02_Play != null)
                {
                    _cmNote02_Play.Click -= cmNote02_Play_Click;
                }

                _cmNote02_Play = value;
                if (_cmNote02_Play != null)
                {
                    _cmNote02_Play.Click += cmNote02_Play_Click;
                }
            }
        }

        private Button _cmNote01_Play;

        internal Button cmNote01_Play
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote01_Play;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote01_Play != null)
                {
                    _cmNote01_Play.Click -= cmNote01_Play_Click;
                }

                _cmNote01_Play = value;
                if (_cmNote01_Play != null)
                {
                    _cmNote01_Play.Click += cmNote01_Play_Click;
                }
            }
        }

        private Button _cmSound15;

        internal Button cmSound15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound15 != null)
                {
                    _cmSound15.MouseDown -= cmSound15_MouseDown;
                    _cmSound15.MouseHover -= cmSound15_MouseHover;
                    _cmSound15.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound15 = value;
                if (_cmSound15 != null)
                {
                    _cmSound15.MouseDown += cmSound15_MouseDown;
                    _cmSound15.MouseHover += cmSound15_MouseHover;
                    _cmSound15.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound14;

        internal Button cmSound14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound14 != null)
                {
                    _cmSound14.MouseDown -= cmSound14_MouseDown;
                    _cmSound14.MouseHover -= cmSound14_MouseHover;
                    _cmSound14.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound14 = value;
                if (_cmSound14 != null)
                {
                    _cmSound14.MouseDown += cmSound14_MouseDown;
                    _cmSound14.MouseHover += cmSound14_MouseHover;
                    _cmSound14.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound13;

        internal Button cmSound13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound13 != null)
                {
                    _cmSound13.MouseDown -= cmSound13_MouseDown;
                    _cmSound13.MouseHover -= cmSound13_MouseHover;
                    _cmSound13.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound13 = value;
                if (_cmSound13 != null)
                {
                    _cmSound13.MouseDown += cmSound13_MouseDown;
                    _cmSound13.MouseHover += cmSound13_MouseHover;
                    _cmSound13.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound12;

        internal Button cmSound12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound12 != null)
                {
                    _cmSound12.MouseDown -= cmSound12_MouseDown;
                    _cmSound12.MouseHover -= cmSound12_MouseHover;
                    _cmSound12.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound12 = value;
                if (_cmSound12 != null)
                {
                    _cmSound12.MouseDown += cmSound12_MouseDown;
                    _cmSound12.MouseHover += cmSound12_MouseHover;
                    _cmSound12.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private Button _cmSound11;

        internal Button cmSound11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSound11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSound11 != null)
                {
                    _cmSound11.MouseDown -= cmSound11_MouseDown;
                    _cmSound11.MouseHover -= cmSound11_MouseHover;
                    _cmSound11.MouseLeave -= cmSound01_MouseLeave;
                }

                _cmSound11 = value;
                if (_cmSound11 != null)
                {
                    _cmSound11.MouseDown += cmSound11_MouseDown;
                    _cmSound11.MouseHover += cmSound11_MouseHover;
                    _cmSound11.MouseLeave += cmSound01_MouseLeave;
                }
            }
        }

        private HScrollBar _scrVolume;

        internal HScrollBar scrVolume
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _scrVolume;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_scrVolume != null)
                {
                    _scrVolume.ValueChanged -= scrVolume_ValueChanged;
                }

                _scrVolume = value;
                if (_scrVolume != null)
                {
                    _scrVolume.ValueChanged += scrVolume_ValueChanged;
                }
            }
        }

        internal Label lbVolume;
        private Button _cmNote_PlayAll;

        internal Button cmNote_PlayAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNote_PlayAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNote_PlayAll != null)
                {
                    _cmNote_PlayAll.Click -= cmNote_PlayAll_Click;
                }

                _cmNote_PlayAll = value;
                if (_cmNote_PlayAll != null)
                {
                    _cmNote_PlayAll.Click += cmNote_PlayAll_Click;
                }
            }
        }

        private ComboBox _cboNoteSpace;

        internal ComboBox cboNoteSpace
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboNoteSpace;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboNoteSpace != null)
                {
                    _cboNoteSpace.SelectedIndexChanged -= cboNoteSpace_SelectedIndexChanged;
                }

                _cboNoteSpace = value;
                if (_cboNoteSpace != null)
                {
                    _cboNoteSpace.SelectedIndexChanged += cboNoteSpace_SelectedIndexChanged;
                }
            }
        }

        internal Label Label5;
        internal CheckBox chkPosition;
        internal ContextMenuStrip tsmPlayer;
        private ToolStripMenuItem _tsmPlayer_Relic;

        internal ToolStripMenuItem tsmPlayer_Relic
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmPlayer_Relic;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmPlayer_Relic != null)
                {
                    _tsmPlayer_Relic.Click -= tsmPlayer_Relic_Click;
                }

                _tsmPlayer_Relic = value;
                if (_tsmPlayer_Relic != null)
                {
                    _tsmPlayer_Relic.Click += tsmPlayer_Relic_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmPlayer_OrgAT;

        internal ToolStripMenuItem tsmPlayer_OrgAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmPlayer_OrgAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmPlayer_OrgAT != null)
                {
                    _tsmPlayer_OrgAT.Click -= tsmPlayer_OrgAT_Click;
                }

                _tsmPlayer_OrgAT = value;
                if (_tsmPlayer_OrgAT != null)
                {
                    _tsmPlayer_OrgAT.Click += tsmPlayer_OrgAT_Click;
                }
            }
        }

        private CheckBox _chkPopUp;

        internal CheckBox chkPopUp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPopUp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPopUp != null)
                {
                    _chkPopUp.CheckedChanged -= chkPopUp_CheckedChanged;
                }

                _chkPopUp = value;
                if (_chkPopUp != null)
                {
                    _chkPopUp.CheckedChanged += chkPopUp_CheckedChanged;
                }
            }
        }

        private ToolStripMenuItem _tsmPlayer_OrgFaction;

        internal ToolStripMenuItem tsmPlayer_OrgFaction
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmPlayer_OrgFaction;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmPlayer_OrgFaction != null)
                {
                    _tsmPlayer_OrgFaction.Click -= tsmPlayer_OrgFaction_Click;
                }

                _tsmPlayer_OrgFaction = value;
                if (_tsmPlayer_OrgFaction != null)
                {
                    _tsmPlayer_OrgFaction.Click += tsmPlayer_OrgFaction_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmPlayer_OrgPlayercard;

        internal ToolStripMenuItem tsmPlayer_OrgPlayercard
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmPlayer_OrgPlayercard;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmPlayer_OrgPlayercard != null)
                {
                    _tsmPlayer_OrgPlayercard.Click -= tsmPlayer_OrgPlayercard_Click;
                }

                _tsmPlayer_OrgPlayercard = value;
                if (_tsmPlayer_OrgPlayercard != null)
                {
                    _tsmPlayer_OrgPlayercard.Click += tsmPlayer_OrgPlayercard_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmPlayer_Google;

        internal ToolStripMenuItem tsmPlayer_Google
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmPlayer_Google;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmPlayer_Google != null)
                {
                    _tsmPlayer_Google.Click -= tsmPlayer_Google_Click;
                }

                _tsmPlayer_Google = value;
                if (_tsmPlayer_Google != null)
                {
                    _tsmPlayer_Google.Click += tsmPlayer_Google_Click;
                }
            }
        }

        internal ContextMenuStrip tsmAudio;
        private ToolStripMenuItem _tsmSetVolTo100;

        internal ToolStripMenuItem tsmSetVolTo100
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo100;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo100 != null)
                {
                    _tsmSetVolTo100.Click -= tsmSetVolTo100_Click;
                }

                _tsmSetVolTo100 = value;
                if (_tsmSetVolTo100 != null)
                {
                    _tsmSetVolTo100.Click += tsmSetVolTo100_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmSetVolTo90;

        internal ToolStripMenuItem tsmSetVolTo90
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo90;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo90 != null)
                {
                    _tsmSetVolTo90.Click -= tsmSetVolTo90_Click;
                }

                _tsmSetVolTo90 = value;
                if (_tsmSetVolTo90 != null)
                {
                    _tsmSetVolTo90.Click += tsmSetVolTo90_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmSetVolTo80;

        internal ToolStripMenuItem tsmSetVolTo80
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo80;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo80 != null)
                {
                    _tsmSetVolTo80.Click -= tsmSetVolTo80_Click;
                }

                _tsmSetVolTo80 = value;
                if (_tsmSetVolTo80 != null)
                {
                    _tsmSetVolTo80.Click += tsmSetVolTo80_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmSetVolTo70;

        internal ToolStripMenuItem tsmSetVolTo70
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo70;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo70 != null)
                {
                    _tsmSetVolTo70.Click -= tsmSetVolTo70_Click;
                }

                _tsmSetVolTo70 = value;
                if (_tsmSetVolTo70 != null)
                {
                    _tsmSetVolTo70.Click += tsmSetVolTo70_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmSetVolTo60;

        internal ToolStripMenuItem tsmSetVolTo60
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo60;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo60 != null)
                {
                    _tsmSetVolTo60.Click -= tsmSetVolTo60_Click;
                }

                _tsmSetVolTo60 = value;
                if (_tsmSetVolTo60 != null)
                {
                    _tsmSetVolTo60.Click += tsmSetVolTo60_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmSetVolTo50;

        internal ToolStripMenuItem tsmSetVolTo50
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo50;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo50 != null)
                {
                    _tsmSetVolTo50.Click -= tsmSetVolTo50_Click;
                }

                _tsmSetVolTo50 = value;
                if (_tsmSetVolTo50 != null)
                {
                    _tsmSetVolTo50.Click += tsmSetVolTo50_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmSetVolTo40;

        internal ToolStripMenuItem tsmSetVolTo40
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo40;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo40 != null)
                {
                    _tsmSetVolTo40.Click -= tsmSetVolTo40_Click;
                }

                _tsmSetVolTo40 = value;
                if (_tsmSetVolTo40 != null)
                {
                    _tsmSetVolTo40.Click += tsmSetVolTo40_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmSetVolTo30;

        internal ToolStripMenuItem tsmSetVolTo30
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo30;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo30 != null)
                {
                    _tsmSetVolTo30.Click -= tsmSetVolTo30_Click;
                }

                _tsmSetVolTo30 = value;
                if (_tsmSetVolTo30 != null)
                {
                    _tsmSetVolTo30.Click += tsmSetVolTo30_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmSetVolTo20;

        internal ToolStripMenuItem tsmSetVolTo20
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo20;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo20 != null)
                {
                    _tsmSetVolTo20.Click -= tsmSetVolTo20_Click;
                }

                _tsmSetVolTo20 = value;
                if (_tsmSetVolTo20 != null)
                {
                    _tsmSetVolTo20.Click += tsmSetVolTo20_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmSetVolTo10;

        internal ToolStripMenuItem tsmSetVolTo10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSetVolTo10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSetVolTo10 != null)
                {
                    _tsmSetVolTo10.Click -= tsmSetVolTo10_Click;
                }

                _tsmSetVolTo10 = value;
                if (_tsmSetVolTo10 != null)
                {
                    _tsmSetVolTo10.Click += tsmSetVolTo10_Click;
                }
            }
        }

        internal ToolStripSeparator ToolStripMenuItem1;
        private ToolStripMenuItem _tsmSelectFile;

        internal ToolStripMenuItem tsmSelectFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmSelectFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmSelectFile != null)
                {
                    _tsmSelectFile.Click -= tsmSelectFile_Click;
                }

                _tsmSelectFile = value;
                if (_tsmSelectFile != null)
                {
                    _tsmSelectFile.Click += tsmSelectFile_Click;
                }
            }
        }

        private Button _cmAudioStop;

        internal Button cmAudioStop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmAudioStop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmAudioStop != null)
                {
                    _cmAudioStop.Click -= cmAudioStop_Click;
                }

                _cmAudioStop = value;
                if (_cmAudioStop != null)
                {
                    _cmAudioStop.Click += cmAudioStop_Click;
                }
            }
        }

        internal Label Label7;
        private TextBox _tbYoff;

        internal TextBox tbYoff
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tbYoff;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tbYoff != null)
                {
                    _tbYoff.KeyPress -= tbYoff_KeyPress;
                    _tbYoff.TextChanged -= tbYoff_TextChanged;
                }

                _tbYoff = value;
                if (_tbYoff != null)
                {
                    _tbYoff.KeyPress += tbYoff_KeyPress;
                    _tbYoff.TextChanged += tbYoff_TextChanged;
                }
            }
        }

        private TextBox _tbXoff;

        internal TextBox tbXoff
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tbXoff;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tbXoff != null)
                {
                    _tbXoff.KeyPress -= tbXoff_KeyPress;
                    _tbXoff.TextChanged -= tbXoff_TextChanged;
                }

                _tbXoff = value;
                if (_tbXoff != null)
                {
                    _tbXoff.KeyPress += tbXoff_KeyPress;
                    _tbXoff.TextChanged += tbXoff_TextChanged;
                }
            }
        }

        private TextBox _tbYSize;

        internal TextBox tbYSize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tbYSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tbYSize != null)
                {
                    _tbYSize.TextChanged -= tbYSize_TextChanged;
                    _tbYSize.KeyPress -= tbYSize_KeyPress;
                }

                _tbYSize = value;
                if (_tbYSize != null)
                {
                    _tbYSize.TextChanged += tbYSize_TextChanged;
                    _tbYSize.KeyPress += tbYSize_KeyPress;
                }
            }
        }

        private TextBox _tbXsize;

        internal TextBox tbXsize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tbXsize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tbXsize != null)
                {
                    _tbXsize.TextChanged -= tbXsize_TextChanged;
                    _tbXsize.KeyPress -= tbXsize_KeyPress;
                }

                _tbXsize = value;
                if (_tbXsize != null)
                {
                    _tbXsize.TextChanged += tbXsize_TextChanged;
                    _tbXsize.KeyPress += tbXsize_KeyPress;
                }
            }
        }

        private Button _cmDefaults;

        internal Button cmDefaults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmDefaults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmDefaults != null)
                {
                    _cmDefaults.Click -= cmDefaults_Click;
                }

                _cmDefaults = value;
                if (_cmDefaults != null)
                {
                    _cmDefaults.Click += cmDefaults_Click;
                }
            }
        }

        private Button _cmStatsModeHelp;

        internal Button cmStatsModeHelp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmStatsModeHelp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmStatsModeHelp != null)
                {
                    _cmStatsModeHelp.Click -= cmStatsModeHelp_Click;
                }

                _cmStatsModeHelp = value;
                if (_cmStatsModeHelp != null)
                {
                    _cmStatsModeHelp.Click += cmStatsModeHelp_Click;
                }
            }
        }

        private CheckBox _chkSmoothAni;

        internal CheckBox chkSmoothAni
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSmoothAni;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSmoothAni != null)
                {
                    _chkSmoothAni.CheckedChanged -= chkSmoothAni_CheckedChanged;
                }

                _chkSmoothAni = value;
                if (_chkSmoothAni != null)
                {
                    _chkSmoothAni.CheckedChanged += chkSmoothAni_CheckedChanged;
                }
            }
        }

        private Button _cmSetupLoad;

        internal Button cmSetupLoad
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSetupLoad;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSetupLoad != null)
                {
                    _cmSetupLoad.Click -= cmSetupLoad_Click;
                }

                _cmSetupLoad = value;
                if (_cmSetupLoad != null)
                {
                    _cmSetupLoad.Click += cmSetupLoad_Click;
                }
            }
        }

        private Button _cmSetupSave;

        internal Button cmSetupSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmSetupSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmSetupSave != null)
                {
                    _cmSetupSave.Click -= cmSetupSave_Click;
                }

                _cmSetupSave = value;
                if (_cmSetupSave != null)
                {
                    _cmSetupSave.Click += cmSetupSave_Click;
                }
            }
        }

        private CheckBox _chkGUIMode;

        internal CheckBox chkGUIMode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkGUIMode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkGUIMode != null)
                {
                    _chkGUIMode.CheckedChanged -= chkGUIMode_CheckedChanged;
                }

                _chkGUIMode = value;
                if (_chkGUIMode != null)
                {
                    _chkGUIMode.CheckedChanged += chkGUIMode_CheckedChanged;
                }
            }
        }

        private CheckBox _chkFoundSound;

        internal CheckBox chkFoundSound
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkFoundSound;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkFoundSound != null)
                {
                    _chkFoundSound.CheckedChanged -= chkFoundSound_CheckedChanged;
                }

                _chkFoundSound = value;
                if (_chkFoundSound != null)
                {
                    _chkFoundSound.CheckedChanged += chkFoundSound_CheckedChanged;
                }
            }
        }

        internal Label lbTime;
        private ComboBox _cboDelay;

        internal ComboBox cboDelay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDelay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDelay != null)
                {
                    _cboDelay.SelectedIndexChanged -= cboDelay_SelectedIndexChanged;
                }

                _cboDelay = value;
                if (_cboDelay != null)
                {
                    _cboDelay.SelectedIndexChanged += cboDelay_SelectedIndexChanged;
                }
            }
        }

        private CheckBox _chkHideMissing;

        internal CheckBox chkHideMissing
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkHideMissing;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkHideMissing != null)
                {
                    _chkHideMissing.CheckedChanged -= chkHideMissing_CheckedChanged;
                }

                _chkHideMissing = value;
                if (_chkHideMissing != null)
                {
                    _chkHideMissing.CheckedChanged += chkHideMissing_CheckedChanged;
                }
            }
        }

        private ToolStripMenuItem _tsmPlayer_Steam;

        internal ToolStripMenuItem tsmPlayer_Steam
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmPlayer_Steam;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmPlayer_Steam != null)
                {
                    _tsmPlayer_Steam.Click -= tsmPlayer_Steam_Click;
                }

                _tsmPlayer_Steam = value;
                if (_tsmPlayer_Steam != null)
                {
                    _tsmPlayer_Steam.Click += tsmPlayer_Steam_Click;
                }
            }
        }

        private Button _cmELO;

        internal Button cmELO
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmELO;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmELO != null)
                {
                    _cmELO.Click -= cmTest_Click;
                }

                _cmELO = value;
                if (_cmELO != null)
                {
                    _cmELO.Click += cmTest_Click;
                }
            }
        }

        private CheckBox _chkShowELO;

        internal CheckBox chkShowELO
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkShowELO;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkShowELO != null)
                {
                    _chkShowELO.CheckedChanged -= chkShowELO_CheckedChanged;
                }

                _chkShowELO = value;
                if (_chkShowELO != null)
                {
                    _chkShowELO.CheckedChanged += chkShowELO_CheckedChanged;
                }
            }
        }

        internal Button cmRID;
        private Timer _timELOCycle;

        internal Timer timELOCycle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _timELOCycle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_timELOCycle != null)
                {
                    _timELOCycle.Tick -= timELOCycle_Tick;
                }

                _timELOCycle = value;
                if (_timELOCycle != null)
                {
                    _timELOCycle.Tick += timELOCycle_Tick;
                }
            }
        }

        private VScrollBar _scrStats;

        internal VScrollBar scrStats
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _scrStats;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_scrStats != null)
                {
                    _scrStats.Scroll -= scrStats_Scroll;
                    _scrStats.ValueChanged -= scrStats_ValueChanged;
                }

                _scrStats = value;
                if (_scrStats != null)
                {
                    _scrStats.Scroll += scrStats_Scroll;
                    _scrStats.ValueChanged += scrStats_ValueChanged;
                }
            }
        }

        private CheckBox _chkSpeech;

        internal CheckBox chkSpeech
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSpeech;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSpeech != null)
                {
                    _chkSpeech.CheckedChanged -= chkSpeech_CheckedChanged;
                }

                _chkSpeech = value;
                if (_chkSpeech != null)
                {
                    _chkSpeech.CheckedChanged += chkSpeech_CheckedChanged;
                }
            }
        }

        private CheckBox _chkGetTeams;

        internal CheckBox chkGetTeams
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkGetTeams;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkGetTeams != null)
                {
                    _chkGetTeams.CheckedChanged -= chkGetTeams_CheckedChanged;
                }

                _chkGetTeams = value;
                if (_chkGetTeams != null)
                {
                    _chkGetTeams.CheckedChanged += chkGetTeams_CheckedChanged;
                }
            }
        }

        internal ListBox lstLog;
        private Button _cmErrLog;

        internal Button cmErrLog
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmErrLog;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmErrLog != null)
                {
                    _cmErrLog.Click -= cmErrLog_Click;
                }

                _cmErrLog = value;
                if (_cmErrLog != null)
                {
                    _cmErrLog.Click += cmErrLog_Click;
                }
            }
        }

        private CheckBox _chkCountry;

        internal CheckBox chkCountry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCountry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCountry != null)
                {
                    _chkCountry.CheckedChanged -= chkCountry_CheckedChanged;
                }

                _chkCountry = value;
                if (_chkCountry != null)
                {
                    _chkCountry.CheckedChanged += chkCountry_CheckedChanged;
                }
            }
        }

        internal StatusStrip SS1;
        internal ToolStripStatusLabel SS1_Version;
        internal ToolStripStatusLabel SS1_Filename;
        internal ToolStripStatusLabel SS1_Sep1;
        internal ToolStripStatusLabel SS1_Sep2;
        internal ToolStripStatusLabel SS1_Time;
        internal ToolStripStatusLabel SS1_Sep3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CheckBox _chkToggleOverlay;
    }
}