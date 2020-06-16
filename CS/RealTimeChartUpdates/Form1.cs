using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace RealTimeChartUpdates {
    public partial class Form1 : Form {
        const int ViewportPointCount = 100;
        ObservableCollection<DataPoint> dataPoints = new ObservableCollection<DataPoint>();
        public Form1() { InitializeComponent(); }

        void Form1_Load(object sender, EventArgs e) {
            chartControl1.Titles.Add(new ChartTitle { Text = "Real-Time Charting" });

            Series series = new Series();
            series.ChangeView(ViewType.Line);
            series.DataSource = dataPoints;
            series.DataSourceSorted = true;
            series.ArgumentDataMember = "Argument";
            series.ValueDataMembers.AddRange("Value");
            chartControl1.Series.Add(series);

            LineSeriesView seriesView = (LineSeriesView)series.View;
            seriesView.LastPoint.LabelDisplayMode = SidePointDisplayMode.DiagramEdge;
            seriesView.LastPoint.Label.TextPattern = "{V:f2}";

            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Continuous;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            diagram.AxisX.WholeRange.SideMarginsValue = 0;
            diagram.DependentAxesYRange = DefaultBoolean.True;
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = false;

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        int counter = 0;
        void Timer_Tick(object sender, EventArgs e) {
            dataPoints.Add(new DataPoint(DateTime.Now, GenerateValue(counter++)));
            if (dataPoints.Count > ViewportPointCount)
                dataPoints.RemoveAt(0);
        }
        double GenerateValue(double x) { 
            return Math.Sin(x) * 3 + x / 2 + 5; 
        }
    }
    public class DataPoint {
        public DateTime Argument { get; set; }
        public double Value { get; set; }
        public DataPoint(DateTime argument, double value) {
            Argument = argument;
            Value = value;
        }
    }
}
