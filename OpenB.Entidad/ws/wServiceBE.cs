using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenB.Entidad.ws
{
    public class ERespuesta
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
               
        public ERespuesta()
        {
            this.Codigo = 0;
            this.Mensaje = "Ejecutado con éxito.";
        }
    }

    public class ERespuestaS: ERespuesta
    {
        public string JsonString { get; set; }
    }

        public class ReniecPide : datosPersona
    {
        public string fotob64 { get; set; }
    }

    public class ERespuestaR
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }

        public ReniecPide r { get; set; }
        public ERespuestaR()
        {
            this.Codigo = 0;
            this.Mensaje = "Ejecutado con éxito.";
            this.r = null;
        }

        public static implicit operator ERespuestaR(Task<ERespuestaR> v)
        {
            throw new NotImplementedException();
        }
    }

    public class gtPersona
    {
        public string tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombres { get; set; }
        public string abreviaturaTitulo { get; set; }
        public string tituloProfesional { get; set; }
        public string universidad { get; set; }
        public string pais { get; set; }
        public string tipoInstitucion { get; set; }
        public string tipoGestion { get; set; }
        public string fechaEmision { get; set; }
        public string resolucion { get; set; }
        public string fechaResolucion { get; set; }
    }

    public class EResGTSunedu
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public respuestaType respuesta { get; set; }
        public List<gtPersona> r { get; set; }
        public EResGTSunedu()
        {
            this.Codigo = 0;
            this.Mensaje = "Ejecutado con éxito.";
            this.respuesta = null;
            this.r = null;
        }
    }


    public class ERespuestaM: ERespuesta
    {
        public respuestaBean r { get; set; }
        public ERespuestaM()
        {
            this.Codigo = 0;
            this.Mensaje = "Ejecutado con éxito.";
            this.r = null;
        }
    }

    public class EResAntJudicial: ERespuesta
    {
        public string r { get; set; }
        public EResAntJudicial()
        {
            this.Codigo = 0;
            this.Mensaje = "Ejecutado con éxito.";
            this.r = null;
        }
    }

    public class EResAntPenal: ERespuesta
    {

        public verificarAntecedentesPenalesResponse r { get; set; }
        public EResAntPenal()
        {
            this.Codigo = 0;
            this.Mensaje = "Ejecutado con éxito.";
            this.r = null;
        }
    }

    public class EResAntPolicial: ERespuesta
    {
        public respuestaPersona[] r { get; set; }
        public EResAntPolicial()
        {
            this.Codigo = 0;
            this.Mensaje = "Ejecutado con éxito.";
            this.r = null;
        }
    }
}
