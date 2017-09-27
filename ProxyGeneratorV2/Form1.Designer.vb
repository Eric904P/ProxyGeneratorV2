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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        CType(Me.TrackBar1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage2.SuspendLayout
        CType(Me.NumericUpDown2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TrackBar2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(6, 162)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(247, 23)
        Me.ProgressBar2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(6, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Scraper Progress"
        '
        'TrackBar1
        '
        Me.TrackBar1.AccessibleName = ""
        Me.TrackBar1.LargeChange = 10
        Me.TrackBar1.Location = New System.Drawing.Point(13, 33)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(240, 45)
        Me.TrackBar1.TabIndex = 5
        Me.TrackBar1.TickFrequency = 10
        Me.TrackBar1.Value = 50
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 289)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "QuickStart"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(106, 289)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Pause"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(198, 289)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(78, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Stop"
        Me.Button3.UseVisualStyleBackColor = true
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = true
        Me.CheckBox1.Location = New System.Drawing.Point(9, 80)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(115, 17)
        Me.CheckBox1.TabIndex = 13
        Me.CheckBox1.Text = "Use inbuilt sources"
        Me.CheckBox1.UseVisualStyleBackColor = true
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(272, 246)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.CheckBox3)
        Me.TabPage1.Controls.Add(Me.Button13)
        Me.TabPage1.Controls.Add(Me.Button7)
        Me.TabPage1.Controls.Add(Me.NumericUpDown1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.TrackBar1)
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.ProgressBar2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(264, 220)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Scraper"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = true
        Me.CheckBox3.Location = New System.Drawing.Point(134, 80)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(128, 17)
        Me.CheckBox3.TabIndex = 19
        Me.CheckBox3.Text = "Save only with results"
        Me.CheckBox3.UseVisualStyleBackColor = true
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(6, 103)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(119, 23)
        Me.Button13.TabIndex = 18
        Me.Button13.Text = "Load Custom"
        Me.Button13.UseVisualStyleBackColor = true
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(134, 191)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(119, 23)
        Me.Button7.TabIndex = 16
        Me.Button7.Text = "Save Scraped"
        Me.Button7.UseVisualStyleBackColor = true
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(63, 7)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(48, 20)
        Me.NumericUpDown1.TabIndex = 17
        Me.NumericUpDown1.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(10, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Threads"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 191)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(119, 23)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Copy Scraped"
        Me.Button4.UseVisualStyleBackColor = true
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(134, 103)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(119, 23)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Save Custom"
        Me.Button6.UseVisualStyleBackColor = true
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(100, 133)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(153, 23)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Start Scraper"
        Me.Button5.UseVisualStyleBackColor = true
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.Button12)
        Me.TabPage2.Controls.Add(Me.Button8)
        Me.TabPage2.Controls.Add(Me.NumericUpDown2)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.CheckBox2)
        Me.TabPage2.Controls.Add(Me.Button9)
        Me.TabPage2.Controls.Add(Me.Button10)
        Me.TabPage2.Controls.Add(Me.TrackBar2)
        Me.TabPage2.Controls.Add(Me.Button11)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.ProgressBar3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(264, 220)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Checker"
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(6, 103)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(119, 23)
        Me.Button12.TabIndex = 28
        Me.Button12.Text = "Load Custom"
        Me.Button12.UseVisualStyleBackColor = true
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(134, 191)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(119, 23)
        Me.Button8.TabIndex = 25
        Me.Button8.Text = "Save Working"
        Me.Button8.UseVisualStyleBackColor = true
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(63, 7)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(48, 20)
        Me.NumericUpDown2.TabIndex = 27
        Me.NumericUpDown2.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(10, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Threads"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = true
        Me.CheckBox2.Location = New System.Drawing.Point(9, 80)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(122, 17)
        Me.CheckBox2.TabIndex = 21
        Me.CheckBox2.Text = "Use scraped proxies"
        Me.CheckBox2.UseVisualStyleBackColor = true
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(6, 191)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(119, 23)
        Me.Button9.TabIndex = 24
        Me.Button9.Text = "Copy Working"
        Me.Button9.UseVisualStyleBackColor = true
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(134, 103)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(119, 23)
        Me.Button10.TabIndex = 22
        Me.Button10.Text = "Save Custom"
        Me.Button10.UseVisualStyleBackColor = true
        '
        'TrackBar2
        '
        Me.TrackBar2.AccessibleName = ""
        Me.TrackBar2.LargeChange = 10
        Me.TrackBar2.Location = New System.Drawing.Point(13, 33)
        Me.TrackBar2.Maximum = 100
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(240, 45)
        Me.TrackBar2.TabIndex = 20
        Me.TrackBar2.TickFrequency = 10
        Me.TrackBar2.Value = 50
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(100, 133)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(153, 23)
        Me.Button11.TabIndex = 23
        Me.Button11.Text = "Start Checker"
        Me.Button11.UseVisualStyleBackColor = true
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(6, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Checker Progress"
        '
        'ProgressBar3
        '
        Me.ProgressBar3.Location = New System.Drawing.Point(6, 162)
        Me.ProgressBar3.Name = "ProgressBar3"
        Me.ProgressBar3.Size = New System.Drawing.Size(247, 23)
        Me.ProgressBar3.TabIndex = 18
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 260)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(264, 23)
        Me.ProgressBar1.TabIndex = 13
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = true
        Me.ListBox1.Location = New System.Drawing.Point(12, 318)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(262, 173)
        Me.ListBox1.TabIndex = 15
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 499)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "Form1"
        Me.Text = "Proxy Generator"
        CType(Me.TrackBar1,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        CType(Me.NumericUpDown2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TrackBar2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents TrackBar3 As TrackBar
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button8 As Button
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents TrackBar2 As TrackBar
    Friend WithEvents Button11 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents ProgressBar3 As ProgressBar
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Button7 As Button
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents Button13 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents ListBox1 As ListBox
End Class
