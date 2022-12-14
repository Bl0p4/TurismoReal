using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace TurismoRealWeb.BLL
{
    public class TR_Recursos
    {
        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            //Usar referencia System.Security.Cryptography;
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));                        
            }

            return Sb.ToString();
        }        

    }
}
