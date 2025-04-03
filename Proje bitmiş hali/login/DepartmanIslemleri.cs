using Islemler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriTabani;

namespace login
{

    internal class DepartmanIslemleri : IslemlerI
    {
        VeriTabaniYonetici _vtYon = new VeriTabaniYonetici();
        public async Task<long> EkleAsync(string sPAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(sPAdi))
            {
                sPAdi = "departman_ekleme_sp";
            }
            return await _vtYon.EkleAsync(sPAdi, p);
        }

        public async Task GuncelleAsync(string sPAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(sPAdi))
            {
                sPAdi = "departman_guncelleme_usp";
            }
            await _vtYon.SilAsync(sPAdi, p);
        }

        public async Task SilAsync(string spAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(spAdi))
            {
                spAdi = "departman_silme_usp";
            }
            await _vtYon.SilAsync(spAdi, p);
        }

        public Task<DataTable> SorgulaGetirAsync(string sPAdi, Dictionary<string, object> p)
        {
            throw new NotImplementedException();
        }

        public async Task<DataTable> TamaminiGetirAsync(string sPAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(sPAdi))
            {
                sPAdi = "departman_TamaminiGetir_sp";
            }
            return await _vtYon.SorgulaAsync(sPAdi, p);
        }

        public async Task<DataRow> TekilGetirAsync(string sPAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(sPAdi))
            {
                sPAdi = "departman_tekil_getir_sp";
            }
            return await _vtYon.TekilGetirAsync(sPAdi, p);
        }
    }
}
