using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MakoCelo.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;

namespace MakoCelo
{
	// Token: 0x0200000C RID: 12
	[DesignerGenerated]
	public partial class frmMain : Form
	{
		// Token: 0x0600012B RID: 299 RVA: 0x00009C68 File Offset: 0x00007E68
		public frmMain()
		{
			base.Load += this.frmMain_Load;
			base.Shown += this.frmMain_Shown;
			base.FormClosed += this.frmMain_FormClosed;
			base.Closing += this.frmMain_Closing;
			base.Paint += this.frmMain_Paint;
			this.STATS_SizeX = 900;
			this.STATS_SizeY = 180;
			this.PATH_Game = "";
			this.PATH_GamePath = "";
			this.PATH_BackgroundImage = "";
			this.PATH_BackgroundImagePath = "";
			this.PATH_SaveStatsImage = "";
			this.PATH_SoundFiles = "";
			this.LAB_Rank = new clsGlobal.t_Box[9];
			this.LAB_Name = new clsGlobal.t_Box[9];
			this.LAB_Fact = new clsGlobal.t_Box[9];
			this.LAB_Name_Align = new StringFormat[9];
			this.PlrName = new string[9];
			this.PlrRank = new string[9];
			this.PlrFact = new string[9];
			this.PlrSteam = new string[9];
			this.PlrName_Last = new string[9];
			this.PlrRank_Last = new string[9];
			this.PlrFact_Last = new string[9];
			this.PlrSteam_Last = new string[9];
			this.CFX3DActive = new bool[11];
			this.CFX3DVar = new string[11, 11];
			this.CFX3DC = new Color[11];
			this.Note01_Text = new string[21];
			this.Note02_Text = new string[21];
			this.Note03_Text = new string[21];
			this.Note04_Text = new string[21];
			this.NoteAnim01_Text = new string[11];
			this.NoteAnim02_Text = new string[11];
			this.NoteAnim03_Text = new string[11];
			this.NoteAnim04_Text = new string[11];
			this.SOUND_File = new string[31];
			this.SOUND_Vol = new string[31];
			this.InitializeComponent();
		}

		// Token: 0x0600012C RID: 300
		[DllImport("winmm.dll")]
		public static extern int waveOutGetVolume(IntPtr hwo, int dwVolume);

		// Token: 0x0600012D RID: 301
		[DllImport("winmm.dll")]
		public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

		// Token: 0x0600012E RID: 302 RVA: 0x00009E7A File Offset: 0x0000807A
		private void cmCheckLog_Click(object sender, EventArgs e)
		{
			this.LOG_Scan();
			this.GFX_DrawStats();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00009E88 File Offset: 0x00008088
		private void STATS_StoreLast()
		{
			int num = 1;
			checked
			{
				int num2;
				while (Operators.CompareString(this.PlrSteam[num], "", false) == 0)
				{
					num++;
					if (num > 8)
					{
						IL_23:
						if (0 < num2)
						{
							num = 1;
							do
							{
								this.PlrRank_Last[num] = this.PlrRank[num];
								this.PlrName_Last[num] = this.PlrName[num];
								this.PlrSteam_Last[num] = this.PlrSteam[num];
								this.PlrFact_Last[num] = this.PlrFact[num];
								num++;
							}
							while (num <= 8);
						}
						return;
					}
				}
				num2 = num;
				goto IL_23;
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00009F08 File Offset: 0x00008108
		private void LOG_Scan()
		{
			string[] array = new string[10];
			string[] array2 = new string[10];
			string[] array3 = new string[10];
			string[] array4 = new string[10];
			long[] array5 = new long[10];
			long[] array6 = new long[10];
			this.lbError1.Text = "";
			this.lbError1.BackColor = Color.FromArgb(255, 192, 192, 192);
			this.lbError2.Text = "";
			this.lbError2.BackColor = Color.FromArgb(255, 192, 192, 192);
			checked
			{
				if (File.Exists(this.PATH_Game))
				{
					this.STATS_StoreLast();
					int num = 1;
					do
					{
						array[num] = this.PlrRank[num];
						array2[num] = this.PlrName[num];
						array3[num] = this.PlrSteam[num];
						array4[num] = this.PlrFact[num];
						this.PlrRank[num] = "";
						this.PlrName[num] = "";
						this.PlrSteam[num] = "";
						this.PlrFact[num] = "";
						num++;
					}
					while (num <= 8);
					this.lbStatus.Text = "Open file...";
					Application.DoEvents();
					FileStream fileStream = new FileStream(this.PATH_Game, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
					using (streamReader)
					{
						while (!streamReader.EndOfStream)
						{
							string text = streamReader.ReadLine();
							if (Strings.InStr(text, "Match Started", CompareMethod.Binary) != 0)
							{
								bool flag = true;
								int num2 = 1;
								do
								{
									this.PlrRank[num2] = "";
									this.PlrSteam[num2] = "";
									array5[num2] = 0L;
									num2++;
								}
								while (num2 <= 8);
								int num3 = 0;
								while (!streamReader.EndOfStream && flag)
								{
									num3++;
									string text2 = Strings.Trim(Strings.Mid(text, 98, 20));
									if (Operators.CompareString(text2, "-1", false) == 0 | Operators.CompareString(text2, "", false) == 0)
									{
										text2 = "---";
									}
									else
									{
										text2 = Conversions.ToString((long)Math.Round(Conversion.Val(text2)) + 1L);
									}
									this.PlrRank[num3] = text2;
									this.PlrSteam[num3] = Strings.Mid(text, 57, 17);
									if (Operators.CompareString(Strings.Mid(this.PlrSteam[num3], 1, 4), "7656", false) != 0)
									{
										this.PlrSteam[num3] = "";
										array5[num3] = 0L;
									}
									else
									{
										array5[num3] = this.LOG_HexToLong(Strings.Mid(text, 41, 8));
										if (array5[num3] == -1L)
										{
											array5[num3] = 0L;
										}
									}
									text = streamReader.ReadLine();
									if (Strings.InStr(text, "Match Started", CompareMethod.Binary) == 0)
									{
										flag = false;
									}
								}
							}
							if (Strings.InStr(text, "GAME ", CompareMethod.Binary) != 0 && (Strings.InStr(text, "Human Player", CompareMethod.Binary) | Strings.InStr(text, "AI Player", CompareMethod.Binary)) != 0)
							{
								int num4 = 1;
								do
								{
									this.PlrName[num4] = "";
									this.PlrFact[num4] = "";
									array6[num4] = 0L;
									num4++;
								}
								while (num4 <= 8);
								int num3 = 0;
								bool flag2 = true;
								while (!streamReader.EndOfStream && flag2)
								{
									num3++;
									int num7;
									unchecked
									{
										long num5 = (long)Strings.InStr(text, "Human Player", CompareMethod.Binary);
										long num6 = (long)Strings.InStr(text, "AI Player", CompareMethod.Binary);
										if (num5 != 0L)
										{
											this.PlrName[num3] = this.LOG_FindPlayer(text, 39);
											array6[num3] = this.LOG_Find_RelicID(text);
										}
										else
										{
											this.PlrName[num3] = this.LOG_FindPlayer(text, 36);
											array6[num3] = 0L;
										}
										num7 = Strings.Len(text);
									}
									if (20 < num7)
									{
										if (Operators.CompareString(Strings.Mid(text, num7 - 5, 6), "german", false) == 0)
										{
											this.PlrFact[num3] = "01";
										}
										if (Operators.CompareString(Strings.Mid(text, num7 - 5, 6), "soviet", false) == 0)
										{
											this.PlrFact[num3] = "02";
										}
										if (Operators.CompareString(Strings.Mid(text, num7 - 10, 11), "west_german", false) == 0)
										{
											this.PlrFact[num3] = "03";
										}
										if (Operators.CompareString(Strings.Mid(text, num7 - 2, 3), "aef", false) == 0)
										{
											this.PlrFact[num3] = "04";
										}
										if (Operators.CompareString(Strings.Mid(text, num7 - 6, 7), "british", false) == 0)
										{
											this.PlrFact[num3] = "05";
										}
									}
									text = streamReader.ReadLine();
									unchecked
									{
										long num8 = (long)Strings.InStr(text, "Human Player", CompareMethod.Binary);
										long num6 = (long)Strings.InStr(text, "AI Player", CompareMethod.Binary);
										if (num8 == 0L & num6 == 0L)
										{
											flag2 = false;
										}
									}
								}
							}
						}
					}
					streamReader.Close();
					streamReader.Dispose();
					fileStream.Close();
					fileStream.Dispose();
					if (!this.FLAG_ShowMismatch)
					{
						bool flag3 = true;
						int num9 = 1;
						while (array5[num9] == array6[num9])
						{
							num9++;
							if (num9 > 8)
							{
								IL_540:
								if (flag3)
								{
									goto IL_5E5;
								}
								this.lbError1.Text = "Mismatched";
								this.lbError1.BackColor = Color.FromArgb(255, 255, 0, 0);
								this.lbError2.Text = "Bad Stats";
								this.lbError2.BackColor = Color.FromArgb(255, 255, 0, 0);
								int num10 = 1;
								for (;;)
								{
									this.PlrName[num10] = "";
									this.PlrRank[num10] = "---";
									this.PlrSteam[num10] = "";
									this.PlrFact[num10] = "";
									num10++;
									if (num10 > 8)
									{
										goto IL_5E5;
									}
								}
							}
						}
						flag3 = false;
						goto IL_540;
					}
					IL_5E5:
					int num11 = 1;
					int num12;
					do
					{
						if (Operators.CompareString(this.PlrRank[num11], "", false) != 0)
						{
							num12++;
						}
						if (Operators.CompareString(this.PlrName[num11], "", false) != 0)
						{
							num12++;
						}
						if (Operators.CompareString(this.PlrSteam[num11], "", false) != 0)
						{
							num12++;
						}
						if (Operators.CompareString(this.PlrFact[num11], "", false) != 0)
						{
							num12++;
						}
						num11++;
					}
					while (num11 <= 8);
					if (num12 == 0)
					{
						int num13 = 1;
						do
						{
							this.PlrRank[num13] = array[num13];
							this.PlrName[num13] = array2[num13];
							this.PlrSteam[num13] = array3[num13];
							this.PlrFact[num13] = array4[num13];
							num13++;
						}
						while (num13 <= 8);
					}
					int num14 = 1;
					do
					{
						if (Operators.CompareString(this.PlrRank[num14], "", false) == 0)
						{
							this.PlrRank[num14] = "---";
						}
						if (Operators.CompareString(this.PlrName[num14], "", false) == 0)
						{
							this.PlrRank[num14] = "";
						}
						num14++;
					}
					while (num14 <= 8);
					this.lbStatus.Text = "Render...";
					Application.DoEvents();
					this.GFX_DrawStats();
					this.lbStatus.Text = "Ready";
					Application.DoEvents();
					return;
				}
				if (Operators.CompareString(this.PATH_Game, "", false) == 0)
				{
					Interaction.MsgBox("Please locate the warnings.log file in your COH2 My Games directory.\r\rClick on FIND LOG FILE to search and select.", MsgBoxStyle.Information, null);
					return;
				}
				Interaction.MsgBox("ERROR: The LOG file location does not appear to be valid.\r\rUnable to open the LOG file to get stats.\rVerify this file/path exists.\r\r" + this.PATH_Game, MsgBoxStyle.Critical, null);
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000A664 File Offset: 0x00008864
		private long LOG_HexToLong(string A)
		{
			long result;
			try
			{
				result = Convert.ToInt64(A, 16);
			}
			catch (Exception ex)
			{
				result = 0L;
			}
			return result;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000A6A0 File Offset: 0x000088A0
		private bool LOG_AreTimesInValid(string MatchTime, string GameTime)
		{
			bool result = false;
			checked
			{
				long num = (long)Math.Round(Conversion.Val(Strings.Mid(MatchTime, 1, 2)));
				long num2 = (long)Math.Round(Conversion.Val(Strings.Mid(GameTime, 1, 2)));
				long num3 = (long)Math.Round(Conversion.Val(Strings.Mid(MatchTime, 4, 2)));
				long num4 = (long)Math.Round(Conversion.Val(Strings.Mid(GameTime, 4, 2)));
				if (num == 0L & num2 == 23L)
				{
					num = 24L;
				}
				if (num3 == 0L & num4 == 59L)
				{
					num3 = 60L;
				}
				if (num2 == 0L & num == 23L)
				{
					num2 = 24L;
				}
				if (num4 == 0L & num3 == 59L)
				{
					num4 = 60L;
				}
				if (2L < Math.Abs(num - num2))
				{
					result = true;
				}
				if (2L < Math.Abs(num3 - num4))
				{
					result = true;
				}
				return result;
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000A77C File Offset: 0x0000897C
		private long LOG_Find_RelicID(string A)
		{
			long result = 0L;
			checked
			{
				int num2;
				int num3;
				for (int i = Strings.Len(A); i >= 1; i += -1)
				{
					if (Operators.CompareString(Strings.Mid(A, i, 1), " ", false) == 0)
					{
						int num;
						num++;
						if (num == 2)
						{
							num2 = i;
						}
						if (num == 3)
						{
							num3 = i;
							break;
						}
					}
				}
				if (num2 != 0)
				{
					result = (long)Math.Round(Conversion.Val(Strings.Mid(A, num3, num2 - num3)));
				}
				return result;
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000A7EC File Offset: 0x000089EC
		private string LOG_FindPlayer(string A, int CharStart)
		{
			checked
			{
				string text;
				int num2;
				for (int i = Strings.Len(A); i >= 1; i += -1)
				{
					text = Strings.Mid(A, i, 1);
					int num;
					if (Operators.CompareString(text, " ", false) == 0)
					{
						num++;
					}
					if (num == 3)
					{
						num2 = i;
						break;
					}
				}
				text = "None";
				if (num2 != 0)
				{
					text = Strings.Mid(A, CharStart, num2 - CharStart);
				}
				return text;
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000A84C File Offset: 0x00008A4C
		private bool SETTINGS_Load_CheckVersion(ref bool IsOldStyle)
		{
			bool flag = false;
			string path = Application.StartupPath + "\\MakoCelo_settings.dat";
			bool result;
			if (!File.Exists(path))
			{
				result = flag;
			}
			else
			{
				FileStream fileStream;
				StreamReader streamReader;
				try
				{
					fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					streamReader = new StreamReader(fileStream, Encoding.UTF8);
					string text = streamReader.ReadLine();
					if (Operators.CompareString(text, "\"VERSION MC300\"", false) != 0)
					{
						if (Operators.CompareString(text, "\"VERSION MC400\"", false) != 0)
						{
							if (Operators.CompareString(text, "VERSION MC300", false) != 0)
							{
								if (Operators.CompareString(text, "VERSION MC400", false) != 0)
								{
									if (Operators.CompareString(text, "VERSION MC500", false) != 0)
									{
										text = "WARNING: The MakoCelo settings file seems to be from a previous version of code and will not be loaded.\r\r";
										text += "This file will be updated automatically when making changes in the new version of the program.";
										Interaction.MsgBox(text, MsgBoxStyle.Information, "MakoCelo Startup Checks");
									}
									else
									{
										flag = true;
										IsOldStyle = false;
									}
								}
								else
								{
									flag = true;
									IsOldStyle = true;
								}
							}
							else
							{
								flag = true;
								IsOldStyle = true;
							}
						}
						else
						{
							flag = true;
							IsOldStyle = true;
						}
					}
					else
					{
						flag = true;
						IsOldStyle = true;
					}
				}
				catch (Exception ex)
				{
					Interaction.MsgBox("ERROR: " + ex.Message + "\r\rUnable to read the saved settings.\rThe last known setup could not be loaded.\r\rIf running a new version, this error may fix itself when a new setup is saved.", MsgBoxStyle.Critical, "MakoCelo - Setup Error");
				}
				streamReader.Close();
				streamReader.Dispose();
				fileStream.Close();
				fileStream.Dispose();
				result = flag;
			}
			return result;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000A990 File Offset: 0x00008B90
		private void SETTINGS_Load()
		{
			int num = 0;
			string path = Application.StartupPath + "\\MakoCelo_settings.dat";
			checked
			{
				if (File.Exists(path))
				{
					FileStream fileStream;
					StreamReader streamReader;
					try
					{
						fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						streamReader = new StreamReader(fileStream, Encoding.UTF8);
						string text = streamReader.ReadLine();
						if (Operators.CompareString(text, "VERSION MC200", false) != 0)
						{
							if (Operators.CompareString(text, "VERSION MC300", false) != 0)
							{
								if (Operators.CompareString(text, "VERSION MC400", false) != 0)
								{
									if (Operators.CompareString(text, "VERSION MC500", false) != 0)
									{
										Interaction.MsgBox("WARNING: The startup data file appears to be corrupt or incorrect.\r\rPath: " + Application.StartupPath + "\\MakoCelo_settings.dat", MsgBoxStyle.Critical, "MakoCELO");
									}
									else
									{
										num = 5;
										text = streamReader.ReadLine();
									}
								}
								else
								{
									num = 4;
									text = streamReader.ReadLine();
								}
							}
							else
							{
								num = 3;
								text = streamReader.ReadLine();
							}
						}
						else
						{
							num = 2;
							text = streamReader.ReadLine();
						}
						text = streamReader.ReadLine();
						int alpha = (int)Math.Round(Conversion.Val(text));
						text = streamReader.ReadLine();
						int red = (int)Math.Round(Conversion.Val(text));
						text = streamReader.ReadLine();
						int green = (int)Math.Round(Conversion.Val(text));
						text = streamReader.ReadLine();
						int blue = (int)Math.Round(Conversion.Val(text));
						Color.FromArgb(alpha, red, green, blue);
						text = streamReader.ReadLine();
						text = streamReader.ReadLine();
						alpha = (int)Math.Round(Conversion.Val(text));
						text = streamReader.ReadLine();
						red = (int)Math.Round(Conversion.Val(text));
						text = streamReader.ReadLine();
						green = (int)Math.Round(Conversion.Val(text));
						text = streamReader.ReadLine();
						blue = (int)Math.Round(Conversion.Val(text));
						Color.FromArgb(alpha, red, green, blue);
						text = streamReader.ReadLine();
						text = streamReader.ReadLine();
						text = streamReader.ReadLine();
						text = streamReader.ReadLine();
						if (File.Exists(text))
						{
							this.NAME_bmp = new Bitmap(text);
							this.PATH_BackgroundImage = text;
						}
						else if (Operators.CompareString(text, "", false) != 0)
						{
							Interaction.MsgBox("ERROR: The User Settings background image no longer exists.\r\rFile:" + text, MsgBoxStyle.OkOnly, null);
						}
						text = streamReader.ReadLine();
						text = streamReader.ReadLine();
						this.PATH_Game = Strings.Trim(text);
						text = streamReader.ReadLine();
						text = streamReader.ReadLine();
						frmMain.FONT_Rank_Name = Strings.Trim(text);
						text = streamReader.ReadLine();
						frmMain.FONT_Rank_Size = Strings.Trim(text);
						text = streamReader.ReadLine();
						frmMain.FONT_Rank_Bold = Strings.Trim(text);
						text = streamReader.ReadLine();
						frmMain.FONT_Rank_Italic = Strings.Trim(text);
						Operators.CompareString(frmMain.FONT_Rank_Bold, "True", false);
						Operators.CompareString(frmMain.FONT_Rank_Italic, "True", false);
						frmMain.FONT_Rank = new Font(frmMain.FONT_Rank_Name, Conversions.ToSingle(frmMain.FONT_Rank_Size), FontStyle.Regular);
						if (Operators.CompareString(frmMain.FONT_Rank_Bold, "True", false) == 0)
						{
							frmMain.FONT_Rank = new Font(frmMain.FONT_Rank_Name, Conversions.ToSingle(frmMain.FONT_Rank_Size), FontStyle.Bold);
						}
						if (Operators.CompareString(frmMain.FONT_Rank_Italic, "True", false) == 0)
						{
							frmMain.FONT_Rank = new Font(frmMain.FONT_Rank_Name, Conversions.ToSingle(frmMain.FONT_Rank_Size), FontStyle.Italic);
						}
						if (0 < num)
						{
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							frmMain.FONT_Name_Name = Strings.Trim(text);
							text = streamReader.ReadLine();
							frmMain.FONT_Name_Size = Strings.Trim(text);
							text = streamReader.ReadLine();
							frmMain.FONT_Name_Bold = Strings.Trim(text);
							text = streamReader.ReadLine();
							frmMain.FONT_Name_Italic = Strings.Trim(text);
							Operators.CompareString(frmMain.FONT_Name_Bold, "True", false);
							Operators.CompareString(frmMain.FONT_Name_Italic, "True", false);
							frmMain.FONT_Name = new Font(frmMain.FONT_Name_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Regular);
							if (Operators.CompareString(frmMain.FONT_Name_Bold, "True", false) == 0)
							{
								frmMain.FONT_Name = new Font(frmMain.FONT_Name_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Bold);
							}
							if (Operators.CompareString(frmMain.FONT_Name_Italic, "True", false) == 0)
							{
								frmMain.FONT_Name = new Font(frmMain.FONT_Name_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Italic);
							}
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							this.SETTINGS_GetStatSize(text);
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							this.cboLayoutY.Text = Strings.Trim(text);
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							this.cboLayoutX.Text = Strings.Trim(text);
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							alpha = (int)Math.Round(Conversion.Val(text));
							text = streamReader.ReadLine();
							red = (int)Math.Round(Conversion.Val(text));
							text = streamReader.ReadLine();
							green = (int)Math.Round(Conversion.Val(text));
							text = streamReader.ReadLine();
							blue = (int)Math.Round(Conversion.Val(text));
							this.pbStats.BackColor = Color.FromArgb(alpha, red, green, blue);
							this.LSName.BackC = this.pbStats.BackColor;
							text = streamReader.ReadLine();
							text = streamReader.ReadLine();
							this.LSName.Scaling = Strings.Trim(text);
							if (!streamReader.EndOfStream)
							{
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.GUI_ColorMode = (int)Math.Round(Conversion.Val(Strings.Trim(text)));
							}
							else
							{
								this.GUI_ColorMode = 0;
							}
							if (2 < num)
							{
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.F1 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.F2 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.LSRank.FDir = Conversions.ToInteger(text);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.B1 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.B2 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.LSRank.BDir = Conversions.ToInteger(text);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.F1 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.F2 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.LSName.FDir = Conversions.ToInteger(text);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.B1 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.B2 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.LSName.BDir = Conversions.ToInteger(text);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.ShadowColor = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.LSRank.ShadowDir = text;
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.LSRank.ShadowDepth = text;
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.ShadowColor = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.LSName.ShadowDir = text;
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.LSName.ShadowDepth = text;
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.COLOR_Back1 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								alpha = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								red = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								green = (int)Math.Round(Conversion.Val(text));
								text = streamReader.ReadLine();
								blue = (int)Math.Round(Conversion.Val(text));
								this.COLOR_Back2 = Color.FromArgb(alpha, red, green, blue);
								text = streamReader.ReadLine();
								text = streamReader.ReadLine();
								this.COLOR_Back_Dir = Conversions.ToInteger(text);
								if (3 < num)
								{
									text = streamReader.ReadLine();
									int num2 = 1;
									do
									{
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										this.CFX3DC[num2] = Color.FromArgb(alpha, red, green, blue);
										num2++;
									}
									while (num2 <= 10);
									text = streamReader.ReadLine();
									int num3 = 1;
									do
									{
										int num4 = 1;
										do
										{
											text = streamReader.ReadLine();
											this.CFX3DVar[num3, num4] = Strings.Trim(text);
											num4++;
										}
										while (num4 <= 10);
										num3++;
									}
									while (num3 <= 10);
									text = streamReader.ReadLine();
									int num5 = 1;
									do
									{
										text = streamReader.ReadLine();
										if (Operators.CompareString(text, "True", false) == 0)
										{
											this.CFX3DActive[num5] = true;
										}
										else
										{
											this.CFX3DActive[num5] = false;
										}
										num5++;
									}
									while (num5 <= 10);
									if (num == 5)
									{
										text = streamReader.ReadLine();
										text = streamReader.ReadLine();
										frmMain.PATH_Name_OVLBmp = text;
										text = streamReader.ReadLine();
										this.LSName.OVLScaling = Conversions.ToString(Conversion.Val(text));
										text = streamReader.ReadLine();
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.B1 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.B2 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.BackC = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote01.BDir = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.F1 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.F2 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote01.FDir = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote01.Height = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote01.O1 = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote01.O2 = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote01.Scaling = Conversions.ToString(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote01.OVLScaling = Conversions.ToString(Conversion.Val(text));
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.ShadowColor = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote01.ShadowDepth = text;
										text = streamReader.ReadLine();
										frmMain.LSNote01.ShadowDir = text;
										text = streamReader.ReadLine();
										frmMain.LSNote01.Width = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.PATH_Note01_Bmp = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note01_BmpPath = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note01_OVLBmp = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note01_OVLBmpPath = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note01_Name = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note01_Bold = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note01_Italic = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note01_Size = text;
										int num6 = 1;
										do
										{
											text = streamReader.ReadLine();
											this.NoteAnim01_Text[num6] = text;
											num6++;
										}
										while (num6 <= 10);
										text = streamReader.ReadLine();
										this.NoteAnim01.Mode = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim01.Speed = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim01.TimeHold = (long)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim01.Align = text;
										text = streamReader.ReadLine();
										this.NoteAnim01.Delim = text;
										text = streamReader.ReadLine();
										this.NoteAnim01.Xoffset = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim01.Yoffset = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.B1 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.B2 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.BackC = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote02.BDir = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.F1 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.F2 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote02.FDir = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote02.Height = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote02.O1 = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote02.O2 = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote02.Scaling = Conversions.ToString(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote02.OVLScaling = Conversions.ToString(Conversion.Val(text));
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.ShadowColor = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote02.ShadowDepth = text;
										text = streamReader.ReadLine();
										frmMain.LSNote02.ShadowDir = text;
										text = streamReader.ReadLine();
										frmMain.LSNote02.Width = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.PATH_Note02_Bmp = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note02_BmpPath = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note02_OVLBmp = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note02_OVLBmpPath = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note02_Name = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note02_Bold = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note02_Italic = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note02_Size = text;
										int num7 = 1;
										do
										{
											text = streamReader.ReadLine();
											this.NoteAnim02_Text[num7] = text;
											num7++;
										}
										while (num7 <= 10);
										text = streamReader.ReadLine();
										this.NoteAnim02.Mode = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim02.Speed = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim02.TimeHold = (long)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim02.Align = text;
										text = streamReader.ReadLine();
										this.NoteAnim02.Delim = text;
										text = streamReader.ReadLine();
										this.NoteAnim02.Xoffset = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim02.Yoffset = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.B1 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.B2 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.BackC = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote03.BDir = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.F1 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.F2 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote03.FDir = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote03.Height = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote03.O1 = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote03.O2 = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote03.Scaling = Conversions.ToString(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote03.OVLScaling = Conversions.ToString(Conversion.Val(text));
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.ShadowColor = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote03.ShadowDepth = text;
										text = streamReader.ReadLine();
										frmMain.LSNote03.ShadowDir = text;
										text = streamReader.ReadLine();
										frmMain.LSNote03.Width = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.PATH_Note03_Bmp = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note03_BmpPath = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note03_OVLBmp = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note03_OVLBmpPath = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note03_Name = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note03_Bold = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note03_Italic = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note03_Size = text;
										int num8 = 1;
										do
										{
											text = streamReader.ReadLine();
											this.NoteAnim03_Text[num8] = text;
											num8++;
										}
										while (num8 <= 10);
										text = streamReader.ReadLine();
										this.NoteAnim03.Mode = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim03.Speed = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim03.TimeHold = (long)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim03.Align = text;
										text = streamReader.ReadLine();
										this.NoteAnim03.Delim = text;
										text = streamReader.ReadLine();
										this.NoteAnim03.Xoffset = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim03.Yoffset = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.B1 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.B2 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.BackC = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote04.BDir = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.F1 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.F2 = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote04.FDir = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote04.Height = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote04.O1 = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote04.O2 = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote04.Scaling = Conversions.ToString(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.LSNote04.OVLScaling = Conversions.ToString(Conversion.Val(text));
										text = streamReader.ReadLine();
										alpha = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										red = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										green = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.ShadowColor = Color.FromArgb(alpha, red, green, blue);
										text = streamReader.ReadLine();
										frmMain.LSNote04.ShadowDepth = text;
										text = streamReader.ReadLine();
										frmMain.LSNote04.ShadowDir = text;
										text = streamReader.ReadLine();
										frmMain.LSNote04.Width = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										frmMain.PATH_Note04_Bmp = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note04_BmpPath = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note04_OVLBmp = text;
										text = streamReader.ReadLine();
										frmMain.PATH_Note04_OVLBmpPath = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note04_Name = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note04_Bold = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note04_Italic = text;
										text = streamReader.ReadLine();
										frmMain.FONT_Note04_Size = text;
										int num9 = 1;
										do
										{
											text = streamReader.ReadLine();
											this.NoteAnim04_Text[num9] = text;
											num9++;
										}
										while (num9 <= 10);
										text = streamReader.ReadLine();
										this.NoteAnim04.Mode = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim04.Speed = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim04.TimeHold = (long)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim04.Align = text;
										text = streamReader.ReadLine();
										this.NoteAnim04.Delim = text;
										text = streamReader.ReadLine();
										this.NoteAnim04.Xoffset = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.NoteAnim04.Yoffset = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										text = streamReader.ReadLine();
										this.NOTE_Spacing = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										int num10 = 1;
										do
										{
											text = streamReader.ReadLine();
											this.SOUND_File[num10] = Strings.Trim(text);
											text = streamReader.ReadLine();
											text = streamReader.ReadLine();
											this.SOUND_Vol[num10] = Conversions.ToString(Conversion.Val(text));
											if (Conversions.ToDouble(this.SOUND_Vol[num10]) < 10.0)
											{
												this.SOUND_Vol[num10] = Conversions.ToString(100);
											}
											num10++;
										}
										while (num10 <= 30);
										text = streamReader.ReadLine();
										this.scrVolume.Value = (int)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										text = streamReader.ReadLine();
										this.Celo_Windowstate = Strings.Trim(text);
										text = streamReader.ReadLine();
										this.Celo_Left = (long)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.Celo_Top = (long)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.Celo_Width = (long)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										this.Celo_Height = (long)Math.Round(Conversion.Val(text));
										text = streamReader.ReadLine();
										if (Operators.CompareString(text, "1", false) == 0)
										{
											this.chkPosition.Checked = true;
										}
										text = streamReader.ReadLine();
										if (Operators.CompareString(text, "1", false) == 0)
										{
											this.chkPopUp.Checked = true;
											this.Celo_Popup = true;
										}
										text = streamReader.ReadLine();
										if (Operators.CompareString(text, "PAGE XY OFFSET", false) == 0)
										{
											text = streamReader.ReadLine();
											this.tbXoff.Text = Strings.Trim(text);
											text = streamReader.ReadLine();
											this.tbYoff.Text = Strings.Trim(text);
										}
										else
										{
											text = streamReader.ReadLine();
											text = streamReader.ReadLine();
										}
										text = streamReader.ReadLine();
										if (Operators.CompareString(text, "PAGE XY SIZE", false) == 0)
										{
											text = streamReader.ReadLine();
											this.tbXsize.Text = Strings.Trim(text);
											text = streamReader.ReadLine();
											this.tbYSize.Text = Strings.Trim(text);
											this.STATS_ClipXY((float)Conversion.Val(this.tbXsize.Text), (float)Conversion.Val(this.tbYSize.Text));
										}
										else
										{
											text = streamReader.ReadLine();
											text = streamReader.ReadLine();
										}
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						Interaction.MsgBox("ERROR: " + ex.Message + "\r\rUnable to read the saved settings.\rThe last known setup could not be loaded.\r\rIf running a new version, this error may fix itself when a new setup is saved.", MsgBoxStyle.Critical, "MakoCelo - Setup Error");
					}
					this.FX_SetVarControls();
					this.SETTINGS_SetupAfterLoad();
					if (!Information.IsNothing(streamReader))
					{
						streamReader.Close();
						streamReader.Dispose();
					}
					if (!Information.IsNothing(fileStream))
					{
						fileStream.Close();
						fileStream.Dispose();
					}
				}
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000CDB4 File Offset: 0x0000AFB4
		private void SETTINGS_GetStatSize(string OldSizeMethod)
		{
			int num = 980;
			int num2 = 180;
			uint num3 = <PrivateImplementationDetails>.ComputeStringHash(OldSizeMethod);
			if (num3 <= 1135835943U)
			{
				if (num3 <= 548848843U)
				{
					if (num3 <= 371867473U)
					{
						if (num3 != 153144592U)
						{
							if (num3 == 371867473U)
							{
								if (Operators.CompareString(OldSizeMethod, "12 - 1280 x 256", false) == 0)
								{
									num = 1280;
									num2 = 256;
								}
							}
						}
						else if (Operators.CompareString(OldSizeMethod, "0 - 580 x 140", false) == 0)
						{
							num = 580;
							num2 = 140;
						}
					}
					else if (num3 != 432266946U)
					{
						if (num3 != 528264336U)
						{
							if (num3 == 548848843U)
							{
								if (Operators.CompareString(OldSizeMethod, "10 - 900 x 180", false) == 0)
								{
									num = 900;
									num2 = 180;
								}
							}
						}
						else if (Operators.CompareString(OldSizeMethod, "11 - 980 x 180", false) == 0)
						{
							num = 980;
							num2 = 180;
						}
					}
					else if (Operators.CompareString(OldSizeMethod, "16 - 800 x 100", false) == 0)
					{
						num = 800;
						num2 = 100;
					}
				}
				else if (num3 <= 670202844U)
				{
					if (num3 != 551252818U)
					{
						if (num3 == 670202844U)
						{
							if (Operators.CompareString(OldSizeMethod, "6 - 580 x 120", false) == 0)
							{
								num = 580;
								num2 = 120;
							}
						}
					}
					else if (Operators.CompareString(OldSizeMethod, "2 - 720 x 180", false) == 0)
					{
						num = 720;
						num2 = 180;
					}
				}
				else if (num3 != 903378294U)
				{
					if (num3 != 1020970369U)
					{
						if (num3 == 1135835943U)
						{
							if (Operators.CompareString(OldSizeMethod, "14 - 640 x 80", false) == 0)
							{
								num = 640;
								num2 = 80;
							}
						}
					}
					else if (Operators.CompareString(OldSizeMethod, "18 - 980 x 120", false) == 0)
					{
						num = 980;
						num2 = 120;
					}
				}
				else if (Operators.CompareString(OldSizeMethod, "9 - 800 x 160", false) == 0)
				{
					num = 800;
					num2 = 160;
				}
			}
			else if (num3 <= 2993519175U)
			{
				if (num3 <= 2263364804U)
				{
					if (num3 != 1661731261U)
					{
						if (num3 == 2263364804U)
						{
							if (Operators.CompareString(OldSizeMethod, "8 - 720 x 144", false) == 0)
							{
								num = 720;
								num2 = 144;
							}
						}
					}
					else if (Operators.CompareString(OldSizeMethod, "5 - 1280 x 320", false) == 0)
					{
						num = 1280;
						num2 = 320;
					}
				}
				else if (num3 != 2278949272U)
				{
					if (num3 != 2358628211U)
					{
						if (num3 == 2993519175U)
						{
							if (Operators.CompareString(OldSizeMethod, "4 - 960 x 240", false) == 0)
							{
								num = 960;
								num2 = 240;
							}
						}
					}
					else if (Operators.CompareString(OldSizeMethod, "3 - 800 x 200", false) == 0)
					{
						num = 800;
						num2 = 200;
					}
				}
				else if (Operators.CompareString(OldSizeMethod, "1 - 640 x 160", false) == 0)
				{
					num = 640;
					num2 = 160;
				}
			}
			else if (num3 <= 3262359726U)
			{
				if (num3 != 3181229790U)
				{
					if (num3 == 3262359726U)
					{
						if (Operators.CompareString(OldSizeMethod, "7 - 640 x 128", false) == 0)
						{
							num = 640;
							num2 = 128;
						}
					}
				}
				else if (Operators.CompareString(OldSizeMethod, "19 - 1280 x 160", false) == 0)
				{
					num = 1280;
					num2 = 160;
				}
			}
			else if (num3 != 3305808094U)
			{
				if (num3 != 3507093361U)
				{
					if (num3 == 4054754368U)
					{
						if (Operators.CompareString(OldSizeMethod, "17 - 900 x 120", false) == 0)
						{
							num = 900;
							num2 = 120;
						}
					}
				}
				else if (Operators.CompareString(OldSizeMethod, "13 - 580 x 68", false) == 0)
				{
					num = 580;
					num2 = 68;
				}
			}
			else if (Operators.CompareString(OldSizeMethod, "15 - 720 x 92", false) == 0)
			{
				num = 720;
				num2 = 92;
			}
			this.tbXsize.Text = Conversions.ToString(num);
			this.tbYSize.Text = Conversions.ToString(num2);
			this.STATS_SizeX = num;
			this.STATS_SizeY = num2;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000D218 File Offset: 0x0000B418
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void SETTINGS_Load_Old()
		{
			string text = "";
			int num = 0;
			string text2 = Application.StartupPath + "\\MakoCelo_settings.dat";
			checked
			{
				if (File.Exists(text2))
				{
					Microsoft.VisualBasic.FileSystem.FileOpen(1, text2, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
					try
					{
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						if (Operators.CompareString(text, "VERSION MC200", false) != 0)
						{
							if (Operators.CompareString(text, "VERSION MC300", false) != 0)
							{
								if (Operators.CompareString(text, "VERSION MC400", false) != 0)
								{
									if (Operators.CompareString(text, "VERSION MC500", false) != 0)
									{
										Interaction.MsgBox("WARNING: The startup data file appears to be corrupt or incorrect.\r\rPath: " + Application.StartupPath + "\\MakoCelo_settings.dat", MsgBoxStyle.Critical, "MakoCELO");
									}
									else
									{
										num = 5;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
									}
								}
								else
								{
									num = 4;
									Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								}
							}
							else
							{
								num = 3;
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							}
						}
						else
						{
							num = 2;
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						}
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						int alpha = (int)Math.Round(Conversion.Val(text));
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						int red = (int)Math.Round(Conversion.Val(text));
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						int green = (int)Math.Round(Conversion.Val(text));
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						int blue = (int)Math.Round(Conversion.Val(text));
						Color.FromArgb(alpha, red, green, blue);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						alpha = (int)Math.Round(Conversion.Val(text));
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						red = (int)Math.Round(Conversion.Val(text));
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						green = (int)Math.Round(Conversion.Val(text));
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						blue = (int)Math.Round(Conversion.Val(text));
						Color.FromArgb(alpha, red, green, blue);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						if (File.Exists(text))
						{
							this.NAME_bmp = new Bitmap(text);
							this.PATH_BackgroundImage = text;
						}
						else if (Operators.CompareString(text, "", false) != 0)
						{
							Interaction.MsgBox("ERROR: The User Settings background image no longer exists.\r\rFile:" + text, MsgBoxStyle.OkOnly, null);
						}
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						this.PATH_Game = Strings.Trim(text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						frmMain.FONT_Rank_Name = Strings.Trim(text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						frmMain.FONT_Rank_Size = Strings.Trim(text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						frmMain.FONT_Rank_Bold = Strings.Trim(text);
						Microsoft.VisualBasic.FileSystem.Input(1, ref text);
						frmMain.FONT_Rank_Italic = Strings.Trim(text);
						Operators.CompareString(frmMain.FONT_Rank_Bold, "True", false);
						Operators.CompareString(frmMain.FONT_Rank_Italic, "True", false);
						frmMain.FONT_Rank = new Font(frmMain.FONT_Rank_Name, Conversions.ToSingle(frmMain.FONT_Rank_Size), FontStyle.Regular);
						if (Operators.CompareString(frmMain.FONT_Rank_Bold, "True", false) == 0)
						{
							frmMain.FONT_Rank = new Font(frmMain.FONT_Rank_Name, Conversions.ToSingle(frmMain.FONT_Rank_Size), FontStyle.Bold);
						}
						if (Operators.CompareString(frmMain.FONT_Rank_Italic, "True", false) == 0)
						{
							frmMain.FONT_Rank = new Font(frmMain.FONT_Rank_Name, Conversions.ToSingle(frmMain.FONT_Rank_Size), FontStyle.Italic);
						}
						if (0 < num)
						{
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							frmMain.FONT_Name_Name = Strings.Trim(text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							frmMain.FONT_Name_Size = Strings.Trim(text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							frmMain.FONT_Name_Bold = Strings.Trim(text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							frmMain.FONT_Name_Italic = Strings.Trim(text);
							Operators.CompareString(frmMain.FONT_Name_Bold, "True", false);
							Operators.CompareString(frmMain.FONT_Name_Italic, "True", false);
							frmMain.FONT_Name = new Font(frmMain.FONT_Name_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Regular);
							if (Operators.CompareString(frmMain.FONT_Name_Bold, "True", false) == 0)
							{
								frmMain.FONT_Name = new Font(frmMain.FONT_Name_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Bold);
							}
							if (Operators.CompareString(frmMain.FONT_Name_Italic, "True", false) == 0)
							{
								frmMain.FONT_Name = new Font(frmMain.FONT_Name_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Italic);
							}
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							this.SETTINGS_GetStatSize(text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							this.cboLayoutY.Text = Strings.Trim(text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							this.cboLayoutX.Text = Strings.Trim(text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							alpha = (int)Math.Round(Conversion.Val(text));
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							red = (int)Math.Round(Conversion.Val(text));
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							green = (int)Math.Round(Conversion.Val(text));
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							blue = (int)Math.Round(Conversion.Val(text));
							this.pbStats.BackColor = Color.FromArgb(alpha, red, green, blue);
							this.LSName.BackC = this.pbStats.BackColor;
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							Microsoft.VisualBasic.FileSystem.Input(1, ref text);
							this.LSName.Scaling = Strings.Trim(text);
							if (!Microsoft.VisualBasic.FileSystem.EOF(1))
							{
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.GUI_ColorMode = (int)Math.Round(Conversion.Val(Strings.Trim(text)));
							}
							else
							{
								this.GUI_ColorMode = 0;
							}
							if (2 < num)
							{
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.F1 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.F2 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.LSRank.FDir = Conversions.ToInteger(text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.B1 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.B2 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.LSRank.BDir = Conversions.ToInteger(text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.F1 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.F2 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.LSName.FDir = Conversions.ToInteger(text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.B1 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.B2 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.LSName.BDir = Conversions.ToInteger(text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSRank.ShadowColor = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.LSRank.ShadowDir = text;
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.LSRank.ShadowDepth = text;
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.LSName.ShadowColor = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.LSName.ShadowDir = text;
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.LSName.ShadowDepth = text;
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.COLOR_Back1 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								alpha = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								red = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								green = (int)Math.Round(Conversion.Val(text));
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								blue = (int)Math.Round(Conversion.Val(text));
								this.COLOR_Back2 = Color.FromArgb(alpha, red, green, blue);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								Microsoft.VisualBasic.FileSystem.Input(1, ref text);
								this.COLOR_Back_Dir = Conversions.ToInteger(text);
								if (3 < num)
								{
									Microsoft.VisualBasic.FileSystem.Input(1, ref text);
									int num2 = 1;
									do
									{
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										this.CFX3DC[num2] = Color.FromArgb(alpha, red, green, blue);
										num2++;
									}
									while (num2 <= 10);
									Microsoft.VisualBasic.FileSystem.Input(1, ref text);
									int num3 = 1;
									do
									{
										int num4 = 1;
										do
										{
											Microsoft.VisualBasic.FileSystem.Input(1, ref text);
											this.CFX3DVar[num3, num4] = Strings.Trim(text);
											num4++;
										}
										while (num4 <= 10);
										num3++;
									}
									while (num3 <= 10);
									Microsoft.VisualBasic.FileSystem.Input(1, ref text);
									int num5 = 1;
									do
									{
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										if (Operators.CompareString(text, "True", false) == 0)
										{
											this.CFX3DActive[num5] = true;
										}
										else
										{
											this.CFX3DActive[num5] = false;
										}
										num5++;
									}
									while (num5 <= 10);
									if (num == 5)
									{
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Name_OVLBmp = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.LSName.OVLScaling = Conversions.ToString(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.B1 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.B2 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.BackC = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.BDir = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.F1 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.F2 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.FDir = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.Height = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.O1 = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.O2 = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.Scaling = Conversions.ToString(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.OVLScaling = Conversions.ToString(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote01.ShadowColor = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.ShadowDepth = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.ShadowDir = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote01.Width = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note01_Bmp = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note01_BmpPath = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note01_OVLBmp = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note01_OVLBmpPath = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note01_Name = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note01_Bold = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note01_Italic = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note01_Size = text;
										int num6 = 1;
										do
										{
											Microsoft.VisualBasic.FileSystem.Input(1, ref text);
											this.NoteAnim01_Text[num6] = text;
											num6++;
										}
										while (num6 <= 10);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim01.Mode = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim01.Speed = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim01.TimeHold = (long)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim01.Align = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim01.Delim = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim01.Xoffset = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim01.Yoffset = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.B1 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.B2 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.BackC = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.BDir = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.F1 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.F2 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.FDir = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.Height = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.O1 = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.O2 = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.Scaling = Conversions.ToString(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.OVLScaling = Conversions.ToString(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote02.ShadowColor = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.ShadowDepth = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.ShadowDir = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote02.Width = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note02_Bmp = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note02_BmpPath = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note02_OVLBmp = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note02_OVLBmpPath = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note02_Name = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note02_Bold = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note02_Italic = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note02_Size = text;
										int num7 = 1;
										do
										{
											Microsoft.VisualBasic.FileSystem.Input(1, ref text);
											this.NoteAnim02_Text[num7] = text;
											num7++;
										}
										while (num7 <= 10);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim02.Mode = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim02.Speed = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim02.TimeHold = (long)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim02.Align = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim02.Delim = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim02.Xoffset = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim02.Yoffset = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.B1 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.B2 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.BackC = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.BDir = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.F1 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.F2 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.FDir = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.Height = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.O1 = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.O2 = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.Scaling = Conversions.ToString(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.OVLScaling = Conversions.ToString(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote03.ShadowColor = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.ShadowDepth = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.ShadowDir = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote03.Width = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note03_Bmp = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note03_BmpPath = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note03_OVLBmp = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note03_OVLBmpPath = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note03_Name = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note03_Bold = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note03_Italic = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note03_Size = text;
										int num8 = 1;
										do
										{
											Microsoft.VisualBasic.FileSystem.Input(1, ref text);
											this.NoteAnim03_Text[num8] = text;
											num8++;
										}
										while (num8 <= 10);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim03.Mode = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim03.Speed = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim03.TimeHold = (long)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim03.Align = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim03.Delim = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim03.Xoffset = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim03.Yoffset = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.B1 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.B2 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.BackC = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.BDir = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.F1 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.F2 = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.FDir = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.Height = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.O1 = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.O2 = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.Scaling = Conversions.ToString(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.OVLScaling = Conversions.ToString(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										alpha = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										red = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										green = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										blue = (int)Math.Round(Conversion.Val(text));
										frmMain.LSNote04.ShadowColor = Color.FromArgb(alpha, red, green, blue);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.ShadowDepth = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.ShadowDir = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.LSNote04.Width = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note04_Bmp = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note04_BmpPath = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note04_OVLBmp = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.PATH_Note04_OVLBmpPath = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note04_Name = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note04_Bold = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note04_Italic = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										frmMain.FONT_Note04_Size = text;
										int num9 = 1;
										do
										{
											Microsoft.VisualBasic.FileSystem.Input(1, ref text);
											this.NoteAnim04_Text[num9] = text;
											num9++;
										}
										while (num9 <= 10);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim04.Mode = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim04.Speed = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim04.TimeHold = (long)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim04.Align = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim04.Delim = text;
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim04.Xoffset = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NoteAnim04.Yoffset = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.NOTE_Spacing = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										int num10 = 1;
										do
										{
											Microsoft.VisualBasic.FileSystem.Input(1, ref text);
											this.SOUND_File[num10] = Strings.Trim(text);
											Microsoft.VisualBasic.FileSystem.Input(1, ref text);
											Microsoft.VisualBasic.FileSystem.Input(1, ref text);
											num10++;
										}
										while (num10 <= 30);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.scrVolume.Value = (int)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.Celo_Windowstate = Strings.Trim(text);
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.Celo_Left = (long)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.Celo_Top = (long)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.Celo_Width = (long)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										this.Celo_Height = (long)Math.Round(Conversion.Val(text));
										Microsoft.VisualBasic.FileSystem.Input(1, ref text);
										if (Operators.CompareString(text, "1", false) == 0)
										{
											this.chkPosition.Checked = true;
										}
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						Interaction.MsgBox("ERROR: " + ex.Message + "\r\rUnable to read the saved settings.\rThe last known setup could not be loaded.\r\rIf running a new version, this error may fix itself when a new setup is saved.", MsgBoxStyle.Critical, "MakoCelo - Setup Error");
					}
					this.FX_SetVarControls();
					this.SETTINGS_SetupAfterLoad();
					Microsoft.VisualBasic.FileSystem.FileClose(new int[]
					{
						1
					});
				}
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000F4CC File Offset: 0x0000D6CC
		private void SETTINGS_SetupAfterLoad()
		{
			frmMain.FONT_Note01 = new Font(frmMain.FONT_Note01_Name, Conversions.ToSingle(frmMain.FONT_Note01_Size), FontStyle.Regular);
			if (Operators.CompareString(frmMain.FONT_Note01_Bold, "True", false) == 0)
			{
				frmMain.FONT_Name = new Font(frmMain.FONT_Note01_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Bold);
			}
			if (Operators.CompareString(frmMain.FONT_Note01_Italic, "True", false) == 0)
			{
				frmMain.FONT_Name = new Font(frmMain.FONT_Note01_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Italic);
			}
			frmMain.FONT_Note02 = new Font(frmMain.FONT_Note02_Name, Conversions.ToSingle(frmMain.FONT_Note02_Size), FontStyle.Regular);
			if (Operators.CompareString(frmMain.FONT_Note02_Bold, "True", false) == 0)
			{
				frmMain.FONT_Name = new Font(frmMain.FONT_Note02_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Bold);
			}
			if (Operators.CompareString(frmMain.FONT_Note02_Italic, "True", false) == 0)
			{
				frmMain.FONT_Name = new Font(frmMain.FONT_Note02_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Italic);
			}
			frmMain.FONT_Note03 = new Font(frmMain.FONT_Note03_Name, Conversions.ToSingle(frmMain.FONT_Note03_Size), FontStyle.Regular);
			if (Operators.CompareString(frmMain.FONT_Note03_Bold, "True", false) == 0)
			{
				frmMain.FONT_Name = new Font(frmMain.FONT_Note03_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Bold);
			}
			if (Operators.CompareString(frmMain.FONT_Note03_Italic, "True", false) == 0)
			{
				frmMain.FONT_Name = new Font(frmMain.FONT_Note03_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Italic);
			}
			frmMain.FONT_Note04 = new Font(frmMain.FONT_Note04_Name, Conversions.ToSingle(frmMain.FONT_Note04_Size), FontStyle.Regular);
			if (Operators.CompareString(frmMain.FONT_Note04_Bold, "True", false) == 0)
			{
				frmMain.FONT_Name = new Font(frmMain.FONT_Note04_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Bold);
			}
			if (Operators.CompareString(frmMain.FONT_Note04_Italic, "True", false) == 0)
			{
				frmMain.FONT_Name = new Font(frmMain.FONT_Note04_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Italic);
			}
			if (File.Exists(frmMain.PATH_Name_OVLBmp))
			{
				this.NAME_OVLBmp = new Bitmap(frmMain.PATH_Name_OVLBmp);
			}
			else if (Operators.CompareString(frmMain.PATH_Name_OVLBmp, "", false) != 0)
			{
				Interaction.MsgBox("ERROR: The User Settings NAME OVERLAY image no longer exists.\r\rFile:" + frmMain.PATH_Name_OVLBmp, MsgBoxStyle.OkOnly, null);
			}
			if (0 < frmMain.LSNote01.Width)
			{
				this.pbNote1.Width = frmMain.LSNote01.Width;
			}
			if (0 < frmMain.LSNote01.Height)
			{
				this.pbNote1.Height = frmMain.LSNote01.Height;
			}
			if (File.Exists(frmMain.PATH_Note01_Bmp))
			{
				frmMain.Note01_BackBmp = new Bitmap(frmMain.PATH_Note01_Bmp);
			}
			else if (Operators.CompareString(frmMain.PATH_Note01_Bmp, "", false) != 0)
			{
				Interaction.MsgBox("ERROR: The User Settings NOTE 1 OVERLAY image no longer exists.\r\rFile:" + frmMain.PATH_Note01_Bmp, MsgBoxStyle.OkOnly, null);
			}
			if (File.Exists(frmMain.PATH_Note01_OVLBmp))
			{
				frmMain.Note01_OVLBmp = new Bitmap(frmMain.PATH_Note01_OVLBmp);
			}
			else if (Operators.CompareString(frmMain.PATH_Note01_OVLBmp, "", false) != 0)
			{
				Interaction.MsgBox("ERROR: The User Settings NOTE 1 OVERLAY image no longer exists.\r\rFile:" + frmMain.PATH_Note01_OVLBmp, MsgBoxStyle.OkOnly, null);
			}
			if (0 < frmMain.LSNote02.Width)
			{
				this.pbNote2.Width = frmMain.LSNote02.Width;
			}
			if (0 < frmMain.LSNote02.Height)
			{
				this.pbNote2.Height = frmMain.LSNote02.Height;
			}
			if (File.Exists(frmMain.PATH_Note02_Bmp))
			{
				frmMain.Note02_BackBmp = new Bitmap(frmMain.PATH_Note02_Bmp);
			}
			else if (Operators.CompareString(frmMain.PATH_Note01_Bmp, "", false) != 0)
			{
				Interaction.MsgBox("ERROR: The User Settings NOTE 2 background image no longer exists.\r\rFile:" + frmMain.PATH_Note02_Bmp, MsgBoxStyle.OkOnly, null);
			}
			if (File.Exists(frmMain.PATH_Note02_OVLBmp))
			{
				frmMain.Note02_OVLBmp = new Bitmap(frmMain.PATH_Note02_OVLBmp);
			}
			else if (Operators.CompareString(frmMain.PATH_Note01_OVLBmp, "", false) != 0)
			{
				Interaction.MsgBox("ERROR: The User Settings NOTE 2 OVERLAY image no longer exists.\r\rFile:" + frmMain.PATH_Note02_OVLBmp, MsgBoxStyle.OkOnly, null);
			}
			if (0 < frmMain.LSNote03.Width)
			{
				this.pbNote3.Width = frmMain.LSNote03.Width;
			}
			if (0 < frmMain.LSNote03.Height)
			{
				this.pbNote3.Height = frmMain.LSNote03.Height;
			}
			if (File.Exists(frmMain.PATH_Note03_Bmp))
			{
				frmMain.Note03_BackBmp = new Bitmap(frmMain.PATH_Note03_Bmp);
			}
			else if (Operators.CompareString(frmMain.PATH_Note03_Bmp, "", false) != 0)
			{
				Interaction.MsgBox("ERROR: The User Settings NOTE 3 background image no longer exists.\r\rFile:" + frmMain.PATH_Note03_Bmp, MsgBoxStyle.OkOnly, null);
			}
			if (File.Exists(frmMain.PATH_Note03_OVLBmp))
			{
				frmMain.Note03_OVLBmp = new Bitmap(frmMain.PATH_Note03_OVLBmp);
			}
			else if (Operators.CompareString(frmMain.PATH_Note03_OVLBmp, "", false) != 0)
			{
				Interaction.MsgBox("ERROR: The User Settings NOTE 3 OVERLAY image no longer exists.\r\rFile:" + frmMain.PATH_Note03_OVLBmp, MsgBoxStyle.OkOnly, null);
			}
			if (0 < frmMain.LSNote04.Width)
			{
				this.pbNote4.Width = frmMain.LSNote04.Width;
			}
			if (0 < frmMain.LSNote04.Height)
			{
				this.pbNote4.Height = frmMain.LSNote04.Height;
			}
			if (File.Exists(frmMain.PATH_Note04_Bmp))
			{
				frmMain.Note04_BackBmp = new Bitmap(frmMain.PATH_Note04_Bmp);
			}
			else if (Operators.CompareString(frmMain.PATH_Note04_Bmp, "", false) != 0)
			{
				Interaction.MsgBox("ERROR: The User Settings NOTE 4 background image no longer exists.\r\rFile:" + frmMain.PATH_Note04_Bmp, MsgBoxStyle.OkOnly, null);
			}
			if (File.Exists(frmMain.PATH_Note04_OVLBmp))
			{
				frmMain.Note04_OVLBmp = new Bitmap(frmMain.PATH_Note04_OVLBmp);
			}
			else if (Operators.CompareString(frmMain.PATH_Note04_OVLBmp, "", false) != 0)
			{
				Interaction.MsgBox("ERROR: The User Settings NOTE 4 OVERLAY image no longer exists.\r\rFile:" + frmMain.PATH_Note04_OVLBmp, MsgBoxStyle.OkOnly, null);
			}
			if (Operators.CompareString(this.PATH_BackgroundImage, "", false) != 0)
			{
				frmMain.PATH_DlgBmp = this.PATH_StripFilename(this.PATH_BackgroundImage);
			}
			else
			{
				if (Operators.CompareString(frmMain.PATH_Note01_Bmp, "", false) != 0)
				{
					frmMain.PATH_DlgBmp = this.PATH_StripFilename(frmMain.PATH_Note01_Bmp);
				}
				if (Operators.CompareString(frmMain.PATH_Note02_Bmp, "", false) != 0)
				{
					frmMain.PATH_DlgBmp = this.PATH_StripFilename(frmMain.PATH_Note02_Bmp);
				}
				if (Operators.CompareString(frmMain.PATH_Note03_Bmp, "", false) != 0)
				{
					frmMain.PATH_DlgBmp = this.PATH_StripFilename(frmMain.PATH_Note03_Bmp);
				}
				if (Operators.CompareString(frmMain.PATH_Note04_Bmp, "", false) != 0)
				{
					frmMain.PATH_DlgBmp = this.PATH_StripFilename(frmMain.PATH_Note04_Bmp);
				}
			}
			checked
			{
				if (Operators.CompareString(this.PATH_SoundFiles, "", false) == 0)
				{
					int num = 1;
					do
					{
						if (Operators.CompareString(this.SOUND_File[num], "", false) != 0)
						{
							this.PATH_SoundFiles = this.PATH_StripFilename(this.SOUND_File[num]);
						}
						num++;
					}
					while (num <= 15);
				}
				this.LS_SetShadowXY(ref this.LSRank);
				this.LS_SetShadowXY(ref this.LSName);
				this.LS_SetShadowXY(ref frmMain.LSNote01);
				this.LS_SetShadowXY(ref frmMain.LSNote02);
				this.LS_SetShadowXY(ref frmMain.LSNote03);
				this.LS_SetShadowXY(ref frmMain.LSNote04);
				this.cboNoteSpace.SelectedIndex = this.NOTE_Spacing;
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000FB78 File Offset: 0x0000DD78
		private void LS_SetShadowXY(ref clsGlobal.t_LabelSetup LS)
		{
			string shadowDir = LS.ShadowDir;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(shadowDir);
			if (num <= 2427795852U)
			{
				if (num <= 1573522228U)
				{
					if (num != 717409452U)
					{
						if (num == 1573522228U)
						{
							if (Operators.CompareString(shadowDir, "90°", false) == 0)
							{
								LS.ShadowX = 0;
								LS.ShadowY = -1;
								return;
							}
						}
					}
					else if (Operators.CompareString(shadowDir, "180°", false) == 0)
					{
						LS.ShadowX = -1;
						LS.ShadowY = 0;
						return;
					}
				}
				else if (num != 1615908792U)
				{
					if (num == 2427795852U)
					{
						if (Operators.CompareString(shadowDir, "315°", false) == 0)
						{
							LS.ShadowX = 1;
							LS.ShadowY = 1;
							return;
						}
					}
				}
				else if (Operators.CompareString(shadowDir, "135°", false) == 0)
				{
					LS.ShadowX = -1;
					LS.ShadowY = -1;
					return;
				}
			}
			else if (num <= 2620932502U)
			{
				if (num != 2453520896U)
				{
					if (num == 2620932502U)
					{
						if (Operators.CompareString(shadowDir, "45°", false) == 0)
						{
							LS.ShadowX = 1;
							LS.ShadowY = -1;
							return;
						}
					}
				}
				else if (Operators.CompareString(shadowDir, "225°", false) == 0)
				{
					LS.ShadowX = -1;
					LS.ShadowY = 1;
					return;
				}
			}
			else if (num != 4134103542U)
			{
				if (num == 4249105564U)
				{
					if (Operators.CompareString(shadowDir, "360°", false) == 0)
					{
						LS.ShadowX = 1;
						LS.ShadowY = 0;
						return;
					}
				}
			}
			else if (Operators.CompareString(shadowDir, "270°", false) == 0)
			{
				LS.ShadowX = 0;
				LS.ShadowY = 1;
				return;
			}
			LS.ShadowX = 0;
			LS.ShadowY = 0;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000FD2C File Offset: 0x0000DF2C
		private void SETTINGS_Save()
		{
			checked
			{
				if (!this.FLAG_Loading)
				{
					string startupPath = Application.StartupPath;
					FileStream fileStream;
					StreamWriter streamWriter;
					try
					{
						fileStream = new FileStream(startupPath + "\\MakoCelo_settings.dat", FileMode.OpenOrCreate);
						streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
						streamWriter.WriteLine("VERSION MC500");
						Color color = this.LSName.F1;
						streamWriter.WriteLine("RANK FORE COLOR");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						color = this.LSName.B1;
						streamWriter.WriteLine("RANK BACK COLOR");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("RANK ALPHA %");
						streamWriter.WriteLine(this.LSRank.O1);
						streamWriter.WriteLine("BACK IMAGE");
						streamWriter.WriteLine(this.PATH_BackgroundImage);
						streamWriter.WriteLine("LOG PATH");
						streamWriter.WriteLine(this.PATH_Game);
						streamWriter.WriteLine("RANK FONT");
						streamWriter.WriteLine(frmMain.FONT_Rank_Name);
						streamWriter.WriteLine(frmMain.FONT_Rank_Size);
						streamWriter.WriteLine(frmMain.FONT_Rank_Bold);
						streamWriter.WriteLine(frmMain.FONT_Rank_Italic);
						color = this.LSName.F1;
						streamWriter.WriteLine("NAME FORE COLOR");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						color = this.LSName.B1;
						streamWriter.WriteLine("NAME BACK COLOR");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("NAME ALPHA %");
						streamWriter.WriteLine(this.LSName.O1);
						streamWriter.WriteLine("NAME FONT");
						streamWriter.WriteLine(frmMain.FONT_Name_Name);
						streamWriter.WriteLine(frmMain.FONT_Name_Size);
						streamWriter.WriteLine(frmMain.FONT_Name_Bold);
						streamWriter.WriteLine(frmMain.FONT_Name_Italic);
						streamWriter.WriteLine("SCREEN SIZE");
						streamWriter.WriteLine(" ");
						streamWriter.WriteLine("PAGE LAYOUT Y");
						streamWriter.WriteLine(this.cboLayoutY.Text);
						streamWriter.WriteLine("PAGE LAYOUT X");
						streamWriter.WriteLine(this.cboLayoutX.Text);
						color = this.pbStats.BackColor;
						streamWriter.WriteLine("PANEL BACK COLOR");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("IMAGE SCALING");
						streamWriter.WriteLine(this.LSName.Scaling);
						streamWriter.WriteLine("GUI COLOR");
						streamWriter.WriteLine(this.GUI_ColorMode);
						color = this.LSRank.F1;
						streamWriter.WriteLine("RANK FORE COLOR 1");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						color = this.LSRank.F2;
						streamWriter.WriteLine("RANK FORE COLOR 2");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("RANK FORE GRADIENT DIR");
						streamWriter.WriteLine(this.LSRank.FDir);
						color = this.LSRank.B1;
						streamWriter.WriteLine("RANK BACK COLOR 1");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						color = this.LSRank.B2;
						streamWriter.WriteLine("RANK BACK COLOR 2");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("RANK BACK GRADIENT DIR");
						streamWriter.WriteLine(this.LSRank.BDir);
						color = this.LSName.F1;
						streamWriter.WriteLine("NAME FORE COLOR 1");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						color = this.LSName.F2;
						streamWriter.WriteLine("NAME FORE COLOR 2");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("NAME FORE GRADIENT DIR");
						streamWriter.WriteLine(this.LSName.FDir);
						color = this.LSName.B1;
						streamWriter.WriteLine("NAME BACK COLOR 1");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						color = this.LSName.B2;
						streamWriter.WriteLine("NAME BACK COLOR 2");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("NAME BACK GRADIENT DIR");
						streamWriter.WriteLine(this.LSName.BDir);
						color = this.LSRank.ShadowColor;
						streamWriter.WriteLine("RANK SHADOW COLOR");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("RANK SHADOW DIR");
						streamWriter.WriteLine(this.LSRank.ShadowDir);
						streamWriter.WriteLine("RANK SHADOW DEPTH");
						if (Operators.CompareString(this.LSRank.ShadowDepth, null, false) == 0)
						{
							this.LSRank.ShadowDepth = "";
						}
						streamWriter.WriteLine(this.LSRank.ShadowDepth);
						color = this.LSName.ShadowColor;
						streamWriter.WriteLine("NAME SHADOW COLOR");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("NAME SHADOW DIR");
						streamWriter.WriteLine(this.LSName.ShadowDir);
						streamWriter.WriteLine("NAME SHADOW DEPTH - Future");
						streamWriter.WriteLine(this.LSName.ShadowDepth);
						color = this.COLOR_Back1;
						streamWriter.WriteLine("BACK GRADIENT COLOR 1 - Future");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						color = this.COLOR_Back2;
						streamWriter.WriteLine("BACK GRADIENT COLOR 2 - Future");
						streamWriter.WriteLine((int)color.A);
						streamWriter.WriteLine((int)color.R);
						streamWriter.WriteLine((int)color.G);
						streamWriter.WriteLine((int)color.B);
						streamWriter.WriteLine("BACK GRADIENT DIR - Future");
						streamWriter.WriteLine(this.COLOR_Back_Dir);
						streamWriter.WriteLine("FX COLORS");
						int num = 1;
						do
						{
							color = this.CFX3DC[num];
							streamWriter.WriteLine((int)color.A);
							streamWriter.WriteLine((int)color.R);
							streamWriter.WriteLine((int)color.G);
							streamWriter.WriteLine((int)color.B);
							num++;
						}
						while (num <= 10);
						streamWriter.WriteLine("FX VARS");
						int num2 = 1;
						do
						{
							int num3 = 1;
							do
							{
								if (Operators.CompareString(this.CFX3DVar[num2, num3], null, false) == 0)
								{
									this.CFX3DVar[num2, num3] = "";
								}
								streamWriter.WriteLine(this.CFX3DVar[num2, num3]);
								num3++;
							}
							while (num3 <= 10);
							num2++;
						}
						while (num2 <= 10);
						streamWriter.WriteLine("FX ACTIVE");
						int num4 = 1;
						do
						{
							if (this.CFX3DActive[num4])
							{
								streamWriter.WriteLine("True");
							}
							else
							{
								streamWriter.WriteLine("False");
							}
							num4++;
						}
						while (num4 <= 10);
						streamWriter.WriteLine("NAME OVERLAY IMAGE");
						streamWriter.WriteLine(frmMain.PATH_Name_OVLBmp);
						streamWriter.WriteLine(this.LSName.OVLScaling);
						streamWriter.WriteLine("NOTE 01 VARS");
						streamWriter.WriteLine((int)frmMain.LSNote01.B1.A);
						streamWriter.WriteLine((int)frmMain.LSNote01.B1.R);
						streamWriter.WriteLine((int)frmMain.LSNote01.B1.G);
						streamWriter.WriteLine((int)frmMain.LSNote01.B1.B);
						streamWriter.WriteLine((int)frmMain.LSNote01.B2.A);
						streamWriter.WriteLine((int)frmMain.LSNote01.B2.R);
						streamWriter.WriteLine((int)frmMain.LSNote01.B2.G);
						streamWriter.WriteLine((int)frmMain.LSNote01.B2.B);
						streamWriter.WriteLine((int)frmMain.LSNote01.BackC.A);
						streamWriter.WriteLine((int)frmMain.LSNote01.BackC.R);
						streamWriter.WriteLine((int)frmMain.LSNote01.BackC.G);
						streamWriter.WriteLine((int)frmMain.LSNote01.BackC.B);
						streamWriter.WriteLine(frmMain.LSNote01.BDir);
						streamWriter.WriteLine((int)frmMain.LSNote01.F1.A);
						streamWriter.WriteLine((int)frmMain.LSNote01.F1.R);
						streamWriter.WriteLine((int)frmMain.LSNote01.F1.G);
						streamWriter.WriteLine((int)frmMain.LSNote01.F1.B);
						streamWriter.WriteLine((int)frmMain.LSNote01.F2.A);
						streamWriter.WriteLine((int)frmMain.LSNote01.F2.R);
						streamWriter.WriteLine((int)frmMain.LSNote01.F2.G);
						streamWriter.WriteLine((int)frmMain.LSNote01.F2.B);
						streamWriter.WriteLine(frmMain.LSNote01.FDir);
						streamWriter.WriteLine(frmMain.LSNote01.Height);
						streamWriter.WriteLine(frmMain.LSNote01.O1);
						streamWriter.WriteLine(frmMain.LSNote01.O2);
						streamWriter.WriteLine(frmMain.LSNote01.Scaling);
						streamWriter.WriteLine(frmMain.LSNote01.OVLScaling);
						streamWriter.WriteLine((int)frmMain.LSNote01.ShadowColor.A);
						streamWriter.WriteLine((int)frmMain.LSNote01.ShadowColor.R);
						streamWriter.WriteLine((int)frmMain.LSNote01.ShadowColor.G);
						streamWriter.WriteLine((int)frmMain.LSNote01.ShadowColor.B);
						streamWriter.WriteLine(frmMain.LSNote01.ShadowDepth);
						streamWriter.WriteLine(frmMain.LSNote01.ShadowDir);
						streamWriter.WriteLine(frmMain.LSNote01.Width);
						streamWriter.WriteLine(frmMain.PATH_Note01_Bmp);
						streamWriter.WriteLine(frmMain.PATH_Note01_BmpPath);
						streamWriter.WriteLine(frmMain.PATH_Note01_OVLBmp);
						streamWriter.WriteLine(frmMain.PATH_Note01_OVLBmpPath);
						streamWriter.WriteLine(frmMain.FONT_Note01_Name);
						streamWriter.WriteLine(frmMain.FONT_Note01_Bold);
						streamWriter.WriteLine(frmMain.FONT_Note01_Italic);
						streamWriter.WriteLine(frmMain.FONT_Note01_Size);
						int num5 = 1;
						do
						{
							streamWriter.WriteLine(this.NoteAnim01_Text[num5]);
							num5++;
						}
						while (num5 <= 10);
						streamWriter.WriteLine(this.NoteAnim01.Mode);
						streamWriter.WriteLine(this.NoteAnim01.Speed);
						streamWriter.WriteLine(this.NoteAnim01.TimeHold);
						streamWriter.WriteLine(this.NoteAnim01.Align);
						streamWriter.WriteLine(this.NoteAnim01.Delim);
						streamWriter.WriteLine(this.NoteAnim01.Xoffset);
						streamWriter.WriteLine(this.NoteAnim01.Yoffset);
						streamWriter.WriteLine("NOTE 02 VARS");
						streamWriter.WriteLine((int)frmMain.LSNote02.B1.A);
						streamWriter.WriteLine((int)frmMain.LSNote02.B1.R);
						streamWriter.WriteLine((int)frmMain.LSNote02.B1.G);
						streamWriter.WriteLine((int)frmMain.LSNote02.B1.B);
						streamWriter.WriteLine((int)frmMain.LSNote02.B2.A);
						streamWriter.WriteLine((int)frmMain.LSNote02.B2.R);
						streamWriter.WriteLine((int)frmMain.LSNote02.B2.G);
						streamWriter.WriteLine((int)frmMain.LSNote02.B2.B);
						streamWriter.WriteLine((int)frmMain.LSNote02.BackC.A);
						streamWriter.WriteLine((int)frmMain.LSNote02.BackC.R);
						streamWriter.WriteLine((int)frmMain.LSNote02.BackC.G);
						streamWriter.WriteLine((int)frmMain.LSNote02.BackC.B);
						streamWriter.WriteLine(frmMain.LSNote02.BDir);
						streamWriter.WriteLine((int)frmMain.LSNote02.F1.A);
						streamWriter.WriteLine((int)frmMain.LSNote02.F1.R);
						streamWriter.WriteLine((int)frmMain.LSNote02.F1.G);
						streamWriter.WriteLine((int)frmMain.LSNote02.F1.B);
						streamWriter.WriteLine((int)frmMain.LSNote02.F2.A);
						streamWriter.WriteLine((int)frmMain.LSNote02.F2.R);
						streamWriter.WriteLine((int)frmMain.LSNote02.F2.G);
						streamWriter.WriteLine((int)frmMain.LSNote02.F2.B);
						streamWriter.WriteLine(frmMain.LSNote02.FDir);
						streamWriter.WriteLine(frmMain.LSNote02.Height);
						streamWriter.WriteLine(frmMain.LSNote02.O1);
						streamWriter.WriteLine(frmMain.LSNote02.O2);
						streamWriter.WriteLine(frmMain.LSNote02.Scaling);
						streamWriter.WriteLine(frmMain.LSNote02.OVLScaling);
						streamWriter.WriteLine((int)frmMain.LSNote02.ShadowColor.A);
						streamWriter.WriteLine((int)frmMain.LSNote02.ShadowColor.R);
						streamWriter.WriteLine((int)frmMain.LSNote02.ShadowColor.G);
						streamWriter.WriteLine((int)frmMain.LSNote02.ShadowColor.B);
						streamWriter.WriteLine(frmMain.LSNote02.ShadowDepth);
						streamWriter.WriteLine(frmMain.LSNote02.ShadowDir);
						streamWriter.WriteLine(frmMain.LSNote02.Width);
						streamWriter.WriteLine(frmMain.PATH_Note02_Bmp);
						streamWriter.WriteLine(frmMain.PATH_Note02_BmpPath);
						streamWriter.WriteLine(frmMain.PATH_Note02_OVLBmp);
						streamWriter.WriteLine(frmMain.PATH_Note02_OVLBmpPath);
						streamWriter.WriteLine(frmMain.FONT_Note02_Name);
						streamWriter.WriteLine(frmMain.FONT_Note02_Bold);
						streamWriter.WriteLine(frmMain.FONT_Note02_Italic);
						streamWriter.WriteLine(frmMain.FONT_Note02_Size);
						int num6 = 1;
						do
						{
							streamWriter.WriteLine(this.NoteAnim02_Text[num6]);
							num6++;
						}
						while (num6 <= 10);
						streamWriter.WriteLine(this.NoteAnim02.Mode);
						streamWriter.WriteLine(this.NoteAnim02.Speed);
						streamWriter.WriteLine(this.NoteAnim02.TimeHold);
						streamWriter.WriteLine(this.NoteAnim02.Align);
						streamWriter.WriteLine(this.NoteAnim02.Delim);
						streamWriter.WriteLine(this.NoteAnim02.Xoffset);
						streamWriter.WriteLine(this.NoteAnim02.Yoffset);
						streamWriter.WriteLine("NOTE 03 VARS");
						streamWriter.WriteLine((int)frmMain.LSNote03.B1.A);
						streamWriter.WriteLine((int)frmMain.LSNote03.B1.R);
						streamWriter.WriteLine((int)frmMain.LSNote03.B1.G);
						streamWriter.WriteLine((int)frmMain.LSNote03.B1.B);
						streamWriter.WriteLine((int)frmMain.LSNote03.B2.A);
						streamWriter.WriteLine((int)frmMain.LSNote03.B2.R);
						streamWriter.WriteLine((int)frmMain.LSNote03.B2.G);
						streamWriter.WriteLine((int)frmMain.LSNote03.B2.B);
						streamWriter.WriteLine((int)frmMain.LSNote03.BackC.A);
						streamWriter.WriteLine((int)frmMain.LSNote03.BackC.R);
						streamWriter.WriteLine((int)frmMain.LSNote03.BackC.G);
						streamWriter.WriteLine((int)frmMain.LSNote03.BackC.B);
						streamWriter.WriteLine(frmMain.LSNote03.BDir);
						streamWriter.WriteLine((int)frmMain.LSNote03.F1.A);
						streamWriter.WriteLine((int)frmMain.LSNote03.F1.R);
						streamWriter.WriteLine((int)frmMain.LSNote03.F1.G);
						streamWriter.WriteLine((int)frmMain.LSNote03.F1.B);
						streamWriter.WriteLine((int)frmMain.LSNote03.F2.A);
						streamWriter.WriteLine((int)frmMain.LSNote03.F2.R);
						streamWriter.WriteLine((int)frmMain.LSNote03.F2.G);
						streamWriter.WriteLine((int)frmMain.LSNote03.F2.B);
						streamWriter.WriteLine(frmMain.LSNote03.FDir);
						streamWriter.WriteLine(frmMain.LSNote03.Height);
						streamWriter.WriteLine(frmMain.LSNote03.O1);
						streamWriter.WriteLine(frmMain.LSNote03.O2);
						streamWriter.WriteLine(frmMain.LSNote03.Scaling);
						streamWriter.WriteLine(frmMain.LSNote03.OVLScaling);
						streamWriter.WriteLine((int)frmMain.LSNote03.ShadowColor.A);
						streamWriter.WriteLine((int)frmMain.LSNote03.ShadowColor.R);
						streamWriter.WriteLine((int)frmMain.LSNote03.ShadowColor.G);
						streamWriter.WriteLine((int)frmMain.LSNote03.ShadowColor.B);
						streamWriter.WriteLine(frmMain.LSNote03.ShadowDepth);
						streamWriter.WriteLine(frmMain.LSNote03.ShadowDir);
						streamWriter.WriteLine(frmMain.LSNote03.Width);
						streamWriter.WriteLine(frmMain.PATH_Note03_Bmp);
						streamWriter.WriteLine(frmMain.PATH_Note03_BmpPath);
						streamWriter.WriteLine(frmMain.PATH_Note03_OVLBmp);
						streamWriter.WriteLine(frmMain.PATH_Note03_OVLBmpPath);
						streamWriter.WriteLine(frmMain.FONT_Note03_Name);
						streamWriter.WriteLine(frmMain.FONT_Note03_Bold);
						streamWriter.WriteLine(frmMain.FONT_Note03_Italic);
						streamWriter.WriteLine(frmMain.FONT_Note03_Size);
						int num7 = 1;
						do
						{
							streamWriter.WriteLine(this.NoteAnim03_Text[num7]);
							num7++;
						}
						while (num7 <= 10);
						streamWriter.WriteLine(this.NoteAnim03.Mode);
						streamWriter.WriteLine(this.NoteAnim03.Speed);
						streamWriter.WriteLine(this.NoteAnim03.TimeHold);
						streamWriter.WriteLine(this.NoteAnim03.Align);
						streamWriter.WriteLine(this.NoteAnim03.Delim);
						streamWriter.WriteLine(this.NoteAnim03.Xoffset);
						streamWriter.WriteLine(this.NoteAnim03.Yoffset);
						streamWriter.WriteLine("NOTE 04 VARS");
						streamWriter.WriteLine((int)frmMain.LSNote04.B1.A);
						streamWriter.WriteLine((int)frmMain.LSNote04.B1.R);
						streamWriter.WriteLine((int)frmMain.LSNote04.B1.G);
						streamWriter.WriteLine((int)frmMain.LSNote04.B1.B);
						streamWriter.WriteLine((int)frmMain.LSNote04.B2.A);
						streamWriter.WriteLine((int)frmMain.LSNote04.B2.R);
						streamWriter.WriteLine((int)frmMain.LSNote04.B2.G);
						streamWriter.WriteLine((int)frmMain.LSNote04.B2.B);
						streamWriter.WriteLine((int)frmMain.LSNote04.BackC.A);
						streamWriter.WriteLine((int)frmMain.LSNote04.BackC.R);
						streamWriter.WriteLine((int)frmMain.LSNote04.BackC.G);
						streamWriter.WriteLine((int)frmMain.LSNote04.BackC.B);
						streamWriter.WriteLine(frmMain.LSNote04.BDir);
						streamWriter.WriteLine((int)frmMain.LSNote04.F1.A);
						streamWriter.WriteLine((int)frmMain.LSNote04.F1.R);
						streamWriter.WriteLine((int)frmMain.LSNote04.F1.G);
						streamWriter.WriteLine((int)frmMain.LSNote04.F1.B);
						streamWriter.WriteLine((int)frmMain.LSNote04.F2.A);
						streamWriter.WriteLine((int)frmMain.LSNote04.F2.R);
						streamWriter.WriteLine((int)frmMain.LSNote04.F2.G);
						streamWriter.WriteLine((int)frmMain.LSNote04.F2.B);
						streamWriter.WriteLine(frmMain.LSNote04.FDir);
						streamWriter.WriteLine(frmMain.LSNote04.Height);
						streamWriter.WriteLine(frmMain.LSNote04.O1);
						streamWriter.WriteLine(frmMain.LSNote04.O2);
						streamWriter.WriteLine(frmMain.LSNote04.Scaling);
						streamWriter.WriteLine(frmMain.LSNote04.OVLScaling);
						streamWriter.WriteLine((int)frmMain.LSNote04.ShadowColor.A);
						streamWriter.WriteLine((int)frmMain.LSNote04.ShadowColor.R);
						streamWriter.WriteLine((int)frmMain.LSNote04.ShadowColor.G);
						streamWriter.WriteLine((int)frmMain.LSNote04.ShadowColor.B);
						streamWriter.WriteLine(frmMain.LSNote04.ShadowDepth);
						streamWriter.WriteLine(frmMain.LSNote04.ShadowDir);
						streamWriter.WriteLine(frmMain.LSNote04.Width);
						streamWriter.WriteLine(frmMain.PATH_Note04_Bmp);
						streamWriter.WriteLine(frmMain.PATH_Note04_BmpPath);
						streamWriter.WriteLine(frmMain.PATH_Note04_OVLBmp);
						streamWriter.WriteLine(frmMain.PATH_Note04_OVLBmpPath);
						streamWriter.WriteLine(frmMain.FONT_Note04_Name);
						streamWriter.WriteLine(frmMain.FONT_Note04_Bold);
						streamWriter.WriteLine(frmMain.FONT_Note04_Italic);
						streamWriter.WriteLine(frmMain.FONT_Note04_Size);
						int num8 = 1;
						do
						{
							streamWriter.WriteLine(this.NoteAnim04_Text[num8]);
							num8++;
						}
						while (num8 <= 10);
						streamWriter.WriteLine(this.NoteAnim04.Mode);
						streamWriter.WriteLine(this.NoteAnim04.Speed);
						streamWriter.WriteLine(this.NoteAnim04.TimeHold);
						streamWriter.WriteLine(this.NoteAnim04.Align);
						streamWriter.WriteLine(this.NoteAnim04.Delim);
						streamWriter.WriteLine(this.NoteAnim04.Xoffset);
						streamWriter.WriteLine(this.NoteAnim04.Yoffset);
						streamWriter.WriteLine("NOTE SPACING");
						streamWriter.WriteLine(this.NOTE_Spacing);
						streamWriter.WriteLine("SOUND SAMPLES");
						int num9 = 1;
						do
						{
							streamWriter.WriteLine(this.SOUND_File[num9]);
							streamWriter.WriteLine(" ");
							streamWriter.WriteLine(this.SOUND_Vol[num9]);
							num9++;
						}
						while (num9 <= 30);
						streamWriter.WriteLine(this.scrVolume.Value);
						streamWriter.WriteLine("WINDOW STATE");
						string value = "Normal";
						if (base.WindowState == FormWindowState.Minimized)
						{
							value = "Minimized";
						}
						if (base.WindowState == FormWindowState.Maximized)
						{
							value = "Maximized";
						}
						streamWriter.WriteLine(value);
						streamWriter.WriteLine(base.Location.X);
						streamWriter.WriteLine(base.Location.Y);
						streamWriter.WriteLine(base.Size.Width);
						streamWriter.WriteLine(base.Size.Height);
						if (this.chkPosition.Checked)
						{
							streamWriter.WriteLine("1");
						}
						else
						{
							streamWriter.WriteLine("0");
						}
						if (this.chkPopUp.Checked)
						{
							streamWriter.WriteLine("1");
						}
						else
						{
							streamWriter.WriteLine("0");
						}
						streamWriter.WriteLine("PAGE XY OFFSET");
						streamWriter.WriteLine(this.tbXoff.Text);
						streamWriter.WriteLine(this.tbYoff.Text);
						streamWriter.WriteLine("PAGE XY SIZE");
						streamWriter.WriteLine(this.STATS_SizeX);
						streamWriter.WriteLine(this.STATS_SizeY);
						int num10 = 1;
						do
						{
							streamWriter.WriteLine(" ");
							num10++;
						}
						while (num10 <= 100);
					}
					catch (Exception ex)
					{
						Interaction.MsgBox("ERROR: " + ex.Message + "\r\rUnable to save the last known setup.", MsgBoxStyle.Critical, "MakoCelo - Setup Error");
					}
					if (!Information.IsNothing(streamWriter))
					{
						streamWriter.Close();
						streamWriter.Dispose();
					}
					if (!Information.IsNothing(fileStream))
					{
						fileStream.Close();
						fileStream.Dispose();
					}
				}
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000117D8 File Offset: 0x0000F9D8
		public object STRING_FindLastSlash(string A)
		{
			int num = 0;
			checked
			{
				for (int i = Strings.Len(A); i >= 1; i += -1)
				{
					if (Operators.CompareString(Strings.Mid(A, i, 1), "\\", false) == 0)
					{
						num = i;
						break;
					}
				}
				return num;
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0001181C File Offset: 0x0000FA1C
		public string PATH_StripFilename(string tPath)
		{
			int num = Conversions.ToInteger(this.STRING_FindLastSlash(tPath));
			string result;
			if (3 < num)
			{
				result = Strings.Mid(tPath, 1, num);
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00011850 File Offset: 0x0000FA50
		public string PATH_GetAnyPath()
		{
			string result = "";
			if (Operators.CompareString(this.PATH_BackgroundImage, "", false) != 0)
			{
				result = this.PATH_StripFilename(this.PATH_BackgroundImage);
			}
			else
			{
				if (Operators.CompareString(frmMain.PATH_Note01_Bmp, "", false) != 0)
				{
					result = this.PATH_StripFilename(frmMain.PATH_Note01_Bmp);
				}
				if (Operators.CompareString(frmMain.PATH_Note02_Bmp, "", false) != 0)
				{
					result = this.PATH_StripFilename(frmMain.PATH_Note02_Bmp);
				}
				if (Operators.CompareString(frmMain.PATH_Note03_Bmp, "", false) != 0)
				{
					result = this.PATH_StripFilename(frmMain.PATH_Note03_Bmp);
				}
				if (Operators.CompareString(frmMain.PATH_Note04_Bmp, "", false) != 0)
				{
					result = this.PATH_StripFilename(frmMain.PATH_Note04_Bmp);
				}
			}
			return result;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00011900 File Offset: 0x0000FB00
		private void frmMain_Load(object sender, EventArgs e)
		{
			this.FLAG_Loading = true;
			this.GUI_Active = false;
			this.PATH_Game = "";
			this.PATH_BackgroundImage = "";
			int num = 1;
			checked
			{
				do
				{
					this.PlrName[num] = "Player " + Conversions.ToString(num);
					this.PlrRank[num] = "---";
					this.PlrFact[num] = "01";
					this.LAB_Name_Align[num] = new StringFormat();
					num++;
				}
				while (num <= 8);
				int num2 = 1;
				do
				{
					this.NoteAnim01_Text[num2] = "";
					this.NoteAnim02_Text[num2] = "";
					this.NoteAnim03_Text[num2] = "";
					this.NoteAnim04_Text[num2] = "";
					this.Note01_Text[num2] = "";
					this.Note02_Text[num2] = "";
					this.Note03_Text[num2] = "";
					this.Note04_Text[num2] = "";
					num2++;
				}
				while (num2 <= 10);
				this.INIT_FillComboBoxes();
				this.ToolTip1.Active = false;
				this.ToolTip_Setup();
				frmMain.FONT_Rank_Name = "Arial";
				frmMain.FONT_Rank_Size = "14";
				frmMain.FONT_Rank_Bold = "True";
				frmMain.FONT_Rank_Italic = "False";
				frmMain.FONT_Rank = new Font(frmMain.FONT_Rank_Name, Conversions.ToSingle(frmMain.FONT_Rank_Size), FontStyle.Bold);
				frmMain.FONT_Name_Name = "Arial";
				frmMain.FONT_Name_Size = "16";
				frmMain.FONT_Name_Bold = "True";
				frmMain.FONT_Name_Italic = "False";
				frmMain.FONT_Name = new Font(frmMain.FONT_Name_Name, Conversions.ToSingle(frmMain.FONT_Name_Size), FontStyle.Bold);
				frmMain.FONT_Note01 = frmMain.FONT_Rank;
				frmMain.FONT_Note01_Name = "Arial";
				frmMain.FONT_Note01_Size = "14";
				frmMain.FONT_Note01_Bold = "True";
				frmMain.FONT_Note01_Italic = "False";
				frmMain.FONT_Note02 = frmMain.FONT_Rank;
				frmMain.FONT_Note02_Name = "Arial";
				frmMain.FONT_Note02_Size = "14";
				frmMain.FONT_Note02_Bold = "True";
				frmMain.FONT_Note02_Italic = "False";
				frmMain.FONT_Note03 = frmMain.FONT_Rank;
				frmMain.FONT_Note03_Name = "Arial";
				frmMain.FONT_Note03_Size = "14";
				frmMain.FONT_Note03_Bold = "True";
				frmMain.FONT_Note03_Italic = "False";
				frmMain.FONT_Note04 = frmMain.FONT_Rank;
				frmMain.FONT_Note04_Name = "Arial";
				frmMain.FONT_Note04_Size = "14";
				frmMain.FONT_Note04_Bold = "True";
				frmMain.FONT_Note04_Italic = "False";
				this.NoteAnim01.Delim = "   ●   ";
				this.NoteAnim02.Delim = "   ●   ";
				this.NoteAnim03.Delim = "   ●   ";
				this.NoteAnim04.Delim = "   ●   ";
				this.LSRank.F1 = Color.FromArgb(255, 255, 255, 64);
				this.LSRank.F2 = Color.FromArgb(255, 192, 192, 48);
				this.LSRank.FDir = 0;
				this.LSRank.B1 = Color.FromArgb(255, 128, 0, 0);
				this.LSRank.B2 = Color.FromArgb(255, 0, 0, 0);
				this.LSRank.BDir = 0;
				this.LSRank.ShadowColor = Color.FromArgb(255, 0, 0, 0);
				this.LSRank.O1 = 100;
				this.LSRank.O2 = 10;
				this.LSName.F1 = Color.FromArgb(255, 255, 255, 255);
				this.LSName.F2 = Color.FromArgb(255, 192, 192, 192);
				this.LSName.FDir = 0;
				this.LSName.B1 = Color.FromArgb(255, 64, 64, 64);
				this.LSName.B2 = Color.FromArgb(25, 0, 0, 0);
				this.LSName.BDir = 1;
				frmMain.LSNote01 = this.LSRank;
				frmMain.LSNote02 = this.LSRank;
				frmMain.LSNote03 = this.LSRank;
				frmMain.LSNote04 = this.LSRank;
				frmMain.LSNote01.Width = this.pbNote1.Width;
				frmMain.LSNote01.Height = this.pbNote1.Height;
				frmMain.LSNote02.Width = this.pbNote2.Width;
				frmMain.LSNote02.Height = this.pbNote2.Height;
				frmMain.LSNote03.Width = this.pbNote3.Width;
				frmMain.LSNote03.Height = this.pbNote3.Height;
				frmMain.LSNote04.Width = this.pbNote4.Width;
				frmMain.LSNote04.Height = this.pbNote4.Height;
				int num3 = 0;
				do
				{
					this.SOUND_File[num3] = "";
					this.SOUND_Vol[num3] = Conversions.ToString(100);
					num3++;
				}
				while (num3 <= 19);
				bool flag = false;
				if (this.SETTINGS_Load_CheckVersion(ref flag))
				{
					if (flag)
					{
						this.SETTINGS_Load_Old();
					}
					else
					{
						this.SETTINGS_Load();
					}
				}
				this.Note01_Bmp = new Bitmap(this.pbNote1.Width, this.pbNote1.Height);
				this.Note02_Bmp = new Bitmap(this.pbNote2.Width, this.pbNote2.Height);
				this.Note03_Bmp = new Bitmap(this.pbNote3.Width, this.pbNote3.Height);
				this.Note04_Bmp = new Bitmap(this.pbNote4.Width, this.pbNote4.Height);
				this.Note01_Gfx = Graphics.FromImage(this.Note01_Bmp);
				this.Note02_Gfx = Graphics.FromImage(this.Note02_Bmp);
				this.Note03_Gfx = Graphics.FromImage(this.Note03_Bmp);
				this.Note04_Gfx = Graphics.FromImage(this.Note04_Bmp);
				frmMain.LSNote01.Width = this.pbNote1.Width;
				frmMain.LSNote01.Height = this.pbNote1.Height;
				frmMain.LSNote02.Width = this.pbNote2.Width;
				frmMain.LSNote02.Height = this.pbNote2.Height;
				frmMain.LSNote03.Width = this.pbNote3.Width;
				frmMain.LSNote03.Height = this.pbNote3.Height;
				frmMain.LSNote04.Width = this.pbNote4.Width;
				frmMain.LSNote04.Height = this.pbNote4.Height;
				int gui_ColorMode = this.GUI_ColorMode;
				if (gui_ColorMode != 0)
				{
					if (gui_ColorMode == 1)
					{
						this.GUI_SetDark();
					}
				}
				else
				{
					this.GUI_SetLite();
				}
				this.LSRank.O1 = (int)Math.Round((double)this.LSRank.B1.A / 2.55);
				this.LSRank.O2 = (int)Math.Round((double)this.LSRank.B2.A / 2.55);
				this.LSName.O1 = (int)Math.Round((double)this.LSName.B1.A / 2.55);
				this.LSName.O2 = (int)Math.Round((double)this.LSName.B2.A / 2.55);
				if (Operators.CompareString(this.cboLayoutY.Text, "", false) == 0)
				{
					this.cboLayoutY.Text = "3 - 90% tight";
				}
				if (Operators.CompareString(this.cboLayoutX.Text, "", false) == 0)
				{
					this.cboLayoutX.Text = "3 - 90% tight";
				}
				if (Operators.CompareString(this.LSName.Scaling, "", false) == 0)
				{
					this.LSName.Scaling = "2 - Fit";
				}
				if (Operators.CompareString(this.LSRank.ShadowDir, "", false) == 0)
				{
					this.LSRank.ShadowDir = "270°";
				}
				if (Operators.CompareString(this.cboFXVar2.Text, "", false) == 0)
				{
					this.cboFXVar2.Text = "270°";
				}
				if (Operators.CompareString(this.cboFxVar3.Text, "", false) == 0)
				{
					this.cboFxVar3.Text = "80%";
				}
				if (Operators.CompareString(this.cboFxVar4.Text, "", false) == 0)
				{
					this.cboFxVar4.Text = "2.0%";
				}
				if (Operators.CompareString(this.cboFXVar1.Text, "", false) == 0)
				{
					this.cboFXVar1.Text = "None";
				}
				int num4 = Strings.InStr(this.PATH_Game, "warnings", CompareMethod.Binary);
				if (3 < num4)
				{
					this.PATH_GamePath = Strings.Mid(this.PATH_Game, 1, num4 - 1);
				}
				else
				{
					this.PATH_GamePath = "";
				}
				num4 = Conversions.ToInteger(this.STRING_FindLastSlash(this.PATH_BackgroundImage));
				if (3 < num4)
				{
					this.PATH_BackgroundImagePath = Strings.Mid(this.PATH_BackgroundImage, 1, num4);
				}
				else
				{
					this.PATH_BackgroundImagePath = "";
				}
				this.FLAG_Loading = false;
				this.STATS_DefineY();
				if (Operators.CompareString(this.Celo_Windowstate, "Normal", false) == 0 & this.chkPosition.Checked)
				{
					base.Location = new Point((int)this.Celo_Left, (int)this.Celo_Top);
					base.Width = (int)this.Celo_Width;
					base.Height = (int)this.Celo_Height;
				}
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00012250 File Offset: 0x00010450
		private void INIT_FillComboBoxes()
		{
			this.CFX3DVar[1, 2] = "270°";
			this.CFX3DVar[1, 3] = "70%";
			this.CFX3DVar[1, 4] = "5.0%";
			this.CFX3DVar[2, 2] = "270°";
			this.CFX3DVar[2, 3] = "50%";
			this.CFX3DVar[2, 4] = "5.0%";
			this.CFX3DVar[3, 2] = "270°";
			this.CFX3DVar[3, 3] = "50%";
			this.CFX3DVar[3, 4] = "2.0%";
			this.cboLayoutY.Items.Add("0 - 60% tight");
			this.cboLayoutY.Items.Add("1 - 70% tight");
			this.cboLayoutY.Items.Add("2 - 80% tight");
			this.cboLayoutY.Items.Add("3 - 90% tight");
			this.cboLayoutY.Items.Add("4 - 100% tight");
			this.cboLayoutY.Items.Add("5 - 60% spread");
			this.cboLayoutY.Items.Add("6 - 70% spread");
			this.cboLayoutY.Items.Add("7 - 80% spread");
			this.cboLayoutY.Items.Add("8 - 90% spread");
			this.cboLayoutY.Items.Add("9 - 100% spread");
			this.cboLayoutX.Items.Add("0 - 60% tight");
			this.cboLayoutX.Items.Add("1 - 70% tight");
			this.cboLayoutX.Items.Add("2 - 80% tight");
			this.cboLayoutX.Items.Add("3 - 90% tight");
			this.cboLayoutX.Items.Add("4 - 100% tight");
			this.cboLayoutX.Items.Add("5 - 60% spread");
			this.cboLayoutX.Items.Add("6 - 70% spread");
			this.cboLayoutX.Items.Add("7 - 80% spread");
			this.cboLayoutX.Items.Add("8 - 90% spread");
			this.cboLayoutX.Items.Add("9 - 100% spread");
			this.cboLayoutX.Items.Add("10 - 60% mid tight");
			this.cboLayoutX.Items.Add("11 - 70% mid tight");
			this.cboLayoutX.Items.Add("12 - 80% mid tight");
			this.cboLayoutX.Items.Add("13 - 90% mid tight");
			this.cboLayoutX.Items.Add("14 - 100% mid tight");
			this.cboLayoutX.Items.Add("15 - 60% mid spread");
			this.cboLayoutX.Items.Add("16 - 70% mid spread");
			this.cboLayoutX.Items.Add("17 - 80% mid spread");
			this.cboLayoutX.Items.Add("18 - 90% mid spread");
			this.cboLayoutX.Items.Add("19 - 100% mid spread");
			this.cboLayoutX.Items.Add("20 - clock tight");
			this.cboLayoutX.Items.Add("21 - clock spread");
			this.cboNoteSpace.Items.Add("0 px");
			this.cboNoteSpace.Items.Add("1 px");
			this.cboNoteSpace.Items.Add("2 px");
			this.cboNoteSpace.Items.Add("3 px");
			this.cboNoteSpace.Items.Add("4 px");
			this.cboNoteSpace.Items.Add("5 px");
			this.cboFXVar1.Items.Add("None");
			this.cboFXVar1.Items.Add("Shadow");
			this.cboFXVar1.Items.Add("Emboss");
			this.cboFXVar1.Items.Add("Lab Blur");
			this.cboFXVar2.Items.Add("--");
			this.cboFXVar2.Items.Add("45°");
			this.cboFXVar2.Items.Add("90°");
			this.cboFXVar2.Items.Add("135°");
			this.cboFXVar2.Items.Add("180°");
			this.cboFXVar2.Items.Add("225°");
			this.cboFXVar2.Items.Add("270°");
			this.cboFXVar2.Items.Add("315°");
			this.cboFXVar2.Items.Add("360°");
			this.cboFxVar4.Items.Add("0.0%");
			this.cboFxVar4.Items.Add("1.0%");
			this.cboFxVar4.Items.Add("2.0%");
			this.cboFxVar4.Items.Add("3.0%");
			this.cboFxVar4.Items.Add("4.0%");
			this.cboFxVar4.Items.Add("5.0%");
			this.cboFxVar4.Items.Add("6.0%");
			this.cboFxVar4.Items.Add("7.0%");
			this.cboFxVar4.Items.Add("8.0%");
			this.cboFxVar4.Items.Add("9.0%");
			this.cboFxVar4.Items.Add("10.0%");
			this.cboFxVar3.Items.Add("40%");
			this.cboFxVar3.Items.Add("45%");
			this.cboFxVar3.Items.Add("50%");
			this.cboFxVar3.Items.Add("55%");
			this.cboFxVar3.Items.Add("60%");
			this.cboFxVar3.Items.Add("65%");
			this.cboFxVar3.Items.Add("70%");
			this.cboFxVar3.Items.Add("75%");
			this.cboFxVar3.Items.Add("80%");
			this.cboFxVar3.Items.Add("85%");
			this.cboFxVar3.Items.Add("90%");
			this.cboFxVar3.Items.Add("95%");
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0001295C File Offset: 0x00010B5C
		private string ALPHA_CalcPercent(int tAlpha)
		{
			return Conversions.ToString(checked((int)Math.Round((double)tAlpha / 2.55))) + "%";
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0001298C File Offset: 0x00010B8C
		private void cmFindLog_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "FIND: Warnings.Log in My Games\\Company of Heroes 2";
			if (Operators.CompareString(this.PATH_GamePath, "", false) != 0)
			{
				openFileDialog.InitialDirectory = this.PATH_GamePath;
			}
			else
			{
				string text = SpecialDirectories.MyDocuments + "\\My Games\\Company of Heroes 2\\";
				if (Directory.Exists(text))
				{
					openFileDialog.InitialDirectory = text;
				}
				else
				{
					openFileDialog.InitialDirectory = SpecialDirectories.MyDocuments;
				}
			}
			openFileDialog.Filter = "Log Files (*.log)|*.log";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.PATH_Game = openFileDialog.FileName;
				this.SETTINGS_Save();
				int num = Conversions.ToInteger(this.STRING_FindLastSlash(this.PATH_Game));
				if (3 < num)
				{
					this.PATH_GamePath = Strings.Mid(this.PATH_Game, 1, num);
					return;
				}
				this.PATH_GamePath = "";
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00012A5C File Offset: 0x00010C5C
		private void cmScanLog_Click(object sender, EventArgs e)
		{
			if (!File.Exists(this.PATH_Game))
			{
				Interaction.MsgBox("Please locate the warnings.log file in your COH2 My Games directory.\r\rClick on FIND LOG FILE to search and select.", MsgBoxStyle.Information, null);
				return;
			}
			this.SCAN_Enabled = !this.SCAN_Enabled;
			if (this.SCAN_Enabled)
			{
				this.cmScanLog.Text = "Scanning...";
				this.lbStatus.BackColor = Color.FromArgb(255, 192, 255, 192);
				this.CONTROLS_Enabled(false);
				this.Timer1.Enabled = true;
				return;
			}
			this.Timer1.Enabled = false;
			this.lbStatus.BackColor = Color.FromArgb(255, 192, 192, 192);
			this.lbStatus.Text = "Ready";
			this.cmScanLog.Text = "Scan log every 10s";
			this.CONTROLS_Enabled(true);
			this.GFX_UpdateScreenControls();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00012B44 File Offset: 0x00010D44
		private void CONTROLS_Enabled(bool tState)
		{
			this.cmCheckLog.Enabled = tState;
			this.cmFindLog.Enabled = tState;
			this.cmTestData.Enabled = tState;
			this.cmRankSetup.Enabled = tState;
			this.cmNameSetup.Enabled = tState;
			this.cmAbout.Enabled = tState;
			this.tbXsize.Enabled = tState;
			this.tbYSize.Enabled = tState;
			this.tbXoff.Enabled = tState;
			this.tbYoff.Enabled = tState;
			this.cboLayoutY.Enabled = tState;
			this.cboLayoutX.Enabled = tState;
			this.cboNoteSpace.Enabled = tState;
			this.cmDefaults.Enabled = tState;
			this.cmStatsModeHelp.Enabled = tState;
			this.cmSizeRefresh.Enabled = tState;
			this.cmGUILite.Enabled = tState;
			this.cmGUIDark.Enabled = tState;
			this.cboFXVar1.Enabled = tState;
			this.chkFX.Enabled = tState;
			this.cmFX3DC.Enabled = tState;
			this.cboFXVar2.Enabled = tState;
			this.cboFxVar3.Enabled = tState;
			this.cboFxVar4.Enabled = tState;
			this.cmFXModeHelp.Enabled = tState;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00012C80 File Offset: 0x00010E80
		private void Timer1_Tick(object sender, EventArgs e)
		{
			if (this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog$Init == null)
			{
				Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog$Init, new StaticLocalInitFlag(), null);
			}
			Monitor.Enter(this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog$Init);
			try
			{
				if (this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog$Init.State == 0)
				{
					this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog$Init.State = 2;
					this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog = false;
				}
				else if (this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog$Init.State == 2)
				{
					throw new IncompleteInitialization();
				}
			}
			finally
			{
				this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog$Init.State = 1;
				Monitor.Exit(this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog$Init);
			}
			checked
			{
				if (!this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog)
				{
					this.$STATIC$Timer1_Tick$20211C12809D$SecCnt += 1L;
					if (10L < this.$STATIC$Timer1_Tick$20211C12809D$SecCnt)
					{
						this.$STATIC$Timer1_Tick$20211C12809D$SecCnt = 0L;
						this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog = true;
						this.LOG_Scan();
						this.$STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog = false;
						return;
					}
					this.lbStatus.Text = "Scan in " + Conversions.ToString(11L - this.$STATIC$Timer1_Tick$20211C12809D$SecCnt) + "s";
				}
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00012D7C File Offset: 0x00010F7C
		private void cmCopy_Click(object sender, EventArgs e)
		{
			Bitmap bitmap = new Bitmap(this.pbStats.Image, this.pbStats.Width, this.pbStats.Height);
			Clipboard.Clear();
			Clipboard.SetImage(bitmap);
			bitmap.Dispose();
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00012DB4 File Offset: 0x00010FB4
		private void cmAbout_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmAbout.ShowDialog();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00012DC8 File Offset: 0x00010FC8
		private void STATS_DefineY()
		{
			double num = Conversion.Val(this.cboLayoutY.Text);
			float num2;
			float num3;
			if (num == 0.0)
			{
				num2 = 0.2f;
				num3 = 0.15f;
			}
			else if (num == 1.0)
			{
				num2 = 0.15f;
				num3 = 0.175f;
			}
			else if (num == 2.0)
			{
				num2 = 0.1f;
				num3 = 0.2f;
			}
			else if (num == 3.0)
			{
				num2 = 0.05f;
				num3 = 0.225f;
			}
			else if (num == 4.0)
			{
				num2 = 0f;
				num3 = 0.25f;
			}
			else if (num == 5.0)
			{
				num2 = 0.2f;
				num3 = 0.15f;
			}
			else if (num == 6.0)
			{
				num2 = 0.15f;
				num3 = 0.175f;
			}
			else if (num == 7.0)
			{
				num2 = 0.1f;
				num3 = 0.2f;
			}
			else if (num == 8.0)
			{
				num2 = 0.05f;
				num3 = 0.225f;
			}
			else if (num == 9.0)
			{
				num2 = 0f;
				num3 = 0.25f;
			}
			int num4;
			double num5;
			checked
			{
				num4 = (int)Math.Round((double)(unchecked(num3 * (float)this.pbStats.Height)));
				num3 = (float)((double)num4 / (double)this.pbStats.Height);
				num4 = (int)Math.Round((double)(unchecked(num2 * (float)this.pbStats.Height)));
				num2 = (float)((double)num4 / (double)this.pbStats.Height);
				num5 = Conversion.Val(this.cboLayoutY.Text);
			}
			float num6;
			if (num5 == 0.0 || num5 == 1.0 || num5 == 2.0 || num5 == 3.0 || num5 == 4.0)
			{
				num6 = num2;
				this.LAB_Height = num3;
			}
			else if (num5 == 5.0 || num5 == 6.0 || num5 == 7.0 || num5 == 8.0 || num5 == 9.0)
			{
				num6 = (float)((double)num2 + (double)num3 * 0.075);
				this.LAB_Height = (float)((double)num3 * 0.8);
			}
			num4 = 1;
			do
			{
				this.LAB_Rank[num4].Y = num6 * (float)this.pbStats.Height;
				this.LAB_Rank[num4].Height = this.LAB_Height * (float)this.pbStats.Height;
				this.LAB_Rank[num4].Ycenter = this.LAB_Rank[num4].Y + this.LAB_Rank[num4].Height / 2f;
				this.LAB_Name[num4].Y = num6 * (float)this.pbStats.Height;
				this.LAB_Name[num4].Height = this.LAB_Height * (float)this.pbStats.Height;
				this.LAB_Name[num4].Ycenter = this.LAB_Name[num4].Y + this.LAB_Name[num4].Height / 2f;
				this.LAB_Fact[num4].Y = num6 * (float)this.pbStats.Height;
				this.LAB_Fact[num4].Height = this.LAB_Height * (float)this.pbStats.Height;
				this.LAB_Fact[num4].Ycenter = this.LAB_Fact[num4].Y + this.LAB_Fact[num4].Height / 2f;
				this.LAB_Rank[checked(num4 + 1)].Y = num6 * (float)this.pbStats.Height;
				this.LAB_Rank[checked(num4 + 1)].Height = this.LAB_Height * (float)this.pbStats.Height;
				this.LAB_Rank[checked(num4 + 1)].Ycenter = this.LAB_Rank[checked(num4 + 1)].Y + this.LAB_Rank[checked(num4 + 1)].Height / 2f;
				this.LAB_Name[checked(num4 + 1)].Y = num6 * (float)this.pbStats.Height;
				this.LAB_Name[checked(num4 + 1)].Height = this.LAB_Height * (float)this.pbStats.Height;
				this.LAB_Name[checked(num4 + 1)].Ycenter = this.LAB_Name[checked(num4 + 1)].Y + this.LAB_Name[checked(num4 + 1)].Height / 2f;
				this.LAB_Fact[checked(num4 + 1)].Y = num6 * (float)this.pbStats.Height;
				this.LAB_Fact[checked(num4 + 1)].Height = this.LAB_Height * (float)this.pbStats.Height;
				this.LAB_Fact[checked(num4 + 1)].Ycenter = this.LAB_Fact[checked(num4 + 1)].Y + this.LAB_Fact[checked(num4 + 1)].Height / 2f;
				num6 += num3;
				checked
				{
					num4 += 2;
				}
			}
			while (num4 <= 7);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00013330 File Offset: 0x00011530
		private void STATS_DefineX()
		{
			checked
			{
				int num = (int)Math.Round((double)this.LAB_Fact[1].Height);
				int num2 = (int)Math.Round((double)this.pbStats.Width / 4.0);
				int num3 = (int)Math.Round((double)this.pbStats.Width / 2.0);
				double num4 = Conversion.Val(this.cboLayoutX.Text);
				int num5;
				int num6;
				float num7;
				if (num4 == 0.0)
				{
					num5 = (int)Math.Round(unchecked(0.6 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.35f;
				}
				else if (num4 == 1.0)
				{
					num5 = (int)Math.Round(unchecked(0.7 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.3f;
				}
				else if (num4 == 2.0)
				{
					num5 = (int)Math.Round(unchecked(0.8 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.25f;
				}
				else if (num4 == 3.0)
				{
					num5 = (int)Math.Round(unchecked(0.9 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.2f;
				}
				else if (num4 == 4.0)
				{
					num5 = (int)Math.Round(unchecked(1.0 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.15f;
				}
				else if (num4 == 5.0)
				{
					num5 = (int)Math.Round(unchecked(0.6 * ((double)this.pbStats.Width / 2.0)));
					num6 = 4;
					num7 = 0.35f;
				}
				else if (num4 == 6.0)
				{
					num5 = (int)Math.Round(unchecked(0.7 * ((double)this.pbStats.Width / 2.0)));
					num6 = 6;
					num7 = 0.3f;
				}
				else if (num4 == 7.0)
				{
					num5 = (int)Math.Round(unchecked(0.8 * ((double)this.pbStats.Width / 2.0)));
					num6 = 8;
					num7 = 0.25f;
				}
				else if (num4 == 8.0)
				{
					num5 = (int)Math.Round(unchecked(0.9 * ((double)this.pbStats.Width / 2.0)));
					num6 = 10;
					num7 = 0.2f;
				}
				else if (num4 == 9.0)
				{
					num5 = (int)Math.Round(unchecked(1.0 * ((double)this.pbStats.Width / 2.0)));
					num6 = 12;
					num7 = 0.15f;
				}
				else if (num4 == 10.0)
				{
					num5 = (int)Math.Round(unchecked(0.6 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.35f;
				}
				else if (num4 == 11.0)
				{
					num5 = (int)Math.Round(unchecked(0.7 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.3f;
				}
				else if (num4 == 12.0)
				{
					num5 = (int)Math.Round(unchecked(0.8 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.25f;
				}
				else if (num4 == 13.0)
				{
					num5 = (int)Math.Round(unchecked(0.9 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.2f;
				}
				else if (num4 == 14.0)
				{
					num5 = (int)Math.Round(unchecked(1.0 * ((double)this.pbStats.Width / 2.0)));
					num6 = 0;
					num7 = 0.15f;
				}
				else if (num4 == 15.0)
				{
					num5 = (int)Math.Round(unchecked(0.6 * ((double)this.pbStats.Width / 2.0)));
					num6 = 4;
					num7 = 0.35f;
				}
				else if (num4 == 16.0)
				{
					num5 = (int)Math.Round(unchecked(0.7 * ((double)this.pbStats.Width / 2.0)));
					num6 = 6;
					num7 = 0.3f;
				}
				else if (num4 == 17.0)
				{
					num5 = (int)Math.Round(unchecked(0.8 * ((double)this.pbStats.Width / 2.0)));
					num6 = 8;
					num7 = 0.25f;
				}
				else if (num4 == 18.0)
				{
					num5 = (int)Math.Round(unchecked(0.9 * ((double)this.pbStats.Width / 2.0)));
					num6 = 10;
					num7 = 0.2f;
				}
				else if (num4 == 19.0)
				{
					num5 = (int)Math.Round(unchecked(1.0 * ((double)this.pbStats.Width / 2.0)));
					num6 = 12;
					num7 = 0.15f;
				}
				else if (num4 == 20.0)
				{
					num5 = (int)Math.Round(unchecked(0.95 * ((double)(checked(this.pbStats.Width - 50)) / 2.0)));
					num6 = 0;
					num7 = 0.2f;
				}
				else if (num4 == 21.0)
				{
					num5 = (int)Math.Round(unchecked(0.95 * ((double)(checked(this.pbStats.Width - 50)) / 2.0)));
					num6 = 10;
					num7 = 0.2f;
				}
				int num8 = (int)Math.Round(unchecked((double)num2 - (double)num5 * 0.5));
				int num9 = num6 + (num8 + num);
				int num10 = (int)Math.Round((double)(unchecked((float)num6 + ((float)num9 + (float)(checked(num5 - num9)) * num7))));
				double num11 = Conversion.Val(this.cboLayoutX.Text);
				if (num11 < 10.0)
				{
					int num12 = 1;
					do
					{
						this.LAB_Fact[num12].X = (float)num8;
						this.LAB_Fact[num12].Xtext = (float)num8;
						this.LAB_Rank[num12].X = (float)num9;
						this.LAB_Rank[num12].Xtext = (float)num9;
						this.LAB_Name[num12].X = (float)num10;
						this.LAB_Name[num12].Xtext = (float)num10;
						this.LAB_Name_Align[num12].Alignment = StringAlignment.Near;
						this.LAB_Fact[num12].Width = (float)num;
						this.LAB_Rank[num12].Width = (float)(num10 - num9 - num6);
						this.LAB_Name[num12].Width = (float)(unchecked((double)num2 + (double)num5 * 0.5 - (double)num10 - (double)num6));
						this.LAB_Fact[num12 + 1].X = (float)(num8 + num3);
						this.LAB_Fact[num12 + 1].Xtext = (float)(num8 + num3);
						this.LAB_Rank[num12 + 1].X = (float)(num9 + num3);
						this.LAB_Rank[num12 + 1].Xtext = (float)(num9 + num3);
						this.LAB_Name[num12 + 1].X = (float)(num10 + num3);
						this.LAB_Name[num12 + 1].Xtext = (float)(num10 + num3);
						this.LAB_Name_Align[num12 + 1].Alignment = StringAlignment.Near;
						this.LAB_Fact[num12 + 1].Width = (float)num;
						this.LAB_Rank[num12 + 1].Width = (float)(num10 - num9 - num6);
						this.LAB_Name[num12 + 1].Width = (float)(unchecked((double)num2 + (double)num5 * 0.5 - (double)num10 - (double)num6));
						num12 += 2;
					}
					while (num12 <= 7);
					return;
				}
				if (num11 >= 11.0 && num11 <= 19.0)
				{
					int num12 = 1;
					do
					{
						this.LAB_Fact[num12].Width = (float)num;
						this.LAB_Rank[num12].Width = (float)(num10 - num9 - num6);
						unchecked
						{
							this.LAB_Name[num12].Width = (float)((double)num2 + (double)num5 * 0.5 - (double)num10 - (double)num6);
							this.LAB_Fact[num12].X = (float)(checked(num3 - num8)) - this.LAB_Fact[num12].Width;
							this.LAB_Fact[num12].Xtext = (float)(checked(num3 - num8)) - this.LAB_Fact[num12].Width;
							this.LAB_Rank[num12].X = (float)(checked(num3 - num9)) - this.LAB_Rank[num12].Width;
							this.LAB_Rank[num12].Xtext = (float)(checked(num3 - num9)) - this.LAB_Rank[num12].Width;
							this.LAB_Name[num12].X = (float)(checked(num3 - num10)) - this.LAB_Name[num12].Width;
							this.LAB_Name[num12].Xtext = (float)(checked(num3 - num10)) - this.LAB_Name[num12].Width;
							this.LAB_Name_Align[num12].Alignment = StringAlignment.Far;
						}
						this.LAB_Fact[num12 + 1].X = (float)(num8 + num3);
						this.LAB_Fact[num12 + 1].Xtext = (float)(num8 + num3);
						this.LAB_Rank[num12 + 1].X = (float)(num9 + num3);
						this.LAB_Rank[num12 + 1].Xtext = (float)(num9 + num3);
						this.LAB_Name[num12 + 1].X = (float)(num10 + num3);
						this.LAB_Name[num12 + 1].Xtext = (float)(num10 + num3);
						this.LAB_Fact[num12 + 1].Width = (float)num;
						this.LAB_Rank[num12 + 1].Width = (float)(num10 - num9 - num6);
						this.LAB_Name[num12 + 1].Width = (float)(unchecked((double)num2 + (double)num5 * 0.5 - (double)num10 - (double)num6));
						this.LAB_Name_Align[num12 + 1].Alignment = StringAlignment.Near;
						num12 += 2;
					}
					while (num12 <= 7);
					return;
				}
				if (num11 == 20.0)
				{
					int num12 = 1;
					do
					{
						this.LAB_Fact[num12 + 1].X = (float)(50 + num3);
						this.LAB_Fact[num12 + 1].Xtext = this.LAB_Fact[num12 + 1].X;
						this.LAB_Rank[num12 + 1].X = (float)(50 + num3 + num);
						this.LAB_Rank[num12 + 1].Xtext = this.LAB_Rank[num12 + 1].X;
						this.LAB_Name[num12 + 1].X = (float)(50 + num3 + num + (num10 - num9 - num6));
						this.LAB_Name[num12 + 1].Xtext = this.LAB_Name[num12 + 1].X;
						this.LAB_Fact[num12 + 1].Width = (float)num;
						this.LAB_Rank[num12 + 1].Width = (float)(num10 - num9 - num6);
						this.LAB_Name[num12 + 1].Width = unchecked((float)this.pbStats.Width - this.LAB_Name[checked(num12 + 1)].X);
						this.LAB_Name_Align[num12 + 1].Alignment = StringAlignment.Near;
						this.LAB_Fact[num12].Width = (float)num;
						this.LAB_Rank[num12].Width = this.LAB_Rank[num12 + 1].Width;
						this.LAB_Name[num12].Width = this.LAB_Name[num12 + 1].Width;
						unchecked
						{
							this.LAB_Fact[num12].X = (float)num3 - Math.Abs(this.LAB_Fact[checked(num12 + 1)].X + (float)num - (float)num3);
							this.LAB_Fact[num12].Xtext = this.LAB_Fact[num12].X;
							this.LAB_Rank[num12].X = (float)num3 - Math.Abs(this.LAB_Rank[checked(num12 + 1)].X + this.LAB_Rank[num12].Width - (float)num3);
							this.LAB_Rank[num12].Xtext = this.LAB_Rank[num12].X;
							this.LAB_Name[num12].X = 0f;
							this.LAB_Name[num12].Xtext = this.LAB_Name[num12].X;
							this.LAB_Name_Align[num12].Alignment = StringAlignment.Far;
						}
						num12 += 2;
					}
					while (num12 <= 7);
					return;
				}
				if (num11 == 21.0)
				{
					int num12 = 1;
					do
					{
						this.LAB_Fact[num12 + 1].X = (float)(50 + num3);
						this.LAB_Fact[num12 + 1].Xtext = this.LAB_Fact[num12 + 1].X;
						this.LAB_Rank[num12 + 1].X = (float)(50 + num3 + num + 5);
						this.LAB_Rank[num12 + 1].Xtext = this.LAB_Rank[num12 + 1].X;
						this.LAB_Name[num12 + 1].X = (float)(50 + num3 + num + 5 + (num10 - num9 - num6));
						this.LAB_Name[num12 + 1].Xtext = this.LAB_Name[num12 + 1].X;
						this.LAB_Fact[num12 + 1].Width = (float)num;
						this.LAB_Rank[num12 + 1].Width = (float)(num10 - num9 - num6 - 5);
						this.LAB_Name[num12 + 1].Width = unchecked((float)this.pbStats.Width - this.LAB_Name[checked(num12 + 1)].X - 5f);
						this.LAB_Name_Align[num12 + 1].Alignment = StringAlignment.Near;
						this.LAB_Fact[num12].Width = (float)num;
						this.LAB_Rank[num12].Width = this.LAB_Rank[num12 + 1].Width;
						this.LAB_Name[num12].Width = this.LAB_Name[num12 + 1].Width;
						unchecked
						{
							this.LAB_Fact[num12].X = (float)num3 - Math.Abs(this.LAB_Fact[checked(num12 + 1)].X + (float)num - (float)num3);
							this.LAB_Fact[num12].Xtext = this.LAB_Fact[num12].X;
							this.LAB_Rank[num12].X = (float)num3 - Math.Abs(this.LAB_Rank[checked(num12 + 1)].X + this.LAB_Rank[num12].Width - (float)num3);
							this.LAB_Rank[num12].Xtext = this.LAB_Rank[num12].X;
							this.LAB_Name[num12].X = 5f;
							this.LAB_Name[num12].Xtext = this.LAB_Name[num12].X;
							this.LAB_Name_Align[num12].Alignment = StringAlignment.Far;
						}
						num12 += 2;
					}
					while (num12 <= 7);
				}
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000143B8 File Offset: 0x000125B8
		private void STATS_ClipXY(float tX, float tY)
		{
			if (tX < 10f)
			{
				tX = 10f;
			}
			if (10000f < tX)
			{
				tX = 10000f;
			}
			checked
			{
				this.STATS_SizeX = (int)Math.Round((double)tX);
				if (tY < 10f)
				{
					tY = 10f;
				}
				if (10000f < tY)
				{
					tY = 10000f;
				}
				this.STATS_SizeY = (int)Math.Round((double)tY);
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0001441D File Offset: 0x0001261D
		private void STATS_Size()
		{
			this.pbStats.Width = this.STATS_SizeX;
			this.pbStats.Height = this.STATS_SizeY;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00014444 File Offset: 0x00012644
		private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.STATS_Size();
				this.STATS_DefineY();
				this.STATS_DefineX();
				this.SETTINGS_Save();
				this.SCREEN_Organize();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00014492 File Offset: 0x00012692
		private void cboLayoutY_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.STATS_DefineY();
				this.STATS_DefineX();
				this.SETTINGS_Save();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00014492 File Offset: 0x00012692
		private void cboLayoutX_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.STATS_DefineY();
				this.STATS_DefineX();
				this.SETTINGS_Save();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000144CC File Offset: 0x000126CC
		private void cmSizeRefresh_Click(object sender, EventArgs e)
		{
			this.STATS_ClipXY((float)Conversion.Val(this.tbXsize.Text), (float)Conversion.Val(this.tbYSize.Text));
			this.pbStats.Width = this.STATS_SizeX;
			this.pbStats.Height = this.STATS_SizeY;
			this.STATS_DefineY();
			this.STATS_DefineX();
			this.SETTINGS_Save();
			this.SCREEN_Organize();
			this.GFX_DrawStats();
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00014544 File Offset: 0x00012744
		private void cmNameFont_Click(object sender, EventArgs e)
		{
			FontDialog fontDialog = new FontDialog();
			fontDialog.Font = frmMain.FONT_Name;
			if (fontDialog.ShowDialog() != DialogResult.Cancel)
			{
				frmMain.FONT_Name = fontDialog.Font;
				frmMain.FONT_Name_Name = fontDialog.Font.Name;
				frmMain.FONT_Name_Size = Conversions.ToString(fontDialog.Font.Size);
				frmMain.FONT_Name_Bold = Conversions.ToString(fontDialog.Font.Bold);
				frmMain.FONT_Name_Italic = Conversions.ToString(fontDialog.Font.Italic);
				this.SETTINGS_Save();
			}
			this.GFX_DrawStats();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000145D1 File Offset: 0x000127D1
		private void frmMain_Shown(object sender, EventArgs e)
		{
			this.FLAG_Loading = true;
			this.STATS_Size();
			this.STATS_DefineY();
			this.STATS_DefineX();
			this.SCREEN_Organize();
			this.GFX_DrawStats();
			this.FLAG_Loading = false;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00014600 File Offset: 0x00012800
		private void CLOCK_Profile()
		{
			Stopwatch stopwatch = new Stopwatch();
			this.timNote1.Enabled = false;
			int num = 1;
			float num3;
			do
			{
				stopwatch.Reset();
				stopwatch.Start();
				long num2 = (long)Environment.TickCount;
				while (num2 == (long)Environment.TickCount)
				{
				}
				stopwatch.Stop();
				num3 = (float)((double)num3 * 0.5 + (double)(checked(unchecked((long)Environment.TickCount) - num2)) * 0.5);
				checked
				{
					long num4;
					this.CLOCK_TicksPerMS = (long)Math.Round(unchecked((double)num4 * 0.5 + (double)stopwatch.ElapsedTicks / (double)stopwatch.ElapsedMilliseconds * 0.5));
					num++;
				}
			}
			while (num <= 10);
			Interaction.MsgBox(num3.ToString(), MsgBoxStyle.OkOnly, null);
			Interaction.MsgBox((checked((long)Math.Round((double)(unchecked(Conversion.Fix(33f / num3) * num3))))).ToString(), MsgBoxStyle.OkOnly, null);
			Interaction.MsgBox(this.CLOCK_TicksPerMS.ToString(), MsgBoxStyle.OkOnly, null);
			this.timNote1.Enabled = true;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000146FA File Offset: 0x000128FA
		private void cboScaling_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.SETTINGS_Save();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00014725 File Offset: 0x00012925
		private void cmGUIDark_Click(object sender, EventArgs e)
		{
			this.GUI_SetDark();
			this.GUI_ColorMode = 1;
			this.SETTINGS_Save();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001473A File Offset: 0x0001293A
		private void cmGUILite_Click(object sender, EventArgs e)
		{
			this.GUI_SetLite();
			this.GUI_ColorMode = 0;
			this.SETTINGS_Save();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00014750 File Offset: 0x00012950
		private void GUI_SetDark()
		{
			Color cgroupFore = Color.FromArgb(255, 255, 255, 255);
			Color clabFore = Color.FromArgb(255, 192, 192, 192);
			Color cfore = Color.FromArgb(255, 232, 232, 232);
			Color cback = Color.FromArgb(255, 32, 32, 32);
			Color chover = Color.FromArgb(255, 48, 64, 48);
			this.BackColor = Color.FromArgb(255, 32, 32, 42);
			this.ForeColor = Color.FromArgb(255, 232, 232, 232);
			this.GUI_SetColor(cfore, cback, chover, cgroupFore, clabFore);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00014810 File Offset: 0x00012A10
		private void GUI_SetLite()
		{
			Color cgroupFore = Color.FromArgb(255, 0, 0, 0);
			Color clabFore = Color.FromArgb(255, 32, 32, 32);
			Color cfore = Color.FromArgb(255, 0, 0, 0);
			Color cback = Color.FromArgb(255, 232, 232, 232);
			Color chover = Color.FromArgb(255, 232, 255, 232);
			this.BackColor = Color.FromArgb(255, 232, 232, 242);
			this.ForeColor = Color.FromArgb(255, 0, 0, 0);
			this.GUI_SetColor(cfore, cback, chover, cgroupFore, clabFore);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000148C0 File Offset: 0x00012AC0
		private void GUI_SetColor(Color CFore, Color CBack, Color CHover, Color CGroupFore, Color CLabFore)
		{
			this.gbRank.ForeColor = CGroupFore;
			this.gbLayout.ForeColor = CGroupFore;
			this.gbFX.ForeColor = CGroupFore;
			this.gbSound.ForeColor = CGroupFore;
			this.Label3.ForeColor = CLabFore;
			this.Label4.ForeColor = CLabFore;
			this.Label5.ForeColor = CLabFore;
			this.Label6.ForeColor = CLabFore;
			this.Label7.ForeColor = CLabFore;
			try
			{
				foreach (object obj in this.gbRank.Controls)
				{
					Control control = (Control)obj;
					if (control is Label)
					{
						((Label)control).ForeColor = CLabFore;
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			try
			{
				foreach (object obj2 in this.gbFX.Controls)
				{
					Control control2 = (Control)obj2;
					if (control2 is Label)
					{
						((Label)control2).ForeColor = CLabFore;
					}
				}
			}
			finally
			{
				IEnumerator enumerator2;
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			try
			{
				foreach (object obj3 in base.Controls)
				{
					Control control3 = (Control)obj3;
					if (control3 is Button)
					{
						Button button = (Button)control3;
						button.BackColor = CBack;
						button.ForeColor = CFore;
						button.FlatAppearance.MouseOverBackColor = CHover;
					}
				}
			}
			finally
			{
				IEnumerator enumerator3;
				if (enumerator3 is IDisposable)
				{
					(enumerator3 as IDisposable).Dispose();
				}
			}
			try
			{
				foreach (object obj4 in this.gbRank.Controls)
				{
					Control control4 = (Control)obj4;
					if (control4 is Button)
					{
						Button button2 = (Button)control4;
						button2.BackColor = CBack;
						button2.ForeColor = CFore;
						button2.FlatAppearance.MouseOverBackColor = CHover;
					}
				}
			}
			finally
			{
				IEnumerator enumerator4;
				if (enumerator4 is IDisposable)
				{
					(enumerator4 as IDisposable).Dispose();
				}
			}
			try
			{
				foreach (object obj5 in this.gbLayout.Controls)
				{
					Control control5 = (Control)obj5;
					if (control5 is Button)
					{
						Button button3 = (Button)control5;
						button3.BackColor = CBack;
						button3.ForeColor = CFore;
						button3.FlatAppearance.MouseOverBackColor = CHover;
					}
				}
			}
			finally
			{
				IEnumerator enumerator5;
				if (enumerator5 is IDisposable)
				{
					(enumerator5 as IDisposable).Dispose();
				}
			}
			try
			{
				foreach (object obj6 in this.gbFX.Controls)
				{
					Control control6 = (Control)obj6;
					if (control6 is Button)
					{
						Button button4 = (Button)control6;
						button4.BackColor = CBack;
						button4.ForeColor = CFore;
						button4.FlatAppearance.MouseOverBackColor = CHover;
					}
				}
			}
			finally
			{
				IEnumerator enumerator6;
				if (enumerator6 is IDisposable)
				{
					(enumerator6 as IDisposable).Dispose();
				}
			}
			try
			{
				foreach (object obj7 in this.gbSound.Controls)
				{
					Control control7 = (Control)obj7;
					if (control7 is Button)
					{
						Button button5 = (Button)control7;
						button5.BackColor = CBack;
						button5.ForeColor = CFore;
						button5.FlatAppearance.MouseOverBackColor = CHover;
					}
				}
			}
			finally
			{
				IEnumerator enumerator7;
				if (enumerator7 is IDisposable)
				{
					(enumerator7 as IDisposable).Dispose();
				}
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00014C5C File Offset: 0x00012E5C
		private void FX_GetVarStrings()
		{
			int selectedIndex = this.cboFXVar1.SelectedIndex;
			if (0 < selectedIndex)
			{
				this.CFX3DVar[selectedIndex, 1] = this.cboFXVar1.Text;
				this.CFX3DVar[selectedIndex, 2] = this.cboFXVar2.Text;
				this.CFX3DVar[selectedIndex, 3] = this.cboFxVar3.Text;
				this.CFX3DVar[selectedIndex, 4] = this.cboFxVar4.Text;
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00014CDC File Offset: 0x00012EDC
		private void FX_SetVarControls()
		{
			int selectedIndex = this.cboFXVar1.SelectedIndex;
			if (0 < selectedIndex)
			{
				this.cboFXVar1.Text = this.CFX3DVar[selectedIndex, 1];
				this.cboFXVar2.Text = this.CFX3DVar[selectedIndex, 2];
				this.cboFxVar3.Text = this.CFX3DVar[selectedIndex, 3];
				this.cboFxVar4.Text = this.CFX3DVar[selectedIndex, 4];
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00014D5C File Offset: 0x00012F5C
		private void OFFSET_Validate(ref int Xoff, ref int Yoff)
		{
			float num = (float)Conversion.Val(this.tbXoff.Text);
			if (num < -10000f)
			{
				num = -10000f;
			}
			if (10000f < num)
			{
				num = 10000f;
			}
			checked
			{
				Xoff = (int)Math.Round((double)num);
				float num2 = (float)Conversion.Val(this.tbYoff.Text);
				if (num2 < -10000f)
				{
					num2 = -10000f;
				}
				if (10000f < num2)
				{
					num2 = 10000f;
				}
				Yoff = (int)Math.Round((double)num2);
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00014DDC File Offset: 0x00012FDC
		private void GFX_DrawStats()
		{
			Font font_Rank = frmMain.FONT_Rank;
			new int[9];
			long num = (long)Environment.TickCount;
			checked
			{
				int num2 = (int)((long)Math.Round((double)this.LAB_Rank[1].Height) / 2L);
				int num3;
				int num4;
				this.OFFSET_Validate(ref num3, ref num4);
				this.pbStats.Width = this.STATS_SizeX;
				this.pbStats.Height = this.STATS_SizeY;
				Bitmap bitmap = new Bitmap(this.pbStats.Width, this.pbStats.Height);
				Image image = new Bitmap(this.pbStats.Width, this.pbStats.Height);
				Graphics graphics = Graphics.FromImage(bitmap);
				Graphics.FromImage(image);
				if (this.NAME_bmp == null)
				{
					graphics.FillRectangle(new SolidBrush(this.LSName.BackC), 0, 0, this.pbStats.Width, this.pbStats.Height);
				}
				else
				{
					double num5 = Conversion.Val(this.LSName.Scaling);
					if (num5 == 0.0)
					{
						graphics.DrawImage(this.NAME_bmp, 0, 0, this.NAME_bmp.Width, this.NAME_bmp.Height);
					}
					else if (num5 == 1.0)
					{
						int height = bitmap.Height;
						int height2 = this.NAME_bmp.Height;
						int num6 = 0;
						while ((height2 >> 31 ^ num6) <= (height2 >> 31 ^ height))
						{
							int width = bitmap.Width;
							int width2 = this.NAME_bmp.Width;
							int num7 = 0;
							while ((width2 >> 31 ^ num7) <= (width2 >> 31 ^ width))
							{
								graphics.DrawImage(this.NAME_bmp, num7, num6, this.NAME_bmp.Width, this.NAME_bmp.Height);
								num7 += width2;
							}
							num6 += height2;
						}
					}
					else if (num5 == 2.0)
					{
						graphics.DrawImage(this.NAME_bmp, 0, 0, bitmap.Width, bitmap.Height);
					}
				}
				if (this.CFX3DActive[3])
				{
					this.GFX_FX_LabBlur(graphics, bitmap, num3, num4);
				}
				new SolidBrush(this.LSRank.B1);
				new SolidBrush(this.LSRank.F1);
				int num8 = 1;
				do
				{
					LinearGradientBrush brush;
					if (this.LSRank.BDir == 0)
					{
						brush = new LinearGradientBrush(new Point(num3 + 0, (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Rank[num8].Y - 1f)))), new Point(num3 + 0, (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Rank[num8].Y + this.LAB_Rank[num8].Height + 1f)))), this.LSRank.B1, this.LSRank.B2);
					}
					else
					{
						brush = new LinearGradientBrush(new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Rank[num8].X - 1f))), num4 + 0), new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Rank[num8].X + this.LAB_Rank[num8].Width + 1f))), num4 + 0), this.LSRank.B1, this.LSRank.B2);
					}
					unchecked
					{
						graphics.FillRectangle(brush, (float)num3 + this.LAB_Rank[num8].X, (float)num4 + this.LAB_Rank[num8].Y, this.LAB_Rank[num8].Width, this.LAB_Rank[num8].Height);
					}
					num8++;
				}
				while (num8 <= 8);
				new SolidBrush(this.LSName.B1);
				new SolidBrush(this.LSName.F1);
				int num9 = 1;
				do
				{
					LinearGradientBrush brush;
					if (this.LSName.BDir == 0)
					{
						brush = new LinearGradientBrush(new Point(num3 + 0, (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Name[num9].Y - 1f)))), new Point(num3 + 0, (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Name[num9].Y + this.LAB_Name[num9].Height + 1f)))), this.LSName.B1, this.LSName.B2);
					}
					else if (this.LAB_Name_Align[num9].Alignment == StringAlignment.Far)
					{
						brush = new LinearGradientBrush(new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num9].X + this.LAB_Name[num9].Width + 1f))), num4 + 0), new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num9].X - 1f))), num4 + 0), this.LSName.B1, this.LSName.B2);
					}
					else
					{
						brush = new LinearGradientBrush(new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num9].X - 1f))), num4 + 0), new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num9].X + this.LAB_Name[num9].Width + 1f))), num4 + 0), this.LSName.B1, this.LSName.B2);
					}
					unchecked
					{
						graphics.FillRectangle(brush, (float)num3 + this.LAB_Name[num9].X, (float)num4 + this.LAB_Name[num9].Y, this.LAB_Name[num9].Width, this.LAB_Name[num9].Height);
					}
					num9++;
				}
				while (num9 <= 8);
				if (this.CFX3DActive[1])
				{
					this.GFX_FX_Shadow(graphics, num3, num4);
				}
				new SolidBrush(this.LSRank.F1);
				new SolidBrush(this.LSRank.F1);
				SolidBrush brush2 = new SolidBrush(this.LSRank.ShadowColor);
				int num10 = (int)Math.Round((double)(graphics.MeasureString("X", frmMain.FONT_Rank).Height / 2f));
				int num11 = 1;
				do
				{
					graphics.Clip = new Region(new Rectangle((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Rank[num11].X + 1f))), (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Rank[num11].Y))), (int)Math.Round((double)(unchecked(this.LAB_Rank[num11].Width - 2f))), (int)Math.Round((double)this.LAB_Rank[num11].Height)));
					int num12 = (int)Math.Round((double)(unchecked(this.LAB_Rank[num11].X + this.LAB_Rank[num11].Width / 2f - graphics.MeasureString(this.PlrRank[num11], frmMain.FONT_Rank).Width / 2f)));
					int num13 = (int)Math.Round((double)(unchecked(this.LAB_Rank[num11].Y + this.LAB_Rank[num11].Height / 2f - graphics.MeasureString(this.PlrRank[num11], frmMain.FONT_Rank).Height / 2f)));
					unchecked
					{
						if (this.LSRank.ShadowX != 0 | this.LSRank.ShadowY != 0)
						{
							graphics.DrawString(this.PlrRank[num11], frmMain.FONT_Rank, brush2, (float)((double)(checked(num3 + num12)) + (double)this.LSRank.ShadowX * Conversion.Val(this.LSRank.ShadowDepth)), (float)((double)(checked(num4 + num13)) + (double)this.LSRank.ShadowY * Conversion.Val(this.LSRank.ShadowDepth)));
						}
					}
					LinearGradientBrush brush;
					if (this.LSRank.FDir == 0)
					{
						brush = new LinearGradientBrush(new Point(num3 + 0, (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Rank[num11].Ycenter - (float)num10)))), new Point(num3 + 0, (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Rank[num11].Ycenter + (float)num10)))), Color.FromArgb(255, (int)this.LSRank.F1.R, (int)this.LSRank.F1.G, (int)this.LSRank.F1.B), Color.FromArgb(255, (int)this.LSRank.F2.R, (int)this.LSRank.F2.G, (int)this.LSRank.F2.B));
					}
					else
					{
						brush = new LinearGradientBrush(new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Rank[num11].X))), num4 + 0), new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Rank[num11].X + this.LAB_Rank[num11].Width))), num4 + 0), Color.FromArgb(255, (int)this.LSRank.F1.R, (int)this.LSRank.F1.G, (int)this.LSRank.F1.B), Color.FromArgb(255, (int)this.LSRank.F2.R, (int)this.LSRank.F2.G, (int)this.LSRank.F2.B));
					}
					graphics.DrawString(this.PlrRank[num11], frmMain.FONT_Rank, brush, (float)(num3 + num12), (float)(num4 + num13));
					graphics.Clip = new Region(new Rectangle(0, 0, bitmap.Width, bitmap.Height));
					num11++;
				}
				while (num11 <= 8);
				int num14 = 1;
				do
				{
					unchecked
					{
						if (Operators.CompareString(this.PlrFact[num14], "", false) != 0)
						{
							PictureBox pictureBox = (PictureBox)base.Controls["pbFact" + this.PlrFact[num14]];
							graphics.DrawImage(pictureBox.Image, (float)num3 + this.LAB_Fact[num14].X, (float)num4 + this.LAB_Fact[num14].Y, this.LAB_Fact[num14].Width, this.LAB_Fact[num14].Height);
						}
					}
					num14++;
				}
				while (num14 <= 8);
				new SolidBrush(this.LSName.F1);
				new SolidBrush(this.LSName.F1);
				brush2 = new SolidBrush(this.LSName.ShadowColor);
				num10 = (int)Math.Round((double)(graphics.MeasureString("X", frmMain.FONT_Name).Height / 2f));
				int num15 = 1;
				do
				{
					graphics.Clip = new Region(new Rectangle((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num15].X + 1f))), (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Name[num15].Y))), (int)Math.Round((double)(unchecked(this.LAB_Name[num15].Width - 2f))), (int)Math.Round((double)this.LAB_Name[num15].Height)));
					if (this.LAB_Name_Align[num15].Alignment == StringAlignment.Far)
					{
						this.LAB_Name[num15].Xtext = unchecked(this.LAB_Name[num15].X + this.LAB_Name[num15].Width);
					}
					int num12 = (int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num15].Xtext)));
					int num13 = (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Name[num15].Y + (float)num2 - (float)num10)));
					unchecked
					{
						if (this.LSName.ShadowX != 0 | this.LSName.ShadowY != 0)
						{
							graphics.DrawString(this.PlrName[num15], frmMain.FONT_Name, brush2, (float)((double)num12 + (double)this.LSName.ShadowX * Conversion.Val(this.LSName.ShadowDepth)), (float)((double)num13 + (double)this.LSName.ShadowY * Conversion.Val(this.LSName.ShadowDepth)), this.LAB_Name_Align[num15]);
						}
					}
					LinearGradientBrush brush;
					if (this.LSName.FDir == 0)
					{
						brush = new LinearGradientBrush(new Point(num3 + 0, (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Name[num15].Ycenter - (float)num10)))), new Point(num3 + 0, (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Name[num15].Ycenter + (float)num10)))), Color.FromArgb(255, (int)this.LSName.F1.R, (int)this.LSName.F1.G, (int)this.LSName.F1.B), Color.FromArgb(255, (int)this.LSName.F2.R, (int)this.LSName.F2.G, (int)this.LSName.F2.B));
					}
					else if (this.LAB_Name_Align[num15].Alignment == StringAlignment.Far)
					{
						brush = new LinearGradientBrush(new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num15].X + this.LAB_Name[num15].Width))), num4 + 0), new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num15].X))), num4 + 0), Color.FromArgb(255, (int)this.LSName.F1.R, (int)this.LSName.F1.G, (int)this.LSName.F1.B), Color.FromArgb(255, (int)this.LSName.F2.R, (int)this.LSName.F2.G, (int)this.LSName.F2.B));
					}
					else
					{
						brush = new LinearGradientBrush(new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num15].X))), num4 + 0), new Point((int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num15].X + this.LAB_Name[num15].Width))), num4 + 0), Color.FromArgb(255, (int)this.LSName.F1.R, (int)this.LSName.F1.G, (int)this.LSName.F1.B), Color.FromArgb(255, (int)this.LSName.F2.R, (int)this.LSName.F2.G, (int)this.LSName.F2.B));
					}
					num12 = (int)Math.Round((double)(unchecked((float)num3 + this.LAB_Name[num15].Xtext)));
					num13 = (int)Math.Round((double)(unchecked((float)num4 + this.LAB_Name[num15].Y + (float)num2 - (float)num10)));
					graphics.DrawString(this.PlrName[num15], frmMain.FONT_Name, brush, (float)num12, (float)num13, this.LAB_Name_Align[num15]);
					graphics.Clip = new Region(new Rectangle(0, 0, bitmap.Width, bitmap.Height));
					num15++;
				}
				while (num15 <= 8);
				if (this.CFX3DActive[2])
				{
					this.GFX_FX_Emboss(graphics, bitmap, num3, num4);
				}
				if (this.NAME_OVLBmp != null)
				{
					double num16 = Conversion.Val(this.LSName.OVLScaling);
					if (num16 == 0.0)
					{
						graphics.DrawImage(this.NAME_OVLBmp, 0, 0, this.NAME_OVLBmp.Width, this.NAME_OVLBmp.Height);
					}
					else if (num16 == 1.0)
					{
						int height3 = bitmap.Height;
						int height4 = this.NAME_OVLBmp.Height;
						int num6 = 0;
						while ((height4 >> 31 ^ num6) <= (height4 >> 31 ^ height3))
						{
							int width3 = bitmap.Width;
							int width4 = this.NAME_OVLBmp.Width;
							int num7 = 0;
							while ((width4 >> 31 ^ num7) <= (width4 >> 31 ^ width3))
							{
								graphics.DrawImage(this.NAME_OVLBmp, num7, num6, this.NAME_OVLBmp.Width, this.NAME_OVLBmp.Height);
								num7 += width4;
							}
							num6 += height4;
						}
					}
					else if (num16 == 2.0)
					{
						unchecked
						{
							if (this.NAME_OVLBmp.Width < bitmap.Width | this.NAME_OVLBmp.Height < bitmap.Height)
							{
								float num17 = (float)((double)bitmap.Width / (double)this.NAME_OVLBmp.Width);
								float num18 = (float)((double)bitmap.Height / (double)this.NAME_OVLBmp.Height);
								graphics.DrawImage(this.NAME_OVLBmp, 0f, 0f, (float)bitmap.Width + num17, (float)bitmap.Height + num18);
							}
							else
							{
								graphics.DrawImage(this.NAME_OVLBmp, 0, 0, bitmap.Width, bitmap.Height);
							}
						}
					}
				}
				this.pbStats.Image = bitmap;
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00015FF0 File Offset: 0x000141F0
		private void GFX_FX_LabBlur(Graphics Gfx, Bitmap BM, int Xoff, int Yoff)
		{
			Rectangle rect = new Rectangle(0, 0, BM.Width, BM.Height);
			BitmapData bitmapData = BM.LockBits(rect, ImageLockMode.ReadWrite, BM.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			int stride = bitmapData.Stride;
			int num;
			byte[] array;
			checked
			{
				num = BM.Width * BM.Height * 4;
				array = new byte[num - 1 + 1];
			}
			float num2;
			if (1 < Strings.Len(this.CFX3DVar[3, 4]))
			{
				num2 = (float)(1.0 + Conversion.Val(Strings.Mid(this.CFX3DVar[3, 4], 1, checked(Strings.Len(this.CFX3DVar[3, 4]) - 1))) * 0.01);
			}
			else
			{
				num2 = 1f;
			}
			if (num2 < 1f)
			{
				num2 = 1f;
			}
			if (1.1 < (double)num2)
			{
				num2 = 1.1f;
			}
			num2 = 1f + (num2 - 1f) * 4f;
			float num3;
			if (1 < Strings.Len(this.CFX3DVar[3, 3]))
			{
				num3 = (float)(Conversion.Val(Strings.Mid(this.CFX3DVar[3, 3], 1, checked(Strings.Len(this.CFX3DVar[3, 3]) - 1))) * 0.01);
			}
			else
			{
				num3 = 0.4f;
			}
			if (num3 == 0f)
			{
				num3 = 0.8f;
			}
			Marshal.Copy(scan, array, 0, num);
			int num4 = 1;
			checked
			{
				do
				{
					this.FX_BlurRect(ref array, stride, num3, num2, (int)Math.Round((double)(unchecked((float)Xoff + this.LAB_Rank[num4].X))), (int)Math.Round((double)(unchecked((float)Yoff + this.LAB_Rank[num4].Y))), (int)Math.Round((double)this.LAB_Rank[num4].Width), (int)Math.Round((double)this.LAB_Rank[num4].Height));
					this.FX_BlurRect(ref array, stride, num3, num2, (int)Math.Round((double)(unchecked((float)Xoff + this.LAB_Name[num4].X))), (int)Math.Round((double)(unchecked((float)Yoff + this.LAB_Name[num4].Y))), (int)Math.Round((double)this.LAB_Name[num4].Width), (int)Math.Round((double)this.LAB_Name[num4].Height));
					num4++;
				}
				while (num4 <= 8);
				Marshal.Copy(array, 0, scan, num);
				BM.UnlockBits(bitmapData);
				Gfx.DrawImage(BM, 0, 0);
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00016278 File Offset: 0x00014478
		private void GFX_FX_Shadow(Graphics Gfx, int Xoff, int Yoff)
		{
			new LinearGradientBrush(new Point(0, 0), new Point(20, 0), Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 0, 255));
			Bitmap bitmap = new Bitmap(this.pbStats.Width, this.pbStats.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			BitmapData bitmapData;
			IntPtr scan;
			int stride;
			int num12;
			byte[] array;
			checked
			{
				int num = (int)((long)Math.Round((double)this.LAB_Rank[1].Height) / 2L);
				int num2 = 1;
				do
				{
					unchecked
					{
						if (Operators.CompareString(this.PlrFact[num2], "", false) != 0)
						{
							PictureBox pictureBox = (PictureBox)base.Controls["pbFact" + this.PlrFact[num2]];
							graphics.DrawImage(pictureBox.Image, (float)Xoff + this.LAB_Fact[num2].X, (float)Yoff + this.LAB_Fact[num2].Y, this.LAB_Fact[num2].Width, this.LAB_Fact[num2].Height);
						}
					}
					num2++;
				}
				while (num2 <= 8);
				SolidBrush brush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
				brush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
				int num3 = (int)Math.Round((double)(graphics.MeasureString("X", frmMain.FONT_Rank).Height / 2f));
				int num4 = 1;
				for (;;)
				{
					graphics.Clip = new Region(new Rectangle((int)Math.Round((double)(unchecked((float)Xoff + this.LAB_Rank[num4].X + 1f))), (int)Math.Round((double)(unchecked((float)Yoff + this.LAB_Rank[num4].Y))), (int)Math.Round((double)(unchecked(this.LAB_Rank[num4].Width - 2f))), (int)Math.Round((double)this.LAB_Rank[num4].Height)));
					int num5 = (int)Math.Round((double)(unchecked(this.LAB_Rank[num4].X + 2f + this.LAB_Rank[num4].Width / 2f - graphics.MeasureString(this.PlrRank[num4], frmMain.FONT_Rank).Width / 2f)));
					int num6 = (int)Math.Round((double)(unchecked(this.LAB_Rank[num4].Y + 2f + this.LAB_Rank[num4].Height / 2f - graphics.MeasureString(this.PlrRank[num4], frmMain.FONT_Rank).Height / 2f)));
					int num7 = (int)Math.Round((double)(graphics.MeasureString(this.PlrRank[num4], frmMain.FONT_Rank).Height / 2f));
					string text = this.CFX3DVar[1, 2];
					uint num8 = <PrivateImplementationDetails>.ComputeStringHash(text);
					int num9;
					int num10;
					if (num8 <= 2427795852U)
					{
						if (num8 <= 1573522228U)
						{
							if (num8 != 717409452U)
							{
								if (num8 != 1573522228U)
								{
									goto IL_45C;
								}
								if (Operators.CompareString(text, "90°", false) != 0)
								{
									goto IL_45C;
								}
								num9 = -2;
								num10 = -4;
							}
							else
							{
								if (Operators.CompareString(text, "180°", false) != 0)
								{
									goto IL_45C;
								}
								num9 = -4;
								num10 = -2;
							}
						}
						else if (num8 != 1615908792U)
						{
							if (num8 != 2427795852U)
							{
								goto IL_45C;
							}
							if (Operators.CompareString(text, "315°", false) != 0)
							{
								goto IL_45C;
							}
							num9 = 0;
							num10 = 0;
						}
						else
						{
							if (Operators.CompareString(text, "135°", false) != 0)
							{
								goto IL_45C;
							}
							num9 = -4;
							num10 = -4;
						}
					}
					else if (num8 <= 2620932502U)
					{
						if (num8 != 2453520896U)
						{
							if (num8 != 2620932502U)
							{
								goto IL_45C;
							}
							if (Operators.CompareString(text, "45°", false) != 0)
							{
								goto IL_45C;
							}
							num9 = 0;
							num10 = -4;
						}
						else
						{
							if (Operators.CompareString(text, "225°", false) != 0)
							{
								goto IL_45C;
							}
							num9 = -4;
							num10 = 0;
						}
					}
					else if (num8 != 4134103542U)
					{
						if (num8 != 4249105564U)
						{
							goto IL_45C;
						}
						if (Operators.CompareString(text, "360°", false) != 0)
						{
							goto IL_45C;
						}
						num9 = 0;
						num10 = -2;
					}
					else
					{
						if (Operators.CompareString(text, "270°", false) != 0)
						{
							goto IL_45C;
						}
						num9 = -2;
						num10 = 0;
					}
					IL_462:
					if (Operators.CompareString(this.CFX3DVar[1, 2], "--", false) != 0)
					{
						graphics.DrawString(this.PlrRank[num4], frmMain.FONT_Rank, brush, (float)(Xoff + num5 + num9), (float)(Yoff + num6 + num10));
					}
					graphics.Clip = new Region(new Rectangle(0, 0, bitmap.Width, bitmap.Height));
					num4++;
					if (num4 > 8)
					{
						break;
					}
					continue;
					IL_45C:
					num9 = 0;
					num10 = 0;
					goto IL_462;
				}
				num3 = (int)Math.Round((double)(graphics.MeasureString("X", frmMain.FONT_Name).Height / 2f));
				int num11 = 1;
				for (;;)
				{
					graphics.Clip = new Region(new Rectangle((int)Math.Round((double)(unchecked((float)Xoff + this.LAB_Name[num11].X + 1f))), (int)Math.Round((double)(unchecked((float)Yoff + this.LAB_Name[num11].Y))), (int)Math.Round((double)(unchecked(this.LAB_Name[num11].Width - 2f))), (int)Math.Round((double)this.LAB_Name[num11].Height)));
					if (this.LAB_Name_Align[num11].Alignment == StringAlignment.Far)
					{
						this.LAB_Name[num11].Xtext = unchecked(this.LAB_Name[num11].X + this.LAB_Name[num11].Width);
					}
					int num5 = (int)Math.Round((double)(unchecked((float)Xoff + this.LAB_Name[num11].Xtext)));
					int num6 = (int)Math.Round((double)(unchecked((float)Yoff + this.LAB_Name[num11].Y + (float)num - (float)num3)));
					string text2 = this.CFX3DVar[1, 2];
					uint num8 = <PrivateImplementationDetails>.ComputeStringHash(text2);
					int num9;
					int num10;
					if (num8 <= 2427795852U)
					{
						if (num8 <= 1573522228U)
						{
							if (num8 != 717409452U)
							{
								if (num8 != 1573522228U)
								{
									goto IL_781;
								}
								if (Operators.CompareString(text2, "90°", false) != 0)
								{
									goto IL_781;
								}
								num9 = 0;
								num10 = -2;
							}
							else
							{
								if (Operators.CompareString(text2, "180°", false) != 0)
								{
									goto IL_781;
								}
								num9 = -2;
								num10 = 0;
							}
						}
						else if (num8 != 1615908792U)
						{
							if (num8 != 2427795852U)
							{
								goto IL_781;
							}
							if (Operators.CompareString(text2, "315°", false) != 0)
							{
								goto IL_781;
							}
							num9 = 2;
							num10 = 2;
						}
						else
						{
							if (Operators.CompareString(text2, "135°", false) != 0)
							{
								goto IL_781;
							}
							num9 = -2;
							num10 = -2;
						}
					}
					else if (num8 <= 2620932502U)
					{
						if (num8 != 2453520896U)
						{
							if (num8 != 2620932502U)
							{
								goto IL_781;
							}
							if (Operators.CompareString(text2, "45°", false) != 0)
							{
								goto IL_781;
							}
							num9 = 2;
							num10 = -2;
						}
						else
						{
							if (Operators.CompareString(text2, "225°", false) != 0)
							{
								goto IL_781;
							}
							num9 = -2;
							num10 = 2;
						}
					}
					else if (num8 != 4134103542U)
					{
						if (num8 != 4249105564U)
						{
							goto IL_781;
						}
						if (Operators.CompareString(text2, "360°", false) != 0)
						{
							goto IL_781;
						}
						num9 = 2;
						num10 = 0;
					}
					else
					{
						if (Operators.CompareString(text2, "270°", false) != 0)
						{
							goto IL_781;
						}
						num9 = 0;
						num10 = 2;
					}
					IL_787:
					if (Operators.CompareString(this.CFX3DVar[1, 2], "--", false) != 0)
					{
						graphics.DrawString(this.PlrName[num11], frmMain.FONT_Name, brush, (float)(num5 + num9), (float)(num6 + num10), this.LAB_Name_Align[num11]);
					}
					graphics.Clip = new Region(new Rectangle(0, 0, bitmap.Width, bitmap.Height));
					num11++;
					if (num11 > 8)
					{
						break;
					}
					continue;
					IL_781:
					num9 = 0;
					num10 = 0;
					goto IL_787;
				}
				Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
				scan = bitmapData.Scan0;
				stride = bitmapData.Stride;
				num12 = bitmap.Width * bitmap.Height * 4;
				array = new byte[num12 - 1 + 1];
				Marshal.Copy(scan, array, 0, num12);
			}
			float num13;
			if (1 < Strings.Len(this.CFX3DVar[1, 4]))
			{
				num13 = (float)(1.0 + Conversion.Val(Strings.Mid(this.CFX3DVar[1, 4], 1, checked(Strings.Len(this.CFX3DVar[1, 4]) - 1))) * 0.01);
			}
			else
			{
				num13 = 1f;
			}
			if (num13 < 1f)
			{
				num13 = 1f;
			}
			if (1.1 < (double)num13)
			{
				num13 = 1.1f;
			}
			num13 = 1f + (num13 - 1f) * 16f;
			float num14;
			if (1 < Strings.Len(this.CFX3DVar[1, 3]))
			{
				num14 = (float)(Conversion.Val(Strings.Mid(this.CFX3DVar[1, 3], 1, checked(Strings.Len(this.CFX3DVar[1, 3]) - 1))) * 0.01);
			}
			else
			{
				num14 = 0.5f;
			}
			if (num14 == 0f)
			{
				num14 = 0.8f;
			}
			float num15 = 1f - num14;
			checked
			{
				int num16 = bitmap.Height - 1;
				int num17;
				int num19;
				for (int i = 0; i <= num16; i++)
				{
					num17 = i * stride;
					int num18 = bitmap.Width - 1;
					for (int j = 0; j <= num18; j++)
					{
						array[num17] = this.CFX3DC[1].B;
						array[num17 + 1] = this.CFX3DC[1].G;
						array[num17 + 2] = this.CFX3DC[1].R;
						array[num17 + 3] = (byte)Math.Round((double)(unchecked((float)num19 * num14 + (float)array[checked(num17 + 3)] * num15)));
						num19 = (int)array[num17 + 3];
						num17 += 4;
					}
				}
				int num20 = (bitmap.Width - 2) * 4;
				int num21 = bitmap.Height - 2;
				for (int k = 0; k <= num21; k++)
				{
					num17 = k * stride + num20;
					for (int l = bitmap.Width - 2; l >= 2; l += -1)
					{
						array[num17 + 3] = (byte)Math.Round((double)(unchecked((float)num19 * num14 + (float)array[checked(num17 + 3)] * num15)));
						num19 = (int)array[num17 + 3];
						num17 -= 4;
					}
				}
				int num22 = bitmap.Width - 2;
				for (int m = 2; m <= num22; m++)
				{
					num17 = m * 4;
					int num23 = bitmap.Height - 2;
					for (int n = 0; n <= num23; n++)
					{
						array[num17 + 3] = (byte)Math.Round((double)(unchecked((float)num19 * num14 + (float)array[checked(num17 + 3)] * num15)));
						num19 = (int)array[num17 + 3];
						num17 += stride;
					}
				}
				num20 = (bitmap.Height - 2) * stride;
				int num24 = bitmap.Width - 2;
				for (int num25 = 2; num25 <= num24; num25++)
				{
					num17 = num20 + num25 * 4;
					for (int num26 = bitmap.Height - 2; num26 >= 2; num26 += -1)
					{
						array[num17 + 3] = (byte)Math.Round((double)(unchecked((float)num19 * num14 + (float)array[checked(num17 + 3)] * num15)));
						num19 = (int)array[num17 + 3];
						num17 -= stride;
					}
				}
				num17 = 3;
				int num27 = num12 - 1;
				for (int num28 = 0; num28 <= num27; num28 += 4)
				{
					int num29 = (int)Math.Round((double)(unchecked((float)array[num17] * num13)));
					if (255 < num29)
					{
						num29 = 255;
					}
					array[num17] = (byte)num29;
					num17 += 4;
				}
				Marshal.Copy(array, 0, scan, num12);
				bitmap.UnlockBits(bitmapData);
				Gfx.DrawImage(bitmap, 0, 0);
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00016E80 File Offset: 0x00015080
		private void GFX_FX_Emboss(Graphics Gfx, Bitmap BM, int Xoff, int Yoff)
		{
			new LinearGradientBrush(new Point(0, 0), new Point(20, 0), Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 0, 255));
			Bitmap bitmap = new Bitmap(BM.Width, BM.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			BitmapData bitmapData;
			BitmapData bitmapData2;
			IntPtr scan;
			int stride;
			int num10;
			byte[] array;
			byte[] array2;
			checked
			{
				int num = (int)((long)Math.Round((double)this.LAB_Rank[1].Height) / 2L);
				int num2 = 1;
				do
				{
					unchecked
					{
						if (Operators.CompareString(this.PlrFact[num2], "", false) != 0)
						{
							PictureBox pictureBox = (PictureBox)base.Controls["pbFact" + this.PlrFact[num2]];
							graphics.DrawImage(pictureBox.Image, (float)Xoff + this.LAB_Fact[num2].X, (float)Yoff + this.LAB_Fact[num2].Y, this.LAB_Fact[num2].Width, this.LAB_Fact[num2].Height);
						}
					}
					num2++;
				}
				while (num2 <= 8);
				SolidBrush brush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
				int num3 = 1;
				do
				{
					graphics.Clip = new Region(new Rectangle((int)Math.Round((double)(unchecked((float)Xoff + this.LAB_Rank[num3].X + 1f))), (int)Math.Round((double)(unchecked((float)Yoff + this.LAB_Rank[num3].Y))), (int)Math.Round((double)(unchecked(this.LAB_Rank[num3].Width - 2f))), (int)Math.Round((double)this.LAB_Rank[num3].Height)));
					int num4 = (int)Math.Round((double)(unchecked((float)Xoff + this.LAB_Rank[num3].X + 2f + this.LAB_Rank[num3].Width / 2f - graphics.MeasureString(this.PlrRank[num3], frmMain.FONT_Rank).Width / 2f)));
					int num5 = (int)Math.Round((double)(unchecked((float)Yoff + this.LAB_Rank[num3].Y + 2f + this.LAB_Rank[num3].Height / 2f - graphics.MeasureString(this.PlrRank[num3], frmMain.FONT_Rank).Height / 2f)));
					int num6 = 0;
					int num7 = -2;
					graphics.DrawString(this.PlrRank[num3], frmMain.FONT_Rank, brush, (float)(num4 + num6), (float)(num5 + num7));
					graphics.Clip = new Region(new Rectangle(0, 0, bitmap.Width, bitmap.Height));
					num3++;
				}
				while (num3 <= 8);
				int num8 = (int)Math.Round((double)(graphics.MeasureString("X", frmMain.FONT_Name).Height / 2f));
				int num9 = 1;
				do
				{
					graphics.Clip = new Region(new Rectangle((int)Math.Round((double)(unchecked((float)Xoff + this.LAB_Name[num9].X + 1f))), (int)Math.Round((double)(unchecked((float)Yoff + this.LAB_Name[num9].Y))), (int)Math.Round((double)(unchecked(this.LAB_Name[num9].Width - 2f))), (int)Math.Round((double)this.LAB_Name[num9].Height)));
					if (this.LAB_Name_Align[num9].Alignment == StringAlignment.Far)
					{
						this.LAB_Name[num9].Xtext = unchecked(this.LAB_Name[num9].X + this.LAB_Name[num9].Width);
					}
					int num4 = (int)Math.Round((double)(unchecked((float)Xoff + this.LAB_Name[num9].Xtext)));
					int num5 = (int)Math.Round((double)(unchecked((float)Yoff + this.LAB_Name[num9].Y + (float)num - (float)num8)));
					graphics.DrawString(this.PlrName[num9], frmMain.FONT_Name, brush, (float)num4, (float)num5, this.LAB_Name_Align[num9]);
					graphics.Clip = new Region(new Rectangle(0, 0, bitmap.Width, bitmap.Height));
					num9++;
				}
				while (num9 <= 8);
				Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				bitmapData = BM.LockBits(rect, ImageLockMode.ReadWrite, BM.PixelFormat);
				bitmapData2 = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
				scan = bitmapData.Scan0;
				IntPtr scan2 = bitmapData2.Scan0;
				stride = bitmapData2.Stride;
				num10 = bitmap.Width * bitmap.Height * 4;
				array = new byte[num10 - 1 + 1];
				array2 = new byte[num10 - 1 + 1];
				Marshal.Copy(scan2, array, 0, num10);
				Marshal.Copy(scan, array2, 0, num10);
				int num11 = bitmap.Height - 2;
				for (int i = 0; i <= num11; i++)
				{
					int num12 = i * stride;
					int num13 = bitmap.Width - 2;
					for (int j = 0; j <= num13; j++)
					{
						int num14 = (int)(array[num12 + 3] - array[num12 + 3 + stride + 4]);
						if (num14 == 0)
						{
							array[num12] = 128;
						}
						else if (num14 < 0)
						{
							array[num12] = byte.MaxValue;
						}
						else if (num14 > 0)
						{
							array[num12] = 0;
						}
						num12 += 4;
					}
				}
			}
			float num15;
			if (1 < Strings.Len(this.CFX3DVar[2, 4]))
			{
				num15 = (float)(1.0 + Conversion.Val(Strings.Mid(this.CFX3DVar[2, 4], 1, checked(Strings.Len(this.CFX3DVar[2, 4]) - 1))) * 0.01);
			}
			else
			{
				num15 = 1f;
			}
			if (num15 < 1f)
			{
				num15 = 1f;
			}
			if (1.5 < (double)num15)
			{
				num15 = 1.5f;
			}
			num15 = 1f + (num15 - 1f) * 16f;
			float num16;
			if (1 < Strings.Len(this.CFX3DVar[2, 3]))
			{
				num16 = (float)(Conversion.Val(Strings.Mid(this.CFX3DVar[2, 3], 1, checked(Strings.Len(this.CFX3DVar[2, 3]) - 1))) * 0.01);
			}
			else
			{
				num16 = 0.4f;
			}
			if (num16 == 0f)
			{
				num16 = 0.8f;
			}
			float num17 = 1f - num16;
			checked
			{
				int num18 = bitmap.Height - 2;
				int num12;
				int num20;
				for (int k = 2; k <= num18; k++)
				{
					num12 = k * stride + 8;
					int num19 = bitmap.Width - 2;
					for (int l = 2; l <= num19; l++)
					{
						array[num12] = (byte)Math.Round((double)(unchecked((float)num20 * num16 + (float)array[num12] * num17)));
						num20 = (int)array[num12];
						num12 += 4;
					}
				}
				int num21 = (bitmap.Width - 2) * 4;
				int num22 = bitmap.Height - 2;
				for (int m = 2; m <= num22; m++)
				{
					num12 = m * stride + num21;
					for (int n = bitmap.Width - 2; n >= 2; n += -1)
					{
						array[num12] = (byte)Math.Round((double)(unchecked((float)num20 * num16 + (float)array[num12] * num17)));
						num20 = (int)array[num12];
						num12 -= 4;
					}
				}
				int num23 = bitmap.Width - 2;
				for (int num24 = 2; num24 <= num23; num24++)
				{
					num12 = 2 * stride + num24 * 4;
					int num25 = bitmap.Height - 2;
					for (int num26 = 2; num26 <= num25; num26++)
					{
						array[num12] = (byte)Math.Round((double)(unchecked((float)num20 * num16 + (float)array[num12] * num17)));
						num20 = (int)array[num12];
						num12 += stride;
					}
				}
				num21 = (bitmap.Height - 2) * stride;
				int num27 = bitmap.Width - 2;
				for (int num28 = 2; num28 <= num27; num28++)
				{
					num12 = num21 + num28 * 4;
					for (int num29 = bitmap.Height - 2; num29 >= 2; num29 += -1)
					{
						array[num12] = (byte)Math.Round((double)(unchecked((float)num20 * num16 + (float)array[num12] * num17)));
						num20 = (int)array[num12];
						num12 -= stride;
					}
				}
				num12 = 0;
				int num30 = num10 - 1;
				for (int num31 = 0; num31 <= num30; num31 += 4)
				{
					int num32 = (int)Math.Round((double)(unchecked((float)array[num12] * num15)));
					if (255 < num32)
					{
						num32 = 255;
					}
					array[num12] = (byte)num32;
					array2[num12] = (byte)Math.Round(unchecked((double)array2[num12] * ((double)array[num12] / 255.0)));
					array2[num12 + 1] = (byte)Math.Round(unchecked((double)array2[checked(num12 + 1)] * ((double)array[num12] / 255.0)));
					array2[num12 + 2] = (byte)Math.Round(unchecked((double)array2[checked(num12 + 2)] * ((double)array[num12] / 255.0)));
					num12 += 4;
				}
				Marshal.Copy(array2, 0, scan, num10);
				bitmap.UnlockBits(bitmapData2);
				BM.UnlockBits(bitmapData);
				Application.DoEvents();
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000177BC File Offset: 0x000159BC
		private void FX_BlurRect(ref byte[] rgbValues, int Stride, float BlurAmount, float BlurBias, int Left, int Top, int Width, int Height)
		{
			float num = 1f - BlurAmount;
			checked
			{
				if (this.pbStats.Width >= Left && this.pbStats.Height >= Top)
				{
					if (Left < 0)
					{
						Left = 0;
					}
					if (Top < 0)
					{
						Top = 0;
					}
					if (this.pbStats.Width < Left + Width)
					{
						Width = this.pbStats.Width - Left;
					}
					if (this.pbStats.Height < Top + Height)
					{
						Height = this.pbStats.Height - Top;
					}
					int num2 = Left * 4;
					int num3 = Top;
					int num4 = Top + Height - 1;
					int num8;
					int num9;
					int num10;
					int num11;
					for (int i = num3; i <= num4; i++)
					{
						int num5 = i * Stride + num2;
						int num6 = Left;
						int num7 = Left + Width - 1;
						for (int j = num6; j <= num7; j++)
						{
							rgbValues[num5] = (byte)Math.Round((double)(unchecked((float)num8 * BlurAmount + (float)rgbValues[num5] * num)));
							num8 = (int)rgbValues[num5];
							rgbValues[num5 + 1] = (byte)Math.Round((double)(unchecked((float)num9 * BlurAmount + (float)rgbValues[checked(num5 + 1)] * num)));
							num9 = (int)rgbValues[num5 + 1];
							rgbValues[num5 + 2] = (byte)Math.Round((double)(unchecked((float)num10 * BlurAmount + (float)rgbValues[checked(num5 + 2)] * num)));
							num10 = (int)rgbValues[num5 + 2];
							rgbValues[num5 + 3] = (byte)Math.Round((double)(unchecked((float)num11 * BlurAmount + (float)rgbValues[checked(num5 + 3)] * num)));
							num11 = (int)rgbValues[num5 + 3];
							num5 += 4;
						}
					}
					num2 = (Left + Width - 1) * 4;
					int num12 = Top;
					int num13 = Top + Height - 1;
					for (int k = num12; k <= num13; k++)
					{
						int num5 = k * Stride + num2;
						int num14 = Left + Width - 1;
						int num15 = Left;
						for (int l = num14; l >= num15; l += -1)
						{
							rgbValues[num5] = (byte)Math.Round((double)(unchecked((float)num8 * BlurAmount + (float)rgbValues[num5] * num)));
							num8 = (int)rgbValues[num5];
							rgbValues[num5 + 1] = (byte)Math.Round((double)(unchecked((float)num9 * BlurAmount + (float)rgbValues[checked(num5 + 1)] * num)));
							num9 = (int)rgbValues[num5 + 1];
							rgbValues[num5 + 2] = (byte)Math.Round((double)(unchecked((float)num10 * BlurAmount + (float)rgbValues[checked(num5 + 2)] * num)));
							num10 = (int)rgbValues[num5 + 2];
							rgbValues[num5 + 3] = (byte)Math.Round((double)(unchecked((float)num11 * BlurAmount + (float)rgbValues[checked(num5 + 3)] * num)));
							num11 = (int)rgbValues[num5 + 3];
							num5 -= 4;
						}
					}
					num2 = Stride * Top;
					int num16 = Left;
					int num17 = Left + Width - 1;
					for (int m = num16; m <= num17; m++)
					{
						int num5 = num2 + m * 4;
						int num18 = Top;
						int num19 = Top + Height - 1;
						for (int n = num18; n <= num19; n++)
						{
							rgbValues[num5] = (byte)Math.Round((double)(unchecked((float)num8 * BlurAmount + (float)rgbValues[num5] * num)));
							num8 = (int)rgbValues[num5];
							rgbValues[num5 + 1] = (byte)Math.Round((double)(unchecked((float)num9 * BlurAmount + (float)rgbValues[checked(num5 + 1)] * num)));
							num9 = (int)rgbValues[num5 + 1];
							rgbValues[num5 + 2] = (byte)Math.Round((double)(unchecked((float)num10 * BlurAmount + (float)rgbValues[checked(num5 + 2)] * num)));
							num10 = (int)rgbValues[num5 + 2];
							rgbValues[num5 + 3] = (byte)Math.Round((double)(unchecked((float)num11 * BlurAmount + (float)rgbValues[checked(num5 + 3)] * num)));
							num11 = (int)rgbValues[num5 + 3];
							num5 += Stride;
						}
					}
					num2 = Stride * (Top + Height - 1);
					int num20 = Left;
					int num21 = Left + Width - 1;
					for (int num22 = num20; num22 <= num21; num22++)
					{
						int num5 = num2 + num22 * 4;
						int num23 = Top + Height - 1;
						int num24 = Top;
						for (int num25 = num23; num25 >= num24; num25 += -1)
						{
							int num26 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num8 * BlurAmount + (float)rgbValues[num5] * num) * BlurBias)));
							if (255 < num26)
							{
								num26 = 255;
							}
							rgbValues[num5] = (byte)num26;
							num8 = (int)rgbValues[num5];
							num26 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num9 * BlurAmount + (float)rgbValues[checked(num5 + 1)] * num) * BlurBias)));
							if (255 < num26)
							{
								num26 = 255;
							}
							rgbValues[num5 + 1] = (byte)num26;
							num9 = (int)rgbValues[num5 + 1];
							num26 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num10 * BlurAmount + (float)rgbValues[checked(num5 + 2)] * num) * BlurBias)));
							if (255 < num26)
							{
								num26 = 255;
							}
							rgbValues[num5 + 2] = (byte)num26;
							num10 = (int)rgbValues[num5 + 2];
							num26 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num11 * BlurAmount + (float)rgbValues[checked(num5 + 3)] * num) * BlurBias)));
							if (255 < num26)
							{
								num26 = 255;
							}
							rgbValues[num5 + 3] = (byte)num26;
							num11 = (int)rgbValues[num5 + 3];
							num5 -= Stride;
						}
					}
				}
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00017C3C File Offset: 0x00015E3C
		private void FX_BlurRect_Old(ref byte[] rgbValues, int Stride, float BlurAmount, float BlurBias, int Left, int Top, int Width, int Height)
		{
			float num = 1f - BlurAmount;
			checked
			{
				int num2 = Top + Height - 1;
				int num7;
				int num8;
				int num9;
				int num10;
				for (int i = Top; i <= num2; i++)
				{
					int num3 = i * Stride;
					int num4 = Left + Width - 1;
					for (int j = Left; j <= num4; j++)
					{
						int num5 = num3 + j * 4;
						int num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num7 * BlurAmount + (float)rgbValues[num5] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5] = (byte)num6;
						num7 = (int)rgbValues[num5];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num8 * BlurAmount + (float)rgbValues[checked(num5 + 1)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 1] = (byte)num6;
						num8 = (int)rgbValues[num5 + 1];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num9 * BlurAmount + (float)rgbValues[checked(num5 + 2)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 2] = (byte)num6;
						num9 = (int)rgbValues[num5 + 2];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num10 * BlurAmount + (float)rgbValues[checked(num5 + 3)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 3] = (byte)num6;
						num10 = (int)rgbValues[num5 + 3];
					}
				}
				int num11 = Top + Height - 1;
				for (int k = Top; k <= num11; k++)
				{
					int num3 = k * Stride;
					for (int l = Left + Width - 1; l >= Left; l += -1)
					{
						int num5 = num3 + l * 4;
						int num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num7 * BlurAmount + (float)rgbValues[num5] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5] = (byte)num6;
						num7 = (int)rgbValues[num5];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num8 * BlurAmount + (float)rgbValues[checked(num5 + 1)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 1] = (byte)num6;
						num8 = (int)rgbValues[num5 + 1];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num9 * BlurAmount + (float)rgbValues[checked(num5 + 2)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 2] = (byte)num6;
						num9 = (int)rgbValues[num5 + 2];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num10 * BlurAmount + (float)rgbValues[checked(num5 + 3)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 3] = (byte)num6;
						num10 = (int)rgbValues[num5 + 3];
					}
				}
				int num12 = Left + Width - 1;
				for (int m = Left; m <= num12; m++)
				{
					int num13 = Top + Height - 1;
					for (int n = Top; n <= num13; n++)
					{
						int num3 = n * Stride;
						int num5 = num3 + m * 4;
						int num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num7 * BlurAmount + (float)rgbValues[num5] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5] = (byte)num6;
						num7 = (int)rgbValues[num5];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num8 * BlurAmount + (float)rgbValues[checked(num5 + 1)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 1] = (byte)num6;
						num8 = (int)rgbValues[num5 + 1];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num9 * BlurAmount + (float)rgbValues[checked(num5 + 2)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 2] = (byte)num6;
						num9 = (int)rgbValues[num5 + 2];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num10 * BlurAmount + (float)rgbValues[checked(num5 + 3)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 3] = (byte)num6;
						num10 = (int)rgbValues[num5 + 3];
					}
				}
				int num14 = Left + Width - 1;
				for (int num15 = Left; num15 <= num14; num15++)
				{
					for (int num16 = Top + Height - 1; num16 >= Top; num16 += -1)
					{
						int num3 = num16 * Stride;
						int num5 = num3 + num15 * 4;
						int num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num7 * BlurAmount + (float)rgbValues[num5] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5] = (byte)num6;
						num7 = (int)rgbValues[num5];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num8 * BlurAmount + (float)rgbValues[checked(num5 + 1)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 1] = (byte)num6;
						num8 = (int)rgbValues[num5 + 1];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num9 * BlurAmount + (float)rgbValues[checked(num5 + 2)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 2] = (byte)num6;
						num9 = (int)rgbValues[num5 + 2];
						num6 = (int)Math.Round((double)(unchecked(Conversion.Int((float)num10 * BlurAmount + (float)rgbValues[checked(num5 + 3)] * num) * BlurBias)));
						if (255 < num6)
						{
							num6 = 255;
						}
						rgbValues[num5 + 3] = (byte)num6;
						num10 = (int)rgbValues[num5 + 3];
					}
				}
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00018188 File Offset: 0x00016388
		private void cmTestData_Click(object sender, EventArgs e)
		{
			checked
			{
				if (Interaction.MsgBox("Selecting this button will place worst case scenario data on the stats page to test your setup.\r\r" + "Steam names are usually limited to 32 characters.\r" + "Ranks are usually limited to 5 digits.\r\r" + "Do you wish to continue?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, null) != MsgBoxResult.No)
				{
					int num = 1;
					do
					{
						this.PlrName[num] = "12345678901234567890123456789012";
						this.PlrRank[num] = "88888";
						num++;
					}
					while (num <= 8);
					this.PlrFact[1] = "01";
					this.PlrFact[2] = "02";
					this.PlrFact[3] = "03";
					this.PlrFact[4] = "04";
					this.PlrFact[5] = "01";
					this.PlrFact[6] = "02";
					this.PlrFact[7] = "03";
					this.PlrFact[8] = "05";
					this.GFX_DrawStats();
				}
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00009B4B File Offset: 0x00007D4B
		private void pbStats_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00018258 File Offset: 0x00016458
		private void pbStats_MouseDown(object sender, MouseEventArgs e)
		{
			int num = 1;
			int num2;
			while (!(this.LAB_Name[num].Y < (float)e.Y & (float)e.Y < this.LAB_Name[num].Y + this.LAB_Name[num].Height) || !(this.LAB_Name[num].X < (float)e.X & (float)e.X < this.LAB_Name[num].X + this.LAB_Name[num].Width))
			{
				checked
				{
					num++;
					if (num > 8)
					{
						IL_A3:
						if (!(num2 == 0 | Operators.CompareString(this.PlrSteam[num2], "", false) == 0))
						{
							if (this.Celo_Popup & e.Button == MouseButtons.Right)
							{
								this.Celo_PopupHit = num2;
								this.tsmPlayer.Show(this.pbStats, new Point(e.X, e.Y));
								return;
							}
							string left = "None";
							if (Keys.None < (Control.ModifierKeys & Keys.Control))
							{
								left = "Ctrl";
							}
							if (Keys.None < (Control.ModifierKeys & Keys.Shift))
							{
								left = "Shift";
							}
							if (e.Button == MouseButtons.Left & Operators.CompareString(this.PlrSteam[num], "", false) != 0)
							{
								if (Operators.CompareString(left, "None", false) != 0)
								{
									if (Operators.CompareString(left, "Ctrl", false) != 0)
									{
										if (Operators.CompareString(left, "Shift", false) == 0)
										{
											Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + this.PlrSteam[num2]);
										}
									}
									else if (Operators.CompareString(this.PlrName[num2], "", false) != 0)
									{
										Process.Start("https://translate.google.com/#view=home&op=translate&sl=auto&tl=en&text=" + this.PlrName[num2]);
									}
								}
								else
								{
									Process.Start("http://www.companyofheroes.com/leaderboards#profile/steam/" + this.PlrSteam[num2] + "/standings");
								}
							}
							if (e.Button == MouseButtons.Right & Operators.CompareString(this.PlrSteam[num], "", false) != 0)
							{
								if (Operators.CompareString(left, "None", false) == 0)
								{
									Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/1/steamid/" + this.PlrSteam[num2]);
									return;
								}
								if (Operators.CompareString(left, "Ctrl", false) != 0)
								{
									if (Operators.CompareString(left, "Shift", false) != 0)
									{
										return;
									}
									Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + this.PlrSteam[num2]);
								}
								else
								{
									string left2 = this.PlrFact[num2];
									if (Operators.CompareString(left2, "05", false) == 0)
									{
										Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/12/steamid/" + this.PlrSteam[num2]);
										return;
									}
									if (Operators.CompareString(left2, "02", false) == 0 || Operators.CompareString(left2, "01", false) == 0)
									{
										Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/11/steamid/" + this.PlrSteam[num2]);
										return;
									}
									if (Operators.CompareString(left2, "04", false) != 0 && Operators.CompareString(left2, "03", false) != 0)
									{
										Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + this.PlrSteam[num2]);
										return;
									}
									Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/10/steamid/" + this.PlrSteam[num2]);
									return;
								}
							}
						}
						return;
					}
				}
			}
			num2 = num;
			goto IL_A3;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0001858E File Offset: 0x0001678E
		private void pbStats_MouseLeave(object sender, EventArgs e)
		{
			if (this.GUI_Active)
			{
				this.GUI_Mouse_PlrIndex = 0;
				this.GFX_DrawStats();
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000185A8 File Offset: 0x000167A8
		private void pbStats_MouseMove(object sender, MouseEventArgs e)
		{
			int gui_Mouse_PlrIndex = this.GUI_Mouse_PlrIndex;
			this.GUI_Mouse_PlrIndex = 0;
			int num = 1;
			int num2;
			while (!(this.LAB_Name[num].Y < (float)e.Y & (float)e.Y < this.LAB_Name[num].Y + this.LAB_Name[num].Height) || !(this.LAB_Name[num].X < (float)e.X & (float)e.X < this.LAB_Name[num].X + this.LAB_Name[num].Width))
			{
				checked
				{
					num++;
					if (num > 8)
					{
						IL_B1:
						if (num2 != 0)
						{
							this.GUI_Mouse_PlrIndex = num2;
							this.pbStats.Cursor = Cursors.Hand;
						}
						else
						{
							this.pbStats.Cursor = Cursors.Default;
						}
						if (this.GUI_Active && gui_Mouse_PlrIndex != this.GUI_Mouse_PlrIndex)
						{
							this.GFX_DrawStats();
						}
						return;
					}
				}
			}
			num2 = num;
			goto IL_B1;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000186AC File Offset: 0x000168AC
		private int PLR_Count()
		{
			int num = 1;
			checked
			{
				int num2;
				do
				{
					if (Operators.CompareString(this.PlrName[num], "", false) != 0)
					{
						num2++;
					}
					num++;
				}
				while (num <= 8);
				return num2;
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000186E0 File Offset: 0x000168E0
		private void cmLastMatch_Click(object sender, EventArgs e)
		{
			int num = 1;
			checked
			{
				do
				{
					this.PlrName[num] = this.PlrName_Last[num];
					this.PlrRank[num] = this.PlrRank_Last[num];
					this.PlrFact[num] = this.PlrFact_Last[num];
					this.PlrSteam[num] = this.PlrSteam_Last[num];
					num++;
				}
				while (num <= 8);
				this.GFX_DrawStats();
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00018740 File Offset: 0x00016940
		private void cmFX3DC_Click(object sender, EventArgs e)
		{
			if (!this.FLAG_Loading)
			{
				this.ColorDialog1.Color = this.CFX3DC[1];
				this.ColorDialog1.ShowDialog();
				int selectedIndex = this.cboFXVar1.SelectedIndex;
				if (0 < selectedIndex)
				{
					this.CFX3DC[selectedIndex] = this.ColorDialog1.Color;
				}
				this.GFX_DrawStats();
				this.SETTINGS_Save();
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000187AC File Offset: 0x000169AC
		private void cboFX3D_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				int selectedIndex = this.cboFXVar1.SelectedIndex;
				if (0 < selectedIndex)
				{
					this.CFX3DVar[selectedIndex, 2] = this.cboFXVar2.Text;
				}
				this.GFX_DrawStats();
				this.SETTINGS_Save();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0001880C File Offset: 0x00016A0C
		private void cboFxVar3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				int selectedIndex = this.cboFXVar1.SelectedIndex;
				if (0 < selectedIndex)
				{
					this.CFX3DVar[selectedIndex, 3] = this.cboFxVar3.Text;
				}
				this.GFX_DrawStats();
				this.SETTINGS_Save();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0001886C File Offset: 0x00016A6C
		private void cboFxVar4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				int selectedIndex = this.cboFXVar1.SelectedIndex;
				if (0 < selectedIndex)
				{
					this.CFX3DVar[selectedIndex, 4] = this.cboFxVar4.Text;
				}
				this.GFX_DrawStats();
				this.SETTINGS_Save();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000188CC File Offset: 0x00016ACC
		private void cboFXMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.FLAG_Loading)
			{
				this.FLAG_Loading = true;
				int selectedIndex = this.cboFXVar1.SelectedIndex;
				if (0 < selectedIndex)
				{
					this.cboFXVar2.Text = this.CFX3DVar[selectedIndex, 2];
					this.cboFxVar3.Text = this.CFX3DVar[selectedIndex, 3];
					this.cboFxVar4.Text = this.CFX3DVar[selectedIndex, 4];
				}
				this.GFX_UpdateScreenControls();
				this.FLAG_Loading = false;
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00018950 File Offset: 0x00016B50
		private void GFX_UpdateScreenControls()
		{
			this.FLAG_Loading = true;
			int selectedIndex = this.cboFXVar1.SelectedIndex;
			if (0 < selectedIndex)
			{
				if (this.CFX3DActive[selectedIndex])
				{
					this.chkFX.Checked = true;
				}
				else
				{
					this.chkFX.Checked = false;
				}
				if (Operators.CompareString(this.CFX3DVar[selectedIndex, 2], null, false) == 0)
				{
					this.CFX3DVar[selectedIndex, 2] = Conversions.ToString(this.cboFXVar2.Items[1]);
				}
				this.cboFXVar2.Text = this.CFX3DVar[selectedIndex, 2];
				if (Operators.CompareString(this.CFX3DVar[selectedIndex, 3], null, false) == 0)
				{
					this.CFX3DVar[selectedIndex, 3] = Conversions.ToString(this.cboFxVar3.Items[1]);
				}
				this.cboFxVar3.Text = this.CFX3DVar[selectedIndex, 3];
				if (Operators.CompareString(this.CFX3DVar[selectedIndex, 4], null, false) == 0)
				{
					this.CFX3DVar[selectedIndex, 4] = Conversions.ToString(this.cboFxVar4.Items[1]);
				}
				this.cboFxVar4.Text = this.CFX3DVar[selectedIndex, 4];
			}
			else
			{
				this.chkFX.Checked = false;
				this.cboFXVar2.Text = "";
				this.cboFxVar3.Text = "";
				this.cboFxVar4.Text = "";
			}
			this.cmFX3DC.Enabled = true;
			this.cboFXVar2.Enabled = true;
			this.cboFxVar3.Enabled = true;
			this.cboFxVar4.Enabled = true;
			string text = this.cboFXVar1.Text;
			if (Operators.CompareString(text, "None", false) != 0)
			{
				if (Operators.CompareString(text, "Shadow", false) != 0)
				{
					if (Operators.CompareString(text, "Emboss", false) != 0)
					{
						if (Operators.CompareString(text, "Lab Blur", false) == 0)
						{
							this.lbFXVar2.Text = "--";
							this.lbFXVar3.Text = "Blur Size";
							this.lbFXVar4.Text = "Bias";
							this.cmFX3DC.Enabled = false;
							this.cboFXVar2.Enabled = false;
							this.chkFX.Enabled = true;
						}
					}
					else
					{
						this.lbFXVar2.Text = "--";
						this.lbFXVar3.Text = "Blur Size";
						this.lbFXVar4.Text = "Bias";
						this.cmFX3DC.Enabled = false;
						this.cboFXVar2.Enabled = false;
						this.chkFX.Enabled = true;
					}
				}
				else
				{
					this.lbFXVar2.Text = "Color/Ang";
					this.lbFXVar3.Text = "Blur Size";
					this.lbFXVar4.Text = "Bias";
					this.chkFX.Enabled = true;
				}
			}
			else
			{
				this.lbFXVar2.Text = "--";
				this.lbFXVar3.Text = "--";
				this.lbFXVar4.Text = "--";
				this.cmFX3DC.Enabled = false;
				this.cboFXVar2.Enabled = false;
				this.cboFxVar3.Enabled = false;
				this.cboFxVar4.Enabled = false;
				this.chkFX.Enabled = false;
			}
			this.FLAG_Loading = false;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00018CB4 File Offset: 0x00016EB4
		private void cmFXModeHelp_Click(object sender, EventArgs e)
		{
			string text = "";
			string text2 = this.cboFXVar1.Text;
			if (Operators.CompareString(text2, "None", false) != 0)
			{
				if (Operators.CompareString(text2, "Shadow", false) != 0)
				{
					if (Operators.CompareString(text2, "Emboss", false) != 0)
					{
						if (Operators.CompareString(text2, "Lab Blur", false) == 0)
						{
							text = "The rectangles under the rank and player name will be blurred.\r\r";
							text += "This tries to make the text stand out from the background a little more.\r\r";
							text += "Doing this effect in an image processing progam and used as a background image could create a better image.\r\r";
							text += "Good start points are: BLUR SIZE (50%), BIAS(2.0%) and using low background opacity values.";
						}
					}
					else
					{
						text = "Emboss tries to add some 3D depth to the text on screen.  Blurring the embossed image can make the embossing larger and smoother.\r\r";
						text += "Embossing multiplies a B/W image and the normal screen. This will always darken the image. Bias Is used to brighten up the darkened image.\r\r";
						text += "Using less Blur helps create a a stronger embossing effect.\r\r";
						text += "Good start points are: BLUR SIZE (50%), BIAS(5.0%)";
					}
				}
				else
				{
					text = "Shadow places a blurred shadow under all text. This helps text pop out more. Depending on the color and angle chosen, the shadow can be dark for a deep shadow or it can be bright giving the effect of light behind the text glowing.\r\r";
					text += "Blur Size adjust how blurry the shadow is. BIAS adds some brightness and contrast to punch up a neutral shadow.\r\r";
					text += "Good start points are: BLUR SIZE (70%), BIAS(5.0%)";
				}
			}
			else
			{
				text = "No FX mode has been selected. FX setups allow for image based adjustments that may just add that cool touch to your stats text.\r\r";
				text += "Select an FX and then click the ACTIVE checkbox to add FX.\r\r";
				text += "Each added FX slows the render time. This only happens when selected and updating the stats. While editing, the GUI may feel sluggish on slower PCs.\r\r";
				text += "Click refresh to update if things get out of sync while scrolling thru options.";
			}
			Interaction.MsgBox(text, MsgBoxStyle.Information, "FX MODE HELP");
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00018DC0 File Offset: 0x00016FC0
		private void chkFX_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.FLAG_Loading)
			{
				bool @checked = this.chkFX.Checked;
				int selectedIndex = this.cboFXVar1.SelectedIndex;
				this.CFX3DActive[selectedIndex] = @checked;
				this.GFX_DrawStats();
				this.SETTINGS_Save();
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00018E0C File Offset: 0x0001700C
		private void cmSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save Stats Image";
			if (Operators.CompareString(this.PATH_SaveStatsImage, "", false) != 0)
			{
				saveFileDialog.InitialDirectory = this.PATH_SaveStatsImage;
			}
			saveFileDialog.Filter = "Png (*.png)|*.png|Gif (*.gif)|*.gif|Jpeg (*.jpg)|*.jpg";
			saveFileDialog.FilterIndex = 3;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.pbStats.Image.Save(saveFileDialog.FileName);
				}
				catch (Exception ex)
				{
					Interaction.MsgBox("ERROR:" + Information.Err().Description + "\r\rUnable to save the stats image.", MsgBoxStyle.Critical, null);
				}
				this.PATH_SaveStatsImage = saveFileDialog.FileName;
				int num = Conversions.ToInteger(this.STRING_FindLastSlash(this.PATH_SaveStatsImage));
				if (3 < num)
				{
					this.PATH_SaveStatsImage = Strings.Mid(this.PATH_SaveStatsImage, 1, num);
					return;
				}
				this.PATH_SaveStatsImage = "";
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00018F00 File Offset: 0x00017100
		private void chkMismatch_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkMismatch.Checked)
			{
				this.FLAG_ShowMismatch = true;
				return;
			}
			this.FLAG_ShowMismatch = false;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00018F20 File Offset: 0x00017120
		private void ToolTip_Setup()
		{
			this.ToolTip1.SetToolTip(this.pbStats, "Click a player name to see web pages for:\rLeft: Relic Stats\rCtrl-Left: Google Translate\rShift-Left: Coh2.org player page\rRight: Coh2.org AT stats\rCtrl-Right: Coh2.org faction page");
			this.ToolTip1.SetToolTip(this.pbNote1, "NOTE #1: Used to display stream based information using animated text options.");
			this.ToolTip1.SetToolTip(this.pbNote2, "NOTE #2: Used to display stream based information using animated text options.");
			this.ToolTip1.SetToolTip(this.pbNote3, "NOTE #3: Used to display stream based information using animated text options.");
			this.ToolTip1.SetToolTip(this.pbNote4, "NOTE #4: Used to display stream based information using animated text options.");
			this.ToolTip1.SetToolTip(this.tbXsize, "Set the Width in pixels of the STATS image.");
			this.ToolTip1.SetToolTip(this.tbYSize, "Set the Height in pixels of the STATS image.\rBest results if Y is divisible by 4.");
			this.ToolTip1.SetToolTip(this.tbXoff, "Adjust the stats value positions within the STATS image.");
			this.ToolTip1.SetToolTip(this.tbYoff, "Adjust the stats value positions within the STATS image.");
			this.ToolTip1.SetToolTip(this.cmDefaults, "Set all STATS size options to their default values.");
			this.ToolTip1.SetToolTip(this.cmStatsModeHelp, "Simple help info for the STATS setup options.");
			this.ToolTip1.SetToolTip(this.cmFindLog, "Locate the log file this program uses to show match stats.");
			this.ToolTip1.SetToolTip(this.cmCheckLog, "Force a one time only reading of the match stats log file.");
			this.ToolTip1.SetToolTip(this.cmScanLog, "Toggle ON or OFF a timer that reads the log file every 10s.");
			this.ToolTip1.SetToolTip(this.cmRankSetup, "Setup the Celo RANK font and colors.");
			this.ToolTip1.SetToolTip(this.cmNameSetup, "Setup the Celo Player NAME font, colors, background and overlay image.");
			this.ToolTip1.SetToolTip(this.cmNote01Setup, "Setup the Note 1 font, colors, size, and background image.");
			this.ToolTip1.SetToolTip(this.cmNote02Setup, "Setup the Note 2 font, colors, size, and background image.");
			this.ToolTip1.SetToolTip(this.cmNote03Setup, "Setup the Note 3 font, colors, size, and background image.");
			this.ToolTip1.SetToolTip(this.cmNote04Setup, "Setup the Note 4 font, colors, size, and background image.");
			this.ToolTip1.SetToolTip(this.cmNote1, "Setup the Note 1 text and animation mode.");
			this.ToolTip1.SetToolTip(this.cmNote2, "Setup the Note 2 text and animation mode.");
			this.ToolTip1.SetToolTip(this.cmNote3, "Setup the Note 3 text and animation mode.");
			this.ToolTip1.SetToolTip(this.cmNote4, "Setup the Note 4 text and animation mode.");
			this.ToolTip1.SetToolTip(this.cmNote_PlayAll, "Toggle on/off all Animation play buttons.");
			this.ToolTip1.SetToolTip(this.cmNote01_Play, "Toggle on/off note 1 Animations.");
			this.ToolTip1.SetToolTip(this.cmNote02_Play, "Toggle on/off note 2 Animations.");
			this.ToolTip1.SetToolTip(this.cmNote03_Play, "Toggle on/off note 3 Animations.");
			this.ToolTip1.SetToolTip(this.cmNote04_Play, "Toggle on/off note 4 Animations.");
			string caption = "Left click to play a sound.\rRight click to map a sound or set the volume.\rCtrl-Click to delete.";
			this.ToolTip1.SetToolTip(this.cmSound01, caption);
			this.ToolTip1.SetToolTip(this.cmSound02, caption);
			this.ToolTip1.SetToolTip(this.cmSound03, caption);
			this.ToolTip1.SetToolTip(this.cmSound04, caption);
			this.ToolTip1.SetToolTip(this.cmSound05, caption);
			this.ToolTip1.SetToolTip(this.cmSound06, caption);
			this.ToolTip1.SetToolTip(this.cmSound07, caption);
			this.ToolTip1.SetToolTip(this.cmSound08, caption);
			this.ToolTip1.SetToolTip(this.cmSound09, caption);
			this.ToolTip1.SetToolTip(this.cmSound10, caption);
			this.ToolTip1.SetToolTip(this.cmSound11, caption);
			this.ToolTip1.SetToolTip(this.cmSound12, caption);
			this.ToolTip1.SetToolTip(this.cmSound13, caption);
			this.ToolTip1.SetToolTip(this.cmSound14, caption);
			this.ToolTip1.SetToolTip(this.cmSound15, caption);
			this.ToolTip1.SetToolTip(this.scrVolume, "Adjust the sound volume for this program.");
			this.ToolTip1.SetToolTip(this.cmAudioStop, "STOP playing the current sound.");
			this.ToolTip1.SetToolTip(this.cmCopy, "Copy the stats page to the clipboard to be pasted in another program.");
			this.ToolTip1.SetToolTip(this.cmSave, "Save a copy of the stats page to the PC. Good to use as a template in custom backgrounds.");
			this.ToolTip1.SetToolTip(this.cboLayoutY, "Set the Y axis orientation of the printed stats.");
			this.ToolTip1.SetToolTip(this.cboLayoutX, "Set the X axis orientation of the printed stats.");
			this.ToolTip1.SetToolTip(this.cboNoteSpace, "Set a border space around NOTES. Set to 0 to use them as a single graphic.");
			this.ToolTip1.SetToolTip(this.cmSizeRefresh, "Force a redraw of the stats page. Useful when changing sizes or editing a page using a lot of FX.");
			this.ToolTip1.SetToolTip(this.cmGUILite, "Set the program color scheme to Light. Helps when cropping in your streaming app.");
			this.ToolTip1.SetToolTip(this.cmGUIDark, "Set the program color scheme to Dark. Helps when cropping in your streaming app.");
			this.ToolTip1.SetToolTip(this.cboFXVar1, "Select a stats page FX item to edit or make active.");
			this.ToolTip1.SetToolTip(this.chkFX, "Toggles the currently selected FX mode to ON or OFF.");
			this.ToolTip1.SetToolTip(this.cmFX3DC, "Select a color to be used in the selected FX.");
			this.ToolTip1.SetToolTip(this.cboFXVar2, "Select an ANGLE to be used in the selected FX.");
			this.ToolTip1.SetToolTip(this.cboFxVar3, "Adjusts an FX setting for the selected FX.");
			this.ToolTip1.SetToolTip(this.cboFxVar4, "Adjusts an FX setting for the selected FX.");
			this.ToolTip1.SetToolTip(this.cmFXModeHelp, "Get FX mode specific help.");
			this.ToolTip1.SetToolTip(this.chkMismatch, "Always show data good or bad. Replay data is missing information, set this to see replay data.");
			this.ToolTip1.SetToolTip(this.chkPopUp, "Toggle the context popup menu on the stats page that shows additional player info on the web.");
			this.ToolTip1.SetToolTip(this.chkPosition, "Store the current window size and position on the screen.");
			this.ToolTip1.SetToolTip(this.chkSmoothAni, "Try to smooth animations by redrawing whole window (10x CPU usage).");
			this.ToolTip1.SetToolTip(this.cmLastMatch, "Display the last valid match found since this program has been running.");
			this.ToolTip1.SetToolTip(this.cmTestData, "Test your current setup by filling the stats page\rwith the largest values you may see in a COH2 match.");
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000194B9 File Offset: 0x000176B9
		private void chkTips_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkTips.Checked)
			{
				this.ToolTip1.Active = true;
				return;
			}
			this.ToolTip1.Active = false;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000194E4 File Offset: 0x000176E4
		private void NOTE_Animation_Setup(ref clsGlobal.t_NoteAnimation NoteAnim, ref PictureBox pbNote, ref Font tFont, ref string[] Note_Text, ref string[] NoteAnim_Text)
		{
			Bitmap bitmap = new Bitmap(pbNote.Width, pbNote.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			bool active = false;
			NoteAnim.TimeAcc = 0L;
			NoteAnim.Holding = false;
			switch (NoteAnim.Mode)
			{
			case 0:
			{
				double num = Conversion.Val(NoteAnim.Align);
				if (num == 0.0)
				{
					NoteAnim.X = 0f;
					NoteAnim.Xstart = 0f;
				}
				else if (num == 1.0)
				{
					NoteAnim.X = (float)((double)pbNote.Width / 2.0);
					NoteAnim.Xstart = NoteAnim.X;
				}
				else if (num == 2.0)
				{
					NoteAnim.X = (float)pbNote.Width;
					NoteAnim.Xstart = NoteAnim.X;
				}
				NoteAnim.Yend = (float)((double)pbNote.Height / 2.0 - (double)(graphics.MeasureString("H", tFont).Height / 2f));
				NoteAnim.Ystart = NoteAnim.Yend;
				NoteAnim.Y = NoteAnim.Yend;
				NoteAnim.Ydir = -2f;
				NoteAnim.TextCount = 1;
				NoteAnim.TextCurrent = 1;
				Note_Text[1] = NoteAnim_Text[1];
				if (Operators.CompareString(Note_Text[1], "", false) != 0)
				{
					active = true;
				}
				break;
			}
			case 1:
			{
				string str = "";
				int num2 = 1;
				checked
				{
					int num3;
					do
					{
						if (Operators.CompareString(Strings.Trim(NoteAnim_Text[num2]), "", false) != 0)
						{
							num3++;
						}
						num2++;
					}
					while (num2 <= 10);
					if (1 < num3)
					{
						str = NoteAnim.Delim;
					}
					Note_Text[1] = "";
					int num4 = 1;
					do
					{
						if (Operators.CompareString(Strings.Trim(NoteAnim_Text[num4]), "", false) != 0)
						{
							Note_Text[1] = Note_Text[1] + NoteAnim_Text[num4] + str;
							active = true;
						}
						num4++;
					}
					while (num4 <= 10);
					NoteAnim.Xstart = (float)pbNote.Width;
					NoteAnim.X = NoteAnim.Xstart;
					NoteAnim.Xend = unchecked(0f - graphics.MeasureString(Note_Text[1], tFont).Width);
					NoteAnim.Xdir = (float)(NoteAnim.Speed * -1);
					NoteAnim.Ystart = 0f;
				}
				NoteAnim.Y = (float)((double)pbNote.Height / 2.0 - (double)(graphics.MeasureString("H", tFont).Height / 2f));
				NoteAnim.TextCount = 1;
				NoteAnim.TextCurrent = 1;
				break;
			}
			case 2:
			{
				double num5 = Conversion.Val(NoteAnim.Align);
				if (num5 == 0.0)
				{
					NoteAnim.X = 0f;
					NoteAnim.Xstart = 0f;
				}
				else if (num5 == 1.0)
				{
					NoteAnim.X = (float)((double)pbNote.Width / 2.0);
					NoteAnim.Xstart = NoteAnim.X;
				}
				else if (num5 == 2.0)
				{
					NoteAnim.X = (float)pbNote.Width;
					NoteAnim.Xstart = NoteAnim.X;
				}
				NoteAnim.Ystart = (float)pbNote.Height;
				NoteAnim.Y = NoteAnim.Ystart;
				NoteAnim.Yend = (float)((double)pbNote.Height / 2.0 - (double)(graphics.MeasureString("H", tFont).Height / 2f));
				checked
				{
					NoteAnim.Ydir = (float)(NoteAnim.Speed * -1);
					NoteAnim.TimeHold = NoteAnim.TimeHold;
					NoteAnim.TextCurrent = 1;
					NoteAnim.TextCount = 0;
					int num6 = 1;
					do
					{
						if (Operators.CompareString(Strings.Trim(NoteAnim_Text[num6]), "", false) != 0)
						{
							Note_Text[num6] = NoteAnim_Text[num6];
							ref int ptr = ref NoteAnim.TextCount;
							NoteAnim.TextCount = ptr + 1;
							active = true;
						}
						num6++;
					}
					while (num6 <= 10);
					break;
				}
			}
			case 3:
			{
				double num7 = Conversion.Val(NoteAnim.Align);
				if (num7 == 0.0)
				{
					NoteAnim.X = 0f;
					NoteAnim.Xstart = 0f;
				}
				else if (num7 == 1.0)
				{
					NoteAnim.X = (float)((double)pbNote.Width / 2.0);
					NoteAnim.Xstart = NoteAnim.X;
				}
				else if (num7 == 2.0)
				{
					NoteAnim.X = (float)pbNote.Width;
					NoteAnim.Xstart = NoteAnim.X;
				}
				NoteAnim.Ystart = (float)(0.0 - (double)graphics.MeasureString("H", tFont).Height * 1.1);
				NoteAnim.Y = NoteAnim.Ystart;
				NoteAnim.Yend = (float)((double)pbNote.Height / 2.0 - (double)(graphics.MeasureString("H", tFont).Height / 2f));
				checked
				{
					NoteAnim.Ydir = (float)(NoteAnim.Speed * 1);
					NoteAnim.TimeHold = NoteAnim.TimeHold;
					NoteAnim.TextCurrent = 1;
					NoteAnim.TextCount = 0;
					int num8 = 1;
					do
					{
						if (Operators.CompareString(Strings.Trim(NoteAnim_Text[num8]), "", false) != 0)
						{
							Note_Text[num8] = NoteAnim_Text[num8];
							ref int ptr = ref NoteAnim.TextCount;
							NoteAnim.TextCount = ptr + 1;
							active = true;
						}
						num8++;
					}
					while (num8 <= 10);
					break;
				}
			}
			case 4:
			{
				double num9 = Conversion.Val(NoteAnim.Align);
				if (num9 == 0.0)
				{
					NoteAnim.X = 0f;
					NoteAnim.Xstart = 0f;
				}
				else if (num9 == 1.0)
				{
					NoteAnim.X = (float)((double)pbNote.Width / 2.0);
					NoteAnim.Xstart = NoteAnim.X;
				}
				else if (num9 == 2.0)
				{
					NoteAnim.X = (float)pbNote.Width;
					NoteAnim.Xstart = NoteAnim.X;
				}
				NoteAnim.Ystart = 0f;
				NoteAnim.Y = (float)((double)pbNote.Height / 2.0 - (double)(graphics.MeasureString("H", tFont).Height / 2f));
				NoteAnim.Yend = 255f;
				checked
				{
					NoteAnim.Ydir = (float)(NoteAnim.Speed * 1);
					NoteAnim.TimeHold = NoteAnim.TimeHold;
					NoteAnim.TextCurrent = 1;
					NoteAnim.TextCount = 0;
					int num10 = 1;
					do
					{
						if (Operators.CompareString(Strings.Trim(NoteAnim_Text[num10]), "", false) != 0)
						{
							Note_Text[num10] = NoteAnim_Text[num10];
							ref int ptr = ref NoteAnim.TextCount;
							NoteAnim.TextCount = ptr + 1;
							active = true;
						}
						num10++;
					}
					while (num10 <= 10);
					break;
				}
			}
			case 5:
			{
				double num11 = Conversion.Val(NoteAnim.Align);
				if (num11 == 0.0)
				{
					NoteAnim.X = 0f;
					NoteAnim.Xstart = 0f;
				}
				else if (num11 == 1.0)
				{
					NoteAnim.X = (float)((double)pbNote.Width / 2.0);
					NoteAnim.Xstart = NoteAnim.X;
				}
				else if (num11 == 2.0)
				{
					NoteAnim.X = (float)pbNote.Width;
					NoteAnim.Xstart = NoteAnim.X;
				}
				NoteAnim.Ystart = (float)pbNote.Height;
				NoteAnim.Y = NoteAnim.Ystart;
				NoteAnim.Yend = 0f - graphics.MeasureString("H", tFont).Height;
				checked
				{
					NoteAnim.Ydir = (float)(NoteAnim.Speed * -1);
					NoteAnim.TimeHold = 0L;
					NoteAnim.TextCurrent = 1;
					NoteAnim.TextCount = 0;
					int num12 = 1;
					do
					{
						if (Operators.CompareString(Strings.Trim(NoteAnim_Text[num12]), "", false) != 0)
						{
							Note_Text[num12] = NoteAnim_Text[num12];
							ref int ptr = ref NoteAnim.TextCount;
							NoteAnim.TextCount = ptr + 1;
							active = true;
						}
						num12++;
					}
					while (num12 <= 10);
					break;
				}
			}
			}
			NoteAnim.Active = active;
			graphics.Dispose();
			bitmap.Dispose();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00019CE8 File Offset: 0x00017EE8
		private void timNote1_Tick(object sender, EventArgs e)
		{
			if (this.ANIMATION_Smooth)
			{
				base.Invalidate();
				return;
			}
			if (Operators.CompareString(this.cmNote01_Play.Text, "||", false) == 0 & this.NoteAnim01.Active)
			{
				PictureBox pictureBox = this.pbNote1;
				this.NOTE_Animate(ref pictureBox, ref this.Note01_Text, ref frmMain.LSNote01, ref frmMain.FONT_Note01, ref this.NoteAnim01, ref this.Note01_Bmp, ref this.Note01_Gfx, ref frmMain.Note01_BackBmp, ref frmMain.Note01_OVLBmp);
				this.pbNote1 = pictureBox;
			}
			if (Operators.CompareString(this.cmNote02_Play.Text, "||", false) == 0 & this.NoteAnim02.Active)
			{
				PictureBox pictureBox = this.pbNote2;
				this.NOTE_Animate(ref pictureBox, ref this.Note02_Text, ref frmMain.LSNote02, ref frmMain.FONT_Note02, ref this.NoteAnim02, ref this.Note02_Bmp, ref this.Note02_Gfx, ref frmMain.Note02_BackBmp, ref frmMain.Note02_OVLBmp);
				this.pbNote2 = pictureBox;
			}
			if (Operators.CompareString(this.cmNote03_Play.Text, "||", false) == 0 & this.NoteAnim03.Active)
			{
				PictureBox pictureBox = this.pbNote3;
				this.NOTE_Animate(ref pictureBox, ref this.Note03_Text, ref frmMain.LSNote03, ref frmMain.FONT_Note03, ref this.NoteAnim03, ref this.Note03_Bmp, ref this.Note03_Gfx, ref frmMain.Note03_BackBmp, ref frmMain.Note03_OVLBmp);
				this.pbNote3 = pictureBox;
			}
			if (Operators.CompareString(this.cmNote04_Play.Text, "||", false) == 0 & this.NoteAnim04.Active)
			{
				PictureBox pictureBox = this.pbNote4;
				this.NOTE_Animate(ref pictureBox, ref this.Note04_Text, ref frmMain.LSNote04, ref frmMain.FONT_Note04, ref this.NoteAnim04, ref this.Note04_Bmp, ref this.Note04_Gfx, ref frmMain.Note04_BackBmp, ref frmMain.Note04_OVLBmp);
				this.pbNote4 = pictureBox;
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00019EA8 File Offset: 0x000180A8
		private void NOTE_Animate(ref PictureBox pbNote, ref string[] Note, ref clsGlobal.t_LabelSetup LSNote, ref Font tFont, ref clsGlobal.t_NoteAnimation NoteAnim, ref Bitmap BM, ref Graphics Gfx, ref Bitmap BackBmp, ref Bitmap OVLBmp)
		{
			StringFormat stringFormat = new StringFormat();
			SolidBrush brush;
			int num4;
			checked
			{
				if (BackBmp != null)
				{
					double num = Conversion.Val(LSNote.Scaling);
					if (num == 0.0)
					{
						Gfx.DrawImage(BackBmp, 0, 0, BackBmp.Width, BackBmp.Height);
					}
					else if (num == 1.0)
					{
						int height = BM.Height;
						int height2 = BackBmp.Height;
						int num2 = 0;
						while ((height2 >> 31 ^ num2) <= (height2 >> 31 ^ height))
						{
							int width = BM.Width;
							int width2 = BackBmp.Width;
							int num3 = 0;
							while ((width2 >> 31 ^ num3) <= (width2 >> 31 ^ width))
							{
								Gfx.DrawImage(BackBmp, num3, num2, BackBmp.Width, BackBmp.Height);
								num3 += width2;
							}
							num2 += height2;
						}
					}
					else if (num == 2.0)
					{
						Gfx.DrawImage(BackBmp, 0, 0, BM.Width, BM.Height);
					}
				}
				brush = new SolidBrush(LSNote.ShadowColor);
				new SolidBrush(LSNote.F1);
				if (NoteAnim.Mode == 4)
				{
					brush = new SolidBrush(Color.FromArgb((int)Math.Round((double)NoteAnim.Ystart), LSNote.ShadowColor));
				}
				else
				{
					brush = new SolidBrush(LSNote.ShadowColor);
				}
				num4 = (int)Math.Round((double)(Gfx.MeasureString("H", tFont).Height / 2f));
				LinearGradientBrush brush2;
				if (LSNote.BDir == 0)
				{
					brush2 = new LinearGradientBrush(new Point(0, 0), new Point(0, pbNote.Height), LSNote.B1, LSNote.B2);
				}
				else
				{
					brush2 = new LinearGradientBrush(new Point(0, 0), new Point(pbNote.Width, 0), LSNote.B1, LSNote.B2);
				}
				Gfx.FillRectangle(brush2, 0, 0, pbNote.Width, pbNote.Height);
			}
			if (!NoteAnim.Holding)
			{
				switch (NoteAnim.Mode)
				{
				case 0:
				case 2:
				case 5:
				{
					ref float ptr = ref NoteAnim.Y;
					NoteAnim.Y = ptr + NoteAnim.Ydir;
					if (NoteAnim.Y <= NoteAnim.Yend)
					{
						NoteAnim.Y = NoteAnim.Yend;
					}
					break;
				}
				case 1:
				{
					ref float ptr = ref NoteAnim.X;
					NoteAnim.X = ptr + NoteAnim.Xdir;
					break;
				}
				case 3:
				{
					ref float ptr = ref NoteAnim.Y;
					NoteAnim.Y = ptr + NoteAnim.Ydir;
					if (NoteAnim.Y >= NoteAnim.Yend)
					{
						NoteAnim.Y = NoteAnim.Yend;
					}
					break;
				}
				case 4:
				{
					ref float ptr = ref NoteAnim.Ystart;
					NoteAnim.Ystart = ptr + NoteAnim.Ydir;
					if (255f < NoteAnim.Ystart)
					{
						NoteAnim.Ystart = 255f;
					}
					if (NoteAnim.Y >= NoteAnim.Yend)
					{
						NoteAnim.Y = NoteAnim.Yend;
					}
					break;
				}
				}
			}
			double num5 = Conversion.Val(NoteAnim.Align);
			if (num5 == 0.0)
			{
				stringFormat.Alignment = StringAlignment.Near;
			}
			else if (num5 == 1.0)
			{
				stringFormat.Alignment = StringAlignment.Center;
			}
			else if (num5 == 2.0)
			{
				stringFormat.Alignment = StringAlignment.Far;
			}
			if (NoteAnim.Mode == 1)
			{
				stringFormat.Alignment = StringAlignment.Near;
			}
			float x;
			float num6;
			if (LSNote.ShadowX != 0 | LSNote.ShadowY != 0)
			{
				Gfx.DrawString(Note[NoteAnim.TextCurrent], tFont, brush, (float)((double)NoteAnim.X + (double)LSNote.ShadowX * Conversion.Val(LSNote.ShadowDepth) + (double)NoteAnim.Xoffset), (float)((double)NoteAnim.Y + (double)LSNote.ShadowY * Conversion.Val(LSNote.ShadowDepth) + (double)NoteAnim.Yoffset), stringFormat);
				if (NoteAnim.Mode == 5)
				{
					x = (float)((double)NoteAnim.X + (double)LSNote.ShadowX * Conversion.Val(LSNote.ShadowDepth) + (double)NoteAnim.Xoffset);
					num6 = (float)((double)NoteAnim.Y + (double)LSNote.ShadowY * Conversion.Val(LSNote.ShadowDepth) + (double)NoteAnim.Yoffset);
					checked
					{
						int num7 = NoteAnim.TextCount - NoteAnim.TextCurrent;
						for (int i = 1; i <= num7; i++)
						{
							float num8 = unchecked(num6 + (float)(checked((num4 + num4) * i)));
							if (num8 < (float)pbNote.Height)
							{
								Gfx.DrawString(Note[NoteAnim.TextCurrent + i], tFont, brush, x, num8, stringFormat);
							}
						}
					}
				}
			}
			x = NoteAnim.X + (float)NoteAnim.Xoffset;
			num6 = NoteAnim.Y + (float)NoteAnim.Yoffset;
			checked
			{
				LinearGradientBrush brush2;
				if (NoteAnim.Mode == 4)
				{
					if (LSNote.FDir == 0)
					{
						brush2 = new LinearGradientBrush(new Point(0, (int)Math.Round((double)num6)), new Point(0, (int)Math.Round((double)(unchecked(num6 + (float)num4 + (float)num4)))), Color.FromArgb((int)Math.Round((double)NoteAnim.Ystart), (int)LSNote.F1.R, (int)LSNote.F1.G, (int)LSNote.F1.B), Color.FromArgb((int)Math.Round((double)NoteAnim.Ystart), (int)LSNote.F2.R, (int)LSNote.F2.G, (int)LSNote.F2.B));
					}
					else
					{
						brush2 = new LinearGradientBrush(new Point(0, 0), new Point(pbNote.Width, 0), Color.FromArgb((int)Math.Round((double)NoteAnim.Ystart), (int)LSNote.F1.R, (int)LSNote.F1.G, (int)LSNote.F1.B), Color.FromArgb((int)Math.Round((double)NoteAnim.Ystart), (int)LSNote.F2.R, (int)LSNote.F2.G, (int)LSNote.F2.B));
					}
				}
				else if (LSNote.FDir == 0)
				{
					brush2 = new LinearGradientBrush(new Point(0, (int)Math.Round((double)num6)), new Point(0, (int)Math.Round((double)(unchecked(num6 + (float)num4 + (float)num4)))), Color.FromArgb(255, (int)LSNote.F1.R, (int)LSNote.F1.G, (int)LSNote.F1.B), Color.FromArgb(255, (int)LSNote.F2.R, (int)LSNote.F2.G, (int)LSNote.F2.B));
				}
				else
				{
					brush2 = new LinearGradientBrush(new Point(0, 0), new Point(pbNote.Width, 0), Color.FromArgb(255, (int)LSNote.F1.R, (int)LSNote.F1.G, (int)LSNote.F1.B), Color.FromArgb(255, (int)LSNote.F2.R, (int)LSNote.F2.G, (int)LSNote.F2.B));
				}
				Gfx.DrawString(Note[NoteAnim.TextCurrent], tFont, brush2, x, num6, stringFormat);
				if (NoteAnim.Mode == 5)
				{
					int num9 = NoteAnim.TextCount - NoteAnim.TextCurrent;
					for (int j = 1; j <= num9; j++)
					{
						int num2 = (num4 + num4) * j;
						num2 = (int)Math.Round((double)(unchecked(NoteAnim.Y + (float)NoteAnim.Yoffset + (float)num2)));
						if (num2 < pbNote.Height)
						{
							if (LSNote.FDir == 0)
							{
								brush2 = new LinearGradientBrush(new Point(0, num2), new Point(0, num4 + num4 + num2), Color.FromArgb(255, (int)LSNote.F1.R, (int)LSNote.F1.G, (int)LSNote.F1.B), Color.FromArgb(255, (int)LSNote.F2.R, (int)LSNote.F2.G, (int)LSNote.F2.B));
							}
							else
							{
								brush2 = new LinearGradientBrush(new Point(0, 0 + num2), new Point(pbNote.Width, 0 + num2), Color.FromArgb(255, (int)LSNote.F1.R, (int)LSNote.F1.G, (int)LSNote.F1.B), Color.FromArgb(255, (int)LSNote.F2.R, (int)LSNote.F2.G, (int)LSNote.F2.B));
							}
							Gfx.DrawString(Note[NoteAnim.TextCurrent + j], tFont, brush2, unchecked(NoteAnim.X + (float)NoteAnim.Xoffset), (float)num2, stringFormat);
						}
					}
				}
				if (OVLBmp != null)
				{
					double num10 = Conversion.Val(LSNote.OVLScaling);
					if (num10 == 0.0)
					{
						Gfx.DrawImage(OVLBmp, 0, 0, OVLBmp.Width, OVLBmp.Height);
					}
					else if (num10 == 1.0)
					{
						int height3 = BM.Height;
						int height4 = OVLBmp.Height;
						int num2 = 0;
						while ((height4 >> 31 ^ num2) <= (height4 >> 31 ^ height3))
						{
							int width3 = BM.Width;
							int width4 = OVLBmp.Width;
							int num11 = 0;
							while ((width4 >> 31 ^ num11) <= (width4 >> 31 ^ width3))
							{
								Gfx.DrawImage(OVLBmp, num11, num2, OVLBmp.Width, OVLBmp.Height);
								num11 += width4;
							}
							num2 += height4;
						}
					}
					else if (num10 == 2.0)
					{
						unchecked
						{
							if (OVLBmp.Width < BM.Width | OVLBmp.Height < BM.Height)
							{
								float num12 = (float)((double)BM.Width / (double)OVLBmp.Width);
								float num13 = (float)((double)BM.Height / (double)OVLBmp.Height);
								Gfx.DrawImage(OVLBmp, 0f, 0f, (float)BM.Width + num12, (float)BM.Height + num13);
							}
							else
							{
								Gfx.DrawImage(OVLBmp, 0, 0, BM.Width, BM.Height);
							}
						}
					}
				}
				if (!NoteAnim.Holding)
				{
					switch (NoteAnim.Mode)
					{
					case 0:
					case 2:
					case 5:
						if (NoteAnim.Y <= NoteAnim.Yend)
						{
							NoteAnim.Y = NoteAnim.Yend;
							NoteAnim.Holding = true;
							NoteAnim.TimeAcc = 0L;
						}
						break;
					case 1:
						if (NoteAnim.X == NoteAnim.Xend)
						{
							NoteAnim.Holding = true;
							NoteAnim.TimeAcc = 0L;
						}
						break;
					case 3:
						if (NoteAnim.Y >= NoteAnim.Yend)
						{
							NoteAnim.Y = NoteAnim.Yend;
							NoteAnim.Holding = true;
							NoteAnim.TimeAcc = 0L;
						}
						break;
					case 4:
						if (NoteAnim.Ystart >= NoteAnim.Yend)
						{
							NoteAnim.Ystart = NoteAnim.Yend;
							NoteAnim.Holding = true;
							NoteAnim.TimeAcc = 0L;
						}
						break;
					}
				}
				ref long ptr2 = ref NoteAnim.TimeAcc;
				NoteAnim.TimeAcc = ptr2 + 33L;
				if (NoteAnim.TimeHold * 1000L < NoteAnim.TimeAcc)
				{
					NoteAnim.Holding = false;
				}
				if (!NoteAnim.Holding)
				{
					switch (NoteAnim.Mode)
					{
					case 0:
					case 2:
					case 5:
						if (NoteAnim.Y <= NoteAnim.Yend)
						{
							NoteAnim.TimeAcc = 0L;
							if (NoteAnim.Mode == 5)
							{
								ref float ptr = ref NoteAnim.Y;
								NoteAnim.Y = unchecked(ptr + (float)(checked(num4 + num4)));
							}
							else
							{
								NoteAnim.Y = NoteAnim.Ystart;
							}
							ref int ptr3 = ref NoteAnim.TextCurrent;
							NoteAnim.TextCurrent = ptr3 + 1;
							if (NoteAnim.TextCount < NoteAnim.TextCurrent)
							{
								NoteAnim.TextCurrent = 1;
								if (NoteAnim.Mode == 5)
								{
									NoteAnim.Y = NoteAnim.Ystart;
								}
							}
						}
						break;
					case 1:
						if (NoteAnim.X < NoteAnim.Xend)
						{
							NoteAnim.X = NoteAnim.Xstart;
						}
						break;
					case 3:
						if (NoteAnim.Y >= NoteAnim.Yend)
						{
							NoteAnim.TimeAcc = 0L;
							NoteAnim.Y = NoteAnim.Ystart;
							ref int ptr3 = ref NoteAnim.TextCurrent;
							NoteAnim.TextCurrent = ptr3 + 1;
							if (NoteAnim.TextCount < NoteAnim.TextCurrent)
							{
								NoteAnim.TextCurrent = 1;
							}
						}
						break;
					case 4:
						if (NoteAnim.Ystart >= NoteAnim.Yend)
						{
							NoteAnim.TimeAcc = 0L;
							NoteAnim.Ystart = 0f;
							ref int ptr3 = ref NoteAnim.TextCurrent;
							NoteAnim.TextCurrent = ptr3 + 1;
							if (NoteAnim.TextCount < NoteAnim.TextCurrent)
							{
								NoteAnim.TextCurrent = 1;
							}
						}
						break;
					}
				}
				pbNote.Image = BM;
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0001AB80 File Offset: 0x00018D80
		private void SOUND_Play(string tFile)
		{
			try
			{
				MyProject.Computer.Audio.Stop();
				MyProject.Computer.Audio.Play(tFile, AudioPlayMode.Background);
			}
			catch (Exception ex)
			{
				this.lbError1.Text = "Error playing";
				this.lbError2.Text = "sound file";
				Interaction.MsgBox("ERROR: " + Information.Err().Description + "\r\rUnable to play this sound file.", MsgBoxStyle.Critical, null);
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0001AC10 File Offset: 0x00018E10
		private void SOUND_HandleClicks(object Sender, MouseEventArgs e, int Index)
		{
			this.CELO_PopUpObject = RuntimeHelpers.GetObjectValue(Sender);
			this.Celo_PopupHit = Index;
			if (Keys.None < (Control.ModifierKeys & Keys.Control))
			{
				this.SOUND_File[Index] = "";
				this.ToolTip1.SetToolTip((Control)Sender, "Left click to play a sound.\rRight click to map a sound or set the volume.\rCtrl-Click to delete.");
				return;
			}
			if (e.Button == MouseButtons.Left & Operators.CompareString(this.SOUND_File[Index], "", false) != 0)
			{
				this.AUDIO_SetVolume(this.scrVolume.Value, Conversions.ToInteger(this.SOUND_Vol[Index]));
				this.SOUND_Play(this.SOUND_File[Index]);
				return;
			}
			if (Operators.CompareString(this.SOUND_File[Index], "", false) != 0)
			{
				this.POPUP_Audio_SetMenu(Conversions.ToInteger(this.SOUND_Vol[Index]));
				this.tsmAudio.Show((Control)Sender, new Point(e.X, e.Y));
				return;
			}
			this.AUDIO_SelectFile(Index);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0001AD08 File Offset: 0x00018F08
		private void POPUP_Audio_SetMenu(int Vol)
		{
			this.tsmSetVolTo100.Checked = false;
			if (Vol == 100)
			{
				this.tsmSetVolTo100.Checked = true;
			}
			this.tsmSetVolTo90.Checked = false;
			if (Vol == 90)
			{
				this.tsmSetVolTo90.Checked = true;
			}
			this.tsmSetVolTo80.Checked = false;
			if (Vol == 80)
			{
				this.tsmSetVolTo80.Checked = true;
			}
			this.tsmSetVolTo70.Checked = false;
			if (Vol == 70)
			{
				this.tsmSetVolTo70.Checked = true;
			}
			this.tsmSetVolTo60.Checked = false;
			if (Vol == 60)
			{
				this.tsmSetVolTo60.Checked = true;
			}
			this.tsmSetVolTo50.Checked = false;
			if (Vol == 50)
			{
				this.tsmSetVolTo50.Checked = true;
			}
			this.tsmSetVolTo40.Checked = false;
			if (Vol == 40)
			{
				this.tsmSetVolTo40.Checked = true;
			}
			this.tsmSetVolTo30.Checked = false;
			if (Vol == 30)
			{
				this.tsmSetVolTo30.Checked = true;
			}
			this.tsmSetVolTo20.Checked = false;
			if (Vol == 20)
			{
				this.tsmSetVolTo20.Checked = true;
			}
			this.tsmSetVolTo10.Checked = false;
			if (Vol == 10)
			{
				this.tsmSetVolTo10.Checked = true;
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0001AE38 File Offset: 0x00019038
		private string SOUND_GetName(string tFile)
		{
			int num = 0;
			checked
			{
				for (int i = Strings.Len(tFile); i >= 1; i += -1)
				{
					if (Operators.CompareString(Strings.Mid(tFile, i, 1), "\\", false) == 0)
					{
						num = i;
						break;
					}
				}
				string value;
				if (num != 0)
				{
					value = Strings.Mid(tFile, num + 1, 255);
				}
				else
				{
					value = tFile;
				}
				return Strings.LCase(value);
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0001AE92 File Offset: 0x00019092
		private void cmAudioStop_Click(object sender, EventArgs e)
		{
			MyProject.Computer.Audio.Stop();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00009B4B File Offset: 0x00007D4B
		private void cmSound01_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0001AEA3 File Offset: 0x000190A3
		private void cmSound01_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 1);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0001AEB3 File Offset: 0x000190B3
		private void cmSound02_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 2);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0001AEC3 File Offset: 0x000190C3
		private void cmSound03_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 3);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0001AED3 File Offset: 0x000190D3
		private void cmSound04_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 4);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0001AEE3 File Offset: 0x000190E3
		private void cmSound05_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 5);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0001AEF3 File Offset: 0x000190F3
		private void cmSound06_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 6);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0001AF03 File Offset: 0x00019103
		private void cmSound07_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 7);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0001AF13 File Offset: 0x00019113
		private void cmSound08_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 8);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0001AF23 File Offset: 0x00019123
		private void cmSound09_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 9);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0001AF34 File Offset: 0x00019134
		private void cmSound10_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 10);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0001AF45 File Offset: 0x00019145
		private void cmSound11_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 11);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0001AF56 File Offset: 0x00019156
		private void cmSound12_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 12);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0001AF67 File Offset: 0x00019167
		private void cmSound13_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 13);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0001AF78 File Offset: 0x00019178
		private void cmSound14_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 14);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0001AF89 File Offset: 0x00019189
		private void cmSound15_MouseDown(object sender, MouseEventArgs e)
		{
			this.SOUND_HandleClicks(RuntimeHelpers.GetObjectValue(sender), e, 15);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0001AF9A File Offset: 0x0001919A
		private void cmSound01_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[1]);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0001AFB5 File Offset: 0x000191B5
		private void cmSound02_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[2]);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0001AFD0 File Offset: 0x000191D0
		private void cmSound03_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[3]);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0001AFEB File Offset: 0x000191EB
		private void cmSound04_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[4]);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0001B006 File Offset: 0x00019206
		private void cmSound05_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[5]);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0001B021 File Offset: 0x00019221
		private void cmSound06_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[6]);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0001B03C File Offset: 0x0001923C
		private void cmSound07_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[7]);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0001B057 File Offset: 0x00019257
		private void cmSound08_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[8]);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0001B072 File Offset: 0x00019272
		private void cmSound09_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[9]);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0001B08E File Offset: 0x0001928E
		private void cmSound10_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[10]);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0001B0AA File Offset: 0x000192AA
		private void cmSound11_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[11]);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0001B0C6 File Offset: 0x000192C6
		private void cmSound12_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[12]);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0001B0E2 File Offset: 0x000192E2
		private void cmSound13_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[13]);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0001B0FE File Offset: 0x000192FE
		private void cmSound14_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[14]);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0001B11A File Offset: 0x0001931A
		private void cmSound15_MouseHover(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = this.SOUND_GetName(this.SOUND_File[15]);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0001B136 File Offset: 0x00019336
		private void cmSound01_MouseLeave(object sender, EventArgs e)
		{
			this.lbSoundCurrent.Text = "";
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0001B148 File Offset: 0x00019348
		private void SCREEN_Organize()
		{
			checked
			{
				this.pbNote1.Top = this.pbStats.Top + this.pbStats.Height + 2;
				this.pbNote2.Top = this.pbNote1.Top + this.pbNote1.Height + this.NOTE_Spacing;
				this.pbNote3.Top = this.pbNote2.Top + this.pbNote2.Height + this.NOTE_Spacing;
				this.pbNote4.Top = this.pbNote3.Top + this.pbNote3.Height + this.NOTE_Spacing;
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0001B1F4 File Offset: 0x000193F4
		private void cmRankSetup_Click(object sender, EventArgs e)
		{
			frmLabelSetup frmLabelSetup = new frmLabelSetup
			{
				HideSizeOptions = true,
				HideSizeAll = true
			};
			this.LSRank.BackC = this.LSName.BackC;
			this.LSRank.Scaling = this.LSName.Scaling;
			this.LSRank.OVLScaling = this.LSName.OVLScaling;
			frmLabelSetup.LSetup = this.LSRank;
			frmMain.FONT_Setup = frmMain.FONT_Rank;
			frmMain.PATH_DlgBmp = this.PATH_BackgroundImage;
			frmMain.Note_BackBmp = this.NAME_bmp;
			frmMain.PATH_DlgBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.PATH_DlgOVLBmp = frmMain.PATH_Name_OVLBmp;
			frmMain.Note_OVLBmp = this.NAME_OVLBmp;
			frmMain.PATH_DlgOVLBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
			frmLabelSetup.ShowDialog();
			checked
			{
				if (!frmLabelSetup.Cancel)
				{
					this.LSRank = frmLabelSetup.LSetup;
					frmMain.FONT_Rank = frmMain.FONT_Setup;
					frmMain.FONT_Rank_Name = frmMain.FONT_Setup.Name;
					frmMain.FONT_Rank_Size = Conversions.ToString(frmMain.FONT_Setup.Size);
					frmMain.FONT_Rank_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
					frmMain.FONT_Rank_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
					this.LSRank.B1 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(this.LSRank.O1) * 0.01))), (int)this.LSRank.B1.R, (int)this.LSRank.B1.G, (int)this.LSRank.B1.B);
					this.LSRank.B2 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(this.LSRank.O2) * 0.01))), (int)this.LSRank.B2.R, (int)this.LSRank.B2.G, (int)this.LSRank.B2.B);
					this.NAME_bmp = frmMain.Note_BackBmp;
					this.PATH_BackgroundImage = frmMain.PATH_DlgBmp;
					this.PATH_BackgroundImagePath = this.PATH_StripFilename(frmMain.PATH_DlgBmp);
					this.NAME_OVLBmp = frmMain.Note_OVLBmp;
					frmMain.PATH_Name_OVLBmp = frmMain.PATH_DlgOVLBmp;
					frmMain.PATH_Name_OVLBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
					this.pbStats.BackColor = this.LSRank.BackC;
					this.LSName.BackC = this.LSRank.BackC;
					this.LSName.Scaling = this.LSRank.Scaling;
					this.LSName.OVLScaling = this.LSRank.OVLScaling;
				}
				frmLabelSetup.Dispose();
				this.SETTINGS_Save();
				this.SCREEN_Organize();
				this.GFX_DrawStats();
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0001B4C8 File Offset: 0x000196C8
		private void cmNameSetup_Click(object sender, EventArgs e)
		{
			frmLabelSetup frmLabelSetup = new frmLabelSetup
			{
				HideSizeOptions = true,
				HideSizeAll = true
			};
			frmLabelSetup.LSetup = this.LSName;
			frmMain.FONT_Setup = frmMain.FONT_Name;
			frmMain.PATH_DlgBmp = this.PATH_BackgroundImage;
			frmMain.Note_BackBmp = this.NAME_bmp;
			frmMain.PATH_DlgBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.PATH_DlgOVLBmp = frmMain.PATH_Name_OVLBmp;
			frmMain.Note_OVLBmp = this.NAME_OVLBmp;
			frmMain.PATH_DlgOVLBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
			frmLabelSetup.ShowDialog();
			checked
			{
				if (!frmLabelSetup.Cancel)
				{
					this.LSName = frmLabelSetup.LSetup;
					frmMain.FONT_Name = frmMain.FONT_Setup;
					frmMain.FONT_Name_Name = frmMain.FONT_Setup.Name;
					frmMain.FONT_Name_Size = Conversions.ToString(frmMain.FONT_Setup.Size);
					frmMain.FONT_Name_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
					frmMain.FONT_Name_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
					this.LSName.B1 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(this.LSName.O1) * 0.01))), (int)this.LSName.B1.R, (int)this.LSName.B1.G, (int)this.LSName.B1.B);
					this.LSName.B2 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(this.LSName.O2) * 0.01))), (int)this.LSName.B2.R, (int)this.LSName.B2.G, (int)this.LSName.B2.B);
					this.NAME_bmp = frmMain.Note_BackBmp;
					this.PATH_BackgroundImage = frmMain.PATH_DlgBmp;
					this.PATH_BackgroundImagePath = this.PATH_StripFilename(frmMain.PATH_DlgBmp);
					this.NAME_OVLBmp = frmMain.Note_OVLBmp;
					frmMain.PATH_Name_OVLBmp = frmMain.PATH_DlgOVLBmp;
					frmMain.PATH_Name_OVLBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
					this.pbStats.BackColor = this.LSName.BackC;
				}
				frmLabelSetup.Dispose();
				this.SETTINGS_Save();
				this.SCREEN_Organize();
				this.GFX_DrawStats();
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0001B718 File Offset: 0x00019918
		private void cmNote_PlayAll_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.cmNote_PlayAll.Text, ">", false) == 0)
			{
				this.cmNote01Setup.Enabled = false;
				this.cmNote02Setup.Enabled = false;
				this.cmNote03Setup.Enabled = false;
				this.cmNote04Setup.Enabled = false;
				this.cmNote_PlayAll.Text = "||";
				this.cmNote01_Play.Text = "||";
				this.cmNote02_Play.Text = "||";
				this.cmNote03_Play.Text = "||";
				this.cmNote04_Play.Text = "||";
				PictureBox pictureBox = this.pbNote1;
				this.NOTE_Animation_Setup(ref this.NoteAnim01, ref pictureBox, ref frmMain.FONT_Note01, ref this.Note01_Text, ref this.NoteAnim01_Text);
				this.pbNote1 = pictureBox;
				pictureBox = this.pbNote2;
				this.NOTE_Animation_Setup(ref this.NoteAnim02, ref pictureBox, ref frmMain.FONT_Note02, ref this.Note02_Text, ref this.NoteAnim02_Text);
				this.pbNote2 = pictureBox;
				pictureBox = this.pbNote3;
				this.NOTE_Animation_Setup(ref this.NoteAnim03, ref pictureBox, ref frmMain.FONT_Note03, ref this.Note03_Text, ref this.NoteAnim03_Text);
				this.pbNote3 = pictureBox;
				pictureBox = this.pbNote4;
				this.NOTE_Animation_Setup(ref this.NoteAnim04, ref pictureBox, ref frmMain.FONT_Note04, ref this.Note04_Text, ref this.NoteAnim04_Text);
				this.pbNote4 = pictureBox;
				return;
			}
			this.cmNote01Setup.Enabled = true;
			this.cmNote02Setup.Enabled = true;
			this.cmNote03Setup.Enabled = true;
			this.cmNote04Setup.Enabled = true;
			this.cmNote_PlayAll.Text = ">";
			this.cmNote01_Play.Text = ">";
			this.cmNote02_Play.Text = ">";
			this.cmNote03_Play.Text = ">";
			this.cmNote04_Play.Text = ">";
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0001B8F8 File Offset: 0x00019AF8
		private void cmNote01_Play_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.cmNote01_Play.Text, ">", false) == 0)
			{
				this.cmNote01Setup.Enabled = false;
				this.cmNote01_Play.Text = "||";
				PictureBox pbNote = this.pbNote1;
				this.NOTE_Animation_Setup(ref this.NoteAnim01, ref pbNote, ref frmMain.FONT_Note01, ref this.Note01_Text, ref this.NoteAnim01_Text);
				this.pbNote1 = pbNote;
				return;
			}
			this.cmNote01Setup.Enabled = true;
			this.cmNote01_Play.Text = ">";
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0001B984 File Offset: 0x00019B84
		private void cmNote02_Play_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.cmNote02_Play.Text, ">", false) == 0)
			{
				this.cmNote02Setup.Enabled = false;
				this.cmNote02_Play.Text = "||";
				PictureBox pbNote = this.pbNote2;
				this.NOTE_Animation_Setup(ref this.NoteAnim02, ref pbNote, ref frmMain.FONT_Note02, ref this.Note02_Text, ref this.NoteAnim02_Text);
				this.pbNote2 = pbNote;
				return;
			}
			this.cmNote02Setup.Enabled = true;
			this.cmNote02_Play.Text = ">";
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0001BA10 File Offset: 0x00019C10
		private void cmNote03_Play_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.cmNote03_Play.Text, ">", false) == 0)
			{
				this.cmNote03Setup.Enabled = false;
				this.cmNote03_Play.Text = "||";
				PictureBox pbNote = this.pbNote3;
				this.NOTE_Animation_Setup(ref this.NoteAnim03, ref pbNote, ref frmMain.FONT_Note03, ref this.Note03_Text, ref this.NoteAnim03_Text);
				this.pbNote3 = pbNote;
				return;
			}
			this.cmNote03Setup.Enabled = true;
			this.cmNote03_Play.Text = ">";
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0001BA9C File Offset: 0x00019C9C
		private void cmNote04_Play_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.cmNote04_Play.Text, ">", false) == 0)
			{
				this.cmNote04Setup.Enabled = false;
				this.cmNote04_Play.Text = "||";
				PictureBox pbNote = this.pbNote4;
				this.NOTE_Animation_Setup(ref this.NoteAnim04, ref pbNote, ref frmMain.FONT_Note04, ref this.Note04_Text, ref this.NoteAnim04_Text);
				this.pbNote4 = pbNote;
				return;
			}
			this.cmNote04Setup.Enabled = true;
			this.cmNote04_Play.Text = ">";
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0001BB27 File Offset: 0x00019D27
		private void NOTE_AdjustBitmap(ref PictureBox pbNote, ref clsGlobal.t_LabelSetup LSNote, ref Bitmap BM, ref Graphics Gfx)
		{
			pbNote.Width = LSNote.Width;
			pbNote.Height = LSNote.Height;
			BM = new Bitmap(pbNote.Width, pbNote.Height);
			Gfx = Graphics.FromImage(BM);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0001BB64 File Offset: 0x00019D64
		private void NOTE_CheckNoteSizes()
		{
			if (frmMain.LSNote01.Width != this.pbNote1.Width | frmMain.LSNote01.Height != this.pbNote1.Height)
			{
				PictureBox pictureBox = this.pbNote1;
				this.NOTE_AdjustBitmap(ref pictureBox, ref frmMain.LSNote01, ref this.Note01_Bmp, ref this.Note01_Gfx);
				this.pbNote1 = pictureBox;
			}
			if (frmMain.LSNote02.Width != this.pbNote2.Width | frmMain.LSNote02.Height != this.pbNote2.Height)
			{
				PictureBox pictureBox = this.pbNote2;
				this.NOTE_AdjustBitmap(ref pictureBox, ref frmMain.LSNote02, ref this.Note02_Bmp, ref this.Note02_Gfx);
				this.pbNote2 = pictureBox;
			}
			if (frmMain.LSNote03.Width != this.pbNote3.Width | frmMain.LSNote03.Height != this.pbNote3.Height)
			{
				PictureBox pictureBox = this.pbNote3;
				this.NOTE_AdjustBitmap(ref pictureBox, ref frmMain.LSNote03, ref this.Note03_Bmp, ref this.Note03_Gfx);
				this.pbNote3 = pictureBox;
			}
			if (frmMain.LSNote04.Width != this.pbNote4.Width | frmMain.LSNote04.Height != this.pbNote4.Height)
			{
				PictureBox pictureBox = this.pbNote4;
				this.NOTE_AdjustBitmap(ref pictureBox, ref frmMain.LSNote04, ref this.Note04_Bmp, ref this.Note04_Gfx);
				this.pbNote4 = pictureBox;
			}
			this.SCREEN_Organize();
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0001BCF0 File Offset: 0x00019EF0
		private void cmNote01Setup_Click_1(object sender, EventArgs e)
		{
			frmLabelSetup frmLabelSetup = new frmLabelSetup
			{
				HideFormColor = true
			};
			frmLabelSetup.LSetup = frmMain.LSNote01;
			frmMain.FONT_Setup = frmMain.FONT_Note01;
			frmMain.PATH_DlgBmp = frmMain.PATH_Note01_Bmp;
			frmMain.Note_BackBmp = frmMain.Note01_BackBmp;
			frmMain.PATH_DlgBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.PATH_DlgOVLBmp = frmMain.PATH_Note01_OVLBmp;
			frmMain.Note_OVLBmp = frmMain.Note01_OVLBmp;
			frmMain.PATH_DlgOVLBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
			frmLabelSetup.ShowDialog();
			checked
			{
				if (!frmLabelSetup.Cancel)
				{
					frmMain.LSNote01 = frmLabelSetup.LSetup;
					frmMain.PATH_Note01_Bmp = frmMain.PATH_DlgBmp;
					frmMain.Note01_BackBmp = frmMain.Note_BackBmp;
					frmMain.PATH_Note01_OVLBmp = frmMain.PATH_DlgOVLBmp;
					frmMain.Note01_OVLBmp = frmMain.Note_OVLBmp;
					frmMain.FONT_Note01 = frmMain.FONT_Setup;
					frmMain.FONT_Note01_Name = frmMain.FONT_Setup.Name;
					frmMain.FONT_Note01_Size = Conversions.ToString(frmMain.FONT_Setup.Size);
					frmMain.FONT_Note01_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
					frmMain.FONT_Note01_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
					frmMain.LSNote01.B1 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote01.O1) * 0.01))), (int)frmMain.LSNote01.B1.R, (int)frmMain.LSNote01.B1.G, (int)frmMain.LSNote01.B1.B);
					frmMain.LSNote01.B2 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote01.O2) * 0.01))), (int)frmMain.LSNote01.B2.R, (int)frmMain.LSNote01.B2.G, (int)frmMain.LSNote01.B2.B);
					this.NOTE_CheckNoteSizes();
					this.SETTINGS_Save();
				}
				frmLabelSetup.Dispose();
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0001BEE8 File Offset: 0x0001A0E8
		private void cmNote02Setup_Click_1(object sender, EventArgs e)
		{
			frmLabelSetup frmLabelSetup = new frmLabelSetup
			{
				HideFormColor = true
			};
			frmLabelSetup.LSetup = frmMain.LSNote02;
			frmMain.FONT_Setup = frmMain.FONT_Note02;
			frmMain.PATH_DlgBmp = frmMain.PATH_Note02_Bmp;
			frmMain.Note_BackBmp = frmMain.Note02_BackBmp;
			frmMain.PATH_DlgBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.PATH_DlgOVLBmp = frmMain.PATH_Note02_OVLBmp;
			frmMain.Note_OVLBmp = frmMain.Note02_OVLBmp;
			frmMain.PATH_DlgOVLBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
			frmLabelSetup.ShowDialog();
			checked
			{
				if (!frmLabelSetup.Cancel)
				{
					frmMain.LSNote02 = frmLabelSetup.LSetup;
					frmMain.PATH_Note02_Bmp = frmMain.PATH_DlgBmp;
					frmMain.Note02_BackBmp = frmMain.Note_BackBmp;
					frmMain.PATH_Note02_OVLBmp = frmMain.PATH_DlgOVLBmp;
					frmMain.Note02_OVLBmp = frmMain.Note_OVLBmp;
					frmMain.FONT_Note02 = frmMain.FONT_Setup;
					frmMain.FONT_Note02_Name = frmMain.FONT_Setup.Name;
					frmMain.FONT_Note02_Size = Conversions.ToString(frmMain.FONT_Setup.Size);
					frmMain.FONT_Note02_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
					frmMain.FONT_Note02_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
					frmMain.LSNote02.B1 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote02.O1) * 0.01))), (int)frmMain.LSNote02.B1.R, (int)frmMain.LSNote02.B1.G, (int)frmMain.LSNote02.B1.B);
					frmMain.LSNote02.B2 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote02.O2) * 0.01))), (int)frmMain.LSNote02.B2.R, (int)frmMain.LSNote02.B2.G, (int)frmMain.LSNote02.B2.B);
					this.NOTE_CheckNoteSizes();
					this.SETTINGS_Save();
				}
				frmLabelSetup.Dispose();
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0001C0E0 File Offset: 0x0001A2E0
		private void cmNote03Setup_Click_1(object sender, EventArgs e)
		{
			frmLabelSetup frmLabelSetup = new frmLabelSetup
			{
				HideFormColor = true
			};
			frmLabelSetup.LSetup = frmMain.LSNote03;
			frmMain.FONT_Setup = frmMain.FONT_Note03;
			frmMain.PATH_DlgBmp = frmMain.PATH_Note03_Bmp;
			frmMain.Note_BackBmp = frmMain.Note03_BackBmp;
			frmMain.PATH_DlgBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.PATH_DlgOVLBmp = frmMain.PATH_Note03_OVLBmp;
			frmMain.Note_OVLBmp = frmMain.Note03_OVLBmp;
			frmMain.PATH_DlgOVLBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
			frmLabelSetup.ShowDialog();
			checked
			{
				if (!frmLabelSetup.Cancel)
				{
					frmMain.LSNote03 = frmLabelSetup.LSetup;
					frmMain.PATH_Note03_Bmp = frmMain.PATH_DlgBmp;
					frmMain.Note03_BackBmp = frmMain.Note_BackBmp;
					frmMain.PATH_Note03_OVLBmp = frmMain.PATH_DlgOVLBmp;
					frmMain.Note03_OVLBmp = frmMain.Note_OVLBmp;
					frmMain.FONT_Note03 = frmMain.FONT_Setup;
					frmMain.FONT_Note03_Name = frmMain.FONT_Setup.Name;
					frmMain.FONT_Note03_Size = Conversions.ToString(frmMain.FONT_Setup.Size);
					frmMain.FONT_Note03_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
					frmMain.FONT_Note03_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
					frmMain.LSNote03.B1 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote03.O1) * 0.01))), (int)frmMain.LSNote03.B1.R, (int)frmMain.LSNote03.B1.G, (int)frmMain.LSNote03.B1.B);
					frmMain.LSNote03.B2 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote03.O2) * 0.01))), (int)frmMain.LSNote03.B2.R, (int)frmMain.LSNote03.B2.G, (int)frmMain.LSNote03.B2.B);
					this.NOTE_CheckNoteSizes();
					this.SETTINGS_Save();
				}
				frmLabelSetup.Dispose();
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0001C2D8 File Offset: 0x0001A4D8
		private void cmNote04Setup_Click_1(object sender, EventArgs e)
		{
			frmLabelSetup frmLabelSetup = new frmLabelSetup
			{
				HideFormColor = true
			};
			frmLabelSetup.LSetup = frmMain.LSNote04;
			frmMain.FONT_Setup = frmMain.FONT_Note04;
			frmMain.PATH_DlgBmp = frmMain.PATH_Note04_Bmp;
			frmMain.Note_BackBmp = frmMain.Note04_BackBmp;
			frmMain.PATH_DlgBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.PATH_DlgOVLBmp = frmMain.PATH_Note04_OVLBmp;
			frmMain.Note_OVLBmp = frmMain.Note04_OVLBmp;
			frmMain.PATH_DlgOVLBmpPath = this.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
			frmLabelSetup.ShowDialog();
			checked
			{
				if (!frmLabelSetup.Cancel)
				{
					frmMain.LSNote04 = frmLabelSetup.LSetup;
					frmMain.PATH_Note04_Bmp = frmMain.PATH_DlgBmp;
					frmMain.Note04_BackBmp = frmMain.Note_BackBmp;
					frmMain.PATH_Note04_OVLBmp = frmMain.PATH_DlgOVLBmp;
					frmMain.Note04_OVLBmp = frmMain.Note_OVLBmp;
					frmMain.FONT_Note04 = frmMain.FONT_Setup;
					frmMain.FONT_Note04_Name = frmMain.FONT_Setup.Name;
					frmMain.FONT_Note04_Size = Conversions.ToString(frmMain.FONT_Setup.Size);
					frmMain.FONT_Note04_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
					frmMain.FONT_Note04_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
					frmMain.LSNote04.B1 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote04.O1) * 0.01))), (int)frmMain.LSNote04.B1.R, (int)frmMain.LSNote04.B1.G, (int)frmMain.LSNote04.B1.B);
					frmMain.LSNote04.B2 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote04.O2) * 0.01))), (int)frmMain.LSNote04.B2.R, (int)frmMain.LSNote04.B2.G, (int)frmMain.LSNote04.B2.B);
					this.NOTE_CheckNoteSizes();
					this.SETTINGS_Save();
				}
				frmLabelSetup.Dispose();
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0001C4D0 File Offset: 0x0001A6D0
		private void cmNote1_Click(object sender, EventArgs e)
		{
			frmNotes frmNotes = new frmNotes();
			int num = 1;
			checked
			{
				do
				{
					frmNotes.set_NoteText(num, this.NoteAnim01_Text[num]);
					num++;
				}
				while (num <= 10);
				frmNotes.NoteAnim = this.NoteAnim01;
				frmNotes.ShowDialog();
				if (!frmNotes.Cancel)
				{
					int num2 = 1;
					do
					{
						this.NoteAnim01_Text[num2] = frmNotes.get_NoteText(num2);
						num2++;
					}
					while (num2 <= 10);
					this.NoteAnim01 = frmNotes.NoteAnim;
					this.SETTINGS_Save();
				}
				frmNotes.Dispose();
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0001C54C File Offset: 0x0001A74C
		private void cmNote2_Click(object sender, EventArgs e)
		{
			frmNotes frmNotes = new frmNotes();
			int num = 1;
			checked
			{
				do
				{
					frmNotes.set_NoteText(num, this.NoteAnim02_Text[num]);
					num++;
				}
				while (num <= 10);
				frmNotes.NoteAnim = this.NoteAnim02;
				frmNotes.ShowDialog();
				if (!frmNotes.Cancel)
				{
					int num2 = 1;
					do
					{
						this.NoteAnim02_Text[num2] = frmNotes.get_NoteText(num2);
						num2++;
					}
					while (num2 <= 10);
					this.NoteAnim02 = frmNotes.NoteAnim;
					this.SETTINGS_Save();
				}
				frmNotes.Dispose();
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0001C5C8 File Offset: 0x0001A7C8
		private void cmNote3_Click(object sender, EventArgs e)
		{
			frmNotes frmNotes = new frmNotes();
			int num = 1;
			checked
			{
				do
				{
					frmNotes.set_NoteText(num, this.NoteAnim03_Text[num]);
					num++;
				}
				while (num <= 10);
				frmNotes.NoteAnim = this.NoteAnim03;
				frmNotes.ShowDialog();
				if (!frmNotes.Cancel)
				{
					int num2 = 1;
					do
					{
						this.NoteAnim03_Text[num2] = frmNotes.get_NoteText(num2);
						num2++;
					}
					while (num2 <= 10);
					this.NoteAnim03 = frmNotes.NoteAnim;
					this.SETTINGS_Save();
				}
				frmNotes.Dispose();
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0001C644 File Offset: 0x0001A844
		private void cmNote4_Click(object sender, EventArgs e)
		{
			frmNotes frmNotes = new frmNotes();
			int num = 1;
			checked
			{
				do
				{
					frmNotes.set_NoteText(num, this.NoteAnim04_Text[num]);
					num++;
				}
				while (num <= 10);
				frmNotes.NoteAnim = this.NoteAnim04;
				frmNotes.ShowDialog();
				if (!frmNotes.Cancel)
				{
					int num2 = 1;
					do
					{
						this.NoteAnim04_Text[num2] = frmNotes.get_NoteText(num2);
						num2++;
					}
					while (num2 <= 10);
					this.NoteAnim04 = frmNotes.NoteAnim;
					this.SETTINGS_Save();
				}
				frmNotes.Dispose();
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0001C6C0 File Offset: 0x0001A8C0
		private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Note01_Bmp.Dispose();
			this.Note02_Bmp.Dispose();
			this.Note03_Bmp.Dispose();
			this.Note04_Bmp.Dispose();
			this.Note01_Gfx.Dispose();
			this.Note02_Gfx.Dispose();
			this.Note03_Gfx.Dispose();
			this.Note04_Gfx.Dispose();
			frmMain.FONT_Rank.Dispose();
			frmMain.FONT_Name.Dispose();
			frmMain.FONT_Note01.Dispose();
			frmMain.FONT_Note02.Dispose();
			frmMain.FONT_Note03.Dispose();
			frmMain.FONT_Note04.Dispose();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0001C764 File Offset: 0x0001A964
		private void scrVolume_ValueChanged(object sender, EventArgs e)
		{
			int num = this.scrVolume.Value;
			if (num < 0)
			{
				num = 0;
			}
			if (100 < num)
			{
				num = 100;
			}
			this.AUDIO_SetVolume(num, 100);
			this.lbVolume.Text = Conversions.ToString(num);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0001C7A8 File Offset: 0x0001A9A8
		private void AUDIO_SetVolume(int MasterVol, int SoundVol)
		{
			checked
			{
				uint num = (uint)Math.Round(unchecked(65535.0 * ((double)MasterVol * 0.01) * ((double)SoundVol * 0.01)));
				ulong num2 = (unchecked((ulong)num) & 65535UL) | (ulong)((long)Math.Round(unchecked(num * 65536.0)));
				frmMain.waveOutSetVolume(IntPtr.Zero, (uint)num2);
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0001C80B File Offset: 0x0001AA0B
		private void cboNoteSpace_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.FLAG_Loading)
			{
				this.NOTE_Spacing = this.cboNoteSpace.SelectedIndex;
				this.SCREEN_Organize();
				this.SETTINGS_Save();
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0001C832 File Offset: 0x0001AA32
		private void frmMain_Closing(object sender, CancelEventArgs e)
		{
			this.SETTINGS_Save();
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0001C83A File Offset: 0x0001AA3A
		private void tsmPlayer_Relic_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.companyofheroes.com/leaderboards#profile/steam/" + this.PlrSteam[this.Celo_PopupHit] + "/standings");
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0001C85E File Offset: 0x0001AA5E
		private void tsmPlayer_OrgAT_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/1/steamid/" + this.PlrSteam[this.Celo_PopupHit]);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0001C87D File Offset: 0x0001AA7D
		private void tsmPlayer_Google_Click(object sender, EventArgs e)
		{
			Process.Start("https://translate.google.com/#view=home&op=translate&sl=auto&tl=en&text=" + this.PlrName[this.Celo_PopupHit]);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0001C89C File Offset: 0x0001AA9C
		private void tsmPlayer_OrgFaction_Click(object sender, EventArgs e)
		{
			string left = this.PlrFact[this.Celo_PopupHit];
			if (Operators.CompareString(left, "05", false) == 0)
			{
				Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/12/steamid/" + this.PlrSteam[this.Celo_PopupHit]);
				return;
			}
			if (Operators.CompareString(left, "02", false) == 0 || Operators.CompareString(left, "01", false) == 0)
			{
				Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/11/steamid/" + this.PlrSteam[this.Celo_PopupHit]);
				return;
			}
			if (Operators.CompareString(left, "04", false) != 0 && Operators.CompareString(left, "03", false) != 0)
			{
				Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + this.PlrSteam[this.Celo_PopupHit]);
				return;
			}
			Process.Start("https://www.coh2.org/ladders/playercard/viewBoard/10/steamid/" + this.PlrSteam[this.Celo_PopupHit]);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0001C976 File Offset: 0x0001AB76
		private void tsmPlayer_OrgPlayercard_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.coh2.org/ladders/playercard/steamid/" + this.PlrSteam[this.Celo_PopupHit]);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0001C998 File Offset: 0x0001AB98
		private void chkPopUp_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkPopUp.Checked)
			{
				this.Celo_Popup = true;
				this.ToolTip1.SetToolTip(this.pbStats, "Click a player name to see web pages for:\rLeft: Relic Stats\rCtrl-Left: Google Translate\rShift-Left: Coh2.org player page\rRight: Popup menu");
				return;
			}
			this.Celo_Popup = false;
			this.ToolTip1.SetToolTip(this.pbStats, "Click a player name to see web pages for:\rLeft: Relic Stats\rCtrl-Left: Google Translate\rShift-Left: Coh2.org player page\rRight: Coh2.org AT stats\rCtrl-Right: Coh2.org faction page");
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0001C9ED File Offset: 0x0001ABED
		private void tsmSelectFile_Click(object sender, EventArgs e)
		{
			this.AUDIO_SelectFile(this.Celo_PopupHit);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0001C9FC File Offset: 0x0001ABFC
		private void AUDIO_SelectFile(int index)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select a sound to play";
			if (Operators.CompareString(this.SOUND_File[index], "", false) == 0)
			{
				if (Operators.CompareString(this.PATH_SoundFiles, "", false) != 0)
				{
					openFileDialog.InitialDirectory = this.PATH_SoundFiles;
				}
			}
			else
			{
				this.PATH_SoundFiles = this.PATH_StripFilename(this.SOUND_File[index]);
				openFileDialog.InitialDirectory = this.PATH_SoundFiles;
			}
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.SOUND_File[index] = openFileDialog.FileName;
				this.ToolTip1.SetToolTip((Control)this.CELO_PopUpObject, this.SOUND_File[index]);
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0001CAB0 File Offset: 0x0001ACB0
		private void tsmSetVolTo100_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(100);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0001CAC6 File Offset: 0x0001ACC6
		private void tsmSetVolTo90_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(90);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0001CADC File Offset: 0x0001ACDC
		private void tsmSetVolTo80_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(80);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0001CAF2 File Offset: 0x0001ACF2
		private void tsmSetVolTo70_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(70);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0001CB08 File Offset: 0x0001AD08
		private void tsmSetVolTo60_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(60);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0001CB1E File Offset: 0x0001AD1E
		private void tsmSetVolTo50_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(50);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0001CB34 File Offset: 0x0001AD34
		private void tsmSetVolTo40_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(40);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0001CB4A File Offset: 0x0001AD4A
		private void tsmSetVolTo30_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(30);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0001CB60 File Offset: 0x0001AD60
		private void tsmSetVolTo20_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(20);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0001CB76 File Offset: 0x0001AD76
		private void tsmSetVolTo10_Click(object sender, EventArgs e)
		{
			this.SOUND_Vol[this.Celo_PopupHit] = Conversions.ToString(10);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000146FA File Offset: 0x000128FA
		private void cboXoff_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.SETTINGS_Save();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000146FA File Offset: 0x000128FA
		private void cboYoff_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.SETTINGS_Save();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0001CB8C File Offset: 0x0001AD8C
		private void tbXoff_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Operators.CompareString(Conversions.ToString(e.KeyChar), "\r", false) == 0 && !(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.SETTINGS_Save();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0001CBDC File Offset: 0x0001ADDC
		private void tbYoff_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Operators.CompareString(Conversions.ToString(e.KeyChar), "\r", false) == 0 && !(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.SETTINGS_Save();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00009B4B File Offset: 0x00007D4B
		private void tbXsize_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0001CC2C File Offset: 0x0001AE2C
		private void tbXsize_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Operators.CompareString(Conversions.ToString(e.KeyChar), "\r", false) == 0 && !(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.STATS_ClipXY((float)Conversion.Val(this.tbXsize.Text), (float)Conversion.Val(this.tbYSize.Text));
				this.pbStats.Width = this.STATS_SizeX;
				this.pbStats.Height = this.STATS_SizeY;
				this.STATS_DefineY();
				this.STATS_DefineX();
				this.SETTINGS_Save();
				this.SCREEN_Organize();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00009B4B File Offset: 0x00007D4B
		private void tbYSize_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0001CCDC File Offset: 0x0001AEDC
		private void tbYSize_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Operators.CompareString(Conversions.ToString(e.KeyChar), "\r", false) == 0 && !(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.STATS_ClipXY((float)Conversion.Val(this.tbXsize.Text), (float)Conversion.Val(this.tbYSize.Text));
				this.pbStats.Width = this.STATS_SizeX;
				this.pbStats.Height = this.STATS_SizeY;
				this.STATS_DefineY();
				this.STATS_DefineX();
				this.SETTINGS_Save();
				this.SCREEN_Organize();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0001CD8C File Offset: 0x0001AF8C
		private void cmDefaults_Click(object sender, EventArgs e)
		{
			int num = (int)MessageBox.Show("You have chosen to restore all STATS pages settings to their default state.\r\rDo you wish To continue?", "STATS - Restore Defaults", MessageBoxButtons.YesNoCancel);
			if (!(num == 2 | num == 7) && !(this.FLAG_Loading | this.FLAG_Drawing))
			{
				this.FLAG_Drawing = true;
				this.STATS_ClipXY(980f, 180f);
				this.pbStats.Width = this.STATS_SizeX;
				this.pbStats.Height = this.STATS_SizeY;
				this.tbXsize.Text = Conversions.ToString(this.STATS_SizeX);
				this.tbYSize.Text = Conversions.ToString(this.STATS_SizeY);
				this.tbXoff.Text = "0";
				this.tbYoff.Text = "0";
				this.cboLayoutY.SelectedIndex = 3;
				this.STATS_DefineY();
				this.cboLayoutX.SelectedIndex = 3;
				this.STATS_DefineX();
				this.SCREEN_Organize();
				this.GFX_DrawStats();
				this.FLAG_Drawing = false;
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0001CE86 File Offset: 0x0001B086
		private void cmStatsModeHelp_Click(object sender, EventArgs e)
		{
			Interaction.MsgBox("This section defines the size and layout of the STATS page below.\r" + "Click DEFAULTS to restore the settings to their default sizes.\r\r" + "The default size is 980x180 which covers all of the COH2 bottom info area.\r\r" + "The XY offset values move the stats data around inside the STATS page. Adjust these values to line up the stats data with a custom made background image.\r\r", MsgBoxStyle.Information, "FX MODE HELP");
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0001CEB8 File Offset: 0x0001B0B8
		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
			if (this.ANIMATION_Smooth)
			{
				if (Operators.CompareString(this.cmNote01_Play.Text, "||", false) == 0 & this.NoteAnim01.Active)
				{
					PictureBox pictureBox = this.pbNote1;
					this.NOTE_Animate(ref pictureBox, ref this.Note01_Text, ref frmMain.LSNote01, ref frmMain.FONT_Note01, ref this.NoteAnim01, ref this.Note01_Bmp, ref this.Note01_Gfx, ref frmMain.Note01_BackBmp, ref frmMain.Note01_OVLBmp);
					this.pbNote1 = pictureBox;
				}
				if (Operators.CompareString(this.cmNote02_Play.Text, "||", false) == 0 & this.NoteAnim02.Active)
				{
					PictureBox pictureBox = this.pbNote2;
					this.NOTE_Animate(ref pictureBox, ref this.Note02_Text, ref frmMain.LSNote02, ref frmMain.FONT_Note02, ref this.NoteAnim02, ref this.Note02_Bmp, ref this.Note02_Gfx, ref frmMain.Note02_BackBmp, ref frmMain.Note02_OVLBmp);
					this.pbNote2 = pictureBox;
				}
				if (Operators.CompareString(this.cmNote03_Play.Text, "||", false) == 0 & this.NoteAnim03.Active)
				{
					PictureBox pictureBox = this.pbNote3;
					this.NOTE_Animate(ref pictureBox, ref this.Note03_Text, ref frmMain.LSNote03, ref frmMain.FONT_Note03, ref this.NoteAnim03, ref this.Note03_Bmp, ref this.Note03_Gfx, ref frmMain.Note03_BackBmp, ref frmMain.Note03_OVLBmp);
					this.pbNote3 = pictureBox;
				}
				if (Operators.CompareString(this.cmNote04_Play.Text, "||", false) == 0 & this.NoteAnim04.Active)
				{
					PictureBox pictureBox = this.pbNote4;
					this.NOTE_Animate(ref pictureBox, ref this.Note04_Text, ref frmMain.LSNote04, ref frmMain.FONT_Note04, ref this.NoteAnim04, ref this.Note04_Bmp, ref this.Note04_Gfx, ref frmMain.Note04_BackBmp, ref frmMain.Note04_OVLBmp);
					this.pbNote4 = pictureBox;
				}
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0001D074 File Offset: 0x0001B274
		private void chkSmoothAni_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkSmoothAni.Checked)
			{
				this.ANIMATION_Smooth = true;
				return;
			}
			this.ANIMATION_Smooth = false;
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00022802 File Offset: 0x00020A02
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x0002280C File Offset: 0x00020A0C
		internal virtual Button cmCheckLog
		{
			[CompilerGenerated]
			get
			{
				return this._cmCheckLog;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmCheckLog_Click);
				Button cmCheckLog = this._cmCheckLog;
				if (cmCheckLog != null)
				{
					cmCheckLog.Click -= value2;
				}
				this._cmCheckLog = value;
				cmCheckLog = this._cmCheckLog;
				if (cmCheckLog != null)
				{
					cmCheckLog.Click += value2;
				}
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x0002284F File Offset: 0x00020A4F
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x00022857 File Offset: 0x00020A57
		internal virtual Label lbStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00022860 File Offset: 0x00020A60
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x00022868 File Offset: 0x00020A68
		internal virtual PictureBox pbFact01 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00022871 File Offset: 0x00020A71
		// (set) Token: 0x060001DB RID: 475 RVA: 0x00022879 File Offset: 0x00020A79
		internal virtual PictureBox pbFact02 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00022882 File Offset: 0x00020A82
		// (set) Token: 0x060001DD RID: 477 RVA: 0x0002288A File Offset: 0x00020A8A
		internal virtual PictureBox pbFact03 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00022893 File Offset: 0x00020A93
		// (set) Token: 0x060001DF RID: 479 RVA: 0x0002289B File Offset: 0x00020A9B
		internal virtual PictureBox pbFact04 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x000228A4 File Offset: 0x00020AA4
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x000228AC File Offset: 0x00020AAC
		internal virtual PictureBox pbFact05 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x000228B5 File Offset: 0x00020AB5
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x000228BD File Offset: 0x00020ABD
		internal virtual Label lbSteam01 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x000228C6 File Offset: 0x00020AC6
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x000228CE File Offset: 0x00020ACE
		internal virtual Label lbSteam02 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x000228D7 File Offset: 0x00020AD7
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x000228DF File Offset: 0x00020ADF
		internal virtual Label lbSteam03 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x000228E8 File Offset: 0x00020AE8
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x000228F0 File Offset: 0x00020AF0
		internal virtual Label lbSteam04 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001EA RID: 490 RVA: 0x000228F9 File Offset: 0x00020AF9
		// (set) Token: 0x060001EB RID: 491 RVA: 0x00022901 File Offset: 0x00020B01
		internal virtual Label lbSteam05 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001EC RID: 492 RVA: 0x0002290A File Offset: 0x00020B0A
		// (set) Token: 0x060001ED RID: 493 RVA: 0x00022912 File Offset: 0x00020B12
		internal virtual Label lbSteam06 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001EE RID: 494 RVA: 0x0002291B File Offset: 0x00020B1B
		// (set) Token: 0x060001EF RID: 495 RVA: 0x00022923 File Offset: 0x00020B23
		internal virtual Label lbSteam07 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x0002292C File Offset: 0x00020B2C
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x00022934 File Offset: 0x00020B34
		internal virtual Label lbSteam08 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x0002293D File Offset: 0x00020B3D
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x00022945 File Offset: 0x00020B45
		internal virtual ColorDialog ColorDialog1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x0002294E File Offset: 0x00020B4E
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x00022956 File Offset: 0x00020B56
		internal virtual OpenFileDialog OpenFileDialog1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x0002295F File Offset: 0x00020B5F
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x00022968 File Offset: 0x00020B68
		internal virtual System.Windows.Forms.Timer Timer1
		{
			[CompilerGenerated]
			get
			{
				return this._Timer1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Timer1_Tick);
				System.Windows.Forms.Timer timer = this._Timer1;
				if (timer != null)
				{
					timer.Tick -= value2;
				}
				this._Timer1 = value;
				timer = this._Timer1;
				if (timer != null)
				{
					timer.Tick += value2;
				}
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x000229AB File Offset: 0x00020BAB
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x000229B4 File Offset: 0x00020BB4
		internal virtual Button cmFindLog
		{
			[CompilerGenerated]
			get
			{
				return this._cmFindLog;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmFindLog_Click);
				Button cmFindLog = this._cmFindLog;
				if (cmFindLog != null)
				{
					cmFindLog.Click -= value2;
				}
				this._cmFindLog = value;
				cmFindLog = this._cmFindLog;
				if (cmFindLog != null)
				{
					cmFindLog.Click += value2;
				}
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001FA RID: 506 RVA: 0x000229F7 File Offset: 0x00020BF7
		// (set) Token: 0x060001FB RID: 507 RVA: 0x00022A00 File Offset: 0x00020C00
		internal virtual Button cmScanLog
		{
			[CompilerGenerated]
			get
			{
				return this._cmScanLog;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmScanLog_Click);
				Button cmScanLog = this._cmScanLog;
				if (cmScanLog != null)
				{
					cmScanLog.Click -= value2;
				}
				this._cmScanLog = value;
				cmScanLog = this._cmScanLog;
				if (cmScanLog != null)
				{
					cmScanLog.Click += value2;
				}
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00022A43 File Offset: 0x00020C43
		// (set) Token: 0x060001FD RID: 509 RVA: 0x00022A4C File Offset: 0x00020C4C
		internal virtual Button cmCopy
		{
			[CompilerGenerated]
			get
			{
				return this._cmCopy;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmCopy_Click);
				Button cmCopy = this._cmCopy;
				if (cmCopy != null)
				{
					cmCopy.Click -= value2;
				}
				this._cmCopy = value;
				cmCopy = this._cmCopy;
				if (cmCopy != null)
				{
					cmCopy.Click += value2;
				}
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00022A8F File Offset: 0x00020C8F
		// (set) Token: 0x060001FF RID: 511 RVA: 0x00022A97 File Offset: 0x00020C97
		internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000200 RID: 512 RVA: 0x00022AA0 File Offset: 0x00020CA0
		// (set) Token: 0x06000201 RID: 513 RVA: 0x00022AA8 File Offset: 0x00020CA8
		internal virtual FontDialog FontDialog1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000202 RID: 514 RVA: 0x00022AB1 File Offset: 0x00020CB1
		// (set) Token: 0x06000203 RID: 515 RVA: 0x00022ABC File Offset: 0x00020CBC
		internal virtual Button cmAbout
		{
			[CompilerGenerated]
			get
			{
				return this._cmAbout;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmAbout_Click);
				Button cmAbout = this._cmAbout;
				if (cmAbout != null)
				{
					cmAbout.Click -= value2;
				}
				this._cmAbout = value;
				cmAbout = this._cmAbout;
				if (cmAbout != null)
				{
					cmAbout.Click += value2;
				}
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000204 RID: 516 RVA: 0x00022AFF File Offset: 0x00020CFF
		// (set) Token: 0x06000205 RID: 517 RVA: 0x00022B07 File Offset: 0x00020D07
		internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00022B10 File Offset: 0x00020D10
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00022B18 File Offset: 0x00020D18
		internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00022B21 File Offset: 0x00020D21
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00022B2C File Offset: 0x00020D2C
		internal virtual ComboBox cboLayoutY
		{
			[CompilerGenerated]
			get
			{
				return this._cboLayoutY;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboLayoutY_SelectedIndexChanged);
				ComboBox cboLayoutY = this._cboLayoutY;
				if (cboLayoutY != null)
				{
					cboLayoutY.SelectedIndexChanged -= value2;
				}
				this._cboLayoutY = value;
				cboLayoutY = this._cboLayoutY;
				if (cboLayoutY != null)
				{
					cboLayoutY.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00022B6F File Offset: 0x00020D6F
		// (set) Token: 0x0600020B RID: 523 RVA: 0x00022B77 File Offset: 0x00020D77
		internal virtual GroupBox gbRank { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00022B80 File Offset: 0x00020D80
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00022B88 File Offset: 0x00020D88
		internal virtual GroupBox gbLayout { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00022B91 File Offset: 0x00020D91
		// (set) Token: 0x0600020F RID: 527 RVA: 0x00022B9C File Offset: 0x00020D9C
		internal virtual ComboBox cboLayoutX
		{
			[CompilerGenerated]
			get
			{
				return this._cboLayoutX;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboLayoutX_SelectedIndexChanged);
				ComboBox cboLayoutX = this._cboLayoutX;
				if (cboLayoutX != null)
				{
					cboLayoutX.SelectedIndexChanged -= value2;
				}
				this._cboLayoutX = value;
				cboLayoutX = this._cboLayoutX;
				if (cboLayoutX != null)
				{
					cboLayoutX.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00022BDF File Offset: 0x00020DDF
		// (set) Token: 0x06000211 RID: 529 RVA: 0x00022BE7 File Offset: 0x00020DE7
		internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00022BF0 File Offset: 0x00020DF0
		// (set) Token: 0x06000213 RID: 531 RVA: 0x00022BF8 File Offset: 0x00020DF8
		internal virtual Button cmSizeRefresh
		{
			[CompilerGenerated]
			get
			{
				return this._cmSizeRefresh;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmSizeRefresh_Click);
				Button cmSizeRefresh = this._cmSizeRefresh;
				if (cmSizeRefresh != null)
				{
					cmSizeRefresh.Click -= value2;
				}
				this._cmSizeRefresh = value;
				cmSizeRefresh = this._cmSizeRefresh;
				if (cmSizeRefresh != null)
				{
					cmSizeRefresh.Click += value2;
				}
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000214 RID: 532 RVA: 0x00022C3B File Offset: 0x00020E3B
		// (set) Token: 0x06000215 RID: 533 RVA: 0x00022C44 File Offset: 0x00020E44
		internal virtual Button cmGUILite
		{
			[CompilerGenerated]
			get
			{
				return this._cmGUILite;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmGUILite_Click);
				Button cmGUILite = this._cmGUILite;
				if (cmGUILite != null)
				{
					cmGUILite.Click -= value2;
				}
				this._cmGUILite = value;
				cmGUILite = this._cmGUILite;
				if (cmGUILite != null)
				{
					cmGUILite.Click += value2;
				}
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00022C87 File Offset: 0x00020E87
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00022C90 File Offset: 0x00020E90
		internal virtual Button cmGUIDark
		{
			[CompilerGenerated]
			get
			{
				return this._cmGUIDark;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmGUIDark_Click);
				Button cmGUIDark = this._cmGUIDark;
				if (cmGUIDark != null)
				{
					cmGUIDark.Click -= value2;
				}
				this._cmGUIDark = value;
				cmGUIDark = this._cmGUIDark;
				if (cmGUIDark != null)
				{
					cmGUIDark.Click += value2;
				}
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00022CD3 File Offset: 0x00020ED3
		// (set) Token: 0x06000219 RID: 537 RVA: 0x00022CDC File Offset: 0x00020EDC
		internal virtual PictureBox pbStats
		{
			[CompilerGenerated]
			get
			{
				return this._pbStats;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.pbStats_Click);
				MouseEventHandler value3 = new MouseEventHandler(this.pbStats_MouseDown);
				EventHandler value4 = new EventHandler(this.pbStats_MouseLeave);
				MouseEventHandler value5 = new MouseEventHandler(this.pbStats_MouseMove);
				PictureBox pbStats = this._pbStats;
				if (pbStats != null)
				{
					pbStats.Click -= value2;
					pbStats.MouseDown -= value3;
					pbStats.MouseLeave -= value4;
					pbStats.MouseMove -= value5;
				}
				this._pbStats = value;
				pbStats = this._pbStats;
				if (pbStats != null)
				{
					pbStats.Click += value2;
					pbStats.MouseDown += value3;
					pbStats.MouseLeave += value4;
					pbStats.MouseMove += value5;
				}
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00022D7C File Offset: 0x00020F7C
		// (set) Token: 0x0600021B RID: 539 RVA: 0x00022D84 File Offset: 0x00020F84
		internal virtual Button cmTestData
		{
			[CompilerGenerated]
			get
			{
				return this._cmTestData;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmTestData_Click);
				Button cmTestData = this._cmTestData;
				if (cmTestData != null)
				{
					cmTestData.Click -= value2;
				}
				this._cmTestData = value;
				cmTestData = this._cmTestData;
				if (cmTestData != null)
				{
					cmTestData.Click += value2;
				}
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600021C RID: 540 RVA: 0x00022DC7 File Offset: 0x00020FC7
		// (set) Token: 0x0600021D RID: 541 RVA: 0x00022DD0 File Offset: 0x00020FD0
		internal virtual Button cmLastMatch
		{
			[CompilerGenerated]
			get
			{
				return this._cmLastMatch;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmLastMatch_Click);
				Button cmLastMatch = this._cmLastMatch;
				if (cmLastMatch != null)
				{
					cmLastMatch.Click -= value2;
				}
				this._cmLastMatch = value;
				cmLastMatch = this._cmLastMatch;
				if (cmLastMatch != null)
				{
					cmLastMatch.Click += value2;
				}
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600021E RID: 542 RVA: 0x00022E13 File Offset: 0x00021013
		// (set) Token: 0x0600021F RID: 543 RVA: 0x00022E1B File Offset: 0x0002101B
		internal virtual GroupBox gbFX { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000220 RID: 544 RVA: 0x00022E24 File Offset: 0x00021024
		// (set) Token: 0x06000221 RID: 545 RVA: 0x00022E2C File Offset: 0x0002102C
		internal virtual Label lbFXVar2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000222 RID: 546 RVA: 0x00022E35 File Offset: 0x00021035
		// (set) Token: 0x06000223 RID: 547 RVA: 0x00022E3D File Offset: 0x0002103D
		internal virtual Label lbFXVar4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000224 RID: 548 RVA: 0x00022E46 File Offset: 0x00021046
		// (set) Token: 0x06000225 RID: 549 RVA: 0x00022E50 File Offset: 0x00021050
		internal virtual Button cmFX3DC
		{
			[CompilerGenerated]
			get
			{
				return this._cmFX3DC;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmFX3DC_Click);
				Button cmFX3DC = this._cmFX3DC;
				if (cmFX3DC != null)
				{
					cmFX3DC.Click -= value2;
				}
				this._cmFX3DC = value;
				cmFX3DC = this._cmFX3DC;
				if (cmFX3DC != null)
				{
					cmFX3DC.Click += value2;
				}
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00022E93 File Offset: 0x00021093
		// (set) Token: 0x06000227 RID: 551 RVA: 0x00022E9C File Offset: 0x0002109C
		internal virtual ComboBox cboFXVar2
		{
			[CompilerGenerated]
			get
			{
				return this._cboFXVar2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboFX3D_SelectedIndexChanged);
				ComboBox cboFXVar = this._cboFXVar2;
				if (cboFXVar != null)
				{
					cboFXVar.SelectedIndexChanged -= value2;
				}
				this._cboFXVar2 = value;
				cboFXVar = this._cboFXVar2;
				if (cboFXVar != null)
				{
					cboFXVar.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00022EDF File Offset: 0x000210DF
		// (set) Token: 0x06000229 RID: 553 RVA: 0x00022EE8 File Offset: 0x000210E8
		internal virtual ComboBox cboFxVar4
		{
			[CompilerGenerated]
			get
			{
				return this._cboFxVar4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboFxVar4_SelectedIndexChanged);
				ComboBox cboFxVar = this._cboFxVar4;
				if (cboFxVar != null)
				{
					cboFxVar.SelectedIndexChanged -= value2;
				}
				this._cboFxVar4 = value;
				cboFxVar = this._cboFxVar4;
				if (cboFxVar != null)
				{
					cboFxVar.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00022F2B File Offset: 0x0002112B
		// (set) Token: 0x0600022B RID: 555 RVA: 0x00022F34 File Offset: 0x00021134
		internal virtual ComboBox cboFxVar3
		{
			[CompilerGenerated]
			get
			{
				return this._cboFxVar3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboFxVar3_SelectedIndexChanged);
				ComboBox cboFxVar = this._cboFxVar3;
				if (cboFxVar != null)
				{
					cboFxVar.SelectedIndexChanged -= value2;
				}
				this._cboFxVar3 = value;
				cboFxVar = this._cboFxVar3;
				if (cboFxVar != null)
				{
					cboFxVar.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600022C RID: 556 RVA: 0x00022F77 File Offset: 0x00021177
		// (set) Token: 0x0600022D RID: 557 RVA: 0x00022F7F File Offset: 0x0002117F
		internal virtual Label lbFXVar3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00022F88 File Offset: 0x00021188
		// (set) Token: 0x0600022F RID: 559 RVA: 0x00022F90 File Offset: 0x00021190
		internal virtual ComboBox cboFXVar1
		{
			[CompilerGenerated]
			get
			{
				return this._cboFXVar1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboFXMode_SelectedIndexChanged);
				ComboBox cboFXVar = this._cboFXVar1;
				if (cboFXVar != null)
				{
					cboFXVar.SelectedIndexChanged -= value2;
				}
				this._cboFXVar1 = value;
				cboFXVar = this._cboFXVar1;
				if (cboFXVar != null)
				{
					cboFXVar.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000230 RID: 560 RVA: 0x00022FD3 File Offset: 0x000211D3
		// (set) Token: 0x06000231 RID: 561 RVA: 0x00022FDB File Offset: 0x000211DB
		internal virtual Label lbFXVar1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00022FE4 File Offset: 0x000211E4
		// (set) Token: 0x06000233 RID: 563 RVA: 0x00022FEC File Offset: 0x000211EC
		internal virtual Button cmFXModeHelp
		{
			[CompilerGenerated]
			get
			{
				return this._cmFXModeHelp;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmFXModeHelp_Click);
				Button cmFXModeHelp = this._cmFXModeHelp;
				if (cmFXModeHelp != null)
				{
					cmFXModeHelp.Click -= value2;
				}
				this._cmFXModeHelp = value;
				cmFXModeHelp = this._cmFXModeHelp;
				if (cmFXModeHelp != null)
				{
					cmFXModeHelp.Click += value2;
				}
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000234 RID: 564 RVA: 0x0002302F File Offset: 0x0002122F
		// (set) Token: 0x06000235 RID: 565 RVA: 0x00023037 File Offset: 0x00021237
		internal virtual Label lbError1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000236 RID: 566 RVA: 0x00023040 File Offset: 0x00021240
		// (set) Token: 0x06000237 RID: 567 RVA: 0x00023048 File Offset: 0x00021248
		internal virtual Label lbError2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00023051 File Offset: 0x00021251
		// (set) Token: 0x06000239 RID: 569 RVA: 0x0002305C File Offset: 0x0002125C
		internal virtual CheckBox chkFX
		{
			[CompilerGenerated]
			get
			{
				return this._chkFX;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.chkFX_CheckedChanged);
				CheckBox chkFX = this._chkFX;
				if (chkFX != null)
				{
					chkFX.CheckedChanged -= value2;
				}
				this._chkFX = value;
				chkFX = this._chkFX;
				if (chkFX != null)
				{
					chkFX.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600023A RID: 570 RVA: 0x0002309F File Offset: 0x0002129F
		// (set) Token: 0x0600023B RID: 571 RVA: 0x000230A7 File Offset: 0x000212A7
		internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600023C RID: 572 RVA: 0x000230B0 File Offset: 0x000212B0
		// (set) Token: 0x0600023D RID: 573 RVA: 0x000230B8 File Offset: 0x000212B8
		internal virtual Button cmSave
		{
			[CompilerGenerated]
			get
			{
				return this._cmSave;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmSave_Click);
				Button cmSave = this._cmSave;
				if (cmSave != null)
				{
					cmSave.Click -= value2;
				}
				this._cmSave = value;
				cmSave = this._cmSave;
				if (cmSave != null)
				{
					cmSave.Click += value2;
				}
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600023E RID: 574 RVA: 0x000230FB File Offset: 0x000212FB
		// (set) Token: 0x0600023F RID: 575 RVA: 0x00023103 File Offset: 0x00021303
		internal virtual SaveFileDialog SaveFileDialog1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0002310C File Offset: 0x0002130C
		// (set) Token: 0x06000241 RID: 577 RVA: 0x00023114 File Offset: 0x00021314
		internal virtual CheckBox chkMismatch
		{
			[CompilerGenerated]
			get
			{
				return this._chkMismatch;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.chkMismatch_CheckedChanged);
				CheckBox chkMismatch = this._chkMismatch;
				if (chkMismatch != null)
				{
					chkMismatch.CheckedChanged -= value2;
				}
				this._chkMismatch = value;
				chkMismatch = this._chkMismatch;
				if (chkMismatch != null)
				{
					chkMismatch.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00023157 File Offset: 0x00021357
		// (set) Token: 0x06000243 RID: 579 RVA: 0x0002315F File Offset: 0x0002135F
		internal virtual ToolTip ToolTip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000244 RID: 580 RVA: 0x00023168 File Offset: 0x00021368
		// (set) Token: 0x06000245 RID: 581 RVA: 0x00023170 File Offset: 0x00021370
		internal virtual CheckBox chkTips
		{
			[CompilerGenerated]
			get
			{
				return this._chkTips;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.chkTips_CheckedChanged);
				CheckBox chkTips = this._chkTips;
				if (chkTips != null)
				{
					chkTips.CheckedChanged -= value2;
				}
				this._chkTips = value;
				chkTips = this._chkTips;
				if (chkTips != null)
				{
					chkTips.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000246 RID: 582 RVA: 0x000231B3 File Offset: 0x000213B3
		// (set) Token: 0x06000247 RID: 583 RVA: 0x000231BB File Offset: 0x000213BB
		internal virtual PictureBox pbNote1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000248 RID: 584 RVA: 0x000231C4 File Offset: 0x000213C4
		// (set) Token: 0x06000249 RID: 585 RVA: 0x000231CC File Offset: 0x000213CC
		internal virtual System.Windows.Forms.Timer timNote1
		{
			[CompilerGenerated]
			get
			{
				return this._timNote1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.timNote1_Tick);
				System.Windows.Forms.Timer timNote = this._timNote1;
				if (timNote != null)
				{
					timNote.Tick -= value2;
				}
				this._timNote1 = value;
				timNote = this._timNote1;
				if (timNote != null)
				{
					timNote.Tick += value2;
				}
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600024A RID: 586 RVA: 0x0002320F File Offset: 0x0002140F
		// (set) Token: 0x0600024B RID: 587 RVA: 0x00023217 File Offset: 0x00021417
		internal virtual GroupBox gbSound { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600024C RID: 588 RVA: 0x00023220 File Offset: 0x00021420
		// (set) Token: 0x0600024D RID: 589 RVA: 0x00023228 File Offset: 0x00021428
		internal virtual Button cmSound02
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound02;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound02_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound02_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound02;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound02 = value;
				cmSound = this._cmSound02;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600024E RID: 590 RVA: 0x000232A1 File Offset: 0x000214A1
		// (set) Token: 0x0600024F RID: 591 RVA: 0x000232AC File Offset: 0x000214AC
		internal virtual Button cmSound01
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound01;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmSound01_Click);
				MouseEventHandler value3 = new MouseEventHandler(this.cmSound01_MouseDown);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseHover);
				EventHandler value5 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound01;
				if (cmSound != null)
				{
					cmSound.Click -= value2;
					cmSound.MouseDown -= value3;
					cmSound.MouseHover -= value4;
					cmSound.MouseLeave -= value5;
				}
				this._cmSound01 = value;
				cmSound = this._cmSound01;
				if (cmSound != null)
				{
					cmSound.Click += value2;
					cmSound.MouseDown += value3;
					cmSound.MouseHover += value4;
					cmSound.MouseLeave += value5;
				}
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000250 RID: 592 RVA: 0x0002334C File Offset: 0x0002154C
		// (set) Token: 0x06000251 RID: 593 RVA: 0x00023354 File Offset: 0x00021554
		internal virtual Label lbSoundCurrent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000252 RID: 594 RVA: 0x0002335D File Offset: 0x0002155D
		// (set) Token: 0x06000253 RID: 595 RVA: 0x00023368 File Offset: 0x00021568
		internal virtual Button cmSound10
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound10;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound10_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound10_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound10;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound10 = value;
				cmSound = this._cmSound10;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000254 RID: 596 RVA: 0x000233E1 File Offset: 0x000215E1
		// (set) Token: 0x06000255 RID: 597 RVA: 0x000233EC File Offset: 0x000215EC
		internal virtual Button cmSound09
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound09;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound09_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound09_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound09;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound09 = value;
				cmSound = this._cmSound09;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00023465 File Offset: 0x00021665
		// (set) Token: 0x06000257 RID: 599 RVA: 0x00023470 File Offset: 0x00021670
		internal virtual Button cmSound08
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound08;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound08_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound08_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound08;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound08 = value;
				cmSound = this._cmSound08;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000258 RID: 600 RVA: 0x000234E9 File Offset: 0x000216E9
		// (set) Token: 0x06000259 RID: 601 RVA: 0x000234F4 File Offset: 0x000216F4
		internal virtual Button cmSound07
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound07;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound07_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound07_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound07;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound07 = value;
				cmSound = this._cmSound07;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0002356D File Offset: 0x0002176D
		// (set) Token: 0x0600025B RID: 603 RVA: 0x00023578 File Offset: 0x00021778
		internal virtual Button cmSound06
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound06;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound06_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound06_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound06;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound06 = value;
				cmSound = this._cmSound06;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600025C RID: 604 RVA: 0x000235F1 File Offset: 0x000217F1
		// (set) Token: 0x0600025D RID: 605 RVA: 0x000235FC File Offset: 0x000217FC
		internal virtual Button cmSound05
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound05;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound05_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound05_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound05;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound05 = value;
				cmSound = this._cmSound05;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00023675 File Offset: 0x00021875
		// (set) Token: 0x0600025F RID: 607 RVA: 0x00023680 File Offset: 0x00021880
		internal virtual Button cmSound04
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound04;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound04_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound04_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound04;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound04 = value;
				cmSound = this._cmSound04;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000260 RID: 608 RVA: 0x000236F9 File Offset: 0x000218F9
		// (set) Token: 0x06000261 RID: 609 RVA: 0x00023704 File Offset: 0x00021904
		internal virtual Button cmSound03
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound03;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound03_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound03_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound03;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound03 = value;
				cmSound = this._cmSound03;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000262 RID: 610 RVA: 0x0002377D File Offset: 0x0002197D
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00023788 File Offset: 0x00021988
		internal virtual Button cmRankSetup
		{
			[CompilerGenerated]
			get
			{
				return this._cmRankSetup;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmRankSetup_Click);
				Button cmRankSetup = this._cmRankSetup;
				if (cmRankSetup != null)
				{
					cmRankSetup.Click -= value2;
				}
				this._cmRankSetup = value;
				cmRankSetup = this._cmRankSetup;
				if (cmRankSetup != null)
				{
					cmRankSetup.Click += value2;
				}
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000264 RID: 612 RVA: 0x000237CB File Offset: 0x000219CB
		// (set) Token: 0x06000265 RID: 613 RVA: 0x000237D4 File Offset: 0x000219D4
		internal virtual Button cmNote3
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote3_Click);
				Button cmNote = this._cmNote3;
				if (cmNote != null)
				{
					cmNote.Click -= value2;
				}
				this._cmNote3 = value;
				cmNote = this._cmNote3;
				if (cmNote != null)
				{
					cmNote.Click += value2;
				}
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000266 RID: 614 RVA: 0x00023817 File Offset: 0x00021A17
		// (set) Token: 0x06000267 RID: 615 RVA: 0x00023820 File Offset: 0x00021A20
		internal virtual Button cmNote2
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote2_Click);
				Button cmNote = this._cmNote2;
				if (cmNote != null)
				{
					cmNote.Click -= value2;
				}
				this._cmNote2 = value;
				cmNote = this._cmNote2;
				if (cmNote != null)
				{
					cmNote.Click += value2;
				}
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00023863 File Offset: 0x00021A63
		// (set) Token: 0x06000269 RID: 617 RVA: 0x0002386C File Offset: 0x00021A6C
		internal virtual Button cmNote1
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote1_Click);
				Button cmNote = this._cmNote1;
				if (cmNote != null)
				{
					cmNote.Click -= value2;
				}
				this._cmNote1 = value;
				cmNote = this._cmNote1;
				if (cmNote != null)
				{
					cmNote.Click += value2;
				}
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600026A RID: 618 RVA: 0x000238AF File Offset: 0x00021AAF
		// (set) Token: 0x0600026B RID: 619 RVA: 0x000238B8 File Offset: 0x00021AB8
		internal virtual Button cmNote03Setup
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote03Setup;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote03Setup_Click_1);
				Button cmNote03Setup = this._cmNote03Setup;
				if (cmNote03Setup != null)
				{
					cmNote03Setup.Click -= value2;
				}
				this._cmNote03Setup = value;
				cmNote03Setup = this._cmNote03Setup;
				if (cmNote03Setup != null)
				{
					cmNote03Setup.Click += value2;
				}
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600026C RID: 620 RVA: 0x000238FB File Offset: 0x00021AFB
		// (set) Token: 0x0600026D RID: 621 RVA: 0x00023904 File Offset: 0x00021B04
		internal virtual Button cmNote02Setup
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote02Setup;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote02Setup_Click_1);
				Button cmNote02Setup = this._cmNote02Setup;
				if (cmNote02Setup != null)
				{
					cmNote02Setup.Click -= value2;
				}
				this._cmNote02Setup = value;
				cmNote02Setup = this._cmNote02Setup;
				if (cmNote02Setup != null)
				{
					cmNote02Setup.Click += value2;
				}
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00023947 File Offset: 0x00021B47
		// (set) Token: 0x0600026F RID: 623 RVA: 0x0002394F File Offset: 0x00021B4F
		internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00023958 File Offset: 0x00021B58
		// (set) Token: 0x06000271 RID: 625 RVA: 0x00023960 File Offset: 0x00021B60
		internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000272 RID: 626 RVA: 0x00023969 File Offset: 0x00021B69
		// (set) Token: 0x06000273 RID: 627 RVA: 0x00023974 File Offset: 0x00021B74
		internal virtual Button cmNote01Setup
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote01Setup;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote01Setup_Click_1);
				Button cmNote01Setup = this._cmNote01Setup;
				if (cmNote01Setup != null)
				{
					cmNote01Setup.Click -= value2;
				}
				this._cmNote01Setup = value;
				cmNote01Setup = this._cmNote01Setup;
				if (cmNote01Setup != null)
				{
					cmNote01Setup.Click += value2;
				}
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000274 RID: 628 RVA: 0x000239B7 File Offset: 0x00021BB7
		// (set) Token: 0x06000275 RID: 629 RVA: 0x000239BF File Offset: 0x00021BBF
		internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000276 RID: 630 RVA: 0x000239C8 File Offset: 0x00021BC8
		// (set) Token: 0x06000277 RID: 631 RVA: 0x000239D0 File Offset: 0x00021BD0
		internal virtual Button cmNameSetup
		{
			[CompilerGenerated]
			get
			{
				return this._cmNameSetup;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNameSetup_Click);
				Button cmNameSetup = this._cmNameSetup;
				if (cmNameSetup != null)
				{
					cmNameSetup.Click -= value2;
				}
				this._cmNameSetup = value;
				cmNameSetup = this._cmNameSetup;
				if (cmNameSetup != null)
				{
					cmNameSetup.Click += value2;
				}
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000278 RID: 632 RVA: 0x00023A13 File Offset: 0x00021C13
		// (set) Token: 0x06000279 RID: 633 RVA: 0x00023A1B File Offset: 0x00021C1B
		internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00023A24 File Offset: 0x00021C24
		// (set) Token: 0x0600027B RID: 635 RVA: 0x00023A2C File Offset: 0x00021C2C
		internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600027C RID: 636 RVA: 0x00023A35 File Offset: 0x00021C35
		// (set) Token: 0x0600027D RID: 637 RVA: 0x00023A3D File Offset: 0x00021C3D
		internal virtual PictureBox pbNote3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00023A46 File Offset: 0x00021C46
		// (set) Token: 0x0600027F RID: 639 RVA: 0x00023A4E File Offset: 0x00021C4E
		internal virtual PictureBox pbNote4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00023A57 File Offset: 0x00021C57
		// (set) Token: 0x06000281 RID: 641 RVA: 0x00023A5F File Offset: 0x00021C5F
		internal virtual PictureBox pbNote2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000282 RID: 642 RVA: 0x00023A68 File Offset: 0x00021C68
		// (set) Token: 0x06000283 RID: 643 RVA: 0x00023A70 File Offset: 0x00021C70
		internal virtual Button cmNote4
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote4_Click);
				Button cmNote = this._cmNote4;
				if (cmNote != null)
				{
					cmNote.Click -= value2;
				}
				this._cmNote4 = value;
				cmNote = this._cmNote4;
				if (cmNote != null)
				{
					cmNote.Click += value2;
				}
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000284 RID: 644 RVA: 0x00023AB3 File Offset: 0x00021CB3
		// (set) Token: 0x06000285 RID: 645 RVA: 0x00023ABC File Offset: 0x00021CBC
		internal virtual Button cmNote04Setup
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote04Setup;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote04Setup_Click_1);
				Button cmNote04Setup = this._cmNote04Setup;
				if (cmNote04Setup != null)
				{
					cmNote04Setup.Click -= value2;
				}
				this._cmNote04Setup = value;
				cmNote04Setup = this._cmNote04Setup;
				if (cmNote04Setup != null)
				{
					cmNote04Setup.Click += value2;
				}
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00023AFF File Offset: 0x00021CFF
		// (set) Token: 0x06000287 RID: 647 RVA: 0x00023B07 File Offset: 0x00021D07
		internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000288 RID: 648 RVA: 0x00023B10 File Offset: 0x00021D10
		// (set) Token: 0x06000289 RID: 649 RVA: 0x00023B18 File Offset: 0x00021D18
		internal virtual Button cmNote04_Play
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote04_Play;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote04_Play_Click);
				Button cmNote04_Play = this._cmNote04_Play;
				if (cmNote04_Play != null)
				{
					cmNote04_Play.Click -= value2;
				}
				this._cmNote04_Play = value;
				cmNote04_Play = this._cmNote04_Play;
				if (cmNote04_Play != null)
				{
					cmNote04_Play.Click += value2;
				}
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00023B5B File Offset: 0x00021D5B
		// (set) Token: 0x0600028B RID: 651 RVA: 0x00023B64 File Offset: 0x00021D64
		internal virtual Button cmNote03_Play
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote03_Play;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote03_Play_Click);
				Button cmNote03_Play = this._cmNote03_Play;
				if (cmNote03_Play != null)
				{
					cmNote03_Play.Click -= value2;
				}
				this._cmNote03_Play = value;
				cmNote03_Play = this._cmNote03_Play;
				if (cmNote03_Play != null)
				{
					cmNote03_Play.Click += value2;
				}
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00023BA7 File Offset: 0x00021DA7
		// (set) Token: 0x0600028D RID: 653 RVA: 0x00023BB0 File Offset: 0x00021DB0
		internal virtual Button cmNote02_Play
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote02_Play;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote02_Play_Click);
				Button cmNote02_Play = this._cmNote02_Play;
				if (cmNote02_Play != null)
				{
					cmNote02_Play.Click -= value2;
				}
				this._cmNote02_Play = value;
				cmNote02_Play = this._cmNote02_Play;
				if (cmNote02_Play != null)
				{
					cmNote02_Play.Click += value2;
				}
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600028E RID: 654 RVA: 0x00023BF3 File Offset: 0x00021DF3
		// (set) Token: 0x0600028F RID: 655 RVA: 0x00023BFC File Offset: 0x00021DFC
		internal virtual Button cmNote01_Play
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote01_Play;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote01_Play_Click);
				Button cmNote01_Play = this._cmNote01_Play;
				if (cmNote01_Play != null)
				{
					cmNote01_Play.Click -= value2;
				}
				this._cmNote01_Play = value;
				cmNote01_Play = this._cmNote01_Play;
				if (cmNote01_Play != null)
				{
					cmNote01_Play.Click += value2;
				}
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000290 RID: 656 RVA: 0x00023C3F File Offset: 0x00021E3F
		// (set) Token: 0x06000291 RID: 657 RVA: 0x00023C48 File Offset: 0x00021E48
		internal virtual Button cmSound15
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound15;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound15_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound15_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound15;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound15 = value;
				cmSound = this._cmSound15;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00023CC1 File Offset: 0x00021EC1
		// (set) Token: 0x06000293 RID: 659 RVA: 0x00023CCC File Offset: 0x00021ECC
		internal virtual Button cmSound14
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound14;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound14_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound14_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound14;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound14 = value;
				cmSound = this._cmSound14;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00023D45 File Offset: 0x00021F45
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00023D50 File Offset: 0x00021F50
		internal virtual Button cmSound13
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound13;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound13_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound13_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound13;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound13 = value;
				cmSound = this._cmSound13;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000296 RID: 662 RVA: 0x00023DC9 File Offset: 0x00021FC9
		// (set) Token: 0x06000297 RID: 663 RVA: 0x00023DD4 File Offset: 0x00021FD4
		internal virtual Button cmSound12
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound12;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound12_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound12_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound12;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound12 = value;
				cmSound = this._cmSound12;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00023E4D File Offset: 0x0002204D
		// (set) Token: 0x06000299 RID: 665 RVA: 0x00023E58 File Offset: 0x00022058
		internal virtual Button cmSound11
		{
			[CompilerGenerated]
			get
			{
				return this._cmSound11;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.cmSound11_MouseDown);
				EventHandler value3 = new EventHandler(this.cmSound11_MouseHover);
				EventHandler value4 = new EventHandler(this.cmSound01_MouseLeave);
				Button cmSound = this._cmSound11;
				if (cmSound != null)
				{
					cmSound.MouseDown -= value2;
					cmSound.MouseHover -= value3;
					cmSound.MouseLeave -= value4;
				}
				this._cmSound11 = value;
				cmSound = this._cmSound11;
				if (cmSound != null)
				{
					cmSound.MouseDown += value2;
					cmSound.MouseHover += value3;
					cmSound.MouseLeave += value4;
				}
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00023ED1 File Offset: 0x000220D1
		// (set) Token: 0x0600029B RID: 667 RVA: 0x00023EDC File Offset: 0x000220DC
		internal virtual HScrollBar scrVolume
		{
			[CompilerGenerated]
			get
			{
				return this._scrVolume;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.scrVolume_ValueChanged);
				HScrollBar scrVolume = this._scrVolume;
				if (scrVolume != null)
				{
					scrVolume.ValueChanged -= value2;
				}
				this._scrVolume = value;
				scrVolume = this._scrVolume;
				if (scrVolume != null)
				{
					scrVolume.ValueChanged += value2;
				}
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00023F1F File Offset: 0x0002211F
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00023F27 File Offset: 0x00022127
		internal virtual Label lbVolume { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600029E RID: 670 RVA: 0x00023F30 File Offset: 0x00022130
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00023F38 File Offset: 0x00022138
		internal virtual Button cmNote_PlayAll
		{
			[CompilerGenerated]
			get
			{
				return this._cmNote_PlayAll;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNote_PlayAll_Click);
				Button cmNote_PlayAll = this._cmNote_PlayAll;
				if (cmNote_PlayAll != null)
				{
					cmNote_PlayAll.Click -= value2;
				}
				this._cmNote_PlayAll = value;
				cmNote_PlayAll = this._cmNote_PlayAll;
				if (cmNote_PlayAll != null)
				{
					cmNote_PlayAll.Click += value2;
				}
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00023F7B File Offset: 0x0002217B
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x00023F84 File Offset: 0x00022184
		internal virtual ComboBox cboNoteSpace
		{
			[CompilerGenerated]
			get
			{
				return this._cboNoteSpace;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboNoteSpace_SelectedIndexChanged);
				ComboBox cboNoteSpace = this._cboNoteSpace;
				if (cboNoteSpace != null)
				{
					cboNoteSpace.SelectedIndexChanged -= value2;
				}
				this._cboNoteSpace = value;
				cboNoteSpace = this._cboNoteSpace;
				if (cboNoteSpace != null)
				{
					cboNoteSpace.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x00023FC7 File Offset: 0x000221C7
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00023FCF File Offset: 0x000221CF
		internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x00023FD8 File Offset: 0x000221D8
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00023FE0 File Offset: 0x000221E0
		internal virtual CheckBox chkPosition { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x00023FE9 File Offset: 0x000221E9
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x00023FF1 File Offset: 0x000221F1
		internal virtual ContextMenuStrip tsmPlayer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x00023FFA File Offset: 0x000221FA
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x00024004 File Offset: 0x00022204
		internal virtual ToolStripMenuItem tsmPlayer_Relic
		{
			[CompilerGenerated]
			get
			{
				return this._tsmPlayer_Relic;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmPlayer_Relic_Click);
				ToolStripMenuItem tsmPlayer_Relic = this._tsmPlayer_Relic;
				if (tsmPlayer_Relic != null)
				{
					tsmPlayer_Relic.Click -= value2;
				}
				this._tsmPlayer_Relic = value;
				tsmPlayer_Relic = this._tsmPlayer_Relic;
				if (tsmPlayer_Relic != null)
				{
					tsmPlayer_Relic.Click += value2;
				}
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00024047 File Offset: 0x00022247
		// (set) Token: 0x060002AB RID: 683 RVA: 0x00024050 File Offset: 0x00022250
		internal virtual ToolStripMenuItem tsmPlayer_OrgAT
		{
			[CompilerGenerated]
			get
			{
				return this._tsmPlayer_OrgAT;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmPlayer_OrgAT_Click);
				ToolStripMenuItem tsmPlayer_OrgAT = this._tsmPlayer_OrgAT;
				if (tsmPlayer_OrgAT != null)
				{
					tsmPlayer_OrgAT.Click -= value2;
				}
				this._tsmPlayer_OrgAT = value;
				tsmPlayer_OrgAT = this._tsmPlayer_OrgAT;
				if (tsmPlayer_OrgAT != null)
				{
					tsmPlayer_OrgAT.Click += value2;
				}
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00024093 File Offset: 0x00022293
		// (set) Token: 0x060002AD RID: 685 RVA: 0x0002409C File Offset: 0x0002229C
		internal virtual CheckBox chkPopUp
		{
			[CompilerGenerated]
			get
			{
				return this._chkPopUp;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.chkPopUp_CheckedChanged);
				CheckBox chkPopUp = this._chkPopUp;
				if (chkPopUp != null)
				{
					chkPopUp.CheckedChanged -= value2;
				}
				this._chkPopUp = value;
				chkPopUp = this._chkPopUp;
				if (chkPopUp != null)
				{
					chkPopUp.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000240DF File Offset: 0x000222DF
		// (set) Token: 0x060002AF RID: 687 RVA: 0x000240E8 File Offset: 0x000222E8
		internal virtual ToolStripMenuItem tsmPlayer_OrgFaction
		{
			[CompilerGenerated]
			get
			{
				return this._tsmPlayer_OrgFaction;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmPlayer_OrgFaction_Click);
				ToolStripMenuItem tsmPlayer_OrgFaction = this._tsmPlayer_OrgFaction;
				if (tsmPlayer_OrgFaction != null)
				{
					tsmPlayer_OrgFaction.Click -= value2;
				}
				this._tsmPlayer_OrgFaction = value;
				tsmPlayer_OrgFaction = this._tsmPlayer_OrgFaction;
				if (tsmPlayer_OrgFaction != null)
				{
					tsmPlayer_OrgFaction.Click += value2;
				}
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x0002412B File Offset: 0x0002232B
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x00024134 File Offset: 0x00022334
		internal virtual ToolStripMenuItem tsmPlayer_OrgPlayercard
		{
			[CompilerGenerated]
			get
			{
				return this._tsmPlayer_OrgPlayercard;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmPlayer_OrgPlayercard_Click);
				ToolStripMenuItem tsmPlayer_OrgPlayercard = this._tsmPlayer_OrgPlayercard;
				if (tsmPlayer_OrgPlayercard != null)
				{
					tsmPlayer_OrgPlayercard.Click -= value2;
				}
				this._tsmPlayer_OrgPlayercard = value;
				tsmPlayer_OrgPlayercard = this._tsmPlayer_OrgPlayercard;
				if (tsmPlayer_OrgPlayercard != null)
				{
					tsmPlayer_OrgPlayercard.Click += value2;
				}
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00024177 File Offset: 0x00022377
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x00024180 File Offset: 0x00022380
		internal virtual ToolStripMenuItem tsmPlayer_Google
		{
			[CompilerGenerated]
			get
			{
				return this._tsmPlayer_Google;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmPlayer_Google_Click);
				ToolStripMenuItem tsmPlayer_Google = this._tsmPlayer_Google;
				if (tsmPlayer_Google != null)
				{
					tsmPlayer_Google.Click -= value2;
				}
				this._tsmPlayer_Google = value;
				tsmPlayer_Google = this._tsmPlayer_Google;
				if (tsmPlayer_Google != null)
				{
					tsmPlayer_Google.Click += value2;
				}
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x000241C3 File Offset: 0x000223C3
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x000241CB File Offset: 0x000223CB
		internal virtual ContextMenuStrip tsmAudio { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x000241D4 File Offset: 0x000223D4
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x000241DC File Offset: 0x000223DC
		internal virtual ToolStripMenuItem tsmSetVolTo100
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo100;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo100_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo100;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo100 = value;
				tsmSetVolTo = this._tsmSetVolTo100;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x0002421F File Offset: 0x0002241F
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00024228 File Offset: 0x00022428
		internal virtual ToolStripMenuItem tsmSetVolTo90
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo90;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo90_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo90;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo90 = value;
				tsmSetVolTo = this._tsmSetVolTo90;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0002426B File Offset: 0x0002246B
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00024274 File Offset: 0x00022474
		internal virtual ToolStripMenuItem tsmSetVolTo80
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo80;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo80_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo80;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo80 = value;
				tsmSetVolTo = this._tsmSetVolTo80;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002BC RID: 700 RVA: 0x000242B7 File Offset: 0x000224B7
		// (set) Token: 0x060002BD RID: 701 RVA: 0x000242C0 File Offset: 0x000224C0
		internal virtual ToolStripMenuItem tsmSetVolTo70
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo70;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo70_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo70;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo70 = value;
				tsmSetVolTo = this._tsmSetVolTo70;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00024303 File Offset: 0x00022503
		// (set) Token: 0x060002BF RID: 703 RVA: 0x0002430C File Offset: 0x0002250C
		internal virtual ToolStripMenuItem tsmSetVolTo60
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo60;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo60_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo60;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo60 = value;
				tsmSetVolTo = this._tsmSetVolTo60;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0002434F File Offset: 0x0002254F
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00024358 File Offset: 0x00022558
		internal virtual ToolStripMenuItem tsmSetVolTo50
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo50;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo50_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo50;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo50 = value;
				tsmSetVolTo = this._tsmSetVolTo50;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x0002439B File Offset: 0x0002259B
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x000243A4 File Offset: 0x000225A4
		internal virtual ToolStripMenuItem tsmSetVolTo40
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo40;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo40_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo40;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo40 = value;
				tsmSetVolTo = this._tsmSetVolTo40;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x000243E7 File Offset: 0x000225E7
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x000243F0 File Offset: 0x000225F0
		internal virtual ToolStripMenuItem tsmSetVolTo30
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo30;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo30_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo30;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo30 = value;
				tsmSetVolTo = this._tsmSetVolTo30;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00024433 File Offset: 0x00022633
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x0002443C File Offset: 0x0002263C
		internal virtual ToolStripMenuItem tsmSetVolTo20
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo20;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo20_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo20;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo20 = value;
				tsmSetVolTo = this._tsmSetVolTo20;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0002447F File Offset: 0x0002267F
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00024488 File Offset: 0x00022688
		internal virtual ToolStripMenuItem tsmSetVolTo10
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSetVolTo10;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSetVolTo10_Click);
				ToolStripMenuItem tsmSetVolTo = this._tsmSetVolTo10;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click -= value2;
				}
				this._tsmSetVolTo10 = value;
				tsmSetVolTo = this._tsmSetVolTo10;
				if (tsmSetVolTo != null)
				{
					tsmSetVolTo.Click += value2;
				}
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060002CA RID: 714 RVA: 0x000244CB File Offset: 0x000226CB
		// (set) Token: 0x060002CB RID: 715 RVA: 0x000244D3 File Offset: 0x000226D3
		internal virtual ToolStripSeparator ToolStripMenuItem1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060002CC RID: 716 RVA: 0x000244DC File Offset: 0x000226DC
		// (set) Token: 0x060002CD RID: 717 RVA: 0x000244E4 File Offset: 0x000226E4
		internal virtual ToolStripMenuItem tsmSelectFile
		{
			[CompilerGenerated]
			get
			{
				return this._tsmSelectFile;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tsmSelectFile_Click);
				ToolStripMenuItem tsmSelectFile = this._tsmSelectFile;
				if (tsmSelectFile != null)
				{
					tsmSelectFile.Click -= value2;
				}
				this._tsmSelectFile = value;
				tsmSelectFile = this._tsmSelectFile;
				if (tsmSelectFile != null)
				{
					tsmSelectFile.Click += value2;
				}
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060002CE RID: 718 RVA: 0x00024527 File Offset: 0x00022727
		// (set) Token: 0x060002CF RID: 719 RVA: 0x00024530 File Offset: 0x00022730
		internal virtual Button cmAudioStop
		{
			[CompilerGenerated]
			get
			{
				return this._cmAudioStop;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmAudioStop_Click);
				Button cmAudioStop = this._cmAudioStop;
				if (cmAudioStop != null)
				{
					cmAudioStop.Click -= value2;
				}
				this._cmAudioStop = value;
				cmAudioStop = this._cmAudioStop;
				if (cmAudioStop != null)
				{
					cmAudioStop.Click += value2;
				}
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x00024573 File Offset: 0x00022773
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x0002457B File Offset: 0x0002277B
		internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00024584 File Offset: 0x00022784
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x0002458C File Offset: 0x0002278C
		internal virtual TextBox tbYoff
		{
			[CompilerGenerated]
			get
			{
				return this._tbYoff;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.tbYoff_KeyPress);
				TextBox tbYoff = this._tbYoff;
				if (tbYoff != null)
				{
					tbYoff.KeyPress -= value2;
				}
				this._tbYoff = value;
				tbYoff = this._tbYoff;
				if (tbYoff != null)
				{
					tbYoff.KeyPress += value2;
				}
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x000245CF File Offset: 0x000227CF
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x000245D8 File Offset: 0x000227D8
		internal virtual TextBox tbXoff
		{
			[CompilerGenerated]
			get
			{
				return this._tbXoff;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.tbXoff_KeyPress);
				TextBox tbXoff = this._tbXoff;
				if (tbXoff != null)
				{
					tbXoff.KeyPress -= value2;
				}
				this._tbXoff = value;
				tbXoff = this._tbXoff;
				if (tbXoff != null)
				{
					tbXoff.KeyPress += value2;
				}
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x0002461B File Offset: 0x0002281B
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00024624 File Offset: 0x00022824
		internal virtual TextBox tbYSize
		{
			[CompilerGenerated]
			get
			{
				return this._tbYSize;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tbYSize_TextChanged);
				KeyPressEventHandler value3 = new KeyPressEventHandler(this.tbYSize_KeyPress);
				TextBox tbYSize = this._tbYSize;
				if (tbYSize != null)
				{
					tbYSize.TextChanged -= value2;
					tbYSize.KeyPress -= value3;
				}
				this._tbYSize = value;
				tbYSize = this._tbYSize;
				if (tbYSize != null)
				{
					tbYSize.TextChanged += value2;
					tbYSize.KeyPress += value3;
				}
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00024682 File Offset: 0x00022882
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x0002468C File Offset: 0x0002288C
		internal virtual TextBox tbXsize
		{
			[CompilerGenerated]
			get
			{
				return this._tbXsize;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.tbXsize_TextChanged);
				KeyPressEventHandler value3 = new KeyPressEventHandler(this.tbXsize_KeyPress);
				TextBox tbXsize = this._tbXsize;
				if (tbXsize != null)
				{
					tbXsize.TextChanged -= value2;
					tbXsize.KeyPress -= value3;
				}
				this._tbXsize = value;
				tbXsize = this._tbXsize;
				if (tbXsize != null)
				{
					tbXsize.TextChanged += value2;
					tbXsize.KeyPress += value3;
				}
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002DA RID: 730 RVA: 0x000246EA File Offset: 0x000228EA
		// (set) Token: 0x060002DB RID: 731 RVA: 0x000246F4 File Offset: 0x000228F4
		internal virtual Button cmDefaults
		{
			[CompilerGenerated]
			get
			{
				return this._cmDefaults;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmDefaults_Click);
				Button cmDefaults = this._cmDefaults;
				if (cmDefaults != null)
				{
					cmDefaults.Click -= value2;
				}
				this._cmDefaults = value;
				cmDefaults = this._cmDefaults;
				if (cmDefaults != null)
				{
					cmDefaults.Click += value2;
				}
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002DC RID: 732 RVA: 0x00024737 File Offset: 0x00022937
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00024740 File Offset: 0x00022940
		internal virtual Button cmStatsModeHelp
		{
			[CompilerGenerated]
			get
			{
				return this._cmStatsModeHelp;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmStatsModeHelp_Click);
				Button cmStatsModeHelp = this._cmStatsModeHelp;
				if (cmStatsModeHelp != null)
				{
					cmStatsModeHelp.Click -= value2;
				}
				this._cmStatsModeHelp = value;
				cmStatsModeHelp = this._cmStatsModeHelp;
				if (cmStatsModeHelp != null)
				{
					cmStatsModeHelp.Click += value2;
				}
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00024783 File Offset: 0x00022983
		// (set) Token: 0x060002DF RID: 735 RVA: 0x0002478C File Offset: 0x0002298C
		internal virtual CheckBox chkSmoothAni
		{
			[CompilerGenerated]
			get
			{
				return this._chkSmoothAni;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.chkSmoothAni_CheckedChanged);
				CheckBox chkSmoothAni = this._chkSmoothAni;
				if (chkSmoothAni != null)
				{
					chkSmoothAni.CheckedChanged -= value2;
				}
				this._chkSmoothAni = value;
				chkSmoothAni = this._chkSmoothAni;
				if (chkSmoothAni != null)
				{
					chkSmoothAni.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x0400007A RID: 122
		public static Color CDialogPick;

		// Token: 0x0400007B RID: 123
		private string Celo_Windowstate;

		// Token: 0x0400007C RID: 124
		private long Celo_Top;

		// Token: 0x0400007D RID: 125
		private long Celo_Left;

		// Token: 0x0400007E RID: 126
		private long Celo_Width;

		// Token: 0x0400007F RID: 127
		private long Celo_Height;

		// Token: 0x04000080 RID: 128
		private bool Celo_Popup;

		// Token: 0x04000081 RID: 129
		private int Celo_PopupHit;

		// Token: 0x04000082 RID: 130
		private object CELO_PopUpObject;

		// Token: 0x04000083 RID: 131
		private int STATS_SizeX;

		// Token: 0x04000084 RID: 132
		private int STATS_SizeY;

		// Token: 0x04000085 RID: 133
		private Bitmap NAME_bmp;

		// Token: 0x04000086 RID: 134
		private Bitmap NAME_OVLBmp;

		// Token: 0x04000087 RID: 135
		private bool FLAG_Loading;

		// Token: 0x04000088 RID: 136
		private bool FLAG_Drawing;

		// Token: 0x04000089 RID: 137
		private bool FLAG_ShowMismatch;

		// Token: 0x0400008A RID: 138
		private string PATH_Game;

		// Token: 0x0400008B RID: 139
		private string PATH_GamePath;

		// Token: 0x0400008C RID: 140
		private string PATH_BackgroundImage;

		// Token: 0x0400008D RID: 141
		private string PATH_BackgroundImagePath;

		// Token: 0x0400008E RID: 142
		public static string PATH_DlgBmp = "";

		// Token: 0x0400008F RID: 143
		public static string PATH_DlgBmpPath = "";

		// Token: 0x04000090 RID: 144
		public static string PATH_Note01_Bmp = "";

		// Token: 0x04000091 RID: 145
		public static string PATH_Note02_Bmp = "";

		// Token: 0x04000092 RID: 146
		public static string PATH_Note03_Bmp = "";

		// Token: 0x04000093 RID: 147
		public static string PATH_Note04_Bmp = "";

		// Token: 0x04000094 RID: 148
		public static string PATH_Note01_BmpPath = "";

		// Token: 0x04000095 RID: 149
		public static string PATH_Note02_BmpPath = "";

		// Token: 0x04000096 RID: 150
		public static string PATH_Note03_BmpPath = "";

		// Token: 0x04000097 RID: 151
		public static string PATH_Note04_BmpPath = "";

		// Token: 0x04000098 RID: 152
		public static string PATH_DlgOVLBmp = "";

		// Token: 0x04000099 RID: 153
		public static string PATH_DlgOVLBmpPath = "";

		// Token: 0x0400009A RID: 154
		public static string PATH_Name_OVLBmp = "";

		// Token: 0x0400009B RID: 155
		public static string PATH_Note01_OVLBmp = "";

		// Token: 0x0400009C RID: 156
		public static string PATH_Note02_OVLBmp = "";

		// Token: 0x0400009D RID: 157
		public static string PATH_Note03_OVLBmp = "";

		// Token: 0x0400009E RID: 158
		public static string PATH_Note04_OVLBmp = "";

		// Token: 0x0400009F RID: 159
		public static string PATH_Name_OVLBmpPath = "";

		// Token: 0x040000A0 RID: 160
		public static string PATH_Note01_OVLBmpPath = "";

		// Token: 0x040000A1 RID: 161
		public static string PATH_Note02_OVLBmpPath = "";

		// Token: 0x040000A2 RID: 162
		public static string PATH_Note03_OVLBmpPath = "";

		// Token: 0x040000A3 RID: 163
		public static string PATH_Note04_OVLBmpPath = "";

		// Token: 0x040000A4 RID: 164
		private string PATH_SaveStatsImage;

		// Token: 0x040000A5 RID: 165
		private string PATH_SoundFiles;

		// Token: 0x040000A6 RID: 166
		private bool SCAN_Enabled;

		// Token: 0x040000A7 RID: 167
		public static Font FONT_Setup;

		// Token: 0x040000A8 RID: 168
		public static string FONT_Setup_Name;

		// Token: 0x040000A9 RID: 169
		public static string FONT_Setup_Size;

		// Token: 0x040000AA RID: 170
		public static string FONT_Setup_Bold;

		// Token: 0x040000AB RID: 171
		public static string FONT_Setup_Italic;

		// Token: 0x040000AC RID: 172
		public static Font FONT_Note01;

		// Token: 0x040000AD RID: 173
		public static string FONT_Note01_Name;

		// Token: 0x040000AE RID: 174
		public static string FONT_Note01_Size;

		// Token: 0x040000AF RID: 175
		public static string FONT_Note01_Bold;

		// Token: 0x040000B0 RID: 176
		public static string FONT_Note01_Italic;

		// Token: 0x040000B1 RID: 177
		public static Font FONT_Note02;

		// Token: 0x040000B2 RID: 178
		public static string FONT_Note02_Name;

		// Token: 0x040000B3 RID: 179
		public static string FONT_Note02_Size;

		// Token: 0x040000B4 RID: 180
		public static string FONT_Note02_Bold;

		// Token: 0x040000B5 RID: 181
		public static string FONT_Note02_Italic;

		// Token: 0x040000B6 RID: 182
		public static Font FONT_Note03;

		// Token: 0x040000B7 RID: 183
		public static string FONT_Note03_Name;

		// Token: 0x040000B8 RID: 184
		public static string FONT_Note03_Size;

		// Token: 0x040000B9 RID: 185
		public static string FONT_Note03_Bold;

		// Token: 0x040000BA RID: 186
		public static string FONT_Note03_Italic;

		// Token: 0x040000BB RID: 187
		public static Font FONT_Note04;

		// Token: 0x040000BC RID: 188
		public static string FONT_Note04_Name;

		// Token: 0x040000BD RID: 189
		public static string FONT_Note04_Size;

		// Token: 0x040000BE RID: 190
		public static string FONT_Note04_Bold;

		// Token: 0x040000BF RID: 191
		public static string FONT_Note04_Italic;

		// Token: 0x040000C0 RID: 192
		public static Font FONT_Rank;

		// Token: 0x040000C1 RID: 193
		public static string FONT_Rank_Name;

		// Token: 0x040000C2 RID: 194
		public static string FONT_Rank_Size;

		// Token: 0x040000C3 RID: 195
		public static string FONT_Rank_Bold;

		// Token: 0x040000C4 RID: 196
		public static string FONT_Rank_Italic;

		// Token: 0x040000C5 RID: 197
		public static Font FONT_Name;

		// Token: 0x040000C6 RID: 198
		public static string FONT_Name_Name;

		// Token: 0x040000C7 RID: 199
		public static string FONT_Name_Size;

		// Token: 0x040000C8 RID: 200
		public static string FONT_Name_Bold;

		// Token: 0x040000C9 RID: 201
		public static string FONT_Name_Italic;

		// Token: 0x040000CA RID: 202
		private Color COLOR_Back1;

		// Token: 0x040000CB RID: 203
		private Color COLOR_Back2;

		// Token: 0x040000CC RID: 204
		private int COLOR_Back_Dir;

		// Token: 0x040000CD RID: 205
		private int GUI_ColorMode;

		// Token: 0x040000CE RID: 206
		private float LAB_Height;

		// Token: 0x040000CF RID: 207
		private clsGlobal.t_Box[] LAB_Rank;

		// Token: 0x040000D0 RID: 208
		private clsGlobal.t_Box[] LAB_Name;

		// Token: 0x040000D1 RID: 209
		private clsGlobal.t_Box[] LAB_Fact;

		// Token: 0x040000D2 RID: 210
		private StringFormat[] LAB_Name_Align;

		// Token: 0x040000D3 RID: 211
		private int GUI_Mouse_PlrIndex;

		// Token: 0x040000D4 RID: 212
		private bool GUI_Active;

		// Token: 0x040000D5 RID: 213
		private string[] PlrName;

		// Token: 0x040000D6 RID: 214
		private string[] PlrRank;

		// Token: 0x040000D7 RID: 215
		private string[] PlrFact;

		// Token: 0x040000D8 RID: 216
		private string[] PlrSteam;

		// Token: 0x040000D9 RID: 217
		private string[] PlrName_Last;

		// Token: 0x040000DA RID: 218
		private string[] PlrRank_Last;

		// Token: 0x040000DB RID: 219
		private string[] PlrFact_Last;

		// Token: 0x040000DC RID: 220
		private string[] PlrSteam_Last;

		// Token: 0x040000DD RID: 221
		private clsGlobal.t_LabelSetup LSRank;

		// Token: 0x040000DE RID: 222
		private clsGlobal.t_LabelSetup LSName;

		// Token: 0x040000DF RID: 223
		public static clsGlobal.t_LabelSetup LSNote01;

		// Token: 0x040000E0 RID: 224
		public static clsGlobal.t_LabelSetup LSNote02;

		// Token: 0x040000E1 RID: 225
		public static clsGlobal.t_LabelSetup LSNote03;

		// Token: 0x040000E2 RID: 226
		public static clsGlobal.t_LabelSetup LSNote04;

		// Token: 0x040000E3 RID: 227
		private int NOTE_Spacing;

		// Token: 0x040000E4 RID: 228
		private bool[] CFX3DActive;

		// Token: 0x040000E5 RID: 229
		private string[,] CFX3DVar;

		// Token: 0x040000E6 RID: 230
		private Color[] CFX3DC;

		// Token: 0x040000E7 RID: 231
		private string[] Note01_Text;

		// Token: 0x040000E8 RID: 232
		private string[] Note02_Text;

		// Token: 0x040000E9 RID: 233
		private string[] Note03_Text;

		// Token: 0x040000EA RID: 234
		private string[] Note04_Text;

		// Token: 0x040000EB RID: 235
		private clsGlobal.t_NoteAnimation NoteAnim_Setup;

		// Token: 0x040000EC RID: 236
		private clsGlobal.t_NoteAnimation NoteAnim01;

		// Token: 0x040000ED RID: 237
		private clsGlobal.t_NoteAnimation NoteAnim02;

		// Token: 0x040000EE RID: 238
		private clsGlobal.t_NoteAnimation NoteAnim03;

		// Token: 0x040000EF RID: 239
		private clsGlobal.t_NoteAnimation NoteAnim04;

		// Token: 0x040000F0 RID: 240
		private string[] NoteAnim01_Text;

		// Token: 0x040000F1 RID: 241
		private string[] NoteAnim02_Text;

		// Token: 0x040000F2 RID: 242
		private string[] NoteAnim03_Text;

		// Token: 0x040000F3 RID: 243
		private string[] NoteAnim04_Text;

		// Token: 0x040000F4 RID: 244
		private Bitmap Note01_Bmp;

		// Token: 0x040000F5 RID: 245
		private Bitmap Note02_Bmp;

		// Token: 0x040000F6 RID: 246
		private Bitmap Note03_Bmp;

		// Token: 0x040000F7 RID: 247
		private Bitmap Note04_Bmp;

		// Token: 0x040000F8 RID: 248
		private Graphics Note01_Gfx;

		// Token: 0x040000F9 RID: 249
		private Graphics Note02_Gfx;

		// Token: 0x040000FA RID: 250
		private Graphics Note03_Gfx;

		// Token: 0x040000FB RID: 251
		private Graphics Note04_Gfx;

		// Token: 0x040000FC RID: 252
		public static Bitmap Note_BackBmp;

		// Token: 0x040000FD RID: 253
		public static Bitmap Note01_BackBmp;

		// Token: 0x040000FE RID: 254
		public static Bitmap Note02_BackBmp;

		// Token: 0x040000FF RID: 255
		public static Bitmap Note03_BackBmp;

		// Token: 0x04000100 RID: 256
		public static Bitmap Note04_BackBmp;

		// Token: 0x04000101 RID: 257
		public static Bitmap Note_OVLBmp;

		// Token: 0x04000102 RID: 258
		public static Bitmap Note01_OVLBmp;

		// Token: 0x04000103 RID: 259
		public static Bitmap Note02_OVLBmp;

		// Token: 0x04000104 RID: 260
		public static Bitmap Note03_OVLBmp;

		// Token: 0x04000105 RID: 261
		public static Bitmap Note04_OVLBmp;

		// Token: 0x04000106 RID: 262
		public static string Note_BackScale;

		// Token: 0x04000107 RID: 263
		private string Note01_BackScale;

		// Token: 0x04000108 RID: 264
		private string Note02_BackScale;

		// Token: 0x04000109 RID: 265
		private string Note03_BackScale;

		// Token: 0x0400010A RID: 266
		private string Note04_BackScale;

		// Token: 0x0400010B RID: 267
		public string Note_OVLScale;

		// Token: 0x0400010C RID: 268
		private string Note01_OVLScale;

		// Token: 0x0400010D RID: 269
		private string Note02_OVLScale;

		// Token: 0x0400010E RID: 270
		private string Note03_OVLScale;

		// Token: 0x0400010F RID: 271
		private string Note04_OVLScale;

		// Token: 0x04000110 RID: 272
		private string[] SOUND_File;

		// Token: 0x04000111 RID: 273
		private string[] SOUND_Vol;

		// Token: 0x04000112 RID: 274
		private bool ANIMATION_Smooth;

		// Token: 0x04000113 RID: 275
		private long CLOCK_TicksPerMS;

		// Token: 0x04000114 RID: 276
		private float CLOCK_Frames;

		// Token: 0x0400019C RID: 412
		private long $STATIC$Timer1_Tick$20211C12809D$SecCnt;

		// Token: 0x0400019D RID: 413
		private bool $STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog;

		// Token: 0x0400019E RID: 414
		private StaticLocalInitFlag $STATIC$Timer1_Tick$20211C12809D$FLAG_CheckingLog$Init;
	}
}
