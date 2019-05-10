<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Custom Folder")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Tv_Explorer = New System.Windows.Forms.TreeView()
        Me.Tv_ImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBoxRIGHTREPEATER = New System.Windows.Forms.GroupBox()
        Me.PlayerRight = New AxWMPLib.AxWindowsMediaPlayer()
        Me.GroupBoxFRONT = New System.Windows.Forms.GroupBox()
        Me.PlayerCenter = New AxWMPLib.AxWindowsMediaPlayer()
        Me.GroupBoxLEFTREPEATER = New System.Windows.Forms.GroupBox()
        Me.PlayerLeft = New AxWMPLib.AxWindowsMediaPlayer()
        Me.TxtBx_Path = New System.Windows.Forms.TextBox()
        Me.GroupBoxCONTROLS = New System.Windows.Forms.GroupBox()
        Me.GBsubCONTROLS = New System.Windows.Forms.GroupBox()
        Me.UPDATELabel = New System.Windows.Forms.Label()
        Me.Donation = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnREVERSE = New System.Windows.Forms.Button()
        Me.BtnPAUSE = New System.Windows.Forms.Button()
        Me.BtnPLAY = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TCLabelMax = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCLabelMin = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PlayerMediaInfo = New AxWMPLib.AxWindowsMediaPlayer()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBoxEXPLORER = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PREVIEWBox = New System.Windows.Forms.GroupBox()
        Me.PlayerPreview = New AxWMPLib.AxWindowsMediaPlayer()
        Me.CustomFolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBoxRIGHTREPEATER.SuspendLayout()
        CType(Me.PlayerRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxFRONT.SuspendLayout()
        CType(Me.PlayerCenter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxLEFTREPEATER.SuspendLayout()
        CType(Me.PlayerLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxCONTROLS.SuspendLayout()
        Me.GBsubCONTROLS.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlayerMediaInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxEXPLORER.SuspendLayout()
        Me.PREVIEWBox.SuspendLayout()
        CType(Me.PlayerPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tv_Explorer
        '
        Me.Tv_Explorer.AllowDrop = True
        Me.Tv_Explorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tv_Explorer.HideSelection = False
        Me.Tv_Explorer.HotTracking = True
        Me.Tv_Explorer.Location = New System.Drawing.Point(0, 13)
        Me.Tv_Explorer.Name = "Tv_Explorer"
        TreeNode9.Name = "Node0"
        TreeNode9.Tag = "Custom"
        TreeNode9.Text = "Custom Folder"
        TreeNode9.ToolTipText = "Custom Folder"
        Me.Tv_Explorer.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode9})
        Me.Tv_Explorer.ShowNodeToolTips = True
        Me.Tv_Explorer.Size = New System.Drawing.Size(376, 266)
        Me.Tv_Explorer.TabIndex = 3
        '
        'Tv_ImgList
        '
        Me.Tv_ImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.Tv_ImgList.ImageSize = New System.Drawing.Size(16, 16)
        Me.Tv_ImgList.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBoxRIGHTREPEATER
        '
        Me.GroupBoxRIGHTREPEATER.Controls.Add(Me.PlayerRight)
        Me.GroupBoxRIGHTREPEATER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxRIGHTREPEATER.Location = New System.Drawing.Point(787, 18)
        Me.GroupBoxRIGHTREPEATER.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxRIGHTREPEATER.Name = "GroupBoxRIGHTREPEATER"
        Me.GroupBoxRIGHTREPEATER.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBoxRIGHTREPEATER.Size = New System.Drawing.Size(359, 268)
        Me.GroupBoxRIGHTREPEATER.TabIndex = 13
        Me.GroupBoxRIGHTREPEATER.TabStop = False
        Me.GroupBoxRIGHTREPEATER.Text = "Right Repeater"
        '
        'PlayerRight
        '
        Me.PlayerRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlayerRight.Enabled = True
        Me.PlayerRight.Location = New System.Drawing.Point(0, 13)
        Me.PlayerRight.Name = "PlayerRight"
        Me.PlayerRight.OcxState = CType(resources.GetObject("PlayerRight.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PlayerRight.Size = New System.Drawing.Size(359, 255)
        Me.PlayerRight.TabIndex = 2
        '
        'GroupBoxFRONT
        '
        Me.GroupBoxFRONT.Controls.Add(Me.PlayerCenter)
        Me.GroupBoxFRONT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxFRONT.Location = New System.Drawing.Point(391, 2)
        Me.GroupBoxFRONT.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxFRONT.Name = "GroupBoxFRONT"
        Me.GroupBoxFRONT.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBoxFRONT.Size = New System.Drawing.Size(359, 268)
        Me.GroupBoxFRONT.TabIndex = 13
        Me.GroupBoxFRONT.TabStop = False
        Me.GroupBoxFRONT.Text = "Front"
        '
        'PlayerCenter
        '
        Me.PlayerCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlayerCenter.Enabled = True
        Me.PlayerCenter.Location = New System.Drawing.Point(0, 13)
        Me.PlayerCenter.Name = "PlayerCenter"
        Me.PlayerCenter.OcxState = CType(resources.GetObject("PlayerCenter.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PlayerCenter.Size = New System.Drawing.Size(359, 255)
        Me.PlayerCenter.TabIndex = 0
        '
        'GroupBoxLEFTREPEATER
        '
        Me.GroupBoxLEFTREPEATER.Controls.Add(Me.PlayerLeft)
        Me.GroupBoxLEFTREPEATER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxLEFTREPEATER.Location = New System.Drawing.Point(9, 289)
        Me.GroupBoxLEFTREPEATER.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxLEFTREPEATER.Name = "GroupBoxLEFTREPEATER"
        Me.GroupBoxLEFTREPEATER.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBoxLEFTREPEATER.Size = New System.Drawing.Size(359, 268)
        Me.GroupBoxLEFTREPEATER.TabIndex = 13
        Me.GroupBoxLEFTREPEATER.TabStop = False
        Me.GroupBoxLEFTREPEATER.Text = "Left Repeater"
        '
        'PlayerLeft
        '
        Me.PlayerLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlayerLeft.Enabled = True
        Me.PlayerLeft.Location = New System.Drawing.Point(0, 13)
        Me.PlayerLeft.Name = "PlayerLeft"
        Me.PlayerLeft.OcxState = CType(resources.GetObject("PlayerLeft.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PlayerLeft.Size = New System.Drawing.Size(359, 255)
        Me.PlayerLeft.TabIndex = 1
        '
        'TxtBx_Path
        '
        Me.TxtBx_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBx_Path.Location = New System.Drawing.Point(653, 309)
        Me.TxtBx_Path.Multiline = True
        Me.TxtBx_Path.Name = "TxtBx_Path"
        Me.TxtBx_Path.Size = New System.Drawing.Size(262, 112)
        Me.TxtBx_Path.TabIndex = 5
        Me.TxtBx_Path.Visible = False
        '
        'GroupBoxCONTROLS
        '
        Me.GroupBoxCONTROLS.Controls.Add(Me.GBsubCONTROLS)
        Me.GroupBoxCONTROLS.Location = New System.Drawing.Point(385, 284)
        Me.GroupBoxCONTROLS.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxCONTROLS.Name = "GroupBoxCONTROLS"
        Me.GroupBoxCONTROLS.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBoxCONTROLS.Size = New System.Drawing.Size(359, 290)
        Me.GroupBoxCONTROLS.TabIndex = 5
        Me.GroupBoxCONTROLS.TabStop = False
        Me.GroupBoxCONTROLS.Text = "Controls"
        '
        'GBsubCONTROLS
        '
        Me.GBsubCONTROLS.Controls.Add(Me.Donation)
        Me.GBsubCONTROLS.Controls.Add(Me.Label7)
        Me.GBsubCONTROLS.Controls.Add(Me.UPDATELabel)
        Me.GBsubCONTROLS.Controls.Add(Me.GroupBox2)
        Me.GBsubCONTROLS.Controls.Add(Me.TrackBar1)
        Me.GBsubCONTROLS.Controls.Add(Me.PictureBox1)
        Me.GBsubCONTROLS.Controls.Add(Me.TCLabelMax)
        Me.GBsubCONTROLS.Controls.Add(Me.TrackBar2)
        Me.GBsubCONTROLS.Controls.Add(Me.Label6)
        Me.GBsubCONTROLS.Controls.Add(Me.Label1)
        Me.GBsubCONTROLS.Controls.Add(Me.Label5)
        Me.GBsubCONTROLS.Controls.Add(Me.Label2)
        Me.GBsubCONTROLS.Controls.Add(Me.TCLabelMin)
        Me.GBsubCONTROLS.Controls.Add(Me.Label3)
        Me.GBsubCONTROLS.Controls.Add(Me.PlayerMediaInfo)
        Me.GBsubCONTROLS.Controls.Add(Me.Label4)
        Me.GBsubCONTROLS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GBsubCONTROLS.Location = New System.Drawing.Point(0, 13)
        Me.GBsubCONTROLS.Name = "GBsubCONTROLS"
        Me.GBsubCONTROLS.Size = New System.Drawing.Size(359, 277)
        Me.GBsubCONTROLS.TabIndex = 19
        Me.GBsubCONTROLS.TabStop = False
        '
        'UPDATELabel
        '
        Me.UPDATELabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.UPDATELabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UPDATELabel.ForeColor = System.Drawing.SystemColors.Control
        Me.UPDATELabel.Location = New System.Drawing.Point(62, 254)
        Me.UPDATELabel.Name = "UPDATELabel"
        Me.UPDATELabel.Size = New System.Drawing.Size(249, 18)
        Me.UPDATELabel.TabIndex = 19
        Me.UPDATELabel.Text = "Check for Updates"
        Me.UPDATELabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Donation
        '
        Me.Donation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Donation.BackColor = System.Drawing.Color.DimGray
        Me.Donation.BackgroundImage = Global.TeslaCam_Viewer.My.Resources.Resources.PayPalMe
        Me.Donation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Donation.Cursor = System.Windows.Forms.Cursors.Default
        Me.Donation.Location = New System.Drawing.Point(292, 181)
        Me.Donation.Name = "Donation"
        Me.Donation.Size = New System.Drawing.Size(59, 54)
        Me.Donation.TabIndex = 18
        Me.Donation.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnREVERSE)
        Me.GroupBox2.Controls.Add(Me.BtnPAUSE)
        Me.GroupBox2.Controls.Add(Me.BtnPLAY)
        Me.GroupBox2.Location = New System.Drawing.Point(97, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 49)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Controls"
        '
        'BtnREVERSE
        '
        Me.BtnREVERSE.Location = New System.Drawing.Point(5, 19)
        Me.BtnREVERSE.Name = "BtnREVERSE"
        Me.BtnREVERSE.Size = New System.Drawing.Size(56, 23)
        Me.BtnREVERSE.TabIndex = 2
        Me.BtnREVERSE.Text = "Reverse"
        Me.BtnREVERSE.UseVisualStyleBackColor = True
        '
        'BtnPAUSE
        '
        Me.BtnPAUSE.Location = New System.Drawing.Point(109, 19)
        Me.BtnPAUSE.Name = "BtnPAUSE"
        Me.BtnPAUSE.Size = New System.Drawing.Size(49, 23)
        Me.BtnPAUSE.TabIndex = 1
        Me.BtnPAUSE.Text = "Pause"
        Me.BtnPAUSE.UseVisualStyleBackColor = True
        '
        'BtnPLAY
        '
        Me.BtnPLAY.Location = New System.Drawing.Point(64, 19)
        Me.BtnPLAY.Name = "BtnPLAY"
        Me.BtnPLAY.Size = New System.Drawing.Size(42, 23)
        Me.BtnPLAY.TabIndex = 0
        Me.BtnPLAY.Text = "Play"
        Me.BtnPLAY.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBar1.BackColor = System.Drawing.Color.DimGray
        Me.TrackBar1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz
        Me.TrackBar1.Location = New System.Drawing.Point(6, 33)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(347, 45)
        Me.TrackBar1.TabIndex = 4
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBox1.Image = Global.TeslaCam_Viewer.My.Resources.Resources.InstaTwitterPurpleModel3
        Me.PictureBox1.Location = New System.Drawing.Point(121, 220)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(134, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'TCLabelMax
        '
        Me.TCLabelMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TCLabelMax.Location = New System.Drawing.Point(244, 13)
        Me.TCLabelMax.Name = "TCLabelMax"
        Me.TCLabelMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TCLabelMax.Size = New System.Drawing.Size(100, 16)
        Me.TCLabelMax.TabIndex = 6
        Me.TCLabelMax.Text = "             "
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(284, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Nate Mccomb"
        '
        'TrackBar2
        '
        Me.TrackBar2.Cursor = System.Windows.Forms.Cursors.NoMoveVert
        Me.TrackBar2.LargeChange = 10
        Me.TrackBar2.Location = New System.Drawing.Point(8, 80)
        Me.TrackBar2.Maximum = 50
        Me.TrackBar2.Minimum = 1
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar2.Size = New System.Drawing.Size(45, 169)
        Me.TrackBar2.TabIndex = 7
        Me.TrackBar2.TickFrequency = 10
        Me.TrackBar2.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.TrackBar2.Value = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(49, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "3x"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "1x"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(120, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Time Code (Seconds)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "1/10x"
        '
        'TCLabelMin
        '
        Me.TCLabelMin.AutoSize = True
        Me.TCLabelMin.Location = New System.Drawing.Point(18, 13)
        Me.TCLabelMin.Name = "TCLabelMin"
        Me.TCLabelMin.Size = New System.Drawing.Size(46, 13)
        Me.TCLabelMin.TabIndex = 5
        Me.TCLabelMin.Text = "             "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "5x"
        '
        'PlayerMediaInfo
        '
        Me.PlayerMediaInfo.AccessibleName = "Play"
        Me.PlayerMediaInfo.Enabled = True
        Me.PlayerMediaInfo.Location = New System.Drawing.Point(221, 77)
        Me.PlayerMediaInfo.Name = "PlayerMediaInfo"
        Me.PlayerMediaInfo.OcxState = CType(resources.GetObject("PlayerMediaInfo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PlayerMediaInfo.Size = New System.Drawing.Size(132, 76)
        Me.PlayerMediaInfo.TabIndex = 12
        Me.PlayerMediaInfo.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Speed"
        '
        'GroupBoxEXPLORER
        '
        Me.GroupBoxEXPLORER.Controls.Add(Me.Tv_Explorer)
        Me.GroupBoxEXPLORER.Location = New System.Drawing.Point(9, 2)
        Me.GroupBoxEXPLORER.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxEXPLORER.Name = "GroupBoxEXPLORER"
        Me.GroupBoxEXPLORER.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBoxEXPLORER.Size = New System.Drawing.Size(376, 279)
        Me.GroupBoxEXPLORER.TabIndex = 14
        Me.GroupBoxEXPLORER.TabStop = False
        Me.GroupBoxEXPLORER.Text = "Explorer"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'PREVIEWBox
        '
        Me.PREVIEWBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PREVIEWBox.Controls.Add(Me.PlayerPreview)
        Me.PREVIEWBox.Location = New System.Drawing.Point(942, 342)
        Me.PREVIEWBox.Name = "PREVIEWBox"
        Me.PREVIEWBox.Size = New System.Drawing.Size(477, 399)
        Me.PREVIEWBox.TabIndex = 18
        Me.PREVIEWBox.TabStop = False
        Me.PREVIEWBox.Text = "Preview Window"
        Me.PREVIEWBox.Visible = False
        '
        'PlayerPreview
        '
        Me.PlayerPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlayerPreview.Enabled = True
        Me.PlayerPreview.Location = New System.Drawing.Point(3, 16)
        Me.PlayerPreview.Name = "PlayerPreview"
        Me.PlayerPreview.OcxState = CType(resources.GetObject("PlayerPreview.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PlayerPreview.Size = New System.Drawing.Size(471, 380)
        Me.PlayerPreview.TabIndex = 0
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(1084, 572)
        Me.Controls.Add(Me.GroupBoxCONTROLS)
        Me.Controls.Add(Me.TxtBx_Path)
        Me.Controls.Add(Me.GroupBoxLEFTREPEATER)
        Me.Controls.Add(Me.GroupBoxRIGHTREPEATER)
        Me.Controls.Add(Me.GroupBoxEXPLORER)
        Me.Controls.Add(Me.GroupBoxFRONT)
        Me.Controls.Add(Me.PREVIEWBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1100, 580)
        Me.Name = "MainForm"
        Me.Text = "TeslaCam Viewer "
        Me.GroupBoxRIGHTREPEATER.ResumeLayout(False)
        CType(Me.PlayerRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxFRONT.ResumeLayout(False)
        CType(Me.PlayerCenter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxLEFTREPEATER.ResumeLayout(False)
        CType(Me.PlayerLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxCONTROLS.ResumeLayout(False)
        Me.GBsubCONTROLS.ResumeLayout(False)
        Me.GBsubCONTROLS.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlayerMediaInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxEXPLORER.ResumeLayout(False)
        Me.PREVIEWBox.ResumeLayout(False)
        CType(Me.PlayerPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PlayerLeft As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents PlayerRight As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Tv_Explorer As TreeView
    Friend WithEvents Tv_ImgList As ImageList
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents GroupBoxCONTROLS As GroupBox
    Friend WithEvents TxtBx_Path As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TCLabelMax As Label
    Friend WithEvents TCLabelMin As Label
    Friend WithEvents TrackBar2 As TrackBar
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PlayerMediaInfo As AxWMPLib.AxWindowsMediaPlayer
    Private WithEvents GroupBoxLEFTREPEATER As GroupBox
    Friend WithEvents GroupBoxFRONT As GroupBox
    Friend WithEvents PlayerCenter As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents GroupBoxRIGHTREPEATER As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnPAUSE As Button
    Friend WithEvents BtnPLAY As Button
    Friend WithEvents BtnREVERSE As Button
    Friend WithEvents PREVIEWBox As GroupBox
    Friend WithEvents PlayerPreview As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents GroupBoxEXPLORER As GroupBox
    Friend WithEvents CustomFolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents Donation As Button
    Private WithEvents GBsubCONTROLS As GroupBox
    Private WithEvents UPDATELabel As Label
End Class
