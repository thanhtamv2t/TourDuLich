using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class ChiPhiModel
    {
        public int chiphi_id { get; set; }
        public int doan_id { get; set; }
        public Decimal chiphi_total { get; set; }
        public string chiphi_chitiet { get; set; }

        public static List<ChiPhiModel> getAll()
        {
            List<ChiPhiModel> list = new List<ChiPhiModel>();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_chiphi";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    ChiPhiModel chiphi = new ChiPhiModel();
                    chiphi.chiphi_id = reader.GetInt32(0);
                    chiphi.doan_id = reader.GetInt32(1);
                    chiphi.chiphi_total = reader.GetDecimal(2);
                    chiphi.chiphi_chitiet = reader.GetString(3);
                    list.Add(chiphi);
                }
                reader.NextResult();
            }
            return list;
        }
        public static ChiPhiModel getDetail(int id)
        {
            ChiPhiModel chiphi = new ChiPhiModel();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_chiphi WHERE chiphi_id=id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                chiphi.chiphi_id = reader.GetInt32(0);
                chiphi.doan_id = reader.GetInt32(1);
                chiphi.chiphi_total = reader.GetDecimal(2);
                chiphi.chiphi_chitiet = reader.GetString(3);
            }
            return chiphi;
        }
        public static void Insert(ChiPhiModel chiphi)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "INSERT INTO tour_chiphi(doan_id, chiphi_total, chiphi_chitiet) VALUES @doanid, @total, @chitiet";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@doanid", chiphi.doan_id);
            cmd.Parameters.AddWithValue("@total", chiphi.chiphi_total);
            cmd.Parameters.AddWithValue("@chitiet", chiphi.chiphi_chitiet);

            cmd.ExecuteNonQuery();
        }

        public static void Update(ChiPhiModel chiphi)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "UPDATE tour_chiphi SET doan_id = @doanid, chiphi_total = @total, chiphi_chitiet = @chitiet WHERE chiphi_id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", chiphi.chiphi_id);
            cmd.Parameters.AddWithValue("@doanid", chiphi.doan_id);
            cmd.Parameters.AddWithValue("@total", chiphi.chiphi_total);
            cmd.Parameters.AddWithValue("@chitiet", chiphi.chiphi_chitiet);

            cmd.ExecuteNonQuery();
        }

    }
}
