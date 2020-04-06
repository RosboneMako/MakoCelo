using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MakoCelo.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
	// Token: 0x0200000A RID: 10
	[DesignerGenerated]
	public partial class frmNotes : Form
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x00006D45 File Offset: 0x00004F45
		public frmNotes()
		{
			base.Load += this.frmNotes_Load;
			this._Cancel = true;
			this._NoteText = new string[12];
			this.InitializeComponent();
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00008384 File Offset: 0x00006584
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x0000838C File Offset: 0x0000658C
		internal virtual TextBox tbN04 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00008395 File Offset: 0x00006595
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x0000839D File Offset: 0x0000659D
		internal virtual TextBox tbN03 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000083A6 File Offset: 0x000065A6
		// (set) Token: 0x060000AB RID: 171 RVA: 0x000083AE File Offset: 0x000065AE
		internal virtual TextBox tbN02 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000AC RID: 172 RVA: 0x000083B7 File Offset: 0x000065B7
		// (set) Token: 0x060000AD RID: 173 RVA: 0x000083BF File Offset: 0x000065BF
		internal virtual TextBox tbN01 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000AE RID: 174 RVA: 0x000083C8 File Offset: 0x000065C8
		// (set) Token: 0x060000AF RID: 175 RVA: 0x000083D0 File Offset: 0x000065D0
		internal virtual TextBox tbN05 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000083D9 File Offset: 0x000065D9
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x000083E1 File Offset: 0x000065E1
		internal virtual TextBox tbN10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x000083EA File Offset: 0x000065EA
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x000083F2 File Offset: 0x000065F2
		internal virtual TextBox tbN09 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x000083FB File Offset: 0x000065FB
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00008403 File Offset: 0x00006603
		internal virtual TextBox tbN08 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000840C File Offset: 0x0000660C
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00008414 File Offset: 0x00006614
		internal virtual TextBox tbN07 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x0000841D File Offset: 0x0000661D
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00008425 File Offset: 0x00006625
		internal virtual TextBox tbN06 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000BA RID: 186 RVA: 0x0000842E File Offset: 0x0000662E
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00008438 File Offset: 0x00006638
		internal virtual Button Button1
		{
			[CompilerGenerated]
			get
			{
				return this._Button1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button1_Click);
				Button button = this._Button1;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button1 = value;
				button = this._Button1;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0000847B File Offset: 0x0000667B
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00008484 File Offset: 0x00006684
		internal virtual Button Button2
		{
			[CompilerGenerated]
			get
			{
				return this._Button2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button2_Click);
				Button button = this._Button2;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button2 = value;
				button = this._Button2;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000BE RID: 190 RVA: 0x000084C7 File Offset: 0x000066C7
		// (set) Token: 0x060000BF RID: 191 RVA: 0x000084D0 File Offset: 0x000066D0
		internal virtual Button Button3
		{
			[CompilerGenerated]
			get
			{
				return this._Button3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button3_Click);
				Button button = this._Button3;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button3 = value;
				button = this._Button3;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00008513 File Offset: 0x00006713
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x0000851C File Offset: 0x0000671C
		internal virtual Button Button4
		{
			[CompilerGenerated]
			get
			{
				return this._Button4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button4_Click);
				Button button = this._Button4;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button4 = value;
				button = this._Button4;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x0000855F File Offset: 0x0000675F
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00008568 File Offset: 0x00006768
		internal virtual Button Button5
		{
			[CompilerGenerated]
			get
			{
				return this._Button5;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button5_Click);
				Button button = this._Button5;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button5 = value;
				button = this._Button5;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x000085AB File Offset: 0x000067AB
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x000085B4 File Offset: 0x000067B4
		internal virtual Button Button6
		{
			[CompilerGenerated]
			get
			{
				return this._Button6;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button6_Click);
				Button button = this._Button6;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button6 = value;
				button = this._Button6;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x000085F7 File Offset: 0x000067F7
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00008600 File Offset: 0x00006800
		internal virtual Button Button7
		{
			[CompilerGenerated]
			get
			{
				return this._Button7;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button7_Click);
				Button button = this._Button7;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button7 = value;
				button = this._Button7;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00008643 File Offset: 0x00006843
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x0000864C File Offset: 0x0000684C
		internal virtual Button Button8
		{
			[CompilerGenerated]
			get
			{
				return this._Button8;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button8_Click);
				Button button = this._Button8;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button8 = value;
				button = this._Button8;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000CA RID: 202 RVA: 0x0000868F File Offset: 0x0000688F
		// (set) Token: 0x060000CB RID: 203 RVA: 0x00008698 File Offset: 0x00006898
		internal virtual Button Button9
		{
			[CompilerGenerated]
			get
			{
				return this._Button9;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button9_Click);
				Button button = this._Button9;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button9 = value;
				button = this._Button9;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000CC RID: 204 RVA: 0x000086DB File Offset: 0x000068DB
		// (set) Token: 0x060000CD RID: 205 RVA: 0x000086E4 File Offset: 0x000068E4
		internal virtual Button Button10
		{
			[CompilerGenerated]
			get
			{
				return this._Button10;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button10_Click);
				Button button = this._Button10;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button10 = value;
				button = this._Button10;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00008727 File Offset: 0x00006927
		// (set) Token: 0x060000CF RID: 207 RVA: 0x0000872F File Offset: 0x0000692F
		internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00008738 File Offset: 0x00006938
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x00008740 File Offset: 0x00006940
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

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00008783 File Offset: 0x00006983
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x0000878C File Offset: 0x0000698C
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

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x000087CF File Offset: 0x000069CF
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x000087D7 File Offset: 0x000069D7
		internal virtual ComboBox cboMode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x000087E0 File Offset: 0x000069E0
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x000087E8 File Offset: 0x000069E8
		internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x000087F1 File Offset: 0x000069F1
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x000087F9 File Offset: 0x000069F9
		internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00008802 File Offset: 0x00006A02
		// (set) Token: 0x060000DB RID: 219 RVA: 0x0000880A File Offset: 0x00006A0A
		internal virtual ComboBox cboSpeed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00008813 File Offset: 0x00006A13
		// (set) Token: 0x060000DD RID: 221 RVA: 0x0000881B File Offset: 0x00006A1B
		internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00008824 File Offset: 0x00006A24
		// (set) Token: 0x060000DF RID: 223 RVA: 0x0000882C File Offset: 0x00006A2C
		internal virtual ComboBox cboHoldTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00008835 File Offset: 0x00006A35
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000883D File Offset: 0x00006A3D
		internal virtual TextBox tbDelim { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00008846 File Offset: 0x00006A46
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x0000884E File Offset: 0x00006A4E
		internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00008857 File Offset: 0x00006A57
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00008860 File Offset: 0x00006A60
		internal virtual ComboBox cboAlign
		{
			[CompilerGenerated]
			get
			{
				return this._cboAlign;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cboAlign_SelectedIndexChanged);
				ComboBox cboAlign = this._cboAlign;
				if (cboAlign != null)
				{
					cboAlign.SelectedIndexChanged -= value2;
				}
				this._cboAlign = value;
				cboAlign = this._cboAlign;
				if (cboAlign != null)
				{
					cboAlign.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x000088A3 File Offset: 0x00006AA3
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x000088AB File Offset: 0x00006AAB
		internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x000088B4 File Offset: 0x00006AB4
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x000088BC File Offset: 0x00006ABC
		internal virtual Label lbXOff { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000EA RID: 234 RVA: 0x000088C5 File Offset: 0x00006AC5
		// (set) Token: 0x060000EB RID: 235 RVA: 0x000088CD File Offset: 0x00006ACD
		internal virtual TextBox tbXoff { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000EC RID: 236 RVA: 0x000088D6 File Offset: 0x00006AD6
		// (set) Token: 0x060000ED RID: 237 RVA: 0x000088DE File Offset: 0x00006ADE
		internal virtual Label lbYoff { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000EE RID: 238 RVA: 0x000088E7 File Offset: 0x00006AE7
		// (set) Token: 0x060000EF RID: 239 RVA: 0x000088EF File Offset: 0x00006AEF
		internal virtual TextBox tbYoff { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x000088F8 File Offset: 0x00006AF8
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00008900 File Offset: 0x00006B00
		internal virtual Button Button11
		{
			[CompilerGenerated]
			get
			{
				return this._Button11;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button11_Click);
				Button button = this._Button11;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button11 = value;
				button = this._Button11;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00008943 File Offset: 0x00006B43
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x0000894C File Offset: 0x00006B4C
		internal virtual Button Button12
		{
			[CompilerGenerated]
			get
			{
				return this._Button12;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button12_Click);
				Button button = this._Button12;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button12 = value;
				button = this._Button12;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x0000898F File Offset: 0x00006B8F
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00008998 File Offset: 0x00006B98
		internal virtual Button Button13
		{
			[CompilerGenerated]
			get
			{
				return this._Button13;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button13_Click);
				Button button = this._Button13;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button13 = value;
				button = this._Button13;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x000089DB File Offset: 0x00006BDB
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x000089E3 File Offset: 0x00006BE3
		internal virtual ToolTip ToolTip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x000089EC File Offset: 0x00006BEC
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x000089F4 File Offset: 0x00006BF4
		public clsGlobal.t_NoteAnimation NoteAnim
		{
			get
			{
				return this._NoteAnim;
			}
			set
			{
				this._NoteAnim = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000FA RID: 250 RVA: 0x000089FD File Offset: 0x00006BFD
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00008A05 File Offset: 0x00006C05
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

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00008A0E File Offset: 0x00006C0E
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00008A18 File Offset: 0x00006C18
		public string NoteText
		{
			get
			{
				return this._NoteText[Index];
			}
			set
			{
				this._NoteText[Index] = value;
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00008A24 File Offset: 0x00006C24
		private void frmNotes_Load(object sender, EventArgs e)
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
			this.tbN01.Text = this._NoteText[1];
			this.tbN02.Text = this._NoteText[2];
			this.tbN03.Text = this._NoteText[3];
			this.tbN04.Text = this._NoteText[4];
			this.tbN05.Text = this._NoteText[5];
			this.tbN06.Text = this._NoteText[6];
			this.tbN07.Text = this._NoteText[7];
			this.tbN08.Text = this._NoteText[8];
			this.tbN09.Text = this._NoteText[9];
			this.tbN10.Text = this._NoteText[10];
			this.cboMode.Items.Add("0 - None");
			this.cboMode.Items.Add("1 - L<-R Crawler");
			this.cboMode.Items.Add("2 - Up Crawler");
			this.cboMode.Items.Add("3 - Down Crawler");
			this.cboMode.Items.Add("4 - Fade In");
			this.cboMode.Items.Add("5 - Up Roll");
			int num = this._NoteAnim.Mode;
			if (num < 0)
			{
				num = 0;
			}
			this.cboMode.SelectedIndex = num;
			this.cboSpeed.Items.Add("0");
			this.cboSpeed.Items.Add("1");
			this.cboSpeed.Items.Add("2");
			this.cboSpeed.Items.Add("3");
			this.cboSpeed.Items.Add("4");
			this.cboSpeed.Items.Add("5");
			this.cboSpeed.Items.Add("6");
			this.cboSpeed.Items.Add("7");
			this.cboSpeed.Items.Add("8");
			this.cboSpeed.Items.Add("9");
			this.cboSpeed.Items.Add("10");
			num = this._NoteAnim.Speed;
			if (num < 0)
			{
				num = 0;
			}
			this.cboSpeed.SelectedIndex = num;
			this.cboHoldTime.Items.Add("0 Secs");
			this.cboHoldTime.Items.Add("1 Secs");
			this.cboHoldTime.Items.Add("2 Secs");
			this.cboHoldTime.Items.Add("3 Secs");
			this.cboHoldTime.Items.Add("4 Secs");
			this.cboHoldTime.Items.Add("5 Secs");
			this.cboHoldTime.Items.Add("6 Secs");
			this.cboHoldTime.Items.Add("7 Secs");
			this.cboHoldTime.Items.Add("8 Secs");
			this.cboHoldTime.Items.Add("9 Secs");
			this.cboHoldTime.Items.Add("10 Secs");
			num = checked((int)this._NoteAnim.TimeHold);
			if (num < 0)
			{
				num = 0;
			}
			this.cboHoldTime.SelectedIndex = num;
			this.tbDelim.Text = this._NoteAnim.Delim;
			this.cboAlign.Items.Add("0 - Left");
			this.cboAlign.Items.Add("1 - Center");
			this.cboAlign.Items.Add("2 - Right");
			this.cboAlign.Text = this._NoteAnim.Align;
			num = this._NoteAnim.Mode;
			if (num < 0)
			{
				num = 0;
			}
			this.cboMode.SelectedIndex = num;
			this.tbXoff.Text = Conversions.ToString(this._NoteAnim.Xoffset);
			this.tbYoff.Text = Conversions.ToString(this._NoteAnim.Yoffset);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00008EAC File Offset: 0x000070AC
		private void ToolTip_Setup()
		{
			this.ToolTip1.SetToolTip(this.cboMode, "Set how the text will be animated on the notes.");
			this.ToolTip1.SetToolTip(this.cboSpeed, "Set how fast text effects happen during animations.");
			this.ToolTip1.SetToolTip(this.cboHoldTime, "How long to show the text after animations are done.");
			this.ToolTip1.SetToolTip(this.cboAlign, "Set the text alignment. This is not used for some animations.");
			this.ToolTip1.SetToolTip(this.tbDelim, "Some animations combine all text. This string will be placed between each line of text.");
			this.ToolTip1.SetToolTip(this.tbXoff, "Modify the position of text so it can align with images being used.");
			this.ToolTip1.SetToolTip(this.tbYoff, "Modify the position of text so it can align with images being used.");
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00008F54 File Offset: 0x00007154
		private void cmOK_Click(object sender, EventArgs e)
		{
			this._NoteText[1] = this.tbN01.Text;
			this._NoteText[2] = this.tbN02.Text;
			this._NoteText[3] = this.tbN03.Text;
			this._NoteText[4] = this.tbN04.Text;
			this._NoteText[5] = this.tbN05.Text;
			this._NoteText[6] = this.tbN06.Text;
			this._NoteText[7] = this.tbN07.Text;
			this._NoteText[8] = this.tbN08.Text;
			this._NoteText[9] = this.tbN09.Text;
			this._NoteText[10] = this.tbN10.Text;
			this._NoteAnim.Mode = this.cboMode.SelectedIndex;
			if (this._NoteAnim.Mode < 0)
			{
				this._NoteAnim.Mode = 0;
			}
			this._NoteAnim.Speed = this.cboSpeed.SelectedIndex;
			if (this._NoteAnim.Speed < 0)
			{
				this._NoteAnim.Speed = 0;
			}
			this._NoteAnim.TimeHold = (long)this.cboHoldTime.SelectedIndex;
			if (this._NoteAnim.TimeHold < 0L)
			{
				this._NoteAnim.TimeHold = 0L;
			}
			this._NoteAnim.Delim = this.tbDelim.Text;
			checked
			{
				this._NoteAnim.Xoffset = (int)Math.Round(Conversion.Val(this.tbXoff.Text));
				this._NoteAnim.Yoffset = (int)Math.Round(Conversion.Val(this.tbYoff.Text));
				this.Cancel = false;
				base.Close();
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00004C76 File Offset: 0x00002E76
		private void cmCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00009119 File Offset: 0x00007319
		private void Button1_Click(object sender, EventArgs e)
		{
			this.tbN01.Text = "";
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000912B File Offset: 0x0000732B
		private void Button2_Click(object sender, EventArgs e)
		{
			this.tbN02.Text = "";
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000913D File Offset: 0x0000733D
		private void Button3_Click(object sender, EventArgs e)
		{
			this.tbN03.Text = "";
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000914F File Offset: 0x0000734F
		private void Button4_Click(object sender, EventArgs e)
		{
			this.tbN04.Text = "";
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00009161 File Offset: 0x00007361
		private void Button5_Click(object sender, EventArgs e)
		{
			this.tbN05.Text = "";
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00009173 File Offset: 0x00007373
		private void Button6_Click(object sender, EventArgs e)
		{
			this.tbN06.Text = "";
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00009185 File Offset: 0x00007385
		private void Button7_Click(object sender, EventArgs e)
		{
			this.tbN07.Text = "";
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00009197 File Offset: 0x00007397
		private void Button8_Click(object sender, EventArgs e)
		{
			this.tbN08.Text = "";
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000091A9 File Offset: 0x000073A9
		private void Button9_Click(object sender, EventArgs e)
		{
			this.tbN09.Text = "";
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000091BB File Offset: 0x000073BB
		private void Button10_Click(object sender, EventArgs e)
		{
			this.tbN10.Text = "";
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000091CD File Offset: 0x000073CD
		private void cboAlign_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._NoteAnim.Align = this.cboAlign.Text;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000091E5 File Offset: 0x000073E5
		private void Button11_Click(object sender, EventArgs e)
		{
			this.tbDelim.Text = "";
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000091F7 File Offset: 0x000073F7
		private void Button12_Click(object sender, EventArgs e)
		{
			this.tbXoff.Text = "0";
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00009209 File Offset: 0x00007409
		private void Button13_Click(object sender, EventArgs e)
		{
			this.tbYoff.Text = "0";
		}

		// Token: 0x0400006C RID: 108
		private clsGlobal.t_NoteAnimation _NoteAnim;

		// Token: 0x0400006D RID: 109
		private bool _Cancel;

		// Token: 0x0400006E RID: 110
		private string[] _NoteText;
	}
}
