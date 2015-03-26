Module Mapping
#Region "Value Map"

    Private Value_Map(0 To 1024) As Long
    Private Const Set_Point As Long = 585 '//특정 저항값
    Private Const Set_STDev As Long = 7 '//특정 저항값 평균에 따른 표준 편차
    Private Const Set_Persent As Long = 39 '//특정 저항값일 때에 퍼센트

    Private Sub Set_Mapping(Point As Long, STDev As Long, Persent As Long)

        Dim i As Long
        Dim Min As Long
        Dim Max As Long
        Dim Current_Point As Long = Point
        Dim Current_Persent As Long = Persent

        '//기준점으로 부터 낮은 부분 맵핑 시작
        Do While Current_Point >= 0

            Current_Point -= STDev * 2
            Min = Current_Point - STDev
            Max = Current_Point + STDev
            Current_Persent += 1

            If Min < 0 Then Min = 0 '//배열 오류 해결

            For i = Min To Max
                Value_Map(i) = Current_Persent
            Next

        Loop

        '//기준점 맵핑
        Current_Persent = Persent
        Current_Point = Point
        Min = Current_Point - STDev
        Max = Current_Point + STDev

        For i = Min To Max
            Value_Map(i) = Current_Persent
        Next

        '//기준점으로 부터 큰 부분 맵핑 시작
        Do While Current_Point <= 1024

            Current_Point += STDev * 2
            Min = Current_Point - STDev
            Max = Current_Point + STDev
            Current_Persent -= 1

            If Max > 1024 Then Max = 1024 '//배열 오류 해결

            For i = Min To Max
                Value_Map(i) = Current_Persent
            Next

        Loop

    End Sub

#End Region
#Region "Value Convert Section"
    Function Convert(ByVal Value As Long) As Long

        If Value_Map(0) = 0 Then Set_Mapping(Set_Point, Set_STDev, Set_Persent)

        Return Value_Map(Value)

    End Function

    Function DeConvert(ByVal Value As Long) As Long
        If Value_Map(0) = 0 Then Set_Mapping(Set_Point, Set_STDev, Set_Persent)

        Dim i As Long

        For i = 0 To 1024

            If Value_Map(i) = Value Then Exit For

        Next

        Return Value_Map(i)
    End Function
#End Region
End Module
