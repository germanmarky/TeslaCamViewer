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
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CurrentVersion As String = Application.ProductVersion
        Me.Text = Me.Text & CurrentVersion
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



        MainToolTip.Active = True



        Me.Size = New Size(1100, 600)
        Me.MinimumSize = Me.Size
        Tv_ImgList.ImageSize = New Size(20, 20)
        Tv_Explorer.ImageList = Tv_ImgList
        Tv_Explorer.HideSelection = False

        RefreshRootNodes()

        PlayerCenter.uiMode = "none"
        PlayerLeft.uiMode = "none"
        PlayerRight.uiMode = "none"
        PlayerPreview.uiMode = "none"
        PlayerCenter.Ctlenabled = False
        PlayerLeft.Ctlenabled = False
        PlayerRight.Ctlenabled = False
        PlayerPreview.Ctlenabled = False

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
        TxtBx_Path.Text = e.Node.Tag.ToString





        If e.Node.ImageKey.ToString() <> "Folder" Then
            Dim FileGroup As String
            FolderViewing = False

            Try
                If TxtBx_Path.Text.Contains("recent-front") Or TxtBx_Path.Text.Contains("saved-front") Then
                    PlayersSTOP()
                    PlayerCenter.URL = TxtBx_Path.Text

                    

                    PlayerCenter.settings.setMode("loop", True)
                    PlayerLeft.settings.setMode("loop", False)
                    PlayerRight.settings.setMode("loop", False)
                Else
                    FileGroup = TxtBx_Path.Text.Remove(TxtBx_Path.Text.LastIndexOf("-"))
                    PlayersSTOP()
                    PlayerCenter.URL = (FileGroup & "-front.mp4")
                    PlayerLeft.URL = (FileGroup & "-left_repeater.mp4")
                    PlayerRight.URL = (FileGroup & "-right_repeater.mp4")
                    'Tv_Explorer.
                    PlayerCenter.settings.setMode("loop", True)
                    PlayerLeft.settings.setMode("loop", True)
                    PlayerRight.settings.setMode("loop", True)

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

                Dim di As New IO.DirectoryInfo(TxtBx_Path.Text)
                Dim fis = di.GetFiles().OrderBy(Function(fi) fi.Name.Contains("front")).ToArray()
                Dim a = fis.GetValue(fis.Length - 1)

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

    Private Function AddImageToImgList(FullPath As String, Optional SpecialImageKeyName As String = "") As String
        Dim ImgKey As String = If(SpecialImageKeyName = "", FullPath, SpecialImageKeyName)
        Dim LoadFromExt As Boolean = False

        If ImgKey = FullPath AndAlso File.Exists(FullPath) Then
            Dim ext As String = Path.GetExtension(FullPath).ToLower
            If ext <> "" AndAlso ext <> ".exe" AndAlso ext <> ".lnk" AndAlso ext <> ".url" Then
                ImgKey = Path.GetExtension(FullPath).ToLower
                LoadFromExt = True
            End If
        End If

        If Not Tv_ImgList.Images.Keys.Contains(ImgKey) Then
            Tv_ImgList.Images.Add(ImgKey, Iconhelper.GetIconImage(If(LoadFromExt, ImgKey, FullPath), IconSizes.Large32x32))
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

        Catch ex As Exception

        End Try


        Try
            If PlayerCenter.playState = WMPLib.WMPPlayState.wmppsStopped Then
                If FolderViewing = True And LastFolderFile = False Then
                    LastFolderFile = True

                    Dim di As New IO.DirectoryInfo(TxtBx_Path.Text.Remove(TxtBx_Path.Text.LastIndexOf("\")))
                    Dim fis = di.GetFiles().OrderBy(Function(fi) fi.Name.Contains("front")).ToArray()
                    Dim a = fis.GetValue(fis.Length - 1)

                    Dim FileGroup As String

                    TxtBx_Path.Text = a.Fullname.ToString
                    FileGroup = TxtBx_Path.Text.Remove(TxtBx_Path.Text.LastIndexOf("-"))
                    'PlayerCenter.Ctlcontrols.play()

                    PlayersSTOP()
                    PlayerCenter.URL = (FileGroup & "-front.mp4")
                    PlayerLeft.URL = (FileGroup & "-left_repeater.mp4")
                    PlayerRight.URL = (FileGroup & "-right_repeater.mp4")
                    'PlayerCenter.Ctlcontrols.play()

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
                Dim di As New IO.DirectoryInfo(TxtBx_Path.Text)
                Dim fis = di.GetFiles().OrderBy(Function(fi) fi.Name.Contains("front")).ToArray()
                Dim a = fis.GetValue(fis.Length - 2)

                Dim FileGroup As String

                TxtBx_Path.Text = a.Fullname.ToString
                FileGroup = TxtBx_Path.Text.Remove(TxtBx_Path.Text.LastIndexOf("-"))
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
            GroupBoxLEFTREPEATER.BackColor = Color.Yellow
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
            GroupBoxRIGHTREPEATER.BackColor = Color.Yellow
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
                    CurrentTimeList.SelectedItem = time.ToString.Replace("-", ":")
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
            GroupBoxFRONT.BackColor = Color.Yellow
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
                If Tv_Explorer.Nodes.Count > 0 Then

                End If





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
        Process.Start("https://paypal.me/NateMccomb")
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


    Private Sub PlayerCenter_KeyPressEvent(sender As Object, e As _WMPOCXEvents_KeyPressEvent) Handles PlayerCenter.KeyPressEvent
        If e.nKeyAscii.ToString = "" Then

        End If

    End Sub

    Private Sub CurrentTimeList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CurrentTimeList.SelectedIndexChanged
        If Not TxtBx_Path.Text.Remove(0, TxtBx_Path.Text.LastIndexOf("\")).Contains(CurrentTimeList.SelectedItem.ToString.Replace(":", "-")) And CurrentTimeList.SelectedItem <> Nothing Then
            Dim di As New IO.DirectoryInfo(TxtBx_Path.Text.Remove(TxtBx_Path.Text.LastIndexOf("\")))
            Dim fis = di.GetFiles().OrderBy(Function(fi) fi.Name).ToArray()

            For Each item In fis
                If item.FullName.Remove(0, item.FullName.LastIndexOf("_")).Contains(CurrentTimeList.SelectedItem.Replace(":", "-")) Then
                    TxtBx_Path.Text = item.FullName
                    Dim FileGroup As String = TxtBx_Path.Text.Remove(TxtBx_Path.Text.LastIndexOf("-"))
                    PlayersSTOP()
                    PlayerCenter.URL = (FileGroup & "-front.mp4")
                    PlayerLeft.URL = (FileGroup & "-left_repeater.mp4")
                    PlayerRight.URL = (FileGroup & "-right_repeater.mp4")
                    'Tv_Explorer.
                    PlayerCenter.settings.setMode("loop", True)
                    PlayerLeft.settings.setMode("loop", True)
                    PlayerRight.settings.setMode("loop", True)

                    UpdatePlayBackSpeed()
                    If Tv_Explorer.Focused = False Then
                        CurrentTimeList.Focus()
                    End If
                    Exit For
                End If
            Next

        End If

    End Sub

    Private Sub TxtBx_Path_TextChanged(sender As Object, e As EventArgs) Handles TxtBx_Path.TextChanged
        CurrentTimeList.Enabled = False
        CurrentTimeList.Items.Clear()
        Dim Location As String = TxtBx_Path.Text
        If Location.LastIndexOf("\") - Location.Length <> 0 Then
            Location = Location.Remove(Location.LastIndexOf("\"))
        End If

        Dim DirInfo As New DirectoryInfo(Location)

        For Each fi As FileInfo In DirInfo.GetFiles.OrderByDescending(Function(p) p.Name).ToArray()
            If Not (fi.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                Dim fiTime As String = fi.Name.Remove(fi.Name.LastIndexOf("-"), fi.Name.Length - fi.Name.LastIndexOf("-"))
                fiTime = fiTime.Remove(0, fiTime.IndexOf("_") + 1)

                If Not CurrentTimeList.Items.Contains(fiTime.Replace("-", ":")) Then
                    CurrentTimeList.Items.Add(fiTime.Replace("-", ":"))

                End If
            End If
        Next

    End Sub

    Private Sub ClipSelectUP_Click(sender As Object, e As EventArgs) Handles ClipSelectUP.Click
        If CurrentTimeList.SelectedIndex > 0 Then
            CurrentTimeList.SelectedIndex -= 1
        End If
    End Sub

    Private Sub ClipSelectDOWN_Click(sender As Object, e As EventArgs) Handles ClipSelectDOWN.Click
        If CurrentTimeList.SelectedIndex < CurrentTimeList.Items.Count - 1 Then
            CurrentTimeList.SelectedIndex += 1
        End If
    End Sub

    Private Sub CurrentTimeList_KeyDown(sender As Object, e As KeyEventArgs) Handles CurrentTimeList.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            e.SuppressKeyPress = True
            Return
        End If
    End Sub
End Class
