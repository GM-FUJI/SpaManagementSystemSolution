' ================================
' BASE CLASS
' ================================
Public Class PackageType
    Public Property ID As Integer
    Public Property Name As String
    Public Property Price As Decimal

    Public Sub New(id As Integer, name As String, price As Decimal)
        Me.ID = id
        Me.Name = name
        Me.Price = price
    End Sub

    Public Overridable Function GetDescription() As String
        Return $"{Name} - ₱{Price:F2}"
    End Function

    Public Overrides Function ToString() As String
        Return GetDescription()
    End Function
End Class

' ============================================
' POLYMORPHIC CHILD CLASSES
' ============================================
Public Class WholeBodyPackage
    Inherits PackageType
    Public Sub New(id As Integer, name As String, price As Decimal)
        MyBase.New(id, name, price)
    End Sub
End Class

Public Class HeadPackage
    Inherits PackageType
    Public Sub New(id As Integer, name As String, price As Decimal)
        MyBase.New(id, name, price)
    End Sub
End Class

Public Class NeckPackage
    Inherits PackageType
    Public Sub New(id As Integer, name As String, price As Decimal)
        MyBase.New(id, name, price)
    End Sub
End Class

Public Class BackPackage
    Inherits PackageType
    Public Sub New(id As Integer, name As String, price As Decimal)
        MyBase.New(id, name, price)
    End Sub
End Class

Public Class ArmsPackage
    Inherits PackageType
    Public Sub New(id As Integer, name As String, price As Decimal)
        MyBase.New(id, name, price)
    End Sub
End Class

Public Class LegsPackage
    Inherits PackageType
    Public Sub New(id As Integer, name As String, price As Decimal)
        MyBase.New(id, name, price)
    End Sub
End Class
