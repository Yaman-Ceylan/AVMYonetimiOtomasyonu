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
    public class GuvenlikYonetimiIslemler
    {
        string sql = string.Empty;
        MySqlConnection conn = new MySqlConnection(Database.GetConnectionString);
        MySqlCommand cmd;
        bool result = default(bool);

        public bool Ekle(string kameraTipi, int konum)
        {
            sql = "INSERT INTO guvenlikkameralari (kameraTipi, konum) " +
                "VALUES('" + kameraTipi + "','" + konum + "')";

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

        public bool Guncelle(int kameraId, string kameraTipi, int konum)
        {
            sql = "UPDATE guvenlikkameralari " +
             "SET kameraTipi='" + kameraTipi + "', konum='" + konum + "' " +
             "WHERE kameraID=" + kameraId;

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

        public bool Delete(int kameraId)
        {
            sql = "DELETE FROM guvenlikkameralari WHERE kameraID=" + kameraId;

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

        public List<GuvenlikKamerası> GetKameralar(params int[] paramId)
        {
            if (paramId.Length > 0)
            {
                sql = "SELECT * FROM guvenlikyonetimi_verileri WHERE kameraID='" + paramId[0] + "'";
            }
            else
            {
                sql = "SELECT * FROM guvenlikyonetimi_verileri";
            }

            List<GuvenlikKamerası> kamera = new List<GuvenlikKamerası>();

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
                        kamera.Add(new GuvenlikKamerası((int)dr[0], dr[1].ToString(), dr[2].ToString()));
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

            return kamera;
        }

        public List<GuvenlikKamerası> GetKameraByArama(string text)
        {
            sql = "SELECT * FROM guvenlikyonetimi_verileri " +
                "WHERE kameraTipi LIKE '" + text + "%'";

            List<GuvenlikKamerası> kamera = new List<GuvenlikKamerası>();

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
                    kamera.Add(new GuvenlikKamerası((int)dr[0], dr[1].ToString(), dr[2].ToString()));
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

            return kamera;
        }

        public List<GuvenlikKamerası> GetKameraFiltre(params string[] param)
        {
            if (param.Length > 0)
            {
                sql = "SELECT * FROM guvenlikyonetimi_verileri " +
                    "WHERE konumAdi LIKE '%" + param[0] + "%'";
            }
            else
            {
                sql = "SELECT * FROM guvenlikyonetimi_verileri";
            }

            List<GuvenlikKamerası> kamera = new List<GuvenlikKamerası>();

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
                        kamera.Add(new GuvenlikKamerası((int)dr[0], dr[1].ToString(), dr[2].ToString()));
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

            return kamera;
        }
    }
}
