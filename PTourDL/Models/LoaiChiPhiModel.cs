using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class LoaiChiPhiModel
    {
        public int cp_id { get; set; }
        public string cp_ten { get; set; }
        public string cp_mota { get; set; }

        public static List<LoaiChiPhiModel> getAll()
        {
            List<LoaiChiPhiModel> list = new List<LoaiChiPhiModel>();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_loaichiphi";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiChiPhiModel cp = new LoaiChiPhiModel();
                    cp.cp_id = reader.GetInt32(0);
                    cp.cp_ten = reader.GetString(1);
                    cp.cp_mota = reader.GetString(2);
                    list.Add(cp);
                }
                reader.NextResult();
            }
            return list;
        }
        public static void Insert(LoaiChiPhiModel cp)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "INSERT INTO tour_loaichiphi(cp_ten, cp_mota) VALUES @ten, @mota";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ten", cp.cp_ten);
            cmd.Parameters.AddWithValue("@mota", cp.cp_mota);

            cmd.ExecuteNonQuery();
        }

        public static void Update(LoaiChiPhiModel cp)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "UPDATE tour_loaichiphi SET cp_ten = @ten, cp_mota = @mota WHERE cp_id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", cp.cp_id);
            cmd.Parameters.AddWithValue("@doanid", cp.cp_ten);
            cmd.Parameters.AddWithValue("@dsnv", cp.cp_mota);

            cmd.ExecuteNonQuery();
        }
    }
}
