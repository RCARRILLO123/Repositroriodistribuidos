Public Class Sociedad

    Private _idSociedad As String = ""
    Private _mandante As String = ""
    Private _sociedadId As String = ""
    Private _descripcion As String = ""
    Private _direccion As String = ""
    Private _ruc As String = ""
    Private _Corporacion As String = ""
    Private _Compania As String = ""
    Private _Libr As String = ""
    Private _UserAs As String = ""
    Private _PwsAs As String = ""
    Private _ServerAs As String = ""
    Private _PathLog As String = ""
    Private _NomLogo As String = ""
    Private _TipoLogo As String = ""
    Private _BinLogo As Byte() = Nothing

    Public Property IDSOCIEDAD As String
        Get
            Return _idSociedad
        End Get
        Set(value As String)
            _idSociedad = value
        End Set
    End Property
    Public Property Mandante As String
        Get
            Return _mandante
        End Get
        Set(value As String)
            _mandante = value
        End Set
    End Property
    Public Property SociedadId As String
        Get
            Return _sociedadId
        End Get
        Set(value As String)
            _sociedadId = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property
    Public Property RUC As String
        Get
            Return _ruc
        End Get
        Set(value As String)
            _ruc = value
        End Set
    End Property
    Public Property Corporacion As String
        Get
            Return _Corporacion
        End Get
        Set(value As String)
            _Corporacion = value
        End Set
    End Property
    Public Property Compania As String
        Get
            Return _Compania
        End Get
        Set(value As String)
            _Compania = value
        End Set
    End Property
    Public Property Libr As String
        Get
            Return _Libr
        End Get
        Set(value As String)
            _Libr = value
        End Set
    End Property
    Public Property UserAs As String
        Get
            Return _UserAs
        End Get
        Set(value As String)
            _UserAs = value
        End Set
    End Property
    Public Property PwsAs As String
        Get
            Return _PwsAs
        End Get
        Set(value As String)
            _PwsAs = value
        End Set
    End Property
    Public Property ServerAs As String
        Get
            Return _ServerAs
        End Get
        Set(value As String)
            _ServerAs = value
        End Set
    End Property
    Public Property PathLog As String
        Get
            Return _PathLog
        End Get
        Set(value As String)
            _PathLog = value
        End Set
    End Property
    Public Property NomLogo As String
        Get
            Return _NomLogo
        End Get
        Set(value As String)
            _NomLogo = value
        End Set
    End Property
    Public Property TipoLogo As String
        Get
            Return _TipoLogo
        End Get
        Set(value As String)
            _TipoLogo = value
        End Set
    End Property
    Public Property BinLogo As Byte()
        Get
            Return _BinLogo
        End Get
        Set(value As Byte())
            _BinLogo = value
        End Set
    End Property


End Class
