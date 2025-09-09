using OpenB.Entidad.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BL
{
    public class wsMTC
    {
        public static ERespuestaS DatosLicencia(string iTipoDocumento, string sNumDocumento)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws3.pide.gob.pe/Rest/Mtc/DatosLicencia?iTipoDocumento={0}&sNumDocumento={1}&out=json";

            if (String.IsNullOrEmpty(sNumDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, iTipoDocumento, sNumDocumento);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta {sNumDocumento}, error : {error}";

                throw;
            }
        }

        public static ERespuestaS RecordConductor(string Numero_Documento, string Numero_Record, string Tipo_Documento)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws3.pide.gob.pe/Rest/Mtc/RecordConductor?Numero_Documento={0}&Numero_Record={1}&Tipo_Documento={2}&out=json";

            if (String.IsNullOrEmpty(Numero_Documento) && String.IsNullOrEmpty(Numero_Record) && String.IsNullOrEmpty(Tipo_Documento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, Numero_Documento, Numero_Record, Tipo_Documento);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta {Numero_Documento}, error : {error}";

                throw;
            }
        }

        public static ERespuestaS DatosPapeletas(string iTipoDocumento, string sNumDocumento)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws3.pide.gob.pe/Rest/Mtc/DatosPapeletas?iTipoDocumento={0}&sNumDocumento={1}&out=json";

            if (String.IsNullOrEmpty(sNumDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, iTipoDocumento, sNumDocumento);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta {sNumDocumento}, error : {error}";

                throw;
            }
        }

        public static ERespuestaS UltimaLicencia(string iTipoDocumento, string sNumDocumento)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws3.pide.gob.pe/Rest/Mtc/UltimaLicencia?iTipoDocumento={0}&sNumDocumento={1}&out=json";

            if (String.IsNullOrEmpty(sNumDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, iTipoDocumento, sNumDocumento);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta {sNumDocumento}, error : {error}";

                throw;
            }
        }

        public static ERespuestaS UltimasSanciones(string iTipoDocumento, string sNumDocumento)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws3.pide.gob.pe/Rest/Mtc/UltimasSanciones?iTipoDocumento={0}&sNumDocumento={1}&out=json";

            if (String.IsNullOrEmpty(sNumDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, iTipoDocumento, sNumDocumento);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta {sNumDocumento}, error : {error}";

                throw;
            }
        }


    }
}
