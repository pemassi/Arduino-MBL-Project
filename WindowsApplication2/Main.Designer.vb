<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim CustomLabel1 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btn_Connect = New System.Windows.Forms.Button()
        Me.lb_port = New System.Windows.Forms.Label()
        Me.cb_port = New System.Windows.Forms.ComboBox()
        Me.ct_sensor = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btn_send = New System.Windows.Forms.Button()
        Me.txt_Send = New System.Windows.Forms.TextBox()
        Me.btn_start = New System.Windows.Forms.Button()
        Me.btn_stop = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rad_xlsx = New System.Windows.Forms.RadioButton()
        Me.Rad_Txt = New System.Windows.Forms.RadioButton()
        Me.gb_Control = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_ms = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_s = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_m = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_h = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_delay = New System.Windows.Forms.TextBox()
        Me.lb_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status = New System.Windows.Forms.StatusStrip()
        Me.tim_Finish = New System.Windows.Forms.Timer(Me.components)
        Me.gbstatus = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lb_Value = New System.Windows.Forms.Label()
        CType(Me.ct_sensor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gb_Control.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Status.SuspendLayout()
        Me.gbstatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'btn_Connect
        '
        Me.btn_Connect.Enabled = False
        Me.btn_Connect.Location = New System.Drawing.Point(174, 12)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(75, 23)
        Me.btn_Connect.TabIndex = 6
        Me.btn_Connect.Text = "연결"
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'lb_port
        '
        Me.lb_port.AutoSize = True
        Me.lb_port.Location = New System.Drawing.Point(12, 17)
        Me.lb_port.Name = "lb_port"
        Me.lb_port.Size = New System.Drawing.Size(29, 12)
        Me.lb_port.TabIndex = 7
        Me.lb_port.Text = "포트"
        '
        'cb_port
        '
        Me.cb_port.FormattingEnabled = True
        Me.cb_port.Location = New System.Drawing.Point(47, 12)
        Me.cb_port.Name = "cb_port"
        Me.cb_port.Size = New System.Drawing.Size(121, 20)
        Me.cb_port.TabIndex = 8
        Me.cb_port.Text = "선택해주세요."
        '
        'ct_sensor
        '
        CustomLabel1.Text = "ㅇㅇㅇ"
        ChartArea1.AxisX2.CustomLabels.Add(CustomLabel1)
        ChartArea1.Name = "ChartArea1"
        Me.ct_sensor.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.ct_sensor.Legends.Add(Legend1)
        Me.ct_sensor.Location = New System.Drawing.Point(255, 12)
        Me.ct_sensor.Name = "ct_sensor"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Legend = "Legend1"
        Series1.Name = "센서 1"
        Me.ct_sensor.Series.Add(Series1)
        Me.ct_sensor.Size = New System.Drawing.Size(377, 433)
        Me.ct_sensor.TabIndex = 11
        Me.ct_sensor.Text = "Chart1"
        Me.ct_sensor.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal
        '
        'btn_send
        '
        Me.btn_send.Location = New System.Drawing.Point(158, 233)
        Me.btn_send.Name = "btn_send"
        Me.btn_send.Size = New System.Drawing.Size(75, 23)
        Me.btn_send.TabIndex = 2
        Me.btn_send.Text = "명령 전송"
        Me.btn_send.UseVisualStyleBackColor = True
        '
        'txt_Send
        '
        Me.txt_Send.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Send.Location = New System.Drawing.Point(6, 233)
        Me.txt_Send.Name = "txt_Send"
        Me.txt_Send.Size = New System.Drawing.Size(146, 21)
        Me.txt_Send.TabIndex = 3
        '
        'btn_start
        '
        Me.btn_start.Enabled = False
        Me.btn_start.Location = New System.Drawing.Point(6, 206)
        Me.btn_start.Name = "btn_start"
        Me.btn_start.Size = New System.Drawing.Size(102, 21)
        Me.btn_start.TabIndex = 9
        Me.btn_start.Text = "측정 시작"
        Me.btn_start.UseVisualStyleBackColor = True
        '
        'btn_stop
        '
        Me.btn_stop.Enabled = False
        Me.btn_stop.Location = New System.Drawing.Point(132, 206)
        Me.btn_stop.Name = "btn_stop"
        Me.btn_stop.Size = New System.Drawing.Size(101, 21)
        Me.btn_stop.TabIndex = 10
        Me.btn_stop.Text = "측정 정지"
        Me.btn_stop.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "log 폴더에 측정 완료 후 저장됩니다."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rad_xlsx)
        Me.GroupBox1.Controls.Add(Me.Rad_Txt)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 134)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 50)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "기록 방법"
        '
        'Rad_xlsx
        '
        Me.Rad_xlsx.AutoSize = True
        Me.Rad_xlsx.Location = New System.Drawing.Point(120, 20)
        Me.Rad_xlsx.Name = "Rad_xlsx"
        Me.Rad_xlsx.Size = New System.Drawing.Size(81, 16)
        Me.Rad_xlsx.TabIndex = 1
        Me.Rad_xlsx.Text = "엑셀(xlsx)"
        Me.Rad_xlsx.UseVisualStyleBackColor = True
        '
        'Rad_Txt
        '
        Me.Rad_Txt.AutoSize = True
        Me.Rad_Txt.Checked = True
        Me.Rad_Txt.Location = New System.Drawing.Point(18, 20)
        Me.Rad_Txt.Name = "Rad_Txt"
        Me.Rad_Txt.Size = New System.Drawing.Size(82, 16)
        Me.Rad_Txt.TabIndex = 0
        Me.Rad_Txt.TabStop = True
        Me.Rad_Txt.Text = "텍스트(txt)"
        Me.Rad_Txt.UseVisualStyleBackColor = True
        '
        'gb_Control
        '
        Me.gb_Control.Controls.Add(Me.GroupBox3)
        Me.gb_Control.Controls.Add(Me.GroupBox2)
        Me.gb_Control.Controls.Add(Me.GroupBox1)
        Me.gb_Control.Controls.Add(Me.Label1)
        Me.gb_Control.Controls.Add(Me.btn_stop)
        Me.gb_Control.Controls.Add(Me.btn_start)
        Me.gb_Control.Controls.Add(Me.txt_Send)
        Me.gb_Control.Controls.Add(Me.btn_send)
        Me.gb_Control.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.gb_Control.Location = New System.Drawing.Point(10, 180)
        Me.gb_Control.Name = "gb_Control"
        Me.gb_Control.Size = New System.Drawing.Size(239, 265)
        Me.gb_Control.TabIndex = 2
        Me.gb_Control.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txt_ms)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txt_s)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txt_m)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txt_h)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(227, 50)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "측정 시간(0 일경우 계속 측정)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(196, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "ms"
        '
        'txt_ms
        '
        Me.txt_ms.Location = New System.Drawing.Point(162, 20)
        Me.txt_ms.Name = "txt_ms"
        Me.txt_ms.Size = New System.Drawing.Size(30, 21)
        Me.txt_ms.TabIndex = 6
        Me.txt_ms.Text = "0"
        Me.txt_ms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(144, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "s"
        '
        'txt_s
        '
        Me.txt_s.Location = New System.Drawing.Point(110, 20)
        Me.txt_s.Name = "txt_s"
        Me.txt_s.Size = New System.Drawing.Size(30, 21)
        Me.txt_s.TabIndex = 4
        Me.txt_s.Text = "0"
        Me.txt_s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(92, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "m"
        '
        'txt_m
        '
        Me.txt_m.Location = New System.Drawing.Point(58, 20)
        Me.txt_m.Name = "txt_m"
        Me.txt_m.Size = New System.Drawing.Size(30, 21)
        Me.txt_m.TabIndex = 2
        Me.txt_m.Text = "0"
        Me.txt_m.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "h"
        '
        'txt_h
        '
        Me.txt_h.Location = New System.Drawing.Point(6, 20)
        Me.txt_h.Name = "txt_h"
        Me.txt_h.Size = New System.Drawing.Size(30, 21)
        Me.txt_h.TabIndex = 0
        Me.txt_h.Text = "0"
        Me.txt_h.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txt_delay)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 50)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "측정 딜레이(기록 딜레이)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ms"
        '
        'txt_delay
        '
        Me.txt_delay.Location = New System.Drawing.Point(6, 20)
        Me.txt_delay.Name = "txt_delay"
        Me.txt_delay.Size = New System.Drawing.Size(183, 21)
        Me.txt_delay.TabIndex = 0
        Me.txt_delay.Text = "500"
        Me.txt_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lb_Status
        '
        Me.lb_Status.Name = "lb_Status"
        Me.lb_Status.Size = New System.Drawing.Size(0, 17)
        '
        'Status
        '
        Me.Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lb_Status})
        Me.Status.Location = New System.Drawing.Point(0, 448)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(641, 22)
        Me.Status.TabIndex = 5
        Me.Status.Text = "StatusStrip1"
        '
        'tim_Finish
        '
        '
        'gbstatus
        '
        Me.gbstatus.Controls.Add(Me.lb_Value)
        Me.gbstatus.Controls.Add(Me.Label7)
        Me.gbstatus.Location = New System.Drawing.Point(10, 42)
        Me.gbstatus.Name = "gbstatus"
        Me.gbstatus.Size = New System.Drawing.Size(239, 132)
        Me.gbstatus.TabIndex = 12
        Me.gbstatus.TabStop = False
        Me.gbstatus.Text = "상태"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "현재 센서 값 : "
        '
        'lb_Value
        '
        Me.lb_Value.AutoSize = True
        Me.lb_Value.Location = New System.Drawing.Point(95, 26)
        Me.lb_Value.Name = "lb_Value"
        Me.lb_Value.Size = New System.Drawing.Size(11, 12)
        Me.lb_Value.TabIndex = 1
        Me.lb_Value.Text = "0"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 470)
        Me.Controls.Add(Me.gbstatus)
        Me.Controls.Add(Me.gb_Control)
        Me.Controls.Add(Me.ct_sensor)
        Me.Controls.Add(Me.cb_port)
        Me.Controls.Add(Me.lb_port)
        Me.Controls.Add(Me.btn_Connect)
        Me.Controls.Add(Me.Status)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Arduino MBL Project"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.ct_sensor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb_Control.ResumeLayout(False)
        Me.gb_Control.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Status.ResumeLayout(False)
        Me.Status.PerformLayout()
        Me.gbstatus.ResumeLayout(False)
        Me.gbstatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btn_Connect As System.Windows.Forms.Button
    Friend WithEvents lb_port As System.Windows.Forms.Label
    Friend WithEvents cb_port As System.Windows.Forms.ComboBox
    Friend WithEvents ct_sensor As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents btn_send As System.Windows.Forms.Button
    Friend WithEvents txt_Send As System.Windows.Forms.TextBox
    Friend WithEvents btn_start As System.Windows.Forms.Button
    Friend WithEvents btn_stop As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rad_xlsx As System.Windows.Forms.RadioButton
    Friend WithEvents Rad_Txt As System.Windows.Forms.RadioButton
    Friend WithEvents gb_Control As System.Windows.Forms.GroupBox
    Friend WithEvents lb_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Status As System.Windows.Forms.StatusStrip
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_ms As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_s As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_m As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_h As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_delay As TextBox
    Friend WithEvents tim_Finish As Timer
    Friend WithEvents gbstatus As System.Windows.Forms.GroupBox
    Friend WithEvents lb_Value As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
