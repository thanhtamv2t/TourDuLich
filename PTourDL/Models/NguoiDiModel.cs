using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class NguoiDiModel
    {
        public int nguoidi_id { get; set; }
        public int doan_id { get; set; }
        public string nguoidi_dsnhanvien { get; set; }
        public string nguoidi_dskhach { get; set; }
        public static List<NguoiDiModel> getAll()
        {
            List<NguoiDiModel> list = new List<NguoiDiModel>();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_nguoidi";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    NguoiDiModel nguoidi = new NguoiDiModel();
                    nguoidi.nguoidi_id = reader.GetInt32(0);
                    nguoidi.doan_id = reader.GetInt32(1);
                    nguoidi.nguoidi_dsnhanvien = reader.GetString(2);
                    nguoidi.nguoidi_dskhach = reader.GetString(3);
                    list.Add(nguoidi);
                }
                reader.NextResult();
            }
            return list;
        }
        public static NguoiDiModel getDetail(int id)
        {
            NguoiDiModel nguoidi = new NguoiDiModel();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_nguoidi WHERE nguoidi_id=id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                nguoidi.nguoidi_id = reader.GetInt32(0);
                nguoidi.doan_id = reader.GetInt32(1);
                nguoidi.nguoidi_dsnhanvien = reader.GetString(2);
                nguoidi.nguoidi_dskhach = reader.GetString(3);
            }
            return nguoidi;
        }
        public static void Insert(NguoiDiModel nguoidi)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "INSERT INTO tour_nguoidi(doan_id, nguoidi_dsnhanvien, nguoidi_dskhach) VALUES @doanid, @dsnv, @dskh";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@doanid", nguoidi.doan_id);
            cmd.Parameters.AddWithValue("@dsnv", nguoidi.nguoidi_dsnhanvien);
            cmd.Parameters.AddWithValue("@dskh", nguoidi.nguoidi_dskhach);

            cmd.ExecuteNonQuery();
        }

        public static void Update(NguoiDiModel nguoidi)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "UPDATE tour_nguoidi SET doan_id = @doanid, nguoidi_dsnhanvien = @dsnv, nguoidi_dskhach = @dskh WHERE nguoidi_id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", nguoidi.nguoidi_id);
            cmd.Parameters.AddWithValue("@doanid", nguoidi.doan_id);
            cmd.Parameters.AddWithValue("@dsnv", nguoidi.nguoidi_dsnhanvien);
            cmd.Parameters.AddWithValue("@dskh", nguoidi.nguoidi_dskhach);

            cmd.ExecuteNonQuery();
        }
    }
}
