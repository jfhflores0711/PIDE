using OpenB.Entidad.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BL
{
    public class wsJUDICIALES
    {
        public static EResAntJudicial GetAntJudicialesPIDE(string nroDocumento, string apePaterno, string apeMaterno, string Nombres)
        {
            EResAntJudicial oERespuesta = new EResAntJudicial();

            if (String.IsNullOrEmpty(apePaterno) || String.IsNullOrEmpty(apeMaterno) || String.IsNullOrEmpty(Nombres))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos, registre e intente nuevamente.";
                return oERespuesta;
            }

            try
            {

                INPEAJudiciales c = new INPEAJudiciales();
                var res = c.getAntecedenteJudicial(apePaterno, apeMaterno, Nombres);

                oERespuesta.r = (string.IsNullOrEmpty(res) ? "" : res);
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
