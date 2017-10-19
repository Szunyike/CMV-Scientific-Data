<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadCountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadCountsFromFastqToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvarageAlignedReadsBestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvarageMisMatchIndelsBestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneralCoverageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlastNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReadCountsToolStripMenuItem, Me.ReadCountsFromFastqToolStripMenuItem, Me.AvarageAlignedReadsBestToolStripMenuItem, Me.AvarageMisMatchIndelsBestToolStripMenuItem, Me.GeneralCoverageToolStripMenuItem, Me.BlastNToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ReadCountsToolStripMenuItem
        '
        Me.ReadCountsToolStripMenuItem.Name = "ReadCountsToolStripMenuItem"
        Me.ReadCountsToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.ReadCountsToolStripMenuItem.Text = "Read Counts From Bam"
        '
        'ReadCountsFromFastqToolStripMenuItem
        '
        Me.ReadCountsFromFastqToolStripMenuItem.Name = "ReadCountsFromFastqToolStripMenuItem"
        Me.ReadCountsFromFastqToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.ReadCountsFromFastqToolStripMenuItem.Text = "Read Counts From Fastq"
        '
        'AvarageAlignedReadsBestToolStripMenuItem
        '
        Me.AvarageAlignedReadsBestToolStripMenuItem.Name = "AvarageAlignedReadsBestToolStripMenuItem"
        Me.AvarageAlignedReadsBestToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.AvarageAlignedReadsBestToolStripMenuItem.Text = "Avarage Aligned Reads Best"
        '
        'AvarageMisMatchIndelsBestToolStripMenuItem
        '
        Me.AvarageMisMatchIndelsBestToolStripMenuItem.Name = "AvarageMisMatchIndelsBestToolStripMenuItem"
        Me.AvarageMisMatchIndelsBestToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.AvarageMisMatchIndelsBestToolStripMenuItem.Text = "Avarage MisMatch, Indels Best"
        '
        'GeneralCoverageToolStripMenuItem
        '
        Me.GeneralCoverageToolStripMenuItem.Name = "GeneralCoverageToolStripMenuItem"
        Me.GeneralCoverageToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.GeneralCoverageToolStripMenuItem.Text = "General Coverage"
        '
        'BlastNToolStripMenuItem
        '
        Me.BlastNToolStripMenuItem.Name = "BlastNToolStripMenuItem"
        Me.BlastNToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.BlastNToolStripMenuItem.Text = "BlastN"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadCountsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneralCoverageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AvarageAlignedReadsBestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadCountsFromFastqToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AvarageMisMatchIndelsBestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BlastNToolStripMenuItem As ToolStripMenuItem
End Class
