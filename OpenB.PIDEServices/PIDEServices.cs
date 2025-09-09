using System;
using System.Configuration;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using OpenB.Entidad.ws;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Security.Policy;
using Microsoft.Win32;

namespace OpenB.PIDEServices
{
    public class PIDEServices
    {

        #region RENIEC
        public async Task<ERespuestaR> getDatosReniec(string nroDNI)
        {
            ReniecConsultaDni c = new ReniecConsultaDni();
            peticionConsulta p = new peticionConsulta();

            string url = "https://ws2.pide.gob.pe/Rest/RENIEC/Consultar?out=json";

            p.nuDniConsulta = nroDNI;
            p.nuDniUsuario = "46035720";
            p.password = "46035720";
            p.nuRucUsuario = "20494443466";

            ERespuestaR res = new ERespuestaR();
            EReniecResp r = new EReniecResp();  


            if (String.IsNullOrEmpty(nroDNI))
            {
                res.Codigo = -4;
                res.Mensaje = "No se ha registrado número de documento.";
                return res;
            }

            try
            {

                Uri u = new Uri(url);
                var payload = "{\r\n\"PIDE\":{\r\n\"nuDniConsulta\": \""+ p.nuDniConsulta + "\",\r\n \"nuDniUsuario\": \""+ p.password + "\",\r\n \"nuRucUsuario\": \""+ p.nuRucUsuario + "\",\r\n \"password\": \""+ p.password + "\"\r\n }\r\n}";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => SendURI(u, content));
                t.Wait();

                r=JsonConvert.DeserializeObject<EReniecResp>(t.Result);                

                if (r.consultarResponse.@return.datospersona != null)
                {

                    ReniecPide dp = new ReniecPide();
                    dp.apPrimer = r.consultarResponse.@return.datospersona.apPrimer;
                    dp.apSegundo = r.consultarResponse.@return.datospersona.apSegundo;
                    dp.prenombres = r.consultarResponse.@return.datospersona.prenombres;
                    dp.estadoCivil = r.consultarResponse.@return.datospersona.estadoCivil;
                    dp.direccion = r.consultarResponse.@return.datospersona.direccion;
                    dp.ubigeo = r.consultarResponse.@return.datospersona.ubigeo;
                    dp.restriccion = r.consultarResponse.@return.datospersona.restriccion;
                    dp.fotob64 = r.consultarResponse.@return.datospersona.foto;

                    res.r = dp;

                }


                return res;
            }
            catch
            {
                res.Codigo = -3;
                res.Mensaje = "Error consultando servicio, contáctese con el administrador.";
                return res;
            }
        }

        #endregion


        #region SUNARP


        public async Task<ESunarpRazoSocial> getRazonSocial(string razonSocial)
        {
            ESunarpRazoSocial oESunarpRazoSocial = new ESunarpRazoSocial();

            string url = "https://ws2.pide.gob.pe/Rest/SUNARP/BPJRSocial?out=json";
            string Usuario = "20494443466-SAT-H";
            string Contrasena= "SunarpSegdi";

            if (String.IsNullOrEmpty(razonSocial))
            {
                oESunarpRazoSocial.Codigo = -4;
                oESunarpRazoSocial.Mensaje = "No se ha registrado datos completos para consulta.";
                return oESunarpRazoSocial;
            }

            try
            {
                Uri u = new Uri(url);
                var payload = "{\r\n\"PIDE\": {\r\n\"usuario\":\""+ Usuario + "\",\r\n\"clave\": \""+ Contrasena + "\",\r\n \"razonSocial\": \""+ razonSocial + "\"\r\n}\r\n}";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => SendURI(u, content));
                t.Wait();

                oESunarpRazoSocial.JSonRasoSocial = t.Result.ToString();

                return oESunarpRazoSocial;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oESunarpRazoSocial.Codigo = -3;
                oESunarpRazoSocial.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }


