Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace Series_PieChart
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create an empty chart.
			Dim pieChart As New ChartControl()

			' Create a pie series.
			Dim series1 As New Series("A Pie Series", ViewType.Pie)

			' Populate the series with points.
			series1.Points.Add(New SeriesPoint("Russia", 17.0752))
			series1.Points.Add(New SeriesPoint("Canada", 9.98467))
			series1.Points.Add(New SeriesPoint("USA", 9.63142))
			series1.Points.Add(New SeriesPoint("China", 9.59696))
			series1.Points.Add(New SeriesPoint("Brazil", 8.511965))
			series1.Points.Add(New SeriesPoint("Australia", 7.68685))
			series1.Points.Add(New SeriesPoint("India", 3.28759))
			series1.Points.Add(New SeriesPoint("Others", 81.2))

			' Add the series to the chart.
			pieChart.Series.Add(series1)

			' Adjust the point options of the series.
			series1.Label.PointOptions.PointView = PointView.ArgumentAndValues
			series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent
			series1.Label.PointOptions.ValueNumericOptions.Precision = 0

			' Detect overlapping of series labels.
			CType(series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

			' Adjust the position of series labels. 
			CType(series1.Label, PieSeriesLabel).Position = PieSeriesLabelPosition.TwoColumns

			' Access the view-type-specific options of the series.
			Dim myView As PieSeriesView = CType(series1.View, PieSeriesView)

			' Show a title for the series.
			myView.Titles.Add(New SeriesTitle())
			myView.Titles(0).Text = series1.Name

			' Specify a data filter to explode points.
			myView.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Value_1, DataFilterCondition.GreaterThanOrEqual, 9))
			myView.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.NotEqual, "Others"))
			myView.ExplodeMode = PieExplodeMode.UseFilters
			myView.ExplodedDistancePercentage = 30
			myView.RuntimeExploding = True
			myView.HeightToWidthRatio = 0.75

			' Hide the legend (if necessary).
			pieChart.Legend.Visible = False

			' Add the chart to the form.
			pieChart.Dock = DockStyle.Fill
			Me.Controls.Add(pieChart)
		End Sub
	End Class
End Namespace