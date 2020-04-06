using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MakoCelo.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
	// Token: 0x02000009 RID: 9
	[DesignerGenerated]
	public partial class frmLabelSetup : Form
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002214 File Offset: 0x00000414
		public frmLabelSetup()
		{
			base.Load += this.frmLabelSetup_Load;
			this._LSetup = default(clsGlobal.t_LabelSetup);
			this._HideSizeOptions = false;
			this._HideImageOptions = false;
			this._HideScalingOptions = false;
			this._HideSizeAll = false;
			this._HideFormColor = false;
			this._Cancel = true;
			this.InitializeComponent();
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000041A1 File Offset: 0x000023A1
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000041A9 File Offset: 0x000023A9
		internal virtual GroupBox gbLabel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000041B2 File Offset: 0x000023B2
		// (set) Token: 0x0600001A RID: 26 RVA: 0x000041BC File Offset: 0x000023BC
		internal virtual Button cmShadowColor
		{
			[CompilerGenerated]
			get
			{
				return this._cmShadowColor;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmShadowColor_Click);
				Button cmShadowColor = this._cmShadowColor;
				if (cmShadowColor != null)
				{
					cmShadowColor.Click -= value2;
				}
				this._cmShadowColor = value;
				cmShadowColor = this._cmShadowColor;
				if (cmShadowColor != null)
				{
					cmShadowColor.Click += value2;
				}
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000041FF File Offset: 0x000023FF
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00004207 File Offset: 0x00002407
		internal virtual Label lbR5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00004210 File Offset: 0x00002410
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00004218 File Offset: 0x00002418
		internal virtual ComboBox cbo3D
		{
			[CompilerGenerated]
			get
			{
				return this._cbo3D;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cbo3D_SelectedIndexChanged);
				ComboBox cbo3D = this._cbo3D;
				if (cbo3D != null)
				{
					cbo3D.SelectedIndexChanged -= value2;
				}
				this._cbo3D = value;
				cbo3D = this._cbo3D;
				if (cbo3D != null)
				{
					cbo3D.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000425B File Offset: 0x0000245B
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00004264 File Offset: 0x00002464
		internal virtual ComboBox cboA2
		{
			[CompilerGenerated]
			get
			{
				return this._cboA2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboA2_SelectedIndexChanged);
				ComboBox cboA = this._cboA2;
				if (cboA != null)
				{
					cboA.SelectedIndexChanged -= value2;
				}
				this._cboA2 = value;
				cboA = this._cboA2;
				if (cboA != null)
				{
					cboA.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000042A7 File Offset: 0x000024A7
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000042AF File Offset: 0x000024AF
		internal virtual Label lbR4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000042B8 File Offset: 0x000024B8
		// (set) Token: 0x06000024 RID: 36 RVA: 0x000042C0 File Offset: 0x000024C0
		internal virtual Button cmBR
		{
			[CompilerGenerated]
			get
			{
				return this._cmBR;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmBR_Click);
				Button cmBR = this._cmBR;
				if (cmBR != null)
				{
					cmBR.Click -= value2;
				}
				this._cmBR = value;
				cmBR = this._cmBR;
				if (cmBR != null)
				{
					cmBR.Click += value2;
				}
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00004303 File Offset: 0x00002503
		// (set) Token: 0x06000026 RID: 38 RVA: 0x0000430C File Offset: 0x0000250C
		internal virtual Button cmBD
		{
			[CompilerGenerated]
			get
			{
				return this._cmBD;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmBD_Click);
				Button cmBD = this._cmBD;
				if (cmBD != null)
				{
					cmBD.Click -= value2;
				}
				this._cmBD = value;
				cmBD = this._cmBD;
				if (cmBD != null)
				{
					cmBD.Click += value2;
				}
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000434F File Offset: 0x0000254F
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00004358 File Offset: 0x00002558
		internal virtual Button cmFR
		{
			[CompilerGenerated]
			get
			{
				return this._cmFR;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmFR_Click);
				Button cmFR = this._cmFR;
				if (cmFR != null)
				{
					cmFR.Click -= value2;
				}
				this._cmFR = value;
				cmFR = this._cmFR;
				if (cmFR != null)
				{
					cmFR.Click += value2;
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000029 RID: 41 RVA: 0x0000439B File Offset: 0x0000259B
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000043A4 File Offset: 0x000025A4
		internal virtual Button cmFD
		{
			[CompilerGenerated]
			get
			{
				return this._cmFD;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmFD_Click);
				Button cmFD = this._cmFD;
				if (cmFD != null)
				{
					cmFD.Click -= value2;
				}
				this._cmFD = value;
				cmFD = this._cmFD;
				if (cmFD != null)
				{
					cmFD.Click += value2;
				}
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000043E7 File Offset: 0x000025E7
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000043F0 File Offset: 0x000025F0
		internal virtual Button cmB2
		{
			[CompilerGenerated]
			get
			{
				return this._cmB2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmB2_Click);
				Button cmB = this._cmB2;
				if (cmB != null)
				{
					cmB.Click -= value2;
				}
				this._cmB2 = value;
				cmB = this._cmB2;
				if (cmB != null)
				{
					cmB.Click += value2;
				}
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00004433 File Offset: 0x00002633
		// (set) Token: 0x0600002E RID: 46 RVA: 0x0000443C File Offset: 0x0000263C
		internal virtual Button cmB1
		{
			[CompilerGenerated]
			get
			{
				return this._cmB1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmB1_Click);
				Button cmB = this._cmB1;
				if (cmB != null)
				{
					cmB.Click -= value2;
				}
				this._cmB1 = value;
				cmB = this._cmB1;
				if (cmB != null)
				{
					cmB.Click += value2;
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002F RID: 47 RVA: 0x0000447F File Offset: 0x0000267F
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00004487 File Offset: 0x00002687
		internal virtual Label lbR2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00004490 File Offset: 0x00002690
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00004498 File Offset: 0x00002698
		internal virtual Button cmF2
		{
			[CompilerGenerated]
			get
			{
				return this._cmF2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmF2_Click);
				Button cmF = this._cmF2;
				if (cmF != null)
				{
					cmF.Click -= value2;
				}
				this._cmF2 = value;
				cmF = this._cmF2;
				if (cmF != null)
				{
					cmF.Click += value2;
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000044DB File Offset: 0x000026DB
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000044E4 File Offset: 0x000026E4
		internal virtual Button cmRankFont
		{
			[CompilerGenerated]
			get
			{
				return this._cmRankFont;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmRankFont_Click);
				Button cmRankFont = this._cmRankFont;
				if (cmRankFont != null)
				{
					cmRankFont.Click -= value2;
				}
				this._cmRankFont = value;
				cmRankFont = this._cmRankFont;
				if (cmRankFont != null)
				{
					cmRankFont.Click += value2;
				}
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00004527 File Offset: 0x00002727
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00004530 File Offset: 0x00002730
		internal virtual Button cmF1
		{
			[CompilerGenerated]
			get
			{
				return this._cmF1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmF1_Click);
				Button cmF = this._cmF1;
				if (cmF != null)
				{
					cmF.Click -= value2;
				}
				this._cmF1 = value;
				cmF = this._cmF1;
				if (cmF != null)
				{
					cmF.Click += value2;
				}
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00004573 File Offset: 0x00002773
		// (set) Token: 0x06000038 RID: 56 RVA: 0x0000457B File Offset: 0x0000277B
		internal virtual Label lbR1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00004584 File Offset: 0x00002784
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000458C File Offset: 0x0000278C
		internal virtual Label lbR3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00004595 File Offset: 0x00002795
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000045A0 File Offset: 0x000027A0
		internal virtual ComboBox cboA1
		{
			[CompilerGenerated]
			get
			{
				return this._cboA1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboA1_SelectedIndexChanged);
				ComboBox cboA = this._cboA1;
				if (cboA != null)
				{
					cboA.SelectedIndexChanged -= value2;
				}
				this._cboA1 = value;
				cboA = this._cboA1;
				if (cboA != null)
				{
					cboA.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000045E3 File Offset: 0x000027E3
		// (set) Token: 0x0600003E RID: 62 RVA: 0x000045EB File Offset: 0x000027EB
		internal virtual PictureBox pbNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000045F4 File Offset: 0x000027F4
		// (set) Token: 0x06000040 RID: 64 RVA: 0x000045FC File Offset: 0x000027FC
		internal virtual Button cmCancel
		{
			[CompilerGenerated]
			get
			{
				return this._cmCancel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmCancel_Click);
				Button cmCancel = this._cmCancel;
				if (cmCancel != null)
				{
					cmCancel.Click -= value2;
				}
				this._cmCancel = value;
				cmCancel = this._cmCancel;
				if (cmCancel != null)
				{
					cmCancel.Click += value2;
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000041 RID: 65 RVA: 0x0000463F File Offset: 0x0000283F
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00004648 File Offset: 0x00002848
		internal virtual Button cmOK
		{
			[CompilerGenerated]
			get
			{
				return this._cmOK;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmOK_Click);
				Button cmOK = this._cmOK;
				if (cmOK != null)
				{
					cmOK.Click -= value2;
				}
				this._cmOK = value;
				cmOK = this._cmOK;
				if (cmOK != null)
				{
					cmOK.Click += value2;
				}
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000468B File Offset: 0x0000288B
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00004693 File Offset: 0x00002893
		internal virtual ColorDialog ColorDialog1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000045 RID: 69 RVA: 0x0000469C File Offset: 0x0000289C
		// (set) Token: 0x06000046 RID: 70 RVA: 0x000046A4 File Offset: 0x000028A4
		internal virtual Label lbSize { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000046AD File Offset: 0x000028AD
		// (set) Token: 0x06000048 RID: 72 RVA: 0x000046B5 File Offset: 0x000028B5
		internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000046BE File Offset: 0x000028BE
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000046C6 File Offset: 0x000028C6
		internal virtual TextBox tbWidth { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000046CF File Offset: 0x000028CF
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000046D7 File Offset: 0x000028D7
		internal virtual TextBox tbHeight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000046E0 File Offset: 0x000028E0
		// (set) Token: 0x0600004E RID: 78 RVA: 0x000046E8 File Offset: 0x000028E8
		internal virtual GroupBox gbBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000046F1 File Offset: 0x000028F1
		// (set) Token: 0x06000050 RID: 80 RVA: 0x000046FC File Offset: 0x000028FC
		internal virtual ComboBox cboScaling
		{
			[CompilerGenerated]
			get
			{
				return this._cboScaling;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboScaling_SelectedIndexChanged);
				ComboBox cboScaling = this._cboScaling;
				if (cboScaling != null)
				{
					cboScaling.SelectedIndexChanged -= value2;
				}
				this._cboScaling = value;
				cboScaling = this._cboScaling;
				if (cboScaling != null)
				{
					cboScaling.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000051 RID: 81 RVA: 0x0000473F File Offset: 0x0000293F
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00004747 File Offset: 0x00002947
		internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00004750 File Offset: 0x00002950
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00004758 File Offset: 0x00002958
		internal virtual Button cmFormColor
		{
			[CompilerGenerated]
			get
			{
				return this._cmFormColor;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmFormColor_Click);
				Button cmFormColor = this._cmFormColor;
				if (cmFormColor != null)
				{
					cmFormColor.Click -= value2;
				}
				this._cmFormColor = value;
				cmFormColor = this._cmFormColor;
				if (cmFormColor != null)
				{
					cmFormColor.Click += value2;
				}
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000055 RID: 85 RVA: 0x0000479B File Offset: 0x0000299B
		// (set) Token: 0x06000056 RID: 86 RVA: 0x000047A4 File Offset: 0x000029A4
		internal virtual Button cmFormImage
		{
			[CompilerGenerated]
			get
			{
				return this._cmFormImage;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmFormImage_Click);
				Button cmFormImage = this._cmFormImage;
				if (cmFormImage != null)
				{
					cmFormImage.Click -= value2;
				}
				this._cmFormImage = value;
				cmFormImage = this._cmFormImage;
				if (cmFormImage != null)
				{
					cmFormImage.Click += value2;
				}
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000047E7 File Offset: 0x000029E7
		// (set) Token: 0x06000058 RID: 88 RVA: 0x000047F0 File Offset: 0x000029F0
		internal virtual Button cmNoImage
		{
			[CompilerGenerated]
			get
			{
				return this._cmNoImage;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmNoImage_Click);
				Button cmNoImage = this._cmNoImage;
				if (cmNoImage != null)
				{
					cmNoImage.Click -= value2;
				}
				this._cmNoImage = value;
				cmNoImage = this._cmNoImage;
				if (cmNoImage != null)
				{
					cmNoImage.Click += value2;
				}
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00004833 File Offset: 0x00002A33
		// (set) Token: 0x0600005A RID: 90 RVA: 0x0000483C File Offset: 0x00002A3C
		internal virtual Button cmCopy01
		{
			[CompilerGenerated]
			get
			{
				return this._cmCopy01;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmCopy01_Click);
				Button cmCopy = this._cmCopy01;
				if (cmCopy != null)
				{
					cmCopy.Click -= value2;
				}
				this._cmCopy01 = value;
				cmCopy = this._cmCopy01;
				if (cmCopy != null)
				{
					cmCopy.Click += value2;
				}
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600005B RID: 91 RVA: 0x0000487F File Offset: 0x00002A7F
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00004888 File Offset: 0x00002A88
		internal virtual Button cmCopy02
		{
			[CompilerGenerated]
			get
			{
				return this._cmCopy02;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmCopy02_Click);
				Button cmCopy = this._cmCopy02;
				if (cmCopy != null)
				{
					cmCopy.Click -= value2;
				}
				this._cmCopy02 = value;
				cmCopy = this._cmCopy02;
				if (cmCopy != null)
				{
					cmCopy.Click += value2;
				}
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600005D RID: 93 RVA: 0x000048CB File Offset: 0x00002ACB
		// (set) Token: 0x0600005E RID: 94 RVA: 0x000048D4 File Offset: 0x00002AD4
		internal virtual Button cmCopy03
		{
			[CompilerGenerated]
			get
			{
				return this._cmCopy03;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmCopy03_Click);
				Button cmCopy = this._cmCopy03;
				if (cmCopy != null)
				{
					cmCopy.Click -= value2;
				}
				this._cmCopy03 = value;
				cmCopy = this._cmCopy03;
				if (cmCopy != null)
				{
					cmCopy.Click += value2;
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00004917 File Offset: 0x00002B17
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00004920 File Offset: 0x00002B20
		internal virtual Button cmCopy04
		{
			[CompilerGenerated]
			get
			{
				return this._cmCopy04;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmCopy04_Click);
				Button cmCopy = this._cmCopy04;
				if (cmCopy != null)
				{
					cmCopy.Click -= value2;
				}
				this._cmCopy04 = value;
				cmCopy = this._cmCopy04;
				if (cmCopy != null)
				{
					cmCopy.Click += value2;
				}
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00004963 File Offset: 0x00002B63
		// (set) Token: 0x06000062 RID: 98 RVA: 0x0000496C File Offset: 0x00002B6C
		internal virtual Button cmCopyAll
		{
			[CompilerGenerated]
			get
			{
				return this._cmCopyAll;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmCopyAll_Click);
				Button cmCopyAll = this._cmCopyAll;
				if (cmCopyAll != null)
				{
					cmCopyAll.Click -= value2;
				}
				this._cmCopyAll = value;
				cmCopyAll = this._cmCopyAll;
				if (cmCopyAll != null)
				{
					cmCopyAll.Click += value2;
				}
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000063 RID: 99 RVA: 0x000049AF File Offset: 0x00002BAF
		// (set) Token: 0x06000064 RID: 100 RVA: 0x000049B8 File Offset: 0x00002BB8
		internal virtual Button cmCopySize
		{
			[CompilerGenerated]
			get
			{
				return this._cmCopySize;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmCopySize_Click);
				Button cmCopySize = this._cmCopySize;
				if (cmCopySize != null)
				{
					cmCopySize.Click -= value2;
				}
				this._cmCopySize = value;
				cmCopySize = this._cmCopySize;
				if (cmCopySize != null)
				{
					cmCopySize.Click += value2;
				}
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000049FB File Offset: 0x00002BFB
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00004A04 File Offset: 0x00002C04
		internal virtual ComboBox cboDepth
		{
			[CompilerGenerated]
			get
			{
				return this._cboDepth;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboDepth_SelectedIndexChanged);
				ComboBox cboDepth = this._cboDepth;
				if (cboDepth != null)
				{
					cboDepth.SelectedIndexChanged -= value2;
				}
				this._cboDepth = value;
				cboDepth = this._cboDepth;
				if (cboDepth != null)
				{
					cboDepth.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00004A47 File Offset: 0x00002C47
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00004A4F File Offset: 0x00002C4F
		internal virtual Label lbDepth { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00004A58 File Offset: 0x00002C58
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00004A60 File Offset: 0x00002C60
		internal virtual ComboBox cboOVLScaling
		{
			[CompilerGenerated]
			get
			{
				return this._cboOVLScaling;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboOVLScaling_SelectedIndexChanged);
				ComboBox cboOVLScaling = this._cboOVLScaling;
				if (cboOVLScaling != null)
				{
					cboOVLScaling.SelectedIndexChanged -= value2;
				}
				this._cboOVLScaling = value;
				cboOVLScaling = this._cboOVLScaling;
				if (cboOVLScaling != null)
				{
					cboOVLScaling.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00004AA3 File Offset: 0x00002CA3
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00004AAB File Offset: 0x00002CAB
		internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00004AB4 File Offset: 0x00002CB4
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00004ABC File Offset: 0x00002CBC
		internal virtual Button cmOverlay
		{
			[CompilerGenerated]
			get
			{
				return this._cmOverlay;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmOverlay_Click);
				Button cmOverlay = this._cmOverlay;
				if (cmOverlay != null)
				{
					cmOverlay.Click -= value2;
				}
				this._cmOverlay = value;
				cmOverlay = this._cmOverlay;
				if (cmOverlay != null)
				{
					cmOverlay.Click += value2;
				}
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00004AFF File Offset: 0x00002CFF
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00004B08 File Offset: 0x00002D08
		internal virtual Button cmOVLNoImage
		{
			[CompilerGenerated]
			get
			{
				return this._cmOVLNoImage;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmOVLNoImage_Click);
				Button cmOVLNoImage = this._cmOVLNoImage;
				if (cmOVLNoImage != null)
				{
					cmOVLNoImage.Click -= value2;
				}
				this._cmOVLNoImage = value;
				cmOVLNoImage = this._cmOVLNoImage;
				if (cmOVLNoImage != null)
				{
					cmOVLNoImage.Click += value2;
				}
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00004B4B File Offset: 0x00002D4B
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00004B53 File Offset: 0x00002D53
		internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00004B5C File Offset: 0x00002D5C
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00004B64 File Offset: 0x00002D64
		internal virtual ToolTip ToolTip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00004B6D File Offset: 0x00002D6D
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00004B75 File Offset: 0x00002D75
		public clsGlobal.t_LabelSetup LSetup
		{
			get
			{
				return this._LSetup;
			}
			set
			{
				this._LSetup = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00004B7E File Offset: 0x00002D7E
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00004B86 File Offset: 0x00002D86
		public bool HideSizeOptions
		{
			get
			{
				return this._HideSizeOptions;
			}
			set
			{
				this._HideSizeOptions = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00004B8F File Offset: 0x00002D8F
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00004B97 File Offset: 0x00002D97
		public bool HideImageOptions
		{
			get
			{
				return this._HideImageOptions;
			}
			set
			{
				this._HideImageOptions = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00004BA0 File Offset: 0x00002DA0
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00004BA8 File Offset: 0x00002DA8
		public bool HideScalingOptions
		{
			get
			{
				return this._HideScalingOptions;
			}
			set
			{
				this._HideScalingOptions = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00004BB1 File Offset: 0x00002DB1
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00004BB9 File Offset: 0x00002DB9
		public bool HideSizeAll
		{
			get
			{
				return this._HideSizeAll;
			}
			set
			{
				this._HideSizeAll = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00004BC2 File Offset: 0x00002DC2
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00004BCA File Offset: 0x00002DCA
		public bool HideFormColor
		{
			get
			{
				return this._HideFormColor;
			}
			set
			{
				this._HideFormColor = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00004BD3 File Offset: 0x00002DD3
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00004BDB File Offset: 0x00002DDB
		public bool Cancel
		{
			get
			{
				return this._Cancel;
			}
			set
			{
				this._Cancel = value;
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004BE4 File Offset: 0x00002DE4
		private void cmOK_Click(object sender, EventArgs e)
		{
			checked
			{
				long num = (long)Math.Round(Conversion.Val(this.tbWidth.Text));
				if (num < 1L)
				{
					num = 1L;
				}
				if (32000L < num)
				{
					num = 32000L;
				}
				this._LSetup.Width = (int)num;
				num = (long)Math.Round(Conversion.Val(this.tbHeight.Text));
				if (num < 1L)
				{
					num = 1L;
				}
				if (32000L < num)
				{
					num = 32000L;
				}
				this._LSetup.Height = (int)num;
				this._Cancel = false;
				base.Close();
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00004C76 File Offset: 0x00002E76
		private void cmCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004C7E File Offset: 0x00002E7E
		private void cmF1_Click(object sender, EventArgs e)
		{
			this.ColorDialog1.Color = this._LSetup.F1;
			this.ColorDialog1.ShowDialog();
			this._LSetup.F1 = this.ColorDialog1.Color;
			this.GFX_DrawStats();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004CBE File Offset: 0x00002EBE
		private void cmF2_Click(object sender, EventArgs e)
		{
			this.ColorDialog1.Color = this._LSetup.F2;
			this.ColorDialog1.ShowDialog();
			this._LSetup.F2 = this.ColorDialog1.Color;
			this.GFX_DrawStats();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004CFE File Offset: 0x00002EFE
		private void cmB1_Click(object sender, EventArgs e)
		{
			this.ColorDialog1.Color = this._LSetup.B1;
			this.ColorDialog1.ShowDialog();
			this._LSetup.B1 = this.ColorDialog1.Color;
			this.GFX_DrawStats();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004D3E File Offset: 0x00002F3E
		private void cmB2_Click(object sender, EventArgs e)
		{
			this.ColorDialog1.Color = this._LSetup.B2;
			this.ColorDialog1.ShowDialog();
			this._LSetup.B2 = this.ColorDialog1.Color;
			this.GFX_DrawStats();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004D80 File Offset: 0x00002F80
		private void frmLabelSetup_Load(object sender, EventArgs e)
		{
			this.ToolTip_Setup();
			if (MyProject.Forms.frmMain.chkTips.Checked)
			{
				this.ToolTip1.Active = true;
			}
			else
			{
				this.ToolTip1.Active = false;
			}
			this.cboA1.Items.Add("100%");
			this.cboA1.Items.Add("90%");
			this.cboA1.Items.Add("80%");
			this.cboA1.Items.Add("70%");
			this.cboA1.Items.Add("60%");
			this.cboA1.Items.Add("50%");
			this.cboA1.Items.Add("40%");
			this.cboA1.Items.Add("30%");
			this.cboA1.Items.Add("20%");
			this.cboA1.Items.Add("10%");
			this.cboA1.Items.Add("0%");
			this.cboA1.Text = Strings.Format(this._LSetup.O1, "#0") + "%";
			this.cboA2.Items.Add("100%");
			this.cboA2.Items.Add("90%");
			this.cboA2.Items.Add("80%");
			this.cboA2.Items.Add("70%");
			this.cboA2.Items.Add("60%");
			this.cboA2.Items.Add("50%");
			this.cboA2.Items.Add("40%");
			this.cboA2.Items.Add("30%");
			this.cboA2.Items.Add("20%");
			this.cboA2.Items.Add("10%");
			this.cboA2.Items.Add("0%");
			this.cboA2.Text = Strings.Format(this._LSetup.O2, "#0") + "%";
			this.cbo3D.Items.Add("--");
			this.cbo3D.Items.Add("45°");
			this.cbo3D.Items.Add("90°");
			this.cbo3D.Items.Add("135°");
			this.cbo3D.Items.Add("180°");
			this.cbo3D.Items.Add("225°");
			this.cbo3D.Items.Add("270°");
			this.cbo3D.Items.Add("315°");
			this.cbo3D.Items.Add("360°");
			this.cbo3D.Text = this._LSetup.ShadowDir;
			this.cboDepth.Items.Add("0");
			this.cboDepth.Items.Add("1");
			this.cboDepth.Items.Add("2");
			this.cboDepth.Items.Add("3");
			this.cboDepth.Items.Add("4");
			this.cboDepth.Items.Add("5");
			this.cboDepth.Text = this._LSetup.ShadowDepth;
			this.tbWidth.Text = Conversions.ToString(this._LSetup.Width);
			this.tbHeight.Text = Conversions.ToString(this._LSetup.Height);
			this.cboScaling.Items.Add("0 - Normal");
			this.cboScaling.Items.Add("1 - Tile");
			this.cboScaling.Items.Add("2 - Fit");
			checked
			{
				this.cboScaling.SelectedIndex = (int)Math.Round(Conversion.Val(this._LSetup.Scaling));
				this.cboOVLScaling.Items.Add("0 - Normal");
				this.cboOVLScaling.Items.Add("1 - Tile");
				this.cboOVLScaling.Items.Add("2 - Fit");
				this.cboOVLScaling.SelectedIndex = (int)Math.Round(Conversion.Val(this._LSetup.OVLScaling));
				if (this.HideSizeOptions)
				{
					this.tbWidth.Enabled = false;
					this.tbHeight.Enabled = false;
				}
				if (this.HideImageOptions)
				{
					this.cmFormColor.Enabled = false;
					this.cmFormImage.Enabled = false;
					this.cmNoImage.Enabled = false;
					this.cmOVLNoImage.Enabled = false;
					this.cmOverlay.Enabled = false;
					this.cboOVLScaling.Enabled = false;
				}
				if (this.HideScalingOptions)
				{
					this.cboScaling.Enabled = false;
				}
				if (this.HideSizeAll)
				{
					this.cmCopySize.Enabled = false;
				}
				if (this.HideFormColor)
				{
					this.cmFormColor.Enabled = false;
				}
				this.tbWidth.Text = Conversions.ToString(this._LSetup.Width);
				this.tbHeight.Text = Conversions.ToString(this._LSetup.Height);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000535C File Offset: 0x0000355C
		private void ToolTip_Setup()
		{
			this.ToolTip1.SetToolTip(this.cmF1, "Set text gradient color #1.");
			this.ToolTip1.SetToolTip(this.cmF2, "Set text gradient color #2.");
			this.ToolTip1.SetToolTip(this.cmFD, "Set the text gradient direction to Down.");
			this.ToolTip1.SetToolTip(this.cmFR, "Set the text gradient direction to Sideways.");
			this.ToolTip1.SetToolTip(this.cmF1, "Set background gradient color #1.");
			this.ToolTip1.SetToolTip(this.cmF2, "Set background gradient color #2.");
			this.ToolTip1.SetToolTip(this.cmFD, "Set the background gradient direction to Down.");
			this.ToolTip1.SetToolTip(this.cmFR, "Set the background gradient direction to Sideways.");
			this.ToolTip1.SetToolTip(this.cboA1, "Set background Alpha/Opacity #1. Set low with no background gives blur effect.");
			this.ToolTip1.SetToolTip(this.cboA2, "Set background Alpha/Opacity #2. Set low with no background gives blur effect.");
			this.ToolTip1.SetToolTip(this.cmShadowColor, "Set text shadow color.");
			this.ToolTip1.SetToolTip(this.cbo3D, "Set text shadow location.0/360 is East.");
			this.ToolTip1.SetToolTip(this.cboDepth, "Set text shadow XY offset.");
			this.ToolTip1.SetToolTip(this.cmFormColor, "Set the background image color. Not used for NOTES.");
			this.ToolTip1.SetToolTip(this.cmNoImage, "Clear the current background image.");
			this.ToolTip1.SetToolTip(this.cmFormImage, "Select a background image.\rFor best results use images the same size as the NOTE/CELO object.");
			this.ToolTip1.SetToolTip(this.cboScaling, "Set how the background image will be scaled/drawn.\rFor best results use NORMAL or TILE.");
			this.ToolTip1.SetToolTip(this.cmOVLNoImage, "Clear the current overlay image.");
			this.ToolTip1.SetToolTip(this.cmOverlay, "Select an overlay image. Image should be a PNG with alpha.\rCan have green screen areas for stream chromakey/overlay.\rFor best results use images the same size as the NOTE/CELO object.");
			this.ToolTip1.SetToolTip(this.cboOVLScaling, "Set how the CELO overlay image will be scaled/drawn.\rFor best results use NORMAL or TILE.");
			this.ToolTip1.SetToolTip(this.cmCopy01, "Set this text setup style to NOTE #1 style.");
			this.ToolTip1.SetToolTip(this.cmCopy02, "Set this text setup style to NOTE #2 style.");
			this.ToolTip1.SetToolTip(this.cmCopy03, "Set this text setup style to NOTE #3 style.");
			this.ToolTip1.SetToolTip(this.cmCopy04, "Set this text setup style to NOTE #4 style.");
			this.ToolTip1.SetToolTip(this.cmCopyAll, "Set all text setup styles to the current style.");
			this.ToolTip1.SetToolTip(this.cmCopySize, "Set all NOTE sizes to the current size.");
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000055A5 File Offset: 0x000037A5
		private void cmShadowColor_Click(object sender, EventArgs e)
		{
			this.ColorDialog1.Color = this._LSetup.ShadowColor;
			this.ColorDialog1.ShowDialog();
			this._LSetup.ShadowColor = this.ColorDialog1.Color;
			this.GFX_DrawStats();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000055E5 File Offset: 0x000037E5
		private void cboA1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._LSetup.O1 = checked((int)Math.Round(Conversion.Val(this.cboA1.Text)));
			this.GFX_DrawStats();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000560E File Offset: 0x0000380E
		private void cboA2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._LSetup.O2 = checked((int)Math.Round(Conversion.Val(this.cboA2.Text)));
			this.GFX_DrawStats();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00005638 File Offset: 0x00003838
		private void cmRankFont_Click(object sender, EventArgs e)
		{
			FontDialog fontDialog = new FontDialog();
			fontDialog.Font = frmMain.FONT_Setup;
			if (fontDialog.ShowDialog() != DialogResult.Cancel)
			{
				frmMain.FONT_Setup = fontDialog.Font;
				frmMain.FONT_Setup_Name = fontDialog.Font.Name;
				frmMain.FONT_Setup_Size = Conversions.ToString(fontDialog.Font.Size);
				frmMain.FONT_Setup_Bold = Conversions.ToString(fontDialog.Font.Bold);
				frmMain.FONT_Setup_Italic = Conversions.ToString(fontDialog.Font.Italic);
			}
			this.GFX_DrawStats();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000056C0 File Offset: 0x000038C0
		private void cbo3D_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._LSetup.ShadowDir = this.cbo3D.Text;
			string shadowDir = this._LSetup.ShadowDir;
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
								this._LSetup.ShadowX = 0;
								this._LSetup.ShadowY = -1;
								goto IL_242;
							}
						}
					}
					else if (Operators.CompareString(shadowDir, "180°", false) == 0)
					{
						this._LSetup.ShadowX = -1;
						this._LSetup.ShadowY = 0;
						goto IL_242;
					}
				}
				else if (num != 1615908792U)
				{
					if (num == 2427795852U)
					{
						if (Operators.CompareString(shadowDir, "315°", false) == 0)
						{
							this._LSetup.ShadowX = 1;
							this._LSetup.ShadowY = 1;
							goto IL_242;
						}
					}
				}
				else if (Operators.CompareString(shadowDir, "135°", false) == 0)
				{
					this._LSetup.ShadowX = -1;
					this._LSetup.ShadowY = -1;
					goto IL_242;
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
							this._LSetup.ShadowX = 1;
							this._LSetup.ShadowY = -1;
							goto IL_242;
						}
					}
				}
				else if (Operators.CompareString(shadowDir, "225°", false) == 0)
				{
					this._LSetup.ShadowX = -1;
					this._LSetup.ShadowY = 1;
					goto IL_242;
				}
			}
			else if (num != 4134103542U)
			{
				if (num == 4249105564U)
				{
					if (Operators.CompareString(shadowDir, "360°", false) == 0)
					{
						this._LSetup.ShadowX = 1;
						this._LSetup.ShadowY = 0;
						goto IL_242;
					}
				}
			}
			else if (Operators.CompareString(shadowDir, "270°", false) == 0)
			{
				this._LSetup.ShadowX = 0;
				this._LSetup.ShadowY = 1;
				goto IL_242;
			}
			this._LSetup.ShadowX = 0;
			this._LSetup.ShadowY = 0;
			IL_242:
			this.GFX_DrawStats();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00005915 File Offset: 0x00003B15
		private void cmFD_Click(object sender, EventArgs e)
		{
			this._LSetup.FDir = 0;
			this.GFX_DrawStats();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00005929 File Offset: 0x00003B29
		private void cmFR_Click(object sender, EventArgs e)
		{
			this._LSetup.FDir = 1;
			this.GFX_DrawStats();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000593D File Offset: 0x00003B3D
		private void cmBD_Click(object sender, EventArgs e)
		{
			this._LSetup.BDir = 0;
			this.GFX_DrawStats();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00005951 File Offset: 0x00003B51
		private void cmBR_Click(object sender, EventArgs e)
		{
			this._LSetup.BDir = 1;
			this.GFX_DrawStats();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00005965 File Offset: 0x00003B65
		private void cmNoImage_Click(object sender, EventArgs e)
		{
			frmMain.Note_BackBmp = null;
			frmMain.PATH_DlgBmp = "";
			this.GFX_DrawStats();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00005980 File Offset: 0x00003B80
		private void cmFormImage_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Background Image Dialog";
			if (Operators.CompareString(frmMain.PATH_DlgBmp, "", false) != 0)
			{
				openFileDialog.InitialDirectory = MyProject.Forms.frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp);
			}
			else
			{
				openFileDialog.InitialDirectory = MyProject.Forms.frmMain.PATH_GetAnyPath();
			}
			openFileDialog.Filter = "Png (*.png)|*.png|Gif (*.gif)|*.gif|Jpeg (*.jpg)|*.jpg";
			openFileDialog.FilterIndex = 3;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				frmMain.Note_BackBmp = new Bitmap(openFileDialog.FileName);
				frmMain.PATH_DlgBmp = openFileDialog.FileName;
				frmMain.PATH_DlgBmpPath = MyProject.Forms.frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp);
			}
			this.GFX_DrawStats();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00005A38 File Offset: 0x00003C38
		private void GFX_DrawStats()
		{
			Font font_Setup = frmMain.FONT_Setup;
			int num = this.pbNote.Height / 2;
			Bitmap bitmap = new Bitmap(this.pbNote.Width, this.pbNote.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			LinearGradientBrush brush;
			Brush brush2;
			int num6;
			int num7;
			int num9;
			int num10;
			checked
			{
				if (frmMain.Note_BackBmp == null)
				{
					graphics.FillRectangle(new SolidBrush(this._LSetup.BackC), 0, 0, this.pbNote.Width, this.pbNote.Height);
				}
				else
				{
					double num2 = Conversion.Val(this.cboScaling.Text);
					if (num2 == 0.0)
					{
						graphics.DrawImage(frmMain.Note_BackBmp, 0, 0, frmMain.Note_BackBmp.Width, frmMain.Note_BackBmp.Height);
					}
					else if (num2 == 1.0)
					{
						int height = bitmap.Height;
						int height2 = frmMain.Note_BackBmp.Height;
						int num3 = 0;
						while ((height2 >> 31 ^ num3) <= (height2 >> 31 ^ height))
						{
							int width = bitmap.Width;
							int width2 = frmMain.Note_BackBmp.Width;
							int num4 = 0;
							while ((width2 >> 31 ^ num4) <= (width2 >> 31 ^ width))
							{
								graphics.DrawImage(frmMain.Note_BackBmp, num4, num3, frmMain.Note_BackBmp.Width, frmMain.Note_BackBmp.Height);
								num4 += width2;
							}
							num3 += height2;
						}
					}
					else if (num2 == 2.0)
					{
						graphics.DrawImage(frmMain.Note_BackBmp, 0, 0, bitmap.Width, bitmap.Height);
					}
				}
				new SolidBrush(this._LSetup.B1);
				new SolidBrush(this._LSetup.F1);
				Color color = Color.FromArgb((int)Math.Round(unchecked(Conversion.Val(this.cboA1.Text) * 2.55)), (int)this._LSetup.B1.R, (int)this._LSetup.B1.G, (int)this._LSetup.B1.B);
				Color color2 = Color.FromArgb((int)Math.Round(unchecked(Conversion.Val(this.cboA2.Text) * 2.55)), (int)this._LSetup.B2.R, (int)this._LSetup.B2.G, (int)this._LSetup.B2.B);
				if (this._LSetup.BDir == 0)
				{
					brush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.pbNote.Height), color, color2);
				}
				else
				{
					brush = new LinearGradientBrush(new Point(0, 0), new Point(this.pbNote.Width, 0), color, color2);
				}
				graphics.FillRectangle(brush, 0, 0, this.pbNote.Width, this.pbNote.Height);
				brush2 = new SolidBrush(this._LSetup.ShadowColor);
				int num5 = (int)Math.Round((double)(graphics.MeasureString("X", frmMain.FONT_Setup).Height / 2f));
				num6 = 0;
				num7 = (int)Math.Round(unchecked((double)this.pbNote.Height / 2.0 - (double)num5));
				string shadowDir = this._LSetup.ShadowDir;
				uint num8 = <PrivateImplementationDetails>.ComputeStringHash(shadowDir);
				if (num8 <= 2427795852U)
				{
					if (num8 <= 1573522228U)
					{
						if (num8 != 717409452U)
						{
							if (num8 == 1573522228U)
							{
								if (Operators.CompareString(shadowDir, "90°", false) == 0)
								{
									num9 = 0;
									num10 = -1;
									goto IL_482;
								}
							}
						}
						else if (Operators.CompareString(shadowDir, "180°", false) == 0)
						{
							num9 = -1;
							num10 = 0;
							goto IL_482;
						}
					}
					else if (num8 != 1615908792U)
					{
						if (num8 == 2427795852U)
						{
							if (Operators.CompareString(shadowDir, "315°", false) == 0)
							{
								num9 = 1;
								num10 = 1;
								goto IL_482;
							}
						}
					}
					else if (Operators.CompareString(shadowDir, "135°", false) == 0)
					{
						num9 = -1;
						num10 = -1;
						goto IL_482;
					}
				}
				else if (num8 <= 2620932502U)
				{
					if (num8 != 2453520896U)
					{
						if (num8 == 2620932502U)
						{
							if (Operators.CompareString(shadowDir, "45°", false) == 0)
							{
								num9 = 1;
								num10 = -1;
								goto IL_482;
							}
						}
					}
					else if (Operators.CompareString(shadowDir, "225°", false) == 0)
					{
						num9 = -1;
						num10 = 1;
						goto IL_482;
					}
				}
				else if (num8 != 4134103542U)
				{
					if (num8 == 4249105564U)
					{
						if (Operators.CompareString(shadowDir, "360°", false) == 0)
						{
							num9 = 1;
							num10 = 0;
							goto IL_482;
						}
					}
				}
				else if (Operators.CompareString(shadowDir, "270°", false) == 0)
				{
					num9 = 0;
					num10 = 1;
					goto IL_482;
				}
				num9 = 0;
				num10 = 0;
				IL_482:;
			}
			if (num9 != 0 | num10 != 0)
			{
				graphics.DrawString("Test Sample Text", frmMain.FONT_Setup, brush2, (float)((double)num6 + (double)num9 * Conversion.Val(this._LSetup.ShadowDepth)), (float)((double)num7 + (double)num10 * Conversion.Val(this._LSetup.ShadowDepth)));
			}
			if (this._LSetup.FDir == 0)
			{
				brush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.pbNote.Height), Color.FromArgb(255, (int)this._LSetup.F1.R, (int)this._LSetup.F1.G, (int)this._LSetup.F1.B), Color.FromArgb(255, (int)this._LSetup.F2.R, (int)this._LSetup.F2.G, (int)this._LSetup.F2.B));
			}
			else
			{
				brush = new LinearGradientBrush(new Point(0, 0), new Point(this.pbNote.Width, 0), Color.FromArgb(255, (int)this._LSetup.F1.R, (int)this._LSetup.F1.G, (int)this._LSetup.F1.B), Color.FromArgb(255, (int)this._LSetup.F2.R, (int)this._LSetup.F2.G, (int)this._LSetup.F2.B));
			}
			graphics.DrawString("Test Sample Text", frmMain.FONT_Setup, brush, (float)num6, (float)num7);
			checked
			{
				if (!this.HideImageOptions && frmMain.Note_OVLBmp != null)
				{
					double num11 = Conversion.Val(this.cboOVLScaling.Text);
					if (num11 == 0.0)
					{
						graphics.DrawImage(frmMain.Note_OVLBmp, 0, 0, frmMain.Note_OVLBmp.Width, frmMain.Note_OVLBmp.Height);
					}
					else if (num11 == 1.0)
					{
						int height3 = bitmap.Height;
						int height4 = frmMain.Note_OVLBmp.Height;
						int num3 = 0;
						while ((height4 >> 31 ^ num3) <= (height4 >> 31 ^ height3))
						{
							int width3 = bitmap.Width;
							int width4 = frmMain.Note_OVLBmp.Width;
							int num4 = 0;
							while ((width4 >> 31 ^ num4) <= (width4 >> 31 ^ width3))
							{
								graphics.DrawImage(frmMain.Note_OVLBmp, num4, num3, frmMain.Note_OVLBmp.Width, frmMain.Note_OVLBmp.Height);
								num4 += width4;
							}
							num3 += height4;
						}
					}
					else if (num11 == 2.0)
					{
						graphics.DrawImage(frmMain.Note_OVLBmp, 0, 0, bitmap.Width, bitmap.Height);
					}
				}
				this.pbNote.Image = bitmap;
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006192 File Offset: 0x00004392
		private void cmFormColor_Click(object sender, EventArgs e)
		{
			this.ColorDialog1.Color = this._LSetup.BackC;
			this.ColorDialog1.ShowDialog();
			this._LSetup.BackC = this.ColorDialog1.Color;
			this.GFX_DrawStats();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000061D4 File Offset: 0x000043D4
		private void cmCopy01_Click(object sender, EventArgs e)
		{
			this._LSetup = frmMain.LSNote01;
			this.cboA1.Text = Strings.Format(this._LSetup.O1, "#0") + "%";
			this.cboA2.Text = Strings.Format(this._LSetup.O2, "#0") + "%";
			this.cbo3D.Text = this._LSetup.ShadowDir;
			frmMain.FONT_Setup = frmMain.FONT_Note01;
			frmMain.PATH_DlgBmp = frmMain.PATH_Note01_Bmp;
			frmMain.Note_BackBmp = frmMain.Note01_BackBmp;
			frmMain.PATH_DlgBmpPath = MyProject.Forms.frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.FONT_Setup = frmMain.FONT_Note01;
			this.GFX_DrawStats();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000062A8 File Offset: 0x000044A8
		private void cmCopy02_Click(object sender, EventArgs e)
		{
			this._LSetup = frmMain.LSNote02;
			this.cboA1.Text = Strings.Format(this._LSetup.O1, "#0") + "%";
			this.cboA2.Text = Strings.Format(this._LSetup.O2, "#0") + "%";
			this.cbo3D.Text = this._LSetup.ShadowDir;
			frmMain.FONT_Setup = frmMain.FONT_Note02;
			frmMain.PATH_DlgBmp = frmMain.PATH_Note02_Bmp;
			frmMain.Note_BackBmp = frmMain.Note02_BackBmp;
			frmMain.PATH_DlgBmpPath = MyProject.Forms.frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.FONT_Setup = frmMain.FONT_Note02;
			this.GFX_DrawStats();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000637C File Offset: 0x0000457C
		private void cmCopy03_Click(object sender, EventArgs e)
		{
			this._LSetup = frmMain.LSNote03;
			this.cboA1.Text = Strings.Format(this._LSetup.O1, "#0") + "%";
			this.cboA2.Text = Strings.Format(this._LSetup.O2, "#0") + "%";
			this.cbo3D.Text = this._LSetup.ShadowDir;
			frmMain.FONT_Setup = frmMain.FONT_Note03;
			frmMain.PATH_DlgBmp = frmMain.PATH_Note03_Bmp;
			frmMain.Note_BackBmp = frmMain.Note03_BackBmp;
			frmMain.PATH_DlgBmpPath = MyProject.Forms.frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.FONT_Setup = frmMain.FONT_Note03;
			this.GFX_DrawStats();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006450 File Offset: 0x00004650
		private void cmCopy04_Click(object sender, EventArgs e)
		{
			this._LSetup = frmMain.LSNote04;
			this.cboA1.Text = Strings.Format(this._LSetup.O1, "#0") + "%";
			this.cboA2.Text = Strings.Format(this._LSetup.O2, "#0") + "%";
			this.cbo3D.Text = this._LSetup.ShadowDir;
			frmMain.FONT_Setup = frmMain.FONT_Note04;
			frmMain.PATH_DlgBmp = frmMain.PATH_Note04_Bmp;
			frmMain.Note_BackBmp = frmMain.Note04_BackBmp;
			frmMain.PATH_DlgBmpPath = MyProject.Forms.frmMain.PATH_StripFilename(frmMain.PATH_DlgBmp);
			frmMain.FONT_Setup = frmMain.FONT_Note04;
			this.GFX_DrawStats();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006524 File Offset: 0x00004724
		private void cmCopyAll_Click(object sender, EventArgs e)
		{
			int width = frmMain.LSNote01.Width;
			int height = frmMain.LSNote01.Height;
			frmMain.LSNote01 = this._LSetup;
			frmMain.LSNote01.Width = width;
			frmMain.LSNote01.Height = height;
			frmMain.PATH_Note01_Bmp = frmMain.PATH_DlgBmp;
			frmMain.Note01_BackBmp = frmMain.Note_BackBmp;
			frmMain.PATH_Note01_OVLBmp = frmMain.PATH_DlgOVLBmp;
			frmMain.Note01_OVLBmp = frmMain.Note_OVLBmp;
			frmMain.FONT_Note01 = frmMain.FONT_Setup;
			frmMain.FONT_Note01_Name = frmMain.FONT_Setup.Name;
			frmMain.FONT_Note01_Size = Conversions.ToString(frmMain.FONT_Setup.Size);
			frmMain.FONT_Note01_Bold = Conversions.ToString(frmMain.FONT_Setup.Bold);
			frmMain.FONT_Note01_Italic = Conversions.ToString(frmMain.FONT_Setup.Italic);
			checked
			{
				frmMain.LSNote01.B1 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote01.O1) * 0.01))), (int)frmMain.LSNote01.B1.R, (int)frmMain.LSNote01.B1.G, (int)frmMain.LSNote01.B1.B);
				frmMain.LSNote01.B2 = Color.FromArgb((int)Math.Round(unchecked(255.0 * (Conversion.Val(frmMain.LSNote01.O2) * 0.01))), (int)frmMain.LSNote01.B2.R, (int)frmMain.LSNote01.B2.G, (int)frmMain.LSNote01.B2.B);
				width = frmMain.LSNote02.Width;
				height = frmMain.LSNote02.Height;
				frmMain.LSNote02 = this._LSetup;
				frmMain.LSNote02.Width = width;
				frmMain.LSNote02.Height = height;
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
				width = frmMain.LSNote03.Width;
				height = frmMain.LSNote03.Height;
				frmMain.LSNote03 = this._LSetup;
				frmMain.LSNote03.Width = width;
				frmMain.LSNote03.Height = height;
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
				width = frmMain.LSNote04.Width;
				height = frmMain.LSNote04.Height;
				frmMain.LSNote04 = this._LSetup;
				frmMain.LSNote04.Width = width;
				frmMain.LSNote04.Height = height;
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
				this.GFX_DrawStats();
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006B57 File Offset: 0x00004D57
		private void cboScaling_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._LSetup.Scaling = Conversions.ToString(this.cboScaling.SelectedIndex);
			this.GFX_DrawStats();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006B7C File Offset: 0x00004D7C
		private void cmCopySize_Click(object sender, EventArgs e)
		{
			checked
			{
				int num = (int)Math.Round(Conversion.Val(this.tbWidth.Text));
				if (32000 < num)
				{
					num = 32000;
				}
				int num2 = (int)Math.Round(Conversion.Val(this.tbHeight.Text));
				if (32000 < num2)
				{
					num2 = 32000;
				}
				frmMain.LSNote01.Width = num;
				frmMain.LSNote01.Height = num2;
				frmMain.LSNote02.Width = num;
				frmMain.LSNote02.Height = num2;
				frmMain.LSNote03.Width = num;
				frmMain.LSNote03.Height = num2;
				frmMain.LSNote04.Width = num;
				frmMain.LSNote04.Height = num2;
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00006C2B File Offset: 0x00004E2B
		private void cboDepth_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._LSetup.ShadowDepth = Conversions.ToString(Conversion.Val(this.cboDepth.Text));
			this.GFX_DrawStats();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00006C54 File Offset: 0x00004E54
		private void cmOverlay_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Overlay Image Dialog";
			if (Operators.CompareString(frmMain.PATH_DlgOVLBmp, "", false) != 0)
			{
				openFileDialog.InitialDirectory = MyProject.Forms.frmMain.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
			}
			else
			{
				openFileDialog.InitialDirectory = MyProject.Forms.frmMain.PATH_GetAnyPath();
			}
			openFileDialog.Filter = "Png (*.png)|*.png|Gif (*.gif)|*.gif|Jpeg (*.jpg)|*.jpg";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				frmMain.Note_OVLBmp = new Bitmap(openFileDialog.FileName);
				frmMain.PATH_DlgOVLBmp = openFileDialog.FileName;
				frmMain.PATH_DlgOVLBmpPath = MyProject.Forms.frmMain.PATH_StripFilename(frmMain.PATH_DlgOVLBmp);
			}
			this.GFX_DrawStats();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00006D0A File Offset: 0x00004F0A
		private void cboOVLScaling_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._LSetup.OVLScaling = Conversions.ToString(this.cboOVLScaling.SelectedIndex);
			this.GFX_DrawStats();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00006D2D File Offset: 0x00004F2D
		private void cmOVLNoImage_Click(object sender, EventArgs e)
		{
			frmMain.Note_OVLBmp = null;
			frmMain.PATH_DlgOVLBmp = "";
			this.GFX_DrawStats();
		}

		// Token: 0x0400003B RID: 59
		private clsGlobal.t_LabelSetup _LSetup;

		// Token: 0x0400003C RID: 60
		private bool _HideSizeOptions;

		// Token: 0x0400003D RID: 61
		private bool _HideImageOptions;

		// Token: 0x0400003E RID: 62
		private bool _HideScalingOptions;

		// Token: 0x0400003F RID: 63
		private bool _HideSizeAll;

		// Token: 0x04000040 RID: 64
		private bool _HideFormColor;

		// Token: 0x04000041 RID: 65
		private bool _Cancel;
	}
}
