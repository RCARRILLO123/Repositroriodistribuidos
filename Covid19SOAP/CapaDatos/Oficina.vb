Public Class Oficina

    Private _oficina As String = ""
    Private _nombreOficina As String = ""
    Private _centro As String = ""

    Public Property Oficina As String
        Get
            Return _oficina
        End Get
        Set(value As String)
            _oficina = value
        End Set
    End Property
    Public Property NombreOficina As String
        Get
            Return _nombreOficina
        End Get
        Set(value As String)
            _nombreOficina = value
        End Set
    End Property
    Public Property Centro As String
        Get
            Return _centro

        End Get
        Set(value As String)
            _centro = value
        End Set
    End Property
End Class
