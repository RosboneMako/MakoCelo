using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{

    // ************************************************************
    // R4.00 A dialog box class for CELO and NOTE setup options.
    // ************************************************************
    public partial class frmLabelSetup
    {
        public frmLabelSetup(bool displayTooltips)
        {
            InitializeComponent();
            _lbShadowColor.Name = "lbShadowColor";
            _lbBordColor.Name = "lbBordColor";
            _lbB2.Name = "lbB2";
            _lbF2.Name = "lbF2";
            _lbB1.Name = "lbB1";
            _lbF1.Name = "lbF1";
            _cmBordColor.Name = "cmBordColor";
            _cboBord.Name = "cboBord";
            _cboDepth.Name = "cboDepth";
            _cmShadowColor.Name = "cmShadowColor";
            _cbo3D.Name = "cbo3D";
            _cmRankFont.Name = "cmRankFont";
            _cboA2.Name = "cboA2";
            _cmBR.Name = "cmBR";
            _cmBD.Name = "cmBD";
            _cmFR.Name = "cmFR";
            _cmFD.Name = "cmFD";
            _cmB2.Name = "cmB2";
            _cmB1.Name = "cmB1";
            _cmF2.Name = "cmF2";
            _cmF1.Name = "cmF1";
            _cboA1.Name = "cboA1";
            _cmCancel.Name = "cmCancel";
            _cmOK.Name = "cmOK";
            _lbBordPanColor.Name = "lbBordPanColor";
            _chkCardBack.Name = "chkCardBack";
            _cmBordPanColor.Name = "cmBordPanColor";
            _cboBordPan.Name = "cboBordPan";
            _cboScaling.Name = "cboScaling";
            _cmFormColor.Name = "cmFormColor";
            _cmFormImage.Name = "cmFormImage";
            _cmNoImage.Name = "cmNoImage";
            _cboOVLScaling.Name = "cboOVLScaling";
            _cmOverlay.Name = "cmOverlay";
            _cmCopy01.Name = "cmCopy01";
            _cmCopy02.Name = "cmCopy02";
            _cmCopy03.Name = "cmCopy03";
            _cmCopy04.Name = "cmCopy04";
            _cmCopyAll.Name = "cmCopyAll";
            _cmCopySize.Name = "cmCopySize";
            _cmOVLNoImage.Name = "cmOVLNoImage";
            _cboBordWidth.Name = "cboBordWidth";
            _cboBordPanWidth.Name = "cboBordPanWidth";
            _displayTooltips = displayTooltips;
        }

        // R4.00 Create some PROPERTIES that hide/show dialog controls.
        private clsGlobal.t_LabelSetup _LSetup = new clsGlobal.t_LabelSetup();
        private bool _HideSizeOptions = false;
        private bool _HideImageOptions = false;
        private bool _HideScalingOptions = false;
        private bool _HideSizeAll = false;
        private bool _HideFormColor = false;
        private bool _Cancel = true;
        private readonly bool _displayTooltips;

        public clsGlobal.t_LabelSetup LSetup
        {
            get
            {
                return _LSetup;
            }

            set
            {
                _LSetup = value;
            }
        }

        public bool HideSizeOptions
        {
            get
            {
                return _HideSizeOptions;
            }

            set
            {
                _HideSizeOptions = value;
            }
        }

        public bool HideImageOptions
        {
            get
            {
                return _HideImageOptions;
            }

            set
            {
                _HideImageOptions = value;
            }
        }

        public bool HideScalingOptions
        {
            get
            {
                return _HideScalingOptions;
            }

            set
            {
                _HideScalingOptions = value;
            }
        }

        public bool HideSizeAll
        {
            get
            {
                return _HideSizeAll;
            }

            set
            {
                _HideSizeAll = value;
            }
        }

        public bool HideFormColor
        {
            get
            {
                return _HideFormColor;
            }

            set
            {
                _HideFormColor = value;
            }
        }

        public bool Cancel
        {
            get
            {
                return _Cancel;
            }

            set
            {
                _Cancel = value;
            }
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            long N;
            N = (long)Math.Round(Conversion.Val(tbWidth.Text));
            if (N < 1L)
                N = 1L;
            if (32000L < N)
                N = 32000L;
            _LSetup.Width = (int)N;
            N = (long)Math.Round(Conversion.Val(tbHeight.Text));
            if (N < 1L)
                N = 1L;
            if (32000L < N)
                N = 32000L;
            _LSetup.Height = (int)N;
            _Cancel = false;
            Close();
        }

        private void cmCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmF1_Click(object sender, EventArgs e)
        {
            ColorDialog1.Color = _LSetup.F1;
            ColorDialog1.ShowDialog();
            _LSetup.F1 = ColorDialog1.Color;
            GFX_DrawStats();
            lbF1.BackColor = _LSetup.F1;
        }

        private void cmF2_Click(object sender, EventArgs e)
        {
            ColorDialog1.Color = _LSetup.F2;
            ColorDialog1.ShowDialog();
            _LSetup.F2 = ColorDialog1.Color;
            GFX_DrawStats();
            lbF2.BackColor = _LSetup.F2;
        }

        private void cmB1_Click(object sender, EventArgs e)
        {
            ColorDialog1.Color = _LSetup.B1;
            ColorDialog1.ShowDialog();
            _LSetup.B1 = ColorDialog1.Color;
            GFX_DrawStats();
            lbB1.BackColor = _LSetup.B1;
        }

        private void cmB2_Click(object sender, EventArgs e)
        {
            ColorDialog1.Color = _LSetup.B2;
            ColorDialog1.ShowDialog();
            _LSetup.B2 = ColorDialog1.Color;
            GFX_DrawStats();
            lbB2.BackColor = _LSetup.B2;
        }

        private void frmLabelSetup_Load(object sender, EventArgs e)
        {

            // R4.00 Setup ToolTips
            ToolTip_Setup();
            if (_displayTooltips)
            {
                ToolTip1.Active = true;
            }
            else
            {
                ToolTip1.Active = false;
            }

            // R4.40 Get CardBack option.
            if (_LSetup.UseCardBack)
            {
                chkCardBack.Checked = true;
            }
            else
            {
                chkCardBack.Checked = false;
            }

            lbF1.BackColor = _LSetup.F1;
            lbF2.BackColor = _LSetup.F2;
            lbB1.BackColor = _LSetup.B1;
            lbB2.BackColor = _LSetup.B2;

            // R4.00 Setup the ALPHA combos.
            cboA1.Items.Add("100%");
            cboA1.Items.Add("90%");
            cboA1.Items.Add("80%");
            cboA1.Items.Add("70%");
            cboA1.Items.Add("60%");
            cboA1.Items.Add("50%");
            cboA1.Items.Add("40%");
            cboA1.Items.Add("30%");
            cboA1.Items.Add("20%");
            cboA1.Items.Add("10%");
            cboA1.Items.Add("0%");
            cboA1.Text = Strings.Format(_LSetup.O1, "#0") + "%";

            // R4.00 Setup the ALPHA combos.
            cboA2.Items.Add("100%");
            cboA2.Items.Add("90%");
            cboA2.Items.Add("80%");
            cboA2.Items.Add("70%");
            cboA2.Items.Add("60%");
            cboA2.Items.Add("50%");
            cboA2.Items.Add("40%");
            cboA2.Items.Add("30%");
            cboA2.Items.Add("20%");
            cboA2.Items.Add("10%");
            cboA2.Items.Add("0%");
            cboA2.Text = Strings.Format(_LSetup.O2, "#0") + "%";
            cboBord.Items.Add("None");
            cboBord.Items.Add("Color");
            cboBord.Items.Add("Glow");
            cboBord.Items.Add("3D");
            cboBord.Items.Add("Round Sm");
            cboBord.Items.Add("Round Md");
            cboBord.Items.Add("Round Lg");
            cboBord.SelectedIndex = _LSetup.BorderMode;
            lbBordColor.BackColor = _LSetup.BorderColor;
            cboBordWidth.Items.Add("1 px");
            cboBordWidth.Items.Add("2 px");
            cboBordWidth.Items.Add("3 px");
            cboBordWidth.Items.Add("4 px");
            cboBordWidth.Items.Add("5 px");
            cboBordWidth.SelectedIndex = _LSetup.BorderWidth;
            cbo3D.Items.Add("--");
            cbo3D.Items.Add("45°");
            cbo3D.Items.Add("90°");
            cbo3D.Items.Add("135°");
            cbo3D.Items.Add("180°");
            cbo3D.Items.Add("225°");
            cbo3D.Items.Add("270°");
            cbo3D.Items.Add("315°");
            cbo3D.Items.Add("360°");
            cbo3D.Text = _LSetup.ShadowDir;
            lbShadowColor.BackColor = _LSetup.ShadowColor;
            cboDepth.Items.Add("0 px");
            cboDepth.Items.Add("1 px");
            cboDepth.Items.Add("2 px");
            cboDepth.Items.Add("3 px");
            cboDepth.Items.Add("4 px");
            cboDepth.Items.Add("5 px");
            cboDepth.Text = _LSetup.ShadowDepth;  // R4.41 Bug Fix.
            tbWidth.Text = _LSetup.Width.ToString();
            tbHeight.Text = _LSetup.Height.ToString();
            cboScaling.Items.Add("Normal");
            cboScaling.Items.Add("Tile");
            cboScaling.Items.Add("Fit");
            cboScaling.SelectedIndex = (int)Math.Round(Conversion.Val(_LSetup.Scaling));
            cboBordPan.Items.Add("None");
            cboBordPan.Items.Add("Color");
            cboBordPan.Items.Add("Glow");
            cboBordPan.Items.Add("3D");
            cboBordPan.Items.Add("Round Sm");
            cboBordPan.Items.Add("Round Md");
            cboBordPan.Items.Add("Round Lg");
            cboBordPan.SelectedIndex = _LSetup.BorderPanelMode;
            lbBordPanColor.BackColor = _LSetup.BorderPanelColor;
            cboBordPanWidth.Items.Add("1 px");
            cboBordPanWidth.Items.Add("2 px");
            cboBordPanWidth.Items.Add("3 px");
            cboBordPanWidth.Items.Add("4 px");
            cboBordPanWidth.Items.Add("5 px");
            cboBordPanWidth.SelectedIndex = _LSetup.BorderPanelWidth;
            cboOVLScaling.Items.Add("Normal");
            cboOVLScaling.Items.Add("Tile");
            cboOVLScaling.Items.Add("Fit");
            cboOVLScaling.SelectedIndex = Conversions.ToInteger(_LSetup.OVLScaling);

            // R3.50 Deal with dialog options set by caller.
            if (HideSizeOptions == true)
            {
                // R4.40 RANK and NAME Setups.
                tbWidth.Enabled = false;
                tbHeight.Enabled = false;
            }
            else
            {
                // R4.40 Hide border options on NOTES.
                cmBordColor.Enabled = false;
                lbBordColor.Enabled = false;
                cboBord.Enabled = false;
                cboBordWidth.Enabled = false;
                cmBordPanColor.Enabled = false;
                lbBordPanColor.Enabled = false;
                cboBordPan.Enabled = false;
                cboBordPanWidth.Enabled = false;
                chkCardBack.Enabled = false;
            }

            if (HideImageOptions == true)
            {
                cmFormColor.Enabled = false;
                cmFormImage.Enabled = false;
                cmNoImage.Enabled = false;
                cmOVLNoImage.Enabled = false;
                cmOverlay.Enabled = false;
                cboOVLScaling.Enabled = false;
            }

            if (HideScalingOptions == true)
            {
                cboScaling.Enabled = false;
            }

            if (HideSizeAll == true)
            {
                cmCopySize.Enabled = false;
            }

            if (HideFormColor == true)
            {
                cmFormColor.Enabled = false;
            }

            tbWidth.Text = _LSetup.Width.ToString();
            tbHeight.Text = _LSetup.Height.ToString();
        }

        private void ToolTip_Setup()
        {
            ToolTip1.SetToolTip(cmF1, "Set text gradient color #1.");
            ToolTip1.SetToolTip(cmF2, "Set text gradient color #2.");
            ToolTip1.SetToolTip(cmFD, "Set the text gradient direction to Down.");
            ToolTip1.SetToolTip(cmFR, "Set the text gradient direction to Sideways.");
            ToolTip1.SetToolTip(cmB1, "Set background gradient color #1.");
            ToolTip1.SetToolTip(cmB2, "Set background gradient color #2.");
            ToolTip1.SetToolTip(cmBD, "Set the background gradient direction to Down.");
            ToolTip1.SetToolTip(cmBR, "Set the background gradient direction to Sideways.");
            ToolTip1.SetToolTip(cboA1, "Set background Alpha/Opacity #1. Set low with no background gives blur effect.");
            ToolTip1.SetToolTip(cboA2, "Set background Alpha/Opacity #2. Set low with no background gives blur effect.");
            ToolTip1.SetToolTip(cmBordColor, "Select a color used for object border drawing.");
            ToolTip1.SetToolTip(cboBord, "Select a border style to draw on these objects.");
            ToolTip1.SetToolTip(cboBordWidth, "Select a line width option for the border object.");
            ToolTip1.SetToolTip(cmShadowColor, "Set text shadow color.");
            ToolTip1.SetToolTip(cbo3D, "Set text shadow location.0/360 is East.");
            ToolTip1.SetToolTip(cboDepth, "Set text shadow XY offset.");
            ToolTip1.SetToolTip(cmFormColor, "Set the background image color. Not used for NOTES.");
            ToolTip1.SetToolTip(cmNoImage, "Clear the current background image.");
            ToolTip1.SetToolTip(cmFormImage, "Select a background image." + Constants.vbCr + "For best results use images the same size as the NOTE/CELO object.");
            ToolTip1.SetToolTip(cboScaling, "Set how the background image will be scaled/drawn." + Constants.vbCr + "For best results use NORMAL or TILE.");
            ToolTip1.SetToolTip(cmBordPanColor, "Select a color used for outside panel border drawing.");
            ToolTip1.SetToolTip(cboBordPan, "Select a border style to draw on the panel.");
            ToolTip1.SetToolTip(cboBordPanWidth, "Select a line width option for the border object.");
            ToolTip1.SetToolTip(chkCardBack, "Use the panel image when drawing player cards. Panel color is the default background.");
            ToolTip1.SetToolTip(cmOVLNoImage, "Clear the current overlay image.");
            ToolTip1.SetToolTip(cmOverlay, "Select an overlay image. Image should be a PNG with alpha." + Constants.vbCr + "Can have green screen areas for stream chromakey/overlay." + Constants.vbCr + "For best results use images the same size as the NOTE/CELO object.");
            ToolTip1.SetToolTip(cboOVLScaling, "Set how the CELO overlay image will be scaled/drawn." + Constants.vbCr + "For best results use NORMAL or TILE.");
            ToolTip1.SetToolTip(cmCopy01, "Set this text setup style to NOTE #1 style.");
            ToolTip1.SetToolTip(cmCopy02, "Set this text setup style to NOTE #2 style.");
            ToolTip1.SetToolTip(cmCopy03, "Set this text setup style to NOTE #3 style.");
            ToolTip1.SetToolTip(cmCopy04, "Set this text setup style to NOTE #4 style.");
            ToolTip1.SetToolTip(cmCopyAll, "Set all text setup styles to the current style.");
            ToolTip1.SetToolTip(cmCopySize, "Set all NOTE sizes to the current size.");
        }

        private void cmShadowColor_Click(object sender, EventArgs e)
        {
            ColorDialog1.Color = _LSetup.ShadowColor;
            ColorDialog1.ShowDialog();
            _LSetup.ShadowColor = ColorDialog1.Color;
            GFX_DrawStats();
            lbShadowColor.BackColor = _LSetup.ShadowColor;
        }

        private void cboA1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LSetup.O1 = (int)Math.Round(Conversion.Val(cboA1.Text));
            GFX_DrawStats();
        }

        private void cboA2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LSetup.O2 = (int)Math.Round(Conversion.Val(cboA2.Text));
            GFX_DrawStats();
        }

        private void cmRankFont_Click(object sender, EventArgs e)
        {
            var fontDialog1 = new FontDialog();

            // R1.00 Get current font.
            fontDialog1.Font = frmMain.FONT_Setup;    // R3.00 lbRank01.Font    

            // R1.00 Get user selected font, store it, and redraw controls.
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                frmMain.FONT_Setup = fontDialog1.Font;                           // R3.00 Moved Font tracking to a VAR now.
                frmMain.FONT_Setup_Name = fontDialog1.Font.Name;
                frmMain.FONT_Setup_Size = fontDialog1.Font.Size.ToString();
                frmMain.FONT_Setup_Bold = Conversions.ToString(fontDialog1.Font.Bold);
                frmMain.FONT_Setup_Italic = Conversions.ToString(fontDialog1.Font.Italic);
            }

            GFX_DrawStats();
        }

        private void cbo3D_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LSetup.ShadowDir = cbo3D.Text;
            switch (_LSetup.ShadowDir ?? "")
            {
                case "45°":
                    {
                        _LSetup.ShadowX = 1;
                        _LSetup.ShadowY = -1;
                        break;
                    }

                case "90°":
                    {
                        _LSetup.ShadowX = 0;
                        _LSetup.ShadowY = -1;
                        break;
                    }

                case "135°":
                    {
                        _LSetup.ShadowX = -1;
                        _LSetup.ShadowY = -1;
                        break;
                    }

                case "180°":
                    {
                        _LSetup.ShadowX = -1;
                        _LSetup.ShadowY = 0;
                        break;
                    }

                case "225°":
                    {
                        _LSetup.ShadowX = -1;
                        _LSetup.ShadowY = 1;
                        break;
                    }

                case "270°":
                    {
                        _LSetup.ShadowX = 0;
                        _LSetup.ShadowY = 1;
                        break;
                    }

                case "315°":
                    {
                        _LSetup.ShadowX = 1;
                        _LSetup.ShadowY = 1;
                        break;
                    }

                case "360°":
                    {
                        _LSetup.ShadowX = 1;
                        _LSetup.ShadowY = 0;
                        break;
                    }

                default:
                    {
                        _LSetup.ShadowX = 0;
                        _LSetup.ShadowY = 0;
                        break;
                    }
            }

            GFX_DrawStats();
        }

        private void cmFD_Click(object sender, EventArgs e)
        {
            _LSetup.FDir = 0;
            GFX_DrawStats();
        }

        private void cmFR_Click(object sender, EventArgs e)
        {
            _LSetup.FDir = 1;
            GFX_DrawStats();
        }

        private void cmBD_Click(object sender, EventArgs e)
        {
            _LSetup.BDir = 0;
            GFX_DrawStats();
        }

        private void cmBR_Click(object sender, EventArgs e)
        {
            _LSetup.BDir = 1;
            GFX_DrawStats();
        }

        private void cmNoImage_Click(object sender, EventArgs e)
        {
            // R4.00 Modified.
            frmMain.Note_BackBmp = null;
            frmMain.PATH_DlgBmp = "";
            GFX_DrawStats();
        }

        private void cmFormImage_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Title = "Background Image Dialog";
            if (!string.IsNullOrEmpty(frmMain.PATH_DlgBmp))
            {
                fd.InitialDirectory = Utilities.PATH_StripFilename(frmMain.PATH_DlgBmp);
            }
            else
            {
                fd.InitialDirectory = Utilities.PATH_GetAnyPath();
            }

            // R4.40 Added BMP and ALL option.
            fd.Filter = "Bitmap (*.bmp)|*.bmp|Png (*.png)|*.png|Gif (*.gif)|*.gif|Jpeg (*.jpg)|*.jpg|All (*.gif,*.png,*.jpg,*.bmp)|*.jpg;*.gif;*.png;*.bmp";
            fd.FilterIndex = 5;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                frmMain.Note_BackBmp = new Bitmap(fd.FileName);
                frmMain.PATH_DlgBmp = fd.FileName;

                // R2.00 Strip the filename off for init dir on dialog.  
                frmMain.PATH_DlgBmpPath = Utilities.PATH_StripFilename(frmMain.PATH_DlgBmp);
            }

            GFX_DrawStats();
        }

        private void GFX_DrawStats()
        {
            int tLabHgt;
            int Cx, Cy, Cx2, Cy2;
            LinearGradientBrush linGrBrush;
            int tX, tY;
            var tFont = frmMain.FONT_Setup;
            int TextHgt12;
            Pen tPen;

            // R3.50 Precalc some vars for readability in code.
            tLabHgt = pbNote.Height / 2;

            // R3.50 Create a bitmap memory image to draw stats to. 
            var BM = new Bitmap(pbNote.Width, pbNote.Height);
            var Gfx = Graphics.FromImage(BM);

            // *****************************************************************
            // R3.50 Draw the stats page background.
            // *****************************************************************
            if (frmMain.Note_BackBmp is null)
            {
                // R3.00 No image available so draw a solid color background.
                Gfx.FillRectangle(new SolidBrush(_LSetup.BackC), 0, 0, pbNote.Width, pbNote.Height);
            }
            else
            {
                // R3.00 Scale and Draw the background image.
                switch (Conversion.Val(cboScaling.Text))
                {
                    case 0d:   // R3.00 Normal Scaling
                        {
                            Gfx.DrawImage(frmMain.Note_BackBmp, 0, 0, frmMain.Note_BackBmp.Width, frmMain.Note_BackBmp.Height);
                            break;
                        }

                    case 1d:   // R3.00 Tiled Scaling
                        {
                            var loopTo = BM.Height;
                            for (tY = 0; frmMain.Note_BackBmp.Height >= 0 ? tY <= loopTo : tY >= loopTo; tY += frmMain.Note_BackBmp.Height)
                            {
                                var loopTo1 = BM.Width;
                                for (tX = 0; frmMain.Note_BackBmp.Width >= 0 ? tX <= loopTo1 : tX >= loopTo1; tX += frmMain.Note_BackBmp.Width)
                                    Gfx.DrawImage(frmMain.Note_BackBmp, tX, tY, frmMain.Note_BackBmp.Width, frmMain.Note_BackBmp.Height);
                            }

                            break;
                        }

                    case 2d: // R3.00 Stretch/Fit Scaling
                        {
                            Gfx.DrawImage(frmMain.Note_BackBmp, 0, 0, BM.Width, BM.Height);
                            break;
                        }
                }
            }

            // *****************************************************************
            // R3.10 Draw the Name background rectangles
            // *****************************************************************  
            var tBrush = new SolidBrush(_LSetup.B1);       // R3.50  Color of Back 1.
            var tBrushFore = new SolidBrush(_LSetup.F1);   // R3.50  Color of Fore 1.
            Color C1, C2;
            int tAlpha;
            tAlpha = (int)Math.Round(Conversion.Val(cboA1.Text) * 2.55d);
            C1 = Color.FromArgb(tAlpha, _LSetup.B1.R, _LSetup.B1.G, _LSetup.B1.B);
            tAlpha = (int)Math.Round(Conversion.Val(cboA2.Text) * 2.55d);
            C2 = Color.FromArgb(tAlpha, _LSetup.B2.R, _LSetup.B2.G, _LSetup.B2.B);

            // R3.00 Draw the NAME background rectangle.
            if (_LSetup.BDir == 0)
            {
                linGrBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, pbNote.Height), C1, C2);
            }
            else
            {
                linGrBrush = new LinearGradientBrush(new Point(0, 0), new Point(pbNote.Width, 0), C1, C2);
            }

            Gfx.FillRectangle(linGrBrush, 0, 0, pbNote.Width, pbNote.Height);
            switch (_LSetup.BorderMode)
            {
                case 0:
                    {
                        break;
                    }

                case 1:
                case 4:
                case 5:
                case 6: // R4.40 Normal.
                    {
                        tPen = new Pen(new SolidBrush(_LSetup.BorderColor));
                        tPen.Width = _LSetup.BorderWidth;
                        Gfx.DrawRectangle(tPen, 2, 2, pbNote.Width - 3, pbNote.Height - 3);
                        break;
                    }

                case 2: // R4.40 Glow
                    {
                        Gfx.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(255, _LSetup.BorderColor.R, _LSetup.BorderColor.G, _LSetup.BorderColor.B))), 2, 2, pbNote.Width - 3, pbNote.Height - 3);
                        Gfx.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(192, _LSetup.BorderColor.R, _LSetup.BorderColor.G, _LSetup.BorderColor.B))), 3, 3, pbNote.Width - 5, pbNote.Height - 5);
                        Gfx.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(64, _LSetup.BorderColor.R, _LSetup.BorderColor.G, _LSetup.BorderColor.B))), 4, 4, pbNote.Width - 7, pbNote.Height - 7);
                        break;
                    }

                case 3: // R4.40 3D
                    {
                        tPen = new Pen(new SolidBrush(_LSetup.BorderColor));
                        tPen.Width = _LSetup.BorderWidth;
                        Gfx.DrawLine(tPen, 2, 2, pbNote.Width - 1, 2);
                        Gfx.DrawLine(tPen, 2, 2, 2, pbNote.Height - 1);
                        tPen = new Pen(new SolidBrush(Color.FromArgb(255, 0, 0, 0)));
                        tPen.Width = _LSetup.BorderWidth;
                        Gfx.DrawLine(tPen, pbNote.Width - 1, 1, pbNote.Width - 1, pbNote.Height - 1);
                        Gfx.DrawLine(tPen, 1, pbNote.Height - 1, pbNote.Width - 1, pbNote.Height - 1);
                        break;
                    }
            }


            // *****************************************************************
            // R3.50 Draw the note TEXT.
            // *****************************************************************  
            Brush tBrushShadow = new SolidBrush(_LSetup.ShadowColor);
            TextHgt12 = (int)Math.Round(Gfx.MeasureString("X", frmMain.FONT_Setup).Height / 2f);       // R3.30 Changed from Xq.


            // R3.50 Draw the shadow text.
            Cx = 0;
            Cy = (int)Math.Round(pbNote.Height / 2d - TextHgt12);
            switch (_LSetup.ShadowDir ?? "")
            {
                case "45°":
                    {
                        Cx2 = 1;
                        Cy2 = -1;
                        break;
                    }

                case "90°":
                    {
                        Cx2 = 0;
                        Cy2 = -1;
                        break;
                    }

                case "135°":
                    {
                        Cx2 = -1;
                        Cy2 = -1;
                        break;
                    }

                case "180°":
                    {
                        Cx2 = -1;
                        Cy2 = 0;
                        break;
                    }

                case "225°":
                    {
                        Cx2 = -1;
                        Cy2 = 1;
                        break;
                    }

                case "270°":
                    {
                        Cx2 = 0;
                        Cy2 = 1;
                        break;
                    }

                case "315°":
                    {
                        Cx2 = 1;
                        Cy2 = 1;
                        break;
                    }

                case "360°":
                    {
                        Cx2 = 1;
                        Cy2 = 0;
                        break;
                    }

                default:
                    {
                        Cx2 = 0;
                        Cy2 = 0;
                        break;
                    }
            }

            if (Cx2 != 0 | Cy2 != 0)
                Gfx.DrawString("Test Sample Text", frmMain.FONT_Setup, tBrushShadow, (float)(Cx + Cx2 * Conversion.Val(_LSetup.ShadowDepth)), (float)(Cy + Cy2 * Conversion.Val(_LSetup.ShadowDepth)));

            // R3.50 Draw the gradient Text.
            // R3.50 Setup LINEAR gradient brushed for TEXT.
            if (_LSetup.FDir == 0)
            {
                linGrBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, pbNote.Height), Color.FromArgb(255, _LSetup.F1.R, _LSetup.F1.G, _LSetup.F1.B), Color.FromArgb(255, _LSetup.F2.R, _LSetup.F2.G, _LSetup.F2.B));
            }
            else
            {
                linGrBrush = new LinearGradientBrush(new Point(0, 0), new Point(pbNote.Width, 0), Color.FromArgb(255, _LSetup.F1.R, _LSetup.F1.G, _LSetup.F1.B), Color.FromArgb(255, _LSetup.F2.R, _LSetup.F2.G, _LSetup.F2.B));
            }

            Gfx.DrawString("Test Sample Text", frmMain.FONT_Setup, linGrBrush, Cx, Cy);


            // *****************************************************************
            // R3.50 Draw the OVERLAY background.
            // *****************************************************************
            if (HideImageOptions == false)
            {
                if (frmMain.Note_OVLBmp is object)
                {
                    // R3.00 Scale and Draw the background image.
                    switch (Conversion.Val(cboOVLScaling.Text))
                    {
                        case 0d:   // R3.00 Normal Scaling
                            {
                                Gfx.DrawImage(frmMain.Note_OVLBmp, 0, 0, frmMain.Note_OVLBmp.Width, frmMain.Note_OVLBmp.Height);
                                break;
                            }

                        case 1d:   // R3.00 Tiled Scaling
                            {
                                var loopTo2 = BM.Height;
                                for (tY = 0; frmMain.Note_OVLBmp.Height >= 0 ? tY <= loopTo2 : tY >= loopTo2; tY += frmMain.Note_OVLBmp.Height)
                                {
                                    var loopTo3 = BM.Width;
                                    for (tX = 0; frmMain.Note_OVLBmp.Width >= 0 ? tX <= loopTo3 : tX >= loopTo3; tX += frmMain.Note_OVLBmp.Width)
                                        Gfx.DrawImage(frmMain.Note_OVLBmp, tX, tY, frmMain.Note_OVLBmp.Width, frmMain.Note_OVLBmp.Height);
                                }

                                break;
                            }

                        case 2d: // R3.00 Stretch/Fit Scaling
                            {
                                Gfx.DrawImage(frmMain.Note_OVLBmp, 0, 0, BM.Width, BM.Height);
                                break;
                            }
                    }
                }
            }

            pbNote.Image = BM;
        }

        private void cmFormColor_Click(object sender, EventArgs e)
        {
            ColorDialog1.Color = _LSetup.BackC;
            ColorDialog1.ShowDialog();
            _LSetup.BackC = ColorDialog1.Color;          // R3.50 Added.
            GFX_DrawStats();
        }

        private void cmCopy01_Click(object sender, EventArgs e)
        {
            // R3.50 Get the data we are editing.
            _LSetup = frmMain.LSNote01;
            cboA1.Text = Strings.Format(_LSetup.O1, "#0") + "%";
            cboA2.Text = Strings.Format(_LSetup.O2, "#0") + "%";
            cbo3D.Text = _LSetup.ShadowDir;
            frmMain.FONT_Setup = frmMain.FONT_Note01;
            frmMain.PATH_DlgBmp = frmMain.PATH_Note01_Bmp;                              // R3.50 Path for back image.
            frmMain.Note_BackBmp = frmMain.Note01_BackBmp;                              // R3.50 Back Image.
            frmMain.PATH_DlgBmpPath = Utilities.PATH_StripFilename(frmMain.PATH_DlgBmp);  // R3.50 Path without Filename. 
            frmMain.FONT_Setup = frmMain.FONT_Note01;
            GFX_DrawStats();
        }

        private void cmCopy02_Click(object sender, EventArgs e)
        {
            // R3.50 Get the data we are editing.
            _LSetup = frmMain.LSNote02;
            cboA1.Text = Strings.Format(_LSetup.O1, "#0") + "%";
            cboA2.Text = Strings.Format(_LSetup.O2, "#0") + "%";
            cbo3D.Text = _LSetup.ShadowDir;
            frmMain.FONT_Setup = frmMain.FONT_Note02;
            frmMain.PATH_DlgBmp = frmMain.PATH_Note02_Bmp;                              // R3.50 Path for back image.
            frmMain.Note_BackBmp = frmMain.Note02_BackBmp;                              // R3.50 Back Image.
            frmMain.PATH_DlgBmpPath = Utilities.PATH_StripFilename(frmMain.PATH_DlgBmp);  // R3.50 Path without Filename. 
            frmMain.FONT_Setup = frmMain.FONT_Note02;
            GFX_DrawStats();
        }

        private void cmCopy03_Click(object sender, EventArgs e)
        {
            // R3.50 Get the data we are editing.
            _LSetup = frmMain.LSNote03;
            cboA1.Text = Strings.Format(_LSetup.O1, "#0") + "%";
            cboA2.Text = Strings.Format(_LSetup.O2, "#0") + "%";
            cbo3D.Text = _LSetup.ShadowDir;
            frmMain.FONT_Setup = frmMain.FONT_Note03;
            frmMain.PATH_DlgBmp = frmMain.PATH_Note03_Bmp;                              // R3.50 Path for back image.
            frmMain.Note_BackBmp = frmMain.Note03_BackBmp;                              // R3.50 Back Image.
            frmMain.PATH_DlgBmpPath = Utilities.PATH_StripFilename(frmMain.PATH_DlgBmp);  // R3.50 Path without Filename. 
            frmMain.FONT_Setup = frmMain.FONT_Note03;
            GFX_DrawStats();
        }

        private void cmCopy04_Click(object sender, EventArgs e)
        {
            // R3.50 Get the data we are editing.
            _LSetup = frmMain.LSNote04;
            cboA1.Text = Strings.Format(_LSetup.O1, "#0") + "%";
            cboA2.Text = Strings.Format(_LSetup.O2, "#0") + "%";
            cbo3D.Text = _LSetup.ShadowDir;
            frmMain.FONT_Setup = frmMain.FONT_Note04;
            frmMain.PATH_DlgBmp = frmMain.PATH_Note04_Bmp;                              // R3.50 Path for back image.
            frmMain.Note_BackBmp = frmMain.Note04_BackBmp;                              // R3.50 Back Image.
            frmMain.PATH_DlgBmpPath = Utilities.PATH_StripFilename(frmMain.PATH_DlgBmp);  // R3.50 Path without Filename. 
            frmMain.FONT_Setup = frmMain.FONT_Note04;
            GFX_DrawStats();
        }

        private void cmCopyAll_Click(object sender, EventArgs e)
        {
            int tWid, tHgt;

            // R3.50 Copy current setup to NOTE01. Dont change NOTE size.
            tWid = frmMain.LSNote01.Width;
            tHgt = frmMain.LSNote01.Height;
            frmMain.LSNote01 = _LSetup;
            frmMain.LSNote01.Width = tWid;
            frmMain.LSNote01.Height = tHgt;
            frmMain.PATH_Note01_Bmp = frmMain.PATH_DlgBmp;        // R4.00 Path for back image.
            frmMain.Note01_BackBmp = frmMain.Note_BackBmp;        // R4.00 Back Image.
            frmMain.PATH_Note01_OVLBmp = frmMain.PATH_DlgOVLBmp;  // R4.00 Path for Overlay image.
            frmMain.Note01_OVLBmp = frmMain.Note_OVLBmp;          // R4.00 Overlay Image.
            frmMain.FONT_Note01 = frmMain.FONT_Setup;
            frmMain.FONT_Note01_Name = frmMain.FONT_Setup.Name;
            frmMain.FONT_Note01_Size = frmMain.FONT_Setup.Size.ToString();
            frmMain.FONT_Note01_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
            frmMain.FONT_Note01_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
            frmMain.LSNote01.B1 = Color.FromArgb((int)Math.Round(255d * (Conversion.Val(frmMain.LSNote01.O1) * 0.01d)), frmMain.LSNote01.B1.R, frmMain.LSNote01.B1.G, frmMain.LSNote01.B1.B);
            frmMain.LSNote01.B2 = Color.FromArgb((int)Math.Round(255d * (Conversion.Val(frmMain.LSNote01.O2) * 0.01d)), frmMain.LSNote01.B2.R, frmMain.LSNote01.B2.G, frmMain.LSNote01.B2.B);

            // R3.50 Copy current setup to NOTE02. Dont change NOTE size.
            tWid = frmMain.LSNote02.Width;
            tHgt = frmMain.LSNote02.Height;
            frmMain.LSNote02 = _LSetup;
            frmMain.LSNote02.Width = tWid;
            frmMain.LSNote02.Height = tHgt;
            frmMain.PATH_Note02_Bmp = frmMain.PATH_DlgBmp;     // R3.50 Path for back image.
            frmMain.Note02_BackBmp = frmMain.Note_BackBmp;     // R3.50 Back Image.
            frmMain.PATH_Note02_OVLBmp = frmMain.PATH_DlgOVLBmp;  // R4.00 Path for Overlay image.
            frmMain.Note02_OVLBmp = frmMain.Note_OVLBmp;          // R4.00 Overlay Image.
            frmMain.FONT_Note02 = frmMain.FONT_Setup;
            frmMain.FONT_Note02_Name = frmMain.FONT_Setup.Name;
            frmMain.FONT_Note02_Size = frmMain.FONT_Setup.Size.ToString();
            frmMain.FONT_Note02_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
            frmMain.FONT_Note02_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
            frmMain.LSNote02.B1 = Color.FromArgb((int)Math.Round(255d * (Conversion.Val(frmMain.LSNote02.O1) * 0.01d)), frmMain.LSNote02.B1.R, frmMain.LSNote02.B1.G, frmMain.LSNote02.B1.B);
            frmMain.LSNote02.B2 = Color.FromArgb((int)Math.Round(255d * (Conversion.Val(frmMain.LSNote02.O2) * 0.01d)), frmMain.LSNote02.B2.R, frmMain.LSNote02.B2.G, frmMain.LSNote02.B2.B);

            // R3.50 Copy current setup to NOTE03. Dont change NOTE size.
            tWid = frmMain.LSNote03.Width;
            tHgt = frmMain.LSNote03.Height;
            frmMain.LSNote03 = _LSetup;
            frmMain.LSNote03.Width = tWid;
            frmMain.LSNote03.Height = tHgt;
            frmMain.PATH_Note03_Bmp = frmMain.PATH_DlgBmp;        // R4.00 Path for back image.
            frmMain.Note03_BackBmp = frmMain.Note_BackBmp;        // R4.00 Back Image.
            frmMain.PATH_Note03_OVLBmp = frmMain.PATH_DlgOVLBmp;  // R4.00 Path for Overlay image.
            frmMain.Note03_OVLBmp = frmMain.Note_OVLBmp;          // R4.00 Overlay Image.
            frmMain.FONT_Note03 = frmMain.FONT_Setup;
            frmMain.FONT_Note03_Name = frmMain.FONT_Setup.Name;
            frmMain.FONT_Note03_Size = frmMain.FONT_Setup.Size.ToString();
            frmMain.FONT_Note03_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
            frmMain.FONT_Note03_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
            frmMain.LSNote03.B1 = Color.FromArgb((int)Math.Round(255d * (Conversion.Val(frmMain.LSNote03.O1) * 0.01d)), frmMain.LSNote03.B1.R, frmMain.LSNote03.B1.G, frmMain.LSNote03.B1.B);
            frmMain.LSNote03.B2 = Color.FromArgb((int)Math.Round(255d * (Conversion.Val(frmMain.LSNote03.O2) * 0.01d)), frmMain.LSNote03.B2.R, frmMain.LSNote03.B2.G, frmMain.LSNote03.B2.B);

            // R3.50 Copy current setup to NOTE03. Dont change NOTE size.
            tWid = frmMain.LSNote04.Width;
            tHgt = frmMain.LSNote04.Height;
            frmMain.LSNote04 = _LSetup;
            frmMain.LSNote04.Width = tWid;
            frmMain.LSNote04.Height = tHgt;
            frmMain.PATH_Note04_Bmp = frmMain.PATH_DlgBmp;        // R4.00 Path for back image.
            frmMain.Note04_BackBmp = frmMain.Note_BackBmp;        // R4.00 Back Image.
            frmMain.PATH_Note04_OVLBmp = frmMain.PATH_DlgOVLBmp;  // R4.00 Path for Overlay image.
            frmMain.Note04_OVLBmp = frmMain.Note_OVLBmp;          // R4.00 Overlay Image.
            frmMain.FONT_Note04 = frmMain.FONT_Setup;
            frmMain.FONT_Note04_Name = frmMain.FONT_Setup.Name;
            frmMain.FONT_Note04_Size = frmMain.FONT_Setup.Size.ToString();
            frmMain.FONT_Note04_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
            frmMain.FONT_Note04_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
            frmMain.LSNote04.B1 = Color.FromArgb((int)Math.Round(255d * (Conversion.Val(frmMain.LSNote04.O1) * 0.01d)), frmMain.LSNote04.B1.R, frmMain.LSNote04.B1.G, frmMain.LSNote04.B1.B);
            frmMain.LSNote04.B2 = Color.FromArgb((int)Math.Round(255d * (Conversion.Val(frmMain.LSNote04.O2) * 0.01d)), frmMain.LSNote04.B2.R, frmMain.LSNote04.B2.G, frmMain.LSNote04.B2.B);
            GFX_DrawStats();
        }

        private void cboScaling_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LSetup.Scaling = cboScaling.SelectedIndex.ToString();
            GFX_DrawStats();
        }

        private void cmCopySize_Click(object sender, EventArgs e)
        {
            int tWid, tHgt;

            // R3.50 Copy current setup to NOTE01. Dont change NOTE size.
            tWid = (int)Math.Round(Conversion.Val(tbWidth.Text));
            if (32000 < tWid)
                tWid = 32000;
            tHgt = (int)Math.Round(Conversion.Val(tbHeight.Text));
            if (32000 < tHgt)
                tHgt = 32000;
            frmMain.LSNote01.Width = tWid;
            frmMain.LSNote01.Height = tHgt;
            frmMain.LSNote02.Width = tWid;
            frmMain.LSNote02.Height = tHgt;
            frmMain.LSNote03.Width = tWid;
            frmMain.LSNote03.Height = tHgt;
            frmMain.LSNote04.Width = tWid;
            frmMain.LSNote04.Height = tHgt;
        }

        private void cboDepth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LSetup.ShadowDepth = cboDepth.Text;  // R4.41 Bug Fix.
            GFX_DrawStats();
        }

        private void cmOverlay_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Title = "Overlay Image Dialog";
            if (!string.IsNullOrEmpty(frmMain.PATH_DlgOVLBmp))
            {
                fd.InitialDirectory = Utilities.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
            }
            else
            {
                fd.InitialDirectory = Utilities.PATH_GetAnyPath();
            }

            fd.Filter = "Transparent Files (*.png,*.gif)|*.png;*.gif"; // R4.40 Removed JPG.
            fd.FilterIndex = 1;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                frmMain.Note_OVLBmp = new Bitmap(fd.FileName);
                frmMain.PATH_DlgOVLBmp = fd.FileName;

                // R2.00 Strip the filename off for init dir on dialog.  
                frmMain.PATH_DlgOVLBmpPath = Utilities.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
            }

            GFX_DrawStats();
        }

        private void cboOVLScaling_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LSetup.OVLScaling = cboOVLScaling.SelectedIndex.ToString();
            GFX_DrawStats();
        }

        private void cmOVLNoImage_Click(object sender, EventArgs e)
        {
            frmMain.Note_OVLBmp = null;
            frmMain.PATH_DlgOVLBmp = "";
            GFX_DrawStats();
        }

        private void cmBordColor_Click(object sender, EventArgs e)
        {
            // R4.40 Added Border box.
            ColorDialog1.Color = _LSetup.BorderColor;
            ColorDialog1.ShowDialog();
            _LSetup.BorderColor = ColorDialog1.Color;
            GFX_DrawStats();
            lbBordColor.BackColor = _LSetup.BorderColor;
        }

        private void cboBord_SelectedIndexChanged(object sender, EventArgs e)
        {
            // R4.40 Added Border box.
            _LSetup.BorderMode = cboBord.SelectedIndex;
            GFX_DrawStats();
        }

        private void chkCardBack_CheckedChanged(object sender, EventArgs e)
        {
            // R4.40 Get CardBack option.
            if (chkCardBack.Checked == true)
            {
                _LSetup.UseCardBack = true;
            }
            else
            {
                _LSetup.UseCardBack = false;
            }

            GFX_DrawStats();
        }

        private void cmBordPanColor_Click(object sender, EventArgs e)
        {
            // R4.40 Added Border box.
            ColorDialog1.Color = _LSetup.BorderPanelColor;
            ColorDialog1.ShowDialog();
            _LSetup.BorderPanelColor = ColorDialog1.Color;  // Call GFX_DrawStats()
            lbBordPanColor.BackColor = _LSetup.BorderPanelColor;
        }

        private void cboBordPan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // R4.40 Added Border box.
            _LSetup.BorderPanelMode = cboBordPan.SelectedIndex;
            // Call GFX_DrawStats()
        }

        private void cboBordWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LSetup.BorderWidth = cboBordWidth.SelectedIndex;
            GFX_DrawStats();
        }

        private void cboBordPanWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LSetup.BorderPanelWidth = cboBordPanWidth.SelectedIndex;
        }

        private void FillRoundedRectangle(Graphics Graphics, Rectangle Rectangle, Brush Brush, int radius)
        {
            using (var path = RoundedRectangle(Rectangle, radius))
            {
                Graphics.FillPath(Brush, path);
            }
        }

        private void FillRoundedRectangle_Max(Graphics Graphics, Rectangle Rectangle, Brush Brush)
        {
            using (var path = RoundedRectangle_Max(Rectangle))
            {
                Graphics.FillPath(Brush, path);
            }
        }

        private GraphicsPath RoundedRectangle(Rectangle r, int radius)
        {
            GraphicsPath RoundedRectangleRet = default;
            var path = new GraphicsPath();
            int d = radius * 2;
            int Mid = (int)Math.Round(r.Top - (r.Top - r.Bottom) / 2d);
            int y1, y2;
            y1 = r.Top + d;
            if (Mid < y1)
                y1 = Mid;
            y2 = r.Bottom - d;
            if (y2 < Mid)
                y2 = Mid;
            path.AddLine(r.Left + d, r.Top, r.Right - d, r.Top);
            path.AddArc(Rectangle.FromLTRB(r.Right - d, r.Top, r.Right, r.Top + d), -90, 90f);
            path.AddLine(r.Right, y1, r.Right, y2);
            path.AddArc(Rectangle.FromLTRB(r.Right - d, r.Bottom - d, r.Right, r.Bottom), 0f, 90f);
            path.AddLine(r.Right - d, r.Bottom, r.Left + d, r.Bottom);
            path.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - d, r.Left + d, r.Bottom), 90f, 90f);
            path.AddLine(r.Left, y2, r.Left, y1);
            path.AddArc(Rectangle.FromLTRB(r.Left, r.Top, r.Left + d, r.Top + d), 180f, 90f);
            path.CloseFigure();
            RoundedRectangleRet = path;
            return RoundedRectangleRet;
        }

        private GraphicsPath RoundedRectangle_Max(Rectangle r)
        {
            GraphicsPath RoundedRectangle_MaxRet = default;
            var path = new GraphicsPath();
            int d = r.Bottom - r.Top;
            path.AddLine(r.Left + d, r.Top, r.Right - d, r.Top);
            path.AddArc(Rectangle.FromLTRB(r.Right - d, r.Top, r.Right, r.Top + d), -90, 180f);
            path.AddLine(r.Right - d, r.Bottom, r.Left + d, r.Bottom);
            path.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - d, r.Left + d, r.Bottom), 90f, 180f);
            path.CloseFigure();
            RoundedRectangle_MaxRet = path;
            return RoundedRectangle_MaxRet;
        }

        private void DrawRoundedRectangle(Graphics Graphics, Rectangle Rectangle, Pen Pen, int radius)
        {
            using (var path = RoundedRectangle(Rectangle, radius))
            {
                Graphics.DrawPath(Pen, path);
            }
        }

        private void DrawRoundedRectangle_Max(Graphics Graphics, Rectangle Rectangle, Pen Pen)
        {
            using (var path = RoundedRectangle_Max(Rectangle))
            {
                Graphics.DrawPath(Pen, path);
            }
        }
    }
}