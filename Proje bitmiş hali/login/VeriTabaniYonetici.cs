using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabani
{
    public class VeriTabaniYonetici
    {
        private readonly SqlConnection _baglanti;
        Baglan b;
        public VeriTabaniYonetici()
        {
            if (b == null)
            {
                b = new Baglan();
            }
            _baglanti = b.BaglantiAl();
        }

        public async Task<long> EkleAsync(string sPadi, Dictionary<string, object> parametreler)
        {
            using (SqlCommand komut = new SqlCommand(sPadi,_baglanti))
            {
                komut.CommandType = CommandType.StoredProcedure;
                ParametreleriEkle(komut, parametreler);
                SqlParameter cikisParam = new SqlParameter("@ID", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                komut.Parameters.Add(cikisParam);
                await _baglanti.OpenAsync();
                await komut.ExecuteNonQueryAsync();
                _baglanti.Close();
                long yeniID = -1;
               if (cikisParam.Value != DBNull.Value)
                {
                    yeniID = (long)cikisParam.Value;
                }
                return yeniID;
            }
        }
        public async Task SilAsync(string spA, Dictionary<string, object> p)
        {
            /*using (SqlCommand komut = new SqlCommand(sPadi, _baglanti))
             {
                 komut.CommandType = CommandType.StoredProcedure;
                 ParametreleriEkle(komut, parametreler);
                 await _baglanti.OpenAsync();
                 await komut.ExecuteNonQueryAsync();
                 _baglanti.Close();
             }*/
            /* using (SqlCommand komut = new SqlCommand())
              {
                  komut.CommandType = CommandType.StoredProcedure;
                  ParametreleriEkle(komut, parametreler);
                  await _baglanti.OpenAsync();
                  await komut.ExecuteNonQueryAsync();
                  _baglanti.Close();
              }*/
            using (SqlCommand komut = new SqlCommand(spA, _baglanti))
            {
                komut.CommandType = CommandType.StoredProcedure;
                ParametreleriEkle(komut, p);
                await _baglanti.OpenAsync();
                await komut.ExecuteNonQueryAsync();
                _baglanti.Close();
            }


        }
        public async Task GuncelleAsync(string sPadi, Dictionary<string, object> parametreler)
        {
            try
            {
                using (SqlCommand komut = new SqlCommand(sPadi, _baglanti))
                {
                    komut.CommandType = CommandType.StoredProcedure;
                    ParametreleriEkle(komut, parametreler);
                    await _baglanti.OpenAsync();
                    await komut.ExecuteNonQueryAsync();
                    _baglanti.Close();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }

        }

        public async Task<DataTable> SorgulaAsync(string sPadi, Dictionary<string, object> parametreler)
        {
            using (SqlCommand komut = new SqlCommand(sPadi, _baglanti))
            {
                komut.CommandType = CommandType.StoredProcedure;
                ParametreleriEkle(komut, parametreler);
                await _baglanti.OpenAsync();
                using (SqlDataReader okuyucu = await komut.ExecuteReaderAsync())
                {
                    DataTable dt = new DataTable();
                    dt.Load(okuyucu);
                    _baglanti.Close();
                    return dt;

                }
            }
        }
        public async Task<DataRow> TekilGetirAsync(string sPadi, Dictionary<string, object> parametreler)
        {
            using (SqlCommand komut = new SqlCommand(sPadi, _baglanti)) 
            {
                komut.CommandType = CommandType.StoredProcedure;
                ParametreleriEkle(komut, parametreler);
                await _baglanti.OpenAsync();
                using (SqlDataReader okuyucu = await komut.ExecuteReaderAsync())
                {
                    DataTable dt = new DataTable();
                    dt.Load(okuyucu);
                    _baglanti.Close();
                    return dt.Rows.Count> 0? dt.Rows[0]:null;
                    _baglanti.Close();
                }
            }
        }

        private void ParametreleriEkle(SqlCommand komut, Dictionary<string, object> parametreler)
        {
            if (parametreler != null)
            {
                foreach (var p in parametreler)
                {
                    komut.Parameters.AddWithValue(p.Key, p.Value??DBNull.Value);
                }
            }
        }


    }
}
