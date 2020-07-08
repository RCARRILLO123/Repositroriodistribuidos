Public Class Parametro
    Private _codigo As String
    Private _nombre As String
    Private _sociedad As String
    Private _areaPersonal As String
    Private _centroCosto As String
    Private _division As String
    Private _estadoCivil As String
    Private _fechaIngreso As String
    Private _numeroDocumento As String
    Private _posicion As String
    Private _sexo As String
    Private _subdivisionPers As String
    Private _unidadOrganizat As String
    Private _codigoDBS As String
    Private _fechacumpleanos As String
    Private _mandante As String

    Public Property Mandante() As String
        Get
            Return _mandante
        End Get
        Set(ByVal value As String)
            _mandante = value
        End Set
    End Property

    Public Property Fechacumpleanos() As String
        Get
            Return _fechacumpleanos
        End Get
        Set(ByVal value As String)
            _fechacumpleanos = value
        End Set
    End Property


    Public Property CodigoDBS() As String
        Get
            Return _codigoDBS
        End Get
        Set(ByVal value As String)
            _codigoDBS = value
        End Set
    End Property

    Public Property UnidadOrganizat() As String
        Get
            Return _unidadOrganizat
        End Get
        Set(ByVal value As String)
            _unidadOrganizat = value
        End Set
    End Property



    Public Property SubdivisionPers() As String
        Get
            Return _subdivisionPers
        End Get
        Set(ByVal value As String)
            _subdivisionPers = value
        End Set
    End Property

    Public Property Sexo() As String
        Get
            Return _sexo
        End Get
        Set(ByVal value As String)
            _sexo = value
        End Set
    End Property

    Public Property Posicion() As String
        Get
            Return _posicion
        End Get
        Set(ByVal value As String)
            _posicion = value
        End Set
    End Property



    Public Property NumeroDocumento() As String
        Get
            Return _numeroDocumento
        End Get
        Set(ByVal value As String)
            _numeroDocumento = value
        End Set
    End Property
    Public Property FechaIngreso() As String
        Get
            Return _fechaIngreso
        End Get
        Set(ByVal value As String)
            _fechaIngreso = value
        End Set
    End Property



    Public Property EstadoCivil() As String
        Get
            Return _estadoCivil
        End Get
        Set(ByVal value As String)
            _estadoCivil = value
        End Set
    End Property


    Public Property Division() As String
        Get
            Return _division
        End Get
        Set(ByVal value As String)
            _division = value
        End Set
    End Property

    Public Property CentroCosto() As String
        Get
            Return _centroCosto
        End Get
        Set(ByVal value As String)
            _centroCosto = value
        End Set
    End Property

    Public Property AreaPersonal() As String
        Get
            Return _areaPersonal
        End Get
        Set(ByVal value As String)
            _areaPersonal = value
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

    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

End Class
