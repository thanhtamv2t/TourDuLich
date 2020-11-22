using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class DiaDiemModel
    {
        public int dd_id { get; set; }
        public string dd_thanhpho { get; set; }
        public string dd_ten { get; set; }
        public string dd_mota { get; set; }
        public static List<DiaDiemModel> getAll()
        {
            List<DiaDiemModel> list = new List<DiaDiemModel>();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_diadiem";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    DiaDiemModel dd = new DiaDiemModel();
                    dd.dd_id = reader.GetInt32(0);
                    dd.dd_thanhpho = reader.GetString(1);
                    dd.dd_ten = reader.GetString(2);
                    dd.dd_mota = reader.GetString(3);
                    list.Add(dd);
                }
                reader.NextResult();
            }
            return list;
        }

        public static DiaDiemModel getDetail(int id)
        {
            DiaDiemModel dd = new DiaDiemModel();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_diadiem WHERE dd_id=id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                dd.dd_id = reader.GetInt32(0);
                dd.dd_thanhpho = reader.GetString(1);
                dd.dd_ten = reader.GetString(2);
                dd.dd_mota = reader.GetString(3);
            }
            return dd;
        }

        public static void Insert(DiaDiemModel dd)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "INSERT INTO tour_diadiem(dd_thanhpho, dd_ten, dd_mota) VALUES @tp, @ten, @mota";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@tp", dd.dd_thanhpho);
            cmd.Parameters.AddWithValue("@ten", dd.dd_ten);
            cmd.Parameters.AddWithValue("@mota", dd.dd_mota);

            cmd.ExecuteNonQuery();
        }

        public static void Update(DiaDiemModel dd)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "UPDATE tour_diadiem SET dd_thanhpho =@ tp, @ten = dd_ten, @mota = dd_mota WHERE dd_id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", dd.dd_id);
            cmd.Parameters.AddWithValue("@tp", dd.dd_thanhpho);
            cmd.Parameters.AddWithValue("@ten", dd.dd_ten);
            cmd.Parameters.AddWithValue("@mota", dd.dd_mota);

            cmd.ExecuteNonQuery();
        }
    }
}

    
