Imports DevExpress.Utils
Imports DevExpress.XtraCharts
Imports System
Imports System.Collections.ObjectModel
Imports System.Windows.Forms

Namespace RealTimeChartUpdates
    Public Partial Class Form1
        Inherits Form

        Const ViewportPointCount = 100
        Private dataPoints As ObservableCollection(Of DataPoint) = New ObservableCollection(Of DataPoint)()

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.chartControl1.Titles.Add(New ChartTitle With {
                .Text = "Real-Time Charting"
            })
            Dim series As Series = New Series()
            series.ChangeView(ViewType.Line)
            series.DataSource = dataPoints
            series.DataSourceSorted = True
            series.ArgumentDataMember = "Argument"
            series.ValueDataMembers.AddRange("Value")
            Me.chartControl1.Series.Add(series)
            Dim seriesView = CType(series.View, LineSeriesView)
            seriesView.LastPoint.LabelDisplayMode = SidePointDisplayMode.DiagramEdge
            seriesView.LastPoint.Label.TextPattern = "{V:f2}"
            Dim diagram = CType(Me.chartControl1.Diagram, XYDiagram)
            diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Continuous
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = False
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = False
            diagram.AxisX.WholeRange.SideMarginsValue = 0
            diagram.DependentAxesYRange = DefaultBoolean.True
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
            Dim timer As Timer = New Timer()
            timer.Interval = 100
            timer.Start()
            AddHandler timer.Tick, AddressOf Timer_Tick
        End Sub

        Private counter = 0

        Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
            dataPoints.Add(New DataPoint(Date.Now, GenerateValue(Math.Min(Threading.Interlocked.Increment(counter), counter - 1))))
            If dataPoints.Count > ViewportPointCount Then dataPoints.RemoveAt(0)
        End Sub

        Private Function GenerateValue(ByVal x As Double) As Double
            Return Math.Sin(x) * 3 + x / 2 + 5
        End Function
    End Class

    Public Class DataPoint
        Public Property Argument As Date
        Public Property Value As Double

        Public Sub New(ByVal argument As Date, ByVal value As Double)
            Me.Argument = argument
            Me.Value = value
        End Sub
    End Class
End Namespace
