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
    public class KiraciIslemler
    {
        string sql = string.Empty;
        MySqlConnection conn = new MySqlConnection(Database.GetConnectionString);
        MySqlCommand cmd;
        bool result = default(bool);

        public bool Ekle(string kiraciAdi, string kiraciTelefon, string kiraciEposta)
        {
            sql = "INSERT INTO kiracilar (kiraciAdi, kiraciTelefon, kiraciEposta) " +
                "VALUES('" + kiraciAdi + "','" + kiraciTelefon + "','" + kiraciEposta + "')";

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

        public bool Guncelle(int kiraciId, string kiraciAdi, string kiraciTelefon, string kiraciEposta)
        {
            sql = "UPDATE kiracilar " +
             "SET kiraciAdi='" + kiraciAdi + "', kiraciTelefon='" + kiraciTelefon + "', kiraciEposta='" + kiraciEposta + "' " +
             "WHERE kiraciID=" + kiraciId;

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

        public bool Delete(int kiraciId)
        {
            sql = "DELETE FROM kiracilar WHERE kiraciID=" + kiraciId;

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

        public List<Kiraci> GetKiracilar(params int[] paramId)
        {
            if (paramId.Length > 0)
            {
                sql = "SELECT * FROM kiracilar WHERE kiraciID='" + paramId[0] + "'";
            }
            else
            {
                sql = "SELECT * FROM kiracilar";
            }

            List<Kiraci> kiraci = new List<Kiraci>();

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
                        kiraci.Add(new Kiraci((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString()));
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

            return kiraci;
        }

        public List<Kiraci> GetKiraciByArama(string text)
        {
            sql = "SELECT * FROM kiracilar " +
                "WHERE kiraciAdi LIKE '" + text + "%'";

            List<Kiraci> kiracilar = new List<Kiraci>();

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
                    kiracilar.Add(new Kiraci((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString()));
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

            return kiracilar;
        }

        public List<Kiraci> GetKiraciFiltre(params string[] param)
        {
            sql = "SELECT * FROM kiracilar " +
                    "WHERE kiraciAdi='" + param[0] + "'";

            List<Kiraci> kiraci = new List<Kiraci>();

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
                        kiraci.Add(new Kiraci((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString()));
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

            return kiraci;
        }
    }
}
