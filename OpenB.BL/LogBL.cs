using OpeB.DA;
using OpenB.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BL
{
    public class LogBL
    {
        public static bool LogSEDI(LogBE l)
        {
            if (LogDA.LogSEDI(l) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
