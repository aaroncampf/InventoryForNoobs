Public Class SAHeader
    Public Property id As Integer
    Public Property Customer As Customer
    Public Property ShipedDate As Date
    Public Property OrderDate As Date
    Public Property RequestedDate As Date

    Public Property Details As New HashSet(Of SADetail)

    'TODO: Make sure all SAHeader have a sales item added
End Class
