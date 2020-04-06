using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo.My
{
	// Token: 0x02000004 RID: 4
	[StandardModule]
	[HideModuleName]
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	internal sealed class MyProject
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020DA File Offset: 0x000002DA
		[HelpKeyword("My.Computer")]
		internal static MyComputer Computer
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_ComputerObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020E6 File Offset: 0x000002E6
		[HelpKeyword("My.Application")]
		internal static MyApplication Application
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_AppObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020F2 File Offset: 0x000002F2
		[HelpKeyword("My.User")]
		internal static User User
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_UserObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020FE File Offset: 0x000002FE
		[HelpKeyword("My.Forms")]
		internal static MyProject.MyForms Forms
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyFormsObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000210A File Offset: 0x0000030A
		[HelpKeyword("My.WebServices")]
		internal static MyProject.MyWebServices WebServices
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyWebServicesObjectProvider.GetInstance;
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();

		// Token: 0x04000002 RID: 2
		private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

		// Token: 0x04000003 RID: 3
		private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();

		// Token: 0x04000004 RID: 4
		private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();

		// Token: 0x04000005 RID: 5
		private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

		// Token: 0x0200000E RID: 14
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
		internal sealed class MyForms
		{
			// Token: 0x060002E1 RID: 737 RVA: 0x00024808 File Offset: 0x00022A08
			[DebuggerHidden]
			private static T Create__Instance__<T>(T Instance) where T : Form, new()
			{
				if (Instance == null || Instance.IsDisposed)
				{
					if (MyProject.MyForms.m_FormBeingCreated != null)
					{
						if (MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T)))
						{
							throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
						}
					}
					else
					{
						MyProject.MyForms.m_FormBeingCreated = new Hashtable();
					}
					MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
					try
					{
						return Activator.CreateInstance<T>();
					}
					catch (TargetInvocationException ex) when (ex.InnerException != null)
					{
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[]
						{
							ex.InnerException.Message
						}), ex.InnerException);
					}
					finally
					{
						MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
					}
				}
				return Instance;
			}

			// Token: 0x060002E2 RID: 738 RVA: 0x0002490C File Offset: 0x00022B0C
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance) where T : Form
			{
				instance.Dispose();
				instance = default(T);
			}

			// Token: 0x060002E3 RID: 739 RVA: 0x0000220B File Offset: 0x0000040B
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyForms()
			{
			}

			// Token: 0x060002E4 RID: 740 RVA: 0x00024921 File Offset: 0x00022B21
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x060002E5 RID: 741 RVA: 0x0002492F File Offset: 0x00022B2F
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x060002E6 RID: 742 RVA: 0x00024937 File Offset: 0x00022B37
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyForms);
			}

			// Token: 0x060002E7 RID: 743 RVA: 0x00024943 File Offset: 0x00022B43
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x170000FC RID: 252
			// (get) Token: 0x060002E8 RID: 744 RVA: 0x0002494B File Offset: 0x00022B4B
			// (set) Token: 0x060002EC RID: 748 RVA: 0x000249AF File Offset: 0x00022BAF
			public frmAbout frmAbout
			{
				get
				{
					this.m_frmAbout = MyProject.MyForms.Create__Instance__<frmAbout>(this.m_frmAbout);
					return this.m_frmAbout;
				}
				set
				{
					if (value != this.m_frmAbout)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmAbout>(ref this.m_frmAbout);
					}
				}
			}

			// Token: 0x170000FD RID: 253
			// (get) Token: 0x060002E9 RID: 745 RVA: 0x00024964 File Offset: 0x00022B64
			// (set) Token: 0x060002ED RID: 749 RVA: 0x000249D4 File Offset: 0x00022BD4
			public frmLabelSetup frmLabelSetup
			{
				get
				{
					this.m_frmLabelSetup = MyProject.MyForms.Create__Instance__<frmLabelSetup>(this.m_frmLabelSetup);
					return this.m_frmLabelSetup;
				}
				set
				{
					if (value != this.m_frmLabelSetup)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmLabelSetup>(ref this.m_frmLabelSetup);
					}
				}
			}

			// Token: 0x170000FE RID: 254
			// (get) Token: 0x060002EA RID: 746 RVA: 0x0002497D File Offset: 0x00022B7D
			// (set) Token: 0x060002EE RID: 750 RVA: 0x000249F9 File Offset: 0x00022BF9
			public frmMain frmMain
			{
				get
				{
					this.m_frmMain = MyProject.MyForms.Create__Instance__<frmMain>(this.m_frmMain);
					return this.m_frmMain;
				}
				set
				{
					if (value != this.m_frmMain)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmMain>(ref this.m_frmMain);
					}
				}
			}

			// Token: 0x170000FF RID: 255
			// (get) Token: 0x060002EB RID: 747 RVA: 0x00024996 File Offset: 0x00022B96
			// (set) Token: 0x060002EF RID: 751 RVA: 0x00024A1E File Offset: 0x00022C1E
			public frmNotes frmNotes
			{
				get
				{
					this.m_frmNotes = MyProject.MyForms.Create__Instance__<frmNotes>(this.m_frmNotes);
					return this.m_frmNotes;
				}
				set
				{
					if (value != this.m_frmNotes)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmNotes>(ref this.m_frmNotes);
					}
				}
			}

			// Token: 0x0400019F RID: 415
			[ThreadStatic]
			private static Hashtable m_FormBeingCreated;

			// Token: 0x040001A0 RID: 416
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmAbout m_frmAbout;

			// Token: 0x040001A1 RID: 417
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmLabelSetup m_frmLabelSetup;

			// Token: 0x040001A2 RID: 418
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmMain m_frmMain;

			// Token: 0x040001A3 RID: 419
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmNotes m_frmNotes;
		}

		// Token: 0x0200000F RID: 15
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class MyWebServices
		{
			// Token: 0x060002F0 RID: 752 RVA: 0x00024921 File Offset: 0x00022B21
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x060002F1 RID: 753 RVA: 0x0002492F File Offset: 0x00022B2F
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x060002F2 RID: 754 RVA: 0x00024A43 File Offset: 0x00022C43
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			internal new Type GetType()
			{
				return typeof(MyProject.MyWebServices);
			}

			// Token: 0x060002F3 RID: 755 RVA: 0x00024943 File Offset: 0x00022B43
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x060002F4 RID: 756 RVA: 0x00024A50 File Offset: 0x00022C50
			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance) where T : new()
			{
				T result;
				if (instance == null)
				{
					result = Activator.CreateInstance<T>();
				}
				else
				{
					result = instance;
				}
				return result;
			}

			// Token: 0x060002F5 RID: 757 RVA: 0x00024A70 File Offset: 0x00022C70
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			// Token: 0x060002F6 RID: 758 RVA: 0x0000220B File Offset: 0x0000040B
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyWebServices()
			{
			}
		}

		// Token: 0x02000010 RID: 16
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		internal sealed class ThreadSafeObjectProvider<T> where T : new()
		{
			// Token: 0x17000100 RID: 256
			// (get) Token: 0x060002F7 RID: 759 RVA: 0x00024A79 File Offset: 0x00022C79
			internal T GetInstance
			{
				[DebuggerHidden]
				get
				{
					if (MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
					{
						MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = Activator.CreateInstance<T>();
					}
					return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
				}
			}

			// Token: 0x060002F8 RID: 760 RVA: 0x0000220B File Offset: 0x0000040B
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ThreadSafeObjectProvider()
			{
			}

			// Token: 0x040001A4 RID: 420
			[CompilerGenerated]
			[ThreadStatic]
			private static T m_ThreadStaticValue;
		}
	}
}
