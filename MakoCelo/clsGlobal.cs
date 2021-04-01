using System.Drawing;

namespace MakoCelo
{
    public class clsGlobal
    {

        // Public Shared NoteAnim01 As t_NoteAnimation           'R3.50 Added.
        // Public Shared NoteSetup_Text(0 To 10) As String       'R3.50 Added.
        // Public Shared NoteAnim01_Text(0 To 10) As String      'R3.50 Added.
        // Public Shared NoteAnim02_Text(0 To 10) As String      'R3.50 Added.
        // Public Shared NoteAnim03_Text(0 To 10) As String      'R3.50 Added.
        // Public Shared NoteAnim04_Text(0 To 10) As String      'R3.50 Added.

        // Public Shared DlgLSetup As t_LabelSetup
        // Public Shared DlgReturnOK As Boolean


        public struct t_TeamList
        {
            public string PLR1;
            public string PLR2;
            public string PLR3;
            public string PLR4;
            public int RID1;
            public int RID2;
            public int RID3;
            public int RID4;
            public int PlrCnt;
            public int Gmode;
            public int RankID;
            public int RankAxis;
            public int RankAllies;
            public int WinAllies;
            public int LossAllies;
            public int WinAxis;
            public int LossAxis;
        }

        public struct t_LabelSetup
        {
            public int Width;
            public int Height;
            public Color F1;
            public Color F2;
            public int FDir;
            public Color B1;
            public Color B2;
            public int BDir;
            public int O1;
            public int O2;
            public Color BackC;           // R4.00 The background color.
            public string ShadowDir;      // R4.00 This should be an integer at some point.
            public Color ShadowColor;
            public string ShadowDepth;    // R4.00 This needs to be an integer at some point. 
            public int ShadowX;       // R4.00 Added this for speed. 
            public int ShadowY;
            public string Scaling;
            public string OVLScaling;
            public int BorderMode;    // R4.40 RANK/NAME border. 
            public Color BorderColor;
            public int BorderWidth;       // R4.40 Thickness of border lines.
            public bool UseCardBack;       // R4.40 Dont use background image on PLAYER CARD draws.
            public int BorderPanelMode;   // R4.40 RANK/NAME border. 
            public Color BorderPanelColor;
            public int BorderPanelWidth;       // R4.40 Thickness of border lines.
        }

        public struct t_Box
        {
            public float X;
            public float Y;
            public float Xtext;      // R3.40 X adjusted for Left or right justify Name text.
            public float Xcenter;
            public float Ycenter;
            public float Width;
            public float Height;
        }

        public struct t_NoteAnimation
        {
            public bool Active;
            public int Mode;
            public string Align;
            public int Xoffset;      // R4.00 Final position offsets.
            public int Yoffset;
            public float X;
            public float Y;
            public float Xstart;
            public float Ystart;
            public float Xend;
            public float Yend;
            public float Xdir;
            public float Ydir;
            public bool Holding;
            public int Speed;
            public long TimeHold;        // R4.00 Time in MilliSeconds to hold once we are done moving.
            public long TimeAcc;         // R4.00 Accumulated time in animation sequence.
            public int TextCount;    // R4.00 How many strings do we have to show.
            public int TextCurrent;  // R4.00 Which string are we showing now.
            public string Delim;         // R4.00 Text seperator for combined message notes.
        }

        public enum FXVarDefs
        {
            None = 0,
            Mode = 1,
            ShadeAng = 2,
            ShadeAmount = 3,
            ShadeBias = 4
        }

        public enum FXMode
        {
            None = 0,
            Shadow = 1,
            Emboss = 2,
            LabelBlur = 3
        }
    }
}