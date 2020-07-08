<Runtime.InteropServices.Guid("84FE404E-F5B6-4C99-AF52-D65E716AD25E")>
Public Class Usuario

    Private _usuarioID As String = ""
    Private _claveAcceso As String = ""
    Private _mandante As String = ""
    Private _nombres As String = ""
    Private _apellidoPaterno As String = ""
    Private _apellidoMaterno As String = ""
    Private _matricula As String = ""
    Private _codigoSAP As String = ""
    Private _codigoDBS As String = ""
    Private _usuarioRed As String = ""

    Private _codigoUnico As String = ""
    Private _corporacion As String = ""
    Private _compania As String = ""
    Private _oficina As String = ""
    Private _agencia As String = ""
    Private _centroCosto As String = ""
    Private _division As String = ""
    Private _linea As String = ""
    Private _sociedad As String = ""
    Private _centroId As String = ""
    Private _almacenId As String = ""

    Private _lComercial As String = ""
    Private _puntoEmision As String = ""
    Private _agenteRetenedor As String = ""

    Private _usuarioRegistro As String = ""
    Private _usuarioSAP As String = ""

    Private _nombresCompletos As String = ""
    Private _fechaExpClave As String = ""
    Private _fechaExpUsuario As String = ""
    Private _expiraClave As Boolean = True

    Private _situacionTrabajador As String = ""
    Private _codigoAutogenerado As String = ""
    Private _sociedadVigente As String = ""
    Private _NumeroDocumento As String = ""
    Private _FechaIngreso As String = ""
    Private _FechaRetiro As String = ""


    'NUEVOS CAMPOS

    Private _AreaPersonal As String = ""
    Private _AreafeCodres As String = ""
    Private _AreafeDesres As String = ""
    Private _AreafeUnidad As String = ""
    Private _AreafeUnides As String = ""
    Private _CodigoJefe As String = ""
    Private _CupId As String = ""
    Private _CwsId As String = ""
    Private _DescAreaPerson As String = ""
    Private _DescCentroCost As String = ""
    Private _DescDivisionPe As String = ""
    Private _DescPosicion As String = ""
    Private _DescSubdivision As String = ""
    Private _DescUnidadOrga As String = ""
    Private _DireccEstablec As String = ""
    Private _EmailTrabajo As String = ""
    Private _EstadoCivil As String = ""
    Private _FechaCumpleanos As String = ""
    Private _FechaNacimiento As String = ""
    Private _GegcorCodres As String = ""
    Private _GegcorDesres As String = ""
    Private _GegcorUnidad As String = ""
    Private _GegcorUnides As String = ""
    Private _GercenCodres As String = ""
    Private _GercenDesres As String = ""
    Private _GercenUnidad As String = ""
    Private _GercenUnides As String = ""
    Private _GercorCodres As String = ""
    Private _GercorDesres As String = ""
    Private _GercorUnidad As String = ""
    Private _GercorUnides As String = ""
    Private _GerdivCodres As String = ""
    Private _GerdivDesres As String = ""
    Private _GerdivUnidad As String = ""
    Private _GerdivUnides As String = ""
    Private _GerencCodres As String = ""
    Private _GerencDesres As String = ""
    Private _GerencUnidad As String = ""
    Private _GerencUnides As String = ""
    Private _GergenCodres As String = ""
    Private _GergenDesres As String = ""
    Private _GergenUnidad As String = ""
    Private _GergenUnides As String = ""
    Private _IndMecaViaje As String = ""
    Private _NombreJefe As String = ""
    Private _NombreSociedad As String = ""
    Private _Posicion As String = ""
    Private _PrecorCodres As String = ""
    Private _PrecorDesres As String = ""
    Private _PrecorUnidad As String = ""
    Private _PrecorUnides As String = ""
    Private _Sexo As String = ""
    Private _SubdivisionPers As String = ""
    Private _SubgerCodres As String = ""
    Private _SubgerDesres As String = ""
    Private _SubgerUnidad As String = ""
    Private _SubgerUnides As String = ""
    Private _TipoDocumento As String = ""
    Private _UnidadOrganizat As String = ""



    Public Property FechaRetiro As String
        Get
            Return _FechaRetiro
        End Get
        Set(value As String)
            _FechaRetiro = value
        End Set
    End Property

    Public Property FechaIngreso As String
        Get
            Return _FechaIngreso
        End Get
        Set(value As String)
            _FechaIngreso = value
        End Set
    End Property

    Public Property UsuarioID As String
        Get
            Return _usuarioID
        End Get
        Set(value As String)
            _usuarioID = value
        End Set
    End Property

    Public Property ClaveAcceso As String
        Get
            Return _claveAcceso
        End Get
        Set(value As String)
            _claveAcceso = value
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

    Public Property Nombres As String
        Get
            Return _nombres
        End Get
        Set(value As String)
            _nombres = value
        End Set
    End Property

    Public Property ApellidoPaterno As String
        Get
            Return _apellidoPaterno
        End Get
        Set(value As String)
            _apellidoPaterno = value
        End Set
    End Property

    Public Property ApellidoMaterno As String
        Get
            Return _apellidoMaterno
        End Get
        Set(value As String)
            _apellidoMaterno = value
        End Set
    End Property

    Public Property Matricula As String
        Get
            Return _matricula
        End Get
        Set(value As String)
            _matricula = value
        End Set
    End Property

    Public Property CodigoSAP As String
        Get
            Return _codigoSAP
        End Get
        Set(value As String)
            _codigoSAP = value
        End Set
    End Property

    Public Property UsuarioRed As String
        Get
            Return _usuarioRed
        End Get
        Set(value As String)
            _usuarioRed = value
        End Set
    End Property

    Public Property CodigoDBS As String
        Get
            Return _codigoDBS
        End Get
        Set(value As String)
            _codigoDBS = value
        End Set
    End Property

    Public Property NombresCompletos As String
        Get
            Return _nombresCompletos
        End Get
        Set(value As String)
            _nombresCompletos = value
        End Set
    End Property

    Public Property FechaExpClave As String
        Get
            Return _fechaExpClave
        End Get
        Set(value As String)
            _fechaExpClave = value
        End Set
    End Property

    Public Property FechaExpUsuario As String
        Get
            Return _fechaExpUsuario
        End Get
        Set(value As String)
            _fechaExpUsuario = value
        End Set
    End Property

    Public Property ExpiraClave As Boolean
        Get
            Return _expiraClave
        End Get
        Set(value As Boolean)
            _expiraClave = value
        End Set
    End Property

    Public Property CodigoUnico As String
        Get
            Return _codigoUnico
        End Get
        Set(value As String)
            _codigoUnico = value

        End Set
    End Property

    Public Property Corporacion As String
        Get
            Return _corporacion
        End Get
        Set(value As String)
            _corporacion = value
        End Set
    End Property

    Public Property Compania As String
        Get
            Return _compania
        End Get
        Set(value As String)
            _compania = value
        End Set
    End Property

    Public Property Oficina As String
        Get
            Return _oficina
        End Get
        Set(value As String)
            _oficina = value
        End Set
    End Property
    Public Property Agencia As String
        Get
            Return _agencia
        End Get
        Set(value As String)
            _agencia = value
        End Set
    End Property

    Public Property CentroCosto As String
        Get
            Return _centroCosto
        End Get
        Set(value As String)
            _centroCosto = value
        End Set
    End Property

    Public Property Division As String
        Get
            Return _division
        End Get
        Set(value As String)
            _division = value
        End Set
    End Property
    Public Property Linea As String
        Get
            Return _linea
        End Get
        Set(value As String)
            _linea = value
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

    Public Property CentroId As String
        Get
            Return _centroId
        End Get
        Set(value As String)
            _centroId = value
        End Set
    End Property
    Public Property AlmacenId As String
        Get
            Return _almacenId
        End Get
        Set(value As String)
            _almacenId = value
        End Set
    End Property

    Private _jefeInm As String = ""
    Public Property JefeInm As String
        Get
            Return _jefeInm
        End Get
        Set(value As String)
            _jefeInm = value
        End Set
    End Property

    Private _usuarioDBS As String = ""
    Public Property UsuarioDBS As String
        Get
            Return _usuarioDBS
        End Get
        Set(value As String)
            _usuarioDBS = value
        End Set
    End Property

    Private _pswSAP As String = ""
    Public Property PswSAP As String
        Get
            Return _pswSAP
        End Get
        Set(value As String)
            _pswSAP = value
        End Set
    End Property

    Private _sociedadCO As String = ""
    Public Property SociedadCO As String
        Get
            Return _sociedadCO
        End Get
        Set(value As String)
            _sociedadCO = value
        End Set
    End Property

    Public Property LugarComercial As String
        Get
            Return _lComercial
        End Get
        Set(value As String)
            _lComercial = value
        End Set
    End Property

    Public Property UsuarioRegistro As String
        Get
            Return _usuarioRegistro
        End Get
        Set(value As String)
            _usuarioRegistro = value
        End Set
    End Property

    Public Property UsuarioSAP As String
        Get
            Return _usuarioSAP
        End Get
        Set(value As String)
            _usuarioSAP = value
        End Set
    End Property

    Public Property SituacionTrabajador As String
        Get
            Return _situacionTrabajador
        End Get
        Set(value As String)
            _situacionTrabajador = value
        End Set
    End Property

    Public Property PuntoEmision As String
        Get
            Return _puntoEmision
        End Get
        Set(value As String)
            _puntoEmision = value
        End Set
    End Property

    Public Property AgenteRetenedor As String
        Get
            Return _agenteRetenedor
        End Get
        Set(value As String)
            _agenteRetenedor = value
        End Set
    End Property

    Public Property CodigoAutogenerado As String
        Get
            Return _codigoAutogenerado
        End Get
        Set(value As String)
            _codigoAutogenerado = value
        End Set
    End Property
    Public Property SociedadVigente As String
        Get
            Return _sociedadVigente
        End Get
        Set(value As String)
            _sociedadVigente = value
        End Set
    End Property


    Public Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
        Set(ByVal value As String)
            _NumeroDocumento = value
        End Set
    End Property


    ' NUEVOS CAMPOS

    Public Property AreaPersonal As String
        Get
            Return _AreaPersonal
        End Get
        Set(value As String)
            _AreaPersonal = value
        End Set
    End Property

    Public Property AreafeCodres As String
        Get
            Return _AreafeCodres
        End Get
        Set(value As String)
            _AreafeCodres = value
        End Set
    End Property

    Public Property AreafeDesres As String
        Get
            Return _AreafeDesres
        End Get
        Set(value As String)
            _AreafeDesres = value
        End Set
    End Property

    Public Property AreafeUnidad As String
        Get
            Return _AreafeUnidad
        End Get
        Set(value As String)
            _AreafeUnidad = value
        End Set
    End Property

    Public Property AreafeUnides As String
        Get
            Return _AreafeUnides
        End Get
        Set(value As String)
            _AreafeUnides = value
        End Set
    End Property

    Public Property CodigoJefe As String
        Get
            Return _CodigoJefe
        End Get
        Set(value As String)
            _CodigoJefe = value
        End Set
    End Property

    Public Property CupId As String
        Get
            Return _CupId
        End Get
        Set(value As String)
            _CupId = value
        End Set
    End Property

    Public Property CwsId As String
        Get
            Return _CwsId
        End Get
        Set(value As String)
            _CwsId = value
        End Set
    End Property

    Public Property DescAreaPerson As String
        Get
            Return _DescAreaPerson
        End Get
        Set(value As String)
            _DescAreaPerson = value
        End Set
    End Property

    Public Property DescCentroCost As String
        Get
            Return _DescCentroCost
        End Get
        Set(value As String)
            _DescCentroCost = value
        End Set
    End Property

    Public Property DescDivisionPe As String
        Get
            Return _DescDivisionPe
        End Get
        Set(value As String)
            _DescDivisionPe = value
        End Set
    End Property

    Public Property DescPosicion As String
        Get
            Return _DescPosicion
        End Get
        Set(value As String)
            _DescPosicion = value
        End Set
    End Property

    Public Property DescSubdivision As String
        Get
            Return _DescSubdivision
        End Get
        Set(value As String)
            _DescSubdivision = value
        End Set
    End Property

    Public Property DescUnidadOrga As String
        Get
            Return _DescUnidadOrga
        End Get
        Set(value As String)
            _DescUnidadOrga = value
        End Set
    End Property

    Public Property DireccEstablec As String
        Get
            Return _DireccEstablec
        End Get
        Set(value As String)
            _DireccEstablec = value
        End Set
    End Property

    Public Property EmailTrabajo As String
        Get
            Return _EmailTrabajo
        End Get
        Set(value As String)
            _EmailTrabajo = value
        End Set
    End Property

    Public Property EstadoCivil As String
        Get
            Return _EstadoCivil
        End Get
        Set(value As String)
            _EstadoCivil = value
        End Set
    End Property

    Public Property FechaCumpleanos As String
        Get
            Return _FechaCumpleanos
        End Get
        Set(value As String)
            _FechaCumpleanos = value
        End Set
    End Property


    Public Property FechaNacimiento As String
        Get
            Return _FechaNacimiento
        End Get
        Set(value As String)
            _FechaNacimiento = value
        End Set
    End Property


    Public Property GegcorCodres As String
        Get
            Return _GegcorCodres
        End Get
        Set(value As String)
            _GegcorCodres = value
        End Set
    End Property

    Public Property GegcorDesres As String
        Get
            Return _GegcorDesres
        End Get
        Set(value As String)
            _GegcorDesres = value
        End Set
    End Property

    Public Property GegcorUnidad As String
        Get
            Return _GegcorUnidad
        End Get
        Set(value As String)
            _GegcorUnidad = value
        End Set
    End Property

    Public Property GegcorUnides As String
        Get
            Return _GegcorUnides
        End Get
        Set(value As String)
            _GegcorUnides = value
        End Set
    End Property

    Public Property GercenCodres As String
        Get
            Return _GercenCodres
        End Get
        Set(value As String)
            _GercenCodres = value
        End Set
    End Property

    Public Property GercenDesres As String
        Get
            Return _GercenDesres
        End Get
        Set(value As String)
            _GercenDesres = value
        End Set
    End Property

    Public Property GercenUnidad As String
        Get
            Return _GercenUnidad
        End Get
        Set(value As String)
            _GercenUnidad = value
        End Set
    End Property

    Public Property GercenUnides As String
        Get
            Return _GercenUnides
        End Get
        Set(value As String)
            _GercenUnides = value
        End Set
    End Property

    Public Property GercorCodres As String
        Get
            Return _GercorCodres
        End Get
        Set(value As String)
            _GercorCodres = value
        End Set
    End Property

    Public Property GercorDesres As String
        Get
            Return _GercorDesres
        End Get
        Set(value As String)
            _GercorDesres = value
        End Set
    End Property

    Public Property GercorUnidad As String
        Get
            Return _GercorUnidad
        End Get
        Set(value As String)
            _GercorUnidad = value
        End Set
    End Property

    Public Property GercorUnides As String
        Get
            Return _GercorUnides
        End Get
        Set(value As String)
            _GercorUnides = value
        End Set
    End Property

    Public Property GerdivCodres As String
        Get
            Return _GerdivCodres
        End Get
        Set(value As String)
            _GerdivCodres = value
        End Set
    End Property

    Public Property GerdivDesres As String
        Get
            Return _GerdivDesres
        End Get
        Set(value As String)
            _GerdivDesres = value
        End Set
    End Property

    Public Property GerdivUnidad As String
        Get
            Return _GerdivUnidad
        End Get
        Set(value As String)
            _GerdivUnidad = value
        End Set
    End Property

    Public Property GerdivUnides As String
        Get
            Return _GerdivUnides
        End Get
        Set(value As String)
            _GerdivUnides = value
        End Set
    End Property

    Public Property GerencCodres As String
        Get
            Return _GerencCodres
        End Get
        Set(value As String)
            _GerencCodres = value
        End Set
    End Property

    Public Property GerencDesres As String
        Get
            Return _GerencDesres
        End Get
        Set(value As String)
            _GerencDesres = value
        End Set
    End Property

    Public Property GerencUnidad As String
        Get
            Return _GerencUnidad
        End Get
        Set(value As String)
            _GerencUnidad = value
        End Set
    End Property

    Public Property GerencUnides As String
        Get
            Return _GerencUnides
        End Get
        Set(value As String)
            _GerencUnides = value
        End Set
    End Property

    Public Property GergenCodres As String
        Get
            Return _GergenCodres
        End Get
        Set(value As String)
            _GergenCodres = value
        End Set
    End Property

    Public Property GergenDesres As String
        Get
            Return _GergenDesres
        End Get
        Set(value As String)
            _GergenDesres = value
        End Set
    End Property

    Public Property GergenUnidad As String
        Get
            Return _GergenUnidad
        End Get
        Set(value As String)
            _GergenUnidad = value
        End Set
    End Property

    Public Property GergenUnides As String
        Get
            Return _GergenUnides
        End Get
        Set(value As String)
            _GergenUnides = value
        End Set
    End Property

    Public Property IndMecaViaje As String
        Get
            Return _IndMecaViaje
        End Get
        Set(value As String)
            _IndMecaViaje = value
        End Set
    End Property

    Public Property NombreJefe As String
        Get
            Return _NombreJefe
        End Get
        Set(value As String)
            _NombreJefe = value
        End Set
    End Property

    Public Property NombreSociedad As String
        Get
            Return _NombreSociedad
        End Get
        Set(value As String)
            _NombreSociedad = value
        End Set
    End Property

    Public Property Posicion As String
        Get
            Return _Posicion
        End Get
        Set(value As String)
            _Posicion = value
        End Set
    End Property

    Public Property PrecorCodres As String
        Get
            Return _PrecorCodres
        End Get
        Set(value As String)
            _PrecorCodres = value
        End Set
    End Property

    Public Property PrecorDesres As String
        Get
            Return _PrecorDesres
        End Get
        Set(value As String)
            _PrecorDesres = value
        End Set
    End Property

    Public Property PrecorUnidad As String
        Get
            Return _PrecorUnidad
        End Get
        Set(value As String)
            _PrecorUnidad = value
        End Set
    End Property

    Public Property PrecorUnides As String
        Get
            Return _PrecorUnides
        End Get
        Set(value As String)
            _PrecorUnides = value
        End Set
    End Property

    Public Property Sexo As String
        Get
            Return _Sexo
        End Get
        Set(value As String)
            _Sexo = value
        End Set
    End Property

    Public Property SubdivisionPers As String
        Get
            Return _SubdivisionPers
        End Get
        Set(value As String)
            _SubdivisionPers = value
        End Set
    End Property

    Public Property SubgerCodres As String
        Get
            Return _SubgerCodres
        End Get
        Set(value As String)
            _SubgerCodres = value
        End Set
    End Property

    Public Property SubgerDesres As String
        Get
            Return _SubgerDesres
        End Get
        Set(value As String)
            _SubgerDesres = value
        End Set
    End Property

    Public Property SubgerUnidad As String
        Get
            Return _SubgerUnidad
        End Get
        Set(value As String)
            _SubgerUnidad = value
        End Set
    End Property

    Public Property SubgerUnides As String
        Get
            Return _SubgerUnides
        End Get
        Set(value As String)
            _SubgerUnides = value
        End Set
    End Property

    Public Property TipoDocumento As String
        Get
            Return _TipoDocumento
        End Get
        Set(value As String)
            _TipoDocumento = value
        End Set
    End Property

    Public Property UnidadOrganizat As String
        Get
            Return _UnidadOrganizat
        End Get
        Set(value As String)
            _UnidadOrganizat = value
        End Set
    End Property
End Class
