namespace OpenB.Entidad.ws
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://controller.pide.sunarp.gob.pe/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://controller.pide.sunarp.gob.pe/", IsNullable = false)]
    public partial class oficina
    {

        private oficina1[] oficina1Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oficina", Namespace = "")]
        public oficina1[] oficina1
        {
            get
            {
                return this.oficina1Field;
            }
            set
            {
                this.oficina1Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("oficina", Namespace = "", IsNullable = false)]
    public partial class oficina1
    {

        private string codZonaField;

        private string codOficinaField;

        private string descripcionField;

        /// <remarks/>
        public string codZona
        {
            get
            {
                return this.codZonaField;
            }
            set
            {
                this.codZonaField = value;
            }
        }

        /// <remarks/>
        public string codOficina
        {
            get
            {
                return this.codOficinaField;
            }
            set
            {
                this.codOficinaField = value;
            }
        }

        /// <remarks/>
        public string descripcion
        {
            get
            {
                return this.descripcionField;
            }
            set
            {
                this.descripcionField = value;
            }
        }
    }
}
