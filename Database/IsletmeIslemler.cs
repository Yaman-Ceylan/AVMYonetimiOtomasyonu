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
    public class IsletmeIslemler
    {
        string sql = string.Empty;
        MySqlConnection conn = new MySqlConnection(Database.GetConnectionString);
        MySqlCommand cmd;
        bool result = default(bool);

        public bool Ekle(string isletmeAdi, int mekan, string isletmeTelefon, int calisanSayisi, int konum)
        {
            sql = "INSERT INTO isletmeler (isletmeAdi, mekan, isletmeTelefon, calisanSayisi, konum) " +
                "VALUES('" + isletmeAdi + "','" + mekan + "','" + isletmeTelefon + "','" + calisanSayisi + "','" + konum + "')";

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

        public bool Guncelle(int isletmeId, string isletmeAdi, int mekan, string isletmeTelefon, int calisanSayisi, int konum)
        {
            sql = "UPDATE isletmeler " +
             "SET isletmeAdi='" + isletmeAdi + "', mekan='" + mekan + "', isletmeTelefon='" + isletmeTelefon + "', calisanSayisi='" + calisanSayisi + "', konum='" + konum + "' " +
             "WHERE isletmeID=" + isletmeId;
            
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

        public bool Delete(int isletmeId)
        {
            sql = "DELETE FROM isletmeler WHERE isletmeID=" + isletmeId;

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

        public List<Isletme> GetIsletmeler(params int[] paramId)
        {
            if (paramId.Length > 0)
            {
                sql = "SELECT * FROM isletmeyonetimi_verileri WHERE isletmeID='" + paramId[0] + "'";
            }
            else
            {
                sql = "SELECT * FROM isletmeyonetimi_verileri";
            }

            List<Isletme> isletme = new List<Isletme>();

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
                        isletme.Add(new Isletme((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), (int)dr[4], dr[5].ToString()));
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

            return isletme;
        }

        public List<Isletme> GetIsletmeByArama(string text)
        {
            sql = "SELECT isletmeID, isletmeAdi, mekanTipi, isletmeTelefon, calisanSayisi, konumAdi FROM isletmeyonetimi_verileri " +
                "WHERE isletmeAdi LIKE '" + text + "%'";

            List<Isletme> isletmeler = new List<Isletme>();

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
                    isletmeler.Add(new Isletme((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), (int)dr[4], dr[5].ToString()));
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

            return isletmeler;
        }

        public List<Isletme> GetIsletmelerFiltre(params string[] param)
        {
            sql = "SELECT * FROM isletmeyonetimi_verileri " +
                    "WHERE mekanTipi LIKE '%" + param[0] + "%'  AND konumAdi LIKE '%" + param[1] + "%'";

            List<Isletme> isletme = new List<Isletme>();

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
                        isletme.Add(new Isletme((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), (int)dr[4], dr[5].ToString()));
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

            return isletme;
        }

        public Dictionary<int, string> GetMekanlar()
        {
            sql = "SELECT mekanID, mekanTipi FROM mekanlar";
            Dictionary<int, string> mekan = new Dictionary<int, string>();

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
                    mekan.Add((int)dr[0], dr[1].ToString());
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

            return mekan;
        }

        public Dictionary<int, string> GetKonumlar()
        {
            sql = "SELECT konumID, konumAdi FROM konumlar";
            Dictionary<int, string> konum = new Dictionary<int, string>();

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
                    konum.Add((int)dr[0], dr[1].ToString());
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

            return konum;
        }
    }
}
