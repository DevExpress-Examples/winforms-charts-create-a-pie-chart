Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.XtraCharts

Namespace Series_PieChart
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			' Create an empty chart.
			Dim pieChart As New ChartControl()

			pieChart.Titles.Add(New ChartTitle() With {.Text = "Land Area by Country"})

			' Create a pie series.
			Dim series1 As New Series("Land Area by Country", ViewType.Pie)

			' Bind the series to data.
			series1.DataSource = DataPoint.GetDataPoints()
			series1.ArgumentDataMember = "Argument"
			series1.ValueDataMembers.AddRange(New String() { "Value" })

            ' Add the series to the chart.
            pieChart.Series.Add(series1)

            ' Access diagram settings.
            Dim diagram As SimpleDiagram = CType(pieChart.Diagram, SimpleDiagram)
            diagram.Margins.All = 10

            ' Format the the series labels.
            series1.Label.TextPattern = "{VP:p0} ({V:.##}M km²)"

            ' Format the series legend items.
            series1.LegendTextPattern = "{A}"

			' Adjust the position of series labels. 
			CType(series1.Label, PieSeriesLabel).Position = PieSeriesLabelPosition.TwoColumns

			' Detect overlapping of series labels.
			CType(series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

			' Access the view-type-specific options of the series.
			Dim myView As PieSeriesView = CType(series1.View, PieSeriesView)

			' Specify a data filter to explode points.
			myView.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Value_1, DataFilterCondition.GreaterThanOrEqual, 9))
			myView.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.NotEqual, "Others"))
			myView.ExplodeMode = PieExplodeMode.UseFilters
			myView.ExplodedDistancePercentage = 30
            myView.RuntimeExploding = True

            ' Specify the pie rotation.
            myView.Rotation = -60

            ' Customize the legend.
            pieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True

			' Add the chart to the form.
			pieChart.Dock = DockStyle.Fill
			Me.Controls.Add(pieChart)
		End Sub
	End Class
	Public Class DataPoint
		Public Property Argument() As String
		Public Property Value() As Double

		Public Shared Function GetDataPoints() As List(Of DataPoint)
			Return New List(Of DataPoint) From {
				New DataPoint With {
					.Argument = "Russia",
					.Value = 17.0752
				},
				New DataPoint With {
					.Argument = "Canada",
					.Value = 9.98467
				},
				New DataPoint With {
					.Argument = "USA",
					.Value = 9.63142
				},
				New DataPoint With {
					.Argument = "China",
					.Value = 9.59696
				},
				New DataPoint With {
					.Argument = "Brazil",
					.Value = 8.511965
				},
				New DataPoint With {
					.Argument = "Australia",
					.Value = 7.68685
				},
				New DataPoint With {
					.Argument = "India",
					.Value = 3.28759
				},
				New DataPoint With {
					.Argument = "Others",
					.Value = 81.2
				}
			}
		End Function
	End Class
End Namespace