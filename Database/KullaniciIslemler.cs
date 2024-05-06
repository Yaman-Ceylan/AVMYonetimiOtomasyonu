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
        string sql = string.Empty;
        MySqlConnection conn = new MySqlConnection(Database.GetConnectionString);
        MySqlCommand cmd;
        bool result = default(bool);

        public bool Ekle(string kullaniciId, string ad, string soyad, string eposta, string sifre, int rolID)
        {
            sql = "INSERT INTO kullanicilar (kullaniciID, adi, soyadi, e_posta, sifre, rol) " +
                "VALUES('" + kullaniciId + "','" + ad + "','" + soyad + "','" + eposta + "','" + sifre + "','" + rolID + "')";

            string kontrolIdSql = "SELECT * FROM kullanicilar WHERE kullaniciID='" + kullaniciId + "'";
            string kontrolEpostaSql = "SELECT * FROM kullanicilar WHERE e_posta='" + eposta + "'";
            string kontrolSifreSql = "SELECT * FROM kullanicilar WHERE sifre='" + sifre + "'";

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                MySqlCommand kontrolIdCmd = new MySqlCommand(kontrolIdSql, conn);
                MySqlDataReader drId = kontrolIdCmd.ExecuteReader();
                bool rowId = drId.Read();
                drId.Close();

                MySqlCommand kontrolEpostaCmd = new MySqlCommand(kontrolEpostaSql, conn);
                MySqlDataReader drEposta = kontrolEpostaCmd.ExecuteReader();
                bool rowEposta = drEposta.Read();
                drEposta.Close();

                MySqlCommand kontrolSifreCmd = new MySqlCommand(kontrolSifreSql, conn);
                MySqlDataReader drSifre = kontrolSifreCmd.ExecuteReader();
                bool rowSifre = drSifre.Read();
                drSifre.Close();


                if (rowId != true && rowEposta != true && rowSifre != true)
                {
                    cmd = new MySqlCommand(sql, conn);
                    int sonuc = cmd.ExecuteNonQuery();

                    if (sonuc > 0)
                    {
                        result = true;
                    }
                }
                else if (rowId)
                {
                    MessageBox.Show("Bu Kullanıcı ID Başka Bir Kullanıcı Tarafından Kullanılıyor.");
                }
                else if (rowEposta)
                {
                    MessageBox.Show("Bu E-Posta Zaten Sisteme Kayıtlı.");
                }
                else if (rowSifre)
                {
                    MessageBox.Show("Bu Şifre Başka Bir Kullanıcı Tarafından Kullanılıyor.");
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

        public bool Guncelle(string mevcutId, string mevcutEposta, string mevcutSifre, string kullaniciId, string ad, string soyad, string eposta, string sifre, int rolID)
        {
            sql = "UPDATE kullanicilar " +
             "SET kullaniciID='" + kullaniciId + "', adi='" + ad + "', soyadi='" + soyad + "', e_posta='" + eposta + "', sifre='" + sifre + "', rol='" + rolID + "' " +
             "WHERE kullaniciID='" + mevcutId + "'";

            string kontrolIdSql = "SELECT * FROM kullanicilar WHERE kullaniciID='" + kullaniciId + "'";
            string kontrolEpostaSql = "SELECT * FROM kullanicilar WHERE e_posta='" + eposta + "'";
            string kontrolSifreSql = "SELECT * FROM kullanicilar WHERE sifre='" + sifre + "'";

            bool rowId = default(bool);
            bool rowEposta = default(bool);
            bool rowSifre = default(bool);

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                if (mevcutId != kullaniciId)
                {
                    MySqlCommand kontrolIdCmd = new MySqlCommand(kontrolIdSql, conn);
                    MySqlDataReader drId = kontrolIdCmd.ExecuteReader();
                    rowId = drId.Read();
                    drId.Close();
                }

                if (mevcutEposta != eposta)
                {
                    MySqlCommand kontrolEpostaCmd = new MySqlCommand(kontrolEpostaSql, conn);
                    MySqlDataReader drEposta = kontrolEpostaCmd.ExecuteReader();
                    rowEposta = drEposta.Read();
                    drEposta.Close();
                }

                if (mevcutSifre != sifre)
                {
                    MySqlCommand kontrolSifreCmd = new MySqlCommand(kontrolSifreSql, conn);
                    MySqlDataReader drSifre = kontrolSifreCmd.ExecuteReader();
                    rowSifre = drSifre.Read();
                    drSifre.Close();
                }

                if (rowId != true && rowEposta != true && rowSifre != true)
                {
                    cmd = new MySqlCommand(sql, conn);
                    int sonuc = cmd.ExecuteNonQuery();

                    if (sonuc > 0)
                    {
                        result = true;
                    }
                }
                else if (rowId)
                {
                    MessageBox.Show("Bu Kullanıcı ID Başka Bir Kullanıcı Tarafından Kullanılıyor.");
                }
                else if (rowEposta)
                {
                    MessageBox.Show("Bu E-Posta Zaten Sisteme Kayıtlı.");
                }
                else if (rowSifre)
                {
                    MessageBox.Show("Bu Şifre Başka Bir Kullanıcı Tarafından Kullanılıyor.");
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

        public bool Delete(string kullaniciId)
        {
            sql = "DELETE FROM kullanicilar WHERE kullaniciID='" + kullaniciId + "'";

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

        public bool GirisKontrol(string kullaniciId, string sifre)
        {
            sql = "SELECT * FROM kullanicilar WHERE kullaniciID='" + kullaniciId + "' AND sifre='" + sifre + "'";
            string kontrolIdSql = "SELECT * FROM kullanicilar WHERE kullaniciID='" + kullaniciId + "'";

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                MySqlCommand kontrolIdCmd = new MySqlCommand(kontrolIdSql, conn);
                MySqlDataReader drId = kontrolIdCmd.ExecuteReader();
                bool rowId = drId.Read();
                drId.Close();

                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader drSifre = cmd.ExecuteReader();
                bool rowSifre = drSifre.Read();
                drSifre.Close();
                //Kullanıcı ID kontrolü..
                if (rowId)
                {
                    //Şifre uyumu kontrolü..
                    if (rowSifre)
                    {
                        result = true;
                    }
                    else
                    {
                        MessageBox.Show("Yanlış Şifre.");
                    }
                }
                else
                {
                    MessageBox.Show("Böyle Bir Kullanıcı Kaydı Bulunamadı, Kullanıcı ID Hatalı.");
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

        public List<Kullanici> GetKullanicilar(params string[] paramId)
        {
            if (paramId.Length > 0)
            {
                sql = "SELECT * FROM kullanicilar WHERE kullaniciID='" + paramId[0] + "'";
            }
            else
            {
                sql = "SELECT * FROM kullanicilar";
            }
            
            List<Kullanici> kullanici = new List<Kullanici>();

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
                        kullanici.Add(new Kullanici(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), (int)dr[5]));
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

            return kullanici;
        }

        public Dictionary<int, string> GetRoller()
        {
            sql = "SELECT rolID, rolAdi FROM roller";
            Dictionary<int, string> rol = new Dictionary<int, string>();

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
                    rol.Add((int)dr[0], dr[1].ToString());
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
