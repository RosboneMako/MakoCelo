Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.IO
Imports System.Speech.Synthesis
Imports System.Drawing.Drawing2D

Public Class frmMain
  'R4.00 NEEDS A fast check to see if LOG file has been updated since last check, since it hiccups the animation code.
  'R4.00 NEEDS Check could be file size and date?
  'R4.00 NEEDS Could put STATS on clipboard for pasting into Coh2 Console for people who cant Alt-Tab without crashing.

  <DllImport("winmm.dll")> Public Shared Function waveOutGetVolume(ByVal hwo As IntPtr, ByVal dwVolume As Integer) As Integer
  End Function
  <DllImport("winmm.dll")> Public Shared Function waveOutSetVolume(hwo As IntPtr, dwVolume As UInteger) As Integer
  End Function

  Private SpeechSynth As New SpeechSynthesizer      'R4.34 Added for TEXT-TO-SPEECH option.

  'R4.41 Made these PUBLIC.
  Private WBrequest As HttpWebRequest = Nothing
  Private WBresponse As HttpWebResponse = Nothing
  Private WBreader As StreamReader = Nothing

  'R3.40 Public Variables
  Public Shared CDialogPick As Color
  Private Celo_Windowstate As String              'R4.00 Aded CELO for window position storage.
  Private Celo_Top As Long
  Private Celo_Left As Long
  Private Celo_Width As Long
  Private Celo_Height As Long
  Private Celo_Popup As Boolean                   'R4.00 Toggle POPUP menu on/off.  
  Private Celo_PopupHit As Integer                'R4.00 Toggle POPUP menu on/off.  
  Private CELO_PopUpObject As Object
  Private STATS_SizeX As Integer = 900
  Private STATS_SizeY As Integer = 180
  Private Main_BM As Bitmap                       'R4.32 Used in GFX_Draw subs.
  Private Main_Gfx As Graphics
  Private Main_BM2 As Bitmap                      'R4.32 Used in GFX Effects subs.  
  Private Main_Gfx2 As Graphics
  Private MainBuffer_BM As Bitmap                 'R4.50 Store the premade STATS background.  
  Private MainBuffer_Gfx As Graphics
  Private MainBuffer_Valid As Boolean
  Private MainBuffer1_BM As Bitmap                 'R4.50 Store the premade STATS GFX with RANK.  
  Private MainBuffer1_Gfx As Graphics
  Private MainBuffer1_Valid As Boolean
  Private MainBuffer2_BM As Bitmap                 'R4.50 Store the premade STATS GFX with LEVEL.  
  Private MainBuffer2_Gfx As Graphics
  Private MainBuffer2_Valid As Boolean
  Private MainBuffer3_BM As Bitmap                 'R4.50 Store the premade STATS GFX with %.  
  Private MainBuffer3_Gfx As Graphics
  Private MainBuffer3_Valid As Boolean
  Private MainBlur_BM As Bitmap                   'R4.50 Used for BLUR masking.  
  Private MainBlur_Gfx As Graphics
  Private MainBlur_Data As System.Drawing.Imaging.BitmapData
  Private MainBlur_Valid As Boolean
  Private NAME_bmp As Bitmap
  Private NAME_OVLBmp As Bitmap

  Private FLAG_Loading As Boolean                 'R2.00 Flag that we are loading, so do not update.
  Private FLAG_Drawing As Boolean                 'R3.40 Dont let combo boxes call when we are drawing.
  Private FLAG_ShowMismatch As Boolean            'R3.40 
  Private FLAG_InitialScanning As Boolean         'R4.30 Added a flag to clear player data. 
  Private FLAG_HideMissing As Boolean             'R4.30 Added to hide blanks on Overlays/Green Screens.
  Private FLAG_EloValid As Boolean                'R4.30 Are the current ELO values valid?
  Private FLAG_EloUse As Boolean                  'R4.30 Try to draw the ELO values on screen?
  Private FLAG_EloMode As Integer                 'R4.30 Which value are we showing right now. Cycles with Scans.
  Private FLAG_ShowPlayerCard As Integer          'R4.30 Toggle STATS and PLAYERCARD display.
  Private FLAG_ShowPlayerCardNum As Integer       'R4.30 Toggle STATS and PLAYERCARD display.
  Private FLAG_SpeechOK As Boolean                'R4.34 Is this PC speech capable?

  Private PATH_Game As String = ""
  Private PATH_GamePath As String = ""            'R2.00 Raw path for dialogs.
  Private PATH_SetupPath As String = ""           'R4.20 Raw path for dialogs.
  Private PATH_BackgroundImage As String = ""
  Private PATH_BackgroundImagePath As String = "" 'R2.00 Raw path for dialogs.

  'R4.00 Need these global so we can set them in frmLabelSetup objects. Could be properties.
  Public Shared PATH_DlgBmp As String = ""               'R4.00 Added NOTE objects.  
  Public Shared PATH_DlgBmpPath As String = ""           'R4.00 Path only.  
  Public Shared PATH_Note01_Bmp As String = ""
  Public Shared PATH_Note02_Bmp As String = ""
  Public Shared PATH_Note03_Bmp As String = ""
  Public Shared PATH_Note04_Bmp As String = ""
  Public Shared PATH_Note01_BmpPath As String = ""        'R4.00 Filename removed. Path only for dialog boxes.  
  Public Shared PATH_Note02_BmpPath As String = ""
  Public Shared PATH_Note03_BmpPath As String = ""
  Public Shared PATH_Note04_BmpPath As String = ""
  Public Shared PATH_DlgOVLBmp As String = ""             'R4.00 Added NOTE objects.  
  Public Shared PATH_DlgOVLBmpPath As String = ""         'R4.00 Path only.  
  Public Shared PATH_Name_OVLBmp As String = ""
  Public Shared PATH_Note01_OVLBmp As String = ""
  Public Shared PATH_Note02_OVLBmp As String = ""
  Public Shared PATH_Note03_OVLBmp As String = ""
  Public Shared PATH_Note04_OVLBmp As String = ""
  Public Shared PATH_Name_OVLBmpPath As String = ""
  Public Shared PATH_Note01_OVLBmpPath As String = ""      'R4.00 Filename removed. Path only for dialog boxes.  
  Public Shared PATH_Note02_OVLBmpPath As String = ""
  Public Shared PATH_Note03_OVLBmpPath As String = ""
  Public Shared PATH_Note04_OVLBmpPath As String = ""

  Private PATH_SaveStatsImage As String = ""
  Private PATH_SoundFiles As String = ""          'R4.00 Added sound playing.
  Private SCAN_Enabled As Boolean
  Private SCAN_Time As Long                       'R4.30 Added variable scan delays.
  Private SCAN_SecCnt As Long                     'R4.30 Counter for how many secs before Auto Scan.

  'R4.00 Need these global so we can set them in frmLabelSetup objects. Could be properties.
  Public Shared FONT_Setup As Font                   'R4.00 Added a var for temporary dialog setups.
  Public Shared FONT_Setup_Name As String
  Public Shared FONT_Setup_Size As String
  Public Shared FONT_Setup_Bold As String
  Public Shared FONT_Setup_Italic As String

  Public Shared FONT_Note01 As Font                   'R4.00 Note Font setup.
  Public Shared FONT_Note01_Name As String
  Public Shared FONT_Note01_Size As String
  Public Shared FONT_Note01_Bold As String
  Public Shared FONT_Note01_Italic As String

  Public Shared FONT_Note02 As Font                   'R4.00 Note Font setup.
  Public Shared FONT_Note02_Name As String
  Public Shared FONT_Note02_Size As String
  Public Shared FONT_Note02_Bold As String
  Public Shared FONT_Note02_Italic As String

  Public Shared FONT_Note03 As Font                   'R4.00 Note Font setup.
  Public Shared FONT_Note03_Name As String
  Public Shared FONT_Note03_Size As String
  Public Shared FONT_Note03_Bold As String
  Public Shared FONT_Note03_Italic As String

  Public Shared FONT_Note04 As Font                   'R4.00 Note Font setup.
  Public Shared FONT_Note04_Name As String
  Public Shared FONT_Note04_Size As String
  Public Shared FONT_Note04_Bold As String
  Public Shared FONT_Note04_Italic As String

  Public Shared FONT_Rank As Font                   'R3.00 Added.
  Public Shared FONT_Rank_Name As String
  Public Shared FONT_Rank_Size As String
  Public Shared FONT_Rank_Bold As String
  Public Shared FONT_Rank_Italic As String

  Public Shared FONT_Name As Font                   'R3.00 Added.
  Public Shared FONT_Name_Name As String
  Public Shared FONT_Name_Size As String
  Public Shared FONT_Name_Bold As String
  Public Shared FONT_Name_Italic As String

  Private COLOR_Back1 As Color                'R3.00 Future gradient on background. 
  Private COLOR_Back2 As Color                'R3.00 Future gradient on background. 
  Private COLOR_Back_Dir As Integer           'R3.00 Future gradient on background. 
  Private GUI_ColorMode As Integer            'R2.01 Color scheme number. 0-Lite,1-Dark
  Private LAB_Height As Single                'R2.00 Height of labels.
  Private LAB_Rank(0 To 8) As clsGlobal.t_Box           'R2.00 Defs for current label layout. 
  Private LAB_Name(0 To 8) As clsGlobal.t_Box
  Private LAB_Fact(0 To 8) As clsGlobal.t_Box
  Private LAB_Name_Align(0 To 8) As StringFormat

  Private GUI_Mouse_PlrIndex As Integer  'R3.00 Which player we are moused over in the stats page.
  Private GUI_Active As Boolean          'R3.10 If TRUE, gui will redraw when mouse over events happen. May be too slow.
  Private PlrName(0 To 8) As String
  Private PlrRank(0 To 8) As String
  Private PlrWin(0 To 8) As Integer
  Private PlrLoss(0 To 8) As Integer
  Private PlrRankALL(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
  Private PlrRankWin(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
  Private PlrRankLoss(0 To 8, 0 To 7, 0 To 4) As Integer 'R4.30 Rank from RID for all game modes.
  Private PlrRankPerc(0 To 8, 0 To 7, 0 To 4) As String  'R4.30 Rank from RID for all game modes.
  Private PlrCountry(0 To 8) As String                   'R4.45 Added contry.
  Private PlrCountryName(0 To 8) As String               'R4.46 Added contry.
  Private PlrFact(0 To 8) As String
  Private PlrSteam(0 To 8) As String
  Private PlrRID(0 To 8) As Integer
  Private PlrELO(0 To 8) As String
  Private PlrTeam(0 To 8) As Integer
  Private PlrTWin(0 To 8) As Integer
  Private PlrTLoss(0 To 8) As Integer
  Private PlrLVL(0 To 8) As String
  Private PlrGLVL(0 To 8) As Integer
  Private TeamList(9, 1000) As clsGlobal.t_TeamList  'R4.34 Added for JSON team parsing.
  Private TeamListCnt(9) As Integer
  Private PlrName_Last(0 To 8) As String
  Private PlrRank_Last(0 To 8) As String
  Private PlrFact_Last(0 To 8) As String
  Private PlrTeam_Last(0 To 8) As Integer
  Private PlrTWin_Last(0 To 8) As Integer
  Private PlrTLoss_Last(0 To 8) As Integer
  Private PlrSteam_Last(0 To 8) As String
  Private PlrRankALL_Last(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
  Private PlrRankWin_Last(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
  Private PlrRankLoss_Last(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
  Private PlrRankPerc_Last(0 To 8, 0 To 7, 0 To 4) As String  'R4.30 Rank from RID for all game modes.
  Private PlrCountry_Last(0 To 8) As String
  Private PlrCountryName_Last(0 To 8) As String                   'R4.46 Added contry.
  Private PlrRID_Last(0 To 8) As Integer
  Private PlrELO_Last(0 To 8) As String
  Private PlrLVL_Last(0 To 8) As String
  Private PlrGLVL_Last(0 To 8) As Integer
  Private TeamList_Last(9, 1000) As clsGlobal.t_TeamList  'R4.34 Added for JSON team parsing.
  Private TeamListCnt_Last(9) As Integer
  Private PlrName_Buffer(0 To 8) As String
  Private PlrRank_Buffer(0 To 8) As String
  Private PlrFact_Buffer(0 To 8) As String
  Private PlrTeam_Buffer(0 To 8) As Integer
  Private PlrTWin_Buffer(0 To 8) As Integer
  Private PlrTLoss_Buffer(0 To 8) As Integer
  Private PlrSteam_Buffer(0 To 8) As String
  Private PlrRID_Buffer(0 To 8) As Integer
  Private PlrRankALL_Buffer(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
  Private PlrRankWin_Buffer(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
  Private PlrRankLoss_Buffer(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
  Private PlrRankPerc_Buffer(0 To 8, 0 To 7, 0 To 4) As String  'R4.30 Rank from RID for all game modes.
  Private PlrCountry_Buffer(0 To 8) As String
  Private PlrCountryName_Buffer(0 To 8) As String                   'R4.46 Added contry.
  Private PlrELO_Buffer(0 To 8) As String
  Private PlrLVL_Buffer(0 To 8) As String
  Private PlrGLVL_Buffer(0 To 8) As Integer
  Private TeamList_Buffer(9, 1000) As clsGlobal.t_TeamList  'R4.34 Added for JSON team parsing.
  Private TeamListCnt_Buffer(9) As Integer

  Private LVLS(0 To 7, 0 To 4) As String
  Private LVLSteps(7, 4, 20) As Integer
  Private LVLpercs(20) As Single

  'R4.30 Get player info from RELICID
  'R4.30 ID for each game mode.
  Dim RelDataLeaderID(0 To 7, 0 To 4) As String

  'R4.46 Added Country Strings.
  Dim Country_Name(0 To 300) As String
  Dim Country_Abbr(0 To 300) As String
  Dim CountryCount As Integer

  'R4.00 Need these global so we can set them in frmLabelSetup objects. Could be properties.
  Private LSRank As clsGlobal.t_LabelSetup
  Private LSName As clsGlobal.t_LabelSetup
  Public Shared LSNote01 As clsGlobal.t_LabelSetup
  Public Shared LSNote02 As clsGlobal.t_LabelSetup
  Public Shared LSNote03 As clsGlobal.t_LabelSetup
  Public Shared LSNote04 As clsGlobal.t_LabelSetup
  Private NOTE_Spacing As Integer

  Private CFX3DActive(0 To 10) As Boolean
  Private CFX3DVar(0 To 10, 0 To 10) As String     'R3.10 1=Mode
  Private CFX3DC(0 To 10) As Color

  'Public NoteAnim01 As t_NoteAnimation            'R4.00 Added.
  Private Note01_Text(0 To 20) As String           'R4.00 These are used during the animation and are modified in code.
  Private Note02_Text(0 To 20) As String           'R4.00 These are used during the animation and are modified in code.
  Private Note03_Text(0 To 20) As String           'R4.00 These are used during the animation and are modified in code.
  Private Note04_Text(0 To 20) As String           'R4.00 These are used during the animation and are modified in code.

  Private NoteAnim_Setup As clsGlobal.t_NoteAnimation
  Private NoteAnim01 As clsGlobal.t_NoteAnimation
  Private NoteAnim02 As clsGlobal.t_NoteAnimation
  Private NoteAnim03 As clsGlobal.t_NoteAnimation
  Private NoteAnim04 As clsGlobal.t_NoteAnimation

  Private NoteAnim01_Text(0 To 10) As String      'R4.00 Added.
  Private NoteAnim02_Text(0 To 10) As String      'R4.00 Added.
  Private NoteAnim03_Text(0 To 10) As String      'R4.00 Added.
  Private NoteAnim04_Text(0 To 10) As String      'R4.00 Added.

  Private Note01_Bmp As Bitmap
  Private Note02_Bmp As Bitmap
  Private Note03_Bmp As Bitmap
  Private Note04_Bmp As Bitmap
  Private Note01_Gfx As Graphics
  Private Note02_Gfx As Graphics
  Private Note03_Gfx As Graphics
  Private Note04_Gfx As Graphics

  'R4.00 Need these global so we can set them in frmLabelSetup objects. Could be properties.
  Public Shared Note_BackBmp As Bitmap        'R4.00 Setup var for dialogs.
  Public Shared Note01_BackBmp As Bitmap      'R4.00 Note background images.
  Public Shared Note02_BackBmp As Bitmap
  Public Shared Note03_BackBmp As Bitmap
  Public Shared Note04_BackBmp As Bitmap
  Public Shared Note_OVLBmp As Bitmap         'R4.00 Setup var for dialogs.
  Public Shared Note01_OVLBmp As Bitmap       'R4.00 Note OVERLAY image.
  Public Shared Note02_OVLBmp As Bitmap
  Public Shared Note03_OVLBmp As Bitmap
  Public Shared Note04_OVLBmp As Bitmap
  Public Shared Note_BackScale As String
  Private Note01_BackScale As String
  Private Note02_BackScale As String
  Private Note03_BackScale As String
  Private Note04_BackScale As String
  Public Note_OVLScale As String
  Private Note01_OVLScale As String
  Private Note02_OVLScale As String
  Private Note03_OVLScale As String
  Private Note04_OVLScale As String

  Private SOUND_File(0 To 30) As String           'R4.00 Added.
  Private SOUND_Vol(0 To 30) As String            'R4.10 Added.

  Private ANIMATION_Smooth As Boolean
  Private CLOCK_TicksPerMS As Long
  Private CLOCK_Frames As Single


  Private Sub cmCheckLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmCheckLog.Click
    'R4.41 Added.
    lbStatus.BackColor = Color.FromArgb(255, 192, 255, 192) : lbStatus.Refresh()
    CONTROLS_Enabled(False)
    cmScanLog.Enabled = False

    'R4.50 Force the STATS image redraw.
    MainBuffer_Valid = False

    'R4.30 Removed extra GFX draw here.
    Call LOG_Scan()

    'R4.41 Added.
    lbStatus.BackColor = Color.FromArgb(255, 192, 192, 192) : lbStatus.Refresh()
    CONTROLS_Enabled(True)
    cmScanLog.Enabled = True

  End Sub

  Private Sub LOG_InitCalcArrays()

    LVLpercs(20) = 0.00013
    LVLpercs(19) = 0.00038
    LVLpercs(18) = 0.00176
    LVLpercs(17) = 0.00466
    LVLpercs(16) = 0.01019
    LVLpercs(15) = 0.0253
    LVLpercs(14) = 0.05021
    LVLpercs(13) = 0.10018
    LVLpercs(12) = 0.15014
    LVLpercs(11) = 0.20023
    LVLpercs(10) = 0.25019
    LVLpercs(9) = 0.31022
    LVLpercs(8) = 0.38019
    LVLpercs(7) = 0.45016
    LVLpercs(6) = 0.55021
    LVLpercs(5) = 0.65014
    LVLpercs(4) = 0.75019
    LVLpercs(3) = 0.80015
    LVLpercs(2) = 0.86018
    LVLpercs(1) = 0.94022

  End Sub

  Private Sub LOG_CalcLevelArrays()
    Dim Max As Integer

    For t1 = 1 To 7
      For t2 = 1 To 4

        'R4.30 calc levels 1 to 15 generically.
        Max = Val(LVLS(t1, t2))
        For t3 = 1 To 15
          LVLSteps(t1, t2, t3) = Max * LVLpercs(t2)
        Next t3

        'R4.30 Top 200 levels are always the same.
        LVLSteps(t1, t2, 20) = 1
        LVLSteps(t1, t2, 19) = 3
        LVLSteps(t1, t2, 18) = 14
        LVLSteps(t1, t2, 17) = 37
        LVLSteps(t1, t2, 16) = 81

      Next t2
    Next t1

  End Sub


  Private Sub STATS_StoreLast()
    Dim t As Integer
    Dim Hit As Integer

    'R4.30 See if we have new valid data.
    For t = 1 To 8
      If 0 < PlrRID(t) Then Hit = t : Exit For
    Next t

    'R3.000 We have new valid incoming data, so clear old data.
    If 0 < Hit Then
      For t = 1 To 8
        PlrRank_Last(t) = PlrRank_Buffer(t)
        PlrName_Last(t) = PlrName_Buffer(t)
        PlrSteam_Last(t) = PlrSteam_Buffer(t)
        PlrRID_Last(t) = PlrRID_Buffer(t)
        PlrFact_Last(t) = PlrFact_Buffer(t)
        PlrTeam_Last(t) = PlrTeam_Buffer(t)
        PlrTWin_Last(t) = PlrTWin_Buffer(t)
        PlrTLoss_Last(t) = PlrTLoss_Buffer(t)
        PlrCountry_Last(t) = PlrCountry_Buffer(t)
        PlrCountryName_Last(t) = PlrCountryName_Buffer(t)
        For T2 = 1 To 5
          For T3 = 1 To 4
            PlrRankALL_Last(t, T2, T3) = PlrRankALL_Buffer(t, T2, T3)
            PlrRankWin_Last(t, T2, T3) = PlrRankWin_Buffer(t, T2, T3)
            PlrRankLoss_Last(t, T2, T3) = PlrRankLoss_Buffer(t, T2, T3)
            PlrRankPerc_Last(t, T2, T3) = PlrRankPerc_Buffer(t, T2, T3)
          Next T3
        Next T2
        TeamListCnt_Last(t) = TeamListCnt_Buffer(t)
        For T2 = 1 To TeamList_Last.GetUpperBound(1)
          TeamList_Last(t, T2) = TeamList_Buffer(t, T2)
        Next T2
        PlrELO_Last(t) = PlrELO_Buffer(t)
        PlrLVL_Last(t) = PlrLVL_Buffer(t)
        PlrGLVL_Last(t) = PlrGLVL_Buffer(t)
      Next
    End If

  End Sub


  Private Sub LOG_Scan()
    'R4.00 Read the RELIC log file and get the match stats.
    'R4.00 Stats come in two sections. Each has a Relic ID #.
    'R4.00 Match the two sections using the Relic ID #.
    'R4.50 Relic broke the file so now there is only one section.
    Dim A, B As String
    Dim FindMatch As Boolean
    Dim FindPlayers As Boolean
    Dim MatchFound As Boolean
    Dim PlrCnt As Integer
    Dim MatchMode As Integer  'R4.30 1-1v1.2-2v2,etc
    Dim tLen As Integer
    Dim LCnt As Long
    Dim test1 As Long
    Dim test2 As Long
    Dim tRank As Long
    Dim tPlrRank(0 To 9) As String     'R3.10 Added Storage to place old vals on screen if no new onesa are found.
    Dim tPlrName(0 To 9) As String
    Dim tPlrSteam(0 To 9) As String
    Dim tPlrRID(0 To 9) As Integer
    Dim tPlrFact(0 To 9) As String
    Dim tPlrTWin(0 To 9) As Integer
    Dim tPlrTLoss(0 To 9) As Integer
    Dim tPlrTeam(0 To 9) As Integer
    Dim tPlrCountry(0 To 9) As String
    Dim tPlrCountryName(0 To 9) As String
    Dim tempTL As New clsGlobal.t_TeamList
    Dim tTeamList(9, 1000) As clsGlobal.t_TeamList
    Dim tTeamListCnt(9) As Integer
    Dim tPlrRankALL(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
    Dim tPlrRankWin(0 To 8, 0 To 7, 0 To 4) As Integer  'R4.30 Rank from RID for all game modes.
    Dim tPlrRankLoss(0 To 8, 0 To 7, 0 To 4) As Integer 'R4.30 Rank from RID for all game modes.
    Dim tPlrRankPerc(0 To 8, 0 To 7, 0 To 4) As String  'R4.30 Rank from RID for all game modes.
    Dim tPlrELO(0 To 9) As String
    Dim tPlrLVL(0 To 9) As String
    Dim tPlrGLVL(0 To 9) As Integer
    Dim MatchRID(0 To 9) As Long
    Dim GameRID(0 To 9) As Long
    Dim tCnt As Integer

    'R3.40 Reset the on screen ERROR labels.
    lbError1.Text = ""
    lbError1.BackColor = Color.FromArgb(255, 192, 192, 192)
    lbError2.Text = ""
    lbError2.BackColor = Color.FromArgb(255, 192, 192, 192)

    'R1.00 If we dont have a valid log file path, exit with help notice.
    If Not (System.IO.File.Exists(PATH_Game)) Then
      If PATH_Game = "" Then
        MsgBox("Please locate the warnings.log file in your COH2 My Games directory." & vbCr & vbCr & "Click on FIND LOG FILE to search and select.", MsgBoxStyle.Information)
      Else
        MsgBox("ERROR: The LOG file location does not appear to be valid." & vbCr & vbCr & "Unable to open the LOG file to get stats." & vbCr & "Verify this file/path exists." & vbCr & vbCr & PATH_Game, MsgBoxStyle.Critical)
      End If

      Exit Sub
    End If

    'R4.30 Delete the initial pretend setup player information.
    If Not FLAG_InitialScanning Then
      FLAG_InitialScanning = True
      For t = 1 To 8
        PlrRank(t) = "---"
        PlrName(t) = ""
        PlrSteam(t) = ""
        PlrFact(t) = ""
        PlrTWin(t) = 0
        PlrTLoss(t) = 0
        PlrTeam(t) = 0
        PlrCountry(t) = ""
        PlrCountryName(t) = ""
        For T2 = 1 To 5
          For T3 = 1 To 4
            PlrRankALL(t, T2, T3) = 0
            PlrRankWin(t, T2, T3) = 0
            PlrRankLoss(t, T2, T3) = 0
            PlrRankPerc(t, T2, T3) = ""
          Next T3
        Next T2
        TeamListCnt(t) = 0
        For T2 = 1 To TeamList.GetUpperBound(1)
          TeamList(t, T2) = tempTL
        Next T2
        PlrELO(t) = ""
        PlrLVL(t) = ""
        PlrGLVL(t) = 0
      Next
    End If

    'R3.00 Clear the Last Valid Match stats if necessary.
    'Call STATS_StoreLast()

    'R3.10 Clear the current match and find new data below. 
    For t = 1 To 8
      tPlrRank(t) = PlrRank(t) : PlrRank(t) = "---"
      tPlrName(t) = PlrName(t) : PlrName(t) = ""
      tPlrSteam(t) = PlrSteam(t) : PlrSteam(t) = ""
      tPlrRID(t) = PlrRID(t) : PlrRID(t) = 0
      tPlrFact(t) = PlrFact(t) : PlrFact(t) = ""
      tPlrTeam(t) = PlrTeam(t) : PlrTeam(t) = 0
      tPlrTWin(t) = PlrTWin(t) : PlrTWin(t) = 0
      tPlrTLoss(t) = PlrTLoss(t) : PlrTLoss(t) = 0
      tPlrCountry(t) = PlrCountry(t) : PlrCountry(t) = ""
      tPlrCountryName(t) = PlrCountryName(t) : PlrCountryName(t) = ""
      For T2 = 1 To 5
        For T3 = 1 To 4
          tPlrRankALL(t, T2, T3) = PlrRankALL(t, T2, T3) : PlrRankALL(t, T2, T3) = 0
          tPlrRankWin(t, T2, T3) = PlrRankWin(t, T2, T3) : PlrRankWin(t, T2, T3) = 0
          tPlrRankLoss(t, T2, T3) = PlrRankLoss(t, T2, T3) : PlrRankLoss(t, T2, T3) = 0
          tPlrRankPerc(t, T2, T3) = PlrRankPerc(t, T2, T3) : PlrRankPerc(t, T2, T3) = ""
        Next T3
      Next T2
      tTeamListCnt(t) = TeamListCnt(t) : TeamListCnt(t) = 0
      For T2 = 1 To TeamList.GetUpperBound(1)
        tTeamList(t, T2) = TeamList(t, T2) : TeamList(t, T2) = tempTL
      Next T2
      tPlrELO(t) = PlrELO(t) : PlrELO(t) = ""
      tPlrLVL(t) = PlrLVL(t) : PlrLVL(t) = ""
      tPlrGLVL(t) = PlrGLVL(t) : PlrGLVL(t) = 0

      'R4.30 Store PUBLIC copy for LAST MATCH ability.
      PlrRank_Buffer(t) = tPlrRank(t)
      PlrName_Buffer(t) = tPlrName(t)
      PlrSteam_Buffer(t) = tPlrSteam(t)
      PlrRID_Buffer(t) = tPlrRID(t)
      PlrFact_Buffer(t) = tPlrFact(t)
      PlrTeam_Buffer(t) = tPlrTeam(t)
      PlrTWin_Buffer(t) = tPlrTWin(t)
      PlrTLoss_Buffer(t) = tPlrTLoss(t)
      PlrCountry_Buffer(t) = tPlrCountry(t)             'R4.45 Added.
      PlrCountryName_Buffer(t) = tPlrCountryName(t)     'R4.45 Added.
      For T2 = 1 To 5
        For T3 = 1 To 4
          PlrRankALL_Buffer(t, T2, T3) = tPlrRankALL(t, T2, T3)
          PlrRankWin_Buffer(t, T2, T3) = tPlrRankWin(t, T2, T3)
          PlrRankLoss_Buffer(t, T2, T3) = tPlrRankLoss(t, T2, T3)
          PlrRankPerc_Buffer(t, T2, T3) = tPlrRankPerc(t, T2, T3)
        Next T3
      Next T2
      TeamListCnt_Buffer(t) = tTeamListCnt(t)
      For T2 = 1 To TeamList_Buffer.GetUpperBound(1)
        TeamList_Buffer(t, T2) = tTeamList(t, T2)
      Next T2
      PlrELO_Buffer(t) = tPlrELO(t)
      PlrLVL_Buffer(t) = tPlrLVL(t)
      PlrGLVL_Buffer(t) = tPlrGLVL(t)
    Next

    lbStatus.Text = "Open file..." : Application.DoEvents()

    Me.Cursor = Cursors.WaitCursor

    'R2.01 OPEN log file and start parsing.
    Dim fs = New IO.FileStream(PATH_Game, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
    Dim sr = New IO.StreamReader(fs, System.Text.Encoding.UTF8)

    Using (sr)

      PlrCnt = 0
      LCnt = 0
      MatchFound = False
      FindMatch = False

      'R2.01 Loop thru the file looking for the match stats.
      While Not sr.EndOfStream
        A = sr.ReadLine()

        '**********************************************************************************
        'R3.20 If Match Started string is found, find all of the other match stats lines.
        '**********************************************************************************
        If InStr(A, "Match Started") Then
          FindMatch = True

          'R3.20 We have found a new section so clear the previous data.
          For t = 1 To 8
            PlrRank(t) = "---"
            PlrSteam(t) = ""
            MatchRID(t) = 0
          Next

          PlrCnt = 0
          While (Not sr.EndOfStream) And (FindMatch = True)
            PlrCnt += 1

            B = Trim(Mid(A, 98, 20))
            If (B = "-1") Or (B = "") Then    'R2.01 Added +1 to rank code. 
              B = ""                          'R1.00 Show unranked as --       
            Else
              tRank = Val(B)
              B = CStr(tRank + 1)
            End If
            PlrRank(PlrCnt) = B

            'R3.20 Get SteamID. If valid, get RelicID also.
            PlrSteam(PlrCnt) = Mid(A, 57, 17)
            If Mid(PlrSteam(PlrCnt), 1, 4) <> "7656" Then
              PlrSteam(PlrCnt) = ""
              MatchRID(PlrCnt) = 0
            Else
              MatchRID(PlrCnt) = LOG_HexToLong(Mid(A, 41, 8))       'R3.20 <-- Convert.ToInt64(Mid(A, 41, 8), 16)
              If MatchRID(PlrCnt) = -1 Then MatchRID(PlrCnt) = 0
            End If

            'R3.20 Read the next line of the file and exit if all of the match lines have been found.
            A = sr.ReadLine()
            If InStr(A, "Match Started") = 0 Then FindMatch = False

          End While

        End If


        '**********************************************************************************
        '3.20 If we find a GAME Human Player string, find all of the other player stats.
        '**********************************************************************************
        If InStr(A, "GAME ") Then
          If (InStr(A, "Human Player")) Or (InStr(A, "AI Player")) Then
            FindPlayers = True

            'R3.20 We have found a new section so clear the previous data.
            For t = 1 To 8
              PlrName(t) = ""
              PlrFact(t) = ""
              PlrRID(t) = 0
              PlrTeam(t) = 0
              PlrTWin(t) = 0
              PlrTLoss(t) = 0
              PlrCountry(t) = ""                'R4.45 Added.
              PlrCountryName(t) = ""            'R4.46 Added.
              For T2 = 1 To 5
                For T3 = 1 To 4
                  PlrRankALL(t, T2, T3) = 0
                  PlrRankWin(t, T2, T3) = 0
                  PlrRankLoss(t, T2, T3) = 0
                  PlrRankPerc(t, T2, T3) = ""
                Next T3
              Next T2
              TeamListCnt(t) = 0
              For T2 = 1 To TeamList.GetUpperBound(1)
                TeamList(t, T2) = tempTL
              Next
              GameRID(t) = 0
            Next

            PlrCnt = 0 : FindPlayers = True
            While (Not sr.EndOfStream) And (FindPlayers = True)
              PlrCnt += 1

              test1 = InStr(A, "Human Player")
              test2 = InStr(A, "AI Player")

              If test1 Then
                PlrName(PlrCnt) = LOG_FindPlayer(A, 39)   'R2.01 Names are not Delimited, need to search for end of name from the end of line.
                GameRID(PlrCnt) = LOG_Find_RelicID(A)     'R3.20 Get the RelicID for this player.  
                PlrRID(PlrCnt) = GameRID(PlrCnt)          'R4.30 Added.
              Else
                PlrName(PlrCnt) = LOG_FindPlayer(A, 36)   'R2.01 AI player. 
                'PlrRank(PlrCnt) = ""                     'R4.30 Added for match tracking.
                GameRID(PlrCnt) = 0                       'R3.20 AI has no RelicID.
                PlrRID(PlrCnt) = 0                        'R4.30 Added.
              End If

              'R3.40 The last part of the string will have faction.
              tLen = Len(A)        'R3.40 Get the lenght of the string.
              If 20 < tLen Then    'R3.40 This should never happen, but just in case.
                If (Mid(A, tLen - 5, 6) = "german") Then PlrFact(PlrCnt) = "01"
                If (Mid(A, tLen - 5, 6) = "soviet") Then PlrFact(PlrCnt) = "02"
                If (Mid(A, tLen - 10, 11) = "west_german") Then PlrFact(PlrCnt) = "03"
                If (Mid(A, tLen - 2, 3) = "aef") Then PlrFact(PlrCnt) = "04"
                If (Mid(A, tLen - 6, 7) = "british") Then PlrFact(PlrCnt) = "05"
              End If

              'R3.20 Read the next line of the file.
              A = sr.ReadLine()
              test1 = InStr(A, "Human Player")
              test2 = InStr(A, "AI Player")
              If (test1 = 0) And (test2 = 0) Then FindPlayers = False

            End While

          End If
        End If

      End While

    End Using


    'R2.01 Close / Clean up  streams?
    sr.Close()        'R4.00 Should not need, is inside USING.
    sr.Dispose()
    fs.Close()
    fs.Dispose()


    'R3.20 Verify all of our data matches. Test against RelicID. Relic broke the STEAM_ID with 64-bit patch.
    'If FLAG_ShowMismatch = False Then
    '  Dim ValidData As Boolean = True
    '  For t = 1 To 8
    '    If (MatchRID(t) <> GameRID(t)) Then ValidData = False : Exit For
    '  Next

    '  'R3.20 The data is not valid, clear all data.
    '  If ValidData = False Then
    '    lbError1.Text = "Mismatched"
    '    lbError1.BackColor = Color.FromArgb(255, 255, 0, 0)
    '    lbError2.Text = "Bad Stats"
    '    lbError2.BackColor = Color.FromArgb(255, 255, 0, 0)
    '    For t = 1 To 8
    '      PlrName(t) = ""
    '      PlrRank(t) = "---"
    '      PlrSteam(t) = ""
    '      PlrRID(t) = 0
    '      PlrFact(t) = ""
    '      PlrELO(t) = ""
    '      PlrLVL(t) = ""
    '      For T2 = 1 To 5
    '        For T3 = 1 To 4
    '          PlrRankALL(t, T2, T3) = 0
    '          PlrRankWin(t, T2, T3) = 0
    '          PlrRankLoss(t, T2, T3) = 0
    '          PlrRankPerc(t, T2, T3) = ""
    '        Next T3
    '      Next T2
    '      tPlrName(t) = ""
    '      tPlrRank(t) = ""
    '      tPlrSteam(t) = ""
    '      tPlrFact(t) = ""
    '      tPlrELO(t) = ""
    '      tPlrLVL(t) = ""
    '      For T2 = 1 To 5
    '        For T3 = 1 To 4
    '          tPlrRankALL(t, T2, T3) = 0
    '          tPlrRankWin(t, T2, T3) = 0
    '          tPlrRankLoss(t, T2, T3) = 0
    '          tPlrRankPerc(t, T2, T3) = ""
    '        Next T3
    '      Next T2
    '    Next
    '  End If
    'End If


    'R4.30 Play the MATCH FOUND ALERT if this a NEW match and are we in AUTO mode.
    Dim F_NewData As Boolean = False
    For t = 1 To 8
      If PlrName(t) <> tPlrName(t) Then F_NewData = True : Exit For
      If PlrRID(t) <> tPlrRID(t) Then F_NewData = True : Exit For
      If PlrFact(t) <> tPlrFact(t) Then F_NewData = True : Exit For
      'If PlrSteam(t) <> tPlrSteam(t) Then F_NewData = True : Exit For  'R4.30 Not in file anymore.
      'If PlrRank(t) <> tPlrRank(t) Then F_NewData = True : Exit For    'R4.30 Not in file anymore.
    Next t

    'R4.30 Clear the Last Valid Match stats if necessary.
    If F_NewData Then
      'R4.30 Reset the ELO cycle mode.
      FLAG_EloMode = 0

      Call STATS_StoreLast()

      If (chkFoundSound.Checked = True) And SCAN_Enabled And (SOUND_File(15) <> "") And (0 < PlrCnt) Then
        AUDIO_SetVolume(100, SOUND_Vol(15))
        SOUND_Play(SOUND_File(15))
      End If

      'R4.50 Show time on status bar.
      SS1_Time.Text = "Match found: " & DateTime.Now.ToString("HH:mm") 'TimeString.ToString("HH:mm")
    End If

    'R3.10 If no new data was found, show the old data.
    If F_NewData = False Then
      For t = 1 To 8
        PlrRank(t) = tPlrRank(t)
        PlrName(t) = tPlrName(t)
        PlrSteam(t) = tPlrSteam(t)
        PlrRID(t) = tPlrRID(t)
        PlrFact(t) = tPlrFact(t)
        PlrTeam(t) = tPlrTeam(t)
        PlrTWin(t) = tPlrTWin(t)
        PlrTLoss(t) = tPlrTLoss(t)
        PlrCountry(t) = tPlrCountry(t)          'R4.45 Added.
        PlrCountryName(t) = tPlrCountryName(t)  'R4.46 Added.
        For T2 = 1 To 5
          For T3 = 1 To 4
            PlrRankALL(t, T2, T3) = tPlrRankALL(t, T2, T3)
            PlrRankWin(t, T2, T3) = tPlrRankWin(t, T2, T3)
            PlrRankLoss(t, T2, T3) = tPlrRankLoss(t, T2, T3)
            PlrRankPerc(t, T2, T3) = tPlrRankPerc(t, T2, T3)
          Next T3
        Next T2
        TeamListCnt(t) = tTeamListCnt(t)
        For T2 = 1 To TeamList.GetUpperBound(1)
          TeamList(t, T2) = tTeamList(t, T2)
        Next T2
        PlrELO(t) = tPlrELO(t)
        PlrLVL(t) = tPlrLVL(t)
      Next
    End If

    lbStatus.Text = "Render..." : Application.DoEvents()

    If 0 < PlrCnt Then MatchMode = 1
    If 2 < PlrCnt Then MatchMode = 2
    If 4 < PlrCnt Then MatchMode = 3
    If 6 < PlrCnt Then MatchMode = 4

    'R4.30 Adjust NAME and RANKS before drawing.
    If (0 < PlrCnt) And (F_NewData Or (Not SCAN_Enabled)) Then
      lstLog.Items.Clear()          'R4.42 Clear error log.

      'R4.30 Get player ranks from the RELIC API.
      For t = 1 To 8
        If (PlrName(t) <> "") And (PlrFact(t) <> "") And (0 < Val(GameRID(t))) Then

          lbStatus.Text = "Web Player: " & t : Application.DoEvents()
          Call STAT_GetFromRID(GameRID(t), t)
          lbStatus.Text = "" : Application.DoEvents()
          PlrRank(t) = PlrRankALL(t, PlrFact(t), MatchMode)
          If PlrRank(t) = "0" Then PlrRank(t) = "---"
          PlrWin(t) = PlrRankWin(t, PlrFact(t), MatchMode)
          PlrLoss(t) = PlrRankLoss(t, PlrFact(t), MatchMode)
        End If
      Next t
      lstLog.Items.Add(Now.ToLongTimeString & " - Get RID - Complete.")

      For t = 1 To 8
        'R4.30 See if any players are a premade team.
        tCnt = 0
        If t Mod 2 = 1 Then
          For t2 = 1 To 7 Step 2
            If (PlrRank(t) = PlrRank(t2)) Then tCnt += 1
          Next t2
        Else
          For t2 = 2 To 8 Step 2
            If (PlrRank(t) = PlrRank(t2)) Then tCnt += 1
          Next t2
        End If

        'R4.30 Update the MAX player counts if on a premade team.
        PlrGLVL(t) = Val(LVLS(Val(PlrFact(t)), MatchMode))
        If (tCnt = 2) Then  'R4.30 AT 2v2
          If (PlrFact(t) = "01" Or PlrFact(t) = "03") Then
            PlrGLVL(t) = Val(LVLS(7, 2))
          Else
            PlrGLVL(t) = Val(LVLS(6, 2))
          End If
        End If
        If (tCnt = 3) Then  'R4.30 AT 3v3
          If (PlrFact(t) = "01" Or PlrFact(t) = "03") Then
            PlrGLVL(t) = Val(LVLS(7, 3))
          Else
            PlrGLVL(t) = Val(LVLS(6, 3))
          End If
        End If
        If (tCnt = 4) Then  'R4.30 AT 4v4
          If (PlrFact(t) = "01" Or PlrFact(t) = "03") Then
            PlrGLVL(t) = Val(LVLS(7, 4))
          Else
            PlrGLVL(t) = Val(LVLS(6, 4))
          End If
        End If

        'R4.30 Calc ELO % and LEVEL values.
        If PlrRank(t) = "" Then PlrRank(t) = "---"
        If PlrName(t) = "" Then
          PlrRank(t) = ""
          PlrELO(t) = ""
          PlrLVL(t) = ""
        Else
          'R4.30 We have a valid player so calc ELO % and approximate LEVEL value.
          If 0 < Val(LVLS(PlrFact(t), MatchMode)) Then
            If PlrRank(t) = "---" Then
              PlrELO(t) = "---"
              PlrLVL(t) = "---"
            Else
              PlrELO(t) = (100 * (Val(PlrRank(t)) / PlrGLVL(t))).ToString("##.0") & "%"
              PlrLVL(t) = "L-" & LOG_CalcLevel(Val(PlrRank(t)), PlrGLVL(t))
            End If
          Else
            PlrELO(t) = ""
            PlrLVL(t) = ""
          End If
        End If

      Next t
    End If

    'R4.34 Dont write over the ELO cycle unless we have new data.
    If (F_NewData Or (Not SCAN_Enabled)) Then

      'R4.34 See if we should search the net for team ranks.
      If chkGetTeams.Checked Then
        'R4.34 Set ranks if players are a team.
        Call STAT_GetCheckForTeam()
        lstLog.Items.Add(Now.ToLongTimeString & " - TEAM Check - Completed.")
      End If

      'R4.34 Text-to-Speech the ranks.
      If chkSpeech.Checked Then Call STATS_ReadAloud()

      'R4.50 Force the STATS image redraw.
      MainBuffer_Valid = False

      'R4.34 Draw the updated ranks.
      Call GFX_DrawStats()
    End If

    'R4.30 Clean up our GUI user indicators.
    Me.Cursor = Cursors.Default
    lbStatus.Text = "Ready" : Application.DoEvents()

  End Sub

  Private Sub STAT_GetCheckForTeam()
    'R4.34 Added.
    Dim TempRank As Long
    Dim TempWin As Long
    Dim TempLoss As Long
    Dim TempMax As Long
    Dim A As String = ""
    Dim Cnt As Integer
    Dim MCnt(9) As Integer
    Dim MTeam(9) As Integer
    Dim MPlr(9, 5) As Integer

    'R4.41 Added TRY CATCH.
    Try

      '*********************************************************
      'R4.34 Loop thru TEAM 1 looking for possible teams.
      '*********************************************************
      For t = 1 To 8 Step 2
        For t2 = 1 To TeamListCnt(t)
          Cnt = 0

          If 0 < TeamList(t, t2).RID1 Then
            If PlrRID(1) = TeamList(t, t2).RID1 Then Cnt += 1
            If PlrRID(3) = TeamList(t, t2).RID1 Then Cnt += 1
            If PlrRID(5) = TeamList(t, t2).RID1 Then Cnt += 1
            If PlrRID(7) = TeamList(t, t2).RID1 Then Cnt += 1
          End If
          If 0 < TeamList(t, t2).RID2 Then
            If PlrRID(1) = TeamList(t, t2).RID2 Then Cnt += 1
            If PlrRID(3) = TeamList(t, t2).RID2 Then Cnt += 1
            If PlrRID(5) = TeamList(t, t2).RID2 Then Cnt += 1
            If PlrRID(7) = TeamList(t, t2).RID2 Then Cnt += 1
          End If
          If 0 < TeamList(t, t2).RID3 Then
            If PlrRID(1) = TeamList(t, t2).RID3 Then Cnt += 1
            If PlrRID(3) = TeamList(t, t2).RID3 Then Cnt += 1
            If PlrRID(5) = TeamList(t, t2).RID3 Then Cnt += 1
            If PlrRID(7) = TeamList(t, t2).RID3 Then Cnt += 1
          End If
          If 0 < TeamList(t, t2).RID4 Then
            If PlrRID(1) = TeamList(t, t2).RID4 Then Cnt += 1
            If PlrRID(3) = TeamList(t, t2).RID4 Then Cnt += 1
            If PlrRID(5) = TeamList(t, t2).RID4 Then Cnt += 1
            If PlrRID(7) = TeamList(t, t2).RID4 Then Cnt += 1
          End If
          If 1 < Cnt Then
            'we found a team.
            If (MCnt(t) <= Cnt) And (TeamList(t, t2).PlrCnt <= Cnt) Then
              MCnt(t) = Cnt
              MTeam(t) = t2
            End If
          End If
        Next t2
      Next t

      'R4.34 Decide if the team is Axis(20,22,24) or Allies(21,23,25) by faction.
      For t = 1 To 8 Step 2
        TempRank = 0
        If 0 < MTeam(t) Then
          If (PlrFact(t) = "01") Or (PlrFact(t) = "03") Then    'R4.34 OST or OKW.
            'R4.35 Added TEAM Win/Loss.
            TempRank = TeamList(t, MTeam(t)).RankAxis
            TempWin = TeamList(t, MTeam(t)).WinAxis
            TempLoss = TeamList(t, MTeam(t)).LossAxis
            Select Case TeamList(t, MTeam(t)).PlrCnt
              Case 2 : TempMax = Val(LVLS(7, 2))   'R4.41 Bug fix.
              Case 3 : TempMax = Val(LVLS(7, 3))   'R4.41 Bug fix.
              Case 4 : TempMax = Val(LVLS(7, 4))   'R4.41 Bug fix.
            End Select
          Else
            'R4.35 Added TEAM Win/Loss.
            TempRank = TeamList(t, MTeam(t)).RankAllies
            TempWin = TeamList(t, MTeam(t)).WinAllies
            TempLoss = TeamList(t, MTeam(t)).LossAllies
            Select Case TeamList(t, MTeam(t)).PlrCnt
              Case 2 : TempMax = Val(LVLS(6, 2))   'R4.41 Bug fix.
              Case 3 : TempMax = Val(LVLS(6, 3))   'R4.41 Bug fix.
              Case 4 : TempMax = Val(LVLS(6, 4))   'R4.41 Bug fix.
            End Select
          End If
          PlrTeam(t) = MTeam(t)
          PlrTWin(t) = TempWin                        'R4.35 Added TEAM Win/Loss.
          PlrTLoss(t) = TempLoss
          PlrRank(t) = TempRank.ToString() & "."
          If (TempMax < 1) Or (TempRank < 1) Then
            If PlrRank(t) = "-1." Then
              PlrRank(t) = "P."                     'R4.46 Added.
            End If
            PlrELO(t) = "---"
            PlrLVL(t) = "---"
          Else
            PlrELO(t) = (100 * (Val(PlrRank(t)) / TempMax)).ToString("##.0") & "%"
            PlrLVL(t) = "L-" & LOG_CalcLevel(Val(PlrRank(t)), TempMax)
          End If

        End If
      Next t

      '*********************************************************
      'R4.34 Loop thru TEAM 2 looking for possible teams.
      '*********************************************************
      For t = 2 To 8 Step 2
        For t2 = 1 To TeamListCnt(t)
          Cnt = 0

          If 0 < TeamList(t, t2).RID1 Then
            If PlrRID(2) = TeamList(t, t2).RID1 Then Cnt += 1
            If PlrRID(4) = TeamList(t, t2).RID1 Then Cnt += 1
            If PlrRID(6) = TeamList(t, t2).RID1 Then Cnt += 1
            If PlrRID(8) = TeamList(t, t2).RID1 Then Cnt += 1
          End If
          If 0 < TeamList(t, t2).RID2 Then
            If PlrRID(2) = TeamList(t, t2).RID2 Then Cnt += 1
            If PlrRID(4) = TeamList(t, t2).RID2 Then Cnt += 1
            If PlrRID(6) = TeamList(t, t2).RID2 Then Cnt += 1
            If PlrRID(8) = TeamList(t, t2).RID2 Then Cnt += 1
          End If
          If 0 < TeamList(t, t2).RID3 Then
            If PlrRID(2) = TeamList(t, t2).RID3 Then Cnt += 1
            If PlrRID(4) = TeamList(t, t2).RID3 Then Cnt += 1
            If PlrRID(6) = TeamList(t, t2).RID3 Then Cnt += 1
            If PlrRID(8) = TeamList(t, t2).RID3 Then Cnt += 1
          End If
          If 0 < TeamList(t, t2).RID4 Then
            If PlrRID(2) = TeamList(t, t2).RID4 Then Cnt += 1
            If PlrRID(4) = TeamList(t, t2).RID4 Then Cnt += 1
            If PlrRID(6) = TeamList(t, t2).RID4 Then Cnt += 1
            If PlrRID(8) = TeamList(t, t2).RID4 Then Cnt += 1
          End If
          If 1 < Cnt Then
            'R4.34 We found a team.
            If (MCnt(t) <= Cnt) And (TeamList(t, t2).PlrCnt <= Cnt) Then
              MCnt(t) = Cnt
              MTeam(t) = t2
            End If
          End If
        Next t2
      Next t

      'R4.34 Decide if the team is Axis(20,22,24) or Allies(21,23,25) by faction.
      For t = 2 To 8 Step 2
        TempRank = 0
        TempMax = 0
        If 0 < MTeam(t) Then
          If (PlrFact(t) = "01") Or (PlrFact(t) = "03") Then    'R4.34 OST or OKW.
            TempRank = TeamList(t, MTeam(t)).RankAxis
            TempWin = TeamList(t, MTeam(t)).WinAxis
            TempLoss = TeamList(t, MTeam(t)).LossAxis
            Select Case TeamList(t, MTeam(t)).PlrCnt
              Case 2 : TempMax = Val(LVLS(7, 2))   'R4.41 Bug fix.
              Case 3 : TempMax = Val(LVLS(7, 3))   'R4.41 Bug fix.
              Case 4 : TempMax = Val(LVLS(7, 4))   'R4.41 Bug fix.
            End Select
          Else
            TempRank = TeamList(t, MTeam(t)).RankAllies
            TempWin = TeamList(t, MTeam(t)).WinAllies
            TempLoss = TeamList(t, MTeam(t)).LossAllies
            Select Case TeamList(t, MTeam(t)).PlrCnt
              Case 2 : TempMax = Val(LVLS(6, 2))   'R4.41 Bug fix.
              Case 3 : TempMax = Val(LVLS(6, 3))   'R4.41 Bug fix.
              Case 4 : TempMax = Val(LVLS(6, 4))   'R4.41 Bug fix.
            End Select
          End If
          PlrTeam(t) = MTeam(t)
          PlrTWin(t) = TempWin                        'R4.35 Added TEAM Win/Loss.
          PlrTLoss(t) = TempLoss
          PlrRank(t) = TempRank.ToString() & "."
          If (TempMax < 1) Or (TempRank < 1) Then
            If PlrRank(t) = "-1." Then
              PlrRank(t) = "P."                       'R4.46 Added.
            End If
            PlrELO(t) = "---"
            PlrLVL(t) = "---"
          Else
            PlrELO(t) = (100 * (Val(PlrRank(t)) / TempMax)).ToString("##.0") & "%"
            PlrLVL(t) = "L-" & LOG_CalcLevel(Val(PlrRank(t)), TempMax)
          End If
        End If
      Next t

    Catch ex As Exception
      lbError2.Text = "Team Check Err"
      lbError2.BackColor = Color.FromArgb(255, 255, 0, 0)

      lstLog.Items.Add(Now.ToLongTimeString & " - Team Check - ERR:" & Err.Description)
    End Try

  End Sub

  Private Sub STATS_ReadAloud()
    'R4.34 Added.
    Dim A As String = ""
    Dim GoodGuys As String = "Good Guys"
    Dim BadGuys As String = "Bad Guys"
    'Dim tts As New SpeechSynthesizer
    Dim TP(9) As String

    If FLAG_SpeechOK = False Then
      lbError2.Text = "Speech Error"
      Exit Sub
    End If

    'R4.34 Remove some chars for clearer speech.
    For t = 1 To 8
      A = PlrName(t)
      A = A.Replace(".", "")
      A = A.Replace(",", "")
      A = A.Replace("|", "")
      TP(t) = A
    Next t

    If (PlrFact(1) = "01") Or (PlrFact(1) = "03") Then
      GoodGuys = "Axis"
      BadGuys = "Allies"
    End If
    If (PlrFact(1) = "02") Or (PlrFact(1) = "04") Or (PlrFact(1) = "05") Then
      GoodGuys = "Allies"
      BadGuys = "Axis"
    End If

    A = A & "The " & GoodGuys & " players are "
    For t = 1 To 8 Step 2
      If PlrName(t) <> "" Then 'R4.34 User may be "..." which will be "".
        A = A & "Player " & TP(t) & ","

        If PlrRank(t) = "---" Then
          A = A & "Faction Rank is None" & ","
        Else
          A = A & "Faction Rank is " & PlrRank(t) & ","
        End If
      End If
    Next

    A = A & "The " & BadGuys & " players are "
    For t = 2 To 8 Step 2
      If PlrName(t) <> "" Then 'R4.34 User may be "..." which will be "".
        A = A & "Player " & TP(t) & ","

        If PlrRank(t) = "---" Then
          A = A & "Faction Rank is None" & ","
        Else
          A = A & "Faction Rank is " & PlrRank(t) & ","
        End If
      End If
    Next

    A = A & ",So we have " & GoodGuys & " "
    For t = 1 To 8 Step 2
      If PlrName(t) <> "" Then
        Select Case PlrFact(t)
          Case "01" : A = A & "O S T,"
          Case "02" : A = A & "SOVIET,"
          Case "03" : A = A & "O K W,"
          Case "04" : A = A & "U S F,"
          Case "05" : A = A & "BRIT,"
        End Select
        If PlrRank(t) = "---" Then
          A = A & "No rank" & ","
        Else
          A = A & "Rank " & PlrRank(t) & ","
        End If
      End If
    Next

    A = A & ", versus " & BadGuys & " "
    For t = 2 To 8 Step 2
      If PlrName(t) <> "" Then
        If PlrName(t) <> "" Then
          Select Case PlrFact(t)
            Case "01" : A = A & "O S T,"
            Case "02" : A = A & "SOVIET,"
            Case "03" : A = A & "O K W,"
            Case "04" : A = A & "U S F,"
            Case "05" : A = A & "BRIT,"
          End Select
          If PlrRank(t) = "---" Then
            A = A & "No rank" & ","
          Else
            A = A & "Rank " & PlrRank(t) & ","
          End If
        End If
      End If
    Next

    If A <> "" Then SpeechSynth.SpeakAsync(A)

  End Sub

  Private Function LOG_HexToLong(A As String) As Long
    Dim L As Long

    'R3.20 Convert a Hex String to a Long. If ERROR, set to ZERO.
    Try
      L = Convert.ToInt64(A, 16)
    Catch ex As Exception
      L = 0
    End Try

    LOG_HexToLong = L

  End Function


  Private Function LOG_CalcLevel(PlrRank As Integer, tMax As Integer) As Integer
    Dim TL As Integer

    'R4.30 loop thru the possible levels.
    TL = 1
    For t = 1 To 15
      If ((LVLpercs(t) * tMax) > PlrRank) Then TL = t + 1
    Next

    'R4.30 Levels above rank 200 are always the same.
    If 200 > PlrRank Then TL = 16
    If 81 > PlrRank Then TL = 17
    If 37 > PlrRank Then TL = 18
    If 14 > PlrRank Then TL = 19
    If 3 > PlrRank Then TL = 20
    If PlrRank = 0 Then TL = 0

    LOG_CalcLevel = TL

  End Function

  Private Function LOG_Find_RelicID(A As String) As Long
    Dim RID As Long = 0
    Dim C As String
    Dim T As Integer
    Dim Cnt As Integer
    Dim CharStart As Integer
    Dim CharEnd As Integer

    'R3.20 Get the RelicID number from the Player stats line.
    For T = Len(A) To 1 Step -1
      C = Mid(A, T, 1)
      If C = " " Then
        Cnt += 1

        If Cnt = 2 Then CharEnd = T

        If Cnt = 3 Then
          CharStart = T
          Exit For
        End If
      End If

    Next T

    If CharEnd Then RID = Val(Mid(A, CharStart, CharEnd - CharStart))

    LOG_Find_RelicID = RID

  End Function


  Private Function LOG_FindPlayer(A As String, CharStart As Integer) As String
    Dim C As String
    Dim T As Integer
    Dim Cnt As Integer
    Dim CharEnd As Integer

    For T = Len(A) To 1 Step -1
      C = Mid(A, T, 1)
      If C = " " Then Cnt += 1
      If Cnt = 3 Then
        CharEnd = T
        Exit For
      End If
    Next T

    C = "None"
    If CharEnd Then C = Mid(A, CharStart, CharEnd - CharStart)

    LOG_FindPlayer = C

  End Function

  Private Function SETTINGS_Load_CheckVersion(tFile As String, ByRef IsOldStyle As Boolean) As Boolean
    Dim tPath As String
    Dim FileOK As Boolean = False
    Dim A As String = ""

    'R4.20 Added Load/Save setups options.
    If tFile = "" Then
      tPath = Application.StartupPath() & "\MakoCelo_settings.dat"
    Else
      tPath = tFile
    End If

    If Not (System.IO.File.Exists(tPath)) Then
      SETTINGS_Load_CheckVersion = FileOK
      Exit Function
    End If

    'R4.00 Create a stream reader to read the file in UTF8 mode.
    Dim fs As IO.FileStream = Nothing
    Dim sr As IO.StreamReader = Nothing

    Try
      fs = New IO.FileStream(tPath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
      sr = New IO.StreamReader(fs, System.Text.Encoding.UTF8)

      'R4.00 Read VERSION from file.
      A = sr.ReadLine()

      Select Case A
        Case Chr(34) & "VERSION MC300" & Chr(34)
          FileOK = True
          IsOldStyle = True

        Case Chr(34) & "VERSION MC400" & Chr(34)
          FileOK = True
          IsOldStyle = True

        Case "VERSION MC300"
          FileOK = True
          IsOldStyle = True

        Case "VERSION MC400"
          FileOK = True
          IsOldStyle = True

        Case "VERSION MC500"
          FileOK = True
          IsOldStyle = False

        Case "VERSION MC600"
          FileOK = True
          IsOldStyle = False

        Case Else
          'R4.30 Changed this message to give users a chance to not destroy settings when going back a rev of code.
          A = "WARNING: The MakoCelo settings file seems to be from an unknown version of code." & vbCr & vbCr
          A = A & "Do you wish to try to use these settings?" & vbCr & vbCr
          A = A & "NOTE: A new version of the settings file will be created later." & vbCr & vbCr
          Dim result As DialogResult = MsgBox(A, MsgBoxStyle.YesNo, "MakoCelo Startup Checks")

          'R4.30 User selected YES, so load the file as the newest version and assume the file is newer than our code.
          If result = DialogResult.Yes Then
            FileOK = True
            IsOldStyle = False
          End If

      End Select

    Catch ex As Exception
      MsgBox("ERROR: " & ex.Message & vbCr & vbCr & "Unable to read the saved settings." & vbCr & "The last known setup could not be loaded." & vbCr & vbCr & "If running a new version, this error may fix itself when a new setup is saved.", MsgBoxStyle.Critical, "MakoCelo - Setup Error")

    End Try

    sr.Close()
    sr.Dispose()
    fs.Close()
    fs.Dispose()

    SETTINGS_Load_CheckVersion = FileOK

  End Function
  Private Sub SETTINGS_Load(tFILE As String)
    Dim C As Color
    Dim Vlong As Long
    Dim tPath As String
    Dim A As String = ""
    Dim Ca, Cr, Cg, Cb As Integer
    Dim tFont_Type As Integer
    Dim Frev As Integer = 0

    'R4.20 Added Load/Save setups options.
    If tFILE = "" Then
      tPath = Application.StartupPath() & "\MakoCelo_settings.dat"
    Else
      tPath = tFILE
    End If

    If Not (System.IO.File.Exists(tPath)) Then Exit Sub


    'R2.01 OPEN log file and start parsing.
    Dim fs As IO.FileStream
    Dim sr As IO.StreamReader

    Try
      fs = New IO.FileStream(tPath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
      sr = New IO.StreamReader(fs, System.Text.Encoding.UTF8)

      A = sr.ReadLine()
      Select Case A
        Case "VERSION MC200"
          Frev = 2
          A = sr.ReadLine()            'R2.00 Read extra header line.
        Case "VERSION MC300"
          Frev = 3
          A = sr.ReadLine()            'R2.00 Read extra header line.
        Case "VERSION MC400"
          Frev = 4
          A = sr.ReadLine()            'R2.00 Read extra header line.
        Case "VERSION MC500"
          Frev = 5
          A = sr.ReadLine()            'R2.00 Read extra header line.
        Case "VERSION MC600"
          Frev = 6
          A = sr.ReadLine()            'R2.00 Read extra header line.
        Case Else
          MsgBox("WARNING: The startup data file appears to be corrupt or incorrect." & vbCr & vbCr & "Path: " & Application.StartupPath() & "\MakoCelo_settings.dat", vbCritical, "MakoCELO")
      End Select

      A = sr.ReadLine() : Ca = Val(A)
      A = sr.ReadLine() : Cr = Val(A)
      A = sr.ReadLine() : Cg = Val(A)
      A = sr.ReadLine() : Cb = Val(A)
      C = Color.FromArgb(Ca, Cr, Cg, Cb)

      A = sr.ReadLine()   'R1.00 BACK COLOR
      A = sr.ReadLine() : Ca = Val(A)
      A = sr.ReadLine() : Cr = Val(A)
      A = sr.ReadLine() : Cg = Val(A)
      A = sr.ReadLine() : Cb = Val(A)
      C = Color.FromArgb(Ca, Cr, Cg, Cb)

      A = sr.ReadLine()      'R1.00 ALPHA
      A = sr.ReadLine()

      A = sr.ReadLine()      'R1.00 BACK IMAGE 
      A = sr.ReadLine()
      If (System.IO.File.Exists(A)) Then
        NAME_bmp = New Bitmap(A)           'R3.00 Switched to memory based image management.
        PATH_BackgroundImage = A           'R3.00 Removed pnlPlr.BackgroundImage = Image.FromFile(A)
      Else
        'R3.30 Added notice if image is missing.
        If A = "" Then
          NAME_bmp = Nothing
          PATH_BackgroundImage = ""         'R4.46 Fixed bug where images did not get cleared on LOAD SETUP if no image was set.
        Else
          MsgBox("ERROR: The User Settings background image no longer exists." & vbCr & vbCr & "File:" & A)
        End If
      End If

      A = sr.ReadLine()      'R1.00 GAME PATH
      A = sr.ReadLine()
      PATH_Game = Trim(A)
      'R3.40 lbPath.Text = PATH_Game

      A = sr.ReadLine()      'R1.00 FONT
      A = sr.ReadLine() : FONT_Rank_Name = Trim(A)
      A = sr.ReadLine() : FONT_Rank_Size = Trim(A)
      A = sr.ReadLine() : FONT_Rank_Bold = Trim(A)
      A = sr.ReadLine() : FONT_Rank_Italic = Trim(A)

      tFont_Type = 0
      If FONT_Rank_Bold = "True" Then tFont_Type = 1
      If FONT_Rank_Italic = "True" Then tFont_Type = 2

      FONT_Rank = New Font(FONT_Rank_Name, CSng(FONT_Rank_Size), FontStyle.Regular)
      If FONT_Rank_Bold = "True" Then FONT_Rank = New Font(FONT_Rank_Name, CSng(FONT_Rank_Size), FontStyle.Bold)
      If FONT_Rank_Italic = "True" Then FONT_Rank = New Font(FONT_Rank_Name, CSng(FONT_Rank_Size), FontStyle.Italic)

      'R3.10 Version 2.0 and above.
      If 0 < Frev Then
        A = sr.ReadLine()     'R1.00 FORE COLOR - DEPRECATED
        A = sr.ReadLine()
        A = sr.ReadLine()
        A = sr.ReadLine()
        A = sr.ReadLine()
        'R3.30 C = Color.FromArgb(Ca, Cr, Cg, Cb)

        A = sr.ReadLine()     'R1.00 BACK COLOR - DEPRECATED
        A = sr.ReadLine()
        A = sr.ReadLine()
        A = sr.ReadLine()
        A = sr.ReadLine()
        'R3.30 C = Color.FromArgb(Ca, Cr, Cg, Cb)

        A = sr.ReadLine()     'R1.00 ALPHA - DEPRECATED
        A = sr.ReadLine()
        'R3.30 ALPHA_Name = Trim(A)

        A = sr.ReadLine()     'R1.00 FONT
        A = sr.ReadLine() : FONT_Name_Name = Trim(A)
        A = sr.ReadLine() : FONT_Name_Size = Trim(A)
        A = sr.ReadLine() : FONT_Name_Bold = Trim(A)
        A = sr.ReadLine() : FONT_Name_Italic = Trim(A)

        tFont_Type = 0
        If FONT_Name_Bold = "True" Then tFont_Type = 1
        If FONT_Name_Italic = "True" Then tFont_Type = 2

        FONT_Name = New Font(FONT_Name_Name, CSng(FONT_Name_Size), FontStyle.Regular)
        If FONT_Name_Bold = "True" Then FONT_Name = New Font(FONT_Name_Name, CSng(FONT_Name_Size), FontStyle.Bold)
        If FONT_Name_Italic = "True" Then FONT_Name = New Font(FONT_Name_Name, CSng(FONT_Name_Size), FontStyle.Italic)

        A = sr.ReadLine()  'R2.00 SCREEN SIZE
        A = sr.ReadLine()  'cboPageSize.Text = Trim(A)
        Call SETTINGS_GetStatSize(A)

        A = sr.ReadLine()  'R2.00 PAGE LAYOUT Y
        A = sr.ReadLine() : cboLayoutY.Text = Trim(A)

        A = sr.ReadLine()  'R2.00 PAGE LAYOUT X
        A = sr.ReadLine() : cboLayoutX.Text = Trim(A)

        A = sr.ReadLine()   'R2.00 PANEL BACK COLOR
        A = sr.ReadLine() : Ca = Val(A)
        A = sr.ReadLine() : Cr = Val(A)
        A = sr.ReadLine() : Cg = Val(A)
        A = sr.ReadLine() : Cb = Val(A)
        pbStats.BackColor = Color.FromArgb(Ca, Cr, Cg, Cb)
        LSName.BackC = pbStats.BackColor                          'R4.00 Added.

        A = sr.ReadLine()  'R2.00 IMAGE SCALING
        A = sr.ReadLine()  'cboScaling.Text = Trim(A)
        LSName.Scaling = Trim(A)                                  'R4.00 Added Scaling var.

        If Not sr.EndOfStream Then
          A = sr.ReadLine() 'R2.00 GUI COLOR SCHEME
          A = sr.ReadLine() : GUI_ColorMode = Val(Trim(A))
          If GUI_ColorMode <> 0 Then chkGUIMode.Checked = True    'R4.30 Added.
        Else
          GUI_ColorMode = 0
        End If

        'R3.00 Rev 3 and above.
        If 2 < Frev Then
          'R3.00 RANK LABEL VARS
          A = sr.ReadLine()      'R3.00 RANK FORE COLOR 1 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSRank.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 RANK FORE COLOR 2 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSRank.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 RANK FORE GRADIENT 
          A = sr.ReadLine()
          LSRank.FDir = A

          A = sr.ReadLine()      'R3.00 RANK BACK COLOR 1 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSRank.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 RANK BACK COLOR 2 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSRank.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 RANK BACK GRADIENT 
          A = sr.ReadLine()
          LSRank.BDir = A

          'R3.00 NAME LABEL VARS
          A = sr.ReadLine()       'R3.00 NAME FORE COLOR 1 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSName.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 NAME FORE COLOR 2 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSName.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 NAME FORE GRADIENT 
          A = sr.ReadLine()
          LSName.FDir = A

          A = sr.ReadLine()       'R3.00 NAME BACK COLOR 1 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSName.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 NAME BACK COLOR 2 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSName.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 NAME BACK GRADIENT 
          A = sr.ReadLine()
          LSName.BDir = A


          A = sr.ReadLine()      'R3.00 RANK SHADOW COLOR 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSRank.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 RANK SHADOW DIR
          A = sr.ReadLine()
          LSRank.ShadowDir = A

          A = sr.ReadLine()       'R3.00 RANK SHADOW DEPTH - Future
          A = sr.ReadLine()
          LSRank.ShadowDepth = A

          A = sr.ReadLine()       'R3.00 NAME SHADOW COLOR 
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          LSName.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 NAME SHADOW DIR
          A = sr.ReadLine()
          LSName.ShadowDir = A

          A = sr.ReadLine()       'R3.00 NAME SHADOW DEPTH - Future
          A = sr.ReadLine()
          LSName.ShadowDepth = A

          A = sr.ReadLine()       'R3.00 BACK GRADIENT COLOR 1 - Future
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          COLOR_Back1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 BACK GRADIENT COLOR 2 - Future
          A = sr.ReadLine() : Ca = Val(A)
          A = sr.ReadLine() : Cr = Val(A)
          A = sr.ReadLine() : Cg = Val(A)
          A = sr.ReadLine() : Cb = Val(A)
          COLOR_Back2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          A = sr.ReadLine()       'R3.00 NAME SHADOW DIR - Future
          A = sr.ReadLine()
          COLOR_Back_Dir = A

          'R3.00 Rev 4 and above.
          If 3 < Frev Then

            A = sr.ReadLine()       'R3.10 FX COLORS
            For t = 1 To 10
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              CFX3DC(t) = Color.FromArgb(Ca, Cr, Cg, Cb)
            Next

            A = sr.ReadLine()        'R3.10 FX VARS
            For N = 1 To 10
              For t = 1 To 10
                A = sr.ReadLine() : CFX3DVar(N, t) = Trim(A)
              Next
            Next

            A = sr.ReadLine()       'R3.10 FX ACTIVE
            For N = 1 To 10
              A = sr.ReadLine()
              If A = "True" Then
                CFX3DActive(N) = True
              Else
                CFX3DActive(N) = False
              End If
            Next

            '**********************************************************
            ' REV 5 and newer files
            '**********************************************************
            If 4 < Frev Then
              A = sr.ReadLine() 'NAME OVERLAY IMAGE
              A = sr.ReadLine() : PATH_Name_OVLBmp = A
              A = sr.ReadLine() : LSName.OVLScaling = Val(A)

              A = sr.ReadLine() 'NOTE 01 VARS
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote01.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote01.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote01.BackC = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote01.BDir = Val(A)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote01.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote01.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote01.FDir = Val(A)
              A = sr.ReadLine() : LSNote01.Height = Val(A)
              A = sr.ReadLine() : LSNote01.O1 = Val(A)
              A = sr.ReadLine() : LSNote01.O2 = Val(A)
              A = sr.ReadLine() : LSNote01.Scaling = Val(A)
              A = sr.ReadLine() : LSNote01.OVLScaling = Val(A)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote01.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote01.ShadowDepth = A
              A = sr.ReadLine() : LSNote01.ShadowDir = A
              A = sr.ReadLine() : LSNote01.Width = Val(A)
              A = sr.ReadLine() : PATH_Note01_Bmp = A
              A = sr.ReadLine() : PATH_Note01_BmpPath = A
              A = sr.ReadLine() : PATH_Note01_OVLBmp = A
              A = sr.ReadLine() : PATH_Note01_OVLBmpPath = A
              A = sr.ReadLine() : FONT_Note01_Name = A
              A = sr.ReadLine() : FONT_Note01_Bold = A
              A = sr.ReadLine() : FONT_Note01_Italic = A
              A = sr.ReadLine() : FONT_Note01_Size = A

              For t = 1 To 10
                A = sr.ReadLine() : NoteAnim01_Text(t) = A
              Next t

              A = sr.ReadLine() : NoteAnim01.Mode = Val(A)
              A = sr.ReadLine() : NoteAnim01.Speed = Val(A)
              A = sr.ReadLine() : NoteAnim01.TimeHold = Val(A)
              A = sr.ReadLine() : NoteAnim01.Align = A
              A = sr.ReadLine() : NoteAnim01.Delim = A
              A = sr.ReadLine() : NoteAnim01.Xoffset = Val(A)
              A = sr.ReadLine() : NoteAnim01.Yoffset = Val(A)

              A = sr.ReadLine()  'NOTE 02 VARS
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote02.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote02.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote02.BackC = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote02.BDir = Val(A)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote02.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote02.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote02.FDir = Val(A)
              A = sr.ReadLine() : LSNote02.Height = Val(A)
              A = sr.ReadLine() : LSNote02.O1 = Val(A)
              A = sr.ReadLine() : LSNote02.O2 = Val(A)
              A = sr.ReadLine() : LSNote02.Scaling = Val(A)
              A = sr.ReadLine() : LSNote02.OVLScaling = Val(A)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote02.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote02.ShadowDepth = A
              A = sr.ReadLine() : LSNote02.ShadowDir = A
              A = sr.ReadLine() : LSNote02.Width = Val(A)
              A = sr.ReadLine() : PATH_Note02_Bmp = A
              A = sr.ReadLine() : PATH_Note02_BmpPath = A
              A = sr.ReadLine() : PATH_Note02_OVLBmp = A
              A = sr.ReadLine() : PATH_Note02_OVLBmpPath = A
              A = sr.ReadLine() : FONT_Note02_Name = A
              A = sr.ReadLine() : FONT_Note02_Bold = A
              A = sr.ReadLine() : FONT_Note02_Italic = A
              A = sr.ReadLine() : FONT_Note02_Size = A

              For t = 1 To 10
                A = sr.ReadLine() : NoteAnim02_Text(t) = A
              Next t

              A = sr.ReadLine() : NoteAnim02.Mode = Val(A)
              A = sr.ReadLine() : NoteAnim02.Speed = Val(A)
              A = sr.ReadLine() : NoteAnim02.TimeHold = Val(A)
              A = sr.ReadLine() : NoteAnim02.Align = A
              A = sr.ReadLine() : NoteAnim02.Delim = A
              A = sr.ReadLine() : NoteAnim02.Xoffset = Val(A)
              A = sr.ReadLine() : NoteAnim02.Yoffset = Val(A)

              A = sr.ReadLine()   'NOTE 03 VARS
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote03.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote03.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote03.BackC = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote03.BDir = Val(A)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote03.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote03.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote03.FDir = Val(A)
              A = sr.ReadLine() : LSNote03.Height = Val(A)
              A = sr.ReadLine() : LSNote03.O1 = Val(A)
              A = sr.ReadLine() : LSNote03.O2 = Val(A)
              A = sr.ReadLine() : LSNote03.Scaling = Val(A)
              A = sr.ReadLine() : LSNote03.OVLScaling = Val(A)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote03.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote03.ShadowDepth = A
              A = sr.ReadLine() : LSNote03.ShadowDir = A
              A = sr.ReadLine() : LSNote03.Width = Val(A)
              A = sr.ReadLine() : PATH_Note03_Bmp = A
              A = sr.ReadLine() : PATH_Note03_BmpPath = A
              A = sr.ReadLine() : PATH_Note03_OVLBmp = A
              A = sr.ReadLine() : PATH_Note03_OVLBmpPath = A
              A = sr.ReadLine() : FONT_Note03_Name = A
              A = sr.ReadLine() : FONT_Note03_Bold = A
              A = sr.ReadLine() : FONT_Note03_Italic = A
              A = sr.ReadLine() : FONT_Note03_Size = A

              For t = 1 To 10
                A = sr.ReadLine() : NoteAnim03_Text(t) = A
              Next t

              A = sr.ReadLine() : NoteAnim03.Mode = Val(A)
              A = sr.ReadLine() : NoteAnim03.Speed = Val(A)
              A = sr.ReadLine() : NoteAnim03.TimeHold = Val(A)
              A = sr.ReadLine() : NoteAnim03.Align = A
              A = sr.ReadLine() : NoteAnim03.Delim = A
              A = sr.ReadLine() : NoteAnim03.Xoffset = Val(A)
              A = sr.ReadLine() : NoteAnim03.Yoffset = Val(A)

              A = sr.ReadLine()  'NOTE 04 VARS
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote04.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote04.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote04.BackC = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote04.BDir = Val(A)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote04.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote04.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote04.FDir = Val(A)
              A = sr.ReadLine() : LSNote04.Height = Val(A)
              A = sr.ReadLine() : LSNote04.O1 = Val(A)
              A = sr.ReadLine() : LSNote04.O2 = Val(A)
              A = sr.ReadLine() : LSNote04.Scaling = Val(A)
              A = sr.ReadLine() : LSNote04.OVLScaling = Val(A)
              A = sr.ReadLine() : Ca = Val(A)
              A = sr.ReadLine() : Cr = Val(A)
              A = sr.ReadLine() : Cg = Val(A)
              A = sr.ReadLine() : Cb = Val(A)
              LSNote04.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)
              A = sr.ReadLine() : LSNote04.ShadowDepth = A
              A = sr.ReadLine() : LSNote04.ShadowDir = A
              A = sr.ReadLine() : LSNote04.Width = Val(A)
              A = sr.ReadLine() : PATH_Note04_Bmp = A
              A = sr.ReadLine() : PATH_Note04_BmpPath = A
              A = sr.ReadLine() : PATH_Note04_OVLBmp = A
              A = sr.ReadLine() : PATH_Note04_OVLBmpPath = A
              A = sr.ReadLine() : FONT_Note04_Name = A
              A = sr.ReadLine() : FONT_Note04_Bold = A
              A = sr.ReadLine() : FONT_Note04_Italic = A
              A = sr.ReadLine() : FONT_Note04_Size = A

              For t = 1 To 10
                A = sr.ReadLine() : NoteAnim04_Text(t) = A
              Next t

              A = sr.ReadLine() : NoteAnim04.Mode = Val(A)
              A = sr.ReadLine() : NoteAnim04.Speed = Val(A)
              A = sr.ReadLine() : NoteAnim04.TimeHold = Val(A)
              A = sr.ReadLine() : NoteAnim04.Align = A
              A = sr.ReadLine() : NoteAnim04.Delim = A
              A = sr.ReadLine() : NoteAnim04.Xoffset = Val(A)
              A = sr.ReadLine() : NoteAnim04.Yoffset = Val(A)

              A = sr.ReadLine()  'NOTE SPACING
              A = sr.ReadLine() : NOTE_Spacing = Val(A)

              A = sr.ReadLine()  'SOUND SAMPLES
              For t = 1 To 30
                A = sr.ReadLine() : SOUND_File(t) = Trim(A)
                A = sr.ReadLine()                             'R4.00 Future Pitch.
                A = sr.ReadLine() : SOUND_Vol(t) = Val(A)     'R4.10 Added.
                If SOUND_Vol(t) < 10 Then SOUND_Vol(t) = 100  'R4.10 Old version 5 has no volume so it will be ZERO.  
              Next t
              A = sr.ReadLine() : scrVolume.Value = Val(A)

              A = sr.ReadLine()  'WINDOW STATE
              A = sr.ReadLine() : Celo_Windowstate = Trim(A)
              A = sr.ReadLine() : Celo_Left = Val(A)
              A = sr.ReadLine() : Celo_Top = Val(A)
              A = sr.ReadLine() : Celo_Width = Val(A)
              A = sr.ReadLine() : Celo_Height = Val(A)
              A = sr.ReadLine() : If A = "1" Then chkPosition.Checked = True
              A = sr.ReadLine() : If A = "1" Then chkPopUp.Checked = True : Celo_Popup = True

              A = sr.ReadLine() 'R4.10 XY OFFSET
              If A = "PAGE XY OFFSET" Then
                A = sr.ReadLine() : tbXoff.Text = Trim(A)
                A = sr.ReadLine() : tbYoff.Text = Trim(A)
              Else
                A = sr.ReadLine()
                A = sr.ReadLine()
              End If

              A = sr.ReadLine() 'R4.10 XY OFFSET
              If A = "PAGE XY SIZE" Then
                A = sr.ReadLine() : tbXsize.Text = Trim(A)
                A = sr.ReadLine() : tbYSize.Text = Trim(A)

                Call STATS_ClipXY(Val(tbXsize.Text), Val(tbYSize.Text))
              Else
                A = sr.ReadLine()
                A = sr.ReadLine()
              End If

              '**********************************************************
              ' REV 6 and newer files
              '**********************************************************
              If 5 < Frev Then
                A = sr.ReadLine() 'R4.30 HOW OFTEN TO READ THE LOG FILE.
                If A = "SCAN TIME" Then
                  A = sr.ReadLine()
                  Vlong = Val(A)
                  If (Vlong < 5) Then A = "5"
                  If (60 < Vlong) Then A = "60"

                  Select Case A
                    Case "5" : cboDelay.SelectedIndex = 0 : SCAN_Time = 5
                    Case "10" : cboDelay.SelectedIndex = 1 : SCAN_Time = 10
                    Case "20" : cboDelay.SelectedIndex = 2 : SCAN_Time = 20
                    Case "30" : cboDelay.SelectedIndex = 3 : SCAN_Time = 30
                    Case "45" : cboDelay.SelectedIndex = 4 : SCAN_Time = 45
                    Case "60" : cboDelay.SelectedIndex = 5 : SCAN_Time = 60
                    Case Else : cboDelay.SelectedIndex = 1 : SCAN_Time = 10
                  End Select

                Else
                  A = sr.ReadLine()
                End If

                A = sr.ReadLine() 'R4.30 PLAY A SOUND WHEN A MATCH IS FOUND.
                If A = "MATCH ALARM ON" Then
                  A = sr.ReadLine()
                  If A = "1" Then
                    chkFoundSound.Checked = True
                  Else
                    chkFoundSound.Checked = False
                  End If
                Else
                  A = sr.ReadLine()
                End If

                A = sr.ReadLine() 'R4.30 DONT DRAW BOXES FOR EMPTY PLAYER SLOTS.
                If A = "HIDE MISSING" Then
                  A = sr.ReadLine()
                  If A = "1" Then
                    chkHideMissing.Checked = True
                  Else
                    chkHideMissing.Checked = False
                  End If
                Else
                  A = sr.ReadLine()
                End If

                A = sr.ReadLine() 'R4.30 MAX PLAYERS FOR EACH GAME MODE.
                If A = "LEVEL STORAGE" Then
                  For t = 1 To 7
                    For tt = 1 To 4
                      A = sr.ReadLine()
                      LVLS(t, tt) = A
                    Next tt
                  Next t
                End If

                A = sr.ReadLine() 'R4.30 SHOW RANKS, ELO %, and LEVEL. 
                If A = "CYCLE ELO" Then
                  A = sr.ReadLine()
                  If A = "1" Then
                    chkShowELO.Checked = True
                    FLAG_EloUse = True
                    timELOCycle.Enabled = True      'R4.30 Turn on the timer to rotate stats.
                  Else
                    chkShowELO.Checked = False
                    FLAG_EloUse = False
                  End If
                Else
                  A = sr.ReadLine()
                End If
              End If

              A = sr.ReadLine() 'R4.34 Use Web Calls and JSON data searches. 
              If A = "USE WEB SEARCH" Then
                A = sr.ReadLine()
                If A = "1" Then
                  chkSpeech.Checked = True
                Else
                  chkSpeech.Checked = False
                End If
              End If

              A = sr.ReadLine() 'R4.34 Read Ranks Aloud. 
              If A = "SPEECH RANKS" Then
                A = sr.ReadLine()
                If A = "1" Then
                  chkSpeech.Checked = True
                Else
                  chkSpeech.Checked = False
                End If
              End If

              A = sr.ReadLine() 'R4.34 Read Ranks Aloud. 
              If A = "FIND TEAMS" Then
                A = sr.ReadLine()
                If A = "1" Then
                  chkGetTeams.Checked = True
                Else
                  chkGetTeams.Checked = False
                End If
              End If

              A = sr.ReadLine() 'R4.40 Draw plain player card. 
              If A = "PLAYER CARD BACK" Then
                A = sr.ReadLine()
                If A = "1" Then
                  LSRank.UseCardBack = True
                  LSName.UseCardBack = True
                Else
                  LSRank.UseCardBack = False
                  LSName.UseCardBack = False
                End If
              End If

              'R4.40 Get the RANK border options.
              A = sr.ReadLine()
              If A = "RANK BORDER" Then
                A = sr.ReadLine() : LSRank.BorderMode = Val(A)
                A = sr.ReadLine() : Ca = Val(A)
                A = sr.ReadLine() : Cr = Val(A)
                A = sr.ReadLine() : Cg = Val(A)
                A = sr.ReadLine() : Cb = Val(A)
                LSRank.BorderColor = Color.FromArgb(Ca, Cr, Cg, Cb)
                A = sr.ReadLine() : LSRank.BorderWidth = Val(A)

                'R4.40 Future Use.
                A = sr.ReadLine()
                A = sr.ReadLine()
                A = sr.ReadLine()
                A = sr.ReadLine()
                A = sr.ReadLine()

              End If

              'R4.40 Get the NAME border options.
              A = sr.ReadLine()
              If A = "NAME BORDER" Then
                A = sr.ReadLine() : LSName.BorderMode = Val(A)
                A = sr.ReadLine() : Ca = Val(A)
                A = sr.ReadLine() : Cr = Val(A)
                A = sr.ReadLine() : Cg = Val(A)
                A = sr.ReadLine() : Cb = Val(A)
                LSName.BorderColor = Color.FromArgb(Ca, Cr, Cg, Cb)
                A = sr.ReadLine() : LSName.BorderWidth = Val(A)

                'R4.40 Future Use.
                A = sr.ReadLine()
                A = sr.ReadLine()
                A = sr.ReadLine()
                A = sr.ReadLine()
                A = sr.ReadLine()

              End If

              'R4.40 Get the PANEL border options.
              A = sr.ReadLine()
              If A = "PANEL BORDER" Then
                A = sr.ReadLine() : LSName.BorderPanelMode = Val(A)
                A = sr.ReadLine() : Ca = Val(A)
                A = sr.ReadLine() : Cr = Val(A)
                A = sr.ReadLine() : Cg = Val(A)
                A = sr.ReadLine() : Cb = Val(A)
                LSName.BorderPanelColor = Color.FromArgb(Ca, Cr, Cg, Cb)
                A = sr.ReadLine() : LSName.BorderPanelWidth = Val(A)

                'R4.40 These must be the same for both RANK and NAME.
                LSRank.BorderPanelWidth = LSName.BorderPanelWidth
                LSRank.BorderPanelColor = LSName.BorderPanelColor
                LSRank.BorderPanelMode = LSName.BorderPanelMode

                'R4.40 Future Use.
                A = sr.ReadLine()
                A = sr.ReadLine()
                A = sr.ReadLine()
                A = sr.ReadLine()
                A = sr.ReadLine()

              End If

              A = sr.ReadLine() 'R4.45 Draw flags. 
              If A = "SHOW COUNTRY" Then
                A = sr.ReadLine()
                If A = "1" Then
                  chkCountry.Checked = True
                Else
                  chkCountry.Checked = False
                End If
              End If


            End If  '<-- REV 5 END

          End If   '<-- REV 4 END

        End If   '<-- REV 3 END

      End If    '<-- REV 2 END

    Catch ex As Exception
      MsgBox("ERROR: " & ex.Message & vbCr & vbCr & "Unable to read the saved settings." & vbCr & "The last known setup could not be loaded." & vbCr & vbCr & "If running a new version, this error may fix itself when a new setup is saved.", MsgBoxStyle.Critical, "MakoCelo - Setup Error")

    Finally
      'R4.00 Close / Clean up  streams?
      If IsNothing(sr) = False Then
        sr.Close()
        sr.Dispose()
      End If
      If IsNothing(fs) = False Then
        fs.Close()
        fs.Dispose()
      End If

    End Try

    Call FX_SetVarControls()

    Call SETTINGS_SetupAfterLoad()

  End Sub

  Private Sub SETTINGS_GetStatSize(OldSizeMethod As String)
    Dim X, Y As Integer

    'R4.10 Changed from premade sizes to adjustable sizes.
    X = 980
    Y = 180
    Select Case OldSizeMethod
      Case "0 - 580 x 140" : X = 580 : Y = 140
      Case "1 - 640 x 160" : X = 640 : Y = 160
      Case "2 - 720 x 180" : X = 720 : Y = 180
      Case "3 - 800 x 200" : X = 800 : Y = 200
      Case "4 - 960 x 240" : X = 960 : Y = 240
      Case "5 - 1280 x 320" : X = 1280 : Y = 320
      Case "6 - 580 x 120" : X = 580 : Y = 120
      Case "7 - 640 x 128" : X = 640 : Y = 128
      Case "8 - 720 x 144" : X = 720 : Y = 144
      Case "9 - 800 x 160" : X = 800 : Y = 160
      Case "10 - 900 x 180" : X = 900 : Y = 180
      Case "11 - 980 x 180" : X = 980 : Y = 180
      Case "12 - 1280 x 256" : X = 1280 : Y = 256
      Case "13 - 580 x 68" : X = 580 : Y = 68
      Case "14 - 640 x 80" : X = 640 : Y = 80
      Case "15 - 720 x 92" : X = 720 : Y = 92
      Case "16 - 800 x 100" : X = 800 : Y = 100
      Case "17 - 900 x 120" : X = 900 : Y = 120
      Case "18 - 980 x 120" : X = 980 : Y = 120
      Case "19 - 1280 x 160" : X = 1280 : Y = 160
    End Select

    tbXsize.Text = X
    tbYSize.Text = Y

    STATS_SizeX = X
    STATS_SizeY = Y

  End Sub

  Private Sub SETTINGS_Load_Old(tFILE As String)
    Dim C As Color
    Dim tPath As String
    Dim A As String = ""
    Dim Ca, Cr, Cg, Cb As Integer
    Dim tFont_Type As Integer
    Dim Frev As Integer = 0

    'R4.20 Added Load/Save setups options.
    If tFILE = "" Then
      tPath = Application.StartupPath() & "\MakoCelo_settings.dat"
    Else
      tPath = tFILE
    End If

    If Not (System.IO.File.Exists(tPath)) Then Exit Sub

    'R4.00 Open the SETTINGS file.
    FileOpen(1, tPath, OpenMode.Input)

    Try

      Input(1, A)
      Select Case A
        Case "VERSION MC200"
          Frev = 2
          Input(1, A)            'R2.00 Read extra header line.
        Case "VERSION MC300"
          Frev = 3
          Input(1, A)            'R2.00 Read extra header line.
        Case "VERSION MC400"
          Frev = 4
          Input(1, A)            'R2.00 Read extra header line.
        Case "VERSION MC500"
          Frev = 5
          Input(1, A)            'R2.00 Read extra header line.
        Case Else
          MsgBox("WARNING: The startup data file appears to be corrupt or incorrect." & vbCr & vbCr & "Path: " & Application.StartupPath() & "\MakoCelo_settings.dat", vbCritical, "MakoCELO")
      End Select


      Input(1, A) : Ca = Val(A)
      Input(1, A) : Cr = Val(A)
      Input(1, A) : Cg = Val(A)
      Input(1, A) : Cb = Val(A)
      C = Color.FromArgb(Ca, Cr, Cg, Cb)

      Input(1, A)   'R1.00 BACK COLOR
      Input(1, A) : Ca = Val(A)
      Input(1, A) : Cr = Val(A)
      Input(1, A) : Cg = Val(A)
      Input(1, A) : Cb = Val(A)
      C = Color.FromArgb(Ca, Cr, Cg, Cb)

      Input(1, A)      'R1.00 ALPHA
      Input(1, A)

      Input(1, A)      'R1.00 BACK IMAGE 
      Input(1, A)
      If (System.IO.File.Exists(A)) Then
        NAME_bmp = New Bitmap(A)           'R4.00 Switched to memory based image management.
        PATH_BackgroundImage = A           'R3.00 Removed pnlPlr.BackgroundImage = Image.FromFile(A)
      Else
        'R3.30 Added notice if image is missing.
        If A <> "" Then MsgBox("ERROR: The User Settings background image no longer exists." & vbCr & vbCr & "File:" & A)
      End If

      Input(1, A)      'R1.00 GAME PATH
      Input(1, A)
      PATH_Game = Trim(A)

      Input(1, A)      'R1.00 FONT
      Input(1, A) : FONT_Rank_Name = Trim(A)
      Input(1, A) : FONT_Rank_Size = Trim(A)
      Input(1, A) : FONT_Rank_Bold = Trim(A)
      Input(1, A) : FONT_Rank_Italic = Trim(A)

      tFont_Type = 0
      If FONT_Rank_Bold = "True" Then tFont_Type = 1
      If FONT_Rank_Italic = "True" Then tFont_Type = 2

      FONT_Rank = New Font(FONT_Rank_Name, CSng(FONT_Rank_Size), FontStyle.Regular)
      If FONT_Rank_Bold = "True" Then FONT_Rank = New Font(FONT_Rank_Name, CSng(FONT_Rank_Size), FontStyle.Bold)
      If FONT_Rank_Italic = "True" Then FONT_Rank = New Font(FONT_Rank_Name, CSng(FONT_Rank_Size), FontStyle.Italic)

      'R3.10 Version 2.0 and above.
      If 0 < Frev Then
        Input(1, A)     'R1.00 FORE COLOR - DEPRECATED
        Input(1, A)
        Input(1, A)
        Input(1, A)
        Input(1, A)

        Input(1, A)     'R1.00 BACK COLOR - DEPRECATED
        Input(1, A)
        Input(1, A)
        Input(1, A)
        Input(1, A)

        Input(1, A)     'R1.00 ALPHA - DEPRECATED
        Input(1, A)

        Input(1, A)     'R1.00 FONT
        Input(1, A) : FONT_Name_Name = Trim(A)
        Input(1, A) : FONT_Name_Size = Trim(A)
        Input(1, A) : FONT_Name_Bold = Trim(A)
        Input(1, A) : FONT_Name_Italic = Trim(A)

        tFont_Type = 0
        If FONT_Name_Bold = "True" Then tFont_Type = 1
        If FONT_Name_Italic = "True" Then tFont_Type = 2

        FONT_Name = New Font(FONT_Name_Name, CSng(FONT_Name_Size), FontStyle.Regular)
        If FONT_Name_Bold = "True" Then FONT_Name = New Font(FONT_Name_Name, CSng(FONT_Name_Size), FontStyle.Bold)
        If FONT_Name_Italic = "True" Then FONT_Name = New Font(FONT_Name_Name, CSng(FONT_Name_Size), FontStyle.Italic)

        Input(1, A)  'R2.00 SCREEN SIZE
        Input(1, A)  'cboPageSize.Text = Trim(A)
        Call SETTINGS_GetStatSize(A)                'R4.10 Changed size.

        Input(1, A)  'R2.00 PAGE LAYOUT Y
        Input(1, A) : cboLayoutY.Text = Trim(A)

        Input(1, A)  'R2.00 PAGE LAYOUT X
        Input(1, A) : cboLayoutX.Text = Trim(A)

        Input(1, A)   'R2.00 PANEL BACK COLOR
        Input(1, A) : Ca = Val(A)
        Input(1, A) : Cr = Val(A)
        Input(1, A) : Cg = Val(A)
        Input(1, A) : Cb = Val(A)
        pbStats.BackColor = Color.FromArgb(Ca, Cr, Cg, Cb)
        LSName.BackC = pbStats.BackColor                          'R4.00 Added.

        Input(1, A)  'R2.00 IMAGE SCALING
        Input(1, A)
        LSName.Scaling = Trim(A)                                  'R4.00 Added Scaling var.

        If Not EOF(1) Then
          Input(1, A) 'R2.00 GUI COLOR SCHEME
          Input(1, A) : GUI_ColorMode = Val(Trim(A))
        Else
          GUI_ColorMode = 0
        End If

        '**********************************************************
        ' REV 3 and newer files
        '**********************************************************
        If 2 < Frev Then
          'R3.00 RANK LABEL VARS
          Input(1, A)      'R3.00 RANK FORE COLOR 1 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSRank.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 RANK FORE COLOR 2 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSRank.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 RANK FORE GRADIENT 
          Input(1, A)
          LSRank.FDir = A

          Input(1, A)      'R3.00 RANK BACK COLOR 1 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSRank.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 RANK BACK COLOR 2 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSRank.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 RANK BACK GRADIENT 
          Input(1, A)
          LSRank.BDir = A

          'R3.00 NAME LABEL VARS
          Input(1, A)       'R3.00 NAME FORE COLOR 1 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSName.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 NAME FORE COLOR 2 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSName.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 NAME FORE GRADIENT 
          Input(1, A)
          LSName.FDir = A

          Input(1, A)       'R3.00 NAME BACK COLOR 1 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSName.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 NAME BACK COLOR 2 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSName.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 NAME BACK GRADIENT 
          Input(1, A)
          LSName.BDir = A


          Input(1, A)      'R3.00 RANK SHADOW COLOR 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSRank.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 RANK SHADOW DIR
          Input(1, A)
          LSRank.ShadowDir = A

          Input(1, A)       'R3.00 RANK SHADOW DEPTH - Future
          Input(1, A)
          LSRank.ShadowDepth = A

          Input(1, A)       'R3.00 NAME SHADOW COLOR 
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          LSName.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 NAME SHADOW DIR
          Input(1, A)
          'CName3D = A
          'cboName3D.Text = A
          LSName.ShadowDir = A

          Input(1, A)       'R3.00 NAME SHADOW DEPTH - Future
          Input(1, A)
          'CName3Depth = A
          LSName.ShadowDepth = A

          Input(1, A)       'R3.00 BACK GRADIENT COLOR 1 - Future
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          COLOR_Back1 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 BACK GRADIENT COLOR 2 - Future
          Input(1, A) : Ca = Val(A)
          Input(1, A) : Cr = Val(A)
          Input(1, A) : Cg = Val(A)
          Input(1, A) : Cb = Val(A)
          COLOR_Back2 = Color.FromArgb(Ca, Cr, Cg, Cb)

          Input(1, A)       'R3.00 NAME SHADOW DIR - Future
          Input(1, A)
          COLOR_Back_Dir = A

          '**********************************************************
          ' REV 4 and newer files
          '**********************************************************
          If 3 < Frev Then

            Input(1, A)       'R3.10 FX COLORS
            For t = 1 To 10
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              CFX3DC(t) = Color.FromArgb(Ca, Cr, Cg, Cb)
            Next

            Input(1, A)        'R3.10 FX VARS
            For N = 1 To 10
              For t = 1 To 10
                Input(1, A) : CFX3DVar(N, t) = Trim(A)
              Next
            Next

            Input(1, A)       'R3.10 FX ACTIVE
            For N = 1 To 10
              Input(1, A)
              If A = "True" Then
                CFX3DActive(N) = True
              Else
                CFX3DActive(N) = False
              End If
            Next

            '***********************************
            'R3.00 Rev 5 and above.
            '***********************************
            If 4 < Frev Then
              Input(1, A) 'NAME OVERLAY IMAGE
              Input(1, A) : PATH_Name_OVLBmp = A
              Input(1, A) : LSName.OVLScaling = Val(A)

              Input(1, A) 'NOTE 01 VARS
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote01.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote01.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote01.BackC = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote01.BDir = Val(A)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote01.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote01.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote01.FDir = Val(A)
              Input(1, A) : LSNote01.Height = Val(A)
              Input(1, A) : LSNote01.O1 = Val(A)
              Input(1, A) : LSNote01.O2 = Val(A)
              Input(1, A) : LSNote01.Scaling = Val(A)
              Input(1, A) : LSNote01.OVLScaling = Val(A)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote01.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote01.ShadowDepth = A
              Input(1, A) : LSNote01.ShadowDir = A
              Input(1, A) : LSNote01.Width = Val(A)
              Input(1, A) : PATH_Note01_Bmp = A
              Input(1, A) : PATH_Note01_BmpPath = A
              Input(1, A) : PATH_Note01_OVLBmp = A
              Input(1, A) : PATH_Note01_OVLBmpPath = A
              Input(1, A) : FONT_Note01_Name = A
              Input(1, A) : FONT_Note01_Bold = A
              Input(1, A) : FONT_Note01_Italic = A
              Input(1, A) : FONT_Note01_Size = A

              For t = 1 To 10
                Input(1, A) : NoteAnim01_Text(t) = A
              Next t

              Input(1, A) : NoteAnim01.Mode = Val(A)
              Input(1, A) : NoteAnim01.Speed = Val(A)
              Input(1, A) : NoteAnim01.TimeHold = Val(A)
              Input(1, A) : NoteAnim01.Align = A
              Input(1, A) : NoteAnim01.Delim = A
              Input(1, A) : NoteAnim01.Xoffset = Val(A)
              Input(1, A) : NoteAnim01.Yoffset = Val(A)

              Input(1, A)  'NOTE 02 VARS
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote02.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote02.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote02.BackC = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote02.BDir = Val(A)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote02.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote02.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote02.FDir = Val(A)
              Input(1, A) : LSNote02.Height = Val(A)
              Input(1, A) : LSNote02.O1 = Val(A)
              Input(1, A) : LSNote02.O2 = Val(A)
              Input(1, A) : LSNote02.Scaling = Val(A)
              Input(1, A) : LSNote02.OVLScaling = Val(A)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote02.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote02.ShadowDepth = A
              Input(1, A) : LSNote02.ShadowDir = A
              Input(1, A) : LSNote02.Width = Val(A)
              Input(1, A) : PATH_Note02_Bmp = A
              Input(1, A) : PATH_Note02_BmpPath = A
              Input(1, A) : PATH_Note02_OVLBmp = A
              Input(1, A) : PATH_Note02_OVLBmpPath = A
              Input(1, A) : FONT_Note02_Name = A
              Input(1, A) : FONT_Note02_Bold = A
              Input(1, A) : FONT_Note02_Italic = A
              Input(1, A) : FONT_Note02_Size = A

              For t = 1 To 10
                Input(1, A) : NoteAnim02_Text(t) = A
              Next t

              Input(1, A) : NoteAnim02.Mode = Val(A)
              Input(1, A) : NoteAnim02.Speed = Val(A)
              Input(1, A) : NoteAnim02.TimeHold = Val(A)
              Input(1, A) : NoteAnim02.Align = A
              Input(1, A) : NoteAnim02.Delim = A
              Input(1, A) : NoteAnim02.Xoffset = Val(A)
              Input(1, A) : NoteAnim02.Yoffset = Val(A)


              Input(1, A)   'NOTE 03 VARS
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote03.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote03.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote03.BackC = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote03.BDir = Val(A)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote03.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote03.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote03.FDir = Val(A)
              Input(1, A) : LSNote03.Height = Val(A)
              Input(1, A) : LSNote03.O1 = Val(A)
              Input(1, A) : LSNote03.O2 = Val(A)
              Input(1, A) : LSNote03.Scaling = Val(A)
              Input(1, A) : LSNote03.OVLScaling = Val(A)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote03.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote03.ShadowDepth = A
              Input(1, A) : LSNote03.ShadowDir = A
              Input(1, A) : LSNote03.Width = Val(A)
              Input(1, A) : PATH_Note03_Bmp = A
              Input(1, A) : PATH_Note03_BmpPath = A
              Input(1, A) : PATH_Note03_OVLBmp = A
              Input(1, A) : PATH_Note03_OVLBmpPath = A
              Input(1, A) : FONT_Note03_Name = A
              Input(1, A) : FONT_Note03_Bold = A
              Input(1, A) : FONT_Note03_Italic = A
              Input(1, A) : FONT_Note03_Size = A

              For t = 1 To 10
                Input(1, A) : NoteAnim03_Text(t) = A
              Next t

              Input(1, A) : NoteAnim03.Mode = Val(A)
              Input(1, A) : NoteAnim03.Speed = Val(A)
              Input(1, A) : NoteAnim03.TimeHold = Val(A)
              Input(1, A) : NoteAnim03.Align = A
              Input(1, A) : NoteAnim03.Delim = A
              Input(1, A) : NoteAnim03.Xoffset = Val(A)
              Input(1, A) : NoteAnim03.Yoffset = Val(A)

              Input(1, A)  'NOTE 04 VARS
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote04.B1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote04.B2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote04.BackC = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote04.BDir = Val(A)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote04.F1 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote04.F2 = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote04.FDir = Val(A)
              Input(1, A) : LSNote04.Height = Val(A)
              Input(1, A) : LSNote04.O1 = Val(A)
              Input(1, A) : LSNote04.O2 = Val(A)
              Input(1, A) : LSNote04.Scaling = Val(A)
              Input(1, A) : LSNote04.OVLScaling = Val(A)
              Input(1, A) : Ca = Val(A)
              Input(1, A) : Cr = Val(A)
              Input(1, A) : Cg = Val(A)
              Input(1, A) : Cb = Val(A)
              LSNote04.ShadowColor = Color.FromArgb(Ca, Cr, Cg, Cb)
              Input(1, A) : LSNote04.ShadowDepth = A
              Input(1, A) : LSNote04.ShadowDir = A
              Input(1, A) : LSNote04.Width = Val(A)
              Input(1, A) : PATH_Note04_Bmp = A
              Input(1, A) : PATH_Note04_BmpPath = A
              Input(1, A) : PATH_Note04_OVLBmp = A
              Input(1, A) : PATH_Note04_OVLBmpPath = A
              Input(1, A) : FONT_Note04_Name = A
              Input(1, A) : FONT_Note04_Bold = A
              Input(1, A) : FONT_Note04_Italic = A
              Input(1, A) : FONT_Note04_Size = A

              For t = 1 To 10
                Input(1, A) : NoteAnim04_Text(t) = A
              Next t

              Input(1, A) : NoteAnim04.Mode = Val(A)
              Input(1, A) : NoteAnim04.Speed = Val(A)
              Input(1, A) : NoteAnim04.TimeHold = Val(A)
              Input(1, A) : NoteAnim04.Align = A
              Input(1, A) : NoteAnim04.Delim = A
              Input(1, A) : NoteAnim04.Xoffset = Val(A)
              Input(1, A) : NoteAnim04.Yoffset = Val(A)

              Input(1, A)  'NOTE SPACING
              Input(1, A) : NOTE_Spacing = Val(A)

              Input(1, A)  'SOUND SAMPLES
              For t = 1 To 30
                Input(1, A) : SOUND_File(t) = Trim(A)
                Input(1, A)                  'R4.00 Future Pitch.
                Input(1, A)                  'R4.00 Future Vol.
              Next t
              Input(1, A) : scrVolume.Value = Val(A)

              Input(1, A)  'WINDOW STATE
              Input(1, A) : Celo_Windowstate = Trim(A)
              Input(1, A) : Celo_Left = Val(A)
              Input(1, A) : Celo_Top = Val(A)
              Input(1, A) : Celo_Width = Val(A)
              Input(1, A) : Celo_Height = Val(A)
              Input(1, A) : If A = "1" Then chkPosition.Checked = True

            End If  '<-- REV 5 END

          End If   '<-- REV 4 END

        End If   '<-- REV 3 END

      End If    '<-- REV 2 END

    Catch ex As Exception
      MsgBox("ERROR: " & ex.Message & vbCr & vbCr & "Unable to read the saved settings." & vbCr & "The last known setup could not be loaded." & vbCr & vbCr & "If running a new version, this error may fix itself when a new setup is saved.", MsgBoxStyle.Critical, "MakoCelo - Setup Error")
    End Try

    Call FX_SetVarControls()

    Call SETTINGS_SetupAfterLoad()

    FileClose(1)

  End Sub



  Private Sub SETTINGS_SetupAfterLoad()

    '*****************************************************
    'R4.40 Setup the NOTE FONTS. This was BUGGED badly. Fixed.
    FONT_Note01 = New Font(FONT_Note01_Name, CSng(FONT_Note01_Size), FontStyle.Regular)
    If FONT_Note01_Bold = "True" Then FONT_Note01 = New Font(FONT_Note01_Name, CSng(FONT_Name_Size), FontStyle.Bold)
    If FONT_Note01_Italic = "True" Then FONT_Note01 = New Font(FONT_Note01_Name, CSng(FONT_Name_Size), FontStyle.Italic)

    FONT_Note02 = New Font(FONT_Note02_Name, CSng(FONT_Note02_Size), FontStyle.Regular)
    If FONT_Note02_Bold = "True" Then FONT_Note02 = New Font(FONT_Note02_Name, CSng(FONT_Name_Size), FontStyle.Bold)
    If FONT_Note02_Italic = "True" Then FONT_Note02 = New Font(FONT_Note02_Name, CSng(FONT_Name_Size), FontStyle.Italic)

    FONT_Note03 = New Font(FONT_Note03_Name, CSng(FONT_Note03_Size), FontStyle.Regular)
    If FONT_Note03_Bold = "True" Then FONT_Note03 = New Font(FONT_Note03_Name, CSng(FONT_Name_Size), FontStyle.Bold)
    If FONT_Note03_Italic = "True" Then FONT_Note03 = New Font(FONT_Note03_Name, CSng(FONT_Name_Size), FontStyle.Italic)

    FONT_Note04 = New Font(FONT_Note04_Name, CSng(FONT_Note04_Size), FontStyle.Regular)
    If FONT_Note04_Bold = "True" Then FONT_Note04 = New Font(FONT_Note04_Name, CSng(FONT_Name_Size), FontStyle.Bold)
    If FONT_Note04_Italic = "True" Then FONT_Note04 = New Font(FONT_Note04_Name, CSng(FONT_Name_Size), FontStyle.Italic)
    '*****************************************************

    '*****************************************************
    'R4.00 Setup Bitmaps
    If (System.IO.File.Exists(PATH_Name_OVLBmp)) Then
      NAME_OVLBmp = New Bitmap(PATH_Name_OVLBmp)
    Else
      If PATH_Name_OVLBmp <> "" Then MsgBox("ERROR: The User Settings NAME OVERLAY image no longer exists." & vbCr & vbCr & "File:" & PATH_Name_OVLBmp)
    End If

    If 0 < LSNote01.Width Then pbNote1.Width = LSNote01.Width
    If 0 < LSNote01.Height Then pbNote1.Height = LSNote01.Height
    If (System.IO.File.Exists(PATH_Note01_Bmp)) Then
      Note01_BackBmp = New Bitmap(PATH_Note01_Bmp)
    Else
      If PATH_Note01_Bmp <> "" Then MsgBox("ERROR: The User Settings NOTE 1 OVERLAY image no longer exists." & vbCr & vbCr & "File:" & PATH_Note01_Bmp)
    End If
    If (System.IO.File.Exists(PATH_Note01_OVLBmp)) Then
      Note01_OVLBmp = New Bitmap(PATH_Note01_OVLBmp)
    Else
      If PATH_Note01_OVLBmp <> "" Then MsgBox("ERROR: The User Settings NOTE 1 OVERLAY image no longer exists." & vbCr & vbCr & "File:" & PATH_Note01_OVLBmp)
    End If

    If 0 < LSNote02.Width Then pbNote2.Width = LSNote02.Width
    If 0 < LSNote02.Height Then pbNote2.Height = LSNote02.Height
    If (System.IO.File.Exists(PATH_Note02_Bmp)) Then
      Note02_BackBmp = New Bitmap(PATH_Note02_Bmp)
    Else
      If PATH_Note01_Bmp <> "" Then MsgBox("ERROR: The User Settings NOTE 2 background image no longer exists." & vbCr & vbCr & "File:" & PATH_Note02_Bmp)
    End If
    If (System.IO.File.Exists(PATH_Note02_OVLBmp)) Then
      Note02_OVLBmp = New Bitmap(PATH_Note02_OVLBmp)
    Else
      If PATH_Note01_OVLBmp <> "" Then MsgBox("ERROR: The User Settings NOTE 2 OVERLAY image no longer exists." & vbCr & vbCr & "File:" & PATH_Note02_OVLBmp)
    End If

    If 0 < LSNote03.Width Then pbNote3.Width = LSNote03.Width
    If 0 < LSNote03.Height Then pbNote3.Height = LSNote03.Height
    If (System.IO.File.Exists(PATH_Note03_Bmp)) Then
      Note03_BackBmp = New Bitmap(PATH_Note03_Bmp)
    Else
      If PATH_Note03_Bmp <> "" Then MsgBox("ERROR: The User Settings NOTE 3 background image no longer exists." & vbCr & vbCr & "File:" & PATH_Note03_Bmp)
    End If
    If (System.IO.File.Exists(PATH_Note03_OVLBmp)) Then
      Note03_OVLBmp = New Bitmap(PATH_Note03_OVLBmp)
    Else
      If PATH_Note03_OVLBmp <> "" Then MsgBox("ERROR: The User Settings NOTE 3 OVERLAY image no longer exists." & vbCr & vbCr & "File:" & PATH_Note03_OVLBmp)
    End If

    If 0 < LSNote04.Width Then pbNote4.Width = LSNote04.Width
    If 0 < LSNote04.Height Then pbNote4.Height = LSNote04.Height
    If (System.IO.File.Exists(PATH_Note04_Bmp)) Then
      Note04_BackBmp = New Bitmap(PATH_Note04_Bmp)
    Else
      If PATH_Note04_Bmp <> "" Then MsgBox("ERROR: The User Settings NOTE 4 background image no longer exists." & vbCr & vbCr & "File:" & PATH_Note04_Bmp)
    End If
    If (System.IO.File.Exists(PATH_Note04_OVLBmp)) Then
      Note04_OVLBmp = New Bitmap(PATH_Note04_OVLBmp)
    Else
      If PATH_Note04_OVLBmp <> "" Then MsgBox("ERROR: The User Settings NOTE 4 OVERLAY image no longer exists." & vbCr & vbCr & "File:" & PATH_Note04_OVLBmp)
    End If
    '*****************************************************

    '*****************************************************
    'R4.00 Get a texture path from defined textures.
    If PATH_BackgroundImage <> "" Then
      PATH_DlgBmp = PATH_StripFilename(PATH_BackgroundImage)
    Else
      If PATH_Note01_Bmp <> "" Then PATH_DlgBmp = PATH_StripFilename(PATH_Note01_Bmp)
      If PATH_Note02_Bmp <> "" Then PATH_DlgBmp = PATH_StripFilename(PATH_Note02_Bmp)
      If PATH_Note03_Bmp <> "" Then PATH_DlgBmp = PATH_StripFilename(PATH_Note03_Bmp)
      If PATH_Note04_Bmp <> "" Then PATH_DlgBmp = PATH_StripFilename(PATH_Note04_Bmp)
    End If
    '*****************************************************

    '*****************************************************
    'R4.00 Get a SOUND file path from defined sounds.
    If PATH_SoundFiles = "" Then
      For t = 1 To 15
        If SOUND_File(t) <> "" Then PATH_SoundFiles = PATH_StripFilename(SOUND_File(t))
      Next
    End If
    '*****************************************************

    '*****************************************************
    'R4.00 Initialize the SHADOW XY coordinates.
    Call LS_SetShadowXY(LSRank)
    Call LS_SetShadowXY(LSName)
    Call LS_SetShadowXY(LSNote01)
    Call LS_SetShadowXY(LSNote02)
    Call LS_SetShadowXY(LSNote03)
    Call LS_SetShadowXY(LSNote04)
    '*****************************************************

    cboNoteSpace.SelectedIndex = NOTE_Spacing


  End Sub

  Private Sub LS_SetShadowXY(ByRef LS As clsGlobal.t_LabelSetup)

    '*****************************************************
    'R4.00 Get a SOUND file path from defined sounds.
    Select Case LS.ShadowDir
      Case "45°" : LS.ShadowX = 1 : LS.ShadowY = -1
      Case "90°" : LS.ShadowX = 0 : LS.ShadowY = -1
      Case "135°" : LS.ShadowX = -1 : LS.ShadowY = -1
      Case "180°" : LS.ShadowX = -1 : LS.ShadowY = 0
      Case "225°" : LS.ShadowX = -1 : LS.ShadowY = 1
      Case "270°" : LS.ShadowX = 0 : LS.ShadowY = 1
      Case "315°" : LS.ShadowX = 1 : LS.ShadowY = 1
      Case "360°" : LS.ShadowX = 1 : LS.ShadowY = 0
      Case Else : LS.ShadowX = 0 : LS.ShadowY = 0
    End Select

  End Sub


  Private Sub SETTINGS_Save(tFile As String)
    Dim A As String
    Dim C As Color
    Dim tPath As String

    If FLAG_Loading Then Exit Sub

    'R4.00 OPEN log file and start parsing.
    Dim fs As IO.FileStream
    Dim sw As IO.StreamWriter

    tPath = Application.StartupPath()
    Try
      If tFile = "" Then
        fs = New IO.FileStream(tPath & "\MakoCelo_settings.dat", IO.FileMode.OpenOrCreate)
      Else
        fs = New IO.FileStream(tFile, IO.FileMode.OpenOrCreate)
      End If
      sw = New IO.StreamWriter(fs, System.Text.Encoding.UTF8)

      sw.WriteLine("VERSION MC600")

      C = LSName.F1  'R3.30 lbRank01.ForeColor
      sw.WriteLine("RANK FORE COLOR")
      sw.WriteLine(C.A)
      sw.WriteLine(C.R)
      sw.WriteLine(C.G)
      sw.WriteLine(C.B)

      C = LSName.B1  'R3.30 lbRank01.BackColor
      sw.WriteLine("RANK BACK COLOR")
      sw.WriteLine(C.A)
      sw.WriteLine(C.R)
      sw.WriteLine(C.G)
      sw.WriteLine(C.B)

      sw.WriteLine("RANK ALPHA %")
      sw.WriteLine(LSRank.O1)

      sw.WriteLine("BACK IMAGE")
      sw.WriteLine(PATH_BackgroundImage)

      sw.WriteLine("LOG PATH")
      sw.WriteLine(PATH_Game)

      sw.WriteLine("RANK FONT")
      sw.WriteLine(FONT_Rank_Name)
      sw.WriteLine(FONT_Rank_Size)
      sw.WriteLine(FONT_Rank_Bold)
      sw.WriteLine(FONT_Rank_Italic)

      C = LSName.F1  'R3.30 lbName01.ForeColor
      sw.WriteLine("NAME FORE COLOR") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      C = LSName.B1  'R3.30 lbName01.BackColor
      sw.WriteLine("NAME BACK COLOR") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      sw.WriteLine("NAME ALPHA %")
      sw.WriteLine(LSName.O1)

      sw.WriteLine("NAME FONT")
      sw.WriteLine(FONT_Name_Name)
      sw.WriteLine(FONT_Name_Size)
      sw.WriteLine(FONT_Name_Bold)
      sw.WriteLine(FONT_Name_Italic)

      sw.WriteLine("SCREEN SIZE")
      sw.WriteLine(" ")               'R4.10 Changed to actual XY size vars at bottom.

      sw.WriteLine("PAGE LAYOUT Y")
      sw.WriteLine(cboLayoutY.Text)

      sw.WriteLine("PAGE LAYOUT X")
      sw.WriteLine(cboLayoutX.Text)

      C = pbStats.BackColor   'R3.30 pnlPlrz.BackColor
      sw.WriteLine("PANEL BACK COLOR") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      sw.WriteLine("IMAGE SCALING")
      sw.WriteLine(LSName.Scaling)

      sw.WriteLine("GUI COLOR")
      sw.WriteLine(GUI_ColorMode)

      C = LSRank.F1 : sw.WriteLine("RANK FORE COLOR 1") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      C = LSRank.F2 : sw.WriteLine("RANK FORE COLOR 2") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      sw.WriteLine("RANK FORE GRADIENT DIR")
      sw.WriteLine(LSRank.FDir)

      C = LSRank.B1 : sw.WriteLine("RANK BACK COLOR 1") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)
      C = LSRank.B2 : sw.WriteLine("RANK BACK COLOR 2") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      sw.WriteLine("RANK BACK GRADIENT DIR")
      sw.WriteLine(LSRank.BDir)


      C = LSName.F1 : sw.WriteLine("NAME FORE COLOR 1") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)
      C = LSName.F2 : sw.WriteLine("NAME FORE COLOR 2") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      sw.WriteLine("NAME FORE GRADIENT DIR")
      sw.WriteLine(LSName.FDir)

      C = LSName.B1 : sw.WriteLine("NAME BACK COLOR 1") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)
      C = LSName.B2 : sw.WriteLine("NAME BACK COLOR 2") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      sw.WriteLine("NAME BACK GRADIENT DIR")
      sw.WriteLine(LSName.BDir)

      C = LSRank.ShadowColor : sw.WriteLine("RANK SHADOW COLOR") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      sw.WriteLine("RANK SHADOW DIR")
      sw.WriteLine(LSRank.ShadowDir)

      sw.WriteLine("RANK SHADOW DEPTH")
      If LSRank.ShadowDepth = Nothing Then LSRank.ShadowDepth = ""
      sw.WriteLine(LSRank.ShadowDepth)

      C = LSName.ShadowColor : sw.WriteLine("NAME SHADOW COLOR") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      sw.WriteLine("NAME SHADOW DIR")
      sw.WriteLine(LSName.ShadowDir)

      sw.WriteLine("NAME SHADOW DEPTH - Future")
      sw.WriteLine(LSName.ShadowDepth)

      C = COLOR_Back1 : sw.WriteLine("BACK GRADIENT COLOR 1 - Future") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)
      C = COLOR_Back2 : sw.WriteLine("BACK GRADIENT COLOR 2 - Future") : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)

      sw.WriteLine("BACK GRADIENT DIR - Future")
      sw.WriteLine(COLOR_Back_Dir)

      sw.WriteLine("FX COLORS")
      For t = 1 To 10
        C = CFX3DC(t) : sw.WriteLine(C.A) : sw.WriteLine(C.R) : sw.WriteLine(C.G) : sw.WriteLine(C.B)
      Next t

      sw.WriteLine("FX VARS")
      For N = 1 To 10
        For t = 1 To 10
          If CFX3DVar(N, t) = Nothing Then CFX3DVar(N, t) = ""
          sw.WriteLine(CFX3DVar(N, t))
        Next
      Next

      sw.WriteLine("FX ACTIVE")
      For N = 1 To 10
        If CFX3DActive(N) Then
          sw.WriteLine("True")
        Else
          sw.WriteLine("False")
        End If
      Next

      '*********************************
      'R4.00 ADDED!
      '*********************************
      sw.WriteLine("NAME OVERLAY IMAGE")
      sw.WriteLine(PATH_Name_OVLBmp)
      sw.WriteLine(LSName.OVLScaling)

      sw.WriteLine("NOTE 01 VARS")
      sw.WriteLine(LSNote01.B1.A)
      sw.WriteLine(LSNote01.B1.R)
      sw.WriteLine(LSNote01.B1.G)
      sw.WriteLine(LSNote01.B1.B)
      sw.WriteLine(LSNote01.B2.A)
      sw.WriteLine(LSNote01.B2.R)
      sw.WriteLine(LSNote01.B2.G)
      sw.WriteLine(LSNote01.B2.B)
      sw.WriteLine(LSNote01.BackC.A)
      sw.WriteLine(LSNote01.BackC.R)
      sw.WriteLine(LSNote01.BackC.G)
      sw.WriteLine(LSNote01.BackC.B)
      sw.WriteLine(LSNote01.BDir)
      sw.WriteLine(LSNote01.F1.A)
      sw.WriteLine(LSNote01.F1.R)
      sw.WriteLine(LSNote01.F1.G)
      sw.WriteLine(LSNote01.F1.B)
      sw.WriteLine(LSNote01.F2.A)
      sw.WriteLine(LSNote01.F2.R)
      sw.WriteLine(LSNote01.F2.G)
      sw.WriteLine(LSNote01.F2.B)
      sw.WriteLine(LSNote01.FDir)
      sw.WriteLine(LSNote01.Height)
      sw.WriteLine(LSNote01.O1)
      sw.WriteLine(LSNote01.O2)
      sw.WriteLine(LSNote01.Scaling)
      sw.WriteLine(LSNote01.OVLScaling)
      sw.WriteLine(LSNote01.ShadowColor.A)
      sw.WriteLine(LSNote01.ShadowColor.R)
      sw.WriteLine(LSNote01.ShadowColor.G)
      sw.WriteLine(LSNote01.ShadowColor.B)
      sw.WriteLine(LSNote01.ShadowDepth)
      sw.WriteLine(LSNote01.ShadowDir)
      sw.WriteLine(LSNote01.Width)
      sw.WriteLine(PATH_Note01_Bmp)
      sw.WriteLine(PATH_Note01_BmpPath)
      sw.WriteLine(PATH_Note01_OVLBmp)
      sw.WriteLine(PATH_Note01_OVLBmpPath)
      sw.WriteLine(FONT_Note01_Name)
      sw.WriteLine(FONT_Note01_Bold)
      sw.WriteLine(FONT_Note01_Italic)
      sw.WriteLine(FONT_Note01_Size)

      For t = 1 To 10
        sw.WriteLine(NoteAnim01_Text(t))
      Next t

      sw.WriteLine(NoteAnim01.Mode)
      sw.WriteLine(NoteAnim01.Speed)
      sw.WriteLine(NoteAnim01.TimeHold)
      sw.WriteLine(NoteAnim01.Align)
      sw.WriteLine(NoteAnim01.Delim)
      sw.WriteLine(NoteAnim01.Xoffset)
      sw.WriteLine(NoteAnim01.Yoffset)

      sw.WriteLine("NOTE 02 VARS")
      sw.WriteLine(LSNote02.B1.A)
      sw.WriteLine(LSNote02.B1.R)
      sw.WriteLine(LSNote02.B1.G)
      sw.WriteLine(LSNote02.B1.B)
      sw.WriteLine(LSNote02.B2.A)
      sw.WriteLine(LSNote02.B2.R)
      sw.WriteLine(LSNote02.B2.G)
      sw.WriteLine(LSNote02.B2.B)
      sw.WriteLine(LSNote02.BackC.A)
      sw.WriteLine(LSNote02.BackC.R)
      sw.WriteLine(LSNote02.BackC.G)
      sw.WriteLine(LSNote02.BackC.B)
      sw.WriteLine(LSNote02.BDir)
      sw.WriteLine(LSNote02.F1.A)
      sw.WriteLine(LSNote02.F1.R)
      sw.WriteLine(LSNote02.F1.G)
      sw.WriteLine(LSNote02.F1.B)
      sw.WriteLine(LSNote02.F2.A)
      sw.WriteLine(LSNote02.F2.R)
      sw.WriteLine(LSNote02.F2.G)
      sw.WriteLine(LSNote02.F2.B)
      sw.WriteLine(LSNote02.FDir)
      sw.WriteLine(LSNote02.Height)
      sw.WriteLine(LSNote02.O1)
      sw.WriteLine(LSNote02.O2)
      sw.WriteLine(LSNote02.Scaling)
      sw.WriteLine(LSNote02.OVLScaling)
      sw.WriteLine(LSNote02.ShadowColor.A)
      sw.WriteLine(LSNote02.ShadowColor.R)
      sw.WriteLine(LSNote02.ShadowColor.G)
      sw.WriteLine(LSNote02.ShadowColor.B)
      sw.WriteLine(LSNote02.ShadowDepth)
      sw.WriteLine(LSNote02.ShadowDir)
      sw.WriteLine(LSNote02.Width)
      sw.WriteLine(PATH_Note02_Bmp)
      sw.WriteLine(PATH_Note02_BmpPath)
      sw.WriteLine(PATH_Note02_OVLBmp)
      sw.WriteLine(PATH_Note02_OVLBmpPath)
      sw.WriteLine(FONT_Note02_Name)
      sw.WriteLine(FONT_Note02_Bold)
      sw.WriteLine(FONT_Note02_Italic)
      sw.WriteLine(FONT_Note02_Size)

      For t = 1 To 10
        sw.WriteLine(NoteAnim02_Text(t))
      Next t

      sw.WriteLine(NoteAnim02.Mode)
      sw.WriteLine(NoteAnim02.Speed)
      sw.WriteLine(NoteAnim02.TimeHold)
      sw.WriteLine(NoteAnim02.Align)
      sw.WriteLine(NoteAnim02.Delim)
      sw.WriteLine(NoteAnim02.Xoffset)
      sw.WriteLine(NoteAnim02.Yoffset)

      sw.WriteLine("NOTE 03 VARS")
      sw.WriteLine(LSNote03.B1.A)
      sw.WriteLine(LSNote03.B1.R)
      sw.WriteLine(LSNote03.B1.G)
      sw.WriteLine(LSNote03.B1.B)
      sw.WriteLine(LSNote03.B2.A)
      sw.WriteLine(LSNote03.B2.R)
      sw.WriteLine(LSNote03.B2.G)
      sw.WriteLine(LSNote03.B2.B)
      sw.WriteLine(LSNote03.BackC.A)
      sw.WriteLine(LSNote03.BackC.R)
      sw.WriteLine(LSNote03.BackC.G)
      sw.WriteLine(LSNote03.BackC.B)
      sw.WriteLine(LSNote03.BDir)
      sw.WriteLine(LSNote03.F1.A)
      sw.WriteLine(LSNote03.F1.R)
      sw.WriteLine(LSNote03.F1.G)
      sw.WriteLine(LSNote03.F1.B)
      sw.WriteLine(LSNote03.F2.A)
      sw.WriteLine(LSNote03.F2.R)
      sw.WriteLine(LSNote03.F2.G)
      sw.WriteLine(LSNote03.F2.B)
      sw.WriteLine(LSNote03.FDir)
      sw.WriteLine(LSNote03.Height)
      sw.WriteLine(LSNote03.O1)
      sw.WriteLine(LSNote03.O2)
      sw.WriteLine(LSNote03.Scaling)
      sw.WriteLine(LSNote03.OVLScaling)
      sw.WriteLine(LSNote03.ShadowColor.A)
      sw.WriteLine(LSNote03.ShadowColor.R)
      sw.WriteLine(LSNote03.ShadowColor.G)
      sw.WriteLine(LSNote03.ShadowColor.B)
      sw.WriteLine(LSNote03.ShadowDepth)
      sw.WriteLine(LSNote03.ShadowDir)
      sw.WriteLine(LSNote03.Width)
      sw.WriteLine(PATH_Note03_Bmp)
      sw.WriteLine(PATH_Note03_BmpPath)
      sw.WriteLine(PATH_Note03_OVLBmp)
      sw.WriteLine(PATH_Note03_OVLBmpPath)
      sw.WriteLine(FONT_Note03_Name)
      sw.WriteLine(FONT_Note03_Bold)
      sw.WriteLine(FONT_Note03_Italic)
      sw.WriteLine(FONT_Note03_Size)

      For t = 1 To 10
        sw.WriteLine(NoteAnim03_Text(t))
      Next t

      sw.WriteLine(NoteAnim03.Mode)
      sw.WriteLine(NoteAnim03.Speed)
      sw.WriteLine(NoteAnim03.TimeHold)
      sw.WriteLine(NoteAnim03.Align)
      sw.WriteLine(NoteAnim03.Delim)
      sw.WriteLine(NoteAnim03.Xoffset)
      sw.WriteLine(NoteAnim03.Yoffset)

      sw.WriteLine("NOTE 04 VARS")
      sw.WriteLine(LSNote04.B1.A)
      sw.WriteLine(LSNote04.B1.R)
      sw.WriteLine(LSNote04.B1.G)
      sw.WriteLine(LSNote04.B1.B)
      sw.WriteLine(LSNote04.B2.A)
      sw.WriteLine(LSNote04.B2.R)
      sw.WriteLine(LSNote04.B2.G)
      sw.WriteLine(LSNote04.B2.B)
      sw.WriteLine(LSNote04.BackC.A)
      sw.WriteLine(LSNote04.BackC.R)
      sw.WriteLine(LSNote04.BackC.G)
      sw.WriteLine(LSNote04.BackC.B)
      sw.WriteLine(LSNote04.BDir)
      sw.WriteLine(LSNote04.F1.A)
      sw.WriteLine(LSNote04.F1.R)
      sw.WriteLine(LSNote04.F1.G)
      sw.WriteLine(LSNote04.F1.B)
      sw.WriteLine(LSNote04.F2.A)
      sw.WriteLine(LSNote04.F2.R)
      sw.WriteLine(LSNote04.F2.G)
      sw.WriteLine(LSNote04.F2.B)
      sw.WriteLine(LSNote04.FDir)
      sw.WriteLine(LSNote04.Height)
      sw.WriteLine(LSNote04.O1)
      sw.WriteLine(LSNote04.O2)
      sw.WriteLine(LSNote04.Scaling)
      sw.WriteLine(LSNote04.OVLScaling)
      sw.WriteLine(LSNote04.ShadowColor.A)
      sw.WriteLine(LSNote04.ShadowColor.R)
      sw.WriteLine(LSNote04.ShadowColor.G)
      sw.WriteLine(LSNote04.ShadowColor.B)
      sw.WriteLine(LSNote04.ShadowDepth)
      sw.WriteLine(LSNote04.ShadowDir)
      sw.WriteLine(LSNote04.Width)
      sw.WriteLine(PATH_Note04_Bmp)
      sw.WriteLine(PATH_Note04_BmpPath)
      sw.WriteLine(PATH_Note04_OVLBmp)
      sw.WriteLine(PATH_Note04_OVLBmpPath)
      sw.WriteLine(FONT_Note04_Name)
      sw.WriteLine(FONT_Note04_Bold)
      sw.WriteLine(FONT_Note04_Italic)
      sw.WriteLine(FONT_Note04_Size)

      For t = 1 To 10
        sw.WriteLine(NoteAnim04_Text(t))
      Next t

      sw.WriteLine(NoteAnim04.Mode)
      sw.WriteLine(NoteAnim04.Speed)
      sw.WriteLine(NoteAnim04.TimeHold)
      sw.WriteLine(NoteAnim04.Align)
      sw.WriteLine(NoteAnim04.Delim)
      sw.WriteLine(NoteAnim04.Xoffset)
      sw.WriteLine(NoteAnim04.Yoffset)

      sw.WriteLine("NOTE SPACING")
      sw.WriteLine(NOTE_Spacing)

      sw.WriteLine("SOUND SAMPLES")
      For t = 1 To 30
        sw.WriteLine(SOUND_File(t))   'R4.00 WAV file path.
        sw.WriteLine(" ")             'R4.00 Future Pitch/Speed.
        sw.WriteLine(SOUND_Vol(t))    'R4.10 Volume.
      Next t
      sw.WriteLine(scrVolume.Value)

      sw.WriteLine("WINDOW STATE")
      A = "Normal"
      If WindowState = 1 Then A = "Minimized"
      If WindowState = 2 Then A = "Maximized"
      sw.WriteLine(A)
      sw.WriteLine(Location.X)
      sw.WriteLine(Location.Y)
      sw.WriteLine(Size.Width)
      sw.WriteLine(Size.Height)
      If chkPosition.Checked Then
        sw.WriteLine("1")
      Else
        sw.WriteLine("0")
      End If
      If chkPopUp.Checked Then
        sw.WriteLine("1")
      Else
        sw.WriteLine("0")
      End If

      sw.WriteLine("PAGE XY OFFSET")
      sw.WriteLine(tbXoff.Text)
      sw.WriteLine(tbYoff.Text)

      sw.WriteLine("PAGE XY SIZE")
      sw.WriteLine(STATS_SizeX)
      sw.WriteLine(STATS_SizeY)

      'R4.30 Added.
      sw.WriteLine("SCAN TIME")
      sw.WriteLine(Val(cboDelay.Items.Item(cboDelay.SelectedIndex)))

      'R4.30 Added.
      sw.WriteLine("MATCH ALARM ON")
      If chkFoundSound.Checked Then
        sw.WriteLine("1")
      Else
        sw.WriteLine("0")
      End If

      'R4.30 Added.
      sw.WriteLine("HIDE MISSING")
      If chkHideMissing.Checked Then
        sw.WriteLine("1")
      Else
        sw.WriteLine("0")
      End If

      sw.WriteLine("LEVEL STORAGE")
      For t = 1 To 7
        For tt = 1 To 4
          sw.WriteLine(LVLS(t, tt))
        Next tt
      Next t

      'R4.30 Added.
      sw.WriteLine("CYCLE ELO")
      If chkShowELO.Checked Then
        sw.WriteLine("1")
      Else
        sw.WriteLine("0")
      End If

      'R4.34 Added until Relic fixes the Warngins.Log file.
      sw.WriteLine("USE WEB SEARCH")
      sw.WriteLine("1")

      'R4.34 Added.
      sw.WriteLine("SPEECH RANKS")
      If chkSpeech.Checked Then
        sw.WriteLine("1")
      Else
        sw.WriteLine("0")
      End If

      'R4.34 Added.
      sw.WriteLine("FIND TEAMS")
      If chkGetTeams.Checked Then
        sw.WriteLine("1")
      Else
        sw.WriteLine("0")
      End If

      'R4.40 Added. LSname and LSrank must be the same.
      sw.WriteLine("PLAYER CARD BACK")
      If LSName.UseCardBack Then
        sw.WriteLine("1")
      Else
        sw.WriteLine("0")
      End If

      'R4.40 Added. LSname and LSrank must be the same.
      sw.WriteLine("RANK BORDER")
      sw.WriteLine(LSRank.BorderMode)
      sw.WriteLine(LSRank.BorderColor.A)
      sw.WriteLine(LSRank.BorderColor.R)
      sw.WriteLine(LSRank.BorderColor.G)
      sw.WriteLine(LSRank.BorderColor.B)
      sw.WriteLine(LSRank.BorderWidth)
      sw.WriteLine("0")
      sw.WriteLine("0")
      sw.WriteLine("0")
      sw.WriteLine("0")
      sw.WriteLine("0")

      'R4.40 Added. LSname and LSrank must be the same.
      sw.WriteLine("NAME BORDER")
      sw.WriteLine(LSName.BorderMode)
      sw.WriteLine(LSName.BorderColor.A)
      sw.WriteLine(LSName.BorderColor.R)
      sw.WriteLine(LSName.BorderColor.G)
      sw.WriteLine(LSName.BorderColor.B)
      sw.WriteLine(LSName.BorderWidth)
      sw.WriteLine("0")
      sw.WriteLine("0")
      sw.WriteLine("0")
      sw.WriteLine("0")
      sw.WriteLine("0")

      'R4.40 Added. LSname and LSrank must be the same.
      sw.WriteLine("PANEL BORDER")
      sw.WriteLine(LSRank.BorderPanelMode)
      sw.WriteLine(LSRank.BorderPanelColor.A)
      sw.WriteLine(LSRank.BorderPanelColor.R)
      sw.WriteLine(LSRank.BorderPanelColor.G)
      sw.WriteLine(LSRank.BorderPanelColor.B)
      sw.WriteLine(LSRank.BorderPanelWidth)
      sw.WriteLine("0")
      sw.WriteLine("0")
      sw.WriteLine("0")
      sw.WriteLine("0")
      sw.WriteLine("0")

      'R4.45 Added.
      sw.WriteLine("SHOW COUNTRY")
      If chkCountry.Checked Then
        sw.WriteLine("1")
      Else
        sw.WriteLine("0")
      End If


      'R3.10 Write some extra lines to stop file open fails on future revs.
      For t = 1 To 100
        sw.WriteLine(" ")
      Next t



    Catch ex As Exception
      MsgBox("ERROR: " & ex.Message & vbCr & vbCr & "Unable to save the last known setup.", MsgBoxStyle.Critical, "MakoCelo - Setup Error")

    End Try

    'R4.00 Close / Clean up  streams?
    If IsNothing(sw) = False Then
      sw.Close()
      sw.Dispose()
    End If
    If IsNothing(fs) = False Then
      fs.Close()
      fs.Dispose()
    End If


  End Sub


  Public Function STRING_FindLastSlash(A As String)
    Dim i As Integer
    Dim Hit As Integer

    Hit = 0
    For i = Len(A) To 1 Step -1
      If Mid(A, i, 1) = "\" Then Hit = i : Exit For
    Next

    STRING_FindLastSlash = Hit

  End Function


  Public Function PATH_StripFilename(tPath As String) As String
    'R2.00 Strip the filename off for init dir on dialog.  
    Dim N As Integer
    Dim S As String

    N = STRING_FindLastSlash(tPath)
    If 3 < N Then
      S = Mid(tPath, 1, N)
    Else
      S = ""
    End If

    PATH_StripFilename = S

  End Function

  Public Function PATH_GetAnyPath() As String
    Dim tPath As String = ""

    'R4.00 Get a texture path from defined textures.
    If PATH_BackgroundImage <> "" Then
      tPath = PATH_StripFilename(PATH_BackgroundImage)
    Else
      If PATH_Note01_Bmp <> "" Then tPath = PATH_StripFilename(PATH_Note01_Bmp)
      If PATH_Note02_Bmp <> "" Then tPath = PATH_StripFilename(PATH_Note02_Bmp)
      If PATH_Note03_Bmp <> "" Then tPath = PATH_StripFilename(PATH_Note03_Bmp)
      If PATH_Note04_Bmp <> "" Then tPath = PATH_StripFilename(PATH_Note04_Bmp)
    End If

    PATH_GetAnyPath = tPath

  End Function

  Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    FLAG_Loading = True         'R2.00 Tell Controls not to update. Most save settings as they update,

    GUI_Active = False          'R3.10 Default to NO active GUI elements.
    PATH_Game = ""              'R2.00 Initialize the var or we get error 448 in file.
    PATH_BackgroundImage = ""

    'R4.43 Added for Connection issues.
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

    'R4.46 Added Country Strings. Read from included Resource FIle.
    Call RES_GetCountryData()

    'R4.30 Create a BMP to work from. 
    Main_BM = New Bitmap(pbStats.Width, pbStats.Height)
    Main_Gfx = Graphics.FromImage(Main_BM)
    Main_Gfx.Clear(Color.Black)
    Main_BM2 = New Bitmap(pbStats.Width, pbStats.Height)
    Main_Gfx2 = Graphics.FromImage(Main_BM2)
    Main_Gfx2.Clear(Color.Black)

    Main_Gfx.SmoothingMode = SmoothingMode.AntiAlias

    'R3.00 Setup default Ranks and Names
    For t = 1 To 8
      PlrName(t) = "Player " & CStr(t)
      PlrRank(t) = "123"
      PlrFact(t) = "01"

      LAB_Name_Align(t) = New StringFormat()
    Next

    'R4.00 Init some string vars.
    For t = 1 To 10
      NoteAnim01_Text(t) = ""
      NoteAnim02_Text(t) = ""
      NoteAnim03_Text(t) = ""
      NoteAnim04_Text(t) = ""
      Note01_Text(t) = ""
      Note02_Text(t) = ""
      Note03_Text(t) = ""
      Note04_Text(t) = ""
    Next

    'R4.30 Fill in the RELIC LEADERBOARD IDs for each game mode.
    Call INIT_LeaderBoardIDs()

    'R3.30 Fill in the Combo Box list items.
    Call INIT_FillComboBoxes()

    'R3.40 Setup ToolTips
    ToolTip1.Active = False
    Call ToolTip_Setup()

    'R4.30 Create array with LEVEL step percentages.
    LOG_InitCalcArrays()

    'R4.00 Setup default FONTs for Rank and Name labels.
    FONT_Rank_Name = "Arial"
    FONT_Rank_Size = "14"
    FONT_Rank_Bold = "True"
    FONT_Rank_Italic = "False"
    FONT_Rank = New Font(FONT_Rank_Name, CSng(FONT_Rank_Size), FontStyle.Bold)
    FONT_Name_Name = "Arial"
    FONT_Name_Size = "16"
    FONT_Name_Bold = "True"
    FONT_Name_Italic = "False"
    FONT_Name = New Font(FONT_Name_Name, CSng(FONT_Name_Size), FontStyle.Bold)
    FONT_Note01 = FONT_Rank
    FONT_Note01_Name = "Arial"
    FONT_Note01_Size = "14"
    FONT_Note01_Bold = "True"
    FONT_Note01_Italic = "False"
    FONT_Note02 = FONT_Rank
    FONT_Note02_Name = "Arial"
    FONT_Note02_Size = "14"
    FONT_Note02_Bold = "True"
    FONT_Note02_Italic = "False"
    FONT_Note03 = FONT_Rank
    FONT_Note03_Name = "Arial"
    FONT_Note03_Size = "14"
    FONT_Note03_Bold = "True"
    FONT_Note03_Italic = "False"
    FONT_Note04 = FONT_Rank
    FONT_Note04_Name = "Arial"
    FONT_Note04_Size = "14"
    FONT_Note04_Bold = "True"
    FONT_Note04_Italic = "False"

    'R4.00 Message seperation string (Delimiter).
    NoteAnim01.Delim = "   ●   "
    NoteAnim02.Delim = "   ●   "
    NoteAnim03.Delim = "   ●   "
    NoteAnim04.Delim = "   ●   "

    'R3.30 Default label gradient color setups.
    LSRank.F1 = Color.FromArgb(255, 255, 255, 64)
    LSRank.F2 = Color.FromArgb(255, 192, 192, 48)
    LSRank.FDir = 0
    LSRank.B1 = Color.FromArgb(255, 128, 0, 0)
    LSRank.B2 = Color.FromArgb(255, 0, 0, 0)
    LSRank.BDir = 0
    LSRank.ShadowColor = Color.FromArgb(255, 0, 0, 0)
    LSRank.O1 = 100
    LSRank.O2 = 10
    LSName.F1 = Color.FromArgb(255, 255, 255, 255)
    LSName.F2 = Color.FromArgb(255, 192, 192, 192)
    LSName.FDir = 0
    LSName.B1 = Color.FromArgb(255, 64, 64, 64)
    LSName.B2 = Color.FromArgb(25, 0, 0, 0)
    LSName.BDir = 1

    'R4.41 Added some color defaults. ARGB(0,0,0,0) does not let you set ARGB(255,0,0,0) in dialog.
    LSRank.ShadowColor = Color.FromArgb(255, 0, 0, 0)
    LSRank.BorderColor = Color.FromArgb(255, 0, 0, 0)
    LSRank.BorderPanelColor = Color.FromArgb(255, 64, 0, 0)
    LSName.ShadowColor = Color.FromArgb(255, 0, 0, 0)
    LSName.BorderColor = Color.FromArgb(255, 0, 0, 0)
    LSName.BorderPanelColor = Color.FromArgb(255, 64, 0, 0)
    LSName.BackC = Color.FromArgb(255, 0, 0, 0)

    'R4.00 Set some default setups for Notes.
    LSNote01 = LSRank
    LSNote02 = LSRank
    LSNote03 = LSRank
    LSNote04 = LSRank

    LSNote01.Width = pbNote1.Width
    LSNote01.Height = pbNote1.Height
    LSNote02.Width = pbNote2.Width
    LSNote02.Height = pbNote2.Height
    LSNote03.Width = pbNote3.Width
    LSNote03.Height = pbNote3.Height
    LSNote04.Width = pbNote4.Width
    LSNote04.Height = pbNote4.Height

    'R4.50 Init the SOUND PAD variables.
    For t = 0 To 19
      SOUND_File(t) = ""
      SOUND_Vol(t) = 100
    Next t

    '***********************************************************************************************************
    'R3.00 Load the base USER settings. Do not load older files that Windows did not cleanup when uninstalled.
    '***********************************************************************************************************
    Dim IsOldStyle As Boolean = False

    If SETTINGS_Load_CheckVersion("", IsOldStyle) = True Then
      If IsOldStyle Then
        Call SETTINGS_Load_Old("")
      Else
        Call SETTINGS_Load("")
      End If
    End If

    Call SETUP_Apply()

    'R4.30 Check the MAX player data to see if is usable.
    Call ELO_VerifyData()

    Call SPEECH_Test()

    'R4.50 Force a clean redraw once fully loaded.
    MainBuffer_Valid = False

  End Sub

  Private Sub SPEECH_Test()
    'Dim tts As New SpeechSynthesizer

    FLAG_SpeechOK = True
    Try
      SpeechSynth.SpeakAsync("")
    Catch
      FLAG_SpeechOK = False
      lbError2.Text = "Speech Error"
    End Try

  End Sub

  Private Sub INIT_LeaderBoardIDs()
    'OST
    RelDataLeaderID(1, 1) = "4"
    RelDataLeaderID(1, 2) = "8"
    RelDataLeaderID(1, 3) = "12"
    RelDataLeaderID(1, 4) = "16"
    'SOV
    RelDataLeaderID(2, 1) = "5"
    RelDataLeaderID(2, 2) = "9"
    RelDataLeaderID(2, 3) = "13"
    RelDataLeaderID(2, 4) = "17"
    'OKW
    RelDataLeaderID(3, 1) = "6"
    RelDataLeaderID(3, 2) = "10"
    RelDataLeaderID(3, 3) = "14"
    RelDataLeaderID(3, 4) = "18"
    'USF
    RelDataLeaderID(4, 1) = "7"
    RelDataLeaderID(4, 2) = "11"
    RelDataLeaderID(4, 3) = "15"
    RelDataLeaderID(4, 4) = "19"
    'BRIT
    RelDataLeaderID(5, 1) = "51"
    RelDataLeaderID(5, 2) = "52"
    RelDataLeaderID(5, 3) = "53"
    RelDataLeaderID(5, 4) = "54"
  End Sub

  Private Sub SETUP_Apply()

    Note01_Bmp = New Bitmap(pbNote1.Width, pbNote1.Height)
    Note02_Bmp = New Bitmap(pbNote2.Width, pbNote2.Height)
    Note03_Bmp = New Bitmap(pbNote3.Width, pbNote3.Height)
    Note04_Bmp = New Bitmap(pbNote4.Width, pbNote4.Height)
    Note01_Gfx = Graphics.FromImage(Note01_Bmp)
    Note02_Gfx = Graphics.FromImage(Note02_Bmp)
    Note03_Gfx = Graphics.FromImage(Note03_Bmp)
    Note04_Gfx = Graphics.FromImage(Note04_Bmp)

    'R4.00 Setup default sizes.
    LSNote01.Width = pbNote1.Width
    LSNote01.Height = pbNote1.Height
    LSNote02.Width = pbNote2.Width
    LSNote02.Height = pbNote2.Height
    LSNote03.Width = pbNote3.Width
    LSNote03.Height = pbNote3.Height
    LSNote04.Width = pbNote4.Width
    LSNote04.Height = pbNote4.Height

    'R3.00 Set GUI color scheme.
    Select Case GUI_ColorMode
      Case 0 : Call GUI_SetLite()
      Case 1 : Call GUI_SetDark()
    End Select

    'R2.00 Try to set some defaults in case we cant read settings.
    LSRank.O1 = CInt((LSRank.B1.A) / 2.55)
    LSRank.O2 = CInt((LSRank.B2.A) / 2.55)
    LSName.O1 = CInt((LSName.B1.A) / 2.55)
    LSName.O2 = CInt((LSName.B2.A) / 2.55)
    If cboLayoutY.Text = "" Then cboLayoutY.Text = "3 - 90% tight"
    If cboLayoutX.Text = "" Then cboLayoutX.Text = "3 - 90% tight"
    If LSName.Scaling = "" Then LSName.Scaling = "2 - Fit"
    If LSRank.ShadowDir = "" Then LSRank.ShadowDir = "270°"

    If cboFXVar2.Text = "" Then
      cboFXVar2.Text = "270°"
    End If
    If cboFxVar3.Text = "" Then cboFxVar3.Text = "80%"
    If cboFxVar4.Text = "" Then cboFxVar4.Text = "2.0%"
    If cboFXVar1.Text = "" Then cboFXVar1.Text = "None"

    'R2.00 Strip the filename off for init dir on dialog.  
    Dim N As Integer = InStr(PATH_Game, "warnings")
    If 3 < N Then
      PATH_GamePath = Mid(PATH_Game, 1, N - 1)
    Else
      PATH_GamePath = ""
    End If

    'R2.00 Strip the filename off for init dir on dialog.  
    N = STRING_FindLastSlash(PATH_BackgroundImage)
    If 3 < N Then
      PATH_BackgroundImagePath = Mid(PATH_BackgroundImage, 1, N)
    Else
      PATH_BackgroundImagePath = ""
    End If

    FLAG_Loading = False

    STATS_DefineY()

    'R4.00 Restore last window position if not min or max. 
    'R4.00 Need a check here for valid postition so we dont set it off screen.
    If (Celo_Windowstate = "Normal") And (chkPosition.Checked) Then
      Location = New Point(Celo_Left, Celo_Top)
      Me.Width = Celo_Width
      Me.Height = Celo_Height
    End If


  End Sub


  Private Sub INIT_FillComboBoxes()
    cboDelay.Items.Add("5")
    cboDelay.Items.Add("10")
    cboDelay.Items.Add("20")
    cboDelay.Items.Add("30")
    cboDelay.Items.Add("45")
    cboDelay.Items.Add("60")

    'R4.30 Set default search time to 10 seconds.
    cboDelay.SelectedIndex = 1

    'R3.20 Setup some default FX values.
    CFX3DVar(1, 2) = "270°"
    CFX3DVar(1, 3) = "70%"
    CFX3DVar(1, 4) = "5.0%"
    CFX3DVar(2, 2) = "270°"
    CFX3DVar(2, 3) = "50%"
    CFX3DVar(2, 4) = "5.0%"
    CFX3DVar(3, 2) = "270°"
    CFX3DVar(3, 3) = "50%"
    CFX3DVar(3, 4) = "2.0%"

    cboLayoutY.Items.Add("0 - 60% tight")
    cboLayoutY.Items.Add("1 - 70% tight")
    cboLayoutY.Items.Add("2 - 80% tight")
    cboLayoutY.Items.Add("3 - 90% tight")
    cboLayoutY.Items.Add("4 - 100% tight")
    cboLayoutY.Items.Add("5 - 60% spread")
    cboLayoutY.Items.Add("6 - 70% spread")
    cboLayoutY.Items.Add("7 - 80% spread")
    cboLayoutY.Items.Add("8 - 90% spread")
    cboLayoutY.Items.Add("9 - 100% spread")

    cboLayoutX.Items.Add("0 - 60% tight")
    cboLayoutX.Items.Add("1 - 70% tight")
    cboLayoutX.Items.Add("2 - 80% tight")
    cboLayoutX.Items.Add("3 - 90% tight")
    cboLayoutX.Items.Add("4 - 100% tight")
    cboLayoutX.Items.Add("5 - 60% spread")
    cboLayoutX.Items.Add("6 - 70% spread")
    cboLayoutX.Items.Add("7 - 80% spread")
    cboLayoutX.Items.Add("8 - 90% spread")
    cboLayoutX.Items.Add("9 - 100% spread")
    cboLayoutX.Items.Add("10 - 60% mid tight")
    cboLayoutX.Items.Add("11 - 70% mid tight")
    cboLayoutX.Items.Add("12 - 80% mid tight")
    cboLayoutX.Items.Add("13 - 90% mid tight")
    cboLayoutX.Items.Add("14 - 100% mid tight")
    cboLayoutX.Items.Add("15 - 60% mid spread")
    cboLayoutX.Items.Add("16 - 70% mid spread")
    cboLayoutX.Items.Add("17 - 80% mid spread")
    cboLayoutX.Items.Add("18 - 90% mid spread")
    cboLayoutX.Items.Add("19 - 100% mid spread")
    cboLayoutX.Items.Add("20 - clock tight")
    cboLayoutX.Items.Add("21 - clock spread")

    cboNoteSpace.Items.Add("0 px")
    cboNoteSpace.Items.Add("1 px")
    cboNoteSpace.Items.Add("2 px")
    cboNoteSpace.Items.Add("3 px")
    cboNoteSpace.Items.Add("4 px")
    cboNoteSpace.Items.Add("5 px")

    cboFXVar1.Items.Add("None")
    cboFXVar1.Items.Add("Shadow")
    cboFXVar1.Items.Add("Emboss")
    cboFXVar1.Items.Add("Lab Blur")

    cboFXVar2.Items.Add("--")
    cboFXVar2.Items.Add("45°")
    cboFXVar2.Items.Add("90°")
    cboFXVar2.Items.Add("135°")
    cboFXVar2.Items.Add("180°")
    cboFXVar2.Items.Add("225°")
    cboFXVar2.Items.Add("270°")
    cboFXVar2.Items.Add("315°")
    cboFXVar2.Items.Add("360°")

    cboFxVar4.Items.Add("0.0%")
    cboFxVar4.Items.Add("1.0%")
    cboFxVar4.Items.Add("2.0%")
    cboFxVar4.Items.Add("3.0%")
    cboFxVar4.Items.Add("4.0%")
    cboFxVar4.Items.Add("5.0%")
    cboFxVar4.Items.Add("6.0%")
    cboFxVar4.Items.Add("7.0%")
    cboFxVar4.Items.Add("8.0%")
    cboFxVar4.Items.Add("9.0%")
    cboFxVar4.Items.Add("10.0%")

    cboFxVar3.Items.Add("40%")
    cboFxVar3.Items.Add("45%")
    cboFxVar3.Items.Add("50%")
    cboFxVar3.Items.Add("55%")
    cboFxVar3.Items.Add("60%")
    cboFxVar3.Items.Add("65%")
    cboFxVar3.Items.Add("70%")
    cboFxVar3.Items.Add("75%")
    cboFxVar3.Items.Add("80%")
    cboFxVar3.Items.Add("85%")
    cboFxVar3.Items.Add("90%")
    cboFxVar3.Items.Add("95%")

  End Sub

  Private Function ALPHA_CalcPercent(tAlpha As Integer) As String

    'R3.00 We are saving Alpha in 0-255, but listing it from 0%-100% in combo list.
    ALPHA_CalcPercent = CStr(CInt(tAlpha / 2.55)) & "%"

  End Function

  Private Sub cmFindLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmFindLog.Click
    Dim fd As OpenFileDialog = New OpenFileDialog()
    Dim A As String
    Dim N As Integer

    'R2.00 Find the LOG file. Try top help get to the right location if possible.
    fd.Title = "FIND: Warnings.Log in My Games\Company of Heroes 2"
    If PATH_GamePath <> "" Then
      fd.InitialDirectory = PATH_GamePath
    Else
      A = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments & "\My Games\Company of Heroes 2\"
      If System.IO.Directory.Exists(A) Then
        fd.InitialDirectory = A
      Else
        fd.InitialDirectory = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments
      End If
    End If
    fd.Filter = "Log Files (*.log)|*.log"
    fd.FilterIndex = 1

    If fd.ShowDialog() = DialogResult.OK Then
      PATH_Game = fd.FileName
      Call SETTINGS_Save("")

      'R3.40 Strip off filename so we can use it for init dir later.
      N = STRING_FindLastSlash(PATH_Game)
      If 3 < N Then
        PATH_GamePath = Mid(PATH_Game, 1, N)
      Else
        PATH_GamePath = ""
      End If

    End If

  End Sub


  Private Sub cmScanLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmScanLog.Click
    'R2.10 If we dont have a valid log file path, exit with help notice.
    If Not (System.IO.File.Exists(PATH_Game)) Then
      MsgBox("Please locate the warnings.log file in your COH2 My Games directory." & vbCr & vbCr & "Click on FIND LOG FILE to search and select.", MsgBoxStyle.Information)
      Exit Sub
    End If

    SCAN_Enabled = Not SCAN_Enabled

    If SCAN_Enabled Then
      SCAN_SecCnt = 0     'R4.30 Reset our wait counter.
      cmScanLog.Text = "Scanning..."
      lbStatus.BackColor = Color.FromArgb(255, 192, 255, 192)
      CONTROLS_Enabled(False)
      Timer1.Enabled = True
    Else
      Timer1.Enabled = False
      lbStatus.BackColor = Color.FromArgb(255, 192, 192, 192)
      lbStatus.Text = "Ready"
      cmScanLog.Text = "Auto Scan Log"
      Call CONTROLS_Enabled(True)               'R3.20 Turn ON all controls.
      Call GFX_UpdateScreenControls()           'R3.20 Turn off the controls for FX that should not be on now.
    End If

  End Sub

  Private Sub CONTROLS_Enabled(tState As Boolean)
    'R1.00 Turn OFF all Controls while scanning on timer.
    'R4.30 Added new controls to this sub.

    cmCheckLog.Enabled = tState
    cmFindLog.Enabled = tState
    cmTestData.Enabled = tState

    cmRankSetup.Enabled = tState
    cmELO.Enabled = tState          'R4.30 Added.
    cmNameSetup.Enabled = tState

    cmSetupLoad.Enabled = tState
    cmSetupSave.Enabled = tState

    cmAbout.Enabled = tState

    tbXsize.Enabled = tState
    tbYSize.Enabled = tState
    tbXoff.Enabled = tState
    tbYoff.Enabled = tState
    cboLayoutY.Enabled = tState
    cboLayoutX.Enabled = tState
    cboNoteSpace.Enabled = tState

    cmDefaults.Enabled = tState
    cmStatsModeHelp.Enabled = tState
    cmSizeRefresh.Enabled = tState

    cboFXVar1.Enabled = tState
    chkFX.Enabled = tState
    cmFX3DC.Enabled = tState
    cboFXVar2.Enabled = tState
    cboFxVar3.Enabled = tState
    cboFxVar4.Enabled = tState

    cmFXModeHelp.Enabled = tState

  End Sub

  Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    'Static SecCnt As Long
    Static FLAG_CheckingLog As Boolean = False  'R4.10 Added.

    'R4.10 MSGBOX in LOG_Scan holds code there, but animation timer keeps going which triggers this timer and you get a loop.
    If FLAG_CheckingLog Then Exit Sub

    SCAN_SecCnt += 1

    If SCAN_Time < SCAN_SecCnt Then
      SCAN_SecCnt = 0
      FLAG_CheckingLog = True
      Call LOG_Scan()
      FLAG_CheckingLog = False
    Else
      lbStatus.Text = "Scan in " & (SCAN_Time + 1) - SCAN_SecCnt & "s"
    End If

  End Sub


  Private Sub cmCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmCopy.Click
    'R3.00 Copy Picturebox image data to the clipboard.
    Dim tmpImg As New Bitmap(pbStats.Image, pbStats.Width, pbStats.Height)

    Clipboard.Clear()
    Clipboard.SetImage(tmpImg)

    tmpImg.Dispose()

  End Sub


  Private Sub cmAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmAbout.Click

    frmAbout.ShowDialog()

  End Sub

  Private Sub STATS_DefineY()
    Dim i As Integer
    Dim YStart As Single
    Dim YStep As Single
    Dim Y As Single

    Select Case Val(cboLayoutY.Text)
      Case 0
        YStart = 0.2 : YStep = 0.6 / 4
      Case 1
        YStart = 0.15 : YStep = 0.7 / 4
      Case 2
        YStart = 0.1 : YStep = 0.8 / 4
      Case 3
        YStart = 0.05 : YStep = 0.9 / 4
      Case 4
        YStart = 0.025 : YStep = 0.94 / 4      'R4.44 Was 0, 1
      Case 5
        YStart = 0.2 : YStep = 0.6 / 4
      Case 6
        YStart = 0.15 : YStep = 0.7 / 4
      Case 7
        YStart = 0.1 : YStep = 0.8 / 4
      Case 8
        YStart = 0.05 : YStep = 0.9 / 4
      Case 9
        YStart = 0.025 : YStep = 0.94 / 4      'R4.44 Was 0, 1
    End Select

    'R2.00 Force YStart and Ystep to an integer pixel value or we get spaces between labels.
    i = YStep * pbStats.Height    'R3.30 Deprecated pnlPlr.Height
    YStep = i / pbStats.Height
    i = YStart * pbStats.Height
    YStart = i / pbStats.Height

    Select Case Val(cboLayoutY.Text)
      Case 0, 1, 2, 3, 4
        Y = YStart : LAB_Height = YStep
      Case 5, 6, 7, 8, 9
        Y = YStart + YStep * 0.075 : LAB_Height = YStep * 0.8
    End Select

    For i = 1 To 7 Step 2
      LAB_Rank(i).Y = Y * pbStats.Height
      LAB_Rank(i).Height = LAB_Height * pbStats.Height
      LAB_Rank(i).Ycenter = LAB_Rank(i).Y + LAB_Rank(i).Height / 2

      LAB_Name(i).Y = Y * pbStats.Height
      LAB_Name(i).Height = LAB_Height * pbStats.Height
      LAB_Name(i).Ycenter = LAB_Name(i).Y + LAB_Name(i).Height / 2

      LAB_Fact(i).Y = Y * pbStats.Height
      LAB_Fact(i).Height = LAB_Height * pbStats.Height
      LAB_Fact(i).Ycenter = LAB_Fact(i).Y + LAB_Fact(i).Height / 2


      LAB_Rank(i + 1).Y = Y * pbStats.Height
      LAB_Rank(i + 1).Height = LAB_Height * pbStats.Height
      LAB_Rank(i + 1).Ycenter = LAB_Rank(i + 1).Y + LAB_Rank(i + 1).Height / 2

      LAB_Name(i + 1).Y = Y * pbStats.Height
      LAB_Name(i + 1).Height = LAB_Height * pbStats.Height
      LAB_Name(i + 1).Ycenter = LAB_Name(i + 1).Y + LAB_Name(i + 1).Height / 2

      LAB_Fact(i + 1).Y = Y * pbStats.Height
      LAB_Fact(i + 1).Height = LAB_Height * pbStats.Height
      LAB_Fact(i + 1).Ycenter = LAB_Fact(i + 1).Y + LAB_Fact(i + 1).Height / 2

      Y += YStep
    Next i

  End Sub

  Private Sub STATS_DefineX()
    '**************************************************************************************
    'R2.00 Should always calc SIZE, LayoutY, and then LayoutX so faction pics are square.
    '**************************************************************************************
    Dim i As Integer
    Dim XC1, XCoff As Integer   'R2.00 Center of each teams labels.
    Dim XF, XR, XP As Integer   'R2.00 Faction, Rank, and Player name positions.  
    Dim XWid As Integer         'R2.00 Width of label group (left or Right). 
    Dim Hgt As Integer          'R2.00 Height of Faction image so we can make it square. 
    Dim Xoff As Integer         'R2.00 Space between labels.
    Dim XRankWidth As Single    'R2.00 Width in percent of space between XR and end of name label.
    Hgt = LAB_Fact(1).Height    'R2.00 Get width of Faction image to make it square.
    XC1 = pbStats.Width / 4     'R2.00 Center of left Label group.
    XCoff = pbStats.Width / 2   'R2.00 Offset to Center of right side group. 

    'R2.00 Get the width of the label groups and space between labels.
    Select Case Val(cboLayoutX.Text)
      Case 0 : XWid = 0.6 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.35
      Case 1 : XWid = 0.7 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.3
      Case 2 : XWid = 0.8 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.25
      Case 3 : XWid = 0.9 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.2
      Case 4 : XWid = 0.96 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.15

      Case 5 : XWid = 0.6 * (pbStats.Width / 2) : Xoff = 4 : XRankWidth = 0.35
      Case 6 : XWid = 0.7 * (pbStats.Width / 2) : Xoff = 6 : XRankWidth = 0.3
      Case 7 : XWid = 0.8 * (pbStats.Width / 2) : Xoff = 8 : XRankWidth = 0.25
      Case 8 : XWid = 0.9 * (pbStats.Width / 2) : Xoff = 10 : XRankWidth = 0.2
      Case 9 : XWid = 0.96 * (pbStats.Width / 2) : Xoff = 12 : XRankWidth = 0.15

      Case 10 : XWid = 0.6 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.35
      Case 11 : XWid = 0.7 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.3
      Case 12 : XWid = 0.8 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.25
      Case 13 : XWid = 0.9 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.2
      Case 14 : XWid = 0.96 * (pbStats.Width / 2) : Xoff = 0 : XRankWidth = 0.15

      Case 15 : XWid = 0.6 * (pbStats.Width / 2) : Xoff = 4 : XRankWidth = 0.35
      Case 16 : XWid = 0.7 * (pbStats.Width / 2) : Xoff = 6 : XRankWidth = 0.3
      Case 17 : XWid = 0.8 * (pbStats.Width / 2) : Xoff = 8 : XRankWidth = 0.25
      Case 18 : XWid = 0.9 * (pbStats.Width / 2) : Xoff = 10 : XRankWidth = 0.2
      Case 19 : XWid = 0.96 * (pbStats.Width / 2) : Xoff = 12 : XRankWidth = 0.15

      Case 20 : XWid = 0.99 * ((pbStats.Width - 50) / 2) : Xoff = 0 : XRankWidth = 0.2
      Case 21 : XWid = 0.99 * ((pbStats.Width - 50) / 2) : Xoff = 10 : XRankWidth = 0.2
    End Select

    'R2.00 Calc Xfaction, Xrank, and Xplayername.
    XF = XC1 - XWid * 0.5
    XR = Xoff + (XF + Hgt)
    XP = Xoff + (XR + (XWid - XR) * XRankWidth)  'R2.00 Make RANK label some % of remaining width.

    Select Case Val(cboLayoutX.Text)
      Case Is < 10
        For i = 1 To 7 Step 2
          'R2.00 Adjust Left Group X values.
          LAB_Fact(i).X = XF
          LAB_Fact(i).Xtext = XF
          LAB_Rank(i).X = XR
          LAB_Rank(i).Xtext = XR
          LAB_Name(i).X = XP
          LAB_Name(i).Xtext = XP
          LAB_Name_Align(i).Alignment = StringAlignment.Near
          LAB_Fact(i).Width = Hgt
          LAB_Rank(i).Width = (XP - XR - Xoff)
          LAB_Name(i).Width = ((XC1 + XWid * 0.5) - XP - Xoff)

          'R2.00 Adjust Right Group X values. All values are pushed right by XCoff for right side group.
          LAB_Fact(i + 1).X = (XF + XCoff)
          LAB_Fact(i + 1).Xtext = (XF + XCoff)
          LAB_Rank(i + 1).X = (XR + XCoff)
          LAB_Rank(i + 1).Xtext = (XR + XCoff)
          LAB_Name(i + 1).X = (XP + XCoff)
          LAB_Name(i + 1).Xtext = (XP + XCoff)
          LAB_Name_Align(i + 1).Alignment = StringAlignment.Near
          LAB_Fact(i + 1).Width = Hgt
          LAB_Rank(i + 1).Width = (XP - XR - Xoff)
          LAB_Name(i + 1).Width = ((XC1 + XWid * 0.5) - XP - Xoff)
        Next i

      Case 10 To 19    'R4.46 Fixed Bug. Was 11 to 19.
        For i = 1 To 7 Step 2
          'R2.00 Adjust Left Group X values.
          LAB_Fact(i).Width = Hgt
          LAB_Rank(i).Width = (XP - XR - Xoff)
          LAB_Name(i).Width = ((XC1 + XWid * 0.5) - XP - Xoff)
          LAB_Fact(i).X = XCoff - XF - LAB_Fact(i).Width - 7
          LAB_Fact(i).Xtext = XCoff - XF - LAB_Fact(i).Width - 7
          LAB_Rank(i).X = XCoff - XR - LAB_Rank(i).Width - 7
          LAB_Rank(i).Xtext = XCoff - XR - LAB_Rank(i).Width - 7
          LAB_Name(i).X = XCoff - XP - LAB_Name(i).Width - 7
          LAB_Name(i).Xtext = XCoff - XP - LAB_Name(i).Width - 7
          LAB_Name_Align(i).Alignment = StringAlignment.Far

          'R2.00 Adjust Right Group X values. All values are pushed right by XCoff for right side group.
          LAB_Fact(i + 1).X = (XF + XCoff)
          LAB_Fact(i + 1).Xtext = (XF + XCoff)
          LAB_Rank(i + 1).X = (XR + XCoff)
          LAB_Rank(i + 1).Xtext = (XR + XCoff)
          LAB_Name(i + 1).X = (XP + XCoff)
          LAB_Name(i + 1).Xtext = (XP + XCoff)
          LAB_Fact(i + 1).Width = Hgt
          LAB_Rank(i + 1).Width = (XP - XR - Xoff)
          LAB_Name(i + 1).Width = ((XC1 + XWid * 0.5) - XP - Xoff)
          LAB_Name_Align(i + 1).Alignment = StringAlignment.Near
        Next i

      Case 20
        'R3.40 Has 80 pixel dead space in mid to go around COH2 clock at top of GUI.
        For i = 1 To 7 Step 2
          'R2.00 Adjust Right Group X values. All values are pushed right by XCoff for right side group.
          LAB_Fact(i + 1).X = 50 + XCoff
          LAB_Fact(i + 1).Xtext = LAB_Fact(i + 1).X
          LAB_Rank(i + 1).X = 50 + XCoff + Hgt
          LAB_Rank(i + 1).Xtext = LAB_Rank(i + 1).X
          LAB_Name(i + 1).X = 50 + XCoff + Hgt + (XP - XR - Xoff)
          LAB_Name(i + 1).Xtext = LAB_Name(i + 1).X
          LAB_Fact(i + 1).Width = Hgt
          LAB_Rank(i + 1).Width = (XP - XR - Xoff)
          LAB_Name(i + 1).Width = pbStats.Width - LAB_Name(i + 1).X - 10
          LAB_Name_Align(i + 1).Alignment = StringAlignment.Near

          'R2.00 Adjust Left Group X values.
          LAB_Fact(i).Width = Hgt
          LAB_Rank(i).Width = LAB_Rank(i + 1).Width
          LAB_Name(i).Width = LAB_Name(i + 1).Width
          LAB_Name(i).X = 2
          LAB_Name(i).Xtext = LAB_Name(i).X
          LAB_Name_Align(i).Alignment = StringAlignment.Far
          LAB_Rank(i).X = LAB_Name(i).X + LAB_Name(i).Width  'R4.46 changed.  XCoff - Math.Abs(LAB_Rank(i + 1).X + LAB_Rank(i).Width - XCoff)
          LAB_Rank(i).Xtext = LAB_Rank(i).X
          LAB_Fact(i).X = LAB_Rank(i).X + LAB_Rank(i).Width  'R4.46 changed.  XCoff - Math.Abs(LAB_Fact(i + 1).X + Hgt - XCoff)
          LAB_Fact(i).Xtext = LAB_Fact(i).X

        Next i

      Case 21
        'R3.40 Has 80 pixel dead space in mid to go around COH2 clock at top of GUI.
        For i = 1 To 7 Step 2
          'R2.00 Adjust Right Group X values. All values are pushed right by XCoff for right side group.
          LAB_Fact(i + 1).X = 50 + XCoff
          LAB_Fact(i + 1).Xtext = LAB_Fact(i + 1).X
          LAB_Rank(i + 1).X = 50 + XCoff + Hgt + 5
          LAB_Rank(i + 1).Xtext = LAB_Rank(i + 1).X
          LAB_Name(i + 1).X = 50 + XCoff + Hgt + 5 + (XP - XR - Xoff)
          LAB_Name(i + 1).Xtext = LAB_Name(i + 1).X
          LAB_Fact(i + 1).Width = Hgt
          LAB_Rank(i + 1).Width = (XP - XR - Xoff - 5)
          LAB_Name(i + 1).Width = pbStats.Width - LAB_Name(i + 1).X - 10
          LAB_Name_Align(i + 1).Alignment = StringAlignment.Near

          'R2.00 Adjust Left Group X values.
          LAB_Fact(i).Width = Hgt
          LAB_Rank(i).Width = LAB_Rank(i + 1).Width
          LAB_Name(i).Width = LAB_Name(i + 1).Width
          LAB_Name(i).X = 3
          LAB_Name(i).Xtext = LAB_Name(i).X
          LAB_Name_Align(i).Alignment = StringAlignment.Far
          LAB_Rank(i).X = LAB_Name(i).X + LAB_Name(i).Width + 5  'R4.46 changed.  XCoff - Math.Abs(LAB_Rank(i + 1).X + LAB_Rank(i).Width - XCoff)
          LAB_Rank(i).Xtext = LAB_Rank(i).X
          LAB_Fact(i).X = LAB_Rank(i).X + LAB_Rank(i).Width + 5  'R4.46 changed.  XCoff - Math.Abs(LAB_Fact(i + 1).X + Hgt - XCoff)
          LAB_Fact(i).Xtext = LAB_Fact(i).X
        Next i
    End Select

  End Sub

  Private Sub STATS_ClipXY(tX As Single, tY As Single)
    'R4.10 Verify and store valid sizes for STATS image.

    If tX < 10 Then tX = 980         'R4.30 Changed.
    If 10000 < tX Then tX = 10000
    STATS_SizeX = tX

    If tY < 10 Then tY = 180         'R4.30 Changed.
    If 10000 < tY Then tY = 10000
    STATS_SizeY = tY

  End Sub

  Private Sub STATS_AdjustSize()

    'R4.50 Setup STATS page size. Added IF checks.
    If pbStats.Width <> STATS_SizeX Then pbStats.Width = STATS_SizeX
    If pbStats.Height <> STATS_SizeY Then pbStats.Height = STATS_SizeY
    If scrStats.Left <> (pbStats.Left + pbStats.Width) Then scrStats.Left = pbStats.Left + pbStats.Width
    If scrStats.Height <> pbStats.Height Then scrStats.Height = pbStats.Height

  End Sub

  Private Sub cboPageSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'R3.40 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    STATS_AdjustSize()
    STATS_DefineY()
    STATS_DefineX()                   'R2.00 X gets adjusted to Y size for faction images.

    SETTINGS_Save("")
    Call SCREEN_Organize()
    Call GFX_DrawStats()

    FLAG_Drawing = False
  End Sub

  Private Sub cboLayoutY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLayoutY.SelectedIndexChanged
    'R3.40 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    STATS_DefineY()
    STATS_DefineX()                   'R2.00 X gets adjusted to Y size for faction images.

    'R4.50 Force STATS redraw.
    MainBuffer_Valid = False

    SETTINGS_Save("")
    Call GFX_DrawStats()

    FLAG_Drawing = False
  End Sub

  Private Sub cboLayoutX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLayoutX.SelectedIndexChanged
    'R3.40 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    STATS_DefineY()
    STATS_DefineX()                  'R2.00 X gets adjusted to Y size for faction images.

    'R4.50 Force STATS redraw.
    MainBuffer_Valid = False

    SETTINGS_Save("")
    Call GFX_DrawStats()

    FLAG_Drawing = False
  End Sub

  Private Sub cmSizeRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmSizeRefresh.Click

    '*****************************************************************
    'R4.30 If doing ELO cycles, calc the current Cycle to show.
    '*****************************************************************
    FLAG_EloMode += 1
    If 2 < FLAG_EloMode Then FLAG_EloMode = 0

    'R4.20 Moved sub for outside calls.
    STATS_Refresh()

  End Sub

  Private Sub STATS_Refresh()
    'R4.20 Added this sub.

    STATS_ClipXY(Val(tbXsize.Text), Val(tbYSize.Text))
    Call STATS_AdjustSize()

    STATS_DefineY()
    STATS_DefineX()                   'R2.00 X gets adjusted to Y size for faction images.

    SETTINGS_Save("")
    Call SCREEN_Organize()
    Call GFX_DrawStats()

  End Sub

  Private Sub cmNameFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim fontDialog1 As FontDialog = New FontDialog

    'R1.00 Get current font.
    fontDialog1.Font = FONT_Name

    'R1.00 Get user selected font, store it, and redraw controls.
    If fontDialog1.ShowDialog() <> DialogResult.Cancel Then
      FONT_Name = fontDialog1.Font
      FONT_Name_Name = fontDialog1.Font.Name
      FONT_Name_Size = fontDialog1.Font.Size
      FONT_Name_Bold = fontDialog1.Font.Bold
      FONT_Name_Italic = fontDialog1.Font.Italic
      SETTINGS_Save("")
    End If

    'R3.00 Update the screen stats area.
    Call GFX_DrawStats()

  End Sub

  Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    Dim A As String

    FLAG_Loading = True      'R3.00 Tell Controls not to update.

    Call STATS_AdjustSize()
    Call STATS_DefineY()
    Call STATS_DefineX()          'R2.00 X gets adjusted to Y size for faction images.
    Call SCREEN_Organize()
    Call GFX_DrawStats()

    'R4.50 Added.
    If PATH_Game = "" Then
      A = "Before MakoCELO can operate it needs to locate the warnings.log file in your COH2 My Games directory." & vbCr & vbCr
      A = A & "Click on FIND LOG FILE to search and select the directory." & vbCr & vbCr
      A = A & "Once the directory is located, match rankings can be found by either selecting "
      A = A & "CHECK LOG FILE or AUTO SCAN LOG." & vbCr & vbCr
      A = A & "Click the ABOUT button to get generic help information." & vbCr & vbCr
      MsgBox(A, MsgBoxStyle.Information)

      'R4.50 Turn on help TIPS for new users.
      chkTips.Checked = True
    End If

    FLAG_Loading = False     'R3.00 Tell Controls its OK to update.

  End Sub

  Private Sub cboScaling_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'R3.40 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    Call SETTINGS_Save("")
    Call GFX_DrawStats()

    FLAG_Drawing = False
  End Sub

  Private Sub GUI_SetDark()
    Dim CHover As Color
    Dim CFore As Color
    Dim CBack As Color
    Dim CGroupFore As Color
    Dim CLabFore As Color

    CGroupFore = Color.FromArgb(255, 255, 255, 255)
    CLabFore = Color.FromArgb(255, 192, 192, 192)

    CFore = Color.FromArgb(255, 232, 232, 232)
    CBack = Color.FromArgb(255, 48, 48, 48)
    CHover = Color.FromArgb(255, 48, 64, 48)

    Me.BackColor = Color.FromArgb(255, 32, 32, 32)
    Me.ForeColor = Color.FromArgb(255, 232, 232, 232)

    Call GUI_SetColor(CFore, CBack, CHover, CGroupFore, CLabFore)

  End Sub

  Private Sub GUI_SetLite()
    Dim CHover As Color
    Dim CFore As Color
    Dim CBack As Color
    Dim CGroupFore As Color
    Dim CLabFore As Color

    CGroupFore = Color.FromArgb(255, 0, 0, 0)
    CLabFore = Color.FromArgb(255, 32, 32, 32)

    CFore = Color.FromArgb(255, 0, 0, 0)
    CBack = Color.FromArgb(255, 232, 232, 232)
    CHover = Color.FromArgb(255, 232, 255, 232)

    Me.BackColor = Color.FromArgb(255, 232, 232, 232)
    Me.ForeColor = Color.FromArgb(255, 0, 0, 0)

    Call GUI_SetColor(CFore, CBack, CHover, CGroupFore, CLabFore)

  End Sub

  Private Sub GUI_SetColor(CFore As Color, CBack As Color, CHover As Color, CGroupFore As Color, CLabFore As Color)
    Dim Butt As Button
    Dim Labe As Label

    'R4.50 Added. 
    SS1.BackColor = CBack
    SS1.ForeColor = CFore

    'R4.00 Modified this whole sub.
    gbRank.ForeColor = CGroupFore
    gbLayout.ForeColor = CGroupFore
    gbFX.ForeColor = CGroupFore
    gbSound.ForeColor = CGroupFore

    lbTime.ForeColor = CLabFore
    Label3.ForeColor = CLabFore
    Label4.ForeColor = CLabFore
    Label5.ForeColor = CLabFore
    Label6.ForeColor = CLabFore
    Label7.ForeColor = CLabFore

    For Each cntrl As Control In gbRank.Controls
      If TypeOf cntrl Is Label Then
        Labe = CType(cntrl, Label)
        Labe.ForeColor = CLabFore
      End If
    Next

    For Each cntrl As Control In gbFX.Controls
      If TypeOf cntrl Is Label Then
        Labe = CType(cntrl, Label)
        Labe.ForeColor = CLabFore
      End If
    Next

    For Each cntrl As Control In Me.Controls
      If TypeOf cntrl Is Button Then
        Butt = CType(cntrl, Button)
        Butt.BackColor = CBack
        Butt.ForeColor = CFore
        Butt.FlatAppearance.MouseOverBackColor = CHover
      End If
    Next

    For Each cntrl As Control In gbRank.Controls
      If TypeOf cntrl Is Button Then
        Butt = CType(cntrl, Button)
        Butt.BackColor = CBack
        Butt.ForeColor = CFore
        Butt.FlatAppearance.MouseOverBackColor = CHover
      End If
    Next

    For Each cntrl As Control In gbLayout.Controls
      If TypeOf cntrl Is Button Then
        Butt = CType(cntrl, Button)
        Butt.BackColor = CBack
        Butt.ForeColor = CFore
        Butt.FlatAppearance.MouseOverBackColor = CHover
      End If
    Next

    For Each cntrl As Control In gbFX.Controls
      If TypeOf cntrl Is Button Then
        Butt = CType(cntrl, Button)
        Butt.BackColor = CBack
        Butt.ForeColor = CFore
        Butt.FlatAppearance.MouseOverBackColor = CHover
      End If
    Next

    For Each cntrl As Control In gbSound.Controls
      If TypeOf cntrl Is Button Then
        Butt = CType(cntrl, Button)
        Butt.BackColor = CBack
        Butt.ForeColor = CFore
        Butt.FlatAppearance.MouseOverBackColor = CHover
      End If
    Next

  End Sub

  Private Sub FX_GetVarStrings()
    Dim N As Integer

    N = cboFXVar1.SelectedIndex

    If 0 < N Then
      CFX3DVar(N, 1) = cboFXVar1.Text
      CFX3DVar(N, 2) = cboFXVar2.Text
      CFX3DVar(N, 3) = cboFxVar3.Text
      CFX3DVar(N, 4) = cboFxVar4.Text
    End If

  End Sub

  Private Sub FX_SetVarControls()
    Dim N As Integer

    N = cboFXVar1.SelectedIndex

    If 0 < N Then
      cboFXVar1.Text = CFX3DVar(N, 1)
      cboFXVar2.Text = CFX3DVar(N, 2)
      cboFxVar3.Text = CFX3DVar(N, 3)
      cboFxVar4.Text = CFX3DVar(N, 4)
    End If

  End Sub

  Private Sub OFFSET_Validate(ByRef Xoff As Integer, ByRef Yoff As Integer)
    Dim TX, TY As Single

    TX = Val(tbXoff.Text)
    If TX < -10000 Then TX = -10000
    If 10000 < TX Then TX = 10000
    Xoff = TX

    TY = Val(tbYoff.Text)
    If TY < -10000 Then TY = -10000
    If 10000 < TY Then TY = 10000
    Yoff = TY

  End Sub

  Private Sub GFX_DrawPlayerCard(N As Integer)
    'R4.10 OFFSET values added.
    Dim tPic As PictureBox
    Dim tLabHgt As Integer
    Dim BruRank As Brush
    Dim BruRank2 As Brush
    Dim BruName As Brush
    Dim fonRank As Font
    Dim fonName As Font
    Dim tX, tY As Integer
    Dim tFont As Font = FONT_Rank
    Dim POP(0 To 8) As Integer
    Dim Xoff, Yoff As Integer
    Dim tString As String = ""
    Dim YSec(0 To 5) As Integer
    Dim YFact(0 To 5) As Integer
    Dim YStart(0 To 5) As Integer
    Dim XSec(0 To 10) As Integer
    Dim Ysec4 As Integer
    Dim Xmid As Integer = pbStats.Width * 0.5

    'R3.00 Precalc some vars for readability in code.
    tLabHgt = LAB_Rank(1).Height \ 2

    'R4.30 Calc Y for each section.
    YFact(1) = (pbStats.Height / 3) * 0.5 - tLabHgt
    YFact(2) = (pbStats.Height / 3) * 0.5 + (pbStats.Height / 3) - tLabHgt
    YFact(3) = (pbStats.Height / 3) * 0.5 + (pbStats.Height / 3) + (pbStats.Height / 3) - tLabHgt
    YFact(4) = (pbStats.Height / 3) * 0.5 - tLabHgt
    YFact(5) = (pbStats.Height / 3) * 0.5 + (pbStats.Height / 3) - tLabHgt

    YSec(1) = (pbStats.Height / 3) * 0
    YSec(2) = (pbStats.Height / 3) * 0.2
    YSec(3) = (pbStats.Height / 3) * 0.4
    YSec(4) = (pbStats.Height / 3) * 0.6
    YSec(5) = (pbStats.Height / 3) * 0.8

    Ysec4 = (pbStats.Height / 3) * 0.25

    YStart(1) = 0
    YStart(2) = (pbStats.Height / 3)
    YStart(3) = (pbStats.Height / 3) * 2
    YStart(4) = 0
    YStart(5) = (pbStats.Height / 3)


    XSec(1) = LAB_Fact(1).Width + 10
    XSec(2) = LAB_Fact(1).Width + 10 + (pbStats.Width * 0.4) * 0.2
    XSec(3) = LAB_Fact(1).Width + 10 + (pbStats.Width * 0.4) * 0.4
    XSec(4) = LAB_Fact(1).Width + 10 + (pbStats.Width * 0.4) * 0.6
    XSec(5) = LAB_Fact(1).Width + 10 + (pbStats.Width * 0.4) * 0.8
    XSec(6) = pbStats.Width * 0.5 + XSec(1)
    XSec(7) = pbStats.Width * 0.5 + XSec(2)
    XSec(8) = pbStats.Width * 0.5 + XSec(3)
    XSec(9) = pbStats.Width * 0.5 + XSec(4)
    XSec(10) = pbStats.Width * 0.5 + XSec(5)

    fonRank = New Font("arial", CSng(pbStats.Width * 0.008), FontStyle.Regular)
    fonName = New Font("arial", CSng(pbStats.Width * 0.008), FontStyle.Regular)

    'R4.10 Get STATS offsets.
    Call OFFSET_Validate(Xoff, Yoff)

    'R4.32 Adjust our working BMP if needed.
    Call STATS_AdjustSize()
    If (Main_BM.Width <> pbStats.Width) Or (Main_BM.Height <> pbStats.Height) Then
      Main_BM = New Bitmap(pbStats.Width, pbStats.Height)
      Main_Gfx = Graphics.FromImage(Main_BM)
    End If
    Main_Gfx.Clear(LSName.BackC)

    '*****************************************************************
    'R3.00 Draw the stats page background.
    '*****************************************************************
    If (NAME_bmp Is Nothing) Or (LSName.UseCardBack = False) Then
      'R3.00 No image available so draw a solid color background.
      Main_Gfx.FillRectangle(New SolidBrush(LSName.BackC), 0, 0, pbStats.Width, pbStats.Height)
    Else
      'R3.00 Scale and Draw the background image.
      Select Case Val(LSName.Scaling)
        Case 0   'R3.00 Normal Scaling
          Main_Gfx.DrawImage(NAME_bmp, 0, 0, NAME_bmp.Width, NAME_bmp.Height)
        Case 1   'R3.00 Tiled Scaling
          For tY = 0 To Main_BM.Height Step NAME_bmp.Height
            For tX = 0 To Main_BM.Width Step NAME_bmp.Width
              Main_Gfx.DrawImage(NAME_bmp, tX, tY, NAME_bmp.Width, NAME_bmp.Height)
            Next
          Next
        Case 2 'R3.00 Stretch/Fit Scaling
          Main_Gfx.DrawImage(NAME_bmp, 0, 0, Main_BM.Width, Main_BM.Height)
      End Select
    End If


    '*****************************************************************
    'Draw the Faction images to the stats page.
    '***************************************************************** 
    BruRank = New SolidBrush(LSRank.F1)
    BruRank2 = New SolidBrush(LSRank.F2)
    BruName = New SolidBrush(LSName.F1)

    For t = 1 To 3
      tPic = CType(Me.Controls("pbFact0" & t.ToString), PictureBox)
      Main_Gfx.DrawImage(tPic.Image, 0, YFact(t), LAB_Fact(t).Width, LAB_Fact(t).Height)
      If t = 1 Then
        Main_Gfx.DrawString("Mode", fonRank, BruRank, XSec(1), YStart(t) + YSec(1))
        Main_Gfx.DrawString("Rank", fonRank, BruRank, XSec(2), YStart(t) + YSec(1))
        Main_Gfx.DrawString("Win", fonRank, BruRank, XSec(3), YStart(t) + YSec(1))
        Main_Gfx.DrawString("Loss", fonRank, BruRank, XSec(4), YStart(t) + YSec(1))
        Main_Gfx.DrawString("%", fonRank, BruRank, XSec(5), YStart(t) + YSec(1))
      End If

      Main_Gfx.DrawString("1v1", fonRank, BruRank2, XSec(1), YStart(t) + YSec(2))
      If PlrRankALL(N, t, 1) <> 0 Then Main_Gfx.DrawString(PlrRankALL(N, t, 1), fonRank, BruName, XSec(2), YStart(t) + YSec(2))
      Main_Gfx.DrawString(PlrRankWin(N, t, 1), fonRank, BruName, XSec(3), YStart(t) + YSec(2))
      Main_Gfx.DrawString(PlrRankLoss(N, t, 1), fonRank, BruName, XSec(4), YStart(t) + YSec(2))
      Main_Gfx.DrawString(PlrRankPerc(N, t, 1), fonRank, BruName, XSec(5), YStart(t) + YSec(2))
      Main_Gfx.DrawString("2v2", fonRank, BruRank2, XSec(1), YStart(t) + YSec(3))
      If PlrRankALL(N, t, 2) <> 0 Then Main_Gfx.DrawString(PlrRankALL(N, t, 2), fonRank, BruName, XSec(2), YStart(t) + YSec(3))
      Main_Gfx.DrawString(PlrRankWin(N, t, 2), fonRank, BruName, XSec(3), YStart(t) + YSec(3))
      Main_Gfx.DrawString(PlrRankLoss(N, t, 2), fonRank, BruName, XSec(4), YStart(t) + YSec(3))
      Main_Gfx.DrawString(PlrRankPerc(N, t, 2), fonRank, BruName, XSec(5), YStart(t) + YSec(3))
      Main_Gfx.DrawString("3v3", fonRank, BruRank2, XSec(1), YStart(t) + YSec(4))
      If PlrRankALL(N, t, 3) <> 0 Then Main_Gfx.DrawString(PlrRankALL(N, t, 3), fonRank, BruName, XSec(2), YStart(t) + YSec(4))
      Main_Gfx.DrawString(PlrRankWin(N, t, 3), fonRank, BruName, XSec(3), YStart(t) + YSec(4))
      Main_Gfx.DrawString(PlrRankLoss(N, t, 3), fonRank, BruName, XSec(4), YStart(t) + YSec(4))
      Main_Gfx.DrawString(PlrRankPerc(N, t, 3), fonRank, BruName, XSec(5), YStart(t) + YSec(4))
      Main_Gfx.DrawString("4v4", fonRank, BruRank2, XSec(1), YStart(t) + YSec(5))
      If PlrRankALL(N, t, 4) <> 0 Then Main_Gfx.DrawString(PlrRankALL(N, t, 4), fonRank, BruName, XSec(2), YStart(t) + YSec(5))
      Main_Gfx.DrawString(PlrRankWin(N, t, 4), fonRank, BruName, XSec(3), YStart(t) + YSec(5))
      Main_Gfx.DrawString(PlrRankLoss(N, t, 4), fonRank, BruName, XSec(4), YStart(t) + YSec(5))
      Main_Gfx.DrawString(PlrRankPerc(N, t, 4), fonRank, BruName, XSec(5), YStart(t) + YSec(5))
    Next
    For t = 4 To 5
      tPic = CType(Me.Controls("pbFact0" & t.ToString), PictureBox)
      Main_Gfx.DrawImage(tPic.Image, Xmid, YFact(t), LAB_Fact(t).Width, LAB_Fact(t).Height)

      If t = 4 Then
        Main_Gfx.DrawString("Mode", fonRank, BruRank, XSec(6), YStart(t) + YSec(1))
        Main_Gfx.DrawString("Rank", fonRank, BruRank, XSec(7), YStart(t) + YSec(1))
        Main_Gfx.DrawString("Win", fonRank, BruRank, XSec(8), YStart(t) + YSec(1))
        Main_Gfx.DrawString("Loss", fonRank, BruRank, XSec(9), YStart(t) + YSec(1))
        Main_Gfx.DrawString("%", fonRank, BruRank, XSec(10), YStart(t) + YSec(1))
      End If

      Main_Gfx.DrawString("1v1", fonRank, BruRank2, XSec(6), YStart(t) + YSec(2))
      If PlrRankALL(N, t, 1) <> 0 Then Main_Gfx.DrawString(PlrRankALL(N, t, 1), fonRank, BruName, XSec(7), YStart(t) + YSec(2))
      Main_Gfx.DrawString(PlrRankWin(N, t, 1), fonRank, BruName, XSec(8), YStart(t) + YSec(2))
      Main_Gfx.DrawString(PlrRankLoss(N, t, 1), fonRank, BruName, XSec(9), YStart(t) + YSec(2))
      Main_Gfx.DrawString(PlrRankPerc(N, t, 1), fonRank, BruName, XSec(10), YStart(t) + YSec(2))
      Main_Gfx.DrawString("2v2", fonRank, BruRank2, XSec(6), YStart(t) + YSec(3))
      If PlrRankALL(N, t, 2) <> 0 Then Main_Gfx.DrawString(PlrRankALL(N, t, 2), fonRank, BruName, XSec(7), YStart(t) + YSec(3))
      Main_Gfx.DrawString(PlrRankWin(N, t, 2), fonRank, BruName, XSec(8), YStart(t) + YSec(3))
      Main_Gfx.DrawString(PlrRankLoss(N, t, 2), fonRank, BruName, XSec(9), YStart(t) + YSec(3))
      Main_Gfx.DrawString(PlrRankPerc(N, t, 2), fonRank, BruName, XSec(10), YStart(t) + YSec(3))
      Main_Gfx.DrawString("3v3", fonRank, BruRank2, XSec(6), YStart(t) + YSec(4))
      If PlrRankALL(N, t, 3) <> 0 Then Main_Gfx.DrawString(PlrRankALL(N, t, 3), fonRank, BruName, XSec(7), YStart(t) + YSec(4))
      Main_Gfx.DrawString(PlrRankWin(N, t, 3), fonRank, BruName, XSec(8), YStart(t) + YSec(4))
      Main_Gfx.DrawString(PlrRankLoss(N, t, 3), fonRank, BruName, XSec(9), YStart(t) + YSec(4))
      Main_Gfx.DrawString(PlrRankPerc(N, t, 3), fonRank, BruName, XSec(10), YStart(t) + YSec(4))
      Main_Gfx.DrawString("4v4", fonRank, BruRank2, XSec(6), YStart(t) + YSec(5))
      If PlrRankALL(N, t, 4) <> 0 Then Main_Gfx.DrawString(PlrRankALL(N, t, 4), fonRank, BruName, XSec(7), YStart(t) + YSec(5))
      Main_Gfx.DrawString(PlrRankWin(N, t, 4), fonRank, BruName, XSec(8), YStart(t) + YSec(5))
      Main_Gfx.DrawString(PlrRankLoss(N, t, 4), fonRank, BruName, XSec(9), YStart(t) + YSec(5))
      Main_Gfx.DrawString(PlrRankPerc(N, t, 4), fonRank, BruName, XSec(10), YStart(t) + YSec(5))
    Next

    Main_Gfx.DrawString("Player: " & PlrName(N), fonRank, BruRank, XSec(6), YStart(3) + YSec(2))
    'R4.46 Removed.   Main_Gfx.DrawString("RelicID: " & PlrRID(N), fonRank, BruRank, XSec(6), YStart(3) + YSec(3))
    Main_Gfx.DrawString("Left Click to exit, Right Click for teams", fonRank, BruName, XSec(6), YStart(3) + YSec(4))

    Main_Gfx.DrawString("Team Win: " & PlrTWin(N), fonRank, BruRank, XSec(9), YStart(3) + YSec(2))
    Main_Gfx.DrawString("Team Loss: " & PlrTLoss(N), fonRank, BruRank, XSec(9), YStart(3) + YSec(3))
    Main_Gfx.DrawString("Team: " & PlrTeam(N), fonRank, BruRank, XSec(9), YStart(3) + YSec(4))

    'R4.45 Added country flags.
    If PlrCountry(N) <> "" Then
      Dim BM_Country = My.Resources.ResourceManager.GetObject("flag_" & PlrCountry(N))
      If Not IsNothing(BM_Country) Then Main_Gfx.DrawImage(BM_Country, New Point(XSec(6) - 20, YStart(3) + YSec(2)))
      Main_Gfx.DrawString(PlrCountry(N), fonRank, BruRank, XSec(6) - 20, YStart(3) + YSec(3))
      Main_Gfx.DrawString("Country: " & PlrCountryName(N), fonRank, BruRank, XSec(6), YStart(3) + YSec(3))   'R4.46 Added.
    End If


    pbStats.Image = Main_BM

  End Sub

  Private Sub GFX_DrawTeams(N As Integer)
    'R4.10 OFFSET values added.
    Dim A As String
    Dim tLabHgt As Integer
    Dim BruRank As Brush
    Dim BruRank2 As Brush
    Dim BruName As Brush
    Dim fonRank As Font
    Dim fonName As Font
    Dim tX, tY As Integer
    Dim tFont As Font = FONT_Rank
    Dim POP(0 To 8) As Integer
    Dim Xoff As Integer = 0
    Dim Yoff As Integer = 0
    Dim YAct As Integer
    Dim tString As String = ""
    Dim Xmid As Integer = pbStats.Width * 0.5

    'R3.00 Precalc some vars for readability in code.
    tLabHgt = LAB_Rank(1).Height \ 2

    fonRank = New Font("arial", CSng(pbStats.Width * 0.008), FontStyle.Regular)
    fonName = New Font("arial", CSng(pbStats.Width * 0.008), FontStyle.Regular)

    'R4.32 Adjust our working BMP if needed.
    Call STATS_AdjustSize()
    If (Main_BM.Width <> pbStats.Width) Or (Main_BM.Height <> pbStats.Height) Then
      Main_BM = New Bitmap(pbStats.Width, pbStats.Height)
      Main_Gfx = Graphics.FromImage(Main_BM)
    End If
    Main_Gfx.Clear(LSName.BackC)

    '*****************************************************************
    'R3.00 Draw the stats page background.
    '*****************************************************************
    If (NAME_bmp Is Nothing) Or (LSName.UseCardBack = False) Then
      'R3.00 No image available so draw a solid color background.
      Main_Gfx.FillRectangle(New SolidBrush(LSName.BackC), 0, 0, pbStats.Width, pbStats.Height)
    Else
      'R3.00 Scale and Draw the background image.
      Select Case Val(LSName.Scaling)
        Case 0   'R3.00 Normal Scaling
          Main_Gfx.DrawImage(NAME_bmp, 0, 0, NAME_bmp.Width, NAME_bmp.Height)
        Case 1   'R3.00 Tiled Scaling
          For tY = 0 To Main_BM.Height Step NAME_bmp.Height
            For tX = 0 To Main_BM.Width Step NAME_bmp.Width
              Main_Gfx.DrawImage(NAME_bmp, tX, tY, NAME_bmp.Width, NAME_bmp.Height)
            Next
          Next
        Case 2 'R3.00 Stretch/Fit Scaling
          Main_Gfx.DrawImage(NAME_bmp, 0, 0, Main_BM.Width, Main_BM.Height)
      End Select
    End If

    '*****************************************************************
    'Draw the Faction images to the stats page.
    '***************************************************************** 
    BruRank = New SolidBrush(LSRank.F1)
    BruRank2 = New SolidBrush(LSRank.F2)
    BruName = New SolidBrush(LSName.F1)

    Yoff = scrStats.Value * -1 '* -75

    'R4.40 Loop thru TEAM lists and draw them until we are off screen.
    For t = 1 To TeamListCnt(N)
      YAct = Yoff + (t - 1) * 90
      If (pbStats.Height < (YAct)) Then Exit For
      If (-91 < YAct) Then
        Main_Gfx.DrawString(t.ToString(), fonRank, BruName, 10, YAct)
        Main_Gfx.DrawString("Team of ", fonRank, BruRank, 45, YAct)
        Main_Gfx.DrawString(TeamList(N, t).PlrCnt, fonRank, BruName, 90, YAct)
        Main_Gfx.DrawString("Allies:", fonRank, BruRank, 120, YAct)
        Main_Gfx.DrawString("Axis:", fonRank, BruRank, 260, YAct)

        A = " (" & TeamList(N, t).WinAllies & "," & TeamList(N, t).LossAllies & ")"
        Select Case TeamList(N, t).RankAllies
          Case -1 : Main_Gfx.DrawString("P" & A, fonRank, BruName, 160, YAct)
          Case 0 : Main_Gfx.DrawString("---" & A, fonRank, BruName, 160, YAct)
          Case Else : Main_Gfx.DrawString(TeamList(N, t).RankAllies & A, fonRank, BruName, 160, YAct)
        End Select

        A = " (" & TeamList(N, t).WinAxis & "," & TeamList(N, t).LossAxis & ")"
        Select Case TeamList(N, t).RankAxis
          Case -1 : Main_Gfx.DrawString("P" & A, fonRank, BruName, 290, YAct)
          Case 0 : Main_Gfx.DrawString("---" & A, fonRank, BruName, 290, YAct)
          Case Else : Main_Gfx.DrawString(TeamList(N, t).RankAxis & A, fonRank, BruName, 290, YAct)
        End Select

        Main_Gfx.DrawString("1:", fonRank, BruRank2, 10, YAct + 15)
        Main_Gfx.DrawString("2:", fonRank, BruRank2, 10, YAct + 30)
        Main_Gfx.DrawString("3:", fonRank, BruRank2, 10, YAct + 45)
        Main_Gfx.DrawString("4:", fonRank, BruRank2, 10, YAct + 60)
        Main_Gfx.DrawString(TeamList(N, t).PLR1, fonRank, BruName, 25, YAct + 15)
        Main_Gfx.DrawString(TeamList(N, t).PLR2, fonRank, BruName, 25, YAct + 30)
        Main_Gfx.DrawString(TeamList(N, t).PLR3, fonRank, BruName, 25, YAct + 45)
        Main_Gfx.DrawString(TeamList(N, t).PLR4, fonRank, BruName, 25, YAct + 60)
      End If
    Next t

    Main_Gfx.DrawString("PREMADE TEAM RANKS", fonRank, BruRank2, 500, 0)
    Main_Gfx.DrawString("Player: " & PlrName(N), fonRank, BruRank, 500, 15)
    Main_Gfx.DrawString("RelicID: " & PlrRID(N), fonRank, BruRank, 500, 30)
    Main_Gfx.DrawString("Click the screen again to exit", fonRank, BruName, 500, 45)

    pbStats.Image = Main_BM

  End Sub

  Private Sub GFX_BuildStatsBackground()
    'R4.10 OFFSET values added.
    Dim tLabHgt As Integer
    Dim linGrBrush As Drawing2D.LinearGradientBrush
    Dim tX, tY As Integer
    Dim tFont As Font = FONT_Rank
    Dim POP(0 To 8) As Integer
    Dim Xoff, Yoff As Integer
    Dim tString As String = ""
    Dim tPen As Pen

    'R3.00 Precalc some vars for readability in code.
    tLabHgt = LAB_Rank(1).Height \ 2

    'R4.10 Get STATS offsets.
    Call OFFSET_Validate(Xoff, Yoff)

    '*****************************************************************
    'R3.00 Draw the stats page background.
    '*****************************************************************
    If NAME_bmp Is Nothing Then
      'R3.00 No image available so draw a solid color background.
      Main_Gfx.FillRectangle(New SolidBrush(LSName.BackC), 0, 0, pbStats.Width, pbStats.Height)
    Else
      'R3.00 Scale and Draw the background image.
      Select Case Val(LSName.Scaling)
        Case 0   'R3.00 Normal Scaling
          Main_Gfx.DrawImage(NAME_bmp, 0, 0, NAME_bmp.Width, NAME_bmp.Height)
        Case 1   'R3.00 Tiled Scaling
          For tY = 0 To Main_BM.Height Step NAME_bmp.Height
            For tX = 0 To Main_BM.Width Step NAME_bmp.Width
              Main_Gfx.DrawImage(NAME_bmp, tX, tY, NAME_bmp.Width, NAME_bmp.Height)
            Next
          Next
        Case 2 'R3.00 Stretch/Fit Scaling
          Main_Gfx.DrawImage(NAME_bmp, 0, 0, Main_BM.Width, Main_BM.Height)
      End Select
    End If

    Select Case LSRank.BorderPanelMode
      Case 0  'R4.40 No border.
      Case 1 'R4.40 Normal.
        'Main_Gfx.draw
        tPen = New Pen(New SolidBrush(LSRank.BorderPanelColor))
        tPen.Width = LSRank.BorderPanelWidth
        Main_Gfx.DrawRectangle(tPen, 2, 2, Main_BM.Width - 5, Main_BM.Height - 5)
      Case 2 'R4.40 Glow
        Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(255, LSRank.BorderPanelColor.R, LSRank.BorderPanelColor.G, LSRank.BorderPanelColor.B))), 2, 2, Main_BM.Width - 5, Main_BM.Height - 5)
        Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(192, LSRank.BorderPanelColor.R, LSRank.BorderPanelColor.G, LSRank.BorderPanelColor.B))), 3, 3, Main_BM.Width - 7, Main_BM.Height - 7)
        Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(128, LSRank.BorderPanelColor.R, LSRank.BorderPanelColor.G, LSRank.BorderPanelColor.B))), 4, 4, Main_BM.Width - 9, Main_BM.Height - 9)
        Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(64, LSRank.BorderPanelColor.R, LSRank.BorderPanelColor.G, LSRank.BorderPanelColor.B))), 5, 5, Main_BM.Width - 11, Main_BM.Height - 11)
        Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(32, LSRank.BorderPanelColor.R, LSRank.BorderPanelColor.G, LSRank.BorderPanelColor.B))), 6, 6, Main_BM.Width - 13, Main_BM.Height - 13)
      Case 3 'R4.40 3D
        Main_Gfx.DrawLine(New Pen(New SolidBrush(LSRank.BorderPanelColor)), 2, 2, Main_BM.Width - 3, 2)
        Main_Gfx.DrawLine(New Pen(New SolidBrush(LSRank.BorderPanelColor)), 2, 2, 2, Main_BM.Height - 3)
        Main_Gfx.DrawLine(New Pen(New SolidBrush(Color.FromArgb(255, 0, 0, 0))), 2, Main_BM.Height - 3, Main_BM.Width - 3, Main_BM.Height - 3)
        Main_Gfx.DrawLine(New Pen(New SolidBrush(Color.FromArgb(255, 0, 0, 0))), Main_BM.Width - 3, 2, Main_BM.Width - 3, Main_BM.Height - 2)
      Case 4 'R4.40 Rounded Corners 4 pixels.
        tPen = New Pen(New SolidBrush(LSRank.BorderPanelColor))
        tPen.Width = LSRank.BorderPanelWidth
        DrawRoundedRectangle(Main_Gfx, New Rectangle(2, 2, Main_BM.Width - 5, Main_BM.Height - 5), tPen, 4)
      Case 5 'R4.40 Rounded Corners 8 pixels.
        tPen = New Pen(New SolidBrush(LSRank.BorderPanelColor))
        tPen.Width = LSRank.BorderPanelWidth
        DrawRoundedRectangle(Main_Gfx, New Rectangle(2, 2, Main_BM.Width - 5, Main_BM.Height - 5), tPen, 8)
      Case 6 'R4.40 Rounded Corners LARGE.
        tPen = New Pen(New SolidBrush(LSRank.BorderPanelColor))
        tPen.Width = LSRank.BorderPanelWidth
        DrawRoundedRectangle_Max(Main_Gfx, New Rectangle(2, 2, Main_BM.Width - 5, Main_BM.Height - 5), tPen)
    End Select

    '*****************************************************************
    'R3.10 Call any background based FX MODE options like SHADOW, etc
    '*****************************************************************
    If CFX3DActive(clsGlobal.FXMode.LabelBlur) Then Call GFX_FX_LabBlur(Main_Gfx, Main_BM, Xoff, Yoff)

    '*****************************************************************
    'R3.10 Draw the Rank background rectangles
    '*****************************************************************
    Dim tBrush As SolidBrush = New SolidBrush(LSRank.B1)        'R3.40  Color of Rank Back 1.
    Dim tBrushFore As SolidBrush = New SolidBrush(LSRank.F1)    'R3.40  Color of Rank Fore 1.

    For T = 1 To 8
      If (Not FLAG_HideMissing) Or (PlrName(T) <> "") Or (PlrSteam(T) <> "") Then
        'R3.00 Draw the RANK background rectangle.
        If LSRank.BDir = 0 Then
          linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + 0, Yoff + LAB_Rank(T).Y - 1), New Point(Xoff + 0, Yoff + LAB_Rank(T).Y + LAB_Rank(T).Height + 1), LSRank.B1, LSRank.B2)
        Else
          linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + LAB_Rank(T).X - 1, Yoff + 0), New Point(Xoff + LAB_Rank(T).X + LAB_Rank(T).Width + 1, Yoff + 0), LSRank.B1, LSRank.B2)
        End If

        'R4.40 Added BORDERS.
        Select Case LSRank.BorderMode
          Case 0  'R4.40 No border.
            Main_Gfx.FillRectangle(linGrBrush, Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height)
          Case 1 'R4.40 Normal.
            Main_Gfx.FillRectangle(linGrBrush, Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height)
            tPen = New Pen(New SolidBrush(LSRank.BorderColor))
            tPen.Width = LSRank.BorderWidth
            Main_Gfx.DrawRectangle(tPen, Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height)
          Case 2 'R4.40 Glow
            Main_Gfx.FillRectangle(linGrBrush, Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height)
            Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(255, LSRank.BorderColor.R, LSRank.BorderColor.G, LSRank.BorderColor.B))), Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width - 1, LAB_Rank(T).Height - 1)
            Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(192, LSRank.BorderColor.R, LSRank.BorderColor.G, LSRank.BorderColor.B))), Xoff + LAB_Rank(T).X + 1, Yoff + LAB_Rank(T).Y + 1, LAB_Rank(T).Width - 3, LAB_Rank(T).Height - 3)
            Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(64, LSRank.BorderColor.R, LSRank.BorderColor.G, LSRank.BorderColor.B))), Xoff + LAB_Rank(T).X + 2, Yoff + LAB_Rank(T).Y + 2, LAB_Rank(T).Width - 5, LAB_Rank(T).Height - 5)
          Case 3 'R4.40 3D
            Main_Gfx.FillRectangle(linGrBrush, Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height)
            tPen = New Pen(New SolidBrush(LSRank.BorderColor))
            tPen.Width = LSRank.BorderWidth
            Main_Gfx.DrawLine(tPen, Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, Xoff + LAB_Rank(T).X + LAB_Rank(T).Width - 1, Yoff + LAB_Rank(T).Y)
            Main_Gfx.DrawLine(tPen, Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y + LAB_Rank(T).Height - 1)
            tPen = New Pen(New SolidBrush(Color.FromArgb(255, 0, 0, 0)))
            tPen.Width = LSRank.BorderWidth
            Main_Gfx.DrawLine(tPen, Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y + LAB_Rank(T).Height, Xoff + LAB_Rank(T).X + LAB_Rank(T).Width, Yoff + LAB_Rank(T).Y + LAB_Rank(T).Height)
            Main_Gfx.DrawLine(tPen, Xoff + LAB_Rank(T).X + LAB_Rank(T).Width, Yoff + LAB_Rank(T).Y, Xoff + LAB_Rank(T).X + LAB_Rank(T).Width, Yoff + LAB_Rank(T).Y + LAB_Rank(T).Height)
          Case 4 'R4.40 Rounded Corners 4 pixels.
            FillRoundedRectangle(Main_Gfx, New Rectangle(Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height), linGrBrush, 4)
            tPen = New Pen(New SolidBrush(LSRank.BorderColor))
            tPen.Width = LSRank.BorderWidth
            DrawRoundedRectangle(Main_Gfx, New Rectangle(Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height), tPen, 4)
          Case 5 'R4.40 Rounded Corners 8 pixels.
            FillRoundedRectangle(Main_Gfx, New Rectangle(Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height), linGrBrush, 8)
            tPen = New Pen(New SolidBrush(LSRank.BorderColor))
            tPen.Width = LSRank.BorderWidth
            DrawRoundedRectangle(Main_Gfx, New Rectangle(Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height), tPen, 8)
          Case 6 'R4.40 Rounded Corners LARGE.
            FillRoundedRectangle_Max(Main_Gfx, New Rectangle(Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height), linGrBrush)
            tPen = New Pen(New SolidBrush(LSRank.BorderColor))
            tPen.Width = LSRank.BorderWidth
            DrawRoundedRectangle_Max(Main_Gfx, New Rectangle(Xoff + LAB_Rank(T).X, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width, LAB_Rank(T).Height), tPen)
        End Select
      End If
    Next

    '*****************************************************************
    'R3.10 Draw the Name background rectangles
    '*****************************************************************  
    tBrush = New SolidBrush(LSName.B1)             'R3.40  Color of Name Back 1.
    tBrushFore = New SolidBrush(LSName.F1)         'R3.40  Color of Name Fore 1.

    For T = 1 To 8
      If (Not FLAG_HideMissing) Or (PlrName(T) <> "") Then
        'R3.00 Draw the NAME background rectangle.
        If LSName.BDir = 0 Then
          linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + 0, Yoff + LAB_Name(T).Y - 1), New Point(Xoff + 0, Yoff + LAB_Name(T).Y + LAB_Name(T).Height + 1), LSName.B1, LSName.B2)
        Else
          'R3.40 Reverse gradient direction for RIGHT justified text.
          If LAB_Name_Align(T).Alignment = StringAlignment.Far Then
            linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + LAB_Name(T).X + LAB_Name(T).Width + 1, Yoff + 0), New Point(Xoff + LAB_Name(T).X - 1, Yoff + 0), LSName.B1, LSName.B2)
          Else
            linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + LAB_Name(T).X - 1, Yoff + 0), New Point(Xoff + LAB_Name(T).X + LAB_Name(T).Width + 1, Yoff + 0), LSName.B1, LSName.B2)
          End If
        End If

        Select Case LSName.BorderMode
          Case 0
            Main_Gfx.FillRectangle(linGrBrush, Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height)
          Case 1 'R4.40 Normal.
            Main_Gfx.FillRectangle(linGrBrush, Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height)
            tPen = New Pen(New SolidBrush(LSName.BorderColor))
            tPen.Width = LSName.BorderWidth
            Main_Gfx.DrawRectangle(tPen, Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height)
          Case 2 'R4.40 Glow
            Main_Gfx.FillRectangle(linGrBrush, Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height)
            Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(255, LSName.BorderColor.R, LSName.BorderColor.G, LSName.BorderColor.B))), Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width - 1, LAB_Name(T).Height - 1)
            Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(192, LSName.BorderColor.R, LSName.BorderColor.G, LSName.BorderColor.B))), Xoff + LAB_Name(T).X + 1, Yoff + LAB_Name(T).Y + 1, LAB_Name(T).Width - 3, LAB_Name(T).Height - 3)
            Main_Gfx.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(64, LSName.BorderColor.R, LSName.BorderColor.G, LSName.BorderColor.B))), Xoff + LAB_Name(T).X + 2, Yoff + LAB_Name(T).Y + 2, LAB_Name(T).Width - 5, LAB_Name(T).Height - 5)
          Case 3 'R4.40 3D
            Main_Gfx.FillRectangle(linGrBrush, Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height)
            tPen = New Pen(New SolidBrush(LSName.BorderColor))
            tPen.Width = LSName.BorderWidth
            Main_Gfx.DrawLine(tPen, Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, Xoff + LAB_Name(T).X + LAB_Name(T).Width - 1, Yoff + LAB_Name(T).Y)
            Main_Gfx.DrawLine(tPen, Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y + LAB_Name(T).Height - 1)
            tPen = New Pen(New SolidBrush(Color.FromArgb(255, 0, 0, 0)))
            tPen.Width = LSName.BorderWidth
            Main_Gfx.DrawLine(tPen, Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y + LAB_Name(T).Height, Xoff + LAB_Name(T).X + LAB_Name(T).Width - 1, Yoff + LAB_Name(T).Y + LAB_Name(T).Height)
            Main_Gfx.DrawLine(tPen, Xoff + LAB_Name(T).X + LAB_Name(T).Width, Yoff + LAB_Name(T).Y, Xoff + LAB_Name(T).X + LAB_Name(T).Width, Yoff + LAB_Name(T).Y + LAB_Name(T).Height - 1)
          Case 4 'R4.40 Rounded Corners 4 pixels.
            FillRoundedRectangle(Main_Gfx, New Rectangle(Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height), linGrBrush, 4)
            tPen = New Pen(New SolidBrush(LSName.BorderColor))
            tPen.Width = LSName.BorderWidth
            DrawRoundedRectangle(Main_Gfx, New Rectangle(Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height), tPen, 4)
          Case 5 'R4.40 Rounded Corners 8 pixels.
            FillRoundedRectangle(Main_Gfx, New Rectangle(Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height), linGrBrush, 8)
            tPen = New Pen(New SolidBrush(LSName.BorderColor))
            tPen.Width = LSName.BorderWidth
            DrawRoundedRectangle(Main_Gfx, New Rectangle(Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height), tPen, 8)
          Case 6 'R4.40 Rounded Corners LARGE.
            FillRoundedRectangle_Max(Main_Gfx, New Rectangle(Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height), linGrBrush)
            tPen = New Pen(New SolidBrush(LSName.BorderColor))
            tPen.Width = LSName.BorderWidth
            DrawRoundedRectangle_Max(Main_Gfx, New Rectangle(Xoff + LAB_Name(T).X, Yoff + LAB_Name(T).Y, LAB_Name(T).Width, LAB_Name(T).Height), tPen)
        End Select
      End If
    Next

    'R4.50 Save the background image we just created for fast draws later.
    MainBuffer_BM = New Bitmap(pbStats.Width, pbStats.Height)
    MainBuffer_Gfx = Graphics.FromImage(MainBuffer_BM)
    MainBuffer_Gfx.DrawImage(Main_BM, 0, 0)
    MainBuffer_Valid = True


  End Sub

  Private Sub GFX_BuildStatsForeground()
    'R4.10 OFFSET values added.
    Dim tLabHgt As Integer
    Dim linGrBrush As Drawing2D.LinearGradientBrush
    Dim tX, tY As Integer
    Dim tFont As Font = FONT_Rank
    Dim POP(0 To 8) As Integer
    Dim Xoff, Yoff As Integer
    Dim tString As String = ""
    Dim Cx, Cy As Integer
    Dim TextHgt12 As Integer
    Dim tPic As PictureBox

    'R3.00 Precalc some vars for readability in code.
    tLabHgt = LAB_Rank(1).Height \ 2

    'R4.10 Get STATS offsets.
    Call OFFSET_Validate(Xoff, Yoff)

    '*****************************************************************
    'R3.10 Call any MID draw based FX MODE options like SHADOW, etc
    '*****************************************************************
    If CFX3DActive(clsGlobal.FXMode.Shadow) Then Call GFX_FX_Shadow(Main_Gfx, Xoff, Yoff)

    '*****************************************************************
    'R3.00 Define paint/fill brushes for the RANK stats.
    '*****************************************************************
    Dim tBrush = New SolidBrush(LSRank.F1)         'R3.40  Color of Rank Back 1.
    Dim tBrushFore = New SolidBrush(LSRank.F1)     'R3.40  Color of Rank Fore 1.
    Dim tBrushShadow = New SolidBrush(LSRank.ShadowColor)
    TextHgt12 = Main_Gfx.MeasureString("X", FONT_Rank).Height / 2    'R3.30 Calc height of gradient color.  'R3.30Changed from Xq.

    For T = 1 To 8
      If FLAG_EloUse = False Then
        tString = PlrRank(T)
      Else
        If FLAG_EloMode = 0 Then tString = PlrRank(T)
        If FLAG_EloMode = 1 Then tString = PlrELO(T)
        If FLAG_EloMode = 2 Then tString = PlrLVL(T)
      End If

      'R3.00 Create a clipping area so names do not draw past the rectangle.
      Main_Gfx.Clip = New Region(New Rectangle(Xoff + LAB_Rank(T).X + 1, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width - 2, LAB_Rank(T).Height))

      'R4.00 Draw the RANK Shadow text.
      Cx = LAB_Rank(T).X + (LAB_Rank(T).Width / 2) - (Main_Gfx.MeasureString(tString, FONT_Rank).Width / 2)
      Cy = LAB_Rank(T).Y + (LAB_Rank(T).Height / 2) - (Main_Gfx.MeasureString(tString, FONT_Rank).Height / 2)
      If (LSRank.ShadowX <> 0) Or (LSRank.ShadowY <> 0) Then Main_Gfx.DrawString(tString, FONT_Rank, tBrushShadow, Xoff + Cx + LSRank.ShadowX * Val(LSRank.ShadowDepth), Yoff + Cy + LSRank.ShadowY * Val(LSRank.ShadowDepth))

      'R3.00 Draw the RANK text.
      If LSRank.FDir = 0 Then
        linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + 0, Yoff + LAB_Rank(T).Ycenter - TextHgt12), New Point(Xoff + 0, Yoff + LAB_Rank(T).Ycenter + TextHgt12), Color.FromArgb(255, LSRank.F1.R, LSRank.F1.G, LSRank.F1.B), Color.FromArgb(255, LSRank.F2.R, LSRank.F2.G, LSRank.F2.B))
      Else
        linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + LAB_Rank(T).X, Yoff + 0), New Point(Xoff + LAB_Rank(T).X + LAB_Rank(T).Width, Yoff + 0), Color.FromArgb(255, LSRank.F1.R, LSRank.F1.G, LSRank.F1.B), Color.FromArgb(255, LSRank.F2.R, LSRank.F2.G, LSRank.F2.B))
      End If
      Main_Gfx.DrawString(tString, FONT_Rank, linGrBrush, Xoff + Cx, Yoff + Cy)

      'R3.00 Clear the clipping area.
      Main_Gfx.Clip = New Region(New Rectangle(0, 0, Main_BM.Width, Main_BM.Height))
    Next

    '*****************************************************************
    'Draw the Faction images to the stats page.
    '***************************************************************** 
    For t = 1 To 8
      If PlrFact(t) <> "" Then
        tPic = CType(Me.Controls("pbFact" & PlrFact(t)), PictureBox)
        Main_Gfx.DrawImage(tPic.Image, Xoff + LAB_Fact(t).X, Yoff + LAB_Fact(t).Y, LAB_Fact(t).Width, LAB_Fact(t).Height)
      End If
    Next

    '*****************************************************************
    'R3.00 Define paint/fill brushes for the NAME stats.
    '*****************************************************************  
    tBrush = New SolidBrush(LSName.F1)          'R3.40  Color of Name Back 1.
    tBrushFore = New SolidBrush(LSName.F1)      'R3.40  Color of Name Fore 1.
    tBrushShadow = New SolidBrush(LSName.ShadowColor)

    TextHgt12 = Main_Gfx.MeasureString("X", FONT_Name).Height / 2       'R3.30 Changed from Xq.

    For T = 1 To 8
      'R3.00 Create a clipping area so names do not draw past the rectangle.
      Main_Gfx.Clip = New Region(New Rectangle(Xoff + LAB_Name(T).X + 1, Yoff + LAB_Name(T).Y, LAB_Name(T).Width - 2, LAB_Name(T).Height))

      'R3.40 Adjust the text X position if RIGHT justified.
      If LAB_Name_Align(T).Alignment = StringAlignment.Far Then LAB_Name(T).Xtext = LAB_Name(T).X + LAB_Name(T).Width

      'R4.00 Draw the NAME shadow text.
      Cx = Xoff + LAB_Name(T).Xtext
      Cy = Yoff + LAB_Name(T).Y + tLabHgt - TextHgt12
      If (LSName.ShadowX <> 0) Or (LSName.ShadowY <> 0) Then
        If chkCountry.Checked Then
          'R4.50 Normal X layout style.
          If Val(cboLayoutX.Text) < 10 Then
            Main_Gfx.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx + 18 + LSName.ShadowX * Val(LSName.ShadowDepth), Cy + LSName.ShadowY * Val(LSName.ShadowDepth), LAB_Name_Align(T))
            If PlrCountry(T) <> "" Then Main_Gfx.FillRectangle(tBrushShadow, CSng(Cx + (LSName.ShadowX * Val(LSName.ShadowDepth)) + 4), CSng((Yoff + LAB_Name(T).Y + tLabHgt - 6) + LSName.ShadowY * Val(LSName.ShadowDepth)), 16, 11)
          Else
            'R4.50 Centered X layout style.
            If (T Mod 2) Then
              'R4.46 ODD players.
              Main_Gfx.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx - 19 + LSName.ShadowX * Val(LSName.ShadowDepth), Cy + LSName.ShadowY * Val(LSName.ShadowDepth), LAB_Name_Align(T))
              If PlrCountry(T) <> "" Then Main_Gfx.FillRectangle(tBrushShadow, CSng(Cx + (LSName.ShadowX * Val(LSName.ShadowDepth)) - 20), CSng((Yoff + LAB_Name(T).Y + tLabHgt - 6) + LSName.ShadowY * Val(LSName.ShadowDepth)), 16, 11)
            Else
              'R4.50 Even players.
              Main_Gfx.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx + 19 + LSName.ShadowX * Val(LSName.ShadowDepth), Cy + LSName.ShadowY * Val(LSName.ShadowDepth), LAB_Name_Align(T))
              If PlrCountry(T) <> "" Then Main_Gfx.FillRectangle(tBrushShadow, CSng(Cx + (LSName.ShadowX * Val(LSName.ShadowDepth)) + 4), CSng((Yoff + LAB_Name(T).Y + tLabHgt - 6) + LSName.ShadowY * Val(LSName.ShadowDepth)), 16, 11)
            End If
          End If
        Else
          Main_Gfx.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx + LSName.ShadowX * Val(LSName.ShadowDepth), Cy + LSName.ShadowY * Val(LSName.ShadowDepth), LAB_Name_Align(T))
        End If

      End If

      'R3.00 Setup the LINEAR brush for NAME text.
      If LSName.FDir = 0 Then
        linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + 0, Yoff + LAB_Name(T).Ycenter - TextHgt12), New Point(Xoff + 0, Yoff + LAB_Name(T).Ycenter + TextHgt12), Color.FromArgb(255, LSName.F1.R, LSName.F1.G, LSName.F1.B), Color.FromArgb(255, LSName.F2.R, LSName.F2.G, LSName.F2.B))
      Else
        'R3.40 Reverse gradient if drawing RIGHT justified text.
        If LAB_Name_Align(T).Alignment = StringAlignment.Far Then
          linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + LAB_Name(T).X + LAB_Name(T).Width, Yoff + 0), New Point(Xoff + LAB_Name(T).X, Yoff + 0), Color.FromArgb(255, LSName.F1.R, LSName.F1.G, LSName.F1.B), Color.FromArgb(255, LSName.F2.R, LSName.F2.G, LSName.F2.B))
        Else
          linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(Xoff + LAB_Name(T).X, Yoff + 0), New Point(Xoff + LAB_Name(T).X + LAB_Name(T).Width, Yoff + 0), Color.FromArgb(255, LSName.F1.R, LSName.F1.G, LSName.F1.B), Color.FromArgb(255, LSName.F2.R, LSName.F2.G, LSName.F2.B))
        End If
      End If

      'R3.00 Draw the NAME Text.
      Cx = Xoff + LAB_Name(T).Xtext
      Cy = Yoff + LAB_Name(T).Y + tLabHgt - TextHgt12

      If chkCountry.Checked Then
        'R4.50 Normal X layout style.
        If Val(cboLayoutX.Text) < 10 Then
          Main_Gfx.DrawString(PlrName(T), FONT_Name, linGrBrush, Cx + 18, Cy, LAB_Name_Align(T))
          If PlrCountry(T) <> "" Then
            Dim BM_Country = My.Resources.ResourceManager.GetObject("flag_" & PlrCountry(T))
            If Not IsNothing(BM_Country) Then Main_Gfx.DrawImage(BM_Country, New Point(Cx + 4, Yoff + LAB_Name(T).Y + tLabHgt - 6))
          End If
        Else
          'R4.46 Centered X layout style.
          If (T Mod 2) Then
            'R4.50 ODD players.
            Main_Gfx.DrawString(PlrName(T), FONT_Name, linGrBrush, Cx - 19, Cy, LAB_Name_Align(T))
            If PlrCountry(T) <> "" Then
              Dim BM_Country = My.Resources.ResourceManager.GetObject("flag_" & PlrCountry(T))
              If Not IsNothing(BM_Country) Then Main_Gfx.DrawImage(BM_Country, New Point(Cx - 20, Yoff + LAB_Name(T).Y + tLabHgt - 6))
            End If
          Else
            'R4.50 Even players.
            Main_Gfx.DrawString(PlrName(T), FONT_Name, linGrBrush, Cx + 19, Cy, LAB_Name_Align(T))
            If PlrCountry(T) <> "" Then
              Dim BM_Country = My.Resources.ResourceManager.GetObject("flag_" & PlrCountry(T))
              If Not IsNothing(BM_Country) Then Main_Gfx.DrawImage(BM_Country, New Point(Cx + 4, Yoff + LAB_Name(T).Y + tLabHgt - 6))
            End If
          End If
        End If

      Else
        Main_Gfx.DrawString(PlrName(T), FONT_Name, linGrBrush, Cx, Cy, LAB_Name_Align(T))
      End If

      'R3.00 Clear the clipping area.
      Main_Gfx.Clip = New Region(New Rectangle(0, 0, Main_BM.Width, Main_BM.Height))
    Next

    '*****************************************************************
    'R3.10 Call any foreground based FX MODE options like SHADOW, etc
    '*****************************************************************
    If CFX3DActive(clsGlobal.FXMode.Emboss) Then Call GFX_FX_Emboss(Main_Gfx, Main_BM, Xoff, Yoff)


    '*****************************************************************
    'R4.00 Draw the OVERLAY image.
    '*****************************************************************
    If Not (NAME_OVLBmp Is Nothing) Then
      'R4.00 Scale and Draw the background image.
      Select Case Val(LSName.OVLScaling)
        Case 0   'R4.00 Normal Scaling
          Main_Gfx.DrawImage(NAME_OVLBmp, 0, 0, NAME_OVLBmp.Width, NAME_OVLBmp.Height)
        Case 1   'R4.00 Tiled Scaling
          For tY = 0 To Main_BM.Height Step NAME_OVLBmp.Height
            For tX = 0 To Main_BM.Width Step NAME_OVLBmp.Width
              Main_Gfx.DrawImage(NAME_OVLBmp, tX, tY, NAME_OVLBmp.Width, NAME_OVLBmp.Height)
            Next
          Next
        Case 2   'R4.00 Stretch/Fit Scaling
          'R4.00 MS sux.
          If (NAME_OVLBmp.Width < Main_BM.Width) Or (NAME_OVLBmp.Height < Main_BM.Height) Then
            Dim OvlXoff As Single = Main_BM.Width / NAME_OVLBmp.Width
            Dim OvlYoff As Single = Main_BM.Height / NAME_OVLBmp.Height
            Main_Gfx.DrawImage(NAME_OVLBmp, 0, 0, Main_BM.Width + OvlXoff, Main_BM.Height + OvlYoff)
          Else
            Main_Gfx.DrawImage(NAME_OVLBmp, 0, 0, Main_BM.Width, Main_BM.Height)
          End If
      End Select
    End If

  End Sub


  Private Sub GFX_DrawStats()

    'R4.32 Adjust our working BMP if needed.
    Call STATS_AdjustSize()
    If (Main_BM.Width <> pbStats.Width) Or (Main_BM.Height <> pbStats.Height) Then
      MainBuffer_Valid = False
      Main_BM = New Bitmap(pbStats.Width, pbStats.Height)
      Main_Gfx = Graphics.FromImage(Main_BM)
    End If
    Main_Gfx.Clear(LSName.BackC)

    'R4.50 Buffers are not valid, redraw ALL buffer images.
    If MainBuffer_Valid = False Then
      MainBlur_Valid = False
      MainBuffer1_Valid = False
      MainBuffer2_Valid = False
      MainBuffer3_Valid = False
    End If

    'R4.50 If we have stored versions skip the drawing code and show buffered versions.
    'R4.50 Are we using ELO cycle. If yes there are three modes Rank, Level, %.
    If FLAG_EloUse = False Then
      If MainBuffer1_Valid Then
        Main_Gfx.DrawImage(MainBuffer1_BM, 0, 0)
        pbStats.Image = Main_BM
        Exit Sub
      End If
    Else
      If MainBuffer1_Valid And (FLAG_EloMode = 0) Then
        Main_Gfx.DrawImage(MainBuffer1_BM, 0, 0)
        pbStats.Image = Main_BM
        Exit Sub
      End If
      If MainBuffer2_Valid And (FLAG_EloMode = 1) Then
        Main_Gfx.DrawImage(MainBuffer2_BM, 0, 0)
        pbStats.Image = Main_BM
        Exit Sub
      End If
      If MainBuffer3_Valid And (FLAG_EloMode = 2) Then
        Main_Gfx.DrawImage(MainBuffer3_BM, 0, 0)
        pbStats.Image = Main_BM
        Exit Sub
      End If
    End If

    'R4.50 If the current background image is valid use it and skip background drawing else build background image.
    If MainBuffer_Valid Then
      Main_Gfx.DrawImage(MainBuffer_BM, 0, 0)
    Else
      Call GFX_BuildStatsBackground()
    End If

    Call GFX_BuildStatsForeground()


    'R4.50 Store the rendered STATS images so we can skip draws on the next Draw/ELO cycle.
    'R4.50 Are we using ELO cycle. If yes there are three modes Rank, Level, %.
    If FLAG_EloUse = False Then
      If (MainBuffer1_Valid = False) Then
        MainBuffer1_BM = New Bitmap(pbStats.Width, pbStats.Height)
        MainBuffer1_Gfx = Graphics.FromImage(MainBuffer1_BM)
        MainBuffer1_Gfx.DrawImage(Main_BM, 0, 0)
        MainBuffer1_Valid = True
      End If
    Else
      If (FLAG_EloMode = 0) And (MainBuffer1_Valid = False) Then
        MainBuffer1_BM = New Bitmap(pbStats.Width, pbStats.Height)
        MainBuffer1_Gfx = Graphics.FromImage(MainBuffer1_BM)
        MainBuffer1_Gfx.DrawImage(Main_BM, 0, 0)
        MainBuffer1_Valid = True
      End If
      If (FLAG_EloMode = 1) And (MainBuffer2_Valid = False) Then
        MainBuffer2_BM = New Bitmap(pbStats.Width, pbStats.Height)
        MainBuffer2_Gfx = Graphics.FromImage(MainBuffer2_BM)
        MainBuffer2_Gfx.DrawImage(Main_BM, 0, 0)
        MainBuffer2_Valid = True
      End If
      If (FLAG_EloMode = 2) And (MainBuffer3_Valid = False) Then
        MainBuffer3_BM = New Bitmap(pbStats.Width, pbStats.Height)
        MainBuffer3_Gfx = Graphics.FromImage(MainBuffer3_BM)
        MainBuffer3_Gfx.DrawImage(Main_BM, 0, 0)
        MainBuffer3_Valid = True
      End If

    End If

    'R4.30 Put the rendered bitmap into the STATS image.
    pbStats.Image = Main_BM

  End Sub

  Private Sub GFX_FX_LabBlur(Gfx As Graphics, BM As Bitmap, Xoff As Integer, Yoff As Integer)
    'R4.10 OFFSET values added.
    'R3.20  Lock the bitmap's bits.
    Dim rect As New Rectangle(0, 0, BM.Width, BM.Height)
    Dim bmpData As System.Drawing.Imaging.BitmapData = BM.LockBits(rect, Drawing.Imaging.ImageLockMode.ReadWrite, BM.PixelFormat)
    Dim ptr As IntPtr = bmpData.Scan0                  ' Get the address of the first line.
    Dim ptrMask As IntPtr
    Dim Stride As Integer = bmpData.Stride
    Dim bytes As Integer = BM.Width * BM.Height * 4    ' Declare an array to hold the bytes of the bitmap.
    Dim rgbValues(bytes - 1) As Byte                   ' This code is specific to a bitmap with 32 bits per pixels.
    Dim rgbMask(bytes - 1) As Byte                     'R4.50 Added.
    Dim t As Integer
    Dim BlurBias As Single
    Dim Blur As Single

    'R4.50 See if our RANK Bitmap MASK is valid. If not draw the mask.
    If ((3 < LSRank.BorderMode) Or (3 < LSName.BorderMode)) And (Not MainBlur_Valid) Then
      MainBlur_Valid = True
      MainBlur_BM = New Bitmap(CInt(BM.Width), CInt(BM.Height))
      MainBlur_Gfx = Graphics.FromImage(MainBlur_BM)
      MainBlur_Gfx.Clear(Color.Black)
      Dim tBrush = New SolidBrush(Color.White)

      For t = 1 To 8
        Select Case LSRank.BorderMode
          Case 4 'R4.50 Rounded Corners 4 pixels.
            FillRoundedRectangle(MainBlur_Gfx, New Rectangle(Xoff + LAB_Rank(t).X, Yoff + LAB_Rank(t).Y, LAB_Rank(t).Width, LAB_Rank(t).Height), tBrush, 4)
          Case 5 'R4.50 Rounded Corners 8 pixels.
            FillRoundedRectangle(MainBlur_Gfx, New Rectangle(Xoff + LAB_Rank(t).X, Yoff + LAB_Rank(t).Y, LAB_Rank(t).Width, LAB_Rank(t).Height), tBrush, 8)
          Case 6 'R4.50 Rounded Corners LARGE.
            FillRoundedRectangle_Max(MainBlur_Gfx, New Rectangle(Xoff + LAB_Rank(t).X, Yoff + LAB_Rank(t).Y, LAB_Rank(t).Width, LAB_Rank(t).Height), tBrush)
          Case Else
            MainBlur_Gfx.FillRectangle(tBrush, Xoff + LAB_Rank(t).X, Yoff + LAB_Rank(t).Y, LAB_Rank(t).Width, LAB_Rank(t).Height)
        End Select
        Select Case LSName.BorderMode
          Case 4 'R4.50 Rounded Corners 4 pixels.
            FillRoundedRectangle(MainBlur_Gfx, New Rectangle(Xoff + LAB_Name(t).X, Yoff + LAB_Name(t).Y, LAB_Name(t).Width, LAB_Name(t).Height), tBrush, 4)
          Case 5 'R4.50 Rounded Corners 8 pixels.
            FillRoundedRectangle(MainBlur_Gfx, New Rectangle(Xoff + LAB_Name(t).X, Yoff + LAB_Name(t).Y, LAB_Name(t).Width, LAB_Name(t).Height), tBrush, 8)
          Case 6 'R4.50 Rounded Corners LARGE.
            FillRoundedRectangle_Max(MainBlur_Gfx, New Rectangle(Xoff + LAB_Name(t).X, Yoff + LAB_Name(t).Y, LAB_Name(t).Width, LAB_Name(t).Height), tBrush)
          Case Else
            MainBlur_Gfx.FillRectangle(tBrush, Xoff + LAB_Name(t).X, Yoff + LAB_Name(t).Y, LAB_Name(t).Width, LAB_Name(t).Height)
        End Select
      Next t

    End If

    'R4.50 If doing borders we need to get to the locked data.
    If (3 < LSRank.BorderMode) Or (3 < LSName.BorderMode) Then
      MainBlur_Data = MainBlur_BM.LockBits(New Rectangle(0, 0, BM.Width, BM.Height), Drawing.Imaging.ImageLockMode.ReadWrite, BM.PixelFormat)
      ptrMask = MainBlur_Data.Scan0                  'R4.50  Get the address of the first line.
      System.Runtime.InteropServices.Marshal.Copy(ptrMask, rgbMask, 0, bytes)
    End If


    'R3.40 Setup the BLUR BIAS value.
    If 1 < Len(CFX3DVar(clsGlobal.FXMode.LabelBlur, clsGlobal.FXVarDefs.ShadeBias)) Then
      BlurBias = 1 + Val(Mid(CFX3DVar(clsGlobal.FXMode.LabelBlur, clsGlobal.FXVarDefs.ShadeBias), 1, Len(CFX3DVar(clsGlobal.FXMode.LabelBlur, clsGlobal.FXVarDefs.ShadeBias)) - 1)) * 0.01
    Else
      BlurBias = 1
    End If
    If BlurBias < 1 Then BlurBias = 1
    If 1.1 < BlurBias Then BlurBias = 1.1
    BlurBias = 1 + ((BlurBias - 1) * 4)      'R3.40 Reworked BLUR routines so Bias needs to be bigger.

    'R3.40 Setup the BLUR amount.
    If 1 < Len(CFX3DVar(clsGlobal.FXMode.LabelBlur, clsGlobal.FXVarDefs.ShadeAmount)) Then
      Blur = Val(Mid(CFX3DVar(clsGlobal.FXMode.LabelBlur, clsGlobal.FXVarDefs.ShadeAmount), 1, Len(CFX3DVar(clsGlobal.FXMode.LabelBlur, clsGlobal.FXVarDefs.ShadeAmount)) - 1)) * 0.01
    Else
      Blur = 0.4
    End If
    If Blur = 0 Then Blur = 0.8

    ' Copy the RGB values into the array.
    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)


    'R4.50 Blur the rectangles. This needs updated for new curved borders.
    For t = 1 To 8
      If (Not FLAG_HideMissing) Or (PlrName(t) <> "") Or (PlrSteam(t) <> "") Then
        If (LSRank.BorderMode < 4) Then
          Call FX_BlurRect(rgbValues, Stride, Blur, BlurBias, Xoff + LAB_Rank(t).X, Yoff + LAB_Rank(t).Y, LAB_Rank(t).Width, LAB_Rank(t).Height)
        Else
          Call FX_BlurRect_Bordered(rgbValues, rgbMask, Stride, Blur, BlurBias, Xoff + LAB_Rank(t).X, Yoff + LAB_Rank(t).Y, LAB_Rank(t).Width, LAB_Rank(t).Height)
        End If

        If (LSName.BorderMode < 4) Then
          Call FX_BlurRect(rgbValues, Stride, Blur, BlurBias, Xoff + LAB_Name(t).X, Yoff + LAB_Name(t).Y, LAB_Name(t).Width, LAB_Name(t).Height)
        Else
          Call FX_BlurRect_Bordered(rgbValues, rgbMask, Stride, Blur, BlurBias, Xoff + LAB_Name(t).X, Yoff + LAB_Name(t).Y, LAB_Name(t).Width, LAB_Name(t).Height)
        End If

      End If
    Next t

    ' Copy the RGB values back to the bitmap
    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes)

    If (3 < LSRank.BorderMode) Or (3 < LSName.BorderMode) Then MainBlur_BM.UnlockBits(MainBlur_Data)
    BM.UnlockBits(bmpData)

    ' Draw the modified image.
    Gfx.DrawImage(BM, 0, 0)

  End Sub


  Private Sub GFX_FX_Shadow(Gfx As Graphics, Xoff As Integer, Yoff As Integer)
    'R4.10 OFFSET values added.
    Dim tPic As PictureBox
    Dim tLabHgt As Integer
    Dim Cx, Cy, Cx2, Cy2, Chgt As Integer
    Dim linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(20, 0), Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 0, 255))
    Dim TextHgt12 As Integer
    Dim Idx As Integer
    Dim tString As String = ""   'R4.30 Added.

    'R3.10 Precalc some vars for readability in code.
    tLabHgt = LAB_Rank(1).Height \ 2

    'R4.32 Adjust our working BMP if needed.
    If (Main_BM2.Width <> pbStats.Width) Or (Main_BM2.Height <> pbStats.Height) Then
      Main_BM2 = New Bitmap(pbStats.Width, pbStats.Height)
      Main_Gfx2 = Graphics.FromImage(Main_BM2)
    End If
    Main_Gfx2.Clear(Color.FromArgb(0, 0, 0, 0))

    '*****************************************************************
    'R3.10 Draw the Faction images to the stats page.
    '***************************************************************** 
    'R3.20 RemovedDim POP(0 To 8) As Integer
    'R3.20 Removed If 0 < GUI_Mouse_PlrIndex Then POP(GUI_Mouse_PlrIndex) = LAB_Fact(1).Height / 6

    For t = 1 To 8
      If PlrFact(t) <> "" Then
        tPic = CType(Me.Controls("pbFact" & PlrFact(t)), PictureBox)
        'R3.20 Removed Gfx2.DrawImage(tPic.Image, LAB_Fact(t).X - POP(t), LAB_Fact(t).Y - POP(t), LAB_Fact(t).Width + POP(t) * 2, LAB_Fact(t).Height + POP(t) * 2)
        Main_Gfx2.DrawImage(tPic.Image, Xoff + LAB_Fact(t).X, Yoff + LAB_Fact(t).Y, LAB_Fact(t).Width, LAB_Fact(t).Height)
      End If
    Next

    '*****************************************************************
    'R3.00 Paint a blurred shadow.
    '*****************************************************************
    Dim tBrushShadow As SolidBrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
    tBrushShadow = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
    TextHgt12 = Main_Gfx2.MeasureString("X", FONT_Rank).Height / 2

    For T = 1 To 8
      If FLAG_EloUse = False Then
        tString = PlrRank(T)
      Else
        If FLAG_EloMode = 0 Then tString = PlrRank(T)
        If FLAG_EloMode = 1 Then tString = PlrELO(T)
        If FLAG_EloMode = 2 Then tString = PlrLVL(T)
      End If

      'R3.00 Create a clipping area so names do not draw past the rectangle.
      Main_Gfx2.Clip = New Region(New Rectangle(Xoff + LAB_Rank(T).X + 1, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width - 2, LAB_Rank(T).Height))

      'R3.00 Draw the RANK Shadow text.
      Cx = LAB_Rank(T).X + 2 + (LAB_Rank(T).Width / 2) - (Main_Gfx2.MeasureString(tString, FONT_Rank).Width / 2)
      Cy = LAB_Rank(T).Y + 2 + (LAB_Rank(T).Height / 2) - (Main_Gfx2.MeasureString(tString, FONT_Rank).Height / 2)
      Chgt = Main_Gfx2.MeasureString(tString, FONT_Rank).Height / 2
      Select Case CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeAng)
        Case "45°" : Cx2 = 0 : Cy2 = -4
        Case "90°" : Cx2 = -2 : Cy2 = -4
        Case "135°" : Cx2 = -4 : Cy2 = -4
        Case "180°" : Cx2 = -4 : Cy2 = -2
        Case "225°" : Cx2 = -4 : Cy2 = 0
        Case "270°" : Cx2 = -2 : Cy2 = 0
        Case "315°" : Cx2 = 0 : Cy2 = 0
        Case "360°" : Cx2 = 0 : Cy2 = -2
        Case Else : Cx2 = 0 : Cy2 = 0
      End Select
      If CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeAng) <> "--" Then Main_Gfx2.DrawString(tString, FONT_Rank, tBrushShadow, Xoff + Cx + Cx2, Yoff + Cy + Cy2)

      'R3.00 Clear the clipping area.
      Main_Gfx2.Clip = New Region(New Rectangle(0, 0, Main_BM2.Width, Main_BM2.Height))
    Next


    TextHgt12 = Main_Gfx2.MeasureString("X", FONT_Name).Height / 2
    For T = 1 To 8
      'R3.00 Create a clipping area so names do not draw past the rectangle.
      Main_Gfx2.Clip = New Region(New Rectangle(Xoff + LAB_Name(T).X + 1, Yoff + LAB_Name(T).Y, LAB_Name(T).Width - 2, LAB_Name(T).Height))

      'R3.40 Adjust the text X position if RIGHT justified.
      If LAB_Name_Align(T).Alignment = StringAlignment.Far Then LAB_Name(T).Xtext = LAB_Name(T).X + LAB_Name(T).Width
      Cx = Xoff + LAB_Name(T).Xtext
      Cy = Yoff + LAB_Name(T).Y + tLabHgt - TextHgt12

      Select Case CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeAng)
        Case "45°" : Cx2 = 2 : Cy2 = -2
        Case "90°" : Cx2 = 0 : Cy2 = -2
        Case "135°" : Cx2 = -2 : Cy2 = -2
        Case "180°" : Cx2 = -2 : Cy2 = 0
        Case "225°" : Cx2 = -2 : Cy2 = 2
        Case "270°" : Cx2 = 0 : Cy2 = 2
        Case "315°" : Cx2 = 2 : Cy2 = 2
        Case "360°" : Cx2 = 2 : Cy2 = 0
        Case Else : Cx2 = 0 : Cy2 = 0
      End Select
      If CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeAng) <> "--" Then
        If chkCountry.Checked Then
          'R4.50 Normal X layout style.
          If Val(cboLayoutX.Text) < 10 Then
            Main_Gfx2.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx + 18 + Cx2, Cy + Cy2, LAB_Name_Align(T))
            If PlrCountry(T) <> "" Then Main_Gfx2.FillRectangle(tBrushShadow, Cx + 4, Yoff + LAB_Name(T).Y + tLabHgt - 6, 16, 11)
          Else
            'R4.50 Centered X layout style.
            If (T Mod 2) Then
              'R4.46 ODD players.
              Main_Gfx2.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx - 19 + Cx2, Cy + Cy2, LAB_Name_Align(T))
              If PlrCountry(T) <> "" Then Main_Gfx2.FillRectangle(tBrushShadow, Cx - 20 + Cx2, Yoff + LAB_Name(T).Y + tLabHgt - 6 + Cy2, 16, 11)
            Else
              'R4.50 Even players.
              Main_Gfx2.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx + 19 + Cx2, Cy + Cy2, LAB_Name_Align(T))
              If PlrCountry(T) <> "" Then Main_Gfx2.FillRectangle(tBrushShadow, Cx + 4 + Cx2, Yoff + LAB_Name(T).Y + tLabHgt - 6 + Cy2, 16, 11)
            End If
          End If
        Else
          Main_Gfx2.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx + Cx2, Cy + Cy2, LAB_Name_Align(T))
        End If
      End If

      'R3.00 Clear the clipping area.
      Main_Gfx2.Clip = New Region(New Rectangle(0, 0, Main_BM2.Width, Main_BM2.Height))
    Next

    ' Lock the bitmap's bits.
    Dim rect As New Rectangle(0, 0, Main_BM2.Width, Main_BM2.Height)
    Dim bmpData As System.Drawing.Imaging.BitmapData = Main_BM2.LockBits(rect, Drawing.Imaging.ImageLockMode.ReadWrite, Main_BM2.PixelFormat)
    Dim ptr As IntPtr = bmpData.Scan0                  'R3.40 Get the address of the first byte.
    Dim Stride As Integer = bmpData.Stride
    Dim bytes As Integer = Main_BM2.Width * Main_BM2.Height * 4  'R3.40 Declare an array to hold the bytes of the bitmap.
    Dim rgbValues(bytes - 1) As Byte                   'R3.40 This code is specific to a bitmap with 32 bits per pixels.
    Dim Ca, Ca2 As Integer
    Dim Blr1, Blr2 As Single
    Dim TempI As Integer

    ' Copy the RGB values into the array.
    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)

    'R3.10 Calculate the Blur Bias value.
    Dim BlrFac As Single
    If 1 < Len(CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeBias)) Then
      BlrFac = 1 + Val(Mid(CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeBias), 1, Len(CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeBias)) - 1)) * 0.01
    Else
      BlrFac = 1
    End If
    If BlrFac < 1 Then BlrFac = 1
    If 1.1 < BlrFac Then BlrFac = 1.1
    BlrFac = 1 + (BlrFac - 1) * 16

    'R3.10 Calculate the Blur Amount.
    If 1 < Len(CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeAmount)) Then
      Blr1 = Val(Mid(CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeAmount), 1, Len(CFX3DVar(clsGlobal.FXMode.Shadow, clsGlobal.FXVarDefs.ShadeAmount)) - 1)) * 0.01
    Else
      Blr1 = 0.5
    End If
    If Blr1 = 0 Then Blr1 = 0.8
    Blr2 = 1 - Blr1

    'R3.00 Fill in the SHADOW color, and BLUR the alpha channel to make it bigger or smaller.
    For y As Integer = 0 To Main_BM2.Height - 1
      Idx = (y * Stride)
      For x As Integer = 0 To Main_BM2.Width - 1
        rgbValues(Idx) = CFX3DC(1).B         'R3.30 Fill in SOLID color RGB.
        rgbValues(Idx + 1) = CFX3DC(1).G
        rgbValues(Idx + 2) = CFX3DC(1).R

        rgbValues(Idx + 3) = Ca * Blr1 + rgbValues(Idx + 3) * Blr2
        Ca = rgbValues(Idx + 3)           'R3.30 We are only BLURRING alpha channel (Idx+3).

        Idx += 4
      Next x
    Next y
    TempI = (Main_BM2.Width - 2) * 4               'R3.40 Do some precalc here.   
    For y As Integer = 0 To Main_BM2.Height - 2
      Idx = (y * Stride) + TempI
      For x As Integer = Main_BM2.Width - 2 To 2 Step -1
        rgbValues(Idx + 3) = Ca * Blr1 + rgbValues(Idx + 3) * Blr2
        Ca = rgbValues(Idx + 3)
        Idx -= 4
      Next x
    Next y
    'TempI = (2 * Stride)                       'R3.40 Do some precalc here.   
    For x As Integer = 2 To Main_BM2.Width - 2
      Idx = (x * 4)
      For y As Integer = 0 To Main_BM2.Height - 2
        rgbValues(Idx + 3) = Ca * Blr1 + rgbValues(Idx + 3) * Blr2
        Ca = rgbValues(Idx + 3)
        Idx += Stride
      Next y
    Next x
    TempI = ((Main_BM2.Height - 2) * Stride)       'R3.40 Do some precalc here.   
    For x As Integer = 2 To Main_BM2.Width - 2
      Idx = TempI + (x * 4)
      For y As Integer = Main_BM2.Height - 2 To 2 Step -1
        rgbValues(Idx + 3) = Ca * Blr1 + rgbValues(Idx + 3) * Blr2
        Ca = rgbValues(Idx + 3)
        Idx -= Stride
      Next y
    Next x


    'R3.10 Multiply the Original data times the Emboss bitmap.
    Idx = 3 'R3.40 Start on ALPHA to reduce # of adds.
    For Y = 0 To bytes - 1 Step 4
      'R3.40 Apply the BIAS factor to brighten the final image.
      'R3.40 Colors get dim when blurred.
      Ca2 = CInt(rgbValues(Idx) * BlrFac)
      If 255 < Ca2 Then Ca2 = 255
      rgbValues(Idx) = Ca2
      Idx += 4
    Next Y


    'R3.00 Copy the RGB values back to the bitmap
    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes)

    'R3.00 Unlock the bits so they can be used.
    Main_BM2.UnlockBits(bmpData)

    'R3.00 Draw the modified image.
    Gfx.DrawImage(Main_BM2, 0, 0)

    'R4.32 Attempt some clean up.
    linGrBrush.Dispose()


  End Sub

  Private Sub GFX_FX_Emboss(Gfx As Graphics, BM As Bitmap, Xoff As Integer, Yoff As Integer)
    'R4.10 OFFSET values added.
    Dim tPic As PictureBox
    Dim LabYCenter As Integer
    Dim Cx, Cy, Cx2, Cy2 As Integer
    Dim TextHgt12 As Integer
    Dim Idx As Integer
    Dim tString As String = ""

    Dim BM2 As Bitmap = New Bitmap(BM.Width, BM.Height)
    Dim Gfx2 As Graphics = Graphics.FromImage(BM2)

    'R3.10 Precalc some vars for readability in code.
    LabYCenter = LAB_Rank(1).Height \ 2

    '*****************************************************************
    'R3.10 Draw the Faction images to the stats page.
    '***************************************************************** 
    'Dim POP(0 To 8) As Integer
    'If 0 < GUI_Mouse_PlrIndex Then POP(GUI_Mouse_PlrIndex) = LAB_Fact(1).Height / 6

    For t = 1 To 8
      If PlrFact(t) <> "" Then
        tPic = CType(Me.Controls("pbFact" & PlrFact(t)), PictureBox)
        Gfx2.DrawImage(tPic.Image, Xoff + LAB_Fact(t).X, Yoff + LAB_Fact(t).Y, LAB_Fact(t).Width, LAB_Fact(t).Height)
      End If
    Next

    '*****************************************************************
    'R3.00 Print the RANK and NAME text on the blank bitmap.
    '*****************************************************************
    Dim tBrushShadow As SolidBrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))

    For T = 1 To 8
      If FLAG_EloUse = False Then
        tString = PlrRank(T)
      Else
        If FLAG_EloMode = 0 Then tString = PlrRank(T)
        If FLAG_EloMode = 1 Then tString = PlrELO(T)
        If FLAG_EloMode = 2 Then tString = PlrLVL(T)
      End If

      'R3.00 Create a clipping area so names do not draw past the rectangle/label.
      Gfx2.Clip = New Region(New Rectangle(Xoff + LAB_Rank(T).X + 1, Yoff + LAB_Rank(T).Y, LAB_Rank(T).Width - 2, LAB_Rank(T).Height))

      'R3.00 Draw the RANK Shadow text.
      Cx = Xoff + LAB_Rank(T).X + 2 + (LAB_Rank(T).Width / 2) - (Gfx2.MeasureString(tString, FONT_Rank).Width / 2)
      Cy = Yoff + LAB_Rank(T).Y + 2 + (LAB_Rank(T).Height / 2) - (Gfx2.MeasureString(tString, FONT_Rank).Height / 2)
      Cx2 = 0 : Cy2 = -2
      Gfx2.DrawString(tString, FONT_Rank, tBrushShadow, Cx + Cx2, Cy + Cy2)

      'R3.00 Clear the clipping area.
      Gfx2.Clip = New Region(New Rectangle(0, 0, BM2.Width, BM2.Height))
    Next

    TextHgt12 = Gfx2.MeasureString("X", FONT_Name).Height / 2           'R3.30 Was Xq.
    For T = 1 To 8
      'R3.00 Create a clipping area so names do not draw past the rectangle.
      Gfx2.Clip = New Region(New Rectangle(Xoff + LAB_Name(T).X + 1, Yoff + LAB_Name(T).Y, LAB_Name(T).Width - 2, LAB_Name(T).Height))

      'R3.40 Adjust the text X position if RIGHT justified.
      If LAB_Name_Align(T).Alignment = StringAlignment.Far Then LAB_Name(T).Xtext = LAB_Name(T).X + LAB_Name(T).Width
      Cx = Xoff + LAB_Name(T).Xtext
      Cy = Yoff + LAB_Name(T).Y + LabYCenter - TextHgt12

      'R4.46 Added Country flags.
      If chkCountry.Checked Then
        'R4.50 Normal X layout style.
        If Val(cboLayoutX.Text) < 10 Then
          Gfx2.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx + 18, Cy, LAB_Name_Align(T))
          If PlrCountry(T) <> "" Then Gfx2.FillRectangle(tBrushShadow, Cx + 4, Yoff + LAB_Name(T).Y + LabYCenter - 6, 16, 11)
        Else
          'R4.46 Centered X layout style.
          If (T Mod 2) Then
            'R4.50 ODD players.
            Gfx2.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx - 19, Cy, LAB_Name_Align(T))
            If PlrCountry(T) <> "" Then Gfx2.FillRectangle(tBrushShadow, Cx - 20, Yoff + LAB_Name(T).Y + LabYCenter - 6, 16, 11)
          Else
            'R4.50 Even players.
            Gfx2.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx + 19, Cy, LAB_Name_Align(T))
            If PlrCountry(T) <> "" Then Gfx2.FillRectangle(tBrushShadow, Cx + 4, Yoff + LAB_Name(T).Y + LabYCenter - 6, 16, 11)
          End If
        End If
      Else
        Gfx2.DrawString(PlrName(T), FONT_Name, tBrushShadow, Cx, Cy, LAB_Name_Align(T))
      End If

      'R3.00 Clear the clipping area.
      Gfx2.Clip = New Region(New Rectangle(0, 0, BM2.Width, BM2.Height))
    Next


    '********************************************************************************************
    ' R3.10 Setup high speed memory operations.
    '********************************************************************************************
    Dim rect As New Rectangle(0, 0, BM2.Width, BM2.Height)
    Dim bmpData As System.Drawing.Imaging.BitmapData = BM.LockBits(rect, Drawing.Imaging.ImageLockMode.ReadWrite, BM.PixelFormat)
    Dim bmpData2 As System.Drawing.Imaging.BitmapData = BM2.LockBits(rect, Drawing.Imaging.ImageLockMode.ReadWrite, BM2.PixelFormat)
    Dim ptr As IntPtr = bmpData.Scan0                  'R3.10 Get the address of the Original data.
    Dim ptr2 As IntPtr = bmpData2.Scan0                'R3.10 Get the address of the Embossed data.
    Dim Stride As Integer = bmpData2.Stride
    Dim bytes As Integer = BM2.Width * BM2.Height * 4  'R3.30 Declare an array to hold the bytes of the bitmap.
    Dim rgbValues(bytes - 1) As Byte                   'R3.30 This code is specific to a bitmap with 32 bits per pixels.
    Dim rgbOrg(bytes - 1) As Byte

    'R3.10 Copy the BGRA values into arrays we can modify.
    System.Runtime.InteropServices.Marshal.Copy(ptr2, rgbValues, 0, bytes)
    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbOrg, 0, bytes)

    ' R3.10 Blur to the right.
    Dim Cb, Ca2 As Integer
    Dim Blr1, Blr2 As Single

    'R3.10 Create GreyScale Embossed bitmap (315 degree) on BLUE channel only.
    'R3.30 Need options for B2 to get other Emboss angles. B2 here is X+1, Y+1.
    'R3.40 Since we read a line and pixel ahead, do not scan the entire bitmap.
    For y As Integer = 0 To BM2.Height - 2
      'R3.40 ScanY = (y * Stride)
      Idx = (y * Stride)
      For x As Integer = 0 To BM2.Width - 2
        'R3.40 Calc EMBOSS pixels on ALPHA, modify BLUE only. 
        Select Case CInt(rgbValues(Idx + 3)) - rgbValues(Idx + 3 + Stride + 4)
          Case Is = 0
            rgbValues(Idx) = 128          'R3.10 CFX3DC(1).B   'User Defined color.
            'rgbValues(Idx + 1) = 128     'R3.10 CFX3DC(1).G
            'rgbValues(Idx + 2) = 128     'R3.10 CFX3DC(1).R
          Case Is < 0
            rgbValues(Idx) = 255
            'rgbValues(Idx + 1) = 255
            'rgbValues(Idx + 2) = 255
          Case Is > 0
            rgbValues(Idx) = 0
            'rgbValues(Idx + 1) = 0
            'rgbValues(Idx + 2) = 0
        End Select

        Idx += 4
      Next x
    Next y

    '********************************************************************
    'R3.10 Blur the Embossed bitmap. Low blur works best for emboss.
    '********************************************************************
    Dim BlrBias As Single

    If 1 < Len(CFX3DVar(clsGlobal.FXMode.Emboss, clsGlobal.FXVarDefs.ShadeBias)) Then
      BlrBias = 1 + Val(Mid(CFX3DVar(clsGlobal.FXMode.Emboss, clsGlobal.FXVarDefs.ShadeBias), 1, Len(CFX3DVar(clsGlobal.FXMode.Emboss, clsGlobal.FXVarDefs.ShadeBias)) - 1)) * 0.01
    Else
      BlrBias = 1
    End If
    If BlrBias < 1 Then BlrBias = 1
    If 1.5 < BlrBias Then BlrBias = 1.5
    BlrBias = 1 + (BlrBias - 1) * 16

    If 1 < Len(CFX3DVar(clsGlobal.FXMode.Emboss, clsGlobal.FXVarDefs.ShadeAmount)) Then
      Blr1 = Val(Mid(CFX3DVar(clsGlobal.FXMode.Emboss, clsGlobal.FXVarDefs.ShadeAmount), 1, Len(CFX3DVar(clsGlobal.FXMode.Emboss, clsGlobal.FXVarDefs.ShadeAmount)) - 1)) * 0.01
    Else
      Blr1 = 0.4
    End If
    If Blr1 = 0 Then Blr1 = 0.8
    Blr2 = 1 - Blr1

    '************************************************************************
    'R3.10 Smooth the EMBOSSED image.
    'R3.40 Since we are multiplying by BlrBias we need to clip values to 255.
    'R3.40 Scan the bitmap and blur four times: Right, Left, Down, then Up.
    '************************************************************************
    Dim TempI As Integer
    For y As Integer = 2 To BM2.Height - 2
      Idx = (y * Stride) + 8    'R3.40 (X * 4)
      For x As Integer = 2 To BM2.Width - 2
        rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
        Cb = rgbValues(Idx)
        Idx += 4
      Next x
    Next y
    TempI = ((BM2.Width - 2) * 4)
    For y As Integer = 2 To BM2.Height - 2
      Idx = (y * Stride) + TempI
      For x As Integer = BM2.Width - 2 To 2 Step -1
        rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
        Cb = rgbValues(Idx)
        Idx -= 4
      Next x
    Next y
    For x As Integer = 2 To BM2.Width - 2
      Idx = (2 * Stride) + (x * 4)
      For y As Integer = 2 To BM2.Height - 2
        rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
        Cb = rgbValues(Idx)
        Idx += Stride
      Next y
    Next x
    TempI = ((BM2.Height - 2) * Stride)
    For x As Integer = 2 To BM2.Width - 2
      Idx = TempI + (x * 4)
      For y As Integer = BM2.Height - 2 To 2 Step -1
        rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
        Cb = rgbValues(Idx)
        Idx -= Stride
      Next y
    Next x

    'R4.50 Multiply the Original data times the Emboss bitmap.
    Dim tFac As Single
    Idx = 0
    For Y = 0 To bytes - 1 Step 4
      'R3.40 Apply the BIAS factor to brighten the final image.
      'R3.40 Colors get dim when blurred.
      Ca2 = CInt(rgbValues(Idx) * BlrBias)
      If 255 < Ca2 Then Ca2 = 255
      rgbValues(Idx) = Ca2

      'R4.50 Added tFac for possible optimization.
      tFac = (Ca2 / 255.0)
      rgbOrg(Idx) = rgbOrg(Idx) * tFac
      rgbOrg(Idx + 1) = rgbOrg(Idx + 1) * tFac   'R3.10 Only use BLUE from Emboss map.
      rgbOrg(Idx + 2) = rgbOrg(Idx + 2) * tFac   'R3.10 Only use BLUE from Emboss map.
      Idx += 4
    Next Y

    'R3.10 Copy the original (now modified) RGB values back to the bitmap memory. It gets drawn in caller.
    System.Runtime.InteropServices.Marshal.Copy(rgbOrg, 0, ptr, bytes)

    'R3.10 Unlock the bitmap memory so it can be used.
    BM2.UnlockBits(bmpData2)
    BM.UnlockBits(bmpData)

    Application.DoEvents()

    'R3.10 Draw the modified value Bitmap. (Not used here, we are modifying the original bitmap.)
    'Gfx.DrawImage(BM, 0, 0)

    'R4.32 Added.
    BM2.Dispose()
    Gfx2.Dispose()

  End Sub

  Private Sub FX_BlurRect(ByRef rgbValues() As Byte, Stride As Integer, BlurAmount As Single, BlurBias As Single, Left As Integer, Top As Integer, Width As Integer, Height As Integer)
    '*******************************************************************************
    'R3.20 ADDED this sub to blur ractangle areas in rgbValues (Bitmap data).
    'R3.20 Uses a criss/cross weighted average.
    '*******************************************************************************
    Dim Blr1, Blr2 As Single
    Dim TempI As Integer
    Dim Idx As Integer
    Dim Cr, Cg, Cb As Integer  'R4.500 Removed ALPHA from this sub.   
    Dim tC As Integer

    Blr1 = BlurAmount         'R3.20 How blurry are we 0 - 1.00.
    Blr2 = 1 - Blr1           'R3.20 Inverse amount of blur.

    'R4.10 ADDED checks for new OFFSET code.
    If pbStats.Width < Left Then Exit Sub
    If pbStats.Height < Top Then Exit Sub
    If Left < 0 Then Left = 0
    If Top < 0 Then Top = 0
    If pbStats.Width < (Left + Width) Then Width = pbStats.Width - Left
    If pbStats.Height < (Top + Height) Then Height = pbStats.Height - Top

    'R3.30 BLUR the selected rectangle area.
    'R3.40 Added -1 to Height and Width calcs.
    TempI = (Left * 4)
    For y As Integer = Top To Top + Height - 1
      Idx = (y * Stride) + TempI
      For x As Integer = Left To Left + Width - 1
        rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
        Cb = rgbValues(Idx)

        rgbValues(Idx + 1) = Cg * Blr1 + rgbValues(Idx + 1) * Blr2
        Cg = rgbValues(Idx + 1)

        rgbValues(Idx + 2) = Cr * Blr1 + rgbValues(Idx + 2) * Blr2
        Cr = rgbValues(Idx + 2)

        Idx += 4
      Next x
    Next y

    TempI = ((Left + Width - 1) * 4)
    For y As Integer = Top To Top + Height - 1
      Idx = (y * Stride) + TempI
      For x As Integer = Left + Width - 1 To Left Step -1

        rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
        Cb = rgbValues(Idx)

        rgbValues(Idx + 1) = Cg * Blr1 + rgbValues(Idx + 1) * Blr2
        Cg = rgbValues(Idx + 1)

        rgbValues(Idx + 2) = Cr * Blr1 + rgbValues(Idx + 2) * Blr2
        Cr = rgbValues(Idx + 2)

        Idx -= 4
      Next x
    Next y

    TempI = Stride * Top
    For x As Integer = Left To Left + Width - 1
      Idx = TempI + (x * 4)
      For y As Integer = Top To Top + Height - 1
        rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
        Cb = rgbValues(Idx)

        rgbValues(Idx + 1) = Cg * Blr1 + rgbValues(Idx + 1) * Blr2
        Cg = rgbValues(Idx + 1)

        rgbValues(Idx + 2) = Cr * Blr1 + rgbValues(Idx + 2) * Blr2
        Cr = rgbValues(Idx + 2)

        Idx += Stride
      Next y
    Next x

    'R3.40 On the last pass, apply the BIAS value to brighten the blur.
    TempI = (Stride * (Top + Height - 1))
    For x As Integer = Left To Left + Width - 1
      Idx = TempI + (x * 4)
      For y As Integer = Top + Height - 1 To Top Step -1
        tC = Int(Cb * Blr1 + rgbValues(Idx) * Blr2) * BlurBias
        If 255 < tC Then tC = 255
        rgbValues(Idx) = tC
        Cb = rgbValues(Idx)

        tC = Int(Cg * Blr1 + rgbValues(Idx + 1) * Blr2) * BlurBias
        If 255 < tC Then tC = 255
        rgbValues(Idx + 1) = tC
        Cg = rgbValues(Idx + 1)

        tC = Int(Cr * Blr1 + rgbValues(Idx + 2) * Blr2) * BlurBias
        If 255 < tC Then tC = 255
        rgbValues(Idx + 2) = tC
        Cr = rgbValues(Idx + 2)

        Idx -= Stride
      Next y
    Next x


  End Sub

  Private Sub FX_BlurRect_Bordered(ByRef rgbValues() As Byte, ByRef rgbMask() As Byte, Stride As Integer, BlurAmount As Single, BlurBias As Single, Left As Integer, Top As Integer, Width As Integer, Height As Integer)
    '*******************************************************************************
    'R4.50 ADDED this sub to blur using a mask (B/W) bitmap of the same size.
    '*******************************************************************************
    Dim Blr1, Blr2 As Single
    Dim TempI As Integer
    Dim Idx As Integer
    Dim Cr, Cg, Cb As Integer
    Dim tC As Integer

    Blr1 = BlurAmount         'R4.50 How blurry are we 0 - 1.00.
    Blr2 = 1 - Blr1           'R4.50 Inverse amount of blur.

    'R4.50 ADDED checks for new OFFSET code.
    If pbStats.Width < Left Then Exit Sub
    If pbStats.Height < Top Then Exit Sub
    If Left < 0 Then Left = 0
    If Top < 0 Then Top = 0
    If pbStats.Width < (Left + Width) Then Width = pbStats.Width - Left
    If pbStats.Height < (Top + Height) Then Height = pbStats.Height - Top


    'R4.50 BLUR the selected rectangle area.
    'R4.50 Added -1 to Height and Width calcs.
    TempI = (Left * 4)
    For y As Integer = Top To Top + Height - 1
      Idx = (y * Stride) + TempI
      For x As Integer = Left To Left + Width - 1
        If rgbMask(Idx) Then

          rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
          Cb = rgbValues(Idx)

          rgbValues(Idx + 1) = Cg * Blr1 + rgbValues(Idx + 1) * Blr2
          Cg = rgbValues(Idx + 1)

          rgbValues(Idx + 2) = Cr * Blr1 + rgbValues(Idx + 2) * Blr2
          Cr = rgbValues(Idx + 2)
        End If

        Idx += 4
      Next x
    Next y

    TempI = ((Left + Width - 1) * 4)
    For y As Integer = Top To Top + Height - 1
      Idx = (y * Stride) + TempI
      For x As Integer = Left + Width - 1 To Left Step -1
        If rgbMask(Idx) Then

          rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
          Cb = rgbValues(Idx)

          rgbValues(Idx + 1) = Cg * Blr1 + rgbValues(Idx + 1) * Blr2
          Cg = rgbValues(Idx + 1)

          rgbValues(Idx + 2) = Cr * Blr1 + rgbValues(Idx + 2) * Blr2
          Cr = rgbValues(Idx + 2)
        End If

        Idx -= 4
      Next x
    Next y

    TempI = Stride * Top
    For x As Integer = Left To Left + Width - 1
      Idx = TempI + (x * 4)
      For y As Integer = Top To Top + Height - 1
        If rgbMask(Idx) Then
          rgbValues(Idx) = Cb * Blr1 + rgbValues(Idx) * Blr2
          Cb = rgbValues(Idx)

          rgbValues(Idx + 1) = Cg * Blr1 + rgbValues(Idx + 1) * Blr2
          Cg = rgbValues(Idx + 1)

          rgbValues(Idx + 2) = Cr * Blr1 + rgbValues(Idx + 2) * Blr2
          Cr = rgbValues(Idx + 2)
        End If

        Idx += Stride
      Next y
    Next x

    'R4.50 On the last pass, apply the BIAS value to brighten the blur.
    TempI = (Stride * (Top + Height - 1))
    For x As Integer = Left To Left + Width - 1
      Idx = TempI + (x * 4)
      For y As Integer = Top + Height - 1 To Top Step -1
        If rgbMask(Idx) Then
          tC = Int(Cb * Blr1 + rgbValues(Idx) * Blr2) * BlurBias
          If 255 < tC Then tC = 255
          rgbValues(Idx) = tC
          Cb = rgbValues(Idx)

          tC = Int(Cg * Blr1 + rgbValues(Idx + 1) * Blr2) * BlurBias
          If 255 < tC Then tC = 255
          rgbValues(Idx + 1) = tC
          Cg = rgbValues(Idx + 1)

          tC = Int(Cr * Blr1 + rgbValues(Idx + 2) * Blr2) * BlurBias
          If 255 < tC Then tC = 255
          rgbValues(Idx + 2) = tC
          Cr = rgbValues(Idx + 2)

        End If

        Idx -= Stride
      Next y
    Next x


  End Sub


  Private Sub cmTestData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmTestData.Click
    Dim A As String

    A = "Selecting this button will place worst case scenario data on the stats page to test your setup." & vbCr & vbCr
    A = A & "Steam names are usually limited to 32 characters." & vbCr
    A = A & "Ranks are usually limited to 5 digits." & vbCr & vbCr
    A = A & "Do you wish to continue?"
    If MsgBox(A, MsgBoxStyle.Information + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

    'R3.00 Create some worst case scenario data to show n user setup.
    For t = 1 To 8
      PlrName(t) = "12345678901234567890123456789012"
      PlrRank(t) = "88888"
    Next

    PlrFact(1) = "01"
    PlrFact(2) = "02"
    PlrFact(3) = "03"
    PlrFact(4) = "04"
    PlrFact(5) = "01"
    PlrFact(6) = "02"
    PlrFact(7) = "03"
    PlrFact(8) = "05"

    'R4.50 Force the STATS image redraw.
    MainBuffer_Valid = False

    Call GFX_DrawStats()

  End Sub

  Private Sub pbStats_Click(sender As Object, e As EventArgs) Handles pbStats.Click
    'R3.30 This is only here to get us close when clicking controls in EDIT mode.
  End Sub

  Private Sub pbStats_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbStats.MouseDown
    Dim T As Integer
    Dim Hit As Integer

    Select Case FLAG_ShowPlayerCard
      Case 0
        FLAG_ShowPlayerCard = 1
      Case 1
        If e.Button = MouseButtons.Left Then
          FLAG_ShowPlayerCard = 0
        Else
          FLAG_ShowPlayerCard = 2
        End If
      Case 2
        FLAG_ShowPlayerCard = 0
    End Select


    If FLAG_ShowPlayerCard = 0 Then
      If FLAG_EloUse Then timELOCycle.Enabled = True
      Call GFX_DrawStats()
      Exit Sub
    End If

    'R4.00 Find which player we have selected.
    If FLAG_ShowPlayerCard = 1 Then
      For T = 1 To 8
        If (LAB_Name(T).Y < e.Y) And (e.Y < LAB_Name(T).Y + LAB_Name(T).Height) Then
          If (LAB_Name(T).X < e.X) And (e.X < LAB_Name(T).X + LAB_Name(T).Width) Then
            Hit = T : Exit For
          End If
        End If
      Next

      FLAG_ShowPlayerCardNum = Hit

      'R4.00 We did not select a player
      If (Hit = 0) Or (PlrName(Hit) = "") Or (PlrName(Hit) = "---") Then
        FLAG_ShowPlayerCard = False
        Exit Sub
      End If
    End If

    If FLAG_EloUse Then timELOCycle.Enabled = False

    If FLAG_ShowPlayerCard = 1 Then
      Call GFX_DrawPlayerCard(Hit)
    Else
      Hit = FLAG_ShowPlayerCardNum

      scrStats.Maximum = TeamListCnt(Hit) * 90
      T = (PlrTeam(Hit) - 1) * 90
      If (T < 0) Then T = 0
      If scrStats.Maximum < T Then T = scrStats.Maximum
      scrStats.Value = T

      Call GFX_DrawTeams(Hit)
    End If

    Exit Sub


    '***************************************************************************************
    ' R4.50 OLD POP UP MENU VERSION before Relic broke the LOG file.
    '***************************************************************************************
    ''R4.00 POPUP menu option.
    'If (Celo_Popup = True) And (e.Button = Windows.Forms.MouseButtons.Right) Then
    '  Celo_PopupHit = Hit
    '  tsmPlayer.Show(pbStats, New Point(e.X, e.Y))
    '  Exit Sub
    'End If

    ''************************************************************
    ''R4.00 REWORKED THIS WHOLE SUB.
    ''************************************************************
    'tKey = "None"
    'If 0 < (Control.ModifierKeys And Keys.Control) Then tKey = "Ctrl"
    'If 0 < (Control.ModifierKeys And Keys.Shift) Then tKey = "Shift"

    'If (e.Button = Windows.Forms.MouseButtons.Left) And (PlrSteam(T) <> "") Then
    '  Select Case tKey
    '    Case "None"
    '      Process.Start("http://www.companyofheroes.com/leaderboards#profile/steam/" + PlrSteam(Hit) + "/standings")
    '    Case "Ctrl"
    '      If PlrName(Hit) <> "" Then Process.Start("https://translate.google.com/#view=home&op=translate&sl=auto&tl=en&text=" + PlrName(Hit))
    '    Case "Shift"
    '      Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + PlrSteam(Hit))
    '  End Select
    'End If

    'If (e.Button = Windows.Forms.MouseButtons.Right) And (PlrSteam(T) <> "") Then
    '  Select Case tKey
    '    Case "None"
    '      Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/1/steamid/" + PlrSteam(Hit))
    '    Case "Ctrl"
    '      'R4.00 Try to select the correct STATS page from.org.
    '      Select Case PlrFact(Hit)
    '        Case "05" : Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/12/steamid/" + PlrSteam(Hit))           'R4.00 UKF
    '        Case "02", "01" : Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/11/steamid/" + PlrSteam(Hit))     'R4.00 SOV, OST
    '        Case "04", "03" : Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/10/steamid/" + PlrSteam(Hit))     'R4.00 USF, OKW
    '        Case Else : Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + PlrSteam(Hit))
    '      End Select
    '    Case "Shift"
    '      Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + PlrSteam(Hit))
    '  End Select
    'End If

  End Sub

  Private Sub pbStats_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbStats.MouseLeave
    If GUI_Active = False Then Exit Sub

    'R3.00 We are not hovering over any players.
    GUI_Mouse_PlrIndex = 0

    Call GFX_DrawStats()
  End Sub


  Private Sub pbStats_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbStats.MouseMove
    'Dim T As Integer
    'Dim Hit As Integer
    'Dim LastPlr As Integer

    'R4.50 OLD POP UP menu before Relic broke the LOG file.
    Exit Sub

    ''R3.00 Store the player we were hovering over if any.
    'LastPlr = GUI_Mouse_PlrIndex

    ''R3.00 Clear the index to which plr we are moused over.
    'GUI_Mouse_PlrIndex = 0

    ''R3.00 Loop thru player labels to see if we are hovering on one.
    'For T = 1 To 8
    '  If (LAB_Name(T).Y < e.Y) And (e.Y < LAB_Name(T).Y + LAB_Name(T).Height) Then
    '    If (LAB_Name(T).X < e.X) And (e.X < LAB_Name(T).X + LAB_Name(T).Width) Then
    '      Hit = T : Exit For
    '    End If
    '  End If
    'Next

    ''R3.00 If we are hovering a player, Store player # and change mouse cursor.
    'If Hit Then
    '  GUI_Mouse_PlrIndex = Hit
    '  pbStats.Cursor = Cursors.Hand
    'Else
    '  pbStats.Cursor = Cursors.Default
    'End If

    ''R3.00 Cut down on Screen Draws. Only update screen when necessary.
    'If GUI_Active = True Then
    '  If (LastPlr <> GUI_Mouse_PlrIndex) Then Call GFX_DrawStats()
    'End If

  End Sub

  Private Function PLR_Count() As Integer
    Dim Cnt As Integer
    Dim t As Integer

    For t = 1 To 8
      If PlrName(t) <> "" Then Cnt += 1
    Next t

    PLR_Count = Cnt
  End Function

  Private Sub cmLastMatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmLastMatch.Click
    Dim t As Integer

    For t = 1 To 8
      PlrName(t) = PlrName_Last(t)
      PlrRank(t) = PlrRank_Last(t)
      PlrFact(t) = PlrFact_Last(t)
      PlrTeam(t) = PlrTeam_Last(t)
      PlrTWin(t) = PlrTWin_Last(t)
      PlrTLoss(t) = PlrTLoss_Last(t)
      PlrSteam(t) = PlrSteam_Last(t)
      PlrRID(t) = PlrRID_Last(t)
      PlrCountry(t) = PlrCountry_Last(t)            'R4.45 Added.
      PlrCountryName(t) = PlrCountryName_Last(t)    'R4.46 Added.
      For T2 = 1 To 5
        For T3 = 1 To 4
          PlrRankALL(t, T2, T3) = PlrRankALL_Last(t, T2, T3)
          PlrRankWin(t, T2, T3) = PlrRankWin_Last(t, T2, T3)
          PlrRankLoss(t, T2, T3) = PlrRankLoss_Last(t, T2, T3)
          PlrRankPerc(t, T2, T3) = PlrRankPerc_Last(t, T2, T3)
        Next T3
      Next T2
      TeamListCnt(t) = TeamListCnt_Last(t)
      For T2 = 1 To TeamList.GetUpperBound(1)
        TeamList(t, T2) = TeamList_Last(t, T2)
      Next T2
      PlrELO(t) = PlrELO_Last(t)
      PlrLVL(t) = PlrLVL_Last(t)
    Next

    'R4.50 Force the STATS image redraw.
    MainBuffer_Valid = False

    Call GFX_DrawStats()

  End Sub


  Private Sub cmFX3DC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmFX3DC.Click
    Dim N As Integer

    If FLAG_Loading Then Exit Sub

    ColorDialog1.Color = CFX3DC(1) : ColorDialog1.ShowDialog()

    N = cboFXVar1.SelectedIndex
    If 0 < N Then CFX3DC(N) = ColorDialog1.Color

    Call GFX_DrawStats()
    Call SETTINGS_Save("")

  End Sub

  Private Sub cboFX3D_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFXVar2.SelectedIndexChanged
    Dim N As Integer

    'R3.40 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    N = cboFXVar1.SelectedIndex
    If 0 < N Then
      CFX3DVar(N, 2) = cboFXVar2.Text
    End If

    'R4.50 Force the BLUR mask to be redrawn.
    MainBlur_Valid = False

    'R4.50 Force a clean STATS redraw.
    MainBuffer_Valid = False

    Call GFX_DrawStats()
    Call SETTINGS_Save("")

    FLAG_Drawing = False

  End Sub

  Private Sub cboFxVar3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFxVar3.SelectedIndexChanged
    Dim N As Integer

    'R3.40 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    N = cboFXVar1.SelectedIndex
    If 0 < N Then
      CFX3DVar(N, 3) = cboFxVar3.Text
    End If

    'R4.50 Force the BLUR mask to be redrawn.
    MainBlur_Valid = False

    'R4.50 Force a clean STATS redraw.
    MainBuffer_Valid = False

    Call GFX_DrawStats()
    Call SETTINGS_Save("")

    FLAG_Drawing = False
  End Sub

  Private Sub cboFxVar4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFxVar4.SelectedIndexChanged
    Dim N As Integer

    'R3.40 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    N = cboFXVar1.SelectedIndex
    If 0 < N Then
      CFX3DVar(N, 4) = cboFxVar4.Text
    End If

    'R4.50 Force the BLUR mask to be redrawn.
    MainBlur_Valid = False

    'R4.50 Force a clean STATS redraw.
    MainBuffer_Valid = False

    Call GFX_DrawStats()
    Call SETTINGS_Save("")

    FLAG_Drawing = False
  End Sub

  Private Sub cboFXMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFXVar1.SelectedIndexChanged
    Dim N As Integer

    If FLAG_Loading Then Exit Sub

    FLAG_Loading = True

    'R3.20 Get the updated FX settings.
    N = cboFXVar1.SelectedIndex

    If 0 < N Then
      cboFXVar2.Text = CFX3DVar(N, 2)
      cboFxVar3.Text = CFX3DVar(N, 3)
      cboFxVar4.Text = CFX3DVar(N, 4)
    End If

    Call GFX_UpdateScreenControls()

    FLAG_Loading = False

  End Sub

  Private Sub GFX_UpdateScreenControls()
    Dim N As Integer

    'R3.20 Dont save data as we are making screen changes only.
    FLAG_Loading = True

    'R3.20 Get the selected FX index (1 - 10).
    N = cboFXVar1.SelectedIndex
    If 0 < N Then
      If CFX3DActive(N) Then
        chkFX.Checked = True
      Else
        chkFX.Checked = False
      End If

      If CFX3DVar(N, 2) = Nothing Then CFX3DVar(N, 2) = cboFXVar2.Items.Item(1)
      cboFXVar2.Text = CFX3DVar(N, 2)

      If CFX3DVar(N, 3) = Nothing Then CFX3DVar(N, 3) = cboFxVar3.Items.Item(1)
      cboFxVar3.Text = CFX3DVar(N, 3)

      If CFX3DVar(N, 4) = Nothing Then CFX3DVar(N, 4) = cboFxVar4.Items.Item(1)
      cboFxVar4.Text = CFX3DVar(N, 4)

    Else
      'R3.20 We have no settings for this yet.
      chkFX.Checked = False
      cboFXVar2.Text = ""
      cboFxVar3.Text = ""
      cboFxVar4.Text = ""
    End If

    'R3.10 This should always be MODE.
    'lbFXVar1.Text = "Mode"

    'R3.10 Reset all FX controls to ON.
    cmFX3DC.Enabled = True
    cboFXVar2.Enabled = True
    cboFxVar3.Enabled = True
    cboFxVar4.Enabled = True

    'R3.10 Adjust screen controls to match  FX mode.
    Select Case cboFXVar1.Text
      Case "None"
        lbFXVar2.Text = "--"
        lbFXVar3.Text = "--"
        lbFXVar4.Text = "--"
        cmFX3DC.Enabled = False
        cboFXVar2.Enabled = False
        cboFxVar3.Enabled = False
        cboFxVar4.Enabled = False
        chkFX.Enabled = False
      Case "Shadow"
        lbFXVar2.Text = "Color/Ang"
        lbFXVar3.Text = "Blur Size"
        lbFXVar4.Text = "Bias"
        chkFX.Enabled = True
      Case "Emboss"
        lbFXVar2.Text = "--"
        lbFXVar3.Text = "Blur Size"
        lbFXVar4.Text = "Bias"
        cmFX3DC.Enabled = False
        cboFXVar2.Enabled = False
        chkFX.Enabled = True
      Case "Lab Blur"
        lbFXVar2.Text = "--"
        lbFXVar3.Text = "Blur Size"
        lbFXVar4.Text = "Bias"
        cmFX3DC.Enabled = False
        cboFXVar2.Enabled = False
        chkFX.Enabled = True
    End Select

    'R3.20 Restore the OK to save settings flag.
    FLAG_Loading = False

  End Sub

  Private Sub cmFXModeHelp_Click(sender As Object, e As EventArgs) Handles cmFXModeHelp.Click
    Dim A As String = ""

    Select Case cboFXVar1.Text
      Case "None"
        A = "No FX mode has been selected. FX setups allow for image based adjustments that may just add that cool touch to your stats text." & vbCr & vbCr
        A += "Select an FX and then click the ACTIVE checkbox to add FX." & vbCr & vbCr
        A += "Each added FX slows the render time. This only happens when selected and updating the stats. While editing, the GUI may feel sluggish on slower PCs." & vbCr & vbCr
        A += "Click refresh to update if things get out of sync while scrolling thru options."
      Case "Shadow"
        A = "Shadow places a blurred shadow under all text. This helps text pop out more. Depending on the color and angle chosen, the shadow can be dark for a deep shadow or it can be bright giving the effect of light behind the text glowing." & vbCr & vbCr
        A = A & "Blur Size adjust how blurry the shadow is. BIAS adds some brightness and contrast to punch up a neutral shadow." & vbCr & vbCr
        A += "Good start points are: BLUR SIZE (70%), BIAS(5.0%)"
      Case "Emboss"
        A = "Emboss tries to add some 3D depth to the text on screen.  Blurring the embossed image can make the embossing larger and smoother." & vbCr & vbCr
        A += "Embossing multiplies a B/W image and the normal screen. This will always darken the image. Bias Is used to brighten up the darkened image." & vbCr & vbCr
        A += "Using less Blur helps create a a stronger embossing effect." & vbCr & vbCr
        A += "Good start points are: BLUR SIZE (50%), BIAS(5.0%)"
      Case "Lab Blur"
        A = "The rectangles under the rank and player name will be blurred." & vbCr & vbCr
        A += "This tries to make the text stand out from the background a little more." & vbCr & vbCr
        A += "Doing this effect in an image processing progam and used as a background image could create a better image." & vbCr & vbCr
        A += "Good start points are: BLUR SIZE (50%), BIAS(2.0%) and using low background opacity values."
    End Select

    'R4.30 Updated. 
    MsgBox(A, MsgBoxStyle.Information, "HELP - Advanced STATS effects")

  End Sub

  Private Sub chkFX_CheckedChanged(sender As Object, e As EventArgs) Handles chkFX.CheckedChanged
    Dim tState As Boolean
    Dim N As Integer

    If FLAG_Loading Then Exit Sub

    If chkFX.Checked Then
      tState = True
    Else
      tState = False
    End If

    N = cboFXVar1.SelectedIndex

    CFX3DActive(N) = tState

    'R4.50 Force the BLUR mask to be redrawn.
    MainBlur_Valid = False

    'R4.50 Force a clean STATS redraw.
    MainBuffer_Valid = False

    Call GFX_DrawStats()
    Call SETTINGS_Save("")

  End Sub

  Private Sub cmSave_Click(sender As Object, e As EventArgs) Handles cmSave.Click
    'R4.50 Save the current STATS image.
    Dim fd As SaveFileDialog = New SaveFileDialog()

    'R4.50 Added to grab the current stats image (they cycle on a timer even while in dialog).
    Dim tmpImg As New Bitmap(pbStats.Image, pbStats.Width, pbStats.Height)

    fd.Title = "Save Stats Image"
    If PATH_SaveStatsImage <> "" Then fd.InitialDirectory = PATH_SaveStatsImage
    fd.Filter = "Png (*.png)|*.png|Gif (*.gif)|*.gif|Jpeg (*.jpg)|*.jpg"
    fd.FilterIndex = 3

    If fd.ShowDialog() = DialogResult.OK Then

      'R3.30 Save the current stats image to selected filename.
      Try
        tmpImg.Save(fd.FileName)     'R4.50 Changed to this from pbStats.
      Catch
        MsgBox("ERROR:" & Err.Description & vbCr & vbCr & "Unable to save the stats image.", vbCritical)
      End Try

      'R4.50 Save the directory we are using for image save dialog.
      PATH_SaveStatsImage = fd.FileName
      PATH_SaveStatsImage = PATH_StripFilename(PATH_SaveStatsImage)

    End If

  End Sub

  Private Sub chkMismatch_CheckedChanged(sender As Object, e As EventArgs) Handles chkMismatch.CheckedChanged

    If chkMismatch.Checked Then
      FLAG_ShowMismatch = True
    Else
      FLAG_ShowMismatch = False
    End If

  End Sub

  Private Sub ToolTip_Setup()
    Dim A As String

    'ToolTip1.SetToolTip(pbStats, "Click a player name to see web pages for:" & vbCr & "Left: Relic Stats" & vbCr & "Ctrl-Left: Google Translate" & vbCr & "Shift-Left: Coh2.org player page" & vbCr & "Right: Coh2.org AT stats" & vbCr & "Ctrl-Right: Coh2.org faction page")
    ToolTip1.SetToolTip(pbStats, "Click a player name to see their player card. Right click again to see teams if option is enabled.")
    ToolTip1.SetToolTip(pbNote1, "NOTE #1: Used to display stream based information using animated text options.")
    ToolTip1.SetToolTip(pbNote2, "NOTE #2: Used to display stream based information using animated text options.")
    ToolTip1.SetToolTip(pbNote3, "NOTE #3: Used to display stream based information using animated text options.")
    ToolTip1.SetToolTip(pbNote4, "NOTE #4: Used to display stream based information using animated text options.")

    ToolTip1.SetToolTip(tbXsize, "Set the Width in pixels of the STATS image.")
    ToolTip1.SetToolTip(tbYSize, "Set the Height in pixels of the STATS image." & vbCr & "Best results if Y is divisible by 4.")
    ToolTip1.SetToolTip(tbXoff, "Adjust the stats value positions within the STATS image.")
    ToolTip1.SetToolTip(tbYoff, "Adjust the stats value positions within the STATS image.")

    ToolTip1.SetToolTip(cmDefaults, "Set all STATS size options to their default values.")
    ToolTip1.SetToolTip(cmStatsModeHelp, "Simple help info for the STATS setup options.")

    ToolTip1.SetToolTip(cmFindLog, "Locate the log file this program uses to show match stats.")
    ToolTip1.SetToolTip(cmCheckLog, "Force a one time only reading of the match stats log file.")
    ToolTip1.SetToolTip(cmScanLog, "Toggle ON or OFF a timer that automatically reads the log file periodically.")
    ToolTip1.SetToolTip(cboDelay, "Select how long to wait between LOG file scans.")

    ToolTip1.SetToolTip(cmRankSetup, "Setup the Celo RANK font and colors.")
    ToolTip1.SetToolTip(cmNameSetup, "Setup the Celo Player NAME font, colors, background and overlay image.")
    ToolTip1.SetToolTip(cmNote01Setup, "Setup the Note 1 font, colors, size, and background image.")
    ToolTip1.SetToolTip(cmNote02Setup, "Setup the Note 2 font, colors, size, and background image.")
    ToolTip1.SetToolTip(cmNote03Setup, "Setup the Note 3 font, colors, size, and background image.")
    ToolTip1.SetToolTip(cmNote04Setup, "Setup the Note 4 font, colors, size, and background image.")
    ToolTip1.SetToolTip(cmNote1, "Setup the Note 1 text and animation mode.")
    ToolTip1.SetToolTip(cmNote2, "Setup the Note 2 text and animation mode.")
    ToolTip1.SetToolTip(cmNote3, "Setup the Note 3 text and animation mode.")
    ToolTip1.SetToolTip(cmNote4, "Setup the Note 4 text and animation mode.")
    ToolTip1.SetToolTip(cmSetupLoad, "Load a new presentation setup from a stored file.")
    ToolTip1.SetToolTip(cmSetupSave, "Save the current presentation setup to a stored file.")

    ToolTip1.SetToolTip(cmNote_PlayAll, "Toggle on/off all Animation play buttons.")
    ToolTip1.SetToolTip(cmNote01_Play, "Toggle on/off note 1 Animations.")
    ToolTip1.SetToolTip(cmNote02_Play, "Toggle on/off note 2 Animations.")
    ToolTip1.SetToolTip(cmNote03_Play, "Toggle on/off note 3 Animations.")
    ToolTip1.SetToolTip(cmNote04_Play, "Toggle on/off note 4 Animations.")

    A = "Left click to play a sound." & vbCr & "Right click to map a sound or set the volume." & vbCr & "Ctrl-Click to delete."
    ToolTip1.SetToolTip(cmSound01, A)
    ToolTip1.SetToolTip(cmSound02, A)
    ToolTip1.SetToolTip(cmSound03, A)
    ToolTip1.SetToolTip(cmSound04, A)
    ToolTip1.SetToolTip(cmSound05, A)
    ToolTip1.SetToolTip(cmSound06, A)
    ToolTip1.SetToolTip(cmSound07, A)
    ToolTip1.SetToolTip(cmSound08, A)
    ToolTip1.SetToolTip(cmSound09, A)
    ToolTip1.SetToolTip(cmSound10, A)
    ToolTip1.SetToolTip(cmSound11, A)
    ToolTip1.SetToolTip(cmSound12, A)
    ToolTip1.SetToolTip(cmSound13, A)
    ToolTip1.SetToolTip(cmSound14, A)
    ToolTip1.SetToolTip(cmSound15, A)

    'R4.30 Updated.
    ToolTip1.SetToolTip(scrVolume, "The master sound volume for this program. Right click pads to adjust individual sounds.")
    ToolTip1.SetToolTip(cmAudioStop, "STOP playing the current sound.")

    ToolTip1.SetToolTip(cmCopy, "Copy the stats page to the clipboard to be pasted in another program.")
    ToolTip1.SetToolTip(cmSave, "Save a copy of the stats page to the PC. Good to use as a template in custom backgrounds.")

    'ToolTip1.SetToolTip(cboPageSize, "Set the stats page overall size.")
    ToolTip1.SetToolTip(cboLayoutY, "Set the Y axis orientation of the printed stats.")
    ToolTip1.SetToolTip(cboLayoutX, "Set the X axis orientation of the printed stats.")
    ToolTip1.SetToolTip(cboNoteSpace, "Set a border space around NOTES. Set to 0 to use them as a single graphic.")

    ToolTip1.SetToolTip(cmSizeRefresh, "Force a redraw of the stats page. Useful when changing sizes or editing a page using a lot of FX.")
    'ToolTip1.SetToolTip(cmGUILite, "Set the program color scheme to Light. Helps when cropping in your streaming app.")
    'ToolTip1.SetToolTip(cmGUIDark, "Set the program color scheme to Dark. Helps when cropping in your streaming app.")

    ToolTip1.SetToolTip(cboFXVar1, "Select a stats page FX item to edit or make active.")
    ToolTip1.SetToolTip(chkFX, "Toggles the currently selected FX mode to ON or OFF.")
    ToolTip1.SetToolTip(cmFX3DC, "Select a color to be used in the selected FX.")
    ToolTip1.SetToolTip(cboFXVar2, "Select an ANGLE to be used in the selected FX.")
    ToolTip1.SetToolTip(cboFxVar3, "Adjusts an FX setting for the selected FX.")
    ToolTip1.SetToolTip(cboFxVar4, "Adjusts an FX setting for the selected FX.")

    ToolTip1.SetToolTip(cmFXModeHelp, "Get FX mode specific help.")

    ToolTip1.SetToolTip(chkMismatch, "Always show data good or bad. Replay data is missing information, set this to see replay data.")
    ToolTip1.SetToolTip(chkPopUp, "Toggle the context popup menu on the stats page that shows additional player info on the web.")
    ToolTip1.SetToolTip(chkPosition, "Store the current window size and position on the screen.")
    ToolTip1.SetToolTip(chkSmoothAni, "Try to smooth animations by redrawing whole window (10x CPU usage).")
    ToolTip1.SetToolTip(chkGUIMode, "Set the program color scheme to Light/Dark. Helps when cropping in your streaming app.")
    ToolTip1.SetToolTip(chkFoundSound, "Play sound pad #15 (Alert) when AUTO search finds a match.")
    ToolTip1.SetToolTip(chkHideMissing, "Do not display blank player information. Use if playing many game modes to hide extra graphics.")
    ToolTip1.SetToolTip(chkShowELO, "If the rank ELO vals are setup, try to show approx ELO as rank.")
    ToolTip1.SetToolTip(chkSpeech, "Use Windows Speech to read ranks aloud at match start.")
    ToolTip1.SetToolTip(chkGetTeams, "Use additional web calls to search for possible team ranks. Ranks ending in period are teams.")

    ToolTip1.SetToolTip(cmLastMatch, "Display the last valid match found since this program has been running.")
    ToolTip1.SetToolTip(cmTestData, "Test your current setup by filling the stats page" & vbCr & "with the largest values you may see in a COH2 match.")
    ToolTip1.SetToolTip(cmErrLog, "Display the web data log transactions. Useful for troubleshooting problems/crashes.")

  End Sub

  Private Sub chkTips_CheckedChanged(sender As Object, e As EventArgs) Handles chkTips.CheckedChanged

    If chkTips.Checked Then
      ToolTip1.Active = True
    Else
      ToolTip1.Active = False
    End If

  End Sub

  Private Sub NOTE_Animation_Setup(ByRef NoteAnim As clsGlobal.t_NoteAnimation, ByRef pbNote As PictureBox, ByRef tFont As Font, ByRef Note_Text() As String, ByRef NoteAnim_Text() As String)
    'R4.00 this sub sets up the animation variables for a NOTE.
    Dim BM As Bitmap = New Bitmap(pbNote.Width, pbNote.Height)
    Dim Gfx As Graphics = Graphics.FromImage(BM)
    Dim tDelim As String
    Dim Cnt As Integer
    Dim HasText As Boolean = False

    NoteAnim.TimeAcc = 0
    NoteAnim.Holding = False

    Select Case NoteAnim.Mode
      Case 0 'R4.00 NO ANIMATION
        'R4.00 Select X position by TEXT alignment setting.
        Select Case Val(NoteAnim.Align)
          Case 0
            NoteAnim.X = 0
            NoteAnim.Xstart = 0
          Case 1
            NoteAnim.X = pbNote.Width / 2
            NoteAnim.Xstart = NoteAnim.X
          Case 2
            NoteAnim.X = pbNote.Width
            NoteAnim.Xstart = NoteAnim.X
        End Select
        NoteAnim.Yend = pbNote.Height / 2 - Gfx.MeasureString("H", tFont).Height / 2
        NoteAnim.Ystart = NoteAnim.Yend
        NoteAnim.Y = NoteAnim.Yend
        NoteAnim.Ydir = -2

        NoteAnim.TextCount = 1
        NoteAnim.TextCurrent = 1

        Note_Text(1) = NoteAnim_Text(1)   'R4.00 Only show the first line.
        If Note_Text(1) <> "" Then HasText = True

      Case 1 'R4.00 L->R CRAWLER
        'R4.00 Do we need the defined delimiter string?
        tDelim = ""
        For t = 1 To 10
          If Trim(NoteAnim_Text(t)) <> "" Then Cnt += 1
        Next
        If 1 < Cnt Then tDelim = NoteAnim.Delim

        'R4.00 Build a giant string with all notes in it. Place Delimiter string in between each line.
        Note_Text(1) = ""
        For t = 1 To 10
          If Trim(NoteAnim_Text(t)) <> "" Then
            Note_Text(1) = Note_Text(1) & NoteAnim_Text(t) & tDelim
            HasText = True
          End If
        Next

        NoteAnim.Xstart = pbNote.Width
        NoteAnim.X = NoteAnim.Xstart
        NoteAnim.Xend = 0 - Gfx.MeasureString(Note_Text(1), tFont).Width
        NoteAnim.Xdir = NoteAnim.Speed * -1
        NoteAnim.Ystart = 0
        NoteAnim.Y = pbNote.Height / 2 - Gfx.MeasureString("H", tFont).Height / 2
        NoteAnim.TextCount = 1
        NoteAnim.TextCurrent = 1

      Case 2 'R4.00 UP CRAWLER
        'R4.00 Select X position by TEXT alignment setting.
        Select Case Val(NoteAnim.Align)
          Case 0
            NoteAnim.X = 0
            NoteAnim.Xstart = 0
          Case 1
            NoteAnim.X = pbNote.Width / 2
            NoteAnim.Xstart = NoteAnim.X
          Case 2
            NoteAnim.X = pbNote.Width
            NoteAnim.Xstart = NoteAnim.X
        End Select
        NoteAnim.Ystart = pbNote.Height
        NoteAnim.Y = NoteAnim.Ystart
        NoteAnim.Yend = pbNote.Height / 2 - Gfx.MeasureString("H", tFont).Height / 2
        NoteAnim.Ydir = NoteAnim.Speed * -1
        NoteAnim.TimeHold = NoteAnim.TimeHold

        NoteAnim.TextCurrent = 1
        NoteAnim.TextCount = 0
        For t = 1 To 10
          If Trim(NoteAnim_Text(t)) <> "" Then
            Note_Text(t) = NoteAnim_Text(t)
            NoteAnim.TextCount += 1
            HasText = True
          End If
        Next t

      Case 3 'R4.00 DOWN CRAWLER
        'R4.00 Select X position by TEXT alignment setting.
        Select Case Val(NoteAnim.Align)
          Case 0
            NoteAnim.X = 0
            NoteAnim.Xstart = 0
          Case 1
            NoteAnim.X = pbNote.Width / 2
            NoteAnim.Xstart = NoteAnim.X
          Case 2
            NoteAnim.X = pbNote.Width
            NoteAnim.Xstart = NoteAnim.X
        End Select
        NoteAnim.Ystart = 0 - Gfx.MeasureString("H", tFont).Height * 1.1
        NoteAnim.Y = NoteAnim.Ystart
        NoteAnim.Yend = pbNote.Height / 2 - Gfx.MeasureString("H", tFont).Height / 2
        NoteAnim.Ydir = NoteAnim.Speed * 1
        NoteAnim.TimeHold = NoteAnim.TimeHold

        NoteAnim.TextCurrent = 1
        NoteAnim.TextCount = 0
        For t = 1 To 10
          If Trim(NoteAnim_Text(t)) <> "" Then
            Note_Text(t) = NoteAnim_Text(t)
            NoteAnim.TextCount += 1
            HasText = True
          End If
        Next t

      Case 4 'R4.00 FADE IN
        'R4.00 Select X position by TEXT alignment setting.
        Select Case Val(NoteAnim.Align)
          Case 0
            NoteAnim.X = 0
            NoteAnim.Xstart = 0
          Case 1
            NoteAnim.X = pbNote.Width / 2
            NoteAnim.Xstart = NoteAnim.X
          Case 2
            NoteAnim.X = pbNote.Width
            NoteAnim.Xstart = NoteAnim.X
        End Select
        NoteAnim.Ystart = 0
        NoteAnim.Y = pbNote.Height / 2 - Gfx.MeasureString("H", tFont).Height / 2
        NoteAnim.Yend = 255
        NoteAnim.Ydir = NoteAnim.Speed * 1
        NoteAnim.TimeHold = NoteAnim.TimeHold

        NoteAnim.TextCurrent = 1
        NoteAnim.TextCount = 0
        For t = 1 To 10
          If Trim(NoteAnim_Text(t)) <> "" Then
            Note_Text(t) = NoteAnim_Text(t)
            NoteAnim.TextCount += 1
            HasText = True
          End If
        Next t

      Case 5 'R4.10 UP CRAWLER
        'R4.10 Select X position by TEXT alignment setting.
        Select Case Val(NoteAnim.Align)
          Case 0
            NoteAnim.X = 0
            NoteAnim.Xstart = 0
          Case 1
            NoteAnim.X = pbNote.Width / 2
            NoteAnim.Xstart = NoteAnim.X
          Case 2
            NoteAnim.X = pbNote.Width
            NoteAnim.Xstart = NoteAnim.X
        End Select
        NoteAnim.Ystart = pbNote.Height
        NoteAnim.Y = NoteAnim.Ystart
        NoteAnim.Yend = 0 - Gfx.MeasureString("H", tFont).Height
        NoteAnim.Ydir = NoteAnim.Speed * -1
        NoteAnim.TimeHold = 0 'NoteAnim.TimeHold

        NoteAnim.TextCurrent = 1
        NoteAnim.TextCount = 0
        For t = 1 To 10
          If Trim(NoteAnim_Text(t)) <> "" Then
            Note_Text(t) = NoteAnim_Text(t)
            NoteAnim.TextCount += 1
            HasText = True
          End If
        Next t

    End Select

    NoteAnim.Active = HasText

    Gfx.Dispose()
    BM.Dispose()

  End Sub


  Private Sub timNote1_Tick(sender As Object, e As EventArgs) Handles timNote1.Tick
    'R4.10 Tried STOPWATCH to get smoother renders but results were worse.

    'R4.10 We can get slightly smoother animations using INVALIDATE and this sub to update the screen.
    'R4.10 But there is a CPU cost (about 10x).
    If ANIMATION_Smooth Then
      Invalidate()
    Else
      If (cmNote01_Play.Text = "||") And (NoteAnim01.Active) Then Call NOTE_Animate(pbNote1, Note01_Text, LSNote01, FONT_Note01, NoteAnim01, Note01_Bmp, Note01_Gfx, Note01_BackBmp, Note01_OVLBmp)
      If (cmNote02_Play.Text = "||") And (NoteAnim02.Active) Then Call NOTE_Animate(pbNote2, Note02_Text, LSNote02, FONT_Note02, NoteAnim02, Note02_Bmp, Note02_Gfx, Note02_BackBmp, Note02_OVLBmp)
      If (cmNote03_Play.Text = "||") And (NoteAnim03.Active) Then Call NOTE_Animate(pbNote3, Note03_Text, LSNote03, FONT_Note03, NoteAnim03, Note03_Bmp, Note03_Gfx, Note03_BackBmp, Note03_OVLBmp)
      If (cmNote04_Play.Text = "||") And (NoteAnim04.Active) Then Call NOTE_Animate(pbNote4, Note04_Text, LSNote04, FONT_Note04, NoteAnim04, Note04_Bmp, Note04_Gfx, Note04_BackBmp, Note04_OVLBmp)
    End If

  End Sub

  Private Sub NOTE_Animate(ByRef pbNote As PictureBox, ByRef Note() As String, ByRef LSNote As clsGlobal.t_LabelSetup, ByRef tFont As Font, ByRef NoteAnim As clsGlobal.t_NoteAnimation, ByRef BM As Bitmap, ByRef Gfx As Graphics, ByRef BackBmp As Bitmap, ByRef OVLBmp As Bitmap)
    Dim linGrBrush As Drawing2D.LinearGradientBrush
    Dim SF As StringFormat = New StringFormat()
    Dim TextHgt12 As Integer
    Dim tY As Integer
    Dim sX, sY, sY2 As Single

    '*****************************************************************
    'R4.00 Draw the background image.
    '*****************************************************************
    If BackBmp Is Nothing Then
      'R3.00 No image available so draw a solid color background.
      'R4.00 without this we get a motion blur effect due to gradient alpha not clearing the image.
      'Gfx.FillRectangle(New SolidBrush(LSNote.BackC), 0, 0, pbNote.Width, pbNote.Height)
    Else
      'R3.00 Scale and Draw the background image.
      Select Case Val(LSNote.Scaling)
        Case 0   'R3.00 Normal Scaling
          Gfx.DrawImage(BackBmp, 0, 0, BackBmp.Width, BackBmp.Height)
        Case 1   'R3.00 Tiled Scaling
          For tY = 0 To BM.Height Step BackBmp.Height
            For tX = 0 To BM.Width Step BackBmp.Width
              Gfx.DrawImage(BackBmp, tX, tY, BackBmp.Width, BackBmp.Height)
            Next
          Next
        Case 2 'R3.00 Stretch/Fit Scaling
          Gfx.DrawImage(BackBmp, 0, 0, BM.Width, BM.Height)
      End Select
    End If

    '*****************************************************************
    'R4.00 Draw the background GRADIENT
    '*****************************************************************
    Dim tBrush As SolidBrush = New SolidBrush(LSNote.ShadowColor)
    Dim tBrushFore As SolidBrush = New SolidBrush(LSNote.F1)        'R4.00  

    If NoteAnim.Mode = 4 Then
      tBrush = New SolidBrush(Color.FromArgb(NoteAnim.Ystart, LSNote.ShadowColor))
    Else
      tBrush = New SolidBrush(LSNote.ShadowColor)
    End If

    TextHgt12 = Gfx.MeasureString("H", tFont).Height / 2

    'R3.00 Draw the background rectangle.
    If LSNote.BDir = 0 Then
      linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, pbNote.Height), LSNote.B1, LSNote.B2)
    Else
      linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(pbNote.Width, 0), LSNote.B1, LSNote.B2)
    End If
    Gfx.FillRectangle(linGrBrush, 0, 0, pbNote.Width, pbNote.Height)

    'R4.10 Move/Animate NOTE OBJECTS.
    If NoteAnim.Holding = False Then
      Select Case NoteAnim.Mode
        Case 1
          NoteAnim.X += NoteAnim.Xdir
        Case 0, 2, 5
          NoteAnim.Y += NoteAnim.Ydir
          If NoteAnim.Y <= NoteAnim.Yend Then NoteAnim.Y = NoteAnim.Yend
        Case 3
          NoteAnim.Y += NoteAnim.Ydir
          If NoteAnim.Y >= NoteAnim.Yend Then NoteAnim.Y = NoteAnim.Yend
        Case 4  'R4.00 Use Ystart as ALPHA counter. Limit to 255 or overflow.
          NoteAnim.Ystart += NoteAnim.Ydir
          If 255 < NoteAnim.Ystart Then NoteAnim.Ystart = 255
          If NoteAnim.Y >= NoteAnim.Yend Then NoteAnim.Y = NoteAnim.Yend
      End Select
    End If

    'R4.00 Setup text align, RLCrawl is always Near aligned.
    Select Case Val(NoteAnim.Align)
      Case 0
        SF.Alignment = StringAlignment.Near
      Case 1
        SF.Alignment = StringAlignment.Center
      Case 2
        SF.Alignment = StringAlignment.Far
    End Select
    If NoteAnim.Mode = 1 Then SF.Alignment = StringAlignment.Near

    'R4.00 Draw the TEXT SHADOW if one has been selected.
    If (0 <> LSNote.ShadowX) Or (0 <> LSNote.ShadowY) Then
      Gfx.DrawString(Note(NoteAnim.TextCurrent), tFont, tBrush, NoteAnim.X + LSNote.ShadowX * Val(LSNote.ShadowDepth) + NoteAnim.Xoffset, NoteAnim.Y + LSNote.ShadowY * Val(LSNote.ShadowDepth) + NoteAnim.Yoffset, SF)

      'R4.10 Print all messages for ROLLING style.
      If NoteAnim.Mode = 5 Then
        sX = NoteAnim.X + LSNote.ShadowX * Val(LSNote.ShadowDepth) + NoteAnim.Xoffset
        sY = NoteAnim.Y + LSNote.ShadowY * Val(LSNote.ShadowDepth) + NoteAnim.Yoffset
        For t = 1 To (NoteAnim.TextCount - NoteAnim.TextCurrent)
          sY2 = sY + (TextHgt12 + TextHgt12) * t
          If sY2 < pbNote.Height Then Gfx.DrawString(Note(NoteAnim.TextCurrent + t), tFont, tBrush, sX, sY2, SF)
        Next t
      End If
    End If


    'R4.00 Adjust gradients for moving text.
    sX = NoteAnim.X + NoteAnim.Xoffset
    sY = NoteAnim.Y + NoteAnim.Yoffset
    If NoteAnim.Mode = 4 Then
      'R4.00 Build ALPHA animation gradient brush for text.
      If LSNote.FDir = 0 Then
        linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, sY), New Point(0, sY + TextHgt12 + TextHgt12), Color.FromArgb(NoteAnim.Ystart, LSNote.F1.R, LSNote.F1.G, LSNote.F1.B), Color.FromArgb(NoteAnim.Ystart, LSNote.F2.R, LSNote.F2.G, LSNote.F2.B))
      Else
        linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(pbNote.Width, 0), Color.FromArgb(NoteAnim.Ystart, LSNote.F1.R, LSNote.F1.G, LSNote.F1.B), Color.FromArgb(NoteAnim.Ystart, LSNote.F2.R, LSNote.F2.G, LSNote.F2.B))
      End If
    Else
      'R4.00 Build gradient brush for text.
      If LSNote.FDir = 0 Then
        linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, sY), New Point(0, sY + TextHgt12 + TextHgt12), Color.FromArgb(255, LSNote.F1.R, LSNote.F1.G, LSNote.F1.B), Color.FromArgb(255, LSNote.F2.R, LSNote.F2.G, LSNote.F2.B))
      Else
        linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(pbNote.Width, 0), Color.FromArgb(255, LSNote.F1.R, LSNote.F1.G, LSNote.F1.B), Color.FromArgb(255, LSNote.F2.R, LSNote.F2.G, LSNote.F2.B))
      End If
    End If
    Gfx.DrawString(Note(NoteAnim.TextCurrent), tFont, linGrBrush, sX, sY, SF)

    'R4.10 Print all messages for ROLLING style.
    If NoteAnim.Mode = 5 Then
      For t = 1 To (NoteAnim.TextCount - NoteAnim.TextCurrent)
        tY = (TextHgt12 + TextHgt12) * t
        tY = NoteAnim.Y + NoteAnim.Yoffset + tY
        If tY < pbNote.Height Then
          If LSNote.FDir = 0 Then
            linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, tY), New Point(0, TextHgt12 + TextHgt12 + tY), Color.FromArgb(255, LSNote.F1.R, LSNote.F1.G, LSNote.F1.B), Color.FromArgb(255, LSNote.F2.R, LSNote.F2.G, LSNote.F2.B))
          Else
            linGrBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0 + tY), New Point(pbNote.Width, 0 + tY), Color.FromArgb(255, LSNote.F1.R, LSNote.F1.G, LSNote.F1.B), Color.FromArgb(255, LSNote.F2.R, LSNote.F2.G, LSNote.F2.B))
          End If
          Gfx.DrawString(Note(NoteAnim.TextCurrent + t), tFont, linGrBrush, NoteAnim.X + NoteAnim.Xoffset, tY, SF)
        End If
      Next t
    End If

    '*****************************************************************
    'R3.50 Draw the NOTE OVERLAY image.
    '*****************************************************************
    If Not (OVLBmp Is Nothing) Then
      'R3.00 Scale and Draw the background image.
      Select Case Val(LSNote.OVLScaling)
        Case 0   'R3.00 Normal Scaling
          Gfx.DrawImage(OVLBmp, 0, 0, OVLBmp.Width, OVLBmp.Height)
        Case 1   'R3.00 Tiled Scaling
          For tY = 0 To BM.Height Step OVLBmp.Height
            For tX = 0 To BM.Width Step OVLBmp.Width
              Gfx.DrawImage(OVLBmp, tX, tY, OVLBmp.Width, OVLBmp.Height)
            Next
          Next
        Case 2 'R3.00 Stretch/Fit Scaling
          'R4.00 MS sux.
          If (OVLBmp.Width < BM.Width) Or (OVLBmp.Height < BM.Height) Then
            Dim Xoff As Single = BM.Width / OVLBmp.Width
            Dim Yoff As Single = BM.Height / OVLBmp.Height
            Gfx.DrawImage(OVLBmp, 0, 0, BM.Width + Xoff, BM.Height + Yoff)
          Else
            Gfx.DrawImage(OVLBmp, 0, 0, BM.Width, BM.Height)
          End If
      End Select
    End If

    If NoteAnim.Holding = False Then
      Select Case NoteAnim.Mode
        Case 1
          If NoteAnim.X = NoteAnim.Xend Then NoteAnim.Holding = True : NoteAnim.TimeAcc = 0
        Case 0, 2, 5
          If NoteAnim.Y <= NoteAnim.Yend Then
            NoteAnim.Y = NoteAnim.Yend
            NoteAnim.Holding = True
            NoteAnim.TimeAcc = 0
          End If
        Case 3
          If NoteAnim.Y >= NoteAnim.Yend Then
            NoteAnim.Y = NoteAnim.Yend
            NoteAnim.Holding = True
            NoteAnim.TimeAcc = 0
          End If
        Case 4
          If NoteAnim.Ystart >= NoteAnim.Yend Then
            NoteAnim.Ystart = NoteAnim.Yend
            NoteAnim.Holding = True
            NoteAnim.TimeAcc = 0
          End If
      End Select
    End If

    NoteAnim.TimeAcc += 33
    If (NoteAnim.TimeHold * 1000) < NoteAnim.TimeAcc Then NoteAnim.Holding = False   'R4.00 TimeHold is in secs, need mS.

    'R4.00 Are we done animating a section/Line.
    If NoteAnim.Holding = False Then
      Select Case NoteAnim.Mode
        Case 1
          If NoteAnim.X < NoteAnim.Xend Then NoteAnim.X = NoteAnim.Xstart
        Case 0, 2, 5
          If NoteAnim.Y <= NoteAnim.Yend Then
            NoteAnim.TimeAcc = 0

            If NoteAnim.Mode = 5 Then
              NoteAnim.Y += (TextHgt12 + TextHgt12)
            Else
              NoteAnim.Y = NoteAnim.Ystart
            End If

            NoteAnim.TextCurrent += 1
            If NoteAnim.TextCount < NoteAnim.TextCurrent Then
              NoteAnim.TextCurrent = 1
              If NoteAnim.Mode = 5 Then NoteAnim.Y = NoteAnim.Ystart
            End If
          End If

        Case 3
          If NoteAnim.Y >= NoteAnim.Yend Then
            NoteAnim.TimeAcc = 0
            NoteAnim.Y = NoteAnim.Ystart
            NoteAnim.TextCurrent += 1
            If NoteAnim.TextCount < NoteAnim.TextCurrent Then NoteAnim.TextCurrent = 1
          End If
        Case 4
          If NoteAnim.Ystart >= NoteAnim.Yend Then
            NoteAnim.TimeAcc = 0
            NoteAnim.Ystart = 0
            NoteAnim.TextCurrent += 1
            If NoteAnim.TextCount < NoteAnim.TextCurrent Then NoteAnim.TextCurrent = 1
          End If
      End Select
    End If

    '3.50 Update the Screen.
    pbNote.Image = BM

  End Sub

  Private Sub SOUND_Play(tFile As String)

    Try
      My.Computer.Audio.Stop()
      My.Computer.Audio.Play(tFile, AudioPlayMode.Background)
    Catch
      lbError1.Text = "Error playing"
      lbError2.Text = "sound file"
      MsgBox("ERROR: " & Err.Description & vbCr & vbCr & "Unable to play this sound file.", MsgBoxStyle.Critical)  'R4.10 Updated.
    End Try


  End Sub

  Private Sub SOUND_HandleClicks(Sender As Object, e As MouseEventArgs, Index As Integer)
    'R4.10 Store which object we are working with so we can set tooltip in other subs.
    CELO_PopUpObject = Sender
    Celo_PopupHit = Index

    If 0 < (Control.ModifierKeys And Keys.Control) Then

      SOUND_File(Index) = ""
      ToolTip1.SetToolTip(Sender, "Left click to play a sound." & vbCr & "Right click to map a sound or set the volume." & vbCr & "Ctrl-Click to delete.")
      'If ToolTip1.Active = False Then 

    Else
      If (e.Button = Windows.Forms.MouseButtons.Left) And (SOUND_File(Index) <> "") Then

        AUDIO_SetVolume(scrVolume.Value, SOUND_Vol(Index))
        SOUND_Play(SOUND_File(Index))

      Else

        If (SOUND_File(Index) <> "") Then
          POPUP_Audio_SetMenu(SOUND_Vol(Index))
          tsmAudio.Show(Sender, New Point(e.X, e.Y))
        Else
          Call AUDIO_SelectFile(Index)
        End If

      End If

    End If

  End Sub

  Private Sub POPUP_Audio_SetMenu(Vol As Integer)

    tsmSetVolTo100.Checked = False
    If Vol = 100 Then tsmSetVolTo100.Checked = True

    tsmSetVolTo90.Checked = False
    If Vol = 90 Then tsmSetVolTo90.Checked = True

    tsmSetVolTo80.Checked = False
    If Vol = 80 Then tsmSetVolTo80.Checked = True

    tsmSetVolTo70.Checked = False
    If Vol = 70 Then tsmSetVolTo70.Checked = True

    tsmSetVolTo60.Checked = False
    If Vol = 60 Then tsmSetVolTo60.Checked = True

    tsmSetVolTo50.Checked = False
    If Vol = 50 Then tsmSetVolTo50.Checked = True

    tsmSetVolTo40.Checked = False
    If Vol = 40 Then tsmSetVolTo40.Checked = True

    tsmSetVolTo30.Checked = False
    If Vol = 30 Then tsmSetVolTo30.Checked = True

    tsmSetVolTo20.Checked = False
    If Vol = 20 Then tsmSetVolTo20.Checked = True

    tsmSetVolTo10.Checked = False
    If Vol = 10 Then tsmSetVolTo10.Checked = True

  End Sub

  Private Function SOUND_GetName(tFile As String) As String
    Dim i As Integer
    Dim Hit As Integer
    Dim S As String

    Hit = 0
    For i = Len(tFile) To 1 Step -1
      If Mid(tFile, i, 1) = "\" Then Hit = i : Exit For
    Next

    If Hit Then
      S = Mid(tFile, Hit + 1, 255)
    Else
      S = tFile
    End If

    SOUND_GetName = LCase(S)

  End Function
  Private Sub cmAudioStop_Click(sender As Object, e As EventArgs) Handles cmAudioStop.Click
    'R4.34 Stop ALL audio being played. Sound Pads and Rank reader.
    My.Computer.Audio.Stop()
    If FLAG_SpeechOK Then SpeechSynth.SpeakAsyncCancelAll()
  End Sub
  Private Sub cmSound01_Click(sender As Object, e As EventArgs) Handles cmSound01.Click
    'R4.00 Not used
  End Sub
  Private Sub cmSound01_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound01.MouseDown
    Call SOUND_HandleClicks(sender, e, 1)
  End Sub
  Private Sub cmSound02_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound02.MouseDown
    Call SOUND_HandleClicks(sender, e, 2)
  End Sub
  Private Sub cmSound03_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound03.MouseDown
    Call SOUND_HandleClicks(sender, e, 3)
  End Sub
  Private Sub cmSound04_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound04.MouseDown
    Call SOUND_HandleClicks(sender, e, 4)
  End Sub
  Private Sub cmSound05_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound05.MouseDown
    Call SOUND_HandleClicks(sender, e, 5)
  End Sub
  Private Sub cmSound06_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound06.MouseDown
    Call SOUND_HandleClicks(sender, e, 6)
  End Sub
  Private Sub cmSound07_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound07.MouseDown
    Call SOUND_HandleClicks(sender, e, 7)
  End Sub
  Private Sub cmSound08_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound08.MouseDown
    Call SOUND_HandleClicks(sender, e, 8)
  End Sub
  Private Sub cmSound09_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound09.MouseDown
    Call SOUND_HandleClicks(sender, e, 9)
  End Sub
  Private Sub cmSound10_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound10.MouseDown
    Call SOUND_HandleClicks(sender, e, 10)
  End Sub
  Private Sub cmSound11_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound11.MouseDown
    Call SOUND_HandleClicks(sender, e, 11)
  End Sub
  Private Sub cmSound12_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound12.MouseDown
    Call SOUND_HandleClicks(sender, e, 12)
  End Sub
  Private Sub cmSound13_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound13.MouseDown
    Call SOUND_HandleClicks(sender, e, 13)
  End Sub
  Private Sub cmSound14_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound14.MouseDown
    Call SOUND_HandleClicks(sender, e, 14)
  End Sub
  Private Sub cmSound15_MouseDown(sender As Object, e As MouseEventArgs) Handles cmSound15.MouseDown
    Call SOUND_HandleClicks(sender, e, 15)
  End Sub

  Private Sub cmSound01_MouseHover(sender As Object, e As EventArgs) Handles cmSound01.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(1))
  End Sub
  Private Sub cmSound02_MouseHover(sender As Object, e As EventArgs) Handles cmSound02.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(2))
  End Sub
  Private Sub cmSound03_MouseHover(sender As Object, e As EventArgs) Handles cmSound03.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(3))
  End Sub
  Private Sub cmSound04_MouseHover(sender As Object, e As EventArgs) Handles cmSound04.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(4))
  End Sub
  Private Sub cmSound05_MouseHover(sender As Object, e As EventArgs) Handles cmSound05.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(5))
  End Sub
  Private Sub cmSound06_MouseHover(sender As Object, e As EventArgs) Handles cmSound06.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(6))
  End Sub
  Private Sub cmSound07_MouseHover(sender As Object, e As EventArgs) Handles cmSound07.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(7))
  End Sub
  Private Sub cmSound08_MouseHover(sender As Object, e As EventArgs) Handles cmSound08.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(8))
  End Sub
  Private Sub cmSound09_MouseHover(sender As Object, e As EventArgs) Handles cmSound09.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(9))
  End Sub
  Private Sub cmSound10_MouseHover(sender As Object, e As EventArgs) Handles cmSound10.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(10))
  End Sub
  Private Sub cmSound11_MouseHover(sender As Object, e As EventArgs) Handles cmSound11.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(11))
  End Sub
  Private Sub cmSound12_MouseHover(sender As Object, e As EventArgs) Handles cmSound12.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(12))
  End Sub
  Private Sub cmSound13_MouseHover(sender As Object, e As EventArgs) Handles cmSound13.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(13))
  End Sub
  Private Sub cmSound14_MouseHover(sender As Object, e As EventArgs) Handles cmSound14.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(14))
  End Sub
  Private Sub cmSound15_MouseHover(sender As Object, e As EventArgs) Handles cmSound15.MouseHover
    lbSoundCurrent.Text = SOUND_GetName(SOUND_File(15))
  End Sub

  Private Sub cmSound01_MouseLeave(sender As Object, e As EventArgs) Handles cmSound01.MouseLeave, cmSound02.MouseLeave, cmSound03.MouseLeave, cmSound04.MouseLeave, cmSound05.MouseLeave, cmSound06.MouseLeave, cmSound07.MouseLeave, cmSound08.MouseLeave, cmSound09.MouseLeave, cmSound10.MouseLeave, cmSound11.MouseLeave, cmSound12.MouseLeave, cmSound13.MouseLeave, cmSound14.MouseLeave, cmSound15.MouseLeave
    lbSoundCurrent.Text = ""
  End Sub

  Private Sub SCREEN_Organize()

    'R4.00 Adjust pictures Y positions based on their size.
    'R4.00 NOTE_Spacing lets you keep Notes together if wanted.
    pbNote1.Top = pbStats.Top + pbStats.Height + 2
    pbNote2.Top = pbNote1.Top + pbNote1.Height + NOTE_Spacing
    pbNote3.Top = pbNote2.Top + pbNote2.Height + NOTE_Spacing
    pbNote4.Top = pbNote3.Top + pbNote3.Height + NOTE_Spacing

  End Sub


  Private Sub cmRankSetup_Click(sender As Object, e As EventArgs) Handles cmRankSetup.Click
    Dim LBDialog As frmLabelSetup = New frmLabelSetup With {.HideSizeOptions = True, .HideSizeAll = True}

    'R4.00 Get the data we are editing.
    LSRank.BackC = LSName.BackC             'R4.00 Name has backround info that is used.
    LSRank.Scaling = LSName.Scaling         'R4.10 Name has scaling info.
    LSRank.OVLScaling = LSName.OVLScaling   'R4.10 Name has scaling info.
    LBDialog.LSetup = LSRank
    FONT_Setup = FONT_Rank

    PATH_DlgBmp = PATH_BackgroundImage                      'R4.00 Path for back image.
    Note_BackBmp = NAME_bmp                                 'R4.00 Back Image.
    PATH_DlgBmpPath = PATH_StripFilename(PATH_DlgBmp)
    PATH_DlgOVLBmp = PATH_Name_OVLBmp                       'R4.00 Path for back image.
    Note_OVLBmp = NAME_OVLBmp                               'R4.00 Back Image.
    PATH_DlgOVLBmpPath = PATH_StripFilename(PATH_DlgOVLBmp)

    'R4.00 Call the setup dialog and default to CANCEL being pressed.
    LBDialog.ShowDialog()

    If LBDialog.Cancel = False Then
      LSRank = LBDialog.LSetup
      FONT_Rank = FONT_Setup
      FONT_Rank_Name = FONT_Setup.Name
      FONT_Rank_Size = FONT_Setup.Size
      FONT_Rank_Bold = FONT_Setup.Bold
      FONT_Rank_Italic = FONT_Setup.Italic
      LSRank.B1 = Color.FromArgb(255 * (Val(LSRank.O1) * 0.01), LSRank.B1.R, LSRank.B1.G, LSRank.B1.B)
      LSRank.B2 = Color.FromArgb(255 * (Val(LSRank.O2) * 0.01), LSRank.B2.R, LSRank.B2.G, LSRank.B2.B)

      NAME_bmp = Note_BackBmp
      PATH_BackgroundImage = PATH_DlgBmp
      PATH_BackgroundImagePath = PATH_StripFilename(PATH_DlgBmp)
      NAME_OVLBmp = Note_OVLBmp
      PATH_Name_OVLBmp = PATH_DlgOVLBmp
      PATH_Name_OVLBmpPath = PATH_StripFilename(PATH_DlgOVLBmp)
      pbStats.BackColor = LSRank.BackC
      LSName.BackC = LSRank.BackC

      'R4.10 We use the NAME info when drawing.
      LSName.Scaling = LSRank.Scaling
      LSName.OVLScaling = LSRank.OVLScaling

      'R4.40 Name and Rank CARD BACK must be the same.
      LSName.UseCardBack = LSRank.UseCardBack
      LSName.BorderPanelMode = LSRank.BorderPanelMode
      LSName.BorderPanelColor = LSRank.BorderPanelColor
      LSName.BorderPanelWidth = LSRank.BorderPanelWidth

      'R4.50 Force the BLUR mask to be redrawn.
      MainBlur_Valid = False

      'R4.50 Force a clean STATS redraw.
      MainBuffer_Valid = False
    End If

    LBDialog.Dispose()

    SETTINGS_Save("")
    Call SCREEN_Organize()
    Call GFX_DrawStats()

  End Sub

  Private Sub cmNameSetup_Click(sender As Object, e As EventArgs) Handles cmNameSetup.Click
    Dim LBDialog As frmLabelSetup = New frmLabelSetup With {.HideSizeOptions = True, .HideSizeAll = True}

    'R4.00 Get the data we are editing.
    LBDialog.LSetup = LSName
    FONT_Setup = FONT_Name
    PATH_DlgBmp = PATH_BackgroundImage                      'R4.00 Path for back image.
    Note_BackBmp = NAME_bmp                                 'R4.00 Back Image.
    PATH_DlgBmpPath = PATH_StripFilename(PATH_DlgBmp)
    PATH_DlgOVLBmp = PATH_Name_OVLBmp                       'R4.00 Path for back image.
    Note_OVLBmp = NAME_OVLBmp                               'R4.00 Back Image.
    PATH_DlgOVLBmpPath = PATH_StripFilename(PATH_DlgOVLBmp)

    'R4.00 Call the setup dialog and default to CANCEL being pressed.
    LBDialog.ShowDialog()

    If LBDialog.Cancel = False Then
      LSName = LBDialog.LSetup
      FONT_Name = FONT_Setup
      FONT_Name_Name = FONT_Setup.Name
      FONT_Name_Size = FONT_Setup.Size
      FONT_Name_Bold = FONT_Setup.Bold
      FONT_Name_Italic = FONT_Setup.Italic
      LSName.B1 = Color.FromArgb(255 * (Val(LSName.O1) * 0.01), LSName.B1.R, LSName.B1.G, LSName.B1.B)
      LSName.B2 = Color.FromArgb(255 * (Val(LSName.O2) * 0.01), LSName.B2.R, LSName.B2.G, LSName.B2.B)

      NAME_bmp = Note_BackBmp
      PATH_BackgroundImage = PATH_DlgBmp
      PATH_BackgroundImagePath = PATH_StripFilename(PATH_DlgBmp)
      NAME_OVLBmp = Note_OVLBmp
      PATH_Name_OVLBmp = PATH_DlgOVLBmp
      PATH_Name_OVLBmpPath = PATH_StripFilename(PATH_DlgOVLBmp)
      pbStats.BackColor = LSName.BackC

      'R4.40 Name and Rank CARD BACK must be the same.
      LSRank.UseCardBack = LSName.UseCardBack
      LSRank.BorderPanelMode = LSName.BorderPanelMode
      LSRank.BorderPanelColor = LSName.BorderPanelColor
      LSRank.BorderPanelWidth = LSName.BorderPanelWidth

      'R4.50 Force the BLUR mask to be redrawn.
      MainBlur_Valid = False

      'R4.50 Force a clean STATS redraw.
      MainBuffer_Valid = False
    End If

    LBDialog.Dispose()

    SETTINGS_Save("")
    Call SCREEN_Organize()
    Call GFX_DrawStats()
  End Sub

  Private Sub cmNote_PlayAll_Click(sender As Object, e As EventArgs) Handles cmNote_PlayAll.Click
    'R4.00 Turn ON/OFF all NOTE animations.
    If cmNote_PlayAll.Text = ">" Then
      cmNote01Setup.Enabled = False
      cmNote02Setup.Enabled = False
      cmNote03Setup.Enabled = False
      cmNote04Setup.Enabled = False
      cmNote_PlayAll.Text = "||"
      cmNote01_Play.Text = "||"
      cmNote02_Play.Text = "||"
      cmNote03_Play.Text = "||"
      cmNote04_Play.Text = "||"
      Call NOTE_Animation_Setup(NoteAnim01, pbNote1, FONT_Note01, Note01_Text, NoteAnim01_Text)
      Call NOTE_Animation_Setup(NoteAnim02, pbNote2, FONT_Note02, Note02_Text, NoteAnim02_Text)
      Call NOTE_Animation_Setup(NoteAnim03, pbNote3, FONT_Note03, Note03_Text, NoteAnim03_Text)
      Call NOTE_Animation_Setup(NoteAnim04, pbNote4, FONT_Note04, Note04_Text, NoteAnim04_Text)
    Else
      cmNote01Setup.Enabled = True
      cmNote02Setup.Enabled = True
      cmNote03Setup.Enabled = True
      cmNote04Setup.Enabled = True
      cmNote_PlayAll.Text = ">"
      cmNote01_Play.Text = ">"
      cmNote02_Play.Text = ">"
      cmNote03_Play.Text = ">"
      cmNote04_Play.Text = ">"
    End If

  End Sub

  Private Sub cmNote01_Play_Click(sender As Object, e As EventArgs) Handles cmNote01_Play.Click
    If cmNote01_Play.Text = ">" Then
      cmNote01Setup.Enabled = False
      cmNote01_Play.Text = "||"
      Call NOTE_Animation_Setup(NoteAnim01, pbNote1, FONT_Note01, Note01_Text, NoteAnim01_Text)
    Else
      cmNote01Setup.Enabled = True
      cmNote01_Play.Text = ">"
    End If

  End Sub

  Private Sub cmNote02_Play_Click(sender As Object, e As EventArgs) Handles cmNote02_Play.Click
    If cmNote02_Play.Text = ">" Then
      cmNote02Setup.Enabled = False
      cmNote02_Play.Text = "||"
      Call NOTE_Animation_Setup(NoteAnim02, pbNote2, FONT_Note02, Note02_Text, NoteAnim02_Text)
    Else
      cmNote02Setup.Enabled = True
      cmNote02_Play.Text = ">"
    End If

  End Sub

  Private Sub cmNote03_Play_Click(sender As Object, e As EventArgs) Handles cmNote03_Play.Click
    If cmNote03_Play.Text = ">" Then
      cmNote03Setup.Enabled = False
      cmNote03_Play.Text = "||"
      Call NOTE_Animation_Setup(NoteAnim03, pbNote3, FONT_Note03, Note03_Text, NoteAnim03_Text)
    Else
      cmNote03Setup.Enabled = True
      cmNote03_Play.Text = ">"
    End If

  End Sub

  Private Sub cmNote04_Play_Click(sender As Object, e As EventArgs) Handles cmNote04_Play.Click
    If cmNote04_Play.Text = ">" Then
      cmNote04Setup.Enabled = False
      cmNote04_Play.Text = "||"
      Call NOTE_Animation_Setup(NoteAnim04, pbNote4, FONT_Note04, Note04_Text, NoteAnim04_Text)
    Else
      cmNote04Setup.Enabled = True
      cmNote04_Play.Text = ">"
    End If

  End Sub

  Private Sub NOTE_AdjustBitmap(ByRef pbNote As PictureBox, ByRef LSNote As clsGlobal.t_LabelSetup, ByRef BM As Bitmap, ByRef Gfx As Graphics)

    pbNote.Width = LSNote.Width
    pbNote.Height = LSNote.Height

    BM = New Bitmap(pbNote.Width, pbNote.Height)
    Gfx = Graphics.FromImage(BM)

  End Sub

  Private Sub NOTE_CheckNoteSizes()

    'R4.00 If the NOTE size was changed, update the picture box size.
    If (LSNote01.Width <> pbNote1.Width) Or (LSNote01.Height <> pbNote1.Height) Then Call NOTE_AdjustBitmap(pbNote1, LSNote01, Note01_Bmp, Note01_Gfx)
    If (LSNote02.Width <> pbNote2.Width) Or (LSNote02.Height <> pbNote2.Height) Then Call NOTE_AdjustBitmap(pbNote2, LSNote02, Note02_Bmp, Note02_Gfx)
    If (LSNote03.Width <> pbNote3.Width) Or (LSNote03.Height <> pbNote3.Height) Then Call NOTE_AdjustBitmap(pbNote3, LSNote03, Note03_Bmp, Note03_Gfx)
    If (LSNote04.Width <> pbNote4.Width) Or (LSNote04.Height <> pbNote4.Height) Then Call NOTE_AdjustBitmap(pbNote4, LSNote04, Note04_Bmp, Note04_Gfx)

    Call SCREEN_Organize()

  End Sub


  Private Sub cmNote01Setup_Click_1(sender As Object, e As EventArgs) Handles cmNote01Setup.Click
    Dim LBDialog As frmLabelSetup = New frmLabelSetup With {.HideFormColor = True}

    'R4.00 Get the data we are editing.
    LBDialog.LSetup = LSNote01
    FONT_Setup = FONT_Note01
    PATH_DlgBmp = PATH_Note01_Bmp                       'R4.00 Path for back image.
    Note_BackBmp = Note01_BackBmp                       'R4.00 Back Image.
    PATH_DlgBmpPath = PATH_StripFilename(PATH_DlgBmp)
    PATH_DlgOVLBmp = PATH_Note01_OVLBmp                 'R4.00 Path for back image.
    Note_OVLBmp = Note01_OVLBmp                         'R4.00 Back Image.
    PATH_DlgOVLBmpPath = PATH_StripFilename(PATH_DlgOVLBmp)

    'R4.00 Call the setup dialog and default to CANCEL being pressed.
    LBDialog.ShowDialog()

    If LBDialog.Cancel = False Then
      LSNote01 = LBDialog.LSetup
      PATH_Note01_Bmp = PATH_DlgBmp        'R4.00 Path for back image.
      Note01_BackBmp = Note_BackBmp        'R4.00 Back Image.
      PATH_Note01_OVLBmp = PATH_DlgOVLBmp  'R4.00 Path for back image.
      Note01_OVLBmp = Note_OVLBmp          'R4.00 Overlay Image.

      FONT_Note01 = FONT_Setup
      FONT_Note01_Name = FONT_Setup.Name
      FONT_Note01_Size = FONT_Setup.Size
      FONT_Note01_Bold = FONT_Setup.Bold
      FONT_Note01_Italic = FONT_Setup.Italic
      LSNote01.B1 = Color.FromArgb(255 * (Val(LSNote01.O1) * 0.01), LSNote01.B1.R, LSNote01.B1.G, LSNote01.B1.B)
      LSNote01.B2 = Color.FromArgb(255 * (Val(LSNote01.O2) * 0.01), LSNote01.B2.R, LSNote01.B2.G, LSNote01.B2.B)

      Call NOTE_CheckNoteSizes()
      SETTINGS_Save("")
    End If

    LBDialog.Dispose()

  End Sub

  Private Sub cmNote02Setup_Click_1(sender As Object, e As EventArgs) Handles cmNote02Setup.Click
    Dim LBDialog As frmLabelSetup = New frmLabelSetup With {.HideFormColor = True}

    'R4.00 Get the data we are editing.
    LBDialog.LSetup = LSNote02
    FONT_Setup = FONT_Note02
    PATH_DlgBmp = PATH_Note02_Bmp                        'R4.00 Path for back image.
    Note_BackBmp = Note02_BackBmp                        'R4.00 Back Image.
    PATH_DlgBmpPath = PATH_StripFilename(PATH_DlgBmp)    'R4.00 Path without Filename. 
    PATH_DlgOVLBmp = PATH_Note02_OVLBmp                  'R4.00 Path for back image.
    Note_OVLBmp = Note02_OVLBmp                          'R4.00 Back Image.
    PATH_DlgOVLBmpPath = PATH_StripFilename(PATH_DlgOVLBmp)

    'R4.00 Call the setup dialog and default to CANCEL being pressed.
    LBDialog.ShowDialog()

    If LBDialog.Cancel = False Then
      LSNote02 = LBDialog.LSetup
      PATH_Note02_Bmp = PATH_DlgBmp        'R4.00 Path for back image.
      Note02_BackBmp = Note_BackBmp        'R4.00 Back Image.
      PATH_Note02_OVLBmp = PATH_DlgOVLBmp  'R4.00 Path for back image.
      Note02_OVLBmp = Note_OVLBmp          'R4.00 Overlay Image.

      FONT_Note02 = FONT_Setup
      FONT_Note02_Name = FONT_Setup.Name
      FONT_Note02_Size = FONT_Setup.Size
      FONT_Note02_Bold = FONT_Setup.Bold
      FONT_Note02_Italic = FONT_Setup.Italic
      LSNote02.B1 = Color.FromArgb(255 * (Val(LSNote02.O1) * 0.01), LSNote02.B1.R, LSNote02.B1.G, LSNote02.B1.B)
      LSNote02.B2 = Color.FromArgb(255 * (Val(LSNote02.O2) * 0.01), LSNote02.B2.R, LSNote02.B2.G, LSNote02.B2.B)

      Call NOTE_CheckNoteSizes()
      SETTINGS_Save("")
    End If

    LBDialog.Dispose()
  End Sub

  Private Sub cmNote03Setup_Click_1(sender As Object, e As EventArgs) Handles cmNote03Setup.Click
    Dim LBDialog As frmLabelSetup = New frmLabelSetup With {.HideFormColor = True}

    'R4.00 Get the data we are editing.
    LBDialog.LSetup = LSNote03
    FONT_Setup = FONT_Note03
    PATH_DlgBmp = PATH_Note03_Bmp                        'R4.00 Path for back image.
    Note_BackBmp = Note03_BackBmp                        'R4.00 Back Image.
    PATH_DlgBmpPath = PATH_StripFilename(PATH_DlgBmp)    'R4.00 Path without Filename. 
    PATH_DlgOVLBmp = PATH_Note03_OVLBmp                  'R4.00 Path for back image.
    Note_OVLBmp = Note03_OVLBmp                          'R4.00 Back Image.
    PATH_DlgOVLBmpPath = PATH_StripFilename(PATH_DlgOVLBmp)

    'R4.00 Call the setup dialog and default to CANCEL being pressed.
    LBDialog.ShowDialog()

    If LBDialog.Cancel = False Then
      LSNote03 = LBDialog.LSetup
      PATH_Note03_Bmp = PATH_DlgBmp        'R4.00 Path for back image.
      Note03_BackBmp = Note_BackBmp        'R4.00 Back Image.
      PATH_Note03_OVLBmp = PATH_DlgOVLBmp  'R4.00 Path for back image.
      Note03_OVLBmp = Note_OVLBmp          'R4.00 Overlay Image.

      FONT_Note03 = FONT_Setup
      FONT_Note03_Name = FONT_Setup.Name
      FONT_Note03_Size = FONT_Setup.Size
      FONT_Note03_Bold = FONT_Setup.Bold
      FONT_Note03_Italic = FONT_Setup.Italic
      LSNote03.B1 = Color.FromArgb(255 * (Val(LSNote03.O1) * 0.01), LSNote03.B1.R, LSNote03.B1.G, LSNote03.B1.B)
      LSNote03.B2 = Color.FromArgb(255 * (Val(LSNote03.O2) * 0.01), LSNote03.B2.R, LSNote03.B2.G, LSNote03.B2.B)

      Call NOTE_CheckNoteSizes()
      SETTINGS_Save("")
    End If

    LBDialog.Dispose()
  End Sub

  Private Sub cmNote04Setup_Click_1(sender As Object, e As EventArgs) Handles cmNote04Setup.Click
    Dim LBDialog As frmLabelSetup = New frmLabelSetup With {.HideFormColor = True}

    'R4.00 Get the data we are editing.
    LBDialog.LSetup = LSNote04
    FONT_Setup = FONT_Note04
    PATH_DlgBmp = PATH_Note04_Bmp                        'R4.00 Path for back image.
    Note_BackBmp = Note04_BackBmp                        'R4.00 Back Image.
    PATH_DlgBmpPath = PATH_StripFilename(PATH_DlgBmp)    'R4.00 Path without Filename. 
    PATH_DlgOVLBmp = PATH_Note04_OVLBmp                  'R4.00 Path for back image.
    Note_OVLBmp = Note04_OVLBmp                          'R4.00 Back Image.
    PATH_DlgOVLBmpPath = PATH_StripFilename(PATH_DlgOVLBmp)

    'R4.00 Call the setup dialog and default to CANCEL being pressed.
    LBDialog.ShowDialog()

    If LBDialog.Cancel = False Then
      LSNote04 = LBDialog.LSetup
      PATH_Note04_Bmp = PATH_DlgBmp        'R4.00 Path for back image.
      Note04_BackBmp = Note_BackBmp        'R4.00 Back Image.
      PATH_Note04_OVLBmp = PATH_DlgOVLBmp  'R4.00 Path for back image.
      Note04_OVLBmp = Note_OVLBmp          'R4.00 Overlay Image.

      FONT_Note04 = FONT_Setup
      FONT_Note04_Name = FONT_Setup.Name
      FONT_Note04_Size = FONT_Setup.Size
      FONT_Note04_Bold = FONT_Setup.Bold
      FONT_Note04_Italic = FONT_Setup.Italic
      LSNote04.B1 = Color.FromArgb(255 * (Val(LSNote04.O1) * 0.01), LSNote04.B1.R, LSNote04.B1.G, LSNote04.B1.B)
      LSNote04.B2 = Color.FromArgb(255 * (Val(LSNote04.O2) * 0.01), LSNote04.B2.R, LSNote04.B2.G, LSNote04.B2.B)

      Call NOTE_CheckNoteSizes()
      SETTINGS_Save("")
    End If

    LBDialog.Dispose()
  End Sub


  '****************************************************************
  'R4.00 NOTE CLICK
  '****************************************************************
  Private Sub cmNote1_Click(sender As Object, e As EventArgs) Handles cmNote1.Click
    Dim DlgNotes As frmNotes = New frmNotes

    For t = 1 To 10
      DlgNotes.NoteText(t) = NoteAnim01_Text(t)
    Next t
    DlgNotes.NoteAnim = NoteAnim01

    DlgNotes.ShowDialog()

    If DlgNotes.Cancel = False Then
      For t = 1 To 10
        NoteAnim01_Text(t) = DlgNotes.NoteText(t)
      Next t

      NoteAnim01 = DlgNotes.NoteAnim

      SETTINGS_Save("")
    End If

    DlgNotes.Dispose()

  End Sub


  Private Sub cmNote2_Click(sender As Object, e As EventArgs) Handles cmNote2.Click
    Dim DlgNotes As frmNotes = New frmNotes

    For t = 1 To 10
      DlgNotes.NoteText(t) = NoteAnim02_Text(t)
    Next t
    DlgNotes.NoteAnim = NoteAnim02

    DlgNotes.ShowDialog()

    If DlgNotes.Cancel = False Then
      For t = 1 To 10
        NoteAnim02_Text(t) = DlgNotes.NoteText(t)
      Next t

      NoteAnim02 = DlgNotes.NoteAnim

      SETTINGS_Save("")
    End If

    DlgNotes.Dispose()

  End Sub

  Private Sub cmNote3_Click(sender As Object, e As EventArgs) Handles cmNote3.Click
    Dim DlgNotes As frmNotes = New frmNotes

    For t = 1 To 10
      DlgNotes.NoteText(t) = NoteAnim03_Text(t)
    Next t
    DlgNotes.NoteAnim = NoteAnim03

    DlgNotes.ShowDialog()

    If DlgNotes.Cancel = False Then
      For t = 1 To 10
        NoteAnim03_Text(t) = DlgNotes.NoteText(t)
      Next t

      NoteAnim03 = DlgNotes.NoteAnim

      SETTINGS_Save("")
    End If

    DlgNotes.Dispose()

  End Sub

  Private Sub cmNote4_Click(sender As Object, e As EventArgs) Handles cmNote4.Click
    Dim DlgNotes As frmNotes = New frmNotes

    For t = 1 To 10
      DlgNotes.NoteText(t) = NoteAnim04_Text(t)
    Next t
    DlgNotes.NoteAnim = NoteAnim04

    DlgNotes.ShowDialog()

    If DlgNotes.Cancel = False Then
      For t = 1 To 10
        NoteAnim04_Text(t) = DlgNotes.NoteText(t)
      Next t


      NoteAnim04 = DlgNotes.NoteAnim

      SETTINGS_Save("")
    End If

    DlgNotes.Dispose()

  End Sub


  Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    'R4.00 Delete all of our Allocated bitmaps, etc
    Note01_Bmp.Dispose()
    Note02_Bmp.Dispose()
    Note03_Bmp.Dispose()
    Note04_Bmp.Dispose()
    Note01_Gfx.Dispose()
    Note02_Gfx.Dispose()
    Note03_Gfx.Dispose()
    Note04_Gfx.Dispose()

    FONT_Rank.Dispose()
    FONT_Name.Dispose()
    FONT_Note01.Dispose()
    FONT_Note02.Dispose()
    FONT_Note03.Dispose()
    FONT_Note04.Dispose()

  End Sub

  Private Sub scrVolume_ValueChanged(sender As Object, e As EventArgs) Handles scrVolume.ValueChanged
    Dim currentVolume As Integer

    'R4.00 Scrollbars are bugged.
    currentVolume = scrVolume.Value
    If (currentVolume < 0) Then currentVolume = 0
    If (100 < currentVolume) Then currentVolume = 100

    Call AUDIO_SetVolume(currentVolume, 100)

    lbVolume.Text = currentVolume

  End Sub

  Private Sub AUDIO_SetVolume(MasterVol As Integer, SoundVol As Integer)
    'R4.10 Receive a MASTER and CHAN/SOUND volume that is 0 - 100 (OFF to FULL volume).

    Dim NewVolume As UInteger = ((UShort.MaxValue) * (MasterVol * 0.01) * (SoundVol * 0.01))

    ' Set the same volume for both the left And the right channels
    Dim NewVolumeAllChannels As UInt64 = ((NewVolume And &HFFFF) Or (NewVolume * (2 ^ 16)))

    ' Set the volume
    waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels)

  End Sub

  Private Sub cboNoteSpace_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNoteSpace.SelectedIndexChanged

    If FLAG_Loading Then Exit Sub

    NOTE_Spacing = cboNoteSpace.SelectedIndex

    Call SCREEN_Organize()
    Call SETTINGS_Save("")

  End Sub

  Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    Call SETTINGS_Save("")

  End Sub

  '****************************************************************************
  'R4.00 CONTEXT MENU STRIP (ToolStripMenu) FOR STATS
  '****************************************************************************
  Private Sub tsmPlayer_Relic_Click(sender As Object, e As EventArgs) Handles tsmPlayer_Relic.Click

    Process.Start("http://www.companyofheroes.com/leaderboards#profile/steam/" + PlrSteam(Celo_PopupHit) + "/standings")

  End Sub

  Private Sub tsmPlayer_OrgAT_Click(sender As Object, e As EventArgs) Handles tsmPlayer_OrgAT.Click

    Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/1/steamid/" + PlrSteam(Celo_PopupHit))

  End Sub

  Private Sub tsmPlayer_Google_Click(sender As Object, e As EventArgs) Handles tsmPlayer_Google.Click

    Process.Start("https://translate.google.com/#view=home&op=translate&sl=auto&tl=en&text=" + PlrName(Celo_PopupHit))

  End Sub

  Private Sub tsmPlayer_Steam_Click(sender As Object, e As EventArgs) Handles tsmPlayer_Steam.Click
    Process.Start("https://steamcommunity.com/profiles/" + PlrSteam(Celo_PopupHit) + "/")
  End Sub


  Private Sub tsmPlayer_OrgFaction_Click(sender As Object, e As EventArgs) Handles tsmPlayer_OrgFaction.Click

    'R4.00 Try to select the correct STATS page from.org.
    Select Case PlrFact(Celo_PopupHit)
      Case "05" : Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/12/steamid/" + PlrSteam(Celo_PopupHit))           'R4.00 UKF
      Case "02", "01" : Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/11/steamid/" + PlrSteam(Celo_PopupHit))     'R4.00 SOV, OST
      Case "04", "03" : Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/10/steamid/" + PlrSteam(Celo_PopupHit))     'R4.00 USF, OKW
      Case Else : Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + PlrSteam(Celo_PopupHit))
    End Select

  End Sub

  Private Sub tsmPlayer_OrgPlayercard_Click(sender As Object, e As EventArgs) Handles tsmPlayer_OrgPlayercard.Click

    Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + PlrSteam(Celo_PopupHit))

  End Sub

  Private Sub chkPopUp_CheckedChanged(sender As Object, e As EventArgs) Handles chkPopUp.CheckedChanged

    'R4.34 This needs restored when Relic fixes the LOG file issues.
    'If chkPopUp.Checked Then
    '  Celo_Popup = True
    '  ToolTip1.SetToolTip(pbStats, "Click a player name to see web pages for:" & vbCr & "Left: Relic Stats" & vbCr & "Ctrl-Left: Google Translate" & vbCr & "Shift-Left: Coh2.org player page" & vbCr & "Right: Popup menu")
    'Else
    '  Celo_Popup = False
    '  ToolTip1.SetToolTip(pbStats, "Click a player name to see web pages for:" & vbCr & "Left: Relic Stats" & vbCr & "Ctrl-Left: Google Translate" & vbCr & "Shift-Left: Coh2.org player page" & vbCr & "Right: Coh2.org AT stats" & vbCr & "Ctrl-Right: Coh2.org faction page")
    'End If

  End Sub

  Private Sub tsmSelectFile_Click(sender As Object, e As EventArgs) Handles tsmSelectFile.Click

    Call AUDIO_SelectFile(Celo_PopupHit)

  End Sub

  Private Sub AUDIO_SelectFile(index As Integer)

    Dim fd As OpenFileDialog = New OpenFileDialog()
    fd.Title = "Select a sound to play"

    If SOUND_File(index) = "" Then
      If PATH_SoundFiles <> "" Then fd.InitialDirectory = PATH_SoundFiles
    Else
      PATH_SoundFiles = PATH_StripFilename(SOUND_File(index))
      fd.InitialDirectory = PATH_SoundFiles
    End If
    fd.Filter = "Wave Files (*.wav)|*.wav"

    If fd.ShowDialog() = DialogResult.OK Then
      SOUND_File(index) = fd.FileName
      ToolTip1.SetToolTip(CELO_PopUpObject, SOUND_File(index))
    End If

  End Sub

  Private Sub tsmSetVolTo100_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo100.Click
    SOUND_Vol(Celo_PopupHit) = 100
  End Sub

  Private Sub tsmSetVolTo90_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo90.Click
    SOUND_Vol(Celo_PopupHit) = 90
  End Sub
  Private Sub tsmSetVolTo80_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo80.Click
    SOUND_Vol(Celo_PopupHit) = 80
  End Sub
  Private Sub tsmSetVolTo70_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo70.Click
    SOUND_Vol(Celo_PopupHit) = 70
  End Sub
  Private Sub tsmSetVolTo60_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo60.Click
    SOUND_Vol(Celo_PopupHit) = 60
  End Sub
  Private Sub tsmSetVolTo50_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo50.Click
    SOUND_Vol(Celo_PopupHit) = 50
  End Sub
  Private Sub tsmSetVolTo40_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo40.Click
    SOUND_Vol(Celo_PopupHit) = 40
  End Sub
  Private Sub tsmSetVolTo30_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo30.Click
    SOUND_Vol(Celo_PopupHit) = 30
  End Sub
  Private Sub tsmSetVolTo20_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo20.Click
    SOUND_Vol(Celo_PopupHit) = 20
  End Sub
  Private Sub tsmSetVolTo10_Click(sender As Object, e As EventArgs) Handles tsmSetVolTo10.Click
    SOUND_Vol(Celo_PopupHit) = 10
  End Sub

  Private Sub cboXoff_SelectedIndexChanged(sender As Object, e As EventArgs)
    'R4.10 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    SETTINGS_Save("")
    Call GFX_DrawStats()

    FLAG_Drawing = False
  End Sub

  Private Sub cboYoff_SelectedIndexChanged(sender As Object, e As EventArgs)
    'R4.10 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    SETTINGS_Save("")
    Call GFX_DrawStats()

    FLAG_Drawing = False
  End Sub

  Private Sub tbXoff_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbXoff.KeyPress
    If e.KeyChar <> vbCr Then Exit Sub

    'R4.10 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    'R4.50 Force STATS redraw.
    MainBuffer_Valid = False

    SETTINGS_Save("")
    Call GFX_DrawStats()

    FLAG_Drawing = False

  End Sub

  Private Sub tbYoff_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbYoff.KeyPress
    If e.KeyChar <> vbCr Then Exit Sub

    'R4.10 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    'R4.50 Force STATS redraw.
    MainBuffer_Valid = False

    SETTINGS_Save("")
    Call GFX_DrawStats()

    FLAG_Drawing = False

  End Sub

  Private Sub tbXsize_TextChanged(sender As Object, e As EventArgs) Handles tbXsize.TextChanged

  End Sub

  Private Sub tbXsize_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbXsize.KeyPress

    If e.KeyChar <> vbCr Then Exit Sub

    'R4.10 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    STATS_ClipXY(Val(tbXsize.Text), Val(tbYSize.Text))
    Call STATS_AdjustSize()

    Call STATS_DefineY()
    Call STATS_DefineX()                   'R2.00 X gets adjusted to Y size for faction images.

    Call SETTINGS_Save("")
    Call SCREEN_Organize()
    Call GFX_DrawStats()

    FLAG_Drawing = False

  End Sub

  Private Sub tbYSize_TextChanged(sender As Object, e As EventArgs) Handles tbYSize.TextChanged

  End Sub

  Private Sub tbYSize_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbYSize.KeyPress

    If e.KeyChar <> vbCr Then Exit Sub

    'R4.10 Added drawing flag.
    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    Call STATS_ClipXY(Val(tbXsize.Text), Val(tbYSize.Text))
    Call STATS_AdjustSize()

    Call STATS_DefineY()
    Call STATS_DefineX()                   'R2.00 X gets adjusted to Y size for faction images.

    Call SETTINGS_Save("")
    Call SCREEN_Organize()
    Call GFX_DrawStats()

    FLAG_Drawing = False

  End Sub

  Private Sub cmDefaults_Click(sender As Object, e As EventArgs) Handles cmDefaults.Click
    'R4.10 Added a RESTORE DEFAULTS button.

    Dim result As Integer = MessageBox.Show("You have chosen to restore all STATS pages settings to their default state." & vbCr & vbCr & "Do you wish To continue?", "STATS - Restore Defaults", MessageBoxButtons.YesNoCancel)

    If (result = DialogResult.Cancel) Or (result = DialogResult.No) Then Exit Sub

    If FLAG_Loading Or FLAG_Drawing Then Exit Sub
    FLAG_Drawing = True

    'R4.30 Updated.
    Call STATS_ClipXY(990, 180)
    Call STATS_AdjustSize()

    tbXsize.Text = STATS_SizeX
    tbYSize.Text = STATS_SizeY

    tbXoff.Text = "0"
    tbYoff.Text = "0"

    cboLayoutY.SelectedIndex = 3
    STATS_DefineY()

    cboLayoutX.SelectedIndex = 3
    STATS_DefineX()

    Call SCREEN_Organize()
    Call GFX_DrawStats()

    FLAG_Drawing = False

  End Sub

  Private Sub cmStatsModeHelp_Click(sender As Object, e As EventArgs) Handles cmStatsModeHelp.Click
    Dim A As String = ""

    'R4.30 Updated.
    A = "This section defines the size and layout of the STATS page below." & vbCr
    A += "Click DEFAULTS to restore the settings to their default sizes." & vbCr & vbCr
    A += "The default size is 990x180 which covers all of the COH2 bottom info area." & vbCr & vbCr
    A += "The XY offset values move the stats data around inside the STATS page. Adjust these values to line up the stats data with a custom made background image." & vbCr & vbCr

    MsgBox(A, MsgBoxStyle.Information, "HELP - Stats Size and Layout")

  End Sub

  Private Sub frmMain_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

    'R4.10 We can get slightly smoother animations using INVALIDATE and this sub to update the screen.
    'R4.10 But there is a CPU/GPU cost (about 10x).
    If ANIMATION_Smooth Then
      If (cmNote01_Play.Text = "||") And (NoteAnim01.Active) Then Call NOTE_Animate(pbNote1, Note01_Text, LSNote01, FONT_Note01, NoteAnim01, Note01_Bmp, Note01_Gfx, Note01_BackBmp, Note01_OVLBmp)
      If (cmNote02_Play.Text = "||") And (NoteAnim02.Active) Then Call NOTE_Animate(pbNote2, Note02_Text, LSNote02, FONT_Note02, NoteAnim02, Note02_Bmp, Note02_Gfx, Note02_BackBmp, Note02_OVLBmp)
      If (cmNote03_Play.Text = "||") And (NoteAnim03.Active) Then Call NOTE_Animate(pbNote3, Note03_Text, LSNote03, FONT_Note03, NoteAnim03, Note03_Bmp, Note03_Gfx, Note03_BackBmp, Note03_OVLBmp)
      If (cmNote04_Play.Text = "||") And (NoteAnim04.Active) Then Call NOTE_Animate(pbNote4, Note04_Text, LSNote04, FONT_Note04, NoteAnim04, Note04_Bmp, Note04_Gfx, Note04_BackBmp, Note04_OVLBmp)
    End If

  End Sub

  Private Sub chkSmoothAni_CheckedChanged(sender As Object, e As EventArgs) Handles chkSmoothAni.CheckedChanged

    'R4.10 We can get slightly smoother animations using INVALIDATE and Form_Paint() to update the screen.
    'R4.10 But there is a CPU/GPU cost (about 10x).
    If chkSmoothAni.Checked Then
      ANIMATION_Smooth = True
    Else
      ANIMATION_Smooth = False
    End If

  End Sub

  Private Sub cmSetupLoad_Click(sender As Object, e As EventArgs) Handles cmSetupLoad.Click
    Dim fd As OpenFileDialog = New OpenFileDialog()
    Dim A As String
    Dim N As Integer
    Dim IsOldStyle As Boolean

    'R2.00 Find the LOG file. Try top help get to the right location if possible.
    fd.Title = "MakoCELO Load a SETUP file from disk"
    If PATH_SetupPath <> "" Then
      fd.InitialDirectory = PATH_SetupPath
    Else
      fd.InitialDirectory = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments
    End If
    fd.Filter = "Celo Setup Files (*.mcs)|*.mcs"
    fd.FilterIndex = 1

    If fd.ShowDialog() = DialogResult.OK Then

      PATH_SetupPath = fd.FileName
      If SETTINGS_Load_CheckVersion(PATH_SetupPath, IsOldStyle) = True Then
        If IsOldStyle Then
          Call SETTINGS_Load_Old(PATH_SetupPath)
        Else
          Call SETTINGS_Load(PATH_SetupPath)
        End If
      End If

      'R3.40 Strip off filename so we can use it for init dir later.
      N = STRING_FindLastSlash(PATH_SetupPath)
      If 3 < N Then
        'R4.50 Add current SETUP file name.
        A = Mid(PATH_SetupPath, N + 1, Len(PATH_SetupPath) - N)
        SS1_Filename.Text = A
        PATH_SetupPath = Mid(PATH_SetupPath, 1, N)
      Else
        PATH_SetupPath = ""
      End If

      Call SETUP_Apply()
      Call STATS_Refresh()
    End If

  End Sub

  Private Sub cmSetupSave_Click(sender As Object, e As EventArgs) Handles cmSetupSave.Click
    Dim fd As SaveFileDialog = New SaveFileDialog()
    Dim N As Integer

    'R2.00 Find the LOG file. Try top help get to the right location if possible.
    fd.Title = "MakoCELO Save a SETUP file to disk"
    If PATH_SetupPath <> "" Then
      fd.InitialDirectory = PATH_SetupPath
    Else
      fd.InitialDirectory = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments
    End If
    fd.Filter = "Celo Setup Files (*.mcs)|*.mcs"
    fd.FilterIndex = 1

    If fd.ShowDialog() = DialogResult.OK Then

      PATH_SetupPath = fd.FileName
      Call SETTINGS_Save(PATH_SetupPath)

      'R3.40 Strip off filename so we can use it for init dir later.
      N = STRING_FindLastSlash(PATH_SetupPath)
      If 3 < N Then
        PATH_SetupPath = Mid(PATH_SetupPath, 1, N)
      Else
        PATH_SetupPath = ""
      End If

    End If

  End Sub

  Private Sub chkGUIMode_CheckedChanged(sender As Object, e As EventArgs) Handles chkGUIMode.CheckedChanged

    'R4.30 Changed from buttons to checkbox.
    If chkGUIMode.Checked Then
      Call GUI_SetDark()
      GUI_ColorMode = 1
      Call SETTINGS_Save("")
    Else
      Call GUI_SetLite()
      GUI_ColorMode = 0
      Call SETTINGS_Save("")
    End If

  End Sub

  Private Sub cboDelay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDelay.SelectedIndexChanged
    SCAN_Time = Val(cboDelay.Items.Item(cboDelay.SelectedIndex))  'R4.30 Added.
  End Sub

  Private Sub chkHideMissing_CheckedChanged(sender As Object, e As EventArgs) Handles chkHideMissing.CheckedChanged
    'R4.30 Added code to hide not used players slots.
    If chkHideMissing.Checked Then
      FLAG_HideMissing = True
    Else
      FLAG_HideMissing = False
    End If

    Call SETTINGS_Save("")

  End Sub

  Private Sub chkFoundSound_CheckedChanged(sender As Object, e As EventArgs) Handles chkFoundSound.CheckedChanged

    'R4.30 Added to play a sound when a match is found.
    Call SETTINGS_Save("")

  End Sub

  Private Sub cmTest_Click(sender As Object, e As EventArgs) Handles cmELO.Click

    Call ELO_Setup()

  End Sub

  Private Sub ELO_Setup()
    Dim PSDialog As frmMaxPlayerSearch = New frmMaxPlayerSearch 'With {} ' {.HideSizeOptions = True, .HideSizeAll = True}

    'R4.00 Get the data we are editing.
    For t = 1 To 7
      For tt = 1 To 4
        PSDialog.LVLs(t, tt) = LVLS(t, tt)
      Next tt
    Next t

    'R4.00 Call the setup dialog and default to CANCEL being pressed.
    PSDialog.ShowDialog()

    If PSDialog.Cancel = False Then
      For t = 1 To 7
        For tt = 1 To 4
          LVLS(t, tt) = PSDialog.LVLs(t, tt)
        Next tt
      Next t

      Call SETTINGS_Save("")
    End If

  End Sub

  Private Sub ELO_VerifyData()
    Dim BadData As Boolean

    'R4.30 Check for VALID max layer counts.
    For T1 = 1 To 5
      For T2 = 1 To 4
        If Val(LVLS(T1, T2)) < 1 Then BadData = True
      Next
    Next
    For T1 = 6 To 7
      For T2 = 2 To 4
        If Val(LVLS(T1, T2)) < 1 Then BadData = True
      Next
    Next

    If BadData Then
      FLAG_EloValid = False
    Else
      FLAG_EloValid = True
    End If

  End Sub

  Private Sub chkShowELO_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowELO.CheckedChanged
    Dim A As String

    'R4.30 Added ELO percantage.
    If chkShowELO.Checked Then
      FLAG_EloUse = True
    Else
      FLAG_EloUse = False
    End If

    'R4.30 Dont do validity checks on load or ELO not used.
    If FLAG_Loading Or (FLAG_EloUse = False) Then
      FLAG_EloMode = 0
      'GFX_DrawStats()
      STATS_Refresh()
      Exit Sub
    End If

    'R4.30 Check for VALID max player counts.
    Call ELO_VerifyData()
    If FLAG_EloValid = False Then

      A = "NOTE: To calc ELO values, MakoCELO needs the max players" & vbCr & vbCr
      A = A & "for each game mode. This can be done by the RANK setup area." & vbCr & vbCr
      A = A & "Would you like to OPEN the ELO setup dialog now?" & vbCr & vbCr
      Dim result As DialogResult = MsgBox(A, MsgBoxStyle.YesNo, "MakoCELO ELO Setup")

      'R4.30 User selected YES.
      If result = DialogResult.No Then
        chkShowELO.Checked = False
        FLAG_EloUse = False
      Else
        'R4.30 Let user get ELO data, then verify that data.
        Call ELO_Setup()
        ELO_VerifyData()
        If FLAG_EloValid = False Then
          A = "NOTE: The ELO data appears to be incomplete." & vbCr & vbCr
          A = A & "ELO Cyclong will be disabled until the ELO" & vbCr & vbCr
          A = A & "data is completed." & vbCr & vbCr
          MsgBox(A, MsgBoxStyle.Information, "MakoCELO ELO Setup")

          chkShowELO.Checked = False
          FLAG_EloUse = False
        End If
      End If
    End If

    Call SETTINGS_Save("")
    STATS_Refresh()

  End Sub


  Private Sub STAT_GetSteamID(RID As String, PLRSlot As Integer)
    'R4.50 It is possible to try and find the STEAMID for a player when parsing the JSON data. 
    'R4.50 Not Implemented.
  End Sub

  Private Function Country_GetName(CA As String) As String
    Dim tName As String = ""

    For t = 1 To CountryCount
      If CA = Country_Abbr(t) Then tName = Country_Name(t) : Exit For
    Next

    Country_GetName = tName

  End Function


  Private Sub STAT_GetFromRID(RID As String, PLRSlot As Integer)
    Dim s As String
    Dim A As String = ""
    Dim GMode As Integer
    Dim P1, P2, P3 As Integer
    Dim RawResp As String = ""
    Dim SearchCnt As String = 4

    Try
      'R4.30 Request leaderboard data from Relic Web API. Put result JSON data in string for parsing.
      lstLog.Items.Add(Now.ToLongTimeString & " - Get RID - PLR:" & PLRSlot & " Web Request sending...")
      'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 'R4.43 Added for Connection issues.

      A = "https://coh2-api.reliclink.com/community/leaderboard/GetPersonalStat?title=coh2&profile_ids=[" & RID & "]"
      WBrequest = DirectCast(WebRequest.Create(A), HttpWebRequest)
      lstLog.Items.Add(Now.ToLongTimeString & " - Get RID - PLR:" & PLRSlot & " Getting response...")

      WBresponse = DirectCast(WBrequest.GetResponse(), HttpWebResponse)
      lstLog.Items.Add(Now.ToLongTimeString & " - Get RID - PLR:" & PLRSlot & " Getting stream...")

      WBreader = New StreamReader(WBresponse.GetResponseStream())
      lstLog.Items.Add(Now.ToLongTimeString & " - Get RID - PLR:" & PLRSlot & " Reading stream...")

      RawResp = WBreader.ReadToEnd()
      WBresponse.Close()
      lstLog.Items.Add(Now.ToLongTimeString & " - Get RID - PLR:" & PLRSlot & " Parsing data..." & Len(RawResp) & " bytes")

      'R4.41 Added to catch bad data.
      If Len(RawResp) < 10 Then
        lstLog.Items.Add(Now.ToLongTimeString & " - ERROR RID - PLR:" & PLRSlot & " No data returned.")
        lbError1.Text = "RID error:" & PLRSlot.ToString()
        lbError1.BackColor = Color.FromArgb(255, 255, 0, 0)
        Exit Sub
      End If

      'R4.41 Added to catch bad data.
      A = "message" & Chr(34) & ":" & Chr(34) & "SUCCESS"
      P1 = InStr(RawResp, A)
      If P1 < 1 Then
        lstLog.Items.Add(Now.ToLongTimeString & " - ERROR RID - PLR:" & PLRSlot & " Server returned error.")
        lbError1.Text = "RID error:" & PLRSlot.ToString()
        lbError1.BackColor = Color.FromArgb(255, 255, 0, 0)
        Exit Sub
      End If

      'R4.41 Start to PARSE the JSON data in a crude and broken manner.
      P1 = InStr(RawResp, "statGroups")

      'R4.45 Get the players COUNTRY.
      If 0 < P1 Then
        A = "profile_id" & Chr(34) & ":" & RID
        P2 = InStr(P1, RawResp, A)
        If 0 < P2 Then
          P2 = InStr(P2, RawResp, "country")
          If 0 < P2 Then
            PlrCountry(PLRSlot) = RawResp.Substring(P2 + 9, 2)
            PlrCountryName(PLRSlot) = Country_GetName(PlrCountry(PLRSlot))
          Else
            PlrCountry(PLRSlot) = ""
            PlrCountryName(PLRSlot) = ""
          End If
        End If
      End If

      'R4.45 Get the Leadboard ranks (player card).
      P2 = InStr(P1, RawResp, "leaderboard_id")
      While 0 < P2
        s = RawResp.Substring(P2 + 15, 6)
        GMode = Val(s)
        For T1 = 1 To 5
          For T2 = 1 To 4
            If GMode = RelDataLeaderID(T1, T2) Then
              P3 = InStr(P2, RawResp, "wins")
              PlrRankWin(PLRSlot, T1, T2) = Val(RawResp.Substring(P3 + 5, 10))
              P3 = InStr(P2, RawResp, "losses")
              PlrRankLoss(PLRSlot, T1, T2) = Val(RawResp.Substring(P3 + 7, 10))
              P3 = InStr(P2, RawResp, "rank")
              PlrRankALL(PLRSlot, T1, T2) = Val(RawResp.Substring(P3 + 5, 10))
              If PlrRankALL(PLRSlot, T1, T2) = -1 Then PlrRankALL(PLRSlot, T1, T2) = 0
              If 0 < PlrRankWin(PLRSlot, T1, T2) Then
                PlrRankPerc(PLRSlot, T1, T2) = (100 * PlrRankWin(PLRSlot, T1, T2) / (PlrRankWin(PLRSlot, T1, T2) + PlrRankLoss(PLRSlot, T1, T2))).ToString("#0")
              Else
                PlrRankPerc(PLRSlot, T1, T2) = ""
              End If
            End If
          Next
        Next
        P2 = InStr(P2 + 15, RawResp, "leaderboard_id")
      End While


    Catch ex As Exception
      'R4.41 Added logging and color change.
      lbError1.Text = "RID error:" & PLRSlot.ToString()
      lbError1.BackColor = Color.FromArgb(255, 255, 0, 0)
      lstLog.Items.Add(Now.ToLongTimeString & " - ERROR RID - PLR:" & PLRSlot & " " & Err.Description)

    End Try

    If RawResp <> "" Then Call STAT_GetTeamsFromRID(RawResp, PLRSlot)


  End Sub

  Private Sub STAT_GetTeamsFromRID(RawResp As String, PLRslot As Integer) 'R4.45 Was  RID As Integer, PLRSlot As Integer)
    Dim s As String
    Dim A As String = ""
    Dim P1, P2, PEnd As Integer
    Dim SearchCnt As String = "4"
    Dim PLR1 As String = ""
    Dim PLR2 As String = ""
    Dim PLR3 As String = ""
    Dim PLR4 As String = ""
    Dim Rank As Integer
    Dim RankID As Integer
    Dim RankID2 As Integer
    Dim RID1 As Integer
    Dim RID2 As Integer
    Dim RID3 As Integer
    Dim RID4 As Integer
    Dim LID As Integer
    Dim Win As Integer
    Dim Loss As Integer
    Dim PlrCnt As Integer
    Dim Cnt As Integer

    Try

      'R4.41 Added to catch bad data.
      If Len(RawResp) < 10 Then
        lstLog.Items.Add(Now.ToLongTimeString & " - ERROR TEAM - PLR:" & PLRslot & " No data returned.")
        lbError1.Text = "Team error:" & PLRslot.ToString()
        lbError1.BackColor = Color.FromArgb(255, 255, 0, 0)
        Exit Sub
      End If

      'R4.41 Added to catch bad data.
      A = "message" & Chr(34) & ":" & Chr(34) & "SUCCESS"
      P1 = InStr(RawResp, A)
      If P1 < 1 Then
        lstLog.Items.Add(Now.ToLongTimeString & " - ERROR TEAM - PLR:" & PLRslot & " Server returned error.")
        lbError1.Text = "Team error:" & PLRslot.ToString()
        lbError1.BackColor = Color.FromArgb(255, 255, 0, 0)
        Exit Sub
      End If

      '*************************************************
      'R4.33 Find all PREMADE TEAMS. Can be team of 1.
      'R4.41 Start to PARSE the JSON data in a crude and broken manner.
      '*************************************************
      P1 = InStr(RawResp, "statGroups")
      PEnd = InStr(P1, RawResp, "leaderboardStats")

      P1 = InStr(P1 + 13, RawResp, "{" & Chr(34) & "id")
      While (0 < P1) And (P1 < PEnd) And (Cnt < 500)
        Cnt += 1
        lbStatus.Text = "Team: " & Cnt : lbStatus.Refresh()

        s = RawResp.Substring(P1 + 5, 9)
        RankID = Val(s)

        P1 = InStr(P1 + 5, RawResp, "type")
        s = RawResp.Substring(P1 + 5, 9)
        PlrCnt = Val(s)

        'R4.34 Get the relicID and Name of each player in this team. Team can be 1-4 players.
        P1 = InStr(P1 + 5, RawResp, "profile_id")
        s = RawResp.Substring(P1 + 11, 32)
        P2 = InStr(P1 + 10, RawResp, Chr(34))
        RID1 = Val(s.Substring(0, P2 - (P1 + 0)))

        P1 = InStr(P1 + 5, RawResp, "alias")
        s = RawResp.Substring(P1 + 7, 64)               'R4.44 Was 32 chars long.
        P2 = InStr(P1 + 8, RawResp, Chr(34))
        PLR1 = s.Substring(0, P2 - (P1 + 8))

        If 1 < PlrCnt Then
          P1 = InStr(P1 + 5, RawResp, "profile_id")
          s = RawResp.Substring(P1 + 11, 32)
          P2 = InStr(P1 + 10, RawResp, Chr(34))
          RID2 = Val(s.Substring(0, P2 - (P1 + 0)))

          P1 = InStr(P1 + 5, RawResp, "alias")
          s = RawResp.Substring(P1 + 7, 64)             'R4.44 Was 32 chars long.
          P2 = InStr(P1 + 8, RawResp, Chr(34))
          PLR2 = s.Substring(0, P2 - (P1 + 8))
        Else
          RID2 = 0
          PLR2 = ""
        End If

        If 2 < PlrCnt Then
          P1 = InStr(P1 + 5, RawResp, "profile_id")
          s = RawResp.Substring(P1 + 11, 32)
          P2 = InStr(P1 + 10, RawResp, Chr(34))
          RID3 = Val(s.Substring(0, P2 - (P1 + 0)))

          P1 = InStr(P1 + 5, RawResp, "alias")
          s = RawResp.Substring(P1 + 7, 64)             'R4.44 Was 32 chars long.
          P2 = InStr(P1 + 8, RawResp, Chr(34))
          PLR3 = s.Substring(0, P2 - (P1 + 8))
        Else
          RID3 = 0
          PLR3 = ""
        End If

        If 3 < PlrCnt Then
          P1 = InStr(P1 + 5, RawResp, "profile_id")
          s = RawResp.Substring(P1 + 11, 32)
          P2 = InStr(P1 + 10, RawResp, Chr(34))
          RID4 = Val(s.Substring(0, P2 - (P1 + 0)))

          P1 = InStr(P1 + 5, RawResp, "alias")
          s = RawResp.Substring(P1 + 7, 64)              'R4.44 Was 32 chars long.
          P2 = InStr(P1 + 8, RawResp, Chr(34))
          PLR4 = s.Substring(0, P2 - (P1 + 8))
        Else
          RID4 = 0
          PLR4 = ""
        End If

        TeamList(PLRslot, Cnt).PLR1 = PLR1
        TeamList(PLRslot, Cnt).PLR2 = PLR2
        TeamList(PLRslot, Cnt).PLR3 = PLR3
        TeamList(PLRslot, Cnt).PLR4 = PLR4
        TeamList(PLRslot, Cnt).RID1 = RID1
        TeamList(PLRslot, Cnt).RID2 = RID2
        TeamList(PLRslot, Cnt).RID3 = RID3
        TeamList(PLRslot, Cnt).RID4 = RID4
        TeamList(PLRslot, Cnt).RankID = RankID
        TeamList(PLRslot, Cnt).PlrCnt = PlrCnt

        P1 = InStr(P1 + 5, RawResp, "{" & Chr(34) & "id")
      End While
      TeamListCnt(PLRslot) = Cnt

      '******************************************
      'R4.33 Find all ranks for premade teams.
      '******************************************
      P1 = PEnd
      PEnd = Len(RawResp)

      Cnt = 0
      P1 = InStr(P1 + 13, RawResp, "statgroup_id")
      While (0 < P1) And (P1 < PEnd) And (Cnt < 1500)
        Cnt += 1

        s = RawResp.Substring(P1 + 13, 12)
        RankID2 = Val(s)

        P1 = InStr(P1 + 13, RawResp, "leaderboard_id")
        s = RawResp.Substring(P1 + 15, 12)
        LID = Val(s)

        P1 = InStr(P1 + 13, RawResp, "wins")
        s = RawResp.Substring(P1 + 5, 12)
        Win = Val(s)

        P1 = InStr(P1 + 5, RawResp, "losses")
        s = RawResp.Substring(P1 + 7, 12)
        Loss = Val(s)

        P1 = InStr(P1 + 7, RawResp, "rank")
        s = RawResp.Substring(P1 + 5, 12)
        Rank = Val(s)

        'R4.33 Try to find a rank for this team. 
        For t = 1 To TeamListCnt(PLRslot)
          If (TeamList(PLRslot, t).RankID = RankID2) Then
            If (LID = 20) Or (LID = 22) Or (LID = 24) Then
              TeamList(PLRslot, t).RankAxis = Rank
              TeamList(PLRslot, t).WinAxis = Win
              TeamList(PLRslot, t).LossAxis = Loss
              Exit For
            End If
            If (LID = 21) Or (LID = 23) Or (LID = 25) Then
              TeamList(PLRslot, t).RankAllies = Rank
              TeamList(PLRslot, t).WinAllies = Win
              TeamList(PLRslot, t).LossAllies = Loss
              Exit For
            End If
          End If
        Next

        P1 = InStr(P1 + 5, RawResp, "statgroup_id")
      End While

    Catch ex As Exception
      'R4.41 Added logging and color change.
      lbError1.Text = "Team Error" : lbError1.Refresh()
      lbError1.BackColor = Color.FromArgb(255, 255, 0, 0)
      lstLog.Items.Add(Now.ToLongTimeString & " - ERROR TEAM - PLR:" & PLRslot & " " & Err.Description)

    End Try

    lbStatus.Text = ""

  End Sub


  Private Sub timELOCycle_Tick(sender As Object, e As EventArgs) Handles timELOCycle.Tick

    If FLAG_EloUse And FLAG_EloValid Then
      '*****************************************************************
      'R4.30 If doing ELO cycles, calc the current Cycle to show.
      '*****************************************************************
      FLAG_EloMode += 1
      If 2 < FLAG_EloMode Then FLAG_EloMode = 0

      'R4.20 Moved sub for outside calls.
      Call GFX_DrawStats()

      'R4.30 Try to do some cleanup.
      Application.DoEvents()
    Else
      FLAG_EloMode = 0
    End If


  End Sub

  Private Sub scrStats_Scroll(sender As Object, e As ScrollEventArgs) Handles scrStats.Scroll

  End Sub

  Private Sub scrStats_ValueChanged(sender As Object, e As EventArgs) Handles scrStats.ValueChanged

    If FLAG_ShowPlayerCard = 2 Then
      Call GFX_DrawTeams(FLAG_ShowPlayerCardNum)
    End If

  End Sub

  Private Sub pbStats_MouseWheel(sender As Object, e As MouseEventArgs) Handles pbStats.MouseWheel
    Dim Y As Long
    Dim Yold As Long

    If FLAG_ShowPlayerCard = 2 Then
      Y = e.Delta
      If 0 < e.Delta Then
        Yold = scrStats.Value - 90
      Else
        Yold = scrStats.Value + 90
      End If
      If Yold < scrStats.Minimum Then Yold = scrStats.Minimum
      If scrStats.Maximum < Yold Then Yold = scrStats.Maximum
      scrStats.Value = Yold

      'R4.50 Data is drawn in scrollbar code.
    End If
  End Sub

  Private Sub chkSpeech_CheckedChanged(sender As Object, e As EventArgs) Handles chkSpeech.CheckedChanged
    'R4.34 Added.
    Call SETTINGS_Save("")

  End Sub

  Private Sub chkGetTeams_CheckedChanged(sender As Object, e As EventArgs) Handles chkGetTeams.CheckedChanged
    'R4.34 Added.
    Call SETTINGS_Save("")

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

  Private Sub cmErrLog_Click(sender As Object, e As EventArgs) Handles cmErrLog.Click
    Dim LogDialog As frmErrLog = New frmErrLog 'With {} ' {.HideSizeOptions = True, .HideSizeAll = True}

    'R4.42 Show the Error Log dialog.
    LogDialog.ShowDialog()

  End Sub

  Private Sub chkCountry_CheckedChanged(sender As Object, e As EventArgs) Handles chkCountry.CheckedChanged

    'R4.45 Added to Country Flags.
    Call SETTINGS_Save("")

  End Sub

  Private Sub RES_GetCountryData()
    Dim A As String = ""
    Dim Cnt As Integer

    'R4.46 Default to no country names available.
    CountryCount = 0

    Try
      Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(New StringReader(My.Resources.country_defs))
        MyReader.TextFieldType = FileIO.FieldType.Delimited
        MyReader.SetDelimiters(",")

        Dim CurrentRow As String()
        While Not MyReader.EndOfData
          CurrentRow = MyReader.ReadFields()

          Cnt += 1
          Country_Name(Cnt) = CurrentRow(0)
          Country_Abbr(Cnt) = LCase(CurrentRow(1))

        End While
        CountryCount = Cnt
      End Using
    Catch
      MsgBox("Error: parsing Country name resource file." & vbCrLf & Err.Description, MsgBoxStyle.ApplicationModal, "MakoCELO - Loading error")
    End Try

  End Sub

  Private Sub tbXoff_TextChanged(sender As Object, e As EventArgs) Handles tbXoff.TextChanged

  End Sub

  Private Sub tbYoff_TextChanged(sender As Object, e As EventArgs) Handles tbYoff.TextChanged

  End Sub
End Class

