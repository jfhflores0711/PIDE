using OpenB.Entidad;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OpenB.DA
{
    public partial class db_openbContext : DbContext
    {
        static db_openbContext()
        {
            Database.SetInitializer<db_openbContext>(null);
        }

        public db_openbContext()
            : base("Name=db_openbContext")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }

        public virtual DbSet<parametros> parametros { get; set; }

    }
}
