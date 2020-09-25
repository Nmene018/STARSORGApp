<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdmin))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpEdit = New System.Windows.Forms.GroupBox()
        Me.txtAdminOrgPass = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnChgPassCancel = New System.Windows.Forms.Button()
        Me.btnAdminSave = New System.Windows.Forms.Button()
        Me.txtAdminConfirmPass = New System.Windows.Forms.TextBox()
        Me.txtAdminNewPass = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.errP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbHome = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMember = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRole = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEvent = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRSVP = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCourse = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSemester = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLogOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbHelp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbAdmin = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAdminPID = New System.Windows.Forms.TextBox()
        Me.txtAdminPassword = New System.Windows.Forms.TextBox()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAdminConfirmMember = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstSecPriv = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.grpAdmin = New System.Windows.Forms.GroupBox()
        Me.btnCrtCancel = New System.Windows.Forms.Button()
        Me.lstNewMemInfo = New System.Windows.Forms.ListBox()
        Me.grpMemSec = New System.Windows.Forms.GroupBox()
        Me.lblMemInfo = New System.Windows.Forms.Label()
        Me.grpEdit.SuspendLayout()
        CType(Me.errP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grpAdmin.SuspendLayout()
        Me.grpMemSec.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(517, 44)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "ADMINISTRATOR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpEdit
        '
        Me.grpEdit.Controls.Add(Me.txtAdminOrgPass)
        Me.grpEdit.Controls.Add(Me.Label5)
        Me.grpEdit.Controls.Add(Me.btnChgPassCancel)
        Me.grpEdit.Controls.Add(Me.btnAdminSave)
        Me.grpEdit.Controls.Add(Me.txtAdminConfirmPass)
        Me.grpEdit.Controls.Add(Me.txtAdminNewPass)
        Me.grpEdit.Controls.Add(Me.Label6)
        Me.grpEdit.Controls.Add(Me.Label7)
        Me.grpEdit.Location = New System.Drawing.Point(377, 281)
        Me.grpEdit.Name = "grpEdit"
        Me.grpEdit.Size = New System.Drawing.Size(303, 145)
        Me.grpEdit.TabIndex = 15
        Me.grpEdit.TabStop = False
        Me.grpEdit.Text = "Reset Member Password"
        '
        'txtAdminOrgPass
        '
        Me.txtAdminOrgPass.Location = New System.Drawing.Point(104, 19)
        Me.txtAdminOrgPass.MaxLength = 15
        Me.txtAdminOrgPass.Name = "txtAdminOrgPass"
        Me.txtAdminOrgPass.Size = New System.Drawing.Size(171, 20)
        Me.txtAdminOrgPass.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "U&ser ID:"
        '
        'btnChgPassCancel
        '
        Me.btnChgPassCancel.Location = New System.Drawing.Point(194, 99)
        Me.btnChgPassCancel.Name = "btnChgPassCancel"
        Me.btnChgPassCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnChgPassCancel.TabIndex = 4
        Me.btnChgPassCancel.Text = "Ca&ncel"
        Me.btnChgPassCancel.UseVisualStyleBackColor = True
        '
        'btnAdminSave
        '
        Me.btnAdminSave.Location = New System.Drawing.Point(104, 99)
        Me.btnAdminSave.Name = "btnAdminSave"
        Me.btnAdminSave.Size = New System.Drawing.Size(80, 35)
        Me.btnAdminSave.TabIndex = 3
        Me.btnAdminSave.Text = "&Save"
        Me.btnAdminSave.UseVisualStyleBackColor = True
        '
        'txtAdminConfirmPass
        '
        Me.txtAdminConfirmPass.Location = New System.Drawing.Point(104, 73)
        Me.txtAdminConfirmPass.MaxLength = 100
        Me.txtAdminConfirmPass.Multiline = True
        Me.txtAdminConfirmPass.Name = "txtAdminConfirmPass"
        Me.txtAdminConfirmPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAdminConfirmPass.Size = New System.Drawing.Size(171, 20)
        Me.txtAdminConfirmPass.TabIndex = 2
        '
        'txtAdminNewPass
        '
        Me.txtAdminNewPass.Location = New System.Drawing.Point(104, 47)
        Me.txtAdminNewPass.MaxLength = 15
        Me.txtAdminNewPass.Name = "txtAdminNewPass"
        Me.txtAdminNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAdminNewPass.Size = New System.Drawing.Size(171, 20)
        Me.txtAdminNewPass.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 32)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "C&onfirm Password: "
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "&New Password: "
        '
        'errP
        '
        Me.errP.ContainerControl = Me
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 454)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(715, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslStatus
        '
        Me.tslStatus.AutoSize = False
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(695, 17)
        Me.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.tsbHome, Me.ToolStripSeparator2, Me.tsbMember, Me.ToolStripSeparator1, Me.tsbRole, Me.ToolStripSeparator9, Me.tsbEvent, Me.ToolStripSeparator8, Me.tsbRSVP, Me.ToolStripSeparator7, Me.tsbCourse, Me.ToolStripSeparator10, Me.tsbSemester, Me.ToolStripSeparator6, Me.ToolStripSeparator5, Me.tsbLogOut, Me.ToolStripSeparator3, Me.tsbHelp, Me.ToolStripSeparator11, Me.tsbAdmin, Me.ToolStripSeparator12})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(715, 50)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AutoSize = False
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(10, 50)
        '
        'tsbHome
        '
        Me.tsbHome.AutoSize = False
        Me.tsbHome.BackgroundImage = CType(resources.GetObject("tsbHome.BackgroundImage"), System.Drawing.Image)
        Me.tsbHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHome.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHome.Name = "tsbHome"
        Me.tsbHome.Size = New System.Drawing.Size(55, 48)
        Me.tsbHome.Text = "HOME"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(10, 50)
        '
        'tsbMember
        '
        Me.tsbMember.AutoSize = False
        Me.tsbMember.BackgroundImage = CType(resources.GetObject("tsbMember.BackgroundImage"), System.Drawing.Image)
        Me.tsbMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMember.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMember.Name = "tsbMember"
        Me.tsbMember.Size = New System.Drawing.Size(55, 48)
        Me.tsbMember.Text = "MEMBER"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(10, 50)
        '
        'tsbRole
        '
        Me.tsbRole.AutoSize = False
        Me.tsbRole.BackgroundImage = CType(resources.GetObject("tsbRole.BackgroundImage"), System.Drawing.Image)
        Me.tsbRole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbRole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRole.Name = "tsbRole"
        Me.tsbRole.Size = New System.Drawing.Size(48, 48)
        Me.tsbRole.Text = "ROLE"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.AutoSize = False
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(10, 50)
        '
        'tsbEvent
        '
        Me.tsbEvent.AutoSize = False
        Me.tsbEvent.BackgroundImage = CType(resources.GetObject("tsbEvent.BackgroundImage"), System.Drawing.Image)
        Me.tsbEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEvent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEvent.Name = "tsbEvent"
        Me.tsbEvent.Size = New System.Drawing.Size(48, 48)
        Me.tsbEvent.Text = "EVENT"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.AutoSize = False
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(10, 50)
        '
        'tsbRSVP
        '
        Me.tsbRSVP.AutoSize = False
        Me.tsbRSVP.BackgroundImage = CType(resources.GetObject("tsbRSVP.BackgroundImage"), System.Drawing.Image)
        Me.tsbRSVP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbRSVP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRSVP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRSVP.Name = "tsbRSVP"
        Me.tsbRSVP.Size = New System.Drawing.Size(48, 48)
        Me.tsbRSVP.Text = "RSVP"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.AutoSize = False
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(10, 50)
        '
        'tsbCourse
        '
        Me.tsbCourse.AutoSize = False
        Me.tsbCourse.BackgroundImage = CType(resources.GetObject("tsbCourse.BackgroundImage"), System.Drawing.Image)
        Me.tsbCourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbCourse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCourse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCourse.Name = "tsbCourse"
        Me.tsbCourse.Size = New System.Drawing.Size(48, 48)
        Me.tsbCourse.Text = "COURSE"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.AutoSize = False
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(10, 50)
        '
        'tsbSemester
        '
        Me.tsbSemester.AutoSize = False
        Me.tsbSemester.BackgroundImage = CType(resources.GetObject("tsbSemester.BackgroundImage"), System.Drawing.Image)
        Me.tsbSemester.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbSemester.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSemester.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSemester.Name = "tsbSemester"
        Me.tsbSemester.Size = New System.Drawing.Size(60, 48)
        Me.tsbSemester.Text = "SEMESTER"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.AutoSize = False
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.AutoSize = False
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(10, 50)
        '
        'tsbLogOut
        '
        Me.tsbLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbLogOut.AutoSize = False
        Me.tsbLogOut.BackgroundImage = CType(resources.GetObject("tsbLogOut.BackgroundImage"), System.Drawing.Image)
        Me.tsbLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbLogOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLogOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLogOut.Name = "tsbLogOut"
        Me.tsbLogOut.Size = New System.Drawing.Size(55, 48)
        Me.tsbLogOut.Text = "LOGOUT"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(10, 50)
        '
        'tsbHelp
        '
        Me.tsbHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbHelp.AutoSize = False
        Me.tsbHelp.BackgroundImage = CType(resources.GetObject("tsbHelp.BackgroundImage"), System.Drawing.Image)
        Me.tsbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHelp.Name = "tsbHelp"
        Me.tsbHelp.Size = New System.Drawing.Size(48, 48)
        Me.tsbHelp.Text = "HELP"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator11.AutoSize = False
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(10, 50)
        '
        'tsbAdmin
        '
        Me.tsbAdmin.AutoSize = False
        Me.tsbAdmin.BackgroundImage = CType(resources.GetObject("tsbAdmin.BackgroundImage"), System.Drawing.Image)
        Me.tsbAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbAdmin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAdmin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdmin.Name = "tsbAdmin"
        Me.tsbAdmin.Size = New System.Drawing.Size(48, 48)
        Me.tsbAdmin.Text = "ADMIN"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.AutoSize = False
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(10, 50)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 29)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "&Panther ID: "
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(6, 97)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 32)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "P&assword: "
        '
        'txtAdminPID
        '
        Me.txtAdminPID.Location = New System.Drawing.Point(104, 20)
        Me.txtAdminPID.MaxLength = 15
        Me.txtAdminPID.Name = "txtAdminPID"
        Me.txtAdminPID.Size = New System.Drawing.Size(182, 20)
        Me.txtAdminPID.TabIndex = 0
        '
        'txtAdminPassword
        '
        Me.txtAdminPassword.Location = New System.Drawing.Point(104, 94)
        Me.txtAdminPassword.MaxLength = 100
        Me.txtAdminPassword.Multiline = True
        Me.txtAdminPassword.Name = "txtAdminPassword"
        Me.txtAdminPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAdminPassword.Size = New System.Drawing.Size(182, 20)
        Me.txtAdminPassword.TabIndex = 2
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(104, 256)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(81, 34)
        Me.btnCreate.TabIndex = 5
        Me.btnCreate.Text = "&Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 32)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "&Confirm Password: "
        '
        'txtAdminConfirmMember
        '
        Me.txtAdminConfirmMember.Location = New System.Drawing.Point(104, 133)
        Me.txtAdminConfirmMember.MaxLength = 100
        Me.txtAdminConfirmMember.Multiline = True
        Me.txtAdminConfirmMember.Name = "txtAdminConfirmMember"
        Me.txtAdminConfirmMember.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAdminConfirmMember.Size = New System.Drawing.Size(182, 20)
        Me.txtAdminConfirmMember.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 32)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "&Security Role:"
        '
        'lstSecPriv
        '
        Me.lstSecPriv.FormattingEnabled = True
        Me.lstSecPriv.Location = New System.Drawing.Point(104, 168)
        Me.lstSecPriv.Name = "lstSecPriv"
        Me.lstSecPriv.Size = New System.Drawing.Size(182, 69)
        Me.lstSecPriv.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(6, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 29)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "&User ID: "
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(104, 59)
        Me.txtUserID.MaxLength = 100
        Me.txtUserID.Multiline = True
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(182, 20)
        Me.txtUserID.TabIndex = 1
        '
        'grpAdmin
        '
        Me.grpAdmin.Controls.Add(Me.btnCrtCancel)
        Me.grpAdmin.Controls.Add(Me.txtUserID)
        Me.grpAdmin.Controls.Add(Me.Label8)
        Me.grpAdmin.Controls.Add(Me.lstSecPriv)
        Me.grpAdmin.Controls.Add(Me.Label3)
        Me.grpAdmin.Controls.Add(Me.txtAdminConfirmMember)
        Me.grpAdmin.Controls.Add(Me.Label2)
        Me.grpAdmin.Controls.Add(Me.btnCreate)
        Me.grpAdmin.Controls.Add(Me.txtAdminPassword)
        Me.grpAdmin.Controls.Add(Me.txtAdminPID)
        Me.grpAdmin.Controls.Add(Me.Label15)
        Me.grpAdmin.Controls.Add(Me.Label4)
        Me.grpAdmin.Location = New System.Drawing.Point(30, 139)
        Me.grpAdmin.Name = "grpAdmin"
        Me.grpAdmin.Size = New System.Drawing.Size(317, 307)
        Me.grpAdmin.TabIndex = 14
        Me.grpAdmin.TabStop = False
        Me.grpAdmin.Text = "Create New Member"
        '
        'btnCrtCancel
        '
        Me.btnCrtCancel.Location = New System.Drawing.Point(205, 256)
        Me.btnCrtCancel.Name = "btnCrtCancel"
        Me.btnCrtCancel.Size = New System.Drawing.Size(81, 34)
        Me.btnCrtCancel.TabIndex = 6
        Me.btnCrtCancel.Text = "C&ancel"
        Me.btnCrtCancel.UseVisualStyleBackColor = True
        '
        'lstNewMemInfo
        '
        Me.lstNewMemInfo.FormattingEnabled = True
        Me.lstNewMemInfo.Location = New System.Drawing.Point(9, 17)
        Me.lstNewMemInfo.Name = "lstNewMemInfo"
        Me.lstNewMemInfo.Size = New System.Drawing.Size(266, 82)
        Me.lstNewMemInfo.TabIndex = 18
        '
        'grpMemSec
        '
        Me.grpMemSec.Controls.Add(Me.lstNewMemInfo)
        Me.grpMemSec.Location = New System.Drawing.Point(377, 139)
        Me.grpMemSec.Name = "grpMemSec"
        Me.grpMemSec.Size = New System.Drawing.Size(303, 104)
        Me.grpMemSec.TabIndex = 20
        Me.grpMemSec.TabStop = False
        Me.grpMemSec.Text = "New Member's Information:"
        '
        'lblMemInfo
        '
        Me.lblMemInfo.BackColor = System.Drawing.Color.White
        Me.lblMemInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMemInfo.Location = New System.Drawing.Point(571, 72)
        Me.lblMemInfo.Name = "lblMemInfo"
        Me.lblMemInfo.Size = New System.Drawing.Size(134, 44)
        Me.lblMemInfo.TabIndex = 21
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 476)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblMemInfo)
        Me.Controls.Add(Me.grpMemSec)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grpEdit)
        Me.Controls.Add(Me.grpAdmin)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administration"
        Me.grpEdit.ResumeLayout(False)
        Me.grpEdit.PerformLayout()
        CType(Me.errP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpAdmin.ResumeLayout(False)
        Me.grpAdmin.PerformLayout()
        Me.grpMemSec.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents grpEdit As GroupBox
    Friend WithEvents txtAdminOrgPass As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnChgPassCancel As Button
    Friend WithEvents btnAdminSave As Button
    Friend WithEvents txtAdminConfirmPass As TextBox
    Friend WithEvents txtAdminNewPass As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents errP As ErrorProvider
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tslStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbHome As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbMember As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbRole As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents tsbEvent As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tsbRSVP As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents tsbCourse As ToolStripButton
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents tsbSemester As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsbLogOut As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsbHelp As ToolStripButton
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents lstNewMemInfo As ListBox
    Friend WithEvents grpAdmin As GroupBox
    Friend WithEvents btnCrtCancel As Button
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lstSecPriv As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAdminConfirmMember As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCreate As Button
    Friend WithEvents txtAdminPassword As TextBox
    Friend WithEvents txtAdminPID As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tsbAdmin As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents grpMemSec As GroupBox
    Friend WithEvents lstMemInfo As ListBox
    Friend WithEvents lblMemInfo As Label
End Class
