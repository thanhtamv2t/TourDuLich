using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class LoaiModel
    {
        public int loai_id { get; set; }
        public string loai_ten { get; set; }
        public string loai_mota { get; set; }
        public static List<LoaiModel> getAll()
        {
            List<LoaiModel> list = new List<LoaiModel>();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_loai";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiModel loai = new LoaiModel();
                    loai.loai_id = reader.GetInt32(0);
                    loai.loai_ten = reader.GetString(1);
                    loai.loai_mota = reader.GetString(2);
                    list.Add(loai);
                }
                reader.NextResult();
            }
            return list;
        }
        public static void Insert(LoaiModel loai)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "INSERT INTO tour_loai(loai_ten, loai_mota) VALUES @ten, @mota";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ten", loai.loai_ten);
            cmd.Parameters.AddWithValue("@mota", loai.loai_mota);

            cmd.ExecuteNonQuery();
        }

        public static void Update(LoaiModel loai)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "UPDATE tour_loai SET loai_ten = @ten, loai_mota = @mota WHERE loai_id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", loai.loai_id);
            cmd.Parameters.AddWithValue("@ten", loai.loai_ten);
            cmd.Parameters.AddWithValue("@mota", loai.loai_mota);

            cmd.ExecuteNonQuery();
        }
    }
    
}
