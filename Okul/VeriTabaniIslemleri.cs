using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Okul
{
    internal class VeriTabaniIslemleri
    {
        string baglanticumlesi = ConfigurationManager.ConnectionStrings["vtbaglanticumlesi"].ConnectionString;

        public MySqlConnection bagla()
        {
            MySqlConnection baglanti = new MySqlConnection(baglanticumlesi);

            MySqlConnection.ClearPool(baglanti);
            return baglanti;
        }
    }
}
