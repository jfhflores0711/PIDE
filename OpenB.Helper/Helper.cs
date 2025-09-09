using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OpenB.Helper
{
    public class General
    {
        public static object ConfigurationManager { get; private set; }

        public static string GetIPCliente(HttpRequestBase request)
        {
            try
            {
                var userHostAddress = request.UserHostAddress;

                IPAddress.Parse(userHostAddress);

                var xForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(xForwardedFor))
                    return userHostAddress;

                var publicForwardingIps = xForwardedFor.Split(',').Where(ip => !IsPrivateIpAddress(ip)).ToList();

                return publicForwardingIps.Any() ? publicForwardingIps.Last() : userHostAddress;
            }
            catch (Exception)
            {
                return "0.0.0.0";
            }
        }

        private static bool IsPrivateIpAddress(string ipAddress)
        {
            var ip = IPAddress.Parse(ipAddress);
            var octets = ip.GetAddressBytes();

            var is24BitBlock = octets[0] == 10;
            if (is24BitBlock) return true;

            var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
            if (is20BitBlock) return true;

            var is16BitBlock = octets[0] == 192 && octets[1] == 168;
            if (is16BitBlock) return true;

            var isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
            return isLinkLocalAddress;
        }

        public static string GetNavegadorCliente(HttpRequestBase request)
        {
            return request.ServerVariables["HTTP_USER_AGENT"];
        }

        public static String generarNombreArchivoFirma(String nombreArchivo)
        {
            var name = Truncate(RemoveSpecialCharacters(nombreArchivo), 80);
            return name + "-[" + DateTime.Now.ToString("ddMMyyyy hhmmss") + "]";
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string ReExtension(string fileExtension)
        {
            string archivo = fileExtension.ToUpper();
            switch (archivo)
            {
                case "TIF":
                    return "image/tiff";
                case "GIF":
                    return "image/gif";
                case "JPG":
                    return "image/jpeg";
                case "PNG":
                    return "image/png";
                case "PDF":
                    return "application/pdf";
                case "DOC":
                    return "application/msword";
                case "DOCX":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case "XLS":
                    return "application/vnd.ms-excel";
                case "XLSX":
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
            string nuevaext = Right(archivo, archivo.Length - 1);
            return "application/" + nuevaext;
        }

        public static string Right(string str, int length)
        {
            return str.Substring(str.Length - length, length);
        }

        public static DataTable ConvertToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static bool Agregar_Firma(string pdf_inicial, string nombre, string dni, string ubicacion, string razon, string ruta_origen, string ruta_destino)
        {
            return true;
        }
    }
}
