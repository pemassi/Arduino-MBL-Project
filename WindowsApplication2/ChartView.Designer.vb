<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartView
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim CustomLabel1 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.ct_sensor = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_End = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Start = New System.Windows.Forms.TextBox()
        CType(Me.ct_sensor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ct_sensor
        '
        CustomLabel1.Text = "ㅇㅇㅇ"
        ChartArea1.AxisX2.CustomLabels.Add(CustomLabel1)
        ChartArea1.Name = "ChartArea1"
        Me.ct_sensor.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.ct_sensor.Legends.Add(Legend1)
        Me.ct_sensor.Location = New System.Drawing.Point(12, 12)
        Me.ct_sensor.Name = "ct_sensor"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Legend = "Legend1"
        Series1.Name = "센서 1"
        Me.ct_sensor.Series.Add(Series1)
        Me.ct_sensor.Size = New System.Drawing.Size(760, 380)
        Me.ct_sensor.TabIndex = 12
        Me.ct_sensor.Text = "Chart1"
        Me.ct_sensor.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txt_End)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_Start)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 400)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 50)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "설정"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(309, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "보기"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_End
        '
        Me.txt_End.Location = New System.Drawing.Point(203, 21)
        Me.txt_End.Name = "txt_End"
        Me.txt_End.Size = New System.Drawing.Size(100, 21)
        Me.txt_End.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "끝점"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "시작점"
        '
        'txt_Start
        '
        Me.txt_Start.Location = New System.Drawing.Point(53, 20)
        Me.txt_Start.Name = "txt_Start"
        Me.txt_Start.Size = New System.Drawing.Size(100, 21)
        Me.txt_Start.TabIndex = 14
        '
        'ChartView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ct_sensor)
        Me.Name = "ChartView"
        Me.Text = "Chart View"
        CType(Me.ct_sensor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ct_sensor As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_End As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Start As System.Windows.Forms.TextBox
End Class