        public async Task<EOficinas> getOficinasSunarp()
        {
            EOficinas oEOficinas = new EOficinas();

            string url = "https://ws2.pide.gob.pe/Rest/SUNARP/GOficina?out=json";
            string Usuario = "20494443466-SAT-H";
            string Contrasena = "SunarpSegdi";

            try
            {

                Uri u = new Uri(url);
                var payload = "{\r\n\"PIDE\": {\r\n\"usuario\": \"" + Usuario + "\",\r\n\"clave\": \"" + Contrasena + "\"\r\n}\r\n}";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => SendURI(u, content));
                t.Wait();

                var r = JsonConvert.DeserializeObject<CollectEOficina> (t.Result.ToString());

                oEOficinas.JSonOficinas = JsonConvert.SerializeObject(r.oficina.oficina);

                return oEOficinas;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oEOficinas.Codigo = -3;
                oEOficinas.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }


        //SERVICIO VDRPVExtra
        public async Task<EVehiculos> getConsultaVehiculo(string zona, string oficina, string placa)
        {
            EVehiculos oEVehiculos = new EVehiculos();

            string url = "https://ws2.pide.gob.pe/Rest/SUNARP/VDRPVExtra?out=json";
            string Usuario = "20494443466-SAT-H";
            string Contrasena = "SunarpSegdi";

            if (String.IsNullOrEmpty(zona) || String.IsNullOrEmpty(oficina) || String.IsNullOrEmpty(placa))
            {
                oEVehiculos.Codigo = -4;
                oEVehiculos.Mensaje = "No se ha registrado datos completos para consulta.";
                return oEVehiculos;
            }

            try
            {

                Uri u = new Uri(url);
                var payload = "{\r\n\"PIDE\":{\r\n\"usuario\": \"" + Usuario + "\",\r\n\"clave\": \"" + Contrasena + "\",\r\n\"zona\": \"" + zona + "\",\r\n\"oficina\": \"" + oficina + "\",\r\n\"placa\": \"" + placa + "\"\r\n}\r\n}"; 

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => SendURI(u, content));
                t.Wait();

                oEVehiculos.JSonVehiculos = t.Result.ToString();

                return oEVehiculos;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oEVehiculos.Codigo = -3;
                oEVehiculos.Mensaje = $"Consulta persona natural, error : {error}";

                throw;
            }
        }

        //SERVICIO TSIRSARP
        public async Task<ERespuestaS> getTitularidadPersoNatural(string apellidoPaterno, string apellidoMaterno, string nombres)
        {
            ERespuestaS oERespuesta = new ERespuestaS();
            
            string url = "https://ws2.pide.gob.pe/Rest/SUNARP/TSIRSARP?out=json";
            string Usuario = "20494443466-SAT-H";
            string Contrasena = "SunarpSegdi";
            string TipoParticipante = "N";
            string RazonSocial = "";

            if (String.IsNullOrEmpty(apellidoPaterno) || String.IsNullOrEmpty(apellidoMaterno) || String.IsNullOrEmpty(nombres))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            try
            {

                Uri u = new Uri(url);
                var payload = "{\r\n\"PIDE\": {\r\n\"usuario\": \""+ Usuario + "\",\r\n\"clave\": \""+ Contrasena + "\",\r\n\"tipoParticipante\": \""+ TipoParticipante + "\",\r\n\"apellidoPaterno\": \""+ apellidoPaterno + "\",\r\n\"apellidoMaterno\": \""+ apellidoMaterno + "\",\r\n \"nombres\": \""+ nombres + "\",\r\n\"razonSocial\": \""+ RazonSocial + "\"\r\n}\r\n}";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => SendURI(u, content));
                t.Wait();

                oERespuesta.JsonString = t.Result.ToString();

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

        public async Task<ERespuestaS> getTitularidadPersoJuridica(string razonSocial)
        {

            ERespuestaS oERespuesta = new ERespuestaS();

            if (String.IsNullOrEmpty(razonSocial))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            string url = "https://ws2.pide.gob.pe/Rest/SUNARP/TSIRSARP?out=json";
            string Usuario = "20494443466-SAT-H";
            string Contrasena = "SunarpSegdi";
            string TipoParticipante = "J";
            string RazonSocial = razonSocial;
            string apellidoPaterno = "";
            string apellidoMaterno = "";
            string nombres = "";

            try
            {

                Uri u = new Uri(url);
                var payload = "{\r\n\"PIDE\": {\r\n\"usuario\": \"" + Usuario + "\",\r\n\"clave\": \"" + Contrasena + "\",\r\n\"tipoParticipante\": \"" + TipoParticipante + "\",\r\n\"apellidoPaterno\": \"" + apellidoPaterno + "\",\r\n\"apellidoMaterno\": \"" + apellidoMaterno + "\",\r\n \"nombres\": \"" + nombres + "\",\r\n\"razonSocial\": \"" + RazonSocial + "\"\r\n}\r\n}";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => SendURI(u, content));
                t.Wait();

                oERespuesta.JsonString = t.Result.ToString();

                return oERespuesta;
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                oERespuesta.Codigo = -3;
                oERespuesta.Mensaje = $"Consulta persona jurídica, error : {error}";

                throw;
            }
        }


        public async Task<ERespuestaS> getListaAsientos(string zona, string oficina, string partida, string registro)
        {
            ERespuestaS oERespuesta = new ERespuestaS();

            if (String.IsNullOrEmpty(zona) || String.IsNullOrEmpty(oficina) || String.IsNullOrEmpty(partida) || String.IsNullOrEmpty(registro))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            string url = "https://ws2.pide.gob.pe/Rest/SUNARP/LASIRSARP?out=json";
            string Usuario = "20494443466-SAT-H";
            string Contrasena = "SunarpSegdi";

            try
            {
                Uri u = new Uri(url);
                var payload = "{\r\n\"PIDE\": {\r\n\"usuario\":\""+ Usuario + "\",\r\n\"clave\": \""+ Contrasena + "\",\r\n\"zona\":\""+ zona + "\",\r\n\"oficina\": \""+ oficina + "\",\r\n\"partida\": \""+ partida + "\",\r\n\"registro\":\""+ registro + "\"\r\n}\r\n}";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => SendURI(u, content));
                t.Wait();

                oERespuesta.JsonString = t.Result.ToString();

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


        public async Task<ERespuestaS> ShowAsientos(string transaccion, string idImg, string tipo, string nroTotalPag, string nroPagRef, string pagina)
        {
            ERespuestaS oERespuesta = new ERespuestaS();


            if (String.IsNullOrEmpty(transaccion) || String.IsNullOrEmpty(idImg) || String.IsNullOrEmpty(tipo) || String.IsNullOrEmpty(nroTotalPag) || String.IsNullOrEmpty(nroPagRef) || String.IsNullOrEmpty(pagina))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado datos completos para consulta.";
                return oERespuesta;
            }

            string url = "https://ws2.pide.gob.pe/Rest/SUNARP/VASIRSARP?out=json";
            string Usuario = "20494443466-SAT-H";
            string Contrasena = "SunarpSegdi";

            try
            {

                Uri u = new Uri(url);
                var payload = "{\r\n\"PIDE\":{\r\n\"usuario\":\""+ Usuario + "\",\r\n\"clave\":\""+ Contrasena + "\",\r\n\"transaccion\":\""+ transaccion + "\",\r\n\"idImg\":\""+ idImg + "\",\r\n\"tipo\":\""+ tipo + "\",\r\n\"nroTotalPag\":\""+ nroTotalPag + "\",\r\n\"nroPagRef\":\""+ nroPagRef + "\",\r\n\"pagina\":\""+ pagina + "\"\r\n}\r\n}";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => SendURI(u, content));
                t.Wait();

                oERespuesta.JsonString = t.Result.ToString();

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

        #endregion




        #region GENERAL
        private async Task<string> SendURI(Uri u, HttpContent c)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = (await result.Content.ReadAsStringAsync());
                }

            }

            return response;
        }

        #endregion



    }



}