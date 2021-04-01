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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            _cmCheckLog = new Button();
            _cmCheckLog.Click += new EventHandler(cmCheckLog_Click);
            lbStatus = new Label();
            pbFact01 = new PictureBox();
            pbFact02 = new PictureBox();
            pbFact03 = new PictureBox();
            pbFact04 = new PictureBox();
            pbFact05 = new PictureBox();
            lbSteam01 = new Label();
            lbSteam02 = new Label();
            lbSteam03 = new Label();
            lbSteam04 = new Label();
            lbSteam05 = new Label();
            lbSteam06 = new Label();
            lbSteam07 = new Label();
            lbSteam08 = new Label();
            ColorDialog1 = new ColorDialog();
            OpenFileDialog1 = new OpenFileDialog();
            _Timer1 = new Timer(components);
            _Timer1.Tick += new EventHandler(Timer1_Tick);
            _cmFindLog = new Button();
            _cmFindLog.Click += new EventHandler(cmFindLog_Click);
            _cmScanLog = new Button();
            _cmScanLog.Click += new EventHandler(cmScanLog_Click);
            _cmCopy = new Button();
            _cmCopy.Click += new EventHandler(cmCopy_Click);
            Label2 = new Label();
            FontDialog1 = new FontDialog();
            _cmAbout = new Button();
            _cmAbout.Click += new EventHandler(cmAbout_Click);
            Label3 = new Label();
            Label4 = new Label();
            _cboLayoutY = new ComboBox();
            _cboLayoutY.SelectedIndexChanged += new EventHandler(cboLayoutY_SelectedIndexChanged);
            gbRank = new GroupBox();
            _cmELO = new Button();
            _cmELO.Click += new EventHandler(cmTest_Click);
            _cmSetupSave = new Button();
            _cmSetupSave.Click += new EventHandler(cmSetupSave_Click);
            _cmSetupLoad = new Button();
            _cmSetupLoad.Click += new EventHandler(cmSetupLoad_Click);
            _cmNote_PlayAll = new Button();
            _cmNote_PlayAll.Click += new EventHandler(cmNote_PlayAll_Click);
            _cmNote04_Play = new Button();
            _cmNote04_Play.Click += new EventHandler(cmNote04_Play_Click);
            _cmNote03_Play = new Button();
            _cmNote03_Play.Click += new EventHandler(cmNote03_Play_Click);
            _cmNote02_Play = new Button();
            _cmNote02_Play.Click += new EventHandler(cmNote02_Play_Click);
            _cmNote01_Play = new Button();
            _cmNote01_Play.Click += new EventHandler(cmNote01_Play_Click);
            _cmNote4 = new Button();
            _cmNote4.Click += new EventHandler(cmNote4_Click);
            _cmNote04Setup = new Button();
            _cmNote04Setup.Click += new EventHandler(cmNote04Setup_Click_1);
            Label14 = new Label();
            _cmNote3 = new Button();
            _cmNote3.Click += new EventHandler(cmNote3_Click);
            _cmNote2 = new Button();
            _cmNote2.Click += new EventHandler(cmNote2_Click);
            _cmNote1 = new Button();
            _cmNote1.Click += new EventHandler(cmNote1_Click);
            _cmNote03Setup = new Button();
            _cmNote03Setup.Click += new EventHandler(cmNote03Setup_Click_1);
            _cmNote02Setup = new Button();
            _cmNote02Setup.Click += new EventHandler(cmNote02Setup_Click_1);
            Label13 = new Label();
            Label12 = new Label();
            _cmNote01Setup = new Button();
            _cmNote01Setup.Click += new EventHandler(cmNote01Setup_Click_1);
            Label11 = new Label();
            _cmNameSetup = new Button();
            _cmNameSetup.Click += new EventHandler(cmNameSetup_Click);
            Label10 = new Label();
            Label9 = new Label();
            _cmRankSetup = new Button();
            _cmRankSetup.Click += new EventHandler(cmRankSetup_Click);
            _cmSave = new Button();
            _cmSave.Click += new EventHandler(cmSave_Click);
            gbLayout = new GroupBox();
            _cmStatsModeHelp = new Button();
            _cmStatsModeHelp.Click += new EventHandler(cmStatsModeHelp_Click);
            _cmDefaults = new Button();
            _cmDefaults.Click += new EventHandler(cmDefaults_Click);
            _tbYSize = new TextBox();
            _tbYSize.TextChanged += new EventHandler(tbYSize_TextChanged);
            _tbYSize.KeyPress += new KeyPressEventHandler(tbYSize_KeyPress);
            _tbXsize = new TextBox();
            _tbXsize.TextChanged += new EventHandler(tbXsize_TextChanged);
            _tbXsize.KeyPress += new KeyPressEventHandler(tbXsize_KeyPress);
            _tbYoff = new TextBox();
            _tbYoff.KeyPress += new KeyPressEventHandler(tbYoff_KeyPress);
            _tbYoff.TextChanged += new EventHandler(tbYoff_TextChanged);
            _tbXoff = new TextBox();
            _tbXoff.KeyPress += new KeyPressEventHandler(tbXoff_KeyPress);
            _tbXoff.TextChanged += new EventHandler(tbXoff_TextChanged);
            Label7 = new Label();
            _cboNoteSpace = new ComboBox();
            _cboNoteSpace.SelectedIndexChanged += new EventHandler(cboNoteSpace_SelectedIndexChanged);
            _chkGUIMode = new CheckBox();
            _chkGUIMode.CheckedChanged += new EventHandler(chkGUIMode_CheckedChanged);
            Label5 = new Label();
            _cmSizeRefresh = new Button();
            _cmSizeRefresh.Click += new EventHandler(cmSizeRefresh_Click);
            _cboLayoutX = new ComboBox();
            _cboLayoutX.SelectedIndexChanged += new EventHandler(cboLayoutX_SelectedIndexChanged);
            Label6 = new Label();
            _pbStats = new PictureBox();
            _pbStats.Click += new EventHandler(pbStats_Click);
            _pbStats.MouseDown += new MouseEventHandler(pbStats_MouseDown);
            _pbStats.MouseLeave += new EventHandler(pbStats_MouseLeave);
            _pbStats.MouseMove += new MouseEventHandler(pbStats_MouseMove);
            _pbStats.MouseWheel += new MouseEventHandler(pbStats_MouseWheel);
            _cmTestData = new Button();
            _cmTestData.Click += new EventHandler(cmTestData_Click);
            _cmLastMatch = new Button();
            _cmLastMatch.Click += new EventHandler(cmLastMatch_Click);
            gbFX = new GroupBox();
            cmRID = new Button();
            _chkFX = new CheckBox();
            _chkFX.CheckedChanged += new EventHandler(chkFX_CheckedChanged);
            Label1 = new Label();
            _cmFXModeHelp = new Button();
            _cmFXModeHelp.Click += new EventHandler(cmFXModeHelp_Click);
            _cboFXVar1 = new ComboBox();
            _cboFXVar1.SelectedIndexChanged += new EventHandler(cboFXMode_SelectedIndexChanged);
            lbFXVar1 = new Label();
            _cboFxVar3 = new ComboBox();
            _cboFxVar3.SelectedIndexChanged += new EventHandler(cboFxVar3_SelectedIndexChanged);
            lbFXVar3 = new Label();
            _cboFxVar4 = new ComboBox();
            _cboFxVar4.SelectedIndexChanged += new EventHandler(cboFxVar4_SelectedIndexChanged);
            _cmFX3DC = new Button();
            _cmFX3DC.Click += new EventHandler(cmFX3DC_Click);
            _cboFXVar2 = new ComboBox();
            _cboFXVar2.SelectedIndexChanged += new EventHandler(cboFX3D_SelectedIndexChanged);
            lbFXVar2 = new Label();
            lbFXVar4 = new Label();
            _chkMismatch = new CheckBox();
            _chkMismatch.CheckedChanged += new EventHandler(chkMismatch_CheckedChanged);
            lbError1 = new Label();
            lbError2 = new Label();
            SaveFileDialog1 = new SaveFileDialog();
            ToolTip1 = new ToolTip(components);
            _chkTips = new CheckBox();
            _chkTips.CheckedChanged += new EventHandler(chkTips_CheckedChanged);
            pbNote1 = new PictureBox();
            _timNote1 = new Timer(components);
            _timNote1.Tick += new EventHandler(timNote1_Tick);
            gbSound = new GroupBox();
            _cmAudioStop = new Button();
            _cmAudioStop.Click += new EventHandler(cmAudioStop_Click);
            lbVolume = new Label();
            _scrVolume = new HScrollBar();
            _scrVolume.ValueChanged += new EventHandler(scrVolume_ValueChanged);
            _cmSound15 = new Button();
            _cmSound15.MouseDown += new MouseEventHandler(cmSound15_MouseDown);
            _cmSound15.MouseHover += new EventHandler(cmSound15_MouseHover);
            _cmSound15.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound14 = new Button();
            _cmSound14.MouseDown += new MouseEventHandler(cmSound14_MouseDown);
            _cmSound14.MouseHover += new EventHandler(cmSound14_MouseHover);
            _cmSound14.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound13 = new Button();
            _cmSound13.MouseDown += new MouseEventHandler(cmSound13_MouseDown);
            _cmSound13.MouseHover += new EventHandler(cmSound13_MouseHover);
            _cmSound13.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound12 = new Button();
            _cmSound12.MouseDown += new MouseEventHandler(cmSound12_MouseDown);
            _cmSound12.MouseHover += new EventHandler(cmSound12_MouseHover);
            _cmSound12.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound11 = new Button();
            _cmSound11.MouseDown += new MouseEventHandler(cmSound11_MouseDown);
            _cmSound11.MouseHover += new EventHandler(cmSound11_MouseHover);
            _cmSound11.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            lbSoundCurrent = new Label();
            _cmSound10 = new Button();
            _cmSound10.MouseDown += new MouseEventHandler(cmSound10_MouseDown);
            _cmSound10.MouseHover += new EventHandler(cmSound10_MouseHover);
            _cmSound10.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound09 = new Button();
            _cmSound09.MouseDown += new MouseEventHandler(cmSound09_MouseDown);
            _cmSound09.MouseHover += new EventHandler(cmSound09_MouseHover);
            _cmSound09.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound08 = new Button();
            _cmSound08.MouseDown += new MouseEventHandler(cmSound08_MouseDown);
            _cmSound08.MouseHover += new EventHandler(cmSound08_MouseHover);
            _cmSound08.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound07 = new Button();
            _cmSound07.MouseDown += new MouseEventHandler(cmSound07_MouseDown);
            _cmSound07.MouseHover += new EventHandler(cmSound07_MouseHover);
            _cmSound07.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound06 = new Button();
            _cmSound06.MouseDown += new MouseEventHandler(cmSound06_MouseDown);
            _cmSound06.MouseHover += new EventHandler(cmSound06_MouseHover);
            _cmSound06.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound05 = new Button();
            _cmSound05.MouseDown += new MouseEventHandler(cmSound05_MouseDown);
            _cmSound05.MouseHover += new EventHandler(cmSound05_MouseHover);
            _cmSound05.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound04 = new Button();
            _cmSound04.MouseDown += new MouseEventHandler(cmSound04_MouseDown);
            _cmSound04.MouseHover += new EventHandler(cmSound04_MouseHover);
            _cmSound04.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound03 = new Button();
            _cmSound03.MouseDown += new MouseEventHandler(cmSound03_MouseDown);
            _cmSound03.MouseHover += new EventHandler(cmSound03_MouseHover);
            _cmSound03.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound02 = new Button();
            _cmSound02.MouseDown += new MouseEventHandler(cmSound02_MouseDown);
            _cmSound02.MouseHover += new EventHandler(cmSound02_MouseHover);
            _cmSound02.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            _cmSound01 = new Button();
            _cmSound01.Click += new EventHandler(cmSound01_Click);
            _cmSound01.MouseDown += new MouseEventHandler(cmSound01_MouseDown);
            _cmSound01.MouseHover += new EventHandler(cmSound01_MouseHover);
            _cmSound01.MouseLeave += new EventHandler(cmSound01_MouseLeave);
            pbNote3 = new PictureBox();
            pbNote4 = new PictureBox();
            pbNote2 = new PictureBox();
            chkPosition = new CheckBox();
            tsmPlayer = new ContextMenuStrip(components);
            _tsmPlayer_Relic = new ToolStripMenuItem();
            _tsmPlayer_Relic.Click += new EventHandler(tsmPlayer_Relic_Click);
            _tsmPlayer_OrgAT = new ToolStripMenuItem();
            _tsmPlayer_OrgAT.Click += new EventHandler(tsmPlayer_OrgAT_Click);
            _tsmPlayer_OrgFaction = new ToolStripMenuItem();
            _tsmPlayer_OrgFaction.Click += new EventHandler(tsmPlayer_OrgFaction_Click);
            _tsmPlayer_OrgPlayercard = new ToolStripMenuItem();
            _tsmPlayer_OrgPlayercard.Click += new EventHandler(tsmPlayer_OrgPlayercard_Click);
            _tsmPlayer_Google = new ToolStripMenuItem();
            _tsmPlayer_Google.Click += new EventHandler(tsmPlayer_Google_Click);
            _tsmPlayer_Steam = new ToolStripMenuItem();
            _tsmPlayer_Steam.Click += new EventHandler(tsmPlayer_Steam_Click);
            _chkPopUp = new CheckBox();
            _chkPopUp.CheckedChanged += new EventHandler(chkPopUp_CheckedChanged);
            tsmAudio = new ContextMenuStrip(components);
            _tsmSetVolTo100 = new ToolStripMenuItem();
            _tsmSetVolTo100.Click += new EventHandler(tsmSetVolTo100_Click);
            _tsmSetVolTo90 = new ToolStripMenuItem();
            _tsmSetVolTo90.Click += new EventHandler(tsmSetVolTo90_Click);
            _tsmSetVolTo80 = new ToolStripMenuItem();
            _tsmSetVolTo80.Click += new EventHandler(tsmSetVolTo80_Click);
            _tsmSetVolTo70 = new ToolStripMenuItem();
            _tsmSetVolTo70.Click += new EventHandler(tsmSetVolTo70_Click);
            _tsmSetVolTo60 = new ToolStripMenuItem();
            _tsmSetVolTo60.Click += new EventHandler(tsmSetVolTo60_Click);
            _tsmSetVolTo50 = new ToolStripMenuItem();
            _tsmSetVolTo50.Click += new EventHandler(tsmSetVolTo50_Click);
            _tsmSetVolTo40 = new ToolStripMenuItem();
            _tsmSetVolTo40.Click += new EventHandler(tsmSetVolTo40_Click);
            _tsmSetVolTo30 = new ToolStripMenuItem();
            _tsmSetVolTo30.Click += new EventHandler(tsmSetVolTo30_Click);
            _tsmSetVolTo20 = new ToolStripMenuItem();
            _tsmSetVolTo20.Click += new EventHandler(tsmSetVolTo20_Click);
            _tsmSetVolTo10 = new ToolStripMenuItem();
            _tsmSetVolTo10.Click += new EventHandler(tsmSetVolTo10_Click);
            ToolStripMenuItem1 = new ToolStripSeparator();
            _tsmSelectFile = new ToolStripMenuItem();
            _tsmSelectFile.Click += new EventHandler(tsmSelectFile_Click);
            _chkSmoothAni = new CheckBox();
            _chkSmoothAni.CheckedChanged += new EventHandler(chkSmoothAni_CheckedChanged);
            _chkFoundSound = new CheckBox();
            _chkFoundSound.CheckedChanged += new EventHandler(chkFoundSound_CheckedChanged);
            lbTime = new Label();
            _cboDelay = new ComboBox();
            _cboDelay.SelectedIndexChanged += new EventHandler(cboDelay_SelectedIndexChanged);
            _chkHideMissing = new CheckBox();
            _chkHideMissing.CheckedChanged += new EventHandler(chkHideMissing_CheckedChanged);
            _chkShowELO = new CheckBox();
            _chkShowELO.CheckedChanged += new EventHandler(chkShowELO_CheckedChanged);
            _timELOCycle = new Timer(components);
            _timELOCycle.Tick += new EventHandler(timELOCycle_Tick);
            _scrStats = new VScrollBar();
            _scrStats.Scroll += new ScrollEventHandler(scrStats_Scroll);
            _scrStats.ValueChanged += new EventHandler(scrStats_ValueChanged);
            _chkSpeech = new CheckBox();
            _chkSpeech.CheckedChanged += new EventHandler(chkSpeech_CheckedChanged);
            _chkGetTeams = new CheckBox();
            _chkGetTeams.CheckedChanged += new EventHandler(chkGetTeams_CheckedChanged);
            lstLog = new ListBox();
            _cmErrLog = new Button();
            _cmErrLog.Click += new EventHandler(cmErrLog_Click);
            _chkCountry = new CheckBox();
            _chkCountry.CheckedChanged += new EventHandler(chkCountry_CheckedChanged);
            SS1 = new StatusStrip();
            SS1_Version = new ToolStripStatusLabel();
            SS1_Sep1 = new ToolStripStatusLabel();
            SS1_Filename = new ToolStripStatusLabel();
            SS1_Sep2 = new ToolStripStatusLabel();
            SS1_Time = new ToolStripStatusLabel();
            SS1_Sep3 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)pbFact01).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFact02).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFact03).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFact04).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFact05).BeginInit();
            gbRank.SuspendLayout();
            gbLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_pbStats).BeginInit();
            gbFX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbNote1).BeginInit();
            gbSound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbNote3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNote4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNote2).BeginInit();
            tsmPlayer.SuspendLayout();
            tsmAudio.SuspendLayout();
            SS1.SuspendLayout();
            SuspendLayout();
            // 
            // cmCheckLog
            // 
            _cmCheckLog.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCheckLog.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCheckLog.FlatStyle = FlatStyle.Flat;
            _cmCheckLog.ForeColor = Color.Black;
            _cmCheckLog.Location = new Point(10, 35);
            _cmCheckLog.Name = "_cmCheckLog";
            _cmCheckLog.Size = new Size(111, 30);
            _cmCheckLog.TabIndex = 1;
            _cmCheckLog.Text = "Check Log File";
            _cmCheckLog.UseVisualStyleBackColor = false;
            // 
            // lbStatus
            // 
            lbStatus.BackColor = Color.Silver;
            lbStatus.BorderStyle = BorderStyle.FixedSingle;
            lbStatus.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbStatus.ForeColor = Color.Black;
            lbStatus.Location = new Point(880, 15);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(235, 25);
            lbStatus.TabIndex = 25;
            lbStatus.Text = "Ready.";
            lbStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbFact01
            // 
            pbFact01.BackgroundImageLayout = ImageLayout.None;
            pbFact01.Image = (Image)resources.GetObject("pbFact01.Image");
            pbFact01.Location = new Point(1378, 192);
            pbFact01.Name = "pbFact01";
            pbFact01.Size = new Size(95, 95);
            pbFact01.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFact01.TabIndex = 26;
            pbFact01.TabStop = false;
            pbFact01.Visible = false;
            // 
            // pbFact02
            // 
            pbFact02.BackgroundImageLayout = ImageLayout.None;
            pbFact02.Image = (Image)resources.GetObject("pbFact02.Image");
            pbFact02.Location = new Point(1296, 192);
            pbFact02.Name = "pbFact02";
            pbFact02.Size = new Size(95, 95);
            pbFact02.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFact02.TabIndex = 27;
            pbFact02.TabStop = false;
            pbFact02.Visible = false;
            // 
            // pbFact03
            // 
            pbFact03.BackgroundImageLayout = ImageLayout.None;
            pbFact03.Image = (Image)resources.GetObject("pbFact03.Image");
            pbFact03.Location = new Point(1378, 279);
            pbFact03.Name = "pbFact03";
            pbFact03.Size = new Size(95, 95);
            pbFact03.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFact03.TabIndex = 28;
            pbFact03.TabStop = false;
            pbFact03.Visible = false;
            // 
            // pbFact04
            // 
            pbFact04.BackgroundImageLayout = ImageLayout.None;
            pbFact04.Image = (Image)resources.GetObject("pbFact04.Image");
            pbFact04.Location = new Point(1460, 279);
            pbFact04.Name = "pbFact04";
            pbFact04.Size = new Size(95, 95);
            pbFact04.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFact04.TabIndex = 29;
            pbFact04.TabStop = false;
            pbFact04.Visible = false;
            // 
            // pbFact05
            // 
            pbFact05.BackgroundImageLayout = ImageLayout.None;
            pbFact05.Image = (Image)resources.GetObject("pbFact05.Image");
            pbFact05.Location = new Point(1296, 279);
            pbFact05.Name = "pbFact05";
            pbFact05.Size = new Size(95, 95);
            pbFact05.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFact05.TabIndex = 30;
            pbFact05.TabStop = false;
            pbFact05.Visible = false;
            // 
            // lbSteam01
            // 
            lbSteam01.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            lbSteam01.Font = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbSteam01.Location = new Point(1465, 200);
            lbSteam01.Name = "lbSteam01";
            lbSteam01.Size = new Size(50, 23);
            lbSteam01.TabIndex = 39;
            lbSteam01.Visible = false;
            // 
            // lbSteam02
            // 
            lbSteam02.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            lbSteam02.Font = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbSteam02.Location = new Point(1465, 223);
            lbSteam02.Name = "lbSteam02";
            lbSteam02.Size = new Size(50, 23);
            lbSteam02.TabIndex = 40;
            lbSteam02.Visible = false;
            // 
            // lbSteam03
            // 
            lbSteam03.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            lbSteam03.Font = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbSteam03.Location = new Point(1465, 246);
            lbSteam03.Name = "lbSteam03";
            lbSteam03.Size = new Size(50, 23);
            lbSteam03.TabIndex = 41;
            lbSteam03.Visible = false;
            // 
            // lbSteam04
            // 
            lbSteam04.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            lbSteam04.Font = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbSteam04.Location = new Point(1465, 269);
            lbSteam04.Name = "lbSteam04";
            lbSteam04.Size = new Size(50, 23);
            lbSteam04.TabIndex = 42;
            lbSteam04.Visible = false;
            // 
            // lbSteam05
            // 
            lbSteam05.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            lbSteam05.Font = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbSteam05.Location = new Point(1519, 200);
            lbSteam05.Name = "lbSteam05";
            lbSteam05.Size = new Size(50, 23);
            lbSteam05.TabIndex = 43;
            lbSteam05.Visible = false;
            // 
            // lbSteam06
            // 
            lbSteam06.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            lbSteam06.Font = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbSteam06.Location = new Point(1519, 223);
            lbSteam06.Name = "lbSteam06";
            lbSteam06.Size = new Size(50, 23);
            lbSteam06.TabIndex = 44;
            lbSteam06.Visible = false;
            // 
            // lbSteam07
            // 
            lbSteam07.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            lbSteam07.Font = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbSteam07.Location = new Point(1519, 246);
            lbSteam07.Name = "lbSteam07";
            lbSteam07.Size = new Size(50, 23);
            lbSteam07.TabIndex = 45;
            lbSteam07.Visible = false;
            // 
            // lbSteam08
            // 
            lbSteam08.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            lbSteam08.Font = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbSteam08.Location = new Point(1519, 269);
            lbSteam08.Name = "lbSteam08";
            lbSteam08.Size = new Size(50, 23);
            lbSteam08.TabIndex = 46;
            lbSteam08.Visible = false;
            // 
            // OpenFileDialog1
            // 
            OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // Timer1
            // 
            _Timer1.Interval = 1000;
            // 
            // cmFindLog
            // 
            _cmFindLog.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFindLog.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFindLog.FlatStyle = FlatStyle.Flat;
            _cmFindLog.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _cmFindLog.ForeColor = Color.Black;
            _cmFindLog.Location = new Point(10, 6);
            _cmFindLog.Name = "_cmFindLog";
            _cmFindLog.Size = new Size(111, 26);
            _cmFindLog.TabIndex = 0;
            _cmFindLog.Text = "Find Log File";
            _cmFindLog.UseVisualStyleBackColor = false;
            // 
            // cmScanLog
            // 
            _cmScanLog.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmScanLog.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmScanLog.FlatStyle = FlatStyle.Flat;
            _cmScanLog.ForeColor = Color.Black;
            _cmScanLog.Location = new Point(10, 115);
            _cmScanLog.Name = "_cmScanLog";
            _cmScanLog.Size = new Size(111, 46);
            _cmScanLog.TabIndex = 2;
            _cmScanLog.Text = "Auto Scan Log";
            _cmScanLog.UseVisualStyleBackColor = false;
            // 
            // cmCopy
            // 
            _cmCopy.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy.FlatStyle = FlatStyle.Flat;
            _cmCopy.ForeColor = Color.Black;
            _cmCopy.Location = new Point(880, 120);
            _cmCopy.Name = "_cmCopy";
            _cmCopy.Size = new Size(105, 23);
            _cmCopy.TabIndex = 6;
            _cmCopy.Text = "Copy Stats Image";
            _cmCopy.UseVisualStyleBackColor = false;
            // 
            // Label2
            // 
            Label2.Location = new Point(880, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(235, 13);
            Label2.TabIndex = 61;
            Label2.Text = "Scan Status";
            Label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmAbout
            // 
            _cmAbout.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmAbout.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmAbout.FlatStyle = FlatStyle.Flat;
            _cmAbout.ForeColor = Color.Black;
            _cmAbout.Location = new Point(880, 45);
            _cmAbout.Name = "_cmAbout";
            _cmAbout.Size = new Size(105, 23);
            _cmAbout.TabIndex = 3;
            _cmAbout.Text = "About";
            _cmAbout.UseVisualStyleBackColor = false;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label3.Location = new Point(5, 20);
            Label3.Name = "Label3";
            Label3.Size = new Size(44, 13);
            Label3.TabIndex = 66;
            Label3.Text = "XY Size";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label4.Location = new Point(5, 95);
            Label4.Name = "Label4";
            Label4.Size = new Size(49, 13);
            Label4.TabIndex = 70;
            Label4.Text = "Y Layout";
            // 
            // cboLayoutY
            // 
            _cboLayoutY.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboLayoutY.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLayoutY.ForeColor = Color.White;
            _cboLayoutY.FormattingEnabled = true;
            _cboLayoutY.Location = new Point(60, 90);
            _cboLayoutY.Name = "_cboLayoutY";
            _cboLayoutY.Size = new Size(126, 21);
            _cboLayoutY.TabIndex = 23;
            // 
            // gbRank
            // 
            gbRank.Controls.Add(_cmELO);
            gbRank.Controls.Add(_cmSetupSave);
            gbRank.Controls.Add(_cmSetupLoad);
            gbRank.Controls.Add(_cmNote_PlayAll);
            gbRank.Controls.Add(_cmNote04_Play);
            gbRank.Controls.Add(_cmNote03_Play);
            gbRank.Controls.Add(_cmNote02_Play);
            gbRank.Controls.Add(_cmNote01_Play);
            gbRank.Controls.Add(_cmNote4);
            gbRank.Controls.Add(_cmNote04Setup);
            gbRank.Controls.Add(Label14);
            gbRank.Controls.Add(_cmNote3);
            gbRank.Controls.Add(_cmNote2);
            gbRank.Controls.Add(_cmNote1);
            gbRank.Controls.Add(_cmNote03Setup);
            gbRank.Controls.Add(_cmNote02Setup);
            gbRank.Controls.Add(Label13);
            gbRank.Controls.Add(Label12);
            gbRank.Controls.Add(_cmNote01Setup);
            gbRank.Controls.Add(Label11);
            gbRank.Controls.Add(_cmNameSetup);
            gbRank.Controls.Add(Label10);
            gbRank.Controls.Add(Label9);
            gbRank.Controls.Add(_cmRankSetup);
            gbRank.ForeColor = Color.Black;
            gbRank.Location = new Point(130, 0);
            gbRank.Name = "gbRank";
            gbRank.Size = new Size(198, 195);
            gbRank.TabIndex = 73;
            gbRank.TabStop = false;
            gbRank.Text = "Stats and Note Setups";
            // 
            // cmELO
            // 
            _cmELO.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmELO.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmELO.FlatStyle = FlatStyle.Flat;
            _cmELO.ForeColor = Color.Black;
            _cmELO.Location = new Point(100, 15);
            _cmELO.Name = "_cmELO";
            _cmELO.Size = new Size(50, 23);
            _cmELO.TabIndex = 94;
            _cmELO.Text = "ELO";
            _cmELO.UseVisualStyleBackColor = false;
            // 
            // cmSetupSave
            // 
            _cmSetupSave.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSetupSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSetupSave.FlatStyle = FlatStyle.Flat;
            _cmSetupSave.ForeColor = Color.Black;
            _cmSetupSave.Location = new Point(100, 165);
            _cmSetupSave.Name = "_cmSetupSave";
            _cmSetupSave.Size = new Size(85, 23);
            _cmSetupSave.TabIndex = 125;
            _cmSetupSave.Text = "Save Setup";
            _cmSetupSave.UseVisualStyleBackColor = false;
            // 
            // cmSetupLoad
            // 
            _cmSetupLoad.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSetupLoad.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSetupLoad.FlatStyle = FlatStyle.Flat;
            _cmSetupLoad.ForeColor = Color.Black;
            _cmSetupLoad.Location = new Point(5, 165);
            _cmSetupLoad.Name = "_cmSetupLoad";
            _cmSetupLoad.Size = new Size(90, 23);
            _cmSetupLoad.TabIndex = 124;
            _cmSetupLoad.Text = "Load Setup";
            _cmSetupLoad.UseVisualStyleBackColor = false;
            // 
            // cmNote_PlayAll
            // 
            _cmNote_PlayAll.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote_PlayAll.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote_PlayAll.FlatStyle = FlatStyle.Flat;
            _cmNote_PlayAll.ForeColor = Color.Black;
            _cmNote_PlayAll.Location = new Point(155, 40);
            _cmNote_PlayAll.Name = "_cmNote_PlayAll";
            _cmNote_PlayAll.Size = new Size(30, 23);
            _cmNote_PlayAll.TabIndex = 10;
            _cmNote_PlayAll.Text = ">";
            _cmNote_PlayAll.UseVisualStyleBackColor = false;
            // 
            // cmNote04_Play
            // 
            _cmNote04_Play.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote04_Play.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote04_Play.FlatStyle = FlatStyle.Flat;
            _cmNote04_Play.ForeColor = Color.Black;
            _cmNote04_Play.Location = new Point(155, 140);
            _cmNote04_Play.Name = "_cmNote04_Play";
            _cmNote04_Play.Size = new Size(30, 23);
            _cmNote04_Play.TabIndex = 14;
            _cmNote04_Play.Text = ">";
            _cmNote04_Play.UseVisualStyleBackColor = false;
            // 
            // cmNote03_Play
            // 
            _cmNote03_Play.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote03_Play.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote03_Play.FlatStyle = FlatStyle.Flat;
            _cmNote03_Play.ForeColor = Color.Black;
            _cmNote03_Play.Location = new Point(155, 115);
            _cmNote03_Play.Name = "_cmNote03_Play";
            _cmNote03_Play.Size = new Size(30, 23);
            _cmNote03_Play.TabIndex = 13;
            _cmNote03_Play.Text = ">";
            _cmNote03_Play.UseVisualStyleBackColor = false;
            // 
            // cmNote02_Play
            // 
            _cmNote02_Play.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote02_Play.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote02_Play.FlatStyle = FlatStyle.Flat;
            _cmNote02_Play.ForeColor = Color.Black;
            _cmNote02_Play.Location = new Point(155, 90);
            _cmNote02_Play.Name = "_cmNote02_Play";
            _cmNote02_Play.Size = new Size(30, 23);
            _cmNote02_Play.TabIndex = 12;
            _cmNote02_Play.Text = ">";
            _cmNote02_Play.UseVisualStyleBackColor = false;
            // 
            // cmNote01_Play
            // 
            _cmNote01_Play.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote01_Play.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote01_Play.FlatStyle = FlatStyle.Flat;
            _cmNote01_Play.ForeColor = Color.Black;
            _cmNote01_Play.Location = new Point(155, 65);
            _cmNote01_Play.Name = "_cmNote01_Play";
            _cmNote01_Play.Size = new Size(30, 23);
            _cmNote01_Play.TabIndex = 11;
            _cmNote01_Play.Text = ">";
            _cmNote01_Play.UseVisualStyleBackColor = false;
            // 
            // cmNote4
            // 
            _cmNote4.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote4.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote4.FlatStyle = FlatStyle.Flat;
            _cmNote4.ForeColor = Color.Black;
            _cmNote4.Location = new Point(100, 140);
            _cmNote4.Name = "_cmNote4";
            _cmNote4.Size = new Size(50, 23);
            _cmNote4.TabIndex = 9;
            _cmNote4.Text = "Notes";
            _cmNote4.UseVisualStyleBackColor = false;
            // 
            // cmNote04Setup
            // 
            _cmNote04Setup.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote04Setup.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote04Setup.FlatStyle = FlatStyle.Flat;
            _cmNote04Setup.ForeColor = Color.Black;
            _cmNote04Setup.Location = new Point(45, 140);
            _cmNote04Setup.Name = "_cmNote04Setup";
            _cmNote04Setup.Size = new Size(50, 23);
            _cmNote04Setup.TabIndex = 8;
            _cmNote04Setup.Text = "Setup";
            _cmNote04Setup.UseVisualStyleBackColor = false;
            // 
            // Label14
            // 
            Label14.AutoSize = true;
            Label14.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label14.Location = new Point(5, 145);
            Label14.Name = "Label14";
            Label14.Size = new Size(39, 13);
            Label14.TabIndex = 123;
            Label14.Text = "Note 4";
            // 
            // cmNote3
            // 
            _cmNote3.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote3.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote3.FlatStyle = FlatStyle.Flat;
            _cmNote3.ForeColor = Color.Black;
            _cmNote3.Location = new Point(100, 115);
            _cmNote3.Name = "_cmNote3";
            _cmNote3.Size = new Size(50, 23);
            _cmNote3.TabIndex = 7;
            _cmNote3.Text = "Notes";
            _cmNote3.UseVisualStyleBackColor = false;
            // 
            // cmNote2
            // 
            _cmNote2.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote2.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote2.FlatStyle = FlatStyle.Flat;
            _cmNote2.ForeColor = Color.Black;
            _cmNote2.Location = new Point(100, 90);
            _cmNote2.Name = "_cmNote2";
            _cmNote2.Size = new Size(50, 23);
            _cmNote2.TabIndex = 5;
            _cmNote2.Text = "Notes";
            _cmNote2.UseVisualStyleBackColor = false;
            // 
            // cmNote1
            // 
            _cmNote1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote1.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote1.FlatStyle = FlatStyle.Flat;
            _cmNote1.ForeColor = Color.Black;
            _cmNote1.Location = new Point(100, 65);
            _cmNote1.Name = "_cmNote1";
            _cmNote1.Size = new Size(50, 23);
            _cmNote1.TabIndex = 3;
            _cmNote1.Text = "Notes";
            _cmNote1.UseVisualStyleBackColor = false;
            // 
            // cmNote03Setup
            // 
            _cmNote03Setup.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote03Setup.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote03Setup.FlatStyle = FlatStyle.Flat;
            _cmNote03Setup.ForeColor = Color.Black;
            _cmNote03Setup.Location = new Point(45, 115);
            _cmNote03Setup.Name = "_cmNote03Setup";
            _cmNote03Setup.Size = new Size(50, 23);
            _cmNote03Setup.TabIndex = 6;
            _cmNote03Setup.Text = "Setup";
            _cmNote03Setup.UseVisualStyleBackColor = false;
            // 
            // cmNote02Setup
            // 
            _cmNote02Setup.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote02Setup.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote02Setup.FlatStyle = FlatStyle.Flat;
            _cmNote02Setup.ForeColor = Color.Black;
            _cmNote02Setup.Location = new Point(45, 90);
            _cmNote02Setup.Name = "_cmNote02Setup";
            _cmNote02Setup.Size = new Size(50, 23);
            _cmNote02Setup.TabIndex = 4;
            _cmNote02Setup.Text = "Setup";
            _cmNote02Setup.UseVisualStyleBackColor = false;
            // 
            // Label13
            // 
            Label13.AutoSize = true;
            Label13.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label13.Location = new Point(5, 120);
            Label13.Name = "Label13";
            Label13.Size = new Size(39, 13);
            Label13.TabIndex = 117;
            Label13.Text = "Note 3";
            // 
            // Label12
            // 
            Label12.AutoSize = true;
            Label12.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label12.Location = new Point(5, 95);
            Label12.Name = "Label12";
            Label12.Size = new Size(39, 13);
            Label12.TabIndex = 116;
            Label12.Text = "Note 2";
            // 
            // cmNote01Setup
            // 
            _cmNote01Setup.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote01Setup.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNote01Setup.FlatStyle = FlatStyle.Flat;
            _cmNote01Setup.ForeColor = Color.Black;
            _cmNote01Setup.Location = new Point(45, 65);
            _cmNote01Setup.Name = "_cmNote01Setup";
            _cmNote01Setup.Size = new Size(50, 23);
            _cmNote01Setup.TabIndex = 2;
            _cmNote01Setup.Text = "Setup";
            _cmNote01Setup.UseVisualStyleBackColor = false;
            // 
            // Label11
            // 
            Label11.AutoSize = true;
            Label11.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label11.Location = new Point(5, 70);
            Label11.Name = "Label11";
            Label11.Size = new Size(39, 13);
            Label11.TabIndex = 114;
            Label11.Text = "Note 1";
            // 
            // cmNameSetup
            // 
            _cmNameSetup.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNameSetup.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNameSetup.FlatStyle = FlatStyle.Flat;
            _cmNameSetup.ForeColor = Color.Black;
            _cmNameSetup.Location = new Point(45, 40);
            _cmNameSetup.Name = "_cmNameSetup";
            _cmNameSetup.Size = new Size(50, 23);
            _cmNameSetup.TabIndex = 1;
            _cmNameSetup.Text = "Setup";
            _cmNameSetup.UseVisualStyleBackColor = false;
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label10.Location = new Point(5, 45);
            Label10.Name = "Label10";
            Label10.Size = new Size(35, 13);
            Label10.TabIndex = 111;
            Label10.Text = "Name";
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label9.Location = new Point(5, 20);
            Label9.Name = "Label9";
            Label9.Size = new Size(33, 13);
            Label9.TabIndex = 110;
            Label9.Text = "Rank";
            // 
            // cmRankSetup
            // 
            _cmRankSetup.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmRankSetup.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmRankSetup.FlatStyle = FlatStyle.Flat;
            _cmRankSetup.ForeColor = Color.Black;
            _cmRankSetup.Location = new Point(45, 15);
            _cmRankSetup.Name = "_cmRankSetup";
            _cmRankSetup.Size = new Size(50, 23);
            _cmRankSetup.TabIndex = 0;
            _cmRankSetup.Text = "Setup";
            _cmRankSetup.UseVisualStyleBackColor = false;
            // 
            // cmSave
            // 
            _cmSave.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSave.FlatStyle = FlatStyle.Flat;
            _cmSave.ForeColor = Color.Black;
            _cmSave.Location = new Point(880, 145);
            _cmSave.Name = "_cmSave";
            _cmSave.Size = new Size(105, 23);
            _cmSave.TabIndex = 7;
            _cmSave.Text = "Save Stats Image";
            _cmSave.UseVisualStyleBackColor = false;
            // 
            // gbLayout
            // 
            gbLayout.Controls.Add(_cmStatsModeHelp);
            gbLayout.Controls.Add(_cmDefaults);
            gbLayout.Controls.Add(_tbYSize);
            gbLayout.Controls.Add(_tbXsize);
            gbLayout.Controls.Add(_tbYoff);
            gbLayout.Controls.Add(_tbXoff);
            gbLayout.Controls.Add(Label7);
            gbLayout.Controls.Add(_cboNoteSpace);
            gbLayout.Controls.Add(_chkGUIMode);
            gbLayout.Controls.Add(Label5);
            gbLayout.Controls.Add(_cmSizeRefresh);
            gbLayout.Controls.Add(_cboLayoutX);
            gbLayout.Controls.Add(Label3);
            gbLayout.Controls.Add(Label6);
            gbLayout.Controls.Add(_cboLayoutY);
            gbLayout.Controls.Add(Label4);
            gbLayout.Location = new Point(335, 0);
            gbLayout.Name = "gbLayout";
            gbLayout.Size = new Size(194, 195);
            gbLayout.TabIndex = 76;
            gbLayout.TabStop = false;
            gbLayout.Text = "Stats Layout";
            // 
            // cmStatsModeHelp
            // 
            _cmStatsModeHelp.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmStatsModeHelp.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmStatsModeHelp.FlatStyle = FlatStyle.Flat;
            _cmStatsModeHelp.ForeColor = Color.Black;
            _cmStatsModeHelp.Location = new Point(67, 165);
            _cmStatsModeHelp.Name = "_cmStatsModeHelp";
            _cmStatsModeHelp.Size = new Size(56, 23);
            _cmStatsModeHelp.TabIndex = 26;
            _cmStatsModeHelp.Text = "Help";
            _cmStatsModeHelp.UseVisualStyleBackColor = false;
            // 
            // cmDefaults
            // 
            _cmDefaults.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmDefaults.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmDefaults.FlatStyle = FlatStyle.Flat;
            _cmDefaults.ForeColor = Color.Black;
            _cmDefaults.Location = new Point(7, 165);
            _cmDefaults.Name = "_cmDefaults";
            _cmDefaults.Size = new Size(58, 23);
            _cmDefaults.TabIndex = 25;
            _cmDefaults.Text = "Defaults";
            _cmDefaults.UseVisualStyleBackColor = false;
            // 
            // tbYSize
            // 
            _tbYSize.Location = new Point(126, 15);
            _tbYSize.Name = "_tbYSize";
            _tbYSize.Size = new Size(60, 20);
            _tbYSize.TabIndex = 19;
            _tbYSize.Text = "180";
            // 
            // tbXsize
            // 
            _tbXsize.Location = new Point(60, 15);
            _tbXsize.Name = "_tbXsize";
            _tbXsize.Size = new Size(60, 20);
            _tbXsize.TabIndex = 18;
            _tbXsize.Text = "990";
            // 
            // tbYoff
            // 
            _tbYoff.Location = new Point(126, 40);
            _tbYoff.Name = "_tbYoff";
            _tbYoff.Size = new Size(60, 20);
            _tbYoff.TabIndex = 21;
            // 
            // tbXoff
            // 
            _tbXoff.Location = new Point(60, 40);
            _tbXoff.Name = "_tbXoff";
            _tbXoff.Size = new Size(60, 20);
            _tbXoff.TabIndex = 20;
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label7.Location = new Point(5, 45);
            Label7.Name = "Label7";
            Label7.Size = new Size(52, 13);
            Label7.TabIndex = 77;
            Label7.Text = "XY Offset";
            // 
            // cboNoteSpace
            // 
            _cboNoteSpace.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboNoteSpace.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboNoteSpace.ForeColor = Color.White;
            _cboNoteSpace.FormattingEnabled = true;
            _cboNoteSpace.Location = new Point(90, 115);
            _cboNoteSpace.Name = "_cboNoteSpace";
            _cboNoteSpace.Size = new Size(96, 21);
            _cboNoteSpace.TabIndex = 24;
            // 
            // chkGUIMode
            // 
            _chkGUIMode.AutoSize = true;
            _chkGUIMode.Location = new Point(8, 145);
            _chkGUIMode.Name = "_chkGUIMode";
            _chkGUIMode.Size = new Size(108, 17);
            _chkGUIMode.TabIndex = 100;
            _chkGUIMode.Text = "Toggle GUI Color";
            _chkGUIMode.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label5.Location = new Point(5, 120);
            Label5.Name = "Label5";
            Label5.Size = new Size(72, 13);
            Label5.TabIndex = 73;
            Label5.Text = "Note Spacing";
            // 
            // cmSizeRefresh
            // 
            _cmSizeRefresh.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSizeRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSizeRefresh.FlatStyle = FlatStyle.Flat;
            _cmSizeRefresh.ForeColor = Color.Black;
            _cmSizeRefresh.Location = new Point(125, 165);
            _cmSizeRefresh.Name = "_cmSizeRefresh";
            _cmSizeRefresh.Size = new Size(58, 23);
            _cmSizeRefresh.TabIndex = 27;
            _cmSizeRefresh.Text = "Refresh";
            _cmSizeRefresh.UseVisualStyleBackColor = false;
            // 
            // cboLayoutX
            // 
            _cboLayoutX.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboLayoutX.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLayoutX.ForeColor = Color.White;
            _cboLayoutX.FormattingEnabled = true;
            _cboLayoutX.Location = new Point(60, 65);
            _cboLayoutX.Name = "_cboLayoutX";
            _cboLayoutX.Size = new Size(126, 21);
            _cboLayoutX.TabIndex = 22;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label6.Location = new Point(5, 70);
            Label6.Name = "Label6";
            Label6.Size = new Size(49, 13);
            Label6.TabIndex = 72;
            Label6.Text = "X Layout";
            // 
            // pbStats
            // 
            _pbStats.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _pbStats.Cursor = Cursors.Default;
            _pbStats.Location = new Point(10, 200);
            _pbStats.Name = "_pbStats";
            _pbStats.Size = new Size(990, 180);
            _pbStats.TabIndex = 77;
            _pbStats.TabStop = false;
            // 
            // cmTestData
            // 
            _cmTestData.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmTestData.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmTestData.FlatStyle = FlatStyle.Flat;
            _cmTestData.ForeColor = Color.Black;
            _cmTestData.Location = new Point(880, 95);
            _cmTestData.Name = "_cmTestData";
            _cmTestData.Size = new Size(105, 23);
            _cmTestData.TabIndex = 5;
            _cmTestData.Text = "Show Test Data";
            _cmTestData.UseVisualStyleBackColor = false;
            // 
            // cmLastMatch
            // 
            _cmLastMatch.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmLastMatch.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmLastMatch.FlatStyle = FlatStyle.Flat;
            _cmLastMatch.ForeColor = Color.Black;
            _cmLastMatch.Location = new Point(880, 70);
            _cmLastMatch.Name = "_cmLastMatch";
            _cmLastMatch.Size = new Size(105, 23);
            _cmLastMatch.TabIndex = 4;
            _cmLastMatch.Text = "Last Match Stats";
            _cmLastMatch.UseVisualStyleBackColor = false;
            // 
            // gbFX
            // 
            gbFX.Controls.Add(cmRID);
            gbFX.Controls.Add(_chkFX);
            gbFX.Controls.Add(Label1);
            gbFX.Controls.Add(_cmFXModeHelp);
            gbFX.Controls.Add(_cboFXVar1);
            gbFX.Controls.Add(lbFXVar1);
            gbFX.Controls.Add(_cboFxVar3);
            gbFX.Controls.Add(lbFXVar3);
            gbFX.Controls.Add(_cboFxVar4);
            gbFX.Controls.Add(_cmFX3DC);
            gbFX.Controls.Add(_cboFXVar2);
            gbFX.Controls.Add(lbFXVar2);
            gbFX.Controls.Add(lbFXVar4);
            gbFX.Controls.Add(_chkMismatch);
            gbFX.Location = new Point(535, 0);
            gbFX.Name = "gbFX";
            gbFX.Size = new Size(145, 195);
            gbFX.TabIndex = 80;
            gbFX.TabStop = false;
            gbFX.Text = "Stats FX";
            // 
            // cmRID
            // 
            cmRID.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            cmRID.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            cmRID.FlatStyle = FlatStyle.Flat;
            cmRID.ForeColor = Color.Black;
            cmRID.Location = new Point(9, 165);
            cmRID.Name = "cmRID";
            cmRID.Size = new Size(50, 23);
            cmRID.TabIndex = 95;
            cmRID.Text = "RID";
            cmRID.UseVisualStyleBackColor = false;
            cmRID.Visible = false;
            // 
            // chkFX
            // 
            _chkFX.AutoSize = true;
            _chkFX.Enabled = false;
            _chkFX.Location = new Point(66, 42);
            _chkFX.Name = "_chkFX";
            _chkFX.Size = new Size(56, 17);
            _chkFX.TabIndex = 88;
            _chkFX.Text = "Active";
            _chkFX.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label1.Location = new Point(6, 45);
            Label1.Name = "Label1";
            Label1.Size = new Size(34, 13);
            Label1.TabIndex = 89;
            Label1.Text = "Mode";
            // 
            // cmFXModeHelp
            // 
            _cmFXModeHelp.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFXModeHelp.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFXModeHelp.FlatStyle = FlatStyle.Flat;
            _cmFXModeHelp.ForeColor = Color.Black;
            _cmFXModeHelp.Location = new Point(65, 165);
            _cmFXModeHelp.Name = "_cmFXModeHelp";
            _cmFXModeHelp.Size = new Size(71, 23);
            _cmFXModeHelp.TabIndex = 93;
            _cmFXModeHelp.Text = "Help";
            _cmFXModeHelp.UseVisualStyleBackColor = false;
            // 
            // cboFXVar1
            // 
            _cboFXVar1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboFXVar1.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFXVar1.ForeColor = Color.White;
            _cboFXVar1.FormattingEnabled = true;
            _cboFXVar1.Location = new Point(65, 15);
            _cboFXVar1.Name = "_cboFXVar1";
            _cboFXVar1.Size = new Size(71, 21);
            _cboFXVar1.TabIndex = 87;
            // 
            // lbFXVar1
            // 
            lbFXVar1.AutoSize = true;
            lbFXVar1.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbFXVar1.Location = new Point(6, 21);
            lbFXVar1.Name = "lbFXVar1";
            lbFXVar1.Size = new Size(34, 13);
            lbFXVar1.TabIndex = 86;
            lbFXVar1.Text = "Mode";
            // 
            // cboFxVar3
            // 
            _cboFxVar3.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboFxVar3.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFxVar3.Enabled = false;
            _cboFxVar3.ForeColor = Color.White;
            _cboFxVar3.FormattingEnabled = true;
            _cboFxVar3.Location = new Point(65, 89);
            _cboFxVar3.Name = "_cboFxVar3";
            _cboFxVar3.Size = new Size(71, 21);
            _cboFxVar3.TabIndex = 91;
            // 
            // lbFXVar3
            // 
            lbFXVar3.AutoSize = true;
            lbFXVar3.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbFXVar3.Location = new Point(6, 91);
            lbFXVar3.Name = "lbFXVar3";
            lbFXVar3.Size = new Size(13, 13);
            lbFXVar3.TabIndex = 84;
            lbFXVar3.Text = "--";
            // 
            // cboFxVar4
            // 
            _cboFxVar4.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboFxVar4.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFxVar4.Enabled = false;
            _cboFxVar4.ForeColor = Color.White;
            _cboFxVar4.FormattingEnabled = true;
            _cboFxVar4.Location = new Point(65, 113);
            _cboFxVar4.Name = "_cboFxVar4";
            _cboFxVar4.Size = new Size(71, 21);
            _cboFxVar4.TabIndex = 92;
            // 
            // cmFX3DC
            // 
            _cmFX3DC.Enabled = false;
            _cmFX3DC.FlatStyle = FlatStyle.Flat;
            _cmFX3DC.Location = new Point(65, 65);
            _cmFX3DC.Name = "_cmFX3DC";
            _cmFX3DC.Size = new Size(21, 21);
            _cmFX3DC.TabIndex = 89;
            _cmFX3DC.Text = "1";
            _cmFX3DC.UseVisualStyleBackColor = true;
            // 
            // cboFXVar2
            // 
            _cboFXVar2.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboFXVar2.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFXVar2.Enabled = false;
            _cboFXVar2.ForeColor = Color.White;
            _cboFXVar2.FormattingEnabled = true;
            _cboFXVar2.Location = new Point(90, 65);
            _cboFXVar2.Name = "_cboFXVar2";
            _cboFXVar2.Size = new Size(46, 21);
            _cboFXVar2.TabIndex = 90;
            // 
            // lbFXVar2
            // 
            lbFXVar2.AutoSize = true;
            lbFXVar2.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbFXVar2.Location = new Point(6, 68);
            lbFXVar2.Name = "lbFXVar2";
            lbFXVar2.Size = new Size(13, 13);
            lbFXVar2.TabIndex = 66;
            lbFXVar2.Text = "--";
            // 
            // lbFXVar4
            // 
            lbFXVar4.AutoSize = true;
            lbFXVar4.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbFXVar4.Location = new Point(6, 115);
            lbFXVar4.Name = "lbFXVar4";
            lbFXVar4.Size = new Size(13, 13);
            lbFXVar4.TabIndex = 70;
            lbFXVar4.Text = "--";
            // 
            // chkMismatch
            // 
            _chkMismatch.AutoSize = true;
            _chkMismatch.Checked = true;
            _chkMismatch.CheckState = CheckState.Checked;
            _chkMismatch.Location = new Point(9, 143);
            _chkMismatch.Name = "_chkMismatch";
            _chkMismatch.Size = new Size(102, 17);
            _chkMismatch.TabIndex = 11;
            _chkMismatch.Text = "Show Bad Stats";
            _chkMismatch.UseVisualStyleBackColor = true;
            _chkMismatch.Visible = false;
            // 
            // lbError1
            // 
            lbError1.BackColor = Color.Silver;
            lbError1.BorderStyle = BorderStyle.FixedSingle;
            lbError1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbError1.ForeColor = Color.White;
            lbError1.Location = new Point(10, 70);
            lbError1.Name = "lbError1";
            lbError1.Size = new Size(111, 18);
            lbError1.TabIndex = 81;
            lbError1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbError2
            // 
            lbError2.BackColor = Color.Silver;
            lbError2.BorderStyle = BorderStyle.FixedSingle;
            lbError2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbError2.ForeColor = Color.White;
            lbError2.Location = new Point(10, 90);
            lbError2.Name = "lbError2";
            lbError2.Size = new Size(111, 18);
            lbError2.TabIndex = 82;
            lbError2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkTips
            // 
            _chkTips.AutoSize = true;
            _chkTips.Location = new Point(991, 42);
            _chkTips.Name = "_chkTips";
            _chkTips.Size = new Size(100, 17);
            _chkTips.TabIndex = 10;
            _chkTips.Text = "Show Tool Tips";
            _chkTips.UseVisualStyleBackColor = true;
            // 
            // pbNote1
            // 
            pbNote1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            pbNote1.Cursor = Cursors.Default;
            pbNote1.Location = new Point(11, 386);
            pbNote1.Name = "pbNote1";
            pbNote1.Size = new Size(500, 60);
            pbNote1.TabIndex = 91;
            pbNote1.TabStop = false;
            // 
            // timNote1
            // 
            _timNote1.Enabled = true;
            _timNote1.Interval = 30;
            // 
            // gbSound
            // 
            gbSound.Controls.Add(_cmAudioStop);
            gbSound.Controls.Add(lbVolume);
            gbSound.Controls.Add(_scrVolume);
            gbSound.Controls.Add(_cmSound15);
            gbSound.Controls.Add(_cmSound14);
            gbSound.Controls.Add(_cmSound13);
            gbSound.Controls.Add(_cmSound12);
            gbSound.Controls.Add(_cmSound11);
            gbSound.Controls.Add(lbSoundCurrent);
            gbSound.Controls.Add(_cmSound10);
            gbSound.Controls.Add(_cmSound09);
            gbSound.Controls.Add(_cmSound08);
            gbSound.Controls.Add(_cmSound07);
            gbSound.Controls.Add(_cmSound06);
            gbSound.Controls.Add(_cmSound05);
            gbSound.Controls.Add(_cmSound04);
            gbSound.Controls.Add(_cmSound03);
            gbSound.Controls.Add(_cmSound02);
            gbSound.Controls.Add(_cmSound01);
            gbSound.Location = new Point(685, 0);
            gbSound.Name = "gbSound";
            gbSound.Size = new Size(190, 195);
            gbSound.TabIndex = 94;
            gbSound.TabStop = false;
            gbSound.Text = "Sound";
            // 
            // cmAudioStop
            // 
            _cmAudioStop.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmAudioStop.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmAudioStop.FlatStyle = FlatStyle.Flat;
            _cmAudioStop.ForeColor = Color.Black;
            _cmAudioStop.Location = new Point(145, 170);
            _cmAudioStop.Name = "_cmAudioStop";
            _cmAudioStop.Size = new Size(35, 18);
            _cmAudioStop.TabIndex = 34;
            _cmAudioStop.Text = "▀";
            _cmAudioStop.UseVisualStyleBackColor = false;
            // 
            // lbVolume
            // 
            lbVolume.BackColor = Color.Silver;
            lbVolume.BorderStyle = BorderStyle.FixedSingle;
            lbVolume.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbVolume.ForeColor = Color.Black;
            lbVolume.Location = new Point(105, 170);
            lbVolume.Name = "lbVolume";
            lbVolume.Size = new Size(35, 18);
            lbVolume.TabIndex = 33;
            lbVolume.Text = "100";
            lbVolume.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scrVolume
            // 
            _scrVolume.Location = new Point(5, 170);
            _scrVolume.Maximum = 109;
            _scrVolume.Name = "_scrVolume";
            _scrVolume.Size = new Size(95, 18);
            _scrVolume.TabIndex = 32;
            _scrVolume.TabStop = true;
            _scrVolume.Value = 100;
            // 
            // cmSound15
            // 
            _cmSound15.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound15.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound15.FlatStyle = FlatStyle.Flat;
            _cmSound15.ForeColor = Color.Black;
            _cmSound15.Location = new Point(125, 115);
            _cmSound15.Name = "_cmSound15";
            _cmSound15.Size = new Size(55, 23);
            _cmSound15.TabIndex = 31;
            _cmSound15.Text = "ALERT";
            _cmSound15.UseVisualStyleBackColor = false;
            // 
            // cmSound14
            // 
            _cmSound14.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound14.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound14.FlatStyle = FlatStyle.Flat;
            _cmSound14.ForeColor = Color.Black;
            _cmSound14.Location = new Point(65, 115);
            _cmSound14.Name = "_cmSound14";
            _cmSound14.Size = new Size(55, 23);
            _cmSound14.TabIndex = 30;
            _cmSound14.Text = "> 14";
            _cmSound14.UseVisualStyleBackColor = false;
            // 
            // cmSound13
            // 
            _cmSound13.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound13.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound13.FlatStyle = FlatStyle.Flat;
            _cmSound13.ForeColor = Color.Black;
            _cmSound13.Location = new Point(5, 115);
            _cmSound13.Name = "_cmSound13";
            _cmSound13.Size = new Size(55, 23);
            _cmSound13.TabIndex = 29;
            _cmSound13.Text = "> 13";
            _cmSound13.UseVisualStyleBackColor = false;
            // 
            // cmSound12
            // 
            _cmSound12.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound12.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound12.FlatStyle = FlatStyle.Flat;
            _cmSound12.ForeColor = Color.Black;
            _cmSound12.Location = new Point(125, 90);
            _cmSound12.Name = "_cmSound12";
            _cmSound12.Size = new Size(55, 23);
            _cmSound12.TabIndex = 28;
            _cmSound12.Text = "> 12";
            _cmSound12.UseVisualStyleBackColor = false;
            // 
            // cmSound11
            // 
            _cmSound11.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound11.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound11.FlatStyle = FlatStyle.Flat;
            _cmSound11.ForeColor = Color.Black;
            _cmSound11.Location = new Point(65, 90);
            _cmSound11.Name = "_cmSound11";
            _cmSound11.Size = new Size(55, 23);
            _cmSound11.TabIndex = 27;
            _cmSound11.Text = "> 11";
            _cmSound11.UseVisualStyleBackColor = false;
            // 
            // lbSoundCurrent
            // 
            lbSoundCurrent.BackColor = Color.Silver;
            lbSoundCurrent.BorderStyle = BorderStyle.FixedSingle;
            lbSoundCurrent.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            lbSoundCurrent.ForeColor = Color.Black;
            lbSoundCurrent.Location = new Point(5, 150);
            lbSoundCurrent.Name = "lbSoundCurrent";
            lbSoundCurrent.Size = new Size(175, 18);
            lbSoundCurrent.TabIndex = 26;
            lbSoundCurrent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmSound10
            // 
            _cmSound10.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound10.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound10.FlatStyle = FlatStyle.Flat;
            _cmSound10.ForeColor = Color.Black;
            _cmSound10.Location = new Point(5, 90);
            _cmSound10.Name = "_cmSound10";
            _cmSound10.Size = new Size(55, 23);
            _cmSound10.TabIndex = 17;
            _cmSound10.Text = "> 10";
            _cmSound10.UseVisualStyleBackColor = false;
            // 
            // cmSound09
            // 
            _cmSound09.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound09.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound09.FlatStyle = FlatStyle.Flat;
            _cmSound09.ForeColor = Color.Black;
            _cmSound09.Location = new Point(125, 65);
            _cmSound09.Name = "_cmSound09";
            _cmSound09.Size = new Size(55, 23);
            _cmSound09.TabIndex = 16;
            _cmSound09.Text = "> 09";
            _cmSound09.UseVisualStyleBackColor = false;
            // 
            // cmSound08
            // 
            _cmSound08.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound08.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound08.FlatStyle = FlatStyle.Flat;
            _cmSound08.ForeColor = Color.Black;
            _cmSound08.Location = new Point(65, 65);
            _cmSound08.Name = "_cmSound08";
            _cmSound08.Size = new Size(55, 23);
            _cmSound08.TabIndex = 15;
            _cmSound08.Text = "> 08";
            _cmSound08.UseVisualStyleBackColor = false;
            // 
            // cmSound07
            // 
            _cmSound07.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound07.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound07.FlatStyle = FlatStyle.Flat;
            _cmSound07.ForeColor = Color.Black;
            _cmSound07.Location = new Point(5, 65);
            _cmSound07.Name = "_cmSound07";
            _cmSound07.Size = new Size(55, 23);
            _cmSound07.TabIndex = 14;
            _cmSound07.Text = "> 07";
            _cmSound07.UseVisualStyleBackColor = false;
            // 
            // cmSound06
            // 
            _cmSound06.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound06.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound06.FlatStyle = FlatStyle.Flat;
            _cmSound06.ForeColor = Color.Black;
            _cmSound06.Location = new Point(125, 40);
            _cmSound06.Name = "_cmSound06";
            _cmSound06.Size = new Size(55, 23);
            _cmSound06.TabIndex = 13;
            _cmSound06.Text = "> 06";
            _cmSound06.UseVisualStyleBackColor = false;
            // 
            // cmSound05
            // 
            _cmSound05.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound05.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound05.FlatStyle = FlatStyle.Flat;
            _cmSound05.ForeColor = Color.Black;
            _cmSound05.Location = new Point(65, 40);
            _cmSound05.Name = "_cmSound05";
            _cmSound05.Size = new Size(55, 23);
            _cmSound05.TabIndex = 12;
            _cmSound05.Text = "> 05";
            _cmSound05.UseVisualStyleBackColor = false;
            // 
            // cmSound04
            // 
            _cmSound04.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound04.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound04.FlatStyle = FlatStyle.Flat;
            _cmSound04.ForeColor = Color.Black;
            _cmSound04.Location = new Point(5, 40);
            _cmSound04.Name = "_cmSound04";
            _cmSound04.Size = new Size(55, 23);
            _cmSound04.TabIndex = 11;
            _cmSound04.Text = "> 04";
            _cmSound04.UseVisualStyleBackColor = false;
            // 
            // cmSound03
            // 
            _cmSound03.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound03.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound03.FlatStyle = FlatStyle.Flat;
            _cmSound03.ForeColor = Color.Black;
            _cmSound03.Location = new Point(125, 15);
            _cmSound03.Name = "_cmSound03";
            _cmSound03.Size = new Size(55, 23);
            _cmSound03.TabIndex = 10;
            _cmSound03.Text = "> 03";
            _cmSound03.UseVisualStyleBackColor = false;
            // 
            // cmSound02
            // 
            _cmSound02.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound02.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound02.FlatStyle = FlatStyle.Flat;
            _cmSound02.ForeColor = Color.Black;
            _cmSound02.Location = new Point(65, 15);
            _cmSound02.Name = "_cmSound02";
            _cmSound02.Size = new Size(55, 23);
            _cmSound02.TabIndex = 9;
            _cmSound02.Text = "> 02";
            _cmSound02.UseVisualStyleBackColor = false;
            // 
            // cmSound01
            // 
            _cmSound01.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound01.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmSound01.FlatStyle = FlatStyle.Flat;
            _cmSound01.ForeColor = Color.Black;
            _cmSound01.Location = new Point(5, 15);
            _cmSound01.Name = "_cmSound01";
            _cmSound01.Size = new Size(55, 23);
            _cmSound01.TabIndex = 8;
            _cmSound01.Text = "> 01";
            _cmSound01.UseVisualStyleBackColor = false;
            // 
            // pbNote3
            // 
            pbNote3.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            pbNote3.Cursor = Cursors.Default;
            pbNote3.Location = new Point(11, 516);
            pbNote3.Name = "pbNote3";
            pbNote3.Size = new Size(500, 60);
            pbNote3.TabIndex = 96;
            pbNote3.TabStop = false;
            // 
            // pbNote4
            // 
            pbNote4.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            pbNote4.Cursor = Cursors.Default;
            pbNote4.Location = new Point(11, 581);
            pbNote4.Name = "pbNote4";
            pbNote4.Size = new Size(500, 60);
            pbNote4.TabIndex = 97;
            pbNote4.TabStop = false;
            // 
            // pbNote2
            // 
            pbNote2.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            pbNote2.Cursor = Cursors.Default;
            pbNote2.Location = new Point(11, 451);
            pbNote2.Name = "pbNote2";
            pbNote2.Size = new Size(500, 60);
            pbNote2.TabIndex = 98;
            pbNote2.TabStop = false;
            // 
            // chkPosition
            // 
            chkPosition.AutoSize = true;
            chkPosition.Location = new Point(991, 59);
            chkPosition.Name = "chkPosition";
            chkPosition.Size = new Size(114, 17);
            chkPosition.TabIndex = 12;
            chkPosition.Text = "Save Window Pos";
            chkPosition.UseVisualStyleBackColor = true;
            // 
            // tsmPlayer
            // 
            tsmPlayer.Items.AddRange(new ToolStripItem[] { _tsmPlayer_Relic, _tsmPlayer_OrgAT, _tsmPlayer_OrgFaction, _tsmPlayer_OrgPlayercard, _tsmPlayer_Google, _tsmPlayer_Steam });
            tsmPlayer.Name = "tsmPlayer";
            tsmPlayer.Size = new Size(290, 136);
            // 
            // tsmPlayer_Relic
            // 
            _tsmPlayer_Relic.Image = (Image)resources.GetObject("tsmPlayer_Relic.Image");
            _tsmPlayer_Relic.Name = "_tsmPlayer_Relic";
            _tsmPlayer_Relic.Size = new Size(289, 22);
            _tsmPlayer_Relic.Text = "&1 - Open Relic Stats webpage";
            // 
            // tsmPlayer_OrgAT
            // 
            _tsmPlayer_OrgAT.Image = (Image)resources.GetObject("tsmPlayer_OrgAT.Image");
            _tsmPlayer_OrgAT.Name = "_tsmPlayer_OrgAT";
            _tsmPlayer_OrgAT.Size = new Size(289, 22);
            _tsmPlayer_OrgAT.Text = "&2 - Open Coh2.Org AT stats webpage";
            // 
            // tsmPlayer_OrgFaction
            // 
            _tsmPlayer_OrgFaction.Image = (Image)resources.GetObject("tsmPlayer_OrgFaction.Image");
            _tsmPlayer_OrgFaction.Name = "_tsmPlayer_OrgFaction";
            _tsmPlayer_OrgFaction.Size = new Size(289, 22);
            _tsmPlayer_OrgFaction.Text = "3 - Open Coh2.Org Faction webpage";
            // 
            // tsmPlayer_OrgPlayercard
            // 
            _tsmPlayer_OrgPlayercard.Image = (Image)resources.GetObject("tsmPlayer_OrgPlayercard.Image");
            _tsmPlayer_OrgPlayercard.Name = "_tsmPlayer_OrgPlayercard";
            _tsmPlayer_OrgPlayercard.Size = new Size(289, 22);
            _tsmPlayer_OrgPlayercard.Text = "&4 - Open Coh2.Org Playercard webpage";
            // 
            // tsmPlayer_Google
            // 
            _tsmPlayer_Google.Image = (Image)resources.GetObject("tsmPlayer_Google.Image");
            _tsmPlayer_Google.Name = "_tsmPlayer_Google";
            _tsmPlayer_Google.Size = new Size(289, 22);
            _tsmPlayer_Google.Text = "&5 - Send player name to Google Translate";
            // 
            // tsmPlayer_Steam
            // 
            _tsmPlayer_Steam.Image = (Image)resources.GetObject("tsmPlayer_Steam.Image");
            _tsmPlayer_Steam.Name = "_tsmPlayer_Steam";
            _tsmPlayer_Steam.Size = new Size(289, 22);
            _tsmPlayer_Steam.Text = "&6 - Open player Steam page";
            // 
            // chkPopUp
            // 
            _chkPopUp.AutoSize = true;
            _chkPopUp.Location = new Point(1029, 201);
            _chkPopUp.Name = "_chkPopUp";
            _chkPopUp.Size = new Size(106, 17);
            _chkPopUp.TabIndex = 13;
            _chkPopUp.Text = "Use Stats Popup";
            _chkPopUp.UseVisualStyleBackColor = true;
            _chkPopUp.Visible = false;
            // 
            // tsmAudio
            // 
            tsmAudio.Items.AddRange(new ToolStripItem[] { _tsmSetVolTo100, _tsmSetVolTo90, _tsmSetVolTo80, _tsmSetVolTo70, _tsmSetVolTo60, _tsmSetVolTo50, _tsmSetVolTo40, _tsmSetVolTo30, _tsmSetVolTo20, _tsmSetVolTo10, ToolStripMenuItem1, _tsmSelectFile });
            tsmAudio.Name = "tsmAudio";
            tsmAudio.Size = new Size(216, 252);
            // 
            // tsmSetVolTo100
            // 
            _tsmSetVolTo100.Name = "_tsmSetVolTo100";
            _tsmSetVolTo100.Size = new Size(215, 22);
            _tsmSetVolTo100.Text = "&0 - Set Vol to 100%";
            // 
            // tsmSetVolTo90
            // 
            _tsmSetVolTo90.Name = "_tsmSetVolTo90";
            _tsmSetVolTo90.Size = new Size(215, 22);
            _tsmSetVolTo90.Text = "9 - Set Vol to 90%";
            // 
            // tsmSetVolTo80
            // 
            _tsmSetVolTo80.Name = "_tsmSetVolTo80";
            _tsmSetVolTo80.Size = new Size(215, 22);
            _tsmSetVolTo80.Text = "8 - Set Vol to 80%";
            // 
            // tsmSetVolTo70
            // 
            _tsmSetVolTo70.Name = "_tsmSetVolTo70";
            _tsmSetVolTo70.Size = new Size(215, 22);
            _tsmSetVolTo70.Text = "7 - Set Vol to 70%";
            // 
            // tsmSetVolTo60
            // 
            _tsmSetVolTo60.Name = "_tsmSetVolTo60";
            _tsmSetVolTo60.Size = new Size(215, 22);
            _tsmSetVolTo60.Text = "6 - Set Vol to 60%";
            // 
            // tsmSetVolTo50
            // 
            _tsmSetVolTo50.Name = "_tsmSetVolTo50";
            _tsmSetVolTo50.Size = new Size(215, 22);
            _tsmSetVolTo50.Text = "5 - Set Vol to 50%";
            // 
            // tsmSetVolTo40
            // 
            _tsmSetVolTo40.Name = "_tsmSetVolTo40";
            _tsmSetVolTo40.Size = new Size(215, 22);
            _tsmSetVolTo40.Text = "4 - Set Vol to 40%";
            // 
            // tsmSetVolTo30
            // 
            _tsmSetVolTo30.Name = "_tsmSetVolTo30";
            _tsmSetVolTo30.Size = new Size(215, 22);
            _tsmSetVolTo30.Text = "3 - Set Vol to 30%";
            // 
            // tsmSetVolTo20
            // 
            _tsmSetVolTo20.Name = "_tsmSetVolTo20";
            _tsmSetVolTo20.Size = new Size(215, 22);
            _tsmSetVolTo20.Text = "2 - Set Vol to 20%";
            // 
            // tsmSetVolTo10
            // 
            _tsmSetVolTo10.Name = "_tsmSetVolTo10";
            _tsmSetVolTo10.Size = new Size(215, 22);
            _tsmSetVolTo10.Text = "1 - Set Vol to 10%";
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size(212, 6);
            // 
            // tsmSelectFile
            // 
            _tsmSelectFile.Name = "_tsmSelectFile";
            _tsmSelectFile.Size = new Size(215, 22);
            _tsmSelectFile.Text = "F - Select Audio file to play";
            // 
            // chkSmoothAni
            // 
            _chkSmoothAni.AutoSize = true;
            _chkSmoothAni.Location = new Point(991, 93);
            _chkSmoothAni.Name = "_chkSmoothAni";
            _chkSmoothAni.Size = new Size(111, 17);
            _chkSmoothAni.TabIndex = 14;
            _chkSmoothAni.Text = "Smooth Animation";
            _chkSmoothAni.UseVisualStyleBackColor = true;
            // 
            // chkFoundSound
            // 
            _chkFoundSound.AutoSize = true;
            _chkFoundSound.Location = new Point(991, 110);
            _chkFoundSound.Name = "_chkFoundSound";
            _chkFoundSound.Size = new Size(113, 17);
            _chkFoundSound.TabIndex = 101;
            _chkFoundSound.Text = "Match Found Alert";
            _chkFoundSound.UseVisualStyleBackColor = true;
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbTime.Location = new Point(8, 170);
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(56, 13);
            lbTime.TabIndex = 102;
            lbTime.Text = "Time (sec)";
            // 
            // cboDelay
            // 
            _cboDelay.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboDelay.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDelay.ForeColor = Color.White;
            _cboDelay.FormattingEnabled = true;
            _cboDelay.Location = new Point(70, 165);
            _cboDelay.Name = "_cboDelay";
            _cboDelay.Size = new Size(51, 21);
            _cboDelay.TabIndex = 103;
            // 
            // chkHideMissing
            // 
            _chkHideMissing.AutoSize = true;
            _chkHideMissing.Location = new Point(991, 127);
            _chkHideMissing.Name = "_chkHideMissing";
            _chkHideMissing.Size = new Size(123, 17);
            _chkHideMissing.TabIndex = 104;
            _chkHideMissing.Text = "Hide Missing Players";
            _chkHideMissing.UseVisualStyleBackColor = true;
            // 
            // chkShowELO
            // 
            _chkShowELO.AutoSize = true;
            _chkShowELO.Location = new Point(991, 144);
            _chkShowELO.Name = "_chkShowELO";
            _chkShowELO.Size = new Size(99, 17);
            _chkShowELO.TabIndex = 105;
            _chkShowELO.Text = "Cycle ELO Vals";
            _chkShowELO.UseVisualStyleBackColor = true;
            // 
            // timELOCycle
            // 
            _timELOCycle.Enabled = true;
            _timELOCycle.Interval = 3000;
            // 
            // scrStats
            // 
            _scrStats.LargeChange = 90;
            _scrStats.Location = new Point(1003, 201);
            _scrStats.Name = "_scrStats";
            _scrStats.Size = new Size(23, 178);
            _scrStats.TabIndex = 107;
            // 
            // chkSpeech
            // 
            _chkSpeech.AutoSize = true;
            _chkSpeech.Location = new Point(991, 161);
            _chkSpeech.Name = "_chkSpeech";
            _chkSpeech.Size = new Size(116, 17);
            _chkSpeech.TabIndex = 108;
            _chkSpeech.Text = "Read Ranks Aloud";
            _chkSpeech.UseVisualStyleBackColor = true;
            // 
            // chkGetTeams
            // 
            _chkGetTeams.AutoSize = true;
            _chkGetTeams.Location = new Point(991, 178);
            _chkGetTeams.Name = "_chkGetTeams";
            _chkGetTeams.Size = new Size(110, 17);
            _chkGetTeams.TabIndex = 109;
            _chkGetTeams.Text = "Find Team Ranks";
            _chkGetTeams.UseVisualStyleBackColor = true;
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(790, 393);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(288, 277);
            lstLog.TabIndex = 110;
            lstLog.Visible = false;
            // 
            // cmErrLog
            // 
            _cmErrLog.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmErrLog.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmErrLog.FlatStyle = FlatStyle.Flat;
            _cmErrLog.ForeColor = Color.Black;
            _cmErrLog.Location = new Point(880, 170);
            _cmErrLog.Name = "_cmErrLog";
            _cmErrLog.Size = new Size(105, 23);
            _cmErrLog.TabIndex = 111;
            _cmErrLog.Text = "View Web Log";
            _cmErrLog.UseVisualStyleBackColor = false;
            // 
            // chkCountry
            // 
            _chkCountry.AutoSize = true;
            _chkCountry.Location = new Point(991, 76);
            _chkCountry.Name = "_chkCountry";
            _chkCountry.Size = new Size(120, 17);
            _chkCountry.TabIndex = 112;
            _chkCountry.Text = "Show Country Flags";
            _chkCountry.UseVisualStyleBackColor = true;
            // 
            // SS1
            // 
            SS1.Items.AddRange(new ToolStripItem[] { SS1_Version, SS1_Sep1, SS1_Filename, SS1_Sep2, SS1_Time, SS1_Sep3 });
            SS1.Location = new Point(0, 638);
            SS1.Name = "SS1";
            SS1.RenderMode = ToolStripRenderMode.Professional;
            SS1.Size = new Size(1130, 22);
            SS1.TabIndex = 113;
            // 
            // SS1_Version
            // 
            SS1_Version.AutoSize = false;
            SS1_Version.BorderStyle = Border3DStyle.Sunken;
            SS1_Version.Name = "SS1_Version";
            SS1_Version.Size = new Size(35, 17);
            SS1_Version.Text = "v4.50";
            SS1_Version.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SS1_Sep1
            // 
            SS1_Sep1.AutoSize = false;
            SS1_Sep1.Name = "SS1_Sep1";
            SS1_Sep1.Size = new Size(10, 17);
            SS1_Sep1.Text = "|";
            // 
            // SS1_Filename
            // 
            SS1_Filename.AutoSize = false;
            SS1_Filename.BorderStyle = Border3DStyle.RaisedOuter;
            SS1_Filename.Name = "SS1_Filename";
            SS1_Filename.Size = new Size(250, 17);
            SS1_Filename.Text = "default.mcs";
            SS1_Filename.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SS1_Sep2
            // 
            SS1_Sep2.AutoSize = false;
            SS1_Sep2.Name = "SS1_Sep2";
            SS1_Sep2.Size = new Size(10, 17);
            SS1_Sep2.Text = "|";
            // 
            // SS1_Time
            // 
            SS1_Time.AutoSize = false;
            SS1_Time.BorderStyle = Border3DStyle.Sunken;
            SS1_Time.Name = "SS1_Time";
            SS1_Time.Size = new Size(180, 17);
            SS1_Time.Text = "Match found:";
            SS1_Time.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SS1_Sep3
            // 
            SS1_Sep3.AutoSize = false;
            SS1_Sep3.Name = "SS1_Sep3";
            SS1_Sep3.Size = new Size(10, 17);
            SS1_Sep3.Text = "|";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            ClientSize = new Size(1130, 660);
            Controls.Add(SS1);
            Controls.Add(_chkCountry);
            Controls.Add(_cmErrLog);
            Controls.Add(lstLog);
            Controls.Add(_chkGetTeams);
            Controls.Add(_chkSpeech);
            Controls.Add(_scrStats);
            Controls.Add(_chkShowELO);
            Controls.Add(_chkHideMissing);
            Controls.Add(_cboDelay);
            Controls.Add(lbTime);
            Controls.Add(_chkFoundSound);
            Controls.Add(_chkSmoothAni);
            Controls.Add(_chkPopUp);
            Controls.Add(chkPosition);
            Controls.Add(_cmCopy);
            Controls.Add(_cmSave);
            Controls.Add(pbNote2);
            Controls.Add(pbNote4);
            Controls.Add(pbNote3);
            Controls.Add(gbSound);
            Controls.Add(pbNote1);
            Controls.Add(_chkTips);
            Controls.Add(lbError2);
            Controls.Add(lbError1);
            Controls.Add(gbFX);
            Controls.Add(_cmLastMatch);
            Controls.Add(_cmTestData);
            Controls.Add(_pbStats);
            Controls.Add(gbLayout);
            Controls.Add(gbRank);
            Controls.Add(_cmAbout);
            Controls.Add(Label2);
            Controls.Add(_cmScanLog);
            Controls.Add(_cmFindLog);
            Controls.Add(lbSteam08);
            Controls.Add(lbSteam07);
            Controls.Add(lbSteam06);
            Controls.Add(lbSteam05);
            Controls.Add(lbSteam04);
            Controls.Add(lbSteam03);
            Controls.Add(lbSteam02);
            Controls.Add(lbSteam01);
            Controls.Add(pbFact05);
            Controls.Add(pbFact04);
            Controls.Add(pbFact03);
            Controls.Add(pbFact02);
            Controls.Add(pbFact01);
            Controls.Add(lbStatus);
            Controls.Add(_cmCheckLog);
            DoubleBuffered = true;
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMain";
            Text = "MakoCelo";
            ((System.ComponentModel.ISupportInitialize)pbFact01).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFact02).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFact03).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFact04).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFact05).EndInit();
            gbRank.ResumeLayout(false);
            gbRank.PerformLayout();
            gbLayout.ResumeLayout(false);
            gbLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_pbStats).EndInit();
            gbFX.ResumeLayout(false);
            gbFX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbNote1).EndInit();
            gbSound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbNote3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNote4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNote2).EndInit();
            tsmPlayer.ResumeLayout(false);
            tsmAudio.ResumeLayout(false);
            SS1.ResumeLayout(false);
            SS1.PerformLayout();
            Load += new EventHandler(frmMain_Load);
            Shown += new EventHandler(frmMain_Shown);
            FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
            Closing += new System.ComponentModel.CancelEventHandler(frmMain_Closing);
            Paint += new PaintEventHandler(frmMain_Paint);
            ResumeLayout(false);
            PerformLayout();
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
    }
}