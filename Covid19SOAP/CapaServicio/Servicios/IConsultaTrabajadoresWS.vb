Imports System.ServiceModel
Imports CapaModelo

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IConsultaTrabjadoresWS" in both code and config file together.
<ServiceContract()>
Public Interface IConsultaTrabajadoresWS



    <OperationContract>
    Function ObtenerDatosTrabajador(model As Parametro) As RespuestaConsultaTrabajador

    <OperationContract>
    Function ObtenerDatosUnidadOrganizativa(model As ParametroUO) As RespuestaConsultaUnidadOrganizativa

End Interface
