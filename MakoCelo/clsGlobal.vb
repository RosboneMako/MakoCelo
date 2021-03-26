Public Class clsGlobal

  'Public Shared NoteAnim01 As t_NoteAnimation           'R3.50 Added.
  'Public Shared NoteSetup_Text(0 To 10) As String       'R3.50 Added.
  'Public Shared NoteAnim01_Text(0 To 10) As String      'R3.50 Added.
  'Public Shared NoteAnim02_Text(0 To 10) As String      'R3.50 Added.
  'Public Shared NoteAnim03_Text(0 To 10) As String      'R3.50 Added.
  'Public Shared NoteAnim04_Text(0 To 10) As String      'R3.50 Added.

  'Public Shared DlgLSetup As t_LabelSetup
  'Public Shared DlgReturnOK As Boolean


  Structure t_TeamList
    Dim PLR1 As String
    Dim PLR2 As String
    Dim PLR3 As String
    Dim PLR4 As String
    Dim RID1 As Integer
    Dim RID2 As Integer
    Dim RID3 As Integer
    Dim RID4 As Integer
    Dim PlrCnt As Integer
    Dim Gmode As Integer
    Dim RankID As Integer
    Dim RankAxis As Integer
    Dim RankAllies As Integer
    Dim WinAllies As Integer
    Dim LossAllies As Integer
    Dim WinAxis As Integer
    Dim LossAxis As Integer
  End Structure

  Structure t_LabelSetup
    Dim Width As Integer
    Dim Height As Integer
    Dim F1 As Color
    Dim F2 As Color
    Dim FDir As Integer
    Dim B1 As Color
    Dim B2 As Color
    Dim BDir As Integer
    Dim O1 As Integer
    Dim O2 As Integer
    Dim BackC As Color           'R4.00 The background color.
    Dim ShadowDir As String      'R4.00 This should be an integer at some point.
    Dim ShadowColor As Color
    Dim ShadowDepth As String    'R4.00 This needs to be an integer at some point. 
    Dim ShadowX As Integer       'R4.00 Added this for speed. 
    Dim ShadowY As Integer
    Dim Scaling As String
    Dim OVLScaling As String
    Dim BorderMode As Integer    'R4.40 RANK/NAME border. 
    Dim BorderColor As Color
    Dim BorderWidth As Integer       'R4.40 Thickness of border lines.
    Dim UseCardBack As Boolean       'R4.40 Dont use background image on PLAYER CARD draws.
    Dim BorderPanelMode As Integer   'R4.40 RANK/NAME border. 
    Dim BorderPanelColor As Color
    Dim BorderPanelWidth As Integer       'R4.40 Thickness of border lines.
  End Structure

  Structure t_Box
    Dim X As Single
    Dim Y As Single
    Dim Xtext As Single      'R3.40 X adjusted for Left or right justify Name text.
    Dim Xcenter As Single
    Dim Ycenter As Single
    Dim Width As Single
    Dim Height As Single

  End Structure

  Structure t_NoteAnimation
    Dim Active As Boolean
    Dim Mode As Integer
    Dim Align As String
    Dim Xoffset As Integer      'R4.00 Final position offsets.
    Dim Yoffset As Integer
    Dim X As Single
    Dim Y As Single
    Dim Xstart As Single
    Dim Ystart As Single
    Dim Xend As Single
    Dim Yend As Single
    Dim Xdir As Single
    Dim Ydir As Single
    Dim Holding As Boolean
    Dim Speed As Integer
    Dim TimeHold As Long        'R4.00 Time in MilliSeconds to hold once we are done moving.
    Dim TimeAcc As Long         'R4.00 Accumulated time in animation sequence.
    Dim TextCount As Integer    'R4.00 How many strings do we have to show.
    Dim TextCurrent As Integer  'R4.00 Which string are we showing now.
    Dim Delim As String         'R4.00 Text seperator for combined message notes.
  End Structure


  Public Enum FXVarDefs
    None = 0
    Mode = 1
    ShadeAng = 2
    ShadeAmount = 3
    ShadeBias = 4

  End Enum

  Public Enum FXMode

    None = 0
    Shadow = 1
    Emboss = 2
    LabelBlur = 3

  End Enum




End Class
