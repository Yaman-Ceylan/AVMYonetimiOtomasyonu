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
    public class GelirGiderIslemler
    {
        string sql = string.Empty;
        MySqlConnection conn = new MySqlConnection(Database.GetConnectionString);
        MySqlCommand cmd;

        public List<Gelir> GetKiraGelirler(params double[] param)
        {
            if (param.Length > 0)
            {
                sql = "SELECT * FROM kiragelirleri WHERE kiraBedeli BETWEEN " + param[0] + " AND " + param[1];
            }
            else
            {
                sql = "SELECT * FROM kiragelirleri";
            }          

            List<Gelir> gelir = new List<Gelir>();

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
                    gelir.Add(new Gelir((int)dr[0], dr[1].ToString(), (double)dr[2]));                
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

            return gelir;
        }

        public List<Gider> GetPersonelGiderler(params object[] param)
        {
            if (param.Length > 0)
            {
                sql = "SELECT * FROM personelgiderleri WHERE pozisyon LIKE '%" + param[0].ToString() + "%'  AND maas BETWEEN " + (double)param[1] + " AND " + (double)param[2];
            }
            else
            {
                sql = "SELECT * FROM personelgiderleri";
            }

            List<Gider> gider = new List<Gider>();

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
                    gider.Add(new Gider(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), (double)dr[3]));
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

            return gider;
        }
    }
}
