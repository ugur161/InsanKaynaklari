using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islemler
{
    public interface IslemlerI
    {
        Task<long> EkleAsync(string sPAdi, Dictionary<string, object> p);
        Task SilAsync(string spAdi, Dictionary<string, object> parametreler);
        Task GuncelleAsync(string sPAdi, Dictionary<string, object> p);
        Task<DataRow> TekilGetirAsync(string sPAdi, Dictionary<string, object> p);

        Task<DataTable> TamaminiGetirAsync(string sPAdi, Dictionary<string, object> p);
        Task<DataTable> SorgulaGetirAsync(string sPAdi, Dictionary<string, object> p);



    }
}
