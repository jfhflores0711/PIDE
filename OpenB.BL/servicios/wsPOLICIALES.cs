using OpenB.Entidad.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BL
{
    public class wsPOLICIALES
    {
        public static EResAntPolicial GetAntPolicialesPIDE(string nroDocumento)
        {
            EResAntPolicial oERespuesta = new EResAntPolicial();
            if (String.IsNullOrEmpty(nroDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {

                PnpAntPolicial c = new PnpAntPolicial();
                var res = c.consultarPersonaNroDoc(
                    System.Configuration.ConfigurationManager.AppSettings["APOL_CLIENTEUSUARIO"], //clienteUsuario,
                    System.Configuration.ConfigurationManager.AppSettings["APOL_CLIENTECLAVE"], //clienteClave,
                    System.Configuration.ConfigurationManager.AppSettings["APOL_SERVICIOCODIGO"],//servicioCodigo,
                    System.Configuration.ConfigurationManager.AppSettings["APOL_CLIENTESISTEMA"],//clienteSistema,
                    System.Configuration.ConfigurationManager.AppSettings["APOL_CLIENTEIP"],//clienteIp,
                    System.Configuration.ConfigurationManager.AppSettings["APOL_CLIENTEMAC"],//clienteMac,
                    "2",//tipoDocUserClieFin,
                    nroDocumento,//nroDocUserClieFin,
                    nroDocumento);//nroDoc

                oERespuesta.r = res;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta {nroDocumento}, error : {error}";

                throw;
            }

            return oERespuesta;
        }
    }
}
