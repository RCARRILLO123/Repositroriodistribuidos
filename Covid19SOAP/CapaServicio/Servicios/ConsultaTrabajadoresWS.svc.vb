' NOTE: You can use the "Rename" command on the context menu to change the class name "ConsultaTrabjadoresWS" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select ConsultaTrabjadoresWS.svc or ConsultaTrabjadoresWS.svc.vb at the Solution Explorer and start debugging.
Imports CapaModelo
Imports Helper
Imports ServicioExterno



Public Class ConsultaTrabjadoresWS

    Implements IConsultaTrabajadoresWS

    Public Function ObtenerDatosTrabajador(ByVal model As Parametro) As RespuestaConsultaTrabajador Implements IConsultaTrabajadoresWS.ObtenerDatosTrabajador

        Dim response As RespuestaConsultaTrabajador
        response = Validar(model)

        If response.ResponseCode = Constantes.RespuestaExitosa Then

            Dim eccResponse As RespuestaConsultaTrabajador = New RespuestaConsultaTrabajador()
            Dim hanaResponse As RespuestaConsultaTrabajador = New RespuestaConsultaTrabajador()

            Dim ecc As New ECCServices()
            Dim hana As New HanaServices()
            Dim sw As New Stopwatch()
            Dim msje As String
            sw.Start()

            If (model.Sociedad = String.Empty) Then
                HelperLog.PutLineError("--Consulta zwshr_trabajador--")
                If (ConfigurationManager.AppSettings.Item("IndECCSAP").ToString() = "1") Then
                    model.Mandante = ConfigurationManager.AppSettings.Item("MandanteECC").ToString()
                    eccResponse = ecc.InvocarServicio(model)
                    sw.Stop()
                    msje = sw.ElapsedMilliseconds
                    HelperLog.PutLineError("--Fin consulta zwshr_trabajador Time elapsed milisegundos: " + sw.ElapsedMilliseconds.ToString())
                End If

                If (eccResponse.ResponseCode <> Constantes.RespuestaExitosa) Then
                    Return eccResponse
                End If
                HelperLog.PutLine("--Consulta ws hanna--")
                Dim sw2 As New Stopwatch()
                sw2.Start()

                model.Mandante = ConfigurationManager.AppSettings.Item("MandanteS4").ToString()
                hanaResponse = hana.InvocarServicio(model)

                sw2.Stop()

                HelperLog.PutLineError("--Fin consulta ws hanna Time elapsed milisegundos: " + sw2.ElapsedMilliseconds.ToString())
                If (hanaResponse.ResponseCode <> Constantes.RespuestaExitosa) Then
                    Return hanaResponse
                End If

                response.ResponseContent.AddRange(eccResponse.ResponseContent)
                response.ResponseContent.AddRange(hanaResponse.ResponseContent)

                'Validacion en caso ningun webservice devuelva un resultado
                If eccResponse.ResponseContent.Count = 0 And hanaResponse.ResponseContent.Count = 0 Then
                    response.ResponseMessage = "No existen datos con los parámetros ingresados"
                End If
            Else
                Dim prefSociedad = Trim(model.Sociedad.Substring(0, 2).ToString)
                If prefSociedad.ToUpper() = "FE" Then
                    Dim ecc2 As New ECCServices()
                    model.Mandante = ConfigurationManager.AppSettings.Item("MandanteECC").ToString()
                    response = ecc2.InvocarServicio(model)
                Else
                    Dim hana2 As New HanaServices()
                    model.Mandante = ConfigurationManager.AppSettings.Item("MandanteS4").ToString()
                    response = hana2.InvocarServicio(model)
                End If
            End If

        End If

        Return response
    End Function

    Private Function Validar(ByVal model As Parametro) As RespuestaConsultaTrabajador
        Dim response As RespuestaConsultaTrabajador = New RespuestaConsultaTrabajador()
        response.ResponseCode = Constantes.RespuestaExitosa
        'If (String.IsNullOrEmpty(model.Sociedad)) Then
        '    response.ResponseCode = Constantes.DatoVacio
        '    response.ResponseMessage = "El parámetro 'Sociedad' está vacío. No se puede obtener data."
        'End If
        If (String.IsNullOrEmpty(model.Mandante)) Then
            response.ResponseCode = Constantes.DatoInvalido
            response.ResponseMessage = "El parámetro 'Mandante' está vacío. No se puede obtener data."
        End If
        Return response
    End Function


    ''' <summary>
    '''          UnidadOrganizativa
    ''' </summary>
    Public Function ObtenerDatosUnidadOrganizativa(ByVal model As ParametroUO) As RespuestaConsultaUnidadOrganizativa Implements IConsultaTrabajadoresWS.ObtenerDatosUnidadOrganizativa
        Dim response As RespuestaConsultaUnidadOrganizativa
        response = ValidarUnidad(model)

        If response.ResponseCode = Constantes.RespuestaExitosa Then

            Dim prefSociedad = Trim(model.Sociedad.Substring(0, 2).ToString)
            If prefSociedad = "FE" Then
                Dim ecc As New ECCServices()
                response = ecc.InvocarServicioUnidad(model)
            Else
                Dim hana As New HanaServices()
                response = hana.InvocarServicioUnidad(model)
            End If
        End If

        Return response
    End Function

    Private Function ValidarUnidad(ByVal model As ParametroUO) As RespuestaConsultaUnidadOrganizativa
        Dim response As RespuestaConsultaUnidadOrganizativa = New RespuestaConsultaUnidadOrganizativa()
        response.ResponseCode = Constantes.RespuestaExitosa
        If (String.IsNullOrEmpty(model.Sociedad)) Then
            response.ResponseCode = Constantes.DatoVacio
            response.ResponseMessage = "El parámetro 'Sociedad' está vacío. No se puede obtener data."
        End If
        Return response
    End Function

End Class





''Public Function ObtenerDatosTrabajador(ByVal model As Parametro) As RespuestaConsultaTrabajador Implements IConsultaTrabajadoresWS.ObtenerDatosTrabajador

''    Dim response As RespuestaConsultaTrabajador
''    response = Validar(model)

''    If response.ResponseCode = Constantes.RespuestaExitosa Then
''        '* Si Mandante productivo SAP ECC es DIFERENTE Mandante productivo SAP S/4hana 21/03/19 *
''        'If model.Mandante.Equals(ConfigurationManager.AppSettings.Item("MandanteECC").ToString()) Then
''        '    Dim ecc As New ECCServices()
''        '    response = ecc.InvocarServicio(model)
''        'ElseIf model.Mandante.Equals(ConfigurationManager.AppSettings.Item("MandanteS4").ToString()) Then
''        '    Dim hana As New HanaServices()
''        '    response = hana.InvocarServicio(model)
''        'Else
''        '    response.ResponseCode = Constantes.DatoInvalido
''        'End If

''        ''* Si Mandante productivo SAP ECC es IGUAL Mandante productivo SAP S/4hana - 21/03/19 *
''        ''If (model.Sociedad = String.Empty) Then

''        ''    ' El flag permite deshabilitar la llamada a SAP HCM ECC 
''        ''    If (model.Flag.ToString.Trim() = "0") Then              ' Flag en 0 no ejecuta servicio ECC, solo servicio HANA
''        ''        Dim hana As New HanaServices()
''        ''        response = hana.InvocarServicio(model)
''        ''    ElseIf (model.Flag.ToString.Trim() = "1") Then           ' Flag en 1 ejecuta los 2 servicios  
''        ''        Dim hanaEcc As New HanaEccServices()
''        ''        response = hanaEcc.InvocarServicios(model)
''        ''    Else
''        ''        response.ResponseCode = Constantes.DatoInvalido
''        ''    End If
''        ''Else
''        ''    Dim prefSociedad = Trim(model.Sociedad.Substring(0, 2).ToString)
''        ''    If prefSociedad = "FE" Then
''        ''        Dim ecc As New ECCServices()
''        ''        response = ecc.InvocarServicio(model)
''        ''    Else
''        ''        Dim hana As New HanaServices()
''        ''        response = hana.InvocarServicio(model)
''        ''    End If
''        ''End If 
''    End If

''    Return response
''End Function
