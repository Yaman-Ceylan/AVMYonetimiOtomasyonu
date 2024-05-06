using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using AVMYonetimiOtomasyonu.Moduller;

namespace AVMYonetimiOtomasyonu.Database
{
    public partial class KullaniciIslemler
    {
        public List<KullaniciYonetimModul> GetKullaniciYonetimiTablo(params string[] param)
        {
            if (param.Length > 0)
            {
                sql = "SELECT kullaniciID, adi, soyadi, e_posta, sifre, rolAdi FROM kullaniciyonetimi_verileri " +
                    "WHERE kullaniciID LIKE '" + param[0] + "%'  AND rolAdi LIKE '%" + param[1] + "%'";
            }
            else
            {
                sql = "SELECT kullaniciID, adi, soyadi, e_posta, sifre, rolAdi " +
                    "FROM kullaniciyonetimi_verileri";
            }

            List<KullaniciYonetimModul> kullanicilar = new List<KullaniciYonetimModul>();

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd = new MySqlCommand(sql, conn);

                object result = cmd.ExecuteScalar();
                if (result != null) 
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        kullanicilar.Add(new KullaniciYonetimModul(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return kullanicilar;
        }

        public List<KullaniciYonetimModul> GetKullaniciByArama(string text)
        {
            sql = "SELECT * FROM kullaniciyonetimi_verileri " +
                "WHERE kullaniciID LIKE '" + text + "%' OR adi LIKE '" + text + "%' OR soyadi LIKE '" + text + "%'";

            List<KullaniciYonetimModul> kullanicilar = new List<KullaniciYonetimModul>();

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    kullanicilar.Add(new KullaniciYonetimModul(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return kullanicilar;
        }

        public int GetRolIDByKullaniciID(string kullaniciId)
        {
            sql = "SELECT rol FROM kullanicilar WHERE kullaniciID='" + kullaniciId + "'";
            int rol = default(int);

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd = new MySqlCommand(sql, conn);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rol = (int)dr[0];    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return rol;
        }


    }
}
