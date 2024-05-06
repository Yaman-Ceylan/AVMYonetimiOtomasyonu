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
    public class PersonelIslemler
    {
        string sql = string.Empty;
        MySqlConnection conn = new MySqlConnection(Database.GetConnectionString);
        MySqlCommand cmd;
        bool result = default(bool);

        public bool Ekle(string personelTC, string personelAdi, string personelSoyadi, string cinsiyet, string telefon, string eposta, string adres, int pozisyon, double maas)
        {
            sql = "INSERT INTO personeller " +
                "VALUES('" + personelTC + "','" + personelAdi + "','" + personelSoyadi + "','" + cinsiyet + "','" + telefon + "','" + eposta + "','" + adres + "','" + pozisyon + "','" + maas + "')";

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd = new MySqlCommand(sql, conn);
                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }

        public bool Guncelle(string personelTC, string personelAdi, string personelSoyadi, string cinsiyet, string telefon, string eposta, string adres, int pozisyon, double maas)
        {
            sql = "UPDATE personeller " +
             "SET personelAdi='" + personelAdi + "', personelSoyadi='" + personelSoyadi + "', cinsiyet='" + cinsiyet + "', telefon='" + telefon + "', e_posta='" + eposta + "', adres='" + adres + "', pozisyon='" + pozisyon + "', maas='" + maas + "' " +
             "WHERE personel_TCNo=" + personelTC;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd = new MySqlCommand(sql, conn);
                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }

        public bool Delete(string personelTC)
        {
            sql = "DELETE FROM personeller WHERE personel_TCNo='" + personelTC + "'";

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd = new MySqlCommand(sql, conn);
                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    result = true;
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
            return result;
        }

        public List<Personel> GetPersoneller(params string[] paramId)
        {
            if (paramId.Length > 0)
            {
                sql = "SELECT * FROM personelyonetimi_verileri WHERE personel_TCNo='" + paramId[0] + "'";
            }
            else
            {
                sql = "SELECT * FROM personelyonetimi_verileri";
            }

            List<Personel> personel = new List<Personel>();

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
                    personel.Add(new Personel(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), (double)dr[8]));
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

            return personel;
        }

        public List<Personel> GetPersonelByArama(string text)
        {
            sql = "SELECT * FROM personelyonetimi_verileri " +
                "WHERE personelAdi LIKE '" + text + "%' OR personelSoyadi LIKE '" + text + "%'";

            List<Personel> personel = new List<Personel>();

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
                    personel.Add(new Personel(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), (double)dr[8]));
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

            return personel;
        }

        public List<Personel> GetPersonelByFiltre(params object[] param)
        {

            sql = "SELECT * FROM personelyonetimi_verileri " +
                "WHERE pozisyon LIKE '%" + param[0].ToString() + "%' AND cinsiyet LIKE '%" + param[1].ToString() + "%' " +
                "AND maas BETWEEN " + (double)param[2] + " AND " + (double)param[3];

            List<Personel> personel = new List<Personel>();

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
                    personel.Add(new Personel(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), (double)dr[8]));
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

            return personel;
        }              

        public int GetGuvenlikPersoneliSayisi()
        {
            sql = "SELECT count(*) FROM personeller WHERE pozisyon=6";
            int personelSayisi = default(int);

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
                    personelSayisi = Convert.ToInt32(result);
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
            return personelSayisi;
        }

        public Dictionary<int, string> GetPozisyonlar()
        {
            sql = "SELECT pozisyonID, pozisyonAdi FROM pozisyonlar";
            Dictionary<int, string> pozisyon = new Dictionary<int, string>();

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
                    pozisyon.Add((int)dr[0], dr[1].ToString());
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

            return pozisyon;
        }

        public List<string> GetCinsiyetler()
        {
            sql = "SELECT cinsiyet FROM personeller GROUP BY cinsiyet";
            List<string> cinsiyet = new List<string>();

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
                    cinsiyet.Add(dr[0].ToString());
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

            return cinsiyet;
        }
    }
}
