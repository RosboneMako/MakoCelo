using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
	// Token: 0x0200000B RID: 11
	[DesignerGenerated]
	public partial class frmAbout : Form
	{
		// Token: 0x06000110 RID: 272 RVA: 0x0000921C File Offset: 0x0000741C
		public frmAbout()
		{
			base.Load += this.frmAbout_Load;
			base.Shown += this.frmAbout_Shown;
			base.KeyDown += this.frmAbout_KeyDown;
			this.InitializeComponent();
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00009AA1 File Offset: 0x00007CA1
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00009AA9 File Offset: 0x00007CA9
		internal virtual PictureBox PictureBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00009AB2 File Offset: 0x00007CB2
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00009ABA File Offset: 0x00007CBA
		internal virtual TextBox tbHelp { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00009AC3 File Offset: 0x00007CC3
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00009ACB File Offset: 0x00007CCB
		internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00009AD4 File Offset: 0x00007CD4
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00009ADC File Offset: 0x00007CDC
		internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00009AE5 File Offset: 0x00007CE5
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00009AED File Offset: 0x00007CED
		internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00009AF6 File Offset: 0x00007CF6
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00009AFE File Offset: 0x00007CFE
		internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00009B07 File Offset: 0x00007D07
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00009B0F File Offset: 0x00007D0F
		internal virtual Label lbBold01 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00009B18 File Offset: 0x00007D18
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00009B20 File Offset: 0x00007D20
		internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00009B29 File Offset: 0x00007D29
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00009B31 File Offset: 0x00007D31
		internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00009B3A File Offset: 0x00007D3A
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00009B42 File Offset: 0x00007D42
		internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000127 RID: 295 RVA: 0x00009B4B File Offset: 0x00007D4B
		private void frmAbout_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00009B4D File Offset: 0x00007D4D
		private void frmAbout_Shown(object sender, EventArgs e)
		{
			this.tbHelp.SelectionLength = 0;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00009B5B File Offset: 0x00007D5B
		private void frmAbout_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape | e.KeyCode == Keys.Return)
			{
				base.Close();
			}
		}
	}
}
