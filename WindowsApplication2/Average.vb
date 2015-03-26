Imports System.IO

Module Average


    Private Const STDev As Double = 0.3 '//데이터 무작위 제거 배수
    Private Const STDelay As Double = 0.7 '//데이터 스택 시간 배수
    Dim Log_FileNums As Integer
    Dim Log_FileNames As String
    Dim Raw_temp As Long = 1

    Public Sub Start_Log()
        On Error Resume Next

        Dim Path As String = Application.StartupPath & "\log\" & Main.Start_Time & "S.txt"
        Dim fileExists As Boolean = File.Exists(Path)

        MkDir(Application.StartupPath & "\log")

        If fileExists = False Then
            Dim Logging As New StreamWriter(Path)
            Logging.Close()
        End If

        Log_FileNums = FreeFile()
        Log_FileNames = Path

        FileOpen(Log_FileNums, Log_FileNames, OpenMode.Append)

    End Sub

    Public Sub Write_Log(Strings As String)

        Dim Time As Date = Date.Now
        Raw_temp += 1

        Print(Log_FileNums, Raw_temp - 1 & vbTab & Time.Date & vbTab & Time.Hour & ":" & Time.Minute & ":" & Time.Second & "." & Time.Millisecond & vbTab & Strings & vbCrLf)

    End Sub

    Public Sub Finish_Log()

        FileClose(Log_FileNums)
        Raw_temp = 1

    End Sub

    Public Function Data_Average(Data() As Long) As Long

        Dim Data_Max As Long = 0
        Dim Data_Min As Long = 0
        Dim Data_Sum As Long = 0
        Dim Data_Array As Long = UBound(Data) + 1
        Dim temp As String = ""

        Debug.Print("K " & UBound(Data))
        For i As Long = 0 To UBound(Data)

            'If Not (Data(i) = 0) Then
            temp = temp & Data(i) & "    "
            ' End If
        Next

        Debug.Print(temp)


        '// 데이터의 최대, 최소를 찾음면서, 전체의 합을 구합니다.
        For i As Long = 0 To UBound(Data)
            If Data(i) > Data_Max Then Data_Max = Data(i)
            If Data(i) < Data_Min Then Data_Min = Data(i)
            If Data(i) = 0 Then Data_Array -= 1
            Data_Sum += Data(i)
        Next

        'Dim Data_Range As Long = Data_Max - Data_Min

        '// 무작위로 STDev 배수 만큼 전체의 합에서 제거합니다.
        'Randomize()
        'For i As Long = 0 To Int(UBound(Data) * STDev)

        '    Dim Rnd_Temp As Long = Rnd() * (UBound(Data) - 0) + 0
        '    Data_Sum -= Data(Rnd_Temp)

        'Next i

        '// 전체 배열 갯수가 2이거나 작으면 오류가 발생하기 떄문에 그전에 값 리턴
        'If Data_Array <= 2 Then Return Int(Data_Sum / Data_Array)


        'Data_Sum -= Data_Max
        'Data_Sum -= Data_Min
        'Data_Array -= 2

        '// 값이 없을 경우

        If Data_Array = 0 Then Return 0

        Write_Log(" 평균 :" & Int(Data_Sum / Data_Array) & " 전체합 : " & Data_Sum & " 배열 수 " & UBound(Data) + 1 & "/" & Data_Array & " 배열 전체 : " & temp)

        '// 값을 반환 합니다.
        Return Int(Data_Sum / Data_Array)

    End Function

    Public Function Sum_StackTime(Delay As Long) As Long
        Return Int(Delay * STDelay)
    End Function

End Module
