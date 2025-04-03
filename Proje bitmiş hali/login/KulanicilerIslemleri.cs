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
    public class KulanicilerIslemleri : IslemlerI
    {
        VeriTabaniYonetici _vtYon = new VeriTabaniYonetici();
        public async Task<long> EkleAsync(string sPAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(sPAdi))
            {
                sPAdi = "kulanıcılar_ekleme_sp";
            }
            return await _vtYon.EkleAsync(sPAdi, p);
        }

        public async Task GuncelleAsync(string sPAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(sPAdi))
            {
                sPAdi = "kulanıcılar_güncelle_sp";
            }
            await _vtYon.GuncelleAsync(sPAdi, p);
        }

        public async Task SilAsync(string sPAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(sPAdi))
            {
                sPAdi = "kulanıcılar_silme_sp";
            }
              await _vtYon.SilAsync(sPAdi, p);
        }

        public Task<DataTable> SorgulaGetirAsync(string sPAdi, Dictionary<string, object> p)
        {
            throw new NotImplementedException();
        }

        public async Task<DataTable> TamaminiGetirAsync(string sPAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(sPAdi))
            {
                sPAdi = "kulanıcı_TamaminiGetir_sp";
            }
            return await _vtYon.SorgulaAsync(sPAdi, p);
        }

        public async Task<DataRow> TekilGetirAsync(string sPAdi, Dictionary<string, object> p)
        {
            if (string.IsNullOrEmpty(sPAdi))
            {
                sPAdi = "kulanıcı_tekil_getir_sp";
            }
            return await _vtYon.TekilGetirAsync(sPAdi, p);
        }
    }
}
