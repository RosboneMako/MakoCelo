Public Class frmNotes
  'R4.00 This class should be rewritten to use properties.

  Private _NoteAnim As clsGlobal.t_NoteAnimation
  Private _Cancel As Boolean = True
  Private _NoteText(11) As String

  Public Property NoteAnim As clsGlobal.t_NoteAnimation
    Get
      Return _NoteAnim
    End Get
    Set(ByVal Value As clsGlobal.t_NoteAnimation)
      _NoteAnim = Value
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

  Public Property NoteText(ByVal Index As Integer) As String
    Get
      Return _NoteText(Index)
    End Get
    Set(ByVal value As String)
      _NoteText(Index) = value
    End Set
  End Property


  Private Sub frmNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim N As Integer

    'R4.00 Setup ToolTips
    Call ToolTip_Setup()
    If frmMain.chkTips.Checked Then
      ToolTip1.Active = True
    Else
      ToolTip1.Active = False
    End If

    tbN01.Text = _NoteText(1)
    tbN02.Text = _NoteText(2)
    tbN03.Text = _NoteText(3)
    tbN04.Text = _NoteText(4)
    tbN05.Text = _NoteText(5)
    tbN06.Text = _NoteText(6)
    tbN07.Text = _NoteText(7)
    tbN08.Text = _NoteText(8)
    tbN09.Text = _NoteText(9)
    tbN10.Text = _NoteText(10)

    cboMode.Items.Add("0 - None")
    cboMode.Items.Add("1 - L<-R Crawler")
    cboMode.Items.Add("2 - Up Crawler")
    cboMode.Items.Add("3 - Down Crawler")
    cboMode.Items.Add("4 - Fade In")
    cboMode.Items.Add("5 - Up Roll")
    N = _NoteAnim.Mode
    If N < 0 Then N = 0
    cboMode.SelectedIndex = N

    cboSpeed.Items.Add("0")
    cboSpeed.Items.Add("1")
    cboSpeed.Items.Add("2")
    cboSpeed.Items.Add("3")
    cboSpeed.Items.Add("4")
    cboSpeed.Items.Add("5")
    cboSpeed.Items.Add("6")
    cboSpeed.Items.Add("7")
    cboSpeed.Items.Add("8")
    cboSpeed.Items.Add("9")
    cboSpeed.Items.Add("10")
    N = _NoteAnim.Speed
    If N < 0 Then N = 0
    cboSpeed.SelectedIndex = N

    cboHoldTime.Items.Add("0 Secs")
    cboHoldTime.Items.Add("1 Secs")
    cboHoldTime.Items.Add("2 Secs")
    cboHoldTime.Items.Add("3 Secs")
    cboHoldTime.Items.Add("4 Secs")
    cboHoldTime.Items.Add("5 Secs")
    cboHoldTime.Items.Add("6 Secs")
    cboHoldTime.Items.Add("7 Secs")
    cboHoldTime.Items.Add("8 Secs")
    cboHoldTime.Items.Add("9 Secs")
    cboHoldTime.Items.Add("10 Secs")
    N = _NoteAnim.TimeHold
    If N < 0 Then N = 0
    cboHoldTime.SelectedIndex = N

    tbDelim.Text = _NoteAnim.Delim

    cboAlign.Items.Add("0 - Left")
    cboAlign.Items.Add("1 - Center")
    cboAlign.Items.Add("2 - Right")
    cboAlign.Text = _NoteAnim.Align

    N = _NoteAnim.Mode
    If N < 0 Then N = 0
    cboMode.SelectedIndex = N

    tbXoff.Text = _NoteAnim.Xoffset
    tbYoff.Text = _NoteAnim.Yoffset

  End Sub

  Private Sub ToolTip_Setup()

    ToolTip1.SetToolTip(cboMode, "Set how the text will be animated on the notes.")
    ToolTip1.SetToolTip(cboSpeed, "Set how fast text effects happen during animations.")
    ToolTip1.SetToolTip(cboHoldTime, "How long to show the text after animations are done.")
    ToolTip1.SetToolTip(cboAlign, "Set the text alignment. This is not used for some animations.")
    ToolTip1.SetToolTip(tbDelim, "Some animations combine all text. This string will be placed between each line of text.")
    ToolTip1.SetToolTip(tbXoff, "Modify the position of text so it can align with images being used.")
    ToolTip1.SetToolTip(tbYoff, "Modify the position of text so it can align with images being used.")

  End Sub

  Private Sub cmOK_Click(sender As Object, e As EventArgs) Handles cmOK.Click

    _NoteText(1) = tbN01.Text
    _NoteText(2) = tbN02.Text
    _NoteText(3) = tbN03.Text
    _NoteText(4) = tbN04.Text
    _NoteText(5) = tbN05.Text
    _NoteText(6) = tbN06.Text
    _NoteText(7) = tbN07.Text
    _NoteText(8) = tbN08.Text
    _NoteText(9) = tbN09.Text
    _NoteText(10) = tbN10.Text
    

    _NoteAnim.Mode = cboMode.SelectedIndex
    If _NoteAnim.Mode < 0 Then _NoteAnim.Mode = 0

    _NoteAnim.Speed = cboSpeed.SelectedIndex
    If _NoteAnim.Speed < 0 Then _NoteAnim.Speed = 0

    _NoteAnim.TimeHold = cboHoldTime.SelectedIndex
    If _NoteAnim.TimeHold < 0 Then _NoteAnim.TimeHold = 0

    _NoteAnim.Delim = tbDelim.Text

    _NoteAnim.Xoffset = Val(tbXoff.Text)
    _NoteAnim.Yoffset = Val(tbYoff.Text)

    'R4.00 We selected OK and close.
    Cancel = False
    Me.Close()

  End Sub

  Private Sub cmCancel_Click(sender As Object, e As EventArgs) Handles cmCancel.Click
    Me.Close()

  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    tbN01.Text = ""
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    tbN02.Text = ""
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    tbN03.Text = ""
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    tbN04.Text = ""
  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    tbN05.Text = ""
  End Sub

  Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    tbN06.Text = ""
  End Sub

  Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    tbN07.Text = ""
  End Sub

  Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    tbN08.Text = ""
  End Sub

  Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
    tbN09.Text = ""
  End Sub

  Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
    tbN10.Text = ""
  End Sub

  Private Sub cboAlign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlign.SelectedIndexChanged
    _NoteAnim.Align = cboAlign.Text
  End Sub

  Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
    tbDelim.Text = ""
  End Sub

  Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
    tbXoff.Text = "0"
  End Sub

  Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
    tbYoff.Text = "0"
  End Sub

  Private Sub cmRotUp_Click(sender As Object, e As EventArgs) Handles cmRotUp.Click
    Dim TS As String

    TS = tbN01.Text
    tbN01.Text = tbN02.Text
    tbN02.Text = tbN03.Text
    tbN03.Text = tbN04.Text
    tbN04.Text = tbN05.Text
    tbN05.Text = tbN06.Text
    tbN06.Text = tbN07.Text
    tbN07.Text = tbN08.Text
    tbN08.Text = tbN09.Text
    tbN09.Text = tbN10.Text
    tbN10.Text = TS

  End Sub

  Private Sub cmRotDn_Click(sender As Object, e As EventArgs) Handles cmRotDn.Click
    Dim TS As String

    TS = tbN10.Text
    tbN10.Text = tbN09.Text
    tbN09.Text = tbN08.Text
    tbN08.Text = tbN07.Text
    tbN07.Text = tbN06.Text
    tbN06.Text = tbN05.Text
    tbN05.Text = tbN04.Text
    tbN04.Text = tbN03.Text
    tbN03.Text = tbN02.Text
    tbN02.Text = tbN01.Text
    tbN01.Text = TS

  End Sub
End Class