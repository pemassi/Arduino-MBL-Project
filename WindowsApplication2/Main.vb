Imports System.IO
Imports System.IO.Ports
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class Main

    Dim WithEvents SerialPort As New IO.Ports.SerialPort

    Delegate Sub myMethodDelegate(ByVal [text] As String)

    Dim myD1 As New myMethodDelegate(AddressOf myShowStringMethod)
    Dim myD2 As New myMethodDelegate(AddressOf chgCB)
    Dim myD3 As New myMethodDelegate(AddressOf chgCB2)
    Dim myD4 As New myMethodDelegate(AddressOf reFound)

    Dim Finish_Stopwatch As Stopwatch = New Stopwatch
    Dim Count_Stopwatch As Stopwatch = New Stopwatch
    Dim Full_Stopwatch As Stopwatch = New Stopwatch

    Dim Log_FileNum As Integer
    Dim Log_FileName As String

    Public Timer_temp As Long = 0 '// 측정 시작 후 지난 시간 
    Public Start_Time As String '// 측정 시작 시간

    Dim test_Count As Long = 0 '// 테스트 관련 플래그
    Dim Raw_temp As Long '// Excel 저장시 사용되는 열

    Dim Data_Stack(0) As Long
    Dim Data_Array_Count As Long = 0

    '// Excel 관련 선언
    Dim oXL As Object
    Dim oWB As Object
    Dim oSheet As Object
    Dim oRng As Object
