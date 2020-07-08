Public Class ParametroUO

    Private _unidadOrganizat As String
    Private _sociedad As String
    Private _unidadOrganizatSup As String
    Private _descUnidadOrganizat As String
    Private _codigoResponsable As String
    Private _situacionFunc As String

    Public Property UnidadOrganizat() As String
        Get
            Return _unidadOrganizat
        End Get
        Set(ByVal value As String)
            _unidadOrganizat = value
        End Set
    End Property

    Public Property Sociedad() As String
        Get
            Return _sociedad
        End Get
        Set(ByVal value As String)
            _sociedad = value
        End Set
    End Property

    Public Property UnidadOrganizatSup() As String
        Get
            Return _unidadOrganizatSup
        End Get
        Set(ByVal value As String)
            _unidadOrganizatSup = value
        End Set
    End Property

    Public Property DescUnidadOrganizat() As String
        Get
            Return _descUnidadOrganizat
        End Get
        Set(ByVal value As String)
            _descUnidadOrganizat = value
        End Set
    End Property

    Public Property CodigoResponsable() As String
        Get
            Return _codigoResponsable
        End Get
        Set(ByVal value As String)
            _codigoResponsable = value
        End Set
    End Property

    Public Property SituacionFunc() As String
        Get
            Return _situacionFunc
        End Get
        Set(ByVal value As String)
            _situacionFunc = value
        End Set
    End Property

End Class



