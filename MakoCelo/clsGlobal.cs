using System;
using System.Drawing;

namespace MakoCelo
{
	// Token: 0x02000008 RID: 8
	public class clsGlobal
	{
		// Token: 0x02000011 RID: 17
		public struct t_LabelSetup
		{
			// Token: 0x040001A5 RID: 421
			public int Width;

			// Token: 0x040001A6 RID: 422
			public int Height;

			// Token: 0x040001A7 RID: 423
			public Color F1;

			// Token: 0x040001A8 RID: 424
			public Color F2;

			// Token: 0x040001A9 RID: 425
			public int FDir;

			// Token: 0x040001AA RID: 426
			public Color B1;

			// Token: 0x040001AB RID: 427
			public Color B2;

			// Token: 0x040001AC RID: 428
			public int BDir;

			// Token: 0x040001AD RID: 429
			public int O1;

			// Token: 0x040001AE RID: 430
			public int O2;

			// Token: 0x040001AF RID: 431
			public Color BackC;

			// Token: 0x040001B0 RID: 432
			public string ShadowDir;

			// Token: 0x040001B1 RID: 433
			public Color ShadowColor;

			// Token: 0x040001B2 RID: 434
			public string ShadowDepth;

			// Token: 0x040001B3 RID: 435
			public int ShadowX;

			// Token: 0x040001B4 RID: 436
			public int ShadowY;

			// Token: 0x040001B5 RID: 437
			public string Scaling;

			// Token: 0x040001B6 RID: 438
			public string OVLScaling;
		}

		// Token: 0x02000012 RID: 18
		public struct t_Box
		{
			// Token: 0x040001B7 RID: 439
			public float X;

			// Token: 0x040001B8 RID: 440
			public float Y;

			// Token: 0x040001B9 RID: 441
			public float Xtext;

			// Token: 0x040001BA RID: 442
			public float Xcenter;

			// Token: 0x040001BB RID: 443
			public float Ycenter;

			// Token: 0x040001BC RID: 444
			public float Width;

			// Token: 0x040001BD RID: 445
			public float Height;
		}

		// Token: 0x02000013 RID: 19
		public struct t_NoteAnimation
		{
			// Token: 0x040001BE RID: 446
			public bool Active;

			// Token: 0x040001BF RID: 447
			public int Mode;

			// Token: 0x040001C0 RID: 448
			public string Align;

			// Token: 0x040001C1 RID: 449
			public int Xoffset;

			// Token: 0x040001C2 RID: 450
			public int Yoffset;

			// Token: 0x040001C3 RID: 451
			public float X;

			// Token: 0x040001C4 RID: 452
			public float Y;

			// Token: 0x040001C5 RID: 453
			public float Xstart;

			// Token: 0x040001C6 RID: 454
			public float Ystart;

			// Token: 0x040001C7 RID: 455
			public float Xend;

			// Token: 0x040001C8 RID: 456
			public float Yend;

			// Token: 0x040001C9 RID: 457
			public float Xdir;

			// Token: 0x040001CA RID: 458
			public float Ydir;

			// Token: 0x040001CB RID: 459
			public bool Holding;

			// Token: 0x040001CC RID: 460
			public int Speed;

			// Token: 0x040001CD RID: 461
			public long TimeHold;

			// Token: 0x040001CE RID: 462
			public long TimeAcc;

			// Token: 0x040001CF RID: 463
			public int TextCount;

			// Token: 0x040001D0 RID: 464
			public int TextCurrent;

			// Token: 0x040001D1 RID: 465
			public string Delim;
		}

		// Token: 0x02000014 RID: 20
		public enum FXVarDefs
		{
			// Token: 0x040001D3 RID: 467
			None,
			// Token: 0x040001D4 RID: 468
			Mode,
			// Token: 0x040001D5 RID: 469
			ShadeAng,
			// Token: 0x040001D6 RID: 470
			ShadeAmount,
			// Token: 0x040001D7 RID: 471
			ShadeBias
		}

		// Token: 0x02000015 RID: 21
		public enum FXMode
		{
			// Token: 0x040001D9 RID: 473
			None,
			// Token: 0x040001DA RID: 474
			Shadow,
			// Token: 0x040001DB RID: 475
			Emboss,
			// Token: 0x040001DC RID: 476
			LabelBlur
		}
	}
}
