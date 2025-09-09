using OpenB.Entidad.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BL
{
    public class wsPENALES
    {
        public static EResAntPenal GetAntPenalesPIDE(string nroDocumento, string apePaterno, string apeMaterno, string pNombres)
        {
            EResAntPenal oERespuesta = new EResAntPenal();


            if (String.IsNullOrEmpty(nroDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {

                string[] nombres = pNombres.Split(' ');
                verificarAntecedentesPenales modelpenal = new verificarAntecedentesPenales();
                modelpenal.xApellidoPaterno = apePaterno;
                modelpenal.xApellidoMaterno = apeMaterno;
                modelpenal.xNombre1 = (string.IsNullOrEmpty(nombres[0]) ? "" : nombres[0]);
                if (nombres.Length > 1)
                {
                    modelpenal.xNombre2 = (string.IsNullOrEmpty(nombres[1]) ? "" : nombres[1]);
                }
                else
                {
                    modelpenal.xNombre2 = "";
                }
                if (nombres.Length > 2)
                {
                    modelpenal.xNombre3 = (string.IsNullOrEmpty(nombres[2]) ? "" : nombres[2]);
                }
                else
                {
                    modelpenal.xNombre3 = "";
                }
                modelpenal.xDni = nroDocumento;
                modelpenal.xMotivoConsulta = "CONSULTA ANTECEDENTES USUARIO SATH " + modelpenal.xDni;
                modelpenal.xProcesoEntidadConsultante = "PROCESO-000-" + modelpenal.xDni;
                modelpenal.xRucEntidadConsultante = System.Configuration.ConfigurationManager.AppSettings["RUC_ENTIDAD"];
                modelpenal.xIpPublica = System.Configuration.ConfigurationManager.AppSettings["AP_IPPUBLICA"]; 
                modelpenal.xDniPersonaConsultante = System.Configuration.ConfigurationManager.AppSettings["AP_DNICONSULTANTE"]; //dni de representante
                modelpenal.xAudNombrePC = System.Configuration.ConfigurationManager.AppSettings["AP_AUDNOMBREPC"];
                modelpenal.xAudIP = System.Configuration.ConfigurationManager.AppSettings["AP_AUDIPPC"];
                modelpenal.xAudNombreUsuario = System.Configuration.ConfigurationManager.AppSettings["AP_AUDNOMUSUARIO"];
                modelpenal.xAudDireccionMAC = System.Configuration.ConfigurationManager.AppSettings["AP_AUDMACPC"];

                PJAntecedentesPenales c = new PJAntecedentesPenales();
                var res = c.verificarAntecedentesPenales(modelpenal);
                var resultado = "";

                if (res != null)
                {
                    resultado = (string.IsNullOrEmpty(res.xMensajeRespuesta) ? "" : res.xMensajeRespuesta);
                }

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
