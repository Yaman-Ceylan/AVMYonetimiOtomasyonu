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
    public class SozlesmeIslemler
    {
        string sql = string.Empty;
        MySqlConnection conn = new MySqlConnection(Database.GetConnectionString);
        MySqlCommand cmd;
        bool result = default(bool);

        public bool Ekle(int isletme, int kiraci, int mekan, int konum, string kiralikAlan, double kiraBedeli, string baslangicTarihi, string bitisTarihi)
        {
            sql = "INSERT INTO kiralananisletmeler (isletme, kiraci, mekan, konum, kiralikAlan, kiraBedeli, kiraSozlesmesiBaslangicTarihi, kiraSozlesmesiBitisTarihi) " +
                "VALUES('" + isletme + "','" + kiraci + "','" + mekan + "','" + konum + "','" + kiralikAlan + "','" + kiraBedeli + "','" + baslangicTarihi + "','" + bitisTarihi + "')";

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

        public bool Guncelle(int kiraId, int isletme, int kiraci, int mekan, int konum, string kiralikAlan, double kiraBedeli, string baslangicTarihi, string bitisTarihi)
        {
            sql = "UPDATE kiralananisletmeler " +
             "SET isletme='" + isletme + "', kiraci='" + kiraci + "', mekan='" + mekan + "', konum='" + konum + "', kiralikAlan='" + kiralikAlan + "', kiraBedeli='" + kiraBedeli + "', kiraSozlesmesiBaslangicTarihi='" + baslangicTarihi + "', kiraSozlesmesiBitisTarihi='" + bitisTarihi + "' " +
             "WHERE kiraID=" + kiraId;

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

        public bool Delete(int kiraId)
        {
            sql = "DELETE FROM kiralananisletmeler WHERE kiraID='" + kiraId + "'";

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

        public List<KiraSozlesmesi> GetSozlesmeler(params int[] paramId)
        {
            if (paramId.Length > 0)
            {
                sql = "SELECT * FROM kirasozlesmeleri WHERE kiraID='" + paramId[0] + "'";
            }
            else
            {
                sql = "SELECT * FROM kirasozlesmeleri";
            }

            List<KiraSozlesmesi> sozlesme = new List<KiraSozlesmesi>();

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
                    sozlesme.Add(new KiraSozlesmesi((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), (double)dr[6], Convert.ToDateTime(dr[7]), Convert.ToDateTime(dr[8])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!!! : " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return sozlesme;
        }

        public List<KiraSozlesmesi> GetSozlesmeByArama(string text)
        {
            sql = "SELECT * FROM kirasozlesmeleri " +
                "WHERE isletme LIKE '" + text + "%' OR kiraci LIKE '" + text + "%'";

            List<KiraSozlesmesi> sozlesme = new List<KiraSozlesmesi>();

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
                    sozlesme.Add(new KiraSozlesmesi((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), (double)dr[6], Convert.ToDateTime(dr[7]), Convert.ToDateTime(dr[8])));
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

            return sozlesme;
        }

        public List<KiraSozlesmesi> GetSozlesmelerFiltre(params string[] param)
        {
            sql = "SELECT * FROM kirasozlesmeleri " +
                "WHERE STR_TO_DATE(kiraSozlesmesiBaslangicTarihi, '%d-%m-%Y') BETWEEN '"+ param[0] + "' AND '" + param[1] + "' " +  //sorgudaki tarih formatı ayarı dış kaynaktan faydalanılarak alıntılanmıştır.
                "AND STR_TO_DATE(kiraSozlesmesiBitisTarihi, '%d-%m-%Y') NOT BETWEEN '" + param[0] + "' AND '" + param[1] + "'";

            List<KiraSozlesmesi> sozlesme = new List<KiraSozlesmesi>();

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
                    sozlesme.Add(new KiraSozlesmesi((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), (double)dr[6], Convert.ToDateTime(dr[7]), Convert.ToDateTime(dr[8])));
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

            return sozlesme;
        }
    }
}
