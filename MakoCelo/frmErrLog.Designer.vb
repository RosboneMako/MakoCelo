<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErrLog
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmErrLog))
        Me.lbHead = New System.Windows.Forms.Label()
        Me.tbErrLog = New System.Windows.Forms.TextBox()
        Me.cmCopy = New System.Windows.Forms.Button()
        Me.cmExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbHead
        '
        Me.lbHead.AutoSize = True
        Me.lbHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHead.Location = New System.Drawing.Point(12, 9)
        Me.lbHead.Name = "lbHead"
        Me.lbHead.Size = New System.Drawing.Size(372, 16)
        Me.lbHead.TabIndex = 0
        Me.lbHead.Text = "The data below is the WEB data log for the last player search:"
        '
        'tbErrLog
        '
        Me.tbErrLog.BackColor = System.Drawing.Color.White
        Me.tbErrLog.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tbErrLog.Location = New System.Drawing.Point(15, 28)
        Me.tbErrLog.Multiline = True
        Me.tbErrLog.Name = "tbErrLog"
        Me.tbErrLog.ReadOnly = True
        Me.tbErrLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbErrLog.Size = New System.Drawing.Size(488, 410)
        Me.tbErrLog.TabIndex = 1
        '
        'cmCopy
        '
        Me.cmCopy.Location = New System.Drawing.Point(542, 28)
        Me.cmCopy.Name = "cmCopy"
        Me.cmCopy.Size = New System.Drawing.Size(125, 54)
        Me.cmCopy.TabIndex = 2
        Me.cmCopy.Text = "Copy to Clipboard"
        Me.cmCopy.UseVisualStyleBackColor = True
        '
        'cmExit
        '
        Me.cmExit.Location = New System.Drawing.Point(542, 108)
        Me.cmExit.Name = "cmExit"
        Me.cmExit.Size = New System.Drawing.Size(125, 54)
        Me.cmExit.TabIndex = 3
        Me.cmExit.Text = "Exit"
        Me.cmExit.UseVisualStyleBackColor = True
        '
        'frmErrLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(698, 458)
        Me.Controls.Add(Me.cmExit)
        Me.Controls.Add(Me.cmCopy)
        Me.Controls.Add(Me.tbErrLog)
        Me.Controls.Add(Me.lbHead)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmErrLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MakoCELO - Web Transaction Log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbHead As Label
    Friend WithEvents tbErrLog As TextBox
    Friend WithEvents cmCopy As Button
    Friend WithEvents cmExit As Button
End Class
