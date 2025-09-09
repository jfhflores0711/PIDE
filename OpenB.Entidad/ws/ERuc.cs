using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad.ws
{

    public class EXml
    {
        public string version { get; set; }
        public string encoding { get; set; }
    }
    public class GetDatosPrincipalesReturn
    {
        public string href { get; set; }
    }
    public class GetDatosPrincipalesResponse
    {
        public string soapenv_encodingStyle { get; set; }
        public string xmlns_ns1 { get; set; }
        public GetDatosPrincipalesReturn getDatosPrincipalesReturn { get; set; }
    }

    public class Soapenv_body
    {
        public GetDatosPrincipalesResponse getDatosPrincipalesResponse { get; set; }
        public MultiRef multiRef { get; set; }
    }

    public class MultiRef
    {
        public string id { get; set; }
        public string soapenc_root { get; set; }
        public string soapenv_encodingStyle { get; set; }
        public string xsi_type { get; set; }
        public string xmlns_soapenc { get; set; }
        public string xmlns_ns2 { get; set; }

        public Cod_dep cod_dep { get; set; }
        public Cod_dist cod_dist { get; set; }
        public Cod_prov cod_prov { get; set; }
        public Ddp_ciiu ddp_ciiu { get; set; }
        public Ddp_doble ddp_doble { get; set; }
        public Ddp_estado ddp_estado { get; set; }
        public Ddp_fecact ddp_fecact { get; set; }
        public Ddp_fecalt ddp_fecalt { get; set; }
        public Ddp_fecbaj ddp_fecbaj { get; set; }
        public Ddp_flag22 ddp_flag22 { get; set; }
        public Ddp_identi ddp_identi { get; set; }
        public Ddp_inter1 ddp_inter1 { get; set; }
        public Ddp_lllttt ddp_lllttt { get; set; }
        public Ddp_mclase ddp_mclase { get; set; }
        public Ddp_nombre ddp_nombre { get; set; }
        public Ddp_nomvia ddp_nomvia { get; set; }
        public Ddp_nomzon ddp_nomzon { get; set; }
        public Ddp_numer1 ddp_numer1 { get; set; }
        public Ddp_numreg ddp_numreg { get; set; }
        public Ddp_numruc ddp_numruc { get; set; }
        public Ddp_reacti ddp_reacti { get; set; }
        public Ddp_refer1 ddp_refer1 { get; set; }
        public Ddp_secuen ddp_secuen { get; set; }
        public Ddp_tamano ddp_tamano { get; set; }
        public Ddp_tipvia ddp_tipvia { get; set; }
        public Ddp_tipzon ddp_tipzon { get; set; }
        public Ddp_tpoemp ddp_tpoemp { get; set; }
        public Ddp_ubigeo ddp_ubigeo { get; set; }
        public Ddp_userna ddp_userna { get; set; }
        public Desc_ciiu desc_ciiu { get; set; }
        public Desc_dep desc_dep { get; set; }
        public Desc_dist desc_dist { get; set; }
        public Desc_estado desc_estado { get; set; }
        public Desc_flag22 desc_flag22 { get; set; }
        public Desc_identi desc_identi { get; set; }
        public Desc_numreg desc_numreg { get; set; }
        public Desc_prov desc_prov { get; set; }
        public Desc_tamano desc_tamano { get; set; }
        public Desc_tipvia desc_tipvia { get; set; }
        public Desc_tipzon desc_tipzon { get; set; }
        public Desc_tpoemp desc_tpoemp { get; set; }
        public EsActivo esActivo { get; set; }
        public EsHabido esHabido { get; set; }
    }

    public class Cod_dep
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Cod_dist
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Cod_prov
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_ciiu
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_doble
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_estado
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_fecact
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_fecalt
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_fecbaj
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_flag22
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_identi
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_inter1
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_lllttt
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_mclase
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_nombre
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_nomvia
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_nomzon
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_numer1
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_numreg
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_numruc
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_reacti
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_refer1
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_secuen
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_tamano
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_tipvia
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_tipzon
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_tpoemp
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_ubigeo
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Ddp_userna
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_ciiu
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_dep
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_dist
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_estado
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_flag22
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_identi
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_numreg
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_prov
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_tamano
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_tipvia
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_tipzon
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class Desc_tpoemp
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class EsActivo
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }
    public class EsHabido
    {
        public string xsi_type { get; set; }
        public string valor { get; set; }
    }


    public class ESoapEnv
    {
        public string xmlns_soapenv { get; set; }
        public string xmlns_xsd { get; set; }
        public string xmlns_xsi { get; set; }
        public Soapenv_body soapenv_body { get; set; }
    }

    public class ERespuestaRuc
    {
        public EXml xml { get; set; }
        public ESoapEnv soapenv_envelope { get; set; }
    }

    public class ERuc
    {
        public string ddp_ubigeo { get; set; }
        public string cod_dep { get; set; }
        public string desc_dep { get; set; }
        public string cod_prov { get; set; }
        public string desc_prov { get; set; }
        public string cod_dist { get; set; }
        public string desc_dist { get; set; }
        public string ddp_ciiu { get; set; }
        public string desc_ciiu { get; set; }
        public string ddp_estado { get; set; }
        public string desc_estado { get; set; }
        public string ddp_fecact { get; set; }
        public string ddp_fecalt { get; set; }
        public string ddp_fecbaj { get; set; }
        public string ddp_identi { get; set; }
        public string desc_identi { get; set; }
        public string ddp_lllttt { get; set; }
        public string ddp_nombre { get; set; }
        public string ddp_nomvia { get; set; }
        public string ddp_numer1 { get; set; }
        public string ddp_inter1 { get; set; }
        public string ddp_nomzon { get; set; }
        public string ddp_refer1 { get; set; }
        public string ddp_flag22 { get; set; }
        public string desc_flag22 { get; set; }
        public string ddp_numreg { get; set; }
        public string desc_numreg { get; set; }
        public string ddp_numruc { get; set; }
        public string ddp_tipvia { get; set; }
        public string desc_tipvia { get; set; }
        public string ddp_tipzon { get; set; }
        public string desc_tipzon { get; set; }
        public string ddp_tpoemp { get; set; }
        public string desc_tpoemp { get; set; }
        public string ddp_secuen { get; set; }
        public string esActivo { get; set; }
        public string esHabido { get; set; }
    }

}
