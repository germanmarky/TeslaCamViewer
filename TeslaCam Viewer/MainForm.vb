Imports System.IO
Imports AxWMPLib

Public Class MainForm
    Dim FolderLocation As String
    Dim FolderViewing As Boolean
    Dim LastFolderFile As Boolean
    Dim WindowLocation11 As Point
    Dim WindowLocation21 As Point
    Dim WindowLocation12 As Point
    Dim WindowLocation22 As Point
    Dim WindowLocation13 As Point
    Dim WindowLocation23 As Point

    Dim OLDgbLOCATION As Point

    Dim MoveGBExplorer As Boolean
    Dim MoveGBControls As Boolean
    Dim MoveGBFront As Boolean
    Dim MoveGBLeftRepeater As Boolean
    Dim MoveGBRightRepeater As Boolean

    Dim CurrentVersion As String = Application.ProductVersion
    Dim FullCenterCameraName = ""

    Public SelectedNumberOfVideos As Integer = 0
    Dim MoveRenderOut As Boolean = False
    Dim MoveRenderIn As Boolean = False
    Dim RenderOutputFile As String
    Dim RenderFileCount As Integer = 0
    Dim RenderFileCountNotDone As Integer = 0
    Delegate Sub UpdateTextBoxDelg(text As String)
    Public myDelegate As UpdateTextBoxDelg = New UpdateTextBoxDelg(AddressOf UpdateTextBox)
    Dim RenderFirstPlay As Boolean = False
    Dim RenderVideoLastPos As Double = 0
    Dim RenderInTime As Integer = 0
    Dim RenderOutTime As Integer = 0
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.Text = Me.Text & CurrentVersion '& " Beta"

        RenderQuality.SelectedIndex = 0
        If My.Computer.Keyboard.ShiftKeyDown = True Then
            My.Settings.Reset()
        End If


        Select Case My.Settings.RenderSelection
            Case 0
                RadioButton1.Checked = True
            Case 1
                RadioButton2.Checked = True
            Case 2
                RadioButton3.Checked = True
            Case 3
                RadioButton4.Checked = True
            Case 4
                RadioButton5.Checked = True
        End Select


        RenderQuality.SelectedIndex = My.Settings.RenderQuality
        FilpLREnable.Checked = My.Settings.FlipLR
        MirrorLREnable.Checked = My.Settings.MirrorLR





        Dim MainToolTip As New Windows.Forms.ToolTip
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/NateMccomb/TeslaCamViewer/master/Version")
            Dim response As System.Net.HttpWebResponse = request.GetResponse

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)

            Dim NewestVersion As String = sr.ReadToEnd


            If NewestVersion.Contains(CurrentVersion) Then
                UPDATELabel.Text = "You are up to date"
                MainToolTip.SetToolTip(UPDATELabel, "You are up to date with Version: " & CurrentVersion)
            Else
                UPDATELabel.Text = "There's a new version available: " & NewestVersion
                MainToolTip.SetToolTip(UPDATELabel, "Click here to download the newest version: " & NewestVersion)
                UPDATELabel.BackColor = Color.BlueViolet
            End If
        Catch ex As Exception
            UPDATELabel.Text = UPDATELabel.Text & " --No Internet Access-- "
            MainToolTip.SetToolTip(UPDATELabel, "Unable to check for new updates.")
        End Try
        RESIZEgb()

        MainToolTip.SetToolTip(Tv_Explorer, "F5-Refresh, Right click - To open file/folder or change Custom Folder, address must contain 'TeslaCam'")

        MainToolTip.SetToolTip(GroupBoxEXPLORER, "Click to move to new location")
        MainToolTip.SetToolTip(GroupBoxCONTROLS, "Click to move to new location")
        MainToolTip.SetToolTip(GroupBoxLEFTREPEATER, "Click to move to new location")
        MainToolTip.SetToolTip(GroupBoxFRONT, "Click to move to new location")
        MainToolTip.SetToolTip(GroupBoxRIGHTREPEATER, "Click to move to new location")

        MainToolTip.SetToolTip(Donation, "Thanks!")


        MainToolTip.SetToolTip(TrackBar1, "Jump Back/Forward '<' / '>', Frame Back/Forward 'M' '/'")
        MainToolTip.SetToolTip(TrackBar2, "Speed - '+' / '-'")
        MainToolTip.SetToolTip(BtnPLAY, "Play/Pause - 'Spacebar' / 'P'")
        MainToolTip.SetToolTip(BtnPAUSE, "Play/Pause - Spacebar / 'P'")
        MainToolTip.SetToolTip(BtnREVERSE, "Reverse - 'R' & Stop - 'S'")
        MainToolTip.SetToolTip(PlayerCenter, "Right click for Fullscreen")
        MainToolTip.SetToolTip(PlayerLeft, "Right click for Fullscreen")
        MainToolTip.SetToolTip(PlayerRight, "Right click for Fullscreen")
        MainToolTip.SetToolTip(RenderFileProgress, "Processing number of files")
        MainToolTip.SetToolTip(ThreadsRunningLabel, "Number of threads running")
        MainToolTip.SetToolTip(RenderPlayerTimecode, "Current Timecode")
        MainToolTip.SetToolTip(RenderInTimeLabel, "Save As Start Point" & vbCrLf & "Right click to set at current timecode")
        MainToolTip.SetToolTip(RenderOutTimeLabel, "Save As End Point" & vbCrLf & "Right click to set at current timecode")
        MainToolTip.SetToolTip(RenderTotalTimeLabel, "Save As File Length")
        MainToolTip.SetToolTip(RenderInTimeGraphic, "In Point Marker" & vbCrLf & "Right click to enable move / set timecode position")
        MainToolTip.SetToolTip(RenderOutTimeGraphic, "Out Point Marker" & vbCrLf & "Right click to enable move / set timecode position")
        MainToolTip.SetToolTip(FFmpegOutput, "FFmpeg Output Console Window")


        MainToolTip.Active = True



        Me.Size = New Size(1100, 600)
        Me.MinimumSize = Me.Size
        Tv_ImgList.ImageSize = New Size(20, 20)
        GroupBoxRENDER.Size = New Size(Me.Width - 60, Me.Height - 50 - 30)
        GroupBoxRENDER.Location = New Point(25, 25)
        Tv_Explorer.ImageList = Tv_ImgList
        Tv_Explorer.HideSelection = False

        RefreshRootNodes()

        PlayerCenter.uiMode = "none"
        PlayerLeft.uiMode = "none"
        PlayerRight.uiMode = "none"
        PlayerPreview.uiMode = "none"
        PlayerRender.uiMode = "none"

        PlayerCenter.Ctlenabled = False
        PlayerLeft.Ctlenabled = False
        PlayerRight.Ctlenabled = False
        PlayerPreview.Ctlenabled = False
        PlayerRender.Ctlenabled = False

        TrackBar1.Minimum = 0


    End Sub
    Private Sub RefreshRootNodes()
        Tv_Explorer.Nodes.Clear()
        If My.Settings.CustomDIR <> "" Then
            UpdateCustomFolder(My.Settings.CustomDIR)
        Else
            UpdateCustomFolder("Custom Folder")
        End If

        AddSpecialAndStandardFolderImages()

        AddSpecialFolderRootNode(SpecialNodeFolders.Desktop)
        AddSpecialFolderRootNode(SpecialNodeFolders.MyDocuments)
        AddSpecialFolderRootNode(SpecialNodeFolders.MyPictures)
        AddSpecialFolderRootNode(SpecialNodeFolders.Recent)


        AddDriveRootNodes()
    End Sub
    Private Sub TV_Explorer_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles Tv_Explorer.BeforeExpand
        Dim DrvIsReady As Boolean = (From d As DriveInfo In DriveInfo.GetDrives Where d.Name = e.Node.ImageKey Select d.IsReady).FirstOrDefault

        If (Not e.Node.ImageKey.Contains(":\")) OrElse DrvIsReady OrElse Directory.Exists(e.Node.ImageKey) Then
            e.Node.Nodes.Clear()
            AddChildNodes(e.Node, e.Node.Tag.ToString)
        Else
            e.Cancel = True
            MessageBox.Show("The CD or DVD drive is empty.", "Drive Info...", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TV_Explorer_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles Tv_Explorer.AfterCollapse
        e.Node.Nodes.Clear()
        e.Node.Nodes.Add("Empty")
    End Sub


    Private Sub TV_Explorer_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tv_Explorer.AfterSelect
        FullCenterCameraName = e.Node.Tag.ToString
        CurrentTimeList.Enabled = False
        CurrentTimeList.Items.Clear()
        Try
            Dim DIRLocation As String = FullCenterCameraName

            If DIRLocation.Contains(".mp4") Then
                DIRLocation = DIRLocation.Remove(DIRLocation.LastIndexOf("\"))
            End If

            Dim DirInfo As New DirectoryInfo(DIRLocation)

            For Each fi As FileInfo In DirInfo.GetFiles.OrderByDescending(Function(p) p.Name).ToArray()
                If Not (fi.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                    Dim fiTime As String = fi.Name.Remove(fi.Name.LastIndexOf("-"), fi.Name.Length - fi.Name.LastIndexOf("-"))
                    fiTime = fiTime.Remove(0, fiTime.IndexOf("_") + 1)

                    If Not CurrentTimeList.Items.Contains(fiTime.Replace("-", ":")) Then
                        CurrentTimeList.Items.Add(fiTime.Replace("-", ":"))

                    End If
                End If
            Next

        Catch ex As Exception

        End Try

        If e.Node.ImageKey.ToString() <> "Folder" Then
            Dim FileGroup As String
            FolderViewing = False
            Try
                If FullCenterCameraName.Contains("recent-front") Or FullCenterCameraName.Contains("saved-front") Then
                    PlayersSTOP()
                    PlayerCenter.URL = FullCenterCameraName
                    PlayerCenter.settings.setMode("loop", True)
                    PlayerLeft.settings.setMode("loop", False)
                    PlayerRight.settings.setMode("loop", False)
                Else
                    FileGroup = FullCenterCameraName.Remove(FullCenterCameraName.LastIndexOf("-"))
                    PlayersSTOP()
                    PlayerCenter.URL = (FileGroup & "-front.mp4")
                    PlayerLeft.URL = (FileGroup & "-left_repeater.mp4")
                    PlayerRight.URL = (FileGroup & "-right_repeater.mp4")
                    'Tv_Explorer.
                    PlayerCenter.settings.setMode("loop", True)
                    PlayerLeft.settings.setMode("loop", True)
                    PlayerRight.settings.setMode("loop", True)
                    FullCenterCameraName = (FileGroup & "-front.mp4")
                    UpdatePlayBackSpeed()
                End If
                PREVIEWBox.Visible = False

            Catch ex As Exception

            End Try
        Else
            Try
                FolderViewing = True
                PlayersSTOP()
                PlayerCenter.settings.setMode("loop", False)
                PlayerLeft.settings.setMode("loop", False)
                PlayerRight.settings.setMode("loop", False)

                Dim di As New IO.DirectoryInfo(FullCenterCameraName)
                Dim fis = di.GetFiles("*front.mp4").OrderByDescending(Function(p) p.Name).ToArray() '(Function(fi) fi.Name.Contains("front")).ToArray()
                Dim a = fis.GetValue(0)

                Dim FileGroup As String

                FileGroup = a.Fullname.ToString.Remove(a.Fullname.ToString.LastIndexOf("-"))

                PlayerMediaInfo.URL = (FileGroup & "-front.mp4")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub AddSpecialFolderRootNode(SpecialFolder As SpecialNodeFolders)
        Dim SpecialFolderPath As String = Environment.GetFolderPath(CType(SpecialFolder, Environment.SpecialFolder))
        Dim SpecialFolderName As String = Path.GetFileName(SpecialFolderPath)

        AddImageToImgList(SpecialFolderPath, SpecialFolderName)

        Dim DesktopNode As New TreeNode(SpecialFolderName)
        With DesktopNode
            .Tag = SpecialFolderPath
            .ImageKey = SpecialFolderName
            .SelectedImageKey = SpecialFolderName
            .Nodes.Add("Empty")
        End With

        Tv_Explorer.Nodes.Add(DesktopNode)
    End Sub

    Private Sub AddDriveRootNodes()
        For Each drv As DriveInfo In DriveInfo.GetDrives
            AddImageToImgList(drv.Name)
            Dim DriveNode As New TreeNode(drv.Name)
            With DriveNode
                .Tag = drv.Name
                .ImageKey = drv.Name
                .SelectedImageKey = drv.Name
                .Nodes.Add("Empty")
            End With
            Tv_Explorer.Nodes.Add(DriveNode)
        Next
    End Sub

    Private Sub AddCustomFolderRootNode(folderpath As String)
        If Directory.Exists(folderpath) Then
            Dim FolderName As String = New DirectoryInfo(folderpath).Name
            AddImageToImgList(folderpath)
            Dim rootNode As New TreeNode(FolderName)
            With rootNode
                .Tag = folderpath
                .ImageKey = folderpath
                .SelectedImageKey = folderpath
                If Directory.GetDirectories(folderpath).Count > 0 OrElse Directory.GetFiles(folderpath).Count > 0 Then
                    .Nodes.Add("Empty")
                End If
            End With
            Tv_Explorer.Nodes.Add(rootNode) 'add this root node to the treeview
        End If
    End Sub

    Private Sub AddChildNodes(tn As TreeNode, DirPath As String)
        Dim DirInfo As New DirectoryInfo(DirPath)
        Try
            For Each di As DirectoryInfo In DirInfo.GetDirectories.OrderByDescending(Function(p) p.Name).ToArray()
                If Not (di.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                    If di.FullName.ToString.Contains("TeslaCam") Then

                        Dim FolderNode As New TreeNode(di.Name)
                        With FolderNode
                            .Tag = di.FullName
                            If Tv_ImgList.Images.Keys.Contains(di.FullName) Then
                                .ImageKey = di.FullName
                                .SelectedImageKey = di.FullName
                            Else
                                .ImageKey = "Folder"
                                .SelectedImageKey = "Folder"
                            End If
                            .Nodes.Add("*Empty*")
                        End With
                        tn.Nodes.Add(FolderNode)

                    End If
                End If

            Next
            If DirInfo.FullName.Contains("\Microsoft\Windows\Recent") Then
                For Each fi As FileInfo In DirInfo.GetFiles.OrderByDescending(Function(p) p.LastAccessTime).ToArray()
                    If Not (fi.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                        Dim ImgKey As String = AddImageToImgList(fi.FullName)
                        Dim FileNode As New TreeNode(fi.Name)
                        With FileNode
                            .Tag = fi.FullName
                            .ImageKey = ImgKey
                            .SelectedImageKey = ImgKey
                        End With
                        tn.Nodes.Add(FileNode)
                    End If
                Next
            Else
                For Each fi As FileInfo In DirInfo.GetFiles.OrderByDescending(Function(p) p.Name).ToArray()
                    If Not (fi.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                        Dim ImgKey As String = AddImageToImgList(fi.FullName)
                        Dim FileNode As New TreeNode(fi.Name)
                        With FileNode
                            .Tag = fi.FullName
                            .ImageKey = ImgKey
                            .SelectedImageKey = ImgKey
                        End With
                        tn.Nodes.Add(FileNode)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddSpecialAndStandardFolderImages()
        AddImageToImgList(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Folder")

        Dim SpecialFolders As New List(Of Environment.SpecialFolder)
        With SpecialFolders
            .Add(Environment.SpecialFolder.Desktop)
            .Add(Environment.SpecialFolder.MyDocuments)
            .Add(Environment.SpecialFolder.Favorites)
            .Add(Environment.SpecialFolder.Recent)
            .Add(Environment.SpecialFolder.MyMusic)
            .Add(Environment.SpecialFolder.History)
            .Add(Environment.SpecialFolder.MyPictures)
            .Add(Environment.SpecialFolder.Personal)
        End With

        For Each sf As Environment.SpecialFolder In SpecialFolders
            AddImageToImgList(Environment.GetFolderPath(sf))
        Next
    End Sub

    Private Function AddImageToImgList(FullFilePath As String, Optional SpecialImageKeyName As String = "") As String
        Dim ImgKey As String = If(SpecialImageKeyName = "", FullFilePath, SpecialImageKeyName)
        Dim LoadFromExt As Boolean = False

        If ImgKey = FullFilePath AndAlso File.Exists(FullFilePath) Then
            Dim ext As String = Path.GetExtension(FullFilePath).ToLower
            If ext <> "" AndAlso ext <> ".exe" AndAlso ext <> ".lnk" AndAlso ext <> ".url" Then
                ImgKey = Path.GetExtension(FullFilePath).ToLower
                LoadFromExt = True
            End If
        End If

        If Not Tv_ImgList.Images.Keys.Contains(ImgKey) Then
            Tv_ImgList.Images.Add(ImgKey, Iconhelper.GetIconImage(If(LoadFromExt, ImgKey, FullFilePath), IconSizes.Large32x32))
        End If

        Return ImgKey
    End Function

    Private Enum SpecialNodeFolders As Integer

        Desktop = Environment.SpecialFolder.Desktop
        Favorites = Environment.SpecialFolder.Favorites
        History = Environment.SpecialFolder.History
        MyDocuments = Environment.SpecialFolder.MyDocuments
        MyMusic = Environment.SpecialFolder.MyMusic
        MyPictures = Environment.SpecialFolder.MyPictures
        Recent = Environment.SpecialFolder.Recent
        UserProfile = Environment.SpecialFolder.Personal
    End Enum

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        TrackBar1.Maximum = PlayerCenter.currentMedia.duration
    End Sub

    Private Sub RefreshPlayers()
        If PlayerLeft.playState = WMPLib.WMPPlayState.wmppsPaused Then
            PlayerLeft.Ctlcontrols.play()
            PlayerLeft.Ctlcontrols.pause()
        End If
        If PlayerCenter.playState = WMPLib.WMPPlayState.wmppsPaused Then
            PlayerCenter.Ctlcontrols.play()
            PlayerCenter.Ctlcontrols.pause()
        End If
        If PlayerRight.playState = WMPLib.WMPPlayState.wmppsPaused Then
            PlayerRight.Ctlcontrols.play()
            PlayerRight.Ctlcontrols.pause()
        End If
    End Sub
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

        PlayerCenter.Ctlcontrols.currentPosition = TrackBar1.Value
        PlayerLeft.Ctlcontrols.currentPosition = TrackBar1.Value
        PlayerRight.Ctlcontrols.currentPosition = TrackBar1.Value
        RefreshPlayers()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If Int(PlayerCenter.currentMedia.duration) <> 0 Then
                TCLabelMax.Text = Int(PlayerCenter.currentMedia.duration)
                TrackBar1.Maximum = Int(PlayerCenter.currentMedia.duration)
                TrackBar1.Value = Int(PlayerCenter.Ctlcontrols.currentPosition)
                Label5.Text = "Time Code (Seconds) - " & Int(PlayerCenter.Ctlcontrols.currentPosition)
                TCLabelMin.Text = "0"

            ElseIf Int(PlayerRight.currentMedia.duration) <> 0 Then
                TCLabelMax.Text = Int(PlayerRight.currentMedia.duration)
                TrackBar1.Maximum = Int(PlayerRight.currentMedia.duration)
                TrackBar1.Value = Int(PlayerRight.Ctlcontrols.currentPosition)
                Label5.Text = "Time Code (Seconds) - " & Int(PlayerRight.Ctlcontrols.currentPosition)
                TCLabelMin.Text = "0"

            ElseIf Int(PlayerLeft.currentMedia.duration) <> 0 Then
                TCLabelMax.Text = Int(PlayerLeft.currentMedia.duration)
                TrackBar1.Maximum = Int(PlayerLeft.currentMedia.duration)
                TrackBar1.Value = Int(PlayerLeft.Ctlcontrols.currentPosition)
                Label5.Text = "Time Code (Seconds) - " & Int(PlayerLeft.Ctlcontrols.currentPosition)
                TCLabelMin.Text = "0"
            End If

            If Int(PlayerRender.currentMedia.duration) <> 0 Then
                RenderTimeline.Value = Int(PlayerRender.Ctlcontrols.currentPosition * 10)
            End If

        Catch ex As Exception

        End Try
        Try
            If PlayerCenter.playState = WMPLib.WMPPlayState.wmppsStopped Then
                If FolderViewing = True Then ' And LastFolderFile = False
                    LastFolderFile = True
                    PlayersSTOP()
                    If CurrentTimeList.SelectedIndex > 0 Then
                        Dim LastIndex As Integer = CurrentTimeList.SelectedIndex
                        CurrentTimeList.SelectedIndices.Clear()
                        CurrentTimeList.SelectedIndex = LastIndex - 1
                    Else
                        CurrentTimeList.SelectedIndices.Clear()
                        CurrentTimeList.SelectedIndex = CurrentTimeList.Items.Count - 1
                    End If
                    PlayersPLAY()
                    UpdatePlayBackSpeed()
                End If
            End If
        Catch ex As Exception

        End Try

        If CurrentTimeList.SelectedIndex > 0 Then
            ClipSelectUP.Enabled = True
        Else
            ClipSelectUP.Enabled = False
        End If
        If CurrentTimeList.SelectedIndex < CurrentTimeList.Items.Count - 1 Then
            ClipSelectDOWN.Enabled = True
        Else
            ClipSelectDOWN.Enabled = False
        End If

        If GroupBoxRENDER.Visible = True Then
            Dim StartMin As Integer = 0
            Dim StartSec As Double = 0
            Dim TotalTimeMin As Double = 0
            Dim TotalTimeSec As Double = 0
            Dim EndMin As Integer = 0
            Dim EndSec As Double = 0
            Dim PlayerMin As Double = 0
            Dim playerSec As Double = 0

            If RenderInTime > 599 Then
                Dim TempTime As Integer = RenderInTime
                For i = 1 To RenderInTime / 600
                    StartMin += 1
                    TempTime -= 600
                Next
                StartSec = TempTime / 10
            Else
                'StartMin = 0
                StartSec = RenderInTime / 10
            End If
            If RenderOutTime > 599 Then
                Dim TempTime As Integer = RenderOutTime
                For i = 1 To RenderOutTime / 600
                    EndMin += 1
                    TempTime -= 600
                Next
                EndSec = TempTime / 10
            Else
                'EndMin = 0
                EndSec = RenderOutTime / 10
            End If
            TotalTimeMin = EndMin - StartMin
            TotalTimeSec = EndSec - StartSec
            If TotalTimeSec < 0 Then
                TotalTimeMin -= 1
                TotalTimeSec = Math.Abs(EndSec)
            End If
            RenderInTimeLabel.Text = StartMin.ToString("00") & ":" & StartSec.ToString("00.00")
            RenderOutTimeLabel.Text = EndMin.ToString("00") & ":" & EndSec.ToString("00.00")
            RenderTotalTimeLabel.Text = TotalTimeMin.ToString("00") & ":" & TotalTimeSec.ToString("00.00")
            If PlayerRender.Ctlcontrols.currentPosition > 59.9 Then
                Dim TempTime As Integer = PlayerRender.Ctlcontrols.currentPosition
                For i = 1 To TempTime / 60
                    PlayerMin += 1
                    TempTime -= 60
                Next
                playerSec = TempTime
            Else
                'StartMin = 0
                playerSec = PlayerRender.Ctlcontrols.currentPosition
            End If
            RenderPlayerTimecode.Text = PlayerMin.ToString("00") & ":" & playerSec.ToString("00.00")
        End If

    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        UpdatePlayBackSpeed()

    End Sub
    Private Sub UpdatePlayBackSpeed()
        PlayerCenter.settings.rate = 0.1 * TrackBar2.Value
        PlayerLeft.settings.rate = 0.1 * TrackBar2.Value
        PlayerRight.settings.rate = 0.1 * TrackBar2.Value

    End Sub


    Private Sub PlayerLeft_OpenStateChange(sender As Object, e As _WMPOCXEvents_OpenStateChangeEvent) Handles PlayerLeft.OpenStateChange
        If PlayerLeft.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            If PlayerCenter.currentMedia.duration Or PlayerRight.currentMedia.duration <= PlayerLeft.currentMedia.duration Then
                TrackBar1.Maximum = PlayerLeft.currentMedia.duration
                TCLabelMax.Text = TrackBar1.Maximum
            End If
        End If
    End Sub

    Private Sub PlayerRight_OpenStateChange(sender As Object, e As _WMPOCXEvents_OpenStateChangeEvent) Handles PlayerRight.OpenStateChange
        If PlayerRight.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            If PlayerCenter.currentMedia.duration Or PlayerLeft.currentMedia.duration <= PlayerRight.currentMedia.duration Then
                TrackBar1.Maximum = PlayerRight.currentMedia.duration
                TCLabelMax.Text = TrackBar1.Maximum

            End If
        End If
    End Sub

    Private Sub PlayerCenter_OpenStateChange(sender As Object, e As _WMPOCXEvents_OpenStateChangeEvent) Handles PlayerCenter.OpenStateChange
        Try
            If PlayerCenter.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                If PlayerLeft.currentMedia.duration Or PlayerRight.currentMedia.duration <= PlayerCenter.currentMedia.duration Then
                    TrackBar1.Maximum = PlayerCenter.currentMedia.duration
                    TCLabelMax.Text = TrackBar1.Maximum
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub MediaInfo_OpenStateChange(sender As Object, e As _WMPOCXEvents_OpenStateChangeEvent) Handles PlayerMediaInfo.OpenStateChange
        Try
            If PlayerMediaInfo.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                Dim di As New IO.DirectoryInfo(FullCenterCameraName)
                Dim fis = di.GetFiles("*front.mp4").OrderByDescending(Function(p) p.Name).ToArray()
                Dim a = fis.GetValue(0)
                If fis.Length > 1 Then
                    a = fis.GetValue(1)
                End If

                Dim FileGroup As String

                FullCenterCameraName = a.Fullname.ToString
                FileGroup = FullCenterCameraName.Remove(FullCenterCameraName.LastIndexOf("-"))
                PlayersSTOP()
                PlayerCenter.URL = (FileGroup & "-front.mp4")
                PlayerLeft.URL = (FileGroup & "-left_repeater.mp4")
                PlayerRight.URL = (FileGroup & "-right_repeater.mp4")
                PlayerCenter.Ctlcontrols.currentPosition = PlayerMediaInfo.currentMedia.duration - 2
                PlayerLeft.Ctlcontrols.currentPosition = PlayerMediaInfo.currentMedia.duration - 2
                PlayerRight.Ctlcontrols.currentPosition = PlayerMediaInfo.currentMedia.duration - 2
                UpdatePlayBackSpeed()
                PlayerMediaInfo.Ctlcontrols.stop()
                LastFolderFile = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PlayerLeft_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles PlayerLeft.PlayStateChange
        If PlayerLeft.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            GroupBoxLEFTREPEATER.BackColor = Color.Lime
            GroupBoxLEFTREPEATER.Text = "Left Repeater - " & PlayerLeft.URL.ToString.Remove(0, PlayerLeft.URL.ToString.LastIndexOf("\") + 1)
        ElseIf PlayerLeft.playState = WMPLib.WMPPlayState.wmppsStopped Then
            GroupBoxLEFTREPEATER.BackColor = Color.Red
        ElseIf PlayerLeft.playState = WMPLib.WMPPlayState.wmppsScanForward Then
            GroupBoxLEFTREPEATER.BackColor = Color.Blue
        ElseIf PlayerLeft.playState = WMPLib.WMPPlayState.wmppsPaused Then
            GroupBoxLEFTREPEATER.BackColor = Me.BackColor
        ElseIf PlayerLeft.playState = WMPLib.WMPPlayState.wmppsReady Then
            GroupBoxLEFTREPEATER.BackColor = Color.LightGray
        ElseIf PlayerLeft.playState = WMPLib.WMPPlayState.wmppsTransitioning Then
            GroupBoxLEFTREPEATER.BackColor = Color.Gray
        ElseIf PlayerLeft.playState = WMPLib.WMPPlayState.wmppsMediaEnded Then
            GroupBoxLEFTREPEATER.BackColor = Color.LightGreen
        ElseIf PlayerLeft.playState = WMPLib.WMPPlayState.wmppsScanReverse Then
            GroupBoxLEFTREPEATER.BackColor = Color.BlueViolet
        Else
            GroupBoxLEFTREPEATER.BackColor = Color.DarkRed
            GroupBoxLEFTREPEATER.Text = "Left Repeater - " & PlayerLeft.URL.ToString.Remove(0, PlayerLeft.URL.ToString.LastIndexOf("\") + 1) & " - ERROR"
        End If
    End Sub

    Private Sub PlayerRight_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles PlayerRight.PlayStateChange
        If PlayerRight.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            GroupBoxRIGHTREPEATER.BackColor = Color.Lime
            GroupBoxRIGHTREPEATER.Text = "Right Repeater - " & PlayerRight.URL.ToString.Remove(0, PlayerRight.URL.ToString.LastIndexOf("\") + 1)
        ElseIf PlayerRight.playState = WMPLib.WMPPlayState.wmppsStopped Then
            GroupBoxRIGHTREPEATER.BackColor = Color.Red
        ElseIf PlayerRight.playState = WMPLib.WMPPlayState.wmppsScanForward Then
            GroupBoxRIGHTREPEATER.BackColor = Color.Blue
        ElseIf PlayerRight.playState = WMPLib.WMPPlayState.wmppsPaused Then
            GroupBoxRIGHTREPEATER.BackColor = Me.BackColor
        ElseIf PlayerRight.playState = WMPLib.WMPPlayState.wmppsReady Then
            GroupBoxRIGHTREPEATER.BackColor = Color.LightGray
        ElseIf PlayerRight.playState = WMPLib.WMPPlayState.wmppsTransitioning Then
            GroupBoxRIGHTREPEATER.BackColor = Color.Gray
        ElseIf PlayerRight.playState = WMPLib.WMPPlayState.wmppsMediaEnded Then
            GroupBoxRIGHTREPEATER.BackColor = Color.LightGreen
        ElseIf PlayerRight.playState = WMPLib.WMPPlayState.wmppsScanReverse Then
            GroupBoxRIGHTREPEATER.BackColor = Color.BlueViolet

        Else
            GroupBoxRIGHTREPEATER.BackColor = Color.DarkRed
            GroupBoxRIGHTREPEATER.Text = "Right Repeater - " & PlayerRight.URL.ToString.Remove(0, PlayerRight.URL.ToString.LastIndexOf("\") + 1) & " - ERROR"
        End If
    End Sub

    Private Sub PlayerCenter_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles PlayerCenter.PlayStateChange
        If PlayerCenter.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            GroupBoxFRONT.BackColor = Color.Lime
            GroupBoxFRONT.Text = "Center - " & PlayerCenter.URL.ToString.Remove(0, PlayerCenter.URL.ToString.LastIndexOf("\") + 1)
            For Each time In CurrentTimeList.Items
                If PlayerCenter.URL.Remove(0, PlayerCenter.URL.LastIndexOf("\")).Contains("_" & time.ToString.Replace(":", "-")) Then
                    CurrentTimeList.SelectedIndices.Clear()
                    CurrentTimeList.SelectedItem = time.ToString.Replace("-", ":")
                    If CurrentTimeList.SelectedIndex < 3 Then
                        CurrentTimeList.TopIndex = 0
                    Else
                        CurrentTimeList.TopIndex = CurrentTimeList.SelectedIndex - 2
                    End If

                    CurrentTimeList.Enabled = True
                    If Tv_Explorer.Focused = False Then
                        CurrentTimeList.Focus()
                    End If
                End If
            Next
        ElseIf PlayerCenter.playState = WMPLib.WMPPlayState.wmppsStopped Then
            GroupBoxFRONT.BackColor = Color.Red
        ElseIf PlayerCenter.playState = WMPLib.WMPPlayState.wmppsScanForward Then
            GroupBoxFRONT.BackColor = Color.Blue
        ElseIf PlayerCenter.playState = WMPLib.WMPPlayState.wmppsPaused Then
            GroupBoxFRONT.BackColor = Me.BackColor
        ElseIf PlayerCenter.playState = WMPLib.WMPPlayState.wmppsReady Then
            GroupBoxFRONT.BackColor = Color.LightGray
        ElseIf PlayerCenter.playState = WMPLib.WMPPlayState.wmppsTransitioning Then
            GroupBoxFRONT.BackColor = Color.Gray
        ElseIf PlayerCenter.playState = WMPLib.WMPPlayState.wmppsMediaEnded Then
            GroupBoxFRONT.BackColor = Color.LightGreen
        ElseIf PlayerCenter.playState = WMPLib.WMPPlayState.wmppsScanReverse Then
            GroupBoxFRONT.BackColor = Color.BlueViolet
        Else
            GroupBoxFRONT.BackColor = Color.DarkRed
            GroupBoxFRONT.Text = "Center Repeater - " & PlayerCenter.URL.ToString.Remove(0, PlayerCenter.URL.ToString.LastIndexOf("\") + 1) & " - ERROR"
        End If
    End Sub
    Private Sub PlayersPAUSE()
        UpdatePlayBackSpeed()
        PlayerCenter.Ctlcontrols.pause()
        PlayerLeft.Ctlcontrols.pause()
        PlayerRight.Ctlcontrols.pause()

    End Sub
    Private Sub PlayersPLAY()
        If PlayerLeft.playState = WMPLib.WMPPlayState.wmppsPlaying Or PlayerCenter.playState = WMPLib.WMPPlayState.wmppsPlaying Or PlayerRight.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            UpdatePlayBackSpeed()
            PlayerCenter.Ctlcontrols.pause()
            PlayerLeft.Ctlcontrols.pause()
            PlayerRight.Ctlcontrols.pause()
        Else
            PlayerCenter.Ctlcontrols.play()
            PlayerLeft.Ctlcontrols.play()
            PlayerRight.Ctlcontrols.play()
            UpdatePlayBackSpeed()
        End If
    End Sub
    Private Sub PlayersSTOP()
        PlayerCenter.Ctlcontrols.stop()
        PlayerLeft.Ctlcontrols.stop()
        PlayerRight.Ctlcontrols.stop()
    End Sub

    Private Sub PlayerCenter_ClickEvent(sender As Object, e As _WMPOCXEvents_ClickEvent) Handles PlayerCenter.ClickEvent
        If e.nButton = 2 Then
            If PlayerCenter.fullScreen = False Then
                PlayerCenter.fullScreen = True
            Else
                PlayerCenter.fullScreen = False
            End If
        End If
    End Sub

    Private Sub PlayerLeft_ClickEvent(sender As Object, e As _WMPOCXEvents_ClickEvent) Handles PlayerLeft.ClickEvent
        If e.nButton = 2 Then
            If PlayerLeft.fullScreen = False Then
                PlayerLeft.fullScreen = True
            Else
                PlayerLeft.fullScreen = False
            End If
        End If
    End Sub

    Private Sub PlayerRight_ClickEvent(sender As Object, e As _WMPOCXEvents_ClickEvent) Handles PlayerRight.ClickEvent
        If e.nButton = 2 Then
            If PlayerRight.fullScreen = False Then
                PlayerRight.fullScreen = True
            Else
                PlayerRight.fullScreen = False
            End If
        End If
    End Sub

    Public Sub UpdateCustomFolder(folderpath As String)
        If Directory.Exists(folderpath) Or folderpath = "Custom Folder" Then
            Dim FolderName As String = New DirectoryInfo(folderpath).Name
            If folderpath <> "Custom Folder" Then
                AddImageToImgList(folderpath)
            End If
            Dim rootNode As New TreeNode("- " & FolderName & " -")
            Try
                With rootNode
                    .ToolTipText = "Custom Folder - " & folderpath
                    .Tag = folderpath
                    .ImageKey = folderpath
                    .SelectedImageKey = folderpath
                    If Directory.GetDirectories(folderpath).Count > 0 OrElse Directory.GetFiles(folderpath).Count > 0 Then
                        .Nodes.Add("Empty")
                    End If
                End With
            Catch ex As Exception

            End Try

            Try
                Tv_Explorer.Nodes.Item(0).Remove()
            Catch ex As Exception

            End Try

            Tv_Explorer.Nodes.Insert(0, rootNode)
        End If
    End Sub
    Private Sub Tv_Explorer_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Tv_Explorer.NodeMouseClick
        If e.Button = MouseButtons.Right Then
            If (File.Exists(e.Node.Tag.ToString) Or Directory.Exists(e.Node.Tag.ToString)) And e.Node.ToolTipText.Contains("Custom Folder") = False Then
                Try
                    Process.Start(e.Node.Tag.ToString)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf e.Node.ToolTipText.Contains("Custom Folder") Then

                If (CustomFolderBrowserDialog.ShowDialog() = DialogResult.OK) Then
                    Dim folderpath = CustomFolderBrowserDialog.SelectedPath
                    UpdateCustomFolder(folderpath)
                    My.Settings.CustomDIR = folderpath
                End If
            End If

        End If


    End Sub

    Private Sub BtnPLAY_Click(sender As Object, e As EventArgs) Handles BtnPLAY.Click
        PlayersPLAY()
    End Sub

    Private Sub BtnPAUSE_Click(sender As Object, e As EventArgs) Handles BtnPAUSE.Click
        UpdatePlayBackSpeed()
        PlayerCenter.Ctlcontrols.pause()
        PlayerLeft.Ctlcontrols.pause()
        PlayerRight.Ctlcontrols.pause()
        PlayerCenter.Focus()
    End Sub

    Private Sub BtnREVERSE_Click(sender As Object, e As EventArgs) Handles BtnREVERSE.Click
        PlayerCenter.Ctlcontrols.fastReverse()
        PlayerLeft.Ctlcontrols.fastReverse()
        PlayerRight.Ctlcontrols.fastReverse()
    End Sub
    Private Sub RESIZEgb()
        WindowLocation11.X = 0
        WindowLocation11.Y = 0
        WindowLocation12.X = Me.Width / 3 - 2
        WindowLocation12.Y = 0
        WindowLocation13.X = (Me.Width / 3) * 2 - 2
        WindowLocation13.Y = 0

        WindowLocation21.X = 0
        WindowLocation21.Y = (Me.Height - 40) / 2
        WindowLocation22.X = Me.Width / 3 - 2
        WindowLocation22.Y = (Me.Height - 40) / 2
        WindowLocation23.X = (Me.Width / 3) * 2 - 2
        WindowLocation23.Y = (Me.Height - 40) / 2


        GroupBoxLEFTREPEATER.Height = (Me.Height - 40) / 2
        GroupBoxFRONT.Height = (Me.Height - 40) / 2
        GroupBoxRIGHTREPEATER.Height = (Me.Height - 40) / 2

        GroupBoxCONTROLS.Height = (Me.Height - 40) / 2
        GroupBoxEXPLORER.Height = (Me.Height - 40) / 2

        GroupBoxLEFTREPEATER.Width = Me.Width / 3 - 4
        GroupBoxFRONT.Width = Me.Width / 3 - 4
        GroupBoxRIGHTREPEATER.Width = Me.Width / 3 - 4

        GroupBoxCONTROLS.Width = Me.Width / 3 - 4
        GroupBoxEXPLORER.Width = Me.Width / 3 - 4


        If My.Settings.LocationLeftRepeater = 0 Then
            GroupBoxLEFTREPEATER.Location = WindowLocation21
        Else
            GroupBoxLEFTREPEATER.Location = ReturnSavedLocation(My.Settings.LocationLeftRepeater)
        End If
        If My.Settings.LocationFront = 0 Then
            GroupBoxFRONT.Location = WindowLocation12
        Else
            GroupBoxFRONT.Location = ReturnSavedLocation(My.Settings.LocationFront)
        End If
        If My.Settings.LocationRightRepeater = 0 Then
            GroupBoxRIGHTREPEATER.Location = WindowLocation23
        Else
            GroupBoxRIGHTREPEATER.Location = ReturnSavedLocation(My.Settings.LocationRightRepeater)
        End If

        If My.Settings.LocationControls = 0 Then
            GroupBoxCONTROLS.Location = WindowLocation22
        Else
            GroupBoxCONTROLS.Location = ReturnSavedLocation(My.Settings.LocationControls)
        End If
        If My.Settings.LocationExplorer = 0 Then
            GroupBoxEXPLORER.Location = WindowLocation11
        Else
            GroupBoxEXPLORER.Location = ReturnSavedLocation(My.Settings.LocationExplorer)
        End If
        GroupBoxSettings.Size = GroupBoxControlsWindow.Size
        GroupBoxSettings.Location = GroupBoxControlsWindow.Location

        Tv_Explorer.Refresh()

    End Sub
    Private Function ReturnSavedLocation(ByVal SettingNum As Integer)
        Select Case SettingNum
            Case 11
                Return WindowLocation11
            Case 12
                Return WindowLocation12
            Case 13
                Return WindowLocation13
            Case 21
                Return WindowLocation21
            Case 22
                Return WindowLocation22
            Case 23
                Return WindowLocation23
        End Select
        Dim none As Point
        Return none
    End Function

    Private Sub MainForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If GroupBoxRENDER.Visible = False Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Space) Or e.KeyChar = "p" Or e.KeyChar = "P" Then
                If BtnPLAY.Focused = False And BtnPAUSE.Focused = False Then
                    PlayersPLAY()
                End If
                e.Handled = True
            End If
            If e.KeyChar = "," Or e.KeyChar = "<" Then
                If TrackBar1.Value > TrackBar1.Minimum Then
                    PlayerCenter.Ctlcontrols.currentPosition -= 1
                    PlayerLeft.Ctlcontrols.currentPosition -= 1
                    PlayerRight.Ctlcontrols.currentPosition -= 1
                    RefreshPlayers()
                End If
                e.Handled = True
            End If
            If e.KeyChar = "m" Or e.KeyChar = "M" Then
                If TrackBar1.Value > TrackBar1.Minimum Then
                    PlayerCenter.Ctlcontrols.currentPosition -= 1 / 36.02
                    PlayerLeft.Ctlcontrols.currentPosition -= 1 / 36.02
                    PlayerRight.Ctlcontrols.currentPosition -= 1 / 36.02
                    RefreshPlayers()
                End If
                e.Handled = True
            End If
            If e.KeyChar = "." Or e.KeyChar = ">" Then
                If TrackBar1.Value < TrackBar1.Maximum Then
                    PlayerCenter.Ctlcontrols.currentPosition += 1
                    PlayerLeft.Ctlcontrols.currentPosition += 1
                    PlayerRight.Ctlcontrols.currentPosition += 1
                    RefreshPlayers()
                End If
                e.Handled = True
            End If
            If e.KeyChar = "/" Or e.KeyChar = "?" Then
                If TrackBar1.Value < TrackBar1.Maximum Then
                    PlayerCenter.Ctlcontrols.currentPosition += 1 / 36.02
                    PlayerLeft.Ctlcontrols.currentPosition += 1 / 36.02
                    PlayerRight.Ctlcontrols.currentPosition += 1 / 36.02
                    RefreshPlayers()
                End If
                e.Handled = True
            End If
            If e.KeyChar = "-" Or e.KeyChar = "_" Then
                If TrackBar2.Value > TrackBar2.Minimum Then
                    TrackBar2.Value -= 1
                End If
                UpdatePlayBackSpeed()
                e.Handled = True
            End If
            If e.KeyChar = "=" Or e.KeyChar = "+" Then
                If TrackBar2.Value < TrackBar2.Maximum Then
                    TrackBar2.Value += 1
                End If
                UpdatePlayBackSpeed()
                e.Handled = True
            End If
            If e.KeyChar = "s" Or e.KeyChar = "S" Then
                PlayerCenter.Ctlcontrols.stop()
                PlayerLeft.Ctlcontrols.stop()
                PlayerRight.Ctlcontrols.stop()
                e.Handled = True
            End If
            If e.KeyChar = "r" Or e.KeyChar = "R" Then
                PlayerCenter.Ctlcontrols.fastReverse()
                PlayerLeft.Ctlcontrols.fastReverse()
                PlayerRight.Ctlcontrols.fastReverse()
                e.Handled = True
            End If
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Or e.KeyChar = "f" Or e.KeyChar = "F" Then
                PlayerCenter.fullScreen = False
                PlayerLeft.fullScreen = False
                PlayerRight.fullScreen = False
                e.Handled = True
            End If
        Else
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Space) Or e.KeyChar = "p" Or e.KeyChar = "P" Then
                If PlayerRender.playState = WMPLib.WMPPlayState.wmppsPaused Then
                    PlayerRender.Ctlcontrols.play()
                Else
                    PlayerRender.Ctlcontrols.pause()
                End If
                e.Handled = True
            End If
            If e.KeyChar = "," Or e.KeyChar = "<" Then
                If RenderTimeline.Value > RenderTimeline.Minimum Then
                    PlayerRender.Ctlcontrols.currentPosition -= 1
                    If PlayerRender.playState = WMPLib.WMPPlayState.wmppsPaused Then
                        PlayerRender.Ctlcontrols.play()
                        PlayerRender.Ctlcontrols.pause()
                    End If
                End If
                e.Handled = True
            End If
            If e.KeyChar = "m" Or e.KeyChar = "M" Then
                If RenderTimeline.Value > RenderTimeline.Minimum Then
                    PlayerRender.Ctlcontrols.currentPosition -= 1 / 36.02
                    If PlayerRender.playState = WMPLib.WMPPlayState.wmppsPaused Then
                        PlayerRender.Ctlcontrols.play()
                        PlayerRender.Ctlcontrols.pause()
                    End If
                End If
                e.Handled = True
            End If
            If e.KeyChar = "." Or e.KeyChar = ">" Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Right) Then
                If RenderTimeline.Value < RenderTimeline.Maximum Then
                    PlayerRender.Ctlcontrols.currentPosition += 1
                    If PlayerRender.playState = WMPLib.WMPPlayState.wmppsPaused Then
                        PlayerRender.Ctlcontrols.play()
                        PlayerRender.Ctlcontrols.pause()
                    End If
                End If
                e.Handled = True
            End If
            If e.KeyChar = "/" Or e.KeyChar = "?" Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Left) Then
                If RenderTimeline.Value < RenderTimeline.Maximum Then
                    PlayerRender.Ctlcontrols.currentPosition += 1 / 36.02
                    If PlayerRender.playState = WMPLib.WMPPlayState.wmppsPaused Then
                        PlayerRender.Ctlcontrols.play()
                        PlayerRender.Ctlcontrols.pause()
                    End If
                End If
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Tv_Explorer_NodeMouseHover(sender As Object, e As TreeNodeMouseHoverEventArgs) Handles Tv_Explorer.NodeMouseHover
        Dim Selection = e.Node.Tag.ToString
        If e.Node.ImageKey.ToString() = ".mp4" Then
            PlayerPreview.URL = e.Node.Tag.ToString
            PlayerPreview.settings.setMode("loop", True)

            PlayerPreview.settings.rate = 20
            PlayerPreview.Ctlcontrols.play()
            PREVIEWBox.BringToFront()
            PREVIEWBox.Visible = True
        Else
            PREVIEWBox.Visible = False
            PlayerPreview.Ctlcontrols.stop()
        End If
    End Sub

    Private Sub Tv_Explorer_MouseLeave(sender As Object, e As EventArgs) Handles Tv_Explorer.MouseLeave
        PREVIEWBox.Visible = False
        PlayerPreview.Ctlcontrols.stop()
    End Sub

    Private Sub Tv_Explorer_MouseMove(sender As Object, e As MouseEventArgs) Handles Tv_Explorer.MouseMove
        Dim Location As Point = MainForm.MousePosition - Me.Location
        If Location.X + PREVIEWBox.Width + 75 > Me.Width Then
            Location.X -= PREVIEWBox.Width + 50
        Else
            Location.X += 50
        End If

        If Location.Y + PREVIEWBox.Height + 20 > Me.Height Then
            Location.Y -= Location.Y + PREVIEWBox.Height + 20 - Me.Height
            Location.Y -= 45
        Else
            Location.Y -= 45
        End If
        PREVIEWBox.Location = Location
    End Sub

    Private Sub PlayerPreview_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles PlayerPreview.PlayStateChange
        If PlayerPreview.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            PREVIEWBox.BackColor = Me.BackColor
            PREVIEWBox.Text = "Preview Window - " & PlayerPreview.URL.ToString.Remove(0, PlayerPreview.URL.ToString.LastIndexOf("\") + 1)
        ElseIf PlayerPreview.playState = WMPLib.WMPPlayState.wmppsStopped Then
            PREVIEWBox.BackColor = Color.Red
        ElseIf PlayerPreview.playState = WMPLib.WMPPlayState.wmppsScanForward Then
            PREVIEWBox.BackColor = Me.BackColor
        ElseIf PlayerPreview.playState = WMPLib.WMPPlayState.wmppsPaused Then
            PREVIEWBox.BackColor = Color.Yellow
        ElseIf PlayerPreview.playState = WMPLib.WMPPlayState.wmppsReady Then
            PREVIEWBox.BackColor = Color.LightGray
        ElseIf PlayerPreview.playState = WMPLib.WMPPlayState.wmppsTransitioning Then
            PREVIEWBox.BackColor = Color.Gray
        ElseIf PlayerPreview.playState = WMPLib.WMPPlayState.wmppsMediaEnded Then
            PREVIEWBox.BackColor = Color.LightGreen
        ElseIf PlayerPreview.playState = WMPLib.WMPPlayState.wmppsScanReverse Then
            PREVIEWBox.BackColor = Color.BlueViolet
        Else
            PREVIEWBox.BackColor = Color.DarkRed
            PREVIEWBox.Text = "Left Repeater - " & PlayerPreview.URL.ToString.Remove(0, PlayerPreview.URL.ToString.LastIndexOf("\") + 1) & " - ERROR"
        End If
    End Sub

    Private Function FindDropPoint(ByVal CurrentPoint As Point)
        Dim gbSize As Point
        gbSize.X = Me.Width / 3 - 4
        gbSize.Y = (Me.Height - 40) / 2
        If CurrentPoint.X - gbSize.X < WindowLocation11.X And CurrentPoint.Y - gbSize.Y < WindowLocation11.Y Then
            Return WindowLocation11
        ElseIf CurrentPoint.X - gbSize.X < WindowLocation21.X And CurrentPoint.Y - gbSize.Y < WindowLocation21.Y Then
            Return WindowLocation21
        ElseIf CurrentPoint.X - gbSize.X < WindowLocation12.X And CurrentPoint.Y - gbSize.Y < WindowLocation12.Y Then
            Return WindowLocation12
        ElseIf CurrentPoint.X - gbSize.X < WindowLocation22.X And CurrentPoint.Y - gbSize.Y < WindowLocation22.Y Then
            Return WindowLocation22
        ElseIf CurrentPoint.X - gbSize.X < WindowLocation13.X And CurrentPoint.Y - gbSize.Y < WindowLocation13.Y Then
            Return WindowLocation13
        ElseIf CurrentPoint.X - gbSize.X < WindowLocation23.X And CurrentPoint.Y - gbSize.Y < WindowLocation23.Y Then
            Return WindowLocation23

        End If
        Dim none As Point
        Return none

    End Function

    Private Function ReturnLocationToSave(ByVal Location As Point)
        Select Case Location
            Case WindowLocation11
                Return 11
            Case WindowLocation12
                Return 12
            Case WindowLocation13
                Return 13
            Case WindowLocation21
                Return 21
            Case WindowLocation22
                Return 22
            Case WindowLocation23
                Return 23
        End Select
        Return 0
    End Function

    Private Sub MainForm_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If MoveGBExplorer = True Then
            GroupBoxEXPLORER.Location = FindDropPoint(e.Location)
            My.Settings.LocationExplorer = ReturnLocationToSave(GroupBoxEXPLORER.Location)
            MoveGBExplorer = False
        ElseIf MoveGBControls = True Then
            GroupBoxCONTROLS.Location = FindDropPoint(e.Location)
            My.Settings.LocationControls = ReturnLocationToSave(GroupBoxCONTROLS.Location)
            MoveGBControls = False
        ElseIf MoveGBFront = True Then
            GroupBoxFRONT.Location = FindDropPoint(e.Location)
            My.Settings.LocationFront = ReturnLocationToSave(GroupBoxFRONT.Location)
            MoveGBFront = False
        ElseIf MoveGBLeftRepeater = True Then
            GroupBoxLEFTREPEATER.Location = FindDropPoint(e.Location)
            My.Settings.LocationLeftRepeater = ReturnLocationToSave(GroupBoxLEFTREPEATER.Location)
            MoveGBLeftRepeater = False
        ElseIf MoveGBRightRepeater = True Then
            GroupBoxRIGHTREPEATER.Location = FindDropPoint(e.Location)
            My.Settings.LocationRightRepeater = ReturnLocationToSave(GroupBoxRIGHTREPEATER.Location)
            MoveGBRightRepeater = False
        End If
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        RESIZEgb()
    End Sub

    Private Sub MainForm_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Dim Location As Point = e.Location
        Location.X += 5
        Location.Y += 5
        If MoveGBExplorer = True Then
            GroupBoxEXPLORER.Location = Location
        ElseIf MoveGBControls = True Then
            GroupBoxCONTROLS.Location = Location
        ElseIf MoveGBFront = True Then
            GroupBoxFRONT.Location = Location
        ElseIf MoveGBLeftRepeater = True Then
            GroupBoxLEFTREPEATER.Location = Location
        ElseIf MoveGBRightRepeater = True Then
            GroupBoxRIGHTREPEATER.Location = Location
        End If
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.LocationExplorer = ReturnLocationToSave(GroupBoxEXPLORER.Location)
        My.Settings.LocationControls = ReturnLocationToSave(GroupBoxCONTROLS.Location)

        My.Settings.LocationFront = ReturnLocationToSave(GroupBoxFRONT.Location)
        My.Settings.LocationLeftRepeater = ReturnLocationToSave(GroupBoxLEFTREPEATER.Location)
        My.Settings.LocationExplorer = ReturnLocationToSave(GroupBoxEXPLORER.Location)
        Try
            Dim a As Integer = 0
            For Each PRunning As Process In System.Diagnostics.Process.GetProcessesByName("ffmpeg")
                PRunning.Kill()
                a += 1
            Next
            'MessageBox.Show("Killed " & a & " Processes ", "Kill Process", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
        Try
            Dim a As String = Path.GetTempPath() & "TeslaCamViewer\"
            System.IO.Directory.Delete(Path.GetTempPath() & "TeslaCamViewer\", True)
        Catch ex As Exception
            'MessageBox.Show("Unable to delete temp folder: " & vbCrLf & ex.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GroupBoxEXPLORER_MouseDown(sender As Object, e As MouseEventArgs) Handles GroupBoxEXPLORER.MouseDown
        Dim Location As Point = MainForm.MousePosition - Me.Location
        GroupBoxEXPLORER.Dock = DockStyle.None
        GroupBoxEXPLORER.Location = Location
        MoveGBExplorer = True
        OLDgbLOCATION = GroupBoxEXPLORER.Location
        GroupBoxEXPLORER.BringToFront()
    End Sub

    Private Sub GroupBoxCONTROLS_MouseDown(sender As Object, e As MouseEventArgs) Handles GroupBoxCONTROLS.MouseDown
        Dim Location As Point = MainForm.MousePosition - Me.Location
        GroupBoxCONTROLS.Dock = DockStyle.None
        GroupBoxCONTROLS.Location = Location
        MoveGBControls = True
        OLDgbLOCATION = GroupBoxCONTROLS.Location
        GroupBoxCONTROLS.BringToFront()
    End Sub

    Private Sub GroupBoxFRONT_MouseDown(sender As Object, e As MouseEventArgs) Handles GroupBoxFRONT.MouseDown
        Dim Location As Point = MainForm.MousePosition - Me.Location
        GroupBoxFRONT.Dock = DockStyle.None
        GroupBoxFRONT.Location = Location
        MoveGBFront = True
        OLDgbLOCATION = GroupBoxFRONT.Location
        GroupBoxFRONT.BringToFront()
    End Sub

    Private Sub GroupBoxLEFTREPEATER_MouseDown(sender As Object, e As MouseEventArgs) Handles GroupBoxLEFTREPEATER.MouseDown
        Dim Location As Point = MainForm.MousePosition - Me.Location
        GroupBoxLEFTREPEATER.Dock = DockStyle.None
        GroupBoxLEFTREPEATER.Location = Location
        MoveGBLeftRepeater = True
        OLDgbLOCATION = GroupBoxLEFTREPEATER.Location
        GroupBoxLEFTREPEATER.BringToFront()
    End Sub

    Private Sub GroupBoxRIGHTREPEATER_MouseDown(sender As Object, e As MouseEventArgs) Handles GroupBoxRIGHTREPEATER.MouseDown
        Dim Location As Point = MainForm.MousePosition - Me.Location
        GroupBoxRIGHTREPEATER.Dock = DockStyle.None
        GroupBoxRIGHTREPEATER.Location = Location
        MoveGBRightRepeater = True
        OLDgbLOCATION = GroupBoxRIGHTREPEATER.Location
        GroupBoxRIGHTREPEATER.BringToFront()
    End Sub

    Private Sub Donation_Click(sender As Object, e As EventArgs) Handles Donation.Click
        Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8UKFUQCU9476N&source=url") 'https://paypal.me/NateMccomb")
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = (Keys.F5) Then
            RefreshRootNodes()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start("https://twitter.com/nate_mccomb")
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Process.Start("https://www.instagram.com/nate.mccomb/")
    End Sub

    Private Sub UPDATELabel_Click(sender As Object, e As EventArgs) Handles UPDATELabel.Click
        Process.Start("https://github.com/NateMccomb/TeslaCamViewer")
    End Sub

    Private Sub CurrentTimeList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CurrentTimeList.SelectedIndexChanged
        If CurrentTimeList.SelectedItem <> Nothing Then
            If CurrentTimeList.SelectedItems.Count = 1 Then
                If Not FullCenterCameraName.Remove(0, FullCenterCameraName.LastIndexOf("\")).Contains(CurrentTimeList.SelectedItem.ToString.Replace(":", "-")) Then
                    Dim di As New IO.DirectoryInfo(FullCenterCameraName.Remove(FullCenterCameraName.LastIndexOf("\")))
                    Dim fis = di.GetFiles().OrderByDescending(Function(p) p.Name).ToArray()
                    For Each item In fis
                        If item.FullName.Remove(0, item.FullName.LastIndexOf("_")).Contains(CurrentTimeList.SelectedItem.Replace(":", "-")) Then
                            FullCenterCameraName = item.FullName
                            Dim FileGroup As String = FullCenterCameraName.Remove(FullCenterCameraName.LastIndexOf("-"))
                            PlayersSTOP()
                            PlayerCenter.URL = (FileGroup & "-front.mp4")
                            PlayerLeft.URL = (FileGroup & "-left_repeater.mp4")
                            PlayerRight.URL = (FileGroup & "-right_repeater.mp4")
                            'Tv_Explorer.
                            PlayerCenter.settings.setMode("loop", False)
                            PlayerLeft.settings.setMode("loop", False)
                            PlayerRight.settings.setMode("loop", False)

                            UpdatePlayBackSpeed()
                            If Tv_Explorer.Focused = False Then
                                CurrentTimeList.Focus()
                            End If
                            Exit For
                        End If
                    Next
                Else
                    PlayerCenter.Ctlcontrols.play()
                    PlayerLeft.Ctlcontrols.play()
                    PlayerRight.Ctlcontrols.play()
                    UpdatePlayBackSpeed()
                End If
            Else
                PlayersPAUSE()
            End If
            RenderBTN.Enabled = True
        Else
            RenderBTN.Enabled = False
        End If
        SelectedNumberOfVideos = CurrentTimeList.SelectedItems.Count
    End Sub

    Private Sub ClipSelectUP_Click(sender As Object, e As EventArgs) Handles ClipSelectUP.Click
        If CurrentTimeList.SelectedIndex > 0 Then
            Dim LastIndex As Integer = CurrentTimeList.SelectedIndex
            CurrentTimeList.SelectedIndices.Clear()
            CurrentTimeList.SelectedIndex = LastIndex - 1
        End If
    End Sub

    Private Sub ClipSelectDOWN_Click(sender As Object, e As EventArgs) Handles ClipSelectDOWN.Click
        If CurrentTimeList.SelectedIndex < CurrentTimeList.Items.Count - 1 Then
            Dim LastIndex As Integer = CurrentTimeList.SelectedIndex
            CurrentTimeList.SelectedIndices.Clear()
            CurrentTimeList.SelectedIndex = LastIndex + 1
        End If
    End Sub

    Private Sub CurrentTimeList_KeyDown(sender As Object, e As KeyEventArgs) Handles CurrentTimeList.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            e.SuppressKeyPress = True
            Return
        End If
    End Sub

    Private Sub RenderBTN_Click(sender As Object, e As EventArgs) Handles RenderBTN.Click
        PlayerCenter.Ctlcontrols.pause()
        PlayerLeft.Ctlcontrols.pause()
        PlayerRight.Ctlcontrols.pause()
        PlayerRender.Ctlcontrols.stop()
        PlayerRender.settings.setMode("loop", True)
        PlayerRender.URL = ""
        RenderSaveAsBTN.Enabled = False
        RenderFileCount = 0
        RenderFileCountNotDone = 0
        RenderFileProgress.Text = "---"
        ThreadsRunningLabel.Text = "---"
        RenderFirstPlay = False
        RenderInTimeGraphic.Left = (((GroupBoxRENDER.Width - 29 - 22) / RenderTimeline.Maximum) * 0) + 19
        RenderOutTimeGraphic.Left = (((GroupBoxRENDER.Width - 29 - 22) / RenderTimeline.Maximum) * RenderTimeline.Maximum) + 19
        Dim dir As New IO.DirectoryInfo(Path.GetTempPath() & "TeslaCamViewer")
        If Not dir.Exists Then
            FileSystem.MkDir(Path.GetTempPath() & "TeslaCamViewer")
        End If
        Try
            System.IO.File.Delete(Path.GetTempPath() & "TeslaCamViewer\join.txt")
        Catch ex As Exception

        End Try

        Dim JoinFile As System.IO.StreamWriter
        JoinFile = My.Computer.FileSystem.OpenTextFileWriter(Path.GetTempPath() & "TeslaCamViewer\join.txt", True, System.Text.Encoding.ASCII)

        If CurrentTimeList.SelectedItem <> Nothing Then
            Dim di As New IO.DirectoryInfo(FullCenterCameraName.Remove(FullCenterCameraName.LastIndexOf("\")))
            Dim fis = di.GetFiles().OrderByDescending(Function(p) p.Name).ToArray() '(Function(fi) fi.Name.Contains("front")).ToArray()
            Dim FilesFound As Boolean = False
            Dim i As Integer = 0
            RenderFileCountNotDone = CurrentTimeList.SelectedItems.Count
            For i = 0 To CurrentTimeList.SelectedItems.Count - 1
                Dim VideoCenter As String = "-i "
                Dim VideoLeft As String = "-i "
                Dim VideoRight As String = "-i "
                Dim FileGroup As String = ""
                For Each item In fis
                    If item.FullName.Remove(0, item.FullName.LastIndexOf("_")).Contains(CurrentTimeList.SelectedItems(i).Replace(":", "-")) Then
                        FileGroup = item.FullName.Remove(FullCenterCameraName.LastIndexOf("-"))
                        If Not VideoCenter.Contains(CurrentTimeList.SelectedItems(i)) Then
                            VideoCenter += Chr(34) & (FileGroup & "-front.mp4") & Chr(34) & " "
                        End If
                        If Not VideoLeft.Contains(CurrentTimeList.SelectedItems(i)) Then
                            If FilpLREnable.Checked = True Then
                                VideoLeft += Chr(34) & (FileGroup & "-right_repeater.mp4") & Chr(34) & " "
                            Else
                                VideoLeft += Chr(34) & (FileGroup & "-left_repeater.mp4") & Chr(34) & " "
                            End If
                        End If
                        If Not VideoRight.Contains(CurrentTimeList.SelectedItems(i)) Then
                            If FilpLREnable.Checked = True Then
                                VideoRight += Chr(34) & (FileGroup & "-left_repeater.mp4") & Chr(34) & " "
                            Else
                                VideoRight += Chr(34) & (FileGroup & "-right_repeater.mp4") & Chr(34) & " "
                            End If

                        End If
                        FilesFound = True
                        Exit For
                    End If
                Next
                If FilesFound = True Then
                    Dim FileName As String = Path.GetTempPath() & "TeslaCamViewer\Temp" & CurrentTimeList.SelectedItems.Count - 1 - i & ".mp4"
                    JoinFile.Write("file Temp" & i & ".mp4" & vbCrLf)
                    If IsFileInUse(FileName) And File.Exists(FileName) Then
                        MessageBox.Show("Unable to save video due to file in use" & vbCrLf & FileName, "Error With Selected File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    FFmpegOutput.Text = ""
                    Dim saveas As String = Chr(34) & FileName & Chr(34)
                    RenderOutputFile = FileName
                    Dim p As New Process
                    p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "ffmpeg.exe")
                    p.StartInfo.UseShellExecute = False
                    p.StartInfo.CreateNoWindow = True
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    p.StartInfo.RedirectStandardError = True
                    p.EnableRaisingEvents = True
                    Application.DoEvents()

                    AddHandler p.ErrorDataReceived, AddressOf proccess_OutputDataReceived
                    AddHandler p.OutputDataReceived, AddressOf proccess_OutputDataReceived
                    AddHandler p.Exited, AddressOf proc_Exited
                    Dim FileTime As String = FileGroup.Remove(0, FileGroup.LastIndexOf("\") + 1).Replace("_", "  ").Replace("-", ".")
                    Dim Watermark As String = " drawtext=text='" & FileTime & "                 TeslaCam Viewer - Ver." & CurrentVersion & "':x=(5):y=(5):fontfile='/Windows/Fonts/AGENCYR.TTF':fontsize=40:fontcolor=white,"

                    '.gif file
                    'p.StartInfo.Arguments = VideoLeft & VideoCenter & VideoRight & "-filter_complex " & Chr(34) & "[1:v][0:v]scale2ref=oh*mdar:ih[1v][0v];[2:v][0v]scale2ref=oh*mdar:ih[2v][0v];[0v][1v][2v]hstack=3,scale='2*trunc(iw/2)':'2*trunc(ih/2)'" & Chr(34) & " -y -r 20 " & saveas
                    Dim SelectedQuality = 0
                    Dim Mirror As String = ""
                    If MirrorLREnable.Checked = True Then
                        Mirror = " hflip,"
                    End If
                    Select Case RenderQuality.SelectedIndex
                        Case 0
                            SelectedQuality = 1
                        Case 1
                            SelectedQuality = 2
                        Case 2
                            SelectedQuality = 4
                        Case 3
                            SelectedQuality = 8
                    End Select
                    My.Settings.RenderQuality = RenderQuality.SelectedIndex

                    If RadioButton1.Checked = True Then
                        'Center large - Left
                        'Left & right - Stack right
                        My.Settings.RenderSelection = 0
                        p.StartInfo.Arguments = VideoCenter & VideoLeft & VideoRight & "-filter_complex " & Chr(34) & "color=s=" & 1920 / SelectedQuality & "x" & 960 / SelectedQuality & ":c=black [base];[0:v]" & Watermark & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [center];[1:v]" & Mirror & " setpts=PTS-STARTPTS, scale=" & 640 / SelectedQuality & "x" & 480 / SelectedQuality & " [topright];[2:v]" & Mirror & " setpts=PTS-STARTPTS, scale=" & 640 / SelectedQuality & "x" & 480 / SelectedQuality & " [bottomright];[base][center] overlay=shortest=1 [tmp1];[tmp1][topright] overlay=shortest=0:x=" & 1280 / SelectedQuality & " [tmp2];[tmp2][bottomright] overlay=shortest=0:x=" & 1280 / SelectedQuality & ":y=" & 480 / SelectedQuality & Chr(34) & " -y -preset veryfast " & saveas

                    ElseIf RadioButton2.Checked = True Then
                        'center - top
                        'Left/right - bottom
                        My.Settings.RenderSelection = 1
                        p.StartInfo.Arguments = VideoCenter & VideoLeft & VideoRight & "-filter_complex " & Chr(34) & "color=s=" & 2560 / SelectedQuality & "x" & 1920 / SelectedQuality & ":c=black [base];[0:v]" & Watermark & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [center];[1:v]" & Mirror & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [bottomleft];[2:v]" & Mirror & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [bottomright];[base][center] overlay=shortest=1:x=" & 640 / SelectedQuality & " [tmp1];[tmp1][bottomleft] overlay=shortest=0:y=" & 960 / SelectedQuality & " [tmp2];[tmp2][bottomright] overlay=shortest=0:x=" & 1280 / SelectedQuality & ":y=" & 960 / SelectedQuality & Chr(34) & " -y -preset veryfast " & saveas
                    ElseIf RadioButton3.Checked = True Then
                        '3 wide - 
                        My.Settings.RenderSelection = 2
                        p.StartInfo.Arguments = VideoLeft & VideoCenter & VideoRight & "-filter_complex " & Chr(34) & "color=s=" & 3840 / SelectedQuality & "x" & 1920 / SelectedQuality & ":c=black [base];[0:v]" & Mirror & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [center];[1:v]" & Watermark & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [bottomleft];[2:v]" & Mirror & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [bottomright];[base][center] overlay=shortest=1:y=" & 480 / SelectedQuality & " [tmp1];[tmp1][bottomleft] overlay=shortest=0:y=" & 480 / SelectedQuality & ":x=" & 1280 / SelectedQuality & " [tmp2];[tmp2][bottomright] overlay=shortest=0:y=" & 480 / SelectedQuality & ":x=" & 2560 / SelectedQuality & Chr(34) & " -y -preset veryfast " & saveas

                    ElseIf RadioButton4.Checked = True Then
                        'Left & Center   
                        My.Settings.RenderSelection = 3
                        p.StartInfo.Arguments = VideoLeft & VideoCenter & "-filter_complex " & Chr(34) & "color=s=" & 2560 / SelectedQuality & "x" & 960 / SelectedQuality & ":c=black [base];[0:v]" & Mirror & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [right];[1:v]" & Watermark & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [left];[base][right] overlay=shortest=1 [tmp1];[tmp1][left] overlay=shortest=0:x=" & 1280 / SelectedQuality & Chr(34) & " -y -preset veryfast " & saveas
                    ElseIf RadioButton5.Checked = True Then
                        'Center & Right 
                        My.Settings.RenderSelection = 4
                        p.StartInfo.Arguments = VideoCenter & VideoRight & "-filter_complex " & Chr(34) & "color=s=" & 2560 / SelectedQuality & "x" & 960 / SelectedQuality & ":c=black [base];[0:v]" & Watermark & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [right];[1:v]" & Mirror & " setpts=PTS-STARTPTS, scale=" & 1280 / SelectedQuality & "x" & 960 / SelectedQuality & " [left];[base][right] overlay=shortest=0 [tmp1];[tmp1][left] overlay=shortest=1:x=" & 1280 / SelectedQuality & Chr(34) & " -y -preset veryfast " & saveas
                    End If
                    My.Settings.FlipLR = FilpLREnable.Checked
                    My.Settings.MirrorLR = MirrorLREnable.Checked

                    DurationProgressBar.Style = ProgressBarStyle.Marquee
                    DurationProgressBar.Maximum = 1
                    DurationProgressBar.Value = 0

                    GroupBoxRENDER.Visible = True
                    GroupBoxRENDER.BringToFront()
                    VideoRendering.Visible = True

                    GroupBoxCONTROLS.Enabled = False
                    GroupBoxEXPLORER.Enabled = False
                    GroupBoxFRONT.Enabled = False
                    GroupBoxLEFTREPEATER.Enabled = False
                    GroupBoxRIGHTREPEATER.Enabled = False

                    UpdateTextBox("---- Starting FFmpeg ----")
                    UpdateTextBox(" ")
                    UpdateTextBox("ffmpeg " & p.StartInfo.Arguments)
                    UpdateTextBox(" ")
                    Try
                        RenderFileCount += 1
                        Call p.Start()
                    Catch ex As Exception
                        UpdateTextBox("---- ERROR Starting FFmpeg ----")
                    End Try
                    Try
                        p.BeginErrorReadLine()
                    Catch ex As Exception

                    End Try
                End If
            Next i
        Else
            RenderBTN.Enabled = False
        End If
        JoinFile.Close()
    End Sub

    Public Sub UpdateTextBox(text As String)
        If text.IsNormalized Then
            FFmpegOutput.Text += Environment.NewLine & text.ToString
        End If
        FFmpegOutput.SelectionStart = FFmpegOutput.Text.Length
        FFmpegOutput.ScrollToCaret()
        If text.Contains("Duration:") Then
            Try
                Dim MaxDuration As Integer = text.Remove(text.IndexOf(","), text.Length - text.IndexOf(",")).Remove(0, text.IndexOf(":")).Replace(":", "").Replace(".", "")
                DurationProgressBar.Style = ProgressBarStyle.Continuous
                If MaxDuration > DurationProgressBar.Maximum Then
                    If MaxDuration < 6000 Then
                        DurationProgressBar.Maximum = MaxDuration
                    Else
                        DurationProgressBar.Maximum = 6000
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
        If text.Contains("time=0") Then
            Try
                Dim CurrentTime As Integer = text.Remove(text.IndexOf(" bitrate="), text.Length - text.IndexOf(" bitrate=")).Remove(0, text.IndexOf("time=0") + 6).Replace(":", "").Replace(".", "")
                DurationProgressBar.Style = ProgressBarStyle.Continuous
                DurationProgressBar.Value = CurrentTime
                If RenderFileCount = 0 And RenderFileCountNotDone = 0 Then
                    RenderFileProgress.Text = "DONE"
                    ThreadsRunningLabel.Text = "DONE"
                    DurationProgressBar.Value = DurationProgressBar.Maximum
                Else
                    RenderFileProgress.Text = RenderFileCount & " of " & RenderFileCountNotDone
                End If
                ThreadsRunningLabel.Text = RenderFileCount & " Running"
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(e.Data) Then
            If Me.InvokeRequired = True Then
                Try
                    Me.Invoke(myDelegate, e.Data)
                Catch ex As Exception

                End Try
            Else
                Try
                    UpdateTextBox(e.Data)
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    Dim RenderedVideoReady As Boolean = False
    Private Sub proc_Exited(ByVal sender As Object, ByVal e As System.EventArgs) ' Handles p.Exited
        If Me.InvokeRequired = True Then
            Me.Invoke(myDelegate, "---- Finished converting video ----")
        Else
            UpdateTextBox("---- Finished converting video ----")
        End If

        DurationProgressBar.Value = DurationProgressBar.Maximum
        RenderedVideoReady = False
        RenderFileCount -= 1
        RenderFileCountNotDone -= 1
        If RenderFileCount = 0 And RenderFileCountNotDone = 0 Then
            If Me.InvokeRequired = True Then
                Me.Invoke(myDelegate, "---- All files are done converting ----")
                RenderSaveAsBTN.Enabled = True
            Else
                UpdateTextBox("---- All files are done converting ----")
                RenderSaveAsBTN.Enabled = True
            End If
            DurationProgressBar.Style = ProgressBarStyle.Continuous
            If SelectedNumberOfVideos = 1 Or RenderOutputFile = Path.GetTempPath() & "TeslaCamViewer\Temp.mp4" Then
                Try
                    RenderedVideoReady = False
                    PlayerRender.URL = RenderOutputFile
                    PlayerRender.Ctlcontrols.play()
                    VideoRendering.Visible = False
                Catch ex As Exception
                    'MessageBox.Show("Error loading render media" & vbCrLf & e.ToString, "Error With Selected File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            Else
                If Me.InvokeRequired = True Then
                    Me.Invoke(myDelegate, "---- Rendering all clips together now ----")
                Else
                    UpdateTextBox("---- Rendering all clips together now ----")
                End If
                Dim VideoALL As String = "-f concat -safe 0 -i " & Chr(34) & Path.GetTempPath().Replace("\", "/") & "TeslaCamViewer/join.txt" & Chr(34)
                VideoALL += " -c copy -y -preset veryfast " & Chr(34) & Path.GetTempPath() & "TeslaCamViewer\Temp.mp4" & Chr(34)

                Dim p As New Process
                p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "ffmpeg.exe")
                p.StartInfo.UseShellExecute = False
                p.StartInfo.CreateNoWindow = True
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.StartInfo.RedirectStandardError = True
                p.EnableRaisingEvents = True
                Application.DoEvents()

                AddHandler p.ErrorDataReceived, AddressOf proccess_OutputDataReceived
                AddHandler p.OutputDataReceived, AddressOf proccess_OutputDataReceived
                AddHandler p.Exited, AddressOf proc_Exited

                p.StartInfo.Arguments = VideoALL
                DurationProgressBar.Maximum = 1
                DurationProgressBar.Value = 0
                GroupBoxRENDER.BringToFront()
                VideoRendering.Visible = True
                FFmpegOutput.Text += "---- Starting FFmpeg ----" & Environment.NewLine
                UpdateTextBox(" ")
                UpdateTextBox("ffmpeg " & p.StartInfo.Arguments)
                UpdateTextBox(" ")
                Try
                    Call p.Start()
                    RenderFileCount = 1
                    RenderFileCountNotDone = 1
                    RenderOutputFile = Path.GetTempPath() & "TeslaCamViewer\Temp.mp4"
                Catch ex As Exception
                    FFmpegOutput.Text += "---- ERROR Starting FFmpeg ----" & Environment.NewLine
                End Try

                Try
                    p.BeginErrorReadLine()
                Catch ex As Exception

                End Try
            End If
        Else
            If Me.InvokeRequired = True Then
                Me.Invoke(myDelegate, "---- Waiting for " & RenderFileCount & " file(s) to finish converting ----")
            Else
                UpdateTextBox("---- Waiting for " & RenderFileCount & " file(s) to finish converting ----")
            End If
        End If
        If RenderFileCount = 0 And RenderFileCountNotDone = 0 Then
            RenderFileProgress.Text = "DONE"
            ThreadsRunningLabel.Text = "DONE"
        Else
            RenderFileProgress.Text = RenderFileCount & " of " & RenderFileCountNotDone
            ThreadsRunningLabel.Text = RenderFileCount & " Running"
        End If

    End Sub

    Public Function IsFileInUse(sFile As String) As Boolean
        Try
            Using f As New IO.FileStream(sFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            End Using
        Catch Ex As Exception
            Return True
        End Try
        Return False
    End Function
    Private Sub CloseGroupboxRender_Click(sender As Object, e As EventArgs) Handles CloseGroupboxRender.Click
        GroupBoxCONTROLS.Enabled = True
        GroupBoxEXPLORER.Enabled = True
        GroupBoxFRONT.Enabled = True
        GroupBoxLEFTREPEATER.Enabled = True
        GroupBoxRIGHTREPEATER.Enabled = True

        GroupBoxRENDER.Visible = False
        PlayerRender.Ctlcontrols.stop()
        PlayerRender.URL = ""
        RenderedVideoReady = False
        RenderOutputFile = ""
        GroupBoxSettings.Visible = False
        Try
            Dim a As Integer = 0
            For Each PRunning As Process In System.Diagnostics.Process.GetProcessesByName("ffmpeg")
                PRunning.Kill()
                a += 1
            Next
            'MessageBox.Show("Killed " & a & " Processes ", "Kill Process", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
        Try
            Dim a As String = Path.GetTempPath() & "TeslaCamViewer\"
            System.IO.Directory.Delete(Path.GetTempPath() & "TeslaCamViewer\", True)
        Catch ex As Exception
            'MessageBox.Show("Unable to delete temp folder: " & vbCrLf & ex.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub PlayerRender_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles PlayerRender.PlayStateChange
        If PlayerRender.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            RenderTimeline.Maximum = (PlayerRender.currentMedia.duration * 10)
            If RenderFirstPlay = False Then
                RenderFirstPlay = True
                RenderOutTime = RenderTimeline.Maximum
                RenderInTimeGraphic.Left = (((GroupBoxRENDER.Width - 29 - 22) / RenderTimeline.Maximum) * 0) + 19
                RenderOutTimeGraphic.Left = (((GroupBoxRENDER.Width - 29 - 22) / RenderTimeline.Maximum) * RenderTimeline.Maximum) + 19

                RenderTimeline.Value = 0
                RenderInTime = 0
            End If
            If RenderedVideoReady = False Then
                RenderedVideoReady = True
            End If
        End If
    End Sub

    Private Sub SettingsBTN_Click(sender As Object, e As EventArgs) Handles SettingsBTN.Click
        GroupBoxSettings.Size = GroupBoxControlsWindow.Size
        GroupBoxSettings.Location = GroupBoxControlsWindow.Location
        GroupBoxSettings.Visible = True
        PlayersPAUSE()
    End Sub

    Private Sub CloseGroupboxSettings_Click(sender As Object, e As EventArgs) Handles CloseGroupboxSettings.Click
        GroupBoxSettings.Visible = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton4.Checked = False
            RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
        End If
    End Sub

    Private Sub RenderSaveAsBTN_Click(sender As Object, e As EventArgs) Handles RenderSaveAsBTN.Click
        Dim sfd As New SaveFileDialog
        sfd.Title = "Save Video As..."
        sfd.FileName = "Untitled"
        sfd.DefaultExt = ".mp4"
        sfd.AddExtension = True
        sfd.Filter = "MP4 Files (*.mp4*)|*.mp4|AVI Image (.avi)|*.avi|Gif Image (.gif)|*.gif"
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            PlayerRender.Ctlcontrols.stop()
            PlayerRender.URL = ""
            Dim p As New Process

            p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "ffmpeg.exe")
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True 'False 'True
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden  'Hidden
            p.StartInfo.RedirectStandardError = True
            p.EnableRaisingEvents = True
            Application.DoEvents()

            AddHandler p.ErrorDataReceived, AddressOf proccess_OutputDataReceived
            AddHandler p.OutputDataReceived, AddressOf proccess_OutputDataReceived
            AddHandler p.Exited, AddressOf proc_Exited
            Dim StartMin As Integer = 0
            Dim StartSec As Double = 0
            Dim EndMin As Integer = 0
            Dim EndSec As Double = 0
            If RenderInTime > 599 Then
                Dim TempTime As Integer = RenderInTime
                For i = 1 To RenderInTime / 600
                    StartMin += 1
                    TempTime -= 600
                Next
                StartSec = TempTime / 10
            Else
                StartSec = RenderInTime / 10
            End If
            If RenderOutTime > 599 Then
                Dim TempTime As Integer = RenderOutTime
                For i = 1 To RenderOutTime / 600
                    EndMin += 1
                    TempTime -= 600
                Next
                EndSec = TempTime / 10
            Else
                EndSec = RenderOutTime / 10
            End If
            EndMin -= StartMin
            EndSec -= StartSec
            If EndSec < 0 Then
                EndMin -= 1
                EndSec = Math.Abs(EndSec)
            End If

            p.StartInfo.Arguments = "-ss 00:" & StartMin.ToString("00") & ":" & StartSec.ToString("00.00") & " -i " & Chr(34) & RenderOutputFile & Chr(34) & " -t 00:" & EndMin.ToString("00") & ":" & EndSec.ToString("00.00") & " -y -preset veryfast " & Chr(34) & sfd.FileName & Chr(34)
            Try
                Call p.Start()
                RenderFileCount = 1
                RenderFileCountNotDone = 1
            Catch ex As Exception
                UpdateTextBox("---- ERROR Starting FFmpeg ----")
            End Try

            Try
                p.BeginErrorReadLine()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RenderTimeline_MouseEnter(sender As Object, e As EventArgs) Handles RenderTimeline.MouseEnter
        'PlayerRender.CreateControl()
        PlayerRender.Ctlcontrols.pause()
    End Sub

    Private Sub RenderTimeline_MouseLeave(sender As Object, e As EventArgs) Handles RenderTimeline.MouseLeave
        If VideoRendering.Visible = False Then
            ' PlayerRender.Ctlcontrols.play()
        End If
    End Sub

    Private Sub RenderTimeline_ValueChanged(sender As Object, e As EventArgs) Handles RenderTimeline.ValueChanged
        PlayerRender.CreateControl()
        If PlayerRender.playState = WMPLib.WMPPlayState.wmppsPaused And RenderTimeline.Value >= (RenderVideoLastPos - 10) * 10 And RenderTimeline.Value <= (RenderVideoLastPos + 10) * 10 Then
            PlayerRender.Ctlcontrols.currentPosition = RenderTimeline.Value / 10
            RenderVideoLastPos = PlayerRender.Ctlcontrols.currentPosition
            PlayerRender.Ctlcontrols.play()
            PlayerRender.Ctlcontrols.pause()
        End If
        If PlayerRender.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            RenderVideoLastPos = PlayerRender.Ctlcontrols.currentPosition
            If RenderTimeline.Value >= RenderOutTime Then
                RenderTimeline.Value = RenderInTime
                PlayerRender.Ctlcontrols.currentPosition = RenderTimeline.Value / 10
            End If
            If RenderTimeline.Value < RenderInTime Then
                RenderTimeline.Value = RenderInTime
                PlayerRender.Ctlcontrols.currentPosition = RenderTimeline.Value / 10
            End If
        End If
    End Sub

    Private Sub RenderSaveOptions_MouseEnter(sender As Object, e As EventArgs) Handles RenderSaveOptions.MouseEnter
        PlayerRender.Ctlcontrols.pause()
    End Sub

    Private Sub RenderSaveAsBTN_MouseEnter(sender As Object, e As EventArgs) Handles RenderSaveAsBTN.MouseEnter
        PlayerRender.Ctlcontrols.pause()
    End Sub

    Private Sub FFmpegOutput_MouseEnter(sender As Object, e As EventArgs) Handles FFmpegOutput.MouseEnter
        PlayerRender.Ctlcontrols.pause()
    End Sub

    Private Sub RenderInTimeLabel_MouseEnter(sender As Object, e As EventArgs) Handles RenderInTimeLabel.MouseEnter
        PlayerRender.Ctlcontrols.pause()
    End Sub

    Private Sub RenderOutTimeLabel_MouseEnter(sender As Object, e As EventArgs) Handles RenderOutTimeLabel.MouseEnter
        PlayerRender.Ctlcontrols.pause()
    End Sub
    Private Sub GroupBoxRENDER_MouseEnter(sender As Object, e As EventArgs) Handles GroupBoxRENDER.MouseEnter
        If VideoRendering.Visible = False Then
            PlayerRender.Ctlcontrols.play()
        End If
    End Sub

    Private Sub RenderInTimeLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles RenderInTimeLabel.MouseClick
        If e.Button = MouseButtons.Right Then
            RenderInTime = RenderTimeline.Value
            If RenderTimeline.Value >= RenderOutTime Then
                RenderTimeline.Value = RenderInTime
                PlayerRender.Ctlcontrols.currentPosition = RenderTimeline.Value / 10
            End If
            If RenderTimeline.Value < RenderInTime Then
                RenderTimeline.Value = RenderInTime
                PlayerRender.Ctlcontrols.currentPosition = RenderTimeline.Value / 10
            End If
            RenderInTimeGraphic.Left = (((GroupBoxRENDER.Width - 29 - 22) / RenderTimeline.Maximum) * RenderTimeline.Value) + 19
        End If
    End Sub

    Private Sub RenderOutTimeLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles RenderOutTimeLabel.MouseClick
        If e.Button = MouseButtons.Right Then
            RenderOutTime = RenderTimeline.Value
            If RenderTimeline.Value > RenderOutTime Then
                RenderTimeline.Value = RenderOutTime
                PlayerRender.Ctlcontrols.currentPosition = RenderTimeline.Value / 10
            End If
            If RenderTimeline.Value < RenderInTime Then
                RenderTimeline.Value = RenderInTime
                PlayerRender.Ctlcontrols.currentPosition = RenderTimeline.Value / 10
            End If
            RenderOutTimeGraphic.Left = (((GroupBoxRENDER.Width - 29 - 22) / RenderTimeline.Maximum) * RenderTimeline.Value) + 19
        End If
    End Sub

    Private Sub RenderInTimeGraphic_Click(sender As Object, e As EventArgs) Handles RenderInTimeGraphic.Click
        If MoveRenderIn = True Then
            MoveRenderIn = False
        Else
            MoveRenderIn = True
        End If
    End Sub

    Private Sub RenderOutTimeGraphic_Click(sender As Object, e As EventArgs) Handles RenderOutTimeGraphic.Click
        If MoveRenderOut = True Then
            MoveRenderOut = False
        Else
            MoveRenderOut = True
        End If
    End Sub

    Private Sub RenderTimeline_MouseMove(sender As Object, e As MouseEventArgs) Handles RenderTimeline.MouseMove
        If MoveRenderOut = True And e.X < GroupBoxRENDER.Width - 42 And e.X > 9 Then
            RenderOutTimeGraphic.Left = e.X + 10
            RenderOutTime = (e.X / ((GroupBoxRENDER.Width - 29 - 22) / RenderTimeline.Maximum)) '* 10
        End If
        If MoveRenderIn = True And e.X < GroupBoxRENDER.Width - 42 And e.X > 9 Then
            RenderInTimeGraphic.Left = e.X + 10
            RenderInTime = (e.X / ((GroupBoxRENDER.Width - 29 - 22) / RenderTimeline.Maximum)) '* 10
        End If

    End Sub

    Private Sub PlayerRender_MouseMoveEvent(sender As Object, e As _WMPOCXEvents_MouseMoveEvent) Handles PlayerRender.MouseMoveEvent
        If PlayerRender.playState <> WMPLib.WMPPlayState.wmppsPlaying And VideoRendering.Visible = False Then
            PlayerRender.Ctlcontrols.play()
        End If
    End Sub

    Private Sub RenderQuality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RenderQuality.SelectedIndexChanged

    End Sub
End Class
