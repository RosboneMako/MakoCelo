using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
    [DesignerGenerated()]
    public partial class frmLabelSetup : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabelSetup));
            gbLabel = new GroupBox();
            _lbShadowColor = new Label();
            _lbShadowColor.Click += new EventHandler(cmShadowColor_Click);
            _lbBordColor = new Label();
            _lbBordColor.Click += new EventHandler(cmBordColor_Click);
            _lbB2 = new Label();
            _lbB2.Click += new EventHandler(cmB2_Click);
            _lbF2 = new Label();
            _lbF2.Click += new EventHandler(cmF2_Click);
            _lbB1 = new Label();
            _lbB1.Click += new EventHandler(cmB1_Click);
            _lbF1 = new Label();
            _lbF1.Click += new EventHandler(cmF1_Click);
            _cmBordColor = new Button();
            _cmBordColor.Click += new EventHandler(cmBordColor_Click);
            _cboBord = new ComboBox();
            _cboBord.SelectedIndexChanged += new EventHandler(cboBord_SelectedIndexChanged);
            Label6 = new Label();
            _cboDepth = new ComboBox();
            _cboDepth.SelectedIndexChanged += new EventHandler(cboDepth_SelectedIndexChanged);
            lbDepth = new Label();
            tbHeight = new TextBox();
            Label1 = new Label();
            tbWidth = new TextBox();
            lbSize = new Label();
            _cmShadowColor = new Button();
            _cmShadowColor.Click += new EventHandler(cmShadowColor_Click);
            lbR5 = new Label();
            _cbo3D = new ComboBox();
            _cbo3D.SelectedIndexChanged += new EventHandler(cbo3D_SelectedIndexChanged);
            _cmRankFont = new Button();
            _cmRankFont.Click += new EventHandler(cmRankFont_Click);
            _cboA2 = new ComboBox();
            _cboA2.SelectedIndexChanged += new EventHandler(cboA2_SelectedIndexChanged);
            lbR4 = new Label();
            _cmBR = new Button();
            _cmBR.Click += new EventHandler(cmBR_Click);
            _cmBD = new Button();
            _cmBD.Click += new EventHandler(cmBD_Click);
            _cmFR = new Button();
            _cmFR.Click += new EventHandler(cmFR_Click);
            _cmFD = new Button();
            _cmFD.Click += new EventHandler(cmFD_Click);
            _cmB2 = new Button();
            _cmB2.Click += new EventHandler(cmB2_Click);
            _cmB1 = new Button();
            _cmB1.Click += new EventHandler(cmB1_Click);
            lbR2 = new Label();
            _cmF2 = new Button();
            _cmF2.Click += new EventHandler(cmF2_Click);
            _cmF1 = new Button();
            _cmF1.Click += new EventHandler(cmF1_Click);
            lbR1 = new Label();
            lbR3 = new Label();
            _cboA1 = new ComboBox();
            _cboA1.SelectedIndexChanged += new EventHandler(cboA1_SelectedIndexChanged);
            pbNote = new PictureBox();
            _cmCancel = new Button();
            _cmCancel.Click += new EventHandler(cmCancel_Click);
            _cmOK = new Button();
            _cmOK.Click += new EventHandler(cmOK_Click);
            ColorDialog1 = new ColorDialog();
            gbBack = new GroupBox();
            _lbBordPanColor = new Label();
            _lbBordPanColor.Click += new EventHandler(cmBordPanColor_Click);
            _chkCardBack = new CheckBox();
            _chkCardBack.CheckedChanged += new EventHandler(chkCardBack_CheckedChanged);
            _cmBordPanColor = new Button();
            _cmBordPanColor.Click += new EventHandler(cmBordPanColor_Click);
            _cboBordPan = new ComboBox();
            _cboBordPan.SelectedIndexChanged += new EventHandler(cboBordPan_SelectedIndexChanged);
            Label3 = new Label();
            _cboScaling = new ComboBox();
            _cboScaling.SelectedIndexChanged += new EventHandler(cboScaling_SelectedIndexChanged);
            Label7 = new Label();
            _cmFormColor = new Button();
            _cmFormColor.Click += new EventHandler(cmFormColor_Click);
            _cmFormImage = new Button();
            _cmFormImage.Click += new EventHandler(cmFormImage_Click);
            _cmNoImage = new Button();
            _cmNoImage.Click += new EventHandler(cmNoImage_Click);
            _cboOVLScaling = new ComboBox();
            _cboOVLScaling.SelectedIndexChanged += new EventHandler(cboOVLScaling_SelectedIndexChanged);
            Label2 = new Label();
            _cmOverlay = new Button();
            _cmOverlay.Click += new EventHandler(cmOverlay_Click);
            _cmCopy01 = new Button();
            _cmCopy01.Click += new EventHandler(cmCopy01_Click);
            _cmCopy02 = new Button();
            _cmCopy02.Click += new EventHandler(cmCopy02_Click);
            _cmCopy03 = new Button();
            _cmCopy03.Click += new EventHandler(cmCopy03_Click);
            _cmCopy04 = new Button();
            _cmCopy04.Click += new EventHandler(cmCopy04_Click);
            _cmCopyAll = new Button();
            _cmCopyAll.Click += new EventHandler(cmCopyAll_Click);
            _cmCopySize = new Button();
            _cmCopySize.Click += new EventHandler(cmCopySize_Click);
            _cmOVLNoImage = new Button();
            _cmOVLNoImage.Click += new EventHandler(cmOVLNoImage_Click);
            GroupBox1 = new GroupBox();
            ToolTip1 = new ToolTip(components);
            _cboBordWidth = new ComboBox();
            _cboBordWidth.SelectedIndexChanged += new EventHandler(cboBordWidth_SelectedIndexChanged);
            Label4 = new Label();
            Label5 = new Label();
            _cboBordPanWidth = new ComboBox();
            _cboBordPanWidth.SelectedIndexChanged += new EventHandler(cboBordPanWidth_SelectedIndexChanged);
            gbLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbNote).BeginInit();
            gbBack.SuspendLayout();
            GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // gbLabel
            // 
            gbLabel.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            gbLabel.Controls.Add(Label4);
            gbLabel.Controls.Add(_cboBordWidth);
            gbLabel.Controls.Add(_lbShadowColor);
            gbLabel.Controls.Add(_lbBordColor);
            gbLabel.Controls.Add(_lbB2);
            gbLabel.Controls.Add(_lbF2);
            gbLabel.Controls.Add(_lbB1);
            gbLabel.Controls.Add(_lbF1);
            gbLabel.Controls.Add(_cmBordColor);
            gbLabel.Controls.Add(_cboBord);
            gbLabel.Controls.Add(Label6);
            gbLabel.Controls.Add(_cboDepth);
            gbLabel.Controls.Add(lbDepth);
            gbLabel.Controls.Add(tbHeight);
            gbLabel.Controls.Add(Label1);
            gbLabel.Controls.Add(tbWidth);
            gbLabel.Controls.Add(lbSize);
            gbLabel.Controls.Add(_cmShadowColor);
            gbLabel.Controls.Add(lbR5);
            gbLabel.Controls.Add(_cbo3D);
            gbLabel.Controls.Add(_cmRankFont);
            gbLabel.Controls.Add(_cboA2);
            gbLabel.Controls.Add(lbR4);
            gbLabel.Controls.Add(_cmBR);
            gbLabel.Controls.Add(_cmBD);
            gbLabel.Controls.Add(_cmFR);
            gbLabel.Controls.Add(_cmFD);
            gbLabel.Controls.Add(_cmB2);
            gbLabel.Controls.Add(_cmB1);
            gbLabel.Controls.Add(lbR2);
            gbLabel.Controls.Add(_cmF2);
            gbLabel.Controls.Add(_cmF1);
            gbLabel.Controls.Add(lbR1);
            gbLabel.Controls.Add(lbR3);
            gbLabel.Controls.Add(_cboA1);
            gbLabel.ForeColor = Color.Black;
            gbLabel.Location = new Point(10, 10);
            gbLabel.Name = "gbLabel";
            gbLabel.Size = new Size(304, 352);
            gbLabel.TabIndex = 74;
            gbLabel.TabStop = false;
            gbLabel.Text = "Text Setup";
            // 
            // lbShadowColor
            // 
            _lbShadowColor.BorderStyle = BorderStyle.FixedSingle;
            _lbShadowColor.Location = new Point(179, 221);
            _lbShadowColor.Name = "_lbShadowColor";
            _lbShadowColor.Size = new Size(10, 21);
            _lbShadowColor.TabIndex = 151;
            // 
            // lbBordColor
            // 
            _lbBordColor.BorderStyle = BorderStyle.FixedSingle;
            _lbBordColor.Location = new Point(178, 157);
            _lbBordColor.Name = "_lbBordColor";
            _lbBordColor.Size = new Size(10, 21);
            _lbBordColor.TabIndex = 150;
            // 
            // lbB2
            // 
            _lbB2.BorderStyle = BorderStyle.FixedSingle;
            _lbB2.Location = new Point(229, 71);
            _lbB2.Name = "_lbB2";
            _lbB2.Size = new Size(10, 21);
            _lbB2.TabIndex = 149;
            // 
            // lbF2
            // 
            _lbF2.BorderStyle = BorderStyle.FixedSingle;
            _lbF2.Location = new Point(229, 47);
            _lbF2.Name = "_lbF2";
            _lbF2.Size = new Size(10, 21);
            _lbF2.TabIndex = 148;
            // 
            // lbB1
            // 
            _lbB1.BorderStyle = BorderStyle.FixedSingle;
            _lbB1.Location = new Point(193, 71);
            _lbB1.Name = "_lbB1";
            _lbB1.Size = new Size(10, 21);
            _lbB1.TabIndex = 147;
            // 
            // lbF1
            // 
            _lbF1.BorderStyle = BorderStyle.FixedSingle;
            _lbF1.Location = new Point(193, 47);
            _lbF1.Name = "_lbF1";
            _lbF1.Size = new Size(10, 21);
            _lbF1.TabIndex = 144;
            // 
            // cmBordColor
            // 
            _cmBordColor.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmBordColor.FlatStyle = FlatStyle.Flat;
            _cmBordColor.Location = new Point(157, 157);
            _cmBordColor.Name = "_cmBordColor";
            _cmBordColor.Size = new Size(20, 21);
            _cmBordColor.TabIndex = 146;
            _cmBordColor.Text = "1";
            _cmBordColor.UseVisualStyleBackColor = false;
            // 
            // cboBord
            // 
            _cboBord.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboBord.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboBord.ForeColor = Color.White;
            _cboBord.FormattingEnabled = true;
            _cboBord.Location = new Point(193, 157);
            _cboBord.Name = "_cboBord";
            _cboBord.Size = new Size(96, 21);
            _cboBord.TabIndex = 145;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label6.Location = new Point(4, 157);
            Label6.Name = "Label6";
            Label6.Size = new Size(38, 13);
            Label6.TabIndex = 144;
            Label6.Text = "Border";
            // 
            // cboDepth
            // 
            _cboDepth.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboDepth.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDepth.ForeColor = Color.White;
            _cboDepth.FormattingEnabled = true;
            _cboDepth.Location = new Point(194, 246);
            _cboDepth.Name = "_cboDepth";
            _cboDepth.Size = new Size(97, 21);
            _cboDepth.TabIndex = 13;
            // 
            // lbDepth
            // 
            lbDepth.AutoSize = true;
            lbDepth.Location = new Point(2, 245);
            lbDepth.Name = "lbDepth";
            lbDepth.Size = new Size(78, 13);
            lbDepth.TabIndex = 143;
            lbDepth.Text = "Shadow Depth";
            // 
            // tbHeight
            // 
            tbHeight.BackColor = Color.White;
            tbHeight.ForeColor = Color.Black;
            tbHeight.Location = new Point(173, 315);
            tbHeight.Name = "tbHeight";
            tbHeight.Size = new Size(118, 20);
            tbHeight.TabIndex = 16;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(7, 317);
            Label1.Name = "Label1";
            Label1.Size = new Size(107, 13);
            Label1.TabIndex = 141;
            Label1.Text = "Note Height (60 max)";
            // 
            // tbWidth
            // 
            tbWidth.BackColor = Color.White;
            tbWidth.ForeColor = Color.Black;
            tbWidth.Location = new Point(173, 290);
            tbWidth.Name = "tbWidth";
            tbWidth.Size = new Size(118, 20);
            tbWidth.TabIndex = 15;
            // 
            // lbSize
            // 
            lbSize.AutoSize = true;
            lbSize.Location = new Point(7, 275);
            lbSize.Name = "lbSize";
            lbSize.Size = new Size(61, 13);
            lbSize.TabIndex = 137;
            lbSize.Text = "Note Width";
            // 
            // cmShadowColor
            // 
            _cmShadowColor.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmShadowColor.FlatStyle = FlatStyle.Flat;
            _cmShadowColor.Location = new Point(158, 221);
            _cmShadowColor.Name = "_cmShadowColor";
            _cmShadowColor.Size = new Size(20, 21);
            _cmShadowColor.TabIndex = 11;
            _cmShadowColor.Text = "1";
            _cmShadowColor.UseVisualStyleBackColor = false;
            // 
            // lbR5
            // 
            lbR5.AutoSize = true;
            lbR5.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbR5.Location = new Point(2, 221);
            lbR5.Name = "lbR5";
            lbR5.Size = new Size(119, 13);
            lbR5.TabIndex = 67;
            lbR5.Text = "Simple Shadow Options";
            // 
            // cbo3D
            // 
            _cbo3D.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cbo3D.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo3D.ForeColor = Color.White;
            _cbo3D.FormattingEnabled = true;
            _cbo3D.Location = new Point(194, 221);
            _cbo3D.Name = "_cbo3D";
            _cbo3D.Size = new Size(96, 21);
            _cbo3D.TabIndex = 12;
            // 
            // cmRankFont
            // 
            _cmRankFont.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmRankFont.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmRankFont.FlatStyle = FlatStyle.Flat;
            _cmRankFont.ForeColor = Color.Black;
            _cmRankFont.Location = new Point(219, 15);
            _cmRankFont.Name = "_cmRankFont";
            _cmRankFont.Size = new Size(70, 26);
            _cmRankFont.TabIndex = 14;
            _cmRankFont.Text = "Font";
            _cmRankFont.UseVisualStyleBackColor = false;
            // 
            // cboA2
            // 
            _cboA2.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboA2.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboA2.ForeColor = Color.White;
            _cboA2.FormattingEnabled = true;
            _cboA2.Location = new Point(193, 122);
            _cboA2.Name = "_cboA2";
            _cboA2.Size = new Size(97, 21);
            _cboA2.TabIndex = 10;
            // 
            // lbR4
            // 
            lbR4.AutoSize = true;
            lbR4.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbR4.Location = new Point(3, 122);
            lbR4.Name = "lbR4";
            lbR4.Size = new Size(156, 13);
            lbR4.TabIndex = 64;
            lbR4.Text = "Background Gradient Opacity 2";
            // 
            // cmBR
            // 
            _cmBR.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmBR.FlatStyle = FlatStyle.Flat;
            _cmBR.Location = new Point(269, 71);
            _cmBR.Name = "_cmBR";
            _cmBR.Size = new Size(20, 21);
            _cmBR.TabIndex = 8;
            _cmBR.Text = ">";
            _cmBR.UseVisualStyleBackColor = false;
            // 
            // cmBD
            // 
            _cmBD.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmBD.FlatStyle = FlatStyle.Flat;
            _cmBD.Location = new Point(244, 71);
            _cmBD.Name = "_cmBD";
            _cmBD.Size = new Size(20, 21);
            _cmBD.TabIndex = 7;
            _cmBD.Text = "˅";
            _cmBD.UseVisualStyleBackColor = false;
            // 
            // cmFR
            // 
            _cmFR.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFR.FlatStyle = FlatStyle.Flat;
            _cmFR.Location = new Point(269, 47);
            _cmFR.Name = "_cmFR";
            _cmFR.Size = new Size(20, 21);
            _cmFR.TabIndex = 4;
            _cmFR.Text = ">";
            _cmFR.UseVisualStyleBackColor = false;
            // 
            // cmFD
            // 
            _cmFD.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFD.FlatStyle = FlatStyle.Flat;
            _cmFD.Location = new Point(244, 47);
            _cmFD.Name = "_cmFD";
            _cmFD.Size = new Size(20, 21);
            _cmFD.TabIndex = 3;
            _cmFD.Text = "˅";
            _cmFD.UseVisualStyleBackColor = false;
            // 
            // cmB2
            // 
            _cmB2.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmB2.FlatStyle = FlatStyle.Flat;
            _cmB2.Location = new Point(208, 71);
            _cmB2.Name = "_cmB2";
            _cmB2.Size = new Size(20, 21);
            _cmB2.TabIndex = 6;
            _cmB2.Text = "2";
            _cmB2.UseVisualStyleBackColor = false;
            // 
            // cmB1
            // 
            _cmB1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmB1.FlatStyle = FlatStyle.Flat;
            _cmB1.Location = new Point(172, 71);
            _cmB1.Name = "_cmB1";
            _cmB1.Size = new Size(20, 21);
            _cmB1.TabIndex = 5;
            _cmB1.Text = "1";
            _cmB1.UseVisualStyleBackColor = false;
            // 
            // lbR2
            // 
            lbR2.AutoSize = true;
            lbR2.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbR2.Location = new Point(4, 72);
            lbR2.Name = "lbR2";
            lbR2.Size = new Size(135, 13);
            lbR2.TabIndex = 57;
            lbR2.Text = "Background Gradient Color";
            // 
            // cmF2
            // 
            _cmF2.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmF2.FlatStyle = FlatStyle.Flat;
            _cmF2.Location = new Point(208, 47);
            _cmF2.Name = "_cmF2";
            _cmF2.Size = new Size(20, 21);
            _cmF2.TabIndex = 2;
            _cmF2.Text = "2";
            _cmF2.UseVisualStyleBackColor = false;
            // 
            // cmF1
            // 
            _cmF1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmF1.FlatStyle = FlatStyle.Flat;
            _cmF1.Location = new Point(172, 47);
            _cmF1.Name = "_cmF1";
            _cmF1.Size = new Size(20, 21);
            _cmF1.TabIndex = 1;
            _cmF1.Text = "1";
            _cmF1.UseVisualStyleBackColor = false;
            // 
            // lbR1
            // 
            lbR1.AutoSize = true;
            lbR1.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbR1.Location = new Point(3, 49);
            lbR1.Name = "lbR1";
            lbR1.Size = new Size(98, 13);
            lbR1.TabIndex = 54;
            lbR1.Text = "Font Gradient Color";
            // 
            // lbR3
            // 
            lbR3.AutoSize = true;
            lbR3.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            lbR3.Location = new Point(4, 97);
            lbR3.Name = "lbR3";
            lbR3.Size = new Size(156, 13);
            lbR3.TabIndex = 53;
            lbR3.Text = "Background Gradient Opacity 1";
            // 
            // cboA1
            // 
            _cboA1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboA1.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboA1.ForeColor = Color.White;
            _cboA1.FormattingEnabled = true;
            _cboA1.Location = new Point(193, 97);
            _cboA1.Name = "_cboA1";
            _cboA1.Size = new Size(97, 21);
            _cboA1.TabIndex = 9;
            // 
            // pbNote
            // 
            pbNote.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            pbNote.Cursor = Cursors.Default;
            pbNote.Location = new Point(10, 378);
            pbNote.Name = "pbNote";
            pbNote.Size = new Size(256, 40);
            pbNote.TabIndex = 92;
            pbNote.TabStop = false;
            // 
            // cmCancel
            // 
            _cmCancel.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCancel.Location = new Point(551, 80);
            _cmCancel.Name = "_cmCancel";
            _cmCancel.Size = new Size(120, 37);
            _cmCancel.TabIndex = 25;
            _cmCancel.Text = "Cancel";
            _cmCancel.UseVisualStyleBackColor = false;
            // 
            // cmOK
            // 
            _cmOK.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmOK.Location = new Point(551, 35);
            _cmOK.Name = "_cmOK";
            _cmOK.Size = new Size(120, 37);
            _cmOK.TabIndex = 24;
            _cmOK.Text = "OK";
            _cmOK.UseVisualStyleBackColor = false;
            // 
            // gbBack
            // 
            gbBack.Controls.Add(Label5);
            gbBack.Controls.Add(_lbBordPanColor);
            gbBack.Controls.Add(_cboBordPanWidth);
            gbBack.Controls.Add(_chkCardBack);
            gbBack.Controls.Add(_cmBordPanColor);
            gbBack.Controls.Add(_cboBordPan);
            gbBack.Controls.Add(Label3);
            gbBack.Controls.Add(_cboScaling);
            gbBack.Controls.Add(Label7);
            gbBack.Controls.Add(_cmFormColor);
            gbBack.Controls.Add(_cmFormImage);
            gbBack.Controls.Add(_cmNoImage);
            gbBack.Location = new Point(320, 10);
            gbBack.Name = "gbBack";
            gbBack.Size = new Size(202, 216);
            gbBack.TabIndex = 135;
            gbBack.TabStop = false;
            gbBack.Text = "Background";
            // 
            // lbBordPanColor
            // 
            _lbBordPanColor.BorderStyle = BorderStyle.FixedSingle;
            _lbBordPanColor.Location = new Point(79, 160);
            _lbBordPanColor.Name = "_lbBordPanColor";
            _lbBordPanColor.Size = new Size(10, 21);
            _lbBordPanColor.TabIndex = 151;
            // 
            // chkCardBack
            // 
            _chkCardBack.AutoSize = true;
            _chkCardBack.Location = new Point(9, 134);
            _chkCardBack.Name = "_chkCardBack";
            _chkCardBack.Size = new Size(143, 17);
            _chkCardBack.TabIndex = 68;
            _chkCardBack.Text = "Use image on playercard";
            _chkCardBack.UseVisualStyleBackColor = true;
            // 
            // cmBordPanColor
            // 
            _cmBordPanColor.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmBordPanColor.FlatStyle = FlatStyle.Flat;
            _cmBordPanColor.Location = new Point(58, 160);
            _cmBordPanColor.Name = "_cmBordPanColor";
            _cmBordPanColor.Size = new Size(20, 21);
            _cmBordPanColor.TabIndex = 67;
            _cmBordPanColor.Text = "1";
            _cmBordPanColor.UseVisualStyleBackColor = false;
            // 
            // cboBordPan
            // 
            _cboBordPan.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboBordPan.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboBordPan.ForeColor = Color.White;
            _cboBordPan.FormattingEnabled = true;
            _cboBordPan.Location = new Point(107, 160);
            _cboBordPan.Name = "_cboBordPan";
            _cboBordPan.Size = new Size(89, 21);
            _cboBordPan.TabIndex = 66;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label3.Location = new Point(5, 162);
            Label3.Name = "Label3";
            Label3.Size = new Size(38, 13);
            Label3.TabIndex = 65;
            Label3.Text = "Border";
            // 
            // cboScaling
            // 
            _cboScaling.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboScaling.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboScaling.ForeColor = Color.White;
            _cboScaling.FormattingEnabled = true;
            _cboScaling.Location = new Point(107, 107);
            _cboScaling.Name = "_cboScaling";
            _cboScaling.Size = new Size(89, 21);
            _cboScaling.TabIndex = 20;
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label7.Location = new Point(5, 110);
            Label7.Name = "Label7";
            Label7.Size = new Size(42, 13);
            Label7.TabIndex = 64;
            Label7.Text = "Scaling";
            // 
            // cmFormColor
            // 
            _cmFormColor.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFormColor.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFormColor.FlatStyle = FlatStyle.Flat;
            _cmFormColor.ForeColor = Color.Black;
            _cmFormColor.Location = new Point(5, 15);
            _cmFormColor.Name = "_cmFormColor";
            _cmFormColor.Size = new Size(191, 26);
            _cmFormColor.TabIndex = 17;
            _cmFormColor.Text = "Panel Color";
            _cmFormColor.UseVisualStyleBackColor = false;
            // 
            // cmFormImage
            // 
            _cmFormImage.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFormImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmFormImage.FlatStyle = FlatStyle.Flat;
            _cmFormImage.ForeColor = Color.Black;
            _cmFormImage.Location = new Point(5, 75);
            _cmFormImage.Name = "_cmFormImage";
            _cmFormImage.Size = new Size(191, 26);
            _cmFormImage.TabIndex = 19;
            _cmFormImage.Text = "Panel Image";
            _cmFormImage.UseVisualStyleBackColor = false;
            // 
            // cmNoImage
            // 
            _cmNoImage.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNoImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmNoImage.FlatStyle = FlatStyle.Flat;
            _cmNoImage.ForeColor = Color.Black;
            _cmNoImage.Location = new Point(5, 45);
            _cmNoImage.Name = "_cmNoImage";
            _cmNoImage.Size = new Size(191, 26);
            _cmNoImage.TabIndex = 18;
            _cmNoImage.Text = "No Image";
            _cmNoImage.UseVisualStyleBackColor = false;
            // 
            // cboOVLScaling
            // 
            _cboOVLScaling.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboOVLScaling.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboOVLScaling.ForeColor = Color.White;
            _cboOVLScaling.FormattingEnabled = true;
            _cboOVLScaling.Location = new Point(94, 80);
            _cboOVLScaling.Name = "_cboOVLScaling";
            _cboOVLScaling.Size = new Size(102, 21);
            _cboOVLScaling.TabIndex = 23;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label2.Location = new Point(5, 84);
            Label2.Name = "Label2";
            Label2.Size = new Size(42, 13);
            Label2.TabIndex = 66;
            Label2.Text = "Scaling";
            // 
            // cmOverlay
            // 
            _cmOverlay.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmOverlay.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmOverlay.FlatStyle = FlatStyle.Flat;
            _cmOverlay.ForeColor = Color.Black;
            _cmOverlay.Location = new Point(5, 49);
            _cmOverlay.Name = "_cmOverlay";
            _cmOverlay.Size = new Size(191, 26);
            _cmOverlay.TabIndex = 22;
            _cmOverlay.Text = "Overlay Image";
            _cmOverlay.UseVisualStyleBackColor = false;
            // 
            // cmCopy01
            // 
            _cmCopy01.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy01.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy01.FlatStyle = FlatStyle.Flat;
            _cmCopy01.ForeColor = Color.Black;
            _cmCopy01.Location = new Point(536, 140);
            _cmCopy01.Name = "_cmCopy01";
            _cmCopy01.Size = new Size(145, 26);
            _cmCopy01.TabIndex = 26;
            _cmCopy01.Text = "Copy Note 1 settings";
            _cmCopy01.UseVisualStyleBackColor = false;
            // 
            // cmCopy02
            // 
            _cmCopy02.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy02.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy02.FlatStyle = FlatStyle.Flat;
            _cmCopy02.ForeColor = Color.Black;
            _cmCopy02.Location = new Point(536, 170);
            _cmCopy02.Name = "_cmCopy02";
            _cmCopy02.Size = new Size(145, 26);
            _cmCopy02.TabIndex = 27;
            _cmCopy02.Text = "Copy Note 2 settings";
            _cmCopy02.UseVisualStyleBackColor = false;
            // 
            // cmCopy03
            // 
            _cmCopy03.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy03.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy03.FlatStyle = FlatStyle.Flat;
            _cmCopy03.ForeColor = Color.Black;
            _cmCopy03.Location = new Point(536, 200);
            _cmCopy03.Name = "_cmCopy03";
            _cmCopy03.Size = new Size(145, 26);
            _cmCopy03.TabIndex = 28;
            _cmCopy03.Text = "Copy Note 3 settings";
            _cmCopy03.UseVisualStyleBackColor = false;
            // 
            // cmCopy04
            // 
            _cmCopy04.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy04.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopy04.FlatStyle = FlatStyle.Flat;
            _cmCopy04.ForeColor = Color.Black;
            _cmCopy04.Location = new Point(536, 230);
            _cmCopy04.Name = "_cmCopy04";
            _cmCopy04.Size = new Size(145, 26);
            _cmCopy04.TabIndex = 29;
            _cmCopy04.Text = "Copy Note 4 settings";
            _cmCopy04.UseVisualStyleBackColor = false;
            // 
            // cmCopyAll
            // 
            _cmCopyAll.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopyAll.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopyAll.FlatStyle = FlatStyle.Flat;
            _cmCopyAll.ForeColor = Color.Black;
            _cmCopyAll.Location = new Point(536, 275);
            _cmCopyAll.Name = "_cmCopyAll";
            _cmCopyAll.Size = new Size(145, 26);
            _cmCopyAll.TabIndex = 30;
            _cmCopyAll.Text = "Set ALL notes to this Style";
            _cmCopyAll.UseVisualStyleBackColor = false;
            // 
            // cmCopySize
            // 
            _cmCopySize.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopySize.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmCopySize.FlatStyle = FlatStyle.Flat;
            _cmCopySize.ForeColor = Color.Black;
            _cmCopySize.Location = new Point(536, 305);
            _cmCopySize.Name = "_cmCopySize";
            _cmCopySize.Size = new Size(145, 26);
            _cmCopySize.TabIndex = 31;
            _cmCopySize.Text = "Set ALL notes to this Size";
            _cmCopySize.UseVisualStyleBackColor = false;
            // 
            // cmOVLNoImage
            // 
            _cmOVLNoImage.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmOVLNoImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(232)));
            _cmOVLNoImage.FlatStyle = FlatStyle.Flat;
            _cmOVLNoImage.ForeColor = Color.Black;
            _cmOVLNoImage.Location = new Point(5, 19);
            _cmOVLNoImage.Name = "_cmOVLNoImage";
            _cmOVLNoImage.Size = new Size(191, 26);
            _cmOVLNoImage.TabIndex = 21;
            _cmOVLNoImage.Text = "No Image";
            _cmOVLNoImage.UseVisualStyleBackColor = false;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(_cmOVLNoImage);
            GroupBox1.Controls.Add(_cmOverlay);
            GroupBox1.Controls.Add(_cboOVLScaling);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Location = new Point(320, 243);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(202, 119);
            GroupBox1.TabIndex = 143;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Overlay";
            // 
            // cboBordWidth
            // 
            _cboBordWidth.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboBordWidth.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboBordWidth.ForeColor = Color.White;
            _cboBordWidth.FormattingEnabled = true;
            _cboBordWidth.Location = new Point(193, 182);
            _cboBordWidth.Name = "_cboBordWidth";
            _cboBordWidth.Size = new Size(96, 21);
            _cboBordWidth.TabIndex = 152;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label4.Location = new Point(4, 185);
            Label4.Name = "Label4";
            Label4.Size = new Size(90, 13);
            Label4.TabIndex = 153;
            Label4.Text = "Border Thickness";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)), Conversions.ToInteger(Conversions.ToByte(32)));
            Label5.Location = new Point(6, 190);
            Label5.Name = "Label5";
            Label5.Size = new Size(90, 13);
            Label5.TabIndex = 155;
            Label5.Text = "Border Thickness";
            // 
            // cboBordPanWidth
            // 
            _cboBordPanWidth.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboBordPanWidth.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboBordPanWidth.ForeColor = Color.White;
            _cboBordPanWidth.FormattingEnabled = true;
            _cboBordPanWidth.Location = new Point(107, 185);
            _cboBordPanWidth.Name = "_cboBordPanWidth";
            _cboBordPanWidth.Size = new Size(89, 21);
            _cboBordPanWidth.TabIndex = 154;
            // 
            // frmLabelSetup
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)), Conversions.ToInteger(Conversions.ToByte(240)));
            ClientSize = new Size(694, 434);
            Controls.Add(GroupBox1);
            Controls.Add(_cmCopySize);
            Controls.Add(_cmCopyAll);
            Controls.Add(_cmCopy04);
            Controls.Add(_cmCopy03);
            Controls.Add(_cmCopy02);
            Controls.Add(_cmCopy01);
            Controls.Add(gbBack);
            Controls.Add(_cmCancel);
            Controls.Add(_cmOK);
            Controls.Add(pbNote);
            Controls.Add(gbLabel);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmLabelSetup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MakoCELO - Presentation Setup";
            gbLabel.ResumeLayout(false);
            gbLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbNote).EndInit();
            gbBack.ResumeLayout(false);
            gbBack.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            Load += new EventHandler(frmLabelSetup_Load);
            ResumeLayout(false);
        }

        internal GroupBox gbLabel;
        private Button _cmShadowColor;

        internal Button cmShadowColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmShadowColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmShadowColor != null)
                {
                    _cmShadowColor.Click -= cmShadowColor_Click;
                }

                _cmShadowColor = value;
                if (_cmShadowColor != null)
                {
                    _cmShadowColor.Click += cmShadowColor_Click;
                }
            }
        }

        internal Label lbR5;
        private ComboBox _cbo3D;

        internal ComboBox cbo3D
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo3D;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo3D != null)
                {
                    _cbo3D.SelectedIndexChanged -= cbo3D_SelectedIndexChanged;
                }

                _cbo3D = value;
                if (_cbo3D != null)
                {
                    _cbo3D.SelectedIndexChanged += cbo3D_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboA2;

        internal ComboBox cboA2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboA2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboA2 != null)
                {
                    _cboA2.SelectedIndexChanged -= cboA2_SelectedIndexChanged;
                }

                _cboA2 = value;
                if (_cboA2 != null)
                {
                    _cboA2.SelectedIndexChanged += cboA2_SelectedIndexChanged;
                }
            }
        }

        internal Label lbR4;
        private Button _cmBR;

        internal Button cmBR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmBR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmBR != null)
                {
                    _cmBR.Click -= cmBR_Click;
                }

                _cmBR = value;
                if (_cmBR != null)
                {
                    _cmBR.Click += cmBR_Click;
                }
            }
        }

        private Button _cmBD;

        internal Button cmBD
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmBD;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmBD != null)
                {
                    _cmBD.Click -= cmBD_Click;
                }

                _cmBD = value;
                if (_cmBD != null)
                {
                    _cmBD.Click += cmBD_Click;
                }
            }
        }

        private Button _cmFR;

        internal Button cmFR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmFR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmFR != null)
                {
                    _cmFR.Click -= cmFR_Click;
                }

                _cmFR = value;
                if (_cmFR != null)
                {
                    _cmFR.Click += cmFR_Click;
                }
            }
        }

        private Button _cmFD;

        internal Button cmFD
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmFD;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmFD != null)
                {
                    _cmFD.Click -= cmFD_Click;
                }

                _cmFD = value;
                if (_cmFD != null)
                {
                    _cmFD.Click += cmFD_Click;
                }
            }
        }

        private Button _cmB2;

        internal Button cmB2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmB2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmB2 != null)
                {
                    _cmB2.Click -= cmB2_Click;
                }

                _cmB2 = value;
                if (_cmB2 != null)
                {
                    _cmB2.Click += cmB2_Click;
                }
            }
        }

        private Button _cmB1;

        internal Button cmB1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmB1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmB1 != null)
                {
                    _cmB1.Click -= cmB1_Click;
                }

                _cmB1 = value;
                if (_cmB1 != null)
                {
                    _cmB1.Click += cmB1_Click;
                }
            }
        }

        internal Label lbR2;
        private Button _cmF2;

        internal Button cmF2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmF2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmF2 != null)
                {
                    _cmF2.Click -= cmF2_Click;
                }

                _cmF2 = value;
                if (_cmF2 != null)
                {
                    _cmF2.Click += cmF2_Click;
                }
            }
        }

        private Button _cmRankFont;

        internal Button cmRankFont
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmRankFont;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmRankFont != null)
                {
                    _cmRankFont.Click -= cmRankFont_Click;
                }

                _cmRankFont = value;
                if (_cmRankFont != null)
                {
                    _cmRankFont.Click += cmRankFont_Click;
                }
            }
        }

        private Button _cmF1;

        internal Button cmF1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmF1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmF1 != null)
                {
                    _cmF1.Click -= cmF1_Click;
                }

                _cmF1 = value;
                if (_cmF1 != null)
                {
                    _cmF1.Click += cmF1_Click;
                }
            }
        }

        internal Label lbR1;
        internal Label lbR3;
        private ComboBox _cboA1;

        internal ComboBox cboA1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboA1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboA1 != null)
                {
                    _cboA1.SelectedIndexChanged -= cboA1_SelectedIndexChanged;
                }

                _cboA1 = value;
                if (_cboA1 != null)
                {
                    _cboA1.SelectedIndexChanged += cboA1_SelectedIndexChanged;
                }
            }
        }

        internal PictureBox pbNote;
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

        internal ColorDialog ColorDialog1;
        internal Label lbSize;
        internal Label Label1;
        internal TextBox tbWidth;
        internal TextBox tbHeight;
        internal GroupBox gbBack;
        private ComboBox _cboScaling;

        internal ComboBox cboScaling
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboScaling;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboScaling != null)
                {
                    _cboScaling.SelectedIndexChanged -= cboScaling_SelectedIndexChanged;
                }

                _cboScaling = value;
                if (_cboScaling != null)
                {
                    _cboScaling.SelectedIndexChanged += cboScaling_SelectedIndexChanged;
                }
            }
        }

        internal Label Label7;
        private Button _cmFormColor;

        internal Button cmFormColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmFormColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmFormColor != null)
                {
                    _cmFormColor.Click -= cmFormColor_Click;
                }

                _cmFormColor = value;
                if (_cmFormColor != null)
                {
                    _cmFormColor.Click += cmFormColor_Click;
                }
            }
        }

        private Button _cmFormImage;

        internal Button cmFormImage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmFormImage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmFormImage != null)
                {
                    _cmFormImage.Click -= cmFormImage_Click;
                }

                _cmFormImage = value;
                if (_cmFormImage != null)
                {
                    _cmFormImage.Click += cmFormImage_Click;
                }
            }
        }

        private Button _cmNoImage;

        internal Button cmNoImage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmNoImage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmNoImage != null)
                {
                    _cmNoImage.Click -= cmNoImage_Click;
                }

                _cmNoImage = value;
                if (_cmNoImage != null)
                {
                    _cmNoImage.Click += cmNoImage_Click;
                }
            }
        }

        private Button _cmCopy01;

        internal Button cmCopy01
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCopy01;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCopy01 != null)
                {
                    _cmCopy01.Click -= cmCopy01_Click;
                }

                _cmCopy01 = value;
                if (_cmCopy01 != null)
                {
                    _cmCopy01.Click += cmCopy01_Click;
                }
            }
        }

        private Button _cmCopy02;

        internal Button cmCopy02
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCopy02;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCopy02 != null)
                {
                    _cmCopy02.Click -= cmCopy02_Click;
                }

                _cmCopy02 = value;
                if (_cmCopy02 != null)
                {
                    _cmCopy02.Click += cmCopy02_Click;
                }
            }
        }

        private Button _cmCopy03;

        internal Button cmCopy03
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCopy03;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCopy03 != null)
                {
                    _cmCopy03.Click -= cmCopy03_Click;
                }

                _cmCopy03 = value;
                if (_cmCopy03 != null)
                {
                    _cmCopy03.Click += cmCopy03_Click;
                }
            }
        }

        private Button _cmCopy04;

        internal Button cmCopy04
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCopy04;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCopy04 != null)
                {
                    _cmCopy04.Click -= cmCopy04_Click;
                }

                _cmCopy04 = value;
                if (_cmCopy04 != null)
                {
                    _cmCopy04.Click += cmCopy04_Click;
                }
            }
        }

        private Button _cmCopyAll;

        internal Button cmCopyAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCopyAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCopyAll != null)
                {
                    _cmCopyAll.Click -= cmCopyAll_Click;
                }

                _cmCopyAll = value;
                if (_cmCopyAll != null)
                {
                    _cmCopyAll.Click += cmCopyAll_Click;
                }
            }
        }

        private Button _cmCopySize;

        internal Button cmCopySize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCopySize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCopySize != null)
                {
                    _cmCopySize.Click -= cmCopySize_Click;
                }

                _cmCopySize = value;
                if (_cmCopySize != null)
                {
                    _cmCopySize.Click += cmCopySize_Click;
                }
            }
        }

        private ComboBox _cboDepth;

        internal ComboBox cboDepth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDepth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDepth != null)
                {
                    _cboDepth.SelectedIndexChanged -= cboDepth_SelectedIndexChanged;
                }

                _cboDepth = value;
                if (_cboDepth != null)
                {
                    _cboDepth.SelectedIndexChanged += cboDepth_SelectedIndexChanged;
                }
            }
        }

        internal Label lbDepth;
        private ComboBox _cboOVLScaling;

        internal ComboBox cboOVLScaling
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOVLScaling;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboOVLScaling != null)
                {
                    _cboOVLScaling.SelectedIndexChanged -= cboOVLScaling_SelectedIndexChanged;
                }

                _cboOVLScaling = value;
                if (_cboOVLScaling != null)
                {
                    _cboOVLScaling.SelectedIndexChanged += cboOVLScaling_SelectedIndexChanged;
                }
            }
        }

        internal Label Label2;
        private Button _cmOverlay;

        internal Button cmOverlay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmOverlay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmOverlay != null)
                {
                    _cmOverlay.Click -= cmOverlay_Click;
                }

                _cmOverlay = value;
                if (_cmOverlay != null)
                {
                    _cmOverlay.Click += cmOverlay_Click;
                }
            }
        }

        private Button _cmOVLNoImage;

        internal Button cmOVLNoImage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmOVLNoImage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmOVLNoImage != null)
                {
                    _cmOVLNoImage.Click -= cmOVLNoImage_Click;
                }

                _cmOVLNoImage = value;
                if (_cmOVLNoImage != null)
                {
                    _cmOVLNoImage.Click += cmOVLNoImage_Click;
                }
            }
        }

        internal GroupBox GroupBox1;
        internal ToolTip ToolTip1;
        private ComboBox _cboBordPan;

        internal ComboBox cboBordPan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboBordPan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboBordPan != null)
                {
                    _cboBordPan.SelectedIndexChanged -= cboBordPan_SelectedIndexChanged;
                }

                _cboBordPan = value;
                if (_cboBordPan != null)
                {
                    _cboBordPan.SelectedIndexChanged += cboBordPan_SelectedIndexChanged;
                }
            }
        }

        internal Label Label3;
        private Button _cmBordPanColor;

        internal Button cmBordPanColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmBordPanColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmBordPanColor != null)
                {
                    _cmBordPanColor.Click -= cmBordPanColor_Click;
                }

                _cmBordPanColor = value;
                if (_cmBordPanColor != null)
                {
                    _cmBordPanColor.Click += cmBordPanColor_Click;
                }
            }
        }

        private Button _cmBordColor;

        internal Button cmBordColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmBordColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmBordColor != null)
                {
                    _cmBordColor.Click -= cmBordColor_Click;
                }

                _cmBordColor = value;
                if (_cmBordColor != null)
                {
                    _cmBordColor.Click += cmBordColor_Click;
                }
            }
        }

        private ComboBox _cboBord;

        internal ComboBox cboBord
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboBord;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboBord != null)
                {
                    _cboBord.SelectedIndexChanged -= cboBord_SelectedIndexChanged;
                }

                _cboBord = value;
                if (_cboBord != null)
                {
                    _cboBord.SelectedIndexChanged += cboBord_SelectedIndexChanged;
                }
            }
        }

        internal Label Label6;
        private CheckBox _chkCardBack;

        internal CheckBox chkCardBack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCardBack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCardBack != null)
                {
                    _chkCardBack.CheckedChanged -= chkCardBack_CheckedChanged;
                }

                _chkCardBack = value;
                if (_chkCardBack != null)
                {
                    _chkCardBack.CheckedChanged += chkCardBack_CheckedChanged;
                }
            }
        }

        private Label _lbB2;

        internal Label lbB2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbB2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbB2 != null)
                {
                    _lbB2.Click -= cmB2_Click;
                }

                _lbB2 = value;
                if (_lbB2 != null)
                {
                    _lbB2.Click += cmB2_Click;
                }
            }
        }

        private Label _lbF2;

        internal Label lbF2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbF2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbF2 != null)
                {
                    _lbF2.Click -= cmF2_Click;
                }

                _lbF2 = value;
                if (_lbF2 != null)
                {
                    _lbF2.Click += cmF2_Click;
                }
            }
        }

        private Label _lbB1;

        internal Label lbB1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbB1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbB1 != null)
                {
                    _lbB1.Click -= cmB1_Click;
                }

                _lbB1 = value;
                if (_lbB1 != null)
                {
                    _lbB1.Click += cmB1_Click;
                }
            }
        }

        private Label _lbF1;

        internal Label lbF1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbF1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbF1 != null)
                {
                    _lbF1.Click -= cmF1_Click;
                }

                _lbF1 = value;
                if (_lbF1 != null)
                {
                    _lbF1.Click += cmF1_Click;
                }
            }
        }

        private Label _lbShadowColor;

        internal Label lbShadowColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbShadowColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbShadowColor != null)
                {
                    _lbShadowColor.Click -= cmShadowColor_Click;
                }

                _lbShadowColor = value;
                if (_lbShadowColor != null)
                {
                    _lbShadowColor.Click += cmShadowColor_Click;
                }
            }
        }

        private Label _lbBordColor;

        internal Label lbBordColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbBordColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbBordColor != null)
                {
                    _lbBordColor.Click -= cmBordColor_Click;
                }

                _lbBordColor = value;
                if (_lbBordColor != null)
                {
                    _lbBordColor.Click += cmBordColor_Click;
                }
            }
        }

        private Label _lbBordPanColor;

        internal Label lbBordPanColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbBordPanColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbBordPanColor != null)
                {
                    _lbBordPanColor.Click -= cmBordPanColor_Click;
                }

                _lbBordPanColor = value;
                if (_lbBordPanColor != null)
                {
                    _lbBordPanColor.Click += cmBordPanColor_Click;
                }
            }
        }

        internal Label Label4;
        private ComboBox _cboBordWidth;

        internal ComboBox cboBordWidth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboBordWidth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboBordWidth != null)
                {
                    _cboBordWidth.SelectedIndexChanged -= cboBordWidth_SelectedIndexChanged;
                }

                _cboBordWidth = value;
                if (_cboBordWidth != null)
                {
                    _cboBordWidth.SelectedIndexChanged += cboBordWidth_SelectedIndexChanged;
                }
            }
        }

        internal Label Label5;
        private ComboBox _cboBordPanWidth;

        internal ComboBox cboBordPanWidth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboBordPanWidth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboBordPanWidth != null)
                {
                    _cboBordPanWidth.SelectedIndexChanged -= cboBordPanWidth_SelectedIndexChanged;
                }

                _cboBordPanWidth = value;
                if (_cboBordPanWidth != null)
                {
                    _cboBordPanWidth.SelectedIndexChanged += cboBordPanWidth_SelectedIndexChanged;
                }
            }
        }
    }
}