using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
    public class Utilities
    {
        public static string PATH_StripFilename(string tPath)
        {
            string PATH_StripFilenameRet = default;
            // R2.00 Strip the filename off for init dir on dialog.  
            int N;
            string S;
            N = Conversions.ToInteger(STRING_FindLastSlash(tPath));
            if (3 < N)
            {
                S = Strings.Mid(tPath, 1, N);
            }
            else
            {
                S = "";
            }

            PATH_StripFilenameRet = S;
            return PATH_StripFilenameRet;
        }

        public static string PATH_GetAnyPath()
        {
            string PATH_GetAnyPathRet = default;
            string tPath = "";

            // R4.00 Get a texture path from defined textures.
            if (!string.IsNullOrEmpty(frmMain.PATH_BackgroundImage))
            {
                tPath = PATH_StripFilename(frmMain.PATH_BackgroundImage);
            }
            else
            {
                if (!string.IsNullOrEmpty(frmMain.PATH_Note01_Bmp))
                    tPath = PATH_StripFilename(frmMain.PATH_Note01_Bmp);
                if (!string.IsNullOrEmpty(frmMain.PATH_Note02_Bmp))
                    tPath = PATH_StripFilename(frmMain.PATH_Note02_Bmp);
                if (!string.IsNullOrEmpty(frmMain.PATH_Note03_Bmp))
                    tPath = PATH_StripFilename(frmMain.PATH_Note03_Bmp);
                if (!string.IsNullOrEmpty(frmMain.PATH_Note04_Bmp))
                    tPath = PATH_StripFilename(frmMain.PATH_Note04_Bmp);
            }

            PATH_GetAnyPathRet = tPath;
            return PATH_GetAnyPathRet;
        }


        public static object STRING_FindLastSlash(string A)
        {
            object STRING_FindLastSlashRet = default;
            int i;
            int Hit;
            Hit = 0;
            for (i = Strings.Len(A); i >= 1; i -= 1)
            {
                if (Strings.Mid(A, i, 1) == @"\")
                {
                    Hit = i;
                    break;
                }
            }

            STRING_FindLastSlashRet = Hit;
            return STRING_FindLastSlashRet;
        }
    }
}
