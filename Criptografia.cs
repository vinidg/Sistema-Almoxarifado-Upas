using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoUpas
{
    public class Criptografia
    {
        /// <summary>
        /// Pegar App.config ou Web.config
        /// </summary>
        /// <returns></returns>
        public string DecryptConnectionString()
        {
            Byte[] b = Convert.FromBase64String(ConfigurationSettings.AppSettings["ConnectionString"]);
            string decryptedConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return decryptedConnectionString;
        }

        /// <summary>
        /// Encripta a string da conexao
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public string EncryptConnectionString(string connectionString)
        {
            Configuration
        }


    }
}
