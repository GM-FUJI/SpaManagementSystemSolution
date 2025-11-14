Imports System.Windows.Forms
Imports Microsoft.Data.SqlClient
Imports LiveCharts
Imports LiveCharts.WinForms
Imports System.Drawing

Public Class AdminInterface

    Private connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    Private refreshTimer As New Timer()
    Private weeklyChart As CartesianChart
    Private dailyEarningsChart As CartesianChart
    Private discountChart As LiveCharts.WinForms.PieChart ' ✅ Added pie chart object

    ' -------------------- FORM LOAD --------------------
    Private Sub AdminInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make sure the panels exist, or create them dynamically
        SetupChartPanels()

        LoadTotalTax()
        LoadTopPackages()
        LoadTopPerformer()
        LoadWeeklyBookingsChart()
        LoadDailyEarningsChart()
        LoadDiscountPieChart() ' ✅ New chart

        ' Auto refresh every 5 seconds
        refreshTimer.Interval = 5000
        AddHandler refreshTimer.Tick, AddressOf RefreshData
        refreshTimer.Start()
    End Sub

    ' -------------------- SETUP PANELS (Fix Overlap) --------------------
    Private Sub SetupChartPanels()
        ' Create Weekly Chart Panel if not in Designer
        If pnlWeeklyChart Is Nothing Then
            pnlWeeklyChart = New Panel() With {
                .Name = "pnlWeeklyChart",
                .Location = New Point(250, 400),
                .Size = New Size(500, 250),
                .BackColor = Color.White
            }
            Controls.Add(pnlWeeklyChart)
        End If

        ' Create Daily Earnings Chart Panel if not in Designer
        If pnlDailyChart Is Nothing Then
            pnlDailyChart = New Panel() With {
                .Name = "pnlDailyChart",
                .Location = New Point(800, 400),
                .Size = New Size(500, 250),
                .BackColor = Color.White
            }
            Controls.Add(pnlDailyChart)
        End If

        ' ✅ Create Discount Chart Panel (below or beside others)
        If pnlDiscountChart Is Nothing Then
            pnlDiscountChart = New Panel() With {
                .Name = "pnlDiscountChart",
                .Location = New Point(1350, 400), ' adjust if needed
                .Size = New Size(400, 250),
                .BackColor = Color.White
            }
            Controls.Add(pnlDiscountChart)
        End If
    End Sub

    ' -------------------- AUTO REFRESH --------------------
    Private Sub RefreshData(sender As Object, e As EventArgs)
        LoadTotalTax()
        LoadTopPackages()
        LoadTopPerformer()
        LoadWeeklyBookingsChart()
        LoadDailyEarningsChart()
        LoadDiscountPieChart() ' ✅ Refresh pie chart too
    End Sub

    ' -------------------- LOAD TOTAL TAX --------------------
    Private Sub LoadTotalTax()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT SUM(Tax) FROM FinancialRecords"
                Using cmd As New SqlCommand(query, conn)
                    Dim result = cmd.ExecuteScalar()
                    lblTotalTax.Text = If(IsDBNull(result), "₱ 0.00", "₱" & Convert.ToDecimal(result).ToString("N2"))
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total tax: " & ex.Message)
        End Try
    End Sub

    ' -------------------- LOAD TOP PACKAGES --------------------
    Private Sub LoadTopPackages()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String =
                    "SELECT TOP 3 P.PackageName
                     FROM BookingPackages BP
                     INNER JOIN Packages P ON P.PackageID = BP.PackageID
                     GROUP BY P.PackageName
                     ORDER BY COUNT(BP.PackageID) DESC;"

                Using cmd As New SqlCommand(query, conn)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    Dim result As String = ""
                    Dim rank As Integer = 1

                    While reader.Read()
                        result &= $"{rank}. {reader("PackageName")}" & Environment.NewLine
                        rank += 1
                    End While
                    reader.Close()

                    lblTopPackage.Text = If(result = "", "No package bookings yet.", result.Trim())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading top packages: " & ex.Message)
        End Try
    End Sub

    ' -------------------- LOAD TOP PERFORMER --------------------
    Private Sub LoadTopPerformer()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String =
                    "SELECT TOP 1 T.Name, SUM(P.PointsEarned) AS TotalPoints
                     FROM PointsSystem P
                     INNER JOIN Therapists T ON T.TherapistID = P.TherapistID
                     GROUP BY T.Name
                     ORDER BY TotalPoints DESC;"

                Using cmd As New SqlCommand(query, conn)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        lblTPTherapist.Text = $"{reader("Name")} ({reader("TotalPoints")} pts)"
                    Else
                        lblTPTherapist.Text = "No data available."
                    End If
                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            lblTPTherapist.Text = "Error loading top performer."
        End Try
    End Sub

    ' -------------------- LOAD WEEKLY BOOKINGS CHART --------------------
    Private Sub LoadWeeklyBookingsChart()
        Try
            pnlWeeklyChart.Controls.Clear()

            weeklyChart = New CartesianChart() With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.White
            }

            Dim values As New ChartValues(Of Integer)()
            Dim labels As New List(Of String)()

            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String =
                    "SELECT DATENAME(WEEKDAY, BookingDate) AS [Day], COUNT(*) AS Total
                     FROM Bookings
                     WHERE BookingDate >= DATEADD(DAY, -6, GETDATE())
                     GROUP BY DATENAME(WEEKDAY, BookingDate),
                              ((DATEPART(WEEKDAY, BookingDate) + @@DATEFIRST - 2) % 7)
                     ORDER BY ((DATEPART(WEEKDAY, BookingDate) + @@DATEFIRST - 2) % 7);"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            labels.Add(reader("Day").ToString())
                            values.Add(Convert.ToInt32(reader("Total")))
                        End While
                    End Using
                End Using
            End Using

            weeklyChart.Series = New SeriesCollection From {
                New LiveCharts.Wpf.ColumnSeries With {
                    .Title = "Bookings",
                    .Values = values
                }
            }

            weeklyChart.AxisX.Add(New LiveCharts.Wpf.Axis With {.Title = "Day", .Labels = labels})
            weeklyChart.AxisY.Add(New LiveCharts.Wpf.Axis With {.Title = "Total Bookings"})

            pnlWeeklyChart.Controls.Add(weeklyChart)

        Catch ex As Exception
            MessageBox.Show("Error loading weekly chart: " & ex.Message)
        End Try
    End Sub

    ' -------------------- LOAD DAILY EARNINGS CHART --------------------
    Private Sub LoadDailyEarningsChart()
        Try
            pnlDailyChart.Controls.Clear()

            dailyEarningsChart = New CartesianChart() With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.White
            }

            Dim earningsValues As New ChartValues(Of Decimal)()
            Dim dateLabels As New List(Of String)()

            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String =
                    "SELECT Date, SUM(TotalAmount) AS TotalEarnings
                     FROM FinancialRecords
                     GROUP BY Date
                     ORDER BY Date ASC;"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            earningsValues.Add(Convert.ToDecimal(reader("TotalEarnings")))
                            dateLabels.Add(Convert.ToDateTime(reader("Date")).ToString("MM/dd"))
                        End While
                    End Using
                End Using
            End Using

            dailyEarningsChart.Series = New SeriesCollection From {
                New LiveCharts.Wpf.ColumnSeries With {
                    .Title = "Earnings",
                    .Values = earningsValues
                }
            }

            dailyEarningsChart.AxisX.Add(New LiveCharts.Wpf.Axis With {
                .Title = "Date",
                .Labels = dateLabels
            })

            dailyEarningsChart.AxisY.Add(New LiveCharts.Wpf.Axis With {
                .Title = "Total Amount (₱)",
                .LabelFormatter = Function(value) "₱" & value.ToString("N0")
            })

            pnlDailyChart.Controls.Add(dailyEarningsChart)

        Catch ex As Exception
            MessageBox.Show("Error loading daily earnings chart: " & ex.Message)
        End Try
    End Sub

    ' -------------------- LOAD DISCOUNT PIE CHART --------------------
    Private Sub LoadDiscountPieChart()
        Try
            pnlDiscountChart.Controls.Clear()

            discountChart = New LiveCharts.WinForms.PieChart() With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.White
            }

            Dim pieSeries As New LiveCharts.SeriesCollection()

            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String =
                    "SELECT D.DiscountName, COUNT(B.DiscountPercent) AS UsedCount
                     FROM Bookings B
                     INNER JOIN Discounts D 
                         ON B.DiscountPercent = D.DiscountPercent
                     GROUP BY D.DiscountName
                     ORDER BY UsedCount DESC;"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim discountName As String = reader("DiscountName").ToString()
                            Dim usedCount As Integer = Convert.ToInt32(reader("UsedCount"))

                            pieSeries.Add(New LiveCharts.Wpf.PieSeries With {
                                .Title = discountName,
                                .Values = New ChartValues(Of Integer)({usedCount}),
                                .DataLabels = True
                            })
                        End While
                    End Using
                End Using
            End Using

            discountChart.Series = pieSeries
            pnlDiscountChart.Controls.Add(discountChart)

        Catch ex As Exception
            MessageBox.Show("Error loading discount pie chart: " & ex.Message)
        End Try
    End Sub

    ' -------------------- NAVIGATION BUTTONS --------------------
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ther As New Therapist(Me)
        ther.StartPosition = FormStartPosition.CenterScreen
        Me.Hide()
        ther.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pack As New Package(Me)
        pack.StartPosition = FormStartPosition.CenterScreen
        Me.Hide()
        pack.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim hist As New History()
        hist.StartPosition = FormStartPosition.CenterScreen
        Me.Hide()
        hist.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim book As New Booking(Me)
        book.StartPosition = FormStartPosition.CenterScreen
        Me.Hide()
        book.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
            Dim loginForm As New LogIn()
            loginForm.StartPosition = FormStartPosition.CenterScreen
            loginForm.Show()
        End If
    End Sub

End Class
