using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabani
{
    public class Baglan
    {
        SqlConnection baglanti;
        public Baglan()
        {
            if (baglanti == null ||string.IsNullOrEmpty(baglanti.ConnectionString)) 
            {
                baglanti = new SqlConnection(login.Properties.Settings.Default.BaglantiCumlesi);
            }
            
        }
        public SqlConnection BaglantiAl()
        {
            return baglanti;
        }
    }
}
