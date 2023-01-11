<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtIDE = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.txtApi = New System.Windows.Forms.TextBox()
        Me.btnApi = New System.Windows.Forms.Button()
        Me.cmbInputs = New System.Windows.Forms.ComboBox()
        Me.lblInput = New System.Windows.Forms.Label()
        Me.lblTextFields = New System.Windows.Forms.Label()
        Me.cmbTextFields = New System.Windows.Forms.ComboBox()
        CType(Me.txtIDE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIDE
        '
        Me.txtIDE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIDE.AutoCompleteBrackets = True
        Me.txtIDE.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.txtIDE.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.\(\)]+\s*(?<range>=)\s*(?<range>.+)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtIDE.AutoScrollMinSize = New System.Drawing.Size(27, 14)
        Me.txtIDE.BackBrush = Nothing
        Me.txtIDE.CharHeight = 14
        Me.txtIDE.CharWidth = 8
        Me.txtIDE.CommentPrefix = "'"
        Me.txtIDE.DefaultMarkerSize = 8
        Me.txtIDE.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtIDE.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtIDE.IsReplaceMode = False
        Me.txtIDE.Language = FastColoredTextBoxNS.Language.VB
        Me.txtIDE.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.txtIDE.Location = New System.Drawing.Point(0, 61)
        Me.txtIDE.Name = "txtIDE"
        Me.txtIDE.Paddings = New System.Windows.Forms.Padding(0)
        Me.txtIDE.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.txtIDE.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtIDE.ServiceColors = CType(resources.GetObject("txtIDE.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.txtIDE.Size = New System.Drawing.Size(888, 537)
        Me.txtIDE.TabIndex = 6
        Me.txtIDE.TabLength = 2
        Me.txtIDE.Zoom = 100
        '
        'txtApi
        '
        Me.txtApi.Location = New System.Drawing.Point(12, 12)
        Me.txtApi.Name = "txtApi"
        Me.txtApi.Size = New System.Drawing.Size(156, 23)
        Me.txtApi.TabIndex = 0
        Me.txtApi.Text = "http://localhost:8088/api"
        '
        'btnApi
        '
        Me.btnApi.Location = New System.Drawing.Point(174, 12)
        Me.btnApi.Name = "btnApi"
        Me.btnApi.Size = New System.Drawing.Size(75, 23)
        Me.btnApi.TabIndex = 1
        Me.btnApi.Text = "Connect"
        Me.btnApi.UseVisualStyleBackColor = True
        '
        'cmbInputs
        '
        Me.cmbInputs.FormattingEnabled = True
        Me.cmbInputs.Location = New System.Drawing.Point(255, 27)
        Me.cmbInputs.Name = "cmbInputs"
        Me.cmbInputs.Size = New System.Drawing.Size(214, 23)
        Me.cmbInputs.TabIndex = 3
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.Location = New System.Drawing.Point(255, 9)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(40, 15)
        Me.lblInput.TabIndex = 2
        Me.lblInput.Text = "Inputs"
        '
        'lblTextFields
        '
        Me.lblTextFields.AutoSize = True
        Me.lblTextFields.Location = New System.Drawing.Point(475, 9)
        Me.lblTextFields.Name = "lblTextFields"
        Me.lblTextFields.Size = New System.Drawing.Size(61, 15)
        Me.lblTextFields.TabIndex = 4
        Me.lblTextFields.Text = "Text Fields"
        '
        'cmbTextFields
        '
        Me.cmbTextFields.FormattingEnabled = True
        Me.cmbTextFields.Location = New System.Drawing.Point(475, 27)
        Me.cmbTextFields.Name = "cmbTextFields"
        Me.cmbTextFields.Size = New System.Drawing.Size(214, 23)
        Me.cmbTextFields.TabIndex = 5
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 610)
        Me.Controls.Add(Me.lblTextFields)
        Me.Controls.Add(Me.cmbTextFields)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.cmbInputs)
        Me.Controls.Add(Me.btnApi)
        Me.Controls.Add(Me.txtApi)
        Me.Controls.Add(Me.txtIDE)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "vMixIDE"
        CType(Me.txtIDE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtIDE As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents txtApi As TextBox
    Friend WithEvents btnApi As Button
    Friend WithEvents cmbInputs As ComboBox
    Friend WithEvents lblInput As Label
    Friend WithEvents lblTextFields As Label
    Friend WithEvents cmbTextFields As ComboBox
End Class
