Imports System.ComponentModel
Imports System.Drawing.Drawing2D

'************************************************************
'R4.00 A dialog box class for CELO and NOTE setup options.
'************************************************************
Public Class frmLabelSetup

  'R4.00 Create some PROPERTIES that hide/show dialog controls.
  Dim _LSetup As clsGlobal.t_LabelSetup = New clsGlobal.t_LabelSetup
  Dim _HideSizeOptions As Boolean = False
  Dim _HideImageOptions As Boolean = False
  Dim _HideScalingOptions As Boolean = False
  Dim _HideSizeAll As Boolean = False
  Dim _HideFormColor As Boolean = False
  Dim _Cancel As Boolean = True

  Public Property LSetup As clsGlobal.t_LabelSetup
    Get
      Return _LSetup
    End Get
    Set(ByVal Value As clsGlobal.t_LabelSetup)
      _LSetup = Value
    End Set
  End Property

  Public Property HideSizeOptions As Boolean
    Get
      Return _HideSizeOptions
    End Get
    Set(ByVal Value As Boolean)
      _HideSizeOptions = Value
    End Set
  End Property
  Public Property HideImageOptions As Boolean
    Get
      Return _HideImageOptions
    End Get
    Set(ByVal Value As Boolean)
      _HideImageOptions = Value
    End Set
  End Property
  Public Property HideScalingOptions As Boolean
    Get
      Return _HideScalingOptions
    End Get
    Set(ByVal Value As Boolean)
      _HideScalingOptions = Value
    End Set
  End Property
  Public Property HideSizeAll As Boolean
    Get
      Return _HideSizeAll
    End Get
    Set(ByVal Value As Boolean)
      _HideSizeAll = Value
    End Set
  End Property
  Public Property HideFormColor As Boolean
    Get
      Return _HideFormColor
    End Get
    Set(ByVal Value As Boolean)
      _HideFormColor = Value
    End Set
  End Property
  Public Property Cancel As Boolean
    Get
      Return _Cancel
    End Get
    Set(ByVal Value As Boolean)
      _Cancel = Value
    End Set
  End Property

  Private Sub cmOK_Click(sender As Object, e As EventArgs) Handles cmOK.Click
    Dim N As Long

    N = Val(tbWidth.Text)
    If N < 1 Then N = 1
    If 32000 < N Then N = 32000
    _LSetup.Width = N

    N = Val(tbHeight.Text)
    If N < 1 Then N = 1
    If 32000 < N Then N = 32000
    _LSetup.Height = N

    _Cancel = False
    Me.Close()

  End Sub

  Private Sub cmCancel_Click(sender As Object, e As EventArgs) Handles cmCancel.Click
    Me.Close()
  End Sub

  Private Sub cmF1_Click(sender As Object, e As EventArgs) Handles cmF1.Click, lbF1.Click
    ColorDialog1.Color = _LSetup.F1 : ColorDialog1.ShowDialog()
    _LSetup.F1 = ColorDialog1.Color : Call GFX_DrawStats()
    lbF1.BackColor = _LSetup.F1
  End Sub

  Private Sub cmF2_Click(sender As Object, e As EventArgs) Handles cmF2.Click, lbF2.Click
    ColorDialog1.Color = _LSetup.F2 : ColorDialog1.ShowDialog()
    _LSetup.F2 = ColorDialog1.Color : Call GFX_DrawStats()
    lbF2.BackColor = _LSetup.F2
  End Sub

  Private Sub cmB1_Click(sender As Object, e As EventArgs) Handles cmB1.Click, lbB1.Click
    ColorDialog1.Color = _LSetup.B1 : ColorDialog1.ShowDialog()
    _LSetup.B1 = ColorDialog1.Color : Call GFX_DrawStats()
    lbB1.BackColor = _LSetup.B1
  End Sub

  Private Sub cmB2_Click(sender As Object, e As EventArgs) Handles cmB2.Click, lbB2.Click
    ColorDialog1.Color = _LSetup.B2 : ColorDialog1.ShowDialog()
    _LSetup.B2 = ColorDialog1.Color : Call GFX_DrawStats()
    lbB2.BackColor = _LSetup.B2
  End Sub

  Private Sub frmLabelSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'R4.00 Setup ToolTips
    Call ToolTip_Setup()
    If frmMain.chkTips.Checked Then
      ToolTip1.Active = True
    Else
      ToolTip1.Active = False
    End If

    'R4.40 Get CardBack option.
    If _LSetup.UseCardBack Then
      chkCardBack.Checked = True
    Else
      chkCardBack.Checked = False
    End If

    lbF1.BackColor = _LSetup.F1
    lbF2.BackColor = _LSetup.F2
    lbB1.BackColor = _LSetup.B1
    lbB2.BackColor = _LSetup.B2

    'R4.00 Setup the ALPHA combos.
    cboA1.Items.Add("100%")
    cboA1.Items.Add("90%")
    cboA1.Items.Add("80%")
    cboA1.Items.Add("70%")
    cboA1.Items.Add("60%")
    cboA1.Items.Add("50%")
    cboA1.Items.Add("40%")
    cboA1.Items.Add("30%")
    cboA1.Items.Add("20%")
    cboA1.Items.Add("10%")
    cboA1.Items.Add("0%")
    cboA1.Text = Format(_LSetup.O1, "#0") & "%"

    'R4.00 Setup the ALPHA combos.
    cboA2.Items.Add("100%")
    cboA2.Items.Add("90%")
    cboA2.Items.Add("80%")
    cboA2.Items.Add("70%")
    cboA2.Items.Add("60%")
    cboA2.Items.Add("50%")
    cboA2.Items.Add("40%")
    cboA2.Items.Add("30%")
    cboA2.Items.Add("20%")
    cboA2.Items.Add("10%")
    cboA2.Items.Add("0%")
    cboA2.Text = Format(_LSetup.O2, "#0") & "%"

    cboBord.Items.Add("None")
    cboBord.Items.Add("Color")
    cboBord.Items.Add("Glow")
    cboBord.Items.Add("3D")
    cboBord.Items.Add("Round Sm")
    cboBord.Items.Add("Round Md")
    cboBord.Items.Add("Round Lg")
    cboBord.SelectedIndex = _LSetup.BorderMode
    lbBordColor.BackColor = _LSetup.BorderColor

    cboBordWidth.Items.Add("1 px")
    cboBordWidth.Items.Add("2 px")
    cboBordWidth.Items.Add("3 px")
    cboBordWidth.Items.Add("4 px")
    cboBordWidth.Items.Add("5 px")
    cboBordWidth.SelectedIndex = _LSetup.BorderWidth

    cbo3D.Items.Add("--")
    cbo3D.Items.Add("45°")
    cbo3D.Items.Add("90°")
    cbo3D.Items.Add("135°")
    cbo3D.Items.Add("180°")
    cbo3D.Items.Add("225°")
    cbo3D.Items.Add("270°")
    cbo3D.Items.Add("315°")
    cbo3D.Items.Add("360°")
    cbo3D.Text = _LSetup.ShadowDir
    lbShadowColor.BackColor = _LSetup.ShadowColor

    cboDepth.Items.Add("0 px")
    cboDepth.Items.Add("1 px")
    cboDepth.Items.Add("2 px")
    cboDepth.Items.Add("3 px")
    cboDepth.Items.Add("4 px")
    cboDepth.Items.Add("5 px")
    cboDepth.Text = _LSetup.ShadowDepth  'R4.41 Bug Fix.

    tbWidth.Text = _LSetup.Width
    tbHeight.Text = _LSetup.Height

    cboScaling.Items.Add("Normal")
    cboScaling.Items.Add("Tile")
    cboScaling.Items.Add("Fit")
    cboScaling.SelectedIndex = val(_LSetup.Scaling)

    cboBordPan.Items.Add("None")
    cboBordPan.Items.Add("Color")
    cboBordPan.Items.Add("Glow")
    cboBordPan.Items.Add("3D")
    cboBordPan.Items.Add("Round Sm")
    cboBordPan.Items.Add("Round Md")
    cboBordPan.Items.Add("Round Lg")
    cboBordPan.SelectedIndex = _LSetup.BorderPanelMode
    lbBordPanColor.BackColor = _LSetup.BorderPanelColor

    cboBordPanWidth.Items.Add("1 px")
    cboBordPanWidth.Items.Add("2 px")
    cboBordPanWidth.Items.Add("3 px")
    cboBordPanWidth.Items.Add("4 px")
    cboBordPanWidth.Items.Add("5 px")
    cboBordPanWidth.SelectedIndex = _LSetup.BorderPanelWidth

    cboOVLScaling.Items.Add("Normal")
    cboOVLScaling.Items.Add("Tile")
    cboOVLScaling.Items.Add("Fit")
    cboOVLScaling.SelectedIndex = _LSetup.OVLScaling

    'R3.50 Deal with dialog options set by caller.
    If HideSizeOptions = True Then
      'R4.40 RANK and NAME Setups.
      tbWidth.Enabled = False
      tbHeight.Enabled = False
    Else
      'R4.40 Hide border options on NOTES.
      cmBordColor.Enabled = False
      lbBordColor.Enabled = False
      cboBord.Enabled = False
      cboBordWidth.Enabled = False
      cmBordPanColor.Enabled = False
      lbBordPanColor.Enabled = False
      cboBordPan.Enabled = False
      cboBordPanWidth.Enabled = False
      chkCardBack.Enabled = False
    End If
    If HideImageOptions = True Then
      cmFormColor.Enabled = False
      cmFormImage.Enabled = False
      cmNoImage.Enabled = False
      cmOVLNoImage.Enabled = False
      cmOverlay.Enabled = False
      cboOVLScaling.Enabled = False
    End If
    If HideScalingOptions = True Then
      cboScaling.Enabled = False
    End If
    If HideSizeAll = True Then
      cmCopySize.Enabled = False
    End If
    If HideFormColor = True Then
      cmFormColor.Enabled = False
    End If

    tbWidth.Text = _LSetup.Width
    tbHeight.Text = _LSetup.Height

  End Sub

  Private Sub ToolTip_Setup()

    ToolTip1.SetToolTip(cmF1, "Set text gradient color #1.")
    ToolTip1.SetToolTip(cmF2, "Set text gradient color #2.")
    ToolTip1.SetToolTip(cmFD, "Set the text gradient direction to Down.")
    ToolTip1.SetToolTip(cmFR, "Set the text gradient direction to Sideways.")

    ToolTip1.SetToolTip(cmB1, "Set background gradient color #1.")
    ToolTip1.SetToolTip(cmB2, "Set background gradient color #2.")
    ToolTip1.SetToolTip(cmBD, "Set the background gradient direction to Down.")
    ToolTip1.SetToolTip(cmBR, "Set the background gradient direction to Sideways.")

    ToolTip1.SetToolTip(cboA1, "Set background Alpha/Opacity #1. Set low with no background gives blur effect.")
    ToolTip1.SetToolTip(cboA2, "Set background Alpha/Opacity #2. Set low with no background gives blur effect.")

    ToolTip1.SetToolTip(cmBordColor, "Select a color used for object border drawing.")
    ToolTip1.SetToolTip(cboBord, "Select a border style to draw on these objects.")
    ToolTip1.SetToolTip(cboBordWidth, "Select a line width option for the border object.")

    ToolTip1.SetToolTip(cmShadowColor, "Set text shadow color.")
    ToolTip1.SetToolTip(cbo3D, "Set text shadow location.0/360 is East.")
    ToolTip1.SetToolTip(cboDepth, "Set text shadow XY offset.")

    ToolTip1.SetToolTip(cmFormColor, "Set the background image color. Not used for NOTES.")
    ToolTip1.SetToolTip(cmNoImage, "Clear the current background image.")
    ToolTip1.SetToolTip(cmFormImage, "Select a background image." & vbCr & "For best results use images the same size as the NOTE/CELO object.")
    ToolTip1.SetToolTip(cboScaling, "Set how the background image will be scaled/drawn." & vbCr & "For best results use NORMAL or TILE.")

    ToolTip1.SetToolTip(cmBordPanColor, "Select a color used for outside panel border drawing.")
    ToolTip1.SetToolTip(cboBordPan, "Select a border style to draw on the panel.")
    ToolTip1.SetToolTip(cboBordPanWidth, "Select a line width option for the border object.")
    ToolTip1.SetToolTip(chkCardBack, "Use the panel image when drawing player cards. Panel color is the default background.")

    ToolTip1.SetToolTip(cmOVLNoImage, "Clear the current overlay image.")
    ToolTip1.SetToolTip(cmOverlay, "Select an overlay image. Image should be a PNG with alpha." & vbCr & "Can have green screen areas for stream chromakey/overlay." & vbCr & "For best results use images the same size as the NOTE/CELO object.")
    ToolTip1.SetToolTip(cboOVLScaling, "Set how the CELO overlay image will be scaled/drawn." & vbCr & "For best results use NORMAL or TILE.")

    ToolTip1.SetToolTip(cmCopy01, "Set this text setup style to NOTE #1 style.")
    ToolTip1.SetToolTip(cmCopy02, "Set this text setup style to NOTE #2 style.")
    ToolTip1.SetToolTip(cmCopy03, "Set this text setup style to NOTE #3 style.")
    ToolTip1.SetToolTip(cmCopy04, "Set this text setup style to NOTE #4 style.")

    ToolTip1.SetToolTip(cmCopyAll, "Set all text setup styles to the current style.")
    ToolTip1.SetToolTip(cmCopySize, "Set all NOTE sizes to the current size.")

  End Sub


  Private Sub cmShadowColor_Click(sender As Object, e As EventArgs) Handles cmShadowColor.Click, lbShadowColor.Click
    ColorDialog1.Color = _LSetup.ShadowColor : ColorDialog1.ShowDialog()
    _LSetup.ShadowColor = ColorDialog1.Color : Call GFX_DrawStats()
    lbShadowColor.BackColor = _LSetup.ShadowColor
  End Sub

  Private Sub cboA1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboA1.SelectedIndexChanged
    _LSetup.O1 = Val(cboA1.Text)
    Call GFX_DrawStats()
  End Sub

  Private Sub cboA2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboA2.SelectedIndexChanged
    _LSetup.O2 = Val(cboA2.Text)
    Call GFX_DrawStats()
  End Sub

  Private Sub cmRankFont_Click(sender As Object, e As EventArgs) Handles cmRankFont.Click
    Dim fontDialog1 As FontDialog = New FontDialog

    'R1.00 Get current font.
    fontDialog1.Font = frmMain.FONT_Setup    'R3.00 lbRank01.Font    

    'R1.00 Get user selected font, store it, and redraw controls.
    If fontDialog1.ShowDialog() <> DialogResult.Cancel Then
      frmMain.FONT_Setup = fontDialog1.Font                           'R3.00 Moved Font tracking to a VAR now.
      frmMain.FONT_Setup_Name = fontDialog1.Font.Name
      frmMain.FONT_Setup_Size = fontDialog1.Font.Size
      frmMain.FONT_Setup_Bold = fontDialog1.Font.Bold
      frmMain.FONT_Setup_Italic = fontDialog1.Font.Italic
    End If

    Call GFX_DrawStats()

  End Sub

  Private Sub cbo3D_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo3D.SelectedIndexChanged

    _LSetup.ShadowDir = cbo3D.Text
    Select Case _LSetup.ShadowDir
      Case "45°" : _LSetup.ShadowX = 1 : _LSetup.ShadowY = -1
      Case "90°" : _LSetup.ShadowX = 0 : _LSetup.ShadowY = -1
      Case "135°" : _LSetup.ShadowX = -1 : _LSetup.ShadowY = -1
      Case "180°" : _LSetup.ShadowX = -1 : _LSetup.ShadowY = 0
      Case "225°" : _LSetup.ShadowX = -1 : _LSetup.ShadowY = 1
      Case "270°" : _LSetup.ShadowX = 0 : _LSetup.ShadowY = 1
      Case "315°" : _LSetup.ShadowX = 1 : _LSetup.ShadowY = 1
      Case "360°" : _LSetup.ShadowX = 1 : _LSetup.ShadowY = 0
      Case Else : _LSetup.ShadowX = 0 : _LSetup.ShadowY = 0
    End Select
    Call GFX_DrawStats()

  End Sub

  Private Sub cmFD_Click(sender As Object, e As EventArgs) Handles cmFD.Click
    _LSetup.FDir = 0
    Call GFX_DrawStats()
  End Sub

  Private Sub cmFR_Click(sender As Object, e As EventArgs) Handles cmFR.Click
    _LSetup.FDir = 1
    Call GFX_DrawStats()
  End Sub

  Private Sub cmBD_Click(sender As Object, e As EventArgs) Handles cmBD.Click
    _LSetup.BDir = 0
    Call GFX_DrawStats()
  End Sub

  Private Sub cmBR_Click(sender As Object, e As EventArgs) Handles cmBR.Click
    _LSetup.BDir = 1
    Call GFX_DrawStats()
  End Sub

  Private Sub cmNoImage_Click(sender As Object, e As EventArgs) Handles cmNoImage.Click
    'R4.00 Modified.
    frmMain.Note_BackBmp = Nothing
    frmMain.PATH_DlgBmp = ""
    Call GFX_DrawStats()
  End Sub

  Private Sub cmFormImage_Click(sender As Object, e As EventArgs) Handles cmFormImage.Click
    Dim fd As OpenFileDialog = New OpenFileDialog()

    fd.Title = "Background Image Dialog"
    If frmMain.PATH_DlgBmp <> "" Then
      fd.InitialDirectory = frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp)
    Else
      fd.InitialDirectory = frmMain.PATH_GetAnyPath()
    End If

    'R4.40 Added BMP and ALL option.
    fd.Filter = "Bitmap (*.bmp)|*.bmp|Png (*.png)|*.png|Gif (*.gif)|*.gif|Jpeg (*.jpg)|*.jpg|All (*.gif,*.png,*.jpg,*.bmp)|*.jpg;*.gif;*.png;*.bmp"
    fd.FilterIndex = 5

    If fd.ShowDialog() = DialogResult.OK Then
      frmMain.Note_BackBmp = New Bitmap(fd.FileName)
      frmMain.PATH_DlgBmp = fd.FileName

      'R2.00 Strip the filename off for init dir on dialog.  
      frmMain.PATH_DlgBmpPath = frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp)
    End If

    Call GFX_DrawStats()

  End Sub

  Private Sub GFX_DrawStats()
    Dim tLabHgt As Integer
    Dim Cx, Cy, Cx2, Cy2 As Integer
    Dim linGrBrush As Drawing2D.LinearGradientBrush
    Dim tX, tY As Integer
    Dim tFont As Font = frmMain.FONT_Setup
    Dim TextHgt12 As Integer
    Dim tPen As Pen

    'R3.50 Precalc some vars for readability in code.
    tLabHgt = pbNote.Height \ 2

    'R3.50 Create a bitmap memory image to draw stats to. 
    Dim BM As Bitmap = New Bitmap(pbNote.Width, pbNote.Height)
    Dim Gfx As Graphics = Graphics.FromImage(BM)

    '*****************************************************************
    'R3.50 Draw the stats page background.
    '*****************************************************************
    If frmMain.Note_BackBmp Is Nothing Then
      'R3.00 No image available so draw a solid color background.
      Gfx.FillRectangle(New SolidBrush(_LSetup.BackC), 0, 0, pbNote.Width, pbNote.Height)
    Else
      'R3.00 Scale and Draw the background image.
      Select Case Val(cboScaling.Text)
        Case 0   'R3.00 Normal Scaling
          Gfx.DrawImage(frmMain.Note_BackBmp, 0, 0, frmMain.Note_BackBmp.Width, frmMain.Note_BackBmp.Height)
        Case 1   'R3.00 Tiled Scaling
          For tY = 0 To BM.Height Step frmMain.Note_BackBmp.Height
            For tX = 0 To BM.Width Step frmMain.Note_BackBmp.Width
              Gfx.DrawImage(frmMain.Note_BackBmp, tX, tY, frmMain.Note_BackBmp.Width, frmMain.Note_BackBmp.Height)
            Next
          Next
        Case 2 'R3.00 Stretch/Fit Scaling
          Gfx.DrawImage(frmMain.Note_BackBmp, 0, 0, BM.Width, BM.Height)
      End Select
    End If

    '*****************************************************************
    'R3.10 Draw the Name background rectangles
    '*****************************************************************  
    Dim tBrush As SolidBrush = New SolidBrush(_LSetup.B1)       'R3.50  Color of Back 1.
    Dim tBrushFore As SolidBrush = New SolidBrush(_LSetup.F1)   'R3.50  Color of Fore 1.
    Dim C1, C2 As Color
    Dim tAlpha As Integer

    tAlpha = Val(cboA1.Text) * 2.55
    C1 = Color.FromArgb(tAlpha, _LSetup.B1.R, _LSetup.B1.G, _LSetup.B1.B)
    tAlpha = Val(cboA2.Text) * 2.55
    C2 = Color.FromArgb(tAlpha, _LSetup.B2.R, _LSetup.B2.G, _LSetup.B2.B)

    'R3.00 Draw the NAME background rectangle.
    If _LSetup.BDir = 0 Then
      linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, pbNote.Height), C1, C2)
    Else
      linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(pbNote.Width, 0), C1, C2)
    End If
    Gfx.FillRectangle(linGrBrush, 0, 0, pbNote.Width, pbNote.Height)

    Select Case _LSetup.BorderMode
      Case 0
      Case 1, 4, 5, 6 'R4.40 Normal.
        tPen = New Pen(New SolidBrush(_LSetup.BorderColor))
        tPen.Width = _LSetup.BorderWidth
        Gfx.DrawRectangle(tPen, 2, 2, pbNote.Width - 3, pbNote.Height - 3)
      Case 2 'R4.40 Glow
        Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(255, _LSetup.BorderColor.R, _LSetup.BorderColor.G, _LSetup.BorderColor.B))), 2, 2, pbNote.Width - 3, pbNote.Height - 3)
        Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(192, _LSetup.BorderColor.R, _LSetup.BorderColor.G, _LSetup.BorderColor.B))), 3, 3, pbNote.Width - 5, pbNote.Height - 5)
        Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(64, _LSetup.BorderColor.R, _LSetup.BorderColor.G, _LSetup.BorderColor.B))), 4, 4, pbNote.Width - 7, pbNote.Height - 7)
      Case 3 'R4.40 3D
        tPen = New Pen(New SolidBrush(_LSetup.BorderColor))
        tPen.Width = _LSetup.BorderWidth
        Gfx.DrawLine(tPen, 2, 2, pbNote.Width - 1, 2)
        Gfx.DrawLine(tPen, 2, 2, 2, pbNote.Height - 1)
        tPen = New Pen(New SolidBrush(Color.FromArgb(255, 0, 0, 0)))
        tPen.Width = _LSetup.BorderWidth
        Gfx.DrawLine(tPen, pbNote.Width - 1, 1, pbNote.Width - 1, pbNote.Height - 1)
        Gfx.DrawLine(tPen, 1, pbNote.Height - 1, pbNote.Width - 1, pbNote.Height - 1)
    End Select


    '*****************************************************************
    'R3.50 Draw the note TEXT.
    '*****************************************************************  
    Dim tBrushShadow As Brush = New SolidBrush(_LSetup.ShadowColor)

    TextHgt12 = Gfx.MeasureString("X", frmMain.FONT_Setup).Height / 2       'R3.30 Changed from Xq.


    'R3.50 Draw the shadow text.
    Cx = 0
    Cy = pbNote.Height / 2 - TextHgt12
    Select Case _LSetup.ShadowDir
      Case "45°" : Cx2 = 1 : Cy2 = -1
      Case "90°" : Cx2 = 0 : Cy2 = -1
      Case "135°" : Cx2 = -1 : Cy2 = -1
      Case "180°" : Cx2 = -1 : Cy2 = 0
      Case "225°" : Cx2 = -1 : Cy2 = 1
      Case "270°" : Cx2 = 0 : Cy2 = 1
      Case "315°" : Cx2 = 1 : Cy2 = 1
      Case "360°" : Cx2 = 1 : Cy2 = 0
      Case Else : Cx2 = 0 : Cy2 = 0
    End Select
    If (Cx2 <> 0) Or (Cy2 <> 0) Then Gfx.DrawString("Test Sample Text", frmMain.FONT_Setup, tBrushShadow, Cx + Cx2 * Val(_LSetup.ShadowDepth), Cy + Cy2 * Val(_LSetup.ShadowDepth))

    'R3.50 Draw the gradient Text.
    'R3.50 Setup LINEAR gradient brushed for TEXT.
    If _LSetup.FDir = 0 Then
      linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, pbNote.Height), Color.FromArgb(255, _LSetup.F1.R, _LSetup.F1.G, _LSetup.F1.B), Color.FromArgb(255, _LSetup.F2.R, _LSetup.F2.G, _LSetup.F2.B))
    Else
      linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(pbNote.Width, 0), Color.FromArgb(255, _LSetup.F1.R, _LSetup.F1.G, _LSetup.F1.B), Color.FromArgb(255, _LSetup.F2.R, _LSetup.F2.G, _LSetup.F2.B))
    End If
    Gfx.DrawString("Test Sample Text", frmMain.FONT_Setup, linGrBrush, Cx, Cy)


    '*****************************************************************
    'R3.50 Draw the OVERLAY background.
    '*****************************************************************
    If HideImageOptions = False Then
      If Not (frmMain.Note_OVLBmp Is Nothing) Then
        'R3.00 Scale and Draw the background image.
        Select Case Val(cboOVLScaling.Text)
          Case 0   'R3.00 Normal Scaling
            Gfx.DrawImage(frmMain.Note_OVLBmp, 0, 0, frmMain.Note_OVLBmp.Width, frmMain.Note_OVLBmp.Height)
          Case 1   'R3.00 Tiled Scaling
            For tY = 0 To BM.Height Step frmMain.Note_OVLBmp.Height
              For tX = 0 To BM.Width Step frmMain.Note_OVLBmp.Width
                Gfx.DrawImage(frmMain.Note_OVLBmp, tX, tY, frmMain.Note_OVLBmp.Width, frmMain.Note_OVLBmp.Height)
              Next
            Next
          Case 2 'R3.00 Stretch/Fit Scaling
            Gfx.DrawImage(frmMain.Note_OVLBmp, 0, 0, BM.Width, BM.Height)
        End Select
      End If
    End If

    pbNote.Image = BM

  End Sub

  Private Sub cmFormColor_Click(sender As Object, e As EventArgs) Handles cmFormColor.Click

    ColorDialog1.Color = _LSetup.BackC
    ColorDialog1.ShowDialog()

    _LSetup.BackC = ColorDialog1.Color          'R3.50 Added.

    Call GFX_DrawStats()
  End Sub
  Private Sub cmCopy01_Click(sender As Object, e As EventArgs) Handles cmCopy01.Click
    'R3.50 Get the data we are editing.
    _LSetup = frmMain.LSNote01
    cboA1.Text = Format(_LSetup.O1, "#0") & "%"
    cboA2.Text = Format(_LSetup.O2, "#0") & "%"
    cbo3D.Text = _LSetup.ShadowDir

    frmMain.FONT_Setup = frmMain.FONT_Note01
    frmMain.PATH_DlgBmp = frmMain.PATH_Note01_Bmp                              'R3.50 Path for back image.
    frmMain.Note_BackBmp = frmMain.Note01_BackBmp                              'R3.50 Back Image.
    frmMain.PATH_DlgBmpPath = frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp)  'R3.50 Path without Filename. 
    frmMain.FONT_Setup = frmMain.FONT_Note01

    Call GFX_DrawStats()
  End Sub

  Private Sub cmCopy02_Click(sender As Object, e As EventArgs) Handles cmCopy02.Click
    'R3.50 Get the data we are editing.
    _LSetup = frmMain.LSNote02
    cboA1.Text = Format(_LSetup.O1, "#0") & "%"
    cboA2.Text = Format(_LSetup.O2, "#0") & "%"
    cbo3D.Text = _LSetup.ShadowDir

    frmMain.FONT_Setup = frmMain.FONT_Note02
    frmMain.PATH_DlgBmp = frmMain.PATH_Note02_Bmp                              'R3.50 Path for back image.
    frmMain.Note_BackBmp = frmMain.Note02_BackBmp                              'R3.50 Back Image.
    frmMain.PATH_DlgBmpPath = frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp)  'R3.50 Path without Filename. 
    frmMain.FONT_Setup = frmMain.FONT_Note02

    Call GFX_DrawStats()
  End Sub

  Private Sub cmCopy03_Click(sender As Object, e As EventArgs) Handles cmCopy03.Click
    'R3.50 Get the data we are editing.
    _LSetup = frmMain.LSNote03
    cboA1.Text = Format(_LSetup.O1, "#0") & "%"
    cboA2.Text = Format(_LSetup.O2, "#0") & "%"
    cbo3D.Text = _LSetup.ShadowDir

    frmMain.FONT_Setup = frmMain.FONT_Note03
    frmMain.PATH_DlgBmp = frmMain.PATH_Note03_Bmp                              'R3.50 Path for back image.
    frmMain.Note_BackBmp = frmMain.Note03_BackBmp                              'R3.50 Back Image.
    frmMain.PATH_DlgBmpPath = frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp)  'R3.50 Path without Filename. 
    frmMain.FONT_Setup = frmMain.FONT_Note03

    Call GFX_DrawStats()
  End Sub

  Private Sub cmCopy04_Click(sender As Object, e As EventArgs) Handles cmCopy04.Click
    'R3.50 Get the data we are editing.
    _LSetup = frmMain.LSNote04
    cboA1.Text = Format(_LSetup.O1, "#0") & "%"
    cboA2.Text = Format(_LSetup.O2, "#0") & "%"
    cbo3D.Text = _LSetup.ShadowDir

    frmMain.FONT_Setup = frmMain.FONT_Note04
    frmMain.PATH_DlgBmp = frmMain.PATH_Note04_Bmp                              'R3.50 Path for back image.
    frmMain.Note_BackBmp = frmMain.Note04_BackBmp                              'R3.50 Back Image.
    frmMain.PATH_DlgBmpPath = frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp)  'R3.50 Path without Filename. 
    frmMain.FONT_Setup = frmMain.FONT_Note04

    Call GFX_DrawStats()
  End Sub

  Private Sub cmCopyAll_Click(sender As Object, e As EventArgs) Handles cmCopyAll.Click
    Dim tWid, tHgt As Integer

    'R3.50 Copy current setup to NOTE01. Dont change NOTE size.
    tWid = frmMain.LSNote01.Width
    tHgt = frmMain.LSNote01.Height
    frmMain.LSNote01 = _LSetup
    frmMain.LSNote01.Width = tWid
    frmMain.LSNote01.Height = tHgt

    frmMain.PATH_Note01_Bmp = frmMain.PATH_DlgBmp        'R4.00 Path for back image.
    frmMain.Note01_BackBmp = frmMain.Note_BackBmp        'R4.00 Back Image.
    frmMain.PATH_Note01_OVLBmp = frmMain.PATH_DlgOVLBmp  'R4.00 Path for Overlay image.
    frmMain.Note01_OVLBmp = frmMain.Note_OVLBmp          'R4.00 Overlay Image.
    frmMain.FONT_Note01 = frmMain.FONT_Setup
    frmMain.FONT_Note01_Name = frmMain.FONT_Setup.Name
    frmMain.FONT_Note01_Size = frmMain.FONT_Setup.Size
    frmMain.FONT_Note01_Bold = frmMain.FONT_Setup.Bold
    frmMain.FONT_Note01_Italic = frmMain.FONT_Setup.Italic
    frmMain.LSNote01.B1 = Color.FromArgb(255 * (Val(frmMain.LSNote01.O1) * 0.01), frmMain.LSNote01.B1.R, frmMain.LSNote01.B1.G, frmMain.LSNote01.B1.B)
    frmMain.LSNote01.B2 = Color.FromArgb(255 * (Val(frmMain.LSNote01.O2) * 0.01), frmMain.LSNote01.B2.R, frmMain.LSNote01.B2.G, frmMain.LSNote01.B2.B)

    'R3.50 Copy current setup to NOTE02. Dont change NOTE size.
    tWid = frmMain.LSNote02.Width
    tHgt = frmMain.LSNote02.Height
    frmMain.LSNote02 = _LSetup
    frmMain.LSNote02.Width = tWid
    frmMain.LSNote02.Height = tHgt

    frmMain.PATH_Note02_Bmp = frmMain.PATH_DlgBmp     'R3.50 Path for back image.
    frmMain.Note02_BackBmp = frmMain.Note_BackBmp     'R3.50 Back Image.
    frmMain.PATH_Note02_OVLBmp = frmMain.PATH_DlgOVLBmp  'R4.00 Path for Overlay image.
    frmMain.Note02_OVLBmp = frmMain.Note_OVLBmp          'R4.00 Overlay Image.
    frmMain.FONT_Note02 = frmMain.FONT_Setup
    frmMain.FONT_Note02_Name = frmMain.FONT_Setup.Name
    frmMain.FONT_Note02_Size = frmMain.FONT_Setup.Size
    frmMain.FONT_Note02_Bold = frmMain.FONT_Setup.Bold
    frmMain.FONT_Note02_Italic = frmMain.FONT_Setup.Italic
    frmMain.LSNote02.B1 = Color.FromArgb(255 * (Val(frmMain.LSNote02.O1) * 0.01), frmMain.LSNote02.B1.R, frmMain.LSNote02.B1.G, frmMain.LSNote02.B1.B)
    frmMain.LSNote02.B2 = Color.FromArgb(255 * (Val(frmMain.LSNote02.O2) * 0.01), frmMain.LSNote02.B2.R, frmMain.LSNote02.B2.G, frmMain.LSNote02.B2.B)

    'R3.50 Copy current setup to NOTE03. Dont change NOTE size.
    tWid = frmMain.LSNote03.Width
    tHgt = frmMain.LSNote03.Height
    frmMain.LSNote03 = _LSetup
    frmMain.LSNote03.Width = tWid
    frmMain.LSNote03.Height = tHgt

    frmMain.PATH_Note03_Bmp = frmMain.PATH_DlgBmp        'R4.00 Path for back image.
    frmMain.Note03_BackBmp = frmMain.Note_BackBmp        'R4.00 Back Image.
    frmMain.PATH_Note03_OVLBmp = frmMain.PATH_DlgOVLBmp  'R4.00 Path for Overlay image.
    frmMain.Note03_OVLBmp = frmMain.Note_OVLBmp          'R4.00 Overlay Image.
    frmMain.FONT_Note03 = frmMain.FONT_Setup
    frmMain.FONT_Note03_Name = frmMain.FONT_Setup.Name
    frmMain.FONT_Note03_Size = frmMain.FONT_Setup.Size
    frmMain.FONT_Note03_Bold = frmMain.FONT_Setup.Bold
    frmMain.FONT_Note03_Italic = frmMain.FONT_Setup.Italic
    frmMain.LSNote03.B1 = Color.FromArgb(255 * (Val(frmMain.LSNote03.O1) * 0.01), frmMain.LSNote03.B1.R, frmMain.LSNote03.B1.G, frmMain.LSNote03.B1.B)
    frmMain.LSNote03.B2 = Color.FromArgb(255 * (Val(frmMain.LSNote03.O2) * 0.01), frmMain.LSNote03.B2.R, frmMain.LSNote03.B2.G, frmMain.LSNote03.B2.B)

    'R3.50 Copy current setup to NOTE03. Dont change NOTE size.
    tWid = frmMain.LSNote04.Width
    tHgt = frmMain.LSNote04.Height
    frmMain.LSNote04 = _LSetup
    frmMain.LSNote04.Width = tWid
    frmMain.LSNote04.Height = tHgt

    frmMain.PATH_Note04_Bmp = frmMain.PATH_DlgBmp        'R4.00 Path for back image.
    frmMain.Note04_BackBmp = frmMain.Note_BackBmp        'R4.00 Back Image.
    frmMain.PATH_Note04_OVLBmp = frmMain.PATH_DlgOVLBmp  'R4.00 Path for Overlay image.
    frmMain.Note04_OVLBmp = frmMain.Note_OVLBmp          'R4.00 Overlay Image.
    frmMain.FONT_Note04 = frmMain.FONT_Setup
    frmMain.FONT_Note04_Name = frmMain.FONT_Setup.Name
    frmMain.FONT_Note04_Size = frmMain.FONT_Setup.Size
    frmMain.FONT_Note04_Bold = frmMain.FONT_Setup.Bold
    frmMain.FONT_Note04_Italic = frmMain.FONT_Setup.Italic
    frmMain.LSNote04.B1 = Color.FromArgb(255 * (Val(frmMain.LSNote04.O1) * 0.01), frmMain.LSNote04.B1.R, frmMain.LSNote04.B1.G, frmMain.LSNote04.B1.B)
    frmMain.LSNote04.B2 = Color.FromArgb(255 * (Val(frmMain.LSNote04.O2) * 0.01), frmMain.LSNote04.B2.R, frmMain.LSNote04.B2.G, frmMain.LSNote04.B2.B)

    Call GFX_DrawStats()
  End Sub

  Private Sub cboScaling_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboScaling.SelectedIndexChanged
    _LSetup.Scaling = cboScaling.SelectedIndex
    Call GFX_DrawStats()
  End Sub

  Private Sub cmCopySize_Click(sender As Object, e As EventArgs) Handles cmCopySize.Click
    Dim tWid, tHgt As Integer

    'R3.50 Copy current setup to NOTE01. Dont change NOTE size.
    tWid = Val(tbWidth.Text)
    If 32000 < tWid Then tWid = 32000
    tHgt = Val(tbHeight.Text)
    If 32000 < tHgt Then tHgt = 32000

    frmMain.LSNote01.Width = tWid
    frmMain.LSNote01.Height = tHgt
    frmMain.LSNote02.Width = tWid
    frmMain.LSNote02.Height = tHgt
    frmMain.LSNote03.Width = tWid
    frmMain.LSNote03.Height = tHgt
    frmMain.LSNote04.Width = tWid
    frmMain.LSNote04.Height = tHgt

  End Sub

  Private Sub cboDepth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepth.SelectedIndexChanged
    _LSetup.ShadowDepth = cboDepth.Text  'R4.41 Bug Fix.
    Call GFX_DrawStats()
  End Sub

  Private Sub cmOverlay_Click(sender As Object, e As EventArgs) Handles cmOverlay.Click
    Dim fd As OpenFileDialog = New OpenFileDialog()

    fd.Title = "Overlay Image Dialog"
    If frmMain.PATH_DlgOVLBmp <> "" Then
      fd.InitialDirectory = frmMain.PATH_StripFilename(frmMain.PATH_DlgOVLBmp)
    Else
      fd.InitialDirectory = frmMain.PATH_GetAnyPath()
    End If
    fd.Filter = "Transparent Files (*.png,*.gif)|*.png;*.gif" 'R4.40 Removed JPG.
    fd.FilterIndex = 1

    If fd.ShowDialog() = DialogResult.OK Then
      frmMain.Note_OVLBmp = New Bitmap(fd.FileName)
      frmMain.PATH_DlgOVLBmp = fd.FileName

      'R2.00 Strip the filename off for init dir on dialog.  
      frmMain.PATH_DlgOVLBmpPath = frmMain.PATH_StripFilename(frmMain.PATH_DlgOVLBmp)
    End If

    Call GFX_DrawStats()
  End Sub

  Private Sub cboOVLScaling_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOVLScaling.SelectedIndexChanged
    _LSetup.OVLScaling = cboOVLScaling.SelectedIndex
    Call GFX_DrawStats()
  End Sub

  Private Sub cmOVLNoImage_Click(sender As Object, e As EventArgs) Handles cmOVLNoImage.Click
    frmMain.Note_OVLBmp = Nothing
    frmMain.PATH_DlgOVLBmp = ""
    Call GFX_DrawStats()
  End Sub

  Private Sub cmBordColor_Click(sender As Object, e As EventArgs) Handles cmBordColor.Click, lbBordColor.Click
    'R4.40 Added Border box.
    ColorDialog1.Color = _LSetup.BorderColor : ColorDialog1.ShowDialog()
    _LSetup.BorderColor = ColorDialog1.Color : Call GFX_DrawStats()
    lbBordColor.BackColor = _LSetup.BorderColor
  End Sub

  Private Sub cboBord_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBord.SelectedIndexChanged
    'R4.40 Added Border box.
    _LSetup.BorderMode = cboBord.SelectedIndex
    Call GFX_DrawStats()
  End Sub

  Private Sub chkCardBack_CheckedChanged(sender As Object, e As EventArgs) Handles chkCardBack.CheckedChanged
    'R4.40 Get CardBack option.
    If chkCardBack.Checked = True Then
      _LSetup.UseCardBack = True
    Else
      _LSetup.UseCardBack = False
    End If
    Call GFX_DrawStats()
  End Sub

  Private Sub cmBordPanColor_Click(sender As Object, e As EventArgs) Handles cmBordPanColor.Click, lbBordPanColor.Click
    'R4.40 Added Border box.
    ColorDialog1.Color = _LSetup.BorderPanelColor : ColorDialog1.ShowDialog()
    _LSetup.BorderPanelColor = ColorDialog1.Color  'Call GFX_DrawStats()
    lbBordPanColor.BackColor = _LSetup.BorderPanelColor
  End Sub

  Private Sub cboBordPan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBordPan.SelectedIndexChanged
    'R4.40 Added Border box.
    _LSetup.BorderPanelMode = cboBordPan.SelectedIndex
    'Call GFX_DrawStats()
  End Sub

  Private Sub cboBordWidth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBordWidth.SelectedIndexChanged
    _LSetup.BorderWidth = cboBordWidth.SelectedIndex
    Call GFX_DrawStats()
  End Sub

  Private Sub cboBordPanWidth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBordPanWidth.SelectedIndexChanged
    _LSetup.BorderPanelWidth = cboBordPanWidth.SelectedIndex
  End Sub

  Private Sub FillRoundedRectangle(Graphics As Graphics, Rectangle As Rectangle, Brush As Brush, radius As Integer)
    Using path As GraphicsPath = RoundedRectangle(Rectangle, radius)
      Graphics.FillPath(Brush, path)
    End Using
  End Sub

  Private Sub FillRoundedRectangle_Max(Graphics As Graphics, Rectangle As Rectangle, Brush As Brush)
    Using path As GraphicsPath = RoundedRectangle_Max(Rectangle)
      Graphics.FillPath(Brush, path)
    End Using
  End Sub

  Private Function RoundedRectangle(r As Rectangle, radius As Integer) As GraphicsPath
    Dim path As GraphicsPath = New GraphicsPath()
    Dim d As Integer = radius * 2
    Dim Mid As Integer = r.Top - ((r.Top - r.Bottom) / 2)
    Dim y1, y2 As Integer

    y1 = r.Top + d
    If Mid < y1 Then y1 = Mid
    y2 = r.Bottom - d
    If y2 < Mid Then y2 = Mid

    path.AddLine(r.Left + d, r.Top, r.Right - d, r.Top)
    path.AddArc(Rectangle.FromLTRB(r.Right - d, r.Top, r.Right, r.Top + d), -90, 90)

    path.AddLine(r.Right, y1, r.Right, y2)
    path.AddArc(Rectangle.FromLTRB(r.Right - d, r.Bottom - d, r.Right, r.Bottom), 0, 90)

    path.AddLine(r.Right - d, r.Bottom, r.Left + d, r.Bottom)
    path.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - d, r.Left + d, r.Bottom), 90, 90)

    path.AddLine(r.Left, y2, r.Left, y1)
    path.AddArc(Rectangle.FromLTRB(r.Left, r.Top, r.Left + d, r.Top + d), 180, 90)
    path.CloseFigure()
    RoundedRectangle = path

  End Function

  Private Function RoundedRectangle_Max(r As Rectangle) As GraphicsPath
    Dim path As GraphicsPath = New GraphicsPath()
    Dim d As Integer = r.Bottom - r.Top

    path.AddLine(r.Left + d, r.Top, r.Right - d, r.Top)
    path.AddArc(Rectangle.FromLTRB(r.Right - d, r.Top, r.Right, r.Top + d), -90, 180)
    path.AddLine(r.Right - d, r.Bottom, r.Left + d, r.Bottom)
    path.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - d, r.Left + d, r.Bottom), 90, 180)

    path.CloseFigure()
    RoundedRectangle_Max = path

  End Function

  Private Sub DrawRoundedRectangle(Graphics As Graphics, Rectangle As Rectangle, Pen As Pen, radius As Integer)
    Using path As GraphicsPath = RoundedRectangle(Rectangle, radius)
      Graphics.DrawPath(Pen, path)
    End Using
  End Sub

  Private Sub DrawRoundedRectangle_Max(Graphics As Graphics, Rectangle As Rectangle, Pen As Pen)
    Using path As GraphicsPath = RoundedRectangle_Max(Rectangle)
      Graphics.DrawPath(Pen, path)
    End Using
  End Sub

End Class