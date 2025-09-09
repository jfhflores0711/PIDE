using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad
{
    public class Eroles
    {
       public int n_id_rol { get; set; } 
        public string v_rol { get; set; }
        public string v_descripcion { get; set; }

    }

    public class ModelUsuario
    {
        public int? n_id_usuario { get; set; }
        [Required(ErrorMessage = "Ingrese login de usuario")]
        public string c_login { get; set; }

        [Required(ErrorMessage = "Ingrese DNI de usuario")]
        public string c_dni { get; set; }
        [Required(ErrorMessage = "Ingrese apellido paterno")]
        public string c_appaterno { get; set; }
        [Required(ErrorMessage = "Ingrese apellido materno")]
        public string c_apmaterno { get; set; }
        [Required(ErrorMessage = "Ingrese nombres")]
        public string c_nombres { get; set; }

        [Required(ErrorMessage = "Ingrese nombre completo")]
        public string c_nombrec { get; set; }
        public string c_cargo { get; set; }
        public bool n_estado { get; set; }
        public int n_usuario_modifica { get; set; }
    }

    public class UsuarioRoles
    {
        public int i_id_usuario { get; set; }
        public int n_id_rol { get; set; }
        public string v_rol { get; set; }
        public string v_descripcion { get; set; }
        public bool roles { get; set; }
    }

    public class ModelUsuarioRole
    {
        public int i_id_usuario { get; set; }
        public int i_id_rol { get; set; }
        public int i_creado_por { get; set; }
        public bool valor { get; set; }
    }

    public class ModelSegUsuario
    {
        [Required(ErrorMessage = "Ingrese clave actual.")]
        public string actual { get; set; }
        [Required(ErrorMessage = "Ingrese nueva clave.")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*+-]).{8,30}$",
         ErrorMessage = "La nueva clave no cumple con la complejidad.")]
        [StringLength(30, ErrorMessage = "La clave debe tener más de 8 caracteres y menos de 30.", MinimumLength = 8)]
        public string nuevo1 { get; set; }
        [Required(ErrorMessage = "Repita nueva clave.")]
        [Compare(nameof(nuevo1), ErrorMessage = "Las claves nuevas no coinciden.")]
        public string nuevo2 { get; set; }
        public int id_usuario { get; set; }
    }

}
