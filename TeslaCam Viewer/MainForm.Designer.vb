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
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Custom Folder")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Tv_Explorer = New System.Windows.Forms.TreeView()
        Me.Tv_ImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBoxRIGHTREPEATER = New System.Windows.Forms.GroupBox()
        Me.PlayerRight = New AxWMPLib.AxWindowsMediaPlayer()
        Me.GroupBoxFRONT = New System.Windows.Forms.GroupBox()
        Me.PlayerCenter = New AxWMPLib.AxWindowsMediaPlayer()
        Me.GroupBoxLEFTREPEATER = New System.Windows.Forms.GroupBox()
        Me.PlayerLeft = New AxWMPLib.AxWindowsMediaPlayer()
        Me.GroupBoxCONTROLS = New System.Windows.Forms.GroupBox()
        Me.GBsubCONTROLS = New System.Windows.Forms.GroupBox()
        Me.GroupBoxSettings = New System.Windows.Forms.GroupBox()
        Me.MirrorLREnable = New System.Windows.Forms.CheckBox()
        Me.FilpLREnable = New System.Windows.Forms.CheckBox()
        Me.RenderQuality = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RenderBTN = New System.Windows.Forms.Button()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.CloseGroupboxSettings = New System.Windows.Forms.Label()
        Me.Donation = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UPDATELabel = New System.Windows.Forms.Label()
        Me.GroupBoxControlsWindow = New System.Windows.Forms.GroupBox()
        Me.ClipSelectUP = New System.Windows.Forms.Button()
        Me.SettingsBTN = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ClipSelectDOWN = New System.Windows.Forms.Button()
        Me.CurrentTimeList = New System.Windows.Forms.ListBox()
        Me.BtnREVERSE = New System.Windows.Forms.Button()
        Me.BtnPAUSE = New System.Windows.Forms.Button()
        Me.BtnPLAY = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TCLabelMax = New System.Windows.Forms.Label()
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
        Me.GroupBoxRENDER = New System.Windows.Forms.GroupBox()
        Me.VideoRendering = New System.Windows.Forms.Label()
        Me.PlayerRender = New AxWMPLib.AxWindowsMediaPlayer()
        Me.RenderSaveOptions = New System.Windows.Forms.GroupBox()
        Me.RenderPlayerTimecode = New System.Windows.Forms.Label()
        Me.RenderTotalTimeLabel = New System.Windows.Forms.Label()
        Me.RenderOutTimeLabel = New System.Windows.Forms.Label()
        Me.RenderInTimeLabel = New System.Windows.Forms.Label()
        Me.RenderSaveAsBTN = New System.Windows.Forms.Button()
        Me.FFmpegOutput = New System.Windows.Forms.RichTextBox()
        Me.RenderOutTimeGraphic = New System.Windows.Forms.Label()
        Me.RenderInTimeGraphic = New System.Windows.Forms.Label()
        Me.RenderTimeline = New System.Windows.Forms.TrackBar()
        Me.DurationProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ThreadsRunningLabel = New System.Windows.Forms.Label()
        Me.RenderFileProgress = New System.Windows.Forms.Label()
        Me.CloseGroupboxRender = New System.Windows.Forms.Label()
        Me.TxtBx_Path = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBoxRIGHTREPEATER.SuspendLayout()
        CType(Me.PlayerRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxFRONT.SuspendLayout()
        CType(Me.PlayerCenter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxLEFTREPEATER.SuspendLayout()
        CType(Me.PlayerLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxCONTROLS.SuspendLayout()
        Me.GBsubCONTROLS.SuspendLayout()
        Me.GroupBoxSettings.SuspendLayout()
        Me.GroupBoxControlsWindow.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlayerMediaInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxEXPLORER.SuspendLayout()
        Me.PREVIEWBox.SuspendLayout()
        CType(Me.PlayerPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxRENDER.SuspendLayout()
        CType(Me.PlayerRender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RenderSaveOptions.SuspendLayout()
        CType(Me.RenderTimeline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        TreeNode6.Name = "Node0"
        TreeNode6.Tag = "Custom"
        TreeNode6.Text = "Custom Folder"
        TreeNode6.ToolTipText = "Custom Folder"
        Me.Tv_Explorer.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode6})
        Me.Tv_Explorer.ShowNodeToolTips = True
        Me.Tv_Explorer.Size = New System.Drawing.Size(376, 266)
        Me.Tv_Explorer.TabIndex = 1
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
        Me.PlayerRight.TabStop = False
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
        Me.PlayerCenter.TabStop = False
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
        Me.PlayerLeft.TabStop = False
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
        Me.GBsubCONTROLS.Controls.Add(Me.GroupBoxSettings)
        Me.GBsubCONTROLS.Controls.Add(Me.Donation)
        Me.GBsubCONTROLS.Controls.Add(Me.Label7)
        Me.GBsubCONTROLS.Controls.Add(Me.UPDATELabel)
        Me.GBsubCONTROLS.Controls.Add(Me.GroupBoxControlsWindow)
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
        'GroupBoxSettings
        '
        Me.GroupBoxSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBoxSettings.Controls.Add(Me.MirrorLREnable)
        Me.GroupBoxSettings.Controls.Add(Me.FilpLREnable)
        Me.GroupBoxSettings.Controls.Add(Me.RenderQuality)
        Me.GroupBoxSettings.Controls.Add(Me.Label9)
        Me.GroupBoxSettings.Controls.Add(Me.RenderBTN)
        Me.GroupBoxSettings.Controls.Add(Me.RadioButton5)
        Me.GroupBoxSettings.Controls.Add(Me.RadioButton4)
        Me.GroupBoxSettings.Controls.Add(Me.RadioButton3)
        Me.GroupBoxSettings.Controls.Add(Me.RadioButton2)
        Me.GroupBoxSettings.Controls.Add(Me.RadioButton1)
        Me.GroupBoxSettings.Controls.Add(Me.CloseGroupboxSettings)
        Me.GroupBoxSettings.Location = New System.Drawing.Point(91, 175)
        Me.GroupBoxSettings.Name = "GroupBoxSettings"
        Me.GroupBoxSettings.Size = New System.Drawing.Size(274, 128)
        Me.GroupBoxSettings.TabIndex = 20
        Me.GroupBoxSettings.TabStop = False
        Me.GroupBoxSettings.Text = "Settings"
        Me.GroupBoxSettings.Visible = False
        '
        'MirrorLREnable
        '
        Me.MirrorLREnable.AutoSize = True
        Me.MirrorLREnable.Location = New System.Drawing.Point(74, 25)
        Me.MirrorLREnable.Name = "MirrorLREnable"
        Me.MirrorLREnable.Size = New System.Drawing.Size(69, 17)
        Me.MirrorLREnable.TabIndex = 12
        Me.MirrorLREnable.TabStop = False
        Me.MirrorLREnable.Text = "Mirror LR"
        Me.MirrorLREnable.UseVisualStyleBackColor = True
        '
        'FilpLREnable
        '
        Me.FilpLREnable.AutoSize = True
        Me.FilpLREnable.Location = New System.Drawing.Point(74, 11)
        Me.FilpLREnable.Name = "FilpLREnable"
        Me.FilpLREnable.Size = New System.Drawing.Size(59, 17)
        Me.FilpLREnable.TabIndex = 11
        Me.FilpLREnable.TabStop = False
        Me.FilpLREnable.Text = "Filp LR"
        Me.FilpLREnable.UseVisualStyleBackColor = True
        '
        'RenderQuality
        '
        Me.RenderQuality.FormattingEnabled = True
        Me.RenderQuality.Items.AddRange(New Object() {"Max", "High", "Medium", "Low"})
        Me.RenderQuality.Location = New System.Drawing.Point(119, 58)
        Me.RenderQuality.Name = "RenderQuality"
        Me.RenderQuality.Size = New System.Drawing.Size(121, 21)
        Me.RenderQuality.TabIndex = 10
        Me.RenderQuality.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(143, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Video Quality"
        '
        'RenderBTN
        '
        Me.RenderBTN.Enabled = False
        Me.RenderBTN.Location = New System.Drawing.Point(141, 83)
        Me.RenderBTN.Name = "RenderBTN"
        Me.RenderBTN.Size = New System.Drawing.Size(75, 23)
        Me.RenderBTN.TabIndex = 6
        Me.RenderBTN.Text = "Render"
        Me.RenderBTN.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.BackgroundImage = CType(resources.GetObject("RadioButton5.BackgroundImage"), System.Drawing.Image)
        Me.RadioButton5.Location = New System.Drawing.Point(6, 106)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton5.TabIndex = 8
        Me.RadioButton5.Text = "            "
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.BackgroundImage = CType(resources.GetObject("RadioButton4.BackgroundImage"), System.Drawing.Image)
        Me.RadioButton4.Location = New System.Drawing.Point(6, 83)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton4.TabIndex = 7
        Me.RadioButton4.Text = "            "
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.BackgroundImage = CType(resources.GetObject("RadioButton3.BackgroundImage"), System.Drawing.Image)
        Me.RadioButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RadioButton3.Location = New System.Drawing.Point(6, 60)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton3.TabIndex = 6
        Me.RadioButton3.Text = "            "
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackgroundImage = CType(resources.GetObject("RadioButton2.BackgroundImage"), System.Drawing.Image)
        Me.RadioButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RadioButton2.Location = New System.Drawing.Point(6, 37)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton2.TabIndex = 5
        Me.RadioButton2.Text = "            "
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackgroundImage = CType(resources.GetObject("RadioButton1.BackgroundImage"), System.Drawing.Image)
        Me.RadioButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.Text = "            "
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'CloseGroupboxSettings
        '
        Me.CloseGroupboxSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseGroupboxSettings.AutoSize = True
        Me.CloseGroupboxSettings.BackColor = System.Drawing.Color.Red
        Me.CloseGroupboxSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseGroupboxSettings.Location = New System.Drawing.Point(262, 8)
        Me.CloseGroupboxSettings.Name = "CloseGroupboxSettings"
        Me.CloseGroupboxSettings.Size = New System.Drawing.Size(11, 12)
        Me.CloseGroupboxSettings.TabIndex = 3
        Me.CloseGroupboxSettings.Text = "X"
        '
        'Donation
        '
        Me.Donation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Donation.BackColor = System.Drawing.Color.DimGray
        Me.Donation.BackgroundImage = Global.TeslaCam_Viewer.My.Resources.Resources.btn_donate_SM
        Me.Donation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Donation.Cursor = System.Windows.Forms.Cursors.Default
        Me.Donation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Donation.ForeColor = System.Drawing.Color.DimGray
        Me.Donation.Location = New System.Drawing.Point(287, 212)
        Me.Donation.Name = "Donation"
        Me.Donation.Size = New System.Drawing.Size(64, 23)
        Me.Donation.TabIndex = 18
        Me.Donation.TabStop = False
        Me.Donation.UseVisualStyleBackColor = False
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
        'GroupBoxControlsWindow
        '
        Me.GroupBoxControlsWindow.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBoxControlsWindow.Controls.Add(Me.BtnREVERSE)
        Me.GroupBoxControlsWindow.Controls.Add(Me.BtnPAUSE)
        Me.GroupBoxControlsWindow.Controls.Add(Me.BtnPLAY)
        Me.GroupBoxControlsWindow.Controls.Add(Me.GroupBox1)
        Me.GroupBoxControlsWindow.Location = New System.Drawing.Point(77, 74)
        Me.GroupBoxControlsWindow.Name = "GroupBoxControlsWindow"
        Me.GroupBoxControlsWindow.Size = New System.Drawing.Size(274, 128)
        Me.GroupBoxControlsWindow.TabIndex = 17
        Me.GroupBoxControlsWindow.TabStop = False
        Me.GroupBoxControlsWindow.Text = "Controls"
        '
        'ClipSelectUP
        '
        Me.ClipSelectUP.Location = New System.Drawing.Point(79, 13)
        Me.ClipSelectUP.Name = "ClipSelectUP"
        Me.ClipSelectUP.Size = New System.Drawing.Size(25, 26)
        Me.ClipSelectUP.TabIndex = 4
        Me.ClipSelectUP.TabStop = False
        Me.ClipSelectUP.Text = "/\"
        Me.ClipSelectUP.UseVisualStyleBackColor = True
        '
        'SettingsBTN
        '
        Me.SettingsBTN.Location = New System.Drawing.Point(143, 45)
        Me.SettingsBTN.Name = "SettingsBTN"
        Me.SettingsBTN.Size = New System.Drawing.Size(75, 23)
        Me.SettingsBTN.TabIndex = 8
        Me.SettingsBTN.Text = "Export"
        Me.SettingsBTN.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(117, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 23)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Export Selected Video Files"
        '
        'ClipSelectDOWN
        '
        Me.ClipSelectDOWN.Location = New System.Drawing.Point(79, 54)
        Me.ClipSelectDOWN.Name = "ClipSelectDOWN"
        Me.ClipSelectDOWN.Size = New System.Drawing.Size(25, 26)
        Me.ClipSelectDOWN.TabIndex = 5
        Me.ClipSelectDOWN.TabStop = False
        Me.ClipSelectDOWN.Text = "\/"
        Me.ClipSelectDOWN.UseVisualStyleBackColor = True
        '
        'CurrentTimeList
        '
        Me.CurrentTimeList.FormattingEnabled = True
        Me.CurrentTimeList.Location = New System.Drawing.Point(6, 12)
        Me.CurrentTimeList.Name = "CurrentTimeList"
        Me.CurrentTimeList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.CurrentTimeList.Size = New System.Drawing.Size(67, 69)
        Me.CurrentTimeList.TabIndex = 2
        '
        'BtnREVERSE
        '
        Me.BtnREVERSE.Location = New System.Drawing.Point(5, 19)
        Me.BtnREVERSE.Name = "BtnREVERSE"
        Me.BtnREVERSE.Size = New System.Drawing.Size(56, 23)
        Me.BtnREVERSE.TabIndex = 5
        Me.BtnREVERSE.Text = "Reverse"
        Me.BtnREVERSE.UseVisualStyleBackColor = True
        '
        'BtnPAUSE
        '
        Me.BtnPAUSE.Location = New System.Drawing.Point(109, 19)
        Me.BtnPAUSE.Name = "BtnPAUSE"
        Me.BtnPAUSE.Size = New System.Drawing.Size(49, 23)
        Me.BtnPAUSE.TabIndex = 4
        Me.BtnPAUSE.Text = "Pause"
        Me.BtnPAUSE.UseVisualStyleBackColor = True
        '
        'BtnPLAY
        '
        Me.BtnPLAY.Location = New System.Drawing.Point(64, 19)
        Me.BtnPLAY.Name = "BtnPLAY"
        Me.BtnPLAY.Size = New System.Drawing.Size(42, 23)
        Me.BtnPLAY.TabIndex = 3
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
        Me.TrackBar1.TabStop = False
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
        Me.TrackBar2.TabStop = False
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
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
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
        Me.PlayerMediaInfo.TabStop = False
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
        Me.PlayerPreview.TabStop = False
        '
        'GroupBoxRENDER
        '
        Me.GroupBoxRENDER.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxRENDER.Controls.Add(Me.VideoRendering)
        Me.GroupBoxRENDER.Controls.Add(Me.PlayerRender)
        Me.GroupBoxRENDER.Controls.Add(Me.RenderSaveOptions)
        Me.GroupBoxRENDER.Controls.Add(Me.FFmpegOutput)
        Me.GroupBoxRENDER.Controls.Add(Me.RenderOutTimeGraphic)
        Me.GroupBoxRENDER.Controls.Add(Me.RenderInTimeGraphic)
        Me.GroupBoxRENDER.Controls.Add(Me.RenderTimeline)
        Me.GroupBoxRENDER.Controls.Add(Me.DurationProgressBar)
        Me.GroupBoxRENDER.Controls.Add(Me.ThreadsRunningLabel)
        Me.GroupBoxRENDER.Controls.Add(Me.RenderFileProgress)
        Me.GroupBoxRENDER.Controls.Add(Me.CloseGroupboxRender)
        Me.GroupBoxRENDER.Location = New System.Drawing.Point(608, 60)
        Me.GroupBoxRENDER.Name = "GroupBoxRENDER"
        Me.GroupBoxRENDER.Size = New System.Drawing.Size(473, 300)
        Me.GroupBoxRENDER.TabIndex = 19
        Me.GroupBoxRENDER.TabStop = False
        Me.GroupBoxRENDER.Text = "Render"
        Me.GroupBoxRENDER.Visible = False
        '
        'VideoRendering
        '
        Me.VideoRendering.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VideoRendering.AutoSize = True
        Me.VideoRendering.BackColor = System.Drawing.Color.Red
        Me.VideoRendering.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VideoRendering.Location = New System.Drawing.Point(-243, 46)
        Me.VideoRendering.Name = "VideoRendering"
        Me.VideoRendering.Size = New System.Drawing.Size(924, 24)
        Me.VideoRendering.TabIndex = 3
        Me.VideoRendering.Text = "Your video is being rendered and could take several minutes, Please be patient wh" &
    "ile this process completes."
        '
        'PlayerRender
        '
        Me.PlayerRender.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayerRender.Enabled = True
        Me.PlayerRender.Location = New System.Drawing.Point(13, 16)
        Me.PlayerRender.Name = "PlayerRender"
        Me.PlayerRender.OcxState = CType(resources.GetObject("PlayerRender.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PlayerRender.Size = New System.Drawing.Size(449, 146)
        Me.PlayerRender.TabIndex = 1
        '
        'RenderSaveOptions
        '
        Me.RenderSaveOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RenderSaveOptions.Controls.Add(Me.RenderPlayerTimecode)
        Me.RenderSaveOptions.Controls.Add(Me.RenderTotalTimeLabel)
        Me.RenderSaveOptions.Controls.Add(Me.RenderOutTimeLabel)
        Me.RenderSaveOptions.Controls.Add(Me.RenderInTimeLabel)
        Me.RenderSaveOptions.Controls.Add(Me.RenderSaveAsBTN)
        Me.RenderSaveOptions.Location = New System.Drawing.Point(272, 190)
        Me.RenderSaveOptions.Name = "RenderSaveOptions"
        Me.RenderSaveOptions.Size = New System.Drawing.Size(190, 88)
        Me.RenderSaveOptions.TabIndex = 8
        Me.RenderSaveOptions.TabStop = False
        Me.RenderSaveOptions.Text = "Save Options"
        '
        'RenderPlayerTimecode
        '
        Me.RenderPlayerTimecode.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RenderPlayerTimecode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RenderPlayerTimecode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenderPlayerTimecode.ForeColor = System.Drawing.Color.White
        Me.RenderPlayerTimecode.Location = New System.Drawing.Point(69, 14)
        Me.RenderPlayerTimecode.Name = "RenderPlayerTimecode"
        Me.RenderPlayerTimecode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RenderPlayerTimecode.Size = New System.Drawing.Size(53, 15)
        Me.RenderPlayerTimecode.TabIndex = 4
        Me.RenderPlayerTimecode.Text = "00:00.00"
        Me.RenderPlayerTimecode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RenderTotalTimeLabel
        '
        Me.RenderTotalTimeLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RenderTotalTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RenderTotalTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenderTotalTimeLabel.ForeColor = System.Drawing.Color.White
        Me.RenderTotalTimeLabel.Location = New System.Drawing.Point(68, 39)
        Me.RenderTotalTimeLabel.Name = "RenderTotalTimeLabel"
        Me.RenderTotalTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RenderTotalTimeLabel.Size = New System.Drawing.Size(53, 15)
        Me.RenderTotalTimeLabel.TabIndex = 3
        Me.RenderTotalTimeLabel.Text = "00:00.00"
        Me.RenderTotalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RenderOutTimeLabel
        '
        Me.RenderOutTimeLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RenderOutTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RenderOutTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenderOutTimeLabel.ForeColor = System.Drawing.Color.White
        Me.RenderOutTimeLabel.Location = New System.Drawing.Point(131, 14)
        Me.RenderOutTimeLabel.Name = "RenderOutTimeLabel"
        Me.RenderOutTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RenderOutTimeLabel.Size = New System.Drawing.Size(53, 15)
        Me.RenderOutTimeLabel.TabIndex = 2
        Me.RenderOutTimeLabel.Text = "00:00.00"
        Me.RenderOutTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RenderInTimeLabel
        '
        Me.RenderInTimeLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RenderInTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RenderInTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenderInTimeLabel.ForeColor = System.Drawing.Color.White
        Me.RenderInTimeLabel.Location = New System.Drawing.Point(6, 14)
        Me.RenderInTimeLabel.Name = "RenderInTimeLabel"
        Me.RenderInTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RenderInTimeLabel.Size = New System.Drawing.Size(53, 15)
        Me.RenderInTimeLabel.TabIndex = 1
        Me.RenderInTimeLabel.Text = "00:00.00"
        Me.RenderInTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RenderSaveAsBTN
        '
        Me.RenderSaveAsBTN.Location = New System.Drawing.Point(55, 57)
        Me.RenderSaveAsBTN.Name = "RenderSaveAsBTN"
        Me.RenderSaveAsBTN.Size = New System.Drawing.Size(75, 23)
        Me.RenderSaveAsBTN.TabIndex = 0
        Me.RenderSaveAsBTN.TabStop = False
        Me.RenderSaveAsBTN.Text = "Save As"
        Me.RenderSaveAsBTN.UseVisualStyleBackColor = True
        '
        'FFmpegOutput
        '
        Me.FFmpegOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FFmpegOutput.Location = New System.Drawing.Point(13, 190)
        Me.FFmpegOutput.Name = "FFmpegOutput"
        Me.FFmpegOutput.Size = New System.Drawing.Size(260, 88)
        Me.FFmpegOutput.TabIndex = 0
        Me.FFmpegOutput.TabStop = False
        Me.FFmpegOutput.Text = ""
        '
        'RenderOutTimeGraphic
        '
        Me.RenderOutTimeGraphic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RenderOutTimeGraphic.AutoSize = True
        Me.RenderOutTimeGraphic.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.RenderOutTimeGraphic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenderOutTimeGraphic.ForeColor = System.Drawing.Color.Red
        Me.RenderOutTimeGraphic.Location = New System.Drawing.Point(441, 180)
        Me.RenderOutTimeGraphic.Name = "RenderOutTimeGraphic"
        Me.RenderOutTimeGraphic.Size = New System.Drawing.Size(15, 20)
        Me.RenderOutTimeGraphic.TabIndex = 13
        Me.RenderOutTimeGraphic.Text = "|"
        '
        'RenderInTimeGraphic
        '
        Me.RenderInTimeGraphic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RenderInTimeGraphic.AutoSize = True
        Me.RenderInTimeGraphic.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.RenderInTimeGraphic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenderInTimeGraphic.ForeColor = System.Drawing.Color.Lime
        Me.RenderInTimeGraphic.Location = New System.Drawing.Point(19, 180)
        Me.RenderInTimeGraphic.Name = "RenderInTimeGraphic"
        Me.RenderInTimeGraphic.Size = New System.Drawing.Size(15, 20)
        Me.RenderInTimeGraphic.TabIndex = 12
        Me.RenderInTimeGraphic.Text = "|"
        '
        'RenderTimeline
        '
        Me.RenderTimeline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RenderTimeline.AutoSize = False
        Me.RenderTimeline.BackColor = System.Drawing.Color.DimGray
        Me.RenderTimeline.Location = New System.Drawing.Point(13, 160)
        Me.RenderTimeline.Name = "RenderTimeline"
        Me.RenderTimeline.Size = New System.Drawing.Size(449, 34)
        Me.RenderTimeline.TabIndex = 11
        Me.RenderTimeline.TabStop = False
        '
        'DurationProgressBar
        '
        Me.DurationProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DurationProgressBar.BackColor = System.Drawing.Color.DimGray
        Me.DurationProgressBar.Location = New System.Drawing.Point(74, 281)
        Me.DurationProgressBar.MarqueeAnimationSpeed = 10
        Me.DurationProgressBar.Name = "DurationProgressBar"
        Me.DurationProgressBar.Size = New System.Drawing.Size(337, 13)
        Me.DurationProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.DurationProgressBar.TabIndex = 4
        '
        'ThreadsRunningLabel
        '
        Me.ThreadsRunningLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ThreadsRunningLabel.AutoSize = True
        Me.ThreadsRunningLabel.Location = New System.Drawing.Point(12, 282)
        Me.ThreadsRunningLabel.Name = "ThreadsRunningLabel"
        Me.ThreadsRunningLabel.Size = New System.Drawing.Size(65, 13)
        Me.ThreadsRunningLabel.TabIndex = 10
        Me.ThreadsRunningLabel.Text = "0 Running   "
        '
        'RenderFileProgress
        '
        Me.RenderFileProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RenderFileProgress.AutoSize = True
        Me.RenderFileProgress.Location = New System.Drawing.Point(416, 281)
        Me.RenderFileProgress.Name = "RenderFileProgress"
        Me.RenderFileProgress.Size = New System.Drawing.Size(24, 13)
        Me.RenderFileProgress.TabIndex = 9
        Me.RenderFileProgress.Text = "0/0"
        '
        'CloseGroupboxRender
        '
        Me.CloseGroupboxRender.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseGroupboxRender.AutoSize = True
        Me.CloseGroupboxRender.BackColor = System.Drawing.Color.Red
        Me.CloseGroupboxRender.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseGroupboxRender.Location = New System.Drawing.Point(461, 7)
        Me.CloseGroupboxRender.Name = "CloseGroupboxRender"
        Me.CloseGroupboxRender.Size = New System.Drawing.Size(11, 12)
        Me.CloseGroupboxRender.TabIndex = 2
        Me.CloseGroupboxRender.Text = "X"
        '
        'TxtBx_Path
        '
        Me.TxtBx_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBx_Path.Location = New System.Drawing.Point(811, 517)
        Me.TxtBx_Path.Multiline = True
        Me.TxtBx_Path.Name = "TxtBx_Path"
        Me.TxtBx_Path.Size = New System.Drawing.Size(250, 112)
        Me.TxtBx_Path.TabIndex = 5
        Me.TxtBx_Path.TabStop = False
        Me.TxtBx_Path.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CurrentTimeList)
        Me.GroupBox1.Controls.Add(Me.ClipSelectUP)
        Me.GroupBox1.Controls.Add(Me.ClipSelectDOWN)
        Me.GroupBox1.Controls.Add(Me.SettingsBTN)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 87)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(1084, 572)
        Me.Controls.Add(Me.TxtBx_Path)
        Me.Controls.Add(Me.GroupBoxRENDER)
        Me.Controls.Add(Me.GroupBoxCONTROLS)
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
        Me.GroupBoxSettings.ResumeLayout(False)
        Me.GroupBoxSettings.PerformLayout()
        Me.GroupBoxControlsWindow.ResumeLayout(False)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlayerMediaInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxEXPLORER.ResumeLayout(False)
        Me.PREVIEWBox.ResumeLayout(False)
        CType(Me.PlayerPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxRENDER.ResumeLayout(False)
        Me.GroupBoxRENDER.PerformLayout()
        CType(Me.PlayerRender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RenderSaveOptions.ResumeLayout(False)
        CType(Me.RenderTimeline, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PlayerLeft As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents PlayerRight As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Tv_Explorer As TreeView
    Friend WithEvents Tv_ImgList As ImageList
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents GroupBoxCONTROLS As GroupBox
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
    Friend WithEvents GroupBoxControlsWindow As GroupBox
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
    Friend WithEvents ClipSelectDOWN As Button
    Friend WithEvents ClipSelectUP As Button
    Friend WithEvents CurrentTimeList As ListBox
    Friend WithEvents RenderBTN As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBoxRENDER As GroupBox
    Friend WithEvents FFmpegOutput As RichTextBox
    Friend WithEvents PlayerRender As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents CloseGroupboxRender As Label
    Friend WithEvents VideoRendering As Label
    Friend WithEvents DurationProgressBar As ProgressBar
    Friend WithEvents SettingsBTN As Button
    Friend WithEvents RenderSaveOptions As GroupBox
    Friend WithEvents GroupBoxSettings As GroupBox
    Friend WithEvents CloseGroupboxSettings As Label
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents TxtBx_Path As TextBox
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RenderSaveAsBTN As Button
    Friend WithEvents RenderQuality As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents RenderFileProgress As Label
    Friend WithEvents ThreadsRunningLabel As Label
    Friend WithEvents MirrorLREnable As CheckBox
    Friend WithEvents FilpLREnable As CheckBox
    Friend WithEvents RenderOutTimeLabel As Label
    Friend WithEvents RenderInTimeLabel As Label
    Friend WithEvents RenderTimeline As TrackBar
    Friend WithEvents RenderTotalTimeLabel As Label
    Friend WithEvents RenderOutTimeGraphic As Label
    Friend WithEvents RenderInTimeGraphic As Label
    Friend WithEvents RenderPlayerTimecode As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
