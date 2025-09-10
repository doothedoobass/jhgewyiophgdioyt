<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        Label1 = New Label()
        ProgressBar1 = New ProgressBar()
        ProgressBar2 = New ProgressBar()
        ProgressBar3 = New ProgressBar()
        ProgressBar4 = New ProgressBar()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = SystemColors.InactiveCaptionText
        TextBox1.ForeColor = Color.Lime
        TextBox1.Location = New Point(12, 12)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(100, 426)
        TextBox1.TabIndex = 0
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = SystemColors.Desktop
        TextBox2.ForeColor = Color.Yellow
        TextBox2.Location = New Point(118, 12)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(100, 426)
        TextBox2.TabIndex = 1
        ' 
        ' TextBox3
        ' 
        TextBox3.BackColor = Color.Black
        TextBox3.ForeColor = Color.Red
        TextBox3.Location = New Point(224, 72)
        TextBox3.Multiline = True
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(408, 282)
        TextBox3.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Red
        Label1.Location = New Point(261, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 32)
        Label1.TabIndex = 3
        Label1.Text = "Solution: ="
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(641, 152)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(150, 23)
        ProgressBar1.TabIndex = 4
        ' 
        ' ProgressBar2
        ' 
        ProgressBar2.Location = New Point(641, 206)
        ProgressBar2.Name = "ProgressBar2"
        ProgressBar2.Size = New Size(150, 23)
        ProgressBar2.TabIndex = 5
        ' 
        ' ProgressBar3
        ' 
        ProgressBar3.Location = New Point(641, 262)
        ProgressBar3.Name = "ProgressBar3"
        ProgressBar3.Size = New Size(150, 23)
        ProgressBar3.TabIndex = 6
        ' 
        ' ProgressBar4
        ' 
        ProgressBar4.Location = New Point(641, 317)
        ProgressBar4.Name = "ProgressBar4"
        ProgressBar4.Size = New Size(150, 23)
        ProgressBar4.TabIndex = 7
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(800, 450)
        Controls.Add(ProgressBar4)
        Controls.Add(ProgressBar3)
        Controls.Add(ProgressBar2)
        Controls.Add(ProgressBar1)
        Controls.Add(Label1)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximizeBox = False
        Name = "Form1"
        Text = "GoldBach Catcher"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents ProgressBar3 As ProgressBar
    Friend WithEvents ProgressBar4 As ProgressBar
    Friend WithEvents Timer1 As Timer

End Class
