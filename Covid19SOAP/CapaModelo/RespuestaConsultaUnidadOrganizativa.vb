Public Class RespuestaConsultaUnidadOrganizativa
    Inherits Respuesta

    Public Sub New()
        _responseContent = New List(Of UnidadOrganizativa)()
    End Sub
    Private _responseContent As List(Of UnidadOrganizativa)
    Public Property ResponseContent() As List(Of UnidadOrganizativa)
        Get
            Return _responseContent
        End Get
        Set(ByVal value As List(Of UnidadOrganizativa))
            _responseContent = value
        End Set
    End Property
End Class
