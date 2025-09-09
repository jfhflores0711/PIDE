using Newtonsoft.Json;
using OpenB.Entidad.ws;
using OpenB.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace OpenB.SathService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IServiceSath
    {
        #region SUNAT
        public ERespuestaS getDatosRUC(string nroDocumento)
        {
            ERespuestaS oERespuesta = new ERespuestaS();
            string datos = "";

            if (String.IsNullOrEmpty(nroDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento";
                return oERespuesta;
            }

            try
            {
                SunatConsultaRuc sunatConsultaRuc = new SunatConsultaRuc();
                var llamada_servicio = sunatConsultaRuc.getDatosPrincipales(nroDocumento);

            }
            catch (Exception e)
            {
                datos = e.Message;

                //datos = datos.Replace("Client found response content type of 'text/plain', but expected 'text/xml'.", "");
                //datos = datos.Replace("The request failed with the error message:", "");

                datos = datos.Replace("El cliente encontró el tipo de contenido de respuesta 'text/plain', pero se esperaba 'text/xml'.", "");
                datos = datos.Replace("Error de la solicitud con el mensaje de error:", "");

                datos = datos.Replace("\r\n--.", "");
                datos = datos.Replace("\r\n\r\n--\r\n", "");
                datos = datos.Replace("HTTP/1.1 100 Continue\r\n\r\n", "");

                datos = datos.Replace("&", "&amp;");
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(datos);

                string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);
                jsonText = FormatearJson(jsonText);

                ERespuestaRuc eRespuestaRuc = new ERespuestaRuc();
                eRespuestaRuc = JsonConvert.DeserializeObject<ERespuestaRuc>(jsonText);

                ERuc ruc = new ERuc();
                ruc = Ruc(eRespuestaRuc.soapenv_envelope.soapenv_body.multiRef);

                oERespuesta.JsonString = JsonConvert.SerializeObject(ruc);
            }
            catch (Exception e)
            {
                oERespuesta.Codigo = -2;
                oERespuesta.Mensaje = "No se obtuvo resultado";
            }

            return oERespuesta;
        }
        public ERuc Ruc(MultiRef multiRef)
        {
            ERuc ruc = new ERuc();

            ruc.ddp_numruc = multiRef.ddp_numruc.valor;
            ruc.ddp_nombre = multiRef.ddp_nombre.valor;

            ruc.cod_dep = multiRef.cod_dep.valor;
            ruc.cod_dist = multiRef.cod_dist.valor;
            ruc.cod_prov = multiRef.cod_prov.valor;
            ruc.ddp_ciiu = multiRef.ddp_ciiu.valor;
            ruc.ddp_estado = multiRef.ddp_estado.valor;
            ruc.ddp_fecact = multiRef.ddp_fecact.valor;
            ruc.ddp_fecalt = multiRef.ddp_fecalt.valor;
            ruc.ddp_fecbaj = multiRef.ddp_fecbaj.valor;
            ruc.ddp_flag22 = multiRef.ddp_flag22.valor;
            ruc.ddp_identi = multiRef.ddp_identi.valor;
            ruc.ddp_inter1 = multiRef.ddp_inter1.valor;
            ruc.ddp_lllttt = multiRef.ddp_lllttt.valor;
            ruc.ddp_nomvia = multiRef.ddp_nomvia.valor;
            ruc.ddp_nomzon = multiRef.ddp_nomzon.valor;
            ruc.ddp_numer1 = multiRef.ddp_numer1.valor;
            ruc.ddp_numreg = multiRef.ddp_numreg.valor;
            ruc.ddp_refer1 = multiRef.ddp_refer1.valor;
            ruc.ddp_secuen = multiRef.ddp_secuen.valor;
            ruc.ddp_tipvia = multiRef.ddp_tipvia.valor;
            ruc.ddp_tipzon = multiRef.ddp_tipzon.valor;
            ruc.ddp_tpoemp = multiRef.ddp_tpoemp.valor;
            ruc.ddp_ubigeo = multiRef.ddp_ubigeo.valor;
            ruc.desc_ciiu = multiRef.desc_ciiu.valor;
            ruc.desc_dep = multiRef.desc_dep.valor;
            ruc.desc_dist = multiRef.desc_dist.valor;
            ruc.desc_estado = multiRef.desc_estado.valor;
            ruc.desc_flag22 = multiRef.desc_flag22.valor;
            ruc.desc_identi = multiRef.desc_identi.valor;
            ruc.desc_numreg = multiRef.desc_numreg.valor;
            ruc.desc_prov = multiRef.desc_prov.valor;
            ruc.desc_tipvia = multiRef.desc_tipvia.valor;
            ruc.desc_tipzon = multiRef.desc_tipzon.valor;
            ruc.desc_tpoemp = multiRef.desc_tpoemp.valor;
            ruc.esActivo = multiRef.esActivo.valor;
            ruc.esHabido = multiRef.esHabido.valor;

            return ruc;
        }
        public string FormatearJson(string jsonText)
        {
            jsonText = jsonText.Replace(@"\", "");
            jsonText = jsonText.Replace("?xml", "xml");
            jsonText = jsonText.Replace("@version", "version");
            jsonText = jsonText.Replace("@encoding", "encoding");
            jsonText = jsonText.Replace("soapenv:Envelope", "soapenv_envelope");
            jsonText = jsonText.Replace("@xmlns:soapenv", "xmlns_soapenv");
            jsonText = jsonText.Replace("@xmlns:xsd", "xmlns_xsd");
            jsonText = jsonText.Replace("@xmlns:xsi", "xmlns_xsi");
            jsonText = jsonText.Replace("soapenv:Body", "soapenv_body");
            jsonText = jsonText.Replace("ns1:getDatosPrincipalesResponse", "getDatosPrincipalesResponse");
            jsonText = jsonText.Replace("@soapenv:encodingStyle", "soapenv_encodingStyle");
            jsonText = jsonText.Replace("@xmlns:ns1", "xmlns_ns1");
            jsonText = jsonText.Replace("@href", "href");
            jsonText = jsonText.Replace("@id", "id");
            jsonText = jsonText.Replace("@soapenc:root", "soapenc_root");
            jsonText = jsonText.Replace("@soapenv:encodingStyle", "soapenv_encodingStyle");
            jsonText = jsonText.Replace("@xsi:type", "xsi_type");
            jsonText = jsonText.Replace("@xmlns:soapenc", "xmlns_soapenc");
            jsonText = jsonText.Replace("@xmlns:ns2", "xmlns_ns2");
            jsonText = jsonText.Replace("#text", "valor");
            jsonText = jsonText.Replace("@xsi:nil", "valor");
            return jsonText;
        }

        public string FormatearJson2(string jsonText)
        {
            jsonText = jsonText.Replace("xsd:string", "");
            jsonText = jsonText.Replace("type=", "");
            jsonText = jsonText.Replace("\"", "");
            jsonText = jsonText.Replace("nil=true", "");
            jsonText = jsonText.Replace("xsd:short", "");
            return jsonText;
        }
        public ERespuestaS getDatosSecundarios(string nroDocumento)
        {
            ERespuestaS oERespuesta = new ERespuestaS();
            string datos = "";

            if (String.IsNullOrEmpty(nroDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento";
                return oERespuesta;
            }

            try
            {
                SunatConsultaRuc sunatConsultaRuc = new SunatConsultaRuc();
                var llamada_servicio = sunatConsultaRuc.getDatosSecundarios(nroDocumento);

            }
            catch (Exception e)
            {
                datos = e.Message;

                //datos = datos.Replace("Client found response content type of 'text/plain', but expected 'text/xml'.", "");
                //datos = datos.Replace("The request failed with the error message:", "");

                datos = datos.Replace("El cliente encontró el tipo de contenido de respuesta 'text/plain', pero se esperaba 'text/xml'.", "");
                datos = datos.Replace("Error de la solicitud con el mensaje de error:", "");

                datos = datos.Replace("\r\n--.", "");
                datos = datos.Replace("\r\n\r\n--\r\n", "");
                datos = datos.Replace("HTTP/1.1 100 Continue\r\n\r\n", "");

                datos = datos.Replace("&", "&amp;");
            }

            try
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(datos);

                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("multiRef");

                string obj_inicial = string.Empty;

                foreach (XmlNode node in nodeList)
                {
                    obj_inicial = node.InnerXml;

                }

                obj_inicial = "<RucDatosSecundarios>" + obj_inicial + "</RucDatosSecundarios>";

                var obj_final = XElement.Parse(obj_inicial);

                var nuevo_obj = RemoveAllNamespaces(obj_final);

                string cadena_final = FormatearJson2(nuevo_obj.ToString());

                RucDatosSecundarios resultado = new RucDatosSecundarios();

                XmlSerializer serializer = new XmlSerializer(typeof(RucDatosSecundarios));
                using (StringReader reader = new StringReader(cadena_final))
                {
                    resultado = (RucDatosSecundarios)serializer.Deserialize(reader);
                }

                oERespuesta.JsonString = JsonConvert.SerializeObject(resultado);
            }
            catch (Exception e)
            {
                oERespuesta.Codigo = -2;
                oERespuesta.Mensaje = "No se obtuvo resultado";
            }

            return oERespuesta;
        }

        public ERespuestaS getDomicilioLegal(string nroDocumento)
        {
            ERespuestaS oERespuesta = new ERespuestaS();
            string datos = "";

            if (String.IsNullOrEmpty(nroDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento";
                return oERespuesta;
            }

            try
            {
                SunatConsultaRuc sunatConsultaRuc = new SunatConsultaRuc();
                var llamada_servicio = sunatConsultaRuc.getDomicilioLegal(nroDocumento);

            }
            catch (Exception e)
            {
                datos = e.Message;

                //datos = datos.Replace("Client found response content type of 'text/plain', but expected 'text/xml'.", "");
                //datos = datos.Replace("The request failed with the error message:", "");

                datos = datos.Replace("El cliente encontró el tipo de contenido de respuesta 'text/plain', pero se esperaba 'text/xml'.", "");
                datos = datos.Replace("Error de la solicitud con el mensaje de error:", "");

                datos = datos.Replace("\r\n--.", "");
                datos = datos.Replace("\r\n\r\n--\r\n", "");
                datos = datos.Replace("HTTP/1.1 100 Continue\r\n\r\n", "");

                datos = datos.Replace("&", "&amp;");
            }

            try
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(datos);

                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("getDomicilioLegalReturn");

                string obj_inicial = string.Empty;

                foreach (XmlNode node in nodeList)
                {
                    obj_inicial = node.InnerXml;

                }

                RucDomicilioLegal resultado = new RucDomicilioLegal();
                resultado.DomicilioLegal = obj_inicial;

                oERespuesta.JsonString = JsonConvert.SerializeObject(resultado);
            }
            catch (Exception e)
            {
                oERespuesta.Codigo = -2;
                oERespuesta.Mensaje = "No se obtuvo resultado";
            }

            return oERespuesta;
        }

        public ERespuestaS getRepresentanteLegal(string nroDocumento)
        {
            ERespuestaS oERespuesta = new ERespuestaS();
            string datos = "";

            if (String.IsNullOrEmpty(nroDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento";
                return oERespuesta;
            }

            try
            {
                SunatConsultaRuc sunatConsultaRuc = new SunatConsultaRuc();
                var llamada_servicio = sunatConsultaRuc.getRepLegales(nroDocumento);

            }
            catch (Exception e)
            {
                datos = e.Message;

                //datos = datos.Replace("Client found response content type of 'text/plain', but expected 'text/xml'.", "");
                //datos = datos.Replace("The request failed with the error message:", "");

                datos = datos.Replace("El cliente encontró el tipo de contenido de respuesta 'text/plain', pero se esperaba 'text/xml'.", "");
                datos = datos.Replace("Error de la solicitud con el mensaje de error:", "");

                datos = datos.Replace("\r\n--.", "");
                datos = datos.Replace("\r\n\r\n--\r\n", "");
                datos = datos.Replace("HTTP/1.1 100 Continue\r\n\r\n", "");

                datos = datos.Replace("&", "&amp;");
            }

            try
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(datos);

                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("multiRef");

                string obj_inicial = string.Empty;

                foreach (XmlNode node in nodeList)
                {
                    obj_inicial = node.InnerXml;

                }

                obj_inicial = "<RucRepresentanteLegal>" + obj_inicial + "</RucRepresentanteLegal>";

                var obj_final = XElement.Parse(obj_inicial);

                var nuevo_obj = RemoveAllNamespaces(obj_final);

                string cadena_final = FormatearJson2(nuevo_obj.ToString());

                RucRepresentanteLegal resultado = new RucRepresentanteLegal();

                XmlSerializer serializer = new XmlSerializer(typeof(RucRepresentanteLegal));
                using (StringReader reader = new StringReader(cadena_final))
                {
                    resultado = (RucRepresentanteLegal)serializer.Deserialize(reader);
                }

                oERespuesta.JsonString = JsonConvert.SerializeObject(resultado);
            }
            catch (Exception e)
            {
                oERespuesta.Codigo = -2;
                oERespuesta.Mensaje = "No se obtuvo resultado";
            }

            return oERespuesta;
        }

        public XElement RemoveAllNamespaces(XElement e)
        {
            return new XElement(e.Name.LocalName,
               (from n in e.Nodes()
                select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
               (e.HasAttributes) ? (from a in e.Attributes()
                                    where (!a.IsNamespaceDeclaration)
                                    select new XAttribute(a.Name.LocalName, a.Value)) : null);
        }


        #endregion

        #region RENIEC
        public ERespuestaR getDatosReniec(string nroDNI)
        {

            ReniecConsultaDni c = new ReniecConsultaDni();
            peticionConsulta p = new peticionConsulta();

            p.nuDniConsulta = nroDNI;
            p.nuDniUsuario = System.Configuration.ConfigurationManager.AppSettings["RENIEC_USUARIO"];
            p.password = System.Configuration.ConfigurationManager.AppSettings["RENIEC_CLAVE"];
            p.nuRucUsuario = System.Configuration.ConfigurationManager.AppSettings["RUC_ENTIDAD"];

            resultadoConsulta r = new resultadoConsulta();
            ERespuestaR res = new ERespuestaR();

            if (String.IsNullOrEmpty(nroDNI))
            {
                res.Codigo = -4;
                res.Mensaje = "No se ha registrado número de documento.";
                return res;
            }

            try
            {

                r = c.consultar(p);
                if (r.datosPersona != null)
                {

                    ReniecPide dp = new ReniecPide();
                    dp.apPrimer = r.datosPersona.apPrimer;
                    dp.apSegundo = r.datosPersona.apSegundo;
                    dp.prenombres = r.datosPersona.prenombres;
                    dp.estadoCivil = r.datosPersona.estadoCivil;
                    dp.direccion = r.datosPersona.direccion;
                    dp.ubigeo = r.datosPersona.ubigeo;
                    dp.restriccion = r.datosPersona.restriccion;

                    dp.fotob64 = Convert.ToBase64String(r.datosPersona.foto);

                    res.r = dp;

                }
                else
                {
                    if (r.coResultado == "1002")
                    {
                        peticionActualizarCredencial datosc = new peticionActualizarCredencial();
                        datosc.credencialAnterior = p.nuDniUsuario;
                        datosc.credencialNueva = p.nuDniUsuario;
                        datosc.nuRuc = p.nuRucUsuario;
                        datosc.nuDni = p.nuDniUsuario;
                        c.actualizarcredencial(datosc);
                        res.Codigo = -1;
                        res.Mensaje = "Por favor, intente nuevamente.";
                    }
                    else
                    {
                        res.Codigo = Convert.ToInt32(r.coResultado);
                        res.Mensaje = r.deResultado;
                    }
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

        #region SUNEDU
        public EResGTSunedu getDatosSunedu(string nroDocumento)
        {
            EResGTSunedu oERespuesta = new EResGTSunedu();

            if (String.IsNullOrEmpty(nroDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {

                WSGrados cclient = new WSGrados();
                Object lista;
                usuarioType usuario = new usuarioType();
                usuario.idEntidad = "1";
                usuario.clave = System.Configuration.ConfigurationManager.AppSettings["SUNEDU_CLAVE"];
                usuario.usuario = System.Configuration.ConfigurationManager.AppSettings["SUNEDU_USUARIO"];
                operacionType operacion = new operacionType();
                operacion.fecha = DateTime.Now.ToString("yyyyMMdd");
                operacion.hora = DateTime.Now.ToString("HHmmss");
                operacion.mac_wsServer = System.Configuration.ConfigurationManager.AppSettings["SUNEDU_MACSERVER"];
                operacion.ip_wsServer = System.Configuration.ConfigurationManager.AppSettings["SUNEDU_IPSERVER"];
                operacion.ip_wsUser = System.Configuration.ConfigurationManager.AppSettings["SUNEDU_IPUSUARIO"];

                var obj = cclient.opConsultarRNGT(usuario, operacion, nroDocumento, out lista);
                XmlNode[] n = lista as System.Xml.XmlNode[];

                List<gtPersona> per = new List<gtPersona>();
                oERespuesta.respuesta = obj;
                if (n != null)
                {
                    foreach (var element in n)
                    {
                        if (element.Name == "gtPersona")
                        {
                            string result = (string)element.InnerXml;
                            string result3 = "<gtPersona>" + result + "</gtPersona>";
                            XmlSerializer serializer = new XmlSerializer(typeof(gtPersona), new XmlRootAttribute("gtPersona"));
                            StringReader stringReader = new StringReader(result3);
                            gtPersona p = (gtPersona)serializer.Deserialize(stringReader);
                            per.Add(p);
                        }
                    }
                }
                oERespuesta.r = per;
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

        #endregion

        #region SUNARP
        public ERespuestaS getSunarpNaveAeronave(string numeroMatricula)
        {
            return wsSUNARP.NaveAeronave(numeroMatricula);
        }

        public ERespuestaS getSunarpPJRazonSocial(string razonSocial)
        {
            return wsSUNARP.PJRazonSocial(razonSocial);
        }

        public ERespuestaS getSunarpTitularidadPN(string apellidoPaterno, string apellidoMaterno, string nombres)
        {
            return wsSUNARP.TitularidadPN(apellidoPaterno, apellidoMaterno, nombres);
        }


        public ERespuestaS getSunarpTitularidadPJ(string razonSocial)
        {
            return wsSUNARP.TitularidadPJ(razonSocial);
        }

        public ERespuestaS getSunarpTitularidadSIRSARP(string apellidoPaterno, string apellidoMaterno, string nombres)
        {
            return wsSUNARP.TitularidadSIRSARP(apellidoPaterno, apellidoMaterno, nombres);
        }

        public ERespuestaS getSunarpTitularidadSIRSARPJ(string razonSocial)
        {
            return wsSUNARP.TitularidadSIRSARPJ(razonSocial);
        }

        public ERespuestaS getSunarpOficinas()
        {
            return wsSUNARP.SunarpOficinas();
        }

        public ERespuestaS getSunarpListarAsientos(string zona, string oficina, string partida, string registro)
        {
            return wsSUNARP.ListarAsientos(zona, oficina, partida, registro);
        }

        public ERespuestaS getSunarpListarAsientosSIRSARP(string zona, string oficina, string partida, string registro)
        {
            return wsSUNARP.ListarAsientosSIRSARP(zona, oficina, partida, registro);
        }

        public ERespuestaS getSunarpVerDetalleRPV(string zona, string oficina, string placa)
        {
            return wsSUNARP.VerDetalleRPV(zona, oficina, placa);
        }

        public ERespuestaS getSunarpVerDetalleRPVExtra(string zona, string oficina, string placa)
        {
            return wsSUNARP.VerDetalleRPVExtra(zona, oficina, placa);
        }

        public ERespuestaS getSunarpVerAsientos(string transaccion, string idImg, string tipo, string nroTotalPag, string nroPagRef, string pagina)
        {
            return wsSUNARP.VerAsientos(transaccion, idImg, tipo, nroTotalPag, nroPagRef, pagina);
        }

        public ERespuestaS getSunarpVerAsientoSIRSARP(string transaccion, string idImg, string tipo, string nroTotalPag, string nroPagRef, string pagina)
        {
            return wsSUNARP.VerAsientoSIRSARP(transaccion, idImg, tipo, nroTotalPag, nroPagRef, pagina);
        }
        #endregion

        #region MIGRACIONES
        public ERespuestaM getMigracionesDocumento(string nroDocumento)
        {
            ERespuestaM oERespuesta = new ERespuestaM();

            if (String.IsNullOrEmpty(nroDocumento))
            {
                oERespuesta.Codigo = -4;
                oERespuesta.Mensaje = "No se ha registrado número de documento.";
                return oERespuesta;
            }

            try
            {

                MigraCarnetdeExtrajeria cclient = new MigraCarnetdeExtrajeria();

                solicitudBean solicitud = new solicitudBean();
                solicitud.strCodInstitucion = System.Configuration.ConfigurationManager.AppSettings["MIGRACIONES_CODIGO"];
                solicitud.strMac = System.Configuration.ConfigurationManager.AppSettings["SUNEDU_MACSERVER"];
                solicitud.strNroIp = System.Configuration.ConfigurationManager.AppSettings["SUNEDU_IPSERVER"];
                solicitud.strNumDocumento = nroDocumento;
                solicitud.strTipoDocumento = "CE";



                var obj = cclient.consultarDocumento(solicitud);

                oERespuesta.r = obj;
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
        #endregion

        #region AJUDICIALES
        public EResAntJudicial getAntJudiciales(string nroDocumento, string apePaterno, string apeMaterno, string Nombres)
        {
            return wsJUDICIALES.GetAntJudicialesPIDE(nroDocumento, apePaterno, apeMaterno, Nombres);
        }

        #endregion

        #region APENALES

        public EResAntPenal getAntPenales(string nroDocumento, string apePaterno, string apeMaterno, string pNombres)
        {
            return wsPENALES.GetAntPenalesPIDE(nroDocumento, apePaterno, apeMaterno, pNombres);
        }


        #endregion

        #region APOLICIALES

        public EResAntPolicial getAntPoliciales(string nroDocumento)
        {
            return wsPOLICIALES.GetAntPolicialesPIDE(nroDocumento);
        }

        #endregion

        #region MTC
        public ERespuestaS getMtcDatosLicencia(string iTipoDocumento, string sNumDocumento)
        {
            return wsMTC.DatosLicencia(iTipoDocumento, sNumDocumento);
        }

        public ERespuestaS getMtcRecordConductor(string Tipo_Documento, string Numero_Documento, string Numero_Record)
        {
            return wsMTC.RecordConductor(Numero_Documento, Numero_Record, Tipo_Documento);
        }

        public ERespuestaS getMtcDatosPapeletas(string iTipoDocumento, string sNumDocumento)
        {
            return wsMTC.DatosPapeletas(iTipoDocumento, sNumDocumento);
        }

        public ERespuestaS getMtcUltimaLicencia(string iTipoDocumento, string sNumDocumento)
        {
            return wsMTC.UltimaLicencia(iTipoDocumento, sNumDocumento);
        }

        public ERespuestaS getMtcUltimasSanciones(string iTipoDocumento, string sNumDocumento)
        {
            return wsMTC.UltimasSanciones(iTipoDocumento, sNumDocumento);
        }
        #endregion
    }
}
