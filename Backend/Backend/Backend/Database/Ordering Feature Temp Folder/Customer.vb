Public Class Customer
    Public Property id As Integer
    Public Property Name As String
    Public Property Address As String
    Public Property City As String
    Public Property State As String
    Public Property Zip As String
    Public Property Phone As String
    Public Property Email As String

    Public Property Orders As New HashSet(Of SAHeader)

End Class
