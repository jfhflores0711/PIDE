using Newtonsoft.Json;
using OpenB.Entidad.ws;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenB.BL
{
    public class wsSUNARP
    {
        public static ERespuestaS NaveAeronave(string numeroMatricula)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws5.pide.gob.pe/Rest/Sunarp/NaveAeronave?numeroMatricula={0}&out=json";

            if (String.IsNullOrEmpty(numeroMatricula))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, numeroMatricula);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta {numeroMatricula}, error : {error}";

                throw;
            }
        }

        public static ERespuestaS PJRazonSocial(string razonSocial)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            //string url = "https://ws5.pide.gob.pe/Rest/Sunarp/PJRazonSocial?razonSocial={0}&out=json";
            string url = "https://ws5.pide.gob.pe/Rest/APide/Sunarp/WSServicePJRazonSocial?razonSocial={0}&usuario={1}&clave={2}&out=json";

            if (String.IsNullOrEmpty(razonSocial))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string usuario = System.Configuration.ConfigurationManager.AppSettings["SUNARP_USUARIO"];
                    string clave = System.Configuration.ConfigurationManager.AppSettings["SUNARP_CLAVE"];

                    url = String.Format(url, razonSocial.ToUpper().Trim(), usuario, clave);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        public static ERespuestaS TitularidadPN(string apellidoPaterno, string apellidoMaterno, string nombres)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            //string url = "https://ws5.pide.gob.pe/Rest/Sunarp/Titularidad?tipoParticipante=N&apellidoPaterno={0}&apellidoMaterno={1}&nombres={2}&out=json";
            string url = "https://ws5.pide.gob.pe/Rest/APide/Sunarp/WSServiceTitularidadSIRSARP?tipoParticipante=N&apellidoPaterno={0}&apellidoMaterno={1}&nombres={2}&usuario={3}&clave={4}&out=json";

            if (String.IsNullOrEmpty(apellidoPaterno) || String.IsNullOrEmpty(apellidoMaterno) || String.IsNullOrEmpty(nombres))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {

                    string usuario = System.Configuration.ConfigurationManager.AppSettings["SUNARP_USUARIO"];
                    string clave = System.Configuration.ConfigurationManager.AppSettings["SUNARP_CLAVE"];

                    url = String.Format(url, apellidoPaterno.ToUpper().Trim(), apellidoMaterno.ToUpper().Trim(), nombres.ToUpper().Trim(),usuario,clave);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        public static ERespuestaS TitularidadPJ(string razonSocial)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            //string url = "https://ws5.pide.gob.pe/Rest/Sunarp/Titularidad?tipoParticipante=J&razonSocial={0}&out=json";
            string url = "https://ws5.pide.gob.pe/Rest/APide/Sunarp/WSServiceTitularidadSIRSARP?tipoParticipante=J&razonSocial={0}&usuario={1}&clave={2}&out=json";

            if (String.IsNullOrEmpty(razonSocial))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string usuario = System.Configuration.ConfigurationManager.AppSettings["SUNARP_USUARIO"];
                    string clave = System.Configuration.ConfigurationManager.AppSettings["SUNARP_CLAVE"];

                    url = String.Format(url, razonSocial.ToUpper().Trim(), usuario, clave);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }


        public static ERespuestaS TitularidadSIRSARP(string apellidoPaterno, string apellidoMaterno, string nombres)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws5.pide.gob.pe/Rest/Sunarp/TitularidadSIRSARP?tipoParticipante=N&apellidoPaterno={0}&apellidoMaterno={1}&nombres={2}&out=json";

            if (String.IsNullOrEmpty(apellidoPaterno) || String.IsNullOrEmpty(apellidoMaterno) || String.IsNullOrEmpty(nombres))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, apellidoPaterno.ToUpper().Trim(), apellidoMaterno.ToUpper().Trim(), nombres.ToUpper().Trim());
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        public static ERespuestaS TitularidadSIRSARPJ(string razonSocial)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws5.pide.gob.pe/Rest/Sunarp/TitularidadSIRSARP?tipoParticipante=J&razonSocial={0}&out=json";

            if (String.IsNullOrEmpty(razonSocial))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, razonSocial.SinTildes().ToUpper().Trim());
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        public static ERespuestaS SunarpOficinas()
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            //string url = "https://ws5.pide.gob.pe/Rest/Sunarp/Oficinas";
            string url = "https://ws5.pide.gob.pe/Rest/APide/Sunarp/WSServicegetOficinas?usuario={0}&clave={1}";

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string usuario = System.Configuration.ConfigurationManager.AppSettings["SUNARP_USUARIO"];
                    string clave = System.Configuration.ConfigurationManager.AppSettings["SUNARP_CLAVE"];

                    url = String.Format(url,usuario,clave);
                    var json = wc.DownloadString(url);
                    var oficinas_ = json;

                    oficina office = new oficina();

                    XmlSerializer serializer = new XmlSerializer(typeof(oficina));
                    using (StringReader reader = new StringReader(oficinas_))
                    {
                        office = (oficina)(serializer.Deserialize(reader));
                    }

                    List<oficina1> oList = new List<oficina1>(office.oficina1);

                    oList = oList.OrderBy(x => x.descripcion).ToList();

                    string jsonO = JsonConvert.SerializeObject(oList);

                    oERespuesta.JsonString = jsonO;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        public static ERespuestaS ListarAsientos(string zona, string oficina, string partida, string registro)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            //string url = "https://ws5.pide.gob.pe/Rest/Sunarp/ListarAsientos?zona={0}&oficina={1}&partida={2}&registro={3}&out=json";
            string url = "https://ws5.pide.gob.pe/Rest/APide/Sunarp/WSServicelistarAsientosSIRSARP?zona={0}&oficina={1}&partida={2}&registro={3}&usuario={4}&clave={5}&out=json";

            if (String.IsNullOrEmpty(zona) || String.IsNullOrEmpty(oficina) || String.IsNullOrEmpty(partida) || String.IsNullOrEmpty(registro))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                string usuario = System.Configuration.ConfigurationManager.AppSettings["SUNARP_USUARIO"];
                string clave = System.Configuration.ConfigurationManager.AppSettings["SUNARP_CLAVE"];

                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, zona.Trim(), oficina.Trim(), partida.Trim(), registro, usuario, clave);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        public static ERespuestaS ListarAsientosSIRSARP(string zona, string oficina, string partida, string registro)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws5.pide.gob.pe/Rest/Sunarp/ListarAsientosSIRSARP?zona={0}&oficina={1}&partida={2}&registro={3}&out=json";

            if (String.IsNullOrEmpty(zona) || String.IsNullOrEmpty(oficina) || String.IsNullOrEmpty(partida) || String.IsNullOrEmpty(registro))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, zona.Trim(), oficina.Trim(), partida.Trim(), registro);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        public static ERespuestaS VerDetalleRPV(string zona, string oficina, string placa)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

        //string url = "https://ws5.pide.gob.pe/Rest/Sunarp/VerDetalleRPV?zona={0}&oficina={1}&placa={2}&out=json";
        string url = "https://ws5.pide.gob.pe/Rest/APide/Sunarp/WSServiceverDetalleRPVExtra?zona={0}&oficina={1}&placa={2}&usuario={3}&clave={4}&out=json";
        

            if (String.IsNullOrEmpty(zona) || String.IsNullOrEmpty(oficina) || String.IsNullOrEmpty(placa))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string usuario = System.Configuration.ConfigurationManager.AppSettings["SUNARP_USUARIO"];
                    string clave = System.Configuration.ConfigurationManager.AppSettings["SUNARP_CLAVE"];

                    url = String.Format(url, zona.Trim(), oficina.Trim(), placa.Trim(), usuario, clave);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }


        public static ERespuestaS VerDetalleRPVExtra(string zona, string oficina, string placa)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws5.pide.gob.pe/Rest/Sunarp/VerDetalleRPVExtra?zona={0}&oficina={1}&placa={2}&out=json";

            if (String.IsNullOrEmpty(zona) || String.IsNullOrEmpty(oficina) || String.IsNullOrEmpty(placa))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, zona.Trim(), oficina.Trim(), placa.Trim());
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        public static ERespuestaS VerAsientos(string transaccion, string idImg, string tipo, string nroTotalPag, string nroPagRef, string pagina)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            //string url = "https://ws5.pide.gob.pe/Rest/Sunarp/VerAsientos?transaccion={0}&idImg={1}&tipo={2}&nroTotalPag={3}&nroPagRef={4}&pagina={5}&out=json";
            string url = "https://ws5.pide.gob.pe/Rest/APide/Sunarp/WSServiceverAsientosSIRSARP?transaccion={0}&idImg={1}&tipo={2}&nroTotalPag={3}&nroPagRef={4}&pagina={5}&usuario={6}&clave={7}&out=json";

            if (String.IsNullOrEmpty(transaccion) || String.IsNullOrEmpty(idImg) || String.IsNullOrEmpty(tipo) || String.IsNullOrEmpty(nroTotalPag) || String.IsNullOrEmpty(nroPagRef) || String.IsNullOrEmpty(pagina))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string usuario = System.Configuration.ConfigurationManager.AppSettings["SUNARP_USUARIO"];
                    string clave = System.Configuration.ConfigurationManager.AppSettings["SUNARP_CLAVE"];

                    url = String.Format(url, transaccion.Trim(), idImg.Trim(), tipo.Trim(), nroTotalPag.Trim(), nroPagRef.Trim(), pagina.Trim(), usuario, clave);
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        public static ERespuestaS VerAsientoSIRSARP(string transaccion, string idImg, string tipo, string nroTotalPag, string nroPagRef, string pagina)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            string url = "https://ws5.pide.gob.pe/Rest/Sunarp/VerAsientosSIRSARP?transaccion={0}&idImg={1}&tipo={2}&nroTotalPag={3}&nroPagRef={4}&pagina={5}&out=json";

            if (String.IsNullOrEmpty(transaccion) || String.IsNullOrEmpty(idImg) || String.IsNullOrEmpty(tipo) || String.IsNullOrEmpty(nroTotalPag) || String.IsNullOrEmpty(nroPagRef) || String.IsNullOrEmpty(pagina))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    url = String.Format(url, transaccion.Trim(), idImg.Trim(), tipo.Trim(), nroTotalPag.Trim(), nroPagRef.Trim(), pagina.Trim());
                    var json = wc.DownloadString(url);
                    oERespuesta.JsonString = json;
                }
                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

    }


    public static class StringExtensions
    {
        public static string SinTildes(this string texto) =>
            new String(
                texto.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray()
            )
            .Normalize(NormalizationForm.FormC);
    }
}
