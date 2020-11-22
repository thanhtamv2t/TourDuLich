using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class KhachHangModel
    {
        public int kh_id { get; set; }
        public string kh_ten { get; set; }
        public string kh_sdt { get; set; }
        public DateTime kh_ngaysinh { get; set; }
        public string kh_email { get; set; }
        public string kh_cmnd { get; set; }
        public static List<KhachHangModel> getAll()
        {
            List<KhachHangModel> list = new List<KhachHangModel>();

            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_khachhang";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    KhachHangModel kh = new KhachHangModel();
                    kh.kh_id = reader.GetInt32(0);
                    kh.kh_ten = reader.GetString(1);
                    kh.kh_sdt = reader.GetString(2);
                    kh.kh_ngaysinh = reader.GetDateTime(3);
                    kh.kh_email = reader.GetString(4);
                    kh.kh_cmnd = reader.GetString(5);
                    list.Add(kh);
                }

                reader.NextResult();


            }
            return list;
        }

        public static void Insert(KhachHangModel kh)

        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();

            string sql = "INSERT INTO tour_khachhang (kh_ten, kh_sdt, kh_ngaysinh, kh_email, kh_cmnd) " +
                " VALUES(@tenkh, @sdt, @ngaysinh, @email, @cmnd)";


            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@tenkh", kh.kh_ten);
            cmd.Parameters.AddWithValue("@sdt", kh.kh_sdt);
            cmd.Parameters.AddWithValue("@ngaysinh", kh.kh_ngaysinh);
            cmd.Parameters.AddWithValue("@email", kh.kh_email);
            cmd.Parameters.AddWithValue("@cmnd", kh.kh_cmnd);
            cmd.ExecuteNonQuery();
        }

        public static void Update(KhachHangModel kh)

        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();

            string sql = "UPDATE tour_khachhang SET kh_ten = @tenkh, kh_sdt = @sdt, kh_ngaysinh = @ngaysinh, kh_email = @email, kh_cmnd = @cmnd WHERE kh_id = @id";


            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", kh.kh_id);
            cmd.Parameters.AddWithValue("@tennv", kh.kh_ten);
            cmd.Parameters.AddWithValue("@sdt", kh.kh_sdt);
            cmd.Parameters.AddWithValue("@ngaysinh", kh.kh_ngaysinh);
            cmd.Parameters.AddWithValue("@email", kh.kh_email);
            cmd.Parameters.AddWithValue("@cmnd", kh.kh_cmnd);
            cmd.ExecuteNonQuery();
        }
    }
}
