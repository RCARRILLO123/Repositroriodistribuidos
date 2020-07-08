Public Class RespuestaConsultaTrabajador
    Inherits Respuesta

    Public Sub New()
        _responseContent = New List(Of Usuario)()
    End Sub
    Private _responseContent As List(Of Usuario)
    Public Property ResponseContent() As List(Of Usuario)
        Get
            Return _responseContent
        End Get
        Set(ByVal value As List(Of Usuario))
            _responseContent = value
        End Set
    End Property



End Class
