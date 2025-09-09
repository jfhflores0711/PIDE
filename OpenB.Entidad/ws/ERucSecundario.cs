using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace OpenB.Entidad.ws
{


    [XmlRoot(ElementName = "RucDatosSecundarios")]
    public class RucDatosSecundarios
    {

        [XmlElement(ElementName = "dds_aparta")]
        public string DdsAparta { get; set; }

        [XmlElement(ElementName = "dds_asient")]
        public string DdsAsient { get; set; }

        [XmlElement(ElementName = "dds_califi")]
        public string DdsCalifi { get; set; }

        [XmlElement(ElementName = "dds_centro")]
        public string DdsCentro { get; set; }

        [XmlElement(ElementName = "dds_cierre")]
        public string DdsCierre { get; set; }

        [XmlElement(ElementName = "dds_comext")]
        public string DdsComext { get; set; }

        [XmlElement(ElementName = "dds_consti")]
        public string DdsConsti { get; set; }

        [XmlElement(ElementName = "dds_contab")]
        public string DdsContab { get; set; }

        [XmlElement(ElementName = "dds_docide")]
        public string DdsDocide { get; set; }

        [XmlElement(ElementName = "dds_domici")]
        public string DdsDomici { get; set; }

        [XmlElement(ElementName = "dds_ejempl")]
        public string DdsEjempl { get; set; }

        [XmlElement(ElementName = "dds_factur")]
        public string DdsFactur { get; set; }

        [XmlElement(ElementName = "dds_fecact")]
        public string DdsFecact { get; set; }

        [XmlElement(ElementName = "dds_fecnac")]
        public string DdsFecnac { get; set; }

        [XmlElement(ElementName = "dds_fecven")]
        public string DdsFecven { get; set; }

        [XmlElement(ElementName = "dds_ficha")]
        public string DdsFicha { get; set; }

        [XmlElement(ElementName = "dds_inicio")]
        public string DdsInicio { get; set; }

        [XmlElement(ElementName = "dds_licenc")]
        public string DdsLicenc { get; set; }

        [XmlElement(ElementName = "dds_motbaj")]
        public string DdsMotbaj { get; set; }

        [XmlElement(ElementName = "dds_motemi")]
        public string DdsMotemi { get; set; }

        [XmlElement(ElementName = "dds_nacion")]
        public string DdsNacion { get; set; }

        [XmlElement(ElementName = "dds_nfolio")]
        public string DdsNfolio { get; set; }

        [XmlElement(ElementName = "dds_nomcom")]
        public string DdsNomcom { get; set; }

        [XmlElement(ElementName = "dds_nrodoc")]
        public string DdsNrodoc { get; set; }

        [XmlElement(ElementName = "dds_numfax")]
        public string DdsNumfax { get; set; }

        [XmlElement(ElementName = "dds_numruc")]
        public string DdsNumruc { get; set; }

        [XmlElement(ElementName = "dds_orient")]
        public string DdsOrient { get; set; }

        [XmlElement(ElementName = "dds_paispa")]
        public string DdsPaispa { get; set; }

        [XmlElement(ElementName = "dds_pasapo")]
        public string DdsPasapo { get; set; }

        [XmlElement(ElementName = "dds_patron")]
        public string DdsPatron { get; set; }

        [XmlElement(ElementName = "dds_sexo")]
        public string DdsSexo { get; set; }

        [XmlElement(ElementName = "dds_telef1")]
        public string DdsTelef1 { get; set; }

        [XmlElement(ElementName = "dds_telef2")]
        public string DdsTelef2 { get; set; }

        [XmlElement(ElementName = "dds_telef3")]
        public string DdsTelef3 { get; set; }

        [XmlElement(ElementName = "dds_userna")]
        public string DdsUserna { get; set; }

        [XmlElement(ElementName = "declara")]
        public string Declara { get; set; }

        [XmlElement(ElementName = "desc_cierre")]
        public string DescCierre { get; set; }

        [XmlElement(ElementName = "desc_comext")]
        public string DescComext { get; set; }

        [XmlElement(ElementName = "desc_contab")]
        public string DescContab { get; set; }

        [XmlElement(ElementName = "desc_docide")]
        public string DescDocide { get; set; }

        [XmlElement(ElementName = "desc_domici")]
        public string DescDomici { get; set; }

        [XmlElement(ElementName = "desc_factur")]
        public string DescFactur { get; set; }

        [XmlElement(ElementName = "desc_motbaj")]
        public string DescMotbaj { get; set; }

        [XmlElement(ElementName = "desc_nacion")]
        public string DescNacion { get; set; }

        [XmlElement(ElementName = "desc_orient")]
        public string DescOrient { get; set; }

        [XmlElement(ElementName = "desc_sexo")]
        public string DescSexo { get; set; }
    }

    public class RucDomicilioLegal
    {
        public string DomicilioLegal { get; set; }
    }

    public class RucRepresentanteLegal
    {
        public string cod_cargo { get; set; }
        public string cod_depar { get; set; }
        public string desc_docide { get; set; }
        public string num_ord_suce { get; set; }
        public string rso_cargoo { get; set; }
        public string rso_docide { get; set; }
        public string rso_fecact { get; set; }
        public string rso_fecnac { get; set; }
        public string rso_nombre { get; set; }
        public string rso_nrodoc { get; set; }
        public string rso_numruc { get; set; }
        public string rso_userna { get; set; }
        public string rso_vdesde { get; set; }
    }

}