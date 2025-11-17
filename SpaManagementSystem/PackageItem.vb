Public Class PackageItem
    Public Property PackageID As Integer
    Public Property PackageName As String
    Public Property Price As Decimal
    Public Property TypeClass As PackageType   ' Polymorphic object

    Public Overrides Function ToString() As String
        Return $"{PackageName} - ₱{Price:F2}"
    End Function
End Class
