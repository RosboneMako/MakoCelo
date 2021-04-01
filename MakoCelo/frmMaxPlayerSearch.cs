using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MakoCelo
{
    public partial class frmMaxPlayerSearch
    {
        public frmMaxPlayerSearch()
        {
            InitializeComponent();
            _Web1.Name = "Web1";
            _cm1v1Sov.Name = "cm1v1Sov";
            _cm1v1Usf.Name = "cm1v1Usf";
            _cm1v1Brit.Name = "cm1v1Brit";
            _cm1v1Ost.Name = "cm1v1Ost";
            _cm1v1Okw.Name = "cm1v1Okw";
            _cmATallies.Name = "cmATallies";
            _cmATAxis.Name = "cmATAxis";
            _cmOK.Name = "cmOK";
            _cmGetAll.Name = "cmGetAll";
            _cmCancel.Name = "cmCancel";
            _cmStopAll.Name = "cmStopAll";
            _cmGetAllActual.Name = "cmGetAllActual";
        }

        // R4.00 Create some PROPERTIES that hide/show dialog controls.
        // Dim _LVLs As clsGlobal.t_LabelSetup = New clsGlobal.t_LabelSetup
        private string[,] _LVLs = new string[8, 5];
        private bool _Cancel = true;
        private bool SearchFound;
        private bool SearchStop;
        private long SearchPage;
        private bool SearchActual;
        private string[,] SearchURL = new string[8, 5];
        private string[,] RelDataLeaderID = new string[8, 5];

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

        public string get_LVLs(int I1, int I2)
        {
            return _LVLs[I1, I2];
        }

        public void set_LVLs(int I1, int I2, string value)
        {
            _LVLs[I1, I2] = value;
        }

        private void frmMaxPlayerSearch_Load(object sender, EventArgs e)
        {
            string A;
            A = "This dialog sets up the ELO CYCLE data. To calc the ELO values, it needs to know the number of players in each game mode." + Constants.vbCrLf + Constants.vbCrLf;
            A = A + "You can select each individual game mode and copy/paste the actual player counts ";
            A = A + "or you can let the program get values automatically." + Constants.vbCrLf + Constants.vbCrLf;
            A = A + "Two auto methods are available. One gets the actual number of players from the HTML code and one gets a ";
            A = A + "close approximation by page view count." + Constants.vbCrLf + Constants.vbCrLf;
            A = A + "Generically these values do not change a lot over time. So you should only need to refresh these ";
            A = A + "values periodically (once a week/once a month)." + Constants.vbCrLf + Constants.vbCrLf;
            A = A + "NOTE: ELO calculations are not exact and are only for reference.";
            tbHelp.Text = A;

            // OST
            RelDataLeaderID[1, 1] = "4";
            RelDataLeaderID[1, 2] = "8";
            RelDataLeaderID[1, 3] = "12";
            RelDataLeaderID[1, 4] = "16";
            // SOV
            RelDataLeaderID[2, 1] = "5";
            RelDataLeaderID[2, 2] = "9";
            RelDataLeaderID[2, 3] = "13";
            RelDataLeaderID[2, 4] = "17";
            // OKW
            RelDataLeaderID[3, 1] = "6";
            RelDataLeaderID[3, 2] = "10";
            RelDataLeaderID[3, 3] = "14";
            RelDataLeaderID[3, 4] = "18";
            // USF
            RelDataLeaderID[4, 1] = "7";
            RelDataLeaderID[4, 2] = "11";
            RelDataLeaderID[4, 3] = "15";
            RelDataLeaderID[4, 4] = "19";
            // BRIT
            RelDataLeaderID[5, 1] = "51";
            RelDataLeaderID[5, 2] = "52";
            RelDataLeaderID[5, 3] = "53";
            RelDataLeaderID[5, 4] = "54";
            SearchURL[1, 1] = "http://www.companyofheroes.com/leaderboards#global/1v1/german/by-rank?page=10000";
            SearchURL[1, 2] = "http://www.companyofheroes.com/leaderboards#global/2v2/german/by-rank?page=10000";
            SearchURL[1, 3] = "http://www.companyofheroes.com/leaderboards#global/3v3/german/by-rank?page=10000";
            SearchURL[1, 4] = "http://www.companyofheroes.com/leaderboards#global/4v4/german/by-rank?page=10000";
            SearchURL[2, 1] = "http://www.companyofheroes.com/leaderboards#global/1v1/soviet/by-rank?page=10000";
            SearchURL[2, 2] = "http://www.companyofheroes.com/leaderboards#global/2v2/soviet/by-rank?page=10000";
            SearchURL[2, 3] = "http://www.companyofheroes.com/leaderboards#global/3v3/soviet/by-rank?page=10000";
            SearchURL[2, 4] = "http://www.companyofheroes.com/leaderboards#global/4v4/soviet/by-rank?page=10000";
            SearchURL[3, 1] = "http://www.companyofheroes.com/leaderboards#global/1v1/wgerman/by-rank?page=10000";
            SearchURL[3, 2] = "http://www.companyofheroes.com/leaderboards#global/2v2/wgerman/by-rank?page=10000";
            SearchURL[3, 3] = "http://www.companyofheroes.com/leaderboards#global/3v3/wgerman/by-rank?page=10000";
            SearchURL[3, 4] = "http://www.companyofheroes.com/leaderboards#global/4v4/wgerman/by-rank?page=10000";
            SearchURL[4, 1] = "http://www.companyofheroes.com/leaderboards#global/1v1/aef/by-rank?page=10000";
            SearchURL[4, 2] = "http://www.companyofheroes.com/leaderboards#global/2v2/aef/by-rank?page=10000";
            SearchURL[4, 3] = "http://www.companyofheroes.com/leaderboards#global/3v3/aef/by-rank?page=10000";
            SearchURL[4, 4] = "http://www.companyofheroes.com/leaderboards#global/4v4/aef/by-rank?page=10000";
            SearchURL[5, 1] = "http://www.companyofheroes.com/leaderboards#global/1v1/british/by-rank?page=10000";
            SearchURL[5, 2] = "http://www.companyofheroes.com/leaderboards#global/2v2/british/by-rank?page=10000";
            SearchURL[5, 3] = "http://www.companyofheroes.com/leaderboards#global/3v3/british/by-rank?page=10000";
            SearchURL[5, 4] = "http://www.companyofheroes.com/leaderboards#global/4v4/british/by-rank?page=10000";
            SearchURL[6, 2] = "http://www.companyofheroes.com/leaderboards#global/team-of-2/allies/by-rank?page=10000";
            SearchURL[6, 3] = "http://www.companyofheroes.com/leaderboards#global/team-of-3/allies/by-rank?page=10000";
            SearchURL[6, 4] = "http://www.companyofheroes.com/leaderboards#global/team-of-4/allies/by-rank?page=10000";
            SearchURL[7, 2] = "http://www.companyofheroes.com/leaderboards#global/team-of-2/axis/by-rank?page=10000";
            SearchURL[7, 3] = "http://www.companyofheroes.com/leaderboards#global/team-of-3/axis/by-rank?page=10000";
            SearchURL[7, 4] = "http://www.companyofheroes.com/leaderboards#global/team-of-4/axis/by-rank?page=10000";
            DATA_Show();
        }

        private void DATA_Show()
        {
            tb1v1Ost.Text = _LVLs[1, 1];
            tb1v1Sov.Text = _LVLs[2, 1];
            tb1v1Okw.Text = _LVLs[3, 1];
            tb1v1Usf.Text = _LVLs[4, 1];
            tb1v1Brit.Text = _LVLs[5, 1];
            tb2v2Ost.Text = _LVLs[1, 2];
            tb2v2Sov.Text = _LVLs[2, 2];
            tb2v2Okw.Text = _LVLs[3, 2];
            tb2v2Usf.Text = _LVLs[4, 2];
            tb2v2Brit.Text = _LVLs[5, 2];
            tb2ATAllies.Text = _LVLs[6, 2];
            tb2ATAxis.Text = _LVLs[7, 2];
            tb3v3Ost.Text = _LVLs[1, 3];
            tb3v3Sov.Text = _LVLs[2, 3];
            tb3v3Okw.Text = _LVLs[3, 3];
            tb3v3Usf.Text = _LVLs[4, 3];
            tb3v3Brit.Text = _LVLs[5, 3];
            tb3ATAllies.Text = _LVLs[6, 3];
            tb3ATAxis.Text = _LVLs[7, 3];
            tb4v4Ost.Text = _LVLs[1, 4];
            tb4v4Sov.Text = _LVLs[2, 4];
            tb4v4Okw.Text = _LVLs[3, 4];
            tb4v4Usf.Text = _LVLs[4, 4];
            tb4v4Brit.Text = _LVLs[5, 4];
            tb4ATAllies.Text = _LVLs[6, 4];
            tb4ATAxis.Text = _LVLs[7, 4];
        }

        private void Web1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int N;
            string A;
            if (SearchActual)
                return;

            // R4.30 None of this works.
            // If Web1.ReadyState <> WebBrowserReadyState.Complete Then Exit Sub
            // If (e.Url.AbsolutePath <> sender.Url.AbsolutePath) Then Exit Sub
            // If e.Url.ToString <> Web1.Url.ToString Then Exit Sub

            // R4.30 We send page 10000 in our URL knowing it does not exist.
            // R4.30 The RELIC page redirects to the ACTUAL last page.
            if (Strings.InStr(e.Url.ToString(), "=10000") == 0)
            {

                // R4.30 Search URL for PAGE=.
                N = Strings.InStr(e.Url.ToString(), "rank?page=");
                A = e.Url.ToString();
                A = A.Substring(N + 9, Strings.Len(A) - (N + 9));
                N = (int)Math.Round(Conversion.Val(A));

                // R4.30 If the last page is not 10000, we are being redirected.
                // R4.30 So store the last PAGE value in SearchPage.
                if (10 < N | 9999 < N)
                {
                    SearchFound = true;
                    SearchPage = N;
                }
            }
        }

        private void cm1v1Sov_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            Application.DoEvents();
            if (rb1v1.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/soviet/by-rank?page=10000");
            if (rb2v2.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/soviet/by-rank?page=10000");
            if (rb3v3.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/soviet/by-rank?page=10000");
            if (rb4v4.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/soviet/by-rank?page=10000");
        }

        private void cm1v1Usf_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            Application.DoEvents();
            if (rb1v1.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/aef/by-rank?page=10000");
            if (rb2v2.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/aef/by-rank?page=10000");
            if (rb3v3.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/aef/by-rank?page=10000");
            if (rb4v4.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/aef/by-rank?page=10000");
        }

        private void cm1v1Brit_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            Application.DoEvents();
            if (rb1v1.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/british/by-rank?page=10000");
            if (rb2v2.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/british/by-rank?page=10000");
            if (rb3v3.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/british/by-rank?page=10000");
            if (rb4v4.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/british/by-rank?page=10000");
        }

        private void cm1v1Ost_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            Application.DoEvents();
            if (rb1v1.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/german/by-rank?page=10000");
            if (rb2v2.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/german/by-rank?page=10000");
            if (rb3v3.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/german/by-rank?page=10000");
            if (rb4v4.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/german/by-rank?page=10000");
        }

        private void cm1v1Okw_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            Application.DoEvents();
            if (rb1v1.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/1v1/wgerman/by-rank?page=10000");
            if (rb2v2.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/2v2/wgerman/by-rank?page=10000");
            if (rb3v3.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/3v3/wgerman/by-rank?page=10000");
            if (rb4v4.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/4v4/wgerman/by-rank?page=10000");
        }

        private void cmATallies_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            Application.DoEvents();
            if (rb2v2.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-2/allies/by-rank?page=10000");
            if (rb3v3.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-3/allies/by-rank?page=10000");
            if (rb4v4.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-4/allies/by-rank?page=10000");
        }

        private void cmATAxis_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            Application.DoEvents();
            if (rb2v2.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-2/axis/by-rank?page=10000");
            if (rb3v3.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-3/axis/by-rank?page=10000");
            if (rb4v4.Checked)
                Web1.Navigate("http://www.companyofheroes.com/leaderboards#global/team-of-4/axis/by-rank?page=10000");
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            _LVLs[1, 1] = tb1v1Ost.Text;
            _LVLs[2, 1] = tb1v1Sov.Text;
            _LVLs[3, 1] = tb1v1Okw.Text;
            _LVLs[4, 1] = tb1v1Usf.Text;
            _LVLs[5, 1] = tb1v1Brit.Text;
            _LVLs[1, 2] = tb2v2Ost.Text;
            _LVLs[2, 2] = tb2v2Sov.Text;
            _LVLs[3, 2] = tb2v2Okw.Text;
            _LVLs[4, 2] = tb2v2Usf.Text;
            _LVLs[5, 2] = tb2v2Brit.Text;
            _LVLs[6, 2] = tb2ATAllies.Text;
            _LVLs[7, 2] = tb2ATAxis.Text;
            _LVLs[1, 3] = tb3v3Ost.Text;
            _LVLs[2, 3] = tb3v3Sov.Text;
            _LVLs[3, 3] = tb3v3Okw.Text;
            _LVLs[4, 3] = tb3v3Usf.Text;
            _LVLs[5, 3] = tb3v3Brit.Text;
            _LVLs[6, 3] = tb3ATAllies.Text;
            _LVLs[7, 3] = tb3ATAxis.Text;
            _LVLs[1, 4] = tb4v4Ost.Text;
            _LVLs[2, 4] = tb4v4Sov.Text;
            _LVLs[3, 4] = tb4v4Okw.Text;
            _LVLs[4, 4] = tb4v4Usf.Text;
            _LVLs[5, 4] = tb4v4Brit.Text;
            _LVLs[6, 4] = tb4ATAllies.Text;
            _LVLs[7, 4] = tb4ATAxis.Text;
            Cancel = false;
            Close();
        }

        private void cmGetAll_Click(object sender, EventArgs e)
        {
            var tCnt = default(int);
            lbStatus.BackColor = Color.FromArgb(255, 128, 255, 128);
            OBJ_Enable(false);

            // R4.30 Loop thru all URLs to get the LAST PAGE value from the redirected URL. 
            for (int t = 1; t <= 7; t++)
            {
                for (int tt = 1; tt <= 4; tt++)
                {
                    tCnt += 1;
                    if (!string.IsNullOrEmpty(SearchURL[t, tt]) & SearchStop == false)
                    {
                        lbStatus.Text = "Searching " + tCnt + " of 28";
                        Web1.Navigate(SearchURL[t, tt]);
                        WAIT_Time(1);

                        // R4.30 Loop here while DOC COMPLETED task checks status of search. 
                        while (SearchFound == false & SearchStop == false)
                            Application.DoEvents();

                        // R4.30 Calc APPROX # of players assuming 40 players per page.
                        _LVLs[t, tt] = (SearchPage * 40L).ToString();

                        // R4.30 Reset our search flags.
                        SearchFound = false;
                        SearchPage = 0L;
                    }
                }
            }

            if (SearchStop == false)
            {
                lbStatus.Text = "Search Complete.";
                DATA_Show();
            }
            else
            {
                lbStatus.Text = "Search Aborted.";
                SearchStop = false;
            }

            lbStatus.BackColor = Color.FromArgb(255, 128, 128, 128);
            OBJ_Enable(true);
        }

        private void HTML_Search()
        {
            string A, B;
            int Tstart = 1;
            long Tptr;
            var N = default(long);

            // R4.30 Do not read something that does not exist yet.
            if (Web1.ReadyState != WebBrowserReadyState.Complete)
                return;

            // R4.30 Get the HTML text to search for rank.
            A = Web1.Document.Body.InnerHtml;
            Tptr = Strings.InStr(Tstart, A, "Rank() : rank()");
            while (0L < Tptr & SearchStop == false)
            {
                B = A.Substring((int)(Tptr + 16L), 9);
                N = (long)Math.Round(Conversion.Val(B));
                Tstart = (int)(Tptr + 50L);
                Tptr = Strings.InStr(Tstart, A, "Rank() : rank()");
            }

            if (0L < N)
                SearchPage = N;
        }

        private void cmStopAll_Click(object sender, EventArgs e)
        {
            SearchStop = true;
        }

        private void cmCancel_Click(object sender, EventArgs e)
        {
            SearchStop = true;
            Application.DoEvents();
            Cancel = true;
            Close();
        }

        private void WAIT_Time(int WaitSeconds)
        {
            string tTim;

            // R4.30 Wait a little bit to let the page begin updating before moving on.
            for (int Z = 1, loopTo = WaitSeconds; Z <= loopTo; Z++)
            {
                tTim = DateTime.Now.ToString();
                while ((tTim ?? "") == (DateTime.Now.ToString() ?? "") & SearchStop == false)
                    Application.DoEvents();
            }
        }

        private void WAIT_TimeMS(int WaitMS)
        {
            long tTim;

            // R4.30 Wait a little bit to let the page begin updating before moving on.
            tTim = Environment.TickCount;
            while (Environment.TickCount < tTim + WaitMS & tTim <= Environment.TickCount & SearchStop == false)
                Application.DoEvents();
        }

        private void cmGetAllActual_Click(object sender, EventArgs e)
        {
            long TLast = 0L;
            int SameCnt = 0;
            int tCnt = 0;
            lbStatus.BackColor = Color.FromArgb(255, 128, 255, 128);
            OBJ_Enable(false);

            // R4.30 Loop thru all URLs to get the LAST PAGE value from the redirected URL. 
            SearchActual = true;
            for (int t = 1; t <= 7; t++)
            {
                for (int tt = 1; tt <= 4; tt++)
                {
                    tCnt += 1;
                    if (!string.IsNullOrEmpty(SearchURL[t, tt]) & SearchStop == false)
                    {
                        lbStatus.Text = "Searching " + tCnt + " of 28";
                        SearchPage = 0L;
                        Web1.Navigate(SearchURL[t, tt]);

                        // R4.30 Loop here while DOC COMPLETED task checks status of search. 
                        while (SearchFound == false & SearchStop == false)
                        {
                            // WAIT_Time(1)
                            WAIT_TimeMS(500);
                            TLast = SearchPage;
                            SearchPage = 0L;
                            HTML_Search();
                            if (TLast == SearchPage & 1000L < SearchPage)
                            {
                                SearchFound = true;
                                SameCnt = 0;
                            }
                        }

                        // R4.30 # of players.
                        _LVLs[t, tt] = SearchPage.ToString();

                        // R4.30 Reset our search flags.
                        SearchFound = false;
                        SearchPage = 0L;
                    }
                }
            }

            SearchActual = false;
            if (SearchStop == false)
            {
                lbStatus.Text = "Search Complete.";
                DATA_Show();
            }
            else
            {
                lbStatus.Text = "Search Aborted.";
                SearchStop = false;
            }

            lbStatus.BackColor = Color.FromArgb(255, 128, 128, 128);
            OBJ_Enable(true);
        }

        private void OBJ_Enable(bool SetToOn)
        {
            cmGetAll.Enabled = SetToOn;
            cmGetAllActual.Enabled = SetToOn;
            cmOK.Enabled = SetToOn;
            cmCancel.Enabled = SetToOn;
            cm1v1Sov.Enabled = SetToOn;
            cm1v1Usf.Enabled = SetToOn;
            cm1v1Brit.Enabled = SetToOn;
            cm1v1Ost.Enabled = SetToOn;
            cm1v1Okw.Enabled = SetToOn;
            cmATallies.Enabled = SetToOn;
            cmATAxis.Enabled = SetToOn;
        }

        // Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        // Dim A As String
        // Dim request As HttpWebRequest
        // Dim response As HttpWebResponse = Nothing
        // Dim reader As StreamReader
        // Dim rawresp As String

        // '/community/leaderboard/getLeaderBoard2?leaderboard_id=${leaderboardID}&title=coh2&platform=PC_STEAM&sortBy=1&start=${start}&count=${count}`
        // 'SearchURL(1, 1) = "http://www.companyofheroes.com/leaderboards#global/1v1/german/by-rank?page=10000"

        // A = "http://www.companyofheroes.com/community/leaderboard/getLeaderBoard2?leaderboard_id=24&title=coh2&platform=PC_STEAM&sortBy=1&start=1&count=40"

        // request = DirectCast(WebRequest.Create(A), HttpWebRequest)

        // response = DirectCast(request.GetResponse(), HttpWebResponse)
        // reader = New StreamReader(response.GetResponseStream())


        // rawresp = reader.ReadToEnd()
        // MsgBox(rawresp)

        // Clipboard.SetText(rawresp)

        // End Sub

    }
}