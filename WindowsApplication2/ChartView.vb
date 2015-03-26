Public Class ChartView

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Start_Pos As Long = txt_Start.Text
        Dim End_Pos As Long = txt_End.Text
        Dim Main_Chart As System.Windows.Forms.DataVisualization.Charting.Chart = Main.ct_sensor
        Dim Copy_Chart As System.Windows.Forms.DataVisualization.Charting.Chart = Me.ct_sensor

        If Start_Pos < 0 Then MsgBox("시작점은 0 이하의 값을 설정할 수 없습니다.", vbCritical, "오류") : Exit Sub
        If End_Pos > Main_Chart.Series(0).Points.Count - 1 Then MsgBox("끝점은 " & Main_Chart.Series(0).Points.Count - 1 & "이상의 값을 설정할 수 없습니다.", vbCritical, "오류") : Exit Sub

        Copy_Chart.Series(0).Points.Clear()

        For i As Integer = Start_Pos To End_Pos

            Copy_Chart.Series(0).Points.AddXY(i, Main_Chart.Series(0).Points.Item(i).YValues(0))

        Next


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Copy_Chart As System.Windows.Forms.DataVisualization.Charting.Chart = Me.ct_sensor
        Copy_Chart.Series(0).Points.Clear()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.Width < 800 Then Me.Width = 800
        If Me.Height < 500 Then Me.Height = 500

        GroupBox1.SetBounds(GroupBox1.Location.X, Me.Height - 100, GroupBox1.Width, GroupBox1.Height)
        ct_sensor.SetBounds(ct_sensor.Location.X, ct_sensor.Location.Y, Me.Width - 40, Me.Height - 120)


    End Sub
End Class