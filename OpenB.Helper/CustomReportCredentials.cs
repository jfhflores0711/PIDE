using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Reporting.WebForms;

namespace OpenB.Helper
{
    public class CustomReportCredentials : IReportServerCredentials
    {
        private string _UserName;
        private string _PassWord;
        private string _DomainName;

        public CustomReportCredentials(string u_, string p_, string d_)
        {
            _UserName = u_;
            _PassWord = p_;
            _DomainName = d_;
        }
        public System.Security.Principal.WindowsIdentity ImpersonationUser { get { return null; } }

        public ICredentials NetworkCredentials { get { return new NetworkCredential(_UserName, _PassWord, _DomainName); } }

        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority) { authCookie = null; user = password = authority = null; return false; }
    }
}
