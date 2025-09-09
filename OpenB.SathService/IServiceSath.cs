using OpenB.Entidad.ws;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OpenB.SathService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceSath
    {
        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de RUC")]
        ERespuestaS getDatosRUC(string nroDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNAT")]
        ERespuestaS getDatosSecundarios(string nroDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNAT")]
        ERespuestaS getDomicilioLegal(string nroDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNAT")]
        ERespuestaS getRepresentanteLegal(string nroDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de RENIEC")]
        ERespuestaR getDatosReniec(string nroDNI);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNEDU")]
        EResGTSunedu getDatosSunedu(string nroDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpNaveAeronave(string numeroMatricula);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpPJRazonSocial(string razonSocial);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpTitularidadPN(string apellidoPaterno, string apellidoMaterno, string nombres);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpTitularidadPJ(string razonSocial);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpTitularidadSIRSARP(string apellidoPaterno, string apellidoMaterno, string nombres);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpTitularidadSIRSARPJ(string razonSocial);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpOficinas();

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpListarAsientos(string zona, string oficina, string partida, string registro);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpListarAsientosSIRSARP(string zona, string oficina, string partida, string registro);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpVerDetalleRPV(string zona, string oficina, string placa);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpVerDetalleRPVExtra(string zona, string oficina, string placa);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpVerAsientos(string transaccion, string idImg, string tipo, string nroTotalPag, string nroPagRef, string pagina);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de SUNARP")]
        ERespuestaS getSunarpVerAsientoSIRSARP(string transaccion, string idImg, string tipo, string nroTotalPag, string nroPagRef, string pagina);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de MIGRACIONES")]
        ERespuestaM getMigracionesDocumento(string nroDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de INPE")]
        EResAntJudicial getAntJudiciales(string nroDocumento, string apePaterno, string apeMaterno, string Nombres);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de PJ")]
        EResAntPenal getAntPenales(string nroDocumento, string apePaterno, string apeMaterno, string pNombres);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de POLICIA")]
        EResAntPolicial getAntPoliciales(string nroDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de MTC")]
        ERespuestaS getMtcDatosLicencia(string iTipoDocumento, string sNumDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de MTC")]
        ERespuestaS getMtcRecordConductor(string Tipo_Documento, string Numero_Documento, string Numero_Record);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de MTC")]
        ERespuestaS getMtcDatosPapeletas(string iTipoDocumento, string sNumDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de MTC")]
        ERespuestaS getMtcUltimaLicencia(string iTipoDocumento, string sNumDocumento);

        [OperationContract]
        [Description("Proporciona el resultado de la consulta realizada al WS de MTC")]
        ERespuestaS getMtcUltimasSanciones(string iTipoDocumento, string sNumDocumento);
    }


  
}
