using System;
using Microsoft.VisualBasic;

namespace MakoCelo
{
    public partial class frmNotes
    {
        public frmNotes(bool displayTooltips)
        {
            InitializeComponent();
            _Button1.Name = "Button1";
            _Button2.Name = "Button2";
            _Button3.Name = "Button3";
            _Button4.Name = "Button4";
            _Button5.Name = "Button5";
            _Button6.Name = "Button6";
            _Button7.Name = "Button7";
            _Button8.Name = "Button8";
            _Button9.Name = "Button9";
            _Button10.Name = "Button10";
            _cmOK.Name = "cmOK";
            _cmCancel.Name = "cmCancel";
            _cboAlign.Name = "cboAlign";
            _Button11.Name = "Button11";
            _Button12.Name = "Button12";
            _Button13.Name = "Button13";
            _cmRotUp.Name = "cmRotUp";
            _cmRotDn.Name = "cmRotDn";
            _displayTooltips = displayTooltips;
        }
        // R4.00 This class should be rewritten to use properties.

        private clsGlobal.t_NoteAnimation _NoteAnim;
        private bool _Cancel = true;
        private string[] _NoteText = new string[12];
        private readonly bool _displayTooltips;

        public clsGlobal.t_NoteAnimation NoteAnim
        {
            get
            {
                return _NoteAnim;
            }

            set
            {
                _NoteAnim = value;
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

        public string get_NoteText(int Index)
        {
            return _NoteText[Index];
        }

        public void set_NoteText(int Index, string value)
        {
            _NoteText[Index] = value;
        }

        private void frmNotes_Load(object sender, EventArgs e)
        {
            int N;

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

            tbN01.Text = _NoteText[1];
            tbN02.Text = _NoteText[2];
            tbN03.Text = _NoteText[3];
            tbN04.Text = _NoteText[4];
            tbN05.Text = _NoteText[5];
            tbN06.Text = _NoteText[6];
            tbN07.Text = _NoteText[7];
            tbN08.Text = _NoteText[8];
            tbN09.Text = _NoteText[9];
            tbN10.Text = _NoteText[10];
            cboMode.Items.Add("0 - None");
            cboMode.Items.Add("1 - L<-R Crawler");
            cboMode.Items.Add("2 - Up Crawler");
            cboMode.Items.Add("3 - Down Crawler");
            cboMode.Items.Add("4 - Fade In");
            cboMode.Items.Add("5 - Up Roll");
            N = _NoteAnim.Mode;
            if (N < 0)
                N = 0;
            cboMode.SelectedIndex = N;
            cboSpeed.Items.Add("0");
            cboSpeed.Items.Add("1");
            cboSpeed.Items.Add("2");
            cboSpeed.Items.Add("3");
            cboSpeed.Items.Add("4");
            cboSpeed.Items.Add("5");
            cboSpeed.Items.Add("6");
            cboSpeed.Items.Add("7");
            cboSpeed.Items.Add("8");
            cboSpeed.Items.Add("9");
            cboSpeed.Items.Add("10");
            N = _NoteAnim.Speed;
            if (N < 0)
                N = 0;
            cboSpeed.SelectedIndex = N;
            cboHoldTime.Items.Add("0 Secs");
            cboHoldTime.Items.Add("1 Secs");
            cboHoldTime.Items.Add("2 Secs");
            cboHoldTime.Items.Add("3 Secs");
            cboHoldTime.Items.Add("4 Secs");
            cboHoldTime.Items.Add("5 Secs");
            cboHoldTime.Items.Add("6 Secs");
            cboHoldTime.Items.Add("7 Secs");
            cboHoldTime.Items.Add("8 Secs");
            cboHoldTime.Items.Add("9 Secs");
            cboHoldTime.Items.Add("10 Secs");
            N = (int)_NoteAnim.TimeHold;
            if (N < 0)
                N = 0;
            cboHoldTime.SelectedIndex = N;
            tbDelim.Text = _NoteAnim.Delim;
            cboAlign.Items.Add("0 - Left");
            cboAlign.Items.Add("1 - Center");
            cboAlign.Items.Add("2 - Right");
            cboAlign.Text = _NoteAnim.Align;
            N = _NoteAnim.Mode;
            if (N < 0)
                N = 0;
            cboMode.SelectedIndex = N;
            tbXoff.Text = _NoteAnim.Xoffset.ToString();
            tbYoff.Text = _NoteAnim.Yoffset.ToString();
        }

        private void ToolTip_Setup()
        {
            ToolTip1.SetToolTip(cboMode, "Set how the text will be animated on the notes.");
            ToolTip1.SetToolTip(cboSpeed, "Set how fast text effects happen during animations.");
            ToolTip1.SetToolTip(cboHoldTime, "How long to show the text after animations are done.");
            ToolTip1.SetToolTip(cboAlign, "Set the text alignment. This is not used for some animations.");
            ToolTip1.SetToolTip(tbDelim, "Some animations combine all text. This string will be placed between each line of text.");
            ToolTip1.SetToolTip(tbXoff, "Modify the position of text so it can align with images being used.");
            ToolTip1.SetToolTip(tbYoff, "Modify the position of text so it can align with images being used.");
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            _NoteText[1] = tbN01.Text;
            _NoteText[2] = tbN02.Text;
            _NoteText[3] = tbN03.Text;
            _NoteText[4] = tbN04.Text;
            _NoteText[5] = tbN05.Text;
            _NoteText[6] = tbN06.Text;
            _NoteText[7] = tbN07.Text;
            _NoteText[8] = tbN08.Text;
            _NoteText[9] = tbN09.Text;
            _NoteText[10] = tbN10.Text;
            _NoteAnim.Mode = cboMode.SelectedIndex;
            if (_NoteAnim.Mode < 0)
                _NoteAnim.Mode = 0;
            _NoteAnim.Speed = cboSpeed.SelectedIndex;
            if (_NoteAnim.Speed < 0)
                _NoteAnim.Speed = 0;
            _NoteAnim.TimeHold = cboHoldTime.SelectedIndex;
            if (_NoteAnim.TimeHold < 0L)
                _NoteAnim.TimeHold = 0L;
            _NoteAnim.Delim = tbDelim.Text;
            _NoteAnim.Xoffset = (int)Math.Round(Conversion.Val(tbXoff.Text));
            _NoteAnim.Yoffset = (int)Math.Round(Conversion.Val(tbYoff.Text));

            // R4.00 We selected OK and close.
            Cancel = false;
            Close();
        }

        private void cmCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tbN01.Text = "";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            tbN02.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            tbN03.Text = "";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            tbN04.Text = "";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            tbN05.Text = "";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            tbN06.Text = "";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            tbN07.Text = "";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            tbN08.Text = "";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            tbN09.Text = "";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            tbN10.Text = "";
        }

        private void cboAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            _NoteAnim.Align = cboAlign.Text;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            tbDelim.Text = "";
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            tbXoff.Text = "0";
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            tbYoff.Text = "0";
        }

        private void cmRotUp_Click(object sender, EventArgs e)
        {
            string TS;
            TS = tbN01.Text;
            tbN01.Text = tbN02.Text;
            tbN02.Text = tbN03.Text;
            tbN03.Text = tbN04.Text;
            tbN04.Text = tbN05.Text;
            tbN05.Text = tbN06.Text;
            tbN06.Text = tbN07.Text;
            tbN07.Text = tbN08.Text;
            tbN08.Text = tbN09.Text;
            tbN09.Text = tbN10.Text;
            tbN10.Text = TS;
        }

        private void cmRotDn_Click(object sender, EventArgs e)
        {
            string TS;
            TS = tbN10.Text;
            tbN10.Text = tbN09.Text;
            tbN09.Text = tbN08.Text;
            tbN08.Text = tbN07.Text;
            tbN07.Text = tbN06.Text;
            tbN06.Text = tbN05.Text;
            tbN05.Text = tbN04.Text;
            tbN04.Text = tbN03.Text;
            tbN03.Text = tbN02.Text;
            tbN02.Text = tbN01.Text;
            tbN01.Text = TS;
        }
    }
}