#Region "About Serial"
    Private Sub myShowStringMethod(ByVal myString As String)
        On Error Resume Next
        Dim Return_Data As String = myString


        If Mid(myString, 1, 1) = "M" Then

            Return_Data = Split(myString, "M")(1)

        End If


        '// 넘어온 데이터가 빈 데이터라면 무시
        If Return_Data = vbNullString Then Exit Sub

        '// 아두이노 버퍼 밀리는 현상 해결
        If InStr(Return_Data, "M") <> 0 Then Exit Sub

        '// Crlf 가 없던 현상 해결
        Return_Data = Replace(Return_Data, vbCrLf, vbNullString)

        '//측정 간격 시간이 되지 않았을 경우에 정해진 시간 전까지 데이터 스택
        If Count_Stopwatch.ElapsedMilliseconds > Average.Sum_StackTime(txt_delay.Text) Then
            ReDim Preserve Data_Stack(Data_Array_Count)
            Data_Stack(Data_Array_Count) = Return_Data
            Data_Array_Count += 1
        End If

        '//측정 간격 시간이 아닌 경우 무시
        If Count_Stopwatch.ElapsedMilliseconds < txt_delay.Text Then Exit Sub

        '//데이터 스택 평균값 계산
        Return_Data = Data_Average(Data_Stack)

        '//데이터가 없을 경우 스킵
        If Return_Data = 0 Then Exit Sub

        '//기록
        Wirte_Log(Application.StartupPath & "\log\" & Start_Time & ".txt", Return_Data)

        '//화면 업데이트
        Display_Update(Return_Data)

        '//딜레이 타이머 리셋
        Count_Stopwatch.Restart()

        '//스택 리셋
        ReDim Data_Stack(0)
        Data_Array_Count = 0
    End Sub
    Private Sub Serialport_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Dim str As String = SerialPort.ReadExisting()
        Try

            Invoke(myD1, str)

        Catch ex As Exception

            lb_Status.Text = ex.Message

        End Try
    End Sub
    Sub chgCB(Str As String)
        cb_port.Items.Add(Str)
    End Sub
    Sub chgCB2(Str As String)
        cb_port.Text = Str
        btn_Connect.Enabled = True
        btn_Connect.Text = "연결"
    End Sub
    Sub reFound(Str As String)
        btn_Connect.Text = "다시찾기"
        btn_Connect.Enabled = True
    End Sub
    Sub Send_Serial(Strings As String)
        On Error Resume Next
        If SerialPort.IsOpen Then
            SerialPort.Write(Strings)
            lb_Status.Text = "데이터를 전송 합니다 - " & SerialPort.PortName & " : " & Strings
        Else
            lb_Status.Text = "연결 되지 않았습니다"
        End If
    End Sub
    Private Sub ConnectSerial(Port As String)
        Try
            lb_Status.Text = "연결 시도 중 입니다 - " & Port

            SerialPort.Parity = Parity.None
            SerialPort.StopBits = StopBits.One
            SerialPort.Handshake = Handshake.None
            SerialPort.Encoding = System.Text.Encoding.Default
            SerialPort.BaudRate = 9600
            SerialPort.PortName = Port
            SerialPort.DtrEnable = True

            SerialPort.Open()

            lb_Status.Text = "연결되었습니다 - " & Port
            btn_start.Enabled = True
            btn_Connect.Text = "끊기"
        Catch
            SerialPort.Close()
            lb_Status.Text = "연결실패 - " & Port
        End Try
    End Sub
    Private Sub Auto_Serial_Found()

        Dim SerialPorts As New IO.Ports.SerialPort
        Dim Port As String

        Dim i As Long
        For i = 5 To 255

            If SerialPorts.IsOpen Then SerialPorts.Close() : Debug.Print("CLOSE" & i)
            Port = "COM" & i

            lb_Status.Text = "자동 포트 찾기 진행 중"

            Try

                SerialPort.Parity = Parity.None
                SerialPort.StopBits = StopBits.One
                SerialPort.Handshake = Handshake.None
                SerialPort.Encoding = System.Text.Encoding.Default
                SerialPort.BaudRate = 9600
                SerialPort.PortName = Port
                SerialPort.DtrEnable = True
                SerialPort.Open()

                Invoke(myD2, Port)
                lb_Status.Text = "자동 포트 찾기 완료" & Port
            Catch

                SerialPort.Close()

            End Try

        Next

        lb_Status.Text = "자동 포트 찾기 완료"
        If cb_port.Items.Count = 0 Then
            lb_Status.Text = "발견된 포트가 없습니다. '다시찾기'를 눌러주세요."
            Invoke(myD4, "")
        Else
            Invoke(myD3, cb_port.Items.Item(0))
        End If

    End Sub
#End Region
#Region "Connect Button"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn_Connect.Click
        If btn_Connect.Text = "연결" Then

            Call ConnectSerial(cb_port.Text)

        ElseIf btn_Connect.Text = "끊기" Then

            If btn_stop.Enabled = True Then btn_stop.PerformClick()

            lb_Status.Text = "연결을 끊었습니다. - " & SerialPort.PortName

            btn_start.Enabled = False
            btn_send.Enabled = False
            btn_Connect.Text = "연결"

            If SerialPort.IsOpen Then SerialPort.Close()

        ElseIf btn_Connect.Text = "다시찾기" Then

            Dim Serial_Threads As New System.Threading.Thread(AddressOf Auto_Serial_Found)
            Serial_Threads.Start()
            btn_Connect.Enabled = False

        End If

        If cb_port.Text = "test" Then

            btn_start.Enabled = True
            btn_send.Enabled = True

        End If

    End Sub
#End Region
#Region "Start Button"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_start.Click
        On Error Resume Next

        If txt_delay.Text.ToString = vbNullString Then txt_delay.Text = "100"
        If txt_h.Text.ToString = vbNullString Then txt_h.Text = "0"
        If txt_m.Text.ToString = vbNullString Then txt_m.Text = "0"
        If txt_s.Text.ToString = vbNullString Then txt_s.Text = "0"
        If txt_ms.Text.ToString = vbNullString Then txt_ms.Text = "0"


        If txt_delay.Text < 100 Then MsgBox("측정 간격은 100ms 이상 부터 가능합니다.", vbCritical, "측정 간격 오류") : Exit Sub
        If MsgBox("측정을 시작하시겠습니까?" & vbCrLf & vbCrLf &
                 "측정 간격 : " & txt_delay.Text & vbCrLf &
                 "총 측정 시간 : " & IIf((txt_h.Text = 0) AndAlso (txt_m.Text = 0) AndAlso (txt_ms.Text = 0) AndAlso (txt_s.Text = 0), "제한 없음",
                 txt_h.Text & ":" & txt_m.Text & ":" & txt_s.Text & "." & txt_ms.Text) & vbCrLf & vbCrLf &
                 "예상 기록 갯수 : " & ((txt_h.Text * 3600000) + (txt_m.Text * 60000) + (txt_s.Text * 1000) + txt_ms.Text) / txt_delay.Text,
                 vbYesNo + vbInformation, "측정 시작") = vbNo Then Exit Sub


        Timer_temp = 0
        Raw_temp = 1

        Send_Serial("S")

        '///////////////////////////////////

        btn_start.Enabled = False
        btn_stop.Enabled = True

        Rad_Txt.Enabled = False
        Rad_xlsx.Enabled = False

        txt_delay.Enabled = False
        txt_h.Enabled = False
        txt_m.Enabled = False
        txt_s.Enabled = False
        txt_ms.Enabled = False

        If Not ((txt_h.Text = 0) AndAlso (txt_m.Text = 0) AndAlso (txt_ms.Text = 0) AndAlso (txt_s.Text = 0)) Then tim_Finish.Enabled = True

        '///////////////////////////////////

        Dim Time As Date
        Time = Date.Now
        Start_Time = Time.Date & "-" & Time.Hour & "-" & Time.Minute & "-" & Time.Second

        If cb_port.Text = "test" Then Timer1.Enabled = True

        If Rad_xlsx.Checked = True Then

            oXL = CreateObject("Excel.Application")
            oXL.Visible = False
            oXL.DisplayAlerts = False

            oWB = oXL.Workbooks.Add
            oSheet = oWB.ActiveSheet

            oSheet.Cells(1, 1).value = "Index"
            oSheet.Cells(1, 2).Value = "날짜"
            oSheet.Cells(1, 3).Value = "시간"
            oSheet.Cells(1, 4).Value = "센서 1 값"
            oSheet.Cells(1, 5).Value = "측정 시작 시간"
            oSheet.Cells(1, 6).Value = Time.Date & "-" & Time.Hour & ":" & Time.Minute & ":" & Time.Second & ":" & Time.Millisecond

        Else

            Dim Path As String = Application.StartupPath & "\log\" & Start_Time & ".txt"
            Dim fileExists As Boolean = File.Exists(Path)

            MkDir(Application.StartupPath & "\log")

            If fileExists = False Then
                Dim Logging As New StreamWriter(Path)
                Logging.Close()
            End If

            Log_FileNum = FreeFile()
            Log_FileName = Path

            FileOpen(Log_FileNum, Log_FileName, OpenMode.Append)

            Print(Log_FileNum, "측정 시작 날짜 " & vbTab & vbCrLf)
            Print(Log_FileNum, "측정 시작 시각 " & vbTab & Time.Hour & ":" & Time.Minute & ":" & Time.Second & "." & Time.Millisecond & vbCrLf)
            Print(Log_FileNum, "Index " & vbTab & "날짜" & vbTab & "시간" & vbTab & "센서1값" & vbCrLf)


        End If

        '//그래프 리셋
        ct_sensor.Series(0).Points.Clear()

        '//측정 시간 시작
        Finish_Stopwatch.Restart()
        Count_Stopwatch.Restart()
        Full_Stopwatch.Restart()

        Average.Start_Log()
    End Sub
#End Region
#Region "Stop Button"
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btn_stop.Click
        On Error Resume Next

        Timer_temp = 0

        Send_Serial("F")

        '///////////////////////////////////

        btn_start.Enabled = True
        btn_stop.Enabled = False

        Rad_Txt.Enabled = True
        Rad_xlsx.Enabled = True

        txt_delay.Enabled = True
        txt_h.Enabled = True
        txt_m.Enabled = True
        txt_s.Enabled = True
        txt_ms.Enabled = True

        Count_Stopwatch.Stop()
        Finish_Stopwatch.Stop()
        Full_Stopwatch.Stop()

        tim_Finish.Enabled = False

        '///////////////////////////////////

        If cb_port.Text = "test" Then Timer1.Enabled = False
        If Rad_xlsx.Checked = True Then

            '셀 사이즈 내용 맞추기
            oRng = oSheet.Range("A1", "G" & Raw_temp)
            oRng.EntireColumn.AutoFit()

            MkDir(Application.StartupPath & "\Log")

            Dim path_temp As String = Application.StartupPath & "\Log\" & Start_Time & ".xlsx"

            If File.Exists(path_temp) = True Then path_temp += "E"

            oSheet.SaveAs(path_temp)

            oWB.Close()
            oXL.Quit()

            ReleaseObject(oRng)
            ReleaseObject(oSheet)
            ReleaseObject(oWB)
            ReleaseObject(oXL)
        Else
            FileClose(Log_FileNum)
        End If

        '// 스크린샷
        Dim SC As New ScreenShot.ScreenCapture
        SC.CaptureWindowToFile(ct_sensor.Handle, Application.StartupPath & "\Log\" & Start_Time & ".png", Imaging.ImageFormat.Png)

        Average.Finish_Log()

        MsgBox("측정 및 저장이 완료되었습니다." & vbCrLf & vbCrLf &
               "기록 파일 저장 경로 : " & Application.StartupPath & "\Log\" & vbCrLf & vbCrLf &
               "총 측정 시간 : " & Full_Stopwatch.Elapsed.ToString & vbCrLf &
               "기록 갯수 : " & Raw_temp, vbInformation, "측정 완료")


    End Sub
    Private Sub ReleaseObject(ByRef obj As Object)
        Try
            Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
#End Region
#Region "Write Log"
    Public Sub Wirte_Log(Path As String, Strings As String)
        On Error GoTo Err_Step

        Dim Time As Date = Date.Now
        Raw_temp += 1

        If Rad_Txt.Checked = True Then
            'Dim FileNum As Integer
            'Dim FileName As String
            


            'FileOpen(Log_FileNum, Log_FileName, OpenMode.Append)

            Print(Log_FileNum, Raw_temp - 1 & vbTab & Time.Date & vbTab & Time.Hour & ":" & Time.Minute & ":" & Time.Second & "." & Time.Millisecond & vbTab & Strings & vbCrLf)

            'FileClose(Log_FileNum)

        Else
            Dim temp As String
            temp = Time.Hour & ":" & Time.Minute & ":" & Time.Second & ":" & Time.Millisecond
            oSheet.Cells(Raw_temp, 1).Value = Raw_temp - 1
            oSheet.Cells(Raw_temp, 2).Value = Time.Date
            oSheet.Cells(Raw_temp, 3).Value = temp
            oSheet.Cells(Raw_temp, 4).Value = Strings
        End If
        Exit Sub

Err_Step:
        Raw_temp -= 1

    End Sub
#End Region
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        If btn_stop.Enabled = True Then btn_stop.PerformClick()
        If SerialPort.IsOpen = True Then SerialPort.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '차트 데이터 설정
        ct_sensor.Series(0).MarkerColor = System.Drawing.Color.Red

        '포트 자동 찾기 쓰레드 실행
        Dim Serial_Thread As New System.Threading.Thread(AddressOf Auto_Serial_Found)
        Serial_Thread.Start()

        '스탑워치 관련 리셋
        Finish_Stopwatch.Reset()
        Count_Stopwatch.Reset()
        Full_Stopwatch.Reset()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_send.Click

        On Error Resume Next
        Send_Serial(txt_Send.Text)

    End Sub
    Private Sub Display_Update(Str As String)

        Dim Time As Date = Now

        '//데이터 로그 추력
        'txt_Serial.AppendText(Time.TimeOfDay.ToString & " - " & Str & vbCrLf)
        lb_Value.Text = Str

        '//그래프 업데이트
        ct_sensor.Series(0).Points.AddXY(Timer_temp, Str)
        Timer_temp += txt_delay.Text / 1000

    End Sub
    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles Rad_Txt.Click
        Rad_Txt.Checked = True
        Rad_xlsx.Checked = False
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles Rad_xlsx.Click
        Rad_xlsx.Checked = True
        Rad_Txt.Checked = False
    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ct_sensor.Width = Me.Width - 280
        ct_sensor.Height = Me.Height - 80
        gb_Control.Top = Me.Height - 330
        gbstatus.Height = Me.Height - (gb_Control.Height + 105)
        If Me.Width < 660 Then Me.Width = 660
        If Me.Height < 510 Then Me.Height = 510
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lb_port.Click
        Dim Serial_Threads As New System.Threading.Thread(AddressOf Auto_Serial_Found)
        Serial_Threads.Start()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)
        btn_start.Enabled = True
        btn_Connect.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        myShowStringMethod("M" & test_Count & vbCrLf)
        myShowStringMethod(test_Count & vbCrLf)
        test_Count += 1
        If test_Count = 1024 Then test_Count = 0

    End Sub

    Private Sub tim_Finish_Tick(sender As Object, e As EventArgs) Handles tim_Finish.Tick
        If Finish_Stopwatch.ElapsedMilliseconds.ToString >= (txt_h.Text * 3600000) + (txt_m.Text * 60000) + (txt_s.Text * 1000) + txt_ms.Text Then
            tim_Finish.Enabled = False
            btn_stop.PerformClick()
        End If
    End Sub

    Private Sub ct_sensor_Click(sender As Object, e As EventArgs) Handles ct_sensor.Click
        ChartView.ShowDialog()

    End Sub

End Class
