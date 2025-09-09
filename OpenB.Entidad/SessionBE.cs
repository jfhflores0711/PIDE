using OpenB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad
{
    public class SessionBE
    {

        public int IdUsuario
        {
            get { return SessionManager.Get<int>("Id_Usuario__"); }
            set { SessionManager.Save<int>("Id_Usuario__", value); }
        }
        public String ApellidoPaterno
        {
            get { return SessionManager.Get<String>("ApePaterno__"); }
            set { SessionManager.Save<String>("ApePaterno__", value); }
        }

        public String ApellidoMaterno
        {
            get { return SessionManager.Get<String>("ApeMaterno__"); }
            set { SessionManager.Save<String>("ApeMaterno__", value); }
        }

        public String Nombres
        {
            get { return SessionManager.Get<String>("Nombres__"); }
            set { SessionManager.Save<String>("Nombres__", value); }
        }

        public String NombreCompleto
        {
            get { return SessionManager.Get<String>("NombreCompleto"); }
            set { SessionManager.Save<String>("NombreCompleto", value); }
        }

        public String NroDocumento
        {
            get { return SessionManager.Get<String>("Login__"); }
            set { SessionManager.Save<String>("Login__", value); }
        }


        public bool Flag
        {
            get { return SessionManager.Get<bool>("Flag__"); }
            set { SessionManager.Save<bool>("Flag__", value); }
        }


    }

}
