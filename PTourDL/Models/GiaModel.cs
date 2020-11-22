using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class GiaModel
    {
        public int gia_id { get; set; }
        public decimal gia_sotien { get; set; }
        public int tour_id { get; set; }
        public DateTime gia_tungay { get; set; }
        public DateTime gia_denngay { get; set; }
        public static List<GiaModel> getAll()
        {
            List<GiaModel> list = new List<GiaModel>();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_gia";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    GiaModel gia = new GiaModel();
                    gia.gia_id = reader.GetInt32(0);
                    gia.gia_sotien = reader.GetDecimal(1);
                    gia.tour_id = reader.GetInt32(2);
                    gia.gia_tungay = reader.GetDateTime(3);
                    gia.gia_denngay = reader.GetDateTime(4);
                    list.Add(gia);
                }
                reader.NextResult();
            }
            return list;
        }
        public static GiaModel getDetail(int id)
        {
            GiaModel gia = new GiaModel();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_gia WHERE gia_id=id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                gia.gia_id = reader.GetInt32(0);
                gia.gia_sotien = reader.GetDecimal(1);
                gia.tour_id = reader.GetInt32(2);
                gia.gia_tungay = reader.GetDateTime(3);
                gia.gia_denngay = reader.GetDateTime(4);
            }
            return gia;
        }
        public static void Insert(GiaModel gia)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "INSERT INTO tour_gia(gia_sotien, tour_id, gia_tungay, gia_denngay) VALUES @sotien, @tourid, @tungay, @denngay";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@sotien", gia.gia_sotien);
            cmd.Parameters.AddWithValue("@tourid", gia.tour_id);
            cmd.Parameters.AddWithValue("@tungay", gia.gia_tungay);
            cmd.Parameters.AddWithValue("@denngay", gia.gia_denngay);

            cmd.ExecuteNonQuery();
        }

        public static void Update(GiaModel gia)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "UPDATE tour_gia SET gia_sotien = @sotien, tour_id = @tourid, gia_tungay = @tungay, gia_denngay = @denngay WHERE gia_id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", gia.gia_id);
            cmd.Parameters.AddWithValue("@sotien", gia.gia_sotien);
            cmd.Parameters.AddWithValue("@tourid", gia.tour_id);
            cmd.Parameters.AddWithValue("@tungay", gia.gia_tungay);
            cmd.Parameters.AddWithValue("@denngay", gia.gia_denngay);

            cmd.ExecuteNonQuery();
        }
    }
}
