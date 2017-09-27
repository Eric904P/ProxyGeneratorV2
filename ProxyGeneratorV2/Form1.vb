Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Threading
Imports ProxyGeneratorV2.My.Resources

Public Class Form1
    Private _thrdCntScrape = 0
    Private _maxThrdScrape
    Private _thrdCntCheck = 0
    Private _maxThrdCheck
    Private _scrapedTotal As Double = 0
    Private _sourceTotal As Double = 0
    Dim _scrpCnt As Double
    Dim _srcCnt As Double
    Private _sources As List(Of String) = New List(Of String)
    Private _scraped As List(Of String) = New List(Of String)
    Private _working As List(Of String) = New List(Of String)
    Private _hasResult As List(Of String) = New List(Of String)
    Private _noResult As List(Of String) = New List(Of String)
    Private _listLock = New Object
    Private _dictScrape = New Dictionary(Of String, Thread)() 
    Private _dictCheck = New Dictionary(Of String, Thread)()
    Private _running As Boolean = False
    Private _paused As Boolean = False
    Private _any As Boolean

    'delegate sub EventHandler()
    Event ProxyChecked(ByVal count As Integer, ByRef working As Boolean) 
    Event SourceScraped(ByVal outCnt As Integer)
    Event ChkThrdChanged(ByVal threads As Integer)
    Event ScrpThrdChanged(ByVal threads As Integer)
    Event IBSrcChanged(ByRef bool As Boolean)
    Event WResultChanged(ByRef bool As Boolean)
    Event UseScrapedChanged(ByRef bool As Boolean)

    'OnLoad Override
    Protected Overrides Sub OnLoad(e As EventArgs) 
        AddHandler ChkThrdChanged, New ChkThrdChangedEventHandler(AddressOf ChkThrdChangedHandler)
        AddHandler ScrpThrdChanged, New ScrpThrdChangedEventHandler(AddressOf ScrpThrdChangedHandler)
        AddHandler IBSrcChanged, New IBSrcChangedEventHandler(AddressOf IBSrcChangedHandler)
        AddHandler WResultChanged, New WResultChangedEventHandler(AddressOf WResultChangedHandler)
        AddHandler UseScrapedChanged, New UseScrapedChangedEventHandler(AddressOf UseScrapedChangedHandler)
        AddHandler SourceScraped, New SourceScrapedEventHandler(AddressOf StepPB1)
        AddHandler ProxyChecked, New ProxyCheckedEventHandler(AddressOf StepPB2)
        _maxThrdScrape = My.Settings.ScrpThrd
        _maxThrdCheck = My.Settings.ChkThrd
    End Sub

    'SCRAPER
    Function ScrapeHerder() As Boolean
        _maxThrdScrape = My.Settings.ScrpThrd
        'AddHandler SourceScraped, New SourceScrapedEventHandler(AddressOf StepPB1)       
        _sourceTotal = _sources.Count
        ListBox1.Items.Add("Scraper started")
        Dim thrdIndex = 1
        While _running and _any
            SyncLock _listLock
                _any = _sources.Any()
            End SyncLock
            While _paused
                
            End While
            If _thrdCntScrape <= _maxThrdScrape Then
                _dictScrape(thrdIndex.ToString) = New Thread(AddressOf ScrapeTask)
                _dictScrape(thrdIndex.ToString).IsBackground = True
                _dictScrape(thrdIndex.ToString).Start()
                _thrdCntScrape = _thrdCntScrape + 1
                thrdIndex = thrdIndex + 1
            End If
        End While
        Return True
    End Function

    Private Sub ScrapeTask()
        If _sources.Any() Then
            Dim scrpBefore = _scraped.Count
            Dim toScrape As String
            SyncLock _listLock
                toScrape = _sources.Item(0)
                _sources.RemoveAt(0)
            End SyncLock
            _scraped.AddRange(ScrapeLink(toScrape).Distinct().ToList())
            _thrdCntScrape = _thrdCntScrape - 1
            RaiseEvent SourceScraped(scrpBefore-_scraped.Count)
        End If
    End Sub

    'scrapes a given link for proxies
    Private Function ScrapeLink(link As String) As List(Of String)
        Dim proxies = New List(Of String)
        Try 'gets the entire web page as a string
            Dim r As HttpWebRequest = HttpWebRequest.Create(link)
            r.UserAgent = UserAgent
            r.Timeout = 15000
            Using sr As New StreamReader(r.GetResponse().GetResponseStream())
                proxies = ExtractProx(sr.ReadToEnd())
            End Using
            r.Abort()
            If proxies.Any() Then
                _hasResult.Add(link)
                ListBox1.Items.Add(link + " " + proxies.Count())
                If (ListBox1.Items.Count > 500) Then
                    ListBox1.Items.RemoveAt(0)
                End If
            Else
                _noResult.Add(link)
            End If
        Catch ex As Exception

        End Try
        'returns scraped result
        Return proxies
    End Function

    'finds all proxies in a given string, returns them as a List(Of String)
    Private Function ExtractProx(http As String) As List(Of String)
        Dim output = New List(Of String)

        For Each proxy As Match In Regex.Matches(http, Matches)
            output.Add(proxy.ToString())
        Next
        Return output
    End Function

    'loads all source links from internal resources
    Private Sub LoadSrc()
        Dim psrc As String = My.Resources.psrc
        _sources = psrc.Split("$").ToList()
        If Not _sources.Count > 0 Then
            LoadSrcWeb()
        End If
        _sources.RemoveAt(0)
    End Sub

    'fallback method, will remove to keep my sources safe
    Private Sub LoadSrcWeb()
        Dim client = New WebClient()
        Dim reader = New StreamReader(client.OpenRead(WebSrc))
        Dim temp As String = reader.ReadToEnd
        Dim tmpSrc As String() = temp.Split(SplitString)
        _sources = tmpSrc.ToList()
        _sources.RemoveAt(0)
    End Sub
    'END SCRAPER

    'CHECKER
    Function CheckHerder() As Boolean
        'AddHandler ProxyChecked, New ProxyCheckedEventHandler(AddressOf StepPB2)
        _scrapedTotal = _scraped.Count
        Dim thrdIndexC = 1
        While _scraped.Any() and _running
            While _paused

            End While
            If _thrdCntCheck <= _maxThrdCheck Then
                _dictCheck(thrdIndexC.ToString) = New Thread(AddressOf CheckTask)
                _dictCheck(thrdIndexC.ToString).IsBackground = True
                _dictCheck(thrdIndexC.ToString).Start()
                _thrdCntCheck = _thrdCntCheck + 1
                thrdIndexC = thrdIndexC + 1
            End If
        End While
        Return True
    End Function

    Private Sub CheckTask()
        If _scraped.Any() Then
            Dim toCheck As String
            Dim working As Boolean = False
            SyncLock _listLock
                toCheck = _scraped.Item(0)
                _scraped.RemoveAt(0)
            End SyncLock
            If CheckProxy(toCheck) and Not _working.contains(toCheck) Then
                _working.Add(toCheck)
                working = True
            End If
            _thrdCntCheck = _thrdCntCheck - 1
            RaiseEvent ProxyChecked(_scrapedTotal-_scraped.Count, working)
        End If
    End Sub

    'test single proxy
    Function CheckProxy(proxy As String) As Boolean
        Try 'uses azenv.net proxy judge
            Dim r As HttpWebRequest = HttpWebRequest.Create(Judge)
            r.UserAgent = UserAgent
            r.Timeout = 3000
            r.ReadWriteTimeout = 3000
            r.Proxy = New WebProxy(proxy)
            Using sr As New StreamReader(r.GetResponse().GetResponseStream())
                If sr.ReadToEnd().Contains(TestString) Then
                    r.Abort()
                    ListBox1.Items.Add(proxy)
                    If (ListBox1.Items.Count > 500) Then
                        ListBox1.Items.RemoveAt(0)
                    End If
                    Return True
                End If
            End Using
            r.Abort()
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    'END CHECKER

    'MISC FUNCTIONS
    Sub SaveFile(tempL As List(Of String))
        If (tempL.Any()) Then
            Dim fs As New SaveFileDialog
            fs.RestoreDirectory = True
            fs.Filter = PGV2_TxtFile
            fs.FilterIndex = 1
            fs.ShowDialog()
            If Not (fs.FileName = Nothing) Then
                Using sw As New StreamWriter(fs.FileName)
                    For Each line As String In tempL
                        sw.WriteLine(line)
                    Next
                End Using
            End If
        Else
           MessageBox.Show(PGV2_1)
        End If
    End Sub

    Function OpenFile() As List(Of String)
        Dim tempList = New List(Of String)
        Dim fo As New OpenFileDialog
        fo.RestoreDirectory = True
        fo.Filter = PGV2_TxtFile
        fo.FilterIndex = 1
        fo.ShowDialog()
        If Not (fo.FileName = Nothing) Then
            Using sr As New StreamReader(fo.FileName)
                Dim line as String
                Do
                    line = sr.ReadLine()
                    tempList.Add(line)
                Loop Until line is Nothing
            End Using
        End If

        return tempList
    End Function

    Sub CopyFile(copyL As List(Of String))
        Dim clip As String = String.Empty
        If copyL.Any() Then
            clip = String.Join(vbNewLine, copyL.ToArray())
            Clipboard.SetText(clip)
            MessageBox.Show(PGV2_7)
        Else
            MessageBox.Show(PGV2_6)
        End If
    End Sub
    'END MISC FUNCTIONS

    'EVENT HANDLING
    'Scraper Thread Trackbar
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        _maxThrdScrape = TrackBar1.Value
        NumericUpDown1.Value = TrackBar1.Value
    End Sub

    'Checker Thread Trackbar
    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        _maxThrdCheck = TrackBar2.Value
        NumericUpDown2.Value = TrackBar2.Value
    End Sub

    'Scraper Threads
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        _maxThrdScrape = NumericUpDown1.Value
        TrackBar1.Value = NumericUpDown1.Value
        Me.Update()
        RaiseEvent ChkThrdChanged(NumericUpDown1.Value)
    End Sub

    'Checker Threads
    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        _maxThrdCheck = NumericUpDown2.Value
        TrackBar2.Value = NumericUpDown2.Value
        Me.Update()
        RaiseEvent ScrpThrdChanged(NumericUpDown2.Value)
    End Sub

    'Save Scraped
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SaveFile(_scraped)
    End Sub

    'Save Working
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SaveFile(_working)
    End Sub

    'Load Custom Scrape
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        _sources = OpenFile()
        MessageBox.Show(_sources.Count + PGV2_sLoad)
    End Sub

    'Save Custom Scrape
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If _noResult.Any() Or _hasResult.Any() Then
            If _hasResult.Any() and My.Settings.WResult Then
                SaveFile(_hasResult)
            Else 
                SaveFile(_noResult.Concat(_hasResult))
            End If
        Else
            MessageBox.Show(PGV2_1)
        End If
    End Sub

    'Copy Scraped
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CopyFile(_scraped)
    End Sub

    'Load Custom Checker
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        _scraped = OpenFile()
        MessageBox.Show(_scraped.Count + PGV2_pLoad)
    End Sub

    'Save Custom Checker
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If _scraped.Any() Then
            SaveFile(_scraped)
        Else 
            MessageBox.Show(PGV2_1)
        End If
    End Sub

    'Copy Working Checker
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        CopyFile(_working)
    End Sub

    'Start Checker
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Not My.Settings.UseScraped And Not _scraped.Any() Then
            MessageBox.Show(PGV2_2)
            Return
        End If
        CheckHerder()
    End Sub

    'Start Scraper
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If My.Settings.IBSrc Then
            LoadSrc()
        Else
            If Not _sources.Any() Then
                MessageBox.Show(PGV2_3)
                Return
            End If
        End If
        ScrapeHerder()
    End Sub

    'QuickStart
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not _paused Then
            LoadSrc()
            _running = True
            If ScrapeHerder() Then
                CheckHerder()
            End If
            While _thrdCntCheck > 0 And _thrdCntScrape > 0 

            End While
            MessageBox.Show(PGV2_4)
            SaveFile(_working)
        Else 
            _paused = False
        End If
    End Sub

    'Pause
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        _paused = True
    End Sub

    'Stop
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        _running = False
        If _paused Then
            _paused = False
        End If
        While _thrdCntCheck > 0 And _thrdCntScrape > 0 

        End While
        MessageBox.Show(PGV2_5)
    End Sub

    'Inbuilt Sources
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        RaiseEvent IBSrcChanged(CheckBox1.Checked)
    End Sub

    'Only save w/results
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        RaiseEvent WResultChanged(CheckBox3.Checked)
    End Sub

    'Use Scraped
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        RaiseEvent UseScrapedChanged(CheckBox2.Checked())
    End Sub
    'END EVENT HANDLING

    'PROGRESS BAR EVENTS
    'Scraper
    Sub StepPb1()
        _srcCnt = _sources.Count
        _scrpCnt = _scraped.Count
        Dim pb2Val = Math.Round((1-(_srcCnt/_sourceTotal))*100)
        Dim pb3Val = Math.Round((1-(_srcCnt/_sourceTotal))*50) + Math.Round((1-(_scrpCnt/_scrapedTotal))*50)
        ProgressBar2.Invoke(Sub()
            ProgressBar2.Value = pb2Val
            Me.Update()
                            End Sub)
        ProgressBar3.Invoke(Sub()
            ProgressBar3.Value = pb3Val
            Me.Update()
                            End Sub)
        Me.Invoke(Sub()
                         Me.Update()
                     End Sub)
    End Sub

    Sub StepPb2()
        _scrpCnt = _scraped.Count
        _srcCnt = _sources.Count
        Dim pb1Val = Math.Round((1-(_scrpCnt/_scrapedTotal))*100)
        Dim pb3Val = Math.Round((1-(_srcCnt/_sourceTotal))*50) + Math.Round((1-(_scrpCnt/_scrapedTotal))*50)
        ProgressBar1.Invoke(Sub()
            ProgressBar1.Value = pb1Val
            Me.Update()
                            End Sub)
        ProgressBar3.Invoke(Sub()
            ProgressBar3.Value = pb3Val
            Me.Update()
                            End Sub)        
    End Sub
    'END PROGRESS BAR EVENTS

    'SETTINGS HANDLING
    Sub ChkThrdChangedHandler(ByVal threads As Integer)
        My.Settings.ChkThrd = threads
    End Sub

    Sub ScrpThrdChangedHandler(ByVal threads As Integer)
        My.Settings.ScrpThrd = threads
    End Sub

    Sub IBSrcChangedHandler(ByRef bool As Boolean)
        My.Settings.IBSrc = bool
    End Sub

    Sub WResultChangedHandler(ByRef bool As Boolean)
        My.Settings.WResult = bool
    End Sub

    Sub UseScrapedChangedHandler(ByRef bool As Boolean)
        My.Settings.UseScraped = bool
    End Sub
    'END SETTINGS HANDLING
End Class
