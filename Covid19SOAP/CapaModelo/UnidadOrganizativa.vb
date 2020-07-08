Public Class UnidadOrganizativa

    Private _corporacion As String = ""
    Private _sociedad As String = ""
    Private _unidadOrganizativa As String = ""
    Private _unidadOrganizativaSup As String = ""
    Private _descUnidadOrganizativa As String = ""
    Private _codigoResponsable As String = ""
    Private _funciones As String = ""
    Private _situacionUnidFunc As String = ""
    Private _nivel As String = ""

    Public Property Corporacion As String
        Get
            Return _corporacion
        End Get
        Set(value As String)
            _corporacion = value
        End Set
    End Property

    Public Property Sociedad As String
        Get
            Return _sociedad
        End Get
        Set(value As String)
            _sociedad = value
        End Set
    End Property

    Public Property UnidadOrganizativa As String
        Get
            Return _unidadOrganizativa
        End Get
        Set(value As String)
            _unidadOrganizativa = value
        End Set
    End Property

    Public Property UnidadOrganizativaSup As String
        Get
            Return _unidadOrganizativaSup
        End Get
        Set(value As String)
            _unidadOrganizativaSup = value
        End Set
    End Property

    Public Property DescUnidadOrganizativa As String
        Get
            Return _descUnidadOrganizativa
        End Get
        Set(value As String)
            _descUnidadOrganizativa = value
        End Set
    End Property
    Public Property CodigoResponsable As String
        Get
            Return _codigoResponsable
        End Get
        Set(value As String)
            _codigoResponsable = value
        End Set
    End Property

    Public Property Funciones As String
        Get
            Return _funciones
        End Get
        Set(value As String)
            _funciones = value
        End Set
    End Property

    Public Property SituacionUnidFunc As String
        Get
            Return _situacionUnidFunc
        End Get
        Set(value As String)
            _situacionUnidFunc = value
        End Set
    End Property

    Public Property Nivel As String
        Get
            Return _nivel
        End Get
        Set(value As String)
            _nivel = value
        End Set
    End Property

End Class

