using System;
using System.ComponentModel;
using System.Diagnostics;

namespace MakoCelo.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmAbout m_frmAbout;

            public frmAbout frmAbout
            {
                [DebuggerHidden]
                get
                {
                    m_frmAbout = Create__Instance__(m_frmAbout);
                    return m_frmAbout;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmAbout))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmAbout);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmErrLog m_frmErrLog;

            public frmErrLog frmErrLog
            {
                [DebuggerHidden]
                get
                {
                    m_frmErrLog = Create__Instance__(m_frmErrLog);
                    return m_frmErrLog;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmErrLog))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmErrLog);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmLabelSetup m_frmLabelSetup;

            public frmLabelSetup frmLabelSetup
            {
                [DebuggerHidden]
                get
                {
                    m_frmLabelSetup = Create__Instance__(m_frmLabelSetup);
                    return m_frmLabelSetup;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmLabelSetup))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmLabelSetup);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMain m_frmMain;

            public frmMain frmMain
            {
                [DebuggerHidden]
                get
                {
                    m_frmMain = Create__Instance__(m_frmMain);
                    return m_frmMain;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMain))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMain);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMaxPlayerSearch m_frmMaxPlayerSearch;

            public frmMaxPlayerSearch frmMaxPlayerSearch
            {
                [DebuggerHidden]
                get
                {
                    m_frmMaxPlayerSearch = Create__Instance__(m_frmMaxPlayerSearch);
                    return m_frmMaxPlayerSearch;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMaxPlayerSearch))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMaxPlayerSearch);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmNotes m_frmNotes;

            public frmNotes frmNotes
            {
                [DebuggerHidden]
                get
                {
                    m_frmNotes = Create__Instance__(m_frmNotes);
                    return m_frmNotes;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmNotes))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmNotes);
                }
            }
        }
    }
}