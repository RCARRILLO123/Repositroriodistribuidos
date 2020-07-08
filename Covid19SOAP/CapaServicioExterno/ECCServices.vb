Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Net
Imports AccesoDatos
Imports CapaModelo
Imports ConsultaTrabjadoresWS
Imports Helper

Public Class ECCServices

    Public Shared Function InvocarServicio(model As Parametro) As RespuestaConsultaTrabajador

        Dim lstResultado As List(Of Usuario) = New List(Of Usuario)()
        Dim response As RespuestaConsultaTrabajador = New RespuestaConsultaTrabajador()
        response.ResponseCode = 0

        Dim da As UsuarioDA = New UsuarioDA()

        Dim paramWS As EccService.ConsultaTrab = New EccService.ConsultaTrab()
        Dim clientWS As EccService.SERVICETRABAJADOR = New EccService.SERVICETRABAJADOR With {
            .Url = String.Format("{0}/zwshr_trabajador_pe/{1}/servicetrabajador/servicetrabajador", ConfigurationManager.AppSettings.Item("URLECCWSSAP").ToString(), model.Mandante),
            .Timeout = -1,
            .Credentials = New NetworkCredential(ConfigurationManager.AppSettings.Item("UserECCSAP").ToString(), ConfigurationManager.AppSettings.Item("PassECCSAP").ToString(), "")
        }

        Try

            If (model.Codigo = "" And
               model.Nombre = "" And
               model.Sociedad = "" And
               model.AreaPersonal = "" And
               model.CentroCosto = "" And
               model.Division = "" And
               model.EstadoCivil = "" And
               model.FechaIngreso = "" And
               model.NumeroDocumento = "" And
               model.Posicion = "" And
               model.Sexo = "" And
               model.SubdivisionPers = "" And
               model.UnidadOrganizat = "" And
               model.CodigoDBS = "") Then
                Return response
            End If

            Dim arySoc As String()
            response.ResponseCode = 0
            Dim SociedadesECC As String = ConfigurationManager.AppSettings.Item("SociedadesECC").ToString()
            arySoc = Split(Trim(SociedadesECC), ",")

            'paramWS.Codigo = IIf(Not String.IsNullOrEmpty(model.Codigo), model.Codigo, "")

            If (String.IsNullOrEmpty(model.Codigo) = True) Then
                paramWS.Codigo = ""
            Else
                paramWS.Codigo = New String("0", 8 - Len(model.Codigo)) + model.Codigo
            End If

            paramWS.Nombre = IIf(Not String.IsNullOrEmpty(model.Nombre), String.Format("*{0}*", UCase(model.Nombre)), "")
            paramWS.Sociedad = IIf(Not String.IsNullOrEmpty(model.Sociedad), model.Sociedad, "")

            paramWS.AreaPersonal = IIf(Not String.IsNullOrEmpty(model.AreaPersonal), model.AreaPersonal, "")
            paramWS.CentroCosto = IIf(Not String.IsNullOrEmpty(model.CentroCosto), model.CentroCosto, "")
            paramWS.DivisionPersona = IIf(Not String.IsNullOrEmpty(model.Division), model.Division, "")
            paramWS.EstadoCivil = IIf(Not String.IsNullOrEmpty(model.EstadoCivil), model.EstadoCivil, "")
            paramWS.FechaIngreso = IIf(Not String.IsNullOrEmpty(model.FechaIngreso), model.FechaIngreso, "")
            paramWS.NumeroDocumento = IIf(Not String.IsNullOrEmpty(model.NumeroDocumento), model.NumeroDocumento, "")
            paramWS.Posicion = model.Posicion
            paramWS.Sexo = model.Sexo
            paramWS.SubdivisionPers = model.SubdivisionPers
            paramWS.UnidadOrganizat = model.UnidadOrganizat
            paramWS.CodigoAutogenerado = IIf(Not String.IsNullOrEmpty(model.CodigoDBS), model.CodigoDBS, "")
            paramWS.Fechacumpleanos = model.Fechacumpleanos

            paramWS.Ttrabajador = (New List(Of EccService.Ztrabajadores)).ToArray()

            'Dim result = clientWS.ConsultaTrab(paramWS).Ttrabajador().ToList()
            lstResultado = (From trabajadorCons In clientWS.ConsultaTrab(paramWS).Ttrabajador().ToList()
                            Join sociedadCons In da.ConsultarListaSociedadUsuario(model.Mandante)
                                       On IIf(Not String.IsNullOrEmpty(trabajadorCons.Sociedad), trabajadorCons.Sociedad, "") Equals sociedadCons.SociedadId
                            Where (IIf(Not String.IsNullOrEmpty(trabajadorCons.SituacionTrabaj), trabajadorCons.SituacionTrabaj, "") = ConfigurationManager.AppSettings.Item("SituacionTrabajadorActivo").ToString() And arySoc.Contains(trabajadorCons.Sociedad))
                            Select New Usuario With
                                {
                                    .CodigoSAP = IIf(Not String.IsNullOrEmpty(trabajadorCons.Codigo), trabajadorCons.Codigo, ""),
                                    .CodigoDBS = IIf(Not String.IsNullOrEmpty(trabajadorCons.CodigoAutogener), trabajadorCons.CodigoAutogener, ""),
                                    .NombresCompletos = IIf(Not String.IsNullOrEmpty(trabajadorCons.NombreCompleto), trabajadorCons.NombreCompleto, ""),
                                    .Nombres = IIf(Not String.IsNullOrEmpty(trabajadorCons.Nombre), trabajadorCons.Nombre, ""),
                                    .ApellidoMaterno = IIf(Not String.IsNullOrEmpty(trabajadorCons.ApellidoMaterno), trabajadorCons.ApellidoMaterno, ""),
                                    .ApellidoPaterno = IIf(Not String.IsNullOrEmpty(trabajadorCons.ApellidoPaterno), trabajadorCons.ApellidoPaterno, ""),
                                    .Corporacion = UCase(Trim(sociedadCons.Corporacion)),
                                    .Compania = UCase(Trim(sociedadCons.Compania)),
                                    .Mandante = IIf(Not String.IsNullOrEmpty(trabajadorCons.Mandt), trabajadorCons.Mandt, ""),
                                    .SituacionTrabajador = IIf(Not String.IsNullOrEmpty(trabajadorCons.SituacionTrabaj), trabajadorCons.SituacionTrabaj, ""),
                                    .Sociedad = IIf(Not String.IsNullOrEmpty(trabajadorCons.Sociedad), trabajadorCons.Sociedad, ""),
                                    .LugarComercial = IIf(Not String.IsNullOrEmpty(trabajadorCons.LugarComercial), trabajadorCons.LugarComercial, ""),
                                    .CentroCosto = IIf(Not String.IsNullOrEmpty(trabajadorCons.CentroCosto), trabajadorCons.CentroCosto, ""),
                                    .Division = IIf(Not String.IsNullOrEmpty(trabajadorCons.DivisionPersona), trabajadorCons.DivisionPersona, ""),
                                    .Matricula = IIf(Len(IIf(Not String.IsNullOrEmpty(trabajadorCons.CodigoAutogener), trabajadorCons.CodigoAutogener, "").Trim()) > 0,
                                                     IIf(Not String.IsNullOrEmpty(trabajadorCons.CodigoAutogener), trabajadorCons.CodigoAutogener, "").Trim().PadLeft(10, "0"),
                                                     IIf(Not String.IsNullOrEmpty(trabajadorCons.CodigoAutogener), trabajadorCons.CodigoAutogener, "").Trim()),
                                    .AreaPersonal = IIf(Not String.IsNullOrEmpty(trabajadorCons.AreaPersonal), trabajadorCons.AreaPersonal, ""),
                                    .AreafeCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.AreafeCodres), trabajadorCons.AreafeCodres, ""),
                                    .AreafeDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.AreafeDesres), trabajadorCons.AreafeDesres, ""),
                                    .AreafeUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.AreafeUnidad), trabajadorCons.AreafeUnidad, ""),
                                    .AreafeUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.AreafeUnides), trabajadorCons.AreafeUnides, ""),
                                    .CodigoJefe = IIf(Not String.IsNullOrEmpty(trabajadorCons.CodigoJefe), trabajadorCons.CodigoJefe, ""),
                                    .CupId = IIf(Not String.IsNullOrEmpty(trabajadorCons.CupId), trabajadorCons.CupId, ""),
                                    .CwsId = IIf(Not String.IsNullOrEmpty(trabajadorCons.CwsId), trabajadorCons.CwsId, ""),
                                    .DescAreaPerson = IIf(Not String.IsNullOrEmpty(trabajadorCons.DescAreaPerson), trabajadorCons.DescAreaPerson, ""),
                                    .DescCentroCost = IIf(Not String.IsNullOrEmpty(trabajadorCons.DescCentroCost), trabajadorCons.DescCentroCost, ""),
                                    .DescDivisionPe = IIf(Not String.IsNullOrEmpty(trabajadorCons.DescDivisionPe), trabajadorCons.DescDivisionPe, ""),
                                    .DescPosicion = IIf(Not String.IsNullOrEmpty(trabajadorCons.DescPosicion), trabajadorCons.DescPosicion, ""),
                                    .DescSubdivision = IIf(Not String.IsNullOrEmpty(trabajadorCons.DescSubdivision), trabajadorCons.DescSubdivision, ""),
                                    .DescUnidadOrga = IIf(Not String.IsNullOrEmpty(trabajadorCons.DescUnidadOrga), trabajadorCons.DescUnidadOrga, ""),
                                    .DireccEstablec = IIf(Not String.IsNullOrEmpty(trabajadorCons.DireccEstablec), trabajadorCons.DireccEstablec, ""),
                                    .EmailTrabajo = IIf(Not String.IsNullOrEmpty(trabajadorCons.EmailTrabajo), trabajadorCons.EmailTrabajo, ""),
                                    .EstadoCivil = IIf(Not String.IsNullOrEmpty(trabajadorCons.EstadoCivil), trabajadorCons.EstadoCivil, ""),
                                    .FechaCumpleanos = IIf(Not String.IsNullOrEmpty(trabajadorCons.FechaCumpleanos), trabajadorCons.FechaCumpleanos, ""),
                                    .FechaIngreso = IIf(Not String.IsNullOrEmpty(trabajadorCons.FechaIngreso), trabajadorCons.FechaIngreso, ""),
                                    .FechaNacimiento = IIf(Not String.IsNullOrEmpty(trabajadorCons.FechaNacimiento), trabajadorCons.FechaNacimiento, ""),
                                    .FechaRetiro = IIf(Not String.IsNullOrEmpty(trabajadorCons.FechaRetiro), trabajadorCons.FechaRetiro, ""),
                                    .GegcorCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GegcorCodres), trabajadorCons.GegcorCodres, ""),
                                    .GegcorDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GegcorDesres), trabajadorCons.GegcorDesres, ""),
                                    .GegcorUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GegcorUnidad), trabajadorCons.GegcorUnidad, ""),
                                    .GegcorUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GegcorUnides), trabajadorCons.GegcorUnides, ""),
                                    .GercenCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GercenCodres), trabajadorCons.GercenCodres, ""),
                                    .GercenDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GercenDesres), trabajadorCons.GercenDesres, ""),
                                    .GercenUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GercenUnidad), trabajadorCons.GercenUnidad, ""),
                                    .GercenUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GercenUnides), trabajadorCons.GercenUnides, ""),
                                    .GercorCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GercorCodres), trabajadorCons.GercorCodres, ""),
                                    .GercorDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GercorDesres), trabajadorCons.GercorDesres, ""),
                                    .GercorUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GercorUnidad), trabajadorCons.GercorUnidad, ""),
                                    .GercorUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GercorUnides), trabajadorCons.GercorUnides, ""),
                                    .GerdivCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerdivCodres), trabajadorCons.GerdivCodres, ""),
                                    .GerdivDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerdivDesres), trabajadorCons.GerdivDesres, ""),
                                    .GerdivUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerdivUnidad), trabajadorCons.GerdivUnidad, ""),
                                    .GerdivUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerdivUnides), trabajadorCons.GerdivUnides, ""),
                                    .GerencCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerencCodres), trabajadorCons.GerencCodres, ""),
                                    .GerencDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerencDesres), trabajadorCons.GerencDesres, ""),
                                    .GerencUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerencUnidad), trabajadorCons.GerencUnidad, ""),
                                    .GerencUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerencUnides), trabajadorCons.GerencUnides, ""),
                                    .GergenCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GergenCodres), trabajadorCons.GergenCodres, ""),
                                    .GergenDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GergenDesres), trabajadorCons.GergenDesres, ""),
                                    .GergenUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GergenUnidad), trabajadorCons.GergenUnidad, ""),
                                    .GergenUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GergenUnides), trabajadorCons.GergenUnides, ""),
                                    .IndMecaViaje = IIf(Not String.IsNullOrEmpty(trabajadorCons.IndMecaViaje), trabajadorCons.IndMecaViaje, ""),
                                    .NombreJefe = IIf(Not String.IsNullOrEmpty(trabajadorCons.NombreJefe), trabajadorCons.NombreJefe, ""),
                                    .NombreSociedad = IIf(Not String.IsNullOrEmpty(trabajadorCons.NombreSociedad), trabajadorCons.NombreSociedad, ""),
                                    .NumeroDocumento = IIf(Not String.IsNullOrEmpty(trabajadorCons.NumeroDocumento), trabajadorCons.NumeroDocumento, ""),
                                    .Posicion = IIf(Not String.IsNullOrEmpty(trabajadorCons.Posicion), trabajadorCons.Posicion, ""),
                                    .PrecorCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.PrecorCodres), trabajadorCons.PrecorCodres, ""),
                                    .PrecorDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.PrecorDesres), trabajadorCons.PrecorDesres, ""),
                                    .PrecorUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.PrecorUnidad), trabajadorCons.PrecorUnidad, ""),
                                    .PrecorUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.PrecorUnides), trabajadorCons.PrecorUnides, ""),
                                    .Sexo = IIf(Not String.IsNullOrEmpty(trabajadorCons.Sexo), trabajadorCons.Sexo, ""),
                                    .SubdivisionPers = IIf(Not String.IsNullOrEmpty(trabajadorCons.SubdivisionPers), trabajadorCons.SubdivisionPers, ""),
                                    .SubgerCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.SubgerCodres), trabajadorCons.SubgerCodres, ""),
                                    .SubgerDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.SubgerDesres), trabajadorCons.SubgerDesres, ""),
                                    .SubgerUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.SubgerUnidad), trabajadorCons.SubgerUnidad, ""),
                                    .SubgerUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.SubgerUnides), trabajadorCons.SubgerUnides, ""),
                                    .TipoDocumento = IIf(Not String.IsNullOrEmpty(trabajadorCons.TipoDocumento), trabajadorCons.TipoDocumento, ""),
                                    .UnidadOrganizat = IIf(Not String.IsNullOrEmpty(trabajadorCons.UnidadOrganizat), trabajadorCons.UnidadOrganizat, "")
                                }).ToList()

            lstResultado.ForEach(Sub(item)
                                     Dim aryCCosto As String()
                                     Dim objUsuarios As Usuario = New Usuario()

                                     If item.SituacionTrabajador.ToString().Trim() = ConfigurationManager.AppSettings.Item("SituacionTrabajadorCesado").ToString() Then
                                         objUsuarios = da.ConsultarDatosTrabajadorSociedad(item.Sociedad, item.CodigoSAP).SingleOrDefault()
                                         If Not IsNothing(objUsuarios) Then
                                             item.CodigoAutogenerado = objUsuarios.CodigoAutogenerado
                                             item.Matricula = IIf(Len(objUsuarios.CodigoAutogenerado.Trim()) > 0, objUsuarios.CodigoAutogenerado.Trim().PadLeft(10, "0"), objUsuarios.CodigoAutogenerado.Trim())
                                             item.CentroCosto = objUsuarios.CentroCosto
                                             item.SituacionTrabajador = objUsuarios.SituacionTrabajador
                                             item.LugarComercial = objUsuarios.LugarComercial

                                         End If
                                     End If

                                     If Len(Trim(item.CentroCosto)) > 0 Then
                                         aryCCosto = Split(Trim(item.CentroCosto), "-")
                                         Select Case aryCCosto.Length
                                             Case 1
                                                 item.CentroCosto = aryCCosto(0).TrimStart("0")
                                                 item.Oficina = da.ConsultarOficinaXSociedad(model.Mandante, UCase(Trim(model.Sociedad)), item.Division)
                                             Case 3
                                                 item.CentroCosto = aryCCosto(2)
                                                 item.Oficina = aryCCosto(1)

                                         End Select
                                     Else
                                         If UCase(Trim(model.Sociedad)) = ConfigurationManager.AppSettings.Item("CodigoSociedadUnimaq").ToString() Then
                                             item.CentroCosto = ConfigurationManager.AppSettings.Item("CentroCosto50").ToString()
                                             item.Oficina = da.ConsultarOficinaXSociedad(model.Mandante, UCase(Trim(model.Sociedad)), item.Division)
                                         Else
                                             item.CentroCosto = ""
                                             item.Oficina = ""
                                         End If
                                     End If

                                     If Trim(item.Compania) <> "" And Trim(item.Oficina) <> "" Then
                                         item.CentroId = da.ConsultarListaAlmacenOficina(UCase(Trim(item.Compania)), item.Oficina).Centro
                                     End If

                                 End Sub)

            response.ResponseContent = lstResultado

        Catch ex As SqlException
            HelperLog.PutLineError(ex.Message)
            response.ResponseMessage = String.Format("{0}: {1}", "Error dentro del proceso ECC", ex.Message.Replace(vbCrLf, " "))
            Select Case ex.Number
                Case -2
                    response.ResponseCode = Constantes.Tecnical2
                Case -53
                    response.ResponseCode = Constantes.Tecnical3
                Case Else
                    response.ResponseCode = Constantes.Tecnical1
            End Select

        Catch ex As Exception
            HelperLog.PutLineError(ex.Message)
            response.ResponseMessage = String.Format("{0}: {1}", "Error dentro del proceso ECC", ex.Message.Replace(vbCrLf, " "))
            response.ResponseCode = Constantes.Tecnical1
        Finally
            clientWS.Dispose()
            clientWS = Nothing
        End Try

        Return response

    End Function


    Public Shared Function InvocarServicioUnidad(model As ParametroUO) As RespuestaConsultaUnidadOrganizativa

        Dim lstResultado As List(Of UnidadOrganizativa) = New List(Of UnidadOrganizativa)()
        Dim response As RespuestaConsultaUnidadOrganizativa = New RespuestaConsultaUnidadOrganizativa()
        response.ResponseCode = 0

        Dim da As UsuarioDA = New UsuarioDA()

        Dim paramWS As EccService.ConsultarUnidorg = New EccService.ConsultarUnidorg()

        Dim clientWS As EccService.SERVICETRABAJADOR = New EccService.SERVICETRABAJADOR With {
            .Url = String.Format("{0}/zwshr_trabajador_pe/{1}/servicetrabajador/servicetrabajador", ConfigurationManager.AppSettings.Item("URLECCWSSAP").ToString(), ConfigurationManager.AppSettings.Item("MandanteECC").ToString()),
            .Timeout = -1,
            .Credentials = New NetworkCredential(ConfigurationManager.AppSettings.Item("UserECCSAP").ToString(), ConfigurationManager.AppSettings.Item("PassECCSAP").ToString(), "")
        }

        Try
            paramWS.UnidadOrg = IIf(Not String.IsNullOrEmpty(model.UnidadOrganizat), model.UnidadOrganizat, "")
            paramWS.Sociedad = IIf(Not String.IsNullOrEmpty(model.Sociedad), model.Sociedad, "")
            paramWS.UnidadOrgSup = IIf(Not String.IsNullOrEmpty(model.UnidadOrganizatSup), model.UnidadOrganizatSup, "")
            paramWS.DesUnidadOrg = IIf(Not String.IsNullOrEmpty(model.DescUnidadOrganizat), model.DescUnidadOrganizat, "")
            paramWS.Responsable = IIf(Not String.IsNullOrEmpty(model.CodigoResponsable), model.CodigoResponsable, "")
            paramWS.Situacion_Funciones = IIf(Not String.IsNullOrEmpty(model.SituacionFunc), model.SituacionFunc, "")

            paramWS.TUnidadOrg = (New List(Of EccService.ZundOrganizativ)).ToArray()

            lstResultado = (From unidadCons In clientWS.ConsultarUnidorg(paramWS).TUnidadOrg().ToList()
                            Select New UnidadOrganizativa With
                                {
                                    .Corporacion = unidadCons.Corporacion,
                                    .Sociedad = unidadCons.Sociedad,
                                    .UnidadOrganizativa = unidadCons.UnidadOrganizat,
                                    .UnidadOrganizativaSup = unidadCons.UnidOrganizSup,
                                    .DescUnidadOrganizativa = unidadCons.DescUnidadOrga,
                                    .CodigoResponsable = unidadCons.CodigoResponsab,
                                    .Funciones = unidadCons.Funciones,
                                    .SituacionUnidFunc = unidadCons.SitUnidFunc,
                                    .Nivel = unidadCons.Nivel
                                    }).ToList()

            response.ResponseContent = lstResultado

        Catch ex As SqlException
            HelperLog.PutLineError(ex.Message)
            response.ResponseMessage = String.Format("{0}: {1}", "Error dentro del proceso ECC", ex.Message.Replace(vbCrLf, " "))
            Select Case ex.Number
                Case -2
                    response.ResponseCode = Constantes.Tecnical2
                Case -53
                    response.ResponseCode = Constantes.Tecnical3
                Case Else
                    response.ResponseCode = Constantes.Tecnical1
            End Select

        Catch ex As Exception
            HelperLog.PutLineError(ex.Message)
            response.ResponseMessage = String.Format("{0}: {1}", "Error dentro del proceso ECC", ex.Message.Replace(vbCrLf, " "))
            response.ResponseCode = Constantes.Tecnical1
        Finally
            clientWS.Dispose()
            clientWS = Nothing
        End Try

        Return response

    End Function


End Class
