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
    Private discountChart As LiveCharts.WinForms.PieChart

    ' -------------------- FORM LOAD --------------------
    Private Sub AdminInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupChartPanels()

        LoadTotalTax()
        LoadTopPackages()
        LoadTopPerformer()
        LoadWeeklyBookingsChart()
        LoadDailyEarningsChart()
        LoadDiscountPieChart()
        LoadBookingsPerDay()

        refreshTimer.Interval = 5000
        AddHandler refreshTimer.Tick, AddressOf RefreshData
        refreshTimer.Start()
    End Sub

    ' -------------------- AUTO REFRESH --------------------
    Private Sub RefreshData(sender As Object, e As EventArgs)
        LoadTotalTax()
        LoadTopPackages()
        LoadTopPerformer()
        LoadWeeklyBookingsChart()
        LoadDailyEarningsChart()
        LoadDiscountPieChart()
        LoadBookingsPerDay()
    End Sub

    ' -------------------- CREATE PANELS IF NOT FOUND --------------------
    Private Sub SetupChartPanels()
        If pnlWeeklyChart Is Nothing Then
            pnlWeeklyChart = New Panel() With {
                .Name = "pnlWeeklyChart",
                .Location = New Point(250, 400),
                .Size = New Size(500, 250),
                .BackColor = Color.White
            }
            Controls.Add(pnlWeeklyChart)
        End If

        If pnlDailyChart Is Nothing Then
            pnlDailyChart = New Panel() With {
                .Name = "pnlDailyChart",
                .Location = New Point(800, 400),
                .Size = New Size(500, 250),
                .BackColor = Color.White
            }
            Controls.Add(pnlDailyChart)
        End If

        If pnlDiscountChart Is Nothing Then
            pnlDiscountChart = New Panel() With {
                .Name = "pnlDiscountChart",
                .Location = New Point(1350, 400),
                .Size = New Size(400, 250),
                .BackColor = Color.White
            }
            Controls.Add(pnlDiscountChart)
        End If
    End Sub

    ' -------------------- LOAD TOTAL TAX --------------------
    Private Sub LoadTotalTax()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT SUM(Tax) FROM FinancialRecords"
                Using cmd As New SqlCommand(query, conn)
                    Dim result = cmd.ExecuteScalar()
                    lblTotalTax.Text = If(IsDBNull(result), "₱0.00", "₱" & Convert.ToDecimal(result).ToString("N2"))
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total tax: " & ex.Message)
        End Try
    End Sub

    ' -------------------- LOAD BOOKINGS PER DAY --------------------
    Private Sub LoadBookingsPerDay()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim query As String =
                    "SELECT COUNT(*) 
                     FROM Bookings
                     WHERE BookingDate = CAST(GETDATE() AS date);"

                Using cmd As New SqlCommand(query, conn)
                    Dim result = cmd.ExecuteScalar()
                    lblBookingpDay.Text = result.ToString()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading bookings per day: " & ex.Message)
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
                    Dim reader = cmd.ExecuteReader()
                    Dim result As String = ""
                    Dim rank As Integer = 1

                    While reader.Read()
                        result &= $"{rank}. {reader("PackageName")}" & Environment.NewLine
                        rank += 1
                    End While

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
                    Dim reader = cmd.ExecuteReader()

                    If reader.Read() Then
                        lblTPTherapist.Text = $"{reader("Name")} ({reader("TotalPoints")} pts)"
                    Else
                        lblTPTherapist.Text = "No data available."
                    End If
                End Using
            End Using

        Catch ex As Exception
            lblTPTherapist.Text = "Error loading top performer."
        End Try
    End Sub

    ' -------------------- WEEKLY BOOKINGS CHART --------------------
    Private Sub LoadWeeklyBookingsChart()
        Try
            pnlWeeklyChart.Controls.Clear()

            weeklyChart = New CartesianChart() With {.Dock = DockStyle.Fill}

            Dim values As New ChartValues(Of Integer)
            Dim labels As New List(Of String)

            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim query As String =
                    "SELECT DATENAME(WEEKDAY, BookingDate) AS [Day], COUNT(*) AS Total,
                     ((DATEPART(WEEKDAY, BookingDate) + @@DATEFIRST - 2) % 7) AS Sort
                     FROM Bookings
                     WHERE BookingDate >= DATEADD(DAY, -6, GETDATE())
                     GROUP BY DATENAME(WEEKDAY, BookingDate),
                              ((DATEPART(WEEKDAY, BookingDate) + @@DATEFIRST - 2) % 7)
                     ORDER BY Sort;"

                Using cmd As New SqlCommand(query, conn)
                    Dim reader = cmd.ExecuteReader()

                    While reader.Read()
                        labels.Add(reader("Day").ToString())
                        values.Add(Convert.ToInt32(reader("Total")))
                    End While

                End Using
            End Using

            weeklyChart.Series = New SeriesCollection From {
                New LiveCharts.Wpf.ColumnSeries With {.Title = "Bookings", .Values = values}
            }

            weeklyChart.AxisX.Add(New LiveCharts.Wpf.Axis With {.Labels = labels})
            weeklyChart.AxisY.Add(New LiveCharts.Wpf.Axis With {.Title = "Total Bookings"})

            pnlWeeklyChart.Controls.Add(weeklyChart)

        Catch ex As Exception
            MessageBox.Show("Error loading weekly chart: " & ex.Message)
        End Try
    End Sub

    ' -------------------- DAILY EARNINGS CHART --------------------
    Private Sub LoadDailyEarningsChart()
        Try
            pnlDailyChart.Controls.Clear()

            dailyEarningsChart = New CartesianChart() With {.Dock = DockStyle.Fill}

            Dim earningsValues As New ChartValues(Of Decimal)
            Dim dateLabels As New List(Of String)

            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim query As String =
                    "SELECT Date, SUM(TotalAmount) AS TotalEarnings
                     FROM FinancialRecords
                     GROUP BY Date
                     ORDER BY Date ASC;"

                Using cmd As New SqlCommand(query, conn)
                    Dim reader = cmd.ExecuteReader()

                    While reader.Read()
                        earningsValues.Add(Convert.ToDecimal(reader("TotalEarnings")))
                        dateLabels.Add(Convert.ToDateTime(reader("Date")).ToString("MM/dd"))
                    End While

                End Using
            End Using

            dailyEarningsChart.Series = New SeriesCollection From {
                New LiveCharts.Wpf.ColumnSeries With {.Title = "Earnings", .Values = earningsValues}
            }

            dailyEarningsChart.AxisX.Add(New LiveCharts.Wpf.Axis With {.Labels = dateLabels})
            dailyEarningsChart.AxisY.Add(New LiveCharts.Wpf.Axis With {
                .Title = "Total Amount (₱)",
                .LabelFormatter = Function(value) "₱" & value.ToString("N0")
            })

            pnlDailyChart.Controls.Add(dailyEarningsChart)

        Catch ex As Exception
            MessageBox.Show("Error loading daily earnings chart: " & ex.Message)
        End Try
    End Sub

    ' -------------------- DISCOUNT PIE CHART --------------------
    Private Sub LoadDiscountPieChart()
        Try
            pnlDiscountChart.Controls.Clear()

            discountChart = New LiveCharts.WinForms.PieChart() With {.Dock = DockStyle.Fill}

            Dim series As New SeriesCollection()

            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim query As String =
                    "SELECT D.DiscountName, COUNT(B.DiscountPercent) AS UsedCount
                     FROM Bookings B
                     INNER JOIN Discounts D ON D.DiscountPercent = B.DiscountPercent
                     GROUP BY D.DiscountName
                     ORDER BY UsedCount DESC;"

                Using cmd As New SqlCommand(query, conn)
                    Dim reader = cmd.ExecuteReader()

                    While reader.Read()
                        series.Add(New LiveCharts.Wpf.PieSeries With {
                            .Title = reader("DiscountName").ToString(),
                            .Values = New ChartValues(Of Integer)({Convert.ToInt32(reader("UsedCount"))}),
                            .DataLabels = True
                        })
                    End While

                End Using
            End Using

            discountChart.Series = series
            pnlDiscountChart.Controls.Add(discountChart)

        Catch ex As Exception
            MessageBox.Show("Error loading discount pie chart: " & ex.Message)
        End Try
    End Sub

    ' -------------------- NAVIGATION --------------------
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ther As New Therapist(Me)
        Me.Hide()
        ther.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pack As New Package(Me)
        Me.Hide()
        pack.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim hist As New History()
        Me.Hide()
        hist.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim book As New Booking(Me)
        Me.Hide()
        book.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.Close()
            Dim login As New LogIn()
            login.Show()
        End If
    End Sub



End Class
