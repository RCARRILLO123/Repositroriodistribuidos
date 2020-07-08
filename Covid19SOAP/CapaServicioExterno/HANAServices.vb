Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Security
Imports AccesoDatos
Imports CapaModelo
Imports ConsultaTrabjadoresWS
Imports Helper

Public Class HanaServices

    Public Shared Function InvocarServicio(model As Parametro) As RespuestaConsultaTrabajador

        Dim lstResultado As List(Of Usuario) = New List(Of Usuario)()
        Dim response As RespuestaConsultaTrabajador = New RespuestaConsultaTrabajador()
        response.ResponseCode = 0

        Dim da As UsuarioDA = New UsuarioDA()
        Dim cda As CostoDA = New CostoDA()
        Dim paramWS As HanaService.DT_CONSULTA_DATOSTRABAJADORES_REQ = New HanaService.DT_CONSULTA_DATOSTRABAJADORES_REQ()
        Dim clientWS As HanaService.SI_OS_CONSULTA_DATOS_TRABAJADORESService = New HanaService.SI_OS_CONSULTA_DATOS_TRABAJADORESService With {
            .Url = ConfigurationManager.AppSettings.Item("URLHANAWSSAP").ToString(),
            .Timeout = -1,
            .Credentials = New NetworkCredential(ConfigurationManager.AppSettings.Item("UserHANASAP").ToString(), ConfigurationManager.AppSettings.Item("PassHANASAP").ToString(), "")
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

            paramWS.Codigo = IIf(Not String.IsNullOrEmpty(model.Codigo), model.Codigo, "")

            If (String.IsNullOrEmpty(model.Codigo) = True) Then
                paramWS.Codigo = ""
            Else
                'paramWS.Codigo = Enumerable.Repeat(Of String(8 - Len(model.Codigo))
                paramWS.Codigo = New String("0", 8 - Len(model.Codigo)) + model.Codigo
            End If

            paramWS.Nombre = IIf(Not String.IsNullOrEmpty(model.Nombre), String.Format("*{0}*", UCase(model.Nombre)), "")
            paramWS.Sociedad = IIf(Not String.IsNullOrEmpty(model.Sociedad), model.Sociedad, "")

            paramWS.AreaPersonal = IIf(Not String.IsNullOrEmpty(model.AreaPersonal), model.AreaPersonal, "")
            paramWS.CentroCosto = IIf(Not String.IsNullOrEmpty(model.CentroCosto), model.CentroCosto, "")
            paramWS.DivisionPersona = IIf(Not String.IsNullOrEmpty(model.Division), model.Division, "")
            paramWS.EstadoCivil = IIf(Not String.IsNullOrEmpty(model.EstadoCivil), model.EstadoCivil, "")

            If (Not String.IsNullOrEmpty(model.FechaIngreso)) Then
                paramWS.FechaIngreso = Date.Parse(model.FechaIngreso)
            End If
            paramWS.CodigoAutoGen = model.CodigoDBS
            paramWS.NumeroDocumento = IIf(Not String.IsNullOrEmpty(model.NumeroDocumento), model.NumeroDocumento, "")
            paramWS.Posicion = model.Posicion
            paramWS.Sexo = model.Sexo
            paramWS.SubdivisionPersona = model.SubdivisionPers
            paramWS.Unidad_Organizat = model.UnidadOrganizat
            paramWS.FechaCumple = model.Fechacumpleanos

            If clientWS.SI_OS_CONSULTA_DATOS_TRABAJADORES(paramWS).TI_ZTRABAJADORES Is Nothing Then
                response.ResponseMessage = "No existen datos con los parámetros ingresados"
            Else
                'Dim result = clientWS.SI_OS_CONSULTA_DATOS_TRABAJADORES(paramWS).TI_ZTRABAJADORES.ToList()

                lstResultado = (From trabajadorCons In clientWS.SI_OS_CONSULTA_DATOS_TRABAJADORES(paramWS).TI_ZTRABAJADORES.ToList()
                                Join sociedadCons In da.ConsultarListaSociedadUsuario(model.Mandante)
                                On IIf(Not String.IsNullOrEmpty(trabajadorCons.Sociedad), trabajadorCons.Sociedad, "") Equals sociedadCons.SociedadId
                                Where IIf(Not String.IsNullOrEmpty(trabajadorCons.Situacion_Trabaj), trabajadorCons.Situacion_Trabaj, "") = ConfigurationManager.AppSettings.Item("SituacionTrabajadorActivo").ToString()
                                Select New Usuario With
                                    {
                                        .CodigoSAP = IIf(Not String.IsNullOrEmpty(trabajadorCons.Codigo), trabajadorCons.Codigo, ""),
                                        .CodigoDBS = IIf(Not String.IsNullOrEmpty(trabajadorCons.Codigo_Autogener), trabajadorCons.Codigo_Autogener, ""),
                                        .NombresCompletos = IIf(Not String.IsNullOrEmpty(trabajadorCons.Nombre_Completo), trabajadorCons.Nombre_Completo, ""),
                                        .Nombres = IIf(Not String.IsNullOrEmpty(trabajadorCons.Nombre), trabajadorCons.Nombre, ""),
                                        .ApellidoMaterno = IIf(Not String.IsNullOrEmpty(trabajadorCons.Apellido_Materno), trabajadorCons.Apellido_Materno, ""),
                                        .ApellidoPaterno = IIf(Not String.IsNullOrEmpty(trabajadorCons.Apellido_Paterno), trabajadorCons.Apellido_Paterno, ""),
                                        .Corporacion = UCase(Trim(sociedadCons.Corporacion)),
                                        .Compania = UCase(Trim(sociedadCons.Compania)),
                                        .Mandante = IIf(Not String.IsNullOrEmpty(trabajadorCons.Mandt), trabajadorCons.Mandt, ""),
                                        .SituacionTrabajador = IIf(Not String.IsNullOrEmpty(trabajadorCons.Situacion_Trabaj), trabajadorCons.Situacion_Trabaj, ""),
                                        .Sociedad = IIf(Not String.IsNullOrEmpty(trabajadorCons.Sociedad), trabajadorCons.Sociedad, ""),
                                        .LugarComercial = IIf(Not String.IsNullOrEmpty(trabajadorCons.Lugar_Comercial), trabajadorCons.Lugar_Comercial, ""),
                                        .CentroCosto = "",
                                        .Division = IIf(Not String.IsNullOrEmpty(trabajadorCons.Division_Persona), "", ""),
                                        .Matricula = IIf(Len(IIf(Not String.IsNullOrEmpty(trabajadorCons.Codigo_Autogener), trabajadorCons.Codigo_Autogener, "").Trim()) > 0,
                                                        IIf(Not String.IsNullOrEmpty(trabajadorCons.Codigo_Autogener), trabajadorCons.Codigo_Autogener, "").Trim().PadLeft(10, "0"),
                                                        IIf(Not String.IsNullOrEmpty(trabajadorCons.Codigo_Autogener), trabajadorCons.Codigo_Autogener, "").Trim()),
                                        .AreaPersonal = IIf(Not String.IsNullOrEmpty(trabajadorCons.Area_Personal), trabajadorCons.Area_Personal, ""),
                                        .AreafeCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.AreaFe_Codres), trabajadorCons.AreaFe_Codres, ""),
                                        .AreafeDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.AreaFe_Desres), trabajadorCons.AreaFe_Desres, ""),
                                        .AreafeUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.AreaFe_Unidad), trabajadorCons.AreaFe_Unidad, ""),
                                        .AreafeUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.AreaFe_Unides), trabajadorCons.AreaFe_Unides, ""),
                                        .CodigoJefe = IIf(Not String.IsNullOrEmpty(trabajadorCons.Codigo_Jefe), trabajadorCons.Codigo_Jefe, ""),
                                        .CupId = IIf(Not String.IsNullOrEmpty(trabajadorCons.Cup_ID), trabajadorCons.Cup_ID, ""),
                                        .CwsId = IIf(Not String.IsNullOrEmpty(trabajadorCons.Cws_ID), trabajadorCons.Cws_ID, ""),
                                        .DescAreaPerson = IIf(Not String.IsNullOrEmpty(trabajadorCons.Desc_Area_Person), trabajadorCons.Desc_Area_Person, ""),
                                        .DescCentroCost = IIf(Not String.IsNullOrEmpty(trabajadorCons.Desc_Centro_Cost), trabajadorCons.Desc_Centro_Cost, ""),
                                        .DescDivisionPe = IIf(Not String.IsNullOrEmpty(trabajadorCons.Desc_Division_Pe), trabajadorCons.Desc_Division_Pe, ""),
                                        .DescPosicion = IIf(Not String.IsNullOrEmpty(trabajadorCons.Desc_Posicion), trabajadorCons.Desc_Posicion, ""),
                                        .DescSubdivision = IIf(Not String.IsNullOrEmpty(trabajadorCons.Desc_Subdivision), trabajadorCons.Desc_Subdivision, ""),
                                        .DescUnidadOrga = IIf(Not String.IsNullOrEmpty(trabajadorCons.Desc_Unidad_Orga), trabajadorCons.Desc_Unidad_Orga, ""),
                                        .DireccEstablec = IIf(Not String.IsNullOrEmpty(trabajadorCons.Direcc_Establec), trabajadorCons.Direcc_Establec, ""),
                                        .EmailTrabajo = IIf(Not String.IsNullOrEmpty(trabajadorCons.Email_Trabajo), trabajadorCons.Email_Trabajo, ""),
                                        .EstadoCivil = IIf(Not String.IsNullOrEmpty(trabajadorCons.Estado_Civil), trabajadorCons.Estado_Civil, ""),
                                        .FechaCumpleanos = IIf(Not String.IsNullOrEmpty(trabajadorCons.Fecha_Cumpleanos), trabajadorCons.Fecha_Cumpleanos, ""),
                                        .FechaIngreso = IIf(Not String.IsNullOrEmpty(trabajadorCons.Fecha_Ingreso), trabajadorCons.Fecha_Ingreso, ""),
                                        .FechaNacimiento = IIf(Not String.IsNullOrEmpty(trabajadorCons.Fecha_Nacimiento), trabajadorCons.Fecha_Nacimiento, ""),
                                        .FechaRetiro = IIf(Not String.IsNullOrEmpty(trabajadorCons.Fecha_Retiro), trabajadorCons.Fecha_Retiro, ""),
                                        .GegcorCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GegCor_Codres), trabajadorCons.GegCor_Codres, ""),
                                        .GegcorDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GegCor_Desres), trabajadorCons.GegCor_Desres, ""),
                                        .GegcorUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GegCor_Unidad), trabajadorCons.GegCor_Unidad, ""),
                                        .GegcorUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GegCor_Unides), trabajadorCons.GegCor_Unides, ""),
                                        .GercenCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerCen_Codres), trabajadorCons.GerCen_Codres, ""),
                                        .GercenDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerCen_Desres), trabajadorCons.GerCen_Desres, ""),
                                        .GercenUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerCen_Unidad), trabajadorCons.GerCen_Unidad, ""),
                                        .GercenUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerCen_Unides), trabajadorCons.GerCen_Unides, ""),
                                        .GercorCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerCor_Codres), trabajadorCons.GerCor_Codres, ""),
                                        .GercorDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerCor_Desres), trabajadorCons.GerCor_Desres, ""),
                                        .GercorUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerCor_Unidad), trabajadorCons.GerCor_Unidad, ""),
                                        .GercorUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerCor_Unides), trabajadorCons.GerCor_Unides, ""),
                                        .GerdivCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerDiv_Codres), trabajadorCons.GerDiv_Codres, ""),
                                        .GerdivDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerDiv_Desres), trabajadorCons.GerDiv_Desres, ""),
                                        .GerdivUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerDiv_Unidad), trabajadorCons.GerDiv_Unidad, ""),
                                        .GerdivUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerDiv_Unides), trabajadorCons.GerDiv_Unides, ""),
                                        .GerencCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.Gerenc_Codres), trabajadorCons.Gerenc_Codres, ""),
                                        .GerencDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.Gerenc_Desres), trabajadorCons.Gerenc_Desres, ""),
                                        .GerencUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.Gerenc_Unidad), trabajadorCons.Gerenc_Unidad, ""),
                                        .GerencUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.Gerenc_Unides), trabajadorCons.Gerenc_Unides, ""),
                                        .GergenCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerGen_Codres), trabajadorCons.GerGen_Codres, ""),
                                        .GergenDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerGen_Desres), trabajadorCons.GerGen_Desres, ""),
                                        .GergenUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerGen_Unidad), trabajadorCons.GerGen_Unidad, ""),
                                        .GergenUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.GerGen_Unides), trabajadorCons.GerGen_Unides, ""),
                                        .IndMecaViaje = IIf(Not String.IsNullOrEmpty(trabajadorCons.Ind_Meca_Viaje), trabajadorCons.Ind_Meca_Viaje, ""),
                                        .NombreJefe = IIf(Not String.IsNullOrEmpty(trabajadorCons.Nombre_Jefe), trabajadorCons.Nombre_Jefe, ""),
                                        .NombreSociedad = IIf(Not String.IsNullOrEmpty(trabajadorCons.Nombre_Sociedad), trabajadorCons.Nombre_Sociedad, ""),
                                        .NumeroDocumento = IIf(Not String.IsNullOrEmpty(trabajadorCons.Numero_Documento), trabajadorCons.Numero_Documento, ""),
                                        .Posicion = IIf(Not String.IsNullOrEmpty(trabajadorCons.Posicion), trabajadorCons.Posicion, ""),
                                        .PrecorCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.Precor_Codres), trabajadorCons.Precor_Codres, ""),
                                        .PrecorDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.Precor_Desres), trabajadorCons.Precor_Desres, ""),
                                        .PrecorUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.Precor_Unidad), trabajadorCons.Precor_Unidad, ""),
                                        .PrecorUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.Precor_Unides), trabajadorCons.Precor_Unides, ""),
                                        .Sexo = IIf(Not String.IsNullOrEmpty(trabajadorCons.Sexo), trabajadorCons.Sexo, ""),
                                        .SubdivisionPers = IIf(Not String.IsNullOrEmpty(trabajadorCons.Subdivision_Pers), trabajadorCons.Subdivision_Pers, ""),
                                        .SubgerCodres = IIf(Not String.IsNullOrEmpty(trabajadorCons.SubGer_Codres), trabajadorCons.SubGer_Codres, ""),
                                        .SubgerDesres = IIf(Not String.IsNullOrEmpty(trabajadorCons.SubGer_Desres), trabajadorCons.SubGer_Desres, ""),
                                        .SubgerUnidad = IIf(Not String.IsNullOrEmpty(trabajadorCons.SubGer_Unidad), trabajadorCons.SubGer_Unidad, ""),
                                        .SubgerUnides = IIf(Not String.IsNullOrEmpty(trabajadorCons.SubGer_Unides), trabajadorCons.SubGer_Unides, ""),
                                        .TipoDocumento = IIf(Not String.IsNullOrEmpty(trabajadorCons.Tipo_Documento), trabajadorCons.Tipo_Documento, ""),
                                        .UnidadOrganizat = IIf(Not String.IsNullOrEmpty(trabajadorCons.Unidad_Organizat), trabajadorCons.Unidad_Organizat, "")
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

                                             Dim CentroCosto = cda.ConsultarCostoPorTrabajador(model.Mandante, model.Sociedad, item.CentroCosto)

                                             aryCCosto = Split(Trim(CentroCosto), "-")
                                             ''
                                             Select Case aryCCosto.Length
                                                 Case 1
                                                     item.CentroCosto = aryCCosto(0).TrimStart("0")
                                                     item.Oficina = da.ConsultarOficinaXSociedad(model.Mandante, UCase(Trim(model.Sociedad)), item.Division)
                                                 Case 3
                                                     item.CentroCosto = aryCCosto(2)
                                                     item.Oficina = aryCCosto(1)

                                             End Select

                                         End If
                                         If Trim(item.Compania) <> "" And Trim(item.Oficina) <> "" Then
                                             item.CentroId = da.ConsultarListaAlmacenOficina(UCase(Trim(item.Compania)), item.Oficina).Centro
                                         End If

                                     End Sub)
                response.ResponseContent = lstResultado
            End If
        Catch ex As SqlException
            HelperLog.PutLineError(ex.Message)
            response.ResponseMessage = String.Format("{0}: {1}", "Error dentro del proceso HANA", ex.Message.Replace(vbCrLf, " "))
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
            response.ResponseMessage = String.Format("{0}: {1}", "Error dentro del proceso HANA", ex.Message.Replace(vbCrLf, " "))
            response.ResponseCode = Constantes.Tecnical1
        Finally
            clientWS.Dispose()
            clientWS = Nothing
        End Try

        Return response

    End Function


    Public Shared Function InvocarServicioUnidad(model As ParametroUO) As RespuestaConsultaUnidadOrganizativa

        Dim da As UsuarioDA = New UsuarioDA()

        Dim lstResultado As List(Of UnidadOrganizativa) = New List(Of UnidadOrganizativa)()
        Dim response As RespuestaConsultaUnidadOrganizativa = New RespuestaConsultaUnidadOrganizativa()
        response.ResponseCode = 0


        Dim paramWS As wsHanaUnidadesOrganizativas.DT_CONSULTA_UNIDAD_ORGANIZATIVA_REQ = New wsHanaUnidadesOrganizativas.DT_CONSULTA_UNIDAD_ORGANIZATIVA_REQ()

        'Dim clientWS As HanaService.SI_OS_CONSULTA_DATOS_TRABAJADORESService = New HanaService.SI_OS_CONSULTA_DATOS_TRABAJADORESService With {
        Dim clientWS As wsHanaUnidadesOrganizativas.SI_OS_CONSULTA_UNIDAD_ORGANIZATIVAService = New wsHanaUnidadesOrganizativas.SI_OS_CONSULTA_UNIDAD_ORGANIZATIVAService With {
            .Url = ConfigurationManager.AppSettings.Item("URLHANAWSSAPuo").ToString(),
            .Timeout = -1,
            .Credentials = New NetworkCredential(ConfigurationManager.AppSettings.Item("UserHANASAPuo").ToString(), ConfigurationManager.AppSettings.Item("PassHANASAPuo").ToString(), "")
        }

        Try
            paramWS.Unidad_Orga = IIf(Not String.IsNullOrEmpty(model.UnidadOrganizat), model.UnidadOrganizat, "")
            paramWS.Sociedad = IIf(Not String.IsNullOrEmpty(model.Sociedad), model.Sociedad, "")
            paramWS.Unidad_OrgSup = IIf(Not String.IsNullOrEmpty(model.UnidadOrganizatSup), model.UnidadOrganizatSup, "")
            paramWS.Desc_UnidadOrga = IIf(Not String.IsNullOrEmpty(model.DescUnidadOrganizat), model.DescUnidadOrganizat, "")
            paramWS.Codigo_Responsable = IIf(Not String.IsNullOrEmpty(model.CodigoResponsable), model.CodigoResponsable, "")
            paramWS.Sit_Func = IIf(Not String.IsNullOrEmpty(model.SituacionFunc), model.SituacionFunc, "")

            lstResultado = (From unidadCons In clientWS.SI_OS_CONSULTA_UNIDAD_ORGANIZATIVA(paramWS).ToList()
                            Select New UnidadOrganizativa With
                                {
                                    .Corporacion = unidadCons.Corporacion,
                                    .Sociedad = unidadCons.Sociedad,
                                    .UnidadOrganizativa = unidadCons.Unidad_Orga,
                                    .UnidadOrganizativaSup = unidadCons.Unid_Organiz_Sup,
                                    .DescUnidadOrganizativa = unidadCons.Desc_Unidad_Orga,
                                    .CodigoResponsable = unidadCons.Codigo_Responsable,
                                    .Funciones = unidadCons.Funciones,
                                    .SituacionUnidFunc = unidadCons.Sit_Unid_Func,
                                    .Nivel = unidadCons.Nivel
                                    }).ToList()

            response.ResponseContent = lstResultado

        Catch ex As SqlException
            HelperLog.PutLineError(ex.Message)
            response.ResponseMessage = String.Format("{0}: {1}", "Error dentro del proceso HANA", ex.Message.Replace(vbCrLf, " "))
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
            response.ResponseMessage = String.Format("{0}: {1}", "Error dentro del proceso HANA", ex.Message.Replace(vbCrLf, " "))
            response.ResponseCode = Constantes.Tecnical1
        Finally
            clientWS.Dispose()
            clientWS = Nothing
        End Try

        Return response

    End Function



End Class
