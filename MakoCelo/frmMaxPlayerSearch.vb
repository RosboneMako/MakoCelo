Imports System.Web.Script.Serialization
Imports System.Net
Imports System.IO

Public Class frmMaxPlayerSearch

  'R4.00 Create some PROPERTIES that hide/show dialog controls.
  'Dim _LVLs As clsGlobal.t_LabelSetup = New clsGlobal.t_LabelSetup
  Dim _LVLs(0 To 7, 0 To 4) As String
  Dim _Cancel As Boolean = True
  Dim SearchFound As Boolean
  Dim SearchStop As Boolean
  Dim SearchPage As Long
  Dim SearchActual As Boolean
  Dim SearchURL(0 To 7, 0 To 4) As String

  Dim RelDataLeaderID(0 To 7, 0 To 4) As String


  Public Property Cancel As Boolean
    Get
      Return _Cancel
    End Get
    Set(ByVal Value As Boolean)
      _Cancel = Value
    End Set
  End Property

  Public Property LVLs(ByVal I1 As Integer, ByVal I2 As Integer) As String
    Get
      Return _LVLs(I1, I2)
    End Get
    Set(ByVal Value As String)
      _LVLs(I1, I2) = Value
    End Set
  End Property


  Private Sub frmMaxPlayerSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim A As String

    A = "This dialog sets up the ELO CYCLE data. To calc the ELO values, it needs to know the number of players in each game mode." & vbCrLf & vbCrLf
    A = A & "You can select each individual game mode and copy/paste the actual player counts "
    A = A & "or you can let the program get values automatically." & vbCrLf & vbCrLf
    A = A & "Two auto methods are available. One gets the actual number of players from the HTML code and one gets a "
    A = A & "close approximation by page view count." & vbCrLf & vbCrLf
    A = A & "Generically these values do not change a lot over time. So you should only need to refresh these "
    A = A & "values periodically (once a week/once a month)." & vbCrLf & vbCrLf
    A = A & "NOTE: ELO calculations are not exact and are only for reference."
    tbHelp.Text = A

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


    SearchURL(1, 1) = "http://www.companyofheroes.com/leaderboards#global/1v1/german/by-rank?page=10000"
    SearchURL(1, 2) = "http://www.companyofheroes.com/leaderboards#global/2v2/german/by-rank?page=10000"
    SearchURL(1, 3) = "http://www.companyofheroes.com/leaderboards#global/3v3/german/by-rank?page=10000"
    SearchURL(1, 4) = "http://www.companyofheroes.com/leaderboards#global/4v4/german/by-rank?page=10000"

    SearchURL(2, 1) = "http://www.companyofheroes.com/leaderboards#global/1v1/soviet/by-rank?page=10000"
    SearchURL(2, 2) = "http://www.companyofheroes.com/leaderboards#global/2v2/soviet/by-rank?page=10000"
    SearchURL(2, 3) = "http://www.companyofheroes.com/leaderboards#global/3v3/soviet/by-rank?page=10000"
    SearchURL(2, 4) = "http://www.companyofheroes.com/leaderboards#global/4v4/soviet/by-rank?page=10000"

    SearchURL(3, 1) = "http://www.companyofheroes.com/leaderboards#global/1v1/wgerman/by-rank?page=10000"
    SearchURL(3, 2) = "http://www.companyofheroes.com/leaderboards#global/2v2/wgerman/by-rank?page=10000"
    SearchURL(3, 3) = "http://www.companyofheroes.com/leaderboards#global/3v3/wgerman/by-rank?page=10000"
    SearchURL(3, 4) = "http://www.companyofheroes.com/leaderboards#global/4v4/wgerman/by-rank?page=10000"

    SearchURL(4, 1) = "http://www.companyofheroes.com/leaderboards#global/1v1/aef/by-rank?page=10000"
    SearchURL(4, 2) = "http://www.companyofheroes.com/leaderboards#global/2v2/aef/by-rank?page=10000"
    SearchURL(4, 3) = "http://www.companyofheroes.com/leaderboards#global/3v3/aef/by-rank?page=10000"
    SearchURL(4, 4) = "http://www.companyofheroes.com/leaderboards#global/4v4/aef/by-rank?page=10000"

    SearchURL(5, 1) = "http://www.companyofheroes.com/leaderboards#global/1v1/british/by-rank?page=10000"
    SearchURL(5, 2) = "http://www.companyofheroes.com/leaderboards#global/2v2/british/by-rank?page=10000"
    SearchURL(5, 3) = "http://www.companyofheroes.com/leaderboards#global/3v3/british/by-rank?page=10000"
    SearchURL(5, 4) = "http://www.companyofheroes.com/leaderboards#global/4v4/british/by-rank?page=10000"

    SearchURL(6, 2) = "http://www.companyofheroes.com/leaderboards#global/team-of-2/allies/by-rank?page=10000"
    SearchURL(6, 3) = "http://www.companyofheroes.com/leaderboards#global/team-of-3/allies/by-rank?page=10000"
    SearchURL(6, 4) = "http://www.companyofheroes.com/leaderboards#global/team-of-4/allies/by-rank?page=10000"

    SearchURL(7, 2) = "http://www.companyofheroes.com/leaderboards#global/team-of-2/axis/by-rank?page=10000"
    SearchURL(7, 3) = "http://www.companyofheroes.com/leaderboards#global/team-of-3/axis/by-rank?page=10000"
    SearchURL(7, 4) = "http://www.companyofheroes.com/leaderboards#global/team-of-4/axis/by-rank?page=10000"

    DATA_Show()

  End Sub

  Private Sub DATA_Show()
    tb1v1Ost.Text = _LVLs(1, 1)
    tb1v1Sov.Text = _LVLs(2, 1)
    tb1v1Okw.Text = _LVLs(3, 1)
    tb1v1Usf.Text = _LVLs(4, 1)
    tb1v1Brit.Text = _LVLs(5, 1)

    tb2v2Ost.Text = _LVLs(1, 2)
    tb2v2Sov.Text = _LVLs(2, 2)
    tb2v2Okw.Text = _LVLs(3, 2)
    tb2v2Usf.Text = _LVLs(4, 2)
    tb2v2Brit.Text = _LVLs(5, 2)
    tb2ATAllies.Text = _LVLs(6, 2)
    tb2ATAxis.Text = _LVLs(7, 2)

    tb3v3Ost.Text = _LVLs(1, 3)
    tb3v3Sov.Text = _LVLs(2, 3)
    tb3v3Okw.Text = _LVLs(3, 3)
    tb3v3Usf.Text = _LVLs(4, 3)
    tb3v3Brit.Text = _LVLs(5, 3)
    tb3ATAllies.Text = _LVLs(6, 3)
    tb3ATAxis.Text = _LVLs(7, 3)

    tb4v4Ost.Text = _LVLs(1, 4)
    tb4v4Sov.Text = _LVLs(2, 4)
    tb4v4Okw.Text = _LVLs(3, 4)
    tb4v4Usf.Text = _LVLs(4, 4)
    tb4v4Brit.Text = _LVLs(5, 4)
    tb4ATAllies.Text = _LVLs(6, 4)
    tb4ATAxis.Text = _LVLs(7, 4)

  End Sub


  Private Sub Web1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles Web1.DocumentCompleted
    Dim N As Integer
    Dim A As String

    If SearchActual Then Exit Sub

    'R4.30 None of this works.
    'If Web1.ReadyState <> WebBrowserReadyState.Complete Then Exit Sub
    'If (e.Url.AbsolutePath <> sender.Url.AbsolutePath) Then Exit Sub
    'If e.Url.ToString <> Web1.Url.ToString Then Exit Sub

    'R4.30 We send page 10000 in our URL knowing it does not exist.
    'R4.30 The RELIC page redirects to the ACTUAL last page.
    If InStr(e.Url.ToString, "=10000") = 0 Then

      'R4.30 Search URL for PAGE=.
      N = InStr(e.Url.ToString, "rank?page=")
      A = e.Url.ToString
      A = A.Substring(N + 9, Len(A) - (N + 9))
      N = Val(A)

      'R4.30 If the last page is not 10000, we are being redirected.
      'R4.30 So store the last PAGE value in SearchPage.
      If (10 < N) Or (9999 < N) Then
        SearchFound = True
        SearchPage = N
      End If

    End If

  End Sub


  Private Sub cm1v1Sov_Click(sender As Object, e As EventArgs) Handles cm1v1Sov.Click
    lbStatus.Text = "" : Application.DoEvents()
    If rb1v1.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/soviet/by-rank?page=10000")
    If rb2v2.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/soviet/by-rank?page=10000")
    If rb3v3.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/soviet/by-rank?page=10000")
    If rb4v4.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/soviet/by-rank?page=10000")

  End Sub

  Private Sub cm1v1Usf_Click(sender As Object, e As EventArgs) Handles cm1v1Usf.Click
    lbStatus.Text = "" : Application.DoEvents()
    If rb1v1.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/aef/by-rank?page=10000")
    If rb2v2.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/aef/by-rank?page=10000")
    If rb3v3.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/aef/by-rank?page=10000")
    If rb4v4.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/aef/by-rank?page=10000")
  End Sub

  Private Sub cm1v1Brit_Click(sender As Object, e As EventArgs) Handles cm1v1Brit.Click
    lbStatus.Text = "" : Application.DoEvents()
    If rb1v1.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/british/by-rank?page=10000")
    If rb2v2.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/british/by-rank?page=10000")
    If rb3v3.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/british/by-rank?page=10000")
    If rb4v4.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/british/by-rank?page=10000")
  End Sub

  Private Sub cm1v1Ost_Click(sender As Object, e As EventArgs) Handles cm1v1Ost.Click
    lbStatus.Text = "" : Application.DoEvents()
    If rb1v1.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/german/by-rank?page=10000")
    If rb2v2.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/german/by-rank?page=10000")
    If rb3v3.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/german/by-rank?page=10000")
    If rb4v4.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/german/by-rank?page=10000")
  End Sub

  Private Sub cm1v1Okw_Click(sender As Object, e As EventArgs) Handles cm1v1Okw.Click
    lbStatus.Text = "" : Application.DoEvents()
    If rb1v1.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/wgerman/by-rank?page=10000")
    If rb2v2.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/wgerman/by-rank?page=10000")
    If rb3v3.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/wgerman/by-rank?page=10000")
    If rb4v4.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/wgerman/by-rank?page=10000")
  End Sub

  Private Sub cmATallies_Click(sender As Object, e As EventArgs) Handles cmATallies.Click
    lbStatus.Text = "" : Application.DoEvents()
    If rb2v2.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-2/allies/by-rank?page=10000")
    If rb3v3.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-3/allies/by-rank?page=10000")
    If rb4v4.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-4/allies/by-rank?page=10000")
  End Sub

  Private Sub cmATAxis_Click(sender As Object, e As EventArgs) Handles cmATAxis.Click
    lbStatus.Text = "" : Application.DoEvents()

    If rb2v2.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-2/axis/by-rank?page=10000")
    If rb3v3.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-3/axis/by-rank?page=10000")
    If rb4v4.Checked Then Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-4/axis/by-rank?page=10000")
  End Sub

  Private Sub cmOK_Click(sender As Object, e As EventArgs) Handles cmOK.Click

    _LVLs(1, 1) = tb1v1Ost.Text
    _LVLs(2, 1) = tb1v1Sov.Text
    _LVLs(3, 1) = tb1v1Okw.Text
    _LVLs(4, 1) = tb1v1Usf.Text
    _LVLs(5, 1) = tb1v1Brit.Text

    _LVLs(1, 2) = tb2v2Ost.Text
    _LVLs(2, 2) = tb2v2Sov.Text
    _LVLs(3, 2) = tb2v2Okw.Text
    _LVLs(4, 2) = tb2v2Usf.Text
    _LVLs(5, 2) = tb2v2Brit.Text
    _LVLs(6, 2) = tb2ATAllies.Text
    _LVLs(7, 2) = tb2ATAxis.Text

    _LVLs(1, 3) = tb3v3Ost.Text
    _LVLs(2, 3) = tb3v3Sov.Text
    _LVLs(3, 3) = tb3v3Okw.Text
    _LVLs(4, 3) = tb3v3Usf.Text
    _LVLs(5, 3) = tb3v3Brit.Text
    _LVLs(6, 3) = tb3ATAllies.Text
    _LVLs(7, 3) = tb3ATAxis.Text

    _LVLs(1, 4) = tb4v4Ost.Text
    _LVLs(2, 4) = tb4v4Sov.Text
    _LVLs(3, 4) = tb4v4Okw.Text
    _LVLs(4, 4) = tb4v4Usf.Text
    _LVLs(5, 4) = tb4v4Brit.Text
    _LVLs(6, 4) = tb4ATAllies.Text
    _LVLs(7, 4) = tb4ATAxis.Text

    Cancel = False
    Me.Close()

  End Sub


  Private Sub cmGetAll_Click(sender As Object, e As EventArgs) Handles cmGetAll.Click
    Dim tCnt As Integer

    lbStatus.BackColor = Color.FromArgb(255, 128, 255, 128)
    Call OBJ_Enable(False)

    'R4.30 Loop thru all URLs to get the LAST PAGE value from the redirected URL. 
    For t = 1 To 7
      For tt = 1 To 4
        tCnt += 1

        If (SearchURL(t, tt) <> "") And (SearchStop = False) Then
          lbStatus.Text = "Searching " & (tCnt) & " of 28"

          Web1.Navigate(SearchURL(t, tt))

          WAIT_Time(1)

          'R4.30 Loop here while DOC COMPLETED task checks status of search. 
          While (SearchFound = False) And (SearchStop = False)
            Application.DoEvents()
          End While

          'R4.30 Calc APPROX # of players assuming 40 players per page.
          _LVLs(t, tt) = SearchPage * 40

          'R4.30 Reset our search flags.
          SearchFound = False
          SearchPage = 0
        End If
      Next tt
    Next t

    If SearchStop = False Then
      lbStatus.Text = "Search Complete."
      DATA_Show()
    Else
      lbStatus.Text = "Search Aborted."
      SearchStop = False
    End If

    lbStatus.BackColor = Color.FromArgb(255, 128, 128, 128)
    Call OBJ_Enable(True)

  End Sub

  Private Sub HTML_Search()
    Dim A, B As String
    Dim Tstart As Integer = 1
    Dim Tptr As Long
    Dim N As Long

    'R4.30 Do not read something that does not exist yet.
    If Web1.ReadyState <> WebBrowserReadyState.Complete Then Exit Sub

    'R4.30 Get the HTML text to search for rank.
    A = Web1.Document.Body.InnerHtml

    Tptr = InStr(Tstart, A, "Rank() : rank()")
    While (0 < Tptr) And (SearchStop = False)
      B = A.Substring(Tptr + 16, 9)
      N = Val(B)

      Tstart = Tptr + 50
      Tptr = InStr(Tstart, A, "Rank() : rank()")
    End While

    If 0 < N Then SearchPage = N

  End Sub

  Private Sub cmStopAll_Click(sender As Object, e As EventArgs) Handles cmStopAll.Click
    SearchStop = True
  End Sub

  Private Sub cmCancel_Click(sender As Object, e As EventArgs) Handles cmCancel.Click

    SearchStop = True
    Application.DoEvents()

    Cancel = True
    Me.Close()

  End Sub

  Private Sub WAIT_Time(WaitSeconds As Integer)
    Dim tTim As String

    'R4.30 Wait a little bit to let the page begin updating before moving on.
    For Z = 1 To WaitSeconds
      tTim = System.DateTime.Now.ToString
      While (tTim = System.DateTime.Now.ToString) And (SearchStop = False)
        Application.DoEvents()
      End While
    Next Z

  End Sub

  Private Sub WAIT_TimeMS(WaitMS As Integer)
    Dim tTim As Long

    'R4.30 Wait a little bit to let the page begin updating before moving on.
    tTim = Environment.TickCount
    While (Environment.TickCount < (tTim + WaitMS)) And (tTim <= Environment.TickCount) And (SearchStop = False)
      Application.DoEvents()
    End While

  End Sub

  Private Sub cmGetAllActual_Click(sender As Object, e As EventArgs) Handles cmGetAllActual.Click
    Dim TLast As Long = 0
    Dim SameCnt As Integer = 0
    Dim tCnt As Integer = 0

    lbStatus.BackColor = Color.FromArgb(255, 128, 255, 128)
    Call OBJ_Enable(False)

    'R4.30 Loop thru all URLs to get the LAST PAGE value from the redirected URL. 
    SearchActual = True
    For t = 1 To 7
      For tt = 1 To 4
        tCnt += 1
        If (SearchURL(t, tt) <> "") And (SearchStop = False) Then
          lbStatus.Text = "Searching " & (tCnt) & " of 28"

          SearchPage = 0
          Web1.Navigate(SearchURL(t, tt))

          'R4.30 Loop here while DOC COMPLETED task checks status of search. 
          While (SearchFound = False) And (SearchStop = False)
            'WAIT_Time(1)
            WAIT_TimeMS(500)

            TLast = SearchPage
            SearchPage = 0
            HTML_Search()

            If (TLast = SearchPage) And (1000 < SearchPage) Then
              SearchFound = True
              SameCnt = 0
            End If
          End While

          'R4.30 # of players.
          _LVLs(t, tt) = SearchPage

          'R4.30 Reset our search flags.
          SearchFound = False
          SearchPage = 0
        End If
      Next tt
    Next t
    SearchActual = False

    If SearchStop = False Then
      lbStatus.Text = "Search Complete."
      DATA_Show()
    Else
      lbStatus.Text = "Search Aborted."
      SearchStop = False
    End If

    lbStatus.BackColor = Color.FromArgb(255, 128, 128, 128)
    Call OBJ_Enable(True)

  End Sub

  Private Sub OBJ_Enable(SetToOn As Boolean)

    cmGetAll.Enabled = SetToOn
    cmGetAllActual.Enabled = SetToOn
    cmOK.Enabled = SetToOn
    cmCancel.Enabled = SetToOn
    cm1v1Sov.Enabled = SetToOn
    cm1v1Usf.Enabled = SetToOn
    cm1v1Brit.Enabled = SetToOn
    cm1v1Ost.Enabled = SetToOn
    cm1v1Okw.Enabled = SetToOn
    cmATallies.Enabled = SetToOn
    cmATAxis.Enabled = SetToOn

  End Sub

  'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
  '  Dim A As String
  '  Dim request As HttpWebRequest
  '  Dim response As HttpWebResponse = Nothing
  '  Dim reader As StreamReader
  '  Dim rawresp As String

  '  '/community/leaderboard/getLeaderBoard2?leaderboard_id=${leaderboardID}&title=coh2&platform=PC_STEAM&sortBy=1&start=${start}&count=${count}`
  '  'SearchURL(1, 1) = "http://www.companyofheroes.com/leaderboards#global/1v1/german/by-rank?page=10000"

  '  A = "http://www.companyofheroes.com/community/leaderboard/getLeaderBoard2?leaderboard_id=24&title=coh2&platform=PC_STEAM&sortBy=1&start=1&count=40"

  '  request = DirectCast(WebRequest.Create(A), HttpWebRequest)

  '  response = DirectCast(request.GetResponse(), HttpWebResponse)
  '  reader = New StreamReader(response.GetResponseStream())


  '  rawresp = reader.ReadToEnd()
  '  MsgBox(rawresp)

  '  Clipboard.SetText(rawresp)

  'End Sub

End Class