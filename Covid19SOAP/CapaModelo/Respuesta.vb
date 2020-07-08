Public Class Respuesta
    Private _responseCode As String
    Public Property ResponseCode() As String
        Get
            Return _responseCode
        End Get
        Set(ByVal value As String)
            _responseCode = value
        End Set
    End Property

    Private _responseMessage As String
    Public Property ResponseMessage() As String
        Get
            Return _responseMessage
        End Get
        Set(ByVal value As String)
            _responseMessage = value
        End Set
    End Property
End Class